using System;
using UnityEngine;

[Serializable]
public class Ef_WorldRot : Ef_Base
{
	public Vector3 euler;

	public bool evelyFlame;

	public bool startRot;

	public Ef_WorldRot()
	{
		euler = Vector3.zero;
	}

	public void Start()
	{
		if (!evelyFlame)
		{
			transform.rotation = Quaternion.Euler(euler);
		}
		else
		{
			euler = transform.rotation.eulerAngles;
		}
	}

	public void LateUpdate()
	{
		if (evelyFlame)
		{
			transform.rotation = Quaternion.Euler(euler);
		}
	}
}
