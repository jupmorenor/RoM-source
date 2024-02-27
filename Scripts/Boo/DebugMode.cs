using System;
using UnityEngine;

[Serializable]
public class DebugMode : MonoBehaviour
{
	public Transform target;

	public float distance;

	public float xSpeed;

	public float ySpeed;

	public int yMinLimit;

	public int yMaxLimit;

	public float yPosition;

	public float yPositionTouch;

	public int FOV;

	public float posY;

	public GUISkin customSkin;

	public bool debugMode;

	private float x;

	private float y;

	private Vector3 preCameraPos;

	private Quaternion preCameraRot;

	public DebugMode()
	{
		distance = 10f;
		xSpeed = 250f;
		ySpeed = 120f;
		yMinLimit = -20;
		yMaxLimit = 80;
		FOV = 45;
		posY = 1.5f;
	}
}
