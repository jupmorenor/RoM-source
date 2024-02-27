using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_LightColor : Ef_Base
{
	public Ef_LightColorObj[] setObjs;

	public bool evelyFlame;

	public string changeShader;

	private Ef_SmokeColorData colorData;

	private float findTime;

	public Material[] mats;

	private Color[] muls;

	private int leng;

	public Ef_LightColor()
	{
		evelyFlame = true;
		changeShader = "Custom/Cutout/Unlit with Shadow Color";
	}

	public void Start()
	{
		int length = setObjs.Length;
		Shader shader = null;
		if (changeShader.Length > 0)
		{
			shader = Shader.Find(changeShader);
		}
		Material[] array = null;
		GameObject gameObject = null;
		int num = default(int);
		int num2 = default(int);
		IEnumerator<int> enumerator = Builtins.range(length).GetEnumerator();
		checked
		{
			try
			{
				while (enumerator.MoveNext())
				{
					num = enumerator.Current;
					Ef_LightColorObj[] array2 = setObjs;
					gameObject = array2[RuntimeServices.NormalizeArrayIndex(array2, num)].gameObj;
					if ((bool)gameObject && (bool)gameObject.renderer)
					{
						array = gameObject.renderer.materials;
						leng += array.Length;
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			mats = new Material[leng];
			muls = new Color[leng];
			int num3 = 0;
			IEnumerator<int> enumerator2 = Builtins.range(length).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					num = enumerator2.Current;
					Ef_LightColorObj[] array3 = setObjs;
					gameObject = array3[RuntimeServices.NormalizeArrayIndex(array3, num)].gameObj;
					if (!gameObject || !gameObject.renderer)
					{
						continue;
					}
					Material[] materials = gameObject.renderer.materials;
					IEnumerator<int> enumerator3 = Builtins.range(materials.Length).GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							num2 = enumerator3.Current;
							Material[] array4 = mats;
							array4[RuntimeServices.NormalizeArrayIndex(array4, num3)] = materials[RuntimeServices.NormalizeArrayIndex(materials, num2)];
							Ef_LightColorObj[] array5 = setObjs;
							if (array5[RuntimeServices.NormalizeArrayIndex(array5, num)].changeShader && (bool)shader)
							{
								Material[] array6 = mats;
								array6[RuntimeServices.NormalizeArrayIndex(array6, num3)].shader = shader;
							}
							if (!materials[RuntimeServices.NormalizeArrayIndex(materials, num2)].HasProperty("_Color"))
							{
								leng--;
								continue;
							}
							Color[] array7 = muls;
							ref Color reference = ref array7[RuntimeServices.NormalizeArrayIndex(array7, num3)];
							Ef_LightColorObj[] array8 = setObjs;
							reference = array8[RuntimeServices.NormalizeArrayIndex(array8, num)].mulColor;
							num3++;
						}
					}
					finally
					{
						enumerator3.Dispose();
					}
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
			SetColor();
		}
	}

	public void Update()
	{
		if (evelyFlame)
		{
			SetColor();
		}
	}

	public void SetColor()
	{
		if (!Ef_SmokeColorData.current)
		{
			return;
		}
		colorData = Ef_SmokeColorData.current.GetComponent<Ef_SmokeColorData>();
		Color color = Color.white;
		if (colorData.lightTable != null)
		{
			color = colorData.lightTable.CheckColor(transform.position);
		}
		if (leng > 0)
		{
			int num = default(int);
			IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					num = enumerator.Current;
					Color color2 = color;
					Color[] array = muls;
					Color color3 = color2 * array[RuntimeServices.NormalizeArrayIndex(array, num)];
					Material[] array2 = mats;
					array2[RuntimeServices.NormalizeArrayIndex(array2, num)].SetColor("_Color", color3);
				}
				return;
			}
			finally
			{
				enumerator.Dispose();
			}
		}
		if ((bool)gameObject.renderer && (bool)gameObject.renderer.material && gameObject.renderer.material.HasProperty("_Color"))
		{
			gameObject.renderer.material.SetColor("_Color", color);
		}
	}
}
