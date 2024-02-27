using System;
using UnityEngine;

[Serializable]
public class SM_animSpeedRandomizer : Ef_Base_Js
{
	public float minSpeed;

	public float maxSpeed;

	public float speed;

	public SM_animSpeedRandomizer()
	{
		minSpeed = 0.7f;
		maxSpeed = 1.5f;
		speed = 1f;
	}

	public virtual void Start()
	{
		speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
	}

	public virtual void Update()
	{
		animation[animation.clip.name].speed = speed * timeScale;
	}
}
