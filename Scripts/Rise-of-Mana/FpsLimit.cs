using System.Diagnostics;
using UnityEngine;

public class FpsLimit : MonoBehaviour
{
	public int waitFps = 15;

	private Stopwatch sw = new Stopwatch();

	private long nextInt;

	private int oldFps;

	private int wait = 60;

	private void Start()
	{
		sw.Start();
	}

	private void Update()
	{
		if (waitFps != oldFps)
		{
			if (waitFps < 1)
			{
				waitFps = 1;
			}
			if (waitFps > 60)
			{
				waitFps = 60;
			}
			wait = 1000 / waitFps;
			nextInt = sw.ElapsedMilliseconds + wait;
			oldFps = waitFps;
		}
		if (waitFps != 60)
		{
			while (sw.ElapsedMilliseconds < nextInt)
			{
			}
			nextInt = sw.ElapsedMilliseconds + wait;
		}
	}

	private void OnGUI()
	{
		GUI.Label(new Rect(80f, 70f, 400f, 400f), "Fps Limit : " + waitFps);
	}
}
