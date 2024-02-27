using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class MerlinLocalNotification : MonoBehaviour
{
	[NonSerialized]
	private static MerlinLocalNotification __instance;

	[NonSerialized]
	protected static bool quitApp;

	[NonSerialized]
	public static MerlinLocalNotification globalInstance;

	[NonSerialized]
	public static bool activateNotification;

	[NonSerialized]
	private static int nBadgeCount_;

	[NonSerialized]
	public static string ApKey = "local_notification_ap";

	[NonSerialized]
	public static string RpKey = "local_notification_rp";

	[NonSerialized]
	public static string BpKey = "local_notification_bp";

	[NonSerialized]
	public static string EmergencyKey = "local_notification_emergency";

	[NonSerialized]
	private static string[] emQuadNumberArray_ = new string[10] { "０", "１", "２", "３", "４", "５", "６", "７", "８", "９" };

	public static MerlinLocalNotification Instance
	{
		get
		{
			MerlinLocalNotification _instance;
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
				__instance = ((MerlinLocalNotification)UnityEngine.Object.FindObjectOfType(typeof(MerlinLocalNotification))) as MerlinLocalNotification;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static MerlinLocalNotification CurrentInstance => __instance;

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00242726();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static MerlinLocalNotification _createInstance()
	{
		string text = "__" + "MerlinLocalNotification" + "__";
		GameObject gameObject = new GameObject(text);
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		MerlinLocalNotification merlinLocalNotification = ExtensionsModule.SetComponent<MerlinLocalNotification>(gameObject);
		if ((bool)merlinLocalNotification)
		{
			merlinLocalNotification._createInstance_callback();
		}
		return merlinLocalNotification;
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

	public void _0024singleton_0024appQuit_00242727()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00242727();
		quitApp = true;
	}

	public void _0024singleton_0024awake_00242726()
	{
	}

	public void Start()
	{
	}

	public void OnApplicationPause(bool pauseStatus)
	{
		if (activateNotification && MGameParameters.findByGameParameterId(19) != null)
		{
		}
	}

	private void addAp_()
	{
		addEvent(UserData.Current.EndApRecoveryDateTime, ApKey, "行動力が全回復しました！");
	}

	private void addRp_()
	{
		addEvent(UserData.Current.EndRpRecoveryDateTime, RpKey, "精神力が全回復しました！");
	}

	private void addBp_()
	{
		addEvent(UserData.Current.EndBpRecoveryDateTime, BpKey, "魔魂力が全回復しました！");
	}

	private void addEvent(DateTime endDate, string key, string altMsg)
	{
		UserData current = UserData.Current;
		if (checkRecoveryTime(endDate))
		{
			string text = null;
			MTexts mTexts = MTexts.Get(key);
			text = ((mTexts == null) ? altMsg : mTexts.msg);
			add(endDate, text, aBadge: true);
		}
	}

	private bool checkRecoveryTime(DateTime aUtcTime)
	{
		bool result = false;
		if (MerlinDateTime.UtcNow < aUtcTime)
		{
			result = true;
		}
		return result;
	}

	public static void createGlobalInstance()
	{
		if (globalInstance == null)
		{
			globalInstance = new MerlinLocalNotification();
		}
	}

	public static void add(DateTime aUtcTime, string aMsg, bool aBadge)
	{
	}

	public static void clear()
	{
	}

	public static string toEmQuadNumber(int aNumber)
	{
		int num = aNumber;
		int num2 = 1;
		while (true)
		{
			num /= 10;
			if (num == 0)
			{
				break;
			}
			num2 = checked(num2 + 1);
		}
		string text = null;
		num = aNumber;
		int num3 = 0;
		int num4 = num2;
		if (num4 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num3 < num4)
		{
			int num5 = num3;
			num3++;
			int index = num % 10;
			string[] array = emQuadNumberArray_;
			text = array[RuntimeServices.NormalizeArrayIndex(array, index)] + text;
			num /= 10;
		}
		return text;
	}
}
