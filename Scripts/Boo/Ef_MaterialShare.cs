using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_MaterialShare : MonoBehaviour
{
	public GameObject[] meshObjs;

	private Material[] mats;

	public Ef_MaterialShare()
	{
		meshObjs = new GameObject[2];
	}

	public void Start()
	{
		int length = meshObjs.Length;
		if (length < 2 || !meshObjs[0] || !meshObjs[0].renderer)
		{
			return;
		}
		Material[] materials = meshObjs[0].renderer.materials;
		int length2 = materials.Length;
		int num = default(int);
		int num2 = default(int);
		IEnumerator<int> enumerator = Builtins.range(1, length).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				GameObject[] array = meshObjs;
				GameObject gameObject = array[RuntimeServices.NormalizeArrayIndex(array, num)];
				if (!gameObject || !gameObject.renderer)
				{
					continue;
				}
				Material[] materials2 = gameObject.renderer.materials;
				IEnumerator<int> enumerator2 = Builtins.range(materials2.Length).GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						num2 = enumerator2.Current;
						if (num2 >= length2)
						{
							break;
						}
						if ((bool)materials2[RuntimeServices.NormalizeArrayIndex(materials2, num2)])
						{
							UnityEngine.Object.Destroy(materials2[RuntimeServices.NormalizeArrayIndex(materials2, num2)]);
						}
						materials2[RuntimeServices.NormalizeArrayIndex(materials2, num2)] = materials[RuntimeServices.NormalizeArrayIndex(materials, num2)];
					}
				}
				finally
				{
					enumerator2.Dispose();
				}
				gameObject.renderer.materials = materials2;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void OnDestroy()
	{
		if (mats == null)
		{
			return;
		}
		int i = 0;
		Material[] array = mats;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null)
			{
				UnityEngine.Object.Destroy(array[i]);
			}
		}
	}
}
