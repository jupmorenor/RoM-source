using System;
using UnityEngine;

[Serializable]
public class RibbonScript : MonoBehaviour
{
	private Vector3 parentPosLastFrame;

	private Transform myParentTransform;

	public RibbonScript()
	{
		parentPosLastFrame = Vector3.zero;
	}

	public virtual void Awake()
	{
		if (Application.loadedLevelName == "Raid")
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		else
		{
			myParentTransform = transform.parent;
		}
	}

	public virtual void Update()
	{
		rigidbody.AddForce((parentPosLastFrame - myParentTransform.position) * 500f);
		parentPosLastFrame = myParentTransform.position;
	}

	public virtual void Main()
	{
	}
}
