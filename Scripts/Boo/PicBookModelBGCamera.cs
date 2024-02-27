using System;
using UnityEngine;

[Serializable]
public class PicBookModelBGCamera : MonoBehaviour
{
	public UltimateOrbitCamera orbitCamera;

	public Transform cameraTarget;

	private Transform mTrans;

	private Vector3 oneRange;

	public void Awake()
	{
		mTrans = transform;
	}

	public void Start()
	{
		oneRange = (cameraTarget.position - mTrans.position) / orbitCamera.distance;
	}

	public void Update()
	{
		mTrans.position = cameraTarget.position - oneRange * orbitCamera.distance;
	}
}
