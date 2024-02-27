using System;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang.Runtime;
using UnityEngine;

namespace GameAsset;

[CompilerGlobalScope]
public sealed class GameAssetModule
{
	private GameAssetModule()
	{
	}

	public static UnityEngine.Object LoadPrefab(string path)
	{
		return Resources.Load(path) as UnityEngine.Object;
	}

	public static UnityEngine.Object LoadPrefab(string path, Type systemTypeInstance)
	{
		return Resources.Load(path, systemTypeInstance) as UnityEngine.Object;
	}

	public static GameObject InstantiatePrefab(string path)
	{
		UnityEngine.Object @object = LoadPrefab(path);
		if (!(@object != null))
		{
			throw new AssertionFailedException(new StringBuilder("プレハブ ").Append(path).Append(" がロードできません").ToString());
		}
		return Instantiate((GameObject)@object);
	}

	public static GameObject InstantiatePrefab(string path, Vector3 pos, Quaternion rot)
	{
		UnityEngine.Object @object = LoadPrefab(path);
		if (!(@object != null))
		{
			throw new AssertionFailedException(new StringBuilder("プレハブ ").Append(path).Append(" がロードできません").ToString());
		}
		return Instantiate((GameObject)@object, pos, rot);
	}

	public static T InstantiatePrefab<T>(string path) where T : Component
	{
		GameObject component = InstantiatePrefab(path);
		return ExtensionsModule.SetComponent<T>(component);
	}

	public static T InstantiatePrefab<T>(string path, Vector3 pos, Quaternion rot) where T : Component
	{
		GameObject component = InstantiatePrefab(path, pos, rot);
		return ExtensionsModule.SetComponent<T>(component);
	}

	public static GameObject Instantiate(GameObject obj)
	{
		return ((GameObject)UnityEngine.Object.Instantiate(obj)) as GameObject;
	}

	public static GameObject Instantiate(GameObject obj, Vector3 pos, Quaternion rot)
	{
		return ((GameObject)UnityEngine.Object.Instantiate(obj, pos, rot)) as GameObject;
	}
}
