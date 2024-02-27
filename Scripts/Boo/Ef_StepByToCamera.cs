using System;
using UnityEngine;

[Serializable]
public class Ef_StepByToCamera : Ef_Base
{
	public float distance;

	public Transform cameraObj;

	public bool nearestCam;

	public int retryCount;

	public bool fstPosScale;

	private Transform parent;

	private Vector3 fstPos;

	private bool ready;

	private float retryWait;

	public Ef_StepByToCamera()
	{
		distance = 1f;
		retryCount = 10;
		retryWait = 1f;
	}

	public void Start()
	{
		ready = false;
		Find();
	}

	public void Find()
	{
		if ((bool)cameraObj && (!cameraObj.camera.enabled || !cameraObj.gameObject.activeSelf))
		{
			cameraObj = null;
		}
		if (!cameraObj)
		{
			if (nearestCam)
			{
				Camera[] allCameras = Camera.allCameras;
				Vector3 position = transform.position;
				float num = 999f;
				int i = 0;
				Camera[] array = allCameras;
				for (int length = array.Length; i < length; i = checked(i + 1))
				{
					float magnitude = (array[i].transform.position - position).magnitude;
					if (!(magnitude >= num))
					{
						cameraObj = array[i].transform;
						num = magnitude;
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
			}
		}
		parent = transform.parent;
		fstPos = transform.localPosition;
		if ((bool)cameraObj && (bool)parent)
		{
			ready = true;
		}
	}

	public void LateUpdate()
	{
		checked
		{
			if (!ready)
			{
				if (retryCount <= 0)
				{
					return;
				}
				retryWait -= deltaTime;
				if (!(retryWait > 0f))
				{
					Find();
					retryWait = 1f;
					retryCount--;
					if (retryCount != 0)
					{
					}
				}
			}
			else if ((bool)cameraObj && (bool)parent)
			{
				Vector3 vector = fstPos;
				if (fstPosScale)
				{
					Vector3 localScale = parent.localScale;
					vector.x *= localScale.x;
					vector.y *= localScale.y;
					vector.z *= localScale.z;
				}
				Vector3 vector2 = parent.position + parent.rotation * vector;
				Vector3 vector3 = (cameraObj.position - vector2).normalized * distance;
				transform.position = vector2 + vector3;
			}
		}
	}
}
