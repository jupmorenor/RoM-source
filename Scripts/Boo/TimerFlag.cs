using System;

[Serializable]
public class TimerFlag
{
	private bool flag;

	private float timer;

	public bool IsOn => flag;

	public float Timer => timer;

	public TimerFlag()
	{
		reset();
	}

	public void reset()
	{
		flag = false;
		timer = 0f;
	}

	public void start(float tm)
	{
		flag = true;
		timer = tm;
	}

	public void update(float dt)
	{
		if (!(timer <= 0f))
		{
			timer -= dt;
			if (!(timer > 0f))
			{
				reset();
			}
		}
	}
}
