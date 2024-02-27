using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

namespace ObjUtil;

[CompilerGlobalScope]
public sealed class ObjUtilModule
{
	private ObjUtilModule()
	{
	}

	public static T FindWithComponent<T>(string path) where T : Component
	{
		GameObject gameObject = GameObject.Find(path);
		return (!(gameObject == null)) ? gameObject.GetComponent<T>() : (null as T);
	}

	public static T FindComponent<T>() where T : Component
	{
		return ((T)UnityEngine.Object.FindObjectOfType(typeof(T))) as T;
	}

	public static T CloneObject<T>(GameObject o) where T : Component
	{
		if (!(o != null))
		{
			throw new AssertionFailedException("CloneObject失敗");
		}
		GameObject gameObject = ((GameObject)UnityEngine.Object.Instantiate(o)) as GameObject;
		if (!(gameObject != null))
		{
			throw new AssertionFailedException("CloneObject失敗");
		}
		T val = ExtensionsModule.SetComponent<T>(gameObject);
		if (!(val != null))
		{
			throw new AssertionFailedException(new StringBuilder("CloneObject失敗(").Append(typeof(T)).Append("の設定)").ToString());
		}
		return val;
	}

	public static T CloneObject<T>(Transform o) where T : Component
	{
		if (!(o != null))
		{
			throw new AssertionFailedException("CloneObject失敗");
		}
		GameObject gameObject = ((GameObject)UnityEngine.Object.Instantiate(o.gameObject)) as GameObject;
		if (!(gameObject != null))
		{
			throw new AssertionFailedException("CloneObject失敗");
		}
		T val = ExtensionsModule.SetComponent<T>(gameObject);
		if (!(val != null))
		{
			throw new AssertionFailedException(new StringBuilder("CloneObject失敗(").Append(typeof(T)).Append("の設定)").ToString());
		}
		return val;
	}

	public static float Distance(GameObject o1, GameObject o2)
	{
		return (!(o1 == null) && !(o2 == null)) ? Vector3.Distance(o1.transform.position, o2.transform.position) : 0f;
	}

	public static float Distance(Component o1, GameObject o2)
	{
		return (!(o1 == null) && !(o2 == null)) ? Vector3.Distance(o1.transform.position, o2.transform.position) : 0f;
	}

	public static float Distance(GameObject o1, Component o2)
	{
		return (!(o1 == null) && !(o2 == null)) ? Vector3.Distance(o1.transform.position, o2.transform.position) : 0f;
	}

	public static float Distance(Component o1, Component o2)
	{
		return (!(o1 == null) && !(o2 == null)) ? Vector3.Distance(o1.transform.position, o2.transform.position) : 0f;
	}

	public static Transform Find1stDescendant(Transform transform, string name)
	{
		object result;
		if (transform == null)
		{
			result = null;
		}
		else if (name == string.Empty)
		{
			result = null;
		}
		else if (transform.name == name)
		{
			result = transform;
		}
		else
		{
			IEnumerator enumerator = transform.GetEnumerator();
			while (true)
			{
				if (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is Transform))
					{
						obj = RuntimeServices.Coerce(obj, typeof(Transform));
					}
					Transform transform2 = (Transform)obj;
					Transform transform3 = Find1stDescendant(transform2, name);
					if ((bool)transform3)
					{
						result = transform3;
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

	public static GameObject FindByName(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			throw new AssertionFailedException("not string.IsNullOrEmpty(name)");
		}
		GameObject gameObject = GameObject.Find(name) as GameObject;
		if (!gameObject)
		{
			gameObject = GameObject.Find(name + "(Clone)") as GameObject;
		}
		return (!gameObject) ? null : gameObject;
	}

	public static string DebugObjectInspection(object obj)
	{
		object result;
		if (obj == null)
		{
			result = "<null>";
		}
		else
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{ ");
			stringBuilder.Append(obj.GetType().ToString());
			stringBuilder.Append(" ");
			int i = 0;
			FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
			for (int length = fields.Length; i < length; i = checked(i + 1))
			{
				try
				{
					object value = fields[i].GetValue(obj);
					stringBuilder.Append(new StringBuilder().Append(fields[i].Name).Append("=").Append(value)
						.Append("/")
						.ToString());
				}
				catch (Exception)
				{
					stringBuilder.Append(new StringBuilder().Append(fields[i].Name).Append("=<unknown>/").ToString());
				}
			}
			stringBuilder.Append(" }");
			result = stringBuilder.ToString();
		}
		return (string)result;
	}

	public static string DebugObjectInspectionFull(object obj)
	{
		object result;
		if (obj == null)
		{
			result = "<null>";
		}
		else
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{ ");
			stringBuilder.Append(obj.GetType().ToString());
			stringBuilder.Append(" ");
			int i = 0;
			FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			for (int length = fields.Length; i < length; i = checked(i + 1))
			{
				try
				{
					object value = fields[i].GetValue(obj);
					stringBuilder.Append(new StringBuilder().Append(fields[i].Name).Append(":").ToString());
					stringBuilder.Append(value.ToString());
					stringBuilder.Append(", ");
				}
				catch (Exception)
				{
					stringBuilder.Append(new StringBuilder().Append(fields[i].Name).Append("=<unknown>, ").ToString());
				}
			}
			stringBuilder.Append(" }");
			result = stringBuilder.ToString();
		}
		return (string)result;
	}

	public static void DeletePersistenData(string fileName)
	{
		string path = Application.persistentDataPath + "/" + fileName;
		try
		{
			File.Delete(path);
		}
		catch (Exception)
		{
		}
	}

	public static bool SaveString(string fileName, string data)
	{
		string path = Application.persistentDataPath + "/" + fileName;
		bool flag;
		try
		{
			FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
			if (fileStream == null)
			{
				flag = false;
				goto IL_006d;
			}
			byte[] bytes = Encoding.Unicode.GetBytes(data);
			fileStream.Write(bytes, 0, bytes.Length);
			fileStream.Close();
		}
		catch (Exception)
		{
			flag = false;
			goto IL_006d;
		}
		Builtins.print("SaveObject end");
		int result = 1;
		goto IL_006f;
		IL_006f:
		return (byte)result != 0;
		IL_006d:
		result = (flag ? 1 : 0);
		goto IL_006f;
	}

	public static string LoadString(string fileName)
	{
		string path = Application.persistentDataPath + "/" + fileName;
		string text = null;
		string text2;
		try
		{
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			if (fileStream == null)
			{
				text2 = null;
				goto IL_006c;
			}
			byte[] array = new byte[checked((int)fileStream.Length)];
			fileStream.Read(array, 0, array.Length);
			text = Encoding.Unicode.GetString(array);
			fileStream.Close();
		}
		catch (Exception)
		{
		}
		string result = text;
		goto IL_006e;
		IL_006c:
		result = text2;
		goto IL_006e;
		IL_006e:
		return result;
	}

	public static Vector3 GetScreenPostion(Transform selfTransform, GameObject target, Camera camera)
	{
		Vector3 vector = default(Vector3);
		Vector3 result;
		if (selfTransform == null || target == null || camera == null)
		{
			result = vector;
		}
		else
		{
			vector = GetScreenPostion(selfTransform, target.transform.position, camera);
			result = vector;
		}
		return result;
	}

	public static Vector3 GetScreenPostion(Transform selfTransform, Vector3 pos, Camera camera)
	{
		Vector3 result;
		if (selfTransform == null || camera == null)
		{
			result = pos;
		}
		else
		{
			pos = camera.WorldToScreenPoint(pos);
			pos.x -= Screen.width / 2;
			pos.y -= Screen.height / 2;
			pos.z = 0f;
			UIRoot componentInChildren = default(UIRoot);
			if ((bool)selfTransform.root)
			{
				componentInChildren = selfTransform.root.gameObject.GetComponentInChildren<UIRoot>();
			}
			if ((bool)componentInChildren)
			{
				pos.x *= componentInChildren.pixelSizeAdjustment;
				pos.y *= componentInChildren.pixelSizeAdjustment;
			}
			result = pos;
		}
		return result;
	}

	public static Component CopyComponent(GameObject gameObject, Component old_component)
	{
		Component component = gameObject.AddComponent(old_component.GetType());
		int i = 0;
		FieldInfo[] fields = old_component.GetType().GetFields();
		for (int length = fields.Length; i < length; i = checked(i + 1))
		{
			fields[i].SetValue(component, fields[i].GetValue(old_component));
		}
		return component;
	}

	public static object[] GetGroundHeight(GameObject gameObject)
	{
		if (!(gameObject != null))
		{
			throw new AssertionFailedException("gameObject != null");
		}
		return GetGroundHeight(gameObject.transform.position);
	}

	public static object[] GetGroundHeight(Transform t)
	{
		return GetGroundHeight(t.position);
	}

	public static object[] GetGroundHeight(Vector3 p)
	{
		string layerName = "Plane";
		float num = 0.01f;
		RaycastHit hitInfo = default(RaycastHit);
		LayerMask layerMask = 1 << LayerMask.NameToLayer(layerName);
		return Physics.Raycast(p + new Vector3(0f, 100f, 0f), Vector3.down, out hitInfo, 1000f, layerMask.value) ? new object[3]
		{
			true,
			hitInfo.point.y + num,
			hitInfo.normal
		} : new object[3]
		{
			false,
			p.y,
			Vector3.up
		};
	}

	public static Vector3 GetGroundHeight(float x, float y)
	{
		Vector3 zero = Vector3.zero;
		zero.x = x;
		zero.z = y;
		string layerName = "Plane";
		float num = 0.01f;
		RaycastHit hitInfo = default(RaycastHit);
		LayerMask layerMask = 1 << LayerMask.NameToLayer(layerName);
		if (Physics.Raycast(zero + new Vector3(0f, 100f, 0f), Vector3.down, out hitInfo, 1000f, layerMask.value))
		{
			zero.y = hitInfo.point.y + num;
		}
		else
		{
			zero.y = float.NegativeInfinity;
		}
		return zero;
	}
}
