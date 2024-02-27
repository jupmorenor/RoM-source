using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class EnumArrayEditAttribute : PropertyAttribute
{
	public Type enumType;

	public string inspectName;

	public int minIndex
	{
		get
		{
			int num = 0;
			IEnumerator enumerator = Enum.GetValues(enumType).GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				int num2 = RuntimeServices.UnboxInt32(current);
				if (num2 < num)
				{
					num = num2;
				}
			}
			return num;
		}
	}

	public int maxIndex
	{
		get
		{
			int num = 0;
			IEnumerator enumerator = Enum.GetValues(enumType).GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				int num2 = RuntimeServices.UnboxInt32(current);
				if (num < num2 || num <= 0)
				{
					num = num2;
				}
			}
			return num;
		}
	}

	public EnumArrayEditAttribute(Type type)
	{
		if (type == null || !type.IsEnum)
		{
			throw new AssertionFailedException(type + "はenum型ではないです");
		}
		enumType = type;
		inspectName = type + "がindexの配列";
	}

	public EnumArrayEditAttribute(Type type, string propName)
	{
		if (type == null || !type.IsEnum)
		{
			throw new AssertionFailedException(type + "はenum型ではないです");
		}
		enumType = type;
		inspectName = propName;
	}
}
