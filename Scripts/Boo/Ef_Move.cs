using System;
using UnityEngine;

[Serializable]
public class Ef_Move : Ef_Base
{
	public float speed;

	public float accel;

	public float targetSpd;

	public float angOffset;

	private Vector3 nrmVel;

	private float fstSpd;

	private bool ready;

	public Ef_Move()
	{
		speed = 6f;
		accel = 6f;
		targetSpd = 6f;
	}

	public void OnActive()
	{
		speed = fstSpd;
		nrmVel = Quaternion.Euler(0f, 0f - angOffset, 0f) * transform.forward;
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
		nrmVel = Quaternion.Euler(0f, 0f - angOffset, 0f) * transform.forward;
	}

	public void Init()
	{
		fstSpd = speed;
		ready = true;
	}

	public void Update()
	{
		Vector3 position = transform.position;
		Vector3 vector = nrmVel * speed;
		position += vector * deltaTime;
		if (!(speed >= targetSpd))
		{
			speed += accel * deltaTime;
			if (!(speed <= targetSpd))
			{
				speed = targetSpd;
			}
		}
		else if (!(speed <= targetSpd))
		{
			speed -= accel * deltaTime;
			if (!(speed >= targetSpd))
			{
				speed = targetSpd;
			}
		}
		transform.position = position;
	}
}
