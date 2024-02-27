using System;
using UnityEngine;

[Serializable]
public class ActionCommandRestoreLife : MerlinActionControl.ActTimeCommand
{
	private float percentage;

	private float timeRange;

	private float remaining;

	public ActionCommandRestoreLife(float _start, float _end, float _percentage)
	{
		setTimeRange(_start, _end);
		timeRange = _end - _start;
		percentage = _percentage;
	}

	public override bool doStart()
	{
		remaining = parent.MaxHitPoint * percentage;
		return false;
	}

	public override bool doMain()
	{
		if (!(timeRange > 0f))
		{
			parent.HitPoint += remaining;
			remaining = 0f;
		}
		return false;
	}

	public override void doUpdateInTime()
	{
		if (!(timeRange <= 0f) && remaining > 0f)
		{
			float num = parent.MaxHitPoint * percentage / timeRange;
			float num2 = Time.deltaTime * num;
			if (!(num2 <= 0f))
			{
				parent.HitPoint = Mathf.Clamp(num2 + parent.HitPoint, 0f, parent.MaxHitPoint);
				remaining -= num2;
			}
		}
	}
}
