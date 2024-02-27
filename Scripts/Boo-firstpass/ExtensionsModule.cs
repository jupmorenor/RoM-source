using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[CompilerGlobalScope]
public sealed class ExtensionsModule
{
	private ExtensionsModule()
	{
	}

	public static GameObject Parent(this GameObject go)
	{
		object result;
		if (go == null)
		{
			result = null;
		}
		else
		{
			Transform transform = go.transform;
			result = ((!(transform.parent == null)) ? transform.parent.gameObject : null);
		}
		return (GameObject)result;
	}

	public static object SetParent(this GameObject go, GameObject parent)
	{
		object result;
		if (go == null)
		{
			result = null;
		}
		else
		{
			go.transform.parent = parent.transform;
			result = null;
		}
		return result;
	}

	public static GameObject FindChild(this GameObject go, string objName)
	{
		__ExtensionsModule_FindChild_0024callable64_002423_9__ _ExtensionsModule_FindChild_0024callable64_002423_9__ = delegate(GameObject g, string n)
		{
			object result;
			if (g == null)
			{
				result = null;
			}
			else if (g.name.ToLower() == n)
			{
				result = g;
			}
			else
			{
				IEnumerator enumerator = g.transform.GetEnumerator();
				while (true)
				{
					if (!enumerator.MoveNext())
					{
						result = _0024FindChild_0024f_00241155(null, n);
						break;
					}
					object obj = enumerator.Current;
					if (!(obj is Transform))
					{
						obj = RuntimeServices.Coerce(obj, typeof(Transform));
					}
					Transform transform = (Transform)obj;
					GameObject gameObject = _0024FindChild_0024f_00241155(transform.gameObject, n);
					if ((bool)gameObject)
					{
						result = gameObject;
						break;
					}
				}
			}
			return (GameObject)result;
		};
		return _ExtensionsModule_FindChild_0024callable64_002423_9__(go, objName.ToLower());
	}

	public static GameObject[] Children(this GameObject go)
	{
		GameObject[] result;
		if (go == null)
		{
			result = new GameObject[0];
		}
		else
		{
			Transform transform = go.transform;
			GameObject[] array = new GameObject[transform.childCount];
			int num = 0;
			IEnumerator enumerator = go.transform.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is Transform))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Transform));
				}
				Transform transform2 = (Transform)obj;
				array[RuntimeServices.NormalizeArrayIndex(array, checked(num++))] = transform2.gameObject;
			}
			result = array;
		}
		return result;
	}

	public static void ActivateChildren(this GameObject go, bool b)
	{
		if (go == null)
		{
			return;
		}
		IEnumerator enumerator = go.transform.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			Transform transform = (Transform)obj;
			transform.gameObject.SetActive(b);
		}
	}

	public static void SetLayer(this GameObject go, string layerName)
	{
		if (!(go == null))
		{
			go.layer = LayerMask.NameToLayer(layerName);
		}
	}

	public static void SetLayerRecursively(this GameObject go, string layerName)
	{
		SetLayerRecursively(go, LayerMask.NameToLayer(layerName));
	}

	public static void SetLayerRecursively(this GameObject go, int layer)
	{
		__ExtensionsModule_SetLayerRecursively_0024callable65_002464_9__ _ExtensionsModule_SetLayerRecursively_0024callable65_002464_9__ = delegate(GameObject go, int l)
		{
			if (go != null)
			{
				go.layer = l;
				IEnumerator enumerator = go.transform.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is Transform))
					{
						obj = RuntimeServices.Coerce(obj, typeof(Transform));
					}
					Transform transform = (Transform)obj;
					_0024SetLayerRecursively_0024_set_00241157(transform.gameObject, l);
				}
			}
		};
		_ExtensionsModule_SetLayerRecursively_0024callable65_002464_9__(go, layer);
	}

	public static GameObject FindInChildrenIgnoreCase(this GameObject go, string nm)
	{
		object result;
		if (go == null || string.IsNullOrEmpty(nm))
		{
			result = null;
		}
		else
		{
			string text = nm.ToLower();
			IEnumerator enumerator = go.transform.GetEnumerator();
			while (true)
			{
				if (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is Transform))
					{
						obj = RuntimeServices.Coerce(obj, typeof(Transform));
					}
					Transform transform = (Transform)obj;
					if (transform.name.ToLower() == text)
					{
						result = transform.gameObject;
						break;
					}
					continue;
				}
				result = null;
				break;
			}
		}
		return (GameObject)result;
	}

	public static GameObject[] FindChildrenIgnoreCaseStartsWith(this GameObject go, string nm)
	{
		object result;
		if (go == null || string.IsNullOrEmpty(nm))
		{
			result = null;
		}
		else
		{
			string value = nm.ToLower();
			Boo.Lang.List<GameObject> list = new Boo.Lang.List<GameObject>();
			IEnumerator enumerator = go.transform.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is Transform))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Transform));
				}
				Transform transform = (Transform)obj;
				if (transform.name.ToLower().StartsWith(value))
				{
					list.Add(transform.gameObject);
				}
			}
			result = (GameObject[])Builtins.array(typeof(GameObject), list);
		}
		return (GameObject[])result;
	}

	public static Transform FindInDescendants(this Transform t, string n)
	{
		Transform transform = t.Find(n);
		object result;
		if (transform != null)
		{
			result = transform;
		}
		else
		{
			IEnumerator enumerator = t.GetEnumerator();
			while (true)
			{
				if (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is Transform))
					{
						obj = RuntimeServices.Coerce(obj, typeof(Transform));
					}
					Transform t2 = (Transform)obj;
					transform = FindInDescendants(t2, n);
					if (transform != null)
					{
						result = transform;
						break;
					}
					continue;
				}
				result = null;
				break;
			}
		}
		return (Transform)result;
	}

	public static Transform FindInActiveDescendants(this Transform t, string n)
	{
		IEnumerator enumerator = t.GetEnumerator();
		object result;
		while (true)
		{
			if (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is Transform))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Transform));
				}
				Transform transform = (Transform)obj;
				if (transform.name == n && transform.gameObject.activeInHierarchy)
				{
					result = transform;
					break;
				}
				Transform transform2 = FindInActiveDescendants(transform, n);
				if (transform2 != null)
				{
					result = transform2;
					break;
				}
				continue;
			}
			result = null;
			break;
		}
		return (Transform)result;
	}

	public static T FindComponent<T>(this Transform t, string n) where T : Component
	{
		Transform transform = t.Find(n);
		return (!(transform != null)) ? (null as T) : transform.GetComponent<T>();
	}

	public static T FindComponentInDescendants<T>(this GameObject g, string n) where T : Component
	{
		int num = 0;
		T[] componentsInChildren = g.GetComponentsInChildren<T>();
		int length = componentsInChildren.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (componentsInChildren[num].gameObject.name == n)
				{
					result = (T)componentsInChildren[num];
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = (T)null;
			break;
		}
		return (T)result;
	}

	public static T FindComponentInChildrenOrSelf<T>(this GameObject g) where T : Component
	{
		object result;
		if (g == null)
		{
			result = null as T;
		}
		else
		{
			T component = g.GetComponent<T>();
			result = ((!(component != null)) ? g.GetComponentInChildren<T>() : component);
		}
		return (T)result;
	}

	public static T ComponentInAncestors<T>(this GameObject o) where T : Component
	{
		object result;
		if (o == null)
		{
			result = null as T;
		}
		else
		{
			T component = o.GetComponent<T>();
			result = ((!(component != null)) ? ComponentInAncestors<T>(Parent(o)) : component);
		}
		return (T)result;
	}

	public static T SetComponent<T>(this GameObject o) where T : Component
	{
		T component = o.GetComponent<T>();
		if (component == null)
		{
			o.AddComponent<T>();
			component = o.GetComponent<T>();
			if (!(component != null))
			{
				throw new AssertionFailedException("c != null");
			}
		}
		return component;
	}

	public static string GetMyID(this UnityEngine.Object o)
	{
		return (!(o != null)) ? "<null>" : o.GetInstanceID().ToString();
	}

	public static string GetMyName(this GameObject o)
	{
		return (!(o != null)) ? "<null>" : o.name;
	}

	public static string ToReadableString(this GameObject o)
	{
		return (!(o == null)) ? new StringBuilder().Append(o.name).Append("/").Append((object)o.GetInstanceID())
			.Append("/")
			.Append(o.GetType().ToString())
			.ToString() : "<null>";
	}

	public static string SafeToString(this object o)
	{
		return (o != null) ? o.ToString() : "<null>";
	}

	public static string Inspect(this UnityEngine.Object o)
	{
		object result;
		if (o == null)
		{
			result = "<null>";
		}
		else
		{
			GameObject gameObject = o as GameObject;
			if (gameObject != null)
			{
				string text2;
				try
				{
					Transform parent = gameObject.transform.parent;
					Component[] componentsInChildren = gameObject.GetComponentsInChildren(typeof(Component), includeInactive: true);
					Boo.Lang.List<string> list = new Boo.Lang.List<string>();
					int i = 0;
					Component[] array = componentsInChildren;
					for (int length = array.Length; i < length; i = checked(i + 1))
					{
						list.Add(array[i].GetType().ToString());
					}
					string value = ToReadableString(list.ToArray());
					if (parent == null)
					{
						string text = new StringBuilder().Append(gameObject.name).Append("/").Append((object)gameObject.GetInstanceID())
							.Append("/")
							.Append(gameObject.GetType().ToString())
							.Append("/(parent:<null>) comps(")
							.Append(value)
							.Append(")")
							.ToString();
						text2 = text.Replace("UnityEngine.", string.Empty);
					}
					else
					{
						string text = new StringBuilder().Append(gameObject.name).Append("/").Append((object)gameObject.GetInstanceID())
							.Append("/")
							.Append(gameObject.GetType().ToString())
							.Append("/(parent:")
							.Append(ToReadableString(parent.gameObject))
							.Append(") comps(")
							.Append(value)
							.Append(")")
							.ToString();
						text2 = text.Replace("UnityEngine.", string.Empty);
					}
				}
				catch (Exception)
				{
					text2 = "<error:${e.ToString()}>";
				}
				result = text2;
			}
			else
			{
				result = SafeToString(o);
			}
		}
		return (string)result;
	}

	public static string ToReadableString<T>(this T[] ids)
	{
		object result;
		if (ids == null)
		{
			result = "<null>";
		}
		else
		{
			string text = string.Empty;
			int i = 0;
			for (int length = ids.Length; i < length; i = checked(i + 1))
			{
				if (ids[i] != null)
				{
					string lhs = text;
					T val = ids[i];
					text = lhs + (val.ToString() + "/");
				}
				else
				{
					text += "<null>";
				}
			}
			text += new StringBuilder("num=").Append((object)ids.Length).ToString();
			result = text;
		}
		return (string)result;
	}

	public static string ToReadableString<T>(this Boo.Lang.List<T> ids)
	{
		object result;
		if (ids == null)
		{
			result = "<null>";
		}
		else
		{
			string lhs = string.Empty;
			IEnumerator<T> enumerator = ids.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					T current = enumerator.Current;
					lhs = ((current == null) ? (lhs + "<null>") : (lhs + (current.ToString() + "/")));
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			lhs += new StringBuilder("num=").Append((object)ids.Count).ToString();
			result = lhs;
		}
		return (string)result;
	}

	public static string ToReadableString(this Hashtable h)
	{
		object result;
		if (h == null)
		{
			result = "<null>";
		}
		else
		{
			string text = string.Empty;
			IEnumerator enumerator = h.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				text += new StringBuilder().Append(current).Append("=").Append(h[current])
					.Append("/")
					.ToString();
			}
			result = text;
		}
		return (string)result;
	}

	public static string ToReadableString<K, V>(this IDictionary<K, V> h)
	{
		object result;
		if (h == null)
		{
			result = "<null>";
		}
		else
		{
			string text = string.Empty;
			IEnumerator enumerator = ((IEnumerable)h.Keys).GetEnumerator();
			while (enumerator.MoveNext())
			{
				K key = (K)enumerator.Current;
				text += new StringBuilder().Append(key.ToString()).Append("=").Append(h[key].ToString())
					.Append("/")
					.ToString();
			}
			result = text;
		}
		return (string)result;
	}

	public static T[] StableSort<T>(this T[] values, Comparison<T> comparison)
	{
		StableSortKey[] array = new StableSortKey[values.Length];
		int num = 0;
		int length = values.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int num2 = num;
			num++;
			array[RuntimeServices.NormalizeArrayIndex(array, num2)] = new StableSortKey(num2, values[RuntimeServices.NormalizeArrayIndex(values, num2)]);
		}
		Array.Sort(array, values, new StabilizingComparer<T>(comparison));
		return values;
	}

	public static YieldInstruction PostStartCoroutine(this MonoBehaviour component, __ExtensionsModule_PostStartCoroutine_0024callable24_0024278_59__ fun)
	{
		if (!(fun != null))
		{
			throw new AssertionFailedException("fun != null");
		}
		if (!(component != null))
		{
			throw new AssertionFailedException("component != null");
		}
		return component.StartCoroutine(fun());
	}

	internal static GameObject _0024FindChild_0024f_00241155(GameObject g, string n)
	{
		object result;
		if (g == null)
		{
			result = null;
		}
		else if (g.name.ToLower() == n)
		{
			result = g;
		}
		else
		{
			IEnumerator enumerator = g.transform.GetEnumerator();
			while (true)
			{
				if (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is Transform))
					{
						obj = RuntimeServices.Coerce(obj, typeof(Transform));
					}
					Transform transform = (Transform)obj;
					GameObject gameObject = _0024FindChild_0024f_00241155(transform.gameObject, n);
					if ((bool)gameObject)
					{
						result = gameObject;
						break;
					}
					continue;
				}
				result = _0024FindChild_0024f_00241155(null, n);
				break;
			}
		}
		return (GameObject)result;
	}

	internal static void _0024SetLayerRecursively_0024_set_00241157(GameObject go, int l)
	{
		if (!(go != null))
		{
			return;
		}
		go.layer = l;
		IEnumerator enumerator = go.transform.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			Transform transform = (Transform)obj;
			_0024SetLayerRecursively_0024_set_00241157(transform.gameObject, l);
		}
	}
}
