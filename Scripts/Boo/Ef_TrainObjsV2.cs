using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_TrainObjsV2 : Ef_Base
{
	public Transform[] transforms;

	public float stepLength;

	public float allLength;

	public float[] distances;

	public Quaternion[] ofsRots;

	public Vector3[] ofsScales;

	private Vector3[] poss;

	private Quaternion[] rots;

	private Vector3[] scales;

	private int pt;

	private int num;

	private int step;

	private bool ready;

	public Ef_TrainObjsV2()
	{
		transforms = new Transform[0];
		stepLength = 0.5f;
		allLength = 20f;
	}

	public void Initialize()
	{
		int length = transforms.Length;
		distances = new float[length];
		ofsRots = new Quaternion[length];
		ofsScales = new Vector3[length];
		if (transforms[0] == null)
		{
			return;
		}
		Quaternion quaternion = Quaternion.Inverse(transforms[0].rotation);
		Vector3 b = default(Vector3);
		Vector3 localScale = transforms[0].localScale;
		if (localScale.x != 0f)
		{
			b.x = 1f / localScale.x;
		}
		else
		{
			b.x = 0f;
		}
		if (localScale.y != 0f)
		{
			b.y = 1f / localScale.y;
		}
		else
		{
			b.y = 0f;
		}
		if (localScale.z != 0f)
		{
			b.z = 1f / localScale.z;
		}
		else
		{
			b.z = 0f;
		}
		allLength = 0f;
		int num = 0;
		int num2 = length;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			Transform[] array = transforms;
			Transform transform = array[RuntimeServices.NormalizeArrayIndex(array, num3)];
			if (transform == null)
			{
				break;
			}
			if (num3 == 0)
			{
				allLength = 0f;
			}
			else
			{
				float num4 = allLength;
				Transform[] array2 = transforms;
				Vector3 position = array2[RuntimeServices.NormalizeArrayIndex(array2, num3)].position;
				Transform[] array3 = transforms;
				allLength = num4 + (position - array3[RuntimeServices.NormalizeArrayIndex(array3, checked(num3 - 1))].position).magnitude;
			}
			float[] array4 = distances;
			array4[RuntimeServices.NormalizeArrayIndex(array4, num3)] = allLength;
			Quaternion[] array5 = ofsRots;
			ref Quaternion reference = ref array5[RuntimeServices.NormalizeArrayIndex(array5, num3)];
			Transform[] array6 = transforms;
			reference = quaternion * array6[RuntimeServices.NormalizeArrayIndex(array6, num3)].rotation;
			Vector3[] array7 = ofsScales;
			ref Vector3 reference2 = ref array7[RuntimeServices.NormalizeArrayIndex(array7, num3)];
			Transform[] array8 = transforms;
			reference2 = Vector3.Scale(array8[RuntimeServices.NormalizeArrayIndex(array8, num3)].localScale, b);
		}
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		if (ready)
		{
			WakeUp();
		}
	}

	public void Start()
	{
		Ef_TrainObjsV2_Edit component = gameObject.GetComponent<Ef_TrainObjsV2_Edit>();
		if (component != null)
		{
			UnityEngine.Object.Destroy(component);
		}
		if (!ready)
		{
			Init();
		}
		if (ready)
		{
			WakeUp();
		}
	}

	public void WakeUp()
	{
		Vector3 position = transforms[0].transform.position;
		Quaternion rotation = transforms[0].transform.rotation;
		Vector3 localScale = transforms[0].transform.localScale;
		int num = 0;
		int num2 = step;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			Vector3[] array = poss;
			array[RuntimeServices.NormalizeArrayIndex(array, index)] = position;
			Quaternion[] array2 = rots;
			array2[RuntimeServices.NormalizeArrayIndex(array2, index)] = rotation;
			Vector3[] array3 = scales;
			array3[RuntimeServices.NormalizeArrayIndex(array3, index)] = localScale;
		}
		pt = 0;
	}

	public void Init()
	{
		this.num = transforms.Length;
		if (distances.Length != this.num || ofsRots.Length != this.num || ofsScales.Length != this.num)
		{
			return;
		}
		int num = 0;
		int num2 = this.num;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			Transform[] array = transforms;
			if (array[RuntimeServices.NormalizeArrayIndex(array, num3)] == null)
			{
				return;
			}
			if (num3 > 0)
			{
				Transform[] array2 = transforms;
				Transform obj = array2[RuntimeServices.NormalizeArrayIndex(array2, num3)];
				string lhs = gameObject.name + "/";
				Transform[] array3 = transforms;
				obj.name = lhs + array3[RuntimeServices.NormalizeArrayIndex(array3, num3)].name;
				Transform[] array4 = transforms;
				array4[RuntimeServices.NormalizeArrayIndex(array4, num3)].parent = null;
			}
		}
		step = checked(Mathf.RoundToInt(allLength / stepLength) + 1);
		poss = new Vector3[step];
		rots = new Quaternion[step];
		scales = new Vector3[step];
		ready = true;
	}

	public void LateUpdate()
	{
		Vector3 position = transforms[0].position;
		Quaternion rotation = transforms[0].rotation;
		Vector3 localScale = transforms[0].localScale;
		Vector3[] array = poss;
		float magnitude = (position - array[RuntimeServices.NormalizeArrayIndex(array, pt)]).magnitude;
		float num = default(float);
		int num2 = 0;
		int num3 = this.num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int num4 = num2;
			num2++;
			checked
			{
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
					continue;
				}
				break;
			}
		}
		int num5 = 1;
		int num6 = this.num;
		int num7 = 1;
		if (num6 < num5)
		{
			num7 = -1;
		}
		while (num5 != num6)
		{
			int index2 = num5;
			num5 += num7;
			float[] array9 = distances;
			float num8 = (array9[RuntimeServices.NormalizeArrayIndex(array9, index2)] - magnitude) / stepLength;
			if (!(num8 >= 0f))
			{
				Transform[] array10 = transforms;
				Transform obj = array10[RuntimeServices.NormalizeArrayIndex(array10, index2)];
				Vector3[] array11 = poss;
				obj.position = Vector3.Lerp(array11[RuntimeServices.NormalizeArrayIndex(array11, pt)], position, 0f - num8);
				Transform[] array12 = transforms;
				Transform obj2 = array12[RuntimeServices.NormalizeArrayIndex(array12, index2)];
				Quaternion[] array13 = rots;
				obj2.rotation = Quaternion.Lerp(array13[RuntimeServices.NormalizeArrayIndex(array13, pt)], rotation, 0f - num8);
				Transform[] array14 = transforms;
				Transform obj3 = array14[RuntimeServices.NormalizeArrayIndex(array14, index2)];
				Vector3[] array15 = scales;
				obj3.localScale = Vector3.Lerp(array15[RuntimeServices.NormalizeArrayIndex(array15, pt)], localScale, 0f - num8);
				continue;
			}
			int num9 = Mathf.FloorToInt(num8);
			num = num8 - (float)num9;
			checked
			{
				int num10 = pt - num9;
				if (num10 < 0)
				{
					num10 += step;
				}
				int num11 = num10 - 1;
				if (num11 < 0)
				{
					num11 += step;
				}
				Transform[] array16 = transforms;
				Transform obj4 = array16[RuntimeServices.NormalizeArrayIndex(array16, index2)];
				Vector3[] array17 = poss;
				Vector3 from = array17[RuntimeServices.NormalizeArrayIndex(array17, num10)];
				Vector3[] array18 = poss;
				obj4.position = Vector3.Lerp(from, array18[RuntimeServices.NormalizeArrayIndex(array18, num11)], num);
				Transform[] array19 = transforms;
				Transform obj5 = array19[RuntimeServices.NormalizeArrayIndex(array19, index2)];
				Quaternion[] array20 = rots;
				Quaternion from2 = array20[RuntimeServices.NormalizeArrayIndex(array20, num10)];
				Quaternion[] array21 = rots;
				Quaternion quaternion = Quaternion.Lerp(from2, array21[RuntimeServices.NormalizeArrayIndex(array21, num11)], num);
				Quaternion[] array22 = ofsRots;
				obj5.rotation = quaternion * array22[RuntimeServices.NormalizeArrayIndex(array22, index2)];
				Vector3[] array23 = scales;
				Vector3 from3 = array23[RuntimeServices.NormalizeArrayIndex(array23, num10)];
				Vector3[] array24 = scales;
				Vector3 localScale2 = Vector3.Lerp(from3, array24[RuntimeServices.NormalizeArrayIndex(array24, num11)], num);
				Vector3[] array25 = ofsScales;
				Vector3 vector = array25[RuntimeServices.NormalizeArrayIndex(array25, index2)];
				localScale2.x *= vector.x;
				localScale2.y *= vector.y;
				localScale2.z *= vector.z;
				Transform[] array26 = transforms;
				array26[RuntimeServices.NormalizeArrayIndex(array26, index2)].localScale = localScale2;
			}
		}
	}

	public void OnDestroy()
	{
		if (transforms == null)
		{
			return;
		}
		int i = 0;
		Transform[] array = transforms;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null)
			{
				UnityEngine.Object.Destroy(array[i].gameObject);
			}
		}
	}
}
