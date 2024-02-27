using System;
using UnityEngine;

[Serializable]
public class Ef_bow_skill4 : Ef_Base
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

	public Ef_bow_skill4()
	{
		length = 40f;
		life = 1f;
		speed = 100f;
	}

	public void Start()
	{
		fstPos = transform.position;
		fstLife = life;
		trailRend = trailObj.GetComponent<TrailRenderer>();
		trailWidth = trailRend.startWidth;
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
		}
		else
		{
			life -= deltaTime;
			trailRend.startWidth = trailWidth / fstLife * life;
			trailRend.endWidth = trailRend.startWidth;
			if (!(life > 0f))
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}
}
