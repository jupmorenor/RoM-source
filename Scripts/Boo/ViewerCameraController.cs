using System;
using UnityEngine;

[Serializable]
[AddComponentMenu("Camera-Control/Viewer Camera Control")]
public class ViewerCameraController : MonoBehaviour
{
	[Serializable]
	private enum CAM_MODE
	{
		none,
		orbit,
		zoom,
		pan
	}

	public float currentSpeed;

	private float x;

	private float y;

	public CAM_MODE カメラモード;

	public float 回転速度;

	public float 移動速度;

	public float ズーム速度;

	private GameObject orbitVector;

	private float distToOrbit;

	private int dragFingerIndex;

	private int panFingerIndex;

	public Component viewer;

	public CAM_MODE cam_mode
	{
		get
		{
			return カメラモード;
		}
		set
		{
			カメラモード = value;
		}
	}

	public float orbitSpeed
	{
		get
		{
			return 回転速度;
		}
		set
		{
			回転速度 = value;
		}
	}

	public float panSpeed
	{
		get
		{
			return 移動速度;
		}
		set
		{
			移動速度 = value;
		}
	}

	public float zoomSpeed
	{
		get
		{
			return ズーム速度;
		}
		set
		{
			ズーム速度 = value;
		}
	}

	public ViewerCameraController()
	{
		カメラモード = CAM_MODE.orbit;
		回転速度 = 20f;
		移動速度 = 10f;
		ズーム速度 = 50f;
		dragFingerIndex = -1;
		panFingerIndex = -1;
	}

	public void OnEnable()
	{
		viewer = (MerlinViewer)UnityEngine.Object.FindObjectOfType(typeof(MerlinViewer));
		RuntimeFingerGestures instance = RuntimeFingerGestures.Instance;
		FingerGestures.OnGestureEvent += FingerGestures_OnGestureEvent;
	}

	public void FingerGestures_OnGestureEvent(Gesture gesture)
	{
		if (gesture is DragGesture)
		{
			OnDrag((DragGesture)gesture);
			OnDragTwoFingers((DragGesture)gesture);
		}
		else if (gesture is PinchGesture)
		{
			OnPinch((PinchGesture)gesture);
		}
	}

	public void OnDragTwoFingers(DragGesture gesture)
	{
		if (cam_mode == CAM_MODE.zoom)
		{
			return;
		}
		FingerGestures.Finger finger = gesture.Fingers[0];
		if (gesture.Phase == ContinuousGesturePhase.Started)
		{
			panFingerIndex = finger.Index;
			setCamMode(CAM_MODE.pan);
		}
		else if (gesture.Phase == ContinuousGesturePhase.Updated)
		{
			if (panFingerIndex == finger.Index)
			{
				pan(gesture.DeltaMove);
			}
		}
		else if (panFingerIndex == finger.Index)
		{
			panFingerIndex = -1;
			setCamMode(CAM_MODE.none);
		}
	}

	public void OnDrag(DragGesture gesture)
	{
		if (cam_mode == CAM_MODE.zoom)
		{
			return;
		}
		FingerGestures.Finger finger = gesture.Fingers[0];
		if (gesture.Phase == ContinuousGesturePhase.Started)
		{
			dragFingerIndex = finger.Index;
			setCamMode(CAM_MODE.orbit);
		}
		else if (gesture.Phase == ContinuousGesturePhase.Updated)
		{
			if (dragFingerIndex == finger.Index)
			{
				orbit(gesture.DeltaMove);
			}
		}
		else if (dragFingerIndex == finger.Index)
		{
			dragFingerIndex = -1;
			setCamMode(CAM_MODE.none);
		}
	}

	public void OnPinch(PinchGesture gesture)
	{
		FingerGestures.Finger finger = gesture.Fingers[0];
		int index = default(int);
		if (gesture.Phase == ContinuousGesturePhase.Started)
		{
			index = finger.Index;
			setCamMode(CAM_MODE.zoom);
		}
		else if (gesture.Phase == ContinuousGesturePhase.Updated)
		{
			if (index == finger.Index)
			{
				zoom((float)((double)gesture.Delta * 0.1));
			}
		}
		else if (index == finger.Index)
		{
			index = -1;
			setCamMode(CAM_MODE.none);
		}
	}

	public void OnTapDrag(TapDragGesture gesture)
	{
		if (gesture.Phase != ContinuousGesturePhase.Started)
		{
			if (gesture.Phase == ContinuousGesturePhase.Updated)
			{
				setCamMode(CAM_MODE.zoom);
				zoom(gesture.DeltaMove);
			}
			else
			{
				setCamMode(CAM_MODE.none);
			}
		}
	}

	public void Start()
	{
		if ((bool)Camera.main)
		{
			orbitVector = GameObject.CreatePrimitive(PrimitiveType.Capsule);
			orbitVector.renderer.enabled = false;
			orbitVector.name = "Camera LookAt (Dummy)";
			orbitVector.transform.parent = Camera.main.transform.parent;
			Vector3 eulerAngles = Camera.main.transform.eulerAngles;
			x = eulerAngles.y;
			y = eulerAngles.x;
		}
	}

	public void LateUpdate()
	{
		distToOrbit = Vector3.Distance(Camera.main.transform.position, orbitVector.transform.position);
		x = Input.GetAxis("Mouse X");
		y = Input.GetAxis("Mouse Y");
		if (resetPressed())
		{
			reset(new Vector3(0f, 1f, 0f));
		}
	}

	public bool resetPressed()
	{
		return Input.GetKeyDown("r");
	}

	public void setCamMode(CAM_MODE m)
	{
		if (m == CAM_MODE.none)
		{
			cam_mode = CAM_MODE.none;
		}
		else if ((cam_mode != CAM_MODE.zoom && cam_mode != CAM_MODE.pan) || m != CAM_MODE.orbit)
		{
			cam_mode = m;
		}
	}

	public void reset()
	{
		reset(new Vector3(0f, 1f, 0f));
	}

	public void reset(Vector3 lookat)
	{
		orbitVector.transform.position = lookat;
		orbitVector.transform.rotation = Quaternion.identity;
		Camera.main.transform.position = lookat + Vector3.zero;
		Camera.main.transform.eulerAngles = new Vector3(0f, 180f, 0f);
		Camera.main.transform.Translate(new Vector3(0f, 0f, (float)((double)lookat.magnitude * -3.5)));
		Camera.main.transform.LookAt(orbitVector.transform.position, Vector3.up);
	}

	public void zoom(float delta)
	{
		if ((bool)Camera.main && (bool)orbitVector && cam_mode == CAM_MODE.zoom)
		{
			currentSpeed = Mathf.Clamp(zoomSpeed * (distToOrbit / 100f), 0.1f, 2f);
			Camera.main.transform.Translate(Vector3.forward * (delta * currentSpeed));
			if (!(Vector3.Distance(Camera.main.transform.position, orbitVector.transform.position) >= 3f))
			{
				orbitVector.transform.Translate(Vector3.forward, Camera.main.transform);
			}
		}
	}

	public void zoom(Vector2 delta)
	{
		if ((bool)Camera.main && (bool)orbitVector && cam_mode == CAM_MODE.zoom)
		{
			currentSpeed = Mathf.Clamp(zoomSpeed * (distToOrbit / 100f), 0.1f, 2f);
			Camera.main.transform.Translate(Vector3.forward * (y * currentSpeed));
			if (!(Vector3.Distance(Camera.main.transform.position, orbitVector.transform.position) >= 3f))
			{
				orbitVector.transform.Translate(Vector3.forward, Camera.main.transform);
			}
		}
	}

	public void orbit(Vector2 delta)
	{
		if ((bool)Camera.main && (bool)orbitVector && cam_mode == CAM_MODE.orbit)
		{
			currentSpeed = Mathf.Clamp(orbitSpeed * (Mathf.Log(distToOrbit + 15f, 3f) / 5f), 1f, orbitSpeed);
			Camera.main.transform.parent = orbitVector.transform;
			orbitVector.transform.Rotate(Vector3.right * (y * currentSpeed));
			orbitVector.transform.Rotate(Vector3.up * (x * currentSpeed), Space.World);
			Camera.main.transform.parent = null;
		}
	}

	public void pan(Vector2 delta)
	{
		if ((bool)Camera.main && (bool)orbitVector && cam_mode == CAM_MODE.pan)
		{
			currentSpeed = Mathf.Clamp(panSpeed * (distToOrbit / 100f), 0.1f, 2f);
			Vector3 translation = Vector3.right * (x * currentSpeed) * -1f;
			Vector3 translation2 = Vector3.up * (y * currentSpeed) * -1f;
			Camera.main.transform.Translate(translation);
			Camera.main.transform.Translate(translation2);
			orbitVector.transform.Translate(translation, Camera.main.transform);
			orbitVector.transform.Translate(translation2, Camera.main.transform);
		}
	}
}
