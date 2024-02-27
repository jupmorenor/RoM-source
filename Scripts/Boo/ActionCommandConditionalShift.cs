using System;
using CompilerGenerated;

[Serializable]
public class ActionCommandConditionalShift : MerlinActionControl.ActTimeCommand
{
	public __LotterySequence_startUpdateFunc_0024callable42_002410_31__ predicate;

	public MotionID shiftMotion;

	public ActionCommandConditionalShift(MotionID motId, float start, float end)
	{
		startTime = start;
		mainTime = start;
		endTime = end;
		shiftMotion = motId;
	}

	public ActionCommandConditionalShift(MotionID motId, float start, float end, __LotterySequence_startUpdateFunc_0024callable42_002410_31__ pred)
	{
		startTime = start;
		mainTime = start;
		endTime = end;
		shiftMotion = motId;
		predicate = pred;
	}

	public override void doUpdateInTime()
	{
		if (predicate != null && predicate())
		{
			parent.playAnimation(shiftMotion);
		}
	}
}
