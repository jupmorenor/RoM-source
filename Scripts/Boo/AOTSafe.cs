using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class AOTSafe
{
	public static void ForEach<T>(object enumerable, Action<T> action)
	{
		if (!RuntimeServices.ToBool(enumerable))
		{
			return;
		}
		Type type = enumerable.GetType().GetInterfaces().First(delegate(Type x)
		{
			bool num = !x.IsGenericType;
			if (num)
			{
				num = x == typeof(IEnumerable);
			}
			return num;
		});
		if (type == null)
		{
			throw new ArgumentException("Object does not implement IEnumerableinterface", "enumerable");
		}
		MethodInfo method = type.GetMethod("GetEnumerator");
		if (method == null)
		{
			throw new InvalidOperationException("Failed to get 'GetEnumberator()'method info from IEnumerable type");
		}
		IEnumerator enumerator = null;
		try
		{
			object obj = method.Invoke(enumerable, null);
			if (!(obj is IEnumerator))
			{
				obj = RuntimeServices.Coerce(obj, typeof(IEnumerator));
			}
			enumerator = (IEnumerator)obj;
			if (enumerator is IEnumerator)
			{
				while (enumerator.MoveNext())
				{
					action((T)enumerator.Current);
				}
			}
			else
			{
				Debug.Log($"{enumerable.ToString()}.GetEnumerator() returned'{enumerator.GetType().Name}' instead of IEnumerator.");
			}
		}
		finally
		{
			if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
	}

	internal static bool _0024ForEach_0024closure_00245260(Type x)
	{
		bool num = !x.IsGenericType;
		if (num)
		{
			num = x == typeof(IEnumerable);
		}
		return num;
	}
}
