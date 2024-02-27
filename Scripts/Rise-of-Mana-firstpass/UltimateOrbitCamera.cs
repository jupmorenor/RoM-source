using UnityEngine;

public class UltimateOrbitCamera : MonoBehaviour
{
	public Transform target;

	public bool onEnableInit = true;

	public float distance = 10f;

	public float maxDistance = 25f;

	public float minDistance = 5f;

	public bool mouseControl = true;

	public string mouseAxisX = "Mouse X";

	public string mouseAxisY = "Mouse Y";

	public string mouseAxisZoom = "Mouse ScrollWheel";

	public bool keyboardControl;

	public string kbPanAxisX = "Horizontal";

	public string kbPanAxisY = "Vertical";

	public bool kbUseZoomAxis;

	public KeyCode zoomInKey = KeyCode.R;

	public KeyCode zoomOutKey = KeyCode.F;

	public string kbZoomAxisName = string.Empty;

	public float initialAngleX;

	public float initialAngleY;

	public bool invertAxisX;

	public bool invertAxisY;

	public bool invertAxisZoom;

	public float xSpeed = 1f;

	public float ySpeed = 1f;

	public float zoomSpeed = 5f;

	public float dampeningX = 0.9f;

	public float dampeningY = 0.9f;

	public float smoothingZoom = 0.1f;

	public bool limitY = true;

	public float yMinLimit = -60f;

	public float yMaxLimit = 60f;

	public float yLimitOffset;

	public bool limitX;

	public float xMinLimit = -60f;

	public float xMaxLimit = 60f;

	public float xLimitOffset;

	public bool clickToRotate = true;

	public bool leftClickToRotate = true;

	public bool rightClickToRotate;

	public bool autoRotateOn;

	public bool autoRotateReverse;

	public float autoRotateSpeed = 0.1f;

	public bool SpinEnabled;

	public bool spinUseAxis;

	public KeyCode spinKey = KeyCode.LeftControl;

	public string spinAxis = string.Empty;

	public float maxSpinSpeed = 3f;

	private bool spinning;

	private float spinSpeed;

	public bool cameraCollision;

	public float collisionRadius = 0.25f;

	private float xVelocity;

	private float yVelocity;

	private float zoomVelocity;

	public float targetDistance = 10f;

	private float x;

	private float y;

	private Vector3 position;

	[HideInInspector]
	public int invertXValue = 1;

	[HideInInspector]
	public int invertYValue = 1;

	[HideInInspector]
	public int invertZoomValue = 1;

	[HideInInspector]
	public int autoRotateReverseValue = 1;

	private Ray ray;

	private RaycastHit hit;

	private Transform _transform;

	private Vector3 startPosition;

	private Quaternion startRotation;

	private float startDistance;

	private float pinchDist;

	private void Awake()
	{
		startDistance = (targetDistance = distance);
		if (invertAxisX)
		{
			invertXValue = -1;
		}
		else
		{
			invertXValue = 1;
		}
		if (invertAxisY)
		{
			invertYValue = -1;
		}
		else
		{
			invertYValue = 1;
		}
		if (invertAxisZoom)
		{
			invertZoomValue = -1;
		}
		else
		{
			invertZoomValue = 1;
		}
		if (autoRotateOn)
		{
			autoRotateReverseValue = -1;
		}
		else
		{
			autoRotateReverseValue = 1;
		}
		_transform = base.transform;
		if (base.rigidbody != null)
		{
			base.rigidbody.freezeRotation = true;
		}
		startPosition = _transform.position;
		startRotation = _transform.localRotation;
	}

	private void OnEnable()
	{
		if (onEnableInit)
		{
			Init();
		}
	}

	public void Init()
	{
		x = initialAngleX;
		y = initialAngleY;
		targetDistance = (distance = startDistance);
		_transform.position = startPosition;
		_transform.localRotation = startRotation;
		_transform.Rotate(new Vector3(0f, initialAngleX, 0f), Space.World);
		_transform.Rotate(new Vector3(initialAngleY, 0f, 0f), Space.Self);
		position = _transform.localRotation * new Vector3(0f, 0f, 0f - distance) + target.position;
	}

	private void Update()
	{
		if (target != null)
		{
			if (autoRotateOn && !Input.GetMouseButton(0))
			{
				xVelocity += autoRotateSpeed * (float)autoRotateReverseValue * Time.deltaTime;
			}
			if (Input.touches.Length == 1)
			{
				xVelocity += Input.GetTouch(0).deltaPosition.x * xSpeed * (float)invertXValue * 0.2f;
				yVelocity -= Input.GetTouch(0).deltaPosition.y * ySpeed * (float)invertYValue * 0.2f;
			}
			if (SpinEnabled && ((mouseControl && clickToRotate) || keyboardControl))
			{
				if ((spinUseAxis && Input.GetAxis(spinAxis) != 0f) || (!spinUseAxis && Input.GetKey(spinKey)))
				{
					spinning = true;
					spinSpeed = Mathf.Min(xVelocity, maxSpinSpeed);
				}
				if (spinning)
				{
					xVelocity = spinSpeed;
				}
			}
			if (limitX)
			{
				if (x + xVelocity < xMinLimit + xLimitOffset)
				{
					xVelocity = xMinLimit + xLimitOffset - x;
				}
				else if (x + xVelocity > xMaxLimit + xLimitOffset)
				{
					xVelocity = xMaxLimit + xLimitOffset - x;
				}
				x += xVelocity;
				_transform.Rotate(new Vector3(0f, xVelocity, 0f), Space.World);
			}
			else
			{
				_transform.Rotate(new Vector3(0f, xVelocity, 0f), Space.World);
			}
			if (limitY)
			{
				if (y + yVelocity < yMinLimit + yLimitOffset)
				{
					yVelocity = yMinLimit + yLimitOffset - y;
				}
				else if (y + yVelocity > yMaxLimit + yLimitOffset)
				{
					yVelocity = yMaxLimit + yLimitOffset - y;
				}
				y += yVelocity;
				_transform.Rotate(new Vector3(yVelocity, 0f, 0f), Space.Self);
			}
			else
			{
				_transform.Rotate(new Vector3(yVelocity, 0f, 0f), Space.Self);
			}
			if (Input.touchCount == 2)
			{
				if (pinchDist == 0f)
				{
					pinchDist = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
				}
				else
				{
					targetDistance += (pinchDist - Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position)) * 0.01f * zoomSpeed * (float)invertZoomValue;
					pinchDist = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
				}
				if (targetDistance < minDistance)
				{
					targetDistance = minDistance;
				}
				else if (targetDistance > maxDistance)
				{
					targetDistance = maxDistance;
				}
			}
			else
			{
				pinchDist = 0f;
			}
			if (targetDistance + zoomVelocity < minDistance)
			{
				zoomVelocity = minDistance - targetDistance;
			}
			else if (targetDistance + zoomVelocity > maxDistance)
			{
				zoomVelocity = maxDistance - targetDistance;
			}
			targetDistance += zoomVelocity;
			distance = Mathf.Lerp(distance, targetDistance, smoothingZoom);
			if (cameraCollision)
			{
				ray = new Ray(_transform.position, (_transform.position - target.position).normalized);
				if (Physics.SphereCast(ray.origin, collisionRadius, ray.direction, out hit, distance))
				{
					distance = hit.distance;
				}
			}
			position = _transform.localRotation * new Vector3(0f, 0f, 0f - distance) + target.position;
			_transform.position = position;
			if (!SpinEnabled || !spinning)
			{
				xVelocity *= dampeningX;
			}
			yVelocity *= dampeningY;
			zoomVelocity = 0f;
		}
		else
		{
			Debug.LogWarning("Orbit Cam - No Target Given");
		}
	}
}
