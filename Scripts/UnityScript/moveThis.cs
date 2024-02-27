using System;
using UnityEngine;

[Serializable]
public class moveThis : Ef_Base_Js
{
	public float translationSpeedX;

	public float translationSpeedY;

	public float translationSpeedZ;

	public bool pause;

	public moveThis()
	{
		translationSpeedY = 1f;
	}

	public virtual void Update()
	{
		if (!pause)
		{
			transform.Translate(new Vector3(translationSpeedX, translationSpeedY, translationSpeedZ) * deltaTime);
		}
	}
}
