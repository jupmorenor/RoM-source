using System;
using UnityEngine;

[Serializable]
public class EffectDestroyTimer : Ef_Base_Js
{
	public float life;

	public EffectDestroyTimer()
	{
		life = 1.5f;
	}

	public virtual void Update()
	{
		life -= deltaTime;
		if (!(life > 0f))
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}
}
