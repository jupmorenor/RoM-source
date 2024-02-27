using System;
using UnityEngine;

[Serializable]
public class EffectTimeScale : MonoBehaviour
{
	public Ef_Base[] efBases;

	public ParticleSystem[] particleSystems;

	public ParticleEmitter[] particleEmitters;

	public float timeScale;

	public EffectTimeScale()
	{
		timeScale = 1f;
	}

	public void Start()
	{
		efBases = GetComponentsInChildren<Ef_Base>(includeInactive: true);
		particleSystems = GetComponentsInChildren<ParticleSystem>(includeInactive: true);
		checked
		{
			if (particleSystems != null)
			{
				int i = 0;
				ParticleSystem[] array = particleSystems;
				for (int length = array.Length; i < length; i++)
				{
					array[i].Pause(withChildren: true);
				}
			}
			particleEmitters = GetComponentsInChildren<ParticleEmitter>(includeInactive: true);
			if (particleEmitters != null)
			{
				int j = 0;
				ParticleEmitter[] array2 = particleEmitters;
				for (int length2 = array2.Length; j < length2; j++)
				{
				}
			}
		}
	}

	public void Update()
	{
		if (!(timeScale <= 10000f))
		{
			return;
		}
		checked
		{
			if (efBases != null)
			{
				int i = 0;
				Ef_Base[] array = efBases;
				for (int length = array.Length; i < length; i++)
				{
					array[i].timeScale = timeScale;
				}
			}
			if (particleSystems != null)
			{
				int j = 0;
				ParticleSystem[] array2 = particleSystems;
				for (int length2 = array2.Length; j < length2; j++)
				{
					if ((bool)array2[j])
					{
						array2[j].Simulate(Time.deltaTime * timeScale, withChildren: false, restart: false);
					}
				}
			}
			if (particleEmitters == null)
			{
				return;
			}
			int k = 0;
			ParticleEmitter[] array3 = particleEmitters;
			for (int length3 = array3.Length; k < length3; k++)
			{
				if ((bool)array3[k])
				{
					array3[k].Simulate(Time.deltaTime * timeScale);
				}
			}
		}
	}
}
