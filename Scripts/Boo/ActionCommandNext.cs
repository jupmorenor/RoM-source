using System;

[Serializable]
public class ActionCommandNext : MerlinActionControl.ActCommand
{
	public MotionID nextMotion;

	public ActionCommandNext(MotionID motionID)
	{
		nextMotion = motionID;
	}

	public ActionCommandNext(string motionName)
	{
		nextMotion = MotionID.ByName(motionName);
	}

	public ActionCommandNext(PlayerAnimationTypes motionType)
	{
		nextMotion = MotionID.ByType((int)motionType);
	}

	public override void doUpdate(float motionTime)
	{
		MerlinMotionPackControl mmpc = parent.Mmpc;
		if (mmpc.IsEndOfMotion)
		{
			parent.playAnimation(nextMotion);
		}
	}
}
