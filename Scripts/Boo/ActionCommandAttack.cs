using System;
using System.Collections.Generic;
using Boo.Lang;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class ActionCommandAttack : MerlinActionControl.ActTimeCommand
{
	[Serializable]
	private class HitInfo
	{
		public int count;

		public float timer;
	}

	[Serializable]
	public class AbnormalStateInfo
	{
		public EnumAbnormalStates effect;

		public int rate;

		public int power;

		public AbnormalStateInfo(EnumAbnormalStates _effect, int _rate, int _power)
		{
			effect = EnumAbnormalStates.None;
			power = 100;
			effect = _effect;
			rate = _rate;
			power = _power;
		}
	}

	[NonSerialized]
	public const int DEFAULT_ABSTAT_INFECTION_POWER = 100;

	public bool once;

	public float knockBackPow;

	public int damage;

	public YarareTypes yarareType;

	public bool invalidSuperArmor;

	public int hitCountLimit;

	public float hitInterval;

	public GameObject hitEffect;

	public NageInfo nageInfo;

	public float breakPow;

	public string hitSE;

	public RespPoppet chainSkillPoppet;

	public bool guardCancel;

	private Boo.Lang.List<AbnormalStateInfo> abnormalStateInfoList;

	public float recoveryRate;

	public float useChainPoppetAttack;

	private RespWeapon origin;

	private EnumElements originElement;

	public float criticalRate;

	protected Collider[] colliders;

	private MerlinAttackCommandHolder holder;

	private bool hit;

	private int invalidSuperArmorAttackers;

	private int invalidSuperArmorDefensers;

	private Dictionary<object, HitInfo> hitInfos;

	public EnumElements OriginElement => (originElement != 0) ? originElement : ((origin != null) ? ((EnumElements)origin.ElementId) : ((EnumElements)0));

	public bool IsChainSkill => chainSkillPoppet != null;

	public bool HasAbnormalEffect
	{
		get
		{
			bool num = abnormalStateInfoList != null;
			if (num)
			{
				num = abnormalStateInfoList.Count > 0;
			}
			return num;
		}
	}

	public bool HasRecoveryRate => recoveryRate > 0f;

	public RespWeapon OriginWeapon => origin;

	public Collider[] Colliders => colliders;

	public MerlinAttackCommandHolder Holder => holder;

	public int InvalidSuperArmorAttackers
	{
		get
		{
			return invalidSuperArmorAttackers;
		}
		set
		{
			invalidSuperArmorAttackers = value;
		}
	}

	public int InvalidSuperArmorDefensers
	{
		get
		{
			return invalidSuperArmorDefensers;
		}
		set
		{
			invalidSuperArmorDefensers = value;
		}
	}

	public ActionCommandAttack(Collider[] _collider)
	{
		hitCountLimit = int.MaxValue;
		nageInfo = new NageInfo();
		breakPow = 1f;
		criticalRate = 1f;
		hitInfos = new Dictionary<object, HitInfo>();
		if (_collider == null)
		{
			colliders = new Collider[0];
			return;
		}
		colliders = Gen_array_macrosModule.GenArray<Collider, Collider>(_collider, (__MerlinActionCommandAttack_0024callable325_0024100_22__)((Collider _0024genarray_00241206) => _0024genarray_00241206), (__MerlinActionCommandAttack_0024callable326_0024100_22__)((Collider _0024genarray_00241206) => _0024genarray_00241206 != null));
	}

	public void setOrigin(RespWeapon org)
	{
		origin = org;
		originElement = (EnumElements)0;
	}

	public void setOriginElement(EnumElements elm)
	{
		origin = null;
		originElement = elm;
	}

	public override void doInit()
	{
		if (parent != null)
		{
			parent.setActionType(ActionTypes.Attack);
		}
	}

	public override bool doStart()
	{
		activateAttack(b: true);
		return true;
	}

	public override bool doMain()
	{
		return true;
	}

	public override bool doEnd()
	{
		activateAttack(b: false);
		return true;
	}

	public override void doUpdateInTime()
	{
		if (!once && !(hitInterval <= 0f))
		{
			updateHitInfo();
		}
	}

	public override void doUpdateAllTime()
	{
	}

	public override void doDispose()
	{
		activateAttack(b: false);
	}

	private void activateAttack(bool b)
	{
		int i = 0;
		Collider[] array = colliders;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if (array[i] != null)
				{
					array[i].enabled = b;
					continue;
				}
				return;
			}
			if (holder == null && colliders.Length > 0)
			{
				int j = 0;
				Collider[] array2 = colliders;
				for (int length2 = array2.Length; j < length2; j++)
				{
					holder = ExtensionsModule.SetComponent<MerlinAttackCommandHolder>(colliders[0].gameObject);
					holder.Command = this;
				}
			}
		}
	}

	public virtual bool canHit(object obj)
	{
		int result;
		checked
		{
			if (obj == null || hit)
			{
				result = 0;
			}
			else if (once)
			{
				hit = true;
				result = 1;
			}
			else
			{
				HitInfo value = null;
				if (!hitInfos.TryGetValue(obj, out value))
				{
					value = new HitInfo();
					hitInfos[obj] = value;
				}
				if (value.count >= hitCountLimit || !(value.timer <= 0f))
				{
					result = 0;
				}
				else
				{
					value.count++;
					value.timer = hitInterval;
					result = 1;
				}
			}
		}
		return (byte)result != 0;
	}

	public bool cannotHitAnyMore()
	{
		return hit;
	}

	private void updateHitInfo()
	{
		foreach (HitInfo value in hitInfos.Values)
		{
			value.timer -= UpdateDeltaTime;
		}
	}

	public void playHitSE()
	{
		if (!string.IsNullOrEmpty(hitSE))
		{
			SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
			if (instance != null)
			{
				instance.PlaySe(hitSE, 0, ParentGameObject.GetInstanceID());
			}
		}
	}

	public void addAbnormalStateEffect(EnumAbnormalStates effect, int rate, int power)
	{
		if (abnormalStateInfoList == null)
		{
			abnormalStateInfoList = new Boo.Lang.List<AbnormalStateInfo>();
		}
		abnormalStateInfoList.Add(new AbnormalStateInfo(effect, rate, power));
	}

	public void enumerateAbnormalState(__ActionCommandAttack_enumerateAbnormalState_0024callable51_0024208_45__ c)
	{
		if (abnormalStateInfoList == null || c == null)
		{
			return;
		}
		IEnumerator<AbnormalStateInfo> enumerator = abnormalStateInfoList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				AbnormalStateInfo current = enumerator.Current;
				c(current);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	internal Collider _0024constructor_0024closure_00243837(Collider _0024genarray_00241206)
	{
		return _0024genarray_00241206;
	}

	internal bool _0024constructor_0024closure_00243838(Collider _0024genarray_00241206)
	{
		return _0024genarray_00241206 != null;
	}
}
