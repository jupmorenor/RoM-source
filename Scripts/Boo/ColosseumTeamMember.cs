using System;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class ColosseumTeamMember
{
	[Serializable]
	public enum EState
	{
		Loading,
		Alive,
		Dead
	}

	[Serializable]
	internal class _0024pop_0024locals_002414377
	{
		internal bool _0024stop;
	}

	[Serializable]
	internal class _0024pop_0024closure_00243108
	{
		internal _0024pop_0024locals_002414377 _0024_0024locals_002414859;

		internal ColosseumTeamMember _0024this_002414860;

		public _0024pop_0024closure_00243108(_0024pop_0024locals_002414377 _0024_0024locals_002414859, ColosseumTeamMember _0024this_002414860)
		{
			this._0024_0024locals_002414859 = _0024_0024locals_002414859;
			this._0024this_002414860 = _0024this_002414860;
		}

		public void Invoke(AIControl ai)
		{
			_0024this_002414860.initAI(ai, _0024_0024locals_002414859._0024stop);
			GameSoundManager.Instance.LoadSeGroup(_0024this_002414860.poppetData.MonsterMaster.SoundID);
		}
	}

	private RespPoppet poppetData;

	private RespWeapon weaponData;

	private bool isPlayerSide;

	private bool isLeader;

	private Vector3 popPosition;

	private EState state;

	private AIControl aiObj;

	private float deadTimer;

	public bool IsPopped
	{
		get
		{
			bool num = aiObj != null;
			if (num)
			{
				num = aiObj.IsAlive;
			}
			return num;
		}
	}

	public bool IsDead
	{
		get
		{
			bool num = aiObj == null;
			if (!num)
			{
				num = aiObj.IsDead;
			}
			return num;
		}
	}

	public float DeckCost => (!(aiObj == null)) ? ((float)aiObj.PoppetData.DeckCost) : 0f;

	public float HitPointRate => (!(aiObj == null)) ? aiObj.getHitPointRate() : 0f;

	public float MagicPoint => (!(aiObj == null)) ? aiObj.MagicSkillComponent.MagicPoint : 0f;

	public float MaxMagicPoint => (!(aiObj == null)) ? aiObj.MagicSkillComponent.MaxMagicPoint : 1000f;

	public RespPoppet PoppetData => poppetData;

	public AIControl aiControl => aiObj;

	public bool IsLeader => isLeader;

	public ColosseumTeamMember(RespPoppet _ppt, RespWeapon _wpn, bool _isPlayerSide, Vector3 _popPos, bool _isLeader)
	{
		state = EState.Dead;
		if (_ppt == null)
		{
			throw new AssertionFailedException("_ppt != null");
		}
		poppetData = _ppt;
		weaponData = _wpn;
		popPosition = _popPos;
		isPlayerSide = _isPlayerSide;
		isLeader = _isLeader;
	}

	public bool isMe(AIControl ai)
	{
		bool num = ai != null;
		if (num)
		{
			num = aiObj == ai;
		}
		return num;
	}

	public void pop(bool stop)
	{
		_0024pop_0024locals_002414377 _0024pop_0024locals_0024 = new _0024pop_0024locals_002414377();
		_0024pop_0024locals_0024._0024stop = stop;
		if (aiObj == null)
		{
			state = EState.Loading;
			PoppetFactory.Instance.createPoppetObj(poppetData, new _0024pop_0024closure_00243108(_0024pop_0024locals_0024, this).Invoke);
			return;
		}
		aiObj.gameObject.SetActive(value: true);
		aiObj.Revive();
		setAIMode(_0024pop_0024locals_0024._0024stop);
		aiObj.transform.position = popPosition;
	}

	private void initAI(AIControl ai, bool stop)
	{
		aiObj = ai;
		if (aiObj != null)
		{
			ShadowSelector.Setup(aiObj.gameObject);
			aiObj.setupColosseumMonster(poppetData, weaponData, isPlayerSide);
			aiObj.transform.position = popPosition;
			setAIMode(stop);
			state = EState.Alive;
		}
		else
		{
			state = EState.Dead;
		}
	}

	private void setAIMode(bool stop)
	{
		if (!(aiObj == null))
		{
			if (stop)
			{
				aiObj.AIMODE_Stop();
				return;
			}
			aiObj.AIMODE_Battle();
			aiObj.showHPMiniBar();
		}
	}

	public void destroyChar()
	{
		if (aiObj != null)
		{
			aiObj.gameObject.SetActive(value: false);
		}
		state = EState.Dead;
	}

	public void startBattle()
	{
		setAIMode(stop: false);
	}

	public void stopBattle()
	{
		if (aiObj != null)
		{
			aiObj.aiProgramOff();
		}
	}

	public void addCoverSkills(RespPoppet skillPoppet, bool isLeader)
	{
		if (aiObj != null)
		{
			aiObj.addCoverSkills(skillPoppet, isLeader);
		}
	}

	public void addCoverSkillFromMaster(MCoverSkills csmst, int level)
	{
		if (aiObj != null && csmst != null)
		{
			aiObj.addCoverSkillForColosseum(csmst, level);
		}
	}

	public void initHP()
	{
		if (aiObj != null)
		{
			aiObj.recalcHpMaxWithWeaponAndSkill();
		}
	}

	public void update(float dt, ICallable killedHandler)
	{
		if (state == EState.Alive)
		{
			updateAlive(dt, killedHandler);
		}
		else if (state == EState.Dead)
		{
			updateDead(dt);
		}
		else if (state != 0)
		{
		}
	}

	public void lateUpdate()
	{
		if (state == EState.Alive)
		{
			tryEmitChainskill();
		}
	}

	private void updateAlive(float dt, ICallable killedHandler)
	{
		if (IsDead)
		{
			killedHandler?.Call(new object[1] { this });
			state = EState.Dead;
		}
	}

	private void updateDead(float dt)
	{
		if (!ChainSkillRoutine.IsPlaying)
		{
			deadTimer += dt;
			if (!(deadTimer <= 3f))
			{
				state = EState.Alive;
				pop(stop: false);
				deadTimer = 0f;
			}
		}
	}

	private void tryEmitChainskill()
	{
		if (aiObj.MagicSkillComponent.canUseSkill())
		{
			execChainSkill();
		}
	}

	private void execChainSkill()
	{
		if (!IsDead)
		{
			aiObj.MagicSkillComponent.useSkill();
		}
	}

	public void debugExecChainSkill()
	{
		execChainSkill();
	}

	public string debugInfo()
	{
		return (!(aiObj != null) || poppetData == null) ? new StringBuilder("aiObj=").Append(aiObj).Append(" poppetData=").Append(poppetData)
			.ToString() : new StringBuilder().Append(poppetData.Name).Append(" ").Append(aiObj.HitPoint)
			.Append("/")
			.Append(aiObj.MaxHitPoint)
			.ToString();
	}
}
