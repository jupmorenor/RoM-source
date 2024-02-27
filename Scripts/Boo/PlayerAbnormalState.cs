using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class PlayerAbnormalState
{
	[Serializable]
	public enum EmitSources
	{
		Player,
		Poppets
	}

	[Serializable]
	public enum EmitConditions
	{
		Any,
		IfPlayer,
		IfPoppet
	}

	public EnumAbnormalStates _type;

	private float aliveTime;

	private float elapsedTime;

	private MAbnormalStateParameters stateData;

	private Boo.Lang.List<GameObject> effects;

	private bool motionPlayed;

	private bool isDead;

	public EnumAbnormalStates Type => _type;

	public bool IsDead => isDead;

	public float AliveTime
	{
		get
		{
			return aliveTime;
		}
		set
		{
			aliveTime = value;
		}
	}

	public float ElapsedTime
	{
		get
		{
			return elapsedTime;
		}
		set
		{
			elapsedTime = value;
		}
	}

	public MAbnormalStateParameters StateData => stateData;

	public PlayerAbnormalState(EnumAbnormalStates type, CharSetupTypes setupType)
	{
		effects = new Boo.Lang.List<GameObject>();
		_type = type;
		stateData = MAbnormalStateParameters.Find(_type, (int)setupType);
		if (stateData == null)
		{
			throw new AssertionFailedException(new StringBuilder().Append(_type).Append("/").Append(setupType)
				.Append("に対応するマスターMAbnormalStateParametersがない")
				.ToString());
		}
		init();
	}

	public void init()
	{
		aliveTime = stateData.Time;
		elapsedTime = 0f;
		isDead = false;
		motionPlayed = false;
		doInit();
	}

	public void update(MerlinActionControl actCntrl, float dt, PlayerAbnormalStateControl.StateParams @params)
	{
		elapsedTime += dt;
		doUpdate(actCntrl, dt);
		emitEffect(actCntrl);
		if (!(elapsedTime < aliveTime))
		{
			kill();
			playStateEndSound(actCntrl);
		}
	}

	public void kill()
	{
		isDead = true;
		destroyEffect();
		doKill();
	}

	private void emitEffect(MerlinActionControl actCntrl)
	{
		if (((ICollection)effects).Count > 0 || !stateData.HasPrefab)
		{
			return;
		}
		PlayerControl playerControl = actCntrl as PlayerControl;
		AIControl aIControl = actCntrl as AIControl;
		switch ((EmitConditions)stateData.EmitCond)
		{
		case EmitConditions.IfPlayer:
			if (playerControl == null)
			{
				return;
			}
			break;
		case EmitConditions.IfPoppet:
			if (aIControl == null)
			{
				return;
			}
			break;
		}
		string prefabName = stateData.Prefab;
		if (aIControl != null && !string.IsNullOrEmpty(stateData.MonsterPrefab))
		{
			prefabName = stateData.MonsterPrefab;
		}
		if (stateData.EmitSource == 0)
		{
			emitEffect(prefabName, actCntrl.transform, stateData.ParentBone);
		}
		else
		{
			if (!(playerControl != null) || playerControl.PoppetNum <= 0)
			{
				return;
			}
			int i = 0;
			AIControl[] poppets = playerControl.Poppets;
			for (int length = poppets.Length; i < length; i = checked(i + 1))
			{
				if (!(poppets[i] != null))
				{
					emitEffect(stateData.Prefab, poppets[i].transform, stateData.ParentBone);
				}
			}
		}
	}

	private void emitEffect(string prefabName, Transform ch, string boneName)
	{
		MasterEffectPack instance = MasterEffectPack.Instance;
		GameObject gameObject = instance.findAndInstantiate(prefabName);
		if (gameObject != null)
		{
			Attach(gameObject, ch, boneName);
			effects.Add(gameObject);
		}
	}

	public void playerChanged(MerlinActionControl ownedControl)
	{
		if (ownedControl == null)
		{
			return;
		}
		Transform transform = ownedControl.transform;
		IEnumerator<GameObject> enumerator = effects.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				GameObject current = enumerator.Current;
				if (!(current == null))
				{
					Transform root = current.transform.root;
					if (root == ownedControl.transform)
					{
						Attach(current, transform, stateData.ParentBone);
					}
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	private static void Attach(GameObject eff, Transform ch, string boneName)
	{
		if (!(eff == null) && !(ch == null))
		{
			Transform parent = ch;
			Transform transform = ExtensionsModule.FindInActiveDescendants(ch, boneName);
			if (transform != null)
			{
				parent = transform;
			}
			eff.transform.parent = parent;
			eff.transform.localPosition = Vector3.zero;
			eff.transform.localRotation = Quaternion.identity;
		}
	}

	private void destroyEffect()
	{
		Boo.Lang.List<GameObject> list = effects;
		int count = ((ICollection)list).Count;
		int num = 0;
		while (num < count)
		{
			GameObject gameObject = list[checked(num++)];
			if (gameObject != null)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
		effects.Clear();
	}

	protected virtual void doInit()
	{
	}

	protected virtual void doUpdate(MerlinActionControl actCntrl, float dt)
	{
	}

	protected virtual void doKill()
	{
	}

	private void playStateEndSound(MerlinActionControl actCntrl)
	{
		if (actCntrl != null)
		{
			actCntrl.playSE(SQEX_SoundPlayerData.SE.state_end);
		}
	}

	public override string ToString()
	{
		return new StringBuilder().Append(GetType()).Append(" type:").Append(_type)
			.Append(" time:")
			.Append(elapsedTime)
			.Append("/")
			.Append(aliveTime)
			.Append("\n MAbnormalStates:")
			.Append(stateData)
			.ToString();
	}
}
