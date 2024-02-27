using System;
using System.Collections;
using System.Text;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class ShortcutIcon : MonoBehaviour
{
	[NonSerialized]
	public static float iconWidth = 80f;

	[NonSerialized]
	public static float iconHeight = 80f;

	[NonSerialized]
	public static float bgPadding = 20f;

	[NonSerialized]
	public static string lastShortcutScnenName;

	[NonSerialized]
	public static bool isUseShortcut;

	public float shortcutIconWidth;

	public float shortcutIconHeight;

	public float shortcutIconBgPadding;

	public float shortcutIconZ;

	public bool vartDirection;

	public GameObject button;

	protected bool isShow;

	public bool show;

	private bool lastShow;

	public UISprite sprite;

	public UISprite bgSprite;

	public string sceneName1;

	public string sceneName2;

	public MAreas area;

	protected object iconMaster;

	protected MShortcutIcons lastIconMaster;

	protected ModalTouchScreen touchScreen;

	public GameObject backGroundPanelPrefab;

	protected UISprite shortcutBackGroundPanel;

	public string iconName;

	private string lastIconName;

	public string bgName;

	private string lastBgName;

	public Color disableColor;

	protected Color orginalColor;

	public string displayName;

	private string lastDisplayName;

	protected bool enableShortCut;

	protected bool lastEnableShortCut;

	[NonSerialized]
	protected static ShortcutIcon curShowChildIcon;

	public bool debug;

	public GameObject newInfo;

	public UISprite newInfoSprite;

	public UILabelBase newInfoLabel;

	[NonSerialized]
	protected static Hashtable hasNewInfo = new Hashtable();

	protected object lastNoticFlag;

	public ShortcutIcon[] childIcons;

	public bool autoCloseChildIcon;

	public int initChildIconMSec;

	protected int childIconMSec;

	protected int lastChildIconMSec;

	protected bool lastOpenChildIcon;

	protected bool openChildIcon;

	public float childIconDuration;

	protected string currentSceneName;

	protected int playerConditionNumber;

	protected QuestManager questMan;

	protected float delay;

	protected Transform fontTf;

	public MShortcutIcons IconMaster => iconMaster as MShortcutIcons;

	public ShortcutIcon AddChildeIcon
	{
		set
		{
			if ((bool)value)
			{
				childIcons = (ShortcutIcon[])RuntimeServices.AddArrays(typeof(ShortcutIcon), childIcons, new ShortcutIcon[1] { value });
				Vector3 localPosition = value.transform.localPosition;
				Vector3 localScale = value.transform.localScale;
				value.transform.parent = gameObject.transform;
				value.transform.localPosition = localPosition;
				value.transform.localScale = localScale;
				value.gameObject.SetActive(value: false);
			}
		}
	}

	public static float IconWidth
	{
		get
		{
			return iconWidth;
		}
		set
		{
			iconWidth = value;
		}
	}

	public static float IconHeight
	{
		get
		{
			return iconHeight;
		}
		set
		{
			iconHeight = value;
		}
	}

	public static float BgPadding
	{
		get
		{
			return bgPadding;
		}
		set
		{
			bgPadding = value;
		}
	}

	public static bool IsUseShortcut
	{
		get
		{
			return isUseShortcut;
		}
		set
		{
			isUseShortcut = value;
		}
	}

	public bool IsShow => isShow;

	public bool EnableShortcut
	{
		get
		{
			return enableShortCut;
		}
		set
		{
			enableShortCut = value;
		}
	}

	public ShortcutIcon()
	{
		shortcutIconWidth = 80f;
		shortcutIconHeight = 80f;
		shortcutIconBgPadding = 20f;
		shortcutIconZ = 20f;
		disableColor = new Color(0.5f, 0.5f, 0.5f, 1f);
		enableShortCut = true;
		childIcons = new ShortcutIcon[0];
		initChildIconMSec = 3000;
		childIconDuration = 0.1f;
		playerConditionNumber = -1;
	}

	public static void NoticeNewInfo(string progName)
	{
		UpdateNoticeFlag(progName, b: true);
	}

	public static void UpdateNoticeFlag(string progName, bool b)
	{
		hasNewInfo[progName] = b;
	}

	public static void UpdateNoticeCount(string progName, int n)
	{
		hasNewInfo[progName] = n;
	}

	public static object NoticeNow(string progName)
	{
		return (!hasNewInfo.ContainsKey(progName)) ? null : hasNewInfo[progName];
	}

	public object NoticeNow()
	{
		return (!RuntimeServices.ToBool(iconMaster)) ? null : NoticeNow(IconMaster.Progname);
	}

	public void Awake()
	{
		questMan = QuestManager.Instance;
		iconWidth = shortcutIconWidth;
		iconHeight = shortcutIconHeight;
		bgPadding = shortcutIconBgPadding;
		button.SetActive(value: false);
		newInfo.SetActive(value: false);
		if ((bool)sprite)
		{
			orginalColor = sprite.color;
		}
		lastEnableShortCut = true;
		lastShortcutScnenName = string.Empty;
	}

	public void Setup(MShortcutIcons micon, MAreas marea, bool showFlag)
	{
		iconMaster = micon;
		iconName = micon.Icon;
		bgName = micon.Bg;
		displayName = micon.GetName();
		sceneName1 = micon.DirectSceneName_1;
		sceneName2 = micon.DirectSceneName_2;
		area = marea;
		show = showFlag;
		if (area == null)
		{
			area = QuestManager.Instance.GetAreaFromSceneName(sceneName1);
		}
		if (area == null)
		{
			area = QuestManager.Instance.GetAreaFromSceneName(sceneName2);
		}
		if ((bool)bgSprite && bgName != lastBgName)
		{
			lastBgName = bgName;
			if (!string.IsNullOrEmpty(bgName))
			{
				bgSprite.spriteName = bgName;
			}
		}
		if ((bool)sprite)
		{
			if (iconName != lastIconName)
			{
				lastIconName = iconName;
				if (!string.IsNullOrEmpty(iconName))
				{
					sprite.spriteName = iconName;
				}
				if (!sprite.atlas)
				{
					show = false;
				}
			}
			if (displayName != lastDisplayName)
			{
				lastDisplayName = displayName;
				SetDisplayName(active: true);
			}
		}
		else
		{
			show = false;
		}
		UpdateCore(reset: true);
	}

	public void ToInvisible()
	{
		show = false;
		UpdateCore(reset: true);
	}

	public void OnEnable()
	{
		delay = 0.5f;
		TweenColor.Begin(sprite.gameObject, 0f, disableColor);
		Update();
	}

	public void Update()
	{
		bool flag = false;
		int num = playerConditionNumber;
		playerConditionNumber = UserData.Current.userMiscInfo.flagData.ConditionNumber;
		if (playerConditionNumber != num)
		{
			flag = true;
		}
		else if (SceneChanger.CurrentSceneName != currentSceneName)
		{
			flag = true;
			currentSceneName = SceneChanger.CurrentSceneName;
		}
		UpdateCore(flag);
		if (isShow && flag)
		{
			CheckNew();
		}
	}

	public bool IsEnableShortcut()
	{
		bool result = true;
		if (NpcTalkControl.IsBusy)
		{
			result = false;
		}
		if (MerlinServer.Busy)
		{
			result = false;
		}
		if (!SceneChanger.isFadeOut)
		{
			result = false;
		}
		if (DialogManager.DialogCount > 0)
		{
			result = false;
		}
		if (EventWindow.isWindow)
		{
			result = false;
		}
		if (!FaderCore.Instance.isOutCompleted)
		{
			result = false;
		}
		if (!MerlinTaskQueue.Instance.IsEmpty)
		{
			result = false;
		}
		if (StartButton.Paused)
		{
			result = false;
		}
		return result;
	}

	public void UpdateCore(bool reset)
	{
		bool flag = false;
		if (show != lastShow || reset)
		{
			lastIconMaster = null;
			lastShow = show;
		}
		if (!RuntimeServices.EqualityOperator(lastIconMaster, iconMaster))
		{
			object obj = iconMaster;
			if (!(obj is MShortcutIcons))
			{
				obj = RuntimeServices.Coerce(obj, typeof(MShortcutIcons));
			}
			lastIconMaster = (MShortcutIcons)obj;
			flag = show;
			if (area == null && string.IsNullOrEmpty(sceneName1) && string.IsNullOrEmpty(sceneName2) && childIcons.Length <= 0)
			{
				flag = false;
			}
			else if (sceneName1 == "Ui_WorldRaid" || sceneName2 == "Ui_WorldRaid")
			{
				flag = UserData.Current.userRaidInfo.raidBattle != null && UserData.Current.userRaidInfo.raidBattle.IsEnableRaid;
			}
			else if (sceneName1 == "Ui_WorldChallenge" || sceneName2 == "Ui_WorldChallenge")
			{
				if (UserData.Current.userRaidInfo.raidBattle != null)
				{
					flag = false;
				}
				if ((bool)questMan && questMan.GetQuestList(0, EnumQuestTypes.Challenge, 0) == null)
				{
					flag = false;
				}
			}
			else if ((sceneName1 == "Ui_WorldColosseum" || sceneName2 == "Ui_WorldColosseum") && (bool)questMan && !questMan.IsColosseumEvent())
			{
				flag = false;
			}
			bool num = flag;
			if (!num)
			{
				num = debug;
			}
			flag = num;
			isShow = flag;
			button.SetActive(flag);
			SetDisplayName(flag);
		}
		lastShow = isShow;
		bool flag2 = default(bool);
		if (isShow)
		{
			if (!(delay <= 0f))
			{
				delay -= Time.deltaTime;
			}
			flag2 = false;
			if (button.active)
			{
				flag2 = IsEnableShortcut();
			}
			if (debug)
			{
				flag2 = true;
			}
			bool num2 = flag2;
			if (num2)
			{
				num2 = enableShortCut;
			}
			if (num2)
			{
				num2 = !(delay > 0f);
			}
			flag2 = num2;
			if (lastEnableShortCut != flag2)
			{
				lastEnableShortCut = flag2;
				if (!flag2)
				{
					TweenColor.Begin(sprite.gameObject, 0.3f, disableColor);
				}
				else
				{
					TweenColor.Begin(sprite.gameObject, 0.3f, orginalColor);
				}
			}
		}
		if (!flag2)
		{
			return;
		}
		object obj2 = NoticeNow();
		if (RuntimeServices.ToBool(iconMaster))
		{
			if (childIconMSec > 0)
			{
				obj2 = false;
			}
			else
			{
				int i = 0;
				ShortcutIcon[] array = childIcons;
				for (int length = array.Length; i < length; i = checked(i + 1))
				{
					ShortcutIcon shortcutIcon = array[i].gameObject.GetComponentsInChildren<ShortcutIcon>(includeInactive: true)[0];
					object obj3 = shortcutIcon.NoticeNow();
					if (obj3 != null)
					{
						if (obj2 == null)
						{
							obj2 = true;
						}
						break;
					}
				}
			}
		}
		if (RuntimeServices.EqualityOperator(obj2, lastNoticFlag))
		{
			return;
		}
		newInfo.SetActive(value: false);
		newInfoLabel.text = string.Empty;
		lastNoticFlag = obj2;
		if (obj2 == null)
		{
			return;
		}
		if (RuntimeServices.EqualityOperator(obj2.GetType(), typeof(bool)))
		{
			newInfoSprite.spriteName = "icon_next";
			newInfo.SetActive(RuntimeServices.UnboxBoolean(obj2));
		}
		if (!RuntimeServices.EqualityOperator(obj2.GetType(), typeof(int)))
		{
			return;
		}
		int num3 = RuntimeServices.UnboxInt32(obj2);
		if (num3 > 0)
		{
			if (num3 > 99)
			{
				num3 = 99;
			}
			newInfoSprite.spriteName = "icon_next2";
			newInfo.SetActive(value: true);
			newInfoLabel.text = new StringBuilder().Append((object)num3).ToString();
		}
	}

	public void SetDisplayName(bool active)
	{
		if (!fontTf)
		{
			fontTf = this.transform.Find("Font");
		}
		if (!fontTf)
		{
			return;
		}
		IEnumerator enumerator = fontTf.transform.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			Transform transform = (Transform)obj;
			UILabelBase component = transform.gameObject.GetComponent<UILabelBase>();
			if ((bool)component)
			{
				component.text = displayName;
				component.gameObject.SetActive(active);
			}
		}
	}

	public void ShortCut()
	{
		if (gameObject.active && lastEnableShortCut && delay <= 0f && IsEnableShortcut())
		{
			string ignoreSceneName = currentSceneName;
			if (!string.IsNullOrEmpty(BattleHUDShortcut.Instance.IgnoreSceneName))
			{
				ignoreSceneName = BattleHUDShortcut.Instance.IgnoreSceneName;
			}
			Jump(area, sceneName1, sceneName2, ignoreSceneName);
		}
	}

	public static void Jump(MAreas targetArea, string scene1, string scene2)
	{
		Jump(targetArea, scene1, scene2, string.Empty);
	}

	public static void Jump(MAreas targetArea, string scene1, string scene2, string ignoreSceneName)
	{
		bool flag = false;
		if (targetArea != null)
		{
			SceneID sceneForJumpArea = QuestManager.GetSceneForJumpArea(targetArea);
			if ((ignoreSceneName != SceneIDModule.SceneIDToName(sceneForJumpArea) || ((sceneForJumpArea == SceneID.Ui_WorldQuest || sceneForJumpArea == SceneID.Ui_WorldRaid || sceneForJumpArea == SceneID.Ui_WorldChallenge) && !RuntimeServices.EqualityOperator(targetArea, QuestManager.Instance.CurArea))) && QuestManager.Instance.SetAndJumpArea(targetArea))
			{
				flag = true;
			}
		}
		else if (ignoreSceneName != scene1 && !string.IsNullOrEmpty(scene1))
		{
			lastShortcutScnenName = scene1;
			SceneChanger.Change(scene1);
			flag = true;
		}
		else if (ignoreSceneName != scene2 && !string.IsNullOrEmpty(scene2))
		{
			lastShortcutScnenName = scene2;
			SceneChanger.Change(scene2);
			flag = true;
		}
		if (flag)
		{
			SceneChanger.ScenePreChangeEvent += ShortcutSceneChangePrevOneshotEvent;
			GameLevelManager.Instance.SceneChangeWait = true;
			GameSoundManager.FromShortcut = true;
			UIButtonMessage.AllDisable = true;
			IsUseShortcut = true;
		}
	}

	public static void ShortcutSceneChangePrevOneshotEvent(string newSceneName)
	{
		SceneChanger.ScenePreChangeEvent -= ShortcutSceneChangePrevOneshotEvent;
		TownShopTopMain.DestroyTownModel(destroy: true);
		MyhomeSubSceneTopMain.DestroyMyhomeModel(destroy: true);
		UIButtonMessage.AllDisable = false;
	}

	public void TouchScreen(GameObject obj)
	{
		openChildIcon = false;
	}

	public void CheckNew()
	{
		if (!debug)
		{
			CheckNewWorldMap();
			CheckNewTownNpc();
			CheckNewMyhomeNpc();
			CheckNewPresent();
			CheckNewGacha();
			CheckMessageBoard();
			CheckDiary();
		}
	}

	public bool IsIconMasterStartsWith(string progname)
	{
		return RuntimeServices.ToBool(iconMaster) && IconMaster.Progname.StartsWith(progname);
	}

	public void CheckNewWorldMap()
	{
		if (IconMaster == null || !IsIconMasterStartsWith("World"))
		{
			return;
		}
		if (!questMan)
		{
			questMan = QuestManager.Instance;
		}
		bool flag = UserData.Current.userMiscInfo.questData.hasDiscover();
		if (!flag && questMan.Areas != null)
		{
			int i = 0;
			MAreas[] areas = questMan.Areas;
			for (int length = areas.Length; i < length; i = checked(i + 1))
			{
				if (QuestManager.IsAreaNewQuest(areas[i]))
				{
					flag = true;
					break;
				}
			}
		}
		if (flag)
		{
			NoticeNewInfo(IconMaster.Progname);
		}
		else
		{
			UpdateNoticeFlag(IconMaster.Progname, b: false);
		}
	}

	public void CheckNewTownNpc()
	{
		if (IconMaster == null || !IsIconMasterStartsWith("Town"))
		{
			return;
		}
		MNpcTalks[] array = GameLevelManager.SimulateGameLevel("Town");
		bool flag = false;
		int i = 0;
		MNpcTalks[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			if (array2[i] != null && (array2[i].Icon == EnumNpcTalkIcons.CAUTION || array2[i].DistantIcon == EnumNpcTalkIcons.CAUTION))
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			NoticeNewInfo(IconMaster.Progname);
		}
		else
		{
			UpdateNoticeFlag(IconMaster.Progname, b: false);
		}
	}

	public void CheckNewMyhomeNpc()
	{
		if (IconMaster == null || !IsIconMasterStartsWith("MyHome"))
		{
			return;
		}
		MNpcTalks[] array = GameLevelManager.SimulateGameLevel("Myhome");
		bool flag = false;
		int i = 0;
		MNpcTalks[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			if (array2[i] != null && (array2[i].Icon == EnumNpcTalkIcons.CAUTION || array2[i].DistantIcon == EnumNpcTalkIcons.CAUTION))
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			NoticeNewInfo(IconMaster.Progname);
		}
		else
		{
			UpdateNoticeFlag(IconMaster.Progname, b: false);
		}
	}

	public void CheckNewPresent()
	{
		if (IconMaster != null && IsIconMasterStartsWith("Gift"))
		{
			UpdateNoticeCount(IconMaster.Progname, UserData.Current.NewPresentData);
		}
	}

	public void CheckNewGacha()
	{
		if (IconMaster != null && IsIconMasterStartsWith("Lottery"))
		{
			UpdateNoticeCount(IconMaster.Progname, UserData.Current.GetFriendGachaCount());
		}
	}

	public void CheckMessageBoard()
	{
		checked
		{
			if (IconMaster != null && IsIconMasterStartsWith("MessageBoard"))
			{
				int newFriendData = UserData.Current.NewFriendData;
				newFriendData += UserData.Current.NewFriendApplyData;
				if (true)
				{
					newFriendData += UserData.Current.NewPartyMemberData;
					newFriendData += UserData.Current.NewPartyApplyData;
				}
				UpdateNoticeCount(IconMaster.Progname, newFriendData);
			}
		}
	}

	public bool CheckDiary()
	{
		int result;
		checked
		{
			if (IconMaster != null && IsIconMasterStartsWith("StoryBook"))
			{
				int num = 0;
				UserData current = UserData.Current;
				if (current == null)
				{
					result = 0;
					goto IL_00a9;
				}
				DateTime utcNow = MerlinDateTime.UtcNow;
				bool flag = false;
				int i = 0;
				MStoryBooks[] all = MStoryBooks.All;
				for (int length = all.Length; i < length; i++)
				{
					if (QuestManager.CheckQuestStoryDiary(all[i], utcNow) && current.userMiscInfo.diaryData.getDiaryState(all[i]) <= 0)
					{
						num++;
					}
				}
				UpdateNoticeCount(IconMaster.Progname, num);
			}
			result = 0;
			goto IL_00a9;
		}
		IL_00a9:
		return (byte)result != 0;
	}
}
