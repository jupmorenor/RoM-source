using System;
using UnityEngine;

[Serializable]
public class Ef_EmitOnCharAnimTimeEmit
{
	public float emitTime;

	public GameObject emitObj;

	public string attachPath;

	public bool attach;

	public bool ajustRot;

	public Vector3 offsetPos;

	public Vector3 offsetRot;

	public int pathId;

	public Ef_EmitOnCharAnimTimeEmit()
	{
		ajustRot = true;
		pathId = -1;
	}
}
