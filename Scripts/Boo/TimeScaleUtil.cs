using System;
using UnityEngine;

[Serializable]
public class TimeScaleUtil
{
	public static void Zero()
	{
		Time.timeScale = 0f;
	}

	public static void One()
	{
		Time.timeScale = 1f;
	}

	public static void Set(float val)
	{
		Time.timeScale = val;
	}
}
