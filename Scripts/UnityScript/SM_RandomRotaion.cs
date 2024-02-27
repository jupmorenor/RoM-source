using System;
using UnityEngine;

[Serializable]
public class SM_RandomRotaion : Ef_Base_Js
{
	public float rotationMaxX;

	public float rotationMaxY;

	public float rotationMaxZ;

	public SM_RandomRotaion()
	{
		rotationMaxY = 360f;
	}

	public virtual void Start()
	{
		float xAngle = UnityEngine.Random.Range(0f - rotationMaxX, rotationMaxX);
		float yAngle = UnityEngine.Random.Range(0f - rotationMaxY, rotationMaxY);
		float zAngle = UnityEngine.Random.Range(0f - rotationMaxZ, rotationMaxZ);
		transform.Rotate(xAngle, yAngle, zAngle);
	}
}
