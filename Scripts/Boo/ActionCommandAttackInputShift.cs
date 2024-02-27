using System;

[Serializable]
public class ActionCommandAttackInputShift : MerlinActionControl.ActTimeCommand
{
	private int inputAttackNo;

	private MotionID motionID;

	public ActionCommandAttackInputShift(int _inputAttackNo, float start, float end, MotionID _motionID)
	{
		startTime = start;
		mainTime = start;
		endTime = end;
		inputAttackNo = _inputAttackNo;
		motionID = _motionID;
	}

	public override void doUpdateInTime()
	{
		if (!parent.isActionType(ActionTypes.Moving) && Input.HasMove)
		{
			parent.playAnimationByType(PlayerAnimationTypes.Run);
		}
		if (Input.hasAttack(inputAttackNo))
		{
			parent.playAnimation(motionID);
		}
	}
}
