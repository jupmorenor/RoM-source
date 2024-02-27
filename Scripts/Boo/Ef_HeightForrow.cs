using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_HeightForrow : MonoBehaviour
{
	public float upLength;

	public bool everyFrame;

	public bool downFollow;

	public bool rotToNormal;

	public Transform rotObj;

	public float rotSoftness;

	public bool upVector;

	public Vector3 rotOffset;

	public bool rotUpVector;

	public float slopeUp;

	public bool onStart;

	public float boundForGravity;

	private Quaternion rot;

	private Vector3 upVec;

	private Ef_Gravity grav;

	private bool oneshot;

	private Ef_HeightBuffer hiBuf;

	public Ef_HeightForrow()
	{
		upLength = 0.1f;
		rotToNormal = true;
		rotSoftness = 2f;
		upVector = true;
		rotOffset = Vector3.zero;
		slopeUp = 0.5f;
		upVec = Vector3.up;
		oneshot = true;
	}

	public void Start()
	{
		hiBuf = Ef_HeightBuffer.Current;
		if (hiBuf == null)
		{
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		if (!rotObj)
		{
			rotObj = transform;
		}
		if (upVector)
		{
			upVec = Vector3.up;
		}
		else
		{
			upVec = Quaternion.Inverse(rotObj.rotation) * Vector3.up;
		}
		rot = Quaternion.Inverse(Quaternion.Euler(rotOffset)) * rotObj.rotation;
		grav = gameObject.GetComponent<Ef_Gravity>();
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
		if (hiBuf == null)
		{
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		Vector3 position = transform.position;
		object[] height = hiBuf.GetHeight(position);
		float num = RuntimeServices.UnboxSingle(height[0]);
		Vector3 vector = (Vector3)height[1];
		num += upLength;
		if (!(slopeUp <= 0f))
		{
			num += Vector3.Angle(vector, Vector3.up) / 90f * slopeUp;
		}
		if (!(position.y >= num))
		{
			position.y = num;
			transform.position = position;
		}
		if (!(transform.position.y <= num) && !downFollow)
		{
			return;
		}
		float y = num;
		Vector3 position2 = transform.position;
		float num2 = (position2.y = y);
		Vector3 vector3 = (transform.position = position2);
		if (!(boundForGravity <= 0f))
		{
			if ((bool)grav)
			{
				grav.upSpeed = Mathf.Abs(grav.upSpeed) * boundForGravity;
				if (!(grav.upSpeed >= 1f))
				{
					boundForGravity = 0f;
				}
			}
		}
		else if ((bool)grav)
		{
			grav.Landing();
		}
		if (!rotToNormal)
		{
			return;
		}
		Quaternion quaternion = default(Quaternion);
		if (!rotUpVector)
		{
			float num3 = default(float);
			quaternion = Quaternion.FromToRotation(rot * upVec, vector) * rot;
			if (everyFrame && !(rotSoftness <= 0f))
			{
				num3 = Quaternion.Angle(rot, quaternion);
				if (!(num3 >= 20f))
				{
					rot = Quaternion.Lerp(rot, quaternion, 1f / (1f + rotSoftness));
				}
				else
				{
					rot = quaternion;
				}
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
			return;
		}
		rot = rotObj.rotation;
		quaternion = Quaternion.FromToRotation(rot * upVec, vector) * rot;
		if (everyFrame && !(rotSoftness <= 0f))
		{
			float num3 = Quaternion.Angle(rot, quaternion);
			if (!(num3 >= 20f))
			{
				rot = Quaternion.Lerp(rot, quaternion, 1f / (1f + rotSoftness));
			}
			else
			{
				rot = quaternion;
			}
		}
		else
		{
			rot = quaternion;
		}
		rotObj.rotation = rot;
	}
}
