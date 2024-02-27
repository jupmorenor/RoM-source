using System;
using UnityEngine;

[Serializable]
public class ActionToTarget : AutoBattleAction
{
	private readonly float LIMIT_DELAY_TIME;

	private float curTime;

	private MerlinActionControl targetChar;

	private float targetCharRadius;

	private Vector3 targetCharPos;

	private bool pathfinding;

	public ActionToTarget(PlayerControl p, MerlinActionControl t)
		: base(p, AutoBattleType.TO_TARGET)
	{
		LIMIT_DELAY_TIME = 1f;
		targetCharPos = Vector3.zero;
		actionNextStep = ActionStep.START;
		targetChar = t;
		targetCharRadius = targetChar.CharControl.radius;
	}

	public override void Init()
	{
		TryMove();
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
		if (pathfinding)
		{
			player.CharPathFinder.Stop();
		}
		else
		{
			player.ActionInput.clearMove();
		}
		actionNextStep = ActionStep.END;
	}

	public override string ToString()
	{
		return "ActionToTarget";
	}

	private void TryMove()
	{
		pathfinding = false;
		curTime = 0f;
		targetCharPos = targetChar.transform.position;
		if (!player.CharPathFinder.IsMovableNode(player.transform.position, targetCharPos))
		{
			pathfinding = true;
			player.CharPathFinder.Goto(targetCharPos);
		}
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
		if (targetChar.IsDead)
		{
			RequireEnd();
			return;
		}
		if (player.isActionType(ActionTypes.Kaihi))
		{
			RequireEnd();
			return;
		}
		if (player.IsMoveDisabledByAbnormalState)
		{
			RequireEnd();
			return;
		}
		bool num = pathfinding;
		if (num)
		{
			num = player.CharPathFinder.PathLength > 0;
		}
		bool flag = num;
		bool flag2 = false;
		if (flag)
		{
			if (!player.CharPathFinder.IsMovement)
			{
				curTime += frameTime;
				if (!(LIMIT_DELAY_TIME > curTime))
				{
					curTime = 0f;
					RequireEnd();
				}
				return;
			}
			if (!player.CharPathFinder.IsMovableNode(player.transform.position, targetCharPos))
			{
				return;
			}
			flag2 = true;
		}
		else
		{
			Vector3 position = targetChar.transform.position;
			player.ActionInput.move(position);
			flag2 = true;
		}
		if (flag && !player.CharPathFinder.IsMovement)
		{
			RequireEnd();
		}
		else if (flag2 && autoBattle.CheckNormalAttackRangeforRunAttack())
		{
			RequireEnd();
		}
	}
}
