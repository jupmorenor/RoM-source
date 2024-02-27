using System;
using UnityEngine;

[Serializable]
public class Ef_Spirit_Undine : Ef_Base
{
	public float life;

	public GameObject animObj;

	public GameObject meshObj;

	private Material mat1;

	private Material mat2;

	public Ef_Spirit_Undine()
	{
		life = 3.5f;
	}

	public void Start()
	{
		if ((bool)animObj)
		{
			animObj.animation.Play("c5015_bt_sp");
		}
		if ((bool)meshObj)
		{
			mat1 = meshObj.renderer.materials[0];
			mat2 = meshObj.renderer.materials[1];
		}
	}

	public void Update()
	{
		life -= deltaTime;
		if (!(life > 0.5f))
		{
			if ((bool)mat1)
			{
				mat1.SetColor("_Color", Color.Lerp(Color.white, new Color(0.7f, 0.7f, 0.7f, 1f), life * 2f));
				mat1.SetColor("_RimColor", Color.Lerp(Color.white, Color.white, life * 2f));
			}
			if ((bool)mat2)
			{
				mat2.SetColor("_Color", Color.Lerp(Color.white, new Color(0.7f, 0.7f, 0.7f, 1f), life * 2f));
				mat2.SetColor("_RimColor", Color.Lerp(Color.white, Color.white, life * 2f));
			}
			if (!(life > 0f))
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	public void OnDestroy()
	{
		if ((bool)mat1)
		{
			UnityEngine.Object.Destroy(mat1);
		}
		if ((bool)mat2)
		{
			UnityEngine.Object.Destroy(mat2);
		}
	}
}
