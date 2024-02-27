using System;

[Serializable]
public class ActionNormalAttack : AutoBattleAction
{
	private readonly float LIMIT_DELAY_TIME;

	private float curTime;

	private bool doAttack;

	public ActionNormalAttack(PlayerControl p)
		: base(p, AutoBattleType.NORMAL_ATTACK)
	{
		LIMIT_DELAY_TIME = 0.25f;
		actionNextStep = ActionStep.START;
	}

	public override void Init()
	{
		curTime = 0f;
		doAttack = false;
		player.ActionInput.attack(1);
		player.ActionInput.runAttack();
	}

	public override int Apply(float frameTime)
	{
		if (actionNextStep == ActionStep.START)
		{
			actionNextStep = ActionStep.DOING;
			Init();
		}
		if (actionNextStep != ActionStep.END)
		{
			Update(frameTime);
		}
		return (int)actionNextStep;
	}

	public override void RequireEnd()
	{
		actionNextStep = ActionStep.END;
	}

	public override string ToString()
	{
		return "ActionNormalAttack";
	}

	private void Update(float frameTime)
	{
		if (player.IsDead)
		{
			RequireEnd();
			return;
		}
		if (!player.LockOnControl.IsLockedOn)
		{
			RequireEnd();
			return;
		}
		if (player.LockOnControl.Target.IsDead)
		{
			RequireEnd();
			return;
		}
		if (player.IsAttackDisabledByAbnormalState)
		{
			RequireEnd();
			return;
		}
		if (player.isActionType(ActionTypes.Kaihi))
		{
			RequireEnd();
			return;
		}
		if (player.isActionType(ActionTypes.Idle))
		{
			if (!player.ActionInput.HasMove)
			{
				curTime += frameTime;
				if (!(curTime <= LIMIT_DELAY_TIME))
				{
					RequireEnd();
					return;
				}
			}
			else
			{
				curTime = 0f;
			}
		}
		else
		{
			curTime = 0f;
		}
		if (doAttack)
		{
			DoAttack();
		}
	}

	public void DoAttack()
	{
		curTime = 0f;
		doAttack = false;
		player.ActionInput.attack(1);
		player.ActionInput.runAttack();
	}

	public void DoAttack(bool attackCondition)
	{
		if (!attackCondition)
		{
			RequireEnd();
		}
		doAttack = attackCondition;
	}
}
