using System;
using UnityEngine;

[Serializable]
public class Fader : MonoBehaviour
{
	public FaderCore faderCore;

	public FaderCore.Mode 現在のモード => FaderCore.Instance.curMode;

	public float 現在のアルファ => FaderCore.Instance.curAlpha;

	public bool Pause
	{
		get
		{
			return FaderCore.Instance.Pause;
		}
		set
		{
			FaderCore.Instance.Pause = value;
		}
	}

	public float red
	{
		get
		{
			return FaderCore.Instance.red;
		}
		set
		{
			FaderCore.Instance.red = value;
		}
	}

	public float green
	{
		get
		{
			return FaderCore.Instance.green;
		}
		set
		{
			FaderCore.Instance.green = value;
		}
	}

	public float blue
	{
		get
		{
			return FaderCore.Instance.blue;
		}
		set
		{
			FaderCore.Instance.blue = value;
		}
	}

	public bool isCompleted => FaderCore.Instance.isCompleted;

	public bool isInCompleted => FaderCore.Instance.isInCompleted;

	public bool isOutCompleted => FaderCore.Instance.isOutCompleted;

	public bool isIn => FaderCore.Instance.isIn;

	public bool isOut => FaderCore.Instance.isOut;

	public void fadeIn()
	{
		FaderCore.Instance.fadeIn(ignoreTScale: false);
	}

	public void fadeIn(bool ignoreTScale)
	{
		FaderCore.Instance.fadeIn(ignoreTScale);
	}

	public void fadeOut()
	{
		FaderCore.Instance.fadeOut(ignoreTScale: false);
	}

	public void fadeOut(bool ignoreTScale)
	{
		FaderCore.Instance.fadeOut(ignoreTScale);
	}

	public void fadeInEx(float r, float g, float b, float speed)
	{
		FaderCore.Instance.fadeInEx(r, g, b, speed);
	}

	public void fadeOutEx(float r, float g, float b, float speed)
	{
		FaderCore.Instance.fadeOutEx(r, g, b, speed);
	}

	public void fadeInEx(float r, float g, float b, float speed, bool ignoreTScale)
	{
		FaderCore.Instance.fadeInEx(r, g, b, speed, ignoreTScale);
	}

	public void fadeOutEx(float r, float g, float b, float speed, bool ignoreTScale)
	{
		FaderCore.Instance.fadeOutEx(r, g, b, speed, ignoreTScale);
	}

	public void Out()
	{
		FaderCore.Instance.Out();
	}

	public void In()
	{
		FaderCore.Instance.In();
	}

	public void fadeInFromOut()
	{
		FaderCore.Instance.fadeInFromOut();
	}

	public void fadeOutFromIn()
	{
		FaderCore.Instance.fadeOutFromIn();
	}

	public void fadeInFromOut(bool ignoreTScale)
	{
		FaderCore.Instance.fadeInFromOut(ignoreTScale);
	}

	public void fadeOutFromIn(bool ignoreTScale)
	{
		FaderCore.Instance.fadeOutFromIn(ignoreTScale);
	}

	public void Start()
	{
		faderCore = FaderCore.Instance;
	}
}
