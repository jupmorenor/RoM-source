using System;
using UnityEngine;

[Serializable]
public class Ef_Sonic_Cone : Ef_Base
{
	public float length;

	public float life;

	public float speed;

	public GameObject trailObj;

	private Vector3 fstPos;

	private bool stop;

	private float fstLife;

	private float trailWidth;

	private TrailRenderer trailRend;

	public Ef_Sonic_Cone()
	{
		length = 40f;
		life = 1f;
		speed = 30f;
	}

	public void Start()
	{
		fstPos = transform.position;
		fstLife = life;
		if ((bool)trailObj)
		{
			trailRend = trailObj.GetComponent<TrailRenderer>();
		}
		if ((bool)trailRend)
		{
			trailWidth = trailRend.startWidth;
		}
	}

	public void Update()
	{
		if (!stop)
		{
			transform.Translate(new Vector3(0f, 0f, speed * deltaTime));
			Vector3 vector = transform.position - fstPos;
			if (!(vector.magnitude <= length))
			{
				transform.position = fstPos + vector.normalized * length;
				stop = true;
			}
			return;
		}
		life -= deltaTime;
		if ((bool)trailRend)
		{
			trailRend.startWidth = trailWidth / fstLife * life;
			trailRend.endWidth = trailRend.startWidth;
		}
		if (!(life > 0f))
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}
}
