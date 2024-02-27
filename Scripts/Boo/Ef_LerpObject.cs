using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_LerpObject : Ef_Base
{
	public Transform[] LerpObjs;

	public float[] speeds;

	public bool scale;

	private Vector3[] poss;

	private Quaternion[] rots;

	private Vector3[] scales;

	private Vector3[] fstPoss;

	private Quaternion[] fstRots;

	private int leng;

	public Ef_LerpObject()
	{
		LerpObjs = new Transform[0];
		speeds = new float[0];
	}

	public void Start()
	{
		leng = LerpObjs.Length;
		poss = new Vector3[leng];
		rots = new Quaternion[leng];
		if (scale)
		{
			scales = new Vector3[leng];
		}
		fstPoss = new Vector3[leng];
		fstRots = new Quaternion[leng];
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
			Vector3[] array = poss;
			ref Vector3 reference = ref array[RuntimeServices.NormalizeArrayIndex(array, index)];
			Transform[] lerpObjs = LerpObjs;
			reference = lerpObjs[RuntimeServices.NormalizeArrayIndex(lerpObjs, index)].position;
			Quaternion[] array2 = rots;
			ref Quaternion reference2 = ref array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
			Transform[] lerpObjs2 = LerpObjs;
			reference2 = lerpObjs2[RuntimeServices.NormalizeArrayIndex(lerpObjs2, index)].rotation;
			if (scale)
			{
				Vector3[] array3 = scales;
				ref Vector3 reference3 = ref array3[RuntimeServices.NormalizeArrayIndex(array3, index)];
				Transform[] lerpObjs3 = LerpObjs;
				reference3 = lerpObjs3[RuntimeServices.NormalizeArrayIndex(lerpObjs3, index)].localScale;
			}
			Vector3[] array4 = fstPoss;
			ref Vector3 reference4 = ref array4[RuntimeServices.NormalizeArrayIndex(array4, index)];
			Transform[] lerpObjs4 = LerpObjs;
			reference4 = lerpObjs4[RuntimeServices.NormalizeArrayIndex(lerpObjs4, index)].localPosition;
			Quaternion[] array5 = fstRots;
			ref Quaternion reference5 = ref array5[RuntimeServices.NormalizeArrayIndex(array5, index)];
			Transform[] lerpObjs5 = LerpObjs;
			reference5 = lerpObjs5[RuntimeServices.NormalizeArrayIndex(lerpObjs5, index)].localRotation;
			if (scale)
			{
				Transform[] lerpObjs6 = LerpObjs;
				Vector3 localScale = lerpObjs6[RuntimeServices.NormalizeArrayIndex(lerpObjs6, index)].localScale;
			}
		}
	}

	public void Update()
	{
		int num = 0;
		int num2 = leng;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			Transform[] lerpObjs = LerpObjs;
			Transform obj = lerpObjs[RuntimeServices.NormalizeArrayIndex(lerpObjs, num3)];
			Vector3[] array = poss;
			obj.position = array[RuntimeServices.NormalizeArrayIndex(array, num3)];
			Transform[] lerpObjs2 = LerpObjs;
			Transform obj2 = lerpObjs2[RuntimeServices.NormalizeArrayIndex(lerpObjs2, num3)];
			Quaternion[] array2 = rots;
			obj2.rotation = array2[RuntimeServices.NormalizeArrayIndex(array2, num3)];
			if (scale)
			{
				Transform[] lerpObjs3 = LerpObjs;
				Transform obj3 = lerpObjs3[RuntimeServices.NormalizeArrayIndex(lerpObjs3, num3)];
				Vector3[] array3 = scales;
				obj3.localScale = array3[RuntimeServices.NormalizeArrayIndex(array3, num3)];
			}
			float num4 = default(float);
			int length = speeds.Length;
			checked
			{
				if (length - 1 < num3)
				{
					if (length > 0)
					{
						float[] array4 = speeds;
						num4 = array4[RuntimeServices.NormalizeArrayIndex(array4, length - 1)];
					}
					else
					{
						num4 = 10f;
					}
				}
				else
				{
					float[] array5 = speeds;
					num4 = array5[RuntimeServices.NormalizeArrayIndex(array5, num3)];
				}
				float t = num4 * deltaTime;
				Transform[] lerpObjs4 = LerpObjs;
				Transform obj4 = lerpObjs4[RuntimeServices.NormalizeArrayIndex(lerpObjs4, num3)];
				Transform[] lerpObjs5 = LerpObjs;
				Vector3 localPosition = lerpObjs5[RuntimeServices.NormalizeArrayIndex(lerpObjs5, num3)].localPosition;
				Vector3[] array6 = fstPoss;
				obj4.localPosition = Vector3.Lerp(localPosition, array6[RuntimeServices.NormalizeArrayIndex(array6, num3)], t);
				Transform[] lerpObjs6 = LerpObjs;
				Transform obj5 = lerpObjs6[RuntimeServices.NormalizeArrayIndex(lerpObjs6, num3)];
				Transform[] lerpObjs7 = LerpObjs;
				Quaternion localRotation = lerpObjs7[RuntimeServices.NormalizeArrayIndex(lerpObjs7, num3)].localRotation;
				Quaternion[] array7 = fstRots;
				obj5.localRotation = Quaternion.Lerp(localRotation, array7[RuntimeServices.NormalizeArrayIndex(array7, num3)], t);
				if (scale)
				{
					Transform[] lerpObjs8 = LerpObjs;
					if ((bool)lerpObjs8[RuntimeServices.NormalizeArrayIndex(lerpObjs8, num3)].parent)
					{
						Transform[] lerpObjs9 = LerpObjs;
						Transform obj6 = lerpObjs9[RuntimeServices.NormalizeArrayIndex(lerpObjs9, num3)];
						Transform[] lerpObjs10 = LerpObjs;
						Vector3 localScale = lerpObjs10[RuntimeServices.NormalizeArrayIndex(lerpObjs10, num3)].localScale;
						Transform[] lerpObjs11 = LerpObjs;
						obj6.localScale = Vector3.Lerp(localScale, lerpObjs11[RuntimeServices.NormalizeArrayIndex(lerpObjs11, num3)].parent.localScale, t);
					}
				}
				Vector3[] array8 = poss;
				ref Vector3 reference = ref array8[RuntimeServices.NormalizeArrayIndex(array8, num3)];
				Transform[] lerpObjs12 = LerpObjs;
				reference = lerpObjs12[RuntimeServices.NormalizeArrayIndex(lerpObjs12, num3)].position;
				Quaternion[] array9 = rots;
				ref Quaternion reference2 = ref array9[RuntimeServices.NormalizeArrayIndex(array9, num3)];
				Transform[] lerpObjs13 = LerpObjs;
				reference2 = lerpObjs13[RuntimeServices.NormalizeArrayIndex(lerpObjs13, num3)].rotation;
			}
		}
	}
}
