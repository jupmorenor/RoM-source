using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_GroundFollow4x : Ef_GroundHeight
{
	public Vector3 fulcrum0;

	public Vector3 fulcrum1;

	public Vector3 fulcrum2;

	public Vector3 fulcrum3;

	public float upLength;

	public bool everyFrame;

	public bool downFollow;

	public bool rotToNormal;

	public float rotSoftness;

	public bool upVector;

	public Vector3 rotOffset;

	public float slopeUp;

	public bool infinitieFall;

	public float infinitieHeight;

	private Quaternion rot;

	private Vector3 upVec;

	private Ef_Gravity grav;

	private Ef_FlyingObject flyo;

	private Vector3 oldPos;

	private Quaternion oldRot;

	private bool oneshot;

	private float rotLerp;

	public Ef_GroundFollow4x()
	{
		fulcrum0 = new Vector3(-0.5f, 0f, 0.5f);
		fulcrum1 = new Vector3(0.5f, 0f, 0.5f);
		fulcrum2 = new Vector3(-0.5f, 0f, -0.5f);
		fulcrum3 = new Vector3(0.5f, 0f, -0.5f);
		upLength = 0.1f;
		rotToNormal = true;
		rotSoftness = 10f;
		rotOffset = Vector3.zero;
		slopeUp = 0.5f;
		infinitieFall = true;
		infinitieHeight = -100f;
		upVec = Vector3.up;
		oldPos = Vector3.zero;
		oldRot = Quaternion.identity;
		oneshot = true;
	}

	public override void Start()
	{
		base.Start();
		upVec = Quaternion.Inverse(transform.rotation) * Vector3.up;
		rot = Quaternion.Inverse(Quaternion.Euler(rotOffset)) * transform.rotation;
		grav = gameObject.GetComponent<Ef_Gravity>();
		flyo = gameObject.GetComponent<Ef_FlyingObject>();
		if (!(rotSoftness <= 0f))
		{
			rotLerp = 60f / (1f + rotSoftness);
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
		Vector3 position = transform.position;
		Vector3 localScale = transform.localScale;
		Vector3 vector = rot * new Vector3(fulcrum0.x * localScale.x, fulcrum0.y * localScale.y, fulcrum0.z * localScale.z);
		Vector3 vector2 = rot * new Vector3(fulcrum1.x * localScale.x, fulcrum1.y * localScale.y, fulcrum1.z * localScale.z);
		Vector3 vector3 = rot * new Vector3(fulcrum2.x * localScale.x, fulcrum2.y * localScale.y, fulcrum2.z * localScale.z);
		Vector3 vector4 = rot * new Vector3(fulcrum3.x * localScale.x, fulcrum3.y * localScale.y, fulcrum3.z * localScale.z);
		Vector3 vector5 = default(Vector3);
		object[] groundHeight = GetGroundHeight(position + vector);
		bool flag = RuntimeServices.UnboxBoolean(groundHeight[0]);
		float num = RuntimeServices.UnboxSingle(groundHeight[1]);
		vector5 = (Vector3)groundHeight[2];
		if (flag)
		{
			num += upLength;
		}
		else if (infinitieFall)
		{
			num = infinitieHeight + upLength;
		}
		object[] groundHeight2 = GetGroundHeight(position + vector2);
		bool flag2 = RuntimeServices.UnboxBoolean(groundHeight2[0]);
		float num2 = RuntimeServices.UnboxSingle(groundHeight2[1]);
		vector5 = (Vector3)groundHeight2[2];
		if (flag2)
		{
			num2 += upLength;
		}
		else if (infinitieFall)
		{
			num2 = infinitieHeight + upLength;
		}
		object[] groundHeight3 = GetGroundHeight(position + vector3);
		bool flag3 = RuntimeServices.UnboxBoolean(groundHeight3[0]);
		float num3 = RuntimeServices.UnboxSingle(groundHeight3[1]);
		vector5 = (Vector3)groundHeight3[2];
		if (flag3)
		{
			num3 += upLength;
		}
		else if (infinitieFall)
		{
			num3 = infinitieHeight + upLength;
		}
		object[] groundHeight4 = GetGroundHeight(position + vector4);
		bool flag4 = RuntimeServices.UnboxBoolean(groundHeight4[0]);
		float num4 = RuntimeServices.UnboxSingle(groundHeight4[1]);
		vector5 = (Vector3)groundHeight4[2];
		if (flag4)
		{
			num4 += upLength;
		}
		else if (infinitieFall)
		{
			num4 = infinitieHeight + upLength;
		}
		object[] groundHeight5 = GetGroundHeight(position);
		bool flag5 = RuntimeServices.UnboxBoolean(groundHeight5[0]);
		float num5 = RuntimeServices.UnboxSingle(groundHeight5[1]);
		vector5 = (Vector3)groundHeight5[2];
		if (flag5)
		{
			num5 += upLength;
		}
		else if (infinitieFall)
		{
			num5 = infinitieHeight + upLength;
		}
		float num6 = (num + num4) / 2f;
		float num7 = (num2 + num3) / 2f;
		if (!(num6 <= num5))
		{
			num5 = num6;
		}
		if (!(num7 <= num5))
		{
			num5 = num7;
		}
		Vector3 vector6 = default(Vector3);
		Vector3 vector7 = default(Vector3);
		Vector3 vector8 = default(Vector3);
		vector7 = new Vector3(vector.x - vector4.x, num - num4, vector.z - vector4.z);
		Quaternion quaternion = Quaternion.FromToRotation(vector, vector7);
		vector8 = new Vector3(vector2.x - vector3.x, 0f, vector2.z - vector3.z);
		Vector3 toDirection = new Vector3(vector8.x, num2 - num3, vector8.z);
		Quaternion quaternion2 = Quaternion.FromToRotation(quaternion * vector8, toDirection);
		vector6 = quaternion2 * quaternion * Vector3.up;
		if (!(slopeUp <= 0f))
		{
			num5 += Vector3.Angle(vector6, Vector3.up) / 90f * slopeUp;
		}
		if (!(transform.position.y <= num5) && !downFollow)
		{
			return;
		}
		float y = num5;
		Vector3 position2 = transform.position;
		float num8 = (position2.y = y);
		Vector3 vector10 = (transform.position = position2);
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
		Quaternion quaternion3 = default(Quaternion);
		quaternion3 = ((!upVector) ? (Quaternion.FromToRotation(rot * upVec, vector6) * rot) : (Quaternion.FromToRotation(rot * Vector3.up, vector6) * rot));
		if (everyFrame && !(rotSoftness <= 0f))
		{
			float num9 = rotLerp * deltaTime;
			if (!(num9 <= 1f))
			{
				num9 = 1f;
			}
			rot = Quaternion.Lerp(rot, quaternion3, num9);
		}
		else
		{
			rot = quaternion3;
		}
		if (rotOffset != Vector3.zero)
		{
			transform.rotation = rot * Quaternion.Euler(rotOffset);
		}
		else
		{
			transform.rotation = rot;
		}
	}
}
