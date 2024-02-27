using System;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class TargetCam : MonoBehaviour
{
	public Transform camObj;

	public Transform posObj;

	public Transform tgtObj;

	public void LateUpdate()
	{
		if (posObj == null)
		{
			if (posObj == null)
			{
				posObj = transform.Find("Camera Transform");
			}
			if (posObj == null)
			{
				posObj = transform.Find("CameraTransform");
			}
			if (posObj == null)
			{
				posObj = transform.Find("Camera Position");
			}
			if (posObj == null)
			{
				posObj = transform.Find("CameraPosition");
			}
			if (posObj == null)
			{
				posObj = transform.Find("Main Camera");
			}
			if (posObj == null)
			{
				posObj = transform.Find("Position");
			}
			if (posObj == null)
			{
				posObj = transform.Find("CamPos");
			}
			if (posObj == null)
			{
				return;
			}
		}
		if (tgtObj == null)
		{
			if (tgtObj == null)
			{
				tgtObj = transform.Find("Camera Target");
			}
			if (tgtObj == null)
			{
				tgtObj = transform.Find("CameraTarget");
			}
			if (tgtObj == null)
			{
				tgtObj = transform.Find("Target");
			}
			if (tgtObj == null)
			{
				tgtObj = transform.Find("CamTgt");
			}
			if (tgtObj == null)
			{
				return;
			}
		}
		if (camObj == null)
		{
			camObj = Camera.main.transform;
			if (camObj == null)
			{
				return;
			}
		}
		camObj.position = posObj.position;
		camObj.LookAt(tgtObj.position, posObj.up);
	}
}
