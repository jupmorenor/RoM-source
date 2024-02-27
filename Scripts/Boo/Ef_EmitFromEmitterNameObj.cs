using System;
using UnityEngine;

[Serializable]
public class Ef_EmitFromEmitterNameObj
{
	public string emitterName;

	public GameObject emitObj;

	public bool ajustRot;

	public Vector3 offsetRot;

	public bool parent;

	public Ef_EmitFromEmitterNameObj()
	{
		emitterName = string.Empty;
		offsetRot = Vector3.zero;
	}
}
