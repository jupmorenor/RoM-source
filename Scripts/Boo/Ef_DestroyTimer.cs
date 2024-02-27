using System;
using UnityEngine;

[Serializable]
public class Ef_DestroyTimer : Ef_Base
{
	public float life;

	public Ef_DestroyTimer()
	{
		life = 1f;
	}

	public void Update()
	{
		life -= deltaTime;
		if (life >= 0f)
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
