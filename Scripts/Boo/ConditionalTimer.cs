using System;
using Boo.Lang;
using CompilerGenerated;

[Serializable]
public class ConditionalTimer
{
	private __LotterySequence_startUpdateFunc_0024callable42_002410_31__ condition;

	private ICallable callback;

	private float callbackTime;

	private float timer;

	private bool enabled;

	public __LotterySequence_startUpdateFunc_0024callable42_002410_31__ Condition
	{
		get
		{
			return condition;
		}
		set
		{
			condition = value;
		}
	}

	public ICallable Callback
	{
		get
		{
			return callback;
		}
		set
		{
			callback = value;
		}
	}

	public float CallbackTime
	{
		get
		{
			return callbackTime;
		}
		set
		{
			if (!(value > 0f))
			{
				throw new ArgumentException("precondition '(value > 0.0F)' failed:");
			}
			callbackTime = value;
		}
	}

	public float Timer => timer;

	public bool Enabled => enabled;

	public ConditionalTimer()
	{
		callbackTime = 1f;
		enabled = true;
	}

	public void stop()
	{
		enabled = false;
	}

	public void start()
	{
		enabled = true;
		timer = 0f;
	}

	public void update(float dt)
	{
		if (!enabled)
		{
			return;
		}
		if (condition != null && condition())
		{
			timer += dt;
			if (!(timer < callbackTime))
			{
				timer = 0f;
				if (callback != null)
				{
					callback.Call(new object[0]);
				}
			}
		}
		else
		{
			timer = 0f;
		}
	}
}
