using System;
using UnityEngine;

[Serializable]
public class SM_destroyThisTimed : Ef_Base_Js
{
	public float destroyTime;

	public float restTime;

	public bool pause;

	public SM_destroyThisTimed()
	{
		destroyTime = 5f;
	}

	public virtual void Start()
	{
		restTime = destroyTime;
		pause = false;
	}

	public virtual void Update()
	{
		if (!pause && !(restTime <= 0f))
		{
			restTime -= deltaTime;
			if (!(restTime > 0f))
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}
}
