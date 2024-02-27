using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class _nameComparer : IComparer
{
	public virtual int Compare(object x, object y)
	{
		object obj = x;
		if (!(obj is GameObject))
		{
			obj = RuntimeServices.Coerce(obj, typeof(GameObject));
		}
		string name = ((GameObject)obj).name;
		object obj2 = y;
		if (!(obj2 is GameObject))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(GameObject));
		}
		return string.CompareOrdinal(name, ((GameObject)obj2).name);
	}
}
