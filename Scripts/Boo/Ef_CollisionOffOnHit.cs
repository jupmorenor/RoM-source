using System;

[Serializable]
public class Ef_CollisionOffOnHit : Ef_Base
{
	public bool stayOnly;

	public float rapidTime;

	private float fstTime;

	public Ef_CollisionOffOnHit()
	{
		stayOnly = true;
	}

	public void Start()
	{
		fstTime = rapidTime;
	}

	public void Update()
	{
		if (!collider.enabled && !(fstTime <= 0f))
		{
			rapidTime -= deltaTime;
			if (!(rapidTime > 0f))
			{
				collider.enabled = true;
				rapidTime = fstTime;
			}
		}
	}

	public void OnCollisionEnter()
	{
		if (!stayOnly)
		{
			collider.enabled = false;
		}
	}

	public void OnCollisionStay()
	{
		collider.enabled = false;
	}

	public void OnTriggerEnter()
	{
		if (!stayOnly)
		{
			collider.enabled = false;
		}
	}

	public void OnTriggerStay()
	{
		collider.enabled = false;
	}
}
