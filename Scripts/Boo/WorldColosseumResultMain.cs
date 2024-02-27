using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class WorldColosseumResultMain : UIMain
{
	[Serializable]
	private enum Mode
	{
		RankChange,
		RankUpReward,
		Result,
		Ranking,
		EventReward,
		ResultShortcut,
		Detail,
		End
	}

	[Serializable]
	public class RankWindow
	{
		public GameObject root;

		public UISprite rankSprite;

		public UILabelBase messageLabel;
	}

	[Serializable]
	internal class _0024PopupRewards_0024locals_002414561
	{
		internal RespReward[] _0024rewards;

		internal Mode _0024nextMode;
	}

	[Serializable]
	internal class _0024PopupRewards_0024coroutine_00245149
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002422177 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal RespReward _0024reward_002422178;

				internal int _0024_002411825_002422179;

				internal RespReward[] _0024_002411826_002422180;

				internal int _0024_002411827_002422181;

				internal _0024PopupRewards_0024coroutine_00245149 _0024self__002422182;

				public _0024(_0024PopupRewards_0024coroutine_00245149 self_)
				{
					_0024self__002422182 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					checked
					{
						switch (_state)
						{
						default:
							_0024_002411825_002422179 = 0;
							_0024_002411826_002422180 = _0024self__002422182._0024_0024locals_002415249._0024rewards;
							_0024_002411827_002422181 = _0024_002411826_002422180.Length;
							goto IL_014d;
						case 2:
							if (!_0024self__002422182._0024this_002415248.closePopup)
							{
								result = (YieldDefault(2) ? 1 : 0);
								break;
							}
							_0024self__002422182._0024this_002415248.popupEffect.SetActive(value: false);
							_0024_002411825_002422179++;
							goto IL_014d;
						case 1:
							{
								result = 0;
								break;
							}
							IL_014d:
							if (_0024_002411825_002422179 < _0024_002411827_002422181)
							{
								_0024self__002422182._0024this_002415248.closePopup = false;
								UIAutoTweenerStandAloneEx.In(_0024self__002422182._0024this_002415248.rewardWindow);
								_0024self__002422182._0024this_002415248.rewardPopup.SetRespRewards(RewardPopupWindow.Type.rewardTypeNormal, new RespReward[1] { _0024_002411826_002422180[_0024_002411825_002422179] }, _0024_002411826_002422180[_0024_002411825_002422179].Title, _0024_002411826_002422180[_0024_002411825_002422179].Message, _0024self__002422182._0024this_002415248.callbackShowDetail);
								_0024self__002422182._0024this_002415248.popupEffect.SetActive(value: true);
								GameSoundManager.PlaySe(_0024self__002422182._0024this_002415248.se_get_item, 0);
								goto case 2;
							}
							_0024self__002422182._0024this_002415248.mode = _0024self__002422182._0024_0024locals_002415249._0024nextMode;
							YieldDefault(1);
							goto case 1;
						}
					}
					return (byte)result != 0;
				}
			}

			internal _0024PopupRewards_0024coroutine_00245149 _0024self__002422183;

			public _0024Invoke_002422177(_0024PopupRewards_0024coroutine_00245149 self_)
			{
				_0024self__002422183 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002422183);
			}
		}

		internal WorldColosseumResultMain _0024this_002415248;

		internal _0024PopupRewards_0024locals_002414561 _0024_0024locals_002415249;

		public _0024PopupRewards_0024coroutine_00245149(WorldColosseumResultMain _0024this_002415248, _0024PopupRewards_0024locals_002414561 _0024_0024locals_002415249)
		{
			this._0024this_002415248 = _0024this_002415248;
			this._0024_0024locals_002415249 = _0024_0024locals_002415249;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002422177(this).GetEnumerator();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024WaitTouch_002422156 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_sec_0024temp_00242669_002422157;

			internal float _0024sec_002422158;

			internal WorldColosseumResultMain _0024self__002422159;

			public _0024(float sec, WorldColosseumResultMain self_)
			{
				_0024sec_002422158 = sec;
				_0024self__002422159 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002422159.SetScreenTouch(b: false);
					_0024_0024wait_sec_0024temp_00242669_002422157 = _0024sec_002422158;
					goto case 2;
				case 2:
					if (_0024_0024wait_sec_0024temp_00242669_002422157 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242669_002422157 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002422159.SetScreenTouch(b: true);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024sec_002422160;

		internal WorldColosseumResultMain _0024self__002422161;

		public _0024WaitTouch_002422156(float sec, WorldColosseumResultMain self_)
		{
			_0024sec_002422160 = sec;
			_0024self__002422161 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024sec_002422160, _0024self__002422161);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024StartConnection_002422162 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal WorldColosseumResultMain _0024self__002422163;

			public _0024(WorldColosseumResultMain self_)
			{
				_0024self__002422163 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__002422163.debugDontConnection)
					{
						throw new AssertionFailedException("通信しない設定ですが通信しようとしました.");
					}
					_0024self__002422163.colosseumSession.closeSession();
					goto case 2;
				case 2:
					if (_0024self__002422163.colosseumSession.IsClosing)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002422163.FinishRequest(_0024self__002422163.colosseumSession.Result);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal WorldColosseumResultMain _0024self__002422164;

		public _0024StartConnection_002422162(WorldColosseumResultMain self_)
		{
			_0024self__002422164 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002422164);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024SceneStart_0024loading_00245144_002422165 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal __PlayerControl_loadMotionPack_0024callable170_00241237_13__ _0024load_002422166;

			internal IEnumerator _0024_0024sco_0024temp_00242672_002422167;

			internal IEnumerator _0024_0024sco_0024temp_00242673_002422168;

			internal IEnumerator _0024_0024sco_0024temp_00242674_002422169;

			internal WorldColosseumResultMain _0024self__002422170;

			public _0024(WorldColosseumResultMain self_)
			{
				_0024self__002422170 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024load_002422166 = (string se) => new _0024_0024_0024SceneStart_0024loading_00245144_0024load_00245145_002422172(se).GetEnumerator();
					_0024_0024sco_0024temp_00242672_002422167 = _0024load_002422166(_0024self__002422170.se_rankUp);
					if (_0024_0024sco_0024temp_00242672_002422167 != null)
					{
						result = (Yield(2, _0024self__002422170.StartCoroutine(_0024_0024sco_0024temp_00242672_002422167)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					_0024_0024sco_0024temp_00242673_002422168 = _0024load_002422166(_0024self__002422170.se_rankDown);
					if (_0024_0024sco_0024temp_00242673_002422168 != null)
					{
						result = (Yield(3, _0024self__002422170.StartCoroutine(_0024_0024sco_0024temp_00242673_002422168)) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					_0024_0024sco_0024temp_00242674_002422169 = _0024load_002422166(_0024self__002422170.se_get_item);
					if (_0024_0024sco_0024temp_00242674_002422169 != null)
					{
						result = (Yield(4, _0024self__002422170.StartCoroutine(_0024_0024sco_0024temp_00242674_002422169)) ? 1 : 0);
						break;
					}
					goto case 4;
				case 4:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal WorldColosseumResultMain _0024self__002422171;

		public _0024_0024SceneStart_0024loading_00245144_002422165(WorldColosseumResultMain self_)
		{
			_0024self__002422171 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422171);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024_0024SceneStart_0024loading_00245144_0024load_00245145_002422172 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_until_0024temp_00242670_002422173;

			internal float _0024_0024wait_until_0024temp_00242671_002422174;

			internal string _0024se_002422175;

			public _0024(string se)
			{
				_0024se_002422175 = se;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					GameSoundManager.Instance.LoadSe(_0024se_002422175);
					_0024_0024wait_until_0024temp_00242670_002422173 = 3f;
					_0024_0024wait_until_0024temp_00242671_002422174 = Time.realtimeSinceStartup;
					goto case 2;
				case 2:
					if (!SQEX_SoundPlayer.Instance.IsLoadSe(_0024se_002422175) && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00242671_002422174 < _0024_0024wait_until_0024temp_00242670_002422173)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
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

		internal string _0024se_002422176;

		public _0024_0024_0024SceneStart_0024loading_00245144_0024load_00245145_002422172(string se)
		{
			_0024se_002422176 = se;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024se_002422176);
		}
	}

	public bool debugDontConnection;

	public bool debugShowResultShortcut;

	private Mode mode;

	private Mode lastMode;

	private Mode prevMode;

	public float waitTime;

	public GameObject screenTouch;

	public GameObject winTitle;

	public GameObject loseTitle;

	public UISprite rankSprite;

	public UILabelBase getBreederPointLabel;

	public UILabelBase needBreederPointLabel;

	public UILabelBase allBreederPointLabel;

	public UILabelBase coinLabel;

	public UILabelBase fpLabel;

	public UILabelBase manaLabel;

	public RankWindow rankUpWindow;

	public RankWindow rankDownWindow;

	private RankWindow currentWindow;

	public GameObject rankUpEffect;

	public GameObject rankDownEffect;

	private readonly string se_rankUp;

	private readonly string se_rankDown;

	private readonly string se_get_item;

	public GameObject rewardWindow;

	private RewardPopupWindow rewardPopup;

	private RespBreeder cacheBreeder;

	private ColosseumSession colosseumSession;

	private RespColosseumBattleResult _cacheLastResult;

	public GameObject weaponDetailPrefab;

	public GameObject poppetDetailPrefab;

	public Transform detailParent;

	private GameObject currentDetail;

	private WeaponInfo weaponDetailInfo;

	private MuppetInfo poppetDetailInfo;

	public GameObject popupEffect;

	public UILabelBase getEventPointLabel;

	public UILabelBase needEventPointLabel;

	public UILabelBase allEventPointLabel;

	private bool closePopup;

	private RespColosseumBattleResult lastResult => _cacheLastResult;

	public WorldColosseumResultMain()
	{
		debugDontConnection = true;
		waitTime = 1f;
		se_rankUp = "se_arena_promote";
		se_rankDown = "se_arena_demote";
		se_get_item = "se_system_new_item";
	}

	private void SetScreenTouch(bool b)
	{
		screenTouch.SetActive(b);
	}

	private IEnumerator WaitTouch(float sec)
	{
		return new _0024WaitTouch_002422156(sec, this).GetEnumerator();
	}

	public override void SceneAwake()
	{
		debugDontConnection = false;
		debugShowResultShortcut = false;
		ResultShortcut.Activate(activate: false);
		SetScreenTouch(b: false);
	}

	public override void SceneStart()
	{
		mode = Mode.End;
		lastMode = Mode.End;
		SceneTitleHUD.UpdateTitle(MTexts.Msg("$COLOSSEUM_RESULT_TITLE"));
		InfomationBarHUD.UpdateText(MTexts.Msg("$COLOSSEUM_RESULT_INFO"));
		UIAutoTweenerStandAloneEx.Hide(rankUpWindow.root);
		UIAutoTweenerStandAloneEx.Hide(rankDownWindow.root);
		UIAutoTweenerStandAloneEx.Hide(rewardWindow);
		rewardPopup = rewardWindow.GetComponentsInChildren<RewardPopupWindow>(includeInactive: true).FirstOrDefault();
		weaponDetailInfo = CreateDetail<WeaponInfo>(weaponDetailPrefab);
		poppetDetailInfo = CreateDetail<MuppetInfo>(poppetDetailPrefab);
		rankUpEffect.SetActive(value: false);
		rankDownEffect.SetActive(value: false);
		popupEffect.SetActive(value: false);
		__GouseiSequense_S540_init_0024callable40_002410_5__ loadingRoutine = () => new _0024_0024SceneStart_0024loading_00245144_002422165(this).GetEnumerator();
		SetLoadingRoutine(loadingRoutine);
		MerlinServer.EditorCommunicationInitialize((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			Initialize();
		});
	}

	private void OnDestroy()
	{
		GameSoundManager.Instance.UnloadSe(se_rankUp);
		GameSoundManager.Instance.UnloadSe(se_rankDown);
		GameSoundManager.Instance.UnloadSe(se_get_item);
	}

	private void Initialize()
	{
		if (debugDontConnection)
		{
			cacheBreeder = debugCreateResult().Breeder;
			colosseumSession = null;
			FinishRequest(debugCreateResult());
			return;
		}
		cacheBreeder = UserData.Current.userBreeder;
		colosseumSession = ColosseumSession.Instance;
		IEnumerator enumerator = StartConnection();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private T CreateDetail<T>(GameObject prefab) where T : Component
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(prefab);
		gameObject.transform.parent = detailParent;
		gameObject.transform.localPosition = new Vector3(0f, 0f, -200f);
		gameObject.transform.localScale = Vector3.one;
		gameObject.SetActive(value: false);
		return gameObject.GetComponent<T>();
	}

	private RespColosseumBattleResult debugCreateResult()
	{
		RespBreeder respBreeder = new RespBreeder();
		respBreeder.Loss = 100;
		respBreeder.Win = 100;
		respBreeder.BreederRankPoint = 124567890L;
		checked
		{
			respBreeder.BreederRankId = unchecked(UnityEngine.Random.Range(0, 1024) % 4) + 1;
			RespColosseumEvent respColosseumEvent = new RespColosseumEvent();
			respColosseumEvent.Id = 1;
			respColosseumEvent.IsFriendCompetition = false;
			respColosseumEvent.FriendPoint = 124567890;
			respColosseumEvent.Coin = 124567890;
			respColosseumEvent.BpCost = 1;
			respColosseumEvent.ManaFragment = 124567890;
			respColosseumEvent.IsRankingEvent = true;
			respColosseumEvent.MItemGroupId = 1;
			respColosseumEvent.IsCostLimit = false;
			respColosseumEvent.IsElementLimit = false;
			respColosseumEvent.IsStyleLimit = false;
			respColosseumEvent.IsMinRarityLimit = false;
			respColosseumEvent.IsMaxRarityLimit = false;
			respColosseumEvent.IsMaxRarityLimit = false;
			respColosseumEvent.CostLimit = 0;
			respColosseumEvent.ElementLimit = 0;
			respColosseumEvent.StyleLimit = 0;
			respColosseumEvent.MinRarityLimit = 0;
			respColosseumEvent.MaxRarityLimit = 0;
			RespColosseumEventRanking respColosseumEventRanking = new RespColosseumEventRanking();
			respColosseumEventRanking.MColosseumEventId = 1;
			respColosseumEventRanking.TSocialPlayerId = UserData.Current.TSocialPlayerId;
			respColosseumEventRanking.Ranking = 9999;
			respColosseumEventRanking.RankingPoint = 124567890.0;
			RespColosseumBattleResult respColosseumBattleResult = new RespColosseumBattleResult();
			respColosseumBattleResult.Breeder = respBreeder;
			respColosseumBattleResult.ColosseumEvent = respColosseumEvent;
			respColosseumBattleResult.ColosseumEventRanking = respColosseumEventRanking;
			respColosseumBattleResult.PresentBox = null;
			respColosseumBattleResult.BreederRankPoint = 10000L;
			respColosseumBattleResult.BreederRankRewards = debugRewardJson();
			respColosseumBattleResult.ColosseumEventTotalRankingPoint = 124567890.0;
			respColosseumBattleResult.EventRankRewards = debugRewardJson();
			respColosseumBattleResult.Coin = 124567890;
			respColosseumBattleResult.FriendPoint = 124567890;
			respColosseumBattleResult.ManaFragment = 124567890;
			respColosseumBattleResult.ColosseumEventTotalRankingPoint = 124567890.0;
			return respColosseumBattleResult;
		}
	}

	private bool IsWin()
	{
		int num = 2;
		if (!debugDontConnection)
		{
			num = colosseumSession.BattleResult.gameResult;
		}
		return num switch
		{
			2 => true, 
			3 => false, 
			_ => false, 
		};
	}

	private void FinishRequest(RespColosseumBattleResult result)
	{
		_cacheLastResult = result;
		winTitle.SetActive(IsWin());
		loseTitle.SetActive(!IsWin());
		__DeckColosseum_SetLimitIcon_0024callable92_0024194_113__ _DeckColosseum_SetLimitIcon_0024callable92_0024194_113__ = (int i) => i.ToString("#,#,#,#,0");
		checked
		{
			__WorldColosseumResultMain_FinishRequest_0024callable189_0024241_13__ _WorldColosseumResultMain_FinishRequest_0024callable189_0024241_13__ = (double d) => ((long)d).ToString("#,#,#,#,0");
			MBreederRanks mBreederRanks = MBreederRanks.Get(result.Breeder.BreederRankId);
			UIBasicUtility.SetBreederRankSprite(rankSprite, result.Breeder);
			UIBasicUtility.SetLabel(getBreederPointLabel, _DeckColosseum_SetLimitIcon_0024callable92_0024194_113__((int)result.BreederRankPoint), show: true);
			UIBasicUtility.SetLabel(allBreederPointLabel, _DeckColosseum_SetLimitIcon_0024callable92_0024194_113__((int)result.Breeder.BreederRankPoint), show: true);
			string text = MTexts.Get("$COLOSSEUM_RESULT_RANK_MAX").ToString();
			MBreederRanks nextRank = MBreederRanks.GetNextRank(result.Breeder.BreederRankId);
			if (nextRank != null)
			{
				text = _DeckColosseum_SetLimitIcon_0024callable92_0024194_113__((int)((long)nextRank.NecessaryPoint - result.Breeder.BreederRankPoint));
			}
			UIBasicUtility.SetLabel(needBreederPointLabel, text, show: true);
			if (NowRankingEvent())
			{
				UIBasicUtility.SetLabel(coinLabel, _DeckColosseum_SetLimitIcon_0024callable92_0024194_113__(result.ColosseumEvent.Coin), show: true);
				UIBasicUtility.SetLabel(fpLabel, _DeckColosseum_SetLimitIcon_0024callable92_0024194_113__(result.ColosseumEvent.FriendPoint), show: true);
				UIBasicUtility.SetLabel(manaLabel, _DeckColosseum_SetLimitIcon_0024callable92_0024194_113__(result.ColosseumEvent.ManaFragment), show: true);
				double colosseumEventTotalRankingPoint = result.ColosseumEventTotalRankingPoint;
				UIBasicUtility.SetLabel(allEventPointLabel, _WorldColosseumResultMain_FinishRequest_0024callable189_0024241_13__(colosseumEventTotalRankingPoint), show: true);
				double colosseumEventRankPoint = result.ColosseumEventRankPoint;
				UIBasicUtility.SetLabel(getEventPointLabel, _WorldColosseumResultMain_FinishRequest_0024callable189_0024241_13__(colosseumEventRankPoint), show: true);
				double d2 = result.ColosseumEventNeedToNextNormaRankPoint;
				UIBasicUtility.SetLabel(needEventPointLabel, _WorldColosseumResultMain_FinishRequest_0024callable189_0024241_13__(d2), show: true);
			}
			else
			{
				UIBasicUtility.SetLabel(coinLabel, _DeckColosseum_SetLimitIcon_0024callable92_0024194_113__(result.Coin), show: true);
				UIBasicUtility.SetLabel(fpLabel, _DeckColosseum_SetLimitIcon_0024callable92_0024194_113__(result.FriendPoint), show: true);
				UIBasicUtility.SetLabel(manaLabel, _DeckColosseum_SetLimitIcon_0024callable92_0024194_113__(result.ManaFragment), show: true);
			}
			mode = Mode.Result;
			if (IsChangeRank())
			{
				mode = Mode.RankChange;
			}
		}
	}

	private IEnumerator StartConnection()
	{
		return new _0024StartConnection_002422162(this).GetEnumerator();
	}

	public override void SceneUpdate()
	{
		if (mode == lastMode)
		{
			return;
		}
		prevMode = lastMode;
		lastMode = mode;
		if (mode == Mode.End)
		{
			PushRetry();
			return;
		}
		if (mode != Mode.Detail)
		{
			ChangeSituation(GetSituation((int)mode));
		}
		if (mode == Mode.RankChange)
		{
			IEnumerator enumerator = WaitTouch(waitTime);
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
			ShowRankChangeWindow();
		}
		else if (mode == Mode.RankUpReward)
		{
			PopupRewards(lastResult.createBreederRankRewards(), Mode.Result);
		}
		else if (mode == Mode.Result)
		{
			IEnumerator enumerator2 = WaitTouch(waitTime);
			if (enumerator2 != null)
			{
				StartCoroutine(enumerator2);
			}
		}
		else if (mode == Mode.Ranking)
		{
			IEnumerator enumerator3 = WaitTouch(waitTime);
			if (enumerator3 != null)
			{
				StartCoroutine(enumerator3);
			}
		}
		else if (mode == Mode.EventReward)
		{
			Mode nextMode = Mode.End;
			if (EnableResutlShortcut())
			{
				nextMode = Mode.ResultShortcut;
			}
			PopupRewards(lastResult.createEventRankRewards(), nextMode);
		}
		else if (mode == Mode.ResultShortcut)
		{
			IEnumerator enumerator4 = WaitTouch(waitTime);
			if (enumerator4 != null)
			{
				StartCoroutine(enumerator4);
			}
			ResultShortcut.Activate(activate: true);
		}
		else if (mode == Mode.Detail)
		{
			SetScreenTouch(b: false);
		}
	}

	private bool EnableResutlShortcut()
	{
		return ResultShortcut.IsEnabled(ResultShortcut.IntoScene.Colosseum);
	}

	private bool IsChangeRank()
	{
		return cacheBreeder.BreederRankId != lastResult.Breeder.BreederRankId;
	}

	private bool IsRankUp()
	{
		MBreederRanks mBreederRanks = MBreederRanks.Get(cacheBreeder.BreederRankId);
		MBreederRanks mBreederRanks2 = MBreederRanks.Get(lastResult.Breeder.BreederRankId);
		return (mBreederRanks.Rank < mBreederRanks2.Rank) ? true : false;
	}

	private bool NowRankingEvent()
	{
		return lastResult != null && lastResult.ColosseumEvent != null && lastResult.ColosseumEvent.IsRankingEvent;
	}

	private void ShowRankChangeWindow()
	{
		string text = "----";
		GameObject gameObject = null;
		string text2 = null;
		if (IsRankUp())
		{
			currentWindow = rankUpWindow;
			text = MTexts.Get("$COLOSSEUM_RESULT_RANK_UP").ToString();
			gameObject = rankUpEffect;
			text2 = se_rankUp;
		}
		else
		{
			currentWindow = rankDownWindow;
			text = MTexts.Get("$COLOSSEUM_RESULT_RANK_DOWN").ToString();
			gameObject = rankDownEffect;
			text2 = se_rankDown;
		}
		RespBreeder breeder = lastResult.Breeder;
		MBreederRanks mBreederRanks = MBreederRanks.Get(breeder.BreederRankId);
		UIBasicUtility.SetBreederRankSprite(currentWindow.rankSprite, mBreederRanks, toLower: false);
		UIBasicUtility.SetLabel(currentWindow.messageLabel, UIBasicUtility.SafeFormat(text, mBreederRanks.Progname));
		UIAutoTweenerStandAloneEx.In(currentWindow.root);
		gameObject.SetActive(value: true);
		GameSoundManager.PlaySe(text2, 0);
	}

	private void PopupRewards(RespReward[] rewards, Mode nextMode)
	{
		_0024PopupRewards_0024locals_002414561 _0024PopupRewards_0024locals_0024 = new _0024PopupRewards_0024locals_002414561();
		_0024PopupRewards_0024locals_0024._0024rewards = rewards;
		_0024PopupRewards_0024locals_0024._0024nextMode = nextMode;
		if (prevMode == Mode.Detail)
		{
			return;
		}
		if (_0024PopupRewards_0024locals_0024._0024rewards == null || _0024PopupRewards_0024locals_0024._0024rewards.Length <= 0)
		{
			mode = _0024PopupRewards_0024locals_0024._0024nextMode;
			return;
		}
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024PopupRewards_0024coroutine_00245149(this, _0024PopupRewards_0024locals_0024).Invoke;
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private void callbackShowDetail(RespReward reward)
	{
		if (reward != null)
		{
			switch (reward.TypeValue)
			{
			case 3:
				weaponDetailInfo.SetWeapon(reward.toRespWeapon(), ignoreUnknown: true);
				currentDetail = weaponDetailInfo.gameObject;
				break;
			case 4:
				poppetDetailInfo.SetMuppet(reward.toRespPoppet(), ignoreUnknown: true);
				currentDetail = poppetDetailInfo.gameObject;
				break;
			}
			mode = Mode.Detail;
			UIAutoTweenerStandAloneEx.In(currentDetail);
		}
	}

	private void PushNext()
	{
		if (IsChangingSituation)
		{
			return;
		}
		if (mode == Mode.RankChange)
		{
			UIAutoTweenerStandAloneEx.Out(currentWindow.root, delegate
			{
				if (IsRankUp())
				{
					mode = Mode.RankUpReward;
				}
				else
				{
					mode = Mode.Result;
				}
			});
		}
		else if (mode == Mode.RankUpReward || mode == Mode.EventReward)
		{
			closePopup = true;
		}
		else if (mode == Mode.Result)
		{
			if (NowRankingEvent())
			{
				mode = Mode.Ranking;
			}
			else
			{
				StartResultShortcut();
			}
		}
		else if (mode == Mode.Ranking)
		{
			if (string.IsNullOrEmpty(lastResult.EventRankRewards))
			{
				StartResultShortcut();
			}
			else
			{
				mode = Mode.EventReward;
			}
		}
	}

	private void PushBack()
	{
		if (!IsChangingSituation && mode == Mode.Detail)
		{
			mode = prevMode;
			UIAutoTweenerStandAloneEx.Out(currentDetail, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024172.Adapt(delegate
			{
				SetScreenTouch(b: true);
			}));
		}
	}

	private void StartResultShortcut()
	{
		if (EnableResutlShortcut())
		{
			mode = Mode.ResultShortcut;
		}
		else
		{
			mode = Mode.End;
		}
	}

	private void PushRetry()
	{
		ResultShortcut.Retry(EnumAreaTypes.Colosseum);
	}

	private void PushEnd()
	{
		ResultShortcut.End();
	}

	private string debugRewardJson()
	{
		return "[{\"Id\":115235,\"MItemGroupId\":33646,\"ItemId\":2,\"MasterTypeValue\":3,\"Quantity\":1,\"Rate\":1,\"Unit\":0,\"Level\":1,\"Name\":\"赤い棒\",\"Explain\":\"ランクEの昇格報酬です。\",\"Title\":\"闘技場昇格報酬\",\"Timestamp\":\"AAAAAAANKRc=\",\"CreateDate\":\"2000-01-01T09:00:00Z\",\"UpdateDate\":\"2000-01-01T09:00:00Z\"},{\"Id\":115236,\"MItemGroupId\":33647,\"ItemId\":0,\"MasterTypeValue\":2,\"Quantity\":10000,\"Rate\":100,\"Unit\":0,\"Level\":0,\"Name\":\"hogehoge\",\"Explain\":\"ランクEの昇格報酬です。\",\"Title\":\"闘技場昇格報酬\",\"Timestamp\":\"AAAAAAANKRg=\",\"CreateDate\":\"2000-01-01T09:00:00Z\",\"UpdateDate\":\"2000-01-01T09:00:00Z\"}]";
	}

	internal IEnumerator _0024SceneStart_0024loading_00245144()
	{
		return new _0024_0024SceneStart_0024loading_00245144_002422165(this).GetEnumerator();
	}

	internal IEnumerator _0024_0024SceneStart_0024loading_00245144_0024load_00245145(string se)
	{
		return new _0024_0024_0024SceneStart_0024loading_00245144_0024load_00245145_002422172(se).GetEnumerator();
	}

	internal void _0024SceneStart_0024closure_00245146()
	{
		Initialize();
	}

	internal string _0024FinishRequest_0024ts_00245147(int i)
	{
		return i.ToString("#,#,#,#,0");
	}

	internal string _0024FinishRequest_0024dts_00245148(double d)
	{
		return checked((long)d).ToString("#,#,#,#,0");
	}

	internal void _0024PushNext_0024closure_00245150(GameObject obj)
	{
		if (IsRankUp())
		{
			mode = Mode.RankUpReward;
		}
		else
		{
			mode = Mode.Result;
		}
	}

	internal void _0024PushBack_0024closure_00245151()
	{
		SetScreenTouch(b: true);
	}
}
