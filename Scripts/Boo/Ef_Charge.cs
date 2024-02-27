using System;
using UnityEngine;

[Serializable]
public class Ef_Charge : Ef_Base
{
	public Color color;

	public float life;

	public GameObject flare;

	public GameObject line;

	public Ef_Charge()
	{
		color = Color.white;
		life = 1f;
	}

	public void Start()
	{
		Transform transform = null;
		if (!flare)
		{
			transform = this.transform.Find("Core/Flare");
			if (!transform)
			{
				UnityEngine.Object.Destroy(gameObject);
				return;
			}
			flare = transform.gameObject;
		}
		if (!line)
		{
			transform = this.transform.Find("Core/Line");
			if (!transform)
			{
				UnityEngine.Object.Destroy(gameObject);
				return;
			}
			line = transform.gameObject;
		}
		flare.particleSystem.startColor = color;
		line.particleSystem.startColor = color;
	}

	public void Update()
	{
		if (!(life <= 0.2f))
		{
			life -= deltaTime;
			if (!(life > 0.2f))
			{
				flare.particleSystem.emissionRate = 0f;
				line.particleSystem.emissionRate = 0f;
			}
		}
		else
		{
			life -= deltaTime;
			if (!(life > 0f))
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}
}
