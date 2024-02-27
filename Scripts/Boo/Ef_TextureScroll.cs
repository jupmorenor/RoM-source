using System;
using UnityEngine;

[Serializable]
public class Ef_TextureScroll : Ef_Base
{
	public float life;

	public Vector2 scrollVec0;

	public Vector2 offset0;

	public string shaderTex0;

	public Vector2 scrollVec1;

	public Vector2 offset1;

	public string shaderTex1;

	private bool end;

	private Material mat;

	public Ef_TextureScroll()
	{
		scrollVec0 = new Vector2(0.1f, 0.1f);
		offset0 = Vector2.zero;
		shaderTex0 = "_MainTex";
		scrollVec1 = Vector2.zero;
		offset1 = Vector2.zero;
		shaderTex1 = string.Empty;
	}

	public void Start()
	{
		if (!renderer)
		{
			end = true;
		}
		else
		{
			mat = renderer.material;
		}
	}

	public void Update()
	{
		if (end || mat == null)
		{
			return;
		}
		offset0 += scrollVec0 * deltaTime;
		mat.SetTextureOffset(shaderTex0, offset0);
		if (scrollVec1 != Vector2.zero)
		{
			offset1 += scrollVec1 * deltaTime;
			mat.SetTextureOffset(shaderTex1, offset1);
		}
		if (!(life <= 0f))
		{
			life -= deltaTime;
			if (!(life > 0f))
			{
				end = true;
			}
		}
	}

	public void OnDestroy()
	{
		if ((bool)mat)
		{
			UnityEngine.Object.Destroy(mat);
		}
	}
}
