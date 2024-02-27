using System;
using UnityEngine;

[Serializable]
public class ActionCommandMovingControl : MerlinActionControl.ActCommand
{
	public MotionID nextMotion;

	public ActionCommandMovingControl()
	{
		nextMotion = MotionID.ByType(0);
	}

	public ActionCommandMovingControl(MotionID _nextMotion)
	{
		nextMotion = _nextMotion;
	}

	public override void doUpdate(float motionTime)
	{
		if (Input.HasMove)
		{
			Vector3 moveToPosition = Input.MoveToPosition;
			parent.setMoveDir(Input.MoveToPosition - CharPosition);
		}
		else
		{
			parent.playAnimation(nextMotion);
		}
	}
}
