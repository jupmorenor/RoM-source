using UnityEngine;

[AddComponentMenu("FingerGestures/Toolbox/Drag To Move")]
public class TBDragToMove : MonoBehaviour
{
	public enum DragPlaneType
	{
		Camera,
		UseCollider
	}

	public Collider DragPlaneCollider;

	public float DragPlaneOffset;

	public Camera RaycastCamera;

	private bool dragging;

	private FingerGestures.Finger draggingFinger;

	private GestureRecognizer gestureRecognizer;

	private bool oldUseGravity;

	private bool oldIsKinematic;

	private Vector3 physxDragMove = Vector3.zero;

	public bool Dragging
	{
		get
		{
			return dragging;
		}
		private set
		{
			if (dragging == value)
			{
				return;
			}
			dragging = value;
			if ((bool)base.rigidbody)
			{
				if (dragging)
				{
					oldUseGravity = base.rigidbody.useGravity;
					oldIsKinematic = base.rigidbody.isKinematic;
					base.rigidbody.useGravity = false;
					base.rigidbody.isKinematic = true;
				}
				else
				{
					base.rigidbody.isKinematic = oldIsKinematic;
					base.rigidbody.useGravity = oldUseGravity;
					base.rigidbody.velocity = Vector3.zero;
				}
			}
		}
	}

	private void Start()
	{
		if (!RaycastCamera)
		{
			RaycastCamera = Camera.main;
		}
	}

	public bool ProjectScreenPointOnDragPlane(Vector3 refPos, Vector2 screenPos, out Vector3 worldPos)
	{
		worldPos = refPos;
		if ((bool)DragPlaneCollider)
		{
			Ray ray = RaycastCamera.ScreenPointToRay(screenPos);
			if (!DragPlaneCollider.Raycast(ray, out var hitInfo, float.MaxValue))
			{
				return false;
			}
			worldPos = hitInfo.point + DragPlaneOffset * hitInfo.normal;
		}
		else
		{
			Transform transform = RaycastCamera.transform;
			Plane plane = new Plane(-transform.forward, refPos);
			Ray ray2 = RaycastCamera.ScreenPointToRay(screenPos);
			float enter = 0f;
			if (!plane.Raycast(ray2, out enter))
			{
				return false;
			}
			worldPos = ray2.GetPoint(enter);
		}
		return true;
	}

	private void HandleDrag(DragGesture gesture)
	{
		if (!base.enabled)
		{
			return;
		}
		if (gesture.Phase == ContinuousGesturePhase.Started)
		{
			Dragging = true;
			draggingFinger = gesture.Fingers[0];
		}
		else
		{
			if (!Dragging || gesture.Fingers[0] != draggingFinger)
			{
				return;
			}
			if (gesture.Phase == ContinuousGesturePhase.Updated)
			{
				Transform transform = base.transform;
				if (ProjectScreenPointOnDragPlane(transform.position, draggingFinger.PreviousPosition, out var worldPos) && ProjectScreenPointOnDragPlane(transform.position, draggingFinger.Position, out var worldPos2))
				{
					Vector3 vector = worldPos2 - worldPos;
					if ((bool)base.rigidbody)
					{
						physxDragMove += vector;
					}
					else
					{
						transform.position += vector;
					}
				}
			}
			else
			{
				Dragging = false;
			}
		}
	}

	private void FixedUpdate()
	{
		if (Dragging && (bool)base.rigidbody)
		{
			base.rigidbody.MovePosition(base.rigidbody.position + physxDragMove);
			physxDragMove = Vector3.zero;
		}
	}

	private void OnDrag(DragGesture gesture)
	{
		HandleDrag(gesture);
	}

	private void OnDisable()
	{
		if (Dragging)
		{
			Dragging = false;
		}
	}
}
