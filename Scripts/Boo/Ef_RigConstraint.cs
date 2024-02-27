using System;
using UnityEngine;

[Serializable]
public class Ef_RigConstraint : MonoBehaviour
{
	public Transform baseObj;

	public Transform targetObj;

	public bool position;

	public bool rotation;

	public bool scale;

	public bool world;

	public bool onLateUpdate;

	public Ef_RigConstraint()
	{
		world = true;
		onLateUpdate = true;
	}

	public void Start()
	{
		if (!baseObj)
		{
			baseObj = transform;
		}
		if ((bool)baseObj && (bool)targetObj)
		{
			UpdateConstraint();
		}
	}

	public void Update()
	{
		if (!onLateUpdate && (bool)baseObj && (bool)targetObj)
		{
			UpdateConstraint();
		}
	}

	public void LateUpdate()
	{
		if (onLateUpdate && (bool)baseObj && (bool)targetObj)
		{
			UpdateConstraint();
		}
	}

	public void UpdateConstraint()
	{
		if (position)
		{
			if (world)
			{
				targetObj.position = baseObj.position;
			}
			else
			{
				targetObj.localPosition = baseObj.localPosition;
			}
		}
		if (rotation)
		{
			if (world)
			{
				targetObj.rotation = baseObj.rotation;
			}
			else
			{
				targetObj.localRotation = baseObj.localRotation;
			}
		}
		if (scale)
		{
			targetObj.localScale = baseObj.localScale;
		}
	}
}
