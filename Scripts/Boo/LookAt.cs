using System;
using UnityEngine;

[Serializable]
public class LookAt : MonoBehaviour
{
	public Transform rotationObj;

	public Transform lookTargetObj;

	public Transform upVectorObj;

	public bool onLateUpdate;

	public LookAt()
	{
		onLateUpdate = true;
	}

	public void Start()
	{
		if (!rotationObj)
		{
			rotationObj = transform;
		}
		if ((bool)rotationObj && (bool)lookTargetObj)
		{
			UpdateLookAt();
		}
	}

	public void Update()
	{
		if (!onLateUpdate && (bool)rotationObj && (bool)lookTargetObj)
		{
			UpdateLookAt();
		}
	}

	public void LateUpdate()
	{
		if (onLateUpdate && (bool)rotationObj && (bool)lookTargetObj)
		{
			UpdateLookAt();
		}
	}

	public void UpdateLookAt()
	{
		Vector3 position = rotationObj.position;
		Vector3 forward = lookTargetObj.position - position;
		Vector3 vector = default(Vector3);
		if ((bool)upVectorObj)
		{
			vector = upVectorObj.position - position;
			if (vector == Vector3.zero)
			{
				vector = Vector3.up;
			}
		}
		else
		{
			vector = Vector3.up;
		}
		rotationObj.rotation = Quaternion.LookRotation(forward, vector);
	}
}
