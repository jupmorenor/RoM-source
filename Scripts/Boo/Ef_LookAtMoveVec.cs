using System;
using UnityEngine;

[Serializable]
public class Ef_LookAtMoveVec : Ef_Base
{
	public Vector3 rotOffset;

	public bool quaternion;

	public bool horizontal;

	private Quaternion rot;

	private Vector3 lstPos;

	private Quaternion ofsRot;

	public Ef_LookAtMoveVec()
	{
		rotOffset = Vector3.zero;
		lstPos = Vector3.zero;
	}

	public void Start()
	{
		ofsRot = Quaternion.Euler(rotOffset);
		rot = transform.rotation * Quaternion.Inverse(ofsRot);
	}

	public void Update()
	{
		Vector3 vector = transform.position - lstPos;
		if (vector != Vector3.zero)
		{
			Vector3 up = Vector3.up;
			if ((bool)transform.parent)
			{
				up = transform.parent.up;
			}
			if (horizontal)
			{
				vector.y = 0f;
			}
			if (!quaternion)
			{
				transform.rotation = Quaternion.LookRotation(vector, up) * ofsRot;
			}
			else
			{
				transform.rotation = Quaternion.FromToRotation(rot * Vector3.forward, vector) * rot * ofsRot;
			}
		}
		lstPos = transform.position;
	}
}
