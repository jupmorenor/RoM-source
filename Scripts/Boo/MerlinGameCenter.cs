using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GooglePlayGames;
using UnityEngine;

[Serializable]
public class MerlinGameCenter : MonoBehaviour
{
	[Serializable]
	internal class _0024_GameCenter_Auth_0024locals_002414572
	{
		internal string _0024successToken;
	}

	[Serializable]
	internal class _0024checkStoryProgression_0024locals_002414573
	{
		internal Boo.Lang.List<string> _0024res;

		internal UserData _0024ud;
	}

	[Serializable]
	internal class _0024_GameCenter_Auth_0024closure_00242852
	{
		internal _0024_GameCenter_Auth_0024locals_002414572 _0024_0024locals_002415265;

		public _0024_GameCenter_Auth_0024closure_00242852(_0024_GameCenter_Auth_0024locals_002414572 _0024_0024locals_002415265)
		{
			this._0024_0024locals_002415265 = _0024_0024locals_002415265;
		}

		public void Invoke(bool success)
		{
			if (success)
			{
				Instance.OnAuthResult(_0024_0024locals_002415265._0024successToken);
			}
			else
			{
				Instance.OnAuthResult("fail");
			}
		}
	}

	[Serializable]
	internal class _0024checkStoryProgression_0024_each_00242855
	{
		internal _0024checkStoryProgression_0024locals_002414573 _0024_0024locals_002415266;

		public _0024checkStoryProgression_0024_each_00242855(_0024checkStoryProgression_0024locals_002414573 _0024_0024locals_002415266)
		{
			this._0024_0024locals_002415266 = _0024_0024locals_002415266;
		}

		public bool Invoke(string fname)
		{
			MQuests mQuests = MQuests.FindByProgname(fname);
			int result;
			if (mQuests == null)
			{
				result = 0;
			}
			else
			{
				string text = MFlagsUtil.QuestClearFlagName(mQuests);
				if (string.IsNullOrEmpty(text))
				{
					result = 0;
				}
				else if (_0024_0024locals_002415266._0024ud.getIntFlag(text, 0) == 0)
				{
					result = 0;
				}
				else
				{
					MHonors mHonors = MHonors.FindByFlagName(text);
					if (mHonors == null)
					{
						result = 1;
					}
					else
					{
						string text2 = null;
						text2 = mHonors.AndroidName;
						if (string.IsNullOrEmpty(text2))
						{
							result = 1;
						}
						else
						{
							_0024_0024locals_002415266._0024res.Add(text2);
							result = 1;
						}
					}
				}
			}
			return (byte)result != 0;
		}
	}

	[NonSerialized]
	private static MerlinGameCenter __instance;

	[NonSerialized]
	protected static bool quitApp;

	[NonSerialized]
	private static string callbackObjectName;

	public bool authenticated;

	private __MerlinGameCenter_authenticateCallback_0024callable125_002485_37__ authenticateCallback;

	[NonSerialized]
	private const string SuccessToken = "success";

	[NonSerialized]
	private const string PlayerPrefsKeyFirstBoot = "GameCenter#AuthOnBoot";

	[NonSerialized]
	private const string PlayerPrefsKeyIgnoreGameCenter = "GameCenter#IgnoreMe";

	public static MerlinGameCenter Instance
	{
		get
		{
			MerlinGameCenter _instance;
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
				__instance = ((MerlinGameCenter)UnityEngine.Object.FindObjectOfType(typeof(MerlinGameCenter))) as MerlinGameCenter;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static MerlinGameCenter CurrentInstance => __instance;

	public bool Authenticated => authenticated;

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00242721();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static MerlinGameCenter _createInstance()
	{
		string text = "__" + "MerlinGameCenter" + "__";
		GameObject gameObject = new GameObject(text);
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		MerlinGameCenter merlinGameCenter = ExtensionsModule.SetComponent<MerlinGameCenter>(gameObject);
		if ((bool)merlinGameCenter)
		{
			merlinGameCenter._createInstance_callback();
		}
		return merlinGameCenter;
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

	public void _0024singleton_0024appQuit_00242722()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00242722();
		quitApp = true;
	}

	[DllImport("__Internal")]
	private static extern void _GameCenter_OpenAchievementsIOSImpl(string[] identifiers, int num);

	[DllImport("__Internal")]
	private static extern void _GameCenter_InitGameCenterIOSImpl(string objectName);

	[DllImport("__Internal")]
	private static extern void _GameCenter_AuthIOSImpl(string callbackName, string successToken);

	[DllImport("__Internal")]
	private static extern void _GameCenter_RestoreSessionIOSImpl(string callbackName, string successToken);

	[DllImport("__Internal")]
	private static extern void _GameCenter_ShowAchievementsUIIOSImpl();

	private static void _GameCenter_OpenAchievements(string[] identifiers, int num)
	{
		__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ from = delegate
		{
		};
		int length = identifiers.Length;
		int num2 = 0;
		while (num2 < length)
		{
			string achievementID = identifiers[RuntimeServices.NormalizeArrayIndex(identifiers, checked(num2++))];
			((PlayGamesPlatform)Social.Active).ReportProgress(achievementID, 100.0, _0024adaptor_0024__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34___0024Action_0024214.Adapt(from));
		}
	}

	private static void _GameCenter_InitGameCenter(string objectName)
	{
		PlayGamesPlatform.DebugLogEnabled = false;
		PlayGamesPlatform.Activate();
	}

	private static void _GameCenter_Auth(string callbackName, string successToken)
	{
		_0024_GameCenter_Auth_0024locals_002414572 _0024_GameCenter_Auth_0024locals_0024 = new _0024_GameCenter_Auth_0024locals_002414572();
		_0024_GameCenter_Auth_0024locals_0024._0024successToken = successToken;
		Social.localUser.Authenticate(new _0024_GameCenter_Auth_0024closure_00242852(_0024_GameCenter_Auth_0024locals_0024).Invoke);
	}

	private static void _GameCenter_RestoreSession(string callbackName, string successToken)
	{
		GameObject gameObject = GameObject.Find(callbackObjectName);
		if ((bool)gameObject)
		{
			gameObject.SendMessage(callbackName, "fail");
		}
	}

	private static void _GameCenter_ShowAchievementsUI()
	{
		Social.ShowAchievementsUI();
	}

	public void _0024singleton_0024awake_00242721()
	{
		Initialize();
	}

	private void Initialize()
	{
		_GameCenter_InitGameCenter(Instance.gameObject.name);
	}

	public void OnAuthResult(string result)
	{
		authenticated = false;
		if (result == "success")
		{
			authenticated = true;
		}
		if (authenticateCallback != null)
		{
			authenticateCallback(Instance);
		}
	}

	public void Auth(__MerlinGameCenter_authenticateCallback_0024callable125_002485_37__ cb)
	{
		authenticateCallback = cb;
		if (authenticated)
		{
			if (authenticateCallback != null)
			{
				authenticateCallback(Instance);
			}
		}
		else
		{
			_GameCenter_Auth("OnAuthResult", "success");
		}
	}

	public void AuthOnBoot()
	{
		PlayerPrefs.SetString("GameCenter#AuthOnBoot", "1");
		if (!string.IsNullOrEmpty(PlayerPrefs.GetString("GameCenter#IgnoreMe")))
		{
			return;
		}
		if (string.IsNullOrEmpty(PlayerPrefs.GetString("GameCenter#AuthOnBoot")))
		{
			authenticateCallback = null;
			Social.localUser.Authenticate(delegate(bool x)
			{
				PlayerPrefs.SetString("GameCenter#AuthOnBoot", "1");
				if (!x)
				{
					PlayerPrefs.SetString("GameCenter#IgnoreMe", "1");
				}
			});
		}
		else
		{
			if (Authenticated)
			{
				return;
			}
			authenticateCallback = null;
			Social.localUser.Authenticate(delegate(bool x)
			{
				if (x)
				{
					OnAuthResult("success");
				}
				else
				{
					OnAuthResult("failed");
				}
			});
		}
	}

	public static void ClearAuthOnBootFlag()
	{
		PlayerPrefs.SetString("GameCenter#AuthOnBoot", null);
	}

	public void OpenAchievements(string[] identifiers)
	{
		if (authenticated)
		{
			_GameCenter_OpenAchievements(identifiers, identifiers.Length);
		}
	}

	public void ShowAchievements()
	{
		if (authenticated)
		{
			_GameCenter_ShowAchievementsUI();
		}
	}

	public void CheckAchievements()
	{
		Boo.Lang.List<string> list = new Boo.Lang.List<string>();
		list += (IEnumerable)checkStoryProgression();
		IEnumerator<string> enumerator = list.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		if (0 < list.Count)
		{
			OpenAchievements(list.ToArray());
		}
	}

	private Boo.Lang.List<string> checkStoryProgression()
	{
		_0024checkStoryProgression_0024locals_002414573 _0024checkStoryProgression_0024locals_0024 = new _0024checkStoryProgression_0024locals_002414573();
		_0024checkStoryProgression_0024locals_0024._0024res = new Boo.Lang.List<string>();
		_0024checkStoryProgression_0024locals_0024._0024ud = UserData.Current;
		__WebView_CommandLinkHandler_0024callable126_002420_34__ _WebView_CommandLinkHandler_0024callable126_002420_34__ = new _0024checkStoryProgression_0024_each_00242855(_0024checkStoryProgression_0024locals_0024).Invoke;
		int num = default(int);
		while (true)
		{
			string text = null;
			text = ((num <= 0) ? $"Story{0:D3}Tutorial" : string.Format("Story{0:D3}Main{0:D3}", num));
			bool flag = _WebView_CommandLinkHandler_0024callable126_002420_34__(text);
			if (!flag && num > 0)
			{
				break;
			}
			num = checked(num + 1);
		}
		return _0024checkStoryProgression_0024locals_0024._0024res;
	}

	internal static void _0024_GameCenter_OpenAchievements_0024cb_00242850(bool success)
	{
	}

	internal void _0024AuthOnBoot_0024closure_00242853(bool x)
	{
		PlayerPrefs.SetString("GameCenter#AuthOnBoot", "1");
		if (!x)
		{
			PlayerPrefs.SetString("GameCenter#IgnoreMe", "1");
		}
	}

	internal void _0024AuthOnBoot_0024closure_00242854(bool x)
	{
		if (x)
		{
			OnAuthResult("success");
		}
		else
		{
			OnAuthResult("failed");
		}
	}
}
