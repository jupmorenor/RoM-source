using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_DeactiveTrail : Ef_Base
{
	public bool sleep;

	public GameObject[] trailObjs;

	public float life;

	public float fadeTime;

	public Transform releaseParent;

	private float fstLife;

	private int leng;

	private TrailRenderer[] trails;

	private float[] fstSWidths;

	private float[] fstSEidths;

	private float[] fstTimes;

	private Vector3[] fstPoss;

	private Quaternion[] fstRots;

	private bool ready;

	private int timeZero;

	public Ef_DeactiveTrail()
	{
		trailObjs = new GameObject[0];
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
		leng = trailObjs.Length;
		if (leng == 0)
		{
			trailObjs = new GameObject[1];
			trailObjs[0] = gameObject;
			leng = 1;
		}
		trails = new TrailRenderer[leng];
		fstSWidths = new float[leng];
		fstSEidths = new float[leng];
		fstTimes = new float[leng];
		if ((bool)releaseParent)
		{
			fstPoss = new Vector3[leng];
			fstRots = new Quaternion[leng];
		}
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				GameObject[] array = trailObjs;
				if (!array[RuntimeServices.NormalizeArrayIndex(array, num)])
				{
					continue;
				}
				TrailRenderer[] array2 = trails;
				int num2 = RuntimeServices.NormalizeArrayIndex(array2, num);
				GameObject[] array3 = trailObjs;
				array2[num2] = array3[RuntimeServices.NormalizeArrayIndex(array3, num)].GetComponent<TrailRenderer>();
				TrailRenderer[] array4 = trails;
				if ((bool)array4[RuntimeServices.NormalizeArrayIndex(array4, num)])
				{
					TrailRenderer[] array5 = trails;
					if ((bool)array5[RuntimeServices.NormalizeArrayIndex(array5, num)])
					{
						float[] array6 = fstSWidths;
						int num3 = RuntimeServices.NormalizeArrayIndex(array6, num);
						TrailRenderer[] array7 = trails;
						array6[num3] = array7[RuntimeServices.NormalizeArrayIndex(array7, num)].startWidth;
						float[] array8 = fstSEidths;
						int num4 = RuntimeServices.NormalizeArrayIndex(array8, num);
						TrailRenderer[] array9 = trails;
						array8[num4] = array9[RuntimeServices.NormalizeArrayIndex(array9, num)].endWidth;
						float[] array10 = fstTimes;
						int num5 = RuntimeServices.NormalizeArrayIndex(array10, num);
						TrailRenderer[] array11 = trails;
						array10[num5] = array11[RuntimeServices.NormalizeArrayIndex(array11, num)].time;
					}
					if ((bool)releaseParent)
					{
						GameObject[] array12 = trailObjs;
						Transform transform = array12[RuntimeServices.NormalizeArrayIndex(array12, num)].transform;
						Vector3[] array13 = fstPoss;
						ref Vector3 reference = ref array13[RuntimeServices.NormalizeArrayIndex(array13, num)];
						reference = transform.localPosition;
						Quaternion[] array14 = fstRots;
						ref Quaternion reference2 = ref array14[RuntimeServices.NormalizeArrayIndex(array14, num)];
						reference2 = transform.localRotation;
					}
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		ready = true;
	}

	public void Update()
	{
		checked
		{
			if (timeZero > 0)
			{
				timeZero--;
				if (timeZero == 0)
				{
					IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							int current = enumerator.Current;
							TrailRenderer[] array = trails;
							if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, current)])
							{
								TrailRenderer[] array2 = trails;
								TrailRenderer obj = array2[RuntimeServices.NormalizeArrayIndex(array2, current)];
								float[] array3 = fstTimes;
								obj.time = array3[RuntimeServices.NormalizeArrayIndex(array3, current)];
							}
						}
					}
					finally
					{
						enumerator.Dispose();
					}
				}
			}
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
					float num2 = life / fadeTime;
					IEnumerator<int> enumerator2 = Builtins.range(leng).GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							num = enumerator2.Current;
							TrailRenderer[] array4 = trails;
							if ((bool)array4[RuntimeServices.NormalizeArrayIndex(array4, num)])
							{
								TrailRenderer[] array5 = trails;
								TrailRenderer obj2 = array5[RuntimeServices.NormalizeArrayIndex(array5, num)];
								float[] array6 = fstSWidths;
								obj2.startWidth = array6[RuntimeServices.NormalizeArrayIndex(array6, num)] * num2;
								TrailRenderer[] array7 = trails;
								TrailRenderer obj3 = array7[RuntimeServices.NormalizeArrayIndex(array7, num)];
								float[] array8 = fstSEidths;
								obj3.endWidth = array8[RuntimeServices.NormalizeArrayIndex(array8, num)] * num2;
							}
						}
					}
					finally
					{
						enumerator2.Dispose();
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
			TrailRenderer[] array = trails;
			if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, index)])
			{
				TrailRenderer[] array2 = trails;
				TrailRenderer obj = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
				float[] array3 = fstSWidths;
				obj.startWidth = array3[RuntimeServices.NormalizeArrayIndex(array3, index)];
				TrailRenderer[] array4 = trails;
				TrailRenderer obj2 = array4[RuntimeServices.NormalizeArrayIndex(array4, index)];
				float[] array5 = fstSEidths;
				obj2.endWidth = array5[RuntimeServices.NormalizeArrayIndex(array5, index)];
				TrailRenderer[] array6 = trails;
				array6[RuntimeServices.NormalizeArrayIndex(array6, index)].time = 0f;
				timeZero = 2;
			}
			if ((bool)releaseParent)
			{
				GameObject[] array7 = trailObjs;
				if ((bool)array7[RuntimeServices.NormalizeArrayIndex(array7, index)])
				{
					GameObject[] array8 = trailObjs;
					Transform transform = array8[RuntimeServices.NormalizeArrayIndex(array8, index)].transform;
					transform.parent = releaseParent;
					Vector3[] array9 = fstPoss;
					transform.localPosition = array9[RuntimeServices.NormalizeArrayIndex(array9, index)];
					Quaternion[] array10 = fstRots;
					transform.localRotation = array10[RuntimeServices.NormalizeArrayIndex(array10, index)];
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
