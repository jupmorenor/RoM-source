using System;
using UnityEngine;

[Serializable]
public class Ef_Kiss : Ef_Base
{
	public Transform b0;

	public float force;

	public float brake;

	public float life;

	public float speed;

	public float spin;

	public float sinX;

	public float sinY;

	public float sinZ;

	public float maxSize;

	private float size;

	private float rnd;

	public Ef_Kiss()
	{
		force = 1f;
		brake = 10f;
		life = 10f;
		speed = 2f;
		spin = 360f;
		sinX = 8f;
		sinY = 12f;
		sinZ = 4f;
		maxSize = 1.5f;
		size = 0.3f;
	}

	public void Start()
	{
		rnd = UnityEngine.Random.Range(0f, 100f);
	}

	public void Update()
	{
		if (!b0)
		{
			b0 = transform.Find("b0");
		}
		if ((bool)b0)
		{
			transform.Translate(Vector3.forward * speed * deltaTime);
			Vector3 zero = Vector3.zero;
			float num = life + rnd;
			zero.x += Mathf.Sin(num * sinX) / 4f;
			zero.y += Mathf.Sin(num * sinY) / 6f;
			zero.z += Mathf.Sin(num * sinZ) / 3f;
			Vector3 vector = zero - b0.localPosition;
			b0.localPosition = zero;
			b0.localRotation = Quaternion.Euler(vector.z * 80f, life * spin, (0f - vector.x) * 80f);
			size += deltaTime / 2f;
			if (!(size <= maxSize))
			{
				size = maxSize;
			}
			b0.localScale = new Vector3(size, size, size);
			life -= deltaTime;
			if (!(life >= 0f))
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}
}
