using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class WorldChallengeMain : QuestMenuBase
{
	[Serializable]
	public enum WORLD_CHALLENGE_MODE
	{
		None = -1,
		Challenge,
		ChallengeDetail,
		Ranking,
		SelectPet,
		ConfChallenge,
		Detail,
		RpShop,
		CostConf,
		StartQuest,
		RankConf,
		Mission,
		MissionDetail,
		Max
	}

	[Serializable]
	public enum WORLD_CHALLENGE_SUB_MODE
	{
		None = -1,
		Banner,
		DropItem,
		Max
	}

	[Serializable]
	internal class _0024SceneUpdate_0024locals_002414551
	{
		internal ApiWebChallengeBanner _0024apiWebChallangeBanner;

		internal ApiWebChallengeDetail _0024apiWebChallangeDetail;

		internal ApiWebRanking _0024apiWebRanking;
	}

	[Serializable]
	internal class _0024_0024InitializeHelpPlayer_0024closure_00245130_0024locals_002414552
	{
		internal bool _0024flag;
	}

	[Serializable]
	internal class _0024_0024InitializeHelpPlayer_0024closure_00245130_0024closure_00245132
	{
		internal _0024_0024InitializeHelpPlayer_0024closure_00245130_0024locals_002414552 _0024_0024locals_002415226;

		public _0024_0024InitializeHelpPlayer_0024closure_00245130_0024closure_00245132(_0024_0024InitializeHelpPlayer_0024closure_00245130_0024locals_002414552 _0024_0024locals_002415226)
		{
			this._0024_0024locals_002415226 = _0024_0024locals_002415226;
		}

		public void Invoke()
		{
			_0024_0024locals_002415226._0024flag = true;
		}
	}

	[Serializable]
	internal class _0024SceneUpdate_0024closure_00245135
	{
		internal _0024SceneUpdate_0024locals_002414551 _0024_0024locals_002415227;

		internal WorldChallengeMain _0024this_002415228;

		public _0024SceneUpdate_0024closure_00245135(_0024SceneUpdate_0024locals_002414551 _0024_0024locals_002415227, WorldChallengeMain _0024this_002415228)
		{
			this._0024_0024locals_002415227 = _0024_0024locals_002415227;
			this._0024this_002415228 = _0024this_002415228;
		}

		public void Invoke()
		{
			_0024this_002415228.curWebView.OpenHtml(_0024_0024locals_002415227._0024apiWebChallangeBanner.Result, ServerURL.GameServerUrl("/"));
			_0024this_002415228.curWebView.gameObject.SetActive(value: true);
			_0024this_002415228.lastSubMode = WORLD_CHALLENGE_SUB_MODE.None;
		}
	}

	[Serializable]
	internal class _0024SceneUpdate_0024closure_00245136
	{
		internal WorldChallengeMain _0024this_002415229;

		internal _0024SceneUpdate_0024locals_002414551 _0024_0024locals_002415230;

		public _0024SceneUpdate_0024closure_00245136(WorldChallengeMain _0024this_002415229, _0024SceneUpdate_0024locals_002414551 _0024_0024locals_002415230)
		{
			this._0024this_002415229 = _0024this_002415229;
			this._0024_0024locals_002415230 = _0024_0024locals_002415230;
		}

		public void Invoke()
		{
			_0024this_002415229.curWebView.OpenHtml(_0024_0024locals_002415230._0024apiWebChallangeDetail.Result, ServerURL.GameServerUrl("/"));
			_0024this_002415229.curWebView.gameObject.SetActive(value: true);
		}
	}

	[Serializable]
	internal class _0024SceneUpdate_0024closure_00245137
	{
		internal _0024SceneUpdate_0024locals_002414551 _0024_0024locals_002415231;

		internal WorldChallengeMain _0024this_002415232;

		public _0024SceneUpdate_0024closure_00245137(_0024SceneUpdate_0024locals_002414551 _0024_0024locals_002415231, WorldChallengeMain _0024this_002415232)
		{
			this._0024_0024locals_002415231 = _0024_0024locals_002415231;
			this._0024this_002415232 = _0024this_002415232;
		}

		public void Invoke()
		{
			_0024this_002415232.curWebView.OpenHtml(_0024_0024locals_002415231._0024apiWebRanking.Result, ServerURL.GameServerUrl("/"));
			_0024this_002415232.curWebView.gameObject.SetActive(value: true);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024StartQuestCore_002422067 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal UserData _0024ud_002422068;

			internal float _0024_0024wait_sec_0024temp_00242659_002422069;

			internal RespFriend _0024curRespFriend_002422070;

			internal long _0024index_002422071;

			internal MStories _0024story_002422072;

			internal RespFriendPoppet _0024friendPoppet_002422073;

			internal string _0024s_002422074;

			internal MStories _0024ms_002422075;

			internal int _0024_002411787_002422076;

			internal MStories[] _0024_002411788_002422077;

			internal int _0024_002411789_002422078;

			internal WorldChallengeMain _0024self__002422079;

			public _0024(WorldChallengeMain self_)
			{
				_0024self__002422079 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (!_0024self__002422079.IsChangingSituation && _0024self__002422079.mode != WORLD_CHALLENGE_MODE.StartQuest)
						{
							if (_0024self__002422079.curQuest == null)
							{
								_0024self__002422079.NoChallengeQuest();
							}
							else
							{
								_0024ud_002422068 = UserData.Current;
								if (_0024ud_002422068 != null)
								{
									ApRpExp.MoveMSec = 300;
									ApRpExp.ApParam = _0024ud_002422068.Ap - _0024self__002422079.curQuest.ApCost;
									ApRpExp.RpParam = _0024ud_002422068.Rp - _0024self__002422079.curQuest.RpCost * costRate;
									goto case 2;
								}
							}
						}
						goto case 1;
					case 2:
						if (ApRpExp.MoveMSec > 0)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024_0024wait_sec_0024temp_00242659_002422069 = 0.5f;
						goto case 3;
					case 3:
						if (_0024_0024wait_sec_0024temp_00242659_002422069 > 0f)
						{
							_0024_0024wait_sec_0024temp_00242659_002422069 -= Time.deltaTime;
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						_0024self__002422079.mode = WORLD_CHALLENGE_MODE.StartQuest;
						_0024self__002422079.questManager.CurQuest = _0024self__002422079.curQuest;
						_0024self__002422079.questManager.CurPoppet = _0024self__002422079.curPet;
						_0024self__002422079.questManager.CurFrPoppet = _0024self__002422079.curFrPet;
						_0024self__002422079.questManager.CurWeapon = _0024self__002422079.curWeapon;
						_0024curRespFriend_002422070 = null;
						if (_0024self__002422079.curFrPet != null)
						{
							_0024index_002422071 = _0024self__002422079.curFrPet.Id.Value;
							if (QuestMenuBase.respFriends != null && 0L <= _0024index_002422071 && _0024index_002422071 < (long)QuestMenuBase.respFriends.Length)
							{
								RespFriend[] respFriends = QuestMenuBase.respFriends;
								_0024curRespFriend_002422070 = respFriends[RuntimeServices.NormalizeArrayIndex(respFriends, (int)_0024index_002422071)];
							}
						}
						_0024story_002422072 = _0024self__002422079.findStory(_0024self__002422079.curQuest);
						if (_0024ud_002422068 != null && _0024self__002422079.curQuest != null && !_0024ud_002422068.userMiscInfo.questData.isPlay(_0024self__002422079.curQuest.Id))
						{
							_0024ud_002422068.userMiscInfo.questData.play(_0024self__002422079.curQuest.Id);
						}
						if (_0024story_002422072 != null && _0024curRespFriend_002422070 != null)
						{
							_0024friendPoppet_002422073 = new RespFriendPoppet(_0024curRespFriend_002422070);
							QuestSession.StartQuest(_0024story_002422072.Id, _0024friendPoppet_002422073, costRate, noSceneLoad: false);
							_0024self__002422079.questManager.StartQuest = true;
							_0024self__002422079.curQuest = null;
							_0024self__002422079.curFrPet = null;
							YieldDefault(1);
							goto case 1;
						}
						if (_0024story_002422072 == null)
						{
							_0024s_002422074 = "全ストーリー:\n";
							_0024_002411787_002422076 = 0;
							_0024_002411788_002422077 = MStories.All;
							for (_0024_002411789_002422078 = _0024_002411788_002422077.Length; _0024_002411787_002422076 < _0024_002411789_002422078; _0024_002411787_002422076++)
							{
								_0024s_002422074 += new StringBuilder().Append(_0024_002411788_002422077[_0024_002411787_002422076]).Append("\n").ToString();
							}
							throw new Exception(new StringBuilder("ストーリーがない, MStroy に追加してください... ").Append(_0024self__002422079.curQuest).ToString());
						}
						if (_0024curRespFriend_002422070 == null)
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

		internal WorldChallengeMain _0024self__002422080;

		public _0024StartQuestCore_002422067(WorldChallengeMain self_)
		{
			_0024self__002422080 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002422080);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024Initialize_0024closure_00245129_002422081 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024count_002422082;

			internal UserData _0024ud_002422083;

			internal WorldChallengeMain _0024self__002422084;

			public _0024(WorldChallengeMain self_)
			{
				_0024self__002422084 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (MerlinServer.Instance.IsBusy)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024count_002422082 = 0;
					_0024self__002422084.mode = WORLD_CHALLENGE_MODE.Challenge;
					_0024self__002422084.lastMode = WORLD_CHALLENGE_MODE.None;
					_0024ud_002422083 = UserData.Current;
					if (_0024ud_002422083 == null)
					{
						throw new AssertionFailedException("ud != null");
					}
					if (_0024ud_002422083.IsValidDeck2)
					{
						_0024self__002422084.curWeapon = _0024ud_002422083.ActiveWeapon;
					}
					else
					{
						_0024self__002422084.curWeapon = _0024ud_002422083.MainWeapon;
					}
					_0024self__002422084.curPet = _0024ud_002422083.CurrentPoppetNewOrOldDeck;
					_0024self__002422084.curFrPet = null;
					if (SceneChanger.LastSceneName == "Ui_MyHomeEquip" && !BattleHUDShortcut.IsSceneFromShortcut)
					{
						_0024self__002422084.questManager.CurWeapon = _0024self__002422084.curWeapon;
						_0024self__002422084.questManager.CurPoppet = _0024self__002422084.curPet;
						_0024self__002422084.mode = WORLD_CHALLENGE_MODE.ConfChallenge;
						_0024self__002422084.lastMode = WORLD_CHALLENGE_MODE.None;
						_0024self__002422084.curQuest = _0024self__002422084.questManager.CurQuest;
						_0024self__002422084.curFrPet = _0024self__002422084.questManager.CurFrPoppet;
						DeckSelector.selFrMapet(_0024self__002422084.curFrPet, _0024self__002422084.curFrPet != null && _0024self__002422084.curFrPet.IsFriend);
					}
					DeckSelector.UpdateEquip();
					_0024self__002422084.rankQuests = _0024self__002422084.questManager.GetChallengeRankQuests();
					_0024self__002422084.debugForceRankSelect = false;
					if (_0024self__002422084.debugForceRankSelect)
					{
						if (_0024self__002422084.rankQuests[1] == null)
						{
							_0024self__002422084.rankQuests[1] = _0024self__002422084.rankQuests[0];
						}
						if (_0024self__002422084.rankQuests[2] == null)
						{
							_0024self__002422084.rankQuests[2] = _0024self__002422084.rankQuests[0];
						}
					}
					if (!_0024self__002422084.isRank3)
					{
						_0024self__002422084.curQuest = _0024self__002422084.rankQuests[0];
					}
					if (!_0024self__002422084.debugFlag)
					{
						_0024self__002422084.debugFlag = false;
						if (null == _0024self__002422084.rankQuests)
						{
							_0024self__002422084.NoChallengeQuest();
							goto case 1;
						}
					}
					_0024self__002422084.pointLabel.text = "-------";
					_0024self__002422084.rankingLabel.text = MTexts.Msg("$WS_CHALLENGE_NO_RANK");
					if (_0024ud_002422083.userChallengeInfo.challengRanking != null)
					{
						_0024self__002422084.pointLabel.text = UIBasicUtility.SafeFormat(_0024self__002422084.pointString, _0024ud_002422083.userChallengeInfo.challengRanking.RankingPoint);
						_0024self__002422084.rankingLabel.text = UIBasicUtility.SafeFormat(_0024self__002422084.rankingString, _0024ud_002422083.userChallengeInfo.challengRanking.Ranking);
					}
					_0024self__002422084.SetQuestInfomation(_0024self__002422084.curQuest);
					UIAutoTweenerStandAloneEx.Hide(_0024self__002422084.challengeBanner);
					UIAutoTweenerStandAloneEx.Hide(_0024self__002422084.dropItemlist);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal WorldChallengeMain _0024self__002422085;

		public _0024_0024Initialize_0024closure_00245129_002422081(WorldChallengeMain self_)
		{
			_0024self__002422085 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002422085);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024InitializeHelpPlayer_0024closure_00245130_002422086 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ApiHomeSlim _0024reqHomeSlim_002422087;

			internal ApiFriendPlayerSearch _0024reqFr_002422088;

			internal _0024_0024InitializeHelpPlayer_0024closure_00245130_0024locals_002414552 _0024_0024locals_002422089;

			internal WorldChallengeMain _0024self__002422090;

			public _0024(WorldChallengeMain self_)
			{
				_0024self__002422090 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002422089 = new _0024_0024InitializeHelpPlayer_0024closure_00245130_0024locals_002414552();
					_0024_0024locals_002422089._0024flag = false;
					_0024reqHomeSlim_002422087 = new ApiHomeSlim();
					_0024reqHomeSlim_002422087.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
					{
						SceneChanger.Change("Ui_World");
					});
					MerlinServer.Request(_0024reqHomeSlim_002422087, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024_0024InitializeHelpPlayer_0024closure_00245130_0024closure_00245132(_0024_0024locals_002422089).Invoke));
					goto case 2;
				case 2:
					if (!_0024_0024locals_002422089._0024flag)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024reqFr_002422088 = new ApiFriendPlayerSearch();
					_0024reqFr_002422088.IsRecommend = true;
					_0024reqFr_002422088.Num = MGameParameters.findByGameParameterId(51).Param;
					_0024reqFr_002422088.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
					{
						SceneChanger.Change("Ui_World");
						QuestMenuBase.respFriends = null;
					});
					MerlinServer.Request(_0024reqFr_002422088, _0024adaptor_0024__MessageBoard_PushFriendSearch_0024callable145_0024918_13___0024__MerlinServer_Request_0024callable86_0024160_56___0024212.Adapt(_0024self__002422090.CallBackHelpPlayer));
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal WorldChallengeMain _0024self__002422091;

		public _0024_0024InitializeHelpPlayer_0024closure_00245130_002422086(WorldChallengeMain self_)
		{
			_0024self__002422091 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002422091);
		}
	}

	private WORLD_CHALLENGE_MODE mode;

	private WORLD_CHALLENGE_MODE lastMode;

	private WORLD_CHALLENGE_SUB_MODE subMode;

	private WORLD_CHALLENGE_SUB_MODE lastSubMode;

	public GameObject challengeBanner;

	public UILabelBase dateLabel;

	protected string dateString;

	public UILabelBase limitLabel;

	protected string limitString;

	protected int lastLimitSec;

	public UILabelBase pointLabel;

	public string pointString;

	public UILabelBase rankingLabel;

	protected string rankingString;

	public UILabelBase costStoneLabel;

	public UILabelBase cost1TimeStoneLabel;

	public UILabelBase cost3TimesStoneLabel;

	protected string costStoneString;

	public UIButtonMessage start1TimeButton;

	public UIButtonMessage start3TimesButton;

	protected WebView curWebView;

	protected bool errorEnd;

	[NonSerialized]
	protected static int costRate = 1;

	public GameObject costConfPanel;

	protected bool costConfPanelFlag;

	public GameObject rankConfPanel;

	protected bool rankConfPanelFlag;

	protected MQuests[] rankQuests;

	protected int curRank;

	public bool enableRankSelect;

	public bool debugFlag;

	public bool debugForceRankSelect;

	private bool isRank3
	{
		get
		{
			int result;
			if (!enableRankSelect)
			{
				result = 0;
			}
			else if (null == rankQuests)
			{
				result = 0;
			}
			else if (3 != rankQuests.Length)
			{
				result = 0;
			}
			else
			{
				int num = 0;
				int num2 = 0;
				while (num2 < 3)
				{
					int index = num2;
					num2++;
					MQuests[] array = rankQuests;
					MQuests mQuests = array[RuntimeServices.NormalizeArrayIndex(array, index)];
					if (mQuests != null)
					{
						num = checked(num + 1);
					}
				}
				result = ((num == 3) ? 1 : 0);
			}
			return (byte)result != 0;
		}
	}

	public WORLD_CHALLENGE_MODE Mode => mode;

	public WorldChallengeMain()
	{
		lastLimitSec = -1;
		pointString = " {0}";
		rankingString = string.Empty;
		costStoneString = string.Empty;
	}

	public override void SceneStart()
	{
		dateString = MTexts.Msg("$WS_CHALLENGE_TERM");
		limitString = MTexts.Msg("$WS_CHALLENGE_LIMIT");
		rankingString = " " + MTexts.Msg("exp_rank");
		costStoneString = MTexts.Msg("$WS_CHALLENGE_COST");
		RuntimeAssetBundleDB.Instance.instantiatePrefab("ZPatch001ChallengeMenu");
		ResetRespFriends();
		InitDetail();
		UIAutoTweenerStandAloneEx.Hide(costConfPanel);
		costConfPanelFlag = false;
		UIAutoTweenerStandAloneEx.Hide(rankConfPanel);
		rankConfPanelFlag = false;
		questManager = QuestManager.Instance;
		dlgMan = DialogManager.Instance;
		if ((bool)selFrPetButton)
		{
			selFrPetButtonValidCtrl = ExtensionsModule.SetComponent<UIValidController>(selFrPetButton.gameObject);
		}
		if ((bool)confQuestButton)
		{
			confQuestButtonValidCtrl = ExtensionsModule.SetComponent<UIValidController>(confQuestButton.gameObject);
		}
		if ((bool)detailButton)
		{
			detailButtonValidCtrl = ExtensionsModule.SetComponent<UIValidController>(detailButton.gameObject);
		}
		if ((bool)mapetList)
		{
			mapetList.hookSettingListItem = base.hookFriendListSettingItem;
			mapetList.hookSelectItem = base.hookFriendListSelect;
			if ((bool)mapetList.sortButton)
			{
				mapetList.sortButton.CheckCloseFunc = () => mode != WORLD_CHALLENGE_MODE.SelectPet;
			}
		}
		DeckSelector.deselect();
		curArea = questManager.curArea;
		mode = WORLD_CHALLENGE_MODE.None;
		lastMode = WORLD_CHALLENGE_MODE.None;
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
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024InitializeHelpPlayer_0024closure_00245130_002422086(this).GetEnumerator();
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
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
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024Initialize_0024closure_00245129_002422081(this).GetEnumerator();
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void NoChallengeQuest()
	{
		if (!questManager.StartQuest && !errorEnd)
		{
			errorEnd = true;
			ErrorDialog.FatalError(MTexts.Msg("$WS_NO_CHALLENGE"), string.Empty, jumpBoot: false, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38___00242.Adapt(delegate
			{
				SceneChanger.ChangeTo(SceneID.Ui_World);
			}));
		}
	}

	public void SetQuestInfomation(MQuests quest)
	{
		SetQuestDate(quest);
		UpdateTreasureIcon(quest);
		UpdateMonsterList(quest);
	}

	public void SetCostInfomation(MQuests quest)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		if (quest == null)
		{
			if (debugFlag)
			{
				if ((bool)cost1TimeStoneLabel)
				{
					cost1TimeStoneLabel.text = UIBasicUtility.SafeFormat(costStoneString, 0);
				}
				if ((bool)cost3TimesStoneLabel)
				{
					cost3TimesStoneLabel.text = UIBasicUtility.SafeFormat(costStoneString, 0);
				}
			}
			return;
		}
		if ((bool)cost1TimeStoneLabel)
		{
			cost1TimeStoneLabel.text = UIBasicUtility.SafeFormat(costStoneString, quest.RpCost);
		}
		checked
		{
			if ((bool)cost3TimesStoneLabel)
			{
				cost3TimesStoneLabel.text = UIBasicUtility.SafeFormat(costStoneString, quest.RpCost * 3);
			}
			bool isValidColor = current.Rp >= quest.RpCost;
			bool isValidColor2 = current.Rp >= quest.RpCost * 3;
			UIValidController uIValidController = default(UIValidController);
			if ((bool)start1TimeButton)
			{
				uIValidController = ExtensionsModule.SetComponent<UIValidController>(start1TimeButton.gameObject);
			}
			UIValidController uIValidController2 = default(UIValidController);
			if ((bool)start3TimesButton)
			{
				uIValidController2 = ExtensionsModule.SetComponent<UIValidController>(start3TimesButton.gameObject);
			}
			if ((bool)start1TimeButton)
			{
				uIValidController.isValidColor = isValidColor;
			}
			if ((bool)start3TimesButton)
			{
				uIValidController2.isValidColor = isValidColor2;
			}
		}
	}

	public void SetQuestDate(MQuests quest)
	{
		if (quest == null)
		{
			return;
		}
		DateTime utcNow = MerlinDateTime.UtcNow;
		if (lastLimitSec != utcNow.Second)
		{
			lastLimitSec = utcNow.Second;
			DateTime beginDate = quest.BeginDate;
			DateTime endDate = quest.EndDate;
			TimeSpan timeSpan = endDate - utcNow;
			MWeek mWeek = MWeek.Get((int)(beginDate.DayOfWeek + 1));
			MWeek mWeek2 = MWeek.Get((int)(endDate.DayOfWeek + 1));
			string text = string.Empty;
			string text2 = string.Empty;
			MTexts mTexts = default(MTexts);
			if (mWeek != null)
			{
				mTexts = MTexts.Get(mWeek.Name);
			}
			MTexts mTexts2 = default(MTexts);
			if (mWeek2 != null)
			{
				mTexts2 = MTexts.Get(mWeek2.Name);
			}
			if (mTexts != null)
			{
				text = mTexts.msg;
			}
			if (mTexts2 != null)
			{
				text2 = mTexts2.msg;
			}
			dateLabel.text = UIBasicUtility.SafeFormat(dateString, beginDate.Month, beginDate.Day, text, beginDate.Hour, beginDate.Minute, endDate.Month, endDate.Day, text2, endDate.Hour, endDate.Minute);
			limitLabel.text = UIBasicUtility.SafeFormat(limitString, checked((int)timeSpan.TotalHours), timeSpan.Minutes, timeSpan.Seconds);
		}
	}

	public override void SceneUpdate()
	{
		_0024SceneUpdate_0024locals_002414551 _0024SceneUpdate_0024locals_0024 = new _0024SceneUpdate_0024locals_002414551();
		if (!SceneChanger.isCompletelyReady || InventoryOverDialog.IsOpenInventoryOverDialog() || IsChangingSituation)
		{
			return;
		}
		if (stoneList.IsDialogUpdating(this))
		{
			if ((bool)curWebView)
			{
				curWebView.gameObject.SetActive(value: false);
			}
			return;
		}
		if (mode != lastMode)
		{
			if (!debugFlag)
			{
				if (!isRank3)
				{
					if (curQuest == null)
					{
						NoChallengeQuest();
						return;
					}
				}
				else if (null == rankQuests)
				{
					NoChallengeQuest();
					return;
				}
			}
			if ((bool)curWebView)
			{
				curWebView.Clear();
			}
			curWebView = null;
			lastMode = mode;
			bool flag = true;
			if (DialogManager.DialogCount > 0)
			{
				flag = false;
			}
			ChangeSituation(GetSituation((int)mode));
			if (mode == WORLD_CHALLENGE_MODE.Challenge)
			{
				UIAutoTweenerStandAloneEx.Hide(challengeBanner);
				curWebView = GetSituation((int)mode).gameObject.GetComponentsInChildren<WebView>(includeInactive: true).FirstOrDefault();
				curWebView.Clear();
				curWebView.gameObject.SetActive(flag);
				subMode = WORLD_CHALLENGE_SUB_MODE.Banner;
				_0024SceneUpdate_0024locals_0024._0024apiWebChallangeBanner = new ApiWebChallengeBanner();
				MerlinServer.Request(_0024SceneUpdate_0024locals_0024._0024apiWebChallangeBanner, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024SceneUpdate_0024closure_00245135(_0024SceneUpdate_0024locals_0024, this).Invoke));
			}
			else if (mode == WORLD_CHALLENGE_MODE.ChallengeDetail)
			{
				curWebView = GetSituation((int)mode).gameObject.GetComponentsInChildren<WebView>(includeInactive: true).FirstOrDefault();
				curWebView.Clear();
				curWebView.gameObject.SetActive(flag);
				_0024SceneUpdate_0024locals_0024._0024apiWebChallangeDetail = new ApiWebChallengeDetail();
				MerlinServer.Request(_0024SceneUpdate_0024locals_0024._0024apiWebChallangeDetail, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024SceneUpdate_0024closure_00245136(this, _0024SceneUpdate_0024locals_0024).Invoke));
			}
			else if (mode == WORLD_CHALLENGE_MODE.Ranking)
			{
				curWebView = GetSituation((int)mode).gameObject.GetComponentsInChildren<WebView>(includeInactive: true).FirstOrDefault();
				curWebView.Clear();
				curWebView.gameObject.SetActive(flag);
				_0024SceneUpdate_0024locals_0024._0024apiWebRanking = new ApiWebRanking();
				MerlinServer.Request(_0024SceneUpdate_0024locals_0024._0024apiWebRanking, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024SceneUpdate_0024closure_00245137(_0024SceneUpdate_0024locals_0024, this).Invoke));
			}
			else if (mode == WORLD_CHALLENGE_MODE.SelectPet)
			{
				UIAutoTweenerStandAloneEx.Out(challengeBanner);
				UIAutoTweenerStandAloneEx.Out(dropItemlist);
				UIAutoTweenerStandAloneEx.Out(costConfPanel);
				UIAutoTweenerStandAloneEx.Out(rankConfPanel);
				InitFriendPetList();
			}
			else if (mode == WORLD_CHALLENGE_MODE.ConfChallenge)
			{
				if (!debugFlag && curQuest == null)
				{
					NoChallengeQuest();
					return;
				}
				if (null != costStoneLabel && curQuest != null)
				{
					costStoneLabel.text = UIBasicUtility.SafeFormat(costStoneString, checked(curQuest.RpCost * costRate));
				}
				DeckSelector.selFrMapet(curFrPet, curFrPet != null && curFrPet.IsFriend);
				DeckSelector.UpdateEquip();
				bool flag2 = false;
				if (null != missionList)
				{
					flag2 = missionList.SetQuest(curQuest, MissionList.ListType.Normal);
				}
				if (null != missionButton)
				{
					missionButton.gameObject.SetActive(flag2);
				}
			}
			else if (mode != WORLD_CHALLENGE_MODE.Detail && mode != WORLD_CHALLENGE_MODE.StartQuest)
			{
				if (mode == WORLD_CHALLENGE_MODE.CostConf)
				{
					SetCostInfomation(curQuest);
					costConfPanelFlag = false;
					UIAutoTweenerStandAloneEx.In(costConfPanel, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024172.Adapt(delegate
					{
						costConfPanelFlag = true;
					}));
				}
				else if (mode == WORLD_CHALLENGE_MODE.RankConf)
				{
					rankConfPanelFlag = false;
					UIAutoTweenerStandAloneEx.In(rankConfPanel, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024172.Adapt(delegate
					{
						rankConfPanelFlag = true;
					}));
				}
			}
		}
		if (mode == WORLD_CHALLENGE_MODE.Challenge)
		{
			SetQuestDate(curQuest);
			if (subMode != lastSubMode)
			{
				lastSubMode = subMode;
				if (subMode == WORLD_CHALLENGE_SUB_MODE.Banner)
				{
					UIAutoTweenerStandAloneEx.In(challengeBanner);
					if (dropItemlist.active)
					{
						UIAutoTweenerStandAloneEx.Out(dropItemlist);
					}
				}
				else if (subMode == WORLD_CHALLENGE_SUB_MODE.DropItem)
				{
					if (challengeBanner.active)
					{
						UIAutoTweenerStandAloneEx.Out(challengeBanner);
					}
					UIAutoTweenerStandAloneEx.In(dropItemlist);
				}
			}
			if (subMode != 0 && subMode == WORLD_CHALLENGE_SUB_MODE.DropItem && WebViewBase.GetNextUrl() == "Back")
			{
				subMode = WORLD_CHALLENGE_SUB_MODE.None;
			}
		}
		else if (mode == WORLD_CHALLENGE_MODE.ChallengeDetail)
		{
			if (WebViewBase.GetNextUrl() == "Back")
			{
				mode = WORLD_CHALLENGE_MODE.Challenge;
			}
		}
		else if (mode == WORLD_CHALLENGE_MODE.Ranking)
		{
			if (WebViewBase.GetNextUrl() == "Back")
			{
				mode = WORLD_CHALLENGE_MODE.Challenge;
			}
		}
		else if (mode == WORLD_CHALLENGE_MODE.SelectPet)
		{
			FriendPetListCtrl();
		}
		else if (mode == WORLD_CHALLENGE_MODE.ConfChallenge)
		{
			ConfQuestCtrl();
		}
	}

	public virtual IEnumerator StartQuestCore()
	{
		return new _0024StartQuestCore_002422067(this).GetEnumerator();
	}

	public MStories findStory(MQuests q)
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

	public override void SelectPet()
	{
		if (!IsChangingSituation && mode == WORLD_CHALLENGE_MODE.SelectPet && curFrPet != null)
		{
			DeckSelector.selFrMapet(curFrPet, curFrPet != null && curFrPet.IsFriend);
			mode = WORLD_CHALLENGE_MODE.ConfChallenge;
			questManager.CurQuest = curQuest;
			questManager.CurPoppet = curPet;
			questManager.CurFrPoppet = curFrPet;
			questManager.CurWeapon = curWeapon;
		}
	}

	public virtual void GotoMyhome(MyHomeEquipMain.MY_HOME_EQUIP_START_MODE startMode)
	{
		if (mode == WORLD_CHALLENGE_MODE.ConfChallenge)
		{
			MyHomeEquipMain.BackScene = "Ui_WorldChallenge";
			MyHomeEquipMain.StartMode = startMode;
			MyHomeEquipMain.BgSpriteName = "map";
			ChangeSceneLikeQuestSubScene(SceneID.Ui_MyHomeEquip);
		}
	}

	public void PushSort(string key)
	{
		if (!IsChangingSituation && mode == WORLD_CHALLENGE_MODE.SelectPet)
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
		if (mode == WORLD_CHALLENGE_MODE.SelectPet)
		{
			if (curFrPet != null && !(null == detailPoppetInfo) && !detailPoppetInfo.active)
			{
				detailPoppetInfo.SetMuppet(curFrPet, ignoreUnknown: true);
				UIAutoTweenerStandAloneEx.In(detailPoppetInfo.gameObject);
				mode = WORLD_CHALLENGE_MODE.Detail;
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
					mode = WORLD_CHALLENGE_MODE.MissionDetail;
				}
			}
			else if (null != componentInChildren2 && componentInChildren2.weaponInfo != null && !(null == detailWeaponInfo) && !detailWeaponInfo.active)
			{
				detailWeaponInfo.SetWeapon(componentInChildren2.weaponInfo, ignoreUnknown: true);
				UIAutoTweenerStandAloneEx.In(detailWeaponInfo.gameObject);
				mode = WORLD_CHALLENGE_MODE.MissionDetail;
			}
		}
	}

	public void PushStart()
	{
		UIAutoTweenerStandAloneEx.Hide(challengeBanner);
		UIAutoTweenerStandAloneEx.Hide(dropItemlist);
		if (!isRank3)
		{
			SetCostInfomation(curQuest);
			mode = WORLD_CHALLENGE_MODE.CostConf;
		}
		else
		{
			mode = WORLD_CHALLENGE_MODE.RankConf;
		}
	}

	public void PushStartCost1Time()
	{
		PushStartCore(1);
	}

	public void PushStartCost3Times()
	{
		PushStartCore(3);
	}

	public void PushStartCore(int useCostRate)
	{
		if (IsChangingSituation || stoneListBusy)
		{
			return;
		}
		UserData current = UserData.Current;
		if (current == null || null == costConfPanel || mode != WORLD_CHALLENGE_MODE.CostConf || (!debugFlag && curQuest == null))
		{
			return;
		}
		bool flag = current.Rp == 0;
		costRate = useCostRate;
		if (curQuest != null)
		{
			flag = current.Rp < checked(curQuest.RpCost * costRate);
		}
		if (flag)
		{
			stoneListBusy = true;
			UIAutoTweenerStandAloneEx.Out(costConfPanel, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024172.Adapt(delegate
			{
				stoneList.ShowCureRpDialog();
				stoneList.OnEnd = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34___0024211.Adapt(delegate
				{
					stoneListBusy = false;
					lastMode = WORLD_CHALLENGE_MODE.None;
					UIAutoTweenerStandAloneEx.Hide(challengeBanner);
					UIAutoTweenerStandAloneEx.Hide(dropItemlist);
					UIAutoTweenerStandAloneEx.Hide(costConfPanel);
					UIAutoTweenerStandAloneEx.Hide(rankConfPanel);
				});
			}));
		}
		else
		{
			costConfPanelFlag = false;
			mode = WORLD_CHALLENGE_MODE.SelectPet;
		}
	}

	public void PushRank1()
	{
		PushRankCore(0);
	}

	public void PushRank2()
	{
		PushRankCore(1);
	}

	public void PushRank3()
	{
		PushRankCore(2);
	}

	public void PushRankCore(int rank)
	{
		if (IsChangingSituation || stoneListBusy)
		{
			return;
		}
		UserData current = UserData.Current;
		if (current == null || null == rankConfPanel || mode != WORLD_CHALLENGE_MODE.RankConf)
		{
			return;
		}
		curRank = rank;
		MQuests[] array = rankQuests;
		curQuest = array[RuntimeServices.NormalizeArrayIndex(array, curRank)];
		if (!debugFlag)
		{
			if (curQuest == null)
			{
				curRank = 0;
				MQuests[] array2 = rankQuests;
				curQuest = array2[RuntimeServices.NormalizeArrayIndex(array2, curRank)];
			}
			debugFlag = false;
			if (curQuest == null)
			{
				NoChallengeQuest();
				return;
			}
		}
		UIAutoTweenerStandAloneEx.Hide(challengeBanner);
		UIAutoTweenerStandAloneEx.Hide(dropItemlist);
		UIAutoTweenerStandAloneEx.Hide(rankConfPanel);
		SetCostInfomation(curQuest);
		mode = WORLD_CHALLENGE_MODE.CostConf;
	}

	public void PushHoge()
	{
		if (!IsChangingSituation && !stoneListBusy)
		{
			mode = WORLD_CHALLENGE_MODE.ConfChallenge;
		}
	}

	public void PushDropItemList()
	{
		if (!IsChangingSituation && !stoneListBusy && mode == WORLD_CHALLENGE_MODE.Challenge)
		{
			if (subMode == WORLD_CHALLENGE_SUB_MODE.DropItem)
			{
				subMode = WORLD_CHALLENGE_SUB_MODE.Banner;
			}
			else
			{
				subMode = WORLD_CHALLENGE_SUB_MODE.DropItem;
			}
		}
	}

	public void PushChallengeDetail()
	{
		if (!IsChangingSituation && !stoneListBusy)
		{
			mode = WORLD_CHALLENGE_MODE.ChallengeDetail;
		}
	}

	public void PushRanking()
	{
		if (!IsChangingSituation && !stoneListBusy)
		{
			mode = WORLD_CHALLENGE_MODE.Ranking;
		}
	}

	public void PushCureYesMP()
	{
	}

	public void PushMission(GameObject obj)
	{
		if (!IsChangingSituation)
		{
			mode = WORLD_CHALLENGE_MODE.Mission;
		}
	}

	public void PushBack()
	{
		if (IsChangingSituation)
		{
			return;
		}
		if (CurrentSituation == stoneList.Situation)
		{
			stoneList.PushCancel();
		}
		else if (mode == WORLD_CHALLENGE_MODE.Challenge)
		{
			UIAutoTweenerStandAloneEx.Out(challengeBanner);
			UIAutoTweenerStandAloneEx.Out(dropItemlist);
			SceneChanger.ChangeTo(SceneID.Ui_World);
			QuestMenuBase.respFriends = null;
		}
		else if (mode == WORLD_CHALLENGE_MODE.ChallengeDetail)
		{
			mode = WORLD_CHALLENGE_MODE.Challenge;
		}
		else if (mode == WORLD_CHALLENGE_MODE.Ranking)
		{
			mode = WORLD_CHALLENGE_MODE.Challenge;
		}
		else if (mode == WORLD_CHALLENGE_MODE.SelectPet)
		{
			mode = WORLD_CHALLENGE_MODE.Challenge;
		}
		else if (mode == WORLD_CHALLENGE_MODE.ConfChallenge)
		{
			if (IsShowConfQuestSupportDialog)
			{
				ConfQuest.ShowSupportDialog(aValid: false);
			}
			else if (!DeckSelector.isSwipe)
			{
				confQuest.Close();
				mode = WORLD_CHALLENGE_MODE.SelectPet;
			}
		}
		else if (mode == WORLD_CHALLENGE_MODE.Detail)
		{
			mode = WORLD_CHALLENGE_MODE.SelectPet;
			if (detailWeaponInfo.gameObject.active)
			{
				UIAutoTweenerStandAloneEx.Out(detailWeaponInfo.gameObject);
			}
			if (detailPoppetInfo.gameObject.active)
			{
				UIAutoTweenerStandAloneEx.Out(detailPoppetInfo.gameObject);
			}
		}
		else if (mode == WORLD_CHALLENGE_MODE.CostConf)
		{
			if (costConfPanelFlag)
			{
				UIAutoTweenerStandAloneEx.Out(costConfPanel, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024172.Adapt(delegate
				{
					mode = WORLD_CHALLENGE_MODE.Challenge;
					costConfPanelFlag = false;
				}));
			}
		}
		else if (mode == WORLD_CHALLENGE_MODE.RankConf)
		{
			if (rankConfPanelFlag)
			{
				UIAutoTweenerStandAloneEx.Out(rankConfPanel, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024172.Adapt(delegate
				{
					mode = WORLD_CHALLENGE_MODE.Challenge;
					rankConfPanelFlag = false;
				}));
			}
		}
		else if (mode == WORLD_CHALLENGE_MODE.Mission)
		{
			mode = WORLD_CHALLENGE_MODE.ConfChallenge;
		}
		else if (mode == WORLD_CHALLENGE_MODE.MissionDetail)
		{
			mode = WORLD_CHALLENGE_MODE.Mission;
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

	internal bool _0024SceneStart_0024closure_00245127()
	{
		return mode != WORLD_CHALLENGE_MODE.SelectPet;
	}

	internal void _0024SceneStart_0024closure_00245128()
	{
		DeckSelector.Init(UserData.Current.userDeckData2.CurrentDeck, UserData.Current.userDeckData2.deckNum());
		InitializeHelpPlayer();
		if ((bool)stoneList)
		{
			stoneList.Download();
		}
	}

	internal IEnumerator _0024Initialize_0024closure_00245129()
	{
		return new _0024_0024Initialize_0024closure_00245129_002422081(this).GetEnumerator();
	}

	internal IEnumerator _0024InitializeHelpPlayer_0024closure_00245130()
	{
		return new _0024_0024InitializeHelpPlayer_0024closure_00245130_002422086(this).GetEnumerator();
	}

	internal void _0024_0024InitializeHelpPlayer_0024closure_00245130_0024closure_00245131()
	{
		SceneChanger.Change("Ui_World");
	}

	internal void _0024_0024InitializeHelpPlayer_0024closure_00245130_0024closure_00245133()
	{
		SceneChanger.Change("Ui_World");
		QuestMenuBase.respFriends = null;
	}

	internal void _0024NoChallengeQuest_0024closure_00245134()
	{
		SceneChanger.ChangeTo(SceneID.Ui_World);
	}

	internal void _0024SceneUpdate_0024closure_00245138()
	{
		costConfPanelFlag = true;
	}

	internal void _0024SceneUpdate_0024closure_00245139()
	{
		rankConfPanelFlag = true;
	}

	internal void _0024PushStartCore_0024closure_00245140()
	{
		stoneList.ShowCureRpDialog();
		stoneList.OnEnd = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34___0024211.Adapt(delegate
		{
			stoneListBusy = false;
			lastMode = WORLD_CHALLENGE_MODE.None;
			UIAutoTweenerStandAloneEx.Hide(challengeBanner);
			UIAutoTweenerStandAloneEx.Hide(dropItemlist);
			UIAutoTweenerStandAloneEx.Hide(costConfPanel);
			UIAutoTweenerStandAloneEx.Hide(rankConfPanel);
		});
	}

	internal void _0024_0024PushStartCore_0024closure_00245140_0024closure_00245141()
	{
		stoneListBusy = false;
		lastMode = WORLD_CHALLENGE_MODE.None;
		UIAutoTweenerStandAloneEx.Hide(challengeBanner);
		UIAutoTweenerStandAloneEx.Hide(dropItemlist);
		UIAutoTweenerStandAloneEx.Hide(costConfPanel);
		UIAutoTweenerStandAloneEx.Hide(rankConfPanel);
	}

	internal void _0024PushBack_0024closure_00245142()
	{
		mode = WORLD_CHALLENGE_MODE.Challenge;
		costConfPanelFlag = false;
	}

	internal void _0024PushBack_0024closure_00245143()
	{
		mode = WORLD_CHALLENGE_MODE.Challenge;
		rankConfPanelFlag = false;
	}
}
