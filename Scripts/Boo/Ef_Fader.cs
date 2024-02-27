using System;
using UnityEngine;

[Serializable]
public class Ef_Fader : Ef_Base
{
	public float life;

	public bool destroy;

	public Ef_Fader()
	{
		life = 1f;
		destroy = true;
	}

	public void Start()
	{
		ScreenMask.Instance.activate();
	}

	public void Update()
	{
		if (life <= 0f)
		{
			return;
		}
		life -= deltaTime;
		if (!(life > 0f))
		{
			ScreenMask.deactivate();
			if (destroy)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	public void OnDestroy()
	{
		ScreenMask.deactivate();
	}
}
