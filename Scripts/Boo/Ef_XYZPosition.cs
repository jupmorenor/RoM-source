using System;
using UnityEngine;

[Serializable]
public class Ef_XYZPosition : MonoBehaviour
{
	public Transform targetObj;

	public bool x;

	public bool y;

	public bool z;

	public float offsetX;

	public float offsetY;

	public float offsetZ;

	public bool everyFrame;

	private Vector3 pos;

	public Ef_XYZPosition()
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
		pos = transform.position;
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
		Vector3 vector = default(Vector3);
		vector = ((!targetObj) ? Vector3.zero : targetObj.position);
		if (x)
		{
			pos.x = vector.x;
		}
		if (y)
		{
			pos.y = vector.y;
		}
		if (z)
		{
			pos.z = vector.z;
		}
		transform.position = pos + new Vector3(offsetX, offsetY, offsetZ);
	}
}
