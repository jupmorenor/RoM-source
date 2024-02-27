using System;
using UnityEngine;

[Serializable]
public class Ef_ColliderSizeAnim : Ef_Base
{
	public float delay;

	public float life;

	public Vector3 endSize;

	public AnimationCurve scaleAnim;

	public Vector3 startSize;

	public Vector3 endCenter;

	public AnimationCurve centerAnim;

	public Vector3 startCenter;

	private BoxCollider coli;

	private float fstDelay;

	private float fstLife;

	private bool ready;

	private bool cAnim;

	private Vector3 lstScl;

	public Ef_ColliderSizeAnim()
	{
		life = 1f;
		endSize = new Vector3(2f, 2f, 2f);
		startSize = new Vector3(0.5f, 0.5f, 0.5f);
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
		coli = gameObject.GetComponent<BoxCollider>();
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
		Vector3 vector = Vector3.Lerp(startSize, endSize, scaleAnim.Evaluate(time));
		if (vector != lstScl)
		{
			coli.size = vector;
			BoxCollider boxCollider = coli;
			bool num = vector.x > 0.1f;
			if (num)
			{
				num = vector.y > 0.1f;
			}
			if (num)
			{
				num = vector.z > 0.1f;
			}
			boxCollider.enabled = num;
			lstScl = vector;
		}
		if (cAnim)
		{
			coli.center = Vector3.Lerp(startCenter, endCenter, centerAnim.Evaluate(time));
		}
	}
}
