using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using UnityEngine;

[Serializable]
public class MyHomeMain : MonoBehaviour
{
	[Serializable]
	internal class _0024CheckLoginBonus_0024locals_002414527
	{
		internal LoginBonus _0024bonus;
	}

	[Serializable]
	internal class _0024_0024CheckLoginBonus_0024closure_00243263_0024closure_00243264
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002421799 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal GameObject _0024loginBonusPrefab_002421800;

				internal GameObject _0024go_002421801;

				internal GameObject _0024parent_002421802;

				internal UIHUDLayer _0024hudLayer_002421803;

				internal _0024_0024CheckLoginBonus_0024closure_00243263_0024closure_00243264 _0024self__002421804;

				public _0024(_0024_0024CheckLoginBonus_0024closure_00243263_0024closure_00243264 self_)
				{
					_0024self__002421804 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						if (!SceneChanger.isFadeOut)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						goto case 3;
					case 3:
						if (IPauseWindow.IsPaused)
						{
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						goto case 4;
					case 4:
						if (MerlinServer.Instance.IsBusy)
						{
							result = (YieldDefault(4) ? 1 : 0);
							break;
						}
						goto case 5;
					case 5:
						if (CutSceneManager.IsBusy)
						{
							result = (YieldDefault(5) ? 1 : 0);
							break;
						}
						goto case 6;
					case 6:
						if (GameLevelManager.IsBusy)
						{
							result = (YieldDefault(6) ? 1 : 0);
							break;
						}
						goto case 7;
					case 7:
						if (TutorialEvent.IsBusy)
						{
							result = (YieldDefault(7) ? 1 : 0);
							break;
						}
						goto case 8;
					case 8:
						if (NpcTalkControl.IsBusy)
						{
							result = (YieldDefault(8) ? 1 : 0);
							break;
						}
						goto case 9;
					case 9:
						if (BattleHUDShortcut.IsOpen)
						{
							result = (YieldDefault(9) ? 1 : 0);
							break;
						}
						goto case 10;
					case 10:
						if (DialogManager.DialogCount != 0)
						{
							result = (YieldDefault(10) ? 1 : 0);
							break;
						}
						TimeScaleUtil.Zero();
						TheWorld.StopWorldAll(_0024self__002421804._0024this_002415174);
						_0024loginBonusPrefab_002421800 = GameAssetModule.LoadPrefab("Prefab/UI_Sequence/LoginBonus") as GameObject;
						_0024go_002421801 = ((GameObject)UnityEngine.Object.Instantiate(_0024loginBonusPrefab_002421800)) as GameObject;
						_0024parent_002421802 = GameObject.Find("1 HUD");
						_0024self__002421804._0024_0024locals_002415173._0024bonus = _0024go_002421801.GetComponent<LoginBonus>();
						if (!(_0024self__002421804._0024_0024locals_002415173._0024bonus != null))
						{
							throw new AssertionFailedException("bonus != null");
						}
						if (!(_0024parent_002421802 != null))
						{
							throw new AssertionFailedException("parent != null");
						}
						_0024go_002421801.transform.parent = _0024parent_002421802.transform;
						_0024go_002421801.transform.localPosition = _0024loginBonusPrefab_002421800.transform.localPosition;
						_0024go_002421801.transform.localScale = Vector3.one;
						ExtensionsModule.FindChild(_0024go_002421801, "Panel").transform.localScale = Vector3.zero;
						_0024hudLayer_002421803 = (UIHUDLayer)UnityEngine.Object.FindObjectOfType(typeof(UIHUDLayer));
						if ((bool)_0024hudLayer_002421803)
						{
							_0024hudLayer_002421803.SetIn(isIn: false);
						}
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
					return (byte)result != 0;
				}
			}

			internal _0024_0024CheckLoginBonus_0024closure_00243263_0024closure_00243264 _0024self__002421805;

			public _0024Invoke_002421799(_0024_0024CheckLoginBonus_0024closure_00243263_0024closure_00243264 self_)
			{
				_0024self__002421805 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002421805);
			}
		}

		internal _0024CheckLoginBonus_0024locals_002414527 _0024_0024locals_002415173;

		internal MyHomeMain _0024this_002415174;

		public _0024_0024CheckLoginBonus_0024closure_00243263_0024closure_00243264(_0024CheckLoginBonus_0024locals_002414527 _0024_0024locals_002415173, MyHomeMain _0024this_002415174)
		{
			this._0024_0024locals_002415173 = _0024_0024locals_002415173;
			this._0024this_002415174 = _0024this_002415174;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002421799(this).GetEnumerator();
		}
	}

	[Serializable]
	internal class _0024CheckLoginBonus_0024closure_00243263
	{
		internal _0024CheckLoginBonus_0024locals_002414527 _0024_0024locals_002415175;

		internal MyHomeMain _0024this_002415176;

		public _0024CheckLoginBonus_0024closure_00243263(_0024CheckLoginBonus_0024locals_002414527 _0024_0024locals_002415175, MyHomeMain _0024this_002415176)
		{
			this._0024_0024locals_002415175 = _0024_0024locals_002415175;
			this._0024this_002415176 = _0024this_002415176;
		}

		public void Invoke()
		{
			__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024_0024CheckLoginBonus_0024closure_00243263_0024closure_00243264(_0024_0024locals_002415175, _0024this_002415176).Invoke;
			IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
			if (enumerator != null)
			{
				_0024this_002415176.StartCoroutine(enumerator);
			}
		}
	}

	[Serializable]
	internal class _0024CheckLoginBonus_0024closure_00243265
	{
		internal _0024CheckLoginBonus_0024locals_002414527 _0024_0024locals_002415177;

		public _0024CheckLoginBonus_0024closure_00243265(_0024CheckLoginBonus_0024locals_002414527 _0024_0024locals_002415177)
		{
			this._0024_0024locals_002415177 = _0024_0024locals_002415177;
		}

		public bool Invoke()
		{
			bool num = _0024_0024locals_002415177._0024bonus != null;
			if (num)
			{
				num = _0024_0024locals_002415177._0024bonus.WaitExit;
			}
			return num;
		}
	}

	[Serializable]
	internal class _0024CheckLoginBonus_0024closure_00243266
	{
		internal _0024CheckLoginBonus_0024locals_002414527 _0024_0024locals_002415178;

		internal MyHomeMain _0024this_002415179;

		public _0024CheckLoginBonus_0024closure_00243266(_0024CheckLoginBonus_0024locals_002414527 _0024_0024locals_002415178, MyHomeMain _0024this_002415179)
		{
			this._0024_0024locals_002415178 = _0024_0024locals_002415178;
			this._0024this_002415179 = _0024this_002415179;
		}

		public void Invoke()
		{
			TimeScaleUtil.One();
			TheWorld.RestartWorld();
			UnityEngine.Object.Destroy(_0024_0024locals_002415178._0024bonus.gameObject);
			UIHUDLayer uIHUDLayer = (UIHUDLayer)UnityEngine.Object.FindObjectOfType(typeof(UIHUDLayer));
			if ((bool)uIHUDLayer)
			{
				uIHUDLayer.SetIn(isIn: true);
			}
			_0024this_002415179.showLoginBonus = false;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024CheckInformation_0024closure_00243267_002421798 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!NewInformation.Shown)
					{
						result = (Yield(2, NewInformation.Show()) ? 1 : 0);
						break;
					}
					goto IL_0038;
				case 2:
					NewInformation.SkipInfo = true;
					goto IL_0038;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0038:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	public string equipObjName;

	public string picBookObjName;

	public string diaryObjName;

	public string giftObjName;

	public string exitObjName;

	public string sabotenObjName;

	public GameObject equipObj;

	public GameObject picBookObj;

	public GameObject diaryObj;

	public GameObject giftObj;

	public GameObject exitObj;

	public GameObject sabotenObj;

	public bool testGiftNew;

	protected bool sabotenCheckStart;

	protected bool sabotenCheckEnd;

	public string sabotenKunCutScene;

	public string sabotenKunCutSceneAssetBundleName;

	public string[] subtenKunCheckScene;

	public bool debugrequestLoginBonus;

	private bool requestLoginBonus;

	private bool showLoginBonus;

	[NonSerialized]
	private static bool needOshirase = true;

	private readonly string seEnter;

	private readonly string seExit;

	private int conditionNumber;

	private bool achievementsChecked;

	public static bool NeedOshirase
	{
		get
		{
			return needOshirase;
		}
		set
		{
			needOshirase = value;
		}
	}

	public MyHomeMain()
	{
		equipObjName = "myhome_equip";
		picBookObjName = "myhome_picbook";
		diaryObjName = "myhome_diary";
		giftObjName = "myhome_gift";
		exitObjName = "myhome_exit";
		sabotenObjName = "myhome_saboten";
		subtenKunCheckScene = new string[6] { "Town", "Ui_World", "Ui_TownBlacksmith", "Ui_TownStoneShop", "Ui_MessageBoard", "Lottery_UI" };
		seEnter = "se_system_door";
		seExit = "se_system_door2";
	}

	public void Start()
	{
		if (!(SceneChanger.CurrentSceneName != "Myhome"))
		{
			GameLevelManager instance = GameLevelManager.Instance;
			QuestManager instance2 = QuestManager.Instance;
			sabotenCheckStart = false;
			sabotenCheckEnd = false;
			SceneChanger.Hook = SabotenKunCheck;
			UpdateCondition(init: true);
			ExtensionsModule.SetComponent<NotificationUpdate>(gameObject);
			CheckAchievements();
			WebBannerTown.InitTownWebBanner();
		}
	}

	public void UpdateCondition(bool init)
	{
		int num = UserData.Current.userMiscInfo.flagData.ConditionNumber;
		if (init || conditionNumber != num)
		{
			conditionNumber = num;
			if (!showLoginBonus)
			{
				requestLoginBonus = UserData.Current.HasLoginBonus;
			}
		}
	}

	public void Update()
	{
		if (!(SceneChanger.CurrentSceneName != "Myhome"))
		{
			UpdateCondition(init: false);
			DailyTask.UpdateCheckDailyTask(gameObject);
			SearchMyHomeObject();
			CheckQueueTasks();
			CheckNewPresent();
		}
	}

	public void CheckQueueTasks()
	{
		if (FaderCore.Instance.isCompleted && !FaderCore.Instance.isInCompleted && !TutorialFlowControl.IsInTutorial && DialogManager.DialogCount <= 0)
		{
			CheckLoginBonus();
			CheckInformation();
		}
	}

	public void CheckLoginBonus()
	{
		_0024CheckLoginBonus_0024locals_002414527 _0024CheckLoginBonus_0024locals_0024 = new _0024CheckLoginBonus_0024locals_002414527();
		if (requestLoginBonus)
		{
			showLoginBonus = true;
			MerlinTaskQueue.Task task = new MerlinTaskQueue.Task();
			task.Priority = 100;
			_0024CheckLoginBonus_0024locals_0024._0024bonus = null;
			task.OnStart = new _0024CheckLoginBonus_0024closure_00243263(_0024CheckLoginBonus_0024locals_0024, this).Invoke;
			task.IsCompleted = new _0024CheckLoginBonus_0024closure_00243265(_0024CheckLoginBonus_0024locals_0024).Invoke;
			task.OnExit = new _0024CheckLoginBonus_0024closure_00243266(_0024CheckLoginBonus_0024locals_0024, this).Invoke;
			MerlinTaskQueue.Instance.Enqueue(task);
			requestLoginBonus = false;
		}
	}

	public void CheckInformation()
	{
		if (needOshirase)
		{
			MerlinTaskQueue.CoroutineTask coroutineTask = new MerlinTaskQueue.CoroutineTask(() => new _0024_0024CheckInformation_0024closure_00243267_002421798().GetEnumerator());
			coroutineTask.Priority = -1;
			MerlinTaskQueue.Instance.Enqueue(coroutineTask);
			needOshirase = false;
		}
	}

	public void CheckAchievements()
	{
		if (!achievementsChecked)
		{
			MerlinTaskQueue.Task task = new MerlinTaskQueue.Task();
			task.Priority = 100;
			task.OnStart = delegate
			{
				MerlinGameCenter.Instance.CheckAchievements();
			};
			task.IsCompleted = () => true;
			task.OnExit = delegate
			{
				achievementsChecked = true;
			};
			MerlinTaskQueue.Instance.Enqueue(task);
		}
	}

	public bool SabotenKunCheck(SceneID sceneId, string sceneName)
	{
		bool flag = false;
		int i = 0;
		string[] array = subtenKunCheckScene;
		int result;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if (array[i] == sceneName)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				result = 1;
			}
			else if (string.IsNullOrEmpty(sabotenKunCutScene))
			{
				result = 1;
			}
			else
			{
				if (!sabotenCheckStart)
				{
					if (!CheckAndWriteNewQuestStoryDiary())
					{
						result = 1;
						goto IL_00ff;
					}
					sabotenCheckStart = true;
					sabotenCheckEnd = false;
					int j = 0;
					NPCControl[] array2 = (NPCControl[])UnityEngine.Object.FindObjectsOfType(typeof(NPCControl));
					for (int length2 = array2.Length; j < length2; j++)
					{
						array2[j].gameObject.SetActive(value: false);
					}
					CutSceneManager cutSceneManager = CutSceneManager.CutSceneEx(sabotenKunCutScene, null, sabotenKunCutSceneAssetBundleName, autoStart: true);
					cutSceneManager.CloseHandler = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
					{
						sabotenCheckEnd = true;
						TheWorld.StopWorldForCutscene(this);
						GameSoundManager.Reset = true;
					};
				}
				result = (sabotenCheckEnd ? 1 : 0);
			}
			goto IL_00ff;
		}
		IL_00ff:
		return (byte)result != 0;
	}

	public bool CheckAndWriteNewQuestStoryDiary()
	{
		UserData current = UserData.Current;
		int result;
		if (current == null)
		{
			result = 0;
		}
		else
		{
			DateTime utcNow = MerlinDateTime.UtcNow;
			bool flag = false;
			int i = 0;
			MStoryBooks[] all = MStoryBooks.All;
			for (int length = all.Length; i < length; i = checked(i + 1))
			{
				if (QuestManager.CheckQuestStoryDiary(all[i], utcNow) && current.userMiscInfo.diaryData.getDiaryState(all[i]) < 0)
				{
					current.userMiscInfo.diaryData.openDiary(all[i]);
					flag = true;
				}
			}
			result = (flag ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public void SearchMyHomeObject()
	{
		if (!equipObj)
		{
			equipObj = GameObject.Find(equipObjName);
		}
		if (!picBookObj)
		{
			picBookObj = GameObject.Find(picBookObjName);
		}
		if (!diaryObj)
		{
			diaryObj = GameObject.Find(diaryObjName);
		}
		if (!giftObj)
		{
			giftObj = GameObject.Find(giftObjName);
		}
		if (!exitObj)
		{
			exitObj = GameObject.Find(exitObjName);
		}
		if (!sabotenObj)
		{
			sabotenObj = GameObject.Find(sabotenObjName);
		}
	}

	public void CheckNewPresent()
	{
		if (!giftObj)
		{
			return;
		}
		NpcTalkControl component = giftObj.GetComponent<NpcTalkControl>();
		if ((bool)component)
		{
			if (testGiftNew || UserData.Current.HasNewPresent)
			{
				component.OverwriteIcon = GimmickIconTypes.CAUTION;
			}
			else
			{
				component.OverwriteIcon = GimmickIconTypes.__NONE__;
			}
		}
	}

	internal void _0024CheckAchievements_0024closure_00243082()
	{
		MerlinGameCenter.Instance.CheckAchievements();
	}

	internal bool _0024CheckAchievements_0024closure_00243083()
	{
		return true;
	}

	internal void _0024CheckAchievements_0024closure_00243084()
	{
		achievementsChecked = true;
	}

	internal IEnumerator _0024CheckInformation_0024closure_00243267()
	{
		return new _0024_0024CheckInformation_0024closure_00243267_002421798().GetEnumerator();
	}

	internal void _0024SabotenKunCheck_0024closure_00243268()
	{
		sabotenCheckEnd = true;
		TheWorld.StopWorldForCutscene(this);
		GameSoundManager.Reset = true;
	}
}
