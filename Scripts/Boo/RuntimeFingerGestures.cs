using System;
using GameAsset;
using UnityEngine;

[Serializable]
public class RuntimeFingerGestures : MonoBehaviour
{
	[NonSerialized]
	public const string DEFAULT_PREFAB_PATH = "Prefab/FingerGestures/FingerGestures";

	[NonSerialized]
	private static RuntimeFingerGestures __instance;

	[NonSerialized]
	protected static bool quitApp;

	public static RuntimeFingerGestures Instance
	{
		get
		{
			RuntimeFingerGestures _instance;
			if (quitApp)
			{
				_instance = __instance;
			}
			else if (__instance != null)
			{
				_instance = __instance;
			}
			else
			{
				__instance = ((RuntimeFingerGestures)UnityEngine.Object.FindObjectOfType(typeof(RuntimeFingerGestures))) as RuntimeFingerGestures;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static RuntimeFingerGestures CurrentInstance => __instance;

	public void _0024singleton_0024awake_00241605()
	{
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00241605();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static RuntimeFingerGestures _createInstance()
	{
		GameObject gameObject = (GameObject)GameAssetModule.LoadPrefab("Prefab/FingerGestures/FingerGestures");
		GameObject gameObject2;
		if (gameObject == null)
		{
			gameObject2 = new GameObject();
		}
		else
		{
			gameObject2 = ((GameObject)UnityEngine.Object.Instantiate(gameObject)) as GameObject;
			if (gameObject2 == null)
			{
				gameObject2 = new GameObject();
			}
		}
		gameObject2.name = "__" + "RuntimeFingerGestures" + "__";
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject2);
		RuntimeFingerGestures runtimeFingerGestures = ExtensionsModule.SetComponent<RuntimeFingerGestures>(gameObject2);
		if ((bool)runtimeFingerGestures)
		{
			runtimeFingerGestures._createInstance_callback();
		}
		return runtimeFingerGestures;
	}

	public void _createInstance_callback()
	{
	}

	public static void DestroyInstance()
	{
		if ((bool)__instance)
		{
			UnityEngine.Object.DestroyObject(__instance.gameObject);
		}
		__instance = null;
	}

	public void _0024singleton_0024appQuit_00241606()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00241606();
		quitApp = true;
	}
}
