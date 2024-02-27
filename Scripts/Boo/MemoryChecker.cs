using System;
using UnityEngine;

[Serializable]
public class MemoryChecker : MonoBehaviour
{
	[NonSerialized]
	private static MemoryChecker __instance;

	[NonSerialized]
	protected static bool quitApp;

	[NonSerialized]
	protected static bool enableShowDialog;

	[NonSerialized]
	protected static bool enableUnloadUnusedAssets;

	protected float warningWait;

	protected float lastLogSec;

	protected float logSec;

	private int logCounter;

	public static MemoryChecker Instance
	{
		get
		{
			MemoryChecker _instance;
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
				__instance = ((MemoryChecker)UnityEngine.Object.FindObjectOfType(typeof(MemoryChecker))) as MemoryChecker;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static MemoryChecker CurrentInstance => __instance;

	public static bool EnableShowDialog
	{
		get
		{
			return enableShowDialog;
		}
		set
		{
			enableShowDialog = value;
		}
	}

	public static bool EnableUnloadUnusedAssets
	{
		get
		{
			return enableUnloadUnusedAssets;
		}
		set
		{
			enableUnloadUnusedAssets = value;
		}
	}

	public void _0024singleton_0024awake_00241638()
	{
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00241638();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static MemoryChecker _createInstance()
	{
		string text = "__" + "MemoryChecker" + "__";
		GameObject gameObject = new GameObject(text);
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		MemoryChecker memoryChecker = ExtensionsModule.SetComponent<MemoryChecker>(gameObject);
		if ((bool)memoryChecker)
		{
			memoryChecker._createInstance_callback();
		}
		return memoryChecker;
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

	public void _0024singleton_0024appQuit_00241639()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00241639();
		quitApp = true;
	}

	public void Start()
	{
	}

	public void Update()
	{
	}

	public void FixedUpdate()
	{
		float deltaTime = Time.deltaTime;
		if (!(warningWait <= 0f))
		{
			warningWait -= deltaTime;
		}
		logSec += deltaTime;
		enableShowDialog = GameParameter.showMemroyWarning;
		enableUnloadUnusedAssets = GameParameter.unloadUnusedAssetsMemroyWarning;
	}

	public void MemoryWarning(string msg)
	{
		if (checked(++logCounter) % 10 == 0 && !(lastLogSec + 1f >= logSec))
		{
			lastLogSec = logSec;
		}
		if (warningWait <= 0f)
		{
			if (enableShowDialog)
			{
				warningWait = 10f;
				Dialog dialog = DialogManager.Open(msg, string.Empty);
			}
			if (enableUnloadUnusedAssets)
			{
				UnloadResource.UnloadUnusedAssets();
			}
		}
	}
}
