using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class SelectFromComponent : MonoBehaviour
{
	public bool select;

	public Transform trush;

	public void Update()
	{
		if (!trush)
		{
			trush = new GameObject("trush").transform;
		}
		if (!select)
		{
			return;
		}
		Transform[] array = new Transform[transform.childCount];
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(array.Length).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				array[RuntimeServices.NormalizeArrayIndex(array, num)] = transform.GetChild(num);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		IEnumerator<int> enumerator2 = Builtins.range(array.Length).GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				num = enumerator2.Current;
				Component[] componentsInChildren = array[RuntimeServices.NormalizeArrayIndex(array, num)].GetComponentsInChildren(typeof(Ef_FindPath));
				if (componentsInChildren.Length == 0)
				{
					array[RuntimeServices.NormalizeArrayIndex(array, num)].parent = trush;
				}
			}
		}
		finally
		{
			enumerator2.Dispose();
		}
		select = false;
	}
}
