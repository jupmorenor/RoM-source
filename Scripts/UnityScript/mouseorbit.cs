using System;
using UnityEngine;

[Serializable]
[AddComponentMenu("Camera-Control/Mouse Orbit")]
public class mouseorbit : MonoBehaviour
{
	public Transform target;

	public int distance;

	public float xSpeed;

	public float ySpeed;

	public int yMinLimit;

	public int yMaxLimit;

	public float yPosition;

	public float yPositionTouch;

	private float x;

	private float y;

	public int FOV;

	public float posY;

	public GUISkin customSkin;

	public bool debugMode;

	public mouseorbit()
	{
		distance = 10;
		xSpeed = 250f;
		ySpeed = 120f;
		yMinLimit = -20;
		yMaxLimit = 80;
		FOV = 60;
		posY = 1.5f;
	}

	public virtual void Start()
	{
		if (target == null)
		{
			target = transform;
		}
		Vector3 eulerAngles = Camera.main.transform.eulerAngles;
		x = eulerAngles.y;
		y = eulerAngles.x;
		FOV = (int)Camera.main.fieldOfView;
		if ((bool)rigidbody)
		{
			rigidbody.freezeRotation = true;
		}
	}

	public virtual void DebugMode(bool flag)
	{
		if (flag)
		{
			Time.timeScale = 0f;
		}
		else
		{
			Time.timeScale = 1f;
		}
		debugMode = flag;
	}

	public virtual void OnGUI()
	{
		if (debugMode)
		{
			if (GUI.Button(new Rect(10f, 10f, 100f, 50f), "Debug Off"))
			{
				DebugMode(flag: false);
			}
			if (GUI.Button(new Rect(10f, 70f, 100f, 50f), "Battle"))
			{
				DebugMode(flag: false);
				Application.LoadLevel("Merlin");
			}
			else if (GUI.Button(new Rect(10f, 130f, 100f, 50f), "Camera"))
			{
				DebugMode(flag: false);
				Application.LoadLevel("BGViewer");
			}
			else if (GUI.Button(new Rect(10f, 190f, 100f, 50f), "Raid"))
			{
				DebugMode(flag: false);
				Application.LoadLevel("Raid");
			}
			GUI.skin = customSkin;
			distance = (int)GUI.HorizontalSlider(new Rect(130f, 30f, 220f, 50f), distance, 5f, 40f);
			GUI.Label(new Rect(130f, 50f, 200f, 50f), "Camera_Distance" + distance);
			FOV = (int)GUI.HorizontalSlider(new Rect(370f, 30f, 220f, 50f), FOV, 20f, 100f);
			GUI.Label(new Rect(370f, 50f, 200f, 60f), "FOV" + FOV);
			posY = GUI.HorizontalSlider(new Rect(610f, 30f, 220f, 50f), posY, 0.5f, 5f);
			GUI.Label(new Rect(610f, 50f, 200f, 50f), "posY " + posY);
		}
		else if (GUI.Button(new Rect(10f, 10f, 100f, 50f), "Debug On"))
		{
			DebugMode(flag: true);
		}
	}

	public virtual void Update()
	{
		if (debugMode)
		{
			if (0 < Input.touchCount)
			{
				yPositionTouch = Input.GetTouch(0).position.y;
			}
			else
			{
				yPosition = Input.mousePosition.y;
			}
			Quaternion quaternion = Quaternion.Euler(y, x, 0f);
			Vector3 position = quaternion * new Vector3(0f, 0f, -distance) + target.position;
			Camera.main.transform.rotation = quaternion;
			Camera.main.transform.position = position;
			Camera.main.fieldOfView = FOV;
			transform.position = new Vector3(0f, posY, 2.83f);
		}
	}

	public virtual void LateUpdate()
	{
		if (!debugMode)
		{
			return;
		}
		if (0 < Input.touchCount)
		{
			if ((bool)target && Input.GetTouch(0).phase == TouchPhase.Moved && !(yPositionTouch >= 550f))
			{
				yPositionTouch = Input.GetTouch(0).position.y;
				x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
				y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
				y = ClampAngle(y, yMinLimit, yMaxLimit);
			}
		}
		else if ((bool)target && Input.GetMouseButton(0) && !(yPosition >= 550f))
		{
			yPosition = Input.mousePosition.y;
			x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
			y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
			y = ClampAngle(y, yMinLimit, yMaxLimit);
		}
	}

	public static float ClampAngle(float angle, float min, float max)
	{
		if (!(angle >= -360f))
		{
			angle += 360f;
		}
		if (!(angle <= 360f))
		{
			angle -= 360f;
		}
		return Mathf.Clamp(angle, min, max);
	}

	public virtual void Main()
	{
	}
}
