using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_HeightFollow4x : MonoBehaviour
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

	private float height;

	private Vector3 normal;

	private Quaternion rot;

	private Vector3 upVec;

	private Ef_Gravity grav;

	private Vector3 oldPos;

	private Quaternion oldRot;

	private bool oneshot;

	private float rotLerp;

	private Ef_HeightBuffer hBuf;

	private Vector3 lstPos;

	private Quaternion lstRot;

	private Vector3 lstScl;

	private bool useOfs;

	private Quaternion ofsRot;

	private bool fstOnStart;

	private bool fstOneshot;

	private bool ready;

	private Transform p0;

	private Transform p1;

	private Transform p2;

	private Transform p3;

	public Ef_HeightFollow4x()
	{
		fulcrumOffSet = 0.5f;
		upLength = 0.1f;
		rotToNormal = true;
		rotSoftness = 2f;
		rotOffset = Vector3.zero;
		slopeUp = 0.5f;
		normal = Vector3.up;
		upVec = Vector3.up;
		oldPos = Vector3.zero;
		oldRot = Quaternion.identity;
		oneshot = true;
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		onStart = fstOnStart;
		oneshot = fstOneshot;
		Check();
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
		Check();
	}

	public void Init()
	{
		fstOnStart = onStart;
		fstOneshot = oneshot;
		hBuf = Ef_HeightBuffer.Current;
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
		useOfs = rotOffset != Vector3.zero;
		ofsRot = Quaternion.Euler(rotOffset);
		rot = Quaternion.Inverse(ofsRot) * rotObj.rotation;
		grav = gameObject.GetComponent<Ef_Gravity>();
		if (onStart)
		{
			Follow();
			oneshot = false;
		}
		ready = true;
	}

	public void Check()
	{
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
		Quaternion rotation = transform.rotation;
		Vector3 localScale = transform.localScale;
		bool flag = false;
		bool flag2 = false;
		if (position != lstPos || rotation != lstRot || localScale != lstScl)
		{
			Vector3 vector = position + rot * new Vector3(fulcrumOffSet * localScale.x, 0f, fulcrumOffSet * localScale.z);
			Vector3 vector2 = position + rot * new Vector3((0f - fulcrumOffSet) * localScale.x, 0f, fulcrumOffSet * localScale.z);
			Vector3 vector3 = position + rot * new Vector3(fulcrumOffSet * localScale.x, 0f, (0f - fulcrumOffSet) * localScale.z);
			Vector3 vector4 = position + rot * new Vector3((0f - fulcrumOffSet) * localScale.x, 0f, (0f - fulcrumOffSet) * localScale.z);
			Vector3 vector5 = default(Vector3);
			object[] array = hBuf.GetHeight(position);
			height = RuntimeServices.UnboxSingle(array[0]);
			vector5 = (Vector3)array[1];
			object[] array2 = hBuf.GetHeight(vector);
			float num = RuntimeServices.UnboxSingle(array2[0]);
			vector5 = (Vector3)array2[1];
			if (vector.y < num || downFollow)
			{
				vector.y = num;
				flag2 = true;
			}
			object[] array3 = hBuf.GetHeight(vector2);
			float num2 = RuntimeServices.UnboxSingle(array3[0]);
			vector5 = (Vector3)array3[1];
			if (vector2.y < num2 || downFollow)
			{
				vector2.y = num2;
				flag2 = true;
			}
			object[] array4 = hBuf.GetHeight(vector3);
			float num3 = RuntimeServices.UnboxSingle(array4[0]);
			vector5 = (Vector3)array4[1];
			if (vector3.y < num3 || downFollow)
			{
				vector3.y = num3;
				flag2 = true;
			}
			object[] array5 = hBuf.GetHeight(vector4);
			float num4 = RuntimeServices.UnboxSingle(array5[0]);
			vector5 = (Vector3)array5[1];
			if (vector4.y < num4 || downFollow)
			{
				vector4.y = num4;
				flag2 = true;
			}
			float num5 = (num + num4) / 2f;
			float num6 = (num2 + num3) / 2f;
			if (!(num5 <= height))
			{
				height = num5;
			}
			if (!(num6 <= height))
			{
				height = num6;
			}
			height += upLength;
			if (!(position.y >= height))
			{
				flag = true;
			}
			Vector3 vector6 = vector4 - vector;
			Vector3 vector7 = vector2 - vector3;
			normal = new Vector3(vector6.y * vector7.z - vector6.z * vector7.y, vector6.z * vector7.x - vector6.x * vector7.z, vector6.x * vector7.y - vector6.y * vector7.x);
			if (!(slopeUp <= 0f))
			{
				height += Vector3.Angle(normal, Vector3.up) / 90f * slopeUp;
			}
		}
		if (flag || downFollow)
		{
			position.y = height;
			transform.position = position;
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
		}
		if ((flag2 || downFollow) && rotToNormal)
		{
			Quaternion quaternion = default(Quaternion);
			if (!rotUpVector)
			{
				float num7 = default(float);
				quaternion = Quaternion.FromToRotation(rot * upVec, normal) * rot;
				if (everyFrame && !(rotSoftness <= 0f))
				{
					num7 = Quaternion.Angle(rot, quaternion);
					if (!(num7 >= 20f))
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
				if (useOfs)
				{
					rotObj.rotation = rot * ofsRot;
				}
				else
				{
					rotObj.rotation = rot;
				}
			}
			else
			{
				rot = rotObj.rotation;
				quaternion = Quaternion.FromToRotation(rot * upVec, normal) * rot;
				if (everyFrame && !(rotSoftness <= 0f))
				{
					float num7 = Quaternion.Angle(rot, quaternion);
					if (!(num7 >= 20f))
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
		lstPos = position;
		lstRot = rotation;
		lstScl = localScale;
	}
}
