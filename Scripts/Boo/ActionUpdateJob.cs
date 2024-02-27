using System;
using CompilerGenerated;

[Serializable]
public class ActionUpdateJob : MerlinActionControl.ActCommand
{
	private __CooldownValue_UpdateHandler_0024callable50_002433_30__ job;

	private __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ dispose;

	public ActionUpdateJob(__CooldownValue_UpdateHandler_0024callable50_002433_30__ c)
	{
		job = c;
	}

	public ActionUpdateJob(__CooldownValue_UpdateHandler_0024callable50_002433_30__ _job, __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _dispose)
	{
		job = _job;
		dispose = _dispose;
	}

	public override void doUpdate(float motionTime)
	{
		if (job != null)
		{
			job(motionTime);
		}
	}

	public override void doDispose()
	{
		base.doDispose();
		if (dispose != null)
		{
			dispose();
		}
	}
}
