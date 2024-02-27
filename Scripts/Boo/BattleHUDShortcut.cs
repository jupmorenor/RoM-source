using System;
using System.Collections;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using UnityEngine;

[Serializable]
public class BattleHUDShortcut : MonoBehaviour
{
	[Serializable]
	public enum Mode
	{
		INIT,
		HIDE,
		SHOW
	}

	[Serializable]
	internal class _0024PushOpen_0024closure_00243759
	{
		internal Vector3 _0024_002412604_002415029;

		internal BattleHUDShortcut _0024this_002415030;

		internal float _0024_002412603_002415031;

		public _0024PushOpen_0024closure_00243759(Vector3 _0024_002412604_002415029, BattleHUDShortcut _0024this_002415030, float _0024_002412603_002415031)
		{
			this._0024_002412604_002415029 = _0024_002412604_002415029;
			this._0024this_002415030 = _0024this_002415030;
			this._0024_002412603_002415031 = _0024_002412603_002415031;
		}

		public void Invoke()
		{
			_0024this_002415030.touchScreen = ModalTouchScreen.Init(_0024this_002415030.transform, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(_0024this_002415030.PushClose));
			float num = (_0024_002412603_002415031 = _0024this_002415030.shortcutIconZ + 20f);
			Vector3 vector = (_0024_002412604_002415029 = _0024this_002415030.touchScreen.transform.localPosition);
			float num2 = (_0024_002412604_002415029.z = _0024_002412603_002415031);
			Vector3 vector3 = (_0024this_002415030.touchScreen.transform.localPosition = _0024_002412604_002415029);
			_0024this_002415030.openButton.SetActive(value: false);
			_0024this_002415030.closeButton.SetActive(value: true);
			_0024this_002415030.Modal = false;
		}
	}

	[NonSerialized]
	public const string DEFAULT_PREFAB_PATH = "Prefab/GUI/ShortcutHUD";

	[NonSerialized]
	private static BattleHUDShortcut __instance;

	[NonSerialized]
	protected static bool quitApp;

	protected bool openFlag;

	protected bool lastOpenFlag;

	protected bool enableShortcutFlag;

	[NonSerialized]
	public static bool isSceneFromShortcut;

	[NonSerialized]
	protected static bool setEventFunc;

	public Hashtable shortcutIcons;

	public string shortcutIconPrefab;

	private GameObject _shortcutIconPrefab;

	public float shortcutIconZ;

	private int areaConditionNumber;

	private int playerConditionNumber;

	public UIAnchor bgPos;

	public Transform hudRoot;

	public Transform iconRoot;

	public Transform bgRoot;

	public UISprite bgWindow;

	public float openSpeed;

	public float openAdjustment;

	public GameObject openButton;

	public GameObject closeButton;

	public int xIconCount;

	public int yIconCount;

	protected string[] showStartSceneNames;

	protected string[] hideIncludeSceneNames;

	protected QuestManager questMan;

	[NonSerialized]
	public static int initDelayFrame = 5;

	[NonSerialized]
	public static float PosToShow;

	[NonSerialized]
	public static float PosToHide = 200f;

	[NonSerialized]
	protected const float HUD_MOVE_TIME = 0.5f;

	[NonSerialized]
	protected static Mode mode;

	private bool isModal;

	protected string lastSceneName;

	protected bool showScene;

	[NonSerialized]
	public static string nextIgnoreSceneName = string.Empty;

	[NonSerialized]
	private static string curIgnoreSceneName = string.Empty;

	protected bool init;

	protected int initDelayCount;

	protected bool setup;

	protected bool debug;

	protected ModalTouchScreen touchScreen;

	private ICallable openHandler;

	private ICallable closeHandler;

	private Mode lastMode;

	public static BattleHUDShortcut Instance
	{
		get
		{
			BattleHUDShortcut _instance;
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
				__instance = ((BattleHUDShortcut)UnityEngine.Object.FindObjectOfType(typeof(BattleHUDShortcut))) as BattleHUDShortcut;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static BattleHUDShortcut CurrentInstance => __instance;

	public static bool IsOpen => (bool)CurrentInstance && CurrentInstance.openFlag;

	public static bool IsShortcut => (bool)CurrentInstance && CurrentInstance.enableShortcutFlag;

	public static bool IsShow => (bool)CurrentInstance && CurrentInstance.bgRoot.active;

	private bool Modal
	{
		get
		{
			return isModal;
		}
		set
		{
			isModal = value;
			ModalCollider.SetActive(this, value);
		}
	}

	public string IgnoreSceneName
	{
		get
		{
			return curIgnoreSceneName;
		}
		set
		{
			nextIgnoreSceneName = value;
		}
	}

	public static bool IsSceneFromShortcut
	{
		get
		{
			return isSceneFromShortcut;
		}
		set
		{
			isSceneFromShortcut = value;
		}
	}

	public bool Debug
	{
		get
		{
			return debug;
		}
		set
		{
			debug = value;
		}
	}

	public ICallable OpenHandler
	{
		get
		{
			return openHandler;
		}
		set
		{
			openHandler = value;
		}
	}

	public ICallable CloseHandler
	{
		get
		{
			return closeHandler;
		}
		set
		{
			closeHandler = value;
		}
	}

	public BattleHUDShortcut()
	{
		shortcutIcons = new Hashtable();
		shortcutIconPrefab = "Prefab/GUI/ShortcutIcon";
		shortcutIconZ = 20f;
		areaConditionNumber = -1;
		playerConditionNumber = -1;
		openSpeed = 0.25f;
		showStartSceneNames = new string[15]
		{
			"Town", "Myhome", "Ui_World", "Ui_Town", "Ui_Town", "Ui_Black", "Ui_MyHome", "Ui_Message", "Ui_Pet", "Ui_Rank",
			"Lottery", "Ui_WorldColosseumResult", "Ui_WorldQuestResult", "Ui_WorldChallengeResult", "Ui_WorldRaidResult"
		};
		hideIncludeSceneNames = new string[4] { "Download", "Terminal", "Char", "Create" };
		lastSceneName = "NoScene";
		initDelayCount = initDelayFrame;
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00242476();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static BattleHUDShortcut _createInstance()
	{
		GameObject gameObject = (GameObject)GameAssetModule.LoadPrefab("Prefab/GUI/ShortcutHUD");
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
		gameObject2.name = "__" + "BattleHUDShortcut" + "__";
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject2);
		BattleHUDShortcut battleHUDShortcut = ExtensionsModule.SetComponent<BattleHUDShortcut>(gameObject2);
		if ((bool)battleHUDShortcut)
		{
			battleHUDShortcut._createInstance_callback();
		}
		return battleHUDShortcut;
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

	public void _0024singleton_0024appQuit_00242477()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00242477();
		quitApp = true;
	}

	public static void Show()
	{
		mode = Mode.SHOW;
	}

	public static void Hide()
	{
		mode = Mode.HIDE;
	}

	public static void Open()
	{
		if (IsShortcut && (bool)CurrentInstance)
		{
			CurrentInstance.PushOpen();
		}
	}

	public static void Close()
	{
		if (IsShortcut && (bool)CurrentInstance)
		{
			CurrentInstance.PushClose();
		}
	}

	private void InitArrowButton(UIButtonMessage btn)
	{
		if ((bool)btn)
		{
			btn.immadiateHandler = delegate
			{
				Modal = true;
			};
		}
	}

	public void _0024singleton_0024awake_00242476()
	{
		if (!setEventFunc)
		{
			SceneChanger.ScenePreChangeEvent += _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__Req_FailHandler_0024callable6_0024440_32___0024148.Adapt(SceheChangeEvent);
			setEventFunc = true;
		}
		InitArrowButton(openButton.GetComponent<UIButtonMessage>());
		InitArrowButton(closeButton.GetComponent<UIButtonMessage>());
		questMan = QuestManager.Instance;
		HideCore();
		_shortcutIconPrefab = (GameObject)Resources.Load(shortcutIconPrefab);
	}

	public static void SceheChangeEvent()
	{
		IsSceneFromShortcut = ShortcutIcon.IsUseShortcut;
		ShortcutIcon.IsUseShortcut = false;
	}

	public void OnDisable()
	{
		enableShortcutFlag = false;
		GameObject gameObject = ModalCollider.GetCollider();
		if (gameObject != null && gameObject.activeSelf)
		{
			Modal = false;
		}
	}

	public void Init()
	{
		float x = bgPos.gameObject.transform.position.x;
		Vector3 position = hudRoot.position;
		float num = (position.x = x);
		Vector3 vector2 = (hudRoot.position = position);
		float y = bgPos.gameObject.transform.position.y;
		Vector3 position2 = hudRoot.position;
		float num2 = (position2.y = y);
		Vector3 vector4 = (hudRoot.position = position2);
		openButton.SetActive(value: true);
		closeButton.SetActive(value: false);
		iconRoot.gameObject.SetActive(value: false);
		openFlag = false;
		init = true;
	}

	public bool IsShowIcon()
	{
		bool result = false;
		IEnumerator enumerator = shortcutIcons.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object current = enumerator.Current;
			object obj = shortcutIcons[current];
			if (!(obj is ShortcutIcon))
			{
				obj = RuntimeServices.Coerce(obj, typeof(ShortcutIcon));
			}
			ShortcutIcon shortcutIcon = (ShortcutIcon)obj;
			if (!shortcutIcon || !shortcutIcon.IsShow)
			{
				continue;
			}
			result = true;
			break;
		}
		return result;
	}

	public bool UpdateShowScene()
	{
		if (!questMan)
		{
			throw new AssertionFailedException("questMan");
		}
		if (areaConditionNumber != questMan.AreaConditionNumber)
		{
			SetupShortcutIconCore();
			areaConditionNumber = questMan.AreaConditionNumber;
		}
		else if (playerConditionNumber != UserData.Current.userMiscInfo.flagData.ConditionNumber)
		{
			SetupShortcutIconCore();
			playerConditionNumber = UserData.Current.userMiscInfo.flagData.ConditionNumber;
		}
		checked
		{
			if (lastSceneName != SceneChanger.CurrentSceneName)
			{
				lastSceneName = SceneChanger.CurrentSceneName;
				curIgnoreSceneName = nextIgnoreSceneName;
				nextIgnoreSceneName = string.Empty;
				showScene = false;
				int i = 0;
				string[] array = showStartSceneNames;
				for (int length = array.Length; i < length; i++)
				{
					if (SceneChanger.CurrentSceneName.StartsWith(array[i]))
					{
						showScene = true;
						int j = 0;
						string[] array2 = hideIncludeSceneNames;
						for (int length2 = array2.Length; j < length2; j++)
						{
							if (SceneChanger.CurrentSceneName.IndexOf(array2[j]) >= 0)
							{
								showScene = false;
								break;
							}
						}
					}
					if (showScene)
					{
						break;
					}
				}
			}
			return showScene;
		}
	}

	public void Update()
	{
		if (StartButton.Paused)
		{
			return;
		}
		checked
		{
			if (initDelayCount > 0)
			{
				initDelayCount--;
				return;
			}
			if (!init)
			{
				Init();
			}
			UpdateShowScene();
			if (mode != lastMode)
			{
				if (mode == Mode.SHOW && IsShowIcon() && showScene)
				{
					ShowCore();
					lastMode = Mode.SHOW;
				}
				else
				{
					HideCore();
					lastMode = Mode.HIDE;
				}
			}
			bool flag = false;
			if (mode == Mode.SHOW)
			{
				flag = true;
				if (flag && NpcTalkControl.IsBusy)
				{
					flag = false;
				}
				if (flag && MerlinServer.Busy)
				{
					flag = false;
				}
				if (flag && !SceneChanger.isFadeOut)
				{
					flag = false;
				}
				if (flag && DialogManager.DialogCount > 0)
				{
					flag = false;
				}
				if (flag && EventWindow.isWindow)
				{
					flag = false;
				}
				if (flag && !FaderCore.Instance.isOutCompleted)
				{
					flag = false;
				}
				if (flag && !MerlinTaskQueue.Instance.IsEmpty)
				{
					flag = false;
				}
			}
			else if (mode == Mode.HIDE && isModal)
			{
				Modal = false;
			}
			enableShortcutFlag = flag;
			if (flag)
			{
				if (lastOpenFlag != openFlag)
				{
					lastOpenFlag = openFlag;
					if (openFlag)
					{
						TheWorld.StopWorldAll(this);
					}
					else
					{
						TheWorld.RestartWorld();
					}
				}
			}
			else if (openFlag)
			{
				TheWorld.RestartWorld();
				PushClose();
				lastOpenFlag = openFlag;
			}
		}
	}

	public void ShowCore()
	{
		bool flag = bgRoot.gameObject.active;
		bgRoot.gameObject.SetActive(value: true);
		if (!flag)
		{
			bgRoot.gameObject.transform.localPosition = Vector3.zero;
		}
	}

	public void HideCore()
	{
		bgRoot.gameObject.SetActive(value: false);
		bgRoot.gameObject.transform.localPosition = Vector3.zero;
	}

	public static void SetupShortcutIcon(Transform parent)
	{
		BattleHUDShortcut instance = Instance;
		instance.AddPrefab(parent, instance.gameObject);
		instance.SetupShortcutIconCore();
	}

	public static void ClearShortcutIcon()
	{
		ClearShortcutIcon(destroy: false);
	}

	public static void ClearShortcutIcon(bool destroy)
	{
		BattleHUDShortcut instance = Instance;
		instance.ClearShortcutIconCore(destroy);
	}

	public void PushOpen()
	{
		if (!CanOpen())
		{
			Modal = false;
			return;
		}
		iconRoot.gameObject.SetActive(value: true);
		float x = 0f - bgWindow.transform.localScale.x + openAdjustment;
		TweenPosition tweenPosition = TweenPosition.Begin(bgRoot.gameObject, openSpeed, new Vector3(x, 0f, 0f));
		tweenPosition.delay = 0f;
		openFlag = true;
		if (openHandler != null)
		{
			openHandler.Call(new object[0]);
		}
		Vector3 _0024_002412604_0024 = default(Vector3);
		float _0024_002412603_0024 = default(float);
		tweenPosition.onFinished = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024OnFinished_0024157.Adapt(new _0024PushOpen_0024closure_00243759(_0024_002412604_0024, this, _0024_002412603_0024).Invoke);
	}

	public bool CanOpen()
	{
		return !NpcTalkControl.IsBusy && !MerlinServer.Busy && SceneChanger.isFadeOut && DialogManager.DialogCount <= 0 && !EventWindow.isWindow && FaderCore.Instance.isOutCompleted && (MerlinTaskQueue.Instance.IsEmpty ? true : false);
	}

	public void PushClose()
	{
		if ((bool)touchScreen)
		{
			UnityEngine.Object.DestroyObject(touchScreen.gameObject);
		}
		touchScreen = null;
		TweenPosition tweenPosition = TweenPosition.Begin(bgRoot.gameObject, openSpeed, new Vector3(0f, 0f, 0f));
		tweenPosition.delay = 0f;
		tweenPosition.onFinished = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024OnFinished_0024157.Adapt(delegate
		{
			openButton.SetActive(value: true);
			closeButton.SetActive(value: false);
			openFlag = false;
			iconRoot.gameObject.SetActive(value: false);
			if (closeHandler != null)
			{
				closeHandler.Call(new object[0]);
			}
			Modal = false;
		});
	}

	public void SetupShortcutIconCore()
	{
		ClearShortcutIconCore();
		setup = true;
		if (string.IsNullOrEmpty(shortcutIconPrefab))
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		int i = 0;
		MShortcutIcons[] all = MShortcutIcons.All;
		checked
		{
			float num3 = default(float);
			float num4 = default(float);
			for (int length = all.Length; i < length; i++)
			{
				if (all[i].EventShortcut)
				{
					continue;
				}
				int posXIndex = all[i].PosXIndex;
				int posYIndex = all[i].PosYIndex;
				int id = all[i].Id;
				ShortcutIcon shortcutIcon = null;
				if (shortcutIcons.ContainsKey(id))
				{
					shortcutIcon = shortcutIcons[id] as ShortcutIcon;
					shortcutIcon.gameObject.SetActive(value: true);
				}
				shortcutIcon = SetupShortcutIconCore(all[i], shortcutIcon);
				if ((bool)shortcutIcon)
				{
					if (num == 0 && num2 == 0)
					{
						float bgPadding = ShortcutIcon.bgPadding;
						num3 = ShortcutIcon.iconWidth + bgPadding;
						num4 = ShortcutIcon.iconHeight + bgPadding;
						float num5 = ShortcutIcon.iconWidth * 0.5f;
						float num6 = ShortcutIcon.iconHeight * 0.5f;
						num = (int)((0f - (float)xIconCount * num3) * 0.5f + num5);
						num2 = (int)((0f - (float)yIconCount * num4) * 0.5f + num6);
					}
					shortcutIcons[id] = shortcutIcon;
					Vector3 ofs = new Vector3((float)num + (float)posXIndex * num3, 0f - ((float)num2 + (float)posYIndex * num4), shortcutIconZ);
					shortcutIcon.button.transform.localScale = new Vector3(shortcutIcon.IconMaster.ScaleX, shortcutIcon.IconMaster.ScaleY, 1f);
					AddPrefabEx(iconRoot, shortcutIcon.gameObject, ofs, Vector3.one);
				}
			}
		}
	}

	public ShortcutIcon SetupShortcutIconCore(MShortcutIcons micon, ShortcutIcon icon)
	{
		if (micon == null)
		{
			throw new AssertionFailedException("micon");
		}
		if (!questMan)
		{
			questMan = QuestManager.Instance;
		}
		MAreas marea = null;
		Hashtable areaGroupTable = questMan.AreaGroupTable;
		object result;
		if (areaGroupTable == null)
		{
			if (icon != null)
			{
				icon.gameObject.SetActive(value: false);
			}
			result = null;
		}
		else
		{
			if (micon.AreaGroup != null && areaGroupTable.ContainsKey(micon.AreaGroup.Id))
			{
				object obj = areaGroupTable[micon.AreaGroup.Id];
				if (!(obj is MAreas))
				{
					obj = RuntimeServices.Coerce(obj, typeof(MAreas));
				}
				marea = (MAreas)obj;
			}
			if (debug)
			{
				goto IL_00f6;
			}
			if (!GameLevelManager.CheckCondition(micon.AllConditions, notFlag: false))
			{
				result = null;
			}
			else
			{
				if (GameLevelManager.CheckCondition(micon.AllNotConditions, notFlag: true))
				{
					goto IL_00f6;
				}
				result = null;
			}
		}
		goto IL_0157;
		IL_0157:
		return (ShortcutIcon)result;
		IL_00f6:
		GameObject gameObject = default(GameObject);
		if (icon == null)
		{
			gameObject = (GameObject)UnityEngine.Object.Instantiate(_shortcutIconPrefab);
			if ((bool)gameObject)
			{
				icon = gameObject.GetComponentInChildren<ShortcutIcon>();
			}
		}
		if ((bool)icon)
		{
			icon.debug = debug;
			icon.Setup(micon, marea, showFlag: true);
			result = icon;
		}
		else
		{
			UnityEngine.Object.DestroyObject(gameObject);
			result = null;
		}
		goto IL_0157;
	}

	public void ClearShortcutIconCore()
	{
		ClearShortcutIconCore(destroy: false);
	}

	public void ClearShortcutIconCore(bool destroy)
	{
		setup = false;
		if (shortcutIcons == null)
		{
			return;
		}
		object[] array = new object[0];
		IEnumerator enumerator = shortcutIcons.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object current = enumerator.Current;
			object obj = shortcutIcons[current];
			if (!(obj is ShortcutIcon))
			{
				obj = RuntimeServices.Coerce(obj, typeof(ShortcutIcon));
			}
			ShortcutIcon shortcutIcon = (ShortcutIcon)obj;
			if (shortcutIcon != null)
			{
				if (destroy)
				{
					UnityEngine.Object.Destroy(shortcutIcon.gameObject);
					array = (object[])RuntimeServices.AddArrays(typeof(object), array, new object[1] { current });
				}
				else
				{
					shortcutIcon.ToInvisible();
					shortcutIcon.gameObject.SetActive(value: false);
				}
			}
		}
		int i = 0;
		object[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			shortcutIcons.Remove(array2[i]);
		}
	}

	private void AddPrefab(Transform parent, GameObject obj)
	{
		AddPrefabEx(parent, obj, Vector3.zero, Vector3.one);
	}

	private void AddPrefabEx(Transform parent, GameObject obj, Vector3 ofs, Vector3 scl)
	{
		obj.transform.parent = parent;
		obj.transform.localScale = scl;
		obj.transform.localPosition = ofs;
		UIPanel[] componentsInChildren = obj.GetComponentsInChildren<UIPanel>(includeInactive: true);
		int i = 0;
		UIPanel[] array = componentsInChildren;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			UnityEngine.Object.DestroyObject(array[i]);
		}
	}

	internal void _0024InitArrowButton_0024closure_00242927()
	{
		Modal = true;
	}

	internal void _0024PushClose_0024closure_00243760()
	{
		openButton.SetActive(value: true);
		closeButton.SetActive(value: false);
		openFlag = false;
		iconRoot.gameObject.SetActive(value: false);
		if (closeHandler != null)
		{
			closeHandler.Call(new object[0]);
		}
		Modal = false;
	}
}
