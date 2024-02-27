using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_Swing : MonoBehaviour
{
	[Serializable]
	public enum Axis
	{
		X,
		Y,
		Z,
		Xm,
		Ym,
		Zm
	}

	[Serializable]
	public enum Mode
	{
		PosAndRot,
		PosOnly,
		RotOnly
	}

	public Transform[] arrTransform;

	public Axis[] arrAxis;

	public Transform scaleObj;

	public float tension;

	public float[] arrRotPower;

	public int brake;

	public float maxSwing;

	public float gravity;

	public Mode mode;

	public int numOf;

	public Transform[] arrParent;

	public Vector3[] arrBasePos;

	public Quaternion[] arrBaseRot;

	public Vector3[] arrPointPos;

	public Transform[] arrCollisionObj;

	public float[] arrCollisionRadius;

	public Transform planeObj;

	private Vector3[] vels;

	private Vector3[] ptVels;

	private Vector3[] poss;

	private Vector3[] ptPoss;

	private Quaternion[] rots;

	private int numColli;

	private float[] arrSqrColliRad;

	private bool ready;

	public bool viewPointObj;

	private Transform[] testPts;

	public Ef_Swing()
	{
		arrTransform = new Transform[1];
		arrAxis = new Axis[1];
		tension = 8f;
		brake = 10;
		maxSwing = 1f;
		mode = Mode.PosAndRot;
	}

	public void Start()
	{
		if (arrParent.Length < numOf || arrBasePos.Length < numOf || arrBaseRot.Length < numOf || arrPointPos.Length < numOf)
		{
			return;
		}
		Ef_SwingEdit component = gameObject.GetComponent<Ef_SwingEdit>();
		if ((bool)component)
		{
			UnityEngine.Object.Destroy(component);
		}
		int length = arrAxis.Length;
		if (length < numOf)
		{
			Axis[] array = new Axis[numOf];
			int num = 0;
			int num2 = length;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int index = num;
				num++;
				int num3 = RuntimeServices.NormalizeArrayIndex(array, index);
				Axis[] array2 = arrAxis;
				array[num3] = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
			}
			int num4 = length;
			int num5 = numOf;
			int num6 = 1;
			if (num5 < num4)
			{
				num6 = -1;
			}
			while (num4 != num5)
			{
				int index2 = num4;
				num4 += num6;
				array[RuntimeServices.NormalizeArrayIndex(array, index2)] = array[RuntimeServices.NormalizeArrayIndex(array, checked(length - 1))];
			}
			arrAxis = array;
		}
		vels = new Vector3[numOf];
		ptVels = new Vector3[numOf];
		poss = new Vector3[numOf];
		rots = new Quaternion[numOf];
		ptPoss = new Vector3[numOf];
		if (viewPointObj)
		{
			testPts = new Transform[numOf];
		}
		int num7 = 0;
		int num8 = numOf;
		if (num8 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num7 < num8)
		{
			int index3 = num7;
			num7++;
			Transform[] array3 = arrTransform;
			if ((bool)array3[RuntimeServices.NormalizeArrayIndex(array3, index3)])
			{
				Vector3[] array4 = vels;
				ref Vector3 reference = ref array4[RuntimeServices.NormalizeArrayIndex(array4, index3)];
				reference = Vector3.zero;
				Vector3[] array5 = ptVels;
				ref Vector3 reference2 = ref array5[RuntimeServices.NormalizeArrayIndex(array5, index3)];
				reference2 = Vector3.zero;
				Vector3[] array6 = poss;
				ref Vector3 reference3 = ref array6[RuntimeServices.NormalizeArrayIndex(array6, index3)];
				Transform[] array7 = arrTransform;
				reference3 = array7[RuntimeServices.NormalizeArrayIndex(array7, index3)].position;
				Quaternion[] array8 = rots;
				ref Quaternion reference4 = ref array8[RuntimeServices.NormalizeArrayIndex(array8, index3)];
				Transform[] array9 = arrTransform;
				reference4 = array9[RuntimeServices.NormalizeArrayIndex(array9, index3)].rotation;
				Vector3[] array10 = ptPoss;
				ref Vector3 reference5 = ref array10[RuntimeServices.NormalizeArrayIndex(array10, index3)];
				Transform[] array11 = arrParent;
				Vector3 position = array11[RuntimeServices.NormalizeArrayIndex(array11, index3)].position;
				Transform[] array12 = arrParent;
				Quaternion rotation = array12[RuntimeServices.NormalizeArrayIndex(array12, index3)].rotation;
				Vector3[] array13 = arrPointPos;
				reference5 = position + rotation * array13[RuntimeServices.NormalizeArrayIndex(array13, index3)];
				if (viewPointObj)
				{
					Transform[] array14 = testPts;
					array14[RuntimeServices.NormalizeArrayIndex(array14, index3)] = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
					Transform[] array15 = testPts;
					array15[RuntimeServices.NormalizeArrayIndex(array15, index3)].localScale = new Vector3(0.3f, 0.3f, 0.3f);
				}
			}
		}
		int length2 = arrRotPower.Length;
		if (length2 < numOf)
		{
			float[] array16 = new float[numOf];
			int num9 = 0;
			int num10 = length2;
			if (num10 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num9 < num10)
			{
				int index4 = num9;
				num9++;
				int num11 = RuntimeServices.NormalizeArrayIndex(array16, index4);
				float[] array17 = arrRotPower;
				array16[num11] = array17[RuntimeServices.NormalizeArrayIndex(array17, index4)];
			}
			int num12 = length2;
			int num13 = numOf;
			int num14 = 1;
			if (num13 < num12)
			{
				num14 = -1;
			}
			while (num12 != num13)
			{
				int index5 = num12;
				num12 += num14;
				array16[RuntimeServices.NormalizeArrayIndex(array16, index5)] = array16[RuntimeServices.NormalizeArrayIndex(array16, checked(length2 - 1))];
			}
			arrRotPower = array16;
		}
		numColli = arrCollisionObj.Length;
		int length3 = arrCollisionRadius.Length;
		if (length3 < numColli)
		{
			float[] array18 = new float[numColli];
			int num15 = 0;
			int num16 = length3;
			if (num16 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num15 < num16)
			{
				int index6 = num15;
				num15++;
				int num17 = RuntimeServices.NormalizeArrayIndex(array18, index6);
				float[] array19 = arrCollisionRadius;
				array18[num17] = array19[RuntimeServices.NormalizeArrayIndex(array19, index6)];
			}
			int num18 = length3;
			int num19 = numColli;
			int num20 = 1;
			if (num19 < num18)
			{
				num20 = -1;
			}
			while (num18 != num19)
			{
				int index7 = num18;
				num18 += num20;
				array18[RuntimeServices.NormalizeArrayIndex(array18, index7)] = array18[RuntimeServices.NormalizeArrayIndex(array18, checked(length3 - 1))];
			}
			arrCollisionRadius = array18;
		}
		arrSqrColliRad = new float[numColli];
		int num21 = 0;
		int num22 = numColli;
		if (num22 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num21 < num22)
		{
			int index8 = num21;
			num21++;
			float[] array20 = arrSqrColliRad;
			int num23 = RuntimeServices.NormalizeArrayIndex(array20, index8);
			float[] array21 = arrCollisionRadius;
			float num24 = array21[RuntimeServices.NormalizeArrayIndex(array21, index8)];
			float[] array22 = arrCollisionRadius;
			array20[num23] = num24 * array22[RuntimeServices.NormalizeArrayIndex(array22, index8)];
		}
		ready = true;
	}

	public void Initialize()
	{
		numOf = arrTransform.Length;
		arrBasePos = new Vector3[numOf];
		arrBaseRot = new Quaternion[numOf];
		arrPointPos = new Vector3[numOf];
		arrParent = new Transform[numOf];
		int num = 0;
		int num2 = numOf;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			Transform[] array = arrTransform;
			if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, index)])
			{
				Transform[] array2 = arrParent;
				int num3 = RuntimeServices.NormalizeArrayIndex(array2, index);
				Transform[] array3 = arrTransform;
				array2[num3] = array3[RuntimeServices.NormalizeArrayIndex(array3, index)].parent;
				Transform[] array4 = arrParent;
				if (array4[RuntimeServices.NormalizeArrayIndex(array4, index)] == null)
				{
					break;
				}
				Vector3[] array5 = arrBasePos;
				ref Vector3 reference = ref array5[RuntimeServices.NormalizeArrayIndex(array5, index)];
				Transform[] array6 = arrTransform;
				reference = array6[RuntimeServices.NormalizeArrayIndex(array6, index)].localPosition;
				Quaternion[] array7 = arrBaseRot;
				ref Quaternion reference2 = ref array7[RuntimeServices.NormalizeArrayIndex(array7, index)];
				Transform[] array8 = arrTransform;
				reference2 = array8[RuntimeServices.NormalizeArrayIndex(array8, index)].localRotation;
				Transform[] array9 = arrTransform;
				int childCount = array9[RuntimeServices.NormalizeArrayIndex(array9, index)].childCount;
				Vector3 vector = Vector3.zero;
				int num4 = 0;
				int num5 = childCount;
				if (num5 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num4 < num5)
				{
					int index2 = num4;
					num4++;
					Vector3 vector2 = vector;
					Transform[] array10 = arrTransform;
					vector = vector2 + array10[RuntimeServices.NormalizeArrayIndex(array10, index)].GetChild(index2).localPosition;
				}
				if (childCount > 0)
				{
					vector /= (float)childCount;
				}
				if (vector == Vector3.zero)
				{
					vector = Vector3.forward;
				}
				Transform[] array11 = arrTransform;
				Vector3 position = array11[RuntimeServices.NormalizeArrayIndex(array11, index)].position;
				Transform[] array12 = arrTransform;
				Vector3 vector3 = position + array12[RuntimeServices.NormalizeArrayIndex(array12, index)].rotation * vector;
				Vector3[] array13 = arrPointPos;
				ref Vector3 reference3 = ref array13[RuntimeServices.NormalizeArrayIndex(array13, index)];
				Transform[] array14 = arrParent;
				Quaternion quaternion = Quaternion.Inverse(array14[RuntimeServices.NormalizeArrayIndex(array14, index)].rotation);
				Transform[] array15 = arrParent;
				reference3 = quaternion * (vector3 - array15[RuntimeServices.NormalizeArrayIndex(array15, index)].position);
			}
		}
	}

	public void AddForce(Transform tf, Vector3 vec, bool horizontal)
	{
		int num = 0;
		int num2 = numOf;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			Transform[] array = arrTransform;
			if (array[RuntimeServices.NormalizeArrayIndex(array, num3)] == tf)
			{
				AddForce(num3, vec, horizontal);
			}
		}
	}

	public void AddForce(int objNo, Vector3 vec, bool horizontal)
	{
		if (horizontal)
		{
			Transform[] array = arrTransform;
			Quaternion rotation = array[RuntimeServices.NormalizeArrayIndex(array, objNo)].rotation;
			vec = Quaternion.Inverse(rotation) * vec;
			Axis[] array2 = arrAxis;
			switch (array2[RuntimeServices.NormalizeArrayIndex(array2, objNo)])
			{
			case Axis.X:
			case Axis.Xm:
				vec.x = 0f;
				break;
			case Axis.Y:
			case Axis.Ym:
				vec.y = 0f;
				break;
			default:
				vec.z = 0f;
				break;
			}
			vec = rotation * vec;
		}
		Vector3[] array3 = ptVels;
		array3[RuntimeServices.NormalizeArrayIndex(array3, objNo)] = vec;
	}

	public void Update()
	{
		UpdateSwing();
	}

	public void UpdateSwing()
	{
		if (!ready)
		{
			return;
		}
		float deltaTime = Time.deltaTime;
		Vector3 b = Vector3.zero;
		bool flag = scaleObj;
		if (flag)
		{
			b = scaleObj.localScale;
		}
		float num = tension * deltaTime * 100f;
		float num2 = gravity * deltaTime * 10f;
		float num3 = 1f - (float)brake * deltaTime;
		if (!(num3 >= 0f))
		{
			num3 = 0f;
		}
		float num4 = maxSwing * maxSwing;
		Vector3 vector = default(Vector3);
		Vector3 vector2 = default(Vector3);
		bool flag2 = planeObj;
		float num5 = 0f;
		if (flag2)
		{
			num5 = planeObj.position.y;
		}
		int num6 = 0;
		int num7 = numOf;
		if (num7 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num6 < num7)
		{
			int index = num6;
			num6++;
			Transform[] array = arrTransform;
			if (!array[RuntimeServices.NormalizeArrayIndex(array, index)])
			{
				continue;
			}
			Transform[] array2 = arrParent;
			Transform transform = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
			bool flag3 = transform != null;
			Vector3 vector3 = default(Vector3);
			Quaternion quaternion = default(Quaternion);
			if (flag3)
			{
				vector3 = transform.position;
				quaternion = transform.rotation;
			}
			Vector3 vector4 = default(Vector3);
			Vector3 vector5 = default(Vector3);
			Quaternion quaternion2 = default(Quaternion);
			if (mode != Mode.RotOnly)
			{
				Vector3[] array3 = poss;
				Vector3 vector6 = array3[RuntimeServices.NormalizeArrayIndex(array3, index)];
				if (flag3)
				{
					if (flag)
					{
						Vector3 vector7 = vector3;
						Quaternion quaternion3 = quaternion;
						Vector3[] array4 = arrBasePos;
						vector5 = vector7 + quaternion3 * Vector3.Scale(array4[RuntimeServices.NormalizeArrayIndex(array4, index)], b);
					}
					else
					{
						Vector3 vector8 = vector3;
						Quaternion quaternion4 = quaternion;
						Vector3[] array5 = arrBasePos;
						vector5 = vector8 + quaternion4 * array5[RuntimeServices.NormalizeArrayIndex(array5, index)];
					}
					Quaternion quaternion5 = quaternion;
					Quaternion[] array6 = arrBaseRot;
					quaternion2 = quaternion5 * array6[RuntimeServices.NormalizeArrayIndex(array6, index)];
				}
				else
				{
					Vector3[] array7 = arrBasePos;
					vector5 = array7[RuntimeServices.NormalizeArrayIndex(array7, index)];
					Quaternion[] array8 = arrBaseRot;
					quaternion2 = array8[RuntimeServices.NormalizeArrayIndex(array8, index)];
				}
				vector4 = vector5 - vector6;
				if (vector4 != Vector3.zero && !(vector4.sqrMagnitude <= num4))
				{
					vector4 = vector4.normalized * maxSwing;
					vector6 = vector5 - vector4;
				}
				Vector3[] array9 = vels;
				ref Vector3 reference = ref array9[RuntimeServices.NormalizeArrayIndex(array9, index)];
				Vector3[] array10 = vels;
				reference = array10[RuntimeServices.NormalizeArrayIndex(array10, index)] + vector4 * num;
				Vector3[] array11 = vels;
				ref Vector3 reference2 = ref array11[RuntimeServices.NormalizeArrayIndex(array11, index)];
				Vector3[] array12 = vels;
				reference2.y = array12[RuntimeServices.NormalizeArrayIndex(array12, index)].y - num2;
				Vector3[] array13 = vels;
				ref Vector3 reference3 = ref array13[RuntimeServices.NormalizeArrayIndex(array13, index)];
				Vector3[] array14 = vels;
				reference3 = array14[RuntimeServices.NormalizeArrayIndex(array14, index)] * num3;
				Vector3[] array15 = vels;
				if (!(array15[RuntimeServices.NormalizeArrayIndex(array15, index)].sqrMagnitude >= 0.01f))
				{
					Vector3[] array16 = vels;
					ref Vector3 reference4 = ref array16[RuntimeServices.NormalizeArrayIndex(array16, index)];
					reference4 = Vector3.zero;
				}
				Vector3 vector9 = vector6;
				Vector3[] array17 = vels;
				vector6 = vector9 + array17[RuntimeServices.NormalizeArrayIndex(array17, index)] * deltaTime;
				int num8 = 0;
				int num9 = numColli;
				if (num9 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num8 < num9)
				{
					int index2 = num8;
					num8++;
					Transform[] array18 = arrCollisionObj;
					vector = array18[RuntimeServices.NormalizeArrayIndex(array18, index2)].position;
					vector2 = vector - vector6;
					float sqrMagnitude = vector4.sqrMagnitude;
					float[] array19 = arrSqrColliRad;
					if (!(sqrMagnitude >= array19[RuntimeServices.NormalizeArrayIndex(array19, index2)]))
					{
						Vector3 vector10 = vector;
						Vector3 normalized = vector2.normalized;
						float[] array20 = arrCollisionRadius;
						vector6 = vector10 - normalized * array20[RuntimeServices.NormalizeArrayIndex(array20, index2)];
					}
				}
				if (flag2 && !(vector6.y >= num5))
				{
					vector6.y = num5;
				}
				Transform[] array21 = arrTransform;
				array21[RuntimeServices.NormalizeArrayIndex(array21, index)].position = vector6;
				Vector3[] array22 = poss;
				array22[RuntimeServices.NormalizeArrayIndex(array22, index)] = vector6;
			}
			if (mode == Mode.PosOnly)
			{
				continue;
			}
			float[] array23 = arrRotPower;
			if (array23[RuntimeServices.NormalizeArrayIndex(array23, index)] <= 0f)
			{
				continue;
			}
			Vector3[] array24 = ptPoss;
			Vector3 vector11 = array24[RuntimeServices.NormalizeArrayIndex(array24, index)];
			if (flag3)
			{
				if (flag)
				{
					Vector3 vector12 = vector3;
					Quaternion quaternion6 = quaternion;
					Vector3[] array25 = arrPointPos;
					vector5 = vector12 + quaternion6 * Vector3.Scale(array25[RuntimeServices.NormalizeArrayIndex(array25, index)], b);
				}
				else
				{
					Vector3 vector13 = vector3;
					Quaternion quaternion7 = quaternion;
					Vector3[] array26 = arrPointPos;
					vector5 = vector13 + quaternion7 * array26[RuntimeServices.NormalizeArrayIndex(array26, index)];
				}
				Quaternion quaternion8 = quaternion;
				Quaternion[] array27 = arrBaseRot;
				quaternion2 = quaternion8 * array27[RuntimeServices.NormalizeArrayIndex(array27, index)];
			}
			else
			{
				Quaternion[] array28 = arrBaseRot;
				quaternion2 = array28[RuntimeServices.NormalizeArrayIndex(array28, index)];
			}
			vector4 = vector5 - vector11;
			if (vector4 != Vector3.zero && !(vector4.sqrMagnitude <= num4))
			{
				vector4 = vector4.normalized * maxSwing;
				vector11 = vector5 - vector4;
			}
			Vector3[] array29 = ptVels;
			ref Vector3 reference5 = ref array29[RuntimeServices.NormalizeArrayIndex(array29, index)];
			Vector3[] array30 = ptVels;
			reference5 = array30[RuntimeServices.NormalizeArrayIndex(array30, index)] + vector4 * num;
			Vector3[] array31 = ptVels;
			ref Vector3 reference6 = ref array31[RuntimeServices.NormalizeArrayIndex(array31, index)];
			Vector3[] array32 = ptVels;
			reference6.y = array32[RuntimeServices.NormalizeArrayIndex(array32, index)].y - num2;
			Vector3[] array33 = ptVels;
			ref Vector3 reference7 = ref array33[RuntimeServices.NormalizeArrayIndex(array33, index)];
			Vector3[] array34 = ptVels;
			reference7 = array34[RuntimeServices.NormalizeArrayIndex(array34, index)] * num3;
			Vector3[] array35 = ptVels;
			if (!(array35[RuntimeServices.NormalizeArrayIndex(array35, index)].sqrMagnitude >= 0.01f))
			{
				Vector3[] array36 = ptVels;
				ref Vector3 reference8 = ref array36[RuntimeServices.NormalizeArrayIndex(array36, index)];
				reference8 = Vector3.zero;
			}
			Vector3 vector14 = vector11;
			Vector3[] array37 = ptVels;
			vector11 = vector14 + array37[RuntimeServices.NormalizeArrayIndex(array37, index)] * deltaTime;
			int num10 = 0;
			int num11 = numColli;
			if (num11 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num10 < num11)
			{
				int index3 = num10;
				num10++;
				Transform[] array38 = arrCollisionObj;
				vector = array38[RuntimeServices.NormalizeArrayIndex(array38, index3)].position;
				vector2 = vector - vector11;
				float sqrMagnitude2 = vector2.sqrMagnitude;
				float[] array39 = arrSqrColliRad;
				if (!(sqrMagnitude2 >= array39[RuntimeServices.NormalizeArrayIndex(array39, index3)]))
				{
					Vector3 vector15 = vector;
					Vector3 normalized2 = vector2.normalized;
					float[] array40 = arrCollisionRadius;
					vector11 = vector15 - normalized2 * array40[RuntimeServices.NormalizeArrayIndex(array40, index3)];
					vector4 = vector5 - vector11;
				}
			}
			if (flag2 && !(vector11.y >= num5))
			{
				vector11.y = num5;
				vector4 = vector5 - vector11;
			}
			Vector3 vector16 = Quaternion.Inverse(quaternion2) * vector4;
			float[] array41 = arrRotPower;
			Vector3 vector17 = vector16 * array41[RuntimeServices.NormalizeArrayIndex(array41, index)];
			Axis[] array42 = arrAxis;
			switch (array42[RuntimeServices.NormalizeArrayIndex(array42, index)])
			{
			case Axis.X:
			{
				Quaternion[] array48 = rots;
				ref Quaternion reference14 = ref array48[RuntimeServices.NormalizeArrayIndex(array48, index)];
				reference14 = quaternion2 * Quaternion.Euler((vector17.y + vector17.z) / 4f, vector17.z, 0f - vector17.y);
				break;
			}
			case Axis.Y:
			{
				Quaternion[] array47 = rots;
				ref Quaternion reference13 = ref array47[RuntimeServices.NormalizeArrayIndex(array47, index)];
				reference13 = quaternion2 * Quaternion.Euler(0f - vector17.z, (vector17.x + vector17.z) / 4f, vector17.x);
				break;
			}
			case Axis.Z:
			{
				Quaternion[] array46 = rots;
				ref Quaternion reference12 = ref array46[RuntimeServices.NormalizeArrayIndex(array46, index)];
				reference12 = quaternion2 * Quaternion.Euler(vector17.y, 0f - vector17.x, (vector17.x + vector17.y) / 4f);
				break;
			}
			case Axis.Xm:
			{
				Quaternion[] array45 = rots;
				ref Quaternion reference11 = ref array45[RuntimeServices.NormalizeArrayIndex(array45, index)];
				reference11 = quaternion2 * Quaternion.Euler((vector17.y + vector17.z) / -4f, 0f - vector17.z, vector17.y);
				break;
			}
			case Axis.Ym:
			{
				Quaternion[] array44 = rots;
				ref Quaternion reference10 = ref array44[RuntimeServices.NormalizeArrayIndex(array44, index)];
				reference10 = quaternion2 * Quaternion.Euler(vector17.z, (vector17.x + vector17.z) / -4f, 0f - vector17.x);
				break;
			}
			default:
			{
				Quaternion[] array43 = rots;
				ref Quaternion reference9 = ref array43[RuntimeServices.NormalizeArrayIndex(array43, index)];
				reference9 = quaternion2 * Quaternion.Euler(0f - vector17.y, vector17.x, (vector17.x + vector17.y) / -4f);
				break;
			}
			}
			Transform[] array49 = arrTransform;
			Transform obj = array49[RuntimeServices.NormalizeArrayIndex(array49, index)];
			Quaternion[] array50 = rots;
			obj.rotation = array50[RuntimeServices.NormalizeArrayIndex(array50, index)];
			Vector3[] array51 = ptPoss;
			array51[RuntimeServices.NormalizeArrayIndex(array51, index)] = vector11;
			if (viewPointObj)
			{
				Transform[] array52 = testPts;
				array52[RuntimeServices.NormalizeArrayIndex(array52, index)].position = vector11;
			}
		}
	}

	public Transform[] ChildPick(Transform tf)
	{
		int num = ChildCount(tf, 0);
		Transform[] array = new Transform[num];
		ChildDig(array, tf, 0);
		return array;
	}

	public int ChildCount(Transform tf, int n)
	{
		n = checked(n + 1);
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(tf.childCount).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				n = ChildCount(tf.GetChild(num), n);
			}
			return n;
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public int ChildDig(Transform[] tfs, Transform tf, int n)
	{
		tfs[RuntimeServices.NormalizeArrayIndex(tfs, n)] = tf;
		n = checked(n + 1);
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(tf.childCount).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				n = ChildDig(tfs, tf.GetChild(num), n);
			}
			return n;
		}
		finally
		{
			enumerator.Dispose();
		}
	}
}
