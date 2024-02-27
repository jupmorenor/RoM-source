using System;
using UnityEngine;

[Serializable]
public class ActionCommandTargetting : MerlinActionControl.ActTimeCommand
{
	[Serializable]
	public enum Type
	{
		None,
		MyTarget,
		Position
	}

	public Type type;

	public float rotationSpeed;

	public Vector3 targetPosition;

	private bool _0024initialized__ActionCommandTargetting_0024;

	public ActionCommandTargetting()
	{
		if (!_0024initialized__ActionCommandTargetting_0024)
		{
			type = Type.MyTarget;
			_0024initialized__ActionCommandTargetting_0024 = true;
		}
		startTime = 0f;
		mainTime = 0f;
		endTime = float.MaxValue;
	}

	public ActionCommandTargetting(float start, float end)
	{
		if (!_0024initialized__ActionCommandTargetting_0024)
		{
			type = Type.MyTarget;
			_0024initialized__ActionCommandTargetting_0024 = true;
		}
		startTime = start;
		mainTime = start;
		endTime = end;
	}

	public override void doUpdateInTime()
	{
		if (!(parent == null) && type != 0)
		{
			Vector3 forward = ((type != Type.MyTarget) ? (targetPosition - CharPosition) : (TargetPos - CharPosition));
			forward.y = 0f;
			Transform transform = parent.transform;
			Quaternion to = Quaternion.identity;
			if (!(forward.magnitude <= 0f))
			{
				to = Quaternion.LookRotation(forward);
			}
			transform.rotation = Quaternion.Slerp(transform.rotation, to, UpdateDeltaTime * rotationSpeed);
		}
	}
}
