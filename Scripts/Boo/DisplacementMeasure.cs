using System;
using UnityEngine;

[Serializable]
public class DisplacementMeasure
{
	private Vector3 prevPos;

	private Vector3 curPos;

	public float length => (prevPos - curPos).magnitude;

	public void updateCurrentPos(float dt, Vector3 p)
	{
		if (dt > 0f)
		{
			prevPos = curPos;
			curPos = p;
		}
	}
}
