using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_GroundFollowMulti : Ef_GroundHeight
{
	public Transform[] transforms;

	public float upLength;

	public bool pickChild;

	public string childName;

	public bool infinitieFall;

	public float infinitieHeight;

	private int leng;

	private Vector3[] basePoss;

	private Quaternion[] fstRots;

	private Vector3 lstPos;

	private Quaternion lstRot;

	private Vector3 lstSiz;

	public Ef_GroundFollowMulti()
	{
		transforms = new Transform[0];
		upLength = 0.1f;
		childName = "b";
		infinitieFall = true;
		infinitieHeight = -100f;
		lstPos = Vector3.zero;
		lstRot = Quaternion.identity;
		lstSiz = Vector3.one;
	}

	public override void Start()
	{
		base.Start();
		int num = default(int);
		int num2 = 0;
		string text = null;
		if (pickChild)
		{
			IEnumerator<int> enumerator = Builtins.range(100).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					num = enumerator.Current;
					text = childName;
					if (num < 10)
					{
						text += "0";
					}
					text += num;
					if ((bool)transform.Find(text))
					{
						num2 = checked(num2 + 1);
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			transforms = new Transform[num2];
			IEnumerator<int> enumerator2 = Builtins.range(num2).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					num = enumerator2.Current;
					text = childName;
					if (num < 10)
					{
						text += "0";
					}
					text += num;
					Transform[] array = transforms;
					array[RuntimeServices.NormalizeArrayIndex(array, num)] = transform.Find(text);
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
			bool flag = false;
		}
		leng = transforms.Length;
		basePoss = new Vector3[leng];
		fstRots = new Quaternion[leng];
		IEnumerator<int> enumerator3 = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				num = enumerator3.Current;
				Transform[] array2 = transforms;
				if ((bool)array2[RuntimeServices.NormalizeArrayIndex(array2, num)])
				{
					Vector3[] array3 = basePoss;
					ref Vector3 reference = ref array3[RuntimeServices.NormalizeArrayIndex(array3, num)];
					Transform[] array4 = transforms;
					reference = array4[RuntimeServices.NormalizeArrayIndex(array4, num)].localPosition;
					Quaternion[] array5 = fstRots;
					ref Quaternion reference2 = ref array5[RuntimeServices.NormalizeArrayIndex(array5, num)];
					Quaternion quaternion = Quaternion.Inverse(transform.rotation);
					Transform[] array6 = transforms;
					reference2 = quaternion * array6[RuntimeServices.NormalizeArrayIndex(array6, num)].rotation;
				}
			}
		}
		finally
		{
			enumerator3.Dispose();
		}
	}

	public void Update()
	{
		if (!(transform.position != lstPos) && !(transform.rotation != lstRot) && !(transform.localScale != lstSiz))
		{
			return;
		}
		Vector3 position = transform.position;
		Quaternion rotation = transform.rotation;
		Vector3 localScale = transform.localScale;
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
					Vector3 vector = position;
					Vector3[] array2 = basePoss;
					object[] groundHeight = GetGroundHeight(vector + rotation * array2[RuntimeServices.NormalizeArrayIndex(array2, num)] * localScale.x);
					bool flag = RuntimeServices.UnboxBoolean(groundHeight[0]);
					float num2 = RuntimeServices.UnboxSingle(groundHeight[1]);
					Vector3 toDirection = (Vector3)groundHeight[2];
					if (flag)
					{
						num2 += upLength;
					}
					else if (infinitieFall)
					{
						num2 = infinitieHeight + upLength;
					}
					float y = (num2 - position.y) / localScale.y;
					Transform[] array3 = transforms;
					Vector3 localPosition = array3[RuntimeServices.NormalizeArrayIndex(array3, num)].localPosition;
					float num3 = (localPosition.y = y);
					Transform[] array4 = transforms;
					Vector3 vector3 = (array4[RuntimeServices.NormalizeArrayIndex(array4, num)].localPosition = localPosition);
					Transform[] array5 = transforms;
					Transform obj = array5[RuntimeServices.NormalizeArrayIndex(array5, num)];
					Quaternion quaternion = Quaternion.FromToRotation(Vector3.up, toDirection) * rotation;
					Quaternion[] array6 = fstRots;
					obj.rotation = quaternion * array6[RuntimeServices.NormalizeArrayIndex(array6, num)];
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		lstPos = transform.position;
		lstRot = transform.rotation;
		lstSiz = transform.localScale;
	}
}
