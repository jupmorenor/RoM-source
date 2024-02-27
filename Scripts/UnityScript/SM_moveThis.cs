using System;
using UnityEngine;

[Serializable]
public class SM_moveThis : Ef_Base_Js
{
	public float translationSpeedX;

	public float translationSpeedY;

	public float translationSpeedZ;

	public bool local;

	public SM_moveThis()
	{
		translationSpeedY = 1f;
		local = true;
	}

	public virtual void Update()
	{
		if (local)
		{
			transform.Translate(new Vector3(translationSpeedX, translationSpeedY, translationSpeedZ) * deltaTime);
		}
		if (!local)
		{
			transform.Translate(new Vector3(translationSpeedX, translationSpeedY, translationSpeedZ) * deltaTime, Space.World);
		}
	}
}
