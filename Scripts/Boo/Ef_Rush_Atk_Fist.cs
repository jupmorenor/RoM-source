using System;
using UnityEngine;

[Serializable]
public class Ef_Rush_Atk_Fist : Ef_Base
{
	public Transform tgtObj;

	public float speed;

	public float timer;

	public float dist;

	public float fstTimer;

	public float fstDist;

	public float width;

	public float height;

	public GameObject hitObj;

	private Vector3 tgtPos;

	public Ef_Rush_Atk_Fist()
	{
		speed = 30f;
		timer = 0.3f;
		dist = 3f;
		fstTimer = 0.3f;
		fstDist = 3f;
		width = 2f;
		height = 1.2f;
		tgtPos = Vector3.zero;
	}

	public void Start()
	{
		transform.parent = null;
	}

	public void Update()
	{
		if (!(timer > 0f))
		{
			dist -= speed * deltaTime;
			if (!(dist > 0f))
			{
				dist = 0f;
				transform.position = tgtPos - transform.forward * dist;
				if ((bool)hitObj)
				{
					((GameObject)UnityEngine.Object.Instantiate(hitObj, transform.position, Quaternion.identity)).AddComponent<Ef_DestroyTimer>().life = 0.5f;
				}
				timer = fstTimer;
			}
			else
			{
				transform.position = tgtPos - transform.forward * dist;
			}
			return;
		}
		timer -= deltaTime;
		if (!(timer > 0f))
		{
			if ((bool)tgtObj)
			{
				float x = UnityEngine.Random.Range((0f - width) / 2f, width / 2f);
				float y = UnityEngine.Random.Range((0f - height) / 2f, height / 2f);
				float z = 2f;
				tgtPos = tgtObj.position + tgtObj.rotation * new Vector3(x, y, z);
				transform.rotation = tgtObj.rotation;
				dist = fstDist;
				timer = 0f;
			}
			else
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
		transform.localScale = new Vector3(1f + timer * 4f, 1f + timer * 4f, 1f - timer * 2f);
	}
}
