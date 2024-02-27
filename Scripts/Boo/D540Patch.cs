using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class D540Patch : MonoBehaviour
{
	private int frameCount;

	private Hashtable varHash;

	public D540Patch()
	{
		varHash = new Hashtable();
	}

	public void Awake()
	{
		D540ScriptRunner component = GetComponent<D540ScriptRunner>();
		if (component != null)
		{
			component.EnabledStart = true;
			component.EnabledUpdate = true;
		}
	}

	public void Update()
	{
		checked
		{
			frameCount++;
		}
	}

	public void setv(string varName, object value)
	{
		if (!string.IsNullOrEmpty(varName))
		{
			varHash[varName] = value;
		}
	}

	public object getv(string varName)
	{
		return string.IsNullOrEmpty(varName) ? null : varHash[varName];
	}

	public int getFrameCount()
	{
		return frameCount;
	}

	public static Vector3 GenVector3(float x, float y, float z)
	{
		return new Vector3(x, y, z);
	}

	public static Quaternion GenQuaternion(float x, float y, float z, float w)
	{
		return new Quaternion(x, y, z, w);
	}

	public static void SetPosition(GameObject obj, Vector3 pos)
	{
		if (obj != null)
		{
			obj.transform.position = pos;
		}
	}

	public static void SetLocalPosition(GameObject obj, Vector3 pos)
	{
		if (obj != null)
		{
			obj.transform.localPosition = pos;
		}
	}

	public static void SetRotation(GameObject obj, Quaternion rot)
	{
		if (obj != null)
		{
			obj.transform.rotation = rot;
		}
	}

	public static void SetLocalRotation(GameObject obj, Quaternion rot)
	{
		if (obj != null)
		{
			obj.transform.localRotation = rot;
		}
	}

	public static string GetBundleVersion()
	{
		return NativeBundleInfo.Version;
	}

	public static string GetApplicationPlatform()
	{
		return Application.platform.ToString();
	}
}
