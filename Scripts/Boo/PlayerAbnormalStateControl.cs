using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class PlayerAbnormalStateControl
{
	[Serializable]
	public class StateParams
	{
		public float speed;

		public float decLife;

		public float attack;

		public float damage;

		public float size;

		public float motionSpeed;

		public bool disableMove;

		public bool disableAttack;

		public bool disableChain;

		public bool disableSkill;

		public bool anger;

		public StateParams()
		{
			clearAll();
		}

		public void clearForUpdate()
		{
			speed = 1f;
			decLife = 0f;
			attack = 1f;
			damage = 1f;
			size = 1f;
			motionSpeed = 1f;
			disableMove = false;
			disableAttack = false;
			disableChain = false;
			disableSkill = false;
			anger = false;
		}

		public void clearAll()
		{
			clearForUpdate();
		}

		public void updateParams(MAbnormalStateParameters sd, MerlinActionControl actCntrl)
		{
			if (sd != null && !(actCntrl == null))
			{
				speed *= (float)sd.Speed / 100f;
				decLife += (float)sd.DecLife / 100f * actCntrl.MaxHitPoint / sd.Time;
				attack *= (float)sd.Attack / 100f;
				damage *= (float)sd.Damage / 100f;
				size *= (float)sd.Size / 100f;
				motionSpeed *= (float)sd.MotionSpeed / 100f;
				if (sd.DisableMove)
				{
					disableMove = true;
				}
				if (sd.DisableAttack)
				{
					disableAttack = true;
				}
				if (sd.DisableChain)
				{
					disableChain = true;
				}
				if (sd.DisableSkill)
				{
					disableSkill = true;
				}
				anger = sd.Anger;
			}
		}

		public void updateStatus(PlayerControl player, MerlinActionControl actCntrl, float dt, Vector3 defaultGameObjectScale)
		{
			if (!(player == null) && !(player == actCntrl))
			{
				throw new AssertionFailedException("(player == null) or (player == actCntrl)");
			}
			if (actCntrl == null)
			{
				return;
			}
			speed = Mathf.Max(0f, speed);
			attack = Mathf.Max(0f, attack);
			damage = Mathf.Max(0f, damage);
			size = Mathf.Max(0f, size);
			if (!actCntrl.IsDead && !(decLife <= 0f) && !ChainSkillRoutine.IsPlaying)
			{
				actCntrl.decHP(decLife * dt);
			}
			actCntrl.TemporalMotionSpeedScale = motionSpeed;
			if (!(player != null))
			{
				return;
			}
			int i = 0;
			AIControl[] poppets = player.Poppets;
			for (int length = poppets.Length; i < length; i = checked(i + 1))
			{
				if ((bool)poppets[i])
				{
					poppets[i].setAttackSide(!anger);
				}
			}
		}

		public void updatePlayerHUD()
		{
			bool num = anger;
			if (!num)
			{
				num = disableChain;
			}
			BattleHUDMappet.EnableBadIcon(num);
			BattleHUDSkill.EnableSkillBadIcon(0, disableSkill);
			BattleHUDSkill.EnableSkillBadIcon(1, disableSkill);
			BattleHUDSkill.EnableSkillBadIcon(2, disableSkill);
		}
	}

	[Serializable]
	internal class _0024hasAbnormalState_0024locals_002414352
	{
		internal EnumAbnormalStates _0024sid;
	}

	[Serializable]
	internal class _0024enable_0024locals_002414353
	{
		internal EnumAbnormalStates _0024sid;
	}

	[Serializable]
	internal class _0024hasAbnormalState_0024closure_00244022
	{
		internal _0024hasAbnormalState_0024locals_002414352 _0024_0024locals_002414819;

		public _0024hasAbnormalState_0024closure_00244022(_0024hasAbnormalState_0024locals_002414352 _0024_0024locals_002414819)
		{
			this._0024_0024locals_002414819 = _0024_0024locals_002414819;
		}

		public bool Invoke(PlayerAbnormalState s)
		{
			bool num = s != null;
			if (num)
			{
				num = s.Type == _0024_0024locals_002414819._0024sid;
			}
			return num;
		}
	}

	[Serializable]
	internal class _0024enable_0024closure_00244027
	{
		internal _0024enable_0024locals_002414353 _0024_0024locals_002414820;

		public _0024enable_0024closure_00244027(_0024enable_0024locals_002414353 _0024_0024locals_002414820)
		{
			this._0024_0024locals_002414820 = _0024_0024locals_002414820;
		}

		public bool Invoke(PlayerAbnormalState s)
		{
			return s.Type == _0024_0024locals_002414820._0024sid;
		}
	}

	[NonSerialized]
	private const int MAX_STATE_NUM = 3;

	private List<PlayerAbnormalState> states;

	private StateParams @params;

	private Vector3 defaultGameObjectScale;

	private PlayerControl player;

	private MerlinActionControl actCntrl;

	private bool IsPlayer => player != null;

	private bool usePlayerHUD
	{
		get
		{
			bool num = player != null;
			if (num)
			{
				num = player.useHUD;
			}
			return num;
		}
	}

	public bool HasAnyAbnormalState => ((ICollection)states).Count > 0;

	public bool IsMonsterBlinded => states.FindIndex(_0024adaptor_0024__PlayerAbnormalStateControl_0024callable333_002441_38___0024Predicate_0024133.Adapt(delegate(PlayerAbnormalState s)
	{
		bool num = s != null;
		if (num)
		{
			num = s.StateData.MonsterBlind;
		}
		return num;
	})) >= 0;

	public bool IsSimpleAttack => states.FindIndex(_0024adaptor_0024__PlayerAbnormalStateControl_0024callable333_002441_38___0024Predicate_0024133.Adapt(delegate(PlayerAbnormalState s)
	{
		bool num = s != null;
		if (num)
		{
			num = s.StateData.SimpleAttack;
		}
		return num;
	})) >= 0;

	public EnumAbnormalStates[] CurrentStates
	{
		get
		{
			EnumAbnormalStates[] array = new EnumAbnormalStates[((ICollection)states).Count];
			int num = 0;
			int length = array.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int index = num;
				num++;
				if (states[index] is PlayerAbnormalState playerAbnormalState)
				{
					array[RuntimeServices.NormalizeArrayIndex(array, index)] = playerAbnormalState.Type;
				}
			}
			return array;
		}
	}

	public StateParams Params => @params;

	public PlayerAbnormalStateControl(MerlinActionControl _actCntrl)
	{
		states = new List<PlayerAbnormalState>();
		@params = new StateParams();
		if (!(_actCntrl != null))
		{
			throw new AssertionFailedException("_actCntrl != null");
		}
		setTargetControl(_actCntrl);
		defaultGameObjectScale = _actCntrl.transform.localScale;
	}

	private void setTargetControl(MerlinActionControl _actCntrl)
	{
		actCntrl = _actCntrl;
		player = actCntrl as PlayerControl;
	}

	private bool hasTarget()
	{
		return actCntrl != null;
	}

	public bool hasAbnormalState(EnumAbnormalStates sid)
	{
		_0024hasAbnormalState_0024locals_002414352 _0024hasAbnormalState_0024locals_0024 = new _0024hasAbnormalState_0024locals_002414352();
		_0024hasAbnormalState_0024locals_0024._0024sid = sid;
		return states.FindIndex(_0024adaptor_0024__PlayerAbnormalStateControl_0024callable333_002441_38___0024Predicate_0024133.Adapt(new _0024hasAbnormalState_0024closure_00244022(_0024hasAbnormalState_0024locals_0024).Invoke)) >= 0;
	}

	public void update(float dt)
	{
		if (!hasTarget())
		{
			return;
		}
		@params.clearForUpdate();
		if (((ICollection)states).Count > 0)
		{
			List<PlayerAbnormalState> list = states;
			int count = ((ICollection)list).Count;
			int num = 0;
			while (num < count)
			{
				PlayerAbnormalState playerAbnormalState = list[checked(num++)];
				playerAbnormalState.update(actCntrl, dt, @params);
				MAbnormalStateParameters stateData = playerAbnormalState.StateData;
				if (stateData != null)
				{
					@params.updateParams(stateData, actCntrl);
				}
			}
			states.RemoveAll(_0024adaptor_0024__PlayerAbnormalStateControl_0024callable333_002441_38___0024Predicate_0024133.Adapt((PlayerAbnormalState s) => s.IsDead));
			if (usePlayerHUD)
			{
				BattleHUDAbnormalState.SetStates(CurrentStates);
			}
		}
		@params.updateStatus(player, actCntrl, dt, defaultGameObjectScale);
		if (usePlayerHUD)
		{
			@params.updatePlayerHUD();
		}
	}

	public void playerChanged()
	{
		if (!(actCntrl == null))
		{
			List<PlayerAbnormalState> list = states;
			int count = ((ICollection)list).Count;
			int num = 0;
			while (num < count)
			{
				PlayerAbnormalState playerAbnormalState = list[checked(num++)];
				playerAbnormalState.playerChanged(actCntrl);
			}
		}
	}

	public void clearAll()
	{
		List<PlayerAbnormalState> list = states;
		int count = ((ICollection)list).Count;
		int num = 0;
		while (num < count)
		{
			PlayerAbnormalState playerAbnormalState = list[checked(num++)];
			playerAbnormalState.kill();
		}
		states.Clear();
		if (usePlayerHUD)
		{
			BattleHUDAbnormalState.SetStates(CurrentStates);
		}
		@params.clearAll();
	}

	public void enable(EnumAbnormalStates sid)
	{
		_0024enable_0024locals_002414353 _0024enable_0024locals_0024 = new _0024enable_0024locals_002414353();
		_0024enable_0024locals_0024._0024sid = sid;
		PlayerAbnormalState playerAbnormalState = states.Find(_0024adaptor_0024__PlayerAbnormalStateControl_0024callable333_002441_38___0024Predicate_0024133.Adapt(new _0024enable_0024closure_00244027(_0024enable_0024locals_0024).Invoke));
		if (playerAbnormalState != null)
		{
			playerAbnormalState.init();
		}
		else
		{
			playerAbnormalState = create(_0024enable_0024locals_0024._0024sid);
			states.Add(playerAbnormalState);
		}
		while (((ICollection)states).Count > 3)
		{
			states[0]?.kill();
			states.RemoveAt(0);
		}
		if (usePlayerHUD)
		{
			BattleHUDAbnormalState.SetStates(CurrentStates);
		}
	}

	public void disableTopState()
	{
		if (states.Count > 0)
		{
			states[0]?.kill();
			states.RemoveAt(0);
		}
		if (usePlayerHUD)
		{
			BattleHUDAbnormalState.SetStates(CurrentStates);
		}
	}

	private PlayerAbnormalState create(EnumAbnormalStates sid)
	{
		CharSetupTypes setupType = CharSetupTypes.Monster;
		if (!actCntrl.IsBareSetup)
		{
			setupType = actCntrl.SetupType;
		}
		return new PlayerAbnormalState(sid, setupType);
	}

	internal bool _0024get_IsSimpleAttack_0024closure_00242898(PlayerAbnormalState s)
	{
		bool num = s != null;
		if (num)
		{
			num = s.StateData.SimpleAttack;
		}
		return num;
	}

	internal bool _0024get_IsMonsterBlinded_0024closure_00243700(PlayerAbnormalState s)
	{
		bool num = s != null;
		if (num)
		{
			num = s.StateData.MonsterBlind;
		}
		return num;
	}

	internal bool _0024update_0024closure_00244024(PlayerAbnormalState s)
	{
		return s.IsDead;
	}
}
