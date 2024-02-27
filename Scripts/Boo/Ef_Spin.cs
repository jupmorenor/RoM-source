using System;
using UnityEngine;

[Serializable]
public class Ef_Spin : Ef_Base
{
	public float x;

	public float y;

	public float z;

	public float randomX;

	public float randomY;

	public float randomZ;

	public bool world;

	private float xRot;

	private float yRot;

	private float zRot;

	public Ef_Spin()
	{
		world = true;
	}

	public void Start()
	{
		x += UnityEngine.Random.Range(0f - randomX, randomX);
		y += UnityEngine.Random.Range(0f - randomY, randomY);
		z += UnityEngine.Random.Range(0f - randomZ, randomZ);
		Vector3 vector = default(Vector3);
		vector = ((!world) ? transform.localRotation.eulerAngles : transform.rotation.eulerAngles);
		xRot = vector.x;
		yRot = vector.y;
		zRot = vector.z;
	}

	public void Update()
	{
		if (x != 0f)
		{
			xRot += x * deltaTime;
		}
		if (y != 0f)
		{
			yRot += y * deltaTime;
		}
		if (z != 0f)
		{
			zRot += z * deltaTime;
		}
		if (world)
		{
			Vector3 vector = new Vector3(xRot, yRot, zRot);
			Quaternion rotation = transform.rotation;
			Vector3 vector3 = (rotation.eulerAngles = vector);
			Quaternion quaternion2 = (transform.rotation = rotation);
		}
		else
		{
			Vector3 vector4 = new Vector3(xRot, yRot, zRot);
			Quaternion localRotation = transform.localRotation;
			Vector3 vector6 = (localRotation.eulerAngles = vector4);
			Quaternion quaternion4 = (transform.localRotation = localRotation);
		}
	}
}
