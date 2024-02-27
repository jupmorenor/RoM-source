using System;

[Serializable]
public class rampDownParticle : Ef_Base_Js
{
	public float delayTime;

	public float delayPlusTime;

	public float rampDownTime;

	public float origMinEmission;

	public float origMaxEmission;

	public bool pause;

	public rampDownParticle()
	{
		rampDownTime = 1f;
	}

	public virtual void Start()
	{
		origMinEmission = particleEmitter.minEmission;
		origMaxEmission = particleEmitter.maxEmission;
		particleEmitter.emit = false;
	}

	public virtual void Update()
	{
		if (pause)
		{
			return;
		}
		if (!(delayTime + delayPlusTime <= 0f))
		{
			delayTime -= deltaTime;
		}
		if (!(delayTime > 0f) && !particleEmitter.emit)
		{
			particleEmitter.emit = true;
		}
		if (!(delayTime + delayPlusTime > 0f))
		{
			particleEmitter.minEmission = origMinEmission * rampDownTime;
			particleEmitter.maxEmission = origMaxEmission * rampDownTime;
			rampDownTime -= deltaTime;
			if (!(rampDownTime >= 0f))
			{
				rampDownTime = 0f;
			}
		}
	}
}
