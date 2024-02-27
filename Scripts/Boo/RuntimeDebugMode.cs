using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class RuntimeDebugMode : MonoBehaviour
{
	[Serializable]
	public struct Mode
	{
		public string name;

		public Type type;

		public Mode(string n, Type t)
		{
			if (string.IsNullOrEmpty(n) || t == null)
			{
				throw new AssertionFailedException("(not string.IsNullOrEmpty(n)) and (t != null)");
			}
			name = n;
			type = t;
		}
	}

	[Serializable]
	private class Pauser
	{
		[NonSerialized]
		private static bool isPaused;

		[NonSerialized]
		private static float timeScale;

		public static void Pause()
		{
			if (!isPaused)
			{
				isPaused = true;
				timeScale = Time.timeScale;
				Time.timeScale = 0f;
			}
		}

		public static void Unpause()
		{
			if (isPaused)
			{
				TimeScaleUtil.Set(timeScale);
				isPaused = false;
			}
		}
	}

	[NonSerialized]
	private static RuntimeDebugMode __instance;

	[NonSerialized]
	protected static bool quitApp;

	[NonSerialized]
	private static int MAIN_VIEW_WIDTH = 740;

	[NonSerialized]
	private static int SHORTCUT_VIEW_WIDTH = 220;

	private Mode[] SubModeClasses;

	private Dictionary<string, bool> evNow;

	private Dictionary<string, bool> evOn;

	private int backButtonCnt;

	private int hideButtonCnt;

	private int stepButtonCnt;

	private int preBackButtonCnt;

	private int preHideButtonCnt;

	private int preStepButtonCnt;

	private bool inDebugMode;

	private bool showDebugMode;

	private RuntimeDebugModeGuiMixin currentMode;

	private string currentModeName;

	private MethodInfo shortcutMethod;

	private RuntimeDebugModeGuiMixin gm;

	private float lastTouch3Checked;

	private bool stopDebugMode;

	[NonSerialized]
	private static int[] _touchMultiBit = new int[9] { 0, 1, 3, 7, 15, 31, 63, 127, 255 };

	public static RuntimeDebugMode Instance
	{
		get
		{
			RuntimeDebugMode _instance;
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
				__instance = ((RuntimeDebugMode)UnityEngine.Object.FindObjectOfType(typeof(RuntimeDebugMode))) as RuntimeDebugMode;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static RuntimeDebugMode CurrentInstance => __instance;

	public bool IsInDebugMode => inDebugMode;

	public RuntimeDebugMode()
	{
		SubModeClasses = new Mode[24]
		{
			new Mode("Jumps", typeof(DebugSubJumps)),
			new Mode("Bookmark", typeof(DebugSubMyJumps)),
			new Mode("Log", typeof(DebugSubLogHistory)),
			new Mode("Option Switches", typeof(DebugSubSwitches)),
			new Mode("Quest", typeof(DebugSubQuest)),
			new Mode("GameObject Inspector", typeof(DebugSubGameObjectInspector)),
			new Mode("Gacha & StoneShop & Sell", typeof(DebugSubGacha)),
			new Mode("Debug Camera", typeof(DebugSubDebugCamera)),
			new Mode("System Infomation", typeof(DebugSubSystemInfo)),
			new Mode("User Data", typeof(DebugSubUserData)),
			new Mode("Friend", typeof(DebugSubFriend)),
			new Mode("Shadow", typeof(DebugSubShadow)),
			new Mode("Sound", typeof(DebugSubSound)),
			new Mode("Monster Pop", typeof(DebugSubMonsterPop)),
			new Mode("Poppet Pop", typeof(DebugSubPoppetPop)),
			new Mode("Font & Languages", typeof(DebugSubFont)),
			new Mode("Test Load Effect", typeof(DebugSubTestLoadEffect)),
			new Mode("スキルとダメージ", typeof(DebugSubSkill)),
			new Mode("WebView", typeof(DebugSubWebView)),
			new Mode("マスター", typeof(DebugSubModeMaster)),
			new Mode("Kamcord", typeof(DebugSubKamcord)),
			new Mode("Colosseum", typeof(DebugSubColosseum)),
			new Mode("LocalRaid", typeof(DebugSubLocalRaid)),
			new Mode("Sample", typeof(DebugSubSample))
		};
		evNow = new Dictionary<string, bool>();
		evOn = new Dictionary<string, bool>();
		gm = new RuntimeDebugModeGuiMixin();
	}

	public void _0024singleton_0024awake_0024663()
	{
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_0024663();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static RuntimeDebugMode _createInstance()
	{
		string text = "__" + "RuntimeDebugMode" + "__";
		GameObject gameObject = new GameObject(text);
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		RuntimeDebugMode runtimeDebugMode = ExtensionsModule.SetComponent<RuntimeDebugMode>(gameObject);
		if ((bool)runtimeDebugMode)
		{
			runtimeDebugMode._createInstance_callback();
		}
		return runtimeDebugMode;
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

	public void _0024singleton_0024appQuit_0024664()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_0024664();
		quitApp = true;
	}

	private void setEvent(string key, bool b)
	{
		if (!string.IsNullOrEmpty(key))
		{
			if (!evNow.ContainsKey(key))
			{
				evNow[key] = false;
				evOn[key] = false;
			}
			Dictionary<string, bool> dictionary = evOn;
			bool num = b;
			if (num)
			{
				num = !evNow[key];
			}
			dictionary[key] = num;
			evNow[key] = b;
		}
	}

	private static bool NeedDebugMode()
	{
		return true;
	}

	public void Start()
	{
	}

	public bool checkEnterTouch3()
	{
		return false;
	}

	private bool checkTouchMulti(int aFingerCount)
	{
		return false;
	}

	public void Update()
	{
		if (NeedDebugMode())
		{
		}
	}

	public void LateUpdate()
	{
		if (NeedDebugMode())
		{
		}
	}

	public void FixedUpdate()
	{
		if (NeedDebugMode())
		{
		}
	}

	public void OnGUI()
	{
		if (NeedDebugMode())
		{
		}
	}

	public void showMainMode()
	{
		if (NeedDebugMode())
		{
		}
	}

	public void setHeightWidthFromResolution()
	{
		checked
		{
			MAIN_VIEW_WIDTH = (int)((double)Screen.width * 0.77);
			SHORTCUT_VIEW_WIDTH = (int)((double)Screen.width * 0.22);
		}
	}

	private IEnumerator debugModeControl()
	{
		if (!NeedDebugMode())
		{
		}
		return null;
	}

	public void stopCurrentMode()
	{
		if (NeedDebugMode())
		{
		}
	}

	public void mainView(string title, ICallable disp)
	{
		if (NeedDebugMode())
		{
		}
	}

	public bool titleView(string title)
	{
		return !NeedDebugMode() && false;
	}

	public void applicationInfoView()
	{
		if (NeedDebugMode())
		{
		}
	}

	public string applicationInfo()
	{
		return (!NeedDebugMode()) ? null : string.Empty;
	}

	public static void staticPublicMethods(Type type)
	{
		if (NeedDebugMode())
		{
		}
	}

	public void shortcutView()
	{
		if (NeedDebugMode())
		{
		}
	}

	public static void DebugChangeScene(string scene)
	{
		if (NeedDebugMode())
		{
		}
	}

	public void ChangeScene(string scene)
	{
		if (NeedDebugMode())
		{
		}
	}
}
