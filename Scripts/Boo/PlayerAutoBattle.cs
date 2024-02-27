using System;
using System.Collections.Generic;
using Boo.Lang.Runtime;
using MerlinAPI;
using ParamCalc;
using UnityEngine;

[Serializable]
public class PlayerAutoBattle : MonoBehaviour, PlayerEventHandlers
{
	private PlayerControl player;

	private Queue<AutoBattleAction> actionAutoBattleQueue;

	private AutoBattleAction currentAction;

	private bool queuingChainSkill;

	private int queuingPetIndex;

	private bool queuingWeaponSkill;

	private bool queuingChange;

	private bool autoSkillMode;

	private bool autoBattleSpeed;

	public Queue<AutoBattleAction> ActionAutoBattleQueue => actionAutoBattleQueue;

	public AutoBattleAction CurrentAction => currentAction;

	public bool QueuingWeaponSkill
	{
		get
		{
			return queuingWeaponSkill;
		}
		set
		{
			queuingWeaponSkill = value;
		}
	}

	public bool QueuingChange
	{
		get
		{
			return queuingChange;
		}
		set
		{
			queuingChange = value;
		}
	}

	public bool AutoSkillMode
	{
		get
		{
			return autoSkillMode;
		}
		set
		{
			autoSkillMode = value;
		}
	}

	public bool AutoBattleSpeed
	{
		get
		{
			return autoBattleSpeed;
		}
		set
		{
			autoBattleSpeed = value;
		}
	}

	public PlayerAutoBattle()
	{
		actionAutoBattleQueue = new Queue<AutoBattleAction>();
		queuingPetIndex = -1;
		autoSkillMode = true;
	}

	public void Start()
	{
	}

	public void Init(PlayerControl _player)
	{
		player = _player;
	}

	public void OnEnable()
	{
		queuingChainSkill = false;
		queuingWeaponSkill = false;
		queuingChange = false;
		ClearAutoBattleAction();
		PlayerEventDispatcher.Add(this);
	}

	public void OnDisable()
	{
		PlayerEventDispatcher.Remove(this);
		if (!(null == player) && player.CharPathFinder.IsMovement)
		{
			player.CharPathFinder.Stop();
		}
	}

	public void OnDestroy()
	{
		destruct();
	}

	private void destruct()
	{
		PlayerEventDispatcher.Remove(this);
		player = null;
		actionAutoBattleQueue = null;
	}

	public bool SetSearchTarget()
	{
		int result;
		if (!player.LockOnControl.IsLockedOn)
		{
			player.LockOnControl.searchAndStart();
			if (!player.LockOnControl.IsLockedOn)
			{
				goto IL_0070;
			}
			result = 1;
		}
		else
		{
			player.LockOnControl.searchAndStart();
			if (!player.LockOnControl.IsLockedOn)
			{
				goto IL_0070;
			}
			result = 1;
		}
		goto IL_0071;
		IL_0070:
		result = 0;
		goto IL_0071;
		IL_0071:
		return (byte)result != 0;
	}

	public bool CheckSkillRange(float attackRange, float attackMoveRange)
	{
		bool flag = false;
		int result;
		if (CheckRange(player, (MerlinActionControl)player.LockOnControl.Target, attackRange))
		{
			result = 1;
		}
		else
		{
			bool flag2 = true;
			flag = CheckRange(player, (MerlinActionControl)player.LockOnControl.Target, attackRange + attackMoveRange);
			result = ((flag2 && flag) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public void actIfMotionChanged(string motName)
	{
		if (!string.IsNullOrEmpty(motName) && IsAttackAnimation(motName) && IsNormalAttackAction())
		{
			bool flag = CheckNormalAttackRange(motName);
			if (!flag)
			{
			}
			SetNormalAttackCondition(flag);
		}
	}

	public string GetNextAttackName(string curAttackName)
	{
		MNormalAttackRange mNormalAttackRange = GetMNormalAttackRange();
		string result;
		if (mNormalAttackRange == null)
		{
			result = string.Empty;
		}
		else
		{
			int num = 0;
			if (curAttackName == mNormalAttackRange.RunAttack_Name)
			{
				num = mNormalAttackRange.RunAttack_Index;
			}
			else if (curAttackName == mNormalAttackRange.Attack1_Name)
			{
				num = mNormalAttackRange.Attack1_Index;
			}
			else if (curAttackName == mNormalAttackRange.Attack2_Name)
			{
				num = mNormalAttackRange.Attack2_Index;
			}
			else if (curAttackName == mNormalAttackRange.Attack3_Name)
			{
				num = mNormalAttackRange.Attack3_Index;
			}
			else if (curAttackName == mNormalAttackRange.Attack4_Name)
			{
				num = mNormalAttackRange.Attack4_Index;
			}
			num = checked(num + 1);
			string text = string.Empty;
			if (num == mNormalAttackRange.RunAttack_Index)
			{
				text = mNormalAttackRange.RunAttack_Name;
			}
			else if (num == mNormalAttackRange.Attack1_Index)
			{
				text = mNormalAttackRange.Attack1_Name;
			}
			else if (num == mNormalAttackRange.Attack2_Index)
			{
				text = mNormalAttackRange.Attack2_Name;
			}
			else if (num == mNormalAttackRange.Attack3_Index)
			{
				text = mNormalAttackRange.Attack3_Name;
			}
			else if (num == mNormalAttackRange.Attack4_Index)
			{
				text = mNormalAttackRange.Attack4_Name;
			}
			if (text == string.Empty)
			{
				text = mNormalAttackRange.RunAttack_Name;
			}
			result = text;
		}
		return result;
	}

	public bool CheckNormalAttackRange(string motName)
	{
		int result;
		if (player == null)
		{
			result = 0;
		}
		else if (!player.LockOnControl.IsLockedOn)
		{
			result = 0;
		}
		else if (player.LockOnControl.Target.IsDead)
		{
			result = 0;
		}
		else
		{
			MNormalAttackRange mNormalAttackRange = GetMNormalAttackRange();
			if (mNormalAttackRange == null)
			{
				result = 0;
			}
			else if (motName == mNormalAttackRange.RunAttack_Name)
			{
				result = 1;
			}
			else
			{
				string nextAttackName = GetNextAttackName(motName);
				float range = 0f;
				float range2 = 0f;
				if (nextAttackName == mNormalAttackRange.RunAttack_Name)
				{
					range = mNormalAttackRange.RunAttack_Range;
					range2 = mNormalAttackRange.RunAttack_Range + mNormalAttackRange.RunAttack_Move;
				}
				else if (nextAttackName == mNormalAttackRange.Attack1_Name)
				{
					range = mNormalAttackRange.Attack1_Range;
					range2 = mNormalAttackRange.Attack1_Range + mNormalAttackRange.Attack1_Move;
				}
				else if (nextAttackName == mNormalAttackRange.Attack2_Name)
				{
					range = mNormalAttackRange.Attack2_Range;
					range2 = mNormalAttackRange.Attack2_Range + mNormalAttackRange.Attack2_Move;
				}
				else if (nextAttackName == mNormalAttackRange.Attack3_Name)
				{
					range = mNormalAttackRange.Attack3_Range;
					range2 = mNormalAttackRange.Attack3_Range + mNormalAttackRange.Attack3_Move;
				}
				else if (nextAttackName == mNormalAttackRange.Attack4_Name)
				{
					range = mNormalAttackRange.Attack4_Range;
					range2 = mNormalAttackRange.Attack4_Range + mNormalAttackRange.Attack4_Move;
				}
				bool flag = false;
				if (CheckRange(player, (MerlinActionControl)player.LockOnControl.Target, range))
				{
					result = 1;
				}
				else
				{
					bool flag2 = true;
					flag = CheckRange(player, (MerlinActionControl)player.LockOnControl.Target, range2);
					result = ((flag2 && flag) ? 1 : 0);
				}
			}
		}
		return (byte)result != 0;
	}

	public bool IsAttackAnimation(string aniName)
	{
		MNormalAttackRange mNormalAttackRange = GetMNormalAttackRange();
		return mNormalAttackRange != null && (aniName == mNormalAttackRange.RunAttack_Name || aniName == mNormalAttackRange.Attack1_Name || aniName == mNormalAttackRange.Attack2_Name || aniName == mNormalAttackRange.Attack3_Name || ((aniName == mNormalAttackRange.Attack4_Name) ? true : false));
	}

	public bool CheckNormalAttackRangeforRunAttack()
	{
		int result;
		if (player == null)
		{
			result = 0;
		}
		else if (!player.LockOnControl.IsLockedOn)
		{
			result = 0;
		}
		else if (player.LockOnControl.Target.IsDead)
		{
			result = 0;
		}
		else
		{
			MNormalAttackRange mNormalAttackRange = GetMNormalAttackRange();
			if (mNormalAttackRange == null)
			{
				result = 0;
			}
			else
			{
				float runAttack_Range = mNormalAttackRange.RunAttack_Range;
				float range = mNormalAttackRange.RunAttack_Range + mNormalAttackRange.RunAttack_Move;
				bool flag = false;
				if (CheckRange(player, (MerlinActionControl)player.LockOnControl.Target, runAttack_Range))
				{
					result = 1;
				}
				else
				{
					bool flag2 = true;
					flag = CheckRange(player, (MerlinActionControl)player.LockOnControl.Target, range);
					result = ((flag2 && flag) ? 1 : 0);
				}
			}
		}
		return (byte)result != 0;
	}

	public bool CheckRange(MerlinActionControl _source, MerlinActionControl _target, float range)
	{
		Vector3 position = _source.transform.position;
		Vector3 position2 = _target.transform.position;
		float radius = _source.CharControl.radius;
		float radius2 = _target.CharControl.radius;
		float num = Vector3.Distance(position, position2);
		return !(num > range + radius + radius2);
	}

	public bool IsNormalAttackAction()
	{
		int result;
		if (currentAction != null)
		{
			AutoBattleType type = currentAction.GetType();
			if (type == AutoBattleType.NORMAL_ATTACK)
			{
				result = 1;
				goto IL_0025;
			}
		}
		result = 0;
		goto IL_0025;
		IL_0025:
		return (byte)result != 0;
	}

	public void SetNormalAttackCondition(bool attackCondition)
	{
		if (currentAction != null)
		{
			AutoBattleType type = currentAction.GetType();
			if (type != 0 && type == AutoBattleType.NORMAL_ATTACK)
			{
				ActionNormalAttack actionNormalAttack = (ActionNormalAttack)currentAction;
				actionNormalAttack.DoAttack(attackCondition);
			}
		}
	}

	public void AddAutoBattleAction(AutoBattleAction action)
	{
		actionAutoBattleQueue.Enqueue(action);
	}

	public void AddActionNormalAttack()
	{
		ActionNormalAttack action = new ActionNormalAttack(player);
		AddAutoBattleAction(action);
	}

	public void AddActionToTarget(MerlinActionControl target)
	{
		ActionToTarget action = new ActionToTarget(player, target);
		AddAutoBattleAction(action);
	}

	public void SetDebugActionCommnad(string command)
	{
		PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
		if (currentPlayer != null && currentPlayer.ActiveDebugActionCommad)
		{
			if (currentPlayer.DebugAutoBattleActionCommadQueue.Count >= 20)
			{
				currentPlayer.DebugAutoBattleActionCommadQueue.Dequeue();
			}
			currentPlayer.DebugAutoBattleActionCommadQueue.Enqueue(command);
		}
	}

	public void ClearDebugActionCommand()
	{
		PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
		if (currentPlayer != null)
		{
			currentPlayer.DebugAutoBattleActionCommadQueue.Clear();
		}
	}

	public float GetRunAttackRange()
	{
		MNormalAttackRange mNormalAttackRange = GetMNormalAttackRange();
		float result;
		if (mNormalAttackRange == null)
		{
			result = 0f;
		}
		else
		{
			float runAttack_Range = mNormalAttackRange.RunAttack_Range;
			result = runAttack_Range;
		}
		return result;
	}

	public float GetRunAttackTotalRange()
	{
		MNormalAttackRange mNormalAttackRange = GetMNormalAttackRange();
		float result;
		if (mNormalAttackRange == null)
		{
			result = 0f;
		}
		else
		{
			float num = mNormalAttackRange.RunAttack_Move + mNormalAttackRange.RunAttack_Range;
			result = num;
		}
		return result;
	}

	public MNormalAttackRange GetMNormalAttackRange()
	{
		object result;
		if (player == null)
		{
			result = null;
		}
		else
		{
			MWeapons mainWeaponMaster = GetMainWeaponMaster();
			if (mainWeaponMaster == null)
			{
				result = null;
			}
			else
			{
				MNormalAttackRange mNormalAttackRange = MNormalAttackRange.FindByStyleId(mainWeaponMaster.MStyleId);
				result = ((mNormalAttackRange == null) ? null : mNormalAttackRange);
			}
		}
		return (MNormalAttackRange)result;
	}

	public MWeaponSkills GetMWeaponSkills()
	{
		return player.CurrentWeaponSkill;
	}

	public MWeaponSkills GetAltMWeaponSkills()
	{
		return player.AltWeaponSkill;
	}

	private MWeapons GetMainWeaponMaster()
	{
		return (player == null) ? null : player.getMainWeapon()?.Master;
	}

	public MChainSkills GetMChainSkills(object petIndex)
	{
		AIControl poppet = player.getPoppet(RuntimeServices.UnboxInt32(petIndex));
		object result;
		if (poppet == null)
		{
			result = null;
		}
		else
		{
			RespPoppet poppetData = poppet.PoppetData;
			if (poppetData == null)
			{
				result = null;
			}
			else
			{
				MChainSkills chainSkill = poppetData.ChainSkill;
				result = chainSkill;
			}
		}
		return (MChainSkills)result;
	}

	public bool IsRatioHP()
	{
		int result;
		if (player == null)
		{
			result = 0;
		}
		else
		{
			float num = (float)player.RecoveryDamage / player.MaxHitPoint;
			result = ((!(player.HitPointRate > 0.25f) && !(0.1f >= num)) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public bool IsReadyPlayerChange()
	{
		return !player.IsDead && player.IsReady && !player.IsActionTypeSkill && !player.IsSkillDisabledByAbnormalState && !IsChainSkillPlaying() && player.ChangeCooldown.IsReady && (IsSetupWeaponSkillCondition(GetAltMWeaponSkills()) ? true : false);
	}

	public bool IsReadyPlayerChangeforQueuing()
	{
		return !player.IsDead && player.IsReady && !player.IsSkillDisabledByAbnormalState && !IsChainSkillPlaying() && (player.ChangeCooldown.IsReady ? true : false);
	}

	public void DoPlayerChange()
	{
		ClearAutoBattleAction();
		player.ActionInput.change();
	}

	public bool IsChainSkillPlaying()
	{
		return ChainSkillRoutine.IsPlaying ? true : false;
	}

	public bool HasActionCommandChainSkill()
	{
		if (player.HAS_ATTACK_COMMANDS)
		{
			ActionCommandAttack[] array = player.collectAttackCommands();
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
				ActionCommandAttack actionCommandAttack = array[RuntimeServices.NormalizeArrayIndex(array, index)];
				if (!actionCommandAttack.IsChainSkill)
				{
					continue;
				}
				goto IL_0059;
			}
		}
		int result = 0;
		goto IL_0068;
		IL_0059:
		result = 1;
		goto IL_0068;
		IL_0068:
		return (byte)result != 0;
	}

	public bool CheckComparisonOperator(int nOperatorType, int source, int dest)
	{
		bool flag = false;
		if (1 == nOperatorType)
		{
			if (source == dest)
			{
				flag = true;
			}
		}
		else if (2 == nOperatorType)
		{
			if (source != dest)
			{
				flag = true;
			}
		}
		else if (3 == nOperatorType)
		{
			if (source < dest)
			{
				flag = true;
			}
		}
		else if (4 == nOperatorType)
		{
			if (source > dest)
			{
				flag = true;
			}
		}
		else if (5 == nOperatorType)
		{
			if (source <= dest)
			{
				flag = true;
			}
		}
		else if (6 == nOperatorType && source >= dest)
		{
			flag = true;
		}
		return flag ? true : false;
	}

	public bool IsSetupEnemyCondition(bool bEnemyAndOr, int nEnemyCount, bool bEnemyExtra)
	{
		int result;
		if (!QuestBattleStarter.IsPlaying)
		{
			result = 0;
		}
		else
		{
			bool flag = false;
			bool flag2 = false;
			int numOfPoppedEnemies = QuestBattleStarter.CurrentBattle.NumOfPoppedEnemies;
			if (numOfPoppedEnemies >= nEnemyCount)
			{
				flag = true;
			}
			MerlinActionControl merlinActionControl = (MerlinActionControl)player.LockOnControl.Target;
			if (merlinActionControl == null)
			{
				result = 0;
			}
			else
			{
				if (!bEnemyExtra)
				{
					flag2 = true;
				}
				else
				{
					bool num = merlinActionControl.IS_ELITE;
					if (!num)
					{
						num = merlinActionControl.IS_BOSS;
					}
					flag2 = num;
				}
				if (!bEnemyAndOr)
				{
					if (flag && flag2)
					{
						goto IL_00aa;
					}
					result = 0;
				}
				else
				{
					if (flag || flag2)
					{
						goto IL_00aa;
					}
					result = 0;
				}
			}
		}
		goto IL_00ab;
		IL_00aa:
		result = 1;
		goto IL_00ab;
		IL_00ab:
		return (byte)result != 0;
	}

	public bool IsSetupPlayerAbnormalCondition(bool bAbnormalState)
	{
		bool flag = false;
		if (!bAbnormalState)
		{
			flag = true;
		}
		else if (player.AbnormalStateControl.CurrentStates != null)
		{
			flag = true;
		}
		return flag ? true : false;
	}

	public bool IsSetupChainSkillCondition(int index)
	{
		MChainSkills mChainSkills = GetMChainSkills(index);
		return mChainSkills != null && IsChainSkillEnemyConditionOk(mChainSkills) && IsChainSkillStatusConditionOk(mChainSkills, index) && (CheckSkillRange(mChainSkills.Attack_Range, mChainSkills.Attack_Move) ? true : false);
	}

	public bool IsChainSkillEnemyConditionOk(MChainSkills chainSkills)
	{
		int result;
		if (chainSkills == null)
		{
			result = 0;
		}
		else
		{
			bool enemy_AndOr = chainSkills.Enemy_AndOr;
			int enemy_Count = chainSkills.Enemy_Count;
			bool enemy_Extra = chainSkills.Enemy_Extra;
			result = (IsSetupEnemyCondition(enemy_AndOr, enemy_Count, enemy_Extra) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public bool IsChainSkillStatusConditionOk(MChainSkills chainSkills, int poppetIndex)
	{
		int result;
		checked
		{
			if (chainSkills == null)
			{
				result = 0;
			}
			else
			{
				int pc_ComparisonOperator = chainSkills.Pc_ComparisonOperator;
				int pc_StatType = chainSkills.Pc_StatType;
				int pc_StatValueMin = chainSkills.Pc_StatValueMin;
				int pc_StatValueMax = chainSkills.Pc_StatValueMax;
				float pc_StatValueExp = chainSkills.Pc_StatValueExp;
				bool pc_AbnormalState = chainSkills.Pc_AbnormalState;
				if (!IsSetupPlayerAbnormalCondition(pc_AbnormalState))
				{
					result = 0;
				}
				else
				{
					AIControl poppet = player.getPoppet(poppetIndex);
					if (poppet == null)
					{
						result = 0;
					}
					else if (!poppet.HasPoppetData)
					{
						result = 0;
					}
					else
					{
						int chainSkillLevel = poppet.PoppetData.ChainSkillLevel;
						int levelMax = chainSkills.LevelMax;
						int source = (int)StatusCalcModule.getPlayerStatCalc(unchecked((EnumStatus)pc_StatType), player);
						int dest = ParamCalcModule.ComputeGrowthInt(chainSkillLevel, levelMax, pc_StatValueMin, pc_StatValueMax, pc_StatValueExp);
						bool flag = false;
						flag = pc_ComparisonOperator == 0 || CheckComparisonOperator(pc_ComparisonOperator, source, dest);
						result = (flag ? 1 : 0);
					}
				}
			}
		}
		return (byte)result != 0;
	}

	public bool IsSetupWeaponSkillCondition()
	{
		int result;
		if (!QuestBattleStarter.IsPlaying)
		{
			result = 0;
		}
		else
		{
			MWeaponSkills mWeaponSkills = GetMWeaponSkills();
			result = ((mWeaponSkills != null && IsSetupWeaponSkillCondition(mWeaponSkills)) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public bool IsSetupWeaponSkillCondition(MWeaponSkills weaponSkills)
	{
		return weaponSkills != null && IsWeaponSkillEnemyConditionOk(weaponSkills) && IsWeaponSkillStatusConditionOk(weaponSkills) && (CheckSkillRange(weaponSkills.Attack_Range, weaponSkills.Attack_Move) ? true : false);
	}

	public bool IsWeaponSkillEnemyConditionOk(MWeaponSkills weaponSkills)
	{
		int result;
		if (weaponSkills == null)
		{
			result = 0;
		}
		else
		{
			bool enemy_AndOr = weaponSkills.Enemy_AndOr;
			int enemy_Count = weaponSkills.Enemy_Count;
			bool enemy_Extra = weaponSkills.Enemy_Extra;
			result = (IsSetupEnemyCondition(enemy_AndOr, enemy_Count, enemy_Extra) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public bool IsWeaponSkillStatusConditionOk(MWeaponSkills weaponSkills)
	{
		int result;
		checked
		{
			if (weaponSkills == null)
			{
				result = 0;
			}
			else
			{
				int pc_ComparisonOperator = weaponSkills.Pc_ComparisonOperator;
				int pc_StatType = weaponSkills.Pc_StatType;
				int pc_StatValueMin = weaponSkills.Pc_StatValueMin;
				int pc_StatValueMax = weaponSkills.Pc_StatValueMax;
				float pc_StatValueExp = weaponSkills.Pc_StatValueExp;
				bool pc_AbnormalState = weaponSkills.Pc_AbnormalState;
				if (!IsSetupPlayerAbnormalCondition(pc_AbnormalState))
				{
					result = 0;
				}
				else
				{
					int currentWeaponSkillLevel = player.CurrentWeaponSkillLevel;
					int levelMax = weaponSkills.LevelMax;
					int source = (int)StatusCalcModule.getPlayerStatCalc(unchecked((EnumStatus)pc_StatType), player);
					int dest = ParamCalcModule.ComputeGrowthInt(currentWeaponSkillLevel, levelMax, pc_StatValueMin, pc_StatValueMax, pc_StatValueExp);
					bool flag = false;
					flag = pc_ComparisonOperator == 0 || CheckComparisonOperator(pc_ComparisonOperator, source, dest);
					result = (flag ? 1 : 0);
				}
			}
		}
		return (byte)result != 0;
	}

	public int GetReadyChainSkill()
	{
		int result;
		if (!player.LockOnControl.IsLockedOn)
		{
			result = -1;
		}
		else if (player.LockOnControl.Target.IsDead)
		{
			result = -1;
		}
		else if (player.IsChainDisabledByAbnormalState)
		{
			result = -1;
		}
		else if (IsChainSkillPlaying())
		{
			result = -1;
		}
		else
		{
			int poppetNum = player.PoppetNum;
			int num = -1;
			int num2 = 0;
			int num3 = poppetNum;
			if (num3 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num2 < num3)
			{
				int num4 = num2;
				num2++;
				MagicSkill poppetMagicSkill = player.getPoppetMagicSkill(num4);
				if (poppetMagicSkill == null || !poppetMagicSkill.canUseSkill())
				{
					continue;
				}
				num = num4;
				break;
			}
			result = ((num < 0) ? (-1) : (IsSetupChainSkillCondition(num) ? num : (-1)));
		}
		return result;
	}

	public bool IsReadyChainSklilforQueuing()
	{
		int result;
		if (!player.IsReady)
		{
			result = 0;
		}
		else if (!player.LockOnControl.IsLockedOn)
		{
			result = 0;
		}
		else if (player.LockOnControl.Target.IsDead)
		{
			result = 0;
		}
		else if (queuingPetIndex < 0)
		{
			result = 0;
		}
		else if (player.IsChainDisabledByAbnormalState)
		{
			result = 0;
		}
		else if (IsChainSkillPlaying())
		{
			result = 0;
		}
		else
		{
			MagicSkill poppetMagicSkill = player.getPoppetMagicSkill(queuingPetIndex);
			result = ((!(poppetMagicSkill == null)) ? (poppetMagicSkill.canUseSkill() ? 1 : 0) : 0);
		}
		return (byte)result != 0;
	}

	public void DoChainSkillFire(int index)
	{
		ClearAutoBattleAction();
		switch (index)
		{
		case 0:
			player.ActionInput.chainMySkill();
			break;
		case 1:
			player.ActionInput.chainFriendSkill();
			break;
		}
	}

	public bool IsReadyWeaponSkill()
	{
		return player.IsReady && player.LockOnControl.IsLockedOn && !player.LockOnControl.Target.IsDead && !player.IsActionTypeSkill && !player.IsSkillDisabledByAbnormalState && !IsChainSkillPlaying() && player.WeaponSkillCooldown.IsReady && (IsSetupWeaponSkillCondition() ? true : false);
	}

	public bool IsReadyWeaponSkillforQueuing()
	{
		return player.LockOnControl.IsLockedOn && !player.LockOnControl.Target.IsDead && !player.IsSkillDisabledByAbnormalState && !IsChainSkillPlaying() && (player.WeaponSkillCooldown.IsReady ? true : false);
	}

	public void DoWeaponSkillFire()
	{
		player.ActionInput.skill1();
		ClearAutoBattleAction();
	}

	public void PreBattleProcess()
	{
		bool flag = false;
		if (!AutoSkillMode)
		{
			if (queuingChange)
			{
				if (IsReadyPlayerChangeforQueuing())
				{
					flag = true;
				}
				queuingChange = false;
			}
		}
		else if (queuingChange)
		{
			if (IsReadyPlayerChangeforQueuing())
			{
				flag = true;
			}
			queuingChange = false;
		}
		else if (IsReadyPlayerChange())
		{
			flag = true;
		}
		if (flag)
		{
			DoPlayerChange();
		}
		int num = -1;
		if (!AutoSkillMode)
		{
			if (queuingChainSkill)
			{
				if (IsReadyChainSklilforQueuing())
				{
					num = queuingPetIndex;
				}
				queuingChainSkill = false;
				queuingPetIndex = -1;
			}
		}
		else if (queuingChainSkill)
		{
			if (IsReadyChainSklilforQueuing())
			{
				num = queuingPetIndex;
			}
			queuingChainSkill = false;
			queuingPetIndex = -1;
		}
		else
		{
			num = GetReadyChainSkill();
		}
		if (num > -1)
		{
			DoChainSkillFire(num);
		}
		bool flag2 = false;
		if (!AutoSkillMode)
		{
			if (queuingWeaponSkill)
			{
				if (IsReadyWeaponSkillforQueuing())
				{
					flag2 = true;
				}
				queuingWeaponSkill = false;
			}
		}
		else if (queuingWeaponSkill)
		{
			if (IsReadyWeaponSkillforQueuing())
			{
				flag2 = true;
			}
			queuingWeaponSkill = false;
		}
		else if (IsReadyWeaponSkill())
		{
			flag2 = true;
		}
		if (flag2)
		{
			DoWeaponSkillFire();
		}
	}

	public void AttackProcess()
	{
		if (!SetSearchTarget())
		{
			return;
		}
		float runAttackRange = GetRunAttackRange();
		if (CheckRange(player, (MerlinActionControl)player.LockOnControl.Target, runAttackRange))
		{
			AddActionNormalAttack();
		}
		else if (true)
		{
			float runAttackTotalRange = GetRunAttackTotalRange();
			if (runAttackTotalRange != 0f)
			{
				if (CheckRange(player, (MerlinActionControl)player.LockOnControl.Target, runAttackTotalRange))
				{
					AddActionNormalAttack();
				}
				else
				{
					AddActionToTarget((MerlinActionControl)player.LockOnControl.Target);
				}
			}
		}
		else
		{
			AddActionToTarget((MerlinActionControl)player.LockOnControl.Target);
		}
	}

	public void SetNextAction()
	{
		if (player.IS_ANIM_IDLE)
		{
			SetDebugActionCommnad("ActionIdle");
			AttackProcess();
		}
	}

	public void doUpdate(float dt)
	{
		if (TheWorld.WorldIsStopped || null == player || player.IsDead)
		{
			return;
		}
		PreBattleProcess();
		if (actionAutoBattleQueue.Count > 0)
		{
			AutoBattleAction autoBattleAction = (currentAction = actionAutoBattleQueue.Peek());
			SetDebugActionCommnad(autoBattleAction.ToString());
			int num = autoBattleAction.Apply(dt);
			if (num == 3)
			{
				actionAutoBattleQueue.Dequeue();
				currentAction = null;
			}
		}
		else
		{
			SetNextAction();
		}
	}

	public void ClearAutoBattleAction()
	{
		currentAction = null;
		actionAutoBattleQueue.Clear();
		ClearDebugActionCommand();
	}

	public void SetQueuingChainSkill(int petIndex)
	{
		queuingChainSkill = true;
		queuingPetIndex = petIndex;
	}

	public void ClearAutoSpeed()
	{
		if (AutoSkillMode && AutoBattleSpeed)
		{
			player.AutoFlowController.AutoFlowSpeed = 1f;
		}
	}

	public virtual void eventPlayerEnabled(PlayerControl player)
	{
	}

	public virtual void eventPlayerDisabled(PlayerControl player)
	{
	}

	public virtual void eventPoppetSet(PlayerControl player, MerlinActionControl[] poppets)
	{
	}

	public virtual void eventBattleStart()
	{
		ClearAutoBattleAction();
	}

	public virtual void eventBattleEnd()
	{
		ClearAutoBattleAction();
		if (player.CharPathFinder.IsMovement)
		{
			player.CharPathFinder.Stop();
		}
	}

	public virtual void eventBattleComplete()
	{
		if (player.CharPathFinder.IsMovement)
		{
			player.CharPathFinder.Stop();
		}
	}

	public virtual void eventPlayerDamage(MerlinActionControl player)
	{
	}

	public virtual void eventPoppetDamage(MerlinActionControl attacker, MerlinActionControl poppet, float damage)
	{
	}

	public virtual void eventMonsterDamage(MerlinActionControl monster)
	{
	}

	public virtual void eventPlayerDown(MerlinActionControl player)
	{
	}

	public virtual void eventPoppetDown(MerlinActionControl attacker, MerlinActionControl poppet, float damage)
	{
	}

	public virtual void eventMonsterDown(MerlinActionControl monster)
	{
	}

	public virtual void eventDead(MerlinActionControl attacker, MerlinActionControl poppet, float damage)
	{
	}

	public virtual void eventRevive(MerlinActionControl poppet)
	{
	}

	public virtual void eventChain(MerlinActionControl poppet)
	{
	}

	public virtual void eventMagicCharge(MerlinActionControl poppet)
	{
	}

	public virtual void eventBossStart(MerlinActionControl boss)
	{
	}

	public virtual void eventBossEnd(MerlinActionControl boss)
	{
	}

	public virtual void eventPoppetFinish(MerlinActionControl poppet, MerlinActionControl monster, float damage)
	{
	}

	public virtual void eventPlayerDead(PlayerControl player)
	{
		ClearAutoBattleAction();
	}

	public virtual void eventBox()
	{
	}

	public virtual void eventBoxGet()
	{
	}

	public virtual void eventCandy()
	{
	}

	public virtual void eventCandyGet()
	{
	}

	public virtual void eventToDemon()
	{
	}

	public virtual void eventToAngel()
	{
	}

	public virtual void eventResistAbnormalStateAttack(EnumAbnormalStates state, MerlinActionControl resister, MerlinActionControl attacker)
	{
	}

	public virtual void eventInfectAbnormalState(EnumAbnormalStates state, MerlinActionControl patient, MerlinActionControl attacker)
	{
	}

	public virtual void eventQuestStart(PlayerControl player)
	{
	}

	public virtual void eventQuestRestart(PlayerControl player)
	{
	}

	public virtual void eventQuestEnd(PlayerControl player)
	{
	}

	public virtual void eventPause()
	{
	}

	public virtual void eventUnpause()
	{
	}

	public virtual void eventJumpStart()
	{
	}

	public virtual void eventJumpEnd()
	{
	}
}
