using UnityEngine;

[AddComponentMenu("FingerGestures/Gestures/Drag Recognizer")]
public class DragRecognizer : ContinuousGestureRecognizer<DragGesture>
{
	public float MoveTolerance = 5f;

	public bool ApplySameDirectionConstraint;

	public override string GetDefaultEventMessageName()
	{
		return "OnDrag";
	}

	protected override GameObject GetDefaultSelectionForSendMessage(DragGesture gesture)
	{
		return gesture.StartSelection;
	}

	protected override bool CanBegin(DragGesture gesture, FingerGestures.IFingerList touches)
	{
		if (!base.CanBegin(gesture, touches))
		{
			return false;
		}
		if (touches.GetAverageDistanceFromStart() < MoveTolerance)
		{
			return false;
		}
		if (!touches.AllMoving())
		{
			return false;
		}
		if (RequiredFingerCount >= 2 && ApplySameDirectionConstraint && !touches.MovingInSameDirection(0.35f))
		{
			return false;
		}
		return true;
	}

	protected override void OnBegin(DragGesture gesture, FingerGestures.IFingerList touches)
	{
		gesture.Position = touches.GetAveragePosition();
		gesture.StartPosition = touches.GetAverageStartPosition();
		gesture.DeltaMove = gesture.Position - gesture.StartPosition;
		gesture.LastDelta = Vector2.zero;
		gesture.LastPos = gesture.Position;
	}

	protected override GestureRecognitionState OnRecognize(DragGesture gesture, FingerGestures.IFingerList touches)
	{
		if (touches.Count != RequiredFingerCount)
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
}
