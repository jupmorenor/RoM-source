using System;
using UnityEngine;

[Serializable]
public class Ef_Comb_Storm_Wave : Ef_Base
{
	public float life;

	public float scale;

	public float speed;

	public Vector2 scrollVec;

	public float rndMax;

	public float rndMin;

	public float brake;

	private float secScale;

	private Vector2 scrollPos;

	public Ef_Comb_Storm_Wave()
	{
		life = 3f;
		scale = 1.5f;
		speed = 1.5f;
		scrollVec = new Vector2(0.5f, -1f);
		rndMax = 1.1f;
		rndMin = 0.9f;
		brake = 0.5f;
		scrollPos = Vector2.zero;
	}

	public void Start()
	{
		float num = UnityEngine.Random.Range(rndMax, rndMin);
		scale *= num;
		speed *= num;
		secScale = scale - 1f;
		scrollVec *= num;
	}

	public void Update()
	{
		transform.Translate(new Vector3(0f, 0f, speed * deltaTime));
		transform.localScale *= 1f + secScale * deltaTime;
		scrollPos += scrollVec * deltaTime;
		renderer.material.SetTextureOffset("_MainTex", scrollPos);
		secScale = (float)((double)secScale * (1.0 - (double)(brake * deltaTime)));
		speed = (float)((double)speed * (1.0 - (double)(brake * deltaTime)));
		scrollVec *= (float)(1.0 - (double)(brake * deltaTime));
		life -= deltaTime;
		if (!(life >= 2f))
		{
			float a = life / 2f;
			Color color = renderer.material.color;
			float num = (color.a = a);
			Color color3 = (renderer.material.color = color);
		}
		if (!(life > 0f))
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}
}
