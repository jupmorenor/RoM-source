using System;
using UnityEngine;

[Serializable]
public class Ef_Area_Ice : Ef_Base
{
	public float radius;

	public float life;

	public Transform meshObj;

	public Transform smokeObj;

	public GameObject smokeObj2;

	public Transform b0Obj;

	public Transform parentObj;

	private bool parFlg;

	private Material mat;

	private Vector3 tgtScale;

	private Color tgtColor;

	public Ef_Area_Ice()
	{
		radius = 1f;
		life = 10f;
		tgtColor = new Color(0.2f, 0.3f, 0.5f, 0.25f);
	}

	public void Start()
	{
		if (!meshObj)
		{
			meshObj = transform.Find("Mesh");
		}
		if (!smokeObj)
		{
			smokeObj = transform.Find("b00/Ef_Area_Ice_Smoke");
		}
		if (!parentObj)
		{
			parentObj = transform.parent;
		}
		if ((bool)parentObj)
		{
			parFlg = true;
		}
		transform.parent = null;
		transform.localScale = new Vector3(0f, 1f, 0f);
		tgtScale = new Vector3(radius, 1f, radius);
		if ((bool)smokeObj)
		{
			smokeObj.particleSystem.Play();
		}
		mat = meshObj.renderer.materials[0];
		mat.color = tgtColor;
	}

	public void Update()
	{
		if (!(life < 1f))
		{
			if (parFlg && !parentObj)
			{
				life = 1f;
			}
			life -= deltaTime;
			if (!(life >= 1f))
			{
				transform.parent = null;
				if ((bool)smokeObj)
				{
					smokeObj.particleSystem.emissionRate = 0f;
				}
				if ((bool)b0Obj && (bool)smokeObj2)
				{
					UnityEngine.Object.Instantiate(smokeObj2, b0Obj.position, b0Obj.rotation);
				}
			}
		}
		else
		{
			life -= deltaTime;
			float a = life * 0.25f;
			Color color = mat.color;
			float num = (color.a = a);
			Color color3 = (mat.color = color);
		}
		if (!(life > 0f))
		{
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		if (!(transform.localScale == tgtScale))
		{
			transform.localScale = Vector3.Lerp(transform.localScale, tgtScale, 10f * deltaTime);
			if (!((tgtScale - transform.localScale).magnitude >= 0.001f))
			{
				transform.localScale = tgtScale;
			}
		}
		Vector2 mainTextureOffset = meshObj.renderer.material.mainTextureOffset;
		mainTextureOffset.x -= 0.05f * deltaTime;
		mainTextureOffset.y -= (Mathf.Sin(life * 4f) + 2f) * 0.1f * deltaTime;
		if (!(mainTextureOffset.x >= 0f))
		{
			mainTextureOffset.y += 1f;
		}
		if (!(mainTextureOffset.y >= 0f))
		{
			mainTextureOffset.y += 1f;
		}
		meshObj.renderer.material.mainTextureOffset = mainTextureOffset;
	}

	public void OnDestroy()
	{
		if ((bool)mat)
		{
			UnityEngine.Object.Destroy(mat);
		}
	}
}
