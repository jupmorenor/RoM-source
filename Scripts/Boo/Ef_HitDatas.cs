using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_HitDatas : MonoBehaviour
{
	[NonSerialized]
	private static Ef_HitDatas current;

	[NonSerialized]
	public const int maxObjNum = 40;

	public Transform[] objs;

	public float[] radiuss;

	private bool ready;

	public static Ef_HitDatas Current
	{
		get
		{
			if (current == null)
			{
				Ef_HitDatas ef_HitDatas = new GameObject("Ef_Hits").AddComponent<Ef_HitDatas>();
				ef_HitDatas.Initialize();
				current = ef_HitDatas;
			}
			return current;
		}
	}

	public void Initialize()
	{
		objs = new Transform[40];
		radiuss = new float[40];
		ready = true;
	}

	public bool SetHitData(Transform obj, float rad)
	{
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(40).GetEnumerator();
		bool flag;
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Transform[] array = objs;
				if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, num)])
				{
					continue;
				}
				Transform[] array2 = objs;
				array2[RuntimeServices.NormalizeArrayIndex(array2, num)] = obj;
				float[] array3 = radiuss;
				array3[RuntimeServices.NormalizeArrayIndex(array3, num)] = rad;
				flag = true;
				goto IL_0078;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		int result = 0;
		goto IL_0079;
		IL_0078:
		result = (flag ? 1 : 0);
		goto IL_0079;
		IL_0079:
		return (byte)result != 0;
	}

	public Transform Hit2D(Transform obj)
	{
		Vector3 position = obj.position;
		int num = default(int);
		float num2 = default(float);
		IEnumerator<int> enumerator = Builtins.range(40).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Transform[] array = objs;
				if (array[RuntimeServices.NormalizeArrayIndex(array, num)] == obj)
				{
					float[] array2 = radiuss;
					num2 = array2[RuntimeServices.NormalizeArrayIndex(array2, num)];
					break;
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		IEnumerator<int> enumerator2 = Builtins.range(40).GetEnumerator();
		Transform transform2;
		try
		{
			while (enumerator2.MoveNext())
			{
				num = enumerator2.Current;
				Transform[] array3 = objs;
				Transform transform = array3[RuntimeServices.NormalizeArrayIndex(array3, num)];
				if (!transform || transform == obj)
				{
					continue;
				}
				Vector3 position2 = transform.position;
				float[] array4 = radiuss;
				float num3 = array4[RuntimeServices.NormalizeArrayIndex(array4, num)];
				float sqrMagnitude = new Vector2(position2[0] - position[0], position2[2] - position[2]).sqrMagnitude;
				float num4 = num2 + num3;
				if (sqrMagnitude > num4 * num4)
				{
					continue;
				}
				transform2 = transform;
				goto IL_0143;
			}
		}
		finally
		{
			enumerator2.Dispose();
		}
		object result = null;
		goto IL_0145;
		IL_0145:
		return (Transform)result;
		IL_0143:
		result = transform2;
		goto IL_0145;
	}

	public void Push2D(Transform obj)
	{
		Vector3 position = obj.position;
		float num = default(float);
		int num2 = 0;
		int num3 = 40;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int index = num2;
			num2++;
			Transform[] array = objs;
			if (array[RuntimeServices.NormalizeArrayIndex(array, index)] == obj)
			{
				float[] array2 = radiuss;
				num = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
				break;
			}
		}
		int num4 = 0;
		int num5 = 40;
		if (num5 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num4 < num5)
		{
			int index2 = num4;
			num4++;
			Transform[] array3 = objs;
			Transform transform = array3[RuntimeServices.NormalizeArrayIndex(array3, index2)];
			if ((bool)transform && !(transform == obj))
			{
				Vector3 position2 = transform.position;
				float[] array4 = radiuss;
				float num6 = array4[RuntimeServices.NormalizeArrayIndex(array4, index2)];
				Vector2 vector = new Vector2(position2[0] - position[0], position2[2] - position[2]);
				if (vector == Vector2.zero)
				{
					vector = new Vector2(0f, 0.0001f);
				}
				float sqrMagnitude = vector.sqrMagnitude;
				float num7 = num + num6;
				if (!(sqrMagnitude > num7 * num7))
				{
					float num8 = Mathf.Sqrt(sqrMagnitude);
					float num9 = (num7 - num8) / 2f + 0.01f;
					Vector2 vector2 = new Vector2(vector[0] / num8 * num9, vector[1] / num8 * num9);
					position2[0] += vector2[0];
					position2[2] += vector2[1];
					position[0] -= vector2[0];
					position[2] -= vector2[1];
					transform.position = position2;
				}
			}
		}
	}

	public void Update()
	{
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(40).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Transform[] array = objs;
				if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, num)])
				{
					return;
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		UnityEngine.Object.Destroy(gameObject);
	}
}
