using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_HeightForrow4x : MonoBehaviour
{
	public float fulcrumOffSet;

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

	private Vector3 oldPos;

	private Quaternion oldRot;

	private bool oneshot;

	private float rotLerp;

	private Ef_HeightBuffer hBuf;

	public Ef_HeightForrow4x()
	{
		fulcrumOffSet = 0.5f;
		upLength = 0.1f;
		rotToNormal = true;
		rotSoftness = 2f;
		rotOffset = Vector3.zero;
		slopeUp = 0.5f;
		upVec = Vector3.up;
		oldPos = Vector3.zero;
		oldRot = Quaternion.identity;
		oneshot = true;
	}

	public void Start()
	{
		hBuf = Ef_HeightBuffer.Current;
		if (hBuf == null)
		{
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		if (!rotObj)
		{
			rotObj = transform;
		}
		upVec = Quaternion.Inverse(rotObj.rotation) * Vector3.up;
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
		if (hBuf == null)
		{
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		Vector3 position = transform.position;
		Vector3 localScale = transform.localScale;
		Vector3 vector = position + rot * new Vector3(fulcrumOffSet * localScale.x, 0f, fulcrumOffSet * localScale.z);
		Vector3 vector2 = position + rot * new Vector3((0f - fulcrumOffSet) * localScale.x, 0f, fulcrumOffSet * localScale.z);
		Vector3 vector3 = position + rot * new Vector3(fulcrumOffSet * localScale.x, 0f, (0f - fulcrumOffSet) * localScale.z);
		Vector3 vector4 = position + rot * new Vector3((0f - fulcrumOffSet) * localScale.x, 0f, (0f - fulcrumOffSet) * localScale.z);
		Vector3 vector5 = default(Vector3);
		object[] height = hBuf.GetHeight(position);
		float num = RuntimeServices.UnboxSingle(height[0]);
		vector5 = (Vector3)height[1];
		num += upLength;
		object[] height2 = hBuf.GetHeight(vector);
		float num2 = RuntimeServices.UnboxSingle(height2[0]);
		vector5 = (Vector3)height2[1];
		if (vector.y < num2 || downFollow)
		{
			vector.y = num2;
		}
		object[] height3 = hBuf.GetHeight(vector2);
		float num3 = RuntimeServices.UnboxSingle(height3[0]);
		vector5 = (Vector3)height3[1];
		if (vector2.y < num3 || downFollow)
		{
			vector2.y = num3;
		}
		object[] height4 = hBuf.GetHeight(vector3);
		float num4 = RuntimeServices.UnboxSingle(height4[0]);
		vector5 = (Vector3)height4[1];
		if (vector3.y < num4 || downFollow)
		{
			vector3.y = num4;
		}
		object[] height5 = hBuf.GetHeight(vector4);
		float num5 = RuntimeServices.UnboxSingle(height5[0]);
		vector5 = (Vector3)height5[1];
		if (vector4.y < num5 || downFollow)
		{
			vector4.y = num5;
		}
		float num6 = (num2 + num5) / 2f;
		float num7 = (num3 + num4) / 2f;
		if (!(num6 <= num))
		{
			num = num6;
		}
		if (!(num7 <= num))
		{
			num = num7;
		}
		num += upLength;
		Vector3 vector6 = vector4 - vector;
		Vector3 vector7 = vector2 - vector3;
		Vector3 vector8 = new Vector3(vector6.y * vector7.z - vector6.z * vector7.y, vector6.z * vector7.x - vector6.x * vector7.z, vector6.x * vector7.y - vector6.y * vector7.x);
		if (!(slopeUp <= 0f))
		{
			num += Vector3.Angle(vector8, Vector3.up) / 90f * slopeUp;
		}
		if (!(transform.position.y <= num) && !downFollow)
		{
			return;
		}
		float y = num;
		Vector3 position2 = transform.position;
		float num8 = (position2.y = y);
		Vector3 vector10 = (transform.position = position2);
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
			float num9 = default(float);
			quaternion = Quaternion.FromToRotation(rot * upVec, vector8) * rot;
			if (everyFrame && !(rotSoftness <= 0f))
			{
				num9 = Quaternion.Angle(rot, quaternion);
				if (!(num9 >= 20f))
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
		quaternion = Quaternion.FromToRotation(rot * upVec, vector8) * rot;
		if (everyFrame && !(rotSoftness <= 0f))
		{
			float num9 = Quaternion.Angle(rot, quaternion);
			if (!(num9 >= 20f))
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
