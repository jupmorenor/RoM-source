using System;
using UnityEngine;

[Serializable]
public class Ef_ColliderRadiusAnim : Ef_Base
{
	public float delay;

	public float life;

	public float endRadius;

	public AnimationCurve scaleAnim;

	public float startRadius;

	public Vector3 endCenter;

	public AnimationCurve centerAnim;

	public Vector3 startCenter;

	private SphereCollider coli;

	private float fstDelay;

	private float fstLife;

	private bool ready;

	private bool cAnim;

	private float lstRadius;

	public Ef_ColliderRadiusAnim()
	{
		life = 1f;
		endRadius = 2f;
		startRadius = 0.5f;
		endCenter = Vector3.zero;
		startCenter = Vector3.zero;
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		if (ready)
		{
			delay = fstDelay;
			life = fstLife;
			UpdateCollision();
		}
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
		if (ready)
		{
			UpdateCollision();
		}
	}

	public void Init()
	{
		fstDelay = delay;
		fstLife = life;
		coli = gameObject.GetComponent<SphereCollider>();
		if ((bool)coli && life > 0f)
		{
			cAnim = startCenter != endCenter;
			ready = true;
		}
	}

	public void Update()
	{
		if (!ready || coli == null)
		{
			return;
		}
		if (!(delay <= 0f))
		{
			delay -= deltaTime;
		}
		else if (life > 0f)
		{
			life -= deltaTime;
			if (!(life > 0f))
			{
				life = 0f;
			}
			UpdateCollision();
		}
	}

	public void UpdateCollision()
	{
		float time = (fstLife - life) / fstLife;
		float num = Mathf.Lerp(startRadius, endRadius, scaleAnim.Evaluate(time));
		if (num != lstRadius)
		{
			coli.radius = num;
			coli.enabled = num > 0.1f;
			lstRadius = num;
		}
		if (cAnim)
		{
			coli.center = Vector3.Lerp(startCenter, endCenter, centerAnim.Evaluate(time));
		}
	}
}
