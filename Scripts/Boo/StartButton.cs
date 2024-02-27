using System;
using Boo.Lang.Runtime;
using GameAsset;
using UnityEngine;

[Serializable]
public class StartButton : MonoBehaviour
{
	public Transform windowParent;

	public Transform backButtonParent;

	public GameObject pauseTownWindowPrefab;

	public GameObject pauseQuestWindowPrefab;

	public GameObject backButtonHUDPrefab;

	public Camera pauseCamera;

	private GameObject window;

	private IPauseWindow iPauseWindow;

	private GameObject btnBackupTarget;

	private string btnBackupFunctionName;

	private bool destoryBackButton;

	public UIButtonMessage pauseMessager;

	private BoxCollider boxCollider;

	private BoxCollider modalCollider;

	[NonSerialized]
	private static bool pause;

	public float backButtonExitDuration;

	private UISprite pauseIcon;

	private bool activeButtonComponents;

	private UISlicedSprite startButtonSprite;

	private bool isStartButtonisRecording;

	private GameObject recordButtonGo;

	private RecordButton recordButtonCmp;

	private bool bActiveRecordButton;

	private bool bShowRecordButton;

	private PauseTown pauseTownCmp;

	private PauseQuest pauseQuestCmp;

	protected float closeButtonNoMoveWait;

	protected float lastTime;

	[NonSerialized]
	protected static float delaySec = 1f;

	[NonSerialized]
	private static StartButton m_instance;

	public static StartButton Instance
	{
		get
		{
			if (!m_instance)
			{
				m_instance = (StartButton)UnityEngine.Object.FindObjectOfType(typeof(StartButton));
			}
			return m_instance;
		}
	}

	public static bool Paused => pause;

	public StartButton()
	{
		backButtonExitDuration = 0.1f;
	}

	public static bool IsEnablePause()
	{
		if (ChainSkillRoutine.IsPlaying)
		{
			delaySec = 1f;
		}
		if (!SceneChanger.isCompletelyReady)
		{
			delaySec = 1f;
		}
		if (MerlinServer.Instance.IsBusy)
		{
			delaySec = 1f;
		}
		if (!PlayerControl.CurrentPlayer)
		{
			delaySec = 1f;
		}
		if ((bool)PlayerControl.CurrentPlayer)
		{
			if (!PlayerControl.CurrentPlayer.IsReady)
			{
				delaySec = 1f;
			}
			if (PlayerControl.CurrentPlayer.IsDead)
			{
				delaySec = 1f;
			}
		}
		if (!FaderCore.Instance.isCompleted)
		{
			delaySec = 1f;
		}
		if (CutSceneManager.IsBusy)
		{
			delaySec = 1f;
		}
		if (GameLevelManager.IsBusy)
		{
			delaySec = 1f;
		}
		if (NpcTalkControl.IsBusy)
		{
			delaySec = 1f;
		}
		if (!MerlinTaskQueue.Instance.IsEmpty)
		{
			delaySec = 1f;
		}
		if (BattleHUDShortcut.IsOpen)
		{
			delaySec = 1f;
		}
		if (DialogManager.DialogCount > 0)
		{
			delaySec = 1f;
		}
		if (EventWindow.isWindow)
		{
			delaySec = 1f;
		}
		return (delaySec <= 0f) ? true : false;
	}

	public void Awake()
	{
		if (SceneChanger.CurrentScene == SceneID.RaidBattle && QuestSession.State == QuestSession.EState.UnInitialized)
		{
			UnityEngine.Object.DestroyObject(gameObject);
			return;
		}
		lastTime = Time.realtimeSinceStartup;
		pause = false;
		if (!pauseMessager)
		{
			pauseMessager = GetComponent<UIButtonMessage>();
		}
		if (!(pauseTownWindowPrefab != null))
		{
			throw new AssertionFailedException("タウンのポーズウィンドウが無いよ！！！！");
		}
		if (!(pauseQuestWindowPrefab != null))
		{
			throw new AssertionFailedException("クエストのポーズウィンドウが無いよ！！！！");
		}
		boxCollider = gameObject.GetComponent<BoxCollider>();
		modalCollider = ModalCollider.GetCollider().GetComponent<BoxCollider>();
		pauseIcon = gameObject.GetComponentInChildren<UISprite>();
	}

	public void Start()
	{
		initSelf();
		initRecordButton();
		UpdateStartButtonGui();
	}

	public void Update()
	{
		float num = Time.realtimeSinceStartup - lastTime;
		lastTime = Time.realtimeSinceStartup;
		if (!(delaySec <= 0f))
		{
			delaySec -= num;
		}
		if (!(closeButtonNoMoveWait <= 0f))
		{
			closeButtonNoMoveWait -= num;
		}
		if (boxCollider.enabled == ModalCollider.GetCollider().activeSelf)
		{
			boxCollider.enabled = !ModalCollider.GetCollider().activeSelf;
		}
		if (pause)
		{
			if ((bool)pauseIcon)
			{
				pauseIcon.color = Color.white;
			}
		}
		else if (IsEnablePause())
		{
			if ((bool)pauseIcon)
			{
				pauseIcon.color = Color.white;
			}
		}
		else if ((bool)pauseIcon)
		{
			pauseIcon.color = Color.grey;
		}
		if (pauseTownCmp != null)
		{
			bool aValid = false;
			if (pauseTownCmp.GetMode() == PauseTown.MODE_PAUSETOWN.top)
			{
				aValid = true;
			}
			showRecordButton(aValid);
		}
		else if (pauseQuestCmp != null)
		{
			bool aValid2 = false;
			if (pauseQuestCmp.GetMode() == PauseQuest.MODE_PAUSEQUEST.top)
			{
				aValid2 = true;
			}
			showRecordButton(aValid2);
		}
		UpdateStartButtonGui();
	}

	private void OnDestroy()
	{
		ClosePause();
	}

	public void pushStartButton()
	{
		pushButton();
	}

	private bool NeedTownMode()
	{
		string currentSceneName = SceneChanger.CurrentSceneName;
		return (currentSceneName == SceneID.Town.ToString() || currentSceneName == SceneID.Myhome.ToString()) ? true : false;
	}

	private void pushButton()
	{
		togglePause();
	}

	private void togglePause()
	{
		if ((!pause && !IsEnablePause()) || ((bool)iPauseWindow && iPauseWindow.IsChangingSituation) || !(closeButtonNoMoveWait <= 0f))
		{
			return;
		}
		pause = !pause;
		if (pause)
		{
			TimeScaleUtil.Zero();
			TheWorld.StopWorldForPause();
			pauseMessager.enabled = true;
			if (!window)
			{
				GameObject prefab = pauseQuestWindowPrefab;
				string currentSceneName = SceneChanger.CurrentSceneName;
				if (NeedTownMode())
				{
					prefab = pauseTownWindowPrefab;
				}
				window = CreatePrefab(prefab, windowParent);
				window.SetActive(value: true);
				iPauseWindow = window.GetComponent<IPauseWindow>();
				iPauseWindow.SetStartButton(this);
				initPauseCmp(window);
			}
			window.SetActive(value: true);
			iPauseWindow = window.GetComponent<IPauseWindow>();
			iPauseWindow.ReqStart();
			if (ButtonBackHUD.Instance == null)
			{
				destoryBackButton = true;
				GameObject gameObject = CreatePrefab(backButtonHUDPrefab, backButtonParent);
				gameObject.SetActive(value: true);
				AnchorDepthOffsetController component = backButtonParent.parent.GetComponent<AnchorDepthOffsetController>();
				if ((bool)component)
				{
					component.DoSet();
				}
			}
			showRecordButton(aValid: true);
			UIButtonMessage button = ButtonBackHUD.GetButton();
			if (!(button != null))
			{
				throw new AssertionFailedException("BackButtonHUD がありません!!!");
			}
			ButtonBackHUD.SetActive(setActive: true);
			UIAutoTweenerStandAloneEx.Hide(ButtonBackHUD.Instance.gameObject);
			closeButtonNoMoveWait = 1f;
			UIAutoTweenerStandAloneEx.In(ButtonBackHUD.Instance.gameObject, delegate
			{
				closeButtonNoMoveWait = 0f;
			});
			btnBackupTarget = button.target;
			btnBackupFunctionName = button.functionName;
			button.target = window;
			button.functionName = "PushBack";
		}
		else
		{
			PauseRelease();
		}
	}

	public void PauseRelease()
	{
		TimeScaleUtil.One();
		TheWorld.RestartWorldForPause();
		showRecordButton(aValid: false);
		ClosePause();
		pause = false;
	}

	public void ClosePause()
	{
		pause = false;
		if (!window)
		{
			return;
		}
		if (window.activeSelf && !window.GetComponent<IPauseWindow>().CanExit())
		{
			window.GetComponent<IPauseWindow>().ReqExit();
			CleanUpBackButton();
			return;
		}
		if (pause)
		{
			TimeScaleUtil.One();
		}
		window.SetActive(value: false);
	}

	private void CleanUpBackButton()
	{
		if (!ButtonBackHUD.Instance)
		{
			return;
		}
		if (destoryBackButton)
		{
			closeButtonNoMoveWait = 1f;
			UIAutoTweenerStandAloneEx.Out(ButtonBackHUD.Instance.gameObject, delegate
			{
				UnityEngine.Object.Destroy(ButtonBackHUD.Instance.gameObject);
				closeButtonNoMoveWait = 0f;
			});
		}
		else
		{
			UIButtonMessage button = ButtonBackHUD.GetButton();
			button.target = btnBackupTarget;
			button.functionName = btnBackupFunctionName;
			closeButtonNoMoveWait = 0f;
		}
	}

	private GameObject CreatePrefab(GameObject prefab, Transform parent)
	{
		object result;
		if (!prefab)
		{
			result = null;
		}
		else
		{
			GameObject gameObject = (NeedTownMode() ? GameAssetModule.Instantiate(prefab) : ((GameObject)UnityEngine.Object.Instantiate(prefab)));
			gameObject.SetActive(value: false);
			gameObject.transform.parent = parent;
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.localPosition = Vector3.zero;
			result = gameObject;
		}
		return (GameObject)result;
	}

	public static void ForceDestroy()
	{
		StartButton startButton = ((StartButton)UnityEngine.Object.FindObjectOfType(typeof(StartButton))) as StartButton;
		if ((bool)startButton)
		{
			UnityEngine.Object.Destroy(startButton.gameObject);
		}
	}

	private void initRecordButton()
	{
		updateRecordButton();
		if (recordButtonGo != null)
		{
			UIAutoTweenerStandAloneEx.Hide(recordButtonGo);
		}
	}

	private void updateRecordButton()
	{
		Transform transform = this.transform.parent.transform;
		int childCount = transform.childCount;
		int num = 0;
		int num2 = childCount;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			Transform child = transform.GetChild(index);
			GameObject gameObject = child.gameObject;
			if (gameObject.name == "RecordButton")
			{
				recordButtonGo = gameObject;
				recordButtonCmp = recordButtonGo.GetComponent<RecordButton>() as RecordButton;
				break;
			}
		}
	}

	private void showRecordButton(bool aValid)
	{
		if (!(recordButtonGo != null))
		{
			return;
		}
		if (aValid && (bool)recordButtonCmp && recordButtonCmp.isRecord)
		{
			recordButtonCmp.StopRecord(modal: true);
		}
		if (!bActiveRecordButton)
		{
			recordButtonGo.SetActive(value: true);
			bActiveRecordButton = true;
		}
		if (aValid)
		{
			if (!bShowRecordButton)
			{
				bShowRecordButton = true;
				UIAutoTweenerStandAloneEx.In(recordButtonGo);
			}
		}
		else if (bShowRecordButton)
		{
			bShowRecordButton = false;
			UIAutoTweenerStandAloneEx.Out(recordButtonGo);
		}
	}

	public void ShowRecordButton(bool aValid)
	{
		showRecordButton(aValid);
	}

	public void Resume()
	{
		if (pause)
		{
			togglePause();
		}
	}

	public bool IsRecord()
	{
		bool result = false;
		if (recordButtonCmp != null)
		{
			result = recordButtonCmp.isRecord;
		}
		return result;
	}

	private void initPauseCmp(GameObject aPauseGo)
	{
		pauseTownCmp = aPauseGo.GetComponent<PauseTown>() as PauseTown;
		pauseQuestCmp = aPauseGo.GetComponent<PauseQuest>() as PauseQuest;
	}

	private void initSelf()
	{
		Transform child = transform.GetChild(0);
		GameObject gameObject = child.gameObject;
		startButtonSprite = gameObject.GetComponent<UISlicedSprite>() as UISlicedSprite;
		isStartButtonisRecording = false;
	}

	public void UpdateStartButtonGui()
	{
		bool startButtonGui = IsRecord();
		setStartButtonGui(startButtonGui);
	}

	private void setStartButtonGui(bool aRecord)
	{
		if (!(startButtonSprite != null))
		{
			return;
		}
		string text = null;
		string spriteName = startButtonSprite.spriteName;
		if (aRecord)
		{
			if (spriteName == "button_open")
			{
				isStartButtonisRecording = true;
				text = "button_rec";
			}
		}
		else if (spriteName == "button_rec")
		{
			isStartButtonisRecording = false;
			text = "button_open";
		}
		if (text != null)
		{
			startButtonSprite.spriteName = text;
		}
	}

	internal void _0024togglePause_0024closure_00243757(GameObject go)
	{
		closeButtonNoMoveWait = 0f;
	}

	internal void _0024CleanUpBackButton_0024closure_00243758(GameObject go)
	{
		UnityEngine.Object.Destroy(ButtonBackHUD.Instance.gameObject);
		closeButtonNoMoveWait = 0f;
	}
}
