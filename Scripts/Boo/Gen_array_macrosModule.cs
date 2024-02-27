using System;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;

[CompilerGlobalScope]
public sealed class Gen_array_macrosModule
{
	private Gen_array_macrosModule()
	{
	}

	public static T[] GenArray<T, S>(S[] src, ICallable expr, ICallable cond)
	{
		List<T> list = new List<T>();
		int i = 0;
		for (int length = src.Length; i < length; i = checked(i + 1))
		{
			if (cond == null || RuntimeServices.ToBool(cond.Call(new object[1] { src[i] })))
			{
				list.Add((T)expr.Call(new object[1] { src[i] }));
			}
		}
		return list.ToArray();
	}

	public static T[] GenArray<T, S>(S[] src, ICallable expr)
	{
		List<T> list = new List<T>();
		int num = 0;
		int length = src.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			object[] array = new object[1];
			array[0] = src[RuntimeServices.NormalizeArrayIndex(src, index)];
			list.Add((T)expr.Call(array));
		}
		return list.ToArray();
	}

	public static void GenArray<T, S>(ref T[] dst, S[] src, ICallable expr)
	{
		List<T> list = new List<T>();
		int num = 0;
		int length = src.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			object[] array = new object[1];
			array[0] = src[RuntimeServices.NormalizeArrayIndex(src, index)];
			list.Add((T)expr.Call(array));
		}
		dst = list.ToArray();
	}
}
