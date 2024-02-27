using System;
using UnityEngine;

[Serializable]
public class Ef_ParticleRandomDelay : MonoBehaviour
{
	public float min;

	public float max;

	public Ef_ParticleRandomDelay()
	{
		max = 1f;
	}

	public void Start()
	{
		particleSystem.Stop();
		particleSystem.Clear();
		particleSystem.startDelay = UnityEngine.Random.Range(min, max);
		particleSystem.Play();
	}

	public void Update()
	{
	}
}
