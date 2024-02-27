using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_DestroyAlpha : Ef_Base
{
	public float life;

	public float fadeDelay;

	public GameObject[] gameObjs;

	private float fadeTime;

	private Material[] mats;

	private float[] fstAlps;

	private int leng;

	private int gleng;

	public Ef_DestroyAlpha()
	{
		life = 1f;
		gameObjs = new GameObject[0];
	}

	public void Start()
	{
		gleng = gameObjs.Length;
		if (gleng == 0)
		{
			gameObjs = new GameObject[1];
			gameObjs[0] = gameObject;
			gleng = 1;
		}
		fadeTime = life - fadeDelay;
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(gleng).GetEnumerator();
		checked
		{
			try
			{
				while (enumerator.MoveNext())
				{
					num = enumerator.Current;
					GameObject[] array = gameObjs;
					if (!(array[RuntimeServices.NormalizeArrayIndex(array, num)] == null))
					{
						GameObject[] array2 = gameObjs;
						if ((bool)array2[RuntimeServices.NormalizeArrayIndex(array2, num)].renderer)
						{
							GameObject[] array3 = gameObjs;
							Material[] materials = array3[RuntimeServices.NormalizeArrayIndex(array3, num)].renderer.materials;
							leng += materials.Length;
						}
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			mats = new Material[leng];
			fstAlps = new float[leng];
			int num2 = 0;
			IEnumerator<int> enumerator2 = Builtins.range(gleng).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					num = enumerator2.Current;
					GameObject[] array4 = gameObjs;
					if (array4[RuntimeServices.NormalizeArrayIndex(array4, num)] == null)
					{
						continue;
					}
					GameObject[] array5 = gameObjs;
					if (!array5[RuntimeServices.NormalizeArrayIndex(array5, num)].renderer)
					{
						continue;
					}
					GameObject[] array6 = gameObjs;
					Material[] materials = array6[RuntimeServices.NormalizeArrayIndex(array6, num)].renderer.materials;
					int num3 = 0;
					int length = materials.Length;
					if (length < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num3 < length)
					{
						int index = num3;
						num3 = unchecked(num3 + 1);
						Material[] array7 = mats;
						int num4 = RuntimeServices.NormalizeArrayIndex(array7, num2);
						Material[] array8 = materials;
						array7[num4] = array8[RuntimeServices.NormalizeArrayIndex(array8, index)];
						Material[] array9 = mats;
						if ((bool)array9[RuntimeServices.NormalizeArrayIndex(array9, num2)])
						{
							Material[] array10 = mats;
							if (!array10[RuntimeServices.NormalizeArrayIndex(array10, num2)].HasProperty("_Color"))
							{
								continue;
							}
							float[] array11 = fstAlps;
							int num5 = RuntimeServices.NormalizeArrayIndex(array11, num2);
							Material[] array12 = mats;
							array11[num5] = array12[RuntimeServices.NormalizeArrayIndex(array12, num2)].GetColor("_Color").a;
						}
						num2++;
					}
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
		}
	}

	public void Update()
	{
		int num = default(int);
		if (!(life <= 0f))
		{
			if (!(life > fadeTime))
			{
				IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						num = enumerator.Current;
						Material[] array = mats;
						if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, num)])
						{
							Material[] array2 = mats;
							if (array2[RuntimeServices.NormalizeArrayIndex(array2, num)].HasProperty("_Color"))
							{
								Material[] array3 = mats;
								Color color = array3[RuntimeServices.NormalizeArrayIndex(array3, num)].GetColor("_Color");
								float[] array4 = fstAlps;
								color.a = array4[RuntimeServices.NormalizeArrayIndex(array4, num)] / fadeTime * life;
								Material[] array5 = mats;
								array5[RuntimeServices.NormalizeArrayIndex(array5, num)].SetColor("_Color", color);
							}
						}
					}
				}
				finally
				{
					enumerator.Dispose();
				}
			}
		}
		else
		{
			IEnumerator<int> enumerator2 = Builtins.range(gleng).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					num = enumerator2.Current;
					GameObject[] array6 = gameObjs;
					if (!array6[RuntimeServices.NormalizeArrayIndex(array6, num)])
					{
						continue;
					}
					GameObject[] array7 = gameObjs;
					Ef_DestroyReleaseV2 component = array7[RuntimeServices.NormalizeArrayIndex(array7, num)].GetComponent<Ef_DestroyReleaseV2>();
					if (component != null)
					{
						component.Release();
					}
					else
					{
						GameObject[] array8 = gameObjs;
						Ef_DestroyRelease component2 = array8[RuntimeServices.NormalizeArrayIndex(array8, num)].GetComponent<Ef_DestroyRelease>();
						if (component2 != null)
						{
							component2.Release();
						}
					}
					GameObject[] array9 = gameObjs;
					UnityEngine.Object.Destroy(array9[RuntimeServices.NormalizeArrayIndex(array9, num)]);
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
		}
		life -= deltaTime;
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
			Material[] array = mats;
			if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, index)])
			{
				Material[] array2 = mats;
				UnityEngine.Object.Destroy(array2[RuntimeServices.NormalizeArrayIndex(array2, index)]);
			}
		}
	}
}
