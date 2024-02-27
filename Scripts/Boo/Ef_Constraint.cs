using System;
using UnityEngine;

[Serializable]
public class Ef_Constraint : MonoBehaviour
{
	public Transform parentObj;

	public bool x;

	public bool y;

	public bool z;

	public bool rotation;

	public bool horizonRot;

	public bool upVector;

	public bool preservation;

	private Vector3 ofsPos;

	private Quaternion ofsRot;

	private bool ready;

	public Ef_Constraint()
	{
		x = true;
		y = true;
		z = true;
		preservation = true;
		ofsPos = Vector3.zero;
		ofsRot = Quaternion.identity;
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
	}

	public void Init()
	{
		if (!parentObj)
		{
			parentObj = transform.parent;
			if (parentObj == null)
			{
				return;
			}
		}
		if (preservation)
		{
			ofsPos = transform.position - parentObj.position;
			ofsRot = Quaternion.Inverse(parentObj.rotation) * transform.rotation;
		}
		ready = true;
	}

	public void Update()
	{
		if (!ready || parentObj == null)
		{
			return;
		}
		Vector3 position = transform.position;
		Vector3 position2 = parentObj.position;
		Quaternion quaternion = parentObj.rotation;
		if (preservation)
		{
			position2 += quaternion * ofsPos;
		}
		if (x)
		{
			position.x = position2.x;
		}
		if (y)
		{
			position.y = position2.y;
		}
		if (z)
		{
			position.z = position2.z;
		}
		transform.position = position;
		if (rotation)
		{
			if (preservation)
			{
				quaternion *= ofsRot;
			}
			if (horizonRot)
			{
				quaternion.eulerAngles = new Vector3(0f, quaternion.eulerAngles.y, 0f);
			}
			else if (upVector)
			{
				quaternion = Quaternion.LookRotation(quaternion * Vector3.forward, Vector3.up);
			}
			transform.rotation = quaternion;
		}
	}
}
