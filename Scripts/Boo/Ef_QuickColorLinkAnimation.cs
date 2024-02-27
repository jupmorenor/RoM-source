using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_QuickColorLinkAnimation : MonoBehaviour
{
	public Ef_QuickColorLinkAnimation_Anim[] animDatas;

	public GameObject[] meshObjs;

	public bool firstColor;

	private Color[] fstColors;

	private Material[] mats;

	private float timeLeng;

	private int leng;

	private int dleng;

	private float[] timeLengs;

	private float[] oldTime;

	private bool[] animFlgs;

	private bool ready;

	public Ef_QuickColorLinkAnimation()
	{
		firstColor = true;
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
	}

	public void Init()
	{
		if (ready)
		{
			return;
		}
		dleng = animDatas.Length;
		timeLengs = new float[dleng];
		oldTime = new float[dleng];
		animFlgs = new bool[dleng];
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(dleng).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Animation obj = animation;
				Ef_QuickColorLinkAnimation_Anim[] array = animDatas;
				AnimationState animationState = obj[array[RuntimeServices.NormalizeArrayIndex(array, num)].clipName];
				if ((bool)animationState)
				{
					float[] array2 = timeLengs;
					array2[RuntimeServices.NormalizeArrayIndex(array2, num)] = animationState.length;
					float[] array3 = oldTime;
					array3[RuntimeServices.NormalizeArrayIndex(array3, num)] = animationState.time;
				}
				else
				{
					float[] array4 = timeLengs;
					array4[RuntimeServices.NormalizeArrayIndex(array4, num)] = 0f;
					float[] array5 = oldTime;
					array5[RuntimeServices.NormalizeArrayIndex(array5, num)] = 0f;
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		int num2 = meshObjs.Length;
		if (num2 == 0)
		{
			meshObjs = new GameObject[1];
			meshObjs[0] = gameObject;
			num2 = 1;
		}
		leng = 0;
		int num3 = 0;
		IEnumerator<int> enumerator2 = Builtins.range(num2).GetEnumerator();
		checked
		{
			try
			{
				while (enumerator2.MoveNext())
				{
					num = enumerator2.Current;
					GameObject[] array6 = meshObjs;
					if (!array6[RuntimeServices.NormalizeArrayIndex(array6, num)])
					{
						return;
					}
					GameObject[] array7 = meshObjs;
					if (!array7[RuntimeServices.NormalizeArrayIndex(array7, num)].renderer)
					{
						return;
					}
					int num4 = leng;
					GameObject[] array8 = meshObjs;
					leng = num4 + array8[RuntimeServices.NormalizeArrayIndex(array8, num)].renderer.materials.Length;
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
			mats = new Material[leng];
			IEnumerator<int> enumerator3 = Builtins.range(num2).GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					num = enumerator3.Current;
					GameObject[] array9 = meshObjs;
					Material[] materials = array9[RuntimeServices.NormalizeArrayIndex(array9, num)].renderer.materials;
					int num5 = default(int);
					IEnumerator<int> enumerator4 = Builtins.range(materials.Length).GetEnumerator();
					try
					{
						while (enumerator4.MoveNext())
						{
							num5 = enumerator4.Current;
							if (!materials[RuntimeServices.NormalizeArrayIndex(materials, num5)].HasProperty("_Color"))
							{
								return;
							}
							Material[] array10 = mats;
							array10[RuntimeServices.NormalizeArrayIndex(array10, num3)] = materials[RuntimeServices.NormalizeArrayIndex(materials, num5)];
							num3++;
						}
					}
					finally
					{
						enumerator4.Dispose();
					}
				}
			}
			finally
			{
				enumerator3.Dispose();
			}
			if (firstColor)
			{
				fstColors = new Color[leng];
				IEnumerator<int> enumerator5 = Builtins.range(leng).GetEnumerator();
				try
				{
					while (enumerator5.MoveNext())
					{
						num = enumerator5.Current;
						Color[] array11 = fstColors;
						ref Color reference = ref array11[RuntimeServices.NormalizeArrayIndex(array11, num)];
						Material[] array12 = mats;
						reference = array12[RuntimeServices.NormalizeArrayIndex(array12, num)].GetColor("_Color");
					}
				}
				finally
				{
					enumerator5.Dispose();
				}
			}
			ready = true;
		}
	}

	public void Update()
	{
		UpdateAnim();
	}

	public void UpdateAnim()
	{
		if (!ready)
		{
			Init();
			if (!ready)
			{
				return;
			}
		}
		bool flag = false;
		Color color = default(Color);
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(dleng).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Animation obj = animation;
				Ef_QuickColorLinkAnimation_Anim[] array = animDatas;
				AnimationState animationState = obj[array[RuntimeServices.NormalizeArrayIndex(array, num)].clipName + " - Queued Clone"];
				if (!animationState)
				{
					Animation obj2 = animation;
					Ef_QuickColorLinkAnimation_Anim[] array2 = animDatas;
					animationState = obj2[array2[RuntimeServices.NormalizeArrayIndex(array2, num)].clipName];
				}
				if (!animationState)
				{
					continue;
				}
				float time = animationState.time;
				float[] array3 = oldTime;
				if (array3[RuntimeServices.NormalizeArrayIndex(array3, num)] != time)
				{
					float[] array4 = timeLengs;
					float num2 = time / array4[RuntimeServices.NormalizeArrayIndex(array4, num)];
					if (animationState.wrapMode == WrapMode.Loop)
					{
						num2 %= 1f;
					}
					Ef_QuickColorLinkAnimation_Anim[] array5 = animDatas;
					color = array5[RuntimeServices.NormalizeArrayIndex(array5, num)].colorAnim.Evaluate(num2);
					float[] array6 = oldTime;
					array6[RuntimeServices.NormalizeArrayIndex(array6, num)] = time;
					bool[] array7 = animFlgs;
					array7[RuntimeServices.NormalizeArrayIndex(array7, num)] = true;
					flag = true;
				}
				else
				{
					bool[] array8 = animFlgs;
					if (array8[RuntimeServices.NormalizeArrayIndex(array8, num)] && animationState.time == 0f)
					{
						Ef_QuickColorLinkAnimation_Anim[] array9 = animDatas;
						color = array9[RuntimeServices.NormalizeArrayIndex(array9, num)].colorAnim.Evaluate(1f);
						bool[] array10 = animFlgs;
						array10[RuntimeServices.NormalizeArrayIndex(array10, num)] = false;
						flag = true;
					}
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		if (!flag)
		{
			return;
		}
		IEnumerator<int> enumerator2 = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				num = enumerator2.Current;
				if (firstColor)
				{
					Color color2 = color;
					Color[] array11 = fstColors;
					color = color2 * array11[RuntimeServices.NormalizeArrayIndex(array11, num)];
				}
				Material[] array12 = mats;
				array12[RuntimeServices.NormalizeArrayIndex(array12, num)].SetColor("_Color", color);
			}
		}
		finally
		{
			enumerator2.Dispose();
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
			Material[] array = mats;
			if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, index)])
			{
				Material[] array2 = mats;
				UnityEngine.Object.Destroy(array2[RuntimeServices.NormalizeArrayIndex(array2, index)]);
			}
		}
	}
}
