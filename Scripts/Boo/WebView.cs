using System;
using System.Collections;
using ChatTest;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class WebView : WebViewBase
{
	protected Hashtable dlgTable;

	public UIButtonMessage pushBackButton;

	public bool commandCloseIsEndWebView;

	public bool shortcutOpenIsHide;

	public bool severBusyIsHide;

	public __WebView_CommandLinkHandler_0024callable126_002420_34__ commandLinkHandler;

	protected bool checkMente;

	private string lastCommand;

	public bool Reset
	{
		set
		{
			if (value)
			{
				dlgTable.Clear();
			}
		}
	}

	public bool fullScreen
	{
		get
		{
			return fullScreenMode == FULLSCREEN_MODE.FULL_FIT;
		}
		set
		{
			if (value)
			{
				fullScreenMode = FULLSCREEN_MODE.FULL_FIT;
			}
			else
			{
				fullScreenMode = FULLSCREEN_MODE.NONE;
			}
		}
	}

	public UIButtonMessage PushBackButton
	{
		get
		{
			return pushBackButton;
		}
		set
		{
			pushBackButton = value;
		}
	}

	public bool CommandCloseIsEndWebView
	{
		get
		{
			return commandCloseIsEndWebView;
		}
		set
		{
			commandCloseIsEndWebView = value;
		}
	}

	public bool ShortcutOpenIsHide
	{
		get
		{
			return shortcutOpenIsHide;
		}
		set
		{
			shortcutOpenIsHide = value;
		}
	}

	public bool SeverBusyIsHide
	{
		get
		{
			return severBusyIsHide;
		}
		set
		{
			severBusyIsHide = value;
		}
	}

	public __WebView_CommandLinkHandler_0024callable126_002420_34__ CommandLinkHandler
	{
		get
		{
			return commandLinkHandler;
		}
		set
		{
			commandLinkHandler = value;
		}
	}

	public WebView()
	{
		dlgTable = new Hashtable();
	}

	public void Awake()
	{
		commandLinkHandler = extraSceneChangeCommand;
	}

	public new void OnEnable()
	{
		base.OnEnable();
		lastCommand = string.Empty;
		checkMente = false;
		GameObject[] dialogArray = DialogManager.DialogArray;
		int i = 0;
		GameObject[] array = dialogArray;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			dlgTable[array[i].GetInstanceID()] = array[i];
		}
		if (WebViewAbortCheck())
		{
			WebViewBase.Visible(flag: false);
		}
	}

	public new void OnDisable()
	{
		base.OnDisable();
		Reset = true;
	}

	public bool CheckMaintenance()
	{
		if (!WebViewBase.pageFinished && !WebViewBase.pageError)
		{
			checkMente = false;
		}
		if (checkMente || (!WebViewBase.pageFinished && !WebViewBase.pageError))
		{
			goto IL_00b0;
		}
		checkMente = true;
		int result;
		if (!string.IsNullOrEmpty(WebViewBase.strHtmlSource) && WebViewBase.strHtmlSource.Contains("<title>聖剣伝説 RISE of MANA - メンテナンス</title>"))
		{
			MerlinServer.RetryDialog("メンテナンス中です。", "エラー", (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				SceneChanger.Kill();
				SceneChanger.Change("Boot");
			});
			result = 1;
		}
		else
		{
			if (!WebViewBase.pageError)
			{
				goto IL_00b0;
			}
			MerlinServer.RetryDialog("Webコンテンツを正しく\n表示できませんでした。", "エラー", (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
			});
			result = 1;
		}
		goto IL_00b1;
		IL_00b1:
		return (byte)result != 0;
		IL_00b0:
		result = 0;
		goto IL_00b1;
	}

	public override bool WebViewAbortCheck()
	{
		int result;
		if (CheckMaintenance())
		{
			result = 1;
		}
		else
		{
			GameObject[] dialogArray = DialogManager.DialogArray;
			int num = 0;
			GameObject[] array = dialogArray;
			int length = array.Length;
			while (true)
			{
				if (num < length)
				{
					if (!dlgTable.ContainsKey(array[num].GetInstanceID()))
					{
						result = 1;
						break;
					}
					num = checked(num + 1);
					continue;
				}
				result = (InventoryOverDialog.IsOpenInventoryOverDialog() ? 1 : ((shortcutOpenIsHide && BattleHUDShortcut.IsOpen) ? 1 : ((severBusyIsHide && (bool)MerlinServer.CurrentInstance && MerlinServer.CurrentInstance.IsBusy) ? 1 : 0)));
				break;
			}
		}
		return (byte)result != 0;
	}

	public override void CommandLinkFunc(string command)
	{
		if (string.IsNullOrEmpty(command))
		{
			return;
		}
		string text = "command:";
		if (command.StartsWith(text))
		{
			command = command.Substring(text.Length);
		}
		if (commandLinkHandler != null && commandLinkHandler(command))
		{
			return;
		}
		if (command == "close")
		{
			if (null != pushBackButton)
			{
				pushBackButton.DoSend();
			}
			else if (commandCloseIsEndWebView)
			{
				WebViewBase.EndWebView();
			}
			lastUrl = string.Empty;
			WebViewBase.ClearNextUrl();
		}
		else
		{
			string text2 = "browser:";
			if (command.StartsWith(text2))
			{
				command = command.Substring(text2.Length);
				Application.OpenURL(command);
				WebViewBase.ClearNextUrl();
				lastUrl = string.Empty;
			}
		}
	}

	public bool extraSceneChangeCommand(string command)
	{
		int result;
		if (string.IsNullOrEmpty(command))
		{
			result = 0;
		}
		else if (command == lastCommand)
		{
			result = 0;
		}
		else
		{
			lastCommand = command;
			int result2 = -1;
			if (command.StartsWith("gacha"))
			{
				int.TryParse(command.Substring(5), out result2);
				command = "gacha";
			}
			switch (command)
			{
			case "specialquest":
				QuestManager.Instance.SetAndJumpArea(QuestManager.getArea(EnumAreaTypes.SpecialQuest));
				result = 1;
				break;
			case "boostquest":
				QuestManager.Instance.SetAndJumpArea(QuestManager.getArea(EnumAreaTypes.BoostQuest));
				result = 1;
				break;
			case "challenge":
				QuestManager.Instance.SetAndJumpArea(QuestManager.getArea(EnumAreaTypes.Challenge));
				result = 1;
				break;
			case "colosseum":
				QuestManager.Instance.SetAndJumpArea(QuestManager.getArea(EnumAreaTypes.Colosseum));
				result = 1;
				break;
			case "gacha":
				if (result2 >= 0)
				{
					LotterySequence.StartId = result2;
				}
				ShortcutIcon.Jump(null, "Lottery_UI", null);
				result = 1;
				break;
			case "blacksmith":
				ShortcutIcon.Jump(null, "Ui_TownBlacksmith", null);
				result = 1;
				break;
			case "stoneshop":
				ShortcutIcon.Jump(null, "Ui_TownStoneShop", null);
				result = 1;
				break;
			case "raid":
				QuestManager.Instance.SetAndJumpArea(QuestManager.getArea(EnumAreaTypes.Raid));
				result = 1;
				break;
			default:
				result = 0;
				break;
			}
		}
		return (byte)result != 0;
	}

	internal void _0024CheckMaintenance_0024closure_00242935()
	{
		SceneChanger.Kill();
		SceneChanger.Change("Boot");
	}

	internal void _0024CheckMaintenance_0024closure_00242936()
	{
	}
}
