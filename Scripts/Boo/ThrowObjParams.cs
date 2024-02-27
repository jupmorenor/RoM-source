using System;
using UnityEngine;

[Serializable]
public class ThrowObjParams
{
	public Vector2 initVelocity;

	public float randVelocityXMin;

	public float randVelocityXMax;

	public float randVelocityYMin;

	public float randVelocityYMax;

	public float randRot;

	public float speedZ;

	public float speedY;

	public bool targetting;

	public float existTime;

	public GameObject destroyEffect;

	public float moveDelay;

	public GameObject hitAfterCreateObj;

	public float secScaleAdd;

	public bool adjustToLockOnY;

	public ThrowObjParams()
	{
		speedZ = 30f;
		existTime = 3f;
	}
}
