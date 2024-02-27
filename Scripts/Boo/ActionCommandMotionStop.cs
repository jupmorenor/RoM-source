using System;

[Serializable]
public class ActionCommandMotionStop : MerlinActionControl.ActTimeCommand
{
	public override bool UpdateWithWorldTime => true;

	public ActionCommandMotionStop(float startTime, float stopTime)
	{
		enableMyTimer();
		setTimeRange(startTime, stopTime);
	}

	public override bool doStart()
	{
		Mmpc.TimeScale = 0f;
		return false;
	}

	public override bool doEnd()
	{
		Mmpc.TimeScale = 1f;
		return false;
	}

	public override void doDispose()
	{
		Mmpc.TimeScale = 1f;
	}
}
