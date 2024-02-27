using System;
using UnityEngine;

[Serializable]
public class Ef_Rush_Atk : Ef_Base
{
	public float speed;

	public float life;

	public Ef_Rush_Atk()
	{
		speed = 8f;
		life = 1f;
	}

	public void Start()
	{
	}

	public void Update()
	{
		transform.Translate(new Vector3(0f, 0f, speed * deltaTime));
		life -= deltaTime;
		if (!(life >= 0f))
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}
}
