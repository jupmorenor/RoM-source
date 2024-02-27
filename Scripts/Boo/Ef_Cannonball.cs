using System;
using UnityEngine;

[Serializable]
public class Ef_Cannonball : Ef_Base
{
	public float speed;

	public float life;

	public Transform parentObj;

	public Transform ballObj;

	public Transform smkObj;

	public Transform endObj;

	private float delTime;

	private bool parent;

	public Ef_Cannonball()
	{
		speed = 15f;
		life = 1f;
	}

	public void Start()
	{
		if (!parentObj)
		{
			parentObj = transform.parent;
		}
		if ((bool)parentObj)
		{
			parent = true;
		}
		transform.parent = null;
		if (!ballObj)
		{
			ballObj = transform.Find("Ef_Cannonball");
		}
		if (!smkObj)
		{
			smkObj = transform.Find("Ef_Cannonball_Smoke");
		}
		if (!endObj)
		{
			endObj = transform.Find("Ef_Cannonball_End");
		}
		ballObj.particleSystem.Play();
		smkObj.particleSystem.Play();
		endObj.particleSystem.Stop();
		endObj.particleSystem.Clear();
	}

	public void Update()
	{
		if (delTime == 0f)
		{
			transform.Translate(Vector3.forward * speed * deltaTime);
		}
		else
		{
			delTime -= deltaTime;
			if (!(delTime >= 0f))
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
		if (life <= 0f)
		{
			return;
		}
		life -= deltaTime;
		if (parent)
		{
			if ((bool)parentObj)
			{
				transform.position = parentObj.position;
			}
			else
			{
				life = 0f;
			}
		}
		if (!(life > 0f))
		{
			Delete();
		}
	}

	public void Delete()
	{
		ballObj.particleSystem.Stop();
		ballObj.particleSystem.Clear();
		smkObj.particleSystem.Stop();
		endObj.particleSystem.Play();
		delTime = 2f;
	}
}
