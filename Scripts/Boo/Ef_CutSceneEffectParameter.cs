using System;
using UnityEngine;

[Serializable]
public class Ef_CutSceneEffectParameter
{
	public int frame;

	public GameObject effectObj;

	public string attachObj;

	public Vector3 offsetPos;

	public Vector3 offsetRot;

	public Ef_CutSceneEffectParameter()
	{
		attachObj = string.Empty;
		offsetPos = Vector3.zero;
		offsetRot = Vector3.zero;
	}
}
