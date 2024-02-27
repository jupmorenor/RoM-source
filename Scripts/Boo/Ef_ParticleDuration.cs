using System;
using UnityEngine;

[Serializable]
public class Ef_ParticleDuration : Ef_Base
{
	public GameObject particleObj;

	public float delay;

	public float duration;

	private ParticleSystem ps;

	private float fstDelay;

	private float fstDuration;

	private int fstRate;

	private bool end;

	private bool ready;

	public void SetLife(float inLife)
	{
		if (!ready)
		{
			Init();
		}
		duration = inLife - fstDelay;
		if (!(duration >= 0f))
		{
			duration = 0f;
		}
		fstDuration = duration;
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		EndAndNext();
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
		EndAndNext();
	}

	public void Init()
	{
		if (particleObj == null)
		{
			particleObj = gameObject;
		}
		ps = particleObj.particleSystem;
		if (ps == null)
		{
			_ = "Ef_ParticleDuration ParticleSystem is not found. " + gameObject.name;
			return;
		}
		ps.loop = true;
		checked
		{
			int num = (int)ps.startDelay;
			if (num > 0)
			{
				delay = num;
				ps.startDelay = 0f;
			}
			if (duration == 0f)
			{
				duration = ps.duration;
			}
			fstDelay = delay;
			fstDuration = duration;
			fstRate = (int)ps.emissionRate;
			ready = true;
		}
	}

	public void Update()
	{
		if (!ready || end)
		{
			return;
		}
		float num = deltaTime;
		if (!(delay <= 0f))
		{
			delay -= num;
			if (!(delay > 0f))
			{
				ps.emissionRate = fstRate;
			}
		}
		else if (!(duration > 0f))
		{
			duration = 0f;
			ps.emissionRate = 0f;
			end = true;
		}
		else
		{
			duration -= num;
		}
	}

	public void EndAndNext()
	{
		if (ready)
		{
			delay = fstDelay;
			duration = fstDuration;
			if (delay == 0f)
			{
				ps.emissionRate = fstRate;
			}
			else
			{
				ps.emissionRate = 0f;
			}
			end = false;
		}
	}
}
