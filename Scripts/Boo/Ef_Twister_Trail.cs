using System;
using UnityEngine;

[Serializable]
public class Ef_Twister_Trail : Ef_Base
{
	public Transform camObj;

	public float fstDist;

	public float speed;

	private TrailRenderer trail;

	public Ef_Twister_Trail()
	{
		fstDist = 10f;
		speed = 30f;
	}

	public void Start()
	{
		transform.localPosition = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f) * new Vector3(0f, UnityEngine.Random.Range(0.5f, 3f), UnityEngine.Random.Range(2f, fstDist));
		if (!camObj)
		{
			Camera main = Camera.main;
			if ((bool)main)
			{
				camObj = main.transform;
			}
		}
		trail = gameObject.GetComponent<TrailRenderer>();
	}

	public void Update()
	{
		Vector3 forward = -transform.localPosition;
		forward.y = 0f;
		Quaternion quaternion = Quaternion.LookRotation(forward, Vector3.up);
		Vector3 vector = quaternion * new Vector3(1f, 0f, 0.2f);
		transform.localPosition += vector * speed * deltaTime;
		float magnitude = forward.magnitude;
		if (!(magnitude <= fstDist - 3f))
		{
			trail.startWidth = Mathf.Min((fstDist - magnitude - 2f) / 3f, 1f) * 0.4f;
			trail.endWidth = trail.startWidth * 2f;
			if (!(trail.startWidth <= 0f) && !trail.enabled)
			{
				trail.enabled = true;
			}
		}
		else if (!(magnitude >= 3f))
		{
			trail.startWidth = Mathf.Max(magnitude - 2f, 0f) * 0.4f;
			trail.endWidth = trail.startWidth * 2f;
			if (!(magnitude >= 2f))
			{
				trail.enabled = false;
				transform.localPosition = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f) * new Vector3(0f, UnityEngine.Random.Range(0.5f, 3f), fstDist);
			}
		}
		else
		{
			trail.startWidth = 0.4f;
			trail.endWidth = trail.startWidth * 2f;
		}
		if ((bool)camObj)
		{
			transform.rotation = camObj.rotation;
		}
	}
}
