using System;

[Serializable]
public class ActionDefaultShiftCommand : MerlinActionControl.ActTimeCommand
{
	public ActionDefaultShiftCommand()
	{
		startTime = 0f;
		mainTime = 0f;
		endTime = float.MaxValue;
	}

	public ActionDefaultShiftCommand(float availTime)
	{
		startTime = availTime;
		mainTime = availTime;
		endTime = float.MaxValue;
	}

	public override void doInit()
	{
		if (!(startTime >= 0f))
		{
			float num = MotionLength + startTime;
			if (!(num >= 0f))
			{
			}
			startTime = num;
			mainTime = num;
		}
	}

	public override void doUpdateInTime()
	{
		if (!parent.isActionType(ActionTypes.Moving) && Input.HasMove)
		{
			parent.playAnimationByType(PlayerAnimationTypes.Run);
		}
		if (Input.hasAttack(1))
		{
			parent.playAnimationByType(PlayerAnimationTypes.Attack1);
		}
		if (Input.hasAttack(2))
		{
			parent.playAnimationByType(PlayerAnimationTypes.Attack2);
		}
		if (Input.hasAttack(3))
		{
			parent.playAnimationByType(PlayerAnimationTypes.Attack3);
		}
		if (Input.hasAttack(4))
		{
			parent.playAnimationByType(PlayerAnimationTypes.Attack4);
		}
		if (Input.hasAttack(5))
		{
			parent.playAnimationByType(PlayerAnimationTypes.Attack5);
		}
		if (Input.hasAttack(6))
		{
			parent.playAnimationByType(PlayerAnimationTypes.Attack6);
		}
		if (Input.hasAttack(7))
		{
			parent.playAnimationByType(PlayerAnimationTypes.Attack7);
		}
		if (Input.hasAttack(8))
		{
			parent.playAnimationByType(PlayerAnimationTypes.Attack8);
		}
		if (Input.HasRunAttack)
		{
			parent.playAnimationByType(PlayerAnimationTypes.RunAttack);
		}
	}
}
