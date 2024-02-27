using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_RigSpine : MonoBehaviour
{
	[Serializable]
	public enum BendMode
	{
		PosBend,
		RotTwist
	}

	public Transform topTarget;

	public Transform bendTarget;

	public BendMode bendMode;

	public Transform lookTarget;

	public Transform[] arrTfs;

	public int numTf;

	private int numTfm;

	public Transform parentTf;

	public Vector3[] arrVecs;

	public Quaternion[] arrBindRots;

	public Quaternion fstInvParRot;

	private Quaternion[] arrRots;

	public bool onLateUpdate;

	public Ef_RigSpine()
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
		numTfm = checked(numTf - 1);
		arrRots = new Quaternion[numTfm];
	}

	public void Initialize()
	{
		numTf = arrTfs.Length;
		numTfm = checked(numTf - 1);
		fstInvParRot = Quaternion.Inverse(parentTf.rotation);
		arrVecs = new Vector3[numTfm];
		arrBindRots = new Quaternion[numTfm];
		int num = 0;
		int num2 = numTfm;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			Vector3[] array = arrVecs;
			ref Vector3 reference = ref array[RuntimeServices.NormalizeArrayIndex(array, num3)];
			Transform[] array2 = arrTfs;
			Vector3 position = array2[RuntimeServices.NormalizeArrayIndex(array2, checked(num3 + 1))].position;
			Transform[] array3 = arrTfs;
			reference = position - array3[RuntimeServices.NormalizeArrayIndex(array3, num3)].position;
			Quaternion[] array4 = arrBindRots;
			ref Quaternion reference2 = ref array4[RuntimeServices.NormalizeArrayIndex(array4, num3)];
			Transform[] array5 = arrTfs;
			reference2 = array5[RuntimeServices.NormalizeArrayIndex(array5, num3)].rotation;
		}
		parentTf = arrTfs[0].parent;
	}

	public void Update()
	{
		if (!onLateUpdate && (bool)topTarget && (bool)bendTarget)
		{
			UpdateIK();
		}
	}

	public void LateUpdate()
	{
		if (onLateUpdate && (bool)topTarget && (bool)bendTarget)
		{
			UpdateIK();
		}
	}

	public void UpdateIK()
	{
		Vector3 position = arrTfs[0].position;
		Vector3 toDirection = topTarget.position - position;
		Vector3 localPosition = bendTarget.localPosition;
		Quaternion quaternion = fstInvParRot * parentTf.rotation;
		Quaternion quaternion2 = default(Quaternion);
		if (bendMode == BendMode.PosBend)
		{
			float x = localPosition[2] * -10f;
			float z = localPosition[0] * 10f;
			float num = default(float);
			if ((bool)lookTarget)
			{
				Vector3 vector = Quaternion.Inverse(quaternion) * (lookTarget.position - position);
				num = PosToAng(vector[2], vector[0]) / (float)numTf;
			}
			else
			{
				num = localPosition[1] * 10f;
			}
			quaternion2 = Quaternion.Euler(x, num, z);
		}
		else
		{
			quaternion2 = Quaternion.Lerp(Quaternion.identity, Quaternion.Inverse(quaternion) * bendTarget.localRotation, 1f / (float)numTf);
		}
		Vector3 vector2 = Vector3.zero;
		int num2 = 0;
		int num3 = numTfm;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int index = num2;
			num2++;
			quaternion *= quaternion2;
			Vector3 vector3 = vector2;
			Quaternion quaternion3 = quaternion;
			Vector3[] array = arrVecs;
			vector2 = vector3 + quaternion3 * array[RuntimeServices.NormalizeArrayIndex(array, index)];
			Quaternion[] array2 = arrRots;
			ref Quaternion reference = ref array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
			Quaternion quaternion4 = quaternion;
			Quaternion[] array3 = arrBindRots;
			reference = quaternion4 * array3[RuntimeServices.NormalizeArrayIndex(array3, index)];
		}
		Quaternion quaternion5 = Quaternion.FromToRotation(vector2, toDirection);
		int num4 = 0;
		int num5 = numTfm;
		if (num5 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num4 < num5)
		{
			int index2 = num4;
			num4++;
			Quaternion[] array4 = arrRots;
			ref Quaternion reference2 = ref array4[RuntimeServices.NormalizeArrayIndex(array4, index2)];
			Quaternion[] array5 = arrRots;
			reference2 = quaternion5 * array5[RuntimeServices.NormalizeArrayIndex(array5, index2)];
			Transform[] array6 = arrTfs;
			Transform obj = array6[RuntimeServices.NormalizeArrayIndex(array6, index2)];
			Quaternion[] array7 = arrRots;
			obj.rotation = array7[RuntimeServices.NormalizeArrayIndex(array7, index2)];
		}
	}

	public float PosToAng(float z, float x)
	{
		float num = 57.29578f;
		float num2 = 0f;
		if (!(Mathf.Abs(z) <= Mathf.Abs(x)))
		{
			if (!(z >= 0f))
			{
				num2 = Mathf.Atan(x / z) * num + 180f;
				if (!(num2 <= 180f))
				{
					num2 -= 360f;
				}
			}
			else if (!(z <= 0f))
			{
				num2 = Mathf.Atan(x / z) * num;
			}
		}
		else if (!(x >= 0f))
		{
			num2 = (0f - Mathf.Atan(z / x)) * num - 90f;
		}
		else if (!(x <= 0f))
		{
			num2 = (0f - Mathf.Atan(z / x)) * num + 90f;
		}
		return num2;
	}
}
