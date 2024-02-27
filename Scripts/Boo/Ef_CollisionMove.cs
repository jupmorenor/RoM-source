using System;
using UnityEngine;

[Serializable]
public class Ef_CollisionMove : MonoBehaviour
{
	public Transform positionObj;

	public bool size;

	private float fstRadius;

	private Vector3 fstSize;

	private float fstHeight;

	private SphereCollider sphere;

	private BoxCollider box;

	private CapsuleCollider capsule;

	private bool ready;

	public void Start()
	{
		sphere = gameObject.GetComponent<SphereCollider>();
		if (!sphere)
		{
			box = gameObject.GetComponent<BoxCollider>();
			if (!box)
			{
				capsule = gameObject.GetComponent<CapsuleCollider>();
				if (!capsule)
				{
					return;
				}
			}
		}
		if (sphere != null)
		{
			fstRadius = sphere.radius;
		}
		else if (box != null)
		{
			fstSize = box.size;
		}
		else if (capsule != null)
		{
			fstRadius = capsule.radius;
			fstHeight = capsule.height;
		}
		ready = true;
	}

	public void Update()
	{
		if (!ready || positionObj == null)
		{
			return;
		}
		Vector3 vector = default(Vector3);
		Vector3 vector2 = positionObj.position - transform.position;
		Vector3 center = Quaternion.Inverse(transform.rotation) * vector2;
		if (sphere != null)
		{
			sphere.center = center;
			if (size)
			{
				vector = positionObj.localScale;
				sphere.enabled = vector != Vector3.zero;
				sphere.radius = fstRadius * vector.x;
			}
		}
		else if (box != null)
		{
			box.center = center;
			if (size)
			{
				vector = positionObj.localScale;
				box.enabled = vector != Vector3.zero;
				box.size = Vector3.Scale(fstSize, vector);
			}
		}
		else if (capsule != null)
		{
			capsule.center = center;
			if (size)
			{
				vector = positionObj.localScale;
				capsule.enabled = vector != Vector3.zero;
				capsule.radius = fstRadius * vector.x;
				capsule.height = fstHeight * vector.y;
			}
		}
	}
}
