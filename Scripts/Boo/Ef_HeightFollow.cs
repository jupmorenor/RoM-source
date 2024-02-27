using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_HeightFollow : MonoBehaviour
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

	private float height;

	private Vector3 normal;

	private Quaternion rot;

	private Vector3 upVec;

	private Ef_Gravity grav;

	private bool oneshot;

	private Ef_HeightBuffer hBuf;

	private Vector3 lstPos;

	private bool useOfs;

	private Quaternion ofsRot;

	private bool fstOnStart;

	private bool fstOneshot;

	private bool ready;

	public Ef_HeightFollow()
	{
		upLength = 0.1f;
		rotToNormal = true;
		rotSoftness = 2f;
		upVector = true;
		rotOffset = Vector3.zero;
		slopeUp = 0.5f;
		normal = Vector3.up;
		upVec = Vector3.up;
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
			hBuf = Ef_HeightBuffer.Current;
			if (hBuf == null)
			{
				UnityEngine.Object.Destroy(gameObject);
				return;
			}
		}
		Vector3 position = transform.position;
		bool flag = false;
		if (position != lstPos)
		{
			object[] array = hBuf.GetHeight(position);
			height = RuntimeServices.UnboxSingle(array[0]);
			normal = (Vector3)array[1];
			height += upLength;
			if (!(slopeUp <= 0f))
			{
				height += Vector3.Angle(normal, Vector3.up) / 90f * slopeUp;
			}
			if (!(position.y >= height))
			{
				flag = true;
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
			if (rotToNormal)
			{
				Quaternion quaternion = default(Quaternion);
				if (!rotUpVector)
				{
					float num = default(float);
					quaternion = Quaternion.FromToRotation(rot * upVec, normal) * rot;
					if (everyFrame && !(rotSoftness <= 0f))
					{
						num = Quaternion.Angle(rot, quaternion);
						if (!(num >= 20f))
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
						float num = Quaternion.Angle(rot, quaternion);
						if (!(num >= 20f))
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
		}
		lstPos = position;
	}
}
