using System;
using UnityEngine;

[Serializable]
public class EventCloseUpCamera : MonoBehaviour
{
	public Camera eventCamera;

	public GameObject char1;

	public GameObject char2;

	public void Start()
	{
		eventCamera = gameObject.GetComponent<Camera>();
		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("CameraMovePath"), "time", 3, "easetype", iTween.EaseType.easeOutSine));
	}

	public void Update()
	{
	}
}
