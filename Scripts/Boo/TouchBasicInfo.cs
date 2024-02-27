using System;
using System.Text;
using UnityEngine;

[Serializable]
public class TouchBasicInfo
{
	private bool touch;

	private bool touchUp;

	private Vector3 scrnPos;

	private float touchTime;

	private int touchNum;

	public bool Touch => touch;

	public bool TouchUp => touchUp;

	public Vector3 ScrnPos => scrnPos;

	public float TouchTime => touchTime;

	public int TouchNum => touchNum;

	public void clear()
	{
		touch = false;
		touchUp = false;
		scrnPos = Vector3.zero;
		touchTime = 0f;
		touchNum = 0;
	}

	public void update(float dt)
	{
		touch = Input.GetMouseButton(0);
		touchUp = Input.GetMouseButtonUp(0);
		scrnPos = Input.mousePosition;
		touchNum = Input.touchCount;
		if (touch)
		{
			touchTime += dt;
		}
		else
		{
			touchTime = 0f;
		}
	}

	public override string ToString()
	{
		return new StringBuilder("touch:").Append(touch).Append(" up:").Append(touchUp)
			.Append(" time:")
			.Append(touchTime)
			.Append(" pos:")
			.Append(scrnPos)
			.ToString();
	}
}
