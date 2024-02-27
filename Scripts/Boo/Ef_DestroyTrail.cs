using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_DestroyTrail : Ef_Base
{
	public GameObject[] gameObjs;

	public float life;

	public float fadeDelay;

	private TrailRenderer[] trails;

	private float fadeTime;

	private float[] fstStarts;

	private float[] fstEnds;

	private int leng;

	public Ef_DestroyTrail()
	{
		gameObjs = new GameObject[0];
		life = 1f;
		fadeTime = 1f;
	}

	public void Start()
	{
		leng = gameObjs.Length;
		if (leng == 0)
		{
			gameObjs = new GameObject[1];
			gameObjs[0] = gameObject;
			leng = 1;
		}
		fadeTime = life - fadeDelay;
		trails = new TrailRenderer[leng];
		fstStarts = new float[leng];
		fstEnds = new float[leng];
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				TrailRenderer[] array = trails;
				int num2 = RuntimeServices.NormalizeArrayIndex(array, num);
				GameObject[] array2 = gameObjs;
				array[num2] = array2[RuntimeServices.NormalizeArrayIndex(array2, num)].GetComponent<TrailRenderer>();
				TrailRenderer[] array3 = trails;
				if ((bool)array3[RuntimeServices.NormalizeArrayIndex(array3, num)])
				{
					float[] array4 = fstStarts;
					int num3 = RuntimeServices.NormalizeArrayIndex(array4, num);
					TrailRenderer[] array5 = trails;
					array4[num3] = array5[RuntimeServices.NormalizeArrayIndex(array5, num)].startWidth;
					float[] array6 = fstEnds;
					int num4 = RuntimeServices.NormalizeArrayIndex(array6, num);
					TrailRenderer[] array7 = trails;
					array6[num4] = array7[RuntimeServices.NormalizeArrayIndex(array7, num)].endWidth;
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void Update()
	{
		life -= deltaTime;
		int num = default(int);
		if (!(life <= 0f))
		{
			if (life > fadeTime)
			{
				return;
			}
			float num2 = life / fadeTime;
			IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					num = enumerator.Current;
					TrailRenderer[] array = trails;
					if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, num)])
					{
						TrailRenderer[] array2 = trails;
						TrailRenderer obj = array2[RuntimeServices.NormalizeArrayIndex(array2, num)];
						float[] array3 = fstStarts;
						obj.startWidth = array3[RuntimeServices.NormalizeArrayIndex(array3, num)] * num2;
						TrailRenderer[] array4 = trails;
						TrailRenderer obj2 = array4[RuntimeServices.NormalizeArrayIndex(array4, num)];
						float[] array5 = fstEnds;
						obj2.endWidth = array5[RuntimeServices.NormalizeArrayIndex(array5, num)] * num2;
					}
				}
				return;
			}
			finally
			{
				enumerator.Dispose();
			}
		}
		IEnumerator<int> enumerator2 = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				num = enumerator2.Current;
				GameObject[] array6 = gameObjs;
				Ef_DestroyReleaseV2 component = array6[RuntimeServices.NormalizeArrayIndex(array6, num)].GetComponent<Ef_DestroyReleaseV2>();
				if (component != null)
				{
					component.Release();
				}
				else
				{
					GameObject[] array7 = gameObjs;
					Ef_DestroyRelease component2 = array7[RuntimeServices.NormalizeArrayIndex(array7, num)].GetComponent<Ef_DestroyRelease>();
					if (component2 != null)
					{
						component2.Release();
					}
				}
				GameObject[] array8 = gameObjs;
				UnityEngine.Object.Destroy(array8[RuntimeServices.NormalizeArrayIndex(array8, num)]);
			}
		}
		finally
		{
			enumerator2.Dispose();
		}
	}
}
