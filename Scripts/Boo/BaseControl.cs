using System;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class BaseControl : MonoBehaviour
{
	public string namae;

	public EnumElements defZokusei;

	public bool superArmor;

	public bool noDamage;

	public bool noHitAttack;

	private bool _pause;

	private Vector3 _knockBack;

	private HitPointContainer hitPointContainer;

	private float updateDeltaTime;

	private float fixedUpdateDeltaTime;

	[NonSerialized]
	private static List<BaseControl> allControlCache = new List<BaseControl>();

	[NonSerialized]
	private static BaseControl[] arrayedAllControlCache = new BaseControl[0];

	public override string CharacterName => namae;

	public bool Pause
	{
		get
		{
			return _pause;
		}
		set
		{
			_pause = value;
			if (_pause)
			{
				doPause();
			}
			else
			{
				doUnpause();
			}
		}
	}

	public Vector3 KnockBack
	{
		get
		{
			return _knockBack;
		}
		set
		{
			_knockBack = value;
		}
	}

	public bool IsAlive => hitPointContainer.Current > 0f;

	public bool IsDead => !IsAlive;

	public float HitPoint
	{
		get
		{
			return hitPointContainer.Current;
		}
		set
		{
			if (!noDamage)
			{
				hitPointContainer.Current = value;
			}
		}
	}

	public float HitPointRate => hitPointContainer.Current / hitPointContainer.Max;

	public float MaxHitPoint
	{
		get
		{
			return hitPointContainer.Max;
		}
		set
		{
			hitPointContainer.Max = value;
		}
	}

	protected float TranslationRateInFixedUpdate => (updateDeltaTime > 0f) ? (fixedUpdateDeltaTime / updateDeltaTime) : 0f;

	public static BaseControl[] AllControls => arrayedAllControlCache;

	public bool IsSidePlayer => getSideIndex() == 0;

	public bool IsSideEnemy => getSideIndex() == 1;

	public float UpdateDeltaTime => updateDeltaTime;

	public float FixedUpdateDeltaTime => fixedUpdateDeltaTime;

	public BaseControl()
	{
		hitPointContainer = new HitPointContainer();
	}

	protected virtual void doPause()
	{
	}

	protected virtual void doUnpause()
	{
	}

	public virtual void HitAttack(int damage, YarareTypes yarare, GameObject attackChar)
	{
	}

	public virtual void OnDestroy()
	{
		hitPointContainer.discard();
	}

	public float getHitPointRate()
	{
		return HitPoint / MaxHitPoint;
	}

	public void setHitPointMax()
	{
		HitPoint = MaxHitPoint;
	}

	public void setHitPointAndHitPointMax(float d)
	{
		MaxHitPoint = d;
		HitPoint = d;
	}

	public void forceSetHitPoint(int hp)
	{
		hitPointContainer.Current = hp;
	}

	public void addHitPoint(float n)
	{
		HitPoint += n;
		HitPoint = Mathf.Clamp(HitPoint, 0f, MaxHitPoint);
	}

	public virtual void decHP(float damage)
	{
		HitPoint -= damage;
		HitPoint = Mathf.Clamp(HitPoint, 0f, MaxHitPoint);
	}

	public virtual void addHP(float hp)
	{
		addHitPoint(hp);
	}

	public virtual void OnEnable()
	{
		ShadowSelector.Setup(gameObject);
		if (!allControlCache.Contains(this))
		{
			allControlCache.Add(this);
			arrayedAllControlCache = (BaseControl[])Builtins.array(typeof(BaseControl), allControlCache);
		}
	}

	public virtual void OnDisable()
	{
		allControlCache.Remove(this);
		arrayedAllControlCache = (BaseControl[])Builtins.array(typeof(BaseControl), allControlCache);
	}

	public virtual void Update()
	{
		if (!_pause)
		{
			updateDeltaTime = Time.deltaTime;
		}
	}

	public virtual void FixedUpdate()
	{
		if (!_pause)
		{
			fixedUpdateDeltaTime = Time.deltaTime;
		}
	}

	public virtual void LateUpdate()
	{
		if (!_pause)
		{
		}
	}

	public static int CollectPlayerSideChars(BaseControl[] chary, int capa)
	{
		return Collect(chary, capa, (BaseControl c) => c.IsSidePlayer);
	}

	public static int CollectEnemySideChars(BaseControl[] chary, int capa)
	{
		return Collect(chary, capa, (BaseControl c) => c.IsSideEnemy);
	}

	private static int Collect(BaseControl[] chary, int capa, __BaseControl_Collect_0024callable56_0024146_78__ pred)
	{
		checked
		{
			int result;
			if (chary == null || pred == null)
			{
				result = 0;
			}
			else
			{
				int num = Mathf.Min(capa, chary.Length);
				int num2 = 0;
				int i = 0;
				BaseControl[] allControls = AllControls;
				for (int length = allControls.Length; i < length; i++)
				{
					if (pred(allControls[i]))
					{
						chary[RuntimeServices.NormalizeArrayIndex(chary, num2)] = allControls[i];
						num2++;
					}
				}
				result = num2;
			}
			return result;
		}
	}

	public void playSE(SQEX_SoundPlayerData.SE se)
	{
		if (se != SQEX_SoundPlayerData.SE.NONE)
		{
			SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
			if (instance != null)
			{
				instance.PlaySe((int)se, 0, gameObject.GetInstanceID());
			}
		}
	}

	public void playSE(string seName)
	{
		if (!string.IsNullOrEmpty(seName))
		{
			SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
			if (instance != null)
			{
				instance.PlaySe(seName, 0, gameObject.GetInstanceID());
			}
		}
	}

	private int getSideIndex()
	{
		int result;
		if (!(this is AIControl))
		{
			result = ((!(this is PlayerControl)) ? (-1) : 0);
		}
		else
		{
			AIControl aIControl = this as AIControl;
			result = ((aIControl.IsColosseumSetup ? (!aIControl.IsPlayer) : (!(aIControl.MagicSkillComponent != null))) ? 1 : 0);
		}
		return result;
	}

	internal static bool _0024CollectPlayerSideChars_0024closure_00242869(BaseControl c)
	{
		return c.IsSidePlayer;
	}

	internal static bool _0024CollectEnemySideChars_0024closure_00242870(BaseControl c)
	{
		return c.IsSideEnemy;
	}
}
