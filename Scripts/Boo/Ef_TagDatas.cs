using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_TagDatas : MonoBehaviour
{
	[NonSerialized]
	private static Ef_TagDatas current;

	[NonSerialized]
	public const int maxObjNum = 10;

	public string[] tags;

	public GameObject[] gameObjs;

	private bool[] hitFlgs;

	private bool ready;

	public static Ef_TagDatas Current
	{
		get
		{
			if (current == null)
			{
				Ef_TagDatas ef_TagDatas = new GameObject("Ef_Tags").AddComponent<Ef_TagDatas>();
				ef_TagDatas.Initialize();
				current = ef_TagDatas;
			}
			return current;
		}
	}

	public void Initialize()
	{
		tags = new string[10];
		gameObjs = new GameObject[10];
		hitFlgs = new bool[10];
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(10).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				string[] array = tags;
				array[RuntimeServices.NormalizeArrayIndex(array, num)] = string.Empty;
				GameObject[] array2 = gameObjs;
				array2[RuntimeServices.NormalizeArrayIndex(array2, num)] = null;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		if (current != null && current.gameObject != gameObject)
		{
			UnityEngine.Object.Destroy(current.gameObject);
		}
		current = this;
		ready = true;
	}

	public void SetTag(string tag, GameObject gameObj)
	{
		if (!ready)
		{
			UnityEngine.Object.Destroy(gameObj);
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(10).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				GameObject[] array = gameObjs;
				if (array[RuntimeServices.NormalizeArrayIndex(array, num)] == null)
				{
					string[] array2 = tags;
					array2[RuntimeServices.NormalizeArrayIndex(array2, num)] = tag;
					GameObject[] array3 = gameObjs;
					array3[RuntimeServices.NormalizeArrayIndex(array3, num)] = gameObj;
					break;
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		if (num == 10)
		{
			UnityEngine.Object.Destroy(gameObj);
		}
	}

	public GameObject[] SearchTag(string tag)
	{
		checked
		{
			GameObject[] result;
			if (!ready)
			{
				UnityEngine.Object.Destroy(gameObject);
				GameObject[] array = null;
				result = array;
			}
			else
			{
				int num = 0;
				int num2 = default(int);
				IEnumerator<int> enumerator = Builtins.range(10).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						num2 = enumerator.Current;
						GameObject[] array2 = gameObjs;
						if ((bool)array2[RuntimeServices.NormalizeArrayIndex(array2, num2)])
						{
							string[] array3 = tags;
							if (array3[RuntimeServices.NormalizeArrayIndex(array3, num2)] == tag)
							{
								bool[] array4 = hitFlgs;
								array4[RuntimeServices.NormalizeArrayIndex(array4, num2)] = true;
								num++;
								continue;
							}
						}
						bool[] array5 = hitFlgs;
						array5[RuntimeServices.NormalizeArrayIndex(array5, num2)] = false;
					}
				}
				finally
				{
					enumerator.Dispose();
				}
				GameObject[] array6 = new GameObject[num];
				int num3 = 0;
				IEnumerator<int> enumerator2 = Builtins.range(10).GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						num2 = enumerator2.Current;
						bool[] array7 = hitFlgs;
						if (array7[RuntimeServices.NormalizeArrayIndex(array7, num2)])
						{
							int num4 = RuntimeServices.NormalizeArrayIndex(array6, num3);
							GameObject[] array8 = gameObjs;
							array6[num4] = array8[RuntimeServices.NormalizeArrayIndex(array8, num2)];
							num3++;
						}
					}
				}
				finally
				{
					enumerator2.Dispose();
				}
				result = array6;
			}
			return result;
		}
	}

	public void Update()
	{
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(10).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				GameObject[] array = gameObjs;
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
