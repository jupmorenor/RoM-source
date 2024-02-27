using System;
using UnityEngine;

[Serializable]
public class Ef_HitPush : MonoBehaviour
{
	public float radius;

	private Ef_HitDatas hitDats;

	public Ef_HitPush()
	{
		radius = 0.5f;
	}

	public void Start()
	{
		hitDats = Ef_HitDatas.Current;
		if (hitDats == null)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		else if (!hitDats.SetHitData(transform, radius))
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public void Update()
	{
		if (hitDats == null)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		else
		{
			hitDats.Push2D(transform);
		}
	}
}
