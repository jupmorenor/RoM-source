using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_DeactiveAlpha : Ef_Base
{
	public bool sleep;

	public GameObject[] rendererObjs;

	public float life;

	public float fadeTime;

	public Transform releaseParent;

	private float fstLife;

	private int gleng;

	private int leng;

	private Material[] mats;

	private float[] fstAlps;

	private Vector3[] fstPoss;

	private Quaternion[] fstRots;

	private bool ready;

	public Ef_DeactiveAlpha()
	{
		rendererObjs = new GameObject[0];
		life = 1f;
	}

	public void SetLife(float inLife)
	{
		life = inLife;
		fstLife = inLife;
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		EndAndNext();
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
	}

	public void Initialize()
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
		fstLife = life;
		if (fadeTime == 0f)
		{
			fadeTime = life;
		}
		gleng = rendererObjs.Length;
		if (gleng == 0)
		{
			rendererObjs = new GameObject[1];
			rendererObjs[0] = gameObject;
			gleng = 1;
		}
		leng = 0;
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(gleng).GetEnumerator();
		checked
		{
			try
			{
				while (enumerator.MoveNext())
				{
					num = enumerator.Current;
					GameObject[] array = rendererObjs;
					if (array[RuntimeServices.NormalizeArrayIndex(array, num)] == null)
					{
						continue;
					}
					GameObject[] array2 = rendererObjs;
					if ((bool)array2[RuntimeServices.NormalizeArrayIndex(array2, num)].renderer)
					{
						GameObject[] array3 = rendererObjs;
						Renderer renderer = array3[RuntimeServices.NormalizeArrayIndex(array3, num)].renderer;
						if (!(renderer == null))
						{
							Material[] materials = renderer.materials;
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
			if ((bool)releaseParent)
			{
				fstPoss = new Vector3[leng];
				fstRots = new Quaternion[leng];
			}
			int num2 = 0;
			IEnumerator<int> enumerator2 = Builtins.range(gleng).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					num = enumerator2.Current;
					GameObject[] array4 = rendererObjs;
					if (!array4[RuntimeServices.NormalizeArrayIndex(array4, num)])
					{
						continue;
					}
					GameObject[] array5 = rendererObjs;
					if ((bool)array5[RuntimeServices.NormalizeArrayIndex(array5, num)].renderer)
					{
						GameObject[] array6 = rendererObjs;
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
					if ((bool)releaseParent)
					{
						GameObject[] array13 = rendererObjs;
						Transform transform = array13[RuntimeServices.NormalizeArrayIndex(array13, num)].transform;
						Vector3[] array14 = fstPoss;
						ref Vector3 reference = ref array14[RuntimeServices.NormalizeArrayIndex(array14, num)];
						reference = transform.localPosition;
						Quaternion[] array15 = fstRots;
						ref Quaternion reference2 = ref array15[RuntimeServices.NormalizeArrayIndex(array15, num)];
						reference2 = transform.localRotation;
					}
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
			ready = true;
		}
	}

	public void Update()
	{
		if (!ready)
		{
			Init();
		}
		if (sleep)
		{
			return;
		}
		int num = default(int);
		if (!(life <= 0f))
		{
			if (!(life >= fadeTime))
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
								float num2 = life / fadeTime;
								float[] array4 = fstAlps;
								color.a = num2 * array4[RuntimeServices.NormalizeArrayIndex(array4, num)];
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
			gameObject.SendMessage("OnDeactive", SendMessageOptions.DontRequireReceiver);
			EndAndNext();
			if (!releaseParent)
			{
				gameObject.SetActive(value: false);
			}
		}
		life -= deltaTime;
	}

	public void EndAndNext()
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
				if (array2[RuntimeServices.NormalizeArrayIndex(array2, index)].HasProperty("_Color"))
				{
					Material[] array3 = mats;
					Color color = array3[RuntimeServices.NormalizeArrayIndex(array3, index)].GetColor("_Color");
					float[] array4 = fstAlps;
					color.a = array4[RuntimeServices.NormalizeArrayIndex(array4, index)];
					Material[] array5 = mats;
					array5[RuntimeServices.NormalizeArrayIndex(array5, index)].SetColor("_Color", color);
				}
			}
			if ((bool)releaseParent)
			{
				GameObject[] array6 = rendererObjs;
				if ((bool)array6[RuntimeServices.NormalizeArrayIndex(array6, index)])
				{
					GameObject[] array7 = rendererObjs;
					Transform transform = array7[RuntimeServices.NormalizeArrayIndex(array7, index)].transform;
					transform.parent = releaseParent;
					Vector3[] array8 = fstPoss;
					transform.localPosition = array8[RuntimeServices.NormalizeArrayIndex(array8, index)];
					Quaternion[] array9 = fstRots;
					transform.localRotation = array9[RuntimeServices.NormalizeArrayIndex(array9, index)];
				}
			}
		}
		if ((bool)releaseParent)
		{
			sleep = true;
		}
		life = fstLife;
	}
}
