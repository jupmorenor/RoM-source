using System;
using UnityEngine;

[Serializable]
public class Ef_MoveByAnimCurveMinMaxAnim
{
	public float animLength;

	public float max;

	public AnimationCurve anim;

	public float min;

	public bool loop;

	private float max_min;

	private bool active;

	public bool Active
	{
		get
		{
			return active;
		}
		set
		{
			active = value;
		}
	}

	public Ef_MoveByAnimCurveMinMaxAnim()
	{
		animLength = 1f;
	}

	public void Initialize()
	{
		bool num = anim.length > 0;
		if (num)
		{
			num = min != max;
		}
		active = num;
		max_min = max - min;
	}

	public float GetValue(float animTime)
	{
		float result;
		if (active)
		{
			float num = default(float);
			num = ((!(animTime > animLength)) ? (animTime / animLength) : ((!loop) ? 1f : (animTime % animLength / animLength)));
			result = min + max_min * anim.Evaluate(num);
		}
		else
		{
			result = min;
		}
		return result;
	}
}
