using UnityEngine;

public class DragGesture : ContinuousGesture
{
	private Vector2 deltaMove = Vector2.zero;

	internal Vector2 LastPos = Vector2.zero;

	internal Vector2 LastDelta = Vector2.zero;

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

	public Vector2 TotalMove => base.Position - base.StartPosition;
}
