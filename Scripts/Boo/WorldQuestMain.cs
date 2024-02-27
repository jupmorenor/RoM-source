using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class WorldQuestMain : QuestMenuBase
{
	[Serializable]
	public enum WORLD_QUEST_MODE
	{
		None = -1,
		SelectQuest,
		SelectPet,
		ConfQuest,
		Detail,
		StoneShop,
		Start,
		Mission,
		MissionDetail,
		Max
	}

	[Serializable]
	public enum QUEST_LIST_TYPE
	{
		None = -1,
		Lo,
		Mid,
		Hi,
		Ex,
		Max
	}

	[Serializable]
	internal class _0024CheckQuest_0024locals_002414562
	{
		internal MQuests _0024quest;
	}

	[Serializable]
	internal class _0024CheckQuest_0024closure_00243250
	{
		internal _0024CheckQuest_0024locals_002414562 _0024_0024locals_002415250;

		public _0024CheckQuest_0024closure_00243250(_0024CheckQuest_0024locals_002414562 _0024_0024locals_002415250)
		{
			this._0024_0024locals_002415250 = _0024_0024locals_002415250;
		}

		public void Invoke(int btn)
		{
			if (btn == 2)
			{
				MasterExtensionsModule.Open(_0024_0024locals_002415250._0024quest);
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024StartQuestCore_002422191 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal UserData _0024ud_002422192;

			internal float _0024_0024wait_sec_0024temp_00242685_002422193;

			internal RespFriend _0024curRespFriend_002422194;

			internal long _0024index_002422195;

			internal MStories _0024story_002422196;

			internal RespFriendPoppet _0024friendPoppet_002422197;

			internal WorldQuestMain _0024self__002422198;

			public _0024(WorldQuestMain self_)
			{
				_0024self__002422198 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (!_0024self__002422198.IsChangingSituation && _0024self__002422198.mode != WORLD_QUEST_MODE.Start)
						{
							_0024ud_002422192 = UserData.Current;
							if (_0024ud_002422192 != null)
							{
								_0024self__002422198.mode = WORLD_QUEST_MODE.Start;
								ApRpExp.MoveMSec = 300;
								ApRpExp.ApParam = _0024ud_002422192.Ap - _0024self__002422198.curQuest.ApCost;
								ApRpExp.RpParam = _0024ud_002422192.Rp - _0024self__002422198.curQuest.RpCost;
								goto case 2;
							}
						}
						goto case 1;
					case 2:
						if (ApRpExp.MoveMSec > 0)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024_0024wait_sec_0024temp_00242685_002422193 = 0.5f;
						goto case 3;
					case 3:
						if (_0024_0024wait_sec_0024temp_00242685_002422193 > 0f)
						{
							_0024_0024wait_sec_0024temp_00242685_002422193 -= Time.deltaTime;
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						_0024self__002422198.questManager.CurQuest = _0024self__002422198.curQuest;
						_0024self__002422198.questManager.CurPoppet = _0024self__002422198.curPet;
						_0024self__002422198.questManager.CurFrPoppet = _0024self__002422198.curFrPet;
						_0024self__002422198.questManager.CurWeapon = _0024self__002422198.curWeapon;
						_0024curRespFriend_002422194 = null;
						if (_0024self__002422198.curFrPet != null)
						{
							_0024index_002422195 = _0024self__002422198.curFrPet.Id.Value;
							if (QuestMenuBase.respFriends != null && 0L <= _0024index_002422195 && _0024index_002422195 < (long)QuestMenuBase.respFriends.Length)
							{
								RespFriend[] respFriends = QuestMenuBase.respFriends;
								_0024curRespFriend_002422194 = respFriends[RuntimeServices.NormalizeArrayIndex(respFriends, (int)_0024index_002422195)];
							}
						}
						QuestMenuBase.respFriends = null;
						_0024story_002422196 = QuestManager.findStory(_0024self__002422198.curQuest);
						if (!_0024ud_002422192.userMiscInfo.questData.isPlay(_0024self__002422198.curQuest.Id))
						{
							_0024ud_002422192.userMiscInfo.questData.play(_0024self__002422198.curQuest.Id);
						}
						if (_0024story_002422196 != null && _0024curRespFriend_002422194 != null)
						{
							_0024friendPoppet_002422197 = new RespFriendPoppet(_0024curRespFriend_002422194);
							if (GameParameter.itsFriend)
							{
								_0024friendPoppet_002422197.IsFriend = true;
							}
							QuestSession.StartQuest(_0024story_002422196.Id, _0024friendPoppet_002422197, noSceneLoad: false);
							_0024self__002422198.questManager.StartQuest = true;
							_0024self__002422198.curQuest = null;
							_0024self__002422198.curFrPet = null;
							_0024ud_002422192.SetOld2AllNewItem();
							YieldDefault(1);
							goto case 1;
						}
						if (_0024story_002422196 == null)
						{
							throw new Exception(new StringBuilder("プレイストーリーが選択できてない... ").Append(_0024self__002422198.curQuest).ToString());
						}
						if (_0024curRespFriend_002422194 == null)
						{
							throw new Exception("助っ人魔ペット選択できてない...");
						}
						throw new Exception("なんでプレイできないのかわからない...");
					case 1:
						result = 0;
						break;
					}
				}
				return (byte)result != 0;
			}
		}

		internal WorldQuestMain _0024self__002422199;

		public _0024StartQuestCore_002422191(WorldQuestMain self_)
		{
			_0024self__002422199 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002422199);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024Initialize_0024closure_00243233_002422200 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal UserData _0024ud_002422201;

			internal int _0024rank_002422202;

			internal MQuests[] _0024normalQuests_002422203;

			internal MQuests[] _0024tmpQuests1_002422204;

			internal MQuests[] _0024tmpQuests2_002422205;

			internal MQuests _0024tutoQuest_002422206;

			internal int _0024rank_002422207;

			internal MQuests[] _0024spQuests_002422208;

			internal int _0024rank_002422209;

			internal int _0024_002411849_002422210;

			internal MQuests[] _0024_002411850_002422211;

			internal int _0024_002411851_002422212;

			internal int _0024_002411853_002422213;

			internal int _0024_002411854_002422214;

			internal int _0024_002411855_002422215;

			internal int _0024_002411856_002422216;

			internal int _0024_002411857_002422217;

			internal int _0024_002411858_002422218;

			internal int _0024_002411859_002422219;

			internal int _0024_002411860_002422220;

			internal int _0024_002411861_002422221;

			internal WorldQuestMain _0024self__002422222;

			public _0024(WorldQuestMain self_)
			{
				_0024self__002422222 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__002422222.curArea != null)
					{
						_0024self__002422222.curType = _0024self__002422222.LoadListType();
						_0024self__002422222.lastType = _0024self__002422222.curType;
					}
					goto case 2;
				case 2:
					if (MerlinServer.Instance.IsBusy)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002422222.dlgMan = DialogManager.Instance;
					_0024self__002422222.count = 0;
					_0024self__002422222.mode = WORLD_QUEST_MODE.SelectQuest;
					_0024self__002422222.lastMode = WORLD_QUEST_MODE.None;
					_0024ud_002422201 = UserData.Current;
					if (_0024ud_002422201 == null)
					{
						throw new AssertionFailedException("ud != null");
					}
					if (_0024ud_002422201.IsValidDeck2)
					{
						_0024self__002422222.curWeapon = _0024ud_002422201.ActiveWeapon;
					}
					else
					{
						_0024self__002422222.curWeapon = _0024ud_002422201.MainWeapon;
					}
					_0024self__002422222.curPet = _0024ud_002422201.CurrentPoppetNewOrOldDeck;
					_0024self__002422222.curFrPet = null;
					if (SceneChanger.LastSceneName == "Ui_MyHomeEquip" && !BattleHUDShortcut.IsSceneFromShortcut)
					{
						_0024self__002422222.questManager.CurWeapon = _0024self__002422222.curWeapon;
						_0024self__002422222.questManager.CurPoppet = _0024self__002422222.curPet;
						_0024self__002422222.mode = WORLD_QUEST_MODE.ConfQuest;
						_0024self__002422222.lastMode = WORLD_QUEST_MODE.None;
						_0024self__002422222.curQuest = _0024self__002422222.questManager.CurQuest;
						_0024self__002422222.curFrPet = _0024self__002422222.questManager.CurFrPoppet;
						DeckSelector.selFrMapet(_0024self__002422222.curFrPet, _0024self__002422222.curFrPet != null && _0024self__002422222.curFrPet.IsFriend);
					}
					DeckSelector.UpdateEquip();
					if (_0024self__002422222.questList != null)
					{
						if (_0024self__002422222.curArea.JumpType == EnumAreaTypes.Quest)
						{
							_0024_002411853_002422213 = 0;
							_0024_002411854_002422214 = 4;
							_0024_002411855_002422215 = 1;
							if (_0024_002411854_002422214 < _0024_002411853_002422213)
							{
								_0024_002411855_002422215 = -1;
							}
							while (_0024_002411853_002422213 != _0024_002411854_002422214)
							{
								_0024rank_002422202 = _0024_002411853_002422213;
								_0024_002411853_002422213 += _0024_002411855_002422215;
								_0024normalQuests_002422203 = new MQuests[0];
								checked
								{
									_0024tmpQuests1_002422204 = _0024self__002422222.questManager.GetCurNormalQuestList(_0024rank_002422202 + 1);
									_0024tmpQuests2_002422205 = _0024self__002422222.questManager.GetCurTutorialQuestList(_0024rank_002422202 + 1);
									if (_0024tmpQuests1_002422204 != null)
									{
										_0024normalQuests_002422203 = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), _0024normalQuests_002422203, _0024tmpQuests1_002422204);
									}
									if (_0024tmpQuests2_002422205 != null)
									{
										_0024normalQuests_002422203 = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), _0024normalQuests_002422203, _0024tmpQuests2_002422205);
									}
									if (_0024tmpQuests2_002422205 != null)
									{
										_0024_002411849_002422210 = 0;
										_0024_002411850_002422211 = _0024tmpQuests2_002422205;
										for (_0024_002411851_002422212 = _0024_002411850_002422211.Length; _0024_002411849_002422210 < _0024_002411851_002422212; _0024_002411849_002422210++)
										{
											if (!_0024ud_002422201.userMiscInfo.questData.isPlay(_0024_002411850_002422211[_0024_002411849_002422210].Id))
											{
												_0024ud_002422201.userMiscInfo.questData.play(_0024_002411850_002422211[_0024_002411849_002422210].Id);
											}
										}
									}
								}
								_0024self__002422222.SetQuestList((QUEST_LIST_TYPE)(0 + _0024rank_002422202), _0024normalQuests_002422203);
							}
						}
						else if (_0024self__002422222.curArea.JumpType == EnumAreaTypes.SpecialQuest)
						{
							_0024_002411856_002422216 = 0;
							_0024_002411857_002422217 = 4;
							_0024_002411858_002422218 = 1;
							if (_0024_002411857_002422217 < _0024_002411856_002422216)
							{
								_0024_002411858_002422218 = -1;
							}
							while (_0024_002411856_002422216 != _0024_002411857_002422217)
							{
								_0024rank_002422207 = _0024_002411856_002422216;
								_0024_002411856_002422216 += _0024_002411858_002422218;
								_0024spQuests_002422208 = _0024self__002422222.questManager.GetCurSpecialQuestList(checked(_0024rank_002422207 + 1), nameSort: true);
								_0024self__002422222.SetQuestList((QUEST_LIST_TYPE)(0 + _0024rank_002422207), _0024spQuests_002422208);
							}
						}
						else if (_0024self__002422222.curArea.JumpType == EnumAreaTypes.BoostQuest)
						{
							_0024_002411859_002422219 = 0;
							_0024_002411860_002422220 = 4;
							_0024_002411861_002422221 = 1;
							if (_0024_002411860_002422220 < _0024_002411859_002422219)
							{
								_0024_002411861_002422221 = -1;
							}
							while (_0024_002411859_002422219 != _0024_002411860_002422220)
							{
								_0024rank_002422209 = _0024_002411859_002422219;
								_0024_002411859_002422219 += _0024_002411861_002422221;
								_0024spQuests_002422208 = _0024self__002422222.questManager.GetCurBoostQuestList(checked(_0024rank_002422209 + 1), nameSort: true);
								_0024self__002422222.SetQuestList((QUEST_LIST_TYPE)(0 + _0024rank_002422209), _0024spQuests_002422208);
							}
						}
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

		internal WorldQuestMain _0024self__002422223;

		public _0024_0024Initialize_0024closure_00243233_002422200(WorldQuestMain self_)
		{
			_0024self__002422223 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002422223);
		}
	}

	public int count;

	public GameObject questListPrefab;

	public QuestList[] questList;

	public Transform questListParent;

	public GameObject[] questListPanel;

	public UIDynamicFontLabel questTitleLabel;

	public UIDynamicFontLabel questExplainLabel;

	private WORLD_QUEST_MODE mode;

	private WORLD_QUEST_MODE lastMode;

	private QUEST_LIST_TYPE curType;

	private QUEST_LIST_TYPE lastType;

	protected int listActiveWait;

	public UIButtonMessage selQuestButton;

	private UIValidController selQuestButtonValidCtrl;

	private string[] questTitles;

	private string spQuestTitle;

	private string boostQuestTitle;

	private string[] buttonSpriteNames;

	public UISprite buttonSprite;

	private string[] rankNames;

	public UILabelBase rankButtonLabel;

	protected bool checkTicket;

	public WORLD_QUEST_MODE Mode => mode;

	public WorldQuestMain()
	{
		questList = new QuestList[4];
		questListPanel = new GameObject[4];
		curType = (curType = QUEST_LIST_TYPE.Lo);
		lastType = (curType = QUEST_LIST_TYPE.None);
	}

	public override void SceneStart()
	{
		RuntimeAssetBundleDB.Instance.instantiatePrefab("ZPatch001QuestMenu");
		ResetRespFriends();
		questTitles = new string[4]
		{
			MTexts.Msg("$WQ_QUEST_L_INFO"),
			MTexts.Msg("$WQ_QUEST_M_INFO"),
			MTexts.Msg("$WQ_QUEST_H_INFO"),
			MTexts.Msg("$WQ_QUEST_EX_INFO")
		};
		spQuestTitle = MTexts.Msg("$WQ_QUEST_SP_INFO");
		boostQuestTitle = MTexts.Msg("$WQ_QUEST_BOOST_INFO");
		buttonSpriteNames = new string[4] { "button09", "button_que00", "button_que01", "button_que02" };
		rankNames = new string[4]
		{
			MTexts.Msg("exp_quest_l_rank"),
			MTexts.Msg("exp_quest_m_rank"),
			MTexts.Msg("exp_quest_h_rank"),
			MTexts.Msg("exp_quest_ex_rank")
		};
		InitDetail();
		selFrPetButtonValidCtrl = ExtensionsModule.SetComponent<UIValidController>(selFrPetButton.gameObject);
		confQuestButtonValidCtrl = ExtensionsModule.SetComponent<UIValidController>(confQuestButton.gameObject);
		if ((bool)selQuestButton)
		{
			selQuestButtonValidCtrl = ExtensionsModule.SetComponent<UIValidController>(selQuestButton.gameObject);
		}
		if ((bool)detailButton)
		{
			detailButtonValidCtrl = ExtensionsModule.SetComponent<UIValidController>(detailButton.gameObject);
		}
		InitQuestInfo();
		if ((bool)mapetList)
		{
			mapetList.hookSettingListItem = base.hookFriendListSettingItem;
			mapetList.hookSelectItem = base.hookFriendListSelect;
			if ((bool)mapetList.sortButton)
			{
				mapetList.sortButton.CheckCloseFunc = () => mode != WORLD_QUEST_MODE.SelectPet;
			}
		}
		DeckSelector.deselect();
		questManager = QuestManager.Instance;
		curArea = questManager.curArea;
		if (curArea != null)
		{
			title = curArea.DisplayName;
		}
		questTitleLabel.text = string.Empty;
		questExplainLabel.text = string.Empty;
		int num = 0;
		int num2 = 4;
		int num3 = 1;
		if (num2 < num)
		{
			num3 = -1;
		}
		while (num != num2)
		{
			int index = num;
			num += num3;
			GameObject gameObject = ((GameObject)UnityEngine.Object.Instantiate(questListPrefab)) as GameObject;
			if (!gameObject)
			{
				continue;
			}
			gameObject.transform.parent = questListParent;
			gameObject.transform.localScale = Vector3.one;
			gameObject.SetActive(value: false);
			QuestList component = gameObject.GetComponent<QuestList>();
			if (component != null)
			{
				component.gameObject.SetActive(value: false);
				UIAutoTweener component2 = component.GetComponent<UIAutoTweener>();
				if (component2 != null)
				{
					component2.Initialize(GetSituation(0));
				}
			}
			QuestList[] array = questList;
			array[RuntimeServices.NormalizeArrayIndex(array, index)] = component;
		}
		mode = WORLD_QUEST_MODE.None;
		lastMode = WORLD_QUEST_MODE.None;
		MerlinServer.EditorCommunicationInitialize((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			DeckSelector.Init(UserData.Current.userDeckData2.CurrentDeck, UserData.Current.userDeckData2.deckNum());
			InitializeHelpPlayer();
			if ((bool)stoneList)
			{
				stoneList.Download();
			}
		});
	}

	protected new void OnDestroy()
	{
		StoreListType(curType);
		base.OnDestroy();
	}

	public void InitializeHelpPlayer()
	{
		if (QuestMenuBase.respFriends != null)
		{
			Initialize();
			return;
		}
		UserData current = UserData.Current;
		if (current == null)
		{
			SceneChanger.Change("Ui_World");
			QuestMenuBase.respFriends = null;
			return;
		}
		ApiFriendPlayerSearch apiFriendPlayerSearch = new ApiFriendPlayerSearch();
		apiFriendPlayerSearch.IsRecommend = true;
		apiFriendPlayerSearch.Num = MGameParameters.findByGameParameterId(51).Param;
		apiFriendPlayerSearch.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
		{
			SceneChanger.Change("Ui_World");
			QuestMenuBase.respFriends = null;
		});
		MerlinServer.Request(apiFriendPlayerSearch, _0024adaptor_0024__MessageBoard_PushFriendSearch_0024callable145_0024918_13___0024__MerlinServer_Request_0024callable86_0024160_56___0024212.Adapt(CallBackHelpPlayer));
	}

	public void CallBackHelpPlayer(ApiFriendPlayerSearch req)
	{
		if (req == null)
		{
			SceneChanger.Change("Ui_World");
			QuestMenuBase.respFriends = null;
			return;
		}
		ApiFriendPlayerSearch.Resp response = req.GetResponse();
		if (response == null)
		{
			throw new AssertionFailedException("resp != null");
		}
		QuestMenuBase.respFriends = response.Friends;
		Initialize();
	}

	private void Initialize()
	{
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024Initialize_0024closure_00243233_002422200(this).GetEnumerator();
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void SetQuestList(QUEST_LIST_TYPE type, MQuests[] quests)
	{
		MQuests[] array = new MQuests[0];
		if (quests != null)
		{
			int i = 0;
			for (int length = quests.Length; i < length; i = checked(i + 1))
			{
				array = (MQuests[])RuntimeServices.AddArrays(typeof(MQuests), new MQuests[1] { quests[i] }, array);
			}
		}
		QuestList[] array2 = this.questList;
		QuestList questList = array2[RuntimeServices.NormalizeArrayIndex(array2, (int)type)];
		string text = "quest";
		__WorldColosseumMain_InitColosseumEventList_0024callable137_0024412_24__ from = delegate(Boo.Lang.List<UIListBase.Container> container)
		{
			__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24__ from2 = checked(delegate(UIListBase.Container a, UIListBase.Container b)
			{
				MQuests data = a.data.GetData<MQuests>();
				MQuests data2 = b.data.GetData<MQuests>();
				int num = data2.SortPriority - data.SortPriority;
				int result;
				if (num != 0)
				{
					result = num;
				}
				else if (data.NeedTicket && !data2.NeedTicket)
				{
					result = -1;
				}
				else if (!data.NeedTicket && data2.NeedTicket)
				{
					result = 1;
				}
				else
				{
					if (data.NeedTicket && data2.NeedTicket)
					{
						int num2 = MasterExtensionsModule.TicketMinimumId(data) - MasterExtensionsModule.TicketMinimumId(data2);
						if (num2 != 0)
						{
							result = num2;
							goto IL_00b5;
						}
					}
					result = b.data.id.CompareTo(a.data.id);
				}
				goto IL_00b5;
				IL_00b5:
				return result;
			});
			return SortFuncs.sort(container, SortFuncs.UIListBaseContainerFuncArray(_0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(from2)));
		};
		questList.SetSortTypeName(new string[1] { text }, 0);
		questList.SetSortFunc(text, _0024adaptor_0024__WorldColosseumMain_InitColosseumEventList_0024callable137_0024412_24___0024ListSortFunc_0024183.Adapt(from));
		questList.SetInputQuestList(array, curArea);
		questList.SelectItem(0);
		SetQuestInfo(curInfo);
	}

	public override void SceneUpdate()
	{
		checked
		{
			count++;
			if ((lastMode != WORLD_QUEST_MODE.None && !FaderCore.Instance.isCompleted) || !SceneChanger.isCompletelyReady || InventoryOverDialog.IsOpenInventoryOverDialog() || IsChangingSituation || stoneList.IsDialogUpdating(this))
			{
				return;
			}
		}
		if (mode != lastMode)
		{
			lastMode = mode;
			if (mode != WORLD_QUEST_MODE.Start)
			{
				ChangeSituation(GetSituation((int)mode));
			}
			if (mode == WORLD_QUEST_MODE.SelectQuest)
			{
				InitQuestList();
			}
			else if (mode == WORLD_QUEST_MODE.SelectPet)
			{
				InitFriendPetList();
			}
			else if (mode == WORLD_QUEST_MODE.ConfQuest)
			{
				DeckSelector.selFrMapet(curFrPet, curFrPet != null && curFrPet.IsFriend);
				DeckSelector.UpdateEquip();
				bool flag = false;
				if (null != missionList)
				{
					flag = missionList.SetQuest(curQuest, MissionList.ListType.Normal);
				}
				if (null != missionButton)
				{
					missionButton.gameObject.SetActive(flag);
				}
			}
			if (curArea != null)
			{
				title = curArea.DisplayName;
			}
			SceneTitleHUD.UpdateTitle(title);
		}
		if (mode == WORLD_QUEST_MODE.SelectQuest)
		{
			QuestListCtrl();
		}
		else if (mode == WORLD_QUEST_MODE.SelectPet)
		{
			FriendPetListCtrl();
		}
		else if (mode == WORLD_QUEST_MODE.ConfQuest)
		{
			ConfQuestCtrl();
		}
	}

	public void InitQuestList()
	{
		curType = lastType;
		lastType = QUEST_LIST_TYPE.None;
		if (curType == QUEST_LIST_TYPE.None)
		{
			curType = QUEST_LIST_TYPE.Lo;
		}
		int num = 0;
		int num2 = 4;
		int num3 = 1;
		if (num2 < num)
		{
			num3 = -1;
		}
		while (num != num2)
		{
			int index = num;
			num += num3;
			QuestList[] array = this.questList;
			QuestList questList = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if ((bool)questList)
			{
				questList.gameObject.SetActive(value: false);
				questList.hookSelectItem = hookQuestListSelect;
			}
		}
		listActiveWait = 5;
		curQuest = null;
	}

	public void QuestListCtrl()
	{
		if (MerlinServer.Instance.IsBusy || null == this.questList)
		{
			return;
		}
		bool flag = false;
		if (curType != lastType)
		{
			flag = true;
			int num = 0;
			int length = questListPanel.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int index = num;
				num++;
				GameObject[] array = questListPanel;
				GameObject gameObject = array[RuntimeServices.NormalizeArrayIndex(array, index)];
				if (null == gameObject)
				{
					continue;
				}
				UITweener[] componentsInChildren = gameObject.GetComponentsInChildren<UITweener>(includeInactive: true);
				IEnumerator enumerator = componentsInChildren.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is UITweener))
					{
						obj = RuntimeServices.Coerce(obj, typeof(UITweener));
					}
					UITweener uITweener = (UITweener)obj;
					uITweener.Reset();
					uITweener.enabled = true;
				}
			}
			int num2 = 0;
			int length2 = questListPanel.Length;
			if (length2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num2 < length2)
			{
				int num3 = num2;
				num2++;
				GameObject[] array2 = questListPanel;
				GameObject gameObject = array2[RuntimeServices.NormalizeArrayIndex(array2, num3)];
				if (!(null == gameObject))
				{
					gameObject.SetActive(curType == (QUEST_LIST_TYPE)num3);
				}
			}
			if (null != buttonSprite)
			{
				UISprite uISprite = buttonSprite;
				string[] array3 = buttonSpriteNames;
				uISprite.spriteName = array3[RuntimeServices.NormalizeArrayIndex(array3, (int)curType)];
			}
			if (null != rankButtonLabel)
			{
				UILabelBase uILabelBase = rankButtonLabel;
				string[] array4 = rankNames;
				uILabelBase.text = array4[RuntimeServices.NormalizeArrayIndex(array4, (int)curType)];
			}
			if (curArea.JumpType == EnumAreaTypes.Quest)
			{
				UIDynamicFontLabel label = questTitleLabel;
				string[] array5 = questTitles;
				UIBasicUtility.SetLabel(label, array5[RuntimeServices.NormalizeArrayIndex(array5, (int)curType)], show: true);
			}
			else if (curArea.JumpType == EnumAreaTypes.SpecialQuest)
			{
				UIBasicUtility.SetLabel(questTitleLabel, spQuestTitle, show: true);
			}
			else if (curArea.JumpType == EnumAreaTypes.BoostQuest)
			{
				UIBasicUtility.SetLabel(questTitleLabel, boostQuestTitle, show: true);
			}
			lastQuest = null;
			int num4 = 0;
			int num5 = 4;
			int num6 = 1;
			if (num5 < num4)
			{
				num6 = -1;
			}
			while (num4 != num5)
			{
				int index2 = num4;
				num4 += num6;
				QuestList[] array6 = this.questList;
				QuestList questList = array6[RuntimeServices.NormalizeArrayIndex(array6, index2)];
				if (!(null == questList))
				{
					questList.gameObject.SetActive(value: false);
					UITweener component = questList.GetComponent<UITweener>();
					if ((bool)component)
					{
						component.Reset();
						component.enabled = true;
					}
				}
			}
			lastType = curType;
			listActiveWait = 5;
			StoreListType(curType);
			if (QUEST_LIST_TYPE.None < curType)
			{
				string text = null;
				if (curQuest != null && curQuest.Rank == (int)curType && !string.IsNullOrEmpty(curQuest.GetName()))
				{
					text = curQuest.GetName();
				}
				QuestList[] array7 = this.questList;
				array7[RuntimeServices.NormalizeArrayIndex(array7, (int)curType)].InitList(text);
			}
		}
		if (listActiveWait > 0)
		{
			checked
			{
				listActiveWait--;
			}
			if (listActiveWait == 0)
			{
				int num7 = 0;
				int num8 = 4;
				int num9 = 1;
				if (num8 < num7)
				{
					num9 = -1;
				}
				while (num7 != num8)
				{
					int num10 = num7;
					num7 += num9;
					QuestList[] array8 = this.questList;
					QuestList questList = array8[RuntimeServices.NormalizeArrayIndex(array8, num10)];
					if (null != questList)
					{
						questList.gameObject.SetActive(curType == (QUEST_LIST_TYPE)num10);
					}
				}
			}
		}
		QuestList[] array9 = this.questList;
		curQuest = array9[RuntimeServices.NormalizeArrayIndex(array9, (int)curType)].CurInfo;
		if (!RuntimeServices.EqualityOperator(curQuest, lastQuest) || flag)
		{
			lastQuest = curQuest;
			string text2 = null;
			if (curQuest != null)
			{
				text2 = curQuest.GetExplain();
			}
			UIBasicUtility.SetLabel(questExplainLabel, text2, show: true);
			UpdateTreasureIcon(curQuest);
			UpdateMonsterList(curQuest);
		}
		if ((bool)selQuestButtonValidCtrl)
		{
			UIValidController uIValidController = selQuestButtonValidCtrl;
			bool num11 = curQuest != null;
			if (num11)
			{
				num11 = !stoneListBusy;
			}
			uIValidController.isValidColor = num11;
		}
	}

	public void StoreListType(QUEST_LIST_TYPE type)
	{
		if (curArea != null)
		{
			if (curArea.JumpType == EnumAreaTypes.Quest)
			{
				QUEST_LIST_TYPE[] questListType = UserData.Current.userMiscInfo.questListType;
				questListType[RuntimeServices.NormalizeArrayIndex(questListType, 0)] = curType;
			}
			else if (curArea.JumpType == EnumAreaTypes.SpecialQuest)
			{
				QUEST_LIST_TYPE[] questListType2 = UserData.Current.userMiscInfo.questListType;
				questListType2[RuntimeServices.NormalizeArrayIndex(questListType2, 1)] = curType;
			}
			else if (curArea.JumpType == EnumAreaTypes.BoostQuest)
			{
				QUEST_LIST_TYPE[] questListType3 = UserData.Current.userMiscInfo.questListType;
				questListType3[RuntimeServices.NormalizeArrayIndex(questListType3, 2)] = curType;
			}
		}
	}

	public QUEST_LIST_TYPE LoadListType()
	{
		QUEST_LIST_TYPE result = default(QUEST_LIST_TYPE);
		if (curArea != null)
		{
			if (curArea.JumpType == EnumAreaTypes.Quest)
			{
				QUEST_LIST_TYPE[] questListType = UserData.Current.userMiscInfo.questListType;
				return questListType[RuntimeServices.NormalizeArrayIndex(questListType, 0)];
			}
			if (curArea.JumpType == EnumAreaTypes.SpecialQuest)
			{
				QUEST_LIST_TYPE[] questListType2 = UserData.Current.userMiscInfo.questListType;
				return questListType2[RuntimeServices.NormalizeArrayIndex(questListType2, 1)];
			}
			if (curArea.JumpType == EnumAreaTypes.BoostQuest)
			{
				QUEST_LIST_TYPE[] questListType3 = UserData.Current.userMiscInfo.questListType;
				return questListType3[RuntimeServices.NormalizeArrayIndex(questListType3, 2)];
			}
		}
		return result;
	}

	public bool hookQuestListSelect(UIListItem item)
	{
		QuestListItem questListItem = (QuestListItem)item;
		MQuests data = item.GetData<MQuests>();
		int result;
		if (RuntimeServices.EqualityOperator(curQuest, data))
		{
			SelectQuest();
			result = 1;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public void SelectQuest()
	{
		if (IsChangingSituation || stoneListBusy || curQuest == null)
		{
			return;
		}
		UserData current = UserData.Current;
		if (questList == null || curType <= QUEST_LIST_TYPE.None)
		{
			return;
		}
		QuestList[] array = questList;
		MQuests mQuests = array[RuntimeServices.NormalizeArrayIndex(array, (int)curType)].CurInfo;
		if (mQuests == null || !CheckQuest(mQuests))
		{
			return;
		}
		if (current.Ap < curQuest.ApCost)
		{
			if (curQuest.ApCost <= current.MaxAp)
			{
				stoneList.ShowCureApDialog();
				stoneListBusy = true;
				stoneList.OnEnd = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34___0024211.Adapt(delegate
				{
					stoneListBusy = false;
					lastMode = WORLD_QUEST_MODE.None;
				});
			}
		}
		else
		{
			curQuest = mQuests;
			if (!current.userMiscInfo.questData.isLook(mQuests.Id))
			{
				current.userMiscInfo.questData.look(mQuests.Id);
			}
			mode = WORLD_QUEST_MODE.SelectPet;
		}
	}

	public bool CheckQuest(MQuests quest)
	{
		_0024CheckQuest_0024locals_002414562 _0024CheckQuest_0024locals_0024 = new _0024CheckQuest_0024locals_002414562();
		_0024CheckQuest_0024locals_0024._0024quest = quest;
		int result;
		if (!MasterExtensionsModule.IsTicket(_0024CheckQuest_0024locals_0024._0024quest))
		{
			result = 1;
		}
		else if (MasterExtensionsModule.IsOpen(_0024CheckQuest_0024locals_0024._0024quest))
		{
			result = 1;
		}
		else if (checkTicket)
		{
			result = 0;
		}
		else
		{
			int notUseTicketCount = MasterExtensionsModule.GetNotUseTicketCount(_0024CheckQuest_0024locals_0024._0024quest);
			int ticketCount = MasterExtensionsModule.GetTicketCount(_0024CheckQuest_0024locals_0024._0024quest);
			RespQuestTicket notOpenTicket = MasterExtensionsModule.GetNotOpenTicket(_0024CheckQuest_0024locals_0024._0024quest);
			bool flag = false;
			string explain = notOpenTicket.GetExplain();
			if (notUseTicketCount > 0 && notOpenTicket != null)
			{
				TimeSpan effetiveTime = notOpenTicket.GetEffetiveTime();
				string text = string.Empty;
				if (!(effetiveTime.TotalDays < 1.0))
				{
					text = UIBasicUtility.SafeFormat("{0:n0}日", effetiveTime.TotalDays);
				}
				else if (!(effetiveTime.TotalHours <= 1.0))
				{
					text = UIBasicUtility.SafeFormat("{0:n0}時間{1:n0}分", effetiveTime.Hours, effetiveTime.Minutes);
				}
				else if (effetiveTime.TotalHours == 1.0)
				{
					text = UIBasicUtility.SafeFormat("{0:n0}時間", effetiveTime.Hours);
				}
				else if (!(effetiveTime.TotalSeconds < 1.0))
				{
					text = UIBasicUtility.SafeFormat("{0:n0}分", effetiveTime.TotalMinutes);
				}
				else if (effetiveTime.Ticks < 0)
				{
					text = "0分";
				}
				checkTicket = true;
				string message = UIBasicUtility.SafeFormat(MTexts.Msg("$WQ_QUEST_OPEN"), explain, explain, text, explain, notUseTicketCount, ticketCount);
				string text2 = UIBasicUtility.SafeFormat(MTexts.Msg("$WQ_QUEST_OPEN_TITLE"), explain);
				Dialog dialog = dlgMan.OpenDialog(message, text2, new string[2]
				{
					MTexts.Msg("exp_no"),
					MTexts.Msg("exp_yes")
				});
				dialog.CloseHandler = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
				{
					checkTicket = false;
				};
				dialog.ButtonHandler = new _0024CheckQuest_0024closure_00243250(_0024CheckQuest_0024locals_0024).Invoke;
			}
			else
			{
				string message = UIBasicUtility.SafeFormat(MTexts.Msg("$WQ_QUEST_OPEN_ERROR"), explain, explain, notUseTicketCount, ticketCount);
				checkTicket = true;
				Dialog dialog = DialogManager.Open(message, string.Empty);
				dialog.CloseHandler = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
				{
					checkTicket = false;
				};
			}
			result = (flag ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public override void SelectPet()
	{
		if (!IsChangingSituation && mode == WORLD_QUEST_MODE.SelectPet && curFrPet != null)
		{
			DeckSelector.selFrMapet(curFrPet, curFrPet != null && curFrPet.IsFriend);
			mode = WORLD_QUEST_MODE.ConfQuest;
			questManager.CurQuest = curQuest;
			questManager.CurPoppet = curPet;
			questManager.CurFrPoppet = curFrPet;
			questManager.CurWeapon = curWeapon;
		}
	}

	public virtual void GotoMyhome(MyHomeEquipMain.MY_HOME_EQUIP_START_MODE startMode)
	{
		if (!stoneListBusy && mode == WORLD_QUEST_MODE.ConfQuest)
		{
			MyHomeEquipMain.BackScene = "Ui_WorldQuest";
			MyHomeEquipMain.StartMode = startMode;
			MyHomeEquipMain.BgSpriteName = "map";
			ChangeSceneLikeQuestSubScene(SceneID.Ui_MyHomeEquip);
		}
	}

	public void PushTreasureInfo()
	{
		SetQuestInfo(QUEST_INFO_TYPE.TREASURE);
	}

	public void PushMonsterInfo()
	{
		SetQuestInfo(QUEST_INFO_TYPE.MONSTER);
	}

	public void PushCategory()
	{
		if (!IsChangingSituation)
		{
			if (curType == QUEST_LIST_TYPE.Lo)
			{
				curType = QUEST_LIST_TYPE.Mid;
			}
			else if (curType == QUEST_LIST_TYPE.Mid)
			{
				curType = QUEST_LIST_TYPE.Hi;
			}
			else if (curType == QUEST_LIST_TYPE.Hi)
			{
				curType = QUEST_LIST_TYPE.Ex;
			}
			else if (curType == QUEST_LIST_TYPE.Ex)
			{
				curType = QUEST_LIST_TYPE.Lo;
			}
		}
	}

	public void PushCategoryDec()
	{
		if (!IsChangingSituation)
		{
			if (curType == QUEST_LIST_TYPE.Lo)
			{
				curType = QUEST_LIST_TYPE.Ex;
			}
			else if (curType == QUEST_LIST_TYPE.Mid)
			{
				curType = QUEST_LIST_TYPE.Lo;
			}
			else if (curType == QUEST_LIST_TYPE.Hi)
			{
				curType = QUEST_LIST_TYPE.Mid;
			}
			else if (curType == QUEST_LIST_TYPE.Ex)
			{
				curType = QUEST_LIST_TYPE.Hi;
			}
		}
	}

	public void PushCategoryLow()
	{
		if (!IsChangingSituation)
		{
			curType = QUEST_LIST_TYPE.Lo;
		}
	}

	public void PushCategoryMid()
	{
		if (!IsChangingSituation)
		{
			curType = QUEST_LIST_TYPE.Mid;
		}
	}

	public void PushCategoryHi()
	{
		if (!IsChangingSituation)
		{
			curType = QUEST_LIST_TYPE.Hi;
		}
	}

	public void PushCategoryEx()
	{
		if (!IsChangingSituation)
		{
			curType = QUEST_LIST_TYPE.Ex;
		}
	}

	public void PushSort(string key)
	{
		if (mode == WORLD_QUEST_MODE.SelectPet)
		{
			mapetList.PushSort(key);
		}
	}

	public void PushDetail(GameObject obj)
	{
		if (IsChangingSituation)
		{
			return;
		}
		if (mode == WORLD_QUEST_MODE.SelectPet)
		{
			if (curFrPet != null && !(null == detailPoppetInfo) && !detailPoppetInfo.active)
			{
				detailPoppetInfo.SetMuppet(curFrPet, ignoreUnknown: true);
				UIAutoTweenerStandAloneEx.In(detailPoppetInfo.gameObject);
				mode = WORLD_QUEST_MODE.Detail;
			}
		}
		else
		{
			if (null == obj)
			{
				return;
			}
			MapetListItem componentInChildren = obj.GetComponentInChildren<MapetListItem>();
			WeaponListItem componentInChildren2 = obj.GetComponentInChildren<WeaponListItem>();
			if (null != componentInChildren)
			{
				if (componentInChildren.mapetInfo != null && !(null == detailPoppetInfo) && !detailPoppetInfo.active)
				{
					detailPoppetInfo.SetMuppet(componentInChildren.mapetInfo, ignoreUnknown: true);
					UIAutoTweenerStandAloneEx.In(detailPoppetInfo.gameObject);
					mode = WORLD_QUEST_MODE.MissionDetail;
				}
			}
			else if (null != componentInChildren2 && componentInChildren2.weaponInfo != null && !(null == detailWeaponInfo) && !detailWeaponInfo.active)
			{
				detailWeaponInfo.SetWeapon(componentInChildren2.weaponInfo, ignoreUnknown: true);
				UIAutoTweenerStandAloneEx.In(detailWeaponInfo.gameObject);
				mode = WORLD_QUEST_MODE.MissionDetail;
			}
		}
	}

	public void PushMission(GameObject obj)
	{
		if (!IsChangingSituation)
		{
			mode = WORLD_QUEST_MODE.Mission;
		}
	}

	public void PushBack(GameObject obj)
	{
		if (IsChangingSituation)
		{
			return;
		}
		if (CurrentSituation == stoneList.Situation)
		{
			stoneList.PushCancel();
		}
		else if (mode == WORLD_QUEST_MODE.SelectQuest)
		{
			SceneChanger.ChangeTo(SceneID.Ui_World);
			QuestMenuBase.respFriends = null;
		}
		else if (mode == WORLD_QUEST_MODE.SelectPet)
		{
			mode = WORLD_QUEST_MODE.SelectQuest;
		}
		else if (mode == WORLD_QUEST_MODE.ConfQuest)
		{
			if (IsShowConfQuestSupportDialog)
			{
				ConfQuest.ShowSupportDialog(aValid: false);
			}
			else if (!DeckSelector.isSwipe)
			{
				confQuest.Close();
				mode = WORLD_QUEST_MODE.SelectPet;
			}
		}
		else if (mode == WORLD_QUEST_MODE.Detail)
		{
			mode = WORLD_QUEST_MODE.SelectPet;
			if (detailWeaponInfo.gameObject.active)
			{
				UIAutoTweenerStandAloneEx.Out(detailWeaponInfo.gameObject);
			}
			if (detailPoppetInfo.gameObject.active)
			{
				UIAutoTweenerStandAloneEx.Out(detailPoppetInfo.gameObject);
			}
		}
		else if (mode == WORLD_QUEST_MODE.Start)
		{
			mode = WORLD_QUEST_MODE.ConfQuest;
		}
		else if (mode == WORLD_QUEST_MODE.Mission)
		{
			mode = WORLD_QUEST_MODE.ConfQuest;
		}
		else if (mode == WORLD_QUEST_MODE.MissionDetail)
		{
			mode = WORLD_QUEST_MODE.Mission;
			if (detailWeaponInfo.gameObject.active)
			{
				UIAutoTweenerStandAloneEx.Out(detailWeaponInfo.gameObject);
			}
			if (detailPoppetInfo.gameObject.active)
			{
				UIAutoTweenerStandAloneEx.Out(detailPoppetInfo.gameObject);
			}
		}
	}

	public virtual IEnumerator StartQuestCore()
	{
		return new _0024StartQuestCore_002422191(this).GetEnumerator();
	}

	internal bool _0024SceneStart_0024closure_00243231()
	{
		return mode != WORLD_QUEST_MODE.SelectPet;
	}

	internal void _0024SceneStart_0024closure_00243232()
	{
		DeckSelector.Init(UserData.Current.userDeckData2.CurrentDeck, UserData.Current.userDeckData2.deckNum());
		InitializeHelpPlayer();
		if ((bool)stoneList)
		{
			stoneList.Download();
		}
	}

	internal IEnumerator _0024Initialize_0024closure_00243233()
	{
		return new _0024_0024Initialize_0024closure_00243233_002422200(this).GetEnumerator();
	}

	internal Boo.Lang.List<UIListBase.Container> _0024SetQuestList_0024closure_00243234(Boo.Lang.List<UIListBase.Container> container)
	{
		__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24__ from = checked(delegate(UIListBase.Container a, UIListBase.Container b)
		{
			MQuests data = a.data.GetData<MQuests>();
			MQuests data2 = b.data.GetData<MQuests>();
			int num = data2.SortPriority - data.SortPriority;
			int result;
			if (num != 0)
			{
				result = num;
			}
			else if (data.NeedTicket && !data2.NeedTicket)
			{
				result = -1;
			}
			else if (!data.NeedTicket && data2.NeedTicket)
			{
				result = 1;
			}
			else
			{
				if (data.NeedTicket && data2.NeedTicket)
				{
					int num2 = MasterExtensionsModule.TicketMinimumId(data) - MasterExtensionsModule.TicketMinimumId(data2);
					if (num2 != 0)
					{
						result = num2;
						goto IL_00b5;
					}
				}
				result = b.data.id.CompareTo(a.data.id);
			}
			goto IL_00b5;
			IL_00b5:
			return result;
		});
		return SortFuncs.sort(container, SortFuncs.UIListBaseContainerFuncArray(_0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(from)));
	}

	internal int _0024_0024SetQuestList_0024closure_00243234_0024closure_00243235(UIListBase.Container a, UIListBase.Container b)
	{
		MQuests data = a.data.GetData<MQuests>();
		MQuests data2 = b.data.GetData<MQuests>();
		int result;
		checked
		{
			int num = data2.SortPriority - data.SortPriority;
			if (num != 0)
			{
				result = num;
			}
			else if (data.NeedTicket && !data2.NeedTicket)
			{
				result = -1;
			}
			else if (!data.NeedTicket && data2.NeedTicket)
			{
				result = 1;
			}
			else
			{
				if (data.NeedTicket && data2.NeedTicket)
				{
					int num2 = MasterExtensionsModule.TicketMinimumId(data) - MasterExtensionsModule.TicketMinimumId(data2);
					if (num2 != 0)
					{
						result = num2;
						goto IL_00b5;
					}
				}
				result = b.data.id.CompareTo(a.data.id);
			}
			goto IL_00b5;
		}
		IL_00b5:
		return result;
	}

	internal void _0024InitializeHelpPlayer_0024closure_00243236()
	{
		SceneChanger.Change("Ui_World");
		QuestMenuBase.respFriends = null;
	}

	internal void _0024SelectQuest_0024closure_00243248()
	{
		stoneListBusy = false;
		lastMode = WORLD_QUEST_MODE.None;
	}

	internal void _0024CheckQuest_0024closure_00243249()
	{
		checkTicket = false;
	}

	internal void _0024CheckQuest_0024closure_00243251()
	{
		checkTicket = false;
	}
}
