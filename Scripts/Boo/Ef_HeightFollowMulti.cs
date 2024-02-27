using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_HeightFollowMulti : MonoBehaviour
{
	public Transform[] transforms;

	public float upLength;

	public bool everyFrame;

	public float slopeUp;

	public bool onStart;

	private int leng;

	private Vector3[] basePoss;

	private Quaternion[] fstRots;

	private Vector3 lstPos;

	private Quaternion lstRot;

	private Vector3 lstSiz;

	private bool oneshot;

	private Ef_HeightBuffer hBuf;

	public Ef_HeightFollowMulti()
	{
		transforms = new Transform[0];
		upLength = 0.1f;
		slopeUp = 0.5f;
		lstPos = new Vector3(0f, 0f, 0.0001f);
		lstRot = Quaternion.identity;
		lstSiz = Vector3.one;
		oneshot = true;
	}

	public void Start()
	{
		hBuf = Ef_HeightBuffer.Current;
		if (hBuf == null)
		{
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		int num = default(int);
		int num2 = 0;
		leng = transforms.Length;
		basePoss = new Vector3[leng];
		fstRots = new Quaternion[leng];
		IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Transform[] array = transforms;
				if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, num)])
				{
					Vector3[] array2 = basePoss;
					ref Vector3 reference = ref array2[RuntimeServices.NormalizeArrayIndex(array2, num)];
					Transform[] array3 = transforms;
					reference = array3[RuntimeServices.NormalizeArrayIndex(array3, num)].localPosition;
					Quaternion[] array4 = fstRots;
					ref Quaternion reference2 = ref array4[RuntimeServices.NormalizeArrayIndex(array4, num)];
					Quaternion quaternion = Quaternion.Inverse(transform.rotation);
					Transform[] array5 = transforms;
					reference2 = quaternion * array5[RuntimeServices.NormalizeArrayIndex(array5, num)].rotation;
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		if (onStart)
		{
			Follow();
			oneshot = false;
		}
	}

	public void Update()
	{
		if (everyFrame || oneshot)
		{
			Follow();
			oneshot = false;
		}
	}

	public void Follow()
	{
		if (hBuf == null)
		{
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		Vector3 position = transform.position;
		Quaternion rotation = transform.rotation;
		Vector3 localScale = transform.localScale;
		if (!(position != lstPos) && !(rotation != lstRot) && !(localScale != lstSiz))
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
				Transform[] array = transforms;
				if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, num)])
				{
					Ef_HeightBuffer ef_HeightBuffer = hBuf;
					Vector3 vector = position;
					Vector3[] array2 = basePoss;
					object[] height = ef_HeightBuffer.GetHeight(vector + rotation * array2[RuntimeServices.NormalizeArrayIndex(array2, num)] * localScale.x);
					float num2 = RuntimeServices.UnboxSingle(height[0]);
					Vector3 vector2 = (Vector3)height[1];
					num2 += upLength;
					if (!(slopeUp <= 0f))
					{
						num2 += Vector3.Angle(vector2, Vector3.up) / 90f * slopeUp;
					}
					float y = (num2 - position.y) / localScale.y;
					Transform[] array3 = transforms;
					Vector3 localPosition = array3[RuntimeServices.NormalizeArrayIndex(array3, num)].localPosition;
					float num3 = (localPosition.y = y);
					Transform[] array4 = transforms;
					Vector3 vector4 = (array4[RuntimeServices.NormalizeArrayIndex(array4, num)].localPosition = localPosition);
					Transform[] array5 = transforms;
					Transform obj = array5[RuntimeServices.NormalizeArrayIndex(array5, num)];
					Quaternion quaternion = Quaternion.FromToRotation(Vector3.up, vector2) * rotation;
					Quaternion[] array6 = fstRots;
					obj.rotation = quaternion * array6[RuntimeServices.NormalizeArrayIndex(array6, num)];
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		lstPos = position;
		lstRot = rotation;
		lstSiz = localScale;
	}
}
