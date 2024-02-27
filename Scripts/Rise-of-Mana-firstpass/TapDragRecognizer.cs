using UnityEngine;

[AddComponentMenu("FingerGestures/Gestures/Tap Drag Recognizer")]
public class TapDragRecognizer : ContinuousGestureRecognizer<TapDragGesture>
{
	public int RequiredTaps = 1;

	public float MoveTolerance = 20f;

	public float MaxDuration;

	public float MaxDelayBetweenTaps = 0.5f;

	public bool ApplySameDirectionConstraint;

	private bool IsMultiTap => RequiredTaps > 1;

	private bool HasTimedOut(TapDragGesture gesture)
	{
		if (MaxDuration > 0f && gesture.ElapsedTime > MaxDuration)
		{
			return true;
		}
		if (IsMultiTap && MaxDelayBetweenTaps > 0f && Time.time - gesture.LastTapTime > MaxDelayBetweenTaps)
		{
			return true;
		}
		return false;
	}

	private bool HasTapTimedOut(TapDragGesture gesture)
	{
		if (MaxDuration > 0f && gesture.ElapsedTime > MaxDuration)
		{
			return true;
		}
		if (MaxDelayBetweenTaps > 0f && Time.time - gesture.LastTapTime > MaxDelayBetweenTaps)
		{
			return true;
		}
		return false;
	}

	private bool HasDragTimedOut(TapDragGesture gesture)
	{
		if (MaxDuration > 0f && gesture.ElapsedTime > MaxDuration)
		{
			return true;
		}
		return false;
	}

	protected override void Reset(TapDragGesture gesture)
	{
		gesture.Taps = 0;
		gesture.Down = false;
		gesture.WasDown = false;
		gesture.IsDragged = false;
		base.Reset(gesture);
	}

	protected override TapDragGesture MatchActiveGestureToCluster(FingerClusterManager.Cluster cluster)
	{
		if (IsMultiTap)
		{
			TapDragGesture tapDragGesture = FindClosestPendingGesture(cluster.Fingers.GetAveragePosition());
			if (tapDragGesture != null)
			{
				return tapDragGesture;
			}
		}
		return base.MatchActiveGestureToCluster(cluster);
	}

	private TapDragGesture FindClosestPendingGesture(Vector2 center)
	{
		TapDragGesture result = null;
		float num = float.PositiveInfinity;
		foreach (TapDragGesture gesture in base.Gestures)
		{
			if (gesture.State == GestureRecognitionState.InProgress && !gesture.Down)
			{
				float num2 = Vector2.SqrMagnitude(center - gesture.Position);
				if (num2 < MoveTolerance * MoveTolerance && num2 < num)
				{
					result = gesture;
					num = num2;
				}
			}
		}
		return result;
	}

	private GestureRecognitionState OnActiveTap(TapDragGesture gesture, FingerGestures.IFingerList touches)
	{
		gesture.WasDown = gesture.Down;
		gesture.Down = false;
		if (touches.Count == RequiredFingerCount)
		{
			gesture.Down = true;
			gesture.LastDownTime = Time.time;
		}
		else if (touches.Count == 0)
		{
			gesture.Down = false;
		}
		else if (touches.Count < RequiredFingerCount)
		{
			if (Time.time - gesture.LastDownTime > 0.25f)
			{
				Reset(gesture);
				return GestureRecognitionState.Failed;
			}
		}
		else if (!Young(touches))
		{
			Reset(gesture);
			return GestureRecognitionState.Failed;
		}
		if (HasTapTimedOut(gesture))
		{
			Reset(gesture);
			return GestureRecognitionState.Failed;
		}
		if (gesture.Down)
		{
			float num = Vector3.SqrMagnitude(touches.GetAveragePosition() - gesture.StartPosition);
			if (num >= MoveTolerance * MoveTolerance)
			{
				return GestureRecognitionState.Failed;
			}
		}
		if (!gesture.Down && gesture.WasDown)
		{
			gesture.Taps++;
			gesture.LastTapTime = Time.time;
		}
		if (gesture.Down && gesture.WasDown && RequiredTaps > 0 && gesture.Taps >= RequiredTaps - 1)
		{
			return OnActiveDrag(gesture, touches);
		}
		return GestureRecognitionState.InProgress;
	}

	protected GestureRecognitionState OnActiveDrag(TapDragGesture gesture, FingerGestures.IFingerList touches)
	{
		gesture.IsDragged = true;
		if (HasDragTimedOut(gesture))
		{
			Reset(gesture);
			return GestureRecognitionState.Ended;
		}
		if (touches.Count == 0)
		{
			Reset(gesture);
			return GestureRecognitionState.Ended;
		}
		if (RequiredFingerCount > 0 && touches.Count != RequiredFingerCount)
		{
			if (touches.Count < RequiredFingerCount)
			{
				return GestureRecognitionState.Ended;
			}
			return GestureRecognitionState.Failed;
		}
		if (RequiredFingerCount >= 2 && ApplySameDirectionConstraint && touches.AllMoving() && !touches.MovingInSameDirection(0.35f))
		{
			return GestureRecognitionState.Failed;
		}
		gesture.Position = touches.GetAveragePosition();
		gesture.LastDelta = gesture.DeltaMove;
		gesture.DeltaMove = gesture.Position - gesture.LastPos;
		if (gesture.DeltaMove.sqrMagnitude > 0f || gesture.LastDelta.sqrMagnitude > 0f)
		{
			gesture.LastPos = gesture.Position;
		}
		RaiseEvent(gesture);
		return GestureRecognitionState.InProgress;
	}

	public override string GetDefaultEventMessageName()
	{
		return "OnTap";
	}

	protected override void OnBegin(TapDragGesture gesture, FingerGestures.IFingerList touches)
	{
		gesture.Position = touches.GetAveragePosition();
		gesture.StartPosition = gesture.Position;
		gesture.LastTapTime = Time.time;
	}

	protected override GestureRecognitionState OnRecognize(TapDragGesture gesture, FingerGestures.IFingerList touches)
	{
		if (gesture.IsDragged)
		{
			return OnActiveDrag(gesture, touches);
		}
		return OnActiveTap(gesture, touches);
	}
}
