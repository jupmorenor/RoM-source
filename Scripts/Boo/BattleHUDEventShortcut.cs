using System;
using System.Collections;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class BattleHUDEventShortcut : MonoBehaviour
{
	[NonSerialized]
	private static BattleHUDEventShortcut __instance;

	[NonSerialized]
	protected static bool quitApp;

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

	public Transform iconRoot;

	protected string[] showStartSceneNames;

	protected QuestManager questMan;

	protected string lastSceneName;

	protected bool showScene;

	protected bool init;

	protected bool setup;

	protected bool debug;

	protected bool newDayFlag;

	public static BattleHUDEventShortcut Instance
	{
		get
		{
			BattleHUDEventShortcut _instance;
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
				__instance = ((BattleHUDEventShortcut)UnityEngine.Object.FindObjectOfType(typeof(BattleHUDEventShortcut))) as BattleHUDEventShortcut;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static BattleHUDEventShortcut CurrentInstance => __instance;

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

	public BattleHUDEventShortcut()
	{
		shortcutIcons = new Hashtable();
		shortcutIconPrefab = "Prefab/GUI/ShortcutIcon";
		shortcutIconZ = 20f;
		areaConditionNumber = -1;
		playerConditionNumber = -1;
		showStartSceneNames = new string[2] { "Town", "Myhome" };
		lastSceneName = "NoScene";
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00242471();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static BattleHUDEventShortcut _createInstance()
	{
		string text = "__" + "BattleHUDEventShortcut" + "__";
		GameObject gameObject = new GameObject(text);
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		BattleHUDEventShortcut battleHUDEventShortcut = ExtensionsModule.SetComponent<BattleHUDEventShortcut>(gameObject);
		if ((bool)battleHUDEventShortcut)
		{
			battleHUDEventShortcut._createInstance_callback();
		}
		return battleHUDEventShortcut;
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

	public void _0024singleton_0024appQuit_00242472()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00242472();
		quitApp = true;
	}

	public void _0024singleton_0024awake_00242471()
	{
		if (!setEventFunc)
		{
			SceneChanger.ScenePreChangeEvent += _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__Req_FailHandler_0024callable6_0024440_32___0024148.Adapt(SceneChangeEvent);
			setEventFunc = true;
		}
		questMan = QuestManager.Instance;
		if (!iconRoot)
		{
			iconRoot = transform;
		}
		_shortcutIconPrefab = (GameObject)GameAssetModule.LoadPrefab(shortcutIconPrefab);
	}

	public static void SceneChangeEvent()
	{
		IsSceneFromShortcut = ShortcutIcon.IsUseShortcut;
		ShortcutIcon.IsUseShortcut = false;
	}

	public static void Reflesh()
	{
		if ((bool)CurrentInstance)
		{
			CurrentInstance.lastSceneName = string.Empty;
		}
	}

	public void OnDisable()
	{
		bool flag = false;
	}

	public void OnApplicationPause(bool pause)
	{
		Reflesh();
	}

	public bool IsShowScene()
	{
		if (!questMan)
		{
			throw new AssertionFailedException("questMan");
		}
		if (lastSceneName != SceneChanger.CurrentSceneName)
		{
			lastSceneName = SceneChanger.CurrentSceneName;
			showScene = false;
			int i = 0;
			string[] array = showStartSceneNames;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (SceneChanger.CurrentSceneName.StartsWith(array[i]))
				{
					showScene = true;
					SetupShortcutIconCore();
				}
				if (showScene)
				{
					break;
				}
			}
		}
		if (showScene)
		{
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
		}
		return showScene;
	}

	public void Update()
	{
		if (DailyTask.IsNewDay)
		{
			if (!newDayFlag)
			{
				Reflesh();
				newDayFlag = true;
			}
		}
		else
		{
			newDayFlag = false;
		}
		bool flag = IsShowScene();
		iconRoot.gameObject.SetActive(flag);
	}

	public static void SetupShortcutIcon(Transform parent)
	{
		BattleHUDEventShortcut instance = Instance;
		instance.AddPrefab(parent, instance.gameObject);
		instance.SetupShortcutIconCore();
	}

	public static void ClearShortcutIcon()
	{
		BattleHUDEventShortcut instance = Instance;
		instance.ClearShortcutIconCore();
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
		int num3 = 0;
		int num4 = 0;
		int i = 0;
		MShortcutIcons[] all = MShortcutIcons.All;
		checked
		{
			float num6 = default(float);
			float num7 = default(float);
			for (int length = all.Length; i < length; i++)
			{
				if (!all[i].EventShortcut)
				{
					continue;
				}
				int num5 = num3;
				ShortcutIcon shortcutIcon = null;
				if (shortcutIcons.ContainsKey(num5))
				{
					shortcutIcon = shortcutIcons[num5] as ShortcutIcon;
					shortcutIcon.gameObject.SetActive(value: true);
				}
				shortcutIcon = SetupShortcutIconCore(all[i], shortcutIcon);
				if ((bool)shortcutIcon)
				{
					num3++;
					if (num == 0 && num2 == 0)
					{
						float bgPadding = ShortcutIcon.bgPadding;
						num6 = ShortcutIcon.iconWidth + bgPadding;
						num7 = ShortcutIcon.iconHeight + bgPadding;
						float num8 = ShortcutIcon.iconWidth * 0.5f;
						float num9 = ShortcutIcon.iconHeight * 0.5f;
						num = (int)num8;
						num2 = (int)num9;
					}
					shortcutIcons[num5] = shortcutIcon;
					Vector3 ofs = new Vector3((float)num - (float)num3 * num6, 0f - ((float)num2 + (float)num4 * num7), shortcutIconZ);
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
		MAreas area = null;
		Hashtable areaGroupTable = questMan.AreaGroupTable;
		object result;
		if (areaGroupTable == null)
		{
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
				area = (MAreas)obj;
			}
			if (!CheckEnableIcon(area, micon.DirectSceneName_1, micon.DirectSceneName_2))
			{
				result = null;
			}
			else
			{
				if (debug)
				{
					goto IL_00fc;
				}
				if (!GameLevelManager.CheckCondition(micon.AllConditions, notFlag: false))
				{
					result = null;
				}
				else
				{
					if (GameLevelManager.CheckCondition(micon.AllNotConditions, notFlag: true))
					{
						goto IL_00fc;
					}
					result = null;
				}
			}
		}
		goto IL_015d;
		IL_015d:
		return (ShortcutIcon)result;
		IL_00fc:
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
			SetupIcon(icon, micon, area);
			result = icon;
		}
		else
		{
			UnityEngine.Object.DestroyObject(gameObject);
			result = null;
		}
		goto IL_015d;
	}

	public void SetupIcon(ShortcutIcon icon, MShortcutIcons micon, MAreas area)
	{
		icon.Setup(micon, area, showFlag: true);
	}

	public void ClearShortcutIconCore()
	{
		setup = false;
		if (shortcutIcons == null)
		{
			return;
		}
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
			if ((bool)shortcutIcon)
			{
				shortcutIcon.gameObject.SetActive(value: false);
			}
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

	public bool CheckEnableIcon(MAreas area, string scene1, string scene2)
	{
		bool flag = true;
		checked
		{
			if (area != null && area.JumpType == EnumAreaTypes.Raid && (scene1 == "Ui_WorldRaid" || scene2 == "Ui_WorldRaid"))
			{
				flag = UserData.Current.userRaidInfo.raidBattle?.IsEnableRaid ?? false;
			}
			else if (area != null && area.JumpType == EnumAreaTypes.Challenge && (scene1 == "Ui_WorldChallenge" || scene2 == "Ui_WorldChallenge"))
			{
				RespTCycleRaidBattle raidBattle = UserData.Current.userRaidInfo.raidBattle;
				if (raidBattle != null)
				{
					flag = false;
				}
				if (flag && questMan.GetQuestList(area.Id, EnumQuestTypes.Challenge, 0) == null)
				{
					flag = false;
				}
			}
			else if (area != null && area.JumpType == EnumAreaTypes.SpecialQuest && (scene1 == "Ui_WorldQuest" || scene2 == "Ui_WorldQuest"))
			{
				MQuests[] curShortSpecialQuestList = questMan.GetCurShortSpecialQuestList(0, nameSort: false, checkTicket: true);
				if (curShortSpecialQuestList.Length == 0)
				{
					flag = false;
				}
			}
			else if (area != null && area.JumpType == EnumAreaTypes.BoostQuest && (scene1 == "Ui_WorldQuest" || scene2 == "Ui_WorldQuest"))
			{
				MQuests[] curShortSpecialQuestList = questMan.GetCurBoostQuestList(0, nameSort: false);
				if (curShortSpecialQuestList.Length == 0)
				{
					flag = false;
				}
			}
			else if (area != null && area.JumpType == EnumAreaTypes.Colosseum && (scene1 == "Ui_WorldColosseum" || scene2 == "Ui_WorldColosseum"))
			{
				if (!questMan.IsColosseumEvent())
				{
					flag = false;
				}
			}
			else if (scene1 == "Town" || scene2 == "Town")
			{
				MNpcTalks[] array = GameLevelManager.SimulateGameLevel("Town");
				flag = false;
				int i = 0;
				MNpcTalks[] array2 = array;
				for (int length = array2.Length; i < length; i++)
				{
					if (array2[i] != null && (array2[i].Icon == EnumNpcTalkIcons.CAUTION || array2[i].DistantIcon == EnumNpcTalkIcons.CAUTION))
					{
						flag = true;
						break;
					}
				}
			}
			else if (scene1 == "Myhome" || scene2 == "Myhome")
			{
				MNpcTalks[] array = GameLevelManager.SimulateGameLevel("Myhome");
				flag = false;
				int j = 0;
				MNpcTalks[] array3 = array;
				for (int length2 = array3.Length; j < length2; j++)
				{
					if (array3[j] != null && (array3[j].Icon == EnumNpcTalkIcons.CAUTION || array3[j].DistantIcon == EnumNpcTalkIcons.CAUTION))
					{
						flag = true;
						break;
					}
				}
			}
			else
			{
				flag = false;
			}
			return flag;
		}
	}
}
