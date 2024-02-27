using System;
using UnityEngine;

[Serializable]
public class InAreaStates
{
	public float _damage;

	public float _speedRate;

	public Vector3 _gravMov;

	private float _yarareInterval;

	public float yarareIntervalVar;

	public float damage
	{
		get
		{
			return _damage;
		}
		set
		{
			_damage = value;
		}
	}

	public float speedRate
	{
		get
		{
			return _speedRate;
		}
		set
		{
			_speedRate = value;
		}
	}

	public Vector3 gravMov
	{
		get
		{
			return _gravMov;
		}
		set
		{
			_gravMov = value;
		}
	}

	public float yarareInterval
	{
		get
		{
			return _yarareInterval;
		}
		set
		{
			if (!(_yarareInterval > 0f))
			{
				_yarareInterval = value;
			}
			else
			{
				_yarareInterval = Mathf.Min(_yarareInterval, value);
			}
			_yarareInterval = Mathf.Max(_yarareInterval, 5f);
		}
	}

	public InAreaStates()
	{
		clear();
	}

	public void clear()
	{
		damage = 0f;
		speedRate = 1f;
		gravMov = Vector3.zero;
		yarareInterval = 5f;
		yarareIntervalVar = 0f;
	}

	public void fixedUpdate(StateChangeAreaData ad, Vector3 charPosition, float maxHitPoint)
	{
		if (ad != null)
		{
			damage += ad.damagePerSec(maxHitPoint);
			yarareIntervalVar = ad.DamageYarareInterval;
			speedRate *= ad.SpeedScale;
			gravMov += ad.gravityVel(charPosition);
		}
	}

	public void damageUpdate(MerlinActionControl ch, float dt)
	{
		if (!(ch == null) && !ChainSkillRoutine.IsPlaying)
		{
			float num = damage * dt;
			if (!(num <= 0f) && !(ch.HitPoint <= num))
			{
				ch.decHP(num);
			}
		}
	}
}
