using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_Rerease : Ef_Base
{
	public GameObject[] childs;

	public float delay;

	public bool destroyWithParent;

	public Ef_Rerease()
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
					UnityEngine.Object.Destroy(array2[RuntimeServices.NormalizeArrayIndex(array2, num)]);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}
}
