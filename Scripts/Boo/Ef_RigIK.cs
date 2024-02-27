using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_RigIK : MonoBehaviour
{
	[Serializable]
	public enum EndRotation
	{
		None,
		Local,
		World,
		TipObjRot
	}

	[Serializable]
	public enum Forward
	{
		X,
		Y,
		Z,
		Xm,
		Ym,
		Zm
	}

	[Serializable]
	public enum Pivot
	{
		X,
		Y,
		Z
	}

	public Transform target;

	public Transform upVector;

	public bool reverseUpVector;

	public EndRotation endObjectRotation;

	public Vector3 endRotOffset;

	public Transform[] arrTfs;

	public float[] arrLengs;

	public float[] arrMinDistAngs;

	public float maxDist;

	public float minDist;

	public int numTf;

	private int numTfm;

	private int numTfmm;

	public float softness;

	public AnimationCurve lerpCurve;

	public Forward ikForward;

	public Pivot pivot;

	public bool useTwist;

	public float reductionValue;

	public float reductionTangent;

	private Quaternion[] arrRots;

	private Quaternion[] arrLocalRots;

	private float sqrMin;

	private float sqrMax;

	private float sqrSoftDist;

	private float sqrTrgDist;

	private bool useEndRotOfst;

	private Quaternion endRotOfs;

	public Forward twistEndObjForward;

	public bool onLateUpdate;

	[HideInInspector]
	public Vector3 fwdVec;

	[HideInInspector]
	public Vector3 prtFwdVec;

	[HideInInspector]
	public Vector3 endBakVec;

	[HideInInspector]
	public Quaternion prtFwdRot;

	[HideInInspector]
	public Quaternion endBakRot;

	[HideInInspector]
	public Transform parentTf;

	[HideInInspector]
	public bool twistReady;

	public Ef_RigIK()
	{
		softness = 0.1f;
		ikForward = Forward.Z;
		pivot = Pivot.X;
		reductionValue = 0.02f;
		reductionTangent = 1f;
		twistEndObjForward = Forward.Z;
		onLateUpdate = true;
	}

	public void Start()
	{
		Ef_RigEdit component = gameObject.GetComponent<Ef_RigEdit>();
		if ((bool)component)
		{
			UnityEngine.Object.Destroy(component);
		}
		checked
		{
			numTfm = numTf - 1;
			numTfmm = numTf - 2;
			sqrMin = minDist * minDist;
			sqrMax = maxDist * maxDist * 0.999999f;
			float num = maxDist - maxDist * softness;
			sqrSoftDist = num * num;
			if (endRotOffset != Vector3.zero)
			{
				useEndRotOfst = true;
				endRotOfs = Quaternion.Euler(endRotOffset);
			}
			arrRots = new Quaternion[numTf];
			arrLocalRots = new Quaternion[numTf];
		}
	}

	public void Update()
	{
		if (onLateUpdate || !target)
		{
			return;
		}
		Vector3 position = arrTfs[0].position;
		Vector3 vector = default(Vector3);
		if (!upVector)
		{
			vector = Vector3.up;
		}
		else
		{
			vector = upVector.position - position;
			if (!reverseUpVector)
			{
				vector = -vector;
			}
		}
		UpdateIK(position, target.position, vector);
	}

	public void LateUpdate()
	{
		if (!onLateUpdate || !target)
		{
			return;
		}
		Vector3 position = arrTfs[0].position;
		Vector3 vector = default(Vector3);
		if (!upVector)
		{
			vector = Vector3.up;
		}
		else
		{
			vector = upVector.position - position;
			if (!reverseUpVector)
			{
				vector = -vector;
			}
		}
		UpdateIK(position, target.position, vector);
	}

	public void Initialize()
	{
		int num = default(int);
		if (arrTfs.Length >= 2 && (bool)arrTfs[1])
		{
			Vector3 localPosition = arrTfs[1].localPosition;
			if (!(Mathf.Abs(localPosition.x) <= Mathf.Abs(localPosition.y)))
			{
				if (!(Mathf.Abs(localPosition.x) <= Mathf.Abs(localPosition.z)))
				{
					if (!(localPosition.x <= 0f))
					{
						ikForward = Forward.X;
					}
					else
					{
						ikForward = Forward.Xm;
					}
				}
				else if (!(Mathf.Abs(localPosition.y) <= Mathf.Abs(localPosition.z)))
				{
					if (!(localPosition.y <= 0f))
					{
						ikForward = Forward.Y;
					}
					else
					{
						ikForward = Forward.Ym;
					}
				}
				else if (!(localPosition.z <= 0f))
				{
					ikForward = Forward.Z;
				}
				else
				{
					ikForward = Forward.Zm;
				}
			}
			else if (!(Mathf.Abs(localPosition.y) <= Mathf.Abs(localPosition.z)))
			{
				if (!(localPosition.y <= 0f))
				{
					ikForward = Forward.Y;
				}
				else
				{
					ikForward = Forward.Ym;
				}
			}
			else if (!(localPosition.z <= 0f))
			{
				ikForward = Forward.Z;
			}
			else
			{
				ikForward = Forward.Zm;
			}
		}
		if (ikForward == Forward.X && pivot == Pivot.X)
		{
			pivot = Pivot.Y;
		}
		else if ((ikForward == Forward.Y && pivot == Pivot.Y) || (ikForward == Forward.Z && pivot == Pivot.Z))
		{
			pivot = Pivot.X;
		}
		numTf = arrTfs.Length;
		SetDistance();
		checked
		{
			if (arrMinDistAngs.Length != numTf - 2)
			{
				arrMinDistAngs = new float[numTf - 2];
				IEnumerator<int> enumerator = Builtins.range(numTf - 2).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						num = enumerator.Current;
						float[] array = arrMinDistAngs;
						array[RuntimeServices.NormalizeArrayIndex(array, num)] = 180f;
					}
				}
				finally
				{
					enumerator.Dispose();
				}
			}
			CurveInit();
			TwistInitialize();
		}
	}

	public void SetDistance()
	{
		checked
		{
			arrLengs = new float[numTf - 1];
			maxDist = 0f;
			int num = 0;
			int num2 = numTf - 1;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int num3 = num;
				num = unchecked(num + 1);
				Transform[] array = arrTfs;
				float num4 = array[RuntimeServices.NormalizeArrayIndex(array, num3 + 1)].localPosition.magnitude;
				maxDist += num4;
				if (ikForward == Forward.Xm || ikForward == Forward.Ym || ikForward == Forward.Zm)
				{
					num4 = 0f - num4;
				}
				float[] array2 = arrLengs;
				array2[RuntimeServices.NormalizeArrayIndex(array2, num3)] = num4;
			}
		}
	}

	public void SetMinDistAngs()
	{
		checked
		{
			arrMinDistAngs = new float[numTf - 2];
			float num = arrLengs[0];
			float num2 = 0f;
			float num3 = 0f;
			float num4 = default(float);
			Vector3 vector = default(Vector3);
			int num5 = 1;
			int num6 = numTf - 1;
			int num7 = 1;
			if (num6 < num5)
			{
				num7 = -1;
			}
			while (num5 != num6)
			{
				int num8 = num5;
				num5 = unchecked(num5 + num7);
				if (pivot == Pivot.X)
				{
					Transform[] array = arrTfs;
					vector = array[RuntimeServices.NormalizeArrayIndex(array, num8)].localRotation.eulerAngles;
					num4 = vector[0];
					if ((vector[1] == 180f || vector[1] == -180f) && (vector[2] == 180f || vector[2] == -180f))
					{
						num4 = 180f - num4;
					}
				}
				else if (pivot == Pivot.Y)
				{
					Transform[] array2 = arrTfs;
					num4 = array2[RuntimeServices.NormalizeArrayIndex(array2, num8)].localRotation.eulerAngles[1];
				}
				else
				{
					Transform[] array3 = arrTfs;
					num4 = array3[RuntimeServices.NormalizeArrayIndex(array3, num8)].localRotation.eulerAngles[2];
				}
				if (!(num4 > -180f))
				{
					num4 += 360f;
				}
				else if (!(num4 < 180f))
				{
					num4 -= 360f;
				}
				float[] array4 = arrMinDistAngs;
				array4[RuntimeServices.NormalizeArrayIndex(array4, num8 - 1)] = num4;
				num3 += num4;
				float f = num3 * 0.01745329f;
				float num9 = num;
				float[] array5 = arrLengs;
				num = num9 + array5[RuntimeServices.NormalizeArrayIndex(array5, num8)] * Mathf.Cos(f);
				float num10 = num2;
				float[] array6 = arrLengs;
				num2 = num10 + array6[RuntimeServices.NormalizeArrayIndex(array6, num8)] * Mathf.Sin(f);
			}
			minDist = new Vector2(num, num2).magnitude;
			CurveInit();
		}
	}

	public void CurveInit()
	{
		sqrMax = maxDist * maxDist * 0.999999f;
		lerpCurve = new AnimationCurve();
		float num = 0f;
		float num2 = 0f;
		int num3 = 100;
		float num4 = 9999f;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		int num9 = 0;
		checked
		{
			int num10 = num3 + 1;
			if (num10 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num9 < num10)
			{
				int num11 = num9;
				num9 = unchecked(num9 + 1);
				float num12 = sqrMax / (float)num3 * (float)num11;
				float num13 = 0f;
				float num14 = 0f;
				float num15 = 1f;
				int num16 = 20;
				int num17 = 0;
				int num18 = num16 + 1;
				if (num18 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num17 < num18)
				{
					int num19 = num17;
					num17 = unchecked(num17 + 1);
					num = arrLengs[0];
					num2 = 0f;
					float num20 = 0f;
					int num21 = 1;
					int num22 = numTf - 1;
					int num23 = 1;
					if (num22 < num21)
					{
						num23 = -1;
					}
					while (num21 != num22)
					{
						int num24 = num21;
						num21 = unchecked(num21 + num23);
						float num25 = num20;
						float from = 0f;
						float[] array = arrMinDistAngs;
						num20 = num25 + Mathf.Lerp(from, array[RuntimeServices.NormalizeArrayIndex(array, num24 - 1)], num14);
						float f = num20 * 0.01745329f;
						float num26 = num;
						float[] array2 = arrLengs;
						num = num26 + array2[RuntimeServices.NormalizeArrayIndex(array2, num24)] * Mathf.Cos(f);
						float num27 = num2;
						float[] array3 = arrLengs;
						num2 = num27 + array3[RuntimeServices.NormalizeArrayIndex(array3, num24)] * Mathf.Sin(f);
					}
					if (num19 < num16)
					{
						num15 /= 2f;
						num13 = num * num + num2 * num2;
						num14 = ((num13 <= num12) ? (num14 - num15) : (num14 + num15));
					}
				}
				if (!(num13 >= num4))
				{
					num4 = num13;
				}
				Keyframe keyframe = default(Keyframe);
				float num28 = 0f;
				if (num11 == 1)
				{
					num28 = (num14 - num5) * (float)(num3 - 1);
					keyframe = new Keyframe(1f / (float)num3 * (float)(num11 - 1), num5);
					keyframe.inTangent = num28;
					keyframe.outTangent = num28;
					lerpCurve.AddKey(keyframe);
				}
				else if (num11 >= 2)
				{
					num28 = (num14 - num6) * (float)(num3 - 1) / 2f;
					if ((!(Mathf.Abs(num28 - num7) <= reductionTangent) && Mathf.Abs(num14 - num8) > reductionValue) || num11 == unchecked(num3 / 2))
					{
						keyframe = new Keyframe(1f / (float)num3 * (float)(num11 - 1), num5);
						keyframe.inTangent = num28;
						keyframe.outTangent = num28;
						lerpCurve.AddKey(keyframe);
						num7 = num28;
						num8 = num14;
					}
				}
				if (num11 == num3)
				{
					num28 = (num14 - num5) * (float)(num3 - 1);
					keyframe = new Keyframe(1f, num14);
					keyframe.inTangent = num28;
					keyframe.outTangent = num28;
					lerpCurve.AddKey(keyframe);
				}
				num6 = num5;
				num5 = num14;
			}
			minDist = Mathf.Sqrt(num4);
		}
	}

	public void UpdateIK(Vector3 pos, Vector3 trgPos, Vector3 upVector)
	{
		float num = arrLengs[0];
		float num2 = 0f;
		Vector3 forward = trgPos - pos;
		float sqrMagnitude = forward.sqrMagnitude;
		Quaternion identity = Quaternion.identity;
		if (softness == 0f)
		{
			int num3 = 1;
			int num4 = numTfm;
			int num5 = 1;
			if (num4 < num3)
			{
				num5 = -1;
			}
			while (num3 != num4)
			{
				int index = num3;
				num3 += num5;
				float num6 = num;
				float[] array = arrLengs;
				num = num6 + array[RuntimeServices.NormalizeArrayIndex(array, index)];
				Quaternion[] array2 = arrLocalRots;
				ref Quaternion reference = ref array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
				reference = Quaternion.identity;
				Quaternion[] array3 = arrRots;
				ref Quaternion reference2 = ref array3[RuntimeServices.NormalizeArrayIndex(array3, index)];
				reference2 = Quaternion.identity;
			}
		}
		else
		{
			if (!(sqrMagnitude >= sqrMin))
			{
				sqrMagnitude = sqrMin;
			}
			if (!(sqrMagnitude <= sqrMax))
			{
				sqrMagnitude = sqrMax;
			}
			if (!(sqrMagnitude >= sqrSoftDist))
			{
				sqrTrgDist = sqrMagnitude;
			}
			else if (!(sqrTrgDist >= sqrSoftDist))
			{
				sqrTrgDist = sqrSoftDist;
			}
			else
			{
				sqrTrgDist = Mathf.Lerp(sqrTrgDist, sqrMagnitude, 0.5f);
			}
			float t = lerpCurve.Evaluate(sqrTrgDist / sqrMax);
			float num7 = 0f;
			float num8 = 0f;
			int num9 = 1;
			int num10 = numTfm;
			int num11 = 1;
			if (num10 < num9)
			{
				num11 = -1;
			}
			while (num9 != num10)
			{
				int num12 = num9;
				num9 += num11;
				float from = 0f;
				float[] array4 = arrMinDistAngs;
				num7 = Mathf.Lerp(from, array4[RuntimeServices.NormalizeArrayIndex(array4, checked(num12 - 1))], t);
				num8 += num7;
				float f = num8 * 0.01745329f;
				float num13 = num;
				float[] array5 = arrLengs;
				num = num13 + array5[RuntimeServices.NormalizeArrayIndex(array5, num12)] * Mathf.Cos(f);
				float num14 = num2;
				float[] array6 = arrLengs;
				num2 = num14 + array6[RuntimeServices.NormalizeArrayIndex(array6, num12)] * Mathf.Sin(f);
				Quaternion quaternion = default(Quaternion);
				quaternion = ((pivot != 0) ? ((pivot != Pivot.Y) ? Quaternion.Euler(0f, 0f, num7) : Quaternion.Euler(0f, num7, 0f)) : Quaternion.Euler(num7, 0f, 0f));
				Quaternion[] array7 = arrLocalRots;
				array7[RuntimeServices.NormalizeArrayIndex(array7, num12)] = quaternion;
				identity *= quaternion;
				Quaternion[] array8 = arrRots;
				array8[RuntimeServices.NormalizeArrayIndex(array8, num12)] = identity;
			}
		}
		float num15 = PosToAng(num, num2);
		Quaternion quaternion2 = Quaternion.LookRotation(forward, upVector);
		Quaternion quaternion3 = default(Quaternion);
		quaternion3 = ((ikForward != Forward.Z && ikForward != Forward.Zm) ? ((ikForward == Forward.Y || ikForward == Forward.Ym) ? ((pivot != 0) ? Quaternion.Euler(0f, 90f, num15 + 90f) : Quaternion.Euler(num15 + 90f, 0f, 0f)) : ((pivot != Pivot.Y) ? Quaternion.Euler(180f, -90f, num15) : Quaternion.Euler(num15 - 90f, 0f, -90f))) : ((pivot != 0) ? (Quaternion.Euler(0f, 0f, -90f) * Quaternion.Euler(0f, num15, 0f)) : Quaternion.Euler(num15, 0f, 0f)));
		ref Quaternion reference3 = ref arrRots[0];
		reference3 = quaternion2 * quaternion3;
		Quaternion quaternion4 = arrRots[0];
		int num16 = 1;
		int num17 = numTfm;
		int num18 = 1;
		if (num17 < num16)
		{
			num18 = -1;
		}
		while (num16 != num17)
		{
			int index2 = num16;
			num16 += num18;
			Quaternion[] array9 = arrRots;
			ref Quaternion reference4 = ref array9[RuntimeServices.NormalizeArrayIndex(array9, index2)];
			Quaternion[] array10 = arrRots;
			reference4 = quaternion4 * array10[RuntimeServices.NormalizeArrayIndex(array10, index2)];
		}
		if (useTwist)
		{
			Twist();
		}
		int num19 = 0;
		int num20 = numTfm;
		if (num20 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num19 < num20)
		{
			int index3 = num19;
			num19++;
			Transform[] array11 = arrTfs;
			Transform obj = array11[RuntimeServices.NormalizeArrayIndex(array11, index3)];
			Quaternion[] array12 = arrRots;
			obj.rotation = array12[RuntimeServices.NormalizeArrayIndex(array12, index3)];
		}
		if (endObjectRotation == EndRotation.Local)
		{
			if (useEndRotOfst)
			{
				Transform[] array13 = arrTfs;
				Transform obj2 = array13[RuntimeServices.NormalizeArrayIndex(array13, numTfm)];
				Quaternion[] array14 = arrRots;
				obj2.rotation = array14[RuntimeServices.NormalizeArrayIndex(array14, numTfmm)] * target.rotation * endRotOfs;
			}
			else
			{
				Transform[] array15 = arrTfs;
				Transform obj3 = array15[RuntimeServices.NormalizeArrayIndex(array15, numTfm)];
				Quaternion[] array16 = arrRots;
				obj3.rotation = array16[RuntimeServices.NormalizeArrayIndex(array16, numTfmm)] * target.rotation;
			}
		}
		else if (endObjectRotation == EndRotation.World)
		{
			if (useEndRotOfst)
			{
				Transform[] array17 = arrTfs;
				array17[RuntimeServices.NormalizeArrayIndex(array17, numTfm)].rotation = target.rotation * endRotOfs;
			}
			else
			{
				Transform[] array18 = arrTfs;
				array18[RuntimeServices.NormalizeArrayIndex(array18, numTfm)].rotation = target.rotation;
			}
		}
		else if (endObjectRotation == EndRotation.TipObjRot)
		{
			if (useEndRotOfst)
			{
				Transform[] array19 = arrTfs;
				Transform obj4 = array19[RuntimeServices.NormalizeArrayIndex(array19, numTfm)];
				Quaternion[] array20 = arrRots;
				Quaternion quaternion5 = array20[RuntimeServices.NormalizeArrayIndex(array20, numTfmm)];
				Quaternion identity2 = Quaternion.identity;
				Quaternion[] array21 = arrLocalRots;
				obj4.rotation = quaternion5 * Quaternion.Lerp(identity2, array21[RuntimeServices.NormalizeArrayIndex(array21, numTfmm)], 0.5f) * endRotOfs;
			}
			else
			{
				Transform[] array22 = arrTfs;
				Transform obj5 = array22[RuntimeServices.NormalizeArrayIndex(array22, numTfm)];
				Quaternion[] array23 = arrRots;
				Quaternion quaternion6 = array23[RuntimeServices.NormalizeArrayIndex(array23, numTfmm)];
				Quaternion identity3 = Quaternion.identity;
				Quaternion[] array24 = arrLocalRots;
				obj5.rotation = quaternion6 * Quaternion.Lerp(identity3, array24[RuntimeServices.NormalizeArrayIndex(array24, numTfmm)], 0.5f);
			}
		}
	}

	public float PosToAng(float x, float y)
	{
		float num = 57.29578f;
		float num2 = 0f;
		if (!(Mathf.Abs(x) <= Mathf.Abs(y)))
		{
			if (!(x >= 0f))
			{
				num2 = (0f - Mathf.Atan(y / x)) * num + 180f;
				if (!(num2 <= 180f))
				{
					num2 -= 360f;
				}
			}
			else if (!(x <= 0f))
			{
				num2 = (0f - Mathf.Atan(y / x)) * num;
			}
		}
		else if (!(y >= 0f))
		{
			num2 = Mathf.Atan(x / y) * num + 90f;
		}
		else if (!(y <= 0f))
		{
			num2 = Mathf.Atan(x / y) * num - 90f;
		}
		return num2;
	}

	public void TwistInitialize()
	{
		twistReady = false;
		if (numTf > 2 && (bool)arrTfs[0].parent)
		{
			parentTf = arrTfs[0].parent;
			fwdVec = ForwardToVector(ikForward);
			prtFwdVec = Quaternion.Inverse(parentTf.rotation) * arrTfs[0].rotation * fwdVec;
			Transform[] array = arrTfs;
			Quaternion quaternion = Quaternion.Inverse(array[RuntimeServices.NormalizeArrayIndex(array, numTfm)].rotation);
			Transform[] array2 = arrTfs;
			endBakVec = quaternion * array2[RuntimeServices.NormalizeArrayIndex(array2, numTfmm)].rotation * -ForwardToVector(twistEndObjForward);
			prtFwdRot = arrTfs[0].localRotation;
			Transform[] array3 = arrTfs;
			Quaternion quaternion2 = Quaternion.Inverse(array3[RuntimeServices.NormalizeArrayIndex(array3, numTfm)].rotation);
			Transform[] array4 = arrTfs;
			endBakRot = quaternion2 * array4[RuntimeServices.NormalizeArrayIndex(array4, numTfmm)].rotation;
			twistReady = true;
		}
	}

	public Vector3 ForwardToVector(Forward fwd)
	{
		return fwd switch
		{
			Forward.X => new Vector3(1f, 0f, 0f), 
			Forward.Y => new Vector3(0f, 1f, 0f), 
			Forward.Z => new Vector3(0f, 0f, 1f), 
			Forward.Xm => new Vector3(-1f, 0f, 0f), 
			Forward.Ym => new Vector3(0f, -1f, 0f), 
			_ => new Vector3(0f, 0f, -1f), 
		};
	}

	public void Twist()
	{
		if (twistReady)
		{
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			Quaternion quaternion = default(Quaternion);
			Quaternion quaternion2 = default(Quaternion);
			Quaternion quaternion3 = default(Quaternion);
			Quaternion quaternion4 = default(Quaternion);
			quaternion4 = parentTf.rotation * prtFwdRot;
			vector = parentTf.rotation * prtFwdVec;
			vector2 = arrRots[0] * fwdVec;
			quaternion = Quaternion.FromToRotation(vector, vector2) * quaternion4;
			quaternion2 = Quaternion.Inverse(arrRots[0]) * quaternion;
			Transform[] array = arrTfs;
			quaternion4 = array[RuntimeServices.NormalizeArrayIndex(array, numTfm)].rotation * endBakRot;
			Transform[] array2 = arrTfs;
			vector = array2[RuntimeServices.NormalizeArrayIndex(array2, numTfm)].rotation * endBakVec;
			Quaternion[] array3 = arrRots;
			vector2 = array3[RuntimeServices.NormalizeArrayIndex(array3, numTfmm)] * -fwdVec;
			quaternion = Quaternion.FromToRotation(vector, vector2) * quaternion4;
			Quaternion[] array4 = arrRots;
			quaternion3 = Quaternion.Inverse(array4[RuntimeServices.NormalizeArrayIndex(array4, numTfmm)]) * quaternion;
			int num = 0;
			int num2 = checked(numTfmm + 1);
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int num3 = num;
				num++;
				Quaternion[] array5 = arrRots;
				ref Quaternion reference = ref array5[RuntimeServices.NormalizeArrayIndex(array5, num3)];
				Quaternion[] array6 = arrRots;
				reference = array6[RuntimeServices.NormalizeArrayIndex(array6, num3)] * Quaternion.Lerp(quaternion2, quaternion3, ((float)num3 + 1f) / (float)numTf);
			}
		}
	}
}
