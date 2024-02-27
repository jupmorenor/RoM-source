using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_ScaleHeight : Ef_GroundHeight
{
	public GameObject meshObj;

	public float scaleHeightA;

	public float scaleHeightB;

	public float scaleHeightC;

	public float alphaHeightA;

	public float alphaHeightB;

	public float alphaHeightC;

	public Vector3 scaleA;

	public Vector3 scaleB;

	public Vector3 scaleC;

	public float alphaA;

	public float alphaB;

	public float alphaC;

	private Material mat;

	public Ef_ScaleHeight()
	{
		scaleHeightB = -3f;
		scaleHeightC = -12f;
		alphaHeightA = -8f;
		alphaHeightB = -8f;
		alphaHeightC = -12f;
		scaleA = Vector3.one;
		scaleB = new Vector3(1.2f, 1.2f, 1.2f);
		scaleC = new Vector3(0.4f, 0.2f, 0.4f);
		alphaA = 1f;
		alphaB = 1f;
	}

	public override void Start()
	{
		base.Start();
		if (!(alphaC >= 1f))
		{
			mat = meshObj.renderer.material;
		}
	}

	public void Update()
	{
		object[] groundHeight = GetGroundHeight(transform.position);
		bool flag = RuntimeServices.UnboxBoolean(groundHeight[0]);
		float num = RuntimeServices.UnboxSingle(groundHeight[1]);
		Vector3 vector = (Vector3)groundHeight[2];
		float num2 = transform.position.y - num;
		Vector3 vector2 = default(Vector3);
		float num3 = default(float);
		float num4 = default(float);
		if (!(num2 >= scaleHeightA))
		{
			if (!(num2 <= scaleHeightB))
			{
				num4 = Mathf.Abs(num2 - scaleHeightA) / (scaleHeightA - scaleHeightB);
				vector2 = Vector3.Lerp(scaleA, scaleB, num4);
			}
			else if (!(num2 <= scaleHeightC))
			{
				num4 = Mathf.Abs(num2 - scaleHeightB) / (scaleHeightB - scaleHeightC);
				vector2 = Vector3.Lerp(scaleB, scaleC, num4);
			}
			else
			{
				vector2 = scaleC;
			}
		}
		else
		{
			vector2 = scaleA;
		}
		if (!(num2 >= alphaHeightA))
		{
			if (!(num2 <= alphaHeightB))
			{
				num4 = Mathf.Abs(num2 - alphaHeightA) / (alphaHeightA - alphaHeightB);
				num3 = Mathf.Lerp(alphaA, alphaB, num4);
			}
			if (!(num2 <= alphaHeightC))
			{
				num4 = Mathf.Abs(num2 - alphaHeightB) / (alphaHeightB - alphaHeightC);
				num3 = Mathf.Lerp(alphaB, alphaC, num4);
			}
			else
			{
				num3 = alphaC;
			}
		}
		else
		{
			num3 = alphaA;
		}
		transform.localScale = vector2;
		if ((bool)mat)
		{
			float a = num3;
			Color color = mat.color;
			float num5 = (color.a = a);
			Color color3 = (mat.color = color);
		}
	}
}
