using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class QuestManager : MonoBehaviour
{
	[Serializable]
	public enum DebugMode
	{
		None,
		Challenge,
		Raid
	}

	[Serializable]
	internal class _0024PopupNewQuestCtrl_0024locals_002414422
	{
		internal MQuests _0024quest;

		internal string _0024questName;
	}

	[Serializable]
	internal class _0024PutAreaIcon_0024locals_002414423
	{
		internal GameObject _0024areaIcon;

		internal MAreas _0024area;
	}

	[Serializable]
	internal class _0024_0024_0024PopupNewQuestCtrl_0024closure_00243777_0024closure_00243778_0024locals_002414424
	{
		internal UITweener[] _0024tweens;

		internal int _0024tweenNum;

		internal bool _0024close;
	}

	[Serializable]
	internal class _0024_0024_0024PopupNewQuestCtrl_0024closure_00243777_0024closure_00243778_0024closure_00243779
	{
		internal _0024_0024_0024PopupNewQuestCtrl_0024closure_00243777_0024closure_00243778_0024locals_002414424 _0024_0024locals_002414961;

		public _0024_0024_0024PopupNewQuestCtrl_0024closure_00243777_0024closure_00243778_0024closure_00243779(_0024_0024_0024PopupNewQuestCtrl_0024closure_00243777_0024closure_00243778_0024locals_002414424 _0024_0024locals_002414961)
		{
			this._0024_0024locals_002414961 = _0024_0024locals_002414961;
		}

		public void Invoke()
		{
			_0024_0024locals_002414961._0024tweenNum = checked(_0024_0024locals_002414961._0024tweenNum - 1);
		}
	}

	[Serializable]
	internal class _0024_0024_0024PopupNewQuestCtrl_0024closure_00243777_0024closure_00243778_0024closure_00243780
	{
		internal _0024_0024_0024PopupNewQuestCtrl_0024closure_00243777_0024closure_00243778_0024locals_002414424 _0024_0024locals_002414962;

		public _0024_0024_0024PopupNewQuestCtrl_0024closure_00243777_0024closure_00243778_0024closure_00243780(_0024_0024_0024PopupNewQuestCtrl_0024closure_00243777_0024closure_00243778_0024locals_002414424 _0024_0024locals_002414962)
		{
			this._0024_0024locals_002414962 = _0024_0024locals_002414962;
		}

		public void Invoke(int index)
		{
			if (_0024_0024locals_002414962._0024tweenNum <= 0)
			{
				_0024_0024locals_002414962._0024close = true;
			}
			else
			{
				if (_0024_0024locals_002414962._0024tweenNum <= 0)
				{
					return;
				}
				int i = 0;
				UITweener[] _0024tweens = _0024_0024locals_002414962._0024tweens;
				for (int length = _0024tweens.Length; i < length; i = checked(i + 1))
				{
					UIAutoTweener component = _0024tweens[i].gameObject.GetComponent<UIAutoTweener>();
					if ((bool)component)
					{
						component.enabled = false;
					}
					Animation component2 = _0024tweens[i].gameObject.GetComponent<Animation>();
					if ((bool)component2)
					{
						IEnumerator enumerator = component2.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							if (!(obj is AnimationState))
							{
								obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
							}
							AnimationState animationState = (AnimationState)obj;
							animationState.time = animationState.length;
						}
						component2.Sample();
						component2.enabled = false;
					}
					_0024tweens[i].delay = 0f;
					_0024tweens[i].style = UITweener.Style.Once;
					_0024tweens[i].method = UITweener.Method.Linear;
					_0024tweens[i].Sample(1f, isFinished: true);
					_0024tweens[i].enabled = false;
					_0024tweens[i].onFinished(_0024tweens[i]);
				}
			}
		}
	}

	[Serializable]
	internal class _0024_0024PopupNewQuestCtrl_0024closure_00243777_0024closure_00243778
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002418895 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal DialogManager _0024dlgMan_002418896;

				internal SQEX_SoundPlayer _0024sndMan_002418897;

				internal UIAutoTweener[] _0024ats_002418898;

				internal UIAutoTweener _0024at_002418899;

				internal UITweener _0024tween_002418900;

				internal float _0024_0024wait_sec_0024temp_00241722_002418901;

				internal int _0024_00249576_002418902;

				internal UIAutoTweener[] _0024_00249577_002418903;

				internal int _0024_00249578_002418904;

				internal int _0024_00249580_002418905;

				internal UITweener[] _0024_00249581_002418906;

				internal int _0024_00249582_002418907;

				internal _0024_0024_0024PopupNewQuestCtrl_0024closure_00243777_0024closure_00243778_0024locals_002414424 _0024_0024locals_002418908;

				internal _0024_0024PopupNewQuestCtrl_0024closure_00243777_0024closure_00243778 _0024self__002418909;

				public _0024(_0024_0024PopupNewQuestCtrl_0024closure_00243777_0024closure_00243778 self_)
				{
					_0024self__002418909 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					checked
					{
						switch (_state)
						{
						default:
							_0024_0024locals_002418908 = new _0024_0024_0024PopupNewQuestCtrl_0024closure_00243777_0024closure_00243778_0024locals_002414424();
							if (!_0024self__002418909._0024this_002414965.IsEnableNewQuestCtrl(igonoreQue: true))
							{
								_0024self__002418909._0024this_002414965.taskCompleted = true;
								goto case 1;
							}
							_0024self__002418909._0024this_002414965.isNowPopNewQuest = true;
							if ((bool)_0024self__002418909._0024this_002414965.player)
							{
								_0024self__002418909._0024this_002414965.player.InputActive = false;
							}
							_0024dlgMan_002418896 = DialogManager.Instance;
							if (!_0024dlgMan_002418896)
							{
								throw new AssertionFailedException("dlgMan");
							}
							_0024dlgMan_002418896.OnButton(0);
							TheWorld.StopWorldAll(_0024self__002418909._0024this_002414965);
							goto case 2;
						case 2:
							if (!TheWorld.WorldIsStopped)
							{
								result = (YieldDefault(2) ? 1 : 0);
								break;
							}
							_0024self__002418909._0024this_002414965.newQuestDialog = _0024dlgMan_002418896.OpenDialog(new StringBuilder("『").Append(_0024self__002418909._0024_0024locals_002414966._0024questName).Append("』\nが発生しました。").ToString(), string.Empty, autoClose: false, DialogManager.MB_FLAG.MB_NONE, new string[1] { "OK" }, 0);
							if (!_0024self__002418909._0024this_002414965.newQuestDialog)
							{
								TheWorld.RestartWorld();
								goto case 3;
							}
							_0024self__002418909._0024this_002414965.newQuestDialog.ButtonHandler = null;
							_0024sndMan_002418897 = SQEX_SoundPlayer.Instance;
							if ((bool)_0024sndMan_002418897)
							{
								_0024sndMan_002418897.PlaySe(233, 0, _0024self__002418909._0024this_002414965.gameObject.GetInstanceID());
							}
							_0024ats_002418898 = _0024self__002418909._0024this_002414965.newQuestDialog.GetComponentsInChildren<UIAutoTweener>(includeInactive: true);
							_0024_00249576_002418902 = 0;
							_0024_00249577_002418903 = _0024ats_002418898;
							for (_0024_00249578_002418904 = _0024_00249577_002418903.Length; _0024_00249576_002418902 < _0024_00249578_002418904; _0024_00249576_002418902++)
							{
								if ((bool)_0024_00249577_002418903[_0024_00249576_002418902])
								{
									_0024_00249577_002418903[_0024_00249576_002418902].Reset(null);
								}
							}
							goto case 4;
						case 3:
							if (TheWorld.WorldIsStopped)
							{
								result = (YieldDefault(3) ? 1 : 0);
								break;
							}
							_0024self__002418909._0024this_002414965.taskCompleted = true;
							goto case 1;
						case 4:
							if (!_0024self__002418909._0024this_002414965.newQuestDialog.gameObject.active)
							{
								result = (YieldDefault(4) ? 1 : 0);
								break;
							}
							_0024_0024locals_002418908._0024tweens = _0024self__002418909._0024this_002414965.newQuestDialog.GetComponentsInChildren<UITweener>();
							_0024_0024locals_002418908._0024tweenNum = 0;
							_0024_00249580_002418905 = 0;
							_0024_00249581_002418906 = _0024_0024locals_002418908._0024tweens;
							for (_0024_00249582_002418907 = _0024_00249581_002418906.Length; _0024_00249580_002418905 < _0024_00249582_002418907; _0024_00249580_002418905++)
							{
								if (_0024_00249581_002418906[_0024_00249580_002418905].style == UITweener.Style.Once)
								{
									_0024_0024locals_002418908._0024tweenNum++;
									_0024_00249581_002418906[_0024_00249580_002418905].onFinished = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024OnFinished_0024157.Adapt(new _0024_0024_0024PopupNewQuestCtrl_0024closure_00243777_0024closure_00243778_0024closure_00243779(_0024_0024locals_002418908).Invoke);
								}
							}
							_0024self__002418909._0024this_002414965.dispNewQuest.Remove(_0024self__002418909._0024_00249480_002414963[_0024self__002418909._0024_00249479_002414964]);
							if (!UserData.Current.userMiscInfo.questData.isDiscover(_0024self__002418909._0024_0024locals_002414966._0024quest.Id))
							{
								UserData.Current.userMiscInfo.questData.discover(_0024self__002418909._0024_0024locals_002414966._0024quest.Id);
							}
							_0024_0024wait_sec_0024temp_00241722_002418901 = 0.5f;
							goto case 5;
						case 5:
							if (_0024_0024wait_sec_0024temp_00241722_002418901 > 0f)
							{
								_0024_0024wait_sec_0024temp_00241722_002418901 -= Time.deltaTime;
								result = (YieldDefault(5) ? 1 : 0);
								break;
							}
							_0024_0024locals_002418908._0024close = false;
							_0024self__002418909._0024this_002414965.newQuestDialog.ButtonHandler = new _0024_0024_0024PopupNewQuestCtrl_0024closure_00243777_0024closure_00243778_0024closure_00243780(_0024_0024locals_002418908).Invoke;
							goto case 6;
						case 6:
							if (!_0024_0024locals_002418908._0024close)
							{
								result = (YieldDefault(6) ? 1 : 0);
								break;
							}
							_0024self__002418909._0024this_002414965.newQuestDialog.CloseImmediate();
							TheWorld.RestartWorld();
							goto case 7;
						case 7:
							if (TheWorld.WorldIsStopped)
							{
								result = (YieldDefault(7) ? 1 : 0);
								break;
							}
							_0024self__002418909._0024this_002414965.taskCompleted = true;
							YieldDefault(1);
							goto case 1;
						case 1:
							result = 0;
							break;
						}
					}
					return (byte)result != 0;
				}
			}

			internal _0024_0024PopupNewQuestCtrl_0024closure_00243777_0024closure_00243778 _0024self__002418910;

			public _0024Invoke_002418895(_0024_0024PopupNewQuestCtrl_0024closure_00243777_0024closure_00243778 self_)
			{
				_0024self__002418910 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002418910);
			}
		}

		internal object[] _0024_00249480_002414963;

		internal int _0024_00249479_002414964;

		internal QuestManager _0024this_002414965;

		internal _0024PopupNewQuestCtrl_0024locals_002414422 _0024_0024locals_002414966;

		public _0024_0024PopupNewQuestCtrl_0024closure_00243777_0024closure_00243778(object[] _0024_00249480_002414963, int _0024_00249479_002414964, QuestManager _0024this_002414965, _0024PopupNewQuestCtrl_0024locals_002414422 _0024_0024locals_002414966)
		{
			this._0024_00249480_002414963 = _0024_00249480_002414963;
			this._0024_00249479_002414964 = _0024_00249479_002414964;
			this._0024this_002414965 = _0024this_002414965;
			this._0024_0024locals_002414966 = _0024_0024locals_002414966;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002418895(this).GetEnumerator();
		}
	}

	[Serializable]
	internal class _0024PopupNewQuestCtrl_0024closure_00243777
	{
		internal QuestManager _0024this_002414967;

		internal object[] _0024_00249480_002414968;

		internal int _0024_00249479_002414969;

		internal _0024PopupNewQuestCtrl_0024locals_002414422 _0024_0024locals_002414970;

		public _0024PopupNewQuestCtrl_0024closure_00243777(QuestManager _0024this_002414967, object[] _0024_00249480_002414968, int _0024_00249479_002414969, _0024PopupNewQuestCtrl_0024locals_002414422 _0024_0024locals_002414970)
		{
			this._0024this_002414967 = _0024this_002414967;
			this._0024_00249480_002414968 = _0024_00249480_002414968;
			this._0024_00249479_002414969 = _0024_00249479_002414969;
			this._0024_0024locals_002414970 = _0024_0024locals_002414970;
		}

		public void Invoke()
		{
			__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024_0024PopupNewQuestCtrl_0024closure_00243777_0024closure_00243778(_0024_00249480_002414968, _0024_00249479_002414969, _0024this_002414967, _0024_0024locals_002414970).Invoke;
			IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
			if (enumerator != null)
			{
				_0024this_002414967.StartCoroutine(enumerator);
			}
		}
	}

	[Serializable]
	internal class _0024PutAreaIcon_0024closure_00243784
	{
		internal _0024PutAreaIcon_0024locals_002414423 _0024_0024locals_002414971;

		internal QuestManager _0024this_002414972;

		public _0024PutAreaIcon_0024closure_00243784(_0024PutAreaIcon_0024locals_002414423 _0024_0024locals_002414971, QuestManager _0024this_002414972)
		{
			this._0024_0024locals_002414971 = _0024_0024locals_002414971;
			this._0024this_002414972 = _0024this_002414972;
		}

		public void Invoke()
		{
			if (!_0024this_002414972.curPushAreaIcon)
			{
				if (_0024this_002414972.SetAndJumpArea(_0024_0024locals_002414971._0024area))
				{
					_0024this_002414972.curPushAreaIcon = _0024_0024locals_002414971._0024areaIcon;
				}
				WorldMain.PushAreaButton(_0024_0024locals_002414971._0024areaIcon);
			}
		}
	}

	[NonSerialized]
	private static QuestManager __instance;

	[NonSerialized]
	protected static bool quitApp;

	protected int areaId;

	[NonSerialized]
	public static DebugMode debugMode = DebugMode.None;

	public string areaIconPrefabPath;

	private GameObject _areaIconPrefab;

	protected Hashtable areaTable;

	public QuestAreaButton[] areaIcons;

	public MAreas[] areas;

	public MAreas curArea;

	public GameObject curPushAreaIcon;

	protected MQuests curQuest;

	protected MStories curStory;

	protected RespWeapon curWeapon;

	protected RespPoppet culPoppet;

	public RespFriendPoppet curFrPoppet;

	public bool startQuest;

	public bool checkBoxOver;

	protected bool setup;

	protected PlayerControl player;

	public bool testFlag;

	public string areaTmpFlag;

	public string questTmpFlag;

	protected int playerConditionNumber;

	protected SceneID lastScene;

	protected SceneID lastSetupScene;

	protected int areaConditionNumber;

	protected int lastAreaConditionNumber;

	protected Hashtable dispNewQuest;

	protected Dialog newQuestDialog;

	protected float waitNewQuest;

	protected bool isNowPopNewQuest;

	public Hashtable inventryCheckScenes;

	protected MerlinTaskQueue.Task task;

	protected bool taskCompleted;

	public static QuestManager Instance
	{
		get
		{
			QuestManager _instance;
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
				__instance = ((QuestManager)UnityEngine.Object.FindObjectOfType(typeof(QuestManager))) as QuestManager;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static QuestManager CurrentInstance => __instance;

	protected GameObject areaIconPrefab
	{
		get
		{
			if (_areaIconPrefab == null)
			{
				_areaIconPrefab = GameAssetModule.LoadPrefab(areaIconPrefabPath) as GameObject;
				if (!(_areaIconPrefab != null))
				{
					throw new AssertionFailedException(new StringBuilder("could not load ").Append(areaIconPrefabPath).ToString());
				}
			}
			return _areaIconPrefab;
		}
	}

	public MQuests CurQuest
	{
		get
		{
			return curQuest;
		}
		set
		{
			if (!RuntimeServices.EqualityOperator(curQuest, value))
			{
				curQuest = value;
				curStory = null;
				MStories mStories = CurStory;
			}
		}
	}

	public MStories CurStory
	{
		get
		{
			object result;
			if (curStory != null)
			{
				result = curStory;
			}
			else if (curQuest == null)
			{
				result = null;
			}
			else
			{
				int num = 0;
				MStories[] all = MStories.All;
				int length = all.Length;
				while (true)
				{
					if (num < length)
					{
						if (RuntimeServices.EqualityOperator(all[num].MQuestId, curQuest))
						{
							curStory = all[num];
							result = curStory;
							break;
						}
						num = checked(num + 1);
						continue;
					}
					result = null;
					break;
				}
			}
			return (MStories)result;
		}
	}

	public Hashtable AreaGroupTable => areaTable;

	public QuestAreaButton[] AreaIcons => areaIcons;

	public MAreas[] Areas => areas;

	public MAreas CurArea => curArea;

	public GameObject CurPushAreaIcon => curPushAreaIcon;

	public RespWeapon CurWeapon
	{
		get
		{
			return curWeapon;
		}
		set
		{
			curWeapon = value;
		}
	}

	public RespPoppet CurPoppet
	{
		get
		{
			return culPoppet;
		}
		set
		{
			culPoppet = value;
		}
	}

	public RespFriendPoppet CurFrPoppet
	{
		get
		{
			return curFrPoppet;
		}
		set
		{
			curFrPoppet = value;
		}
	}

	public bool StartQuest
	{
		get
		{
			return startQuest;
		}
		set
		{
			startQuest = value;
		}
	}

	public bool CheckBoxOver
	{
		get
		{
			return checkBoxOver;
		}
		set
		{
			checkBoxOver = value;
		}
	}

	public string AreaTmpFlag
	{
		get
		{
			return areaTmpFlag;
		}
		set
		{
			areaTmpFlag = value;
		}
	}

	public string QuestTmpFlag
	{
		get
		{
			return questTmpFlag;
		}
		set
		{
			questTmpFlag = value;
		}
	}

	public int AreaConditionNumber
	{
		get
		{
			return areaConditionNumber;
		}
		set
		{
			areaConditionNumber = value;
		}
	}

	public QuestManager()
	{
		areaIconPrefabPath = "Prefab/Quest/QuestAreaButton";
		areaTable = new Hashtable();
		playerConditionNumber = -1;
		lastScene = (SceneID)(-1);
		lastSetupScene = (SceneID)(-1);
		areaConditionNumber = -1;
		lastAreaConditionNumber = -1;
		dispNewQuest = new Hashtable();
		waitNewQuest = 1f;
		inventryCheckScenes = new Hash
		{
			{
				SceneID.Ui_World,
				SceneID.Town
			},
			{
				SceneID.Lottery_UI,
				SceneID.Town
			},
			{
				SceneID.Ui_MyHomeGift,
				SceneID.Myhome
			},
			{
				SceneID.Ui_WorldQuest,
				SceneID.Town
			},
			{
				SceneID.Ui_WorldChallenge,
				SceneID.Town
			},
			{
				SceneID.Ui_WorldColosseum,
				SceneID.Town
			},
			{
				SceneID.Ui_WorldRaid,
				SceneID.Town
			}
		};
	}

	public void _0024singleton_0024awake_00241720()
	{
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00241720();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static QuestManager _createInstance()
	{
		string text = "__" + "QuestManager" + "__";
		GameObject gameObject = new GameObject(text);
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		QuestManager questManager = ExtensionsModule.SetComponent<QuestManager>(gameObject);
		if ((bool)questManager)
		{
			questManager._createInstance_callback();
		}
		return questManager;
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

	public void _0024singleton_0024appQuit_00241721()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00241721();
		quitApp = true;
	}

	public void detachWorldMapTexture()
	{
		_areaIconPrefab = null;
	}

	public bool ExistChalengeQuest()
	{
		if (areas != null)
		{
			int i = 0;
			MAreas[] array = areas;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (array[i].JumpType != EnumAreaTypes.Challenge)
				{
					continue;
				}
				MQuests[] questList = GetQuestList(array[i].Id, EnumQuestTypes.Challenge, 0);
				if (questList == null || 0 >= questList.Length)
				{
					continue;
				}
				goto IL_0057;
			}
		}
		int result = 0;
		goto IL_006a;
		IL_006a:
		return (byte)result != 0;
		IL_0057:
		result = 1;
		goto IL_006a;
	}

	public bool ExistRaidBattle()
	{
		UserData current = UserData.Current;
		int result;
		if (current != null)
		{
			RespTCycleRaidBattle raidBattle = current.userRaidInfo.raidBattle;
			if (raidBattle != null && raidBattle.IsEnableRaid)
			{
				result = 1;
				goto IL_0030;
			}
		}
		result = 0;
		goto IL_0030;
		IL_0030:
		return (byte)result != 0;
	}

	public void OnGUI_()
	{
		if (testFlag && GUILayout.Button("QuestManager Test"))
		{
			testFlag = false;
			Setup();
		}
	}

	public void Start()
	{
		MWeekEventsUtil.CreateQuestTable();
		UserData current = UserData.Current;
		if (current != null)
		{
			playerConditionNumber = current.userMiscInfo.flagData.ConditionNumber;
		}
	}

	public void OnDestory()
	{
		UnityEngine.Object.DestroyObject(gameObject);
	}

	public void Update()
	{
		if (SceneChanger.CurrentScene != lastScene || checkBoxOver)
		{
			checkBoxOver = false;
			lastScene = SceneChanger.CurrentScene;
			if (inventryCheckScenes != null)
			{
				IEnumerator enumerator = inventryCheckScenes.Keys.GetEnumerator();
				while (enumerator.MoveNext())
				{
					SceneID sceneID = (SceneID)enumerator.Current;
					if (SceneChanger.CurrentScene == sceneID && InventoryOverDialog.IsInventoryOver() && !InventoryOverDialog.IsOpenInventoryOverDialog())
					{
						InventoryOverDialog.OpenInventoryOverDialog((SceneID)inventryCheckScenes[sceneID]);
					}
				}
			}
		}
		if (SceneChanger.CurrentScene != lastSetupScene)
		{
			player = PlayerControl.CurrentPlayer;
			if ((bool)player && player.enabled)
			{
				lastSetupScene = SceneChanger.CurrentScene;
				setup = true;
			}
			if ((bool)newQuestDialog)
			{
				newQuestDialog.CloseImmediate();
				newQuestDialog = null;
				TheWorld.RestartWorld();
				taskCompleted = true;
			}
		}
		UserData current = UserData.Current;
		int num = playerConditionNumber;
		if (current != null)
		{
			playerConditionNumber = current.userMiscInfo.flagData.ConditionNumber;
		}
		if (playerConditionNumber != num)
		{
			setup = true;
		}
		if (setup)
		{
			SetupCore();
		}
		if (lastAreaConditionNumber != areaConditionNumber)
		{
			lastAreaConditionNumber = areaConditionNumber;
			CheckNewQuest();
		}
		if (startQuest)
		{
			SetQuestStartInfo();
		}
		AreaTmpFlagCtrl();
		QuestTmpFlagCtrl();
		PopupNewQuestCtrl();
	}

	public void CheckNewQuest()
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			return;
		}
		MQuests[] targetQuestList = GetTargetQuestList(EnumQuestTypes.Normal, UserMiscInfo.QuestData.STATE.None, 0);
		targetQuestList = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), targetQuestList, GetTargetQuestList(EnumQuestTypes.RaidTutorial, UserMiscInfo.QuestData.STATE.None, 0));
		if (targetQuestList != null)
		{
			int i = 0;
			MQuests[] array = targetQuestList;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				dispNewQuest[array[i].Id] = array[i];
			}
			waitNewQuest = 1f;
		}
	}

	public bool IsEnableNewQuestCtrl(bool igonoreQue)
	{
		int result;
		if (isNowPopNewQuest)
		{
			result = 0;
		}
		else
		{
			if (UserData.Current == null)
			{
				waitNewQuest = 1f;
			}
			if ((bool)newQuestDialog)
			{
				waitNewQuest = 1f;
			}
			if (dispNewQuest.Count <= 0)
			{
				waitNewQuest = 1f;
			}
			if (DialogManager.DialogCount > 0)
			{
				waitNewQuest = 1f;
			}
			if (NpcTalkControl.IsBusy)
			{
				waitNewQuest = 1f;
			}
			if (MerlinServer.Busy)
			{
				waitNewQuest = 1f;
			}
			if (TheWorld.WorldIsStopped)
			{
				waitNewQuest = 1f;
			}
			if (!SceneChanger.isFadeOut)
			{
				waitNewQuest = 1f;
			}
			if (!FaderCore.Instance.isOutCompleted)
			{
				waitNewQuest = 1f;
			}
			if (SceneChanger.CurrentScene != SceneID.Town && SceneChanger.CurrentScene != SceneID.Myhome)
			{
				waitNewQuest = 1f;
			}
			if ((bool)player && !player.InputActive)
			{
				waitNewQuest = 1f;
			}
			if (!igonoreQue && !MerlinTaskQueue.Instance.IsEmpty)
			{
				waitNewQuest = 1f;
			}
			if (TutorialEvent.IsBusy)
			{
				waitNewQuest = 1f;
			}
			if (EventWindow.isWindow)
			{
				waitNewQuest = 1f;
			}
			if (CutSceneManager.IsBusy)
			{
				waitNewQuest = 1f;
			}
			result = ((waitNewQuest <= 0f) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public void PopupNewQuestCtrl()
	{
		_0024PopupNewQuestCtrl_0024locals_002414422 _0024PopupNewQuestCtrl_0024locals_0024 = new _0024PopupNewQuestCtrl_0024locals_002414422();
		if (!(waitNewQuest <= 0f))
		{
			waitNewQuest -= Time.deltaTime;
		}
		if (!IsEnableNewQuestCtrl(igonoreQue: false))
		{
			return;
		}
		object[] array = Builtins.array(dispNewQuest.Keys);
		int i = 0;
		object[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			object obj = dispNewQuest[array2[i]];
			if (!(obj is MQuests))
			{
				obj = RuntimeServices.Coerce(obj, typeof(MQuests));
			}
			_0024PopupNewQuestCtrl_0024locals_0024._0024quest = (MQuests)obj;
			if (_0024PopupNewQuestCtrl_0024locals_0024._0024quest == null)
			{
				dispNewQuest.Remove(array2[i]);
				continue;
			}
			if (_0024PopupNewQuestCtrl_0024locals_0024._0024quest.Rank > 1 && _0024PopupNewQuestCtrl_0024locals_0024._0024quest.QuestType == EnumQuestTypes.Normal)
			{
				dispNewQuest.Remove(array2[i]);
				continue;
			}
			if (_0024PopupNewQuestCtrl_0024locals_0024._0024quest.QuestType == EnumQuestTypes.Challenge)
			{
				dispNewQuest.Remove(array2[i]);
				continue;
			}
			_0024PopupNewQuestCtrl_0024locals_0024._0024questName = _0024PopupNewQuestCtrl_0024locals_0024._0024quest.GetName();
			if (_0024PopupNewQuestCtrl_0024locals_0024._0024quest.QuestType == EnumQuestTypes.Special || _0024PopupNewQuestCtrl_0024locals_0024._0024quest.QuestType == EnumQuestTypes.LongTerm || _0024PopupNewQuestCtrl_0024locals_0024._0024quest.QuestType == EnumQuestTypes.Boost)
			{
				if (_0024PopupNewQuestCtrl_0024locals_0024._0024quest.Rank == 1)
				{
					_0024PopupNewQuestCtrl_0024locals_0024._0024questName = new StringBuilder().Append(_0024PopupNewQuestCtrl_0024locals_0024._0024questName).Append("(初級)").ToString();
				}
				if (_0024PopupNewQuestCtrl_0024locals_0024._0024quest.Rank == 2)
				{
					_0024PopupNewQuestCtrl_0024locals_0024._0024questName = new StringBuilder().Append(_0024PopupNewQuestCtrl_0024locals_0024._0024questName).Append("(中級)").ToString();
				}
				if (_0024PopupNewQuestCtrl_0024locals_0024._0024quest.Rank == 3)
				{
					_0024PopupNewQuestCtrl_0024locals_0024._0024questName = new StringBuilder().Append(_0024PopupNewQuestCtrl_0024locals_0024._0024questName).Append("(上級)").ToString();
				}
			}
			if (GameParameter.noQuestDiscoveringPop)
			{
				dispNewQuest.Remove(array2[i]);
				continue;
			}
			task = new MerlinTaskQueue.Task();
			taskCompleted = false;
			task.OnStart = new _0024PopupNewQuestCtrl_0024closure_00243777(this, array2, i, _0024PopupNewQuestCtrl_0024locals_0024).Invoke;
			task.IsCompleted = () => taskCompleted;
			task.OnExit = delegate
			{
				isNowPopNewQuest = false;
				if ((bool)player)
				{
					player.InputActive = true;
				}
			};
			MerlinTaskQueue.Instance.Enqueue(task);
			break;
		}
	}

	public void AreaTmpFlagCtrl()
	{
		if (curArea == null || curArea.TempFlag == null || curArea.TempFlag.Progname == areaTmpFlag)
		{
			return;
		}
		UserData current = UserData.Current;
		if (current == null)
		{
			return;
		}
		if (!string.IsNullOrEmpty(areaTmpFlag))
		{
			current.userMiscInfo.flagData.delete(areaTmpFlag);
			current.userMiscInfo.flagData.deleteAllStartWith(areaTmpFlag + "_");
		}
		if (curArea.TempFlag != null)
		{
			areaTmpFlag = curArea.TempFlag.Progname;
			if (!string.IsNullOrEmpty(areaTmpFlag))
			{
				current.userMiscInfo.flagData.set(areaTmpFlag, 1);
			}
		}
	}

	public void QuestTmpFlagCtrl()
	{
		if (CurQuest == null || CurQuest.TempFlag == null || CurQuest.TempFlag.Progname == questTmpFlag)
		{
			return;
		}
		UserData current = UserData.Current;
		if (current == null)
		{
			return;
		}
		current.userMiscInfo.flagData.delete(questTmpFlag);
		current.userMiscInfo.flagData.deleteAllStartWith(questTmpFlag + "_");
		if (CurQuest.TempFlag != null)
		{
			questTmpFlag = CurQuest.TempFlag.Progname;
			if (!string.IsNullOrEmpty(questTmpFlag))
			{
				current.userMiscInfo.flagData.set(questTmpFlag, 1);
			}
		}
	}

	public void SetQuestStartInfo()
	{
		if (CurQuest == null || CurArea == null || CurQuest.StartSceneId == null || CurQuest.StartSceneId.SceneName != SceneChanger.CurrentSceneName || !FaderCore.Instance.isCompleted || MerlinServer.Instance.IsBusy || !SceneChanger.isFadeOut)
		{
			return;
		}
		startQuest = false;
		string place = null;
		string empty = string.Empty;
		string text = null;
		string info = null;
		if (curArea != null && !string.IsNullOrEmpty(curArea.GetName()))
		{
			place = curArea.GetName();
		}
		if (CurQuest != null)
		{
			if (!string.IsNullOrEmpty(CurQuest.GetName()))
			{
				text = CurQuest.GetName();
			}
			if (!string.IsNullOrEmpty(CurQuest.GetExplain()))
			{
				info = CurQuest.GetExplain();
			}
			if (CurQuest.IsChallenge)
			{
				place = "チャレンジ";
			}
		}
		QuestStartInfo.OpenQuestStartInfo(place, empty, text, info);
	}

	public void Setup()
	{
		setup = true;
	}

	public void SetupCore()
	{
		if (SceneChanger.CurrentScene != SceneID.Ui_World && SceneChanger.CurrentScene != SceneID.Myhome && SceneChanger.CurrentScene != SceneID.Town && SceneChanger.CurrentScene != SceneID.Ui_MessageBoard)
		{
			return;
		}
		MWeekEventsUtil.CreateQuestTable();
		GameObject gameObject = null;
		if (SceneChanger.CurrentScene == SceneID.Ui_World)
		{
			gameObject = GameObject.Find("WorldMap") as GameObject;
		}
		if ((bool)gameObject)
		{
			IEnumerator enumerator = gameObject.transform.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is Transform))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Transform));
				}
				Transform transform = (Transform)obj;
				UnityEngine.Object.DestroyObject(transform.gameObject);
			}
		}
		setup = false;
		areas = SetupAreaIcon(gameObject);
	}

	public MAreas[] SetupAreaIcon(GameObject worldMap)
	{
		areaIcons = new QuestAreaButton[0];
		curArea = null;
		Boo.Lang.List<MAreas> list = new Boo.Lang.List<MAreas>();
		CreatAreaGroupTable();
		curPushAreaIcon = null;
		IEnumerator enumerator = areaTable.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object current = enumerator.Current;
			if (!RuntimeServices.ToBool(areaTable[current]))
			{
				continue;
			}
			if ((bool)worldMap)
			{
				object obj = areaTable[current];
				if (!(obj is MAreas))
				{
					obj = RuntimeServices.Coerce(obj, typeof(MAreas));
				}
				QuestAreaButton questAreaButton = PutAreaIcon(worldMap, (MAreas)obj);
				areaIcons = (QuestAreaButton[])RuntimeServices.AddArrays(typeof(QuestAreaButton), areaIcons, new QuestAreaButton[1] { questAreaButton });
			}
			object obj2 = areaTable[current];
			if (!(obj2 is MAreas))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(MAreas));
			}
			list.Add((MAreas)obj2);
		}
		return list.ToArray();
	}

	public void CreatAreaGroupTable()
	{
		checked
		{
			areaConditionNumber++;
			UserData current = UserData.Current;
			DateTime utcNow = MerlinDateTime.UtcNow;
			areaTable.Clear();
			int i = 0;
			MAreas[] all = MAreas.All;
			for (int length = all.Length; i < length; i++)
			{
				if (utcNow < all[i].BeginPeriod || (all[i].EndPeriod <= utcNow && unchecked((int)all[i].EndPeriod.Ticks) != 0))
				{
					continue;
				}
				bool flag = true;
				if (!GameLevelManager.CheckCondition(all[i].AllConditions, notFlag: false))
				{
					flag = false;
				}
				if (!GameLevelManager.CheckCondition(all[i].AllNotConditions, notFlag: true))
				{
					flag = false;
				}
				if (all[i].JumpType == EnumAreaTypes.Town)
				{
					flag = flag;
				}
				else if (all[i].JumpType == EnumAreaTypes.Myhome)
				{
					flag = flag;
				}
				else if (all[i].JumpType == EnumAreaTypes.Raid)
				{
					flag = debugMode != DebugMode.Challenge && (current.userRaidInfo.raidBattle?.IsEnableRaid ?? false);
				}
				else if (all[i].JumpType == EnumAreaTypes.RaidTutorial)
				{
					flag = debugMode != DebugMode.Challenge && flag;
				}
				else if (all[i].JumpType == EnumAreaTypes.Challenge)
				{
					if (debugMode == DebugMode.Raid)
					{
						flag = false;
					}
					else if (debugMode == DebugMode.Challenge)
					{
						flag = true;
					}
					else
					{
						RespTCycleRaidBattle raidBattle = current.userRaidInfo.raidBattle;
						if (raidBattle != null)
						{
							flag = false;
						}
					}
					if (flag && GetQuestList(all[i].Id, EnumQuestTypes.Challenge, 0) == null)
					{
						flag = false;
					}
				}
				else if (all[i].JumpType == EnumAreaTypes.SpecialQuest)
				{
					MQuests[] curSpecialQuestList = GetCurSpecialQuestList(0, nameSort: false);
					if (curSpecialQuestList.Length == 0)
					{
						flag = false;
					}
				}
				else if (all[i].JumpType == EnumAreaTypes.BoostQuest)
				{
					MQuests[] curSpecialQuestList = GetCurBoostQuestList(0, nameSort: false);
					if (curSpecialQuestList.Length == 0)
					{
						flag = false;
					}
				}
				else if (all[i].JumpType == EnumAreaTypes.Colosseum)
				{
					if (!IsColosseumEvent())
					{
						flag = false;
					}
				}
				else if (GetQuestList(all[i].Id, EnumQuestTypes.Normal, 0) == null && GetQuestList(all[i].Id, EnumQuestTypes.Tutorial, 0) == null)
				{
					flag = false;
				}
				if (flag && all[i].AreaGroup != null)
				{
					areaTable[all[i].AreaGroup.Id] = all[i];
				}
			}
		}
	}

	public QuestAreaButton PutAreaIcon(GameObject worldMap, MAreas area)
	{
		_0024PutAreaIcon_0024locals_002414423 _0024PutAreaIcon_0024locals_0024 = new _0024PutAreaIcon_0024locals_002414423();
		_0024PutAreaIcon_0024locals_0024._0024area = area;
		object result;
		if (null == worldMap)
		{
			result = null;
		}
		else if (_0024PutAreaIcon_0024locals_0024._0024area == null)
		{
			result = null;
		}
		else if (null == areaIconPrefab)
		{
			result = null;
		}
		else
		{
			bool flag = true;
			_0024PutAreaIcon_0024locals_0024._0024areaIcon = ((GameObject)UnityEngine.Object.Instantiate(areaIconPrefab)) as GameObject;
			_0024PutAreaIcon_0024locals_0024._0024areaIcon.SetActive(value: false);
			if (null == _0024PutAreaIcon_0024locals_0024._0024areaIcon)
			{
				result = null;
			}
			else
			{
				if (null == _0024PutAreaIcon_0024locals_0024._0024area.Position)
				{
					UnityEngine.Object.DestroyObject(_0024PutAreaIcon_0024locals_0024._0024areaIcon);
				}
				else if (null == _0024PutAreaIcon_0024locals_0024._0024area.Icon)
				{
					UnityEngine.Object.DestroyObject(_0024PutAreaIcon_0024locals_0024._0024areaIcon);
				}
				else
				{
					if ((EnumAreaTypes)0 < _0024PutAreaIcon_0024locals_0024._0024area.JumpType)
					{
						string[] array = _0024PutAreaIcon_0024locals_0024._0024area.Position.Split(',');
						if (array != null)
						{
							_0024PutAreaIcon_0024locals_0024._0024areaIcon.transform.parent = worldMap.transform;
							_0024PutAreaIcon_0024locals_0024._0024areaIcon.transform.localScale = Vector3.one;
							try
							{
								float x = float.Parse(array[0]);
								Vector3 localPosition = _0024PutAreaIcon_0024locals_0024._0024areaIcon.transform.localPosition;
								float num = (localPosition.x = x);
								Vector3 vector2 = (_0024PutAreaIcon_0024locals_0024._0024areaIcon.transform.localPosition = localPosition);
							}
							catch (Exception)
							{
								int num2 = 0;
								Vector3 localPosition2 = _0024PutAreaIcon_0024locals_0024._0024areaIcon.transform.localPosition;
								float num3 = (localPosition2.x = num2);
								Vector3 vector4 = (_0024PutAreaIcon_0024locals_0024._0024areaIcon.transform.localPosition = localPosition2);
							}
							try
							{
								float y = float.Parse(array[1]);
								Vector3 localPosition3 = _0024PutAreaIcon_0024locals_0024._0024areaIcon.transform.localPosition;
								float num4 = (localPosition3.y = y);
								Vector3 vector6 = (_0024PutAreaIcon_0024locals_0024._0024areaIcon.transform.localPosition = localPosition3);
							}
							catch (Exception)
							{
								int num5 = 0;
								Vector3 localPosition4 = _0024PutAreaIcon_0024locals_0024._0024areaIcon.transform.localPosition;
								float num6 = (localPosition4.y = num5);
								Vector3 vector8 = (_0024PutAreaIcon_0024locals_0024._0024areaIcon.transform.localPosition = localPosition4);
							}
						}
						QuestAreaButton component = _0024PutAreaIcon_0024locals_0024._0024areaIcon.GetComponent<QuestAreaButton>();
						if (null == component)
						{
							UnityEngine.Object.DestroyObject(_0024PutAreaIcon_0024locals_0024._0024areaIcon);
							result = null;
						}
						else
						{
							string icon = default(string);
							if (!string.IsNullOrEmpty(_0024PutAreaIcon_0024locals_0024._0024area.Icon))
							{
								icon = _0024PutAreaIcon_0024locals_0024._0024area.Icon;
							}
							string newAreaName = default(string);
							if (!string.IsNullOrEmpty(_0024PutAreaIcon_0024locals_0024._0024area.GetName()))
							{
								newAreaName = _0024PutAreaIcon_0024locals_0024._0024area.GetName();
							}
							component.Init(_0024PutAreaIcon_0024locals_0024._0024area.Id, icon, newAreaName, _0024PutAreaIcon_0024locals_0024._0024area.No1stIconDemo);
							UIButtonMessage uIButtonMessage = (UIButtonMessage)_0024PutAreaIcon_0024locals_0024._0024areaIcon.GetComponent(typeof(UIButtonMessage));
							if (null != uIButtonMessage)
							{
								uIButtonMessage.eventHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024EventHandler_0024156.Adapt(new _0024PutAreaIcon_0024closure_00243784(_0024PutAreaIcon_0024locals_0024, this).Invoke);
							}
							if (flag)
							{
								_0024PutAreaIcon_0024locals_0024._0024areaIcon.SetActive(value: true);
							}
							else
							{
								UnityEngine.Object.DestroyObject(_0024PutAreaIcon_0024locals_0024._0024areaIcon);
							}
							result = component;
						}
						goto IL_0388;
					}
					UnityEngine.Object.DestroyObject(_0024PutAreaIcon_0024locals_0024._0024areaIcon);
				}
				result = null;
			}
		}
		goto IL_0388;
		IL_0388:
		return (QuestAreaButton)result;
	}

	public void DisbaleAreaIconButton()
	{
		if (areaIcons == null)
		{
			return;
		}
		int i = 0;
		QuestAreaButton[] array = areaIcons;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if ((bool)array[i])
			{
				UIButton uIButton = (UIButton)array[i].GetComponent(typeof(UIButton));
				uIButton.enabled = false;
				UIButtonMessage uIButtonMessage = (UIButtonMessage)array[i].GetComponent(typeof(UIButtonMessage));
				uIButtonMessage.enabled = false;
			}
		}
	}

	public bool SetAndJumpArea(MAreas area)
	{
		int result;
		if (!SceneChanger.isCompletelyReady)
		{
			result = 0;
		}
		else
		{
			MAreas lhs = curArea;
			curArea = area;
			if (area == null)
			{
				result = 0;
			}
			else
			{
				UserData current = UserData.Current;
				if (current != null && area.AreaGroup != null)
				{
					current.userMiscInfo.areaData.play(area.AreaGroup.Id.ToString());
				}
				SceneID sceneForJumpArea = GetSceneForJumpArea(area);
				bool flag = false;
				if (SceneChanger.CurrentScene != sceneForJumpArea || !RuntimeServices.EqualityOperator(lhs, curArea))
				{
					SceneChanger.ChangeTo(sceneForJumpArea);
					flag = true;
				}
				if (flag)
				{
					if (area.JumpType == EnumAreaTypes.Raid)
					{
						WorldRaidMain.SetTutorialFlag(isTuto: false);
					}
					else if (area.JumpType == EnumAreaTypes.RaidTutorial)
					{
						WorldRaidMain.SetTutorialFlag(isTuto: true);
					}
				}
				result = (flag ? 1 : 0);
			}
		}
		return (byte)result != 0;
	}

	public static SceneID GetSceneForJumpArea(MAreas area)
	{
		return (area == null) ? SceneID.__NONE__ : ((area.JumpType == EnumAreaTypes.Quest) ? SceneID.Ui_WorldQuest : ((area.JumpType == EnumAreaTypes.SpecialQuest) ? SceneID.Ui_WorldQuest : ((area.JumpType == EnumAreaTypes.BoostQuest) ? SceneID.Ui_WorldQuest : ((area.JumpType == EnumAreaTypes.Raid) ? SceneID.Ui_WorldRaid : ((area.JumpType == EnumAreaTypes.RaidTutorial) ? SceneID.Ui_WorldRaid : ((area.JumpType == EnumAreaTypes.Town) ? SceneID.Town : ((area.JumpType == EnumAreaTypes.Myhome) ? SceneID.Myhome : ((area.JumpType == EnumAreaTypes.Challenge) ? SceneID.Ui_WorldChallenge : ((area.JumpType != EnumAreaTypes.Colosseum) ? SceneID.__NONE__ : SceneID.Ui_WorldColosseum)))))))));
	}

	public MQuests[] GetCurNormalQuestList(int rank)
	{
		return (curArea == null) ? null : GetQuestList(curArea.Id, EnumQuestTypes.Normal, rank);
	}

	public MQuests[] GetCurTutorialQuestList(int rank)
	{
		return (curArea == null) ? null : GetQuestList(curArea.Id, EnumQuestTypes.Tutorial, rank);
	}

	public MQuests[] GetCurAllNormalQuestList()
	{
		MQuests[] array = new MQuests[0];
		MQuests[] result;
		if (areas == null)
		{
			result = array;
		}
		else
		{
			int i = 0;
			MAreas[] array2 = areas;
			for (int length = array2.Length; i < length; i = checked(i + 1))
			{
				MQuests[] questList = GetQuestList(array2[i].Id, EnumQuestTypes.Normal, 0);
				if (questList != null)
				{
					array = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), array, questList);
				}
			}
			result = array;
		}
		return result;
	}

	public MQuests[] GetCurSpecialQuestList(int rank, bool nameSort)
	{
		MQuests[] array = new MQuests[0];
		int i = 0;
		MAreas[] all = MAreas.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			MQuests[] questList = GetQuestList(all[i].Id, EnumQuestTypes.Special, rank);
			if (questList != null)
			{
				array = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), array, questList);
			}
			MQuests[] questList2 = GetQuestList(all[i].Id, EnumQuestTypes.LongTerm, rank);
			if (questList2 != null)
			{
				array = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), array, questList2);
			}
		}
		if (nameSort)
		{
			Array.Sort(array, (MQuests a, MQuests b) => a.GetName().CompareTo(b.GetName()));
		}
		return array;
	}

	public MQuests[] GetCurBoostQuestList(int rank, bool nameSort)
	{
		MQuests[] array = new MQuests[0];
		int i = 0;
		MAreas[] all = MAreas.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			MQuests[] questList = GetQuestList(all[i].Id, EnumQuestTypes.Boost, rank);
			if (questList != null)
			{
				array = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), array, questList);
			}
		}
		if (nameSort)
		{
			Array.Sort(array, (MQuests a, MQuests b) => a.GetName().CompareTo(b.GetName()));
		}
		return array;
	}

	public MQuests[] GetCurShortSpecialQuestList(int rank, bool nameSort)
	{
		return GetCurShortSpecialQuestList(rank, nameSort, checkTicket: false);
	}

	public MQuests[] GetCurShortSpecialQuestList(int rank, bool nameSort, bool checkTicket)
	{
		MQuests[] array = new MQuests[0];
		MQuests[] array2 = new MQuests[0];
		int i = 0;
		MAreas[] all = MAreas.All;
		checked
		{
			for (int length = all.Length; i < length; i++)
			{
				MQuests[] questList = GetQuestList(all[i].Id, EnumQuestTypes.Special, rank);
				if (questList != null)
				{
					array = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), array, questList);
				}
				MQuests[] questList2 = GetQuestList(all[i].Id, EnumQuestTypes.LongTerm, rank);
				if (questList2 != null)
				{
					array = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), array, questList2);
				}
			}
			int j = 0;
			MQuests[] array3 = array;
			for (int length2 = array3.Length; j < length2; j++)
			{
				if (checkTicket && array3[j].NeedTicket)
				{
					if (MasterExtensionsModule.GetNotOpenTicket(array3[j]) != null)
					{
						array2 = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), array2, new MQuests[1] { array3[j] });
					}
					else if (MasterExtensionsModule.GetOpenTicket(array3[j]) != null)
					{
						array2 = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), array2, new MQuests[1] { array3[j] });
					}
					continue;
				}
				MWeekEvents[] weekEvent = MWeekEventsUtil.GetWeekEvent(array3[j].Id);
				if (weekEvent == null)
				{
					continue;
				}
				int k = 0;
				MWeekEvents[] array4 = weekEvent;
				for (int length3 = array4.Length; k < length3; k++)
				{
					if (!((array4[k].EndTime - array4[k].BeginTime).TotalMinutes >= 1440.0))
					{
						array2 = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), array2, new MQuests[1] { array3[j] });
					}
				}
			}
			if (nameSort)
			{
				Array.Sort(array2, (MQuests a, MQuests b) => a.GetName().CompareTo(b.GetName()));
			}
			return array2;
		}
	}

	public MQuests GetCurChallengeQuest()
	{
		MQuests mQuests = null;
		MQuests[] questList = GetQuestList(0, EnumQuestTypes.Challenge, 0);
		object result;
		if (questList == null)
		{
			result = null;
		}
		else
		{
			DateTime dateTime = default(DateTime);
			int i = 0;
			MQuests[] array = questList;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (array[i].BeginDate > dateTime)
				{
					dateTime = array[i].BeginDate;
					mQuests = array[i];
				}
			}
			result = mQuests;
		}
		return (MQuests)result;
	}

	public MQuests[] GetChallengeRankQuests()
	{
		MQuests[] array = new MQuests[3];
		MQuests[] openQuests = MChallengeQuestScheduleDetails.GetOpenQuests();
		if (openQuests != null)
		{
			int num = 0;
			while (num < 3)
			{
				int num2 = num;
				num++;
				object obj = null;
				int i = 0;
				MQuests[] array2 = openQuests;
				checked
				{
					for (int length = array2.Length; i < length; i++)
					{
						if (array2[i] != null && array2[i].Rank == num2 + 1)
						{
							obj = array2[i];
							break;
						}
					}
					int num3 = RuntimeServices.NormalizeArrayIndex(array, num2);
					object obj2 = obj;
					if (!(obj2 is MQuests))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(MQuests));
					}
					array[num3] = (MQuests)obj2;
				}
			}
		}
		return array;
	}

	public MQuests[] GetTargetQuestList(EnumQuestTypes type, UserMiscInfo.QuestData.STATE targetState, int rank)
	{
		MQuests[] array = new MQuests[0];
		checked
		{
			MQuests[] result;
			if (areas == null)
			{
				result = array;
			}
			else
			{
				UserData current = UserData.Current;
				if (current == null)
				{
					result = array;
				}
				else
				{
					MQuests[] array2 = new MQuests[0];
					int i = 0;
					MAreas[] array3 = areas;
					for (int length = array3.Length; i < length; i++)
					{
						MQuests[] questList = GetQuestList(array3[i].Id, type, rank);
						if (questList != null)
						{
							array2 = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), array2, questList);
						}
					}
					int j = 0;
					MQuests[] array4 = array2;
					for (int length2 = array4.Length; j < length2; j++)
					{
						UserMiscInfo.QuestData.STATE state = current.userMiscInfo.questData.getState(array4[j].Id);
						if (state == targetState)
						{
							array = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), array, new MQuests[1] { array4[j] });
						}
					}
					result = array;
				}
			}
			return result;
		}
	}

	public MQuests[] GetQuestList(int areaId, EnumQuestTypes type, int rank)
	{
		DateTime utcNow = MerlinDateTime.UtcNow;
		DateTime now = MerlinDateTime.Now;
		TimeSpan localNow = new TimeSpan(now.Hour, now.Minute, now.Second);
		int dayOfWeek = (int)now.DayOfWeek;
		UserData current = UserData.Current;
		MQuests[] array = new MQuests[0];
		MAreas mAreas = MAreas.Get(areaId);
		object result;
		if (type != EnumQuestTypes.Challenge && mAreas == null)
		{
			result = null;
		}
		else
		{
			int i = 0;
			MQuests[] all = MQuests.All;
			for (int length = all.Length; i < length; i = checked(i + 1))
			{
				if ((type == EnumQuestTypes.Challenge || RuntimeServices.EqualityOperator(all[i].MAreaId, mAreas)) && (rank <= 0 || all[i].Rank == rank) && IsQuestReady(all[i], type, utcNow, localNow, dayOfWeek))
				{
					array = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), array, new MQuests[1] { all[i] });
				}
			}
			result = ((array.Length <= 0) ? null : array);
		}
		return (MQuests[])result;
	}

	public static bool IsQuestReady(MQuests quest, EnumQuestTypes type)
	{
		DateTime utcNow = MerlinDateTime.UtcNow;
		DateTime now = MerlinDateTime.Now;
		TimeSpan localNow = new TimeSpan(now.Hour, now.Minute, now.Second);
		int dayOfWeek = (int)now.DayOfWeek;
		return IsQuestReady(quest, type, utcNow, localNow, dayOfWeek);
	}

	public static bool IsQuestReady(MQuests quest, EnumQuestTypes type, DateTime today, TimeSpan localNow, int localTodayWeek)
	{
		int result;
		if (quest == null)
		{
			result = 0;
		}
		else if (quest.HideFlag)
		{
			result = 0;
		}
		else if (quest.QuestType != type)
		{
			result = 0;
		}
		else
		{
			bool flag = default(bool);
			if (quest.NeedTicket)
			{
				if (MasterExtensionsModule.IsTicket(quest))
				{
					goto IL_00d3;
				}
				result = 0;
			}
			else
			{
				if (type != EnumQuestTypes.Special && type != EnumQuestTypes.LongTerm && type != EnumQuestTypes.Boost)
				{
					goto IL_00d3;
				}
				MWeekEvents[] weekEvent = MWeekEventsUtil.GetWeekEvent(quest.Id);
				if (weekEvent == null)
				{
					result = 0;
				}
				else
				{
					int i = 0;
					MWeekEvents[] array = weekEvent;
					for (int length = array.Length; i < length; i = checked(i + 1))
					{
						flag = IsWeekEventReady(array[i], today, localNow, localTodayWeek);
						if (flag)
						{
							break;
						}
					}
					if (flag)
					{
						goto IL_00d3;
					}
					result = 0;
				}
			}
		}
		goto IL_013f;
		IL_013f:
		return (byte)result != 0;
		IL_00d3:
		if (today < quest.BeginDate)
		{
			result = 0;
		}
		else if (today > quest.EndDate && (int)quest.EndDate.Ticks != 0)
		{
			result = 0;
		}
		else
		{
			bool flag = true;
			if (!GameLevelManager.CheckCondition(quest.AllConditions, notFlag: false))
			{
				flag = false;
			}
			if (!GameLevelManager.CheckCondition(quest.AllNotConditions, notFlag: true))
			{
				flag = false;
			}
			result = (flag ? 1 : 0);
		}
		goto IL_013f;
	}

	public static bool IsWeekEventReady(MWeekEvents ev)
	{
		DateTime utcNow = MerlinDateTime.UtcNow;
		DateTime now = MerlinDateTime.Now;
		TimeSpan localNow = new TimeSpan(now.Hour, now.Minute, now.Second);
		int dayOfWeek = (int)now.DayOfWeek;
		return IsWeekEventReady(ev, utcNow, localNow, dayOfWeek);
	}

	public static bool IsWeekEventReady(MWeekEvents ev, DateTime today, TimeSpan localNow, int localTodayWeek)
	{
		int result;
		if (today < ev.BeginDate)
		{
			result = 0;
		}
		else if (today > ev.EndDate)
		{
			result = 0;
		}
		else
		{
			int week = (int)ev.Week;
			result = ((localTodayWeek == week && !(localNow < ev.BeginTime) && !(localNow > ev.EndTime)) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public RespColosseumEvent[] GetCurColosseumEventList()
	{
		RespColosseumEvent[] array = new RespColosseumEvent[0];
		DateTime utcNow = MerlinDateTime.UtcNow;
		DateTime now = MerlinDateTime.Now;
		TimeSpan timeSpan = new TimeSpan(now.Hour, now.Minute, now.Second);
		int dayOfWeek = (int)now.DayOfWeek;
		RespColosseumEvent[] colosseumEvent = UserData.Current.userColosseumEvent.ColosseumEvent;
		if (colosseumEvent != null)
		{
			int i = 0;
			RespColosseumEvent[] array2 = colosseumEvent;
			for (int length = array2.Length; i < length; i = checked(i + 1))
			{
				if (!(utcNow < array2[i].BeginDate) && !(utcNow > array2[i].EndDate))
				{
					array = (RespColosseumEvent[])RuntimeServices.AddArrays(typeof(RespColosseumEvent), array, new RespColosseumEvent[1] { array2[i] });
				}
			}
		}
		return array;
	}

	public bool IsColosseumEvent()
	{
		RespColosseumEvent[] curColosseumEventList = GetCurColosseumEventList();
		return (curColosseumEventList != null && curColosseumEventList.Length > 0) ? true : false;
	}

	public static bool IsAreaQuestClar(int areaId, int rank, ref bool nextIconFlag)
	{
		MAreas area = MAreas.Get(areaId);
		return IsAreaQuestClar(area, rank, ref nextIconFlag);
	}

	public static bool IsAreaQuestClar(MAreas area, int rank, ref bool nextIconFlag)
	{
		bool flag = false;
		nextIconFlag = false;
		int result;
		bool flag2;
		checked
		{
			if (area == null)
			{
				result = 0;
			}
			else
			{
				MQuests[] array = new MQuests[0];
				MQuests[] array2 = new MQuests[0];
				if (area.JumpType == EnumAreaTypes.SpecialQuest || area.JumpType == EnumAreaTypes.BoostQuest)
				{
					if (area.JumpType == EnumAreaTypes.SpecialQuest)
					{
						array2 = Instance.GetCurSpecialQuestList(0, nameSort: false);
					}
					else if (area.JumpType == EnumAreaTypes.BoostQuest)
					{
						array2 = Instance.GetCurBoostQuestList(0, nameSort: false);
					}
					if (array2 != null)
					{
						array = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), array, array2);
					}
					Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
					int i = 0;
					MQuests[] array3 = array;
					for (int length = array3.Length; i < length; i++)
					{
						if (!array3[i].HideFlag)
						{
							UserMiscInfo.QuestData.STATE state = UserData.Current.userMiscInfo.questData.getState(array3[i].Id);
							string origname = array3[i].Origname;
							if (!dictionary.ContainsKey(origname))
							{
								dictionary[origname] = false;
							}
							if (state == UserMiscInfo.QuestData.STATE.Clear)
							{
								dictionary[origname] = true;
							}
						}
					}
					foreach (string key in dictionary.Keys)
					{
						if (dictionary[key])
						{
							continue;
						}
						flag2 = false;
						goto IL_03b6;
					}
				}
				else
				{
					if (area.JumpType == EnumAreaTypes.Raid)
					{
						result = 1;
						goto IL_03b8;
					}
					if (area.JumpType == EnumAreaTypes.RaidTutorial)
					{
						array2 = Instance.GetQuestList(area.Id, EnumQuestTypes.RaidTutorial, rank);
						if (array2 != null)
						{
							array = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), array, array2);
						}
						flag = true;
					}
					else
					{
						if (area.JumpType == EnumAreaTypes.Challenge)
						{
							result = 1;
							goto IL_03b8;
						}
						if (area.JumpType == EnumAreaTypes.Quest)
						{
							array2 = Instance.GetQuestList(area.Id, EnumQuestTypes.Normal, rank);
							if (array2 != null)
							{
								array = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), array, array2);
							}
							array2 = Instance.GetQuestList(area.Id, EnumQuestTypes.Tutorial, rank);
							if (array2 != null)
							{
								array = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), array, array2);
							}
							flag = true;
						}
						else if (area.JumpType == EnumAreaTypes.Town)
						{
							MNpcTalks[] array4 = GameLevelManager.SimulateGameLevel("Town");
							nextIconFlag = false;
							int num = 0;
							MNpcTalks[] array5 = array4;
							int length2 = array5.Length;
							while (true)
							{
								if (num < length2)
								{
									if (array5[num] != null && (array5[num].Icon == EnumNpcTalkIcons.CAUTION || array5[num].DistantIcon == EnumNpcTalkIcons.CAUTION))
									{
										nextIconFlag = true;
										result = 1;
										break;
									}
									num++;
									continue;
								}
								array4 = GameLevelManager.SimulateGameLevel("Myhome");
								int num2 = 0;
								MNpcTalks[] array6 = array4;
								int length3 = array6.Length;
								while (true)
								{
									if (num2 < length3)
									{
										if (array6[num2] != null && (array6[num2].Icon == EnumNpcTalkIcons.CAUTION || array6[num2].DistantIcon == EnumNpcTalkIcons.CAUTION))
										{
											nextIconFlag = true;
											result = 1;
											break;
										}
										num2++;
										continue;
									}
									result = 1;
									break;
								}
								break;
							}
							goto IL_03b8;
						}
					}
					int j = 0;
					MQuests[] array7 = array;
					for (int length4 = array7.Length; j < length4; j++)
					{
						if (array7[j].HideFlag)
						{
							continue;
						}
						UserMiscInfo.QuestData.STATE state = UserData.Current.userMiscInfo.questData.getState(array7[j].Id);
						if (state == UserMiscInfo.QuestData.STATE.Clear)
						{
							continue;
						}
						goto IL_0391;
					}
				}
				result = 1;
			}
			goto IL_03b8;
		}
		IL_0391:
		if (flag)
		{
			nextIconFlag = true;
		}
		result = 0;
		goto IL_03b8;
		IL_03b6:
		result = (flag2 ? 1 : 0);
		goto IL_03b8;
		IL_03b8:
		return (byte)result != 0;
	}

	public MAreas GetAreaFromSceneName(string areaName)
	{
		object result;
		if (areas == null)
		{
			result = null;
		}
		else
		{
			int num = 0;
			MAreas[] array = areas;
			int length = array.Length;
			while (true)
			{
				if (num < length)
				{
					if (areaName == "Ui_WorldQuest" && array[num].JumpType == EnumAreaTypes.Quest)
					{
						result = array[num];
						break;
					}
					if (areaName == "Ui_WorldQuest" && array[num].JumpType == EnumAreaTypes.SpecialQuest)
					{
						result = array[num];
						break;
					}
					if (areaName == "Ui_WorldQuest" && array[num].JumpType == EnumAreaTypes.BoostQuest)
					{
						result = array[num];
						break;
					}
					if (areaName == "Ui_WorldRaid" && array[num].JumpType == EnumAreaTypes.Raid)
					{
						result = array[num];
						break;
					}
					if (areaName == "Ui_WorldRaid" && array[num].JumpType == EnumAreaTypes.RaidTutorial)
					{
						result = array[num];
						break;
					}
					if (areaName == "Town" && array[num].JumpType == EnumAreaTypes.Town)
					{
						result = array[num];
						break;
					}
					if (areaName == "Myhome" && array[num].JumpType == EnumAreaTypes.Myhome)
					{
						result = array[num];
						break;
					}
					if (areaName == "Ui_WorldChallenge" && array[num].JumpType == EnumAreaTypes.Challenge)
					{
						result = array[num];
						break;
					}
					if (areaName == "Ui_WorldColosseum" && array[num].JumpType == EnumAreaTypes.Colosseum)
					{
						result = array[num];
						break;
					}
					num = checked(num + 1);
					continue;
				}
				result = null;
				break;
			}
		}
		return (MAreas)result;
	}

	public static bool IsAreaNewQuest(int areaId)
	{
		MAreas area = MAreas.Get(areaId);
		return IsAreaNewQuest(area);
	}

	public static bool IsAreaNewQuest(MAreas area)
	{
		int result;
		if (area == null)
		{
			result = 0;
		}
		else
		{
			MQuests[] array = new MQuests[0];
			if (area.JumpType == EnumAreaTypes.Raid)
			{
				result = 0;
			}
			else
			{
				MQuests[] questList = default(MQuests[]);
				if (area.JumpType == EnumAreaTypes.RaidTutorial)
				{
					questList = Instance.GetQuestList(area.Id, EnumQuestTypes.RaidTutorial, 0);
					if (questList != null)
					{
						array = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), array, questList);
					}
				}
				else if (area.JumpType == EnumAreaTypes.Challenge)
				{
					questList = Instance.GetQuestList(area.Id, EnumQuestTypes.Challenge, 0);
					if (questList != null)
					{
						array = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), array, questList);
					}
				}
				else if (area.JumpType == EnumAreaTypes.Quest)
				{
					questList = Instance.GetQuestList(area.Id, EnumQuestTypes.Normal, 0);
					if (questList != null)
					{
						array = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), array, questList);
					}
					questList = Instance.GetQuestList(area.Id, EnumQuestTypes.Tutorial, 0);
					if (questList != null)
					{
						array = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), array, questList);
					}
				}
				else if (area.JumpType == EnumAreaTypes.SpecialQuest)
				{
					if (area != null)
					{
						questList = Instance.GetCurSpecialQuestList(0, nameSort: false);
					}
					if (questList != null)
					{
						array = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), array, questList);
					}
				}
				else if (area.JumpType == EnumAreaTypes.BoostQuest)
				{
					if (area != null)
					{
						questList = Instance.GetCurBoostQuestList(0, nameSort: false);
					}
					if (questList != null)
					{
						array = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), array, questList);
					}
				}
				int num = 0;
				MQuests[] array2 = array;
				int length = array2.Length;
				while (true)
				{
					if (num < length)
					{
						if (!array2[num].HideFlag)
						{
							int state = (int)UserData.Current.userMiscInfo.questData.getState(array2[num].Id);
							if (state <= 0)
							{
								result = 1;
								break;
							}
						}
						num = checked(num + 1);
						continue;
					}
					result = 0;
					break;
				}
			}
		}
		return (byte)result != 0;
	}

	public static bool IsNewArea(int areaId)
	{
		MAreas area = MAreas.Get(areaId);
		return IsNewArea(area);
	}

	public static bool IsNewArea(MAreas area)
	{
		int result;
		if (area == null)
		{
			result = 0;
		}
		else
		{
			int @int = UserData.Current.userMiscInfo.areaData.getInt(area.AreaGroup.Id.ToString());
			result = ((@int <= 0) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public static bool IsQuestStory(MQuests quest)
	{
		return quest?.StoryFlag ?? false;
	}

	public static bool IsQuestRaid(MQuests quest)
	{
		int num;
		if (quest == null)
		{
			num = 0;
		}
		else
		{
			MAreas mAreaId = quest.MAreaId;
			if (mAreaId == null)
			{
				num = 0;
			}
			else
			{
				num = ((mAreaId.JumpType == EnumAreaTypes.Raid) ? 1 : 0);
				if (num == 0)
				{
					num = ((mAreaId.JumpType == EnumAreaTypes.RaidTutorial) ? 1 : 0);
				}
			}
		}
		return (byte)num != 0;
	}

	public static bool CheckQuestStoryDiary(MStoryBooks diary, DateTime today)
	{
		int result;
		if (diary == null)
		{
			result = 0;
		}
		else if (today < diary.StartDate)
		{
			result = 0;
		}
		else
		{
			UserData current = UserData.Current;
			result = ((current != null) ? ((diary.MStoryId != null) ? ((current.userMiscInfo.storyData.getInt(diary.MStoryId.Progname) >= 0) ? ((diary.MStoryId.MQuestId != null) ? ((UserMiscInfo.QuestData.STATE.Clear == current.userMiscInfo.questData.getState(diary.MStoryId.MQuestId.Id)) ? (GameLevelManager.CheckCondition(diary.AllConditions, notFlag: false) ? (GameLevelManager.CheckCondition(diary.AllNotConditions, notFlag: true) ? 1 : 0) : 0) : 0) : 0) : 0) : 0) : 0);
		}
		return (byte)result != 0;
	}

	public static MStories findStory(MQuests q)
	{
		object result;
		if (q == null)
		{
			result = null;
		}
		else
		{
			int num = 0;
			MStories[] all = MStories.All;
			int length = all.Length;
			while (true)
			{
				if (num < length)
				{
					if (RuntimeServices.EqualityOperator(all[num].MQuestId, q))
					{
						result = all[num];
						break;
					}
					num = checked(num + 1);
					continue;
				}
				result = null;
				break;
			}
		}
		return (MStories)result;
	}

	public static MAreas getArea(EnumAreaTypes areaType)
	{
		int num = 0;
		MAreas[] array = Instance.Areas;
		int length = array.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (array[num].JumpType == areaType)
				{
					result = array[num];
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = null;
			break;
		}
		return (MAreas)result;
	}

	internal bool _0024PopupNewQuestCtrl_0024closure_00243781()
	{
		return taskCompleted;
	}

	internal void _0024PopupNewQuestCtrl_0024closure_00243782()
	{
		isNowPopNewQuest = false;
		if ((bool)player)
		{
			player.InputActive = true;
		}
	}

	internal int _0024GetCurSpecialQuestList_0024closure_00243786(MQuests a, MQuests b)
	{
		return a.GetName().CompareTo(b.GetName());
	}

	internal int _0024GetCurBoostQuestList_0024closure_00243787(MQuests a, MQuests b)
	{
		return a.GetName().CompareTo(b.GetName());
	}

	internal int _0024GetCurShortSpecialQuestList_0024closure_00243788(MQuests a, MQuests b)
	{
		return a.GetName().CompareTo(b.GetName());
	}
}
