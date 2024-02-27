using System;
using UnityEngine;

[Serializable]
public class Ef_LookCameraBillBoard : Ef_Base
{
	public Transform cameraObj;

	public Camera cameraCom;

	public bool lookAt;

	public bool nearestCam;

	public bool evelyFlame;

	public bool horizontal;

	public bool localHorizon;

	public Vector3 rotOffset;

	private Transform parentObj;

	private Quaternion inverse;

	public Ef_LookCameraBillBoard()
	{
		evelyFlame = true;
		rotOffset = Vector3.zero;
		inverse = Quaternion.Euler(0f, 180f, 0f);
	}

	public void Start()
	{
		if ((bool)transform.parent)
		{
			parentObj = transform.parent;
		}
		else if (localHorizon)
		{
			localHorizon = false;
		}
		LookAt();
	}

	public void Update()
	{
		if (evelyFlame)
		{
			LookAt();
		}
	}

	public void LookAt()
	{
		if ((bool)cameraCom && !cameraCom.enabled)
		{
			cameraObj = null;
		}
		if ((bool)cameraObj && !cameraObj.gameObject.activeSelf)
		{
			cameraObj = null;
		}
		if (!cameraObj)
		{
			if (nearestCam)
			{
				Camera[] allCameras = Camera.allCameras;
				Vector3 position = transform.position;
				float num = 999999f;
				int i = 0;
				Camera[] array = allCameras;
				for (int length = array.Length; i < length; i = checked(i + 1))
				{
					Vector3 position2 = array[i].transform.position;
					if (!(position2 == Vector3.zero))
					{
						float sqrMagnitude = (position2 - position).sqrMagnitude;
						if (!(sqrMagnitude >= num))
						{
							cameraObj = array[i].transform;
							cameraCom = array[i];
							num = sqrMagnitude;
						}
					}
				}
				if (!cameraObj)
				{
					return;
				}
			}
			else
			{
				if (!Camera.main)
				{
					return;
				}
				cameraObj = Camera.main.transform;
				cameraCom = Camera.main;
			}
		}
		Quaternion quaternion = default(Quaternion);
		Quaternion quaternion2 = default(Quaternion);
		if (!lookAt)
		{
			quaternion2 = cameraObj.rotation * inverse;
			if (horizontal)
			{
				if (!localHorizon)
				{
					float x = 0f;
					Vector3 eulerAngles = quaternion2.eulerAngles;
					float num2 = (eulerAngles.x = x);
					Vector3 vector2 = (quaternion2.eulerAngles = eulerAngles);
				}
				else
				{
					quaternion = parentObj.rotation;
					Vector3 eulerAngles2 = (Quaternion.Inverse(quaternion) * quaternion2).eulerAngles;
					eulerAngles2.x = 0f;
					eulerAngles2.z = 0f;
					quaternion2 = quaternion * Quaternion.Euler(eulerAngles2);
				}
			}
		}
		else
		{
			Vector3 vector3 = cameraObj.position - transform.position;
			if (vector3 == Vector3.zero)
			{
				vector3 = new Vector3(0f, 0f, 0.001f);
			}
			if (horizontal)
			{
				if (!localHorizon)
				{
					vector3.y = 0f;
					quaternion2 = Quaternion.LookRotation(vector3, Vector3.up);
					if (rotOffset != Vector3.zero)
					{
						quaternion2 *= Quaternion.Euler(rotOffset);
					}
				}
				else
				{
					quaternion = parentObj.rotation;
					vector3 = Quaternion.Inverse(quaternion) * vector3;
					vector3.y = 0f;
					vector3 = quaternion * vector3;
					quaternion2 = Quaternion.LookRotation(vector3, quaternion * Vector3.up);
				}
			}
			else
			{
				quaternion2 = Quaternion.LookRotation(vector3, Vector3.up);
			}
		}
		if (rotOffset != Vector3.zero)
		{
			quaternion2 *= Quaternion.Euler(rotOffset);
		}
		transform.rotation = quaternion2;
	}
}
