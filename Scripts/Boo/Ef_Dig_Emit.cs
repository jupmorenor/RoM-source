using System;
using UnityEngine;

[Serializable]
public class Ef_Dig_Emit : Ef_Base
{
	public GameObject emitObj;

	public float delay;

	public float life;

	public int rate;

	private float cut;

	private int bullet;

	public Ef_Dig_Emit()
	{
		delay = 1f;
		life = 2f;
		rate = 4;
	}

	public void Start()
	{
		if (!emitObj)
		{
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		cut = 1f / (float)rate;
		bullet = Mathf.FloorToInt(life / cut);
	}

	public void Update()
	{
		if (!(delay <= 0f))
		{
			delay -= deltaTime;
			return;
		}
		checked
		{
			if (Mathf.FloorToInt(life / cut) < bullet)
			{
				UnityEngine.Object.Instantiate(emitObj, transform.position, Quaternion.identity);
				bullet--;
			}
			life -= deltaTime;
			if (!(life > 0f))
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}
}
