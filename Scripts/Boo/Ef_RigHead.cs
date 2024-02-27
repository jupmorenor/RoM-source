using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_RigHead : MonoBehaviour
{
	public Transform lookTarget;

	public Transform rotTarget;

	public Transform[] arrTfs;

	public float[] arrBendRates;

	public int numTf;

	public Transform parentTf;

	public Vector3 parentUpVec;

	public Quaternion[] arrBindRots;

	public Quaternion fstInvParRot;

	public bool onLateUpdate;

	public Ef_RigHead()
	{
		onLateUpdate = true;
	}

	public void Start()
	{
		Ef_RigEdit component = gameObject.GetComponent<Ef_RigEdit>();
		if ((bool)component)
		{
			UnityEngine.Object.Destroy(component);
		}
	}

	public void Initialize()
	{
		numTf = arrTfs.Length;
		fstInvParRot = Quaternion.Inverse(parentTf.rotation);
		arrBindRots = new Quaternion[numTf];
		int num = 0;
		int num2 = numTf;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			Quaternion[] array = arrBindRots;
			ref Quaternion reference = ref array[RuntimeServices.NormalizeArrayIndex(array, index)];
			Transform[] array2 = arrTfs;
			reference = array2[RuntimeServices.NormalizeArrayIndex(array2, index)].rotation;
		}
		parentTf = arrTfs[0].parent;
		parentUpVec = fstInvParRot * Vector3.up;
		if (arrBendRates.Length != numTf)
		{
			arrBendRates = new float[numTf];
			int num3 = 0;
			int num4 = numTf;
			if (num4 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num3 < num4)
			{
				int num5 = num3;
				num3++;
				float[] array3 = arrBendRates;
				array3[RuntimeServices.NormalizeArrayIndex(array3, num5)] = 1f / (float)numTf * (float)checked(num5 + 1);
			}
		}
	}

	public void Update()
	{
		if (!onLateUpdate)
		{
			if ((bool)lookTarget)
			{
				UpdateLook();
			}
			else if ((bool)rotTarget)
			{
				UpdateRot();
			}
		}
	}

	public void LateUpdate()
	{
		if (onLateUpdate)
		{
			if ((bool)lookTarget)
			{
				UpdateLook();
			}
			else if ((bool)rotTarget)
			{
				UpdateRot();
			}
		}
	}

	public void UpdateLook()
	{
		Vector3 forward = lookTarget.position - arrTfs[0].position;
		Quaternion from = parentTf.rotation * fstInvParRot;
		Vector3 vector = default(Vector3);
		vector = ((!rotTarget) ? (parentTf.rotation * parentUpVec) : (parentTf.rotation * rotTarget.localRotation * parentUpVec));
		Quaternion to = Quaternion.LookRotation(forward, vector);
		int num = 0;
		int num2 = numTf;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			Transform[] array = arrTfs;
			Transform obj = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			float[] array2 = arrBendRates;
			Quaternion quaternion = Quaternion.Lerp(from, to, array2[RuntimeServices.NormalizeArrayIndex(array2, index)]);
			Quaternion[] array3 = arrBindRots;
			obj.rotation = quaternion * array3[RuntimeServices.NormalizeArrayIndex(array3, index)];
		}
	}

	public void UpdateRot()
	{
		Quaternion from = parentTf.rotation * fstInvParRot;
		Quaternion localRotation = rotTarget.localRotation;
		int num = 0;
		int num2 = numTf;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			Transform[] array = arrTfs;
			Transform obj = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			float[] array2 = arrBendRates;
			Quaternion quaternion = Quaternion.Lerp(from, localRotation, array2[RuntimeServices.NormalizeArrayIndex(array2, index)]);
			Quaternion[] array3 = arrBindRots;
			obj.rotation = quaternion * array3[RuntimeServices.NormalizeArrayIndex(array3, index)];
		}
	}
}
