using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_TextureScrollMulti : Ef_Base
{
	public float life;

	public Color[] colors;

	public Vector2[] tilings;

	public Vector2[] scrollVecs;

	public Vector2[] offsets;

	public string[] shaderTexs;

	private Material[] materials;

	private int leng;

	private bool end;

	public Ef_TextureScrollMulti()
	{
		colors = new Color[0];
		tilings = new Vector2[0];
		scrollVecs = new Vector2[0];
		offsets = new Vector2[0];
		shaderTexs = new string[0];
		materials = new Material[0];
	}

	public void Start()
	{
		int num = default(int);
		if (materials.Length == 0)
		{
			materials = renderer.materials;
		}
		leng = materials.Length;
		if (scrollVecs.Length < leng)
		{
			scrollVecs = new Vector2[leng];
			IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					num = enumerator.Current;
					Vector2[] array = scrollVecs;
					ref Vector2 reference = ref array[RuntimeServices.NormalizeArrayIndex(array, num)];
					reference = new Vector2(0.1f, 0.1f);
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		}
		if (offsets.Length < leng)
		{
			offsets = new Vector2[leng];
		}
		if (shaderTexs.Length < leng)
		{
			shaderTexs = new string[leng];
			IEnumerator<int> enumerator2 = Builtins.range(leng).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					num = enumerator2.Current;
					string[] array2 = shaderTexs;
					array2[RuntimeServices.NormalizeArrayIndex(array2, num)] = "_MainTex";
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
		}
		if (colors.Length >= leng)
		{
			IEnumerator<int> enumerator3 = Builtins.range(leng).GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					num = enumerator3.Current;
					Material[] array3 = materials;
					if (array3[RuntimeServices.NormalizeArrayIndex(array3, num)].HasProperty("_Color"))
					{
						Material[] array4 = materials;
						Material obj = array4[RuntimeServices.NormalizeArrayIndex(array4, num)];
						Color[] array5 = colors;
						obj.SetColor("_Color", array5[RuntimeServices.NormalizeArrayIndex(array5, num)]);
					}
				}
			}
			finally
			{
				enumerator3.Dispose();
			}
		}
		if (tilings.Length < leng)
		{
			return;
		}
		IEnumerator<int> enumerator4 = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator4.MoveNext())
			{
				num = enumerator4.Current;
				Material[] array6 = materials;
				Material obj2 = array6[RuntimeServices.NormalizeArrayIndex(array6, num)];
				string[] array7 = shaderTexs;
				string propertyName = array7[RuntimeServices.NormalizeArrayIndex(array7, num)];
				Vector2[] array8 = tilings;
				obj2.SetTextureScale(propertyName, array8[RuntimeServices.NormalizeArrayIndex(array8, num)]);
			}
		}
		finally
		{
			enumerator4.Dispose();
		}
	}

	public void Update()
	{
		if (end)
		{
			return;
		}
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Vector2[] array = offsets;
				ref Vector2 reference = ref array[RuntimeServices.NormalizeArrayIndex(array, num)];
				Vector2[] array2 = offsets;
				Vector2 vector = array2[RuntimeServices.NormalizeArrayIndex(array2, num)];
				Vector2[] array3 = scrollVecs;
				reference = vector + array3[RuntimeServices.NormalizeArrayIndex(array3, num)] * deltaTime;
				Material[] array4 = materials;
				Material obj = array4[RuntimeServices.NormalizeArrayIndex(array4, num)];
				string[] array5 = shaderTexs;
				string propertyName = array5[RuntimeServices.NormalizeArrayIndex(array5, num)];
				Vector2[] array6 = offsets;
				obj.SetTextureOffset(propertyName, array6[RuntimeServices.NormalizeArrayIndex(array6, num)]);
			}
		}
		finally
		{
			enumerator.Dispose();
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
		int num = 0;
		int num2 = leng;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			Material[] array = materials;
			if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, index)])
			{
				Material[] array2 = materials;
				UnityEngine.Object.Destroy(array2[RuntimeServices.NormalizeArrayIndex(array2, index)]);
			}
		}
	}
}
