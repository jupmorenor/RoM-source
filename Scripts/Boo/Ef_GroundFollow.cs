using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_GroundFollow : Ef_GroundHeight
{
	public float upLength;

	public bool everyFrame;

	public bool downFollow;

	public bool rotToNormal;

	public Transform rotObj;

	public float rotSoftness;

	public bool upVector;

	public Vector3 rotOffset;

	public float slopeUp;

	public bool onStart;

	public bool infinitieFall;

	public float infinitieHeight;

	private Quaternion rot;

	private Vector3 upVec;

	private Ef_Gravity grav;

	private Ef_FlyingObject flyo;

	private bool oneshot;

	public Ef_GroundFollow()
	{
		upLength = 0.1f;
		rotToNormal = true;
		rotSoftness = 10f;
		rotOffset = Vector3.zero;
		slopeUp = 0.5f;
		infinitieFall = true;
		infinitieHeight = -100f;
		upVec = Vector3.up;
		oneshot = true;
	}

	public override void Start()
	{
		base.Start();
		if (!rotObj)
		{
			rotObj = transform;
		}
		upVec = Quaternion.Inverse(rotObj.rotation) * Vector3.up;
		rot = Quaternion.Inverse(Quaternion.Euler(rotOffset)) * rotObj.rotation;
		grav = gameObject.GetComponent<Ef_Gravity>();
		flyo = gameObject.GetComponent<Ef_FlyingObject>();
		if (onStart)
		{
			Follow();
			oneshot = false;
		}
	}

	public void Update()
	{
		if (everyFrame || oneshot)
		{
			Follow();
			oneshot = false;
		}
	}

	public void Follow()
	{
		object[] groundHeight = GetGroundHeight(transform.position);
		bool flag = RuntimeServices.UnboxBoolean(groundHeight[0]);
		float num = RuntimeServices.UnboxSingle(groundHeight[1]);
		Vector3 vector = (Vector3)groundHeight[2];
		if (flag)
		{
			num += upLength;
		}
		else if (infinitieFall)
		{
			num = infinitieHeight + upLength;
		}
		if (!(slopeUp <= 0f))
		{
			num += Vector3.Angle(vector, Vector3.up) / 90f * slopeUp;
		}
		if (!(transform.position.y <= num) && !downFollow)
		{
			return;
		}
		float y = num;
		Vector3 position = transform.position;
		float num2 = (position.y = y);
		Vector3 vector3 = (transform.position = position);
		if ((bool)grav)
		{
			grav.Landing();
		}
		if ((bool)flyo)
		{
			flyo.Landing();
		}
		if (!rotToNormal)
		{
			return;
		}
		Quaternion quaternion = default(Quaternion);
		quaternion = ((!upVector) ? (Quaternion.FromToRotation(rot * upVec, vector) * rot) : (Quaternion.FromToRotation(rot * Vector3.up, vector) * rot));
		if (everyFrame)
		{
			float num3 = default(float);
			num3 = ((rotSoftness <= 0f || Quaternion.Angle(rot, quaternion) >= 10f) ? 1f : (60f / (1f + rotSoftness) * deltaTime));
			if (!(num3 <= 1f))
			{
				num3 = 1f;
			}
			rot = Quaternion.Lerp(rot, quaternion, num3);
		}
		else
		{
			rot = quaternion;
		}
		if (rotOffset != Vector3.zero)
		{
			rotObj.rotation = rot * Quaternion.Euler(rotOffset);
		}
		else
		{
			rotObj.rotation = rot;
		}
	}
}
