using System;
using UnityEngine;

[Serializable]
public class Ef_bow_skill5 : Ef_Base
{
	public float life;

	public float speed;

	public GameObject bombObj;

	public Ef_bow_skill5()
	{
		life = 3f;
		speed = 20f;
	}

	public void Update()
	{
		transform.Translate(new Vector3(0f, 0f, speed * deltaTime));
		life -= deltaTime;
		if (!(life > 0f))
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public void OnDestroy()
	{
		if (!Ef_Base.isShuttingDown && (bool)bombObj)
		{
			UnityEngine.Object.Instantiate(bombObj, transform.position, Quaternion.identity);
		}
	}
}
