using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class QuestSession
{
	[Serializable]
	public enum EState
	{
		UnInitialized,
		Starting,
		Started,
		Closing,
		Closed
	}

	[Serializable]
	public class StartSessionForDebug
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024main_002418947 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal QuestSessionParameters _0024prm_002418948;

				internal ApiFriendPlayerSearch _0024_00243320_002418949;

				internal ApiFriendPlayerSearch _0024freq_002418950;

				internal ApiQuestStart _0024request_002418951;

				internal ApiFriendPlayerSearch.Resp _0024resp_002418952;

				internal RespFriend[] _0024friends_002418953;

				internal StartSessionForDebug _0024self__002418954;

				public _0024(StartSessionForDebug self_)
				{
					_0024self__002418954 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
					{
						if (_0024self__002418954.parameters == null)
						{
							throw new AssertionFailedException("parameters != null");
						}
						_0024prm_002418948 = _0024self__002418954.parameters;
						ApiFriendPlayerSearch apiFriendPlayerSearch = (_0024_00243320_002418949 = new ApiFriendPlayerSearch());
						bool flag = (_0024_00243320_002418949.IsRecommend = true);
						_0024freq_002418950 = _0024_00243320_002418949;
						MerlinServer.Request(_0024freq_002418950);
						goto case 2;
					}
					case 2:
						if (!_0024freq_002418950.IsOk)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024request_002418951 = null;
						if (_0024prm_002418948.WithServer)
						{
							_0024resp_002418952 = _0024freq_002418950.GetResponse();
							if (_0024resp_002418952 == null)
							{
								throw new AssertionFailedException("我が生涯に一片の悔い無し!");
							}
							_0024friends_002418953 = _0024resp_002418952.Friends;
							if (_0024friends_002418953 == null || _0024friends_002418953.Length <= 0)
							{
								throw new AssertionFailedException("お助けフレンドリストが空だ！");
							}
							_0024prm_002418948.helper = new RespFriendPoppet(_0024friends_002418953[0]);
						}
						_0024request_002418951 = StartSession(_0024prm_002418948);
						if (_0024self__002418954.handler != null)
						{
							_0024self__002418954.handler(_0024request_002418951);
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

			internal StartSessionForDebug _0024self__002418955;

			public _0024main_002418947(StartSessionForDebug self_)
			{
				_0024self__002418955 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002418955);
			}
		}

		public ApiQuestStart request;

		private QuestSessionParameters parameters;

		private __QuestSession_StartSessionDebug_0024callable80_00241001_56__ handler;

		public ApiQuestStart Request => request;

		public StartSessionForDebug(MonoBehaviour you, int storyId, bool noSceneLoad, __QuestSession_StartSessionDebug_0024callable80_00241001_56__ handler)
		{
			initParameters(storyId, noSceneLoad, withServer: true, handler);
			you.StartCoroutine(main());
		}

		public StartSessionForDebug(MonoBehaviour you, int storyId, bool noSceneLoad, bool withServer, __QuestSession_StartSessionDebug_0024callable80_00241001_56__ handler)
		{
			initParameters(storyId, noSceneLoad, withServer, handler);
			you.StartCoroutine(main());
		}

		public StartSessionForDebug(MonoBehaviour you, QuestSessionParameters prm)
		{
			if (prm == null)
			{
				throw new AssertionFailedException("prm != null");
			}
			parameters = prm;
			you.StartCoroutine(main());
		}

		private IEnumerator initParameters(int storyId, bool noSceneLoad, bool withServer, __QuestSession_StartSessionDebug_0024callable80_00241001_56__ handler)
		{
			parameters = new QuestSessionParameters();
			parameters.storyId = storyId;
			parameters.noSceneLoad = noSceneLoad;
			parameters.withServer = withServer;
			this.handler = handler;
			return null;
		}

		private IEnumerator main()
		{
			return new _0024main_002418947(this).GetEnumerator();
		}
	}

	[Serializable]
	public class ContinueDataSet
	{
		private QuestSessionParameters prms;

		private QuestSessionData sdata;

		private QuestGeometricSessionData geom;

		private bool isLoaded;

		private bool invalidVersion;

		public bool IsValid
		{
			get
			{
				bool num = prms != null;
				if (num)
				{
					num = sdata != null;
				}
				if (num)
				{
					num = geom != null;
				}
				return num;
			}
		}

		public string QuestProgname => (prms == null) ? null : MStories.Get(prms.StoryId)?.MQuestId?.Progname;

		public QuestSessionParameters Prms => prms;

		public QuestSessionData Sdata => sdata;

		public QuestGeometricSessionData Geom => geom;

		public bool IsLoaded => isLoaded;

		public bool InvalidVersion => invalidVersion;

		public bool load()
		{
			isLoaded = false;
			try
			{
				byte[] array = File.ReadAllBytes(SAVE_FILEPATH);
				byte[] array2 = Crypt.DecryptQuest(array, GetSaveKey());
				if (array2 != null && array2.Length > 0)
				{
					array = array2;
				}
				if (array == null || array.Length <= 0)
				{
					DeleteSaveData();
				}
				else
				{
					QuestSessionDataSerialize questSessionDataSerialize = new QuestSessionDataSerialize();
					int outVersion = 0;
					object[] array3 = questSessionDataSerialize.deserialize(array, ref outVersion);
					object obj = array3[0];
					if (!(obj is QuestSessionParameters))
					{
						obj = RuntimeServices.Coerce(obj, typeof(QuestSessionParameters));
					}
					prms = (QuestSessionParameters)obj;
					object obj2 = array3[1];
					if (!(obj2 is QuestSessionData))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(QuestSessionData));
					}
					sdata = (QuestSessionData)obj2;
					object obj3 = array3[2];
					if (!(obj3 is QuestGeometricSessionData))
					{
						obj3 = RuntimeServices.Coerce(obj3, typeof(QuestGeometricSessionData));
					}
					geom = (QuestGeometricSessionData)obj3;
					if (outVersion <= QuestSessionDataSerialize.INVALID_VERSION)
					{
						invalidVersion = true;
						DeleteSaveData();
					}
					else if (prms == null || sdata == null || geom == null)
					{
						DeleteSaveData();
					}
					else
					{
						isLoaded = true;
					}
				}
			}
			catch (Exception)
			{
				DeleteSaveData();
			}
			return isLoaded;
		}
	}

	[Serializable]
	internal class _0024StartSession_0024locals_002414428
	{
		internal QuestSessionParameters _0024prm;

		internal ApiQuestStart _0024req;
	}

	[Serializable]
	internal class _0024GetActivePoppets_0024locals_002414429
	{
		internal Boo.Lang.List<RespPoppet> _0024ppts;
	}

	[Serializable]
	internal class _0024get_KilledNum_0024locals_002414430
	{
		internal int _0024n;
	}

	[Serializable]
	internal class _0024GetKilledMonsterNum_0024locals_002414431
	{
		internal int _0024n;

		internal int _0024monsterMasterId;
	}

	[Serializable]
	internal class _0024get_AllMonsterNum_0024locals_002414432
	{
		internal int _0024n;
	}

	[Serializable]
	internal class _0024StageBattleMonster_0024locals_002414433
	{
		internal Boo.Lang.List<RespMonster> _0024md;

		internal MStageBattles _0024battle;
	}

	[Serializable]
	internal class _0024IsContainedMonter_0024locals_002414434
	{
		internal RespMonster _0024m;
	}

	[Serializable]
	internal class _0024GotoStage_0024locals_002414435
	{
		internal EnumMapLinkDir _0024dir;
	}

	[Serializable]
	internal class _0024StartSession_0024closure_00243925
	{
		internal _0024StartSession_0024locals_002414428 _0024_0024locals_002414977;

		public _0024StartSession_0024closure_00243925(_0024StartSession_0024locals_002414428 _0024_0024locals_002414977)
		{
			this._0024_0024locals_002414977 = _0024_0024locals_002414977;
		}

		public void Invoke(ApiQuestStart r)
		{
			_Session.setStartResponse(_0024_0024locals_002414977._0024req.GetResponse());
			if (r == null)
			{
				throw new AssertionFailedException("r != null");
			}
			RespQuestStart response = r.GetResponse();
			if (_0024_0024locals_002414977._0024prm.lastDataKey != response.DataKey)
			{
				QuestInitializer.ChangeSceneFromQuest("Boot");
				return;
			}
			_State = EState.Started;
			initMScenesAndSetStartScene(_0024_0024locals_002414977._0024prm);
			SetStageMonsters(Quest, _Session.monsterData);
			PlaceStageDrops(Quest);
			clearAllTFlags();
			MerlinServer.Request(new ApiPlayer());
			InitializeSE();
			NotifyTutorialStepAtStarting(Quest);
		}
	}

	[Serializable]
	internal class _0024GetActivePoppets_0024_add_00243926
	{
		internal _0024GetActivePoppets_0024locals_002414429 _0024_0024locals_002414978;

		public _0024GetActivePoppets_0024_add_00243926(_0024GetActivePoppets_0024locals_002414429 _0024_0024locals_002414978)
		{
			this._0024_0024locals_002414978 = _0024_0024locals_002414978;
		}

		public void Invoke(RespPoppet _ppt)
		{
			if (_ppt != null)
			{
				_0024_0024locals_002414978._0024ppts.Add(_ppt);
			}
		}
	}

	[Serializable]
	internal class _0024CheckMasterAndResponseMonsters_0024closure_00243927
	{
		internal MStageMonsters _0024m_002414979;

		public _0024CheckMasterAndResponseMonsters_0024closure_00243927(MStageMonsters _0024m_002414979)
		{
			this._0024m_002414979 = _0024m_002414979;
		}

		public bool Invoke(RespMonster rm)
		{
			return rm.Id == _0024m_002414979.Id;
		}
	}

	[Serializable]
	internal class _0024get_KilledNum_0024closure_00242990
	{
		internal _0024get_KilledNum_0024locals_002414430 _0024_0024locals_002414980;

		public _0024get_KilledNum_0024closure_00242990(_0024get_KilledNum_0024locals_002414430 _0024_0024locals_002414980)
		{
			this._0024_0024locals_002414980 = _0024_0024locals_002414980;
		}

		public void Invoke(RespMonster m)
		{
			if (m.IsKill)
			{
				_0024_0024locals_002414980._0024n = checked(_0024_0024locals_002414980._0024n + 1);
			}
		}
	}

	[Serializable]
	internal class _0024GetKilledMonsterNum_0024closure_00243928
	{
		internal _0024GetKilledMonsterNum_0024locals_002414431 _0024_0024locals_002414981;

		public _0024GetKilledMonsterNum_0024closure_00243928(_0024GetKilledMonsterNum_0024locals_002414431 _0024_0024locals_002414981)
		{
			this._0024_0024locals_002414981 = _0024_0024locals_002414981;
		}

		public void Invoke(RespMonster e)
		{
			if (e.IsKill)
			{
				MMonsters master = e.Master;
				if (master != null && master.Id == _0024_0024locals_002414981._0024monsterMasterId)
				{
					_0024_0024locals_002414981._0024n = checked(_0024_0024locals_002414981._0024n + 1);
				}
			}
		}
	}

	[Serializable]
	internal class _0024get_AllMonsterNum_0024closure_00242991
	{
		internal _0024get_AllMonsterNum_0024locals_002414432 _0024_0024locals_002414982;

		public _0024get_AllMonsterNum_0024closure_00242991(_0024get_AllMonsterNum_0024locals_002414432 _0024_0024locals_002414982)
		{
			this._0024_0024locals_002414982 = _0024_0024locals_002414982;
		}

		public int Invoke(RespMonster m)
		{
			return _0024_0024locals_002414982._0024n = checked(_0024_0024locals_002414982._0024n + 1);
		}
	}

	[Serializable]
	internal class _0024StageBattleMonster_0024closure_00243929
	{
		internal _0024StageBattleMonster_0024locals_002414433 _0024_0024locals_002414983;

		public _0024StageBattleMonster_0024closure_00243929(_0024StageBattleMonster_0024locals_002414433 _0024_0024locals_002414983)
		{
			this._0024_0024locals_002414983 = _0024_0024locals_002414983;
		}

		public void Invoke(RespMonster m)
		{
			int i = 0;
			MStageMonsters[] allStageMonsters = _0024_0024locals_002414983._0024battle.AllStageMonsters;
			for (int length = allStageMonsters.Length; i < length; i = checked(i + 1))
			{
				if (allStageMonsters[i].Id == m.Id)
				{
					_0024_0024locals_002414983._0024md.Add(m);
				}
			}
		}
	}

	[Serializable]
	internal class _0024IsContainedMonter_0024closure_00243930
	{
		internal _0024IsContainedMonter_0024locals_002414434 _0024_0024locals_002414984;

		public _0024IsContainedMonter_0024closure_00243930(_0024IsContainedMonter_0024locals_002414434 _0024_0024locals_002414984)
		{
			this._0024_0024locals_002414984 = _0024_0024locals_002414984;
		}

		public bool Invoke(RespMonster mm)
		{
			return RuntimeServices.EqualityOperator(mm, _0024_0024locals_002414984._0024m);
		}
	}

	[Serializable]
	internal class _0024GotoStage_0024closure_00243933
	{
		internal _0024GotoStage_0024locals_002414435 _0024_0024locals_002414985;

		public _0024GotoStage_0024closure_00243933(_0024GotoStage_0024locals_002414435 _0024_0024locals_002414985)
		{
			this._0024_0024locals_002414985 = _0024_0024locals_002414985;
		}

		public void Invoke(MScenes preStage)
		{
			EnumMapLinkDir enumMapLinkDir = preStage.linkToDir(_0024_0024locals_002414985._0024dir);
			_JumpToDir = ((enumMapLinkDir > (EnumMapLinkDir)0) ? enumMapLinkDir : MasterUtil.OppositeDirection(_0024_0024locals_002414985._0024dir));
		}
	}

	[NonSerialized]
	public static bool LOAD_BATTLE_SE_AT_INITIALIZATION;

	[NonSerialized]
	public static bool LOAD_MONSTER_SE_AT_INITIALIZATION = true;

	[NonSerialized]
	public static bool LOAD_POPPET_SE_AT_INITIALIZATION;

	[NonSerialized]
	public static bool LOAD_SKILL_SE_AT_INITIALIZATION;

	[NonSerialized]
	public static bool LOAD_SCENE_SE_AT_INITIALIZATION;

	[NonSerialized]
	public static bool ENCRYPT_QUEST_SESSION_DATA = true;

	[NonSerialized]
	protected const string ALL_SCENE_VISIT_FLAG = "tAllVisit";

	[NonSerialized]
	private static QuestSessionParameters _Parameter = new QuestSessionParameters();

	[NonSerialized]
	private static QuestSessionData _Session = new QuestSessionData();

	[NonSerialized]
	private static QuestGeometricSessionData _Geom = new QuestGeometricSessionData();

	[NonSerialized]
	private static bool _IsLoaded;

	[NonSerialized]
	private static RespQuestResult _lastResultResponse;

	[NonSerialized]
	private static RespPlayerPresentBox[] _preEndQuestPrsentResponse;

	[NonSerialized]
	private static EState _State = EState.UnInitialized;

	[NonSerialized]
	private static MScenes _DebugPrevScene;

	[NonSerialized]
	private static EnumMapLinkDir _JumpToDir;

	[NonSerialized]
	private const string SAVE_FILENAME = "riseofmana.cont";

	public static QuestBattleSessionData BattleSessionData => (_Session == null) ? null : _Session.battleSession;

	public static bool HasBattleStoppedData
	{
		get
		{
			bool num = IsLoaded;
			if (num)
			{
				num = _Session.battleSession.stopped;
			}
			return num;
		}
	}

	public static bool IsBattleStoppedBeforeContinue => HasBattleStoppedData && !_Session.battleSession.afterContinue;

	public static bool NeedResultMode => _Parameter == null || _Parameter.needResultMode;

	public static bool NeedEndLogo => _Parameter == null || _Parameter.needEndLogo;

	public static RespFriendPoppet LastSessionFriend => (_Parameter == null) ? null : _Parameter.helper;

	public static bool IsDebugDirectSceneStartMode
	{
		get
		{
			bool num = _Parameter != null;
			if (num)
			{
				num = _Parameter.debugMScenes != null;
			}
			return num;
		}
	}

	public static int StoryId => (_Parameter != null) ? _Parameter.StoryId : 0;

	public static MStories Story => MStories.Get(StoryId);

	public static MQuests Quest => (Story == null) ? null : Story.MQuestId;

	public static bool IsContinuableQuest
	{
		get
		{
			MQuests quest = Quest;
			bool num = quest != null;
			if (num)
			{
				bool num2 = quest.ForbidContinuation;
				if (!num2)
				{
					num2 = IsFailIfDead;
				}
				num = !num2;
			}
			return num;
		}
	}

	public static bool IsFailIfDead
	{
		get
		{
			MQuests quest = Quest;
			bool num = quest != null;
			if (num)
			{
				num = quest.FailIfDead;
			}
			return num;
		}
	}

	public static MStages Stage => (Quest == null) ? null : Quest.MStageId;

	public static bool WithServer => _Parameter != null && _Parameter.WithServer;

	public static bool IsPractice => Story != null && Story.Practice;

	public static RespQuestStart LastStartResponse => _Session.startResponse;

	private static RespQuestResult LastResultResponse
	{
		get
		{
			return _lastResultResponse;
		}
		set
		{
			_lastResultResponse = value;
		}
	}

	private static RespPlayerPresentBox[] PreEndQuestPrsentResponse
	{
		get
		{
			return _preEndQuestPrsentResponse;
		}
		set
		{
			_preEndQuestPrsentResponse = value;
		}
	}

	public static MScenes[] AllScenes
	{
		get
		{
			return _Session.allScenes;
		}
		set
		{
			_Session.allScenes = value;
		}
	}

	public static Boo.Lang.List<MScenes> VisitedScenes => _Session.visitedScenes;

	public static bool IsAllScenesVisited => AllScenes.Length <= ((ICollection)VisitedScenes).Count;

	public static int FriendSocialId => _Parameter.helper.SocialId;

	public static bool IsStarted => _State >= EState.Started;

	public static bool IsStartFinished => _State >= EState.Started;

	public static bool IsInPlay => _State == EState.Started;

	public static bool CompletelyClosed => _State == EState.Closed;

	public static Dictionary<MStageBattles, RespMonster[]> MonsterMap => _Session.monsterMap;

	public static HashSet<MStageBattles> ExistBattles => _Session.existBattles;

	public static int ExistBattleNum => ExistBattles.Count;

	public static int NutRateOfMonsterCandy => Quest?.NutRateOfMonsterCandy ?? 0;

	public static QuestBattleStatistics LoadedQuestBattleStatistics => _Session.questBattleStatistics;

	public static QuestDropManager StageDropManager => _Session.stageDropManager;

	public static int TotalKusamushiNum => StageDropManager.totalDropNum<DropDataKusamushi>();

	public static int PickedKusamushiNum => StageDropManager.pickedUpNum<DropDataKusamushi>();

	public static int RemainingKusamushiNum => StageDropManager.remainingDropNum<DropDataKusamushi>();

	public static bool WasPlayedOpeningCutScene => _Session.playedOpeningCutScene;

	public static RespMonster[] DebugAllQuestMonsters => _Session.AllQuestMonsters;

	public static int KeyItemPoint
	{
		get
		{
			return _Session.keyItemPoint;
		}
		set
		{
			_Session.keyItemPoint = value;
		}
	}

	public static int KilledNum
	{
		get
		{
			_0024get_KilledNum_0024locals_002414430 _0024get_KilledNum_0024locals_0024 = new _0024get_KilledNum_0024locals_002414430();
			_0024get_KilledNum_0024locals_0024._0024n = 0;
			_Session.eachMonster(new _0024get_KilledNum_0024closure_00242990(_0024get_KilledNum_0024locals_0024).Invoke);
			return _0024get_KilledNum_0024locals_0024._0024n;
		}
	}

	public static int AllMonsterNum
	{
		get
		{
			_0024get_AllMonsterNum_0024locals_002414432 _0024get_AllMonsterNum_0024locals_0024 = new _0024get_AllMonsterNum_0024locals_002414432();
			_0024get_AllMonsterNum_0024locals_0024._0024n = 0;
			_Session.eachMonster(_0024adaptor_0024__ArrayMapMain_RespsToInts_0024callable122_002491_65___0024__QuestSessionData_eachMonster_0024callable81_0024164_34___0024160.Adapt(new _0024get_AllMonsterNum_0024closure_00242991(_0024get_AllMonsterNum_0024locals_0024).Invoke));
			return _0024get_AllMonsterNum_0024locals_0024._0024n;
		}
	}

	public static RespSimpleReward[] AllQuestRewards => (LastStartResponse == null) ? new RespSimpleReward[0] : LastStartResponse.QuestRewards;

	public static int EarnedCoin => _Session.EarnedCoin;

	public static int EarnedDummyCoin => _Session.EarnedDummyCoin;

	public static int EarnedTreasureNum => _Session.EarnedTreasureNum;

	public static int EarnedDummyTreasureNum => _Session.EarnedDummyTreasureNum;

	public static MScenes CurrentScene
	{
		get
		{
			return _Session.currentScene;
		}
		set
		{
			_Session.currentScene = value;
		}
	}

	public static bool IsCurrentStageAvailable => CurrentScene != null;

	public static HashSet<MStageBattles> MarkedBattles => _Session.markedBattles;

	private static string SAVE_FILEPATH => Path.Combine(Application.persistentDataPath, "riseofmana.cont");

	public static bool IsSessionEnded => _Session.ended;

	public static bool IsSessionSucceeded
	{
		get
		{
			bool num = IsSessionEnded;
			if (num)
			{
				num = _Session.endStatus == 0;
			}
			return num;
		}
	}

	public static bool IsSessionFailed
	{
		get
		{
			bool num = IsSessionEnded;
			if (num)
			{
				num = _Session.endStatus == 1;
			}
			return num;
		}
	}

	public static bool IsSessionTimeover
	{
		get
		{
			bool num = IsSessionEnded;
			if (num)
			{
				num = _Session.endStatus == 2;
			}
			return num;
		}
	}

	public static bool IsPlayingFinalQuest
	{
		get
		{
			bool num = Quest != null;
			if (num)
			{
				num = IsFinalQuest(Quest.Progname);
			}
			return num;
		}
	}

	public static QuestSessionParameters LastSessionParameter => _Parameter;

	public static QuestSessionData Session => _Session;

	public static QuestGeometricSessionData GeomSession => _Geom;

	public static bool IsLoaded => _IsLoaded;

	public static EState State => _State;

	public static MScenes DebugPrevScene => _DebugPrevScene;

	public static EnumMapLinkDir JumpToDir => _JumpToDir;

	public static void ClearBattleSessionData()
	{
		BattleSessionData?.clear();
	}

	public static Dictionary<MScenes, Boo.Lang.List<QuestDropManager.DropData>> GetKusamushiMapForDebug()
	{
		return StageDropManager.DropMap;
	}

	public static QuestDropManager.DropData[] GetKusamushiDataOfCurrentScene()
	{
		QuestDropManager.DropData[] dropData = StageDropManager.GetDropData(CurrentScene);
		return null;
	}

	public static QuestDropManager.DropData[] GetKusamushiData(MScenes scn)
	{
		return StageDropManager.GetDropData(scn);
	}

	public static void PickedKusamushiUp(QuestDropManager.DropData kdata)
	{
		StageDropManager.PickedDropUp(kdata);
		int pickedUpNum = StageDropManager.pickedUpNum<DropDataKusamushi>();
		QuestClearConditionChecker.Instance.satisfyKusamushi(pickedUpNum);
	}

	private static void PlaceStageDrops(MQuests q)
	{
		if (q == null)
		{
			throw new AssertionFailedException("q != null");
		}
		Boo.Lang.List<QuestDropManager.DropData> list = new Boo.Lang.List<QuestDropManager.DropData>();
		MQuestClears[] array = KusamushiConditions(q);
		if (array.Length > 1)
		{
			throw new AssertionFailedException(new StringBuilder("草虫クリア条件は各クエストに１つしかダメです ").Append(q).ToString());
		}
		if (array.Length > 0)
		{
			MKusamushi kusamushiMaster = array[0].KusamushiMaster;
			int kusamushiNum = array[0].KusamushiNum;
			if (kusamushiMaster == null)
			{
				throw new AssertionFailedException("km != null");
			}
			int num = 0;
			int num2 = kusamushiNum;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int num3 = num;
				num++;
				list.Add(new DropDataKusamushi(kusamushiMaster));
			}
		}
		int num4 = 0;
		int candyDropNum = q.CandyDropNum;
		if (candyDropNum < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num4 < candyDropNum)
		{
			int num5 = num4;
			num4++;
			list.Add(new DropDataCandy());
		}
		int num6 = 0;
		int nutDropNum = q.NutDropNum;
		if (nutDropNum < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num6 < nutDropNum)
		{
			int num7 = num6;
			num6++;
			list.Add(new DropDataNut());
		}
		StageDropManager.PlaceDrops(q, list.ToArray());
	}

	private static MQuestClears[] KusamushiConditions(MQuests q)
	{
		MQuestClears[] result;
		if (q == null)
		{
			result = new MQuestClears[0];
		}
		else
		{
			Boo.Lang.List<MQuestClears> list = new Boo.Lang.List<MQuestClears>();
			int i = 0;
			MQuestClears[] clearConditions = q.ClearConditions;
			for (int length = clearConditions.Length; i < length; i = checked(i + 1))
			{
				if (clearConditions[i].ClearType == EnumQuestClearTypes.Kusamushi)
				{
					list.Add(clearConditions[i]);
				}
			}
			result = list.ToArray();
		}
		return result;
	}

	public static ApiQuestStart StartQuest(int storyId, RespFriendPoppet helper, bool noSceneLoad)
	{
		return StartQuest(storyId, helper, 0, noSceneLoad);
	}

	public static ApiQuestStart StartQuest(int storyId, RespFriendPoppet helper, int questStartOption, bool noSceneLoad)
	{
		QuestSessionParameters questSessionParameters = new QuestSessionParameters();
		questSessionParameters.storyId = storyId;
		questSessionParameters.helper = helper;
		questSessionParameters.noSceneLoad = noSceneLoad;
		questSessionParameters.option = questStartOption;
		return StartSession(questSessionParameters);
	}

	public static ApiQuestStart StartSession(QuestSessionParameters prm)
	{
		if (prm == null)
		{
			throw new AssertionFailedException("prm != null");
		}
		prm.dump("QuestSession.StartSession parameters:");
		_State = EState.Starting;
		_Parameter = prm;
		_Session.clear();
		_Geom.clear();
		_IsLoaded = false;
		int storyId = prm.StoryId;
		RespFriendPoppet helper = prm.helper;
		bool noSceneLoad = prm.NoSceneLoad;
		MStories mStories = MStories.Get(storyId);
		if (mStories != null && mStories.Practice)
		{
			prm.withServer = false;
		}
		return StartSession();
	}

	private static ApiQuestStart StartSession()
	{
		_0024StartSession_0024locals_002414428 _0024StartSession_0024locals_0024 = new _0024StartSession_0024locals_002414428();
		GameSoundManager.Instance.CurMQuest = Quest;
		QuestClearConditionChecker.Instance.clearCondition();
		QuestClearConditionChecker.Instance.initTimer();
		InitQuestEventHandlerParams();
		_0024StartSession_0024locals_0024._0024prm = _Parameter;
		object result;
		if (_0024StartSession_0024locals_0024._0024prm.WithServer)
		{
			_0024StartSession_0024locals_0024._0024req = _0024StartSession_0024locals_0024._0024prm.createStartRequest();
			_0024StartSession_0024locals_0024._0024req.PreDialogErrorHandler = delegate(RequestBase r)
			{
				communicationError(r);
			};
			ContinueDataSet continueDataSet = LoadContinueData();
			if (!continueDataSet.IsLoaded)
			{
				Save(succComm: false);
			}
			MerlinServer.Request(_0024StartSession_0024locals_0024._0024req, _0024adaptor_0024__QuestSession_StartSessionDebug_0024callable80_00241001_56___0024__MerlinServer_Request_0024callable86_0024160_56___0024158.Adapt(new _0024StartSession_0024closure_00243925(_0024StartSession_0024locals_0024).Invoke));
			result = _0024StartSession_0024locals_0024._0024req;
		}
		else
		{
			initMScenesAndSetStartScene(_0024StartSession_0024locals_0024._0024prm);
			_State = EState.Started;
			RespMonster[] startRequestNoServer = SetStageMonstersFromMasterOnly(Quest);
			_Session.setStartRequestNoServer(startRequestNoServer);
			InitializeSE();
			PlaceStageDrops(Quest);
			clearAllTFlags();
			result = null;
		}
		return (ApiQuestStart)result;
	}

	private static void InitQuestEventHandlerParams()
	{
		WeaponEquipments weq = WeaponEquipments.FromUserData();
		RespPoppet[] activePoppets = GetActivePoppets();
		float atk = DamageCalc.TotalPlayerAttack(weq, activePoppets);
		float hp = DamageCalc.TotalPlayerHP(weq, activePoppets);
		QuestEventHandler.InitBattleInfo(atk, hp);
	}

	private static RespPoppet[] GetActivePoppets()
	{
		_0024GetActivePoppets_0024locals_002414429 _0024GetActivePoppets_0024locals_0024 = new _0024GetActivePoppets_0024locals_002414429();
		_0024GetActivePoppets_0024locals_0024._0024ppts = new Boo.Lang.List<RespPoppet>();
		__DebugSubNewEquipSystem_selectPoppet_0024callable28_0024267_55__ _DebugSubNewEquipSystem_selectPoppet_0024callable28_0024267_55__ = new _0024GetActivePoppets_0024_add_00243926(_0024GetActivePoppets_0024locals_0024).Invoke;
		_DebugSubNewEquipSystem_selectPoppet_0024callable28_0024267_55__(UserData.Current.CurrentPoppetNewOrOldDeck);
		if (_Parameter != null)
		{
			_DebugSubNewEquipSystem_selectPoppet_0024callable28_0024267_55__(_Parameter.helper);
		}
		return (RespPoppet[])Builtins.array(typeof(RespPoppet), _0024GetActivePoppets_0024locals_0024._0024ppts);
	}

	private static void NotifyTutorialStepAtStarting(MQuests q)
	{
		if (q != null)
		{
			if (q.Progname == "Story001Main001")
			{
				MerlinServer.NotifyTutorialStep(350);
			}
			else if (q.Progname == "Story001Sub001")
			{
				MerlinServer.NotifyTutorialStep(450);
			}
			else if (q.Progname == "Story001Free002")
			{
				MerlinServer.NotifyTutorialStep(460);
			}
			else if (q.Progname == "Story001Sub002")
			{
				MerlinServer.NotifyTutorialStep(470);
			}
			else if (q.Progname == "Story001Free003")
			{
				MerlinServer.NotifyTutorialStep(480);
			}
		}
	}

	private static void NotifyTutorialStepAtEnding(MQuests q)
	{
		if (q != null && q.Progname == "Story001Main001")
		{
			MerlinServer.NotifyTutorialStep(400);
		}
	}

	private static void initMScenesAndSetStartScene(QuestSessionParameters prm)
	{
		if (prm == null || Quest == null)
		{
			throw new AssertionFailedException("(prm != null) and (Quest != null)");
		}
		AllScenes = Quest.StartSceneId.collectAllLinkedScenes();
		VisitedScenes.Clear();
		if (prm.debugMScenes == null)
		{
			MScenes mScenes = null;
			mScenes = ((!MQuestsUtil.MustPlayStartCutScene(Quest) || !Quest.HasSceneOfStartCutScene || WasPlayedOpeningCutScene) ? GetStartScene(prm.StoryId) : Quest.SceneOfStartCutScene);
			SetStartStage(mScenes, prm.NoSceneLoad, prm.withSceneFade);
		}
		else
		{
			SetStartStage(prm.debugMScenes, prm.NoSceneLoad, prm.withSceneFade);
		}
	}

	private static void MarkAsVisit(MScenes mscn)
	{
		if (mscn != null && !VisitedScenes.Contains(mscn))
		{
			VisitedScenes.Add(mscn);
			if (IsAllScenesVisited)
			{
				UserData.Current.setFlag("tAllVisit");
			}
		}
	}

	public static void InitializeSE()
	{
		if (LOAD_BATTLE_SE_AT_INITIALIZATION)
		{
			InitializeBattleSE();
		}
		if (LOAD_MONSTER_SE_AT_INITIALIZATION)
		{
			InitializeMonsterSE(_Session.monsterData);
		}
		if (LOAD_POPPET_SE_AT_INITIALIZATION)
		{
			InitializePoppetSE();
		}
		GameSoundManager instance = default(GameSoundManager);
		if (LOAD_SKILL_SE_AT_INITIALIZATION)
		{
			instance = GameSoundManager.Instance;
			if (instance != null)
			{
				instance.LoadSeType(2);
			}
		}
		if (LOAD_SCENE_SE_AT_INITIALIZATION)
		{
			instance.LoadSceneSe(CurrentScene);
		}
	}

	public static void LoadSEInPlay(PlayerControl playerControl)
	{
		if (!LOAD_MONSTER_SE_AT_INITIALIZATION)
		{
			InitializeMonsterSE();
		}
		if (!LOAD_POPPET_SE_AT_INITIALIZATION)
		{
			InitializePoppetSE();
		}
		if (!LOAD_SKILL_SE_AT_INITIALIZATION)
		{
			playerControl.loadAssetsInMotPack();
		}
		if (!LOAD_BATTLE_SE_AT_INITIALIZATION)
		{
			InitializeBattleSE();
		}
		if (!LOAD_BATTLE_SE_AT_INITIALIZATION)
		{
			InitializeSceneSE();
		}
	}

	private static void InitializeMonsterSE()
	{
		InitializeMonsterSE(_Session.monsterData);
	}

	public static void InitializeMonsterSE(RespMonster[] monsters)
	{
		SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
		GameSoundManager instance2 = GameSoundManager.Instance;
		if (instance == null || instance2 == null)
		{
			return;
		}
		instance.UnloadSeType(6);
		instance.UnloadSeType(7);
		instance2.LoadSeGroup("e_common");
		int i = 0;
		for (int length = monsters.Length; i < length; i = checked(i + 1))
		{
			MMonsters master = monsters[i].Master;
			if (master != null && !string.IsNullOrEmpty(master.SoundID))
			{
				instance2.LoadSeGroup(master.SoundID);
			}
		}
	}

	private static void InitializeSceneSE()
	{
		GameSoundManager instance = GameSoundManager.Instance;
		if (!(instance == null))
		{
			instance.LoadSceneSe(CurrentScene);
		}
	}

	public static void InitializeBattleSE()
	{
		GameSoundManager instance = GameSoundManager.Instance;
		if (!(instance == null))
		{
			instance.LoadSeType(1);
		}
	}

	private static void InitializePoppetSE()
	{
		GameSoundManager instance = GameSoundManager.Instance;
		if (instance == null)
		{
			return;
		}
		UserData current = UserData.Current;
		if (current != null)
		{
			RespPoppet currentPoppetNewOrOldDeck = current.CurrentPoppetNewOrOldDeck;
			if (currentPoppetNewOrOldDeck != null)
			{
				MMonsters monsterMaster = currentPoppetNewOrOldDeck.MonsterMaster;
				if (monsterMaster != null && !string.IsNullOrEmpty(monsterMaster.SoundID))
				{
					instance.LoadSeGroup(monsterMaster.SoundID);
				}
			}
		}
		RespFriendPoppet helper = _Parameter.helper;
		if (helper != null)
		{
			MMonsters monsterMaster = helper.MonsterMaster;
			if (monsterMaster != null && !string.IsNullOrEmpty(monsterMaster.SoundID))
			{
				instance.LoadSeGroup(monsterMaster.SoundID);
			}
		}
	}

	private static RespMonster[] SetStageMonstersFromMasterOnly(MQuests quest)
	{
		Boo.Lang.List<RespMonster> list = new Boo.Lang.List<RespMonster>();
		int i = 0;
		MStageMonsters[] all = MStageMonsters.All;
		checked
		{
			for (int length = all.Length; i < length; i++)
			{
				if (all[i].MStageId != quest.MStageId.Id)
				{
					continue;
				}
				int j = 0;
				RespMonster[] array = RespMonster.FromStageMonster(all[i]);
				for (int length2 = array.Length; j < length2; j++)
				{
					if (array[j] != null)
					{
						list.Add(array[j]);
					}
				}
			}
			RespMonster[] array2 = (RespMonster[])Builtins.array(typeof(RespMonster), list);
			SetStageMonsters(quest, array2);
			return array2;
		}
	}

	private static void SetStageMonsters(MQuests quest, RespMonster[] monsters)
	{
		if (quest == null || monsters == null)
		{
			throw new AssertionFailedException("(quest != null) and (monsters != null)");
		}
		CheckMasterAndResponseMonsters(quest, monsters);
		if (quest == null || quest.StartSceneId == null)
		{
			return;
		}
		Dictionary<int, Queue<RespMonster>> dictionary = new Dictionary<int, Queue<RespMonster>>();
		int i = 0;
		checked
		{
			for (int length = monsters.Length; i < length; i++)
			{
				if (!dictionary.ContainsKey(monsters[i].Id))
				{
					dictionary[monsters[i].Id] = new Queue<RespMonster>();
				}
				dictionary[monsters[i].Id].Enqueue(monsters[i]);
			}
			int j = 0;
			MScenes[] allScenes = AllScenes;
			for (int length2 = allScenes.Length; j < length2; j++)
			{
				int k = 0;
				MStageBattles[] allStageBattles = allScenes[j].AllStageBattles;
				for (int length3 = allStageBattles.Length; k < length3; k++)
				{
					ExistBattles.Add(allStageBattles[k]);
					Boo.Lang.List<RespMonster> list = new Boo.Lang.List<RespMonster>();
					int l = 0;
					MStageMonsters[] allStageMonsters = allStageBattles[k].AllStageMonsters;
					for (int length4 = allStageMonsters.Length; l < length4; l++)
					{
						if (dictionary.ContainsKey(allStageMonsters[l].Id))
						{
							Queue<RespMonster> queue = dictionary[allStageMonsters[l].Id];
							if (queue.Count > 0)
							{
								list.Add(queue.Dequeue());
							}
						}
					}
					MonsterMap[allStageBattles[k]] = (RespMonster[])Builtins.array(typeof(RespMonster), list);
				}
			}
		}
	}

	private static void CheckMasterAndResponseMonsters(MQuests quest, RespMonster[] monsters)
	{
		if (quest == null)
		{
			throw new AssertionFailedException("quest=null");
		}
		if (monsters == null)
		{
			throw new AssertionFailedException("monsters=null");
		}
		Boo.Lang.List<MStageMonsters> list = new Boo.Lang.List<MStageMonsters>();
		IEnumerator enumerator = MStageMonsters.All.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is MStageMonsters))
			{
				obj = RuntimeServices.Coerce(obj, typeof(MStageMonsters));
			}
			MStageMonsters mStageMonsters = (MStageMonsters)obj;
			if (mStageMonsters.MStageId != quest.MStageId.Id)
			{
				continue;
			}
			RespMonster respMonster = Array.Find(monsters, _0024adaptor_0024__QuestSessionData_findMonster_0024callable82_0024170_37___0024Predicate_0024159.Adapt(new _0024CheckMasterAndResponseMonsters_0024closure_00243927(mStageMonsters).Invoke)) as RespMonster;
			if (respMonster == null)
			{
				MStageBattles parentStageBattle = mStageMonsters.ParentStageBattle;
				if (parentStageBattle == null)
				{
				}
				MScenes parentScene = parentStageBattle.ParentScene;
				if (parentScene == null)
				{
				}
				if (mStageMonsters.Rate < 100)
				{
				}
			}
		}
		MStages mStages = MStages.Get(quest.Id);
		if (mStages == null)
		{
			throw new AssertionFailedException(new StringBuilder().Append(quest).Append("に対応する ").Append(mStages)
				.Append("がない")
				.ToString());
		}
		int i = 0;
		for (int length = monsters.Length; i < length; i = checked(i + 1))
		{
			if (monsters[i].Master == null)
			{
			}
			MStageMonsters mStageMonsters2 = MStageMonsters.Get(monsters[i].Id);
			if (mStageMonsters2.MStageId != mStages.Id)
			{
			}
		}
	}

	public static void PlayedOpeningCutScene()
	{
		_Session.playedOpeningCutScene = true;
	}

	public static int GetKilledMonsterNum(int monsterMasterId)
	{
		_0024GetKilledMonsterNum_0024locals_002414431 _0024GetKilledMonsterNum_0024locals_0024 = new _0024GetKilledMonsterNum_0024locals_002414431();
		_0024GetKilledMonsterNum_0024locals_0024._0024monsterMasterId = monsterMasterId;
		_0024GetKilledMonsterNum_0024locals_0024._0024n = 0;
		_Session.eachMonster(new _0024GetKilledMonsterNum_0024closure_00243928(_0024GetKilledMonsterNum_0024locals_0024).Invoke);
		return _0024GetKilledMonsterNum_0024locals_0024._0024n;
	}

	public static RespMonster[] StageBattleMonster(MStageBattles battle)
	{
		_0024StageBattleMonster_0024locals_002414433 _0024StageBattleMonster_0024locals_0024 = new _0024StageBattleMonster_0024locals_002414433();
		_0024StageBattleMonster_0024locals_0024._0024battle = battle;
		object result;
		if (_0024StageBattleMonster_0024locals_0024._0024battle == null)
		{
			result = new RespMonster[0];
		}
		else if (_State >= EState.Started)
		{
			if (MonsterMap.ContainsKey(_0024StageBattleMonster_0024locals_0024._0024battle))
			{
				result = MonsterMap[_0024StageBattleMonster_0024locals_0024._0024battle];
			}
			else
			{
				_0024StageBattleMonster_0024locals_0024._0024md = new Boo.Lang.List<RespMonster>();
				_Session.eachMonster(new _0024StageBattleMonster_0024closure_00243929(_0024StageBattleMonster_0024locals_0024).Invoke);
				result = (RespMonster[])Builtins.array(typeof(RespMonster), _0024StageBattleMonster_0024locals_0024._0024md);
			}
		}
		else
		{
			result = (RespMonster[])Builtins.array(typeof(RespMonster), _0024StageBattleMonster_0024locals_0024._0024md);
		}
		return (RespMonster[])result;
	}

	public static bool HasAnyMonsters(MStageBattles battle)
	{
		return battle != null && _State >= EState.Started && MonsterMap.ContainsKey(battle) && MonsterMap[battle].Length > 0;
	}

	public static void CloseBattle(MStageBattles battle)
	{
		if (battle != null && ExistBattles.Contains(battle))
		{
			ExistBattles.Remove(battle);
		}
	}

	public static void GotMonsterReward(RespSimpleReward r)
	{
		if (r == null || LastStartResponse == null)
		{
			return;
		}
		int i = 0;
		RespMonster[] monsterData = _Session.monsterData;
		checked
		{
			for (int length = monsterData.Length; i < length; i++)
			{
				int j = 0;
				RespSimpleReward[] rewards = monsterData[i].Rewards;
				for (int length2 = rewards.Length; j < length2; j++)
				{
					if (RuntimeServices.EqualityOperator(rewards[j], r))
					{
						MKeyItems keyItem = rewards[j].KeyItem;
						if (!rewards[j].IsGet && keyItem != null)
						{
							int num = Mathf.Max(rewards[j].Quantity, 1);
							KeyItemPoint += keyItem.Point * num;
						}
						rewards[j].IsGet = true;
					}
				}
			}
		}
	}

	public static bool KillMonster(RespMonster questMonster)
	{
		int result;
		if (questMonster != null && IsContainedMonter(questMonster) && !questMonster.IsKill)
		{
			questMonster.IsKill = true;
			result = 1;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public static void GotMonsterDropAll(RespMonster qm)
	{
		if (qm != null && IsContainedMonter(qm))
		{
			int i = 0;
			RespSimpleReward[] array = (RespSimpleReward[])RuntimeServices.AddArrays(typeof(RespSimpleReward), (RespSimpleReward[])RuntimeServices.AddArrays(typeof(RespSimpleReward), qm.RewardWeapons, qm.RewardPoppets), qm.RewardCoins);
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				array[i].IsGet = true;
			}
		}
	}

	public static void GotAllMonsterDropAll()
	{
		int i = 0;
		RespMonster[] monsterData = _Session.monsterData;
		for (int length = monsterData.Length; i < length; i = checked(i + 1))
		{
			GotMonsterDropAll(monsterData[i]);
		}
	}

	public static void GotMonsterWeaponPoppetDrops(RespMonster questMonster)
	{
		if (LastStartResponse != null && questMonster != null && IsContainedMonter(questMonster))
		{
			int i = 0;
			RespSimpleReward[] array = (RespSimpleReward[])RuntimeServices.AddArrays(typeof(RespSimpleReward), questMonster.RewardWeapons, questMonster.RewardPoppets);
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				array[i].IsGet = true;
			}
		}
	}

	public static void GotMonsterCoins(RespMonster questMonster)
	{
		if (LastStartResponse != null && questMonster != null)
		{
			if (!IsContainedMonter(questMonster))
			{
				throw new AssertionFailedException("IsContainedMonter(questMonster)");
			}
			int i = 0;
			RespSimpleReward[] rewardCoins = questMonster.RewardCoins;
			for (int length = rewardCoins.Length; i < length; i = checked(i + 1))
			{
				rewardCoins[i].IsGet = true;
			}
		}
	}

	public static void GotMonsterExp(RespMonster questMonster)
	{
		if (questMonster != null && LastStartResponse != null && IsContainedMonter(questMonster))
		{
			int i = 0;
			RespSimpleReward[] rewardExps = questMonster.RewardExps;
			for (int length = rewardExps.Length; i < length; i = checked(i + 1))
			{
				rewardExps[i].IsGet = true;
			}
		}
	}

	public static void GotQuestRewards()
	{
		if (LastStartResponse != null)
		{
			int i = 0;
			RespSimpleReward[] questRewards = LastStartResponse.QuestRewards;
			for (int length = questRewards.Length; i < length; i = checked(i + 1))
			{
				questRewards[i].IsGet = true;
			}
		}
	}

	public static RespSimpleReward[] AllCollectedDrops()
	{
		Boo.Lang.List<RespSimpleReward> list = new Boo.Lang.List<RespSimpleReward>();
		checked
		{
			if (LastStartResponse != null)
			{
				int i = 0;
				RespMonster[] monsterData = _Session.monsterData;
				for (int length = monsterData.Length; i < length; i++)
				{
					int j = 0;
					RespSimpleReward[] rewards = monsterData[i].Rewards;
					for (int length2 = rewards.Length; j < length2; j++)
					{
						if (rewards[j].IsGet)
						{
							list.Add(rewards[j]);
						}
					}
				}
			}
			return (RespSimpleReward[])Builtins.array(typeof(RespSimpleReward), list);
		}
	}

	public static RespReward[] ResultCollectedDrops()
	{
		RespReward[] result;
		if (LastResultResponse != null)
		{
			UserBoxData userBoxData = UserData.Current.userBoxData;
			Boo.Lang.List<RespReward> list = new Boo.Lang.List<RespReward>();
			int i = 0;
			int[] dropBoxIds = LastResultResponse.getDropBoxIds();
			for (int length = dropBoxIds.Length; i < length; i = checked(i + 1))
			{
				RespReward respReward = RespReward.FromPlayerBox(userBoxData.get(new BoxId(dropBoxIds[i])));
				if (respReward != null)
				{
					list.Add(respReward);
				}
			}
			result = list.ToArray();
		}
		else
		{
			result = new RespReward[0];
		}
		return result;
	}

	private static bool IsContainedMonter(RespMonster m)
	{
		_0024IsContainedMonter_0024locals_002414434 _0024IsContainedMonter_0024locals_0024 = new _0024IsContainedMonter_0024locals_002414434();
		_0024IsContainedMonter_0024locals_0024._0024m = m;
		int result;
		if (_0024IsContainedMonter_0024locals_0024._0024m == null)
		{
			result = 0;
		}
		else
		{
			RespMonster respMonster = _Session.findMonster(new _0024IsContainedMonter_0024closure_00243930(_0024IsContainedMonter_0024locals_0024).Invoke);
			result = ((respMonster != null) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	private static void ResetAllMonstersAndRewards()
	{
		if (LastStartResponse == null)
		{
			return;
		}
		int i = 0;
		RespMonster[] monsterData = _Session.monsterData;
		checked
		{
			for (int length = monsterData.Length; i < length; i++)
			{
				monsterData[i].IsKill = false;
				int j = 0;
				RespSimpleReward[] rewards = monsterData[i].Rewards;
				for (int length2 = rewards.Length; j < length2; j++)
				{
					rewards[j].IsGet = false;
				}
			}
		}
	}

	public static ApiQuestResult Succeeded()
	{
		if (LastStartResponse == null)
		{
			throw new AssertionFailedException("LastStartResponse != null");
		}
		return EndQuest();
	}

	public static ApiQuestResult Failed()
	{
		if (LastStartResponse == null || _State != EState.Started)
		{
			throw new AssertionFailedException(new StringBuilder("LastStartResponse:").Append(LastStartResponse).Append(" or _State:").Append(_State)
				.Append(" was invalid.")
				.ToString());
		}
		SetSessionFailed();
		return EndQuest();
	}

	public static ApiQuestResult EndQuest()
	{
		if (_Parameter == null)
		{
			throw new AssertionFailedException("_Parameter != null");
		}
		bool num = Quest != null;
		if (num)
		{
			num = Quest.IsChallenge;
		}
		bool flag = num;
		bool num2 = flag;
		if (!num2)
		{
			num2 = _Session.EndedSucceeded;
		}
		bool flag2 = num2;
		if (!flag2)
		{
			ResetAllMonstersAndRewards();
		}
		ApiQuestResult apiQuestResult = _Session.createEndRequest(LastStartResponse, flag2);
		_Session.ended = true;
		Save();
		_State = EState.Closing;
		PreEndQuestPrsentResponse = null;
		if (flag2 && Story != null)
		{
			UserData.Current.userMiscInfo.storyData.play(Story.Progname);
		}
		if (flag)
		{
			flag = true;
			UserData.Current.setFlag("xPlayedChallenge", 1);
			apiQuestResult.IsSuccess = true;
		}
		if (_Parameter.WithServer)
		{
			if (flag)
			{
				MerlinServer.Request(new ApiPresent(), _0024adaptor_0024__QuestSession_0024callable352_0024920_54___0024__MerlinServer_Request_0024callable86_0024160_56___0024161.Adapt(delegate(ApiPresent respPresent)
				{
					if (respPresent == null)
					{
						throw new AssertionFailedException("respPresent != null");
					}
					PreEndQuestPrsentResponse = respPresent.GetResponse().PresentBox;
				}));
			}
			MerlinServer.Request(apiQuestResult, _0024adaptor_0024__QuestSession_0024callable353_0024924_41___0024__MerlinServer_Request_0024callable86_0024160_56___0024162.Adapt(delegate(ApiQuestResult r)
			{
				if (r == null)
				{
					throw new AssertionFailedException("r != null");
				}
				LastResultResponse = r.GetResponse();
				DeleteSaveData();
				_State = EState.Closed;
				QuestClearConditionChecker.Instance.stop();
				if (r.IsSuccess)
				{
					setQuestClearFlag(Quest);
				}
				NotifyTutorialStepAtEnding(Quest);
				ApiLocalDataUpload apiLocalDataUpload = ApiLocalDataUpload.WithUserData();
				apiLocalDataUpload.Stealth = true;
				apiLocalDataUpload.ignoreAllErrors = true;
				MerlinServer.Request(apiLocalDataUpload);
			}));
		}
		else
		{
			LastResultResponse = null;
			DeleteSaveData();
			_State = EState.Closed;
		}
		return apiQuestResult;
	}

	private static void setQuestClearFlag(MQuests q)
	{
		if (q == null)
		{
			return;
		}
		string text = MFlagsUtil.QuestClearFlagName(Quest);
		if (!string.IsNullOrEmpty(text))
		{
			MFlags mFlags = MFlagsUtil.Find(text);
			if (mFlags != null)
			{
				UserData.Current.setFlag(text);
			}
		}
	}

	private static void SetCurrentQuestClearFlag()
	{
		if (Quest != null)
		{
			setQuestClearFlag(Quest);
			UserData.Current.userMiscInfo.questData.clear(Quest.Id);
		}
		if (Story != null)
		{
			UserData.Current.userMiscInfo.storyData.play(Story.Progname);
		}
	}

	private static void clearAllTFlags()
	{
		UserData current = UserData.Current;
		int i = 0;
		MFlags[] all = MFlags.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (all[i] != null && !string.IsNullOrEmpty(all[i].Progname) && all[i].Progname.StartsWith("t"))
			{
				current.deleteFlag(all[i].Progname);
			}
		}
	}

	public static RespQuestResult GetLastResult()
	{
		return LastResultResponse;
	}

	public static RespPlayerPresentBox[] GetLastPresents()
	{
		return PreEndQuestPrsentResponse;
	}

	public static void InvalidateSession()
	{
		_State = EState.UnInitialized;
		_Parameter = null;
		_Session.clear();
	}

	public static StartSessionForDebug StartSessionDebug(MonoBehaviour you, int storyId, bool noSceneLoad, __QuestSession_StartSessionDebug_0024callable80_00241001_56__ handler)
	{
		return new StartSessionForDebug(you, storyId, noSceneLoad, handler);
	}

	public static StartSessionForDebug StartSessionDebug(MonoBehaviour you, int storyId, bool noSceneLoad)
	{
		return new StartSessionForDebug(you, storyId, noSceneLoad, null);
	}

	public static StartSessionForDebug StartSessionDebugWithoutServer(MonoBehaviour you, int storyId, bool noSceneLoad)
	{
		return new StartSessionForDebug(you, storyId, noSceneLoad, withServer: false, null);
	}

	public static StartSessionForDebug StartSessionDebug(MonoBehaviour you, QuestSessionParameters @params)
	{
		return new StartSessionForDebug(you, @params);
	}

	private static MScenes GetStartScene(int storyId)
	{
		MStories mStories = MStories.Get(storyId);
		if (mStories == null)
		{
			throw new AssertionFailedException(new StringBuilder().Append((object)storyId).Append("のストーリーが無い！").ToString());
		}
		MQuests mQuestId = mStories.MQuestId;
		if (mQuestId == null)
		{
			throw new Exception(new StringBuilder("ストーリー").Append(mStories).Append("のクエストが無い！").ToString());
		}
		if (mQuestId.StartSceneId == null)
		{
			throw new AssertionFailedException(new StringBuilder("クエスト").Append(mQuestId).Append("の開始ステージが無い！").ToString());
		}
		return mQuestId.StartSceneId;
	}

	public static MScenes SetStartStageForEditorDirectPlay(string sceneName)
	{
		object result;
		if (string.IsNullOrEmpty(sceneName))
		{
			result = null;
		}
		else
		{
			int num = 0;
			MScenes[] all = MScenes.All;
			int length = all.Length;
			while (true)
			{
				if (num < length)
				{
					if (all[num].SceneName == sceneName)
					{
						SetStartStage(all[num], noSceneLoad: true, withSceneFade: true);
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
		return (MScenes)result;
	}

	private static void SetStartStage(MScenes mscn, bool noSceneLoad, bool withSceneFade)
	{
		if (mscn == null)
		{
			throw new AssertionFailedException("mscn != null");
		}
		if (!RuntimeServices.EqualityOperator(CurrentScene, mscn))
		{
			MarkAsVisit(mscn);
			if (!noSceneLoad)
			{
				LoadStageScene(mscn, withSceneFade);
			}
		}
	}

	public static bool IsMarkedBattle(MStageBattles battle)
	{
		if (battle == null)
		{
			throw new AssertionFailedException("バトル==null");
		}
		return MarkedBattles.Contains(battle);
	}

	public static void MarkBattle(MStageBattles battle)
	{
		if (battle != null && !MarkedBattles.Contains(battle))
		{
			MarkedBattles.Add(battle);
		}
	}

	public static void MarkAllBattles()
	{
		MQuests quest = Quest;
		if (quest == null)
		{
			return;
		}
		int i = 0;
		MScenes[] array = quest.StartSceneId.collectAllLinkedScenes();
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				int j = 0;
				MStageBattles[] allStageBattles = array[i].AllStageBattles;
				for (int length2 = allStageBattles.Length; j < length2; j++)
				{
					MarkBattle(allStageBattles[j]);
				}
			}
		}
	}

	public static bool CanGoto(string dirStr)
	{
		EnumMapLinkDir enumMapLinkDir = StrToMapLinkDir(dirStr);
		return enumMapLinkDir >= (EnumMapLinkDir)0 && CanGoto(enumMapLinkDir);
	}

	public static bool CanGoto(EnumMapLinkDir dir)
	{
		return CurrentScene.linkTo(dir) != null;
	}

	public static MScenes GotoStage(string dirStr)
	{
		EnumMapLinkDir enumMapLinkDir = StrToMapLinkDir(dirStr);
		return (enumMapLinkDir < (EnumMapLinkDir)0) ? null : GotoStage(enumMapLinkDir);
	}

	public static MScenes GotoStage(EnumMapLinkDir dir)
	{
		_0024GotoStage_0024locals_002414435 _0024GotoStage_0024locals_0024 = new _0024GotoStage_0024locals_002414435();
		_0024GotoStage_0024locals_0024._0024dir = dir;
		if (CurrentScene == null)
		{
			throw new AssertionFailedException("CurrentScene != null");
		}
		MScenes stage = CurrentScene.linkTo(_0024GotoStage_0024locals_0024._0024dir);
		return GotoStage(stage, new _0024GotoStage_0024closure_00243933(_0024GotoStage_0024locals_0024).Invoke);
	}

	public static MScenes GotoStage(MScenes stage, __QuestLinkRoutine_JumpStartEvent_0024callable78_002412_36__ c)
	{
		if (stage == null)
		{
			throw new AssertionFailedException("stage != null");
		}
		if (!RuntimeServices.EqualityOperator(stage, CurrentScene))
		{
			MScenes currentScene = CurrentScene;
			MarkAsVisit(stage);
			LoadStageScene(stage);
			if (c != null)
			{
				c(currentScene);
			}
		}
		return CurrentScene;
	}

	private static EnumMapLinkDir StrToMapLinkDir(string s)
	{
		try
		{
			return (EnumMapLinkDir)Enum.Parse(typeof(EnumMapLinkDir), s, ignoreCase: true);
		}
		catch (Exception)
		{
			return (EnumMapLinkDir)(-1);
		}
	}

	public static MStageBattles[] GetCurrentStageBattles()
	{
		if (CurrentScene == null)
		{
			throw new AssertionFailedException("ステージ設定(クエスト初期化)なしに敵ポップ位置取得");
		}
		return CurrentScene.AllStageBattles;
	}

	public static bool LoadStageScene(MScenes stage)
	{
		return LoadStageScene(stage, useFade: true);
	}

	public static bool LoadStageScene(MScenes stage, bool useFade)
	{
		if (stage == null)
		{
			throw new AssertionFailedException("null ステージへのロード");
		}
		int result;
		if (!RuntimeServices.EqualityOperator(CurrentScene, stage))
		{
			_DebugPrevScene = CurrentScene;
			CurrentScene = stage;
			SceneChanger.Change(stage.SceneName, useFade);
			result = 1;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public static bool IsSceneLoaded()
	{
		return SceneChanger.isSceneChanged;
	}

	private static string CurrentLoadedScene()
	{
		return SceneChanger.CurrentSceneName;
	}

	private static void communicationError(RequestBase r)
	{
		SceneChanger.ChangeTo(SceneID.Ui_World);
		GameApiResponseBase gameApiResponseBase = r as GameApiResponseBase;
		DeleteSaveData();
	}

	public static void BookkeepPlayerInfo(PlayerControl p)
	{
		_Geom.bookkeep(p);
	}

	public static void Save()
	{
		Save(succComm: true);
	}

	public static void Save(bool succComm)
	{
		SaveMain(succComm);
	}

	public static void SaveMain(bool succComm)
	{
		if (_Parameter == null || _Session == null || _Geom == null || (succComm && _Session.currentScene == null))
		{
			return;
		}
		try
		{
			_Session.finStartCommunication = succComm;
			PlayerControl playerControl = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
			if (playerControl != null)
			{
				BookkeepPlayerInfo(playerControl);
			}
			QuestSessionDataSerialize questSessionDataSerialize = new QuestSessionDataSerialize();
			byte[] array = questSessionDataSerialize.serialize(_Parameter, _Session, _Geom);
			if (array == null)
			{
				throw new AssertionFailedException("data != null");
			}
			if (ENCRYPT_QUEST_SESSION_DATA)
			{
				array = Crypt.EncryptQuest(array, GetSaveKey());
			}
			File.WriteAllBytes(SAVE_FILEPATH, array);
		}
		catch (Exception)
		{
		}
	}

	public static ContinueDataSet LoadContinueData()
	{
		ContinueDataSet continueDataSet = new ContinueDataSet();
		continueDataSet.load();
		return continueDataSet;
	}

	public static bool Continue(ContinueDataSet cd)
	{
		int result;
		if (cd == null)
		{
			result = 0;
		}
		else if (!cd.IsValid)
		{
			result = 0;
		}
		else
		{
			_Parameter = cd.Prms;
			_Session = cd.Sdata;
			_Geom = cd.Geom;
			if (!RuntimeServices.EqualityOperator(QuestManager.Instance.CurQuest, Quest))
			{
				QuestManager.Instance.CurQuest = Quest;
			}
			if (!_Session.finStartCommunication)
			{
				StartSession();
				if (_Parameter != null && _Parameter.WithServer)
				{
					result = 1;
					goto IL_0112;
				}
			}
			_IsLoaded = true;
			_State = EState.Started;
			QuestClearConditionChecker.Instance.clearCondition();
			if (_Session.ended)
			{
				if (IsPlayingFinalQuest && _Session.EndedSucceeded)
				{
					GotoEpilogueFromFinalQuest();
				}
				else
				{
					QuestClearConditionChecker.JumpToNextSceneIfNeed();
				}
			}
			else
			{
				MScenes currentScene = _Session.currentScene;
				_Session.currentScene = null;
				LoadStageScene(currentScene);
				InitializeSE();
			}
			result = 1;
		}
		goto IL_0112;
		IL_0112:
		return (byte)result != 0;
	}

	public static void Load()
	{
		ContinueDataSet continueDataSet = LoadContinueData();
		if (continueDataSet.IsLoaded)
		{
			Continue(continueDataSet);
		}
	}

	public static void DeleteSaveData()
	{
		try
		{
			File.Delete(SAVE_FILEPATH);
			RenewSaveKey();
		}
		catch (Exception)
		{
		}
	}

	public static void SetSessionSucceeded()
	{
		SetSessionEnd(0);
	}

	public static void SetSessionFailed()
	{
		SetSessionEnd(1);
	}

	public static void SetSessionTimeover()
	{
		SetSessionEnd(2);
	}

	private static void SetSessionEnd(int endStatus)
	{
		_Session.ended = true;
		_Session.endStatus = endStatus;
		Save();
	}

	public static byte[] GetSaveKey()
	{
		CypherKeyGenerator cypherKeyGenerator = CypherKeyGenerator.ForQuest();
		return cypherKeyGenerator.getSaveKey();
	}

	public static void RenewSaveKey()
	{
		CypherKeyGenerator cypherKeyGenerator = CypherKeyGenerator.ForQuest();
		cypherKeyGenerator.renewSaveKey();
	}

	public static bool IsFinalQuest(string questProgName)
	{
		bool num = !string.IsNullOrEmpty(questProgName);
		if (num)
		{
			num = questProgName.ToLower().StartsWith("story999last001");
		}
		return num;
	}

	public static void GotoEpilogueFromFinalQuest()
	{
		SetCurrentQuestClearFlag();
		InvalidateSession();
		DeleteSaveData();
		QuestInitializer.ChangeSceneFromQuest("Epilogue");
	}

	internal static void _0024StartSession_0024closure_00243924(RequestBase r)
	{
		communicationError(r);
	}

	internal static void _0024EndQuest_0024closure_00243931(ApiPresent respPresent)
	{
		if (respPresent == null)
		{
			throw new AssertionFailedException("respPresent != null");
		}
		PreEndQuestPrsentResponse = respPresent.GetResponse().PresentBox;
	}

	internal static void _0024EndQuest_0024closure_00243932(ApiQuestResult r)
	{
		if (r == null)
		{
			throw new AssertionFailedException("r != null");
		}
		LastResultResponse = r.GetResponse();
		DeleteSaveData();
		_State = EState.Closed;
		QuestClearConditionChecker.Instance.stop();
		if (r.IsSuccess)
		{
			setQuestClearFlag(Quest);
		}
		NotifyTutorialStepAtEnding(Quest);
		ApiLocalDataUpload apiLocalDataUpload = ApiLocalDataUpload.WithUserData();
		apiLocalDataUpload.Stealth = true;
		apiLocalDataUpload.ignoreAllErrors = true;
		MerlinServer.Request(apiLocalDataUpload);
	}
}
