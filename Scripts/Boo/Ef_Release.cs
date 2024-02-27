using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_Release : Ef_Base
{
	public GameObject[] childs;

	public float delay;

	public bool destroyWithParent;

	public Ef_Release()
	{
		destroyWithParent = true;
	}

	public void Start()
	{
		if (delay == 0f)
		{
			Rerease();
		}
	}

	public void Update()
	{
		if (delay > 0f)
		{
			delay -= deltaTime;
			if (!(delay > 0f))
			{
				Rerease();
			}
		}
	}

	public void Rerease()
	{
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(childs.Length).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				GameObject[] array = childs;
				if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, num)])
				{
					GameObject[] array2 = childs;
					array2[RuntimeServices.NormalizeArrayIndex(array2, num)].transform.parent = null;
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void OnDestroy()
	{
		if (!destroyWithParent)
		{
			return;
		}
		int num = default(int);
		if (childs == null)
		{
			return;
		}
		IEnumerator<int> enumerator = Builtins.range(childs.Length).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				GameObject[] array = childs;
				if (!(array[RuntimeServices.NormalizeArrayIndex(array, num)] != null))
				{
					continue;
				}
				GameObject[] array2 = childs;
				Ef_DestroyReleaseV2 component = array2[RuntimeServices.NormalizeArrayIndex(array2, num)].GetComponent<Ef_DestroyReleaseV2>();
				if (component != null)
				{
					component.Release();
				}
				else
				{
					GameObject[] array3 = childs;
					Ef_DestroyRelease component2 = array3[RuntimeServices.NormalizeArrayIndex(array3, num)].GetComponent<Ef_DestroyRelease>();
					if (component2 != null)
					{
						component2.Release();
					}
				}
				GameObject[] array4 = childs;
				UnityEngine.Object.Destroy(array4[RuntimeServices.NormalizeArrayIndex(array4, num)]);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}
}
