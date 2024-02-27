using System;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class PauseQuest : PauseBase
{
	[Serializable]
	public enum MODE_PAUSEQUEST
	{
		top,
		info,
		sound,
		pad,
		help,
		exit,
		retire
	}

	public UILabelBase textDate;

	public WebView helpWebView;

	protected MODE_PAUSEQUEST mode;

	protected MODE_PAUSEQUEST lastMode;

	private DialogManager dlgMan;

	private Dialog dialog;

	public UIButtonMessage retireButton;

	public UIButtonMessage questInfoButton;

	public UIButtonMessage helpButton;

	protected UIValidController retireButtonValidCtrl;

	protected UIValidController questInfoButtonValidCtrl;

	protected UIValidController helpButtonValidCtrl;

	protected bool retireFlag;

	protected bool closeFlag;

	private bool calledStart;

	public override void SceneAwake()
	{
		dlgMan = DialogManager.Instance;
		textDate.text = MerlinDateTime.Now.ToString("HH:mm");
		retireButtonValidCtrl = retireButton.gameObject.GetComponent<UIValidController>();
		questInfoButtonValidCtrl = questInfoButton.gameObject.GetComponent<UIValidController>();
		helpButtonValidCtrl = helpButton.gameObject.GetComponent<UIValidController>();
		MQuests quest = QuestSession.Quest;
		if (quest != null && (quest.QuestType == EnumQuestTypes.Tutorial || quest.QuestType == EnumQuestTypes.RaidTutorial))
		{
			retireButtonValidCtrl.isValidColor = false;
			retireButton.enabled = false;
		}
		if (TutorialFlowControl.IsInTutorial)
		{
			retireButtonValidCtrl.isValidColor = false;
			retireButton.enabled = false;
		}
	}

	public override void SceneStart()
	{
		mode = (lastMode = MODE_PAUSEQUEST.top);
		ChangeSituation(GetSituation(0));
		calledStart = true;
		resetPauseFlag();
	}

	public void OnDestroy()
	{
		RestoreVolume();
		RestorePad();
		TheWorld.RestartWorldForPause();
		if (retireFlag)
		{
			TheWorld.Init();
		}
		resetPauseFlag();
	}

	private void setPauseFlag()
	{
		if (!IPauseWindow.isPaused)
		{
			PlayerEventDispatcher.InvokePause();
		}
		IPauseWindow.isPaused = true;
	}

	private void resetPauseFlag()
	{
		if (IPauseWindow.isPaused)
		{
			PlayerEventDispatcher.InvokeUnpause();
		}
		IPauseWindow.isPaused = false;
	}

	public override void SceneUpdate()
	{
		textDate.text = MerlinDateTime.Now.ToString("HH:mm");
		if (!SceneChanger.isCompletelyReady || IsChangingSituation)
		{
			return;
		}
		if (mode != lastMode)
		{
			lastMode = mode;
			UISituation situation = GetSituation((int)mode);
			GameObject situationRoot = default(GameObject);
			if ((bool)situation)
			{
				situationRoot = situation.gameObject;
				ChangeSituation(situation);
			}
			if (mode == MODE_PAUSEQUEST.top)
			{
				setPauseFlag();
				closeFlag = false;
			}
			else if (mode == MODE_PAUSEQUEST.sound)
			{
				InitSoundSetting(situationRoot);
			}
			else if (mode == MODE_PAUSEQUEST.pad)
			{
				RestorePad();
			}
			else if (mode == MODE_PAUSEQUEST.help)
			{
				helpWebView.Clear();
				MerlinServer.Request(new ApiHelp(), _0024adaptor_0024__PauseQuest_0024callable349_0024121_51___0024__MerlinServer_Request_0024callable86_0024160_56___0024152.Adapt(delegate(ApiHelp req)
				{
					string result = req.Result;
					helpWebView.OpenHtml(result, ServerURL.GameServerUrl("/"));
				}));
			}
			else if (mode == MODE_PAUSEQUEST.exit)
			{
				resetPauseFlag();
			}
		}
		if (mode == MODE_PAUSEQUEST.sound)
		{
			seSlider.ForceUpdate();
		}
	}

	public void PushRetire()
	{
		if (IsChangingSituation || !retireButtonValidCtrl.isValidColor)
		{
			return;
		}
		mode = MODE_PAUSEQUEST.retire;
		MQuests quest = QuestSession.Quest;
		if (quest != null && quest.QuestType == EnumQuestTypes.Challenge)
		{
			dlgMan.OnButton(0);
			dialog = dlgMan.OpenDialog("現在の成績でチャレンジを\n終了します。", "リタイアしますか？", DialogManager.MB_FLAG.MB_NONE, new string[2] { "いいえ", "はい" }).GetComponent<Dialog>();
			dialog.ButtonHandler = delegate(int btn)
			{
				if (btn == 2)
				{
					StartButton.ForceDestroy();
					QuestClearConditionChecker.Instance.doClear();
					retireFlag = true;
					TimeScaleUtil.One();
				}
				else
				{
					mode = MODE_PAUSEQUEST.top;
				}
			};
			return;
		}
		dlgMan.OnButton(0);
		dialog = dlgMan.OpenDialog(MTexts.Get("$d-mboard-quest-retire-final-text").msg, MTexts.Get("$d-mboard-quest-retire-final-title").msg, DialogManager.MB_FLAG.MB_NONE, new string[2] { "いいえ", "はい" }).GetComponent<Dialog>();
		dialog.ButtonHandler = delegate(int btn)
		{
			if (btn == 2)
			{
				StartButton.ForceDestroy();
				dialog = dlgMan.OpenDialog(MTexts.Get("$d-mboard-challenge-retire-final-text").msg, MTexts.Get("$d-mboard-challenge-retire-final-title").msg, DialogManager.MB_FLAG.MB_NONE, new string[1] { "OK" }).GetComponent<Dialog>();
				dialog.ButtonHandler = delegate
				{
					QuestClearConditionChecker.Instance.doFail();
					retireFlag = true;
					TimeScaleUtil.One();
					resetPauseFlag();
				};
			}
			else
			{
				mode = MODE_PAUSEQUEST.top;
			}
		};
	}

	public override void ReqStart()
	{
		if (calledStart)
		{
			mode = MODE_PAUSEQUEST.top;
		}
		textDate.text = MerlinDateTime.Now.ToString("HH:mm");
	}

	public override void ReqExit()
	{
		if (mode == MODE_PAUSEQUEST.sound)
		{
			SaveVolume();
		}
		else if (mode == MODE_PAUSEQUEST.pad)
		{
			SavePad();
		}
		mode = MODE_PAUSEQUEST.exit;
	}

	public override bool CanExit()
	{
		return !IsChangingSituation && mode == MODE_PAUSEQUEST.exit;
	}

	public void PushQuestInfo()
	{
		if (!IsChangingSituation && helpButtonValidCtrl.isValidColor)
		{
			mode = MODE_PAUSEQUEST.info;
		}
	}

	public void PushHelp()
	{
		if (!IsChangingSituation && helpButtonValidCtrl.isValidColor)
		{
			mode = MODE_PAUSEQUEST.help;
		}
	}

	public void PushSoundSetting()
	{
		if (!IsChangingSituation && helpButtonValidCtrl.isValidColor)
		{
			mode = MODE_PAUSEQUEST.sound;
		}
	}

	public void PushPadSetting()
	{
		if (!IsChangingSituation && helpButtonValidCtrl.isValidColor)
		{
			mode = MODE_PAUSEQUEST.pad;
		}
	}

	public void PushBack()
	{
		if (!IsChangingSituation && !closeFlag && !dialog)
		{
			if (mode == MODE_PAUSEQUEST.top)
			{
				base.startButton.pushStartButton();
				closeFlag = true;
			}
			else if (mode == MODE_PAUSEQUEST.sound)
			{
				SaveVolume();
				mode = MODE_PAUSEQUEST.top;
			}
			else if (mode == MODE_PAUSEQUEST.pad)
			{
				SavePad();
				mode = MODE_PAUSEQUEST.top;
			}
			else
			{
				mode = MODE_PAUSEQUEST.top;
			}
		}
	}

	public MODE_PAUSEQUEST GetMode()
	{
		return mode;
	}

	internal void _0024SceneUpdate_0024closure_00243753(ApiHelp req)
	{
		string result = req.Result;
		helpWebView.OpenHtml(result, ServerURL.GameServerUrl("/"));
	}

	internal void _0024PushRetire_0024closure_00243754(int btn)
	{
		if (btn == 2)
		{
			StartButton.ForceDestroy();
			QuestClearConditionChecker.Instance.doClear();
			retireFlag = true;
			TimeScaleUtil.One();
		}
		else
		{
			mode = MODE_PAUSEQUEST.top;
		}
	}

	internal void _0024PushRetire_0024closure_00243755(int btn)
	{
		if (btn == 2)
		{
			StartButton.ForceDestroy();
			dialog = dlgMan.OpenDialog(MTexts.Get("$d-mboard-challenge-retire-final-text").msg, MTexts.Get("$d-mboard-challenge-retire-final-title").msg, DialogManager.MB_FLAG.MB_NONE, new string[1] { "OK" }).GetComponent<Dialog>();
			dialog.ButtonHandler = delegate
			{
				QuestClearConditionChecker.Instance.doFail();
				retireFlag = true;
				TimeScaleUtil.One();
				resetPauseFlag();
			};
		}
		else
		{
			mode = MODE_PAUSEQUEST.top;
		}
	}

	internal void _0024_0024PushRetire_0024closure_00243755_0024closure_00243756(int btn)
	{
		QuestClearConditionChecker.Instance.doFail();
		retireFlag = true;
		TimeScaleUtil.One();
		resetPauseFlag();
	}
}
