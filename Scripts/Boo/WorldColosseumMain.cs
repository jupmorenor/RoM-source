using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class WorldColosseumMain : QuestMenuBase
{
	[Serializable]
	public enum WORLD_POPPET_BATTLE_MODE
	{
		None = -1,
		Colosseum,
		DeckColosseum,
		BpShop,
		StartQuest,
		Max
	}

	[Serializable]
	public enum WORLD_POPPET_BATTLE_SUB_MODE
	{
		None = -1,
		SelectBattleType,
		Opponent,
		Max
	}

	[Serializable]
	internal class _0024LoadBannerHtml_0024locals_002414553
	{
		internal string _0024html;

		internal ICallable _0024cb;
	}

	[Serializable]
	internal class _0024StartQuestCore_0024locals_002414554
	{
		internal bool _0024error;

		internal bool _0024flag;
	}

	[Serializable]
	internal class _0024_sendConfQuestDeck_0024locals_002414555
	{
		internal ApiPoppetDeckUpdate _0024req;
	}

	[Serializable]
	internal class _0024AutoRecStopEvent_0024locals_002414556
	{
		internal KamcordRecorder _0024_recorder;
	}

	[Serializable]
	internal class _0024OpenFullRankingWebView_0024locals_002414557
	{
		internal bool _0024flag;
	}

	[Serializable]
	internal class _0024OpenFullWebView_0024locals_002414558
	{
		internal bool _0024closeFlag;

		internal UIAutoTweener[] _0024tweens;
	}

	[Serializable]
	internal class _0024_0024InitializeColosseumEventBanner_0024closure_00243122_0024locals_002414559
	{
		internal bool _0024flag;
	}

	[Serializable]
	internal class _0024_0024InitializeOpponentPlayer_0024closure_00243127_0024locals_002414560
	{
		internal bool _0024flag;

		internal ApiColosseumFriendOpponentList _0024req;

		internal ApiColosseumOpponentList _0024reqOp;
	}

	[Serializable]
	internal class _0024_0024InitializeColosseumEventBanner_0024closure_00243122_0024closure_00243124
	{
		internal _0024_0024InitializeColosseumEventBanner_0024closure_00243122_0024locals_002414559 _0024_0024locals_002415233;

		public _0024_0024InitializeColosseumEventBanner_0024closure_00243122_0024closure_00243124(_0024_0024InitializeColosseumEventBanner_0024closure_00243122_0024locals_002414559 _0024_0024locals_002415233)
		{
			this._0024_0024locals_002415233 = _0024_0024locals_002415233;
		}

		public void Invoke()
		{
			_0024_0024locals_002415233._0024flag = true;
		}
	}

	[Serializable]
	internal class _0024_0024InitializeOpponentPlayer_0024closure_00243127_0024closure_00243129
	{
		internal _0024_0024InitializeOpponentPlayer_0024closure_00243127_0024locals_002414560 _0024_0024locals_002415234;

		public _0024_0024InitializeOpponentPlayer_0024closure_00243127_0024closure_00243129(_0024_0024InitializeOpponentPlayer_0024closure_00243127_0024locals_002414560 _0024_0024locals_002415234)
		{
			this._0024_0024locals_002415234 = _0024_0024locals_002415234;
		}

		public void Invoke()
		{
			_0024_0024locals_002415234._0024flag = true;
		}
	}

	[Serializable]
	internal class _0024_0024InitializeOpponentPlayer_0024closure_00243127_0024closure_00243131
	{
		internal WorldColosseumMain _0024this_002415235;

		internal _0024_0024InitializeOpponentPlayer_0024closure_00243127_0024locals_002414560 _0024_0024locals_002415236;

		public _0024_0024InitializeOpponentPlayer_0024closure_00243127_0024closure_00243131(WorldColosseumMain _0024this_002415235, _0024_0024InitializeOpponentPlayer_0024closure_00243127_0024locals_002414560 _0024_0024locals_002415236)
		{
			this._0024this_002415235 = _0024this_002415235;
			this._0024_0024locals_002415236 = _0024_0024locals_002415236;
		}

		public void Invoke()
		{
			_0024_0024locals_002415236._0024flag = true;
			_0024this_002415235.CallBackFrOpponentPlayer(_0024_0024locals_002415236._0024req);
		}
	}

	[Serializable]
	internal class _0024_0024InitializeOpponentPlayer_0024closure_00243127_0024closure_00243133
	{
		internal WorldColosseumMain _0024this_002415237;

		internal _0024_0024InitializeOpponentPlayer_0024closure_00243127_0024locals_002414560 _0024_0024locals_002415238;

		public _0024_0024InitializeOpponentPlayer_0024closure_00243127_0024closure_00243133(WorldColosseumMain _0024this_002415237, _0024_0024InitializeOpponentPlayer_0024closure_00243127_0024locals_002414560 _0024_0024locals_002415238)
		{
			this._0024this_002415237 = _0024this_002415237;
			this._0024_0024locals_002415238 = _0024_0024locals_002415238;
		}

		public void Invoke()
		{
			_0024_0024locals_002415238._0024flag = true;
			_0024this_002415237.CallBackOpponentPlayer(_0024_0024locals_002415238._0024reqOp);
		}
	}

	[Serializable]
	internal class _0024LoadBannerHtml_0024closure_00243123
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002422150 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal string _0024url_002422151;

				internal int _0024retryCount_002422152;

				internal WWW _0024www_002422153;

				internal _0024LoadBannerHtml_0024closure_00243123 _0024self__002422154;

				public _0024(_0024LoadBannerHtml_0024closure_00243123 self_)
				{
					_0024self__002422154 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					checked
					{
						switch (_state)
						{
						default:
							if (!string.IsNullOrEmpty(_0024self__002422154._0024_0024locals_002415239._0024html))
							{
								MerlinServer.Busy = true;
								_0024url_002422151 = AssetBundlePath.RuntimeDataPath(_0024self__002422154._0024_0024locals_002415239._0024html);
								_0024retryCount_002422152 = 3;
								goto IL_00e8;
							}
							goto IL_013f;
						case 2:
							if (!_0024www_002422153.isDone && _0024www_002422153.error == null)
							{
								result = (YieldDefault(2) ? 1 : 0);
								break;
							}
							if (!string.IsNullOrEmpty(_0024www_002422153.error))
							{
								goto IL_00e8;
							}
							goto IL_00f4;
						case 1:
							{
								result = 0;
								break;
							}
							IL_00f4:
							if (!string.IsNullOrEmpty(_0024www_002422153.text))
							{
								_0024self__002422154._0024this_002415240.htmlBanners[_0024self__002422154._0024_0024locals_002415239._0024html] = _0024www_002422153.text;
							}
							MerlinServer.Busy = false;
							goto IL_013f;
							IL_00e8:
							while (_0024retryCount_002422152 > 0)
							{
								_0024retryCount_002422152--;
								try
								{
									_0024www_002422153 = new WWW(_0024url_002422151);
								}
								catch (Exception)
								{
									continue;
								}
								goto case 2;
							}
							goto IL_00f4;
							IL_013f:
							if (_0024self__002422154._0024_0024locals_002415239._0024cb != null)
							{
								_0024self__002422154._0024_0024locals_002415239._0024cb.Call(new object[0]);
							}
							YieldDefault(1);
							goto case 1;
						}
					}
					return (byte)result != 0;
				}
			}

			internal _0024LoadBannerHtml_0024closure_00243123 _0024self__002422155;

			public _0024Invoke_002422150(_0024LoadBannerHtml_0024closure_00243123 self_)
			{
				_0024self__002422155 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002422155);
			}
		}

		internal _0024LoadBannerHtml_0024locals_002414553 _0024_0024locals_002415239;

		internal WorldColosseumMain _0024this_002415240;

		public _0024LoadBannerHtml_0024closure_00243123(_0024LoadBannerHtml_0024locals_002414553 _0024_0024locals_002415239, WorldColosseumMain _0024this_002415240)
		{
			this._0024_0024locals_002415239 = _0024_0024locals_002415239;
			this._0024this_002415240 = _0024this_002415240;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002422150(this).GetEnumerator();
		}
	}

	[Serializable]
	internal class _0024StartQuestCore_0024closure_00243149
	{
		internal _0024StartQuestCore_0024locals_002414554 _0024_0024locals_002415241;

		public _0024StartQuestCore_0024closure_00243149(_0024StartQuestCore_0024locals_002414554 _0024_0024locals_002415241)
		{
			this._0024_0024locals_002415241 = _0024_0024locals_002415241;
		}

		public void Invoke()
		{
			_0024_0024locals_002415241._0024error = true;
		}
	}

	[Serializable]
	internal class _0024StartQuestCore_0024closure_00243150
	{
		internal _0024StartQuestCore_0024locals_002414554 _0024_0024locals_002415242;

		public _0024StartQuestCore_0024closure_00243150(_0024StartQuestCore_0024locals_002414554 _0024_0024locals_002415242)
		{
			this._0024_0024locals_002415242 = _0024_0024locals_002415242;
		}

		public void Invoke()
		{
			_0024_0024locals_002415242._0024flag = true;
		}
	}

	[Serializable]
	internal class _0024_sendConfQuestDeck_0024closure_00243152
	{
		internal _0024_sendConfQuestDeck_0024locals_002414555 _0024_0024locals_002415243;

		internal WorldColosseumMain _0024this_002415244;

		public _0024_sendConfQuestDeck_0024closure_00243152(_0024_sendConfQuestDeck_0024locals_002414555 _0024_0024locals_002415243, WorldColosseumMain _0024this_002415244)
		{
			this._0024_0024locals_002415243 = _0024_0024locals_002415243;
			this._0024this_002415244 = _0024this_002415244;
		}

		public void Invoke(RequestBase r)
		{
			if (!_0024_0024locals_002415243._0024req.HasMasterVersionError && !_0024_0024locals_002415243._0024req.HasDataVersionError && !_0024_0024locals_002415243._0024req.HasClientVersionError && !_0024_0024locals_002415243._0024req.GotoBootError && !_0024_0024locals_002415243._0024req.Is500Error && !_0024_0024locals_002415243._0024req.Is400Error)
			{
				_0024this_002415244._sendEquipError = true;
			}
		}
	}

	[Serializable]
	internal class _0024AutoRecStopEvent_0024closure_00243156
	{
		internal _0024AutoRecStopEvent_0024locals_002414556 _0024_0024locals_002415245;

		public _0024AutoRecStopEvent_0024closure_00243156(_0024AutoRecStopEvent_0024locals_002414556 _0024_0024locals_002415245)
		{
			this._0024_0024locals_002415245 = _0024_0024locals_002415245;
		}

		public void Invoke(int btn)
		{
			if (btn != 1 && btn == 2)
			{
				_0024_0024locals_002415245._0024_recorder.showView();
			}
		}
	}

	[Serializable]
	internal class _0024OpenFullRankingWebView_0024closure_00243157
	{
		internal _0024OpenFullRankingWebView_0024locals_002414557 _0024_0024locals_002415246;

		public _0024OpenFullRankingWebView_0024closure_00243157(_0024OpenFullRankingWebView_0024locals_002414557 _0024_0024locals_002415246)
		{
			this._0024_0024locals_002415246 = _0024_0024locals_002415246;
		}

		public void Invoke()
		{
			_0024_0024locals_002415246._0024flag = true;
		}
	}

	[Serializable]
	internal class _0024OpenFullWebView_0024closure_00243158
	{
		internal _0024OpenFullWebView_0024locals_002414558 _0024_0024locals_002415247;

		public _0024OpenFullWebView_0024closure_00243158(_0024OpenFullWebView_0024locals_002414558 _0024_0024locals_002415247)
		{
			this._0024_0024locals_002415247 = _0024_0024locals_002415247;
		}

		public void Invoke()
		{
			_0024_0024locals_002415247._0024closeFlag = true;
			int i = 0;
			UIAutoTweener[] _0024tweens = _0024_0024locals_002415247._0024tweens;
			for (int length = _0024tweens.Length; i < length; i = checked(i + 1))
			{
				_0024tweens[i].PlayAnimation(forward: false);
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024StartQuestCore_002422092 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ColosseumDeckItemUi _0024deckUi_002422093;

			internal Dialog _0024dialog_002422094;

			internal ApiColosseumOpponentList _0024reqOp_002422095;

			internal ApiColosseumOpponentList.RespColosseumOpponentList _0024resp_002422096;

			internal RespOpponent _0024tmpOpResp_002422097;

			internal UserData _0024ud_002422098;

			internal int _0024bpCost_002422099;

			internal float _0024_0024wait_sec_0024temp_00242664_002422100;

			internal _0024StartQuestCore_0024locals_002414554 _0024_0024locals_002422101;

			internal WorldColosseumMain _0024self__002422102;

			public _0024(WorldColosseumMain self_)
			{
				_0024self__002422102 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002422101 = new _0024StartQuestCore_0024locals_002414554();
					if (!_0024self__002422102.IsChangingSituation && !_0024self__002422102.isBusy && _0024self__002422102.mode != WORLD_POPPET_BATTLE_MODE.StartQuest && _0024self__002422102.curColosseumEvent != null)
					{
						_0024deckUi_002422093 = (ColosseumDeckItemUi)DeckSelector.currentDeckItemUi;
						if (!(null == _0024deckUi_002422093))
						{
							if (_0024deckUi_002422093.IsEnableDeck())
							{
								MerlinServer.Busy = true;
								_0024_0024locals_002422101._0024error = false;
								if (!_0024self__002422102.IsNeedToShowOpponentList())
								{
									_0024self__002422102.curOpponent = null;
									_0024_0024locals_002422101._0024flag = false;
									_0024reqOp_002422095 = new ApiColosseumOpponentList();
									_0024reqOp_002422095.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024StartQuestCore_0024closure_00243149(_0024_0024locals_002422101).Invoke);
									MerlinServer.Request(_0024reqOp_002422095, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024StartQuestCore_0024closure_00243150(_0024_0024locals_002422101).Invoke));
									goto case 2;
								}
								goto IL_021b;
							}
							MerlinServer.Busy = false;
							_0024dialog_002422094 = _0024self__002422102.dlgMan.OpenDialog(MTexts.Msg("$COLOSSEUM_LIMIT_NG"), string.Empty);
							_0024dialog_002422094.ButtonHandler = delegate
							{
								_0024self__002422102.mode = WORLD_POPPET_BATTLE_MODE.DeckColosseum;
							};
						}
					}
					goto case 1;
				case 2:
					if (!_0024_0024locals_002422101._0024flag)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024resp_002422096 = _0024reqOp_002422095.GetResponse();
					if (_0024resp_002422096 != null)
					{
						_0024self__002422102.respOpponents = _0024resp_002422096.Opponent;
						_0024tmpOpResp_002422097 = _0024self__002422102.GetRandomOpponentPlayer();
						if (_0024tmpOpResp_002422097 != null)
						{
							_0024self__002422102.curOpponent = new RespColosseumOpponentPoppet(_0024tmpOpResp_002422097);
						}
					}
					goto IL_021b;
				case 3:
					if (ApRpExp.MoveMSec > 0)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024_0024wait_sec_0024temp_00242664_002422100 = 0.5f;
					goto case 4;
				case 4:
					if (_0024_0024wait_sec_0024temp_00242664_002422100 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242664_002422100 -= Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					goto IL_033c;
				case 5:
					if (!ColosseumSession.Instance.HasError)
					{
						goto IL_03f6;
					}
					_0024self__002422102.ResetBanner();
					SceneChanger.ChangeTo(SceneID.Ui_World);
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_021b:
					if (_0024self__002422102.curOpponent == null || _0024_0024locals_002422101._0024error)
					{
						MerlinServer.Busy = false;
						_0024dialog_002422094 = _0024self__002422102.dlgMan.OpenDialog(MTexts.Msg("$COLOSSEUM_OPPONENT_LIST_ERROR"), string.Empty);
						_0024dialog_002422094.ButtonHandler = delegate
						{
							_0024self__002422102.mode = WORLD_POPPET_BATTLE_MODE.DeckColosseum;
						};
						goto case 1;
					}
					if (_0024self__002422102.curColosseumEvent.BpCost > 0)
					{
						_0024ud_002422098 = UserData.Current;
						_0024bpCost_002422099 = _0024self__002422102.curColosseumEvent.BpCost;
						ApRpExp.MoveMSec = 300;
						ApRpExp.BpParam = checked(_0024ud_002422098.Bp - _0024bpCost_002422099 * costRate);
						goto case 3;
					}
					goto IL_033c;
					IL_03f6:
					if (!ColosseumSession.Instance.IsPlaying)
					{
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					YieldDefault(1);
					goto case 1;
					IL_033c:
					_0024self__002422102.mode = WORLD_POPPET_BATTLE_MODE.StartQuest;
					_0024self__002422102.SetAutoRecEvent();
					if (_0024self__002422102.curOpponent.RespOpponent != null)
					{
						ColosseumSession.Instance.startSessionPvP(_0024self__002422102.curOpponent.RespOpponent);
					}
					else
					{
						ColosseumSession.Instance.startSessionVSFriend(_0024self__002422102.curOpponent.RespOpponentWithOrganize);
					}
					MerlinServer.Busy = false;
					_0024self__002422102.curQuest = null;
					_0024self__002422102.curOpponent = null;
					goto IL_03f6;
				}
				return (byte)result != 0;
			}
		}

		internal WorldColosseumMain _0024self__002422103;

		public _0024StartQuestCore_002422092(WorldColosseumMain self_)
		{
			_0024self__002422103 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002422103);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_sendConfQuestDeck_002422104 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal UserData _0024ud_002422105;

			internal int _0024currentIndex_002422106;

			internal _0024_sendConfQuestDeck_0024locals_002414555 _0024_0024locals_002422107;

			internal WorldColosseumMain _0024self__002422108;

			public _0024(WorldColosseumMain self_)
			{
				_0024self__002422108 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002422107 = new _0024_sendConfQuestDeck_0024locals_002414555();
					if (_0024self__002422108._sendEquip)
					{
						goto case 1;
					}
					_0024self__002422108._sendEquip = true;
					_0024ud_002422105 = UserData.Current;
					if (_0024ud_002422105 == null)
					{
						throw new AssertionFailedException("ud");
					}
					_0024currentIndex_002422106 = DeckSelector.currentDeckIndex;
					if (DeckSelector.isDirty || QuestMenuBase._isEquipChanged)
					{
						_0024_0024locals_002422107._0024req = DeckColosseum.CreatePoppetDeckRequest();
						_0024_0024locals_002422107._0024req.ErrorHandler = new _0024_sendConfQuestDeck_0024closure_00243152(_0024_0024locals_002422107, _0024self__002422108).Invoke;
						MerlinServer.Request(_0024_0024locals_002422107._0024req);
						goto case 2;
					}
					_0024self__002422108._sendEquipResult = true;
					goto IL_012a;
				case 2:
					if (!_0024_0024locals_002422107._0024req.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002422108._sendEquipResult = true;
					if (!_0024self__002422108._sendEquipError)
					{
						DeckSelector.OnSent();
					}
					goto IL_012a;
				case 1:
					{
						result = 0;
						break;
					}
					IL_012a:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal WorldColosseumMain _0024self__002422109;

		public _0024_sendConfQuestDeck_002422104(WorldColosseumMain self_)
		{
			_0024self__002422109 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002422109);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024OpenFullRankingWebView_002422110 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ApiWebRanking _0024apiWebRanking_002422111;

			internal IEnumerator _0024_0024sco_0024temp_00242666_002422112;

			internal _0024OpenFullRankingWebView_0024locals_002414557 _0024_0024locals_002422113;

			internal WorldColosseumMain _0024self__002422114;

			public _0024(WorldColosseumMain self_)
			{
				_0024self__002422114 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002422113 = new _0024OpenFullRankingWebView_0024locals_002414557();
					if (!_0024self__002422114.IsEnableFullWebView())
					{
						goto case 1;
					}
					_0024_0024locals_002422113._0024flag = false;
					_0024apiWebRanking_002422111 = new ApiWebRanking();
					MerlinServer.Request(_0024apiWebRanking_002422111, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024OpenFullRankingWebView_0024closure_00243157(_0024_0024locals_002422113).Invoke));
					goto case 2;
				case 2:
					if (!_0024_0024locals_002422113._0024flag)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024_0024sco_0024temp_00242666_002422112 = _0024self__002422114.OpenFullWebView(_0024apiWebRanking_002422111.Result, isUrl: false);
					if (_0024_0024sco_0024temp_00242666_002422112 != null)
					{
						_0024self__002422114.StartCoroutine(_0024_0024sco_0024temp_00242666_002422112);
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

		internal WorldColosseumMain _0024self__002422115;

		public _0024OpenFullRankingWebView_002422110(WorldColosseumMain self_)
		{
			_0024self__002422115 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002422115);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024OpenFullWebView_002422116 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal bool _0024curWebViewActive_002422117;

			internal GameObject _0024webPrefab_002422118;

			internal UIAutoTweener _0024tween_002422119;

			internal UIButtonMessage _0024closeButton_002422120;

			internal WebView _0024fullWebView_002422121;

			internal float _0024_0024wait_sec_0024temp_00242668_002422122;

			internal int _0024_002411807_002422123;

			internal UIAutoTweener[] _0024_002411808_002422124;

			internal int _0024_002411809_002422125;

			internal _0024OpenFullWebView_0024locals_002414558 _0024_0024locals_002422126;

			internal string _0024urlOrHtml_002422127;

			internal bool _0024isUrl_002422128;

			internal WorldColosseumMain _0024self__002422129;

			public _0024(string urlOrHtml, bool isUrl, WorldColosseumMain self_)
			{
				_0024urlOrHtml_002422127 = urlOrHtml;
				_0024isUrl_002422128 = isUrl;
				_0024self__002422129 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024_0024locals_002422126 = new _0024OpenFullWebView_0024locals_002414558();
						_0024curWebViewActive_002422117 = false;
						if (null != _0024self__002422129.curWebView)
						{
							_0024curWebViewActive_002422117 = _0024self__002422129.curWebView.gameObject.active;
						}
						if (null != _0024self__002422129.curWebView)
						{
							_0024self__002422129.ResetBanner();
						}
						_0024_0024locals_002422126._0024closeFlag = false;
						if ((bool)_0024self__002422129.fullWebViewObj)
						{
							goto IL_016b;
						}
						_0024webPrefab_002422118 = (GameObject)GameAssetModule.LoadPrefab("Prefab/GUI/WebFullScreen");
						if ((bool)_0024webPrefab_002422118)
						{
							_0024self__002422129.fullWebViewObj = (GameObject)UnityEngine.Object.Instantiate(_0024webPrefab_002422118);
							if ((bool)_0024self__002422129.fullWebViewObj)
							{
								_0024self__002422129.fullWebViewObj.transform.parent = _0024self__002422129.transform.parent;
								_0024self__002422129.fullWebViewObj.transform.localPosition = _0024webPrefab_002422118.transform.localPosition;
								_0024self__002422129.fullWebViewObj.transform.localScale = Vector3.one;
								goto IL_016b;
							}
						}
						goto case 1;
					case 2:
						if (!_0024isUrl_002422128)
						{
							_0024fullWebView_002422121.OpenHtml(_0024urlOrHtml_002422127, ServerURL.GameServerUrl("/"));
						}
						else
						{
							_0024fullWebView_002422121.Open(_0024urlOrHtml_002422127);
						}
						goto case 3;
					case 3:
						if (!_0024_0024locals_002422126._0024closeFlag && _0024self__002422129.mode == WORLD_POPPET_BATTLE_MODE.Colosseum)
						{
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						_0024fullWebView_002422121.gameObject.SetActive(value: false);
						result = (YieldDefault(4) ? 1 : 0);
						break;
					case 4:
						UnityEngine.Object.DestroyObject(_0024self__002422129.fullWebViewObj);
						_0024self__002422129.fullWebViewObj = null;
						_0024fullWebView_002422121 = null;
						_0024self__002422129.lastCommand = string.Empty;
						_0024_0024wait_sec_0024temp_00242668_002422122 = 1f;
						goto case 5;
					case 5:
						if (_0024_0024wait_sec_0024temp_00242668_002422122 > 0f)
						{
							_0024_0024wait_sec_0024temp_00242668_002422122 -= Time.deltaTime;
							result = (YieldDefault(5) ? 1 : 0);
							break;
						}
						_0024self__002422129.LoadBanner(_0024curWebViewActive_002422117, (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
						{
						});
						YieldDefault(1);
						goto case 1;
					case 1:
						{
							result = 0;
							break;
						}
						IL_016b:
						if ((bool)_0024self__002422129.fullWebViewObj)
						{
							_0024self__002422129.fullWebViewObj.SetActive(value: false);
							_0024_0024locals_002422126._0024tweens = _0024self__002422129.fullWebViewObj.GetComponentsInChildren<UIAutoTweener>(includeInactive: true);
							_0024_002411807_002422123 = 0;
							_0024_002411808_002422124 = _0024_0024locals_002422126._0024tweens;
							for (_0024_002411809_002422125 = _0024_002411808_002422124.Length; _0024_002411807_002422123 < _0024_002411809_002422125; _0024_002411807_002422123++)
							{
								_0024_002411808_002422124[_0024_002411807_002422123].Reset(null);
							}
							_0024closeButton_002422120 = ExtensionsModule.FindChild(_0024self__002422129.fullWebViewObj, "Button").GetComponentsInChildren<UIButtonMessage>(includeInactive: true).FirstOrDefault();
							_0024closeButton_002422120.eventHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024EventHandler_0024156.Adapt(new _0024OpenFullWebView_0024closure_00243158(_0024_0024locals_002422126).Invoke);
							_0024fullWebView_002422121 = _0024self__002422129.fullWebViewObj.GetComponentsInChildren<WebView>(includeInactive: true).FirstOrDefault();
							if ((bool)_0024fullWebView_002422121)
							{
								_0024fullWebView_002422121.enableLinkJump = true;
								_0024fullWebView_002422121.Clear();
								_0024self__002422129.fullWebViewObj.SetActive(value: true);
								result = (YieldDefault(2) ? 1 : 0);
								break;
							}
						}
						goto case 1;
					}
				}
				return (byte)result != 0;
			}
		}

		internal string _0024urlOrHtml_002422130;

		internal bool _0024isUrl_002422131;

		internal WorldColosseumMain _0024self__002422132;

		public _0024OpenFullWebView_002422116(string urlOrHtml, bool isUrl, WorldColosseumMain self_)
		{
			_0024urlOrHtml_002422130 = urlOrHtml;
			_0024isUrl_002422131 = isUrl;
			_0024self__002422132 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024urlOrHtml_002422130, _0024isUrl_002422131, _0024self__002422132);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024Initialize_0024closure_00243121_002422133 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024count_002422134;

			internal WorldColosseumMain _0024self__002422135;

			public _0024(WorldColosseumMain self_)
			{
				_0024self__002422135 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002422135.InitializeColosseumEventBanner();
					goto case 2;
				case 2:
					if (MerlinServer.Instance.IsBusy)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024count_002422134 = 0;
					_0024self__002422135.mode = WORLD_POPPET_BATTLE_MODE.Colosseum;
					_0024self__002422135.lastMode = WORLD_POPPET_BATTLE_MODE.None;
					_0024self__002422135.InitColosseumEventList(_0024self__002422135.colosseumEvents);
					_0024self__002422135.UpdateBreedInfomation();
					_0024self__002422135.UpdateEventRankingInfomation();
					if (null != _0024self__002422135.oppnentList)
					{
						UIAutoTweenerStandAloneEx.Hide(_0024self__002422135.oppnentList);
					}
					if (null != _0024self__002422135.battleTypeList)
					{
						UIAutoTweenerStandAloneEx.Hide(_0024self__002422135.battleTypeList);
					}
					if (null != _0024self__002422135.dailySkillInfo)
					{
						UIAutoTweenerStandAloneEx.Hide(_0024self__002422135.dailySkillInfo);
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

		internal WorldColosseumMain _0024self__002422136;

		public _0024_0024Initialize_0024closure_00243121_002422133(WorldColosseumMain self_)
		{
			_0024self__002422136 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002422136);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024InitializeColosseumEventBanner_0024closure_00243122_002422137 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RespColosseumEvent _0024colEvents_002422138;

			internal int _0024_002411817_002422139;

			internal RespColosseumEvent[] _0024_002411818_002422140;

			internal int _0024_002411819_002422141;

			internal _0024_0024InitializeColosseumEventBanner_0024closure_00243122_0024locals_002414559 _0024_0024locals_002422142;

			internal WorldColosseumMain _0024self__002422143;

			public _0024(WorldColosseumMain self_)
			{
				_0024self__002422143 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024_0024locals_002422142 = new _0024_0024InitializeColosseumEventBanner_0024closure_00243122_0024locals_002414559();
						if (null == _0024self__002422143.colosseumEvents)
						{
							goto case 1;
						}
						MerlinServer.Busy = true;
						_0024_002411817_002422139 = 0;
						_0024_002411818_002422140 = _0024self__002422143.colosseumEvents;
						_0024_002411819_002422141 = _0024_002411818_002422140.Length;
						goto IL_0108;
					case 2:
						if (!_0024_0024locals_002422142._0024flag)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						goto IL_00fa;
					case 1:
						{
							result = 0;
							break;
						}
						IL_0108:
						if (_0024_002411817_002422139 < _0024_002411819_002422141)
						{
							if (_0024_002411818_002422140[_0024_002411817_002422139] == null)
							{
								goto IL_00fa;
							}
							_0024_0024locals_002422142._0024flag = false;
							_0024self__002422143.LoadBannerHtml(_0024_002411818_002422140[_0024_002411817_002422139].BannerHtml, _0024_002411818_002422140[_0024_002411817_002422139].Id, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024InitializeColosseumEventBanner_0024closure_00243122_0024closure_00243124(_0024_0024locals_002422142).Invoke));
							goto case 2;
						}
						MerlinServer.Busy = false;
						YieldDefault(1);
						goto case 1;
						IL_00fa:
						_0024_002411817_002422139++;
						goto IL_0108;
					}
				}
				return (byte)result != 0;
			}
		}

		internal WorldColosseumMain _0024self__002422144;

		public _0024_0024InitializeColosseumEventBanner_0024closure_00243122_002422137(WorldColosseumMain self_)
		{
			_0024self__002422144 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002422144);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024InitializeOpponentPlayer_0024closure_00243127_002422145 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ApiHomeSlim _0024reqHomeSlim_002422146;

			internal _0024_0024InitializeOpponentPlayer_0024closure_00243127_0024locals_002414560 _0024_0024locals_002422147;

			internal WorldColosseumMain _0024self__002422148;

			public _0024(WorldColosseumMain self_)
			{
				_0024self__002422148 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002422147 = new _0024_0024InitializeOpponentPlayer_0024closure_00243127_0024locals_002414560();
					MerlinServer.Busy = true;
					_0024_0024locals_002422147._0024flag = false;
					_0024reqHomeSlim_002422146 = new ApiHomeSlim();
					_0024reqHomeSlim_002422146.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
					{
						SceneChanger.Change("Ui_World");
					});
					MerlinServer.Request(_0024reqHomeSlim_002422146, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024_0024InitializeOpponentPlayer_0024closure_00243127_0024closure_00243129(_0024_0024locals_002422147).Invoke));
					goto case 2;
				case 2:
					if (!_0024_0024locals_002422147._0024flag)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024_0024locals_002422147._0024req = new ApiColosseumFriendOpponentList();
					_0024_0024locals_002422147._0024flag = false;
					_0024_0024locals_002422147._0024req.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
					{
						SceneChanger.Change("Ui_World");
						_0024self__002422148.respFrOpponents = null;
					});
					MerlinServer.Request(_0024_0024locals_002422147._0024req, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024_0024InitializeOpponentPlayer_0024closure_00243127_0024closure_00243131(_0024self__002422148, _0024_0024locals_002422147).Invoke));
					goto case 3;
				case 3:
					if (!_0024_0024locals_002422147._0024flag)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024_0024locals_002422147._0024reqOp = new ApiColosseumOpponentList();
					_0024_0024locals_002422147._0024flag = false;
					_0024_0024locals_002422147._0024reqOp.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
					{
						SceneChanger.Change("Ui_World");
						_0024self__002422148.respOpponents = null;
					});
					MerlinServer.Request(_0024_0024locals_002422147._0024reqOp, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024_0024InitializeOpponentPlayer_0024closure_00243127_0024closure_00243133(_0024self__002422148, _0024_0024locals_002422147).Invoke));
					goto case 4;
				case 4:
					if (!_0024_0024locals_002422147._0024flag)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					MerlinServer.Busy = false;
					_0024self__002422148.Initialize();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal WorldColosseumMain _0024self__002422149;

		public _0024_0024InitializeOpponentPlayer_0024closure_00243127_002422145(WorldColosseumMain self_)
		{
			_0024self__002422149 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002422149);
		}
	}

	private WORLD_POPPET_BATTLE_MODE mode;

	private WORLD_POPPET_BATTLE_MODE lastMode;

	private WORLD_POPPET_BATTLE_SUB_MODE subMode;

	private WORLD_POPPET_BATTLE_SUB_MODE lastSubMode;

	public ColosseumEventList eventList;

	private WebView curWebView;

	private Dictionary<string, string> htmlBanners;

	private string lastBannerUrl;

	private GameObject fullWebViewObj;

	private string lastCommand;

	public UILabelBase teamNameLabel;

	public UILabelBase pointLabel;

	public UILabelBase defenseLabel;

	public string pointString;

	public string defenseString;

	public UISprite rankingIcon;

	public string rankingIconName;

	public UILabelBase winLoseLabel;

	public string winLoseString;

	public UILabelBase eventPointLabel;

	public string eventPointString;

	public UILabelBase eventRankingLabel;

	public string eventRankingString;

	public UILabelBase[] dailySkillLabels;

	public GameObject dailySkillInfo;

	protected bool errorEnd;

	[NonSerialized]
	protected static int costRate = 1;

	public GameObject oppnentList;

	public GameObject battleTypeList;

	private RespOpponentWithOrganize[] respFrOpponents;

	private RespOpponent[] respOpponents;

	private RespColosseumOpponentPoppet curOpponent;

	private RespColosseumOpponentPoppet lastOpponent;

	private RespColosseumEvent curColosseumEvent;

	private RespColosseumEvent[] colosseumEvents;

	public GameObject recButtonGo;

	private UILabelBase recButtonLabel;

	private bool autoRec;

	private bool _lastEquipChanged;

	private bool nowOut;

	private bool nowIn;

	public string helpUrl;

	public string rewardUrl;

	public bool debugFlag;

	public GameObject rewardConfButton;

	private bool isBusy
	{
		get
		{
			bool num = nowOut;
			if (!num)
			{
				num = nowIn;
			}
			return num;
		}
		set
		{
			nowOut = value;
			nowIn = value;
		}
	}

	public WORLD_POPPET_BATTLE_MODE Mode => mode;

	public WORLD_POPPET_BATTLE_SUB_MODE SubMode => subMode;

	public WebView CurWebView => curWebView;

	public RespColosseumEvent CurColosseumEvent
	{
		get
		{
			return curColosseumEvent;
		}
		set
		{
			curColosseumEvent = value;
		}
	}

	public WorldColosseumMain()
	{
		htmlBanners = new Dictionary<string, string>();
		pointString = " {0}";
		defenseString = " {0}";
		rankingIconName = "breedrank_{0}";
		winLoseString = "{0}勝{1}敗";
		eventPointString = " {0}";
		eventRankingString = " {0}";
		helpUrl = "/Web/Campaign?campaignId=154&token={0}";
		rewardUrl = "/Web/Ranking/EventPVPRankingRewards?token={0}";
	}

	public override void SceneStart()
	{
		string text = MTexts.Msg("$COLOSSEUM_COST");
		RuntimeAssetBundleDB.Instance.instantiatePrefab("ZPatch001ColosseumMenu");
		ResetRespFriends();
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
		InitRecButton();
		curArea = questManager.curArea;
		mode = WORLD_POPPET_BATTLE_MODE.None;
		lastMode = WORLD_POPPET_BATTLE_MODE.None;
		MerlinServer.EditorCommunicationInitialize((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			colosseumEvents = questManager.GetCurColosseumEventList();
			if (null == colosseumEvents)
			{
				ErrorColosseum("$COLOSSEUM_NO_EVENT_ERROR");
			}
			else if (colosseumEvents.Length == 0)
			{
				ErrorColosseum("$COLOSSEUM_NO_EVENT_ERROR");
			}
			else
			{
				DeckSelector.Init(UserData.Current.userPoppetDeckData.CurrentDeck, UserData.Current.userPoppetDeckData.deckNum());
				InitializeOpponentPlayer();
				if ((bool)stoneList)
				{
					stoneList.Download();
				}
				bool flag = true;
				RespColosseumEvent[] colosseumEvent = UserData.Current.userColosseumEvent.ColosseumEvent;
				if (colosseumEvent != null && 0 < colosseumEvent.Length)
				{
					int i = 0;
					RespColosseumEvent[] array = colosseumEvent;
					for (int length = array.Length; i < length; i = checked(i + 1))
					{
						if (array[i].IsRankingEvent)
						{
							flag = false;
							break;
						}
					}
				}
				if (flag)
				{
					UnityEngine.Object.Destroy(rewardConfButton);
				}
			}
		});
	}

	private void InitializeColosseumEventBanner()
	{
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024InitializeColosseumEventBanner_0024closure_00243122_002422137(this).GetEnumerator();
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private void InitializeOpponentPlayer()
	{
		if (respFrOpponents != null)
		{
			Initialize();
			return;
		}
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("null != ud");
		}
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024InitializeOpponentPlayer_0024closure_00243127_002422145(this).GetEnumerator();
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private RespOpponent GetRandomOpponentPlayer()
	{
		object obj = null;
		if (respOpponents != null && respOpponents.Length > 0)
		{
			RespOpponent[] array = respOpponents;
			obj = array[RuntimeServices.NormalizeArrayIndex(array, UnityEngine.Random.RandomRange(0, respOpponents.Length))];
		}
		object obj2 = obj;
		if (!(obj2 is RespOpponent))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(RespOpponent));
		}
		return (RespOpponent)obj2;
	}

	private void CallBackFrOpponentPlayer(ApiColosseumFriendOpponentList req)
	{
		if (req == null)
		{
			ErrorColosseum("$COLOSSEUM_OPPONENT_LIST_ERROR");
			respFrOpponents = null;
			return;
		}
		ApiColosseumFriendOpponentList.RespColosseumOpponentList response = req.GetResponse();
		if (response == null)
		{
			throw new AssertionFailedException("resp != null");
		}
		respFrOpponents = response.Opponent;
	}

	private void CallBackOpponentPlayer(ApiColosseumOpponentList req)
	{
		if (req == null)
		{
			respOpponents = null;
			return;
		}
		ApiColosseumOpponentList.RespColosseumOpponentList response = req.GetResponse();
		if (response == null)
		{
			throw new AssertionFailedException("resp != null");
		}
		respOpponents = response.Opponent;
	}

	private void Initialize()
	{
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024Initialize_0024closure_00243121_002422133(this).GetEnumerator();
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	protected void InitOpponentList()
	{
		if (curColosseumEvent == null)
		{
			return;
		}
		if (curColosseumEvent.IsFriendCompetition)
		{
			if (!IsEnableFriendOpponentList())
			{
				ErrorDialog.FatalError(MTexts.Msg("$COLOSSEUM_NO_FRIEND_OPPONENT"), string.Empty, jumpBoot: false, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38___00242.Adapt(delegate
				{
					subMode = WORLD_POPPET_BATTLE_SUB_MODE.SelectBattleType;
				}));
			}
			else
			{
				InitOpponentFrList(respFrOpponents, -1);
			}
		}
		else
		{
			InitOpponentRandomList(respOpponents, GetEableOpponentListCount(curColosseumEvent));
		}
	}

	protected void InitOpponentRandomList(RespOpponent[] respOps, int max)
	{
		if (null == respOps)
		{
			return;
		}
		RespColosseumOpponentPoppet[] array = new RespColosseumOpponentPoppet[0];
		int num = 0;
		int i = 0;
		checked
		{
			for (int length = respOps.Length; i < length; i++)
			{
				if (respOps[i] != null && !string.IsNullOrEmpty(respOps[i].Name))
				{
					RespColosseumOpponentPoppet respColosseumOpponentPoppet = new RespColosseumOpponentPoppet(respOps[i]);
					respColosseumOpponentPoppet.Id = new BoxId(num);
					array = (RespColosseumOpponentPoppet[])RuntimeServices.AddArrays(typeof(RespColosseumOpponentPoppet), array, new RespColosseumOpponentPoppet[1] { respColosseumOpponentPoppet });
					num++;
				}
			}
			InitOpponentListCore(array, max);
		}
	}

	protected void InitOpponentFrList(RespOpponentWithOrganize[] respOps, int max)
	{
		if (null == respOps)
		{
			return;
		}
		RespColosseumOpponentPoppet[] array = new RespColosseumOpponentPoppet[0];
		int num = 0;
		int i = 0;
		checked
		{
			for (int length = respOps.Length; i < length; i++)
			{
				if (respOps[i] != null && !string.IsNullOrEmpty(respOps[i].Name))
				{
					RespColosseumOpponentPoppet respColosseumOpponentPoppet = new RespColosseumOpponentPoppet(respOps[i]);
					respColosseumOpponentPoppet.Id = new BoxId(num);
					array = (RespColosseumOpponentPoppet[])RuntimeServices.AddArrays(typeof(RespColosseumOpponentPoppet), array, new RespColosseumOpponentPoppet[1] { respColosseumOpponentPoppet });
					num++;
				}
			}
			InitOpponentListCore(array, max);
		}
	}

	protected void InitOpponentListCore(RespColosseumOpponentPoppet[] respOps, int max)
	{
		UserData current = UserData.Current;
		if (current == null || max == 0 || !(null != mapetList))
		{
			return;
		}
		mapetList.Reset();
		mapetList.hookSettingListItem = hookOpponentListSettingItem;
		mapetList.hookSelectItem = hookOpponentListSelect;
		RespPoppet[] array = new RespPoppet[0];
		if (respOps != null)
		{
			int i = 0;
			for (int length = respOps.Length; i < length; i = checked(i + 1))
			{
				if (respOps[i] != null)
				{
					if (max > 0 && max <= array.Length)
					{
						break;
					}
					if (!string.IsNullOrEmpty(respOps[i].Name))
					{
						array = (RespPoppet[])RuntimeServices.AddArrays(typeof(RespPoppet), array, new RespPoppet[1] { respOps[i] as RespPoppet });
					}
				}
			}
			BoxId boxId = default(BoxId);
			if (curOpponent != null)
			{
				boxId = curOpponent.Id;
			}
			mapetList.SetFocusItem(boxId.Value);
			mapetList.DefaultSortFunc = null;
			mapetList.SetInputMapetList(array);
			if (curOpponent == null)
			{
				mapetList.SelectItem(0);
			}
			else
			{
				mapetList.SelectItemById(curOpponent.Id.Value, canDecide: false);
			}
		}
		if (array.Length == 0)
		{
			ErrorColosseum("$COLOSSEUM_OPPONENT_LIST_ERROR");
		}
	}

	public bool hookOpponentListSelect(UIListItem item)
	{
		MapetListItem mapetListItem = (MapetListItem)item;
		RespColosseumOpponentPoppet data = item.GetData<RespColosseumOpponentPoppet>();
		int result;
		if (RuntimeServices.EqualityOperator(curOpponent, data))
		{
			SelectPet();
			result = 1;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public bool hookOpponentListSettingItem(UIListItem item)
	{
		item.Select = false;
		float z = -2f;
		Vector3 localPosition = item.transform.localPosition;
		float num = (localPosition.z = z);
		Vector3 vector2 = (item.transform.localPosition = localPosition);
		if (!(item is MapetListItem))
		{
			throw new AssertionFailedException("MapetListItem じゃないUIListItemが渡されました");
		}
		MapetListItem mapetListItem = (MapetListItem)item;
		RespColosseumOpponentPoppet data = item.GetData<RespColosseumOpponentPoppet>();
		if (data != null)
		{
			mapetListItem.SetMapet(data, ignoreUnknown: true);
		}
		NGUITools.DestroyAllSameComponent<UIPanel>(mapetListItem.gameObject);
		return true;
	}

	protected void InitColosseumEventList(RespColosseumEvent[] events)
	{
		if (!(null != eventList))
		{
			throw new AssertionFailedException("null != eventList");
		}
		if (null == events)
		{
			ErrorColosseum("$COLOSSEUM_OPPONENT_LIST_ERROR");
		}
		if (events.Length == 0)
		{
			ErrorColosseum("$COLOSSEUM_OPPONENT_LIST_ERROR");
		}
		if (!(null != eventList) || eventList.isInitFinished)
		{
			return;
		}
		eventList.hookSelectItem = hookEventListSelect;
		eventList.SetEvents(events);
		string text = "event";
		__WorldColosseumMain_InitColosseumEventList_0024callable137_0024412_24__ from = delegate(Boo.Lang.List<UIListBase.Container> container)
		{
			__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24__ from2 = (UIListBase.Container a, UIListBase.Container b) => b.data.id.CompareTo(a.data.id);
			return SortFuncs.sort(container, SortFuncs.UIListBaseContainerFuncArray(_0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(from2)));
		};
		eventList.SetSortTypeName(new string[1] { text }, 0);
		eventList.SetSortFunc(text, _0024adaptor_0024__WorldColosseumMain_InitColosseumEventList_0024callable137_0024412_24___0024ListSortFunc_0024183.Adapt(from));
		eventList.SimpleSort(text);
		if (curColosseumEvent == null)
		{
			eventList.SelectItem(0);
		}
		else
		{
			eventList.SelectItemById(curColosseumEvent.Id, canDecide: false);
		}
	}

	public bool hookEventListSelect(UIListItem item)
	{
		ColosseumEventListItem colosseumEventListItem = (ColosseumEventListItem)item;
		RespColosseumEvent data = item.GetData<RespColosseumEvent>();
		if (data != null)
		{
			PushSelectEvent(data);
		}
		return false;
	}

	public void ErrorColosseum(string textId)
	{
		if (!questManager.StartQuest && !errorEnd)
		{
			errorEnd = true;
			ErrorDialog.FatalError(MTexts.Msg(textId), string.Empty, jumpBoot: false, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38___00242.Adapt(delegate
			{
				ResetBanner();
				SceneChanger.ChangeTo(SceneID.Ui_World);
			}));
		}
	}

	private void UpdateBreedInfomation()
	{
		UserData current = UserData.Current;
		if (null != teamNameLabel)
		{
			teamNameLabel.text = current.PlayerName;
		}
		if (null != pointLabel)
		{
			pointLabel.text = UIBasicUtility.SafeFormat(pointString, current.userBreeder.BreederRankPoint.ToString("0"));
		}
		if (null != defenseLabel)
		{
			defenseLabel.text = UIBasicUtility.SafeFormat(defenseString, 0);
		}
		if (null != winLoseLabel)
		{
			winLoseLabel.text = UIBasicUtility.SafeFormat(winLoseString, current.userBreeder.Win, current.userBreeder.Loss);
		}
		if (null != rankingIcon)
		{
			rankingIcon.spriteName = UIBasicUtility.SafeFormat(rankingIconName, MBreederRanks.Get(current.userBreeder.BreederRankId).Progname);
		}
	}

	private void UpdateEventRankingInfomation()
	{
		UserData current = UserData.Current;
		RespColosseumEventRanking colosseumEventRanking = current.userColosseumEvent.ColosseumEventRanking;
		string text = "--------";
		string text2 = "--------";
		if (colosseumEventRanking != null)
		{
			text = UIBasicUtility.SafeFormat(eventPointString, colosseumEventRanking.RankingPoint.ToString("0"));
			if (colosseumEventRanking.Ranking > 0)
			{
				text2 = UIBasicUtility.SafeFormat(eventRankingString, colosseumEventRanking.Ranking.ToString("0"));
			}
		}
		if (null != eventPointLabel)
		{
			eventPointLabel.text = text;
		}
		if (null != eventRankingLabel)
		{
			eventRankingLabel.text = text2;
		}
	}

	public override void SceneUpdate()
	{
		if (!SceneChanger.isCompletelyReady || InventoryOverDialog.IsOpenInventoryOverDialog() || IsChangingSituation)
		{
			return;
		}
		if (stoneList.IsDialogUpdating(this))
		{
			ResetBanner();
			return;
		}
		if (mode != lastMode)
		{
			lastMode = mode;
			bool initWebViewActive = true;
			if (DialogManager.DialogCount > 0)
			{
				initWebViewActive = false;
			}
			ChangeSituation(GetSituation((int)mode));
			if (mode == WORLD_POPPET_BATTLE_MODE.Colosseum)
			{
				if (null != oppnentList)
				{
					UIAutoTweenerStandAloneEx.Hide(oppnentList);
				}
				if (null != battleTypeList)
				{
					UIAutoTweenerStandAloneEx.Hide(battleTypeList);
				}
				LoadBanner(initWebViewActive, (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
				{
				});
				lastSubMode = WORLD_POPPET_BATTLE_SUB_MODE.None;
			}
			else if (mode == WORLD_POPPET_BATTLE_MODE.DeckColosseum)
			{
				PanelOut(oppnentList);
				PanelOut(battleTypeList);
				isBusy = false;
				SetDailySkill();
				DeckSelector.UpdateEquip();
				SetupColosseumEvent();
				InfomationBarHUD.UpdateText(MTexts.Msg("$COLOSSEUM_SETUP_DECK"));
			}
			else if (mode != WORLD_POPPET_BATTLE_MODE.StartQuest)
			{
			}
		}
		if (mode == WORLD_POPPET_BATTLE_MODE.Colosseum)
		{
			if (subMode != lastSubMode)
			{
				lastSubMode = subMode;
				if (subMode == WORLD_POPPET_BATTLE_SUB_MODE.SelectBattleType)
				{
					PanelOut(oppnentList);
					PanelIn(battleTypeList);
					InfomationBarHUD.UpdateText(MTexts.Msg("$COLOSSEUM_SELECT_BATTLE_TYPE"));
				}
				else if (subMode == WORLD_POPPET_BATTLE_SUB_MODE.Opponent)
				{
					PanelIn(oppnentList);
					PanelOut(battleTypeList);
					InitOpponentList();
					InfomationBarHUD.UpdateText(MTexts.Msg("$COLOSSEUM_SELECT_OPPONENT"));
				}
			}
			if (subMode == WORLD_POPPET_BATTLE_SUB_MODE.Opponent)
			{
				OppnentPetListCtrl();
			}
		}
		else if (mode == WORLD_POPPET_BATTLE_MODE.DeckColosseum)
		{
			ConfQuestCtrl();
			if (!_lastEquipChanged && (QuestMenuBase._isEquipChanged || DeckSelector.isDirty))
			{
				_lastEquipChanged = true;
				InitSendHook();
			}
		}
	}

	public void ReseColosseumEvent()
	{
		PoppetDeckCtrl.SetCostMax(0);
		PoppetDeckCtrl.SetRarityLimit(0, 0);
		PoppetDeckCtrl.SetElementLimit(new int[1]);
		PoppetDeckCtrl.SetStyleLimit(new int[1]);
	}

	public void SetupColosseumEvent()
	{
		if (curColosseumEvent == null)
		{
			throw new AssertionFailedException("null != curColosseumEvent");
		}
		int costMax = 0;
		if (curColosseumEvent.IsCostLimit)
		{
			costMax = curColosseumEvent.CostLimit;
		}
		PoppetDeckCtrl.SetCostMax(costMax);
		int minLimit = 0;
		int maxLimit = 0;
		if (curColosseumEvent.IsMinRarityLimit)
		{
			minLimit = curColosseumEvent.MinRarityLimit;
		}
		if (curColosseumEvent.IsMaxRarityLimit)
		{
			maxLimit = curColosseumEvent.MaxRarityLimit;
		}
		PoppetDeckCtrl.SetRarityLimit(minLimit, maxLimit);
		int num = 0;
		if (curColosseumEvent.IsElementLimit)
		{
			num = curColosseumEvent.ElementLimit;
		}
		PoppetDeckCtrl.SetElementLimit(new int[1] { num });
		int num2 = 0;
		if (curColosseumEvent.IsStyleLimit)
		{
			num2 = curColosseumEvent.StyleLimit;
		}
		PoppetDeckCtrl.SetStyleLimit(new int[1] { num2 });
	}

	private void ResetBanner()
	{
		if (null != curWebView)
		{
			curWebView.gameObject.SetActive(value: false);
			curWebView.Clear();
			lastBannerUrl = null;
		}
		curWebView = null;
	}

	public void LoadBanner(bool initWebViewActive, ICallable cb)
	{
		if (null == curWebView)
		{
			curWebView = GetSituation((int)mode).gameObject.GetComponentsInChildren<WebView>(includeInactive: true).FirstOrDefault();
			if (null != curWebView)
			{
				curWebView.ShortcutOpenIsHide = true;
				curWebView.enableLinkJump = true;
				curWebView.Clear();
				curWebView.gameObject.SetActive(initWebViewActive);
			}
		}
		RankingWebInit();
		opneHtml(cb);
	}

	public void LoadBannerHtml(string html, int eventId, ICallable cb)
	{
		_0024LoadBannerHtml_0024locals_002414553 _0024LoadBannerHtml_0024locals_0024 = new _0024LoadBannerHtml_0024locals_002414553();
		_0024LoadBannerHtml_0024locals_0024._0024html = html;
		_0024LoadBannerHtml_0024locals_0024._0024cb = cb;
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024LoadBannerHtml_0024closure_00243123(_0024LoadBannerHtml_0024locals_0024, this).Invoke;
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public bool opneHtml(ICallable cb)
	{
		int result;
		if (null == curWebView)
		{
			result = 0;
		}
		else if (htmlBanners == null)
		{
			result = 0;
		}
		else if (curColosseumEvent == null)
		{
			result = 0;
		}
		else if (string.IsNullOrEmpty(curColosseumEvent.BannerHtml))
		{
			result = 0;
		}
		else if (lastBannerUrl == curColosseumEvent.BannerHtml)
		{
			result = 0;
		}
		else if (!htmlBanners.ContainsKey(curColosseumEvent.BannerHtml))
		{
			result = 0;
		}
		else if (string.IsNullOrEmpty(htmlBanners[curColosseumEvent.BannerHtml]))
		{
			result = 0;
		}
		else
		{
			lastBannerUrl = curColosseumEvent.BannerHtml;
			curWebView.OpenHtml(htmlBanners[curColosseumEvent.BannerHtml], ServerURL.GameServerUrl("/"));
			curWebView.gameObject.SetActive(value: true);
			cb?.Call(new object[0]);
			result = 1;
		}
		return (byte)result != 0;
	}

	protected void OppnentPetListCtrl()
	{
		if ((bool)mapetList)
		{
			curOpponent = mapetList.GetFocusData<RespColosseumOpponentPoppet>();
			if (!RuntimeServices.EqualityOperator(curOpponent, lastOpponent))
			{
				lastOpponent = curOpponent;
			}
		}
		if (curOpponent != null)
		{
			if ((bool)selFrPetButtonValidCtrl)
			{
				selFrPetButtonValidCtrl.isValidColor = true;
			}
			if ((bool)detailButtonValidCtrl)
			{
				detailButtonValidCtrl.isValidColor = true;
			}
		}
		else
		{
			if ((bool)selFrPetButtonValidCtrl)
			{
				selFrPetButtonValidCtrl.isValidColor = false;
			}
			if ((bool)detailButtonValidCtrl)
			{
				detailButtonValidCtrl.isValidColor = false;
			}
		}
	}

	private void SceneReload()
	{
		SceneChanger.ChangeTo(SceneID.Ui_WorldColosseum);
	}

	private int GetEableOpponentListCount(RespColosseumEvent colEv)
	{
		return (colEv != null) ? (colEv.IsFriendCompetition ? (-1) : (MColosseumEvents.Get(curColosseumEvent.Id)?.NoFrCompeOpponentListCount ?? 0)) : 0;
	}

	private bool IsNeedToShowOpponentList()
	{
		return (GetEableOpponentListCount(curColosseumEvent) != 0) ? true : false;
	}

	public virtual IEnumerator StartQuestCore()
	{
		return new _0024StartQuestCore_002422092(this).GetEnumerator();
	}

	protected override IEnumerator _sendConfQuestDeck()
	{
		return new _0024_sendConfQuestDeck_002422104(this).GetEnumerator();
	}

	private bool IsEnableFriendOpponentList()
	{
		return !(null == respFrOpponents) && ((respFrOpponents.Length != 0) ? true : false);
	}

	protected void PushSelectEvent(RespColosseumEvent ev)
	{
		if (IsChangingSituation || isBusy || mode != 0 || ev == null)
		{
			return;
		}
		if (RuntimeServices.EqualityOperator(ev, curColosseumEvent))
		{
			if (IsNeedToShowOpponentList())
			{
				subMode = WORLD_POPPET_BATTLE_SUB_MODE.Opponent;
			}
			else
			{
				PushStartCore(1);
			}
		}
		else
		{
			curColosseumEvent = ev;
			opneHtml(null);
		}
	}

	public override void SelectPet()
	{
		if (!IsChangingSituation && !isBusy && subMode == WORLD_POPPET_BATTLE_SUB_MODE.Opponent && mode == WORLD_POPPET_BATTLE_MODE.Colosseum && curOpponent != null)
		{
			PushStartCore(1);
		}
	}

	public virtual void GotoMyhome(MyHomeEquipMain.MY_HOME_EQUIP_START_MODE startMode)
	{
		if (mode == WORLD_POPPET_BATTLE_MODE.DeckColosseum)
		{
			MyHomeEquipMain.BackScene = "Ui_WorldColosseum";
			MyHomeEquipMain.StartMode = startMode;
			MyHomeEquipMain.BgSpriteName = "map";
			ChangeSceneLikeQuestSubScene(SceneID.Ui_MyHomeEquip);
		}
	}

	public void PushStart()
	{
		if (!IsChangingSituation && !isBusy && mode == WORLD_POPPET_BATTLE_MODE.Colosseum)
		{
			if (subMode == WORLD_POPPET_BATTLE_SUB_MODE.SelectBattleType)
			{
				PushSelectEvent(curColosseumEvent);
			}
			else if (subMode == WORLD_POPPET_BATTLE_SUB_MODE.Opponent)
			{
				SelectPet();
			}
		}
	}

	private void PushStartCore(int useCostRate)
	{
		if (IsChangingSituation || isBusy || stoneListBusy)
		{
			return;
		}
		UserData current = UserData.Current;
		if (current == null || mode == WORLD_POPPET_BATTLE_MODE.DeckColosseum || curColosseumEvent == null)
		{
			return;
		}
		if (curColosseumEvent.BpCost > 0)
		{
			bool flag = current.Bp == 0;
			costRate = useCostRate;
			int bpCost = curColosseumEvent.BpCost;
			if (current.Bp < checked(bpCost * costRate))
			{
				stoneListBusy = true;
				stoneList.ShowCureBpDialog();
				stoneList.OnEnd = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34___0024211.Adapt(delegate
				{
					stoneListBusy = false;
					lastMode = WORLD_POPPET_BATTLE_MODE.None;
					if (null != oppnentList && oppnentList.active)
					{
						UIAutoTweenerStandAloneEx.Hide(oppnentList);
					}
					if (null != battleTypeList && battleTypeList.active)
					{
						UIAutoTweenerStandAloneEx.Hide(battleTypeList);
					}
				});
				return;
			}
		}
		PanelOut(oppnentList);
		PanelOut(battleTypeList);
		mode = WORLD_POPPET_BATTLE_MODE.DeckColosseum;
	}

	public void PushBack()
	{
		if (IsChangingSituation || isBusy)
		{
			return;
		}
		if (CurrentSituation == stoneList.Situation)
		{
			stoneList.PushCancel();
		}
		else if (mode == WORLD_POPPET_BATTLE_MODE.Colosseum)
		{
			if (subMode == WORLD_POPPET_BATTLE_SUB_MODE.Opponent)
			{
				subMode = WORLD_POPPET_BATTLE_SUB_MODE.SelectBattleType;
				PanelOut(oppnentList);
				return;
			}
			PanelOut(oppnentList);
			PanelOut(battleTypeList);
			ResetBanner();
			SceneChanger.ChangeTo(SceneID.Ui_World);
		}
		else
		{
			if (mode != WORLD_POPPET_BATTLE_MODE.DeckColosseum)
			{
				return;
			}
			if (null != dailySkillInfo && dailySkillInfo.active)
			{
				UIAutoTweenerStandAloneEx.Out(dailySkillInfo);
			}
			else if (!DeckSelector.isSwipe)
			{
				DeckColosseum.Current().Close();
				if (curColosseumEvent.IsFriendCompetition)
				{
					mode = WORLD_POPPET_BATTLE_MODE.Colosseum;
					subMode = WORLD_POPPET_BATTLE_SUB_MODE.Opponent;
				}
				else
				{
					mode = WORLD_POPPET_BATTLE_MODE.Colosseum;
					subMode = WORLD_POPPET_BATTLE_SUB_MODE.SelectBattleType;
				}
			}
		}
	}

	private void PanelIn(GameObject go)
	{
		if (null != go)
		{
			nowIn = true;
			UIAutoTweenerStandAloneEx.In(go, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024172.Adapt(delegate
			{
				nowIn = false;
			}));
		}
	}

	private void PanelOut(GameObject go)
	{
		if (null != go && go.active)
		{
			nowOut = true;
			UIAutoTweenerStandAloneEx.Out(go, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024172.Adapt(delegate
			{
				nowOut = false;
			}));
		}
	}

	private void InitRecButton()
	{
		if (!(null != recButtonGo))
		{
			throw new AssertionFailedException("null != recButtonGo");
		}
		autoRec = UserData.Current.userMiscInfo.autoRecColosseum;
		if (!Kamcord.IsEnabled())
		{
			UnityEngine.Object.DestroyObject(recButtonGo);
			return;
		}
		if (!PerformanceSettingBase.enableKamcord)
		{
			UnityEngine.Object.DestroyObject(recButtonGo);
			return;
		}
		recButtonLabel = recButtonGo.GetComponentsInChildren<UILabelBase>(includeInactive: true).FirstOrDefault();
		UpdateRecButton();
	}

	private void UpdateRecButton()
	{
		if (!(null == recButtonLabel))
		{
			if (autoRec)
			{
				UIBasicUtility.SetLabel(recButtonLabel, MTexts.Msg("$COLOSSEUM_REC_BUTTON_ON"));
			}
			else
			{
				UIBasicUtility.SetLabel(recButtonLabel, MTexts.Msg("$COLOSSEUM_REC_BUTTON_OFF"));
			}
		}
	}

	private void PushAutoRec()
	{
		autoRec = !autoRec;
		UserData.Current.userMiscInfo.autoRecColosseum = autoRec;
		UpdateRecButton();
	}

	private void SetAutoRecEvent()
	{
		if (autoRec)
		{
			SceneChanger.SceneChangeEventAtFadeout += AutoRecStartEvent;
		}
	}

	private static void AutoRecStartEvent(string sceneName)
	{
		SceneChanger.SceneChangeEventAtFadeout -= AutoRecStartEvent;
		if (Kamcord.IsEnabled() && PerformanceSettingBase.enableKamcord && !string.IsNullOrEmpty(sceneName) && sceneName.StartsWith("colosseum"))
		{
			SceneChanger.SceneChangeEventAtFadeout += AutoRecStopEvent;
			KamcordRecorder instance = KamcordRecorder.instance;
			if (!(null == instance))
			{
				instance.startRecording();
			}
		}
	}

	private static void AutoRecStopEvent(string sceneName)
	{
		_0024AutoRecStopEvent_0024locals_002414556 _0024AutoRecStopEvent_0024locals_0024 = new _0024AutoRecStopEvent_0024locals_002414556();
		SceneChanger.SceneChangeEventAtFadeout -= AutoRecStopEvent;
		if (!Kamcord.IsEnabled() || !PerformanceSettingBase.enableKamcord || string.IsNullOrEmpty(sceneName))
		{
			return;
		}
		_0024AutoRecStopEvent_0024locals_0024._0024_recorder = KamcordRecorder.instance;
		if (!(null == _0024AutoRecStopEvent_0024locals_0024._0024_recorder))
		{
			_0024AutoRecStopEvent_0024locals_0024._0024_recorder.stopRecording();
			if (SceneIDModule.StrToSceneID(sceneName) == SceneID.Ui_WorldColosseumResult)
			{
				Dialog dialog = DialogManager.Instance.OpenDialog(MTexts.Msg("$COLOSSEUM_REC_CHECK"), MTexts.Msg("$COLOSSEUM_REC_STOP"), DialogManager.MB_FLAG.MB_NONE, new string[2]
				{
					MTexts.Msg("exp_no"),
					MTexts.Msg("exp_yes")
				});
				dialog.ButtonHandler = new _0024AutoRecStopEvent_0024closure_00243156(_0024AutoRecStopEvent_0024locals_0024).Invoke;
			}
		}
	}

	private void RankingWebInit()
	{
		if (null != curWebView)
		{
			curWebView.CommandLinkHandler = RankingWebCommandLinkHandler;
		}
		lastCommand = string.Empty;
	}

	public bool RankingWebCommandLinkHandler(string command)
	{
		int result;
		if (command == lastCommand)
		{
			result = 0;
		}
		else if (null == curWebView)
		{
			result = 0;
		}
		else
		{
			lastCommand = command;
			string value = "ranking:";
			if (command.StartsWith(value))
			{
				IEnumerator enumerator = OpenFullRankingWebView();
				if (enumerator != null)
				{
					StartCoroutine(enumerator);
				}
				result = 1;
			}
			else
			{
				result = (curWebView.extraSceneChangeCommand(command) ? 1 : 0);
			}
		}
		return (byte)result != 0;
	}

	private bool IsEnableFullWebView()
	{
		return !IsChangingSituation && !isBusy && !(CurrentSituation == stoneList.Situation) && mode == WORLD_POPPET_BATTLE_MODE.Colosseum && !(null == curWebView) && (curWebView.gameObject.active ? true : false);
	}

	private IEnumerator OpenFullRankingWebView()
	{
		return new _0024OpenFullRankingWebView_002422110(this).GetEnumerator();
	}

	private void PushColosseumHelp()
	{
		if (IsEnableFullWebView())
		{
			OpenWebPageWithToken(helpUrl);
		}
	}

	private void PushRewardConf()
	{
		if (IsEnableFullWebView())
		{
			OpenWebPageWithToken(rewardUrl);
		}
	}

	private void OpenWebPageWithToken(string urlFormat)
	{
		string path = UIBasicUtility.SafeFormat(urlFormat, CurrentInfo.Token);
		path = ServerURL.GameApiUrl(path);
		IEnumerator enumerator = OpenFullWebView(path, isUrl: true);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator OpenFullWebView(string urlOrHtml, bool isUrl)
	{
		return new _0024OpenFullWebView_002422116(urlOrHtml, isUrl, this).GetEnumerator();
	}

	private void SetDailySkill()
	{
		if (null == dailySkillLabels)
		{
			return;
		}
		int[] dailyPassiveSkills = UserData.Current.userColosseumEvent.DailyPassiveSkills;
		if (null == dailyPassiveSkills)
		{
			return;
		}
		int num = 0;
		int length = dailySkillLabels.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int num2 = num;
			num++;
			UILabelBase[] array = dailySkillLabels;
			if (!(null == array[RuntimeServices.NormalizeArrayIndex(array, num2)]))
			{
				MCoverSkills mCoverSkills = null;
				if (num2 < dailyPassiveSkills.Length)
				{
					mCoverSkills = MCoverSkills.Get(dailyPassiveSkills[RuntimeServices.NormalizeArrayIndex(dailyPassiveSkills, num2)]);
				}
				if (mCoverSkills != null && !mCoverSkills.DisableColosseum)
				{
					UILabelBase[] array2 = dailySkillLabels;
					array2[RuntimeServices.NormalizeArrayIndex(array2, num2)].text = mCoverSkills.Name.msg;
				}
				else
				{
					UILabelBase[] array3 = dailySkillLabels;
					array3[RuntimeServices.NormalizeArrayIndex(array3, num2)].text = MTexts.Msg("exp_none");
				}
			}
		}
	}

	private void PushDailySkillDetail()
	{
		if (!IsChangingSituation && !isBusy && !(CurrentSituation == stoneList.Situation) && mode == WORLD_POPPET_BATTLE_MODE.DeckColosseum && !DeckSelector.isSwipe)
		{
			ShowDailySkillDetail();
		}
	}

	private void ShowDailySkillDetail()
	{
		if (null == dailySkillInfo)
		{
			return;
		}
		int[] dailyPassiveSkills = UserData.Current.userColosseumEvent.DailyPassiveSkills;
		if (null == dailyPassiveSkills || dailyPassiveSkills.Length == 0)
		{
			return;
		}
		ColosseumDailySkillDetail component = dailySkillInfo.GetComponent<ColosseumDailySkillDetail>();
		if (!(null == component))
		{
			if (null != dailySkillInfo)
			{
				UIAutoTweenerStandAloneEx.In(dailySkillInfo);
			}
			component.SetDailySkills(dailyPassiveSkills);
		}
	}

	internal void _0024SceneStart_0024closure_00243120()
	{
		colosseumEvents = questManager.GetCurColosseumEventList();
		if (null == colosseumEvents)
		{
			ErrorColosseum("$COLOSSEUM_NO_EVENT_ERROR");
			return;
		}
		if (colosseumEvents.Length == 0)
		{
			ErrorColosseum("$COLOSSEUM_NO_EVENT_ERROR");
			return;
		}
		DeckSelector.Init(UserData.Current.userPoppetDeckData.CurrentDeck, UserData.Current.userPoppetDeckData.deckNum());
		InitializeOpponentPlayer();
		if ((bool)stoneList)
		{
			stoneList.Download();
		}
		bool flag = true;
		RespColosseumEvent[] colosseumEvent = UserData.Current.userColosseumEvent.ColosseumEvent;
		if (colosseumEvent != null && 0 < colosseumEvent.Length)
		{
			int i = 0;
			RespColosseumEvent[] array = colosseumEvent;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (array[i].IsRankingEvent)
				{
					flag = false;
					break;
				}
			}
		}
		if (flag)
		{
			UnityEngine.Object.Destroy(rewardConfButton);
		}
	}

	internal IEnumerator _0024Initialize_0024closure_00243121()
	{
		return new _0024_0024Initialize_0024closure_00243121_002422133(this).GetEnumerator();
	}

	internal IEnumerator _0024InitializeColosseumEventBanner_0024closure_00243122()
	{
		return new _0024_0024InitializeColosseumEventBanner_0024closure_00243122_002422137(this).GetEnumerator();
	}

	internal Boo.Lang.List<UIListBase.Container> _0024InitColosseumEventList_0024closure_00243125(Boo.Lang.List<UIListBase.Container> container)
	{
		__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24__ from = (UIListBase.Container a, UIListBase.Container b) => b.data.id.CompareTo(a.data.id);
		return SortFuncs.sort(container, SortFuncs.UIListBaseContainerFuncArray(_0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(from)));
	}

	internal int _0024_0024InitColosseumEventList_0024closure_00243125_0024closure_00243126(UIListBase.Container a, UIListBase.Container b)
	{
		return b.data.id.CompareTo(a.data.id);
	}

	internal IEnumerator _0024InitializeOpponentPlayer_0024closure_00243127()
	{
		return new _0024_0024InitializeOpponentPlayer_0024closure_00243127_002422145(this).GetEnumerator();
	}

	internal void _0024_0024InitializeOpponentPlayer_0024closure_00243127_0024closure_00243128()
	{
		SceneChanger.Change("Ui_World");
	}

	internal void _0024_0024InitializeOpponentPlayer_0024closure_00243127_0024closure_00243130()
	{
		SceneChanger.Change("Ui_World");
		respFrOpponents = null;
	}

	internal void _0024_0024InitializeOpponentPlayer_0024closure_00243127_0024closure_00243132()
	{
		SceneChanger.Change("Ui_World");
		respOpponents = null;
	}

	internal void _0024InitOpponentList_0024closure_00243134()
	{
		subMode = WORLD_POPPET_BATTLE_SUB_MODE.SelectBattleType;
	}

	internal void _0024ErrorColosseum_0024closure_00243135()
	{
		ResetBanner();
		SceneChanger.ChangeTo(SceneID.Ui_World);
	}

	internal void _0024SceneUpdate_0024closure_00243136()
	{
	}

	internal void _0024StartQuestCore_0024closure_00243148(int btn)
	{
		mode = WORLD_POPPET_BATTLE_MODE.DeckColosseum;
	}

	internal void _0024StartQuestCore_0024closure_00243151(int btn)
	{
		mode = WORLD_POPPET_BATTLE_MODE.DeckColosseum;
	}

	internal void _0024PushStartCore_0024closure_00243153()
	{
		stoneListBusy = false;
		lastMode = WORLD_POPPET_BATTLE_MODE.None;
		if (null != oppnentList && oppnentList.active)
		{
			UIAutoTweenerStandAloneEx.Hide(oppnentList);
		}
		if (null != battleTypeList && battleTypeList.active)
		{
			UIAutoTweenerStandAloneEx.Hide(battleTypeList);
		}
	}

	internal void _0024PanelIn_0024closure_00243154()
	{
		nowIn = false;
	}

	internal void _0024PanelOut_0024closure_00243155()
	{
		nowOut = false;
	}

	internal void _0024OpenFullWebView_0024closure_00243159()
	{
	}
}
