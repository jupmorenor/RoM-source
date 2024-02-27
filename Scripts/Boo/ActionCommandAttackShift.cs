using System;

[Serializable]
public class ActionCommandAttackShift : MerlinActionControl.ActTimeCommand
{
	public int inputAttackNo;

	public MotionID shiftMotion;

	public ActionCommandAttackShift(int _inputAttackNo, MotionID motionID, float start, float end)
	{
		inputAttackNo = _inputAttackNo;
		startTime = start;
		mainTime = start;
		endTime = end;
		shiftMotion = motionID;
	}

	public ActionCommandAttackShift(int _inputAttackNo, MotionID motionID)
	{
		inputAttackNo = _inputAttackNo;
		shiftMotion = motionID;
		setAllTime();
	}

	public override void doUpdateInTime()
	{
		if (Input.hasAttack(inputAttackNo) && !parent.Mmpc.HasPlayCommand)
		{
			parent.playAnimation(shiftMotion);
		}
	}
}
