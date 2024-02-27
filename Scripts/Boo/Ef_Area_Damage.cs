using System;
using UnityEngine;

[Serializable]
public class Ef_Area_Damage : Ef_Base
{
	public float radius;

	public float life;

	public Transform meshObj;

	public Transform b0Obj;

	public GameObject smokeObj;

	public Transform parentObj;

	private bool parFlg;

	private Material mat;

	private Vector3 tgtScale;

	private Color tgtColor;

	private float fstAlpha;

	public Ef_Area_Damage()
	{
		radius = 1f;
		life = 10f;
		tgtColor = new Color(0.625f, 0.625f, 0.625f, 0.25f);
	}

	public void Start()
	{
		if (!meshObj)
		{
			meshObj = transform.Find("Mesh");
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
		mat = meshObj.renderer.materials[0];
		mat.color = tgtColor;
	}

	public void Update()
	{
		if (meshObj == null)
		{
			return;
		}
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
				if ((bool)b0Obj && (bool)smokeObj)
				{
					UnityEngine.Object.Instantiate(smokeObj, b0Obj.position, b0Obj.rotation);
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
		if (transform.localScale != tgtScale)
		{
			transform.localScale = Vector3.Lerp(transform.localScale, tgtScale, 10f * deltaTime);
			if (!((tgtScale - transform.localScale).magnitude >= 0.001f))
			{
				transform.localScale = tgtScale;
			}
		}
		Vector2 mainTextureOffset = meshObj.renderer.material.mainTextureOffset;
		mainTextureOffset.x -= 0.05f * deltaTime;
		mainTextureOffset.y -= 0.2f * deltaTime;
		if (!(mainTextureOffset.x >= 0f))
		{
			mainTextureOffset.y += 1f;
		}
		if (!(mainTextureOffset.y >= 0f))
		{
			mainTextureOffset.y += 1f;
		}
		meshObj.renderer.material.mainTextureOffset = mainTextureOffset;
		meshObj.gameObject.GetComponent<SkinnedMeshRenderer>().materials[0].mainTextureOffset = mainTextureOffset;
	}

	public void OnDestroy()
	{
		if ((bool)mat)
		{
			UnityEngine.Object.Destroy(mat);
		}
	}
}
