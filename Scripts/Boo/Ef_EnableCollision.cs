using System;

[Serializable]
public class Ef_EnableCollision : Ef_Base
{
	public float enableTime;

	public float desableTime;

	public float timer;

	private bool already;

	private bool desabled;

	public void OnActive()
	{
		already = !(enableTime > 0f);
		SetEnable(already);
		desabled = !(desableTime > 0f);
		timer = 0f;
	}

	public void Start()
	{
		already = !(enableTime > 0f);
		SetEnable(already);
		desabled = !(desableTime > 0f);
		timer = 0f;
	}

	public void Update()
	{
		if (!already)
		{
			if (!(timer < enableTime))
			{
				SetEnable(enable: true);
				already = true;
			}
			timer += deltaTime;
		}
		else if (!desabled)
		{
			if (!(timer < desableTime))
			{
				SetEnable(enable: false);
				desabled = true;
			}
			timer += deltaTime;
		}
	}

	public void SetEnable(bool enable)
	{
		if (collider != null)
		{
			collider.enabled = enable;
		}
	}
}
