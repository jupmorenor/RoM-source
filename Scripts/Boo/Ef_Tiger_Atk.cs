using System;
using UnityEngine;

[Serializable]
public class Ef_Tiger_Atk : Ef_Base
{
	public float life;

	public float speed;

	public float maxSpd;

	public float accel;

	public Transform hitObj;

	public Ef_Tiger_Atk()
	{
		life = 3f;
		speed = 2f;
		maxSpd = 10f;
		accel = 6f;
	}

	public void Update()
	{
		speed += accel * deltaTime;
		if (!(speed <= maxSpd))
		{
			speed = maxSpd;
		}
		transform.Translate(new Vector3(0f, 0f, speed * deltaTime));
		life -= deltaTime;
		if (!(life > 0f))
		{
			UnityEngine.Object.Destroy(gameObject);
			if ((bool)hitObj)
			{
				UnityEngine.Object.Instantiate(hitObj.gameObject, transform.position, transform.rotation);
			}
		}
	}
}
