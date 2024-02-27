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
public class QuestInitializer : MonoBehaviour
{
	[Serializable]
	internal class _0024main_0024locals_002414420
	{
		internal bool _0024ok;
	}

	[Serializable]
	internal class _0024main_0024closure_00242993
	{
		internal _0024main_0024locals_002414420 _0024_0024locals_002414959;

		public _0024main_0024closure_00242993(_0024main_0024locals_002414420 _0024_0024locals_002414959)
		{
			this._0024_0024locals_002414959 = _0024_0024locals_002414959;
		}

		public void Invoke()
		{
			_0024_0024locals_002414959._0024ok = true;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002418786 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal GameObject _0024hud_002418787;

			internal QuestAssets _0024qa_002418788;

			internal PlayerControl.BATTLE_MODE _0024bmode_002418789;

			internal PlayerPoppetCache.PlayerParams _0024prm_002418790;

			internal PlayerControl _0024playerControl_002418791;

			internal QuestMapper _0024mapper_002418792;

			internal bool _0024requirePoppets_002418793;

			internal PoppetFactory.CreatedPoppets _0024createdPoppets_002418794;

			internal RespFriendPoppet _0024friend_002418795;

			internal PoppetFactory _0024pfac_002418796;

			internal RespFriendPoppet _0024friendPoppet_002418797;

			internal IEnumerator _0024_0024sco_0024temp_00241705_002418798;

			internal IEnumerator _0024_0024sco_0024temp_00241706_002418799;

			internal GameObject _0024others_002418800;

			internal GameObject _0024_mainCamera_002418801;

			internal CameraControl _0024cameraControl_002418802;

			internal BasicCamera _0024basicCamera_002418803;

			internal IEnumerator _0024_0024sco_0024temp_00241707_002418804;

			internal bool _0024killAutoBattle_002418805;

			internal QuestBattleSessionData _0024btlSession_002418806;

			internal ApiContinue _0024capi_002418807;

			internal MQuests _0024q_002418808;

			internal int _0024coin_002418809;

			internal int _0024ndrop_002418810;

			internal IEnumerator _0024_0024sco_0024temp_00241708_002418811;

			internal BattleContinue _0024bc_002418812;

			internal PlayerDieWatcher _0024pdw_002418813;

			internal int _0024pnt_002418814;

			internal _0024main_0024locals_002414420 _0024_0024locals_002418815;

			internal QuestInitializer _0024self__002418816;

			public _0024(QuestInitializer self_)
			{
				_0024self__002418816 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024_0024locals_002418815 = new _0024main_0024locals_002414420();
						SceneChanger.Instance().dontReveal = true;
						_LastMyPosition = _0024self__002418816.transform.position;
						_0024_0024locals_002418815._0024ok = false;
						MerlinServer.EditorCommunicationInitialize(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024main_0024closure_00242993(_0024_0024locals_002418815).Invoke));
						goto case 2;
					case 2:
						if (!_0024_0024locals_002418815._0024ok)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (_instance == null)
						{
							_instance = _0024self__002418816;
							RuntimeAssetBundleDB.Instance.instantiatePrefab("ZPatch001Quest", delegate(GameObject go)
							{
								if (go != null)
								{
									_0024self__002418816.MarkAsDontDestroy(go);
								}
							});
							GameSoundManager.Instance.CurMQuest = QuestSession.Quest;
							NonQuestDontDestroyObjects.DestroyAll();
							SceneDontDestroyObject.dontDestroyOnLoad(_0024self__002418816.gameObject);
							if (_0024self__002418816.transform.parent != null)
							{
								_0024self__002418816.transform.parent = null;
							}
							_0024self__002418816.questEventHandler = ExtensionsModule.SetComponent<QuestEventHandler>(_0024self__002418816.gameObject);
							_IsInQuest = true;
							_0024hud_002418787 = GameAssetModule.InstantiatePrefab("Prefab/HUD/Battle UI Root");
							_0024self__002418816.MarkAsDontDestroy(_0024hud_002418787);
							QuestParam.Show();
							_0024qa_002418788 = QuestAssets.Instance;
							_0024self__002418816.MarkAsDontDestroy(_0024qa_002418788.gameObject);
							_0024bmode_002418789 = PlayerControl.BATTLE_MODE.Non_Battle;
							_0024prm_002418790 = new PlayerPoppetCache.PlayerParams();
							_0024prm_002418790.isBattleMode = false;
							_0024playerControl_002418791 = PlayerPoppetCache.Instance.getPlayer(_0024prm_002418790);
							PlayerPoppetCache.Instance.dontHidePlayerWhenSceneChanging();
							if (!QuestSession.IsStarted)
							{
								QuestSession.SetStartStageForEditorDirectPlay(SceneChanger.CurrentSceneName);
								_0024mapper_002418792 = (QuestMapper)UnityEngine.Object.FindObjectOfType(typeof(QuestMapper));
								if (_0024mapper_002418792 != null)
								{
									_0024mapper_002418792.remap();
								}
							}
							_0024requirePoppets_002418793 = true;
							if (QuestSession.Story != null && QuestSession.Story.IsTutorial)
							{
								_0024requirePoppets_002418793 = false;
							}
							if (QuestSession.Quest != null && QuestSession.Quest.NoPoppets)
							{
								_0024requirePoppets_002418793 = false;
							}
							_0024createdPoppets_002418794 = new PoppetFactory.CreatedPoppets();
							if (_0024requirePoppets_002418793)
							{
								_0024friend_002418795 = QuestSession.LastSessionFriend;
								_0024pfac_002418796 = PoppetFactory.Instance;
								if (_0024friend_002418795 != null)
								{
									_0024friendPoppet_002418797 = _0024friend_002418795;
									_0024_0024sco_0024temp_00241705_002418798 = _0024pfac_002418796.questPoppetsCreationRoutine(_0024friendPoppet_002418797);
									if (_0024_0024sco_0024temp_00241705_002418798 != null)
									{
										result = (Yield(3, _0024self__002418816.StartCoroutine(_0024_0024sco_0024temp_00241705_002418798)) ? 1 : 0);
										break;
									}
								}
								else
								{
									_0024_0024sco_0024temp_00241706_002418799 = _0024pfac_002418796.questPoppetsCreationRoutine(new RespPoppet(1));
									if (_0024_0024sco_0024temp_00241706_002418799 != null)
									{
										result = (Yield(4, _0024self__002418816.StartCoroutine(_0024_0024sco_0024temp_00241706_002418799)) ? 1 : 0);
										break;
									}
								}
								goto case 3;
							}
							goto IL_03e2;
						}
						UnityEngine.Object.Destroy(_0024self__002418816.gameObject);
						SceneChanger.Instance().dontReveal = false;
						goto case 1;
					case 3:
					case 4:
						_0024createdPoppets_002418794 = _0024pfac_002418796.CreationResult;
						if (_0024createdPoppets_002418794.myPoppet == null)
						{
						}
						if (_0024createdPoppets_002418794.friendPoppet == null)
						{
						}
						if (_0024createdPoppets_002418794.friendPoppet != null)
						{
							_0024others_002418800 = _0024createdPoppets_002418794.friendPoppet.gameObject;
							_0024self__002418816.MarkAsDontDestroy(_0024others_002418800);
						}
						goto IL_03e2;
					case 5:
						if (!_0024playerControl_002418791.IsReady)
						{
							result = (YieldDefault(5) ? 1 : 0);
							break;
						}
						_0024playerControl_002418791.clearPoppets();
						if (_0024createdPoppets_002418794.myPoppet != null)
						{
							_0024playerControl_002418791.addPoppet(_0024createdPoppets_002418794.myPoppet);
						}
						if (_0024createdPoppets_002418794.friendPoppet != null)
						{
							_0024playerControl_002418791.addPoppet(_0024createdPoppets_002418794.friendPoppet);
						}
						_0024playerControl_002418791.recalcParametersFromWeaponsAndPoppets();
						if (QuestSession.IsLoaded)
						{
							QuestSession.GeomSession.restore(_0024playerControl_002418791);
							goto IL_0585;
						}
						_0024_0024sco_0024temp_00241707_002418804 = _0024self__002418816.getPlayerPosition();
						if (_0024_0024sco_0024temp_00241707_002418804 != null)
						{
							result = (Yield(6, _0024self__002418816.StartCoroutine(_0024_0024sco_0024temp_00241707_002418804)) ? 1 : 0);
							break;
						}
						goto case 6;
					case 6:
						_0024playerControl_002418791.transform.position = _0024self__002418816.initialPlayerPosition;
						SetPoppetInitialPosition(_0024playerControl_002418791.Poppets, _0024self__002418816.initialPlayerPosition);
						goto IL_0585;
					case 7:
						result = (Yield(8, UnloadResource.UnloadUnusedAssets()) ? 1 : 0);
						break;
					case 8:
						if (QuestSession.HasBattleStoppedData)
						{
							_0024btlSession_002418806 = QuestSession.BattleSessionData;
							goto case 9;
						}
						goto IL_06e8;
					case 9:
						if (!_0024self__002418816.isMapperReady())
						{
							result = (YieldDefault(9) ? 1 : 0);
							break;
						}
						QuestBattleStarter.LoadAndStart(_0024btlSession_002418806, _0024playerControl_002418791);
						if (QuestSession.IsBattleStoppedBeforeContinue)
						{
							_0024playerControl_002418791.playDead();
							goto IL_06e8;
						}
						_0024capi_002418807 = new ApiContinue();
						_0024capi_002418807.ApiKey = _0024btlSession_002418806.continueApiKey;
						MerlinServer.Request(_0024capi_002418807);
						goto case 10;
					case 10:
						if (!_0024capi_002418807.IsEnd)
						{
							result = (YieldDefault(10) ? 1 : 0);
							break;
						}
						if (_0024capi_002418807.IsOk)
						{
							BattleContinue.ReviveForBattleContinue(_0024playerControl_002418791);
						}
						else
						{
							ErrorDialog.FatalError("精霊石が足りません。タイトルに戻ります。", "通信エラー", jumpBoot: true, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38___00242.Adapt(delegate
							{
								SceneChanger.Instance().dontReveal = false;
								ChangeSceneFromQuest("Boot");
							}));
						}
						goto IL_06e8;
					case 11:
						if (_0024cameraControl_002418802 != null)
						{
							_0024cameraControl_002418802.setAreaParameter(SceneChanger.CurrentSceneName);
						}
						if (!_0024q_002418808.HasSceneOfStartCutScene)
						{
							goto IL_082b;
						}
						_0024self__002418816.destroyMe();
						QuestSession.LoadStageScene(_0024q_002418808.StartSceneId, useFade: true);
						goto case 1;
					case 12:
						if (!SceneChanger.isSceneChanged && !SceneChanger.isCompletelyReady)
						{
							result = (YieldDefault(12) ? 1 : 0);
							break;
						}
						ShadowSelector.Setup(_0024playerControl_002418791.gameObject);
						if (_0024createdPoppets_002418794.myPoppet != null)
						{
							ShadowSelector.Setup(_0024createdPoppets_002418794.myPoppet.gameObject);
						}
						if (_0024createdPoppets_002418794.friendPoppet != null)
						{
							ShadowSelector.Setup(_0024createdPoppets_002418794.friendPoppet.gameObject);
						}
						if (QuestSession.IsContinuableQuest)
						{
							_0024bc_002418812 = ExtensionsModule.SetComponent<BattleContinue>(_0024self__002418816.gameObject);
							_0024bc_002418812.Player = _0024playerControl_002418791;
						}
						if (QuestSession.IsFailIfDead)
						{
							_0024pdw_002418813 = ExtensionsModule.SetComponent<PlayerDieWatcher>(_0024self__002418816.gameObject);
						}
						ResourceClearner.CleanUpForQuest();
						result = (Yield(13, UnloadResource.UnloadUnusedAssets()) ? 1 : 0);
						break;
					case 13:
						QuestClearConditionChecker.Instance.unpauseTimer();
						SceneChanger.Instance().dontReveal = false;
						if (QuestSession.IsLoaded && _0024q_002418808 != null && _0024q_002418808.IsChallenge)
						{
							_0024pnt_002418814 = QuestSession.KeyItemPoint;
							BattleHUDQuestCondition.dispChallengeRankingPoint(_0024pnt_002418814);
						}
						QuestSession.LoadSEInPlay(_0024playerControl_002418791);
						if (_0024q_002418808.HasSceneOfStartCutScene)
						{
							_0024playerControl_002418791.AutoFlowController.ProcessEvent();
						}
						_0024playerControl_002418791.AutoFlowController.startFlow(QuestSession.Quest);
						_IsInPlay = true;
						if (QuestSession.IsLoaded)
						{
							PlayerEventDispatcher.InvokeQuestRestart(_0024playerControl_002418791);
						}
						else
						{
							PlayerEventDispatcher.InvokeQuestStart(_0024playerControl_002418791);
						}
						YieldDefault(1);
						goto case 1;
					case 1:
						{
							result = 0;
							break;
						}
						IL_0585:
						_0024playerControl_002418791.initPoppetHUD();
						_0024killAutoBattle_002418805 = false;
						if (QuestSession.Quest != null && QuestSession.Quest.QuestType == EnumQuestTypes.RaidTutorial)
						{
							_0024killAutoBattle_002418805 = true;
						}
						if (_0024killAutoBattle_002418805)
						{
							_0024playerControl_002418791.forceSetAutoBattle(active: false);
							BattleHUDAutoBattle.Activate(b: false);
						}
						result = (YieldDefault(7) ? 1 : 0);
						break;
						IL_03e2:
						_0024_mainCamera_002418801 = _0024self__002418816.CreateGameObject(_0024self__002418816.mainCamera);
						_0024cameraControl_002418802 = _0024_mainCamera_002418801.GetComponent<CameraControl>();
						_0024basicCamera_002418803 = _0024_mainCamera_002418801.GetComponent<BasicCamera>();
						if (_0024basicCamera_002418803 != null)
						{
							_0024cameraControl_002418802.target = _0024playerControl_002418791.transform;
						}
						if (_0024cameraControl_002418802 != null)
						{
							_0024cameraControl_002418802.setAreaParameter(SceneChanger.CurrentSceneName);
						}
						goto case 5;
						IL_06e8:
						IconAtlasPool.UnloadWeaponPoppet();
						_0024q_002418808 = QuestSession.Quest;
						if (QuestSession.IsLoaded)
						{
							_0024coin_002418809 = QuestSession.EarnedCoin + QuestSession.EarnedDummyCoin;
							QuestParam.SetEarnedCoinNum(_0024coin_002418809);
							_0024ndrop_002418810 = QuestSession.EarnedTreasureNum + QuestSession.EarnedDummyTreasureNum;
							QuestParam.SetEarnedTreasureNum(_0024ndrop_002418810);
						}
						else if (_0024q_002418808 != null && !MQuestsUtil.MustPlayStartCutScene(_0024q_002418808))
						{
							QuestSession.Save();
						}
						if (QuestSession.IsLoaded || QuestSession.WasPlayedOpeningCutScene || _0024q_002418808 == null || !MQuestsUtil.MustPlayStartCutScene(_0024q_002418808))
						{
							goto IL_082b;
						}
						QuestSession.PlayedOpeningCutScene();
						_0024_0024sco_0024temp_00241708_002418811 = _0024self__002418816.playOpeningCutScene(_0024q_002418808);
						if (_0024_0024sco_0024temp_00241708_002418811 != null)
						{
							result = (Yield(11, _0024self__002418816.StartCoroutine(_0024_0024sco_0024temp_00241708_002418811)) ? 1 : 0);
							break;
						}
						goto case 11;
						IL_082b:
						if (_0024cameraControl_002418802 != null)
						{
							_0024cameraControl_002418802.fieldCameraUpdate(withInterpol: false);
						}
						_0024self__002418816.masterEffectPack = MasterEffectPack.Instance;
						goto case 12;
					}
				}
				return (byte)result != 0;
			}
		}

		internal QuestInitializer _0024self__002418817;

		public _0024main_002418786(QuestInitializer self_)
		{
			_0024self__002418817 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024self__002418817);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024playOpeningCutScene_002418818 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal QuestCutscenePlayer _0024mainRoutine_002418819;

			internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024readyCB_002418820;

			internal IEnumerator _0024_0024sco_0024temp_00241709_002418821;

			internal MQuests _0024q_002418822;

			internal QuestInitializer _0024self__002418823;

			public _0024(MQuests q, QuestInitializer self_)
			{
				_0024q_002418822 = q;
				_0024self__002418823 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024q_002418822 == null || !MQuestsUtil.MustPlayStartCutScene(_0024q_002418822))
					{
						throw new AssertionFailedException("(q != null) and MQuestsUtil.MustPlayStartCutScene(q)");
					}
					_0024mainRoutine_002418819 = QuestCutscenePlayer.Instance;
					_0024readyCB_002418820 = delegate
					{
						SceneChanger.Instance().dontReveal = false;
					};
					_0024_0024sco_0024temp_00241709_002418821 = _0024mainRoutine_002418819.playCutScene(_0024q_002418822.StartCutScene, _0024readyCB_002418820);
					if (_0024_0024sco_0024temp_00241709_002418821 != null)
					{
						result = (Yield(2, _0024self__002418823.StartCoroutine(_0024_0024sco_0024temp_00241709_002418821)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MQuests _0024q_002418824;

		internal QuestInitializer _0024self__002418825;

		public _0024playOpeningCutScene_002418818(MQuests q, QuestInitializer self_)
		{
			_0024q_002418824 = q;
			_0024self__002418825 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024q_002418824, _0024self__002418825);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024getPlayerPosition_002418826 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal MQuests _0024q_002418827;

			internal MScenes _0024curScn_002418828;

			internal QuestMapper _0024mapper_002418829;

			internal MScenes _0024mscn_002418830;

			internal EnumMapLinkDir _0024e_002418831;

			internal GameObject _0024obj_002418832;

			internal IEnumerator _0024_0024iterator_002413698_002418833;

			internal QuestInitializer _0024self__002418834;

			public _0024(QuestInitializer self_)
			{
				_0024self__002418834 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002418834.initialPlayerPosition = _0024self__002418834.transform.position;
					_0024q_002418827 = QuestSession.Quest;
					if (_0024q_002418827 != null)
					{
						_0024curScn_002418828 = QuestSession.CurrentScene;
						if (!string.IsNullOrEmpty(_0024q_002418827.StartPosition) && RuntimeServices.EqualityOperator(_0024q_002418827.StartSceneId, _0024curScn_002418828))
						{
							_0024self__002418834.initialPlayerPosition = MasterUtil.StrToPos(_0024q_002418827.StartPosition);
						}
						if (QuestSession.IsDebugDirectSceneStartMode && QuestSession.IsStarted && _0024curScn_002418828 != null)
						{
							_0024mapper_002418829 = (QuestMapper)UnityEngine.Object.FindObjectOfType(typeof(QuestMapper));
							if (!(_0024mapper_002418829 == null))
							{
								goto case 2;
							}
						}
					}
					goto case 1;
				case 2:
					if (!_0024mapper_002418829.Initialized)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024mscn_002418830 = QuestSession.CurrentScene;
					_0024_0024iterator_002413698_002418833 = Enum.GetValues(typeof(EnumMapLinkDir)).GetEnumerator();
					while (true)
					{
						if (_0024_0024iterator_002413698_002418833.MoveNext())
						{
							_0024e_002418831 = (EnumMapLinkDir)_0024_0024iterator_002413698_002418833.Current;
							if (_0024mscn_002418830.linkTo(_0024e_002418831) != null && !_0024mscn_002418830.isBlocked(_0024e_002418831))
							{
								_0024obj_002418832 = _0024mapper_002418829.GetPositionObject(_0024e_002418831);
								if (_0024obj_002418832 != null)
								{
									_0024self__002418834.initialPlayerPosition = _0024obj_002418832.transform.position;
									break;
								}
							}
							continue;
						}
						YieldDefault(1);
						break;
					}
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal QuestInitializer _0024self__002418835;

		public _0024getPlayerPosition_002418826(QuestInitializer self_)
		{
			_0024self__002418835 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002418835);
		}
	}

	[NonSerialized]
	private const string HUD_PREFAB = "Prefab/HUD/Battle UI Root";

	[NonSerialized]
	private const float INITIAL_POPPET_POSITION_XZ_RANGE = 2f;

	[NonSerialized]
	private static bool _IsInQuest;

	[NonSerialized]
	private static bool _IsInPlay;

	[NonSerialized]
	private static Vector3 _LastMyPosition;

	public GameObject mainCamera;

	public GameObject castLightShadow;

	private Boo.Lang.List<GameObject> createGameObjects;

	private readonly int CREATE_GAMEOBJECT_NUM;

	[NonSerialized]
	private static QuestInitializer _instance;

	private Vector3 initialPlayerPosition;

	private QuestEventHandler questEventHandler;

	private MasterEffectPack masterEffectPack;

	public static bool IsInQuest => _IsInQuest;

	public static bool IsInPlay => _IsInPlay;

	public static Vector3 LastMyPosition => _LastMyPosition;

	public QuestInitializer()
	{
		createGameObjects = new Boo.Lang.List<GameObject>();
		CREATE_GAMEOBJECT_NUM = 9;
	}

	public static bool IsInQuestScene(string questSceneName)
	{
		MScenes currentScene = QuestSession.CurrentScene;
		int result;
		if (!IsInQuest || string.IsNullOrEmpty(questSceneName))
		{
			result = 0;
		}
		else
		{
			string text = questSceneName.ToLower();
			result = ((currentScene != null && !string.IsNullOrEmpty(currentScene.Progname) && text == currentScene.Progname.ToLower()) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public void Awake()
	{
	}

	public void Start()
	{
		StartCoroutine(main());
	}

	public void Update()
	{
		if (questEventHandler != null)
		{
			questEventHandler.updatePlayTime(Time.deltaTime);
		}
	}

	public void OnDestroy()
	{
	}

	private IEnumerator main()
	{
		return new _0024main_002418786(this).GetEnumerator();
	}

	private bool isMapperReady()
	{
		int num = 0;
		QuestMapper[] array = (QuestMapper[])UnityEngine.Object.FindObjectsOfType(typeof(QuestMapper));
		int length = array.Length;
		int result;
		while (true)
		{
			if (num < length)
			{
				if (!array[num].Initialized)
				{
					result = 0;
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	private IEnumerator playOpeningCutScene(MQuests q)
	{
		return new _0024playOpeningCutScene_002418818(q, this).GetEnumerator();
	}

	private void setPoppetInitialPosition(AIControl[] poppets)
	{
		SetPoppetInitialPosition(poppets, transform.position);
	}

	public static void SetPoppetInitialPosition(AIControl[] poppets, Vector3 basePos)
	{
		if (poppets == null)
		{
			return;
		}
		int num = 0;
		int length = poppets.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			AIControl aIControl = poppets[RuntimeServices.NormalizeArrayIndex(poppets, index)];
			if (aIControl != null)
			{
				Vector3 poppetRandomPosition = GetPoppetRandomPosition(basePos);
				poppetRandomPosition = new Vector3(poppetRandomPosition.x, poppetRandomPosition.y + 0.8f, poppetRandomPosition.z);
				aIControl.transform.position = poppetRandomPosition;
			}
		}
	}

	private static Vector3 GetPoppetRandomPosition(Vector3 pos)
	{
		float num = 2f;
		Vector3 vector = new Vector3(UnityEngine.Random.Range(0f - num, num), 0f, UnityEngine.Random.Range(0f - num, num));
		return BattleUtil.AdjustYpos(pos + vector);
	}

	private void destroyMe()
	{
		IEnumerator<GameObject> enumerator = createGameObjects.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				GameObject current = enumerator.Current;
				string text = new StringBuilder().Append(current).ToString();
				try
				{
					if (current != null)
					{
						UnityEngine.Object.Destroy(current);
					}
				}
				catch (Exception)
				{
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		createGameObjects.Clear();
		UnityEngine.Object.Destroy(gameObject);
		if (_instance == this)
		{
			_IsInQuest = false;
			_IsInPlay = false;
			_instance = null;
		}
	}

	private GameObject CreateGameObject(GameObject obj)
	{
		object result;
		if (!(obj == null))
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(obj);
			gameObject.name = obj.name;
			result = MarkAsDontDestroy(gameObject);
		}
		else
		{
			result = null;
		}
		return (GameObject)result;
	}

	private GameObject MarkAsDontDestroy(GameObject obj)
	{
		SceneDontDestroyObject.dontDestroyOnLoad(obj);
		createGameObjects.Add(obj);
		return obj;
	}

	public static void ChangeSceneFromQuest(string scene)
	{
		DisposeAll();
		SceneChanger.Change(scene);
	}

	public static void DisposeAll()
	{
		int i = 0;
		QuestInitializer[] array = (QuestInitializer[])UnityEngine.Object.FindObjectsOfType(typeof(QuestInitializer));
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			array[i].destroyMe();
		}
		QuestClearConditionChecker.Instance.pauseTimer();
		IconAtlasPool.UnloadAll();
		RuntimeAssetBundleDB.Instance.unloadAll();
		AssetBundleLoader.DestroyAll();
		QuestAssets.Unload();
		SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
		if (instance != null)
		{
			instance.UnloadSeType(6);
			instance.UnloadSeType(7);
			instance.UnloadSeType(1);
			instance.UnloadSeType(2);
		}
		PlayerPoppetCache.Instance.hidePlayerWhenSceneChanging();
		PlayerPoppetCache.Instance.hideAll();
	}

	private IEnumerator getPlayerPosition()
	{
		return new _0024getPlayerPosition_002418826(this).GetEnumerator();
	}

	internal void _0024main_0024closure_00242994(GameObject go)
	{
		if (go != null)
		{
			MarkAsDontDestroy(go);
		}
	}

	internal void _0024main_0024closure_00243011()
	{
		SceneChanger.Instance().dontReveal = false;
		ChangeSceneFromQuest("Boot");
	}

	internal void _0024playOpeningCutScene_0024readyCB_00243719()
	{
		SceneChanger.Instance().dontReveal = false;
	}
}
