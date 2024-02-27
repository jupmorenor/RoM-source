using System;
using UnityEngine;

[Serializable]
public class Ef_DestroyScale : Ef_Base
{
	public float life;

	public float fadeDelay;

	private float scaleTime;

	private Vector3 fstScale;

	public Ef_DestroyScale()
	{
		life = 3f;
		fstScale = Vector3.one;
	}

	public void Start()
	{
		scaleTime = life - fadeDelay;
		fstScale = transform.localScale;
	}

	public void Update()
	{
		life -= deltaTime;
		if (!(life > scaleTime))
		{
			float num = life / scaleTime;
			if (!(num > 0.01f))
			{
				num = 0.01f;
			}
			transform.localScale = fstScale * num;
		}
		if (life > 0f)
		{
			return;
		}
		Ef_DestroyReleaseV2 component = gameObject.GetComponent<Ef_DestroyReleaseV2>();
		if (component != null)
		{
			component.Release();
		}
		else
		{
			Ef_DestroyRelease component2 = gameObject.GetComponent<Ef_DestroyRelease>();
			if (component2 != null)
			{
				component2.Release();
			}
		}
		UnityEngine.Object.Destroy(gameObject);
	}
}
