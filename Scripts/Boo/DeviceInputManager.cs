using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class DeviceInputManager : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024CantTouchCoroutine_002421334 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_until_0024temp_00242486_002421335;

			internal float _0024_0024wait_until_0024temp_00242487_002421336;

			internal DeviceInputManager _0024self__002421337;

			public _0024(DeviceInputManager self_)
			{
				_0024self__002421337 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002421337.cantTouch = true;
					_0024_0024wait_until_0024temp_00242486_002421335 = _0024self__002421337.waitTime;
					_0024_0024wait_until_0024temp_00242487_002421336 = Time.realtimeSinceStartup;
					goto case 2;
				case 2:
					if (0 == 0 && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00242487_002421336 < _0024_0024wait_until_0024temp_00242486_002421335)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002421337.cantTouch = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal DeviceInputManager _0024self__002421338;

		public _0024CantTouchCoroutine_002421334(DeviceInputManager self_)
		{
			_0024self__002421338 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421338);
		}
	}

	[NonSerialized]
	private static DeviceInputManager __instance;

	[NonSerialized]
	protected static bool quitApp;

	public bool showButtonOnDisplay;

	private bool pushEsc;

	private float waitTime;

	private Dialog dialog;

	private bool cantTouch;

	private DialogManager dlgMan;

	private GameObject modCol;

	private __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ escHaandler;

	public bool showLog;

	public bool showLogDoRetrun;

	public bool outLogErr;

	public static DeviceInputManager Instance
	{
		get
		{
			DeviceInputManager _instance;
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
				__instance = ((DeviceInputManager)UnityEngine.Object.FindObjectOfType(typeof(DeviceInputManager))) as DeviceInputManager;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static DeviceInputManager CurrentInstance => __instance;

	private bool doReturn
	{
		get
		{
			int result;
			if (cantTouch)
			{
				ShowLogDoRetrun("if cantTouch:");
				result = 1;
			}
			else if (typeof(InventoryOverDialog) == null && !LoginBonusDialog.IsOpened && !EventWindow.isWindow && !StartButton.Paused && DialogManager.DialogCount <= 0 && (bool)modCol && modCol.activeSelf)
			{
				ShowLogDoRetrun("if modCol and modCol.activeSelf:");
				result = 1;
			}
			else if (!SceneChanger.isCompletelyReady)
			{
				ShowLogDoRetrun("if not SceneChanger.isCompletelyReady");
				result = 1;
			}
			else if (MerlinServer.Instance.IsBusy)
			{
				ShowLogDoRetrun("if MerlinServer.Instance.IsBusy:");
				result = 1;
			}
			else if (!FaderCore.Instance.isCompleted)
			{
				ShowLogDoRetrun("if not FaderCore.Instance.isCompleted:");
				result = 1;
			}
			else if (UIButtonMessage.AllDisable)
			{
				ShowLogDoRetrun("if UIButtonMessage.AllDisable:");
				result = 1;
			}
			else if ((bool)PlayerControl.CurrentPlayer && !PlayerControl.CurrentPlayer.IsReady)
			{
				ShowLogDoRetrun("if UIButtonMessage.AllDisable:");
				result = 1;
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	public __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ EscHandler
	{
		get
		{
			return escHaandler;
		}
		set
		{
			escHaandler = value;
		}
	}

	public DeviceInputManager()
	{
		waitTime = 0.6f;
		outLogErr = true;
	}

	public void _0024singleton_0024awake_00242484()
	{
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00242484();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static DeviceInputManager _createInstance()
	{
		string text = "__" + "DeviceInputManager" + "__";
		GameObject gameObject = new GameObject(text);
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		DeviceInputManager deviceInputManager = ExtensionsModule.SetComponent<DeviceInputManager>(gameObject);
		if ((bool)deviceInputManager)
		{
			deviceInputManager._createInstance_callback();
		}
		return deviceInputManager;
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

	public void _0024singleton_0024appQuit_00242485()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00242485();
		quitApp = true;
	}

	private IEnumerator CantTouchCoroutine()
	{
		return new _0024CantTouchCoroutine_002421334(this).GetEnumerator();
	}

	private void Start()
	{
		modCol = ModalCollider.GetCollider();
		dlgMan = DialogManager.Instance;
		cantTouch = false;
		dialog = null;
	}

	private void LateUpdate()
	{
		pushEsc = false;
	}

	private void Update()
	{
		if (doReturn || (MerlinPlatformModule.CurrentMerlinPlatform() != MerlinPlatform.Android && (!Application.isEditor || !Application.isPlaying)) || (!Input.GetKeyUp(KeyCode.Escape) && !pushEsc))
		{
			return;
		}
		ShowLog("Input.GetKey(KeyCode.Escape)");
		IEnumerator enumerator = CantTouchCoroutine();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
		if (escHaandler != null)
		{
			ShowLog("if escHaandler:");
			escHaandler();
			return;
		}
		if (0 < DialogManager.DialogCount)
		{
			ShowLog("0 < dlgMan.DialogCount");
			if ((bool)DialogManager.CurrentDialog && DialogManager.CurrentDialog.name != "SignQuestFind(Clone)")
			{
				if (!RuntimeServices.EqualityOperator(DialogManager.CurrentDialog.Result, 0))
				{
					ShowLog("if 0 < dlgMan.DialogCount:");
					DialogManager.CurrentDialog.OnButton(1);
				}
				else
				{
					ShowLog("else if not 0 < dlgMan.DialogCount:");
				}
				return;
			}
		}
		if ((bool)dialog)
		{
			return;
		}
		if (LoginBonusDialog.IsOpened)
		{
			ShowLog("if LoginBonusDialog.IsOpened:");
			LoginBonusDialog.PushOK();
			return;
		}
		if (WebViewBase.Instance != null && WebViewBase.Instance.fullScreenMode != 0)
		{
			ShowLog("if WebViewBase.Instance.fullScreenMode != WebViewBase.FULLSCREEN_MODE.NONE:");
			return;
		}
		checked
		{
			if (SceneChanger.CurrentScene == SceneID.Ui_WorldQuestResult || SceneChanger.CurrentScene == SceneID.Ui_WorldChallengeResult || SceneChanger.CurrentScene == SceneID.Ui_WorldRaidResult)
			{
				WorldQuestResultMain worldQuestResultMain = (WorldQuestResultMain)UnityEngine.Object.FindObjectOfType(typeof(WorldQuestResultMain));
				if ((bool)worldQuestResultMain)
				{
					if ((bool)worldQuestResultMain.leveupWindow && worldQuestResultMain.leveupWindow.activeSelf)
					{
						ShowLog("if result.leveupWindow and result.leveupWindow.activeSelf:");
						worldQuestResultMain.gameObject.SendMessage("LevelUpClose", this.gameObject, SendMessageOptions.DontRequireReceiver);
						return;
					}
					if ((bool)worldQuestResultMain.specialRewardWindow && worldQuestResultMain.specialRewardWindow.activeSelf)
					{
						ShowLog("if result.specialRewardWindow and result.specialRewardWindow.activeSelf:");
						worldQuestResultMain.gameObject.SendMessage("PushRewardOk", this.gameObject, SendMessageOptions.DontRequireReceiver);
						return;
					}
					if ((bool)worldQuestResultMain.friendPanel && worldQuestResultMain.friendPanel.gameObject.activeSelf)
					{
						ShowLog("if result.friendPanel and result.noFriendPanel.gameObject.activeSelf:");
						UIButtonMessage componentInChildren = worldQuestResultMain.friendPanel.gameObject.GetComponentInChildren<UIButtonMessage>();
						if ((bool)componentInChildren)
						{
							componentInChildren.DoSend();
							return;
						}
					}
					if ((bool)worldQuestResultMain.noFriendPanel && worldQuestResultMain.noFriendPanel.gameObject.activeSelf)
					{
						ShowLog("if result.noFriendPanel and result.noFriendPanel.gameObject.activeSelf:");
						UIButtonMessage[] componentsInChildren = worldQuestResultMain.noFriendPanel.gameObject.GetComponentsInChildren<UIButtonMessage>();
						if (componentsInChildren != null)
						{
							int i = 0;
							UIButtonMessage[] array = componentsInChildren;
							for (int length = array.Length; i < length; i++)
							{
								if ((bool)array[i] && !(array[i].name != "ButtonN"))
								{
									array[i].DoSend();
									return;
								}
							}
						}
					}
				}
			}
			if (BattleHUDShortcut.IsOpen)
			{
				ShowLog("if BattleHUDShortcut.IsOpen:");
				BattleHUDShortcut.Close();
				return;
			}
			if (!EventWindow.isWindow)
			{
				ShowLog("not EventWindow.isWindow");
				if ((bool)InventoryOverDialog.Instance)
				{
					ShowLog("if InventoryOverDialog.Instance:");
					InventoryOverDialog.PushBack();
					return;
				}
				if (IPauseWindow.IsPaused)
				{
					if (CheckControllerSettingsWindow(isPause: true))
					{
						ShowLog("if IPauseWindow.IsPaused:");
						return;
					}
					if (CommentSelectDialog.IsRunning)
					{
						CommentSelectDialog commentSelectDialog = (CommentSelectDialog)UnityEngine.Object.FindObjectOfType(typeof(CommentSelectDialog));
						if ((bool)commentSelectDialog)
						{
							ShowLog("if commentSelectDialog:");
							GameObject gameObject = ExtensionsModule.FindChild(commentSelectDialog.gameObject, "EnterButton");
							UIButtonMessage[] componentsInChildren = gameObject.GetComponents<UIButtonMessage>();
							if (componentsInChildren == null)
							{
								return;
							}
							UIButtonMessage componentInChildren = null;
							int j = 0;
							UIButtonMessage[] array2 = componentsInChildren;
							for (int length2 = array2.Length; j < length2; j++)
							{
								if ((bool)array2[j] && array2[j].functionName == "ReleaseEnter")
								{
									array2[j].DoSend();
									break;
								}
							}
							return;
						}
					}
				}
				bool flag = true;
				PowupBase powupBase = (PowupBase)UnityEngine.Object.FindObjectOfType(typeof(PowupBase));
				if ((bool)powupBase && powupBase.SequenceMode == PowupBase.POWUP_MODE.PowupDemo)
				{
					ShowLog("if powupBase and powupBase.SequenceMode == PowupBase.POWUP_MODE.PowupDemo:");
					flag = false;
				}
				if (flag)
				{
					if ((bool)ButtonBackHUD.Instance && ButtonBackHUD.Instance.gameObject.activeSelf)
					{
						ShowLog("if ButtonBackHUD.Instance and ButtonBackHUD.Instance.gameObject.activeSelf:");
						UIButtonMessage componentInChildren = ButtonBackHUD.GetButton();
						if ((bool)componentInChildren && componentInChildren.enabled)
						{
							ShowLog("if btn and btn.enabled:");
							Collider collider = componentInChildren.collider;
							if ((bool)collider && collider.enabled)
							{
								ShowLog("if ButtonBackHUD.Instance:");
								componentInChildren.DoSend();
							}
							else
							{
								if (SceneChanger.CurrentScene != SceneID.Ui_MessageBoard)
								{
									return;
								}
								TeamAdminDialog teamAdminDialog = (TeamAdminDialog)UnityEngine.Object.FindObjectOfType(typeof(TeamAdminDialog));
								if (!teamAdminDialog || !teamAdminDialog.gameObject.activeSelf)
								{
									return;
								}
								ShowLog("if teamAdminDialog and teamAdminDialog.activeSelf:");
								UIButtonMessage[] componentsInChildren = teamAdminDialog.gameObject.GetComponentsInChildren<UIButtonMessage>();
								if (componentsInChildren == null)
								{
									return;
								}
								int k = 0;
								UIButtonMessage[] array3 = componentsInChildren;
								for (int length3 = array3.Length; k < length3; k++)
								{
									if ((bool)array3[k] && array3[k].functionName == "Cancel")
									{
										array3[k].DoSend();
										break;
									}
								}
							}
							return;
						}
					}
					else if (SceneChanger.CurrentScene == SceneID.Lottery_UI)
					{
						ShowLog("SceneChanger.CurrentScene == SceneID.Lottery_UI:");
						LotteryBase lotteryBase = (LotteryBase)UnityEngine.Object.FindObjectOfType(typeof(LotteryBase));
						if ((bool)lotteryBase && lotteryBase.ItemDetails != null)
						{
							ShowLog("if lottery and lottery.ItemDetails:");
							if (lotteryBase.ItemDetails[0].gameObject.activeSelf || lotteryBase.ItemDetails[1].gameObject.activeSelf)
							{
								lotteryBase.PushBack();
								return;
							}
						}
					}
				}
				if (StartButton.IsEnablePause() && (bool)StartButton.Instance)
				{
					ShowLog("if StartButton.IsEnablePause():");
					StartButton.Instance.pushStartButton();
					return;
				}
			}
			else
			{
				ShowLog("EventWindow.isWindow");
			}
			if (SceneChanger.CurrentScene == SceneID.Ui_Download)
			{
				ShowLog("if SceneChanger.CurrentScene == SceneID.Ui_Download:");
				if (CheckControllerSettingsWindow(isPause: false))
				{
					ShowLog("if CheckControllerSettingsWindow( false ):");
				}
				return;
			}
			if (SceneChanger.CurrentScene == SceneID.RaidBattle)
			{
				ShowLog("if SceneChanger.CurrentScene == SceneID.RaidBattle:");
				return;
			}
			ShowLog("dlgMan.OpenDialog");
			dialog = dlgMan.OpenDialog("アプリを終了します。\nよろしいですか？", "アプリを終了します", DialogManager.MB_FLAG.MB_NONE, new string[2] { "いいえ", "はい" });
			dialog.ButtonHandler = delegate(int btn)
			{
				if (btn == 2)
				{
					ShowLog("Application.Quit()");
					Application.Quit();
				}
				else
				{
					dialog = null;
				}
			};
		}
	}

	private bool CheckControllerSettingsWindow(bool isPause)
	{
		PadSettingMenu padSettingMenu = (PadSettingMenu)UnityEngine.Object.FindObjectOfType(typeof(PadSettingMenu));
		int result;
		if ((bool)padSettingMenu && padSettingMenu.gameObject.activeSelf)
		{
			ShowLog("if padMenu and padMenu.activeSelf:");
			if (isPause)
			{
				PadSettingMenuBoard componentInChildren = padSettingMenu.GetComponentInChildren<PadSettingMenuBoard>();
				if ((bool)componentInChildren && componentInChildren.gameObject.activeSelf)
				{
					ShowLog("if padBoard and padBoard.gameObject.activeSelf:");
					padSettingMenu.gameObject.SendMessage("PushBack", null, SendMessageOptions.DontRequireReceiver);
					result = 1;
					goto IL_00f1;
				}
			}
			else
			{
				Transform transform = padSettingMenu.transform.Find("PadSettingMenu/5 ButtonOK");
				if ((bool)transform && transform.gameObject.activeSelf)
				{
					ShowLog("if okButton and okButton.gameObject.activeSelf:");
					UIButtonMessage component = transform.gameObject.GetComponent<UIButtonMessage>();
					if ((bool)component)
					{
						ShowLog("if btn:");
						component.DoSend();
						result = 1;
						goto IL_00f1;
					}
				}
			}
		}
		result = 0;
		goto IL_00f1;
		IL_00f1:
		return (byte)result != 0;
	}

	private void ShowLog(string t)
	{
		if (showLog && !outLogErr)
		{
		}
	}

	private void ShowLogDoRetrun(string t)
	{
		if (showLogDoRetrun)
		{
			ShowLog("doReturn: " + t);
		}
	}

	private float CalcWidth(float w)
	{
		return w / 960f * (float)Screen.width;
	}

	private float CalcHeight(float h)
	{
		return h / 640f * (float)Screen.height;
	}

	public void OnGUI_()
	{
		if (showButtonOnDisplay)
		{
		}
	}

	internal void _0024Update_0024closure_00244276(int btn)
	{
		if (btn == 2)
		{
			ShowLog("Application.Quit()");
			Application.Quit();
		}
		else
		{
			dialog = null;
		}
	}
}
