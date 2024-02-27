using System;
using UnityEngine;

[Serializable]
public class TapDragGesture : ContinuousGesture
{
	private int taps;

	internal bool Down;

	internal bool WasDown;

	internal float LastDownTime;

	internal float LastTapTime;

	private Vector2 deltaMove = Vector2.zero;

	private bool dragged;

	internal Vector2 LastPos = Vector2.zero;

	internal Vector2 LastDelta = Vector2.zero;

	public new ContinuousGesturePhase Phase
	{
		get
		{
			switch (base.State)
			{
			case GestureRecognitionState.Started:
				return ContinuousGesturePhase.None;
			case GestureRecognitionState.InProgress:
				if (IsDragged)
				{
					return ContinuousGesturePhase.Updated;
				}
				return ContinuousGesturePhase.None;
			case GestureRecognitionState.Failed:
			case GestureRecognitionState.Ended:
				return ContinuousGesturePhase.Ended;
			default:
				return ContinuousGesturePhase.None;
			}
		}
	}

	public int Taps
	{
		get
		{
			return taps;
		}
		internal set
		{
			taps = value;
		}
	}

	public Vector2 DeltaMove
	{
		get
		{
			return deltaMove;
		}
		internal set
		{
			deltaMove = value;
		}
	}

	public bool IsDragged
	{
		get
		{
			return dragged;
		}
		internal set
		{
			dragged = value;
		}
	}

	public Vector2 TotalMove => base.Position - base.StartPosition;
}
