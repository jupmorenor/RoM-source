using System;
using UnityEngine;

[Serializable]
public class Ef_ParticleTimeScale : MonoBehaviour
{
	public float playbackSpeed;

	public Ef_ParticleTimeScale()
	{
		playbackSpeed = 1f;
	}

	public void Start()
	{
		ParticleSystem[] componentsInChildren = GetComponentsInChildren<ParticleSystem>();
		int i = 0;
		ParticleSystem[] array = componentsInChildren;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			array[i].playbackSpeed = playbackSpeed;
		}
	}

	public void Update()
	{
	}
}
