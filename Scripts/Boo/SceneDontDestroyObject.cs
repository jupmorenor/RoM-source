using System;
using System.Collections;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class SceneDontDestroyObject : MonoBehaviour
{
	[NonSerialized]
	protected static Hashtable dontDestroyList = new Hashtable();

	public static Hashtable DontDestroyList => dontDestroyList;

	public static void dontDestroyOnLoad(UnityEngine.Object obj)
	{
		UnityEngine.Object.DontDestroyOnLoad(obj);
		dontDestroyList[obj.GetInstanceID()] = obj;
		object[] array = Builtins.array(dontDestroyList.Keys);
		int i = 0;
		object[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			if (!RuntimeServices.ToBool(dontDestroyList[array2[i]]))
			{
				dontDestroyList.Remove(array2[i]);
			}
		}
	}

	public static void DestroyAll()
	{
		IEnumerator enumerator = dontDestroyList.Values.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is UnityEngine.Object))
			{
				obj = RuntimeServices.Coerce(obj, typeof(UnityEngine.Object));
			}
			UnityEngine.Object @object = (UnityEngine.Object)obj;
			if (@object != null)
			{
				UnityEngine.Object.Destroy(@object);
			}
		}
		dontDestroyList.Clear();
	}

	public void Start()
	{
	}

	public void Update()
	{
	}

	public void OnDestroy()
	{
	}
}
