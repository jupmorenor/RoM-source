using System;
using UnityEngine;

[Serializable]
public class Ef_TrailDelay : Ef_Base
{
	public float delay;

	private TrailRenderer trail;

	public Ef_TrailDelay()
	{
		delay = 0.05f;
	}

	public void Start()
	{
		trail = gameObject.GetComponent<TrailRenderer>();
		if (trail != null)
		{
			trail.enabled = false;
		}
	}

	public void Update()
	{
		if (trail != null)
		{
			delay -= deltaTime;
			if (!(delay > 0f))
			{
				trail.enabled = true;
			}
		}
	}
}
