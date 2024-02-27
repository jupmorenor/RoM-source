using System;
using UnityEngine;

[Serializable]
public class Ef_LookCameraParticleSizeObj
{
	public GameObject particleObj;

	public float distanceToSpeed;

	public float distanceToSize;

	private ParticleSystem particleSys;

	public Ef_LookCameraParticleSizeObj()
	{
		distanceToSpeed = 0.01f;
		distanceToSize = 0.8f;
	}

	public void Setsize(float dist)
	{
		if (!particleObj)
		{
			return;
		}
		ParticleSystem particleSystem = particleObj.particleSystem;
		if ((bool)particleSystem)
		{
			if (distanceToSize != 0f)
			{
				particleSystem.startSize = dist * distanceToSize;
			}
			if (distanceToSpeed != 0f)
			{
				particleSystem.startSpeed = dist * distanceToSpeed;
			}
		}
		else if (distanceToSize != 0f)
		{
			float num = dist * distanceToSize;
			particleObj.transform.localScale = new Vector3(num, num, num);
		}
	}
}
