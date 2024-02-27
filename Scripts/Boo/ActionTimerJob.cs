using System;
using System.Text;
using Boo.Lang;
using CompilerGenerated;

[Serializable]
public class ActionTimerJob : MerlinActionControl.ActTimeCommand
{
	public string myName;

	public __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ job;

	public __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ startJob;

	public __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ endJob;

	public __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ disposeJob;

	public __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ inTimeJob;

	private bool _0024initialized__ActionTimerJob_0024;

	public ActionTimerJob(float time, ICallable _job)
	{
		if (!_0024initialized__ActionTimerJob_0024)
		{
			myName = "ActionTimerJob";
			_0024initialized__ActionTimerJob_0024 = true;
		}
		setJustTime(time);
		job = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)_job;
	}

	public ActionTimerJob(float start, float end)
	{
		if (!_0024initialized__ActionTimerJob_0024)
		{
			myName = "ActionTimerJob";
			_0024initialized__ActionTimerJob_0024 = true;
		}
		setTimeRange(start, end);
	}

	public ActionTimerJob(float start, float end, ICallable _job)
	{
		if (!_0024initialized__ActionTimerJob_0024)
		{
			myName = "ActionTimerJob";
			_0024initialized__ActionTimerJob_0024 = true;
		}
		setTimeRange(start, end);
		job = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)_job;
	}

	public override bool doStart()
	{
		if (startJob != null)
		{
			startJob();
		}
		return true;
	}

	public override bool doMain()
	{
		if (job != null)
		{
			job();
		}
		return true;
	}

	public override void doUpdateInTime()
	{
		if (inTimeJob != null)
		{
			inTimeJob();
		}
	}

	public override bool doEnd()
	{
		if (endJob != null)
		{
			endJob();
		}
		return true;
	}

	public override void doDispose()
	{
		if (disposeJob != null)
		{
			disposeJob();
		}
		base.doDispose();
	}

	public override string ToString()
	{
		return myName + new StringBuilder(": time ").Append(startTime).Append("/").Append(endTime)
			.ToString();
	}
}
