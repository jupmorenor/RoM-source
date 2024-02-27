using System;
using UnityEngine;

[Serializable]
public class Ef_LookAt : MonoBehaviour
{
	public Transform target;

	public bool everyFrame;

	public Vector3 offsetPos;

	public bool onStart;

	public Transform upVecObj;

	private bool oneshot;

	public Ef_LookAt()
	{
		everyFrame = true;
		offsetPos = Vector3.zero;
		oneshot = true;
	}

	public void Start()
	{
		if (onStart)
		{
			LookAt();
			oneshot = false;
		}
	}

	public void LateUpdate()
	{
		if (everyFrame || oneshot)
		{
			LookAt();
			oneshot = false;
		}
	}

	public void LookAt()
	{
		if ((bool)target)
		{
			Vector3 position = transform.position;
			Vector3 forward = target.position - position;
			Vector3 vector = default(Vector3);
			vector = ((!upVecObj) ? Vector3.up : (upVecObj.position - position));
			transform.rotation = Quaternion.LookRotation(forward, vector);
		}
	}
}
