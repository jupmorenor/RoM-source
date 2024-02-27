using System;
using GameAsset;
using UnityEngine;

[Serializable]
public class HockeyAppUtil : MonoBehaviour
{
	[NonSerialized]
	public const string DEFAULT_PREFAB_PATH = "Prefab/HockeyApp";

	[NonSerialized]
	private static HockeyAppUtil __instance;

	[NonSerialized]
	protected static bool quitApp;

	public static HockeyAppUtil Instance
	{
		get
		{
			HockeyAppUtil _instance;
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
				__instance = ((HockeyAppUtil)UnityEngine.Object.FindObjectOfType(typeof(HockeyAppUtil))) as HockeyAppUtil;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static HockeyAppUtil CurrentInstance => __instance;

	public void _0024singleton_0024awake_00242719()
	{
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00242719();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static HockeyAppUtil _createInstance()
	{
		GameObject gameObject = (GameObject)GameAssetModule.LoadPrefab("Prefab/HockeyApp");
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
		gameObject2.name = "__" + "HockeyAppUtil" + "__";
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject2);
		HockeyAppUtil hockeyAppUtil = ExtensionsModule.SetComponent<HockeyAppUtil>(gameObject2);
		if ((bool)hockeyAppUtil)
		{
			hockeyAppUtil._createInstance_callback();
		}
		return hockeyAppUtil;
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

	public void _0024singleton_0024appQuit_00242720()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00242720();
		quitApp = true;
	}
}
