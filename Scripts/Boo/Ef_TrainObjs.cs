using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_TrainObjs : Ef_Base
{
	public Transform[] transforms;

	public float allLength;

	public float stepLength;

	private float[] dists;

	private Vector3[] poss;

	private Quaternion[] rots;

	private Vector3[] scales;

	private Quaternion[] fstRots;

	private Vector3[] fstScales;

	private int pt;

	private int num;

	private int step;

	public Ef_TrainObjs()
	{
		transforms = new Transform[0];
		allLength = 20f;
		stepLength = 0.5f;
	}

	public void Start()
	{
		this.num = transforms.Length;
		step = Mathf.RoundToInt(allLength / stepLength);
		poss = new Vector3[step];
		rots = new Quaternion[step];
		scales = new Vector3[step];
		dists = new float[this.num];
		fstRots = new Quaternion[this.num];
		fstScales = new Vector3[this.num];
		Quaternion quaternion = Quaternion.Inverse(transforms[0].rotation);
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(this.num).GetEnumerator();
		checked
		{
			try
			{
				while (enumerator.MoveNext())
				{
					num = enumerator.Current;
					if (num == 0)
					{
						dists[0] = 0f;
						ref Quaternion reference = ref fstRots[0];
						reference = Quaternion.identity;
						ref Vector3 reference2 = ref fstScales[0];
						reference2 = Vector3.one;
						continue;
					}
					float[] array = dists;
					int num2 = RuntimeServices.NormalizeArrayIndex(array, num);
					float[] array2 = dists;
					float num3 = array2[RuntimeServices.NormalizeArrayIndex(array2, num - 1)];
					Transform[] array3 = transforms;
					Vector3 position = array3[RuntimeServices.NormalizeArrayIndex(array3, num)].position;
					Transform[] array4 = transforms;
					array[num2] = num3 + (position - array4[RuntimeServices.NormalizeArrayIndex(array4, num - 1)].position).magnitude;
					Quaternion[] array5 = fstRots;
					ref Quaternion reference3 = ref array5[RuntimeServices.NormalizeArrayIndex(array5, num)];
					Transform[] array6 = transforms;
					reference3 = quaternion * array6[RuntimeServices.NormalizeArrayIndex(array6, num)].rotation;
					Vector3[] array7 = fstScales;
					ref Vector3 reference4 = ref array7[RuntimeServices.NormalizeArrayIndex(array7, num)];
					Transform[] array8 = transforms;
					reference4 = array8[RuntimeServices.NormalizeArrayIndex(array8, num)].localScale;
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			IEnumerator<int> enumerator2 = Builtins.range(step).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					num = enumerator2.Current;
					Vector3[] array9 = poss;
					ref Vector3 reference5 = ref array9[RuntimeServices.NormalizeArrayIndex(array9, num)];
					reference5 = transforms[0].transform.position;
					Quaternion[] array10 = rots;
					ref Quaternion reference6 = ref array10[RuntimeServices.NormalizeArrayIndex(array10, num)];
					reference6 = transforms[0].transform.rotation;
					Vector3[] array11 = scales;
					ref Vector3 reference7 = ref array11[RuntimeServices.NormalizeArrayIndex(array11, num)];
					reference7 = transforms[0].transform.localScale;
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
		Vector3 position = transforms[0].position;
		Quaternion rotation = transforms[0].rotation;
		Vector3 localScale = transforms[0].localScale;
		Vector3[] array = poss;
		float magnitude = (position - array[RuntimeServices.NormalizeArrayIndex(array, pt)]).magnitude;
		float num = default(float);
		int num2 = default(int);
		IEnumerator<int> enumerator = Builtins.range(100).GetEnumerator();
		checked
		{
			try
			{
				while (enumerator.MoveNext())
				{
					num2 = enumerator.Current;
					if (!(magnitude < stepLength))
					{
						int index = pt;
						pt++;
						if (pt >= step)
						{
							pt = 0;
						}
						num = stepLength / magnitude;
						Vector3[] array2 = poss;
						ref Vector3 reference = ref array2[RuntimeServices.NormalizeArrayIndex(array2, pt)];
						Vector3[] array3 = poss;
						reference = Vector3.Lerp(array3[RuntimeServices.NormalizeArrayIndex(array3, index)], position, num);
						Quaternion[] array4 = rots;
						ref Quaternion reference2 = ref array4[RuntimeServices.NormalizeArrayIndex(array4, pt)];
						Quaternion[] array5 = rots;
						reference2 = Quaternion.Lerp(array5[RuntimeServices.NormalizeArrayIndex(array5, index)], rotation, num);
						Vector3[] array6 = scales;
						ref Vector3 reference3 = ref array6[RuntimeServices.NormalizeArrayIndex(array6, pt)];
						Vector3[] array7 = scales;
						reference3 = Vector3.Lerp(array7[RuntimeServices.NormalizeArrayIndex(array7, index)], localScale, num);
						Vector3[] array8 = poss;
						magnitude = (position - array8[RuntimeServices.NormalizeArrayIndex(array8, pt)]).magnitude;
					}
					else
					{
						num2 = 100;
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			IEnumerator<int> enumerator2 = Builtins.range(1, this.num).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					num2 = enumerator2.Current;
					Transform[] array9 = transforms;
					Vector3 localScale2 = array9[RuntimeServices.NormalizeArrayIndex(array9, num2)].localScale;
					float num3 = localScale2.x * localScale2.y * localScale2.z;
					float[] array10 = dists;
					float num4 = (array10[RuntimeServices.NormalizeArrayIndex(array10, num2)] - magnitude) / stepLength;
					if (!(num4 >= 0f))
					{
						Transform[] array11 = transforms;
						Transform obj = array11[RuntimeServices.NormalizeArrayIndex(array11, num2)];
						Vector3[] array12 = poss;
						obj.position = Vector3.Lerp(array12[RuntimeServices.NormalizeArrayIndex(array12, pt)], position, 0f - num4);
						Transform[] array13 = transforms;
						Transform obj2 = array13[RuntimeServices.NormalizeArrayIndex(array13, num2)];
						Quaternion[] array14 = rots;
						obj2.rotation = Quaternion.Lerp(array14[RuntimeServices.NormalizeArrayIndex(array14, pt)], rotation, 0f - num4);
						Transform[] array15 = transforms;
						Transform obj3 = array15[RuntimeServices.NormalizeArrayIndex(array15, num2)];
						Vector3[] array16 = scales;
						obj3.localScale = Vector3.Lerp(array16[RuntimeServices.NormalizeArrayIndex(array16, pt)], localScale, 0f - num4);
						continue;
					}
					int num5 = Mathf.FloorToInt(num4);
					num = num4 - (float)num5;
					int num6 = pt - num5;
					if (num6 < 0)
					{
						num6 += step;
					}
					int num7 = num6 - 1;
					if (num7 < 0)
					{
						num7 += step;
					}
					Transform[] array17 = transforms;
					Transform obj4 = array17[RuntimeServices.NormalizeArrayIndex(array17, num2)];
					Vector3[] array18 = poss;
					Vector3 from = array18[RuntimeServices.NormalizeArrayIndex(array18, num6)];
					Vector3[] array19 = poss;
					obj4.position = Vector3.Lerp(from, array19[RuntimeServices.NormalizeArrayIndex(array19, num7)], num);
					Transform[] array20 = transforms;
					Transform obj5 = array20[RuntimeServices.NormalizeArrayIndex(array20, num2)];
					Quaternion[] array21 = rots;
					Quaternion from2 = array21[RuntimeServices.NormalizeArrayIndex(array21, num6)];
					Quaternion[] array22 = rots;
					Quaternion quaternion = Quaternion.Lerp(from2, array22[RuntimeServices.NormalizeArrayIndex(array22, num7)], num);
					Quaternion[] array23 = fstRots;
					obj5.rotation = quaternion * array23[RuntimeServices.NormalizeArrayIndex(array23, num2)];
					Vector3[] array24 = scales;
					Vector3 from3 = array24[RuntimeServices.NormalizeArrayIndex(array24, num6)];
					Vector3[] array25 = scales;
					Vector3 localScale3 = Vector3.Lerp(from3, array25[RuntimeServices.NormalizeArrayIndex(array25, num7)], num);
					Vector3[] array26 = fstScales;
					Vector3 vector = array26[RuntimeServices.NormalizeArrayIndex(array26, num2)];
					localScale3.x *= vector.x;
					localScale3.y *= vector.y;
					localScale3.z *= vector.z;
					Transform[] array27 = transforms;
					array27[RuntimeServices.NormalizeArrayIndex(array27, num2)].localScale = localScale3;
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
		}
	}
}
