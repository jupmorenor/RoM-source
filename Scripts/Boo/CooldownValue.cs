using System;
using System.Text;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class CooldownValue
{
	private float current;

	private float heatTime;

	private float decreaseScale;

	private __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ endHandler;

	private __CooldownValue_UpdateHandler_0024callable50_002433_30__ updateHandler;

	private bool initialized;

	public float Current
	{
		get
		{
			return current;
		}
		set
		{
			current = Mathf.Clamp(value, 0f, heatTime);
		}
	}

	public float HeatTime
	{
		get
		{
			return heatTime;
		}
		set
		{
			if (!(value > 0f))
			{
				throw new AssertionFailedException("value > 0.0F");
			}
			heatTime = value;
			current = Mathf.Min(heatTime, current);
		}
	}

	public bool IsReady => !(current > 0f);

	public int CurrentAsInt
	{
		get
		{
			Mathf.CeilToInt(current);
			return 0;
		}
	}

	public float DecreaseScale
	{
		get
		{
			return decreaseScale;
		}
		set
		{
			if (!(value > 0f))
			{
				throw new ArgumentException("precondition '(value > 0.0F)' failed:");
			}
			decreaseScale = value;
		}
	}

	public __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ EndHandler
	{
		get
		{
			return endHandler;
		}
		set
		{
			endHandler = value;
		}
	}

	public __CooldownValue_UpdateHandler_0024callable50_002433_30__ UpdateHandler
	{
		get
		{
			return updateHandler;
		}
		set
		{
			updateHandler = value;
		}
	}

	public CooldownValue()
	{
		heatTime = 6f;
		decreaseScale = 1f;
		initialized = true;
	}

	public void update(float dt)
	{
		if (!(current > 0f) && initialized)
		{
			return;
		}
		initialized = false;
		float num = current;
		current -= dt * DecreaseScale;
		current = Mathf.Max(0f, current);
		if (!(current > 0f))
		{
			if (endHandler != null && !(num <= 0f))
			{
				endHandler();
			}
		}
		else if (updateHandler != null)
		{
			updateHandler(current);
		}
	}

	public void heatUp()
	{
		if (!GameParameter.noSkillCoolDown)
		{
			current = heatTime;
		}
	}

	public void reset()
	{
		if (!(current <= 0f))
		{
			current = 0f;
			if (endHandler != null)
			{
				endHandler();
			}
		}
	}

	public void resetAndSetDefaultSpeed()
	{
		reset();
		DecreaseScale = 1f;
	}

	public void 超デバッグタイム設定使うなごるあ(float v)
	{
		if (!(v > 0f))
		{
			throw new AssertionFailedException("v > 0.0F");
		}
		current = v;
	}

	public override string ToString()
	{
		return new StringBuilder().Append(current).Append("/").Append(heatTime)
			.Append(" ready=")
			.Append(IsReady)
			.ToString();
	}
}
