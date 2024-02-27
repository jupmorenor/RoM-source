using System;
using UnityEngine;

[Serializable]
public class MTouch
{
	public Vector2 deltaPosition;

	public float deltaTime;

	public int fingerId;

	public TouchPhase phase;

	public Vector2 position;

	public Vector2 rawPosition;

	public int tapCount;

	public bool IsTouched
	{
		get
		{
			bool num = phase == TouchPhase.Began;
			if (!num)
			{
				num = phase == TouchPhase.Moved;
			}
			if (!num)
			{
				num = phase == TouchPhase.Stationary;
			}
			return num;
		}
	}

	public MTouch(Touch t)
	{
		deltaPosition = t.deltaPosition;
		deltaTime = t.deltaTime;
		fingerId = t.fingerId;
		phase = t.phase;
		position = t.position;
		rawPosition = t.rawPosition;
		tapCount = t.tapCount;
	}

	public MTouch()
	{
	}
}
