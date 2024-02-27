using System;
using UnityEngine;

[Serializable]
public class ActionCommandTranslate : MerlinActionControl.ActTimeCommand
{
	private ActionDirections direction;

	private float speed;

	public ActionCommandTranslate(float start, float end, ActionDirections dir, float spd)
	{
		startTime = start;
		mainTime = start;
		endTime = end;
		direction = dir;
		speed = spd;
	}

	public override void doUpdateInTime()
	{
		if (!(parent == null))
		{
			float updateDeltaTime = UpdateDeltaTime;
			Transform transform = parent.transform;
			Vector3 moveDir = default(Vector3);
			if (direction == ActionDirections.Forward)
			{
				moveDir = transform.forward;
			}
			else if (direction == ActionDirections.Left)
			{
				moveDir = -transform.right;
			}
			else if (direction == ActionDirections.Backward)
			{
				moveDir = -transform.forward;
			}
			else if (direction == ActionDirections.Right)
			{
				moveDir = transform.right;
			}
			float moveSpeed = speed * parent.MoveCommandSpeedScale;
			parent.MoveSpeed = moveSpeed;
			parent.MoveDir = moveDir;
		}
	}

	public override bool doEnd()
	{
		if (!(parent == null))
		{
			parent.MoveSpeed = 0f;
		}
		return false;
	}
}
