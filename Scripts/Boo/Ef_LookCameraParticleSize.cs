using System;
using UnityEngine;

[Serializable]
public class Ef_LookCameraParticleSize : MonoBehaviour
{
	public Transform cameraObj;

	public Camera cameraCom;

	public Ef_LookCameraParticleSizeObj[] particleObjs;

	public bool nearestCam;

	public bool evelyFlameLookAt;

	public bool evelyFlameSetSize;

	public float minDistance;

	public float maxDistance;

	public bool onStart;

	public Vector3 rotOffset;

	private bool oneShotLookAt;

	private bool oneShotSetSize;

	public Ef_LookCameraParticleSize()
	{
		evelyFlameLookAt = true;
		minDistance = 1f;
		maxDistance = 20f;
		onStart = true;
		rotOffset = Vector3.zero;
		oneShotLookAt = true;
		oneShotSetSize = true;
	}

	public void Start()
	{
		if (onStart)
		{
			LookAt();
			oneShotLookAt = false;
		}
	}

	public void Update()
	{
		if (evelyFlameLookAt || oneShotLookAt)
		{
			LookAt();
			oneShotLookAt = false;
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
		checked
		{
			if (!cameraObj)
			{
				if (nearestCam)
				{
					Camera[] allCameras = Camera.allCameras;
					Vector3 position = transform.position;
					float num = 999999f;
					int i = 0;
					Camera[] array = allCameras;
					for (int length = array.Length; i < length; i++)
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
			Vector3 vector = cameraObj.position - transform.position;
			if (vector == Vector3.zero)
			{
				vector = new Vector3(0f, 0f, 0.001f);
			}
			quaternion2 = Quaternion.LookRotation(vector, Vector3.up);
			if (rotOffset != Vector3.zero)
			{
				quaternion2 *= Quaternion.Euler(rotOffset);
			}
			transform.rotation = quaternion2;
			if (evelyFlameSetSize || oneShotSetSize)
			{
				float magnitude = vector.magnitude;
				if (!(magnitude >= minDistance))
				{
					magnitude = minDistance;
				}
				else if (!(magnitude <= maxDistance))
				{
					magnitude = maxDistance;
				}
				int j = 0;
				Ef_LookCameraParticleSizeObj[] array2 = particleObjs;
				for (int length2 = array2.Length; j < length2; j++)
				{
					array2[j].Setsize(magnitude);
				}
				oneShotSetSize = false;
			}
		}
	}
}
