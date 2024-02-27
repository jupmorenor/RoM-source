using System;
using UnityEngine;

[Serializable]
public class Ef_ParticleStartRotation : MonoBehaviour
{
	public bool evelyFlame;

	public void Start()
	{
		if (!evelyFlame)
		{
			Set();
		}
	}

	public void Update()
	{
		if (evelyFlame)
		{
			Set();
		}
	}

	public void Set()
	{
		if ((bool)particleSystem)
		{
			Vector3 vector = transform.forward;
			vector.y = 0f;
			if (vector == Vector3.zero)
			{
				vector = new Vector3(0f, 0f, 1f);
			}
			float y = Quaternion.LookRotation(vector).eulerAngles.y;
			particleSystem.startRotation = y / 180f * (float)Math.PI;
		}
	}
}
