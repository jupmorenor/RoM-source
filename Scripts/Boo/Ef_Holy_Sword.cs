using System;
using UnityEngine;

[Serializable]
public class Ef_Holy_Sword : Ef_Base
{
	public float life;

	public float speed;

	public Ef_Holy_Sword()
	{
		life = 10f;
	}

	public void Update()
	{
		if (!(speed <= 0f))
		{
			transform.Translate(new Vector3(0f, 0f, speed * deltaTime));
		}
		life -= deltaTime;
		if (!(life > 0f))
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}
}
