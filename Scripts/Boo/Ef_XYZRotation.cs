using System;
using UnityEngine;

[Serializable]
public class Ef_XYZRotation : MonoBehaviour
{
	public Transform targetObj;

	public bool x;

	public bool y;

	public bool z;

	public float offsetX;

	public float offsetY;

	public float offsetZ;

	public bool everyFrame;

	private Quaternion rot;

	public Ef_XYZRotation()
	{
		x = true;
		y = true;
		z = true;
	}

	public void Start()
	{
		if (!targetObj)
		{
			targetObj = transform.parent;
		}
		rot = transform.rotation;
		Move();
	}

	public void LateUpdate()
	{
		if (everyFrame)
		{
			Move();
		}
	}

	public void Move()
	{
		Quaternion quaternion = Quaternion.identity;
		if ((bool)targetObj)
		{
			quaternion = targetObj.rotation;
		}
		Vector3 vector = rot * Vector3.forward;
		Vector3 vector2 = quaternion * Vector3.forward;
		Vector3 forward = vector2;
		if (!x)
		{
			vector2.y = vector.y;
		}
		if (!y)
		{
			vector2.x = vector.x;
			vector2.z = vector.z;
		}
		rot = Quaternion.LookRotation(vector2, Vector3.up);
		if (z)
		{
			Quaternion quaternion2 = Quaternion.Inverse(Quaternion.LookRotation(forward, Vector3.up)) * quaternion;
			rot *= quaternion2;
		}
		transform.rotation = rot * Quaternion.Euler(new Vector3(offsetX, offsetY, offsetZ));
	}
}
