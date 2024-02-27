using System;
using UnityEngine;

[Serializable]
public class Ef_Gravity : Ef_Base
{
	public float gravity;

	public float fstUp;

	public float upSpeed;

	private float lstY;

	public Ef_Gravity()
	{
		gravity = 9.8f;
		fstUp = 5f;
		lstY = -9999f;
	}

	public void OnActive()
	{
		upSpeed = fstUp;
		lstY = -9999f;
	}

	public void Start()
	{
		upSpeed += fstUp;
	}

	public void Update()
	{
		float num = deltaTime;
		float y = transform.position.y;
		if (!(upSpeed >= 0f) && !(y <= lstY))
		{
			upSpeed = 0f;
		}
		y += upSpeed * num;
		float y2 = y;
		Vector3 position = transform.position;
		float num2 = (position.y = y2);
		Vector3 vector2 = (transform.position = position);
		lstY = y;
		upSpeed -= gravity * num;
		if (!(upSpeed >= -20f))
		{
			upSpeed = -20f;
		}
	}

	public void Landing()
	{
		upSpeed = 0f;
	}
}
