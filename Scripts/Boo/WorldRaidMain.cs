using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class WorldRaidMain : QuestMenuBase
{
	[Serializable]
	public enum WORLD_RAID_MODE
	{
		None = -1,
		Info = 0,
		Help = 1,
		Conf = 2,
		Detail = 3,
		LastRaidFinish = 4,
		RaidDiscover = 5,
		StoneShop = 6,
		Max = 7,
		Log = 100
	}

	[Serializable]
	private enum RaidStartState
	{
		Full,
		Normal
	}

	[Serializable]
	internal class _0024_0024SendRequestRaidBattle_0024send_00243163_0024locals_002414567
	{
		internal bool _0024alreadyFinish;

		internal ApiGuildRaidBattle _0024apiRaidBattle;
	}

	[Serializable]
	internal class _0024_0024SendRequestRaidBattle_0024send_00243163_0024closure_00243164
	{
		internal WorldRaidMain _0024this_002415259;

		internal _0024_0024SendRequestRaidBattle_0024send_00243163_0024locals_002414567 _0024_0024locals_002415260;

		public _0024_0024SendRequestRaidBattle_0024send_00243163_0024closure_00243164(WorldRaidMain _0024this_002415259, _0024_0024SendRequestRaidBattle_0024send_00243163_0024locals_002414567 _0024_0024locals_002415260)
		{
			this._0024this_002415259 = _0024this_002415259;
			this._0024_0024locals_002415260 = _0024_0024locals_002415260;
		}

		public void Invoke()
		{
			RespTCycleRaidBattle raidBattle = _0024_0024locals_002415260._0024apiRaidBattle.GetResponse().RaidBattle;
			if (raidBattle != null && _0024this_002415259.LastRaidCycleId != raidBattle.TCycleId)
			{
				if (raidBattle.IsEnableRaid)
				{
					_0024this_002415259.LastRaidCycleId = raidBattle.TCycleId;
				}
				_0024this_002415259.LastBattleDate = string.Empty;
				_0024this_002415259.LastDiscoverDate = string.Empty;
				_0024this_002415259.ChangeMode(WORLD_RAID_MODE.RaidDiscover);
				_0024this_002415259.enabledCutscene = true;
			}
			_0024this_002415259.raidInfo.UpdateFlag = true;
			_0024this_002415259.isDiscovered = _0024this_002415259.HasDiscovered(raidBattle);
			if (raidBattle != null && raidBattle.IsEnableRaid)
			{
				_0024this_002415259.isDead = raidBattle.Hp <= 0;
			}
			else
			{
				_0024this_002415259.isNoRaid = true;
			}
			if (_0024this_002415259.IsLastRaidFinish(raidBattle))
			{
				_0024_0024locals_002415260._0024alreadyFinish = true;
				_0024this_002415259.ChangeMode(WORLD_RAID_MODE.LastRaidFinish);
			}
			else
			{
				_0024this_002415259.UpdateSimpleLog(_0024_0024locals_002415260._0024apiRaidBattle.GetResponse());
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024UpdateLog_002422333 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal bool _0024showLogMsg_002422334;

			internal string _0024noneMsg_002422335;

			internal ApiGuildBattleLog.Resp _0024resps_002422336;

			internal RespBattleLogs[] _0024blogs_002422337;

			internal ApiGuildBattleLog _0024req_002422338;

			internal WorldRaidMain _0024self__002422339;

			public _0024(ApiGuildBattleLog req, WorldRaidMain self_)
			{
				_0024req_002422338 = req;
				_0024self__002422339 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024showLogMsg_002422334 = true;
					_0024noneMsg_002422335 = MTexts.Msg("$WR_RAID_LOG_NONE_MSG");
					_0024resps_002422336 = null;
					if (_0024req_002422338 != null)
					{
						goto case 2;
					}
					goto IL_00f3;
				case 2:
					if (!_0024req_002422338.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024resps_002422336 = _0024req_002422338.GetResponse();
					if (_0024resps_002422336 != null)
					{
						_0024blogs_002422337 = _0024resps_002422336.BattleLogs;
						if (_0024blogs_002422337 != null && 0 < _0024blogs_002422337.Length)
						{
							_0024self__002422339.logMessageList.scrollBar.gameObject.SetActive(value: true);
							_0024self__002422339.logMessageList.SetLogMessageList(_0024blogs_002422337);
							_0024showLogMsg_002422334 = true;
						}
						else
						{
							_0024showLogMsg_002422334 = false;
						}
					}
					goto IL_00f3;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00f3:
					if (_0024req_002422338 == null)
					{
						if (_0024self__002422339.logMessageList.Count() <= 0)
						{
							_0024showLogMsg_002422334 = false;
						}
					}
					else if (!_0024req_002422338.IsOk)
					{
						_0024showLogMsg_002422334 = false;
						_0024self__002422339.showError(MTexts.Msg("$WR_RAID_LOG_FAILED_REQ_TITLE"));
					}
					if (_0024showLogMsg_002422334)
					{
						UIBasicUtility.SetLabel(_0024self__002422339.logNottingMessasge, string.Empty, show: false);
					}
					else
					{
						_0024self__002422339.logMessageList.scrollBar.gameObject.SetActive(value: false);
						UIBasicUtility.SetLabel(_0024self__002422339.logNottingMessasge, _0024noneMsg_002422335, show: true);
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal ApiGuildBattleLog _0024req_002422340;

		internal WorldRaidMain _0024self__002422341;

		public _0024UpdateLog_002422333(ApiGuildBattleLog req, WorldRaidMain self_)
		{
			_0024req_002422340 = req;
			_0024self__002422341 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024req_002422340, _0024self__002422341);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024InitializeHelpPlayer_002422342 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal UserData _0024ud_002422343;

			internal ApiFriendPlayerSearch _0024r_002422344;

			internal WorldRaidMain _0024self__002422345;

			public _0024(WorldRaidMain self_)
			{
				_0024self__002422345 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (QuestMenuBase.respFriends == null)
					{
						_0024ud_002422343 = UserData.Current;
						_0024r_002422344 = new ApiFriendPlayerSearch();
						_0024r_002422344.IsRecommend = true;
						_0024r_002422344.Num = MGameParameters.findByGameParameterId(51).Param;
						_0024r_002422344.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
						{
							_0024self__002422345.SceneReload();
							QuestMenuBase.respFriends = null;
						});
						MerlinServer.Request(_0024r_002422344, _0024adaptor_0024__MessageBoard_PushFriendSearch_0024callable145_0024918_13___0024__MerlinServer_Request_0024callable86_0024160_56___0024212.Adapt(delegate(ApiFriendPlayerSearch req)
						{
							if (!_0024self__002422345.isNoRaid && !_0024self__002422345.isDead && _0024self__002422345.isDiscovered)
							{
								if (req == null)
								{
									_0024self__002422345.SceneReload();
									QuestMenuBase.respFriends = null;
								}
								else
								{
									ApiFriendPlayerSearch.Resp response = req.GetResponse();
									if (response == null)
									{
										throw new AssertionFailedException("resp != null");
									}
									QuestMenuBase.respFriends = response.Friends;
									_0024self__002422345.curFrPet = null;
								}
							}
						}));
						goto case 2;
					}
					goto IL_00c3;
				case 2:
					if (!_0024r_002422344.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto IL_00c3;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00c3:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal WorldRaidMain _0024self__002422346;

		public _0024InitializeHelpPlayer_002422342(WorldRaidMain self_)
		{
			_0024self__002422346 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002422346);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024LastInitialize_002422347 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal UserData _0024ud_002422348;

			internal WorldRaidMain _0024self__002422349;

			public _0024(WorldRaidMain self_)
			{
				_0024self__002422349 = self_;
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
					_0024ud_002422348 = UserData.Current;
					if (_0024self__002422349.FromBackButton())
					{
						_0024self__002422349.ChangeMode(WORLD_RAID_MODE.Conf);
						_0024self__002422349.questManager.CurWeapon = _0024self__002422349.curWeapon;
						_0024self__002422349.questManager.CurPoppet = _0024self__002422349.curPet;
						_0024self__002422349.curQuest = _0024self__002422349.questManager.CurQuest;
						_0024self__002422349.curFrPet = _0024self__002422349.questManager.CurFrPoppet;
						DeckSelector.selFrMapet(_0024self__002422349.curFrPet, _0024self__002422349.curFrPet != null && _0024self__002422349.curFrPet.IsFriend);
					}
					else if (_0024self__002422349.HasTutrial())
					{
						if (_0024ud_002422348.isFirstVisitScene(SceneChanger.CurrentSceneName))
						{
							_0024self__002422349.ChangeMode(WORLD_RAID_MODE.RaidDiscover);
						}
						else
						{
							_0024self__002422349.ChangeMode(WORLD_RAID_MODE.Info);
						}
					}
					else
					{
						if (_0024self__002422349.LastDiscoverDate == _0024self__002422349.raidBattle.DiscoverDate.ToString())
						{
							_0024self__002422349.ChangeMode(WORLD_RAID_MODE.Info);
						}
						else
						{
							_0024self__002422349.ChangeMode(WORLD_RAID_MODE.RaidDiscover);
						}
						_0024self__002422349.LastDiscoverDate = _0024self__002422349.raidBattle.DiscoverDate.ToString();
					}
					DeckSelector.UpdateEquip();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal WorldRaidMain _0024self__002422350;

		public _0024LastInitialize_002422347(WorldRaidMain self_)
		{
			_0024self__002422350 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002422350);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024StartRaidCore_002422351 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal UserData _0024ud_002422352;

			internal float _0024_0024wait_sec_0024temp_00242714_002422353;

			internal IEnumerator _0024_0024sco_0024temp_00242715_002422354;

			internal RespFriend _0024curRespFriend_002422355;

			internal int _0024index_002422356;

			internal MStories _0024story_002422357;

			internal RespFriendPoppet _0024friendPoppet_002422358;

			internal ApiGuildRaidStart.Resp _0024res_002422359;

			internal ApiGuildRaidStart _0024raidStart_002422360;

			internal int _0024needRp_002422361;

			internal WorldRaidMain _0024self__002422362;

			public _0024(int needRp, WorldRaidMain self_)
			{
				_0024needRp_002422361 = needRp;
				_0024self__002422362 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024ud_002422352 = UserData.Current;
						_0024self__002422362.canRaidConnection = true;
						ApRpExp.MoveMSec = 300;
						ApRpExp.RpParam = _0024ud_002422352.Rp - _0024needRp_002422361;
						goto case 2;
					case 2:
						if (ApRpExp.MoveMSec > 0)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024_0024wait_sec_0024temp_00242714_002422353 = 0.5f;
						goto case 3;
					case 3:
						if (_0024_0024wait_sec_0024temp_00242714_002422353 > 0f)
						{
							_0024_0024wait_sec_0024temp_00242714_002422353 -= Time.deltaTime;
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						_0024self__002422362.questManager.CurPoppet = _0024self__002422362.curPet;
						_0024self__002422362.questManager.CurFrPoppet = _0024self__002422362.curFrPet;
						_0024self__002422362.questManager.CurWeapon = _0024self__002422362.curWeapon;
						_0024_0024sco_0024temp_00242715_002422354 = _0024self__002422362._0024SendDeck2_002422363();
						if (_0024_0024sco_0024temp_00242715_002422354 != null)
						{
							result = (Yield(4, _0024self__002422362.StartCoroutine(_0024_0024sco_0024temp_00242715_002422354)) ? 1 : 0);
							break;
						}
						goto case 4;
					case 4:
						if (IsTutorial)
						{
							_0024self__002422362.questManager.CurPoppet = _0024self__002422362.curPet;
							_0024self__002422362.questManager.CurFrPoppet = _0024self__002422362.curFrPet;
							_0024self__002422362.questManager.CurWeapon = _0024self__002422362.curWeapon;
							_0024self__002422362.questManager.CurQuest = _0024self__002422362.curQuest;
							_0024curRespFriend_002422355 = null;
							if (_0024self__002422362.curFrPet != null)
							{
								_0024index_002422356 = (int)_0024self__002422362.curFrPet.Id.Value;
								if (QuestMenuBase.respFriends != null && 0 <= _0024index_002422356 && _0024index_002422356 < QuestMenuBase.respFriends.Length)
								{
									RespFriend[] respFriends = QuestMenuBase.respFriends;
									_0024curRespFriend_002422355 = respFriends[RuntimeServices.NormalizeArrayIndex(respFriends, _0024index_002422356)];
								}
							}
							QuestMenuBase.respFriends = null;
							_0024story_002422357 = QuestManager.findStory(_0024self__002422362.curQuest);
							if (!_0024ud_002422352.userMiscInfo.questData.isPlay(_0024self__002422362.curQuest.Id))
							{
								_0024ud_002422352.userMiscInfo.questData.play(_0024self__002422362.curQuest.Id);
							}
							if (_0024story_002422357 != null && _0024curRespFriend_002422355 != null)
							{
								_0024friendPoppet_002422358 = new RespFriendPoppet(_0024curRespFriend_002422355);
								QuestSession.StartQuest(_0024story_002422357.Id, _0024friendPoppet_002422358, noSceneLoad: false);
							}
							_0024self__002422362.questManager.StartQuest = true;
							_0024self__002422362.curQuest = null;
							_0024self__002422362.curFrPet = null;
						}
						else if (_0024self__002422362.debug_localRaid)
						{
							QuestSession.InvalidateSession();
							if (_0024self__002422362.curFrPet == null)
							{
								throw new AssertionFailedException("レイドにつれてく友達がない？");
							}
							if (_0024self__002422362.curFrPet.RespFriend == null)
							{
								throw new AssertionFailedException("レイドにつれてく友達がない？");
							}
							_0024res_002422359 = new ApiGuildRaidStart.Resp();
							_0024res_002422359.RaidBattle = _0024self__002422362.raidBattle;
							PhotonClientMain.SavePlayInfo(_0024res_002422359);
							PhotonClientMain.RaidFriendPoppet = _0024self__002422362.curFrPet;
							QuestMenuBase.respFriends = null;
							_0024self__002422362.LastBattleDate = _0024self__002422362.raidBattle.DiscoverDate.ToString();
							SceneChanger.ScenePostChangeEvent += _0024self__002422362.Debug_LocalRaidPostSceneChangeEvent;
							SceneChanger.ChangeTo(SceneID.RaidBattle);
						}
						else
						{
							QuestSession.InvalidateSession();
							_0024raidStart_002422360 = new ApiGuildRaidStart();
							_0024raidStart_002422360.UseRp = _0024needRp_002422361;
							if (_0024self__002422362.curFrPet == null)
							{
								throw new AssertionFailedException("レイドにつれてく友達がない？");
							}
							if (_0024self__002422362.curFrPet.RespFriend == null)
							{
								throw new AssertionFailedException("レイドにつれてく友達がない？");
							}
							_0024raidStart_002422360.RecommendId = _0024self__002422362.curFrPet.RespFriend.TSocialPlayerId;
							_0024raidStart_002422360.ErrorHandler = _0024adaptor_0024__WorldRaidMain_0024callable368_00241043_38___0024__MerlinServer_Request_0024callable86_0024160_56___0024213.Adapt(delegate
							{
								_0024self__002422362.canRaidConnection = false;
								ModalCollider.SetActive(_0024self__002422362, active: false);
								_0024self__002422362.SceneReload();
							});
							_0024raidStart_002422360.Handler = _0024adaptor_0024__WorldRaidMain_0024callable368_00241043_38___0024__MerlinServer_Request_0024callable86_0024160_56___0024213.Adapt(delegate(ApiGuildRaidStart req)
							{
								PhotonClientMain.RaidStartResponse = req.GetResponse();
								if (req.IsOk)
								{
									PhotonClientMain.SavePlayInfo(req.GetResponse());
									SceneChanger.ChangeTo(SceneID.RaidBattle);
									QuestMenuBase.respFriends = null;
									_0024self__002422362.LastBattleDate = _0024self__002422362.raidBattle.DiscoverDate.ToString();
								}
								_0024self__002422362.canRaidConnection = false;
							});
							PhotonClientMain.RaidStartRequest = _0024raidStart_002422360;
							PhotonClientMain.RaidFriendPoppet = _0024self__002422362.curFrPet;
							MerlinServer.Request(_0024raidStart_002422360);
						}
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

		internal int _0024needRp_002422364;

		internal WorldRaidMain _0024self__002422365;

		public _0024StartRaidCore_002422351(int needRp, WorldRaidMain self_)
		{
			_0024needRp_002422364 = needRp;
			_0024self__002422365 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024needRp_002422364, _0024self__002422365);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024SendRequestRaidBattle_0024send_00243163_002422366 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal UserData _0024ud_002422367;

			internal _0024_0024SendRequestRaidBattle_0024send_00243163_0024locals_002414567 _0024_0024locals_002422368;

			internal WorldRaidMain _0024self__002422369;

			public _0024(WorldRaidMain self_)
			{
				_0024self__002422369 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002422368 = new _0024_0024SendRequestRaidBattle_0024send_00243163_0024locals_002414567();
					_0024ud_002422367 = UserData.Current;
					if (_0024self__002422369.HasTutrial() || _0024self__002422369.FromBackButton())
					{
						_0024self__002422369.raidBattle = _0024ud_002422367.userRaidInfo.raidBattle;
						_0024self__002422369.raidRanking = _0024ud_002422367.userRaidInfo.guildPlayerRanking;
						if (_0024self__002422369.HasTutrial())
						{
							_0024self__002422369.enabledCutscene = true;
						}
						_0024self__002422369.isDiscovered = _0024self__002422369.HasDiscovered(_0024self__002422369.raidBattle);
						goto IL_014d;
					}
					_0024_0024locals_002422368._0024alreadyFinish = false;
					_0024_0024locals_002422368._0024apiRaidBattle = new ApiGuildRaidBattle();
					MerlinServer.Request(_0024_0024locals_002422368._0024apiRaidBattle, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024_0024SendRequestRaidBattle_0024send_00243163_0024closure_00243164(_0024self__002422369, _0024_0024locals_002422368).Invoke));
					goto case 2;
				case 2:
					if (!_0024_0024locals_002422368._0024apiRaidBattle.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024_0024locals_002422368._0024alreadyFinish)
					{
						goto IL_014d;
					}
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_014d:
					_0024self__002422369.Initialize();
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal WorldRaidMain _0024self__002422370;

		public _0024_0024SendRequestRaidBattle_0024send_00243163_002422366(WorldRaidMain self_)
		{
			_0024self__002422370 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002422370);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024Initialize_0024send_00243165_002422371 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00242705_002422372;

			internal IEnumerator _0024_0024sco_0024temp_00242706_002422373;

			internal WorldRaidMain _0024self__002422374;

			public _0024(WorldRaidMain self_)
			{
				_0024self__002422374 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024sco_0024temp_00242705_002422372 = _0024self__002422374.InitializeHelpPlayer();
					if (_0024_0024sco_0024temp_00242705_002422372 != null)
					{
						result = (Yield(2, _0024self__002422374.StartCoroutine(_0024_0024sco_0024temp_00242705_002422372)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					_0024_0024sco_0024temp_00242706_002422373 = _0024self__002422374.LastInitialize();
					if (_0024_0024sco_0024temp_00242706_002422373 != null)
					{
						result = (Yield(3, _0024self__002422374.StartCoroutine(_0024_0024sco_0024temp_00242706_002422373)) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal WorldRaidMain _0024self__002422375;

		public _0024_0024Initialize_0024send_00243165_002422371(WorldRaidMain self_)
		{
			_0024self__002422375 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422375);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024PushHelp_0024coroutine_00243176_002422376 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_sec_0024temp_00242708_002422377;

			internal WorldRaidMain _0024self__002422378;

			public _0024(WorldRaidMain self_)
			{
				_0024self__002422378 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024wait_sec_0024temp_00242708_002422377 = 0.1f;
					goto case 2;
				case 2:
					if (_0024_0024wait_sec_0024temp_00242708_002422377 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242708_002422377 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					if (_0024self__002422378.IsChangingSituation)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__002422378.LockTouch(on: false);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal WorldRaidMain _0024self__002422379;

		public _0024_0024PushHelp_0024coroutine_00243176_002422376(WorldRaidMain self_)
		{
			_0024self__002422379 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002422379);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024PushLog_0024showLogPage_00243217_002422380 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiGuildBattleLog _0024req_002422381;

			internal IEnumerator _0024_0024sco_0024temp_00242710_002422382;

			internal WorldRaidMain _0024self__002422383;

			public _0024(WorldRaidMain self_)
			{
				_0024self__002422383 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req_002422381 = _0024self__002422383.GetLogMessage();
					_0024_0024sco_0024temp_00242710_002422382 = _0024self__002422383.UpdateLog(_0024req_002422381);
					if (_0024_0024sco_0024temp_00242710_002422382 != null)
					{
						result = (Yield(2, _0024self__002422383.StartCoroutine(_0024_0024sco_0024temp_00242710_002422382)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					if (_0024self__002422383._0024get_IsChangingSituation_002422384())
					{
						_0024self__002422383.LockTouch(on: false);
					}
					else
					{
						_0024self__002422383.ChangeMode(WORLD_RAID_MODE.Log);
						_0024self__002422383.pageTween.In(_0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024172.Adapt(delegate
						{
							_0024self__002422383.pageTween.InHandler = null;
							_0024self__002422383.listTween.In(_0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024172.Adapt(delegate
							{
								_0024self__002422383.listTween.InHandler = null;
								_0024self__002422383.LockTouch(on: false);
							}));
						}));
						YieldDefault(1);
					}
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal WorldRaidMain _0024self__002422385;

		public _0024_0024PushLog_0024showLogPage_00243217_002422380(WorldRaidMain self_)
		{
			_0024self__002422385 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422385);
		}
	}

	private WORLD_RAID_MODE mode;

	private WORLD_RAID_MODE lastMode;

	public bool debug_discover;

	public bool debug_tutorial;

	public bool debug_reset_first_visit;

	public bool debug_endResultTest;

	public bool debug_localRaid;

	public bool enabledCutscene;

	private bool doCutScene;

	private bool isDiscovered;

	private bool isDead;

	private bool isNoRaid;

	private bool canRaidConnection;

	private bool hasOpenedEscapeDialog;

	[NonSerialized]
	private static bool tutorialFlag;

	public UIButtonMessage confQuestButton2;

	private UIValidController confQuestButton2ValidCtrl;

	public UIButtonMessage unionButton;

	private UIValidController unionButtonValidCtrl;

	public WorldRaidInfo raidInfo;

	public Camera basicCamera;

	public Camera cutSceneCamera;

	private RespTCycleRaidBattle raidBattle;

	private RespCycleGuildPlayerRanking raidRanking;

	private GameObject bossModel;

	public GameObject bg3DModelPrefab;

	private GameObject bg3DModel;

	private int bossMonsterId;

	private readonly float LOG_INTERVAL_TIME;

	private readonly int BATTLE_LOG_TAKE_COUNT;

	public UIButtonMessage joinButton;

	private UIValidController joinButtonValidCtrl;

	public UIButtonMessage logButton;

	public UILabelBase logMessageSimpleLabel;

	public GameObject logMessagePage;

	public LogMessageList logMessageList;

	public GameObject logMessageListTweener;

	public UILabelBase logNottingMessasge;

	private float lastGetLogMessageTime;

	private UIAutoTweenerStandAloneEx pageTween;

	private UIAutoTweenerStandAloneEx listTween;

	private readonly int RAID_OPEN_TIME_SPAN;

	private readonly int RAID_ESCAPING_TIME_SPAN;

	private bool finishBossEscaped;

	private string LastBattleDate
	{
		get
		{
			return UserData.Current.userMiscInfo.raidData.LastBattleRaidDiscoverDate;
		}
		set
		{
			UserData.Current.userMiscInfo.raidData.LastBattleRaidDiscoverDate = value;
		}
	}

	private string LastDiscoverDate
	{
		get
		{
			return UserData.Current.userMiscInfo.raidData.LastDiscoverRaidDiscoverDate;
		}
		set
		{
			UserData.Current.userMiscInfo.raidData.LastDiscoverRaidDiscoverDate = value;
		}
	}

	private int LastRaidCycleId
	{
		get
		{
			return UserData.Current.userMiscInfo.raidData.LastRaidCycleId;
		}
		set
		{
			UserData.Current.userMiscInfo.raidData.LastRaidCycleId = value;
		}
	}

	public WORLD_RAID_MODE Mode => mode;

	public static bool IsTutorial => tutorialFlag;

	public WorldRaidMain()
	{
		LOG_INTERVAL_TIME = 10f;
		BATTLE_LOG_TAKE_COUNT = 50;
		RAID_OPEN_TIME_SPAN = 3600;
		RAID_ESCAPING_TIME_SPAN = 3720;
	}

	public static void SetTutorialFlag(bool isTuto)
	{
		tutorialFlag = isTuto;
	}

	private bool FromBackButton()
	{
		bool num = SceneChanger.LastSceneName == "Ui_MyHomeEquip";
		if (num)
		{
			num = !BattleHUDShortcut.IsSceneFromShortcut;
		}
		return num;
	}

	private bool HasTutrial()
	{
		bool num = IsTutorial;
		if (num)
		{
			num = curQuest != null;
		}
		return num;
	}

	private bool HasDiscovered(RespTCycleRaidBattle rb)
	{
		int result;
		if (HasTutrial())
		{
			result = 1;
		}
		else if (rb != null && rb.IsDiscover)
		{
			int num = checked((int)(MerlinDateTime.UtcNow - rb.DiscoverDate).TotalSeconds);
			result = ((num < RAID_OPEN_TIME_SPAN) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	private bool IsEscaping(RespTCycleRaidBattle rb)
	{
		int result;
		if (rb != null)
		{
			int num = checked((int)(MerlinDateTime.UtcNow - rb.DiscoverDate).TotalSeconds);
			result = ((num < RAID_ESCAPING_TIME_SPAN) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	private bool MatchRaid(int cycleId)
	{
		return raidBattle.TCycleId != cycleId;
	}

	public override void LockTouch(bool on)
	{
		base.LockTouch(on);
	}

	private void immadiateFunc()
	{
		LockTouch(on: true);
	}

	private void SetValidController(ref UIValidController vc, UIButtonMessage btn)
	{
		if ((bool)btn)
		{
			vc = ExtensionsModule.SetComponent<UIValidController>(btn.gameObject);
		}
	}

	private void ChangeMode(WORLD_RAID_MODE m)
	{
		mode = m;
	}

	private void SwitchCamera(bool isCutScene)
	{
		basicCamera.gameObject.SetActive(!isCutScene);
		cutSceneCamera.gameObject.SetActive(isCutScene);
	}

	private void SetValidButton(UIValidController vc, bool valid)
	{
		if (!(vc == null))
		{
			vc.isValidColor = valid;
			vc.collider.enabled = valid;
		}
	}

	private new void OnDestroy()
	{
		ModalCollider.SetActive(this, active: false);
		if (doCutScene)
		{
			CutSceneManager.Abort();
		}
	}

	public override void SceneStart()
	{
		SceneInitialize();
		MerlinServer.EditorCommunicationInitialize((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			DeckSelector.Init(UserData.Current.userDeckData2.CurrentDeck, UserData.Current.userDeckData2.deckNum());
			if (debug_localRaid)
			{
				SendDummyRequestRaidBattle();
			}
			else
			{
				SendRequestRaidBattle();
			}
		});
	}

	private void SceneInitialize()
	{
		logButton.immadiateHandler = immadiateFunc;
		joinButton.immadiateHandler = immadiateFunc;
		unionButton.immadiateHandler = immadiateFunc;
		RuntimeAssetBundleDB.Instance.instantiatePrefab("ZPatch001RaidMenu");
		ResetRespFriends();
		SetValidController(ref selFrPetButtonValidCtrl, selFrPetButton);
		SetValidController(ref confQuestButtonValidCtrl, confQuestButton);
		SetValidController(ref confQuestButton2ValidCtrl, confQuestButton2);
		SetValidController(ref detailButtonValidCtrl, detailButton);
		SetValidController(ref unionButtonValidCtrl, unionButton);
		SetValidController(ref joinButtonValidCtrl, joinButton);
		debug_localRaid = false;
		if (bg3DModelPrefab != null && bg3DModel == null)
		{
			bg3DModel = (GameObject)UnityEngine.Object.Instantiate(bg3DModelPrefab);
		}
		if (bg3DModel != null)
		{
			bg3DModel.transform.position = new Vector3(0f, 0f, 0f);
			bg3DModel.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
		}
		mode = WORLD_RAID_MODE.None;
		lastMode = WORLD_RAID_MODE.None;
		if (IsTutorial)
		{
			int i = 0;
			MQuests[] all = MQuests.All;
			for (int length = all.Length; i < length; i = checked(i + 1))
			{
				if (all[i].QuestType == EnumQuestTypes.RaidTutorial)
				{
					curQuest = all[i];
					SetValidButton(unionButtonValidCtrl, valid: false);
					break;
				}
			}
			if (curQuest == null)
			{
				throw new AssertionFailedException("チュートリアルのレイドクエストが見つからない");
			}
		}
		InitDetail();
		if (mapetList != null)
		{
			mapetList.hookSettingListItem = base.hookFriendListSettingItem;
			mapetList.hookSelectItem = base.hookFriendListSelect;
			if (mapetList.sortButton != null)
			{
				mapetList.sortButton.CheckCloseFunc = () => mode != WORLD_RAID_MODE.Help;
			}
		}
		InitLogMessage();
		DeckSelector.deselect();
		questManager = QuestManager.Instance;
		dlgMan = DialogManager.Instance;
		curArea = questManager.curArea;
		SetSceneTitle(curArea);
	}

	private void InitLogMessage()
	{
		listTween = logMessageListTweener.GetComponent<UIAutoTweenerStandAloneEx>();
		listTween.Hide();
		pageTween = logMessagePage.GetComponent<UIAutoTweenerStandAloneEx>();
		pageTween.Hide();
		listTween.tweenScaleExitDurationFactor = pageTween.tweenScaleExitDurationFactor;
		UpdateSimpleLog(null);
		if (logMessageList == null)
		{
		}
		lastGetLogMessageTime = 0f;
	}

	private ApiGuildBattleLog GetLogMessage()
	{
		ApiGuildBattleLog apiGuildBattleLog = null;
		if (!(LOG_INTERVAL_TIME >= Time.realtimeSinceStartup - lastGetLogMessageTime))
		{
			apiGuildBattleLog = new ApiGuildBattleLog();
			apiGuildBattleLog.Take = BATTLE_LOG_TAKE_COUNT;
			lastGetLogMessageTime = Time.realtimeSinceStartup;
			MerlinServer.Request(apiGuildBattleLog);
		}
		return apiGuildBattleLog;
	}

	private string logMsg(string player_name)
	{
		if (!(player_name != null))
		{
			throw new AssertionFailedException("player_name != null");
		}
		return UIBasicUtility.SafeFormat("{0}  {1}", player_name, MTexts.Msg("$WR_RAID_LOG_BATTLE_NOW"));
	}

	private void showError(string msg)
	{
		Dialog dialog = DialogManager.Instance.OpenDialog(msg, string.Empty, DialogManager.MB_FLAG.MB_NONE, new string[1] { "OK" });
	}

	private IEnumerator UpdateLog(ApiGuildBattleLog req)
	{
		return new _0024UpdateLog_002422333(req, this).GetEnumerator();
	}

	private void UpdateSimpleLog(ApiGuildRaidBattle.Resp resp)
	{
		bool flag = true;
		string text = MTexts.Msg("$WR_RAID_LOG_NONE_ACTIVE_MSG");
		string text2 = text;
		if (resp != null)
		{
			string[] fighters = resp.Fighters;
			if (fighters != null && 0 < fighters.Length)
			{
				text2 = string.Empty;
				int num = 0;
				while (num < 3)
				{
					int num2 = num;
					num++;
					if (fighters.Length <= num2)
					{
						break;
					}
					text2 += logMsg(fighters[RuntimeServices.NormalizeArrayIndex(fighters, num2)]) + "\n";
				}
				if (string.IsNullOrEmpty(text2))
				{
					text2 = text;
				}
			}
		}
		UIBasicUtility.SetLabel(logMessageSimpleLabel, text2, show: true);
	}

	private void SendRequestRaidBattle()
	{
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024SendRequestRaidBattle_0024send_00243163_002422366(this).GetEnumerator();
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private void SendDummyRequestRaidBattle()
	{
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = delegate
		{
			UserData current = UserData.Current;
			bool flag = false;
			RespTCycleRaidBattle respTCycleRaidBattle = current.userRaidInfo.raidBattle;
			if (respTCycleRaidBattle != null && LastRaidCycleId != respTCycleRaidBattle.TCycleId)
			{
				if (respTCycleRaidBattle.IsEnableRaid)
				{
					LastRaidCycleId = respTCycleRaidBattle.TCycleId;
				}
				LastBattleDate = string.Empty;
				LastDiscoverDate = string.Empty;
				ChangeMode(WORLD_RAID_MODE.RaidDiscover);
				enabledCutscene = true;
			}
			raidInfo.UpdateFlag = true;
			isDiscovered = HasDiscovered(respTCycleRaidBattle);
			if (respTCycleRaidBattle != null && respTCycleRaidBattle.IsEnableRaid)
			{
				isDead = respTCycleRaidBattle.Hp <= 0;
			}
			Initialize();
			return (IEnumerator)null;
		};
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private bool IsLastRaidFinish(RespTCycleRaidBattle resRaidBattle)
	{
		int result;
		if (resRaidBattle != null && resRaidBattle.IsEnableRaid)
		{
			DateTime discoverDate = resRaidBattle.DiscoverDate;
			bool flag = LastDiscoverDate != discoverDate.ToString();
			bool flag2 = isDead;
			bool num = !isDiscovered;
			if (num)
			{
				num = !flag;
			}
			bool flag3 = num;
			result = ((flag || flag2 || flag3) ? 1 : 0);
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	private void Initialize()
	{
		if (isNoRaid)
		{
			return;
		}
		UserData current = UserData.Current;
		raidBattle = current.userRaidInfo.raidBattle;
		raidRanking = current.userRaidInfo.guildPlayerRanking;
		if (!HasTutrial() && raidBattle == null)
		{
			RetrunToWorldMap();
			return;
		}
		InitBossModel();
		if (!isDiscovered)
		{
			if (!isNoRaid)
			{
				BossEscaped();
			}
			return;
		}
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024Initialize_0024send_00243165_002422371(this).GetEnumerator();
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator InitializeHelpPlayer()
	{
		return new _0024InitializeHelpPlayer_002422342(this).GetEnumerator();
	}

	private IEnumerator LastInitialize()
	{
		return new _0024LastInitialize_002422347(this).GetEnumerator();
	}

	private void InitBossModel()
	{
		MMonsters monster = null;
		checked
		{
			if (HasTutrial())
			{
				MStageMonsters mStageMonsters = null;
				MStageMonsters mStageMonsters2 = null;
				int i = 0;
				MStageBattles[] allStageBattles = curQuest.StartSceneId.AllStageBattles;
				for (int length = allStageBattles.Length; i < length; i++)
				{
					int j = 0;
					MStageMonsters[] allStageMonsters = allStageBattles[i].AllStageMonsters;
					for (int length2 = allStageMonsters.Length; j < length2; j++)
					{
						if (mStageMonsters == null)
						{
							mStageMonsters = allStageMonsters[j];
						}
						if (allStageMonsters[j].IsBoss != 0)
						{
							mStageMonsters2 = allStageMonsters[j];
							break;
						}
					}
				}
				if (mStageMonsters2 == null)
				{
					mStageMonsters2 = mStageMonsters;
				}
				if (mStageMonsters2 != null)
				{
					monster = mStageMonsters2.MMonsterId;
				}
				raidInfo.RaidTutoralMonster = mStageMonsters2;
			}
			else
			{
				if (raidBattle == null)
				{
					return;
				}
				monster = MMonsters.Get(raidBattle.MMonsterId);
			}
			LoadBossModel(monster);
		}
	}

	private void LoadBossModel(MMonsters monster)
	{
		bossMonsterId = monster.Id;
		RuntimeAssetBundleDB.SafeInstantiatePrefab(this, monster.PrefabName, delegate(GameObject go)
		{
			if (!(go != null))
			{
				throw new AssertionFailedException("go != null");
			}
			if (bossModel != null)
			{
				UnityEngine.Object.DestroyObject(bossModel);
				bossModel = null;
			}
			bossModel = go;
			CharacterController component = bossModel.GetComponent<CharacterController>();
			component.enabled = false;
			PicBookContents component2 = bossModel.GetComponent<PicBookContents>();
			if (component2 != null)
			{
				bossModel.transform.localScale = component2.PicBookDisplayScale;
				bossModel.transform.localPosition = component2.PicBookDisplayPosition;
				bossModel.transform.localEulerAngles = component2.PicBookDisplayRotation;
			}
			else
			{
				bossModel.transform.localPosition = new Vector3(0f, 0f, 0f);
			}
			D540ScriptRunner component3 = bossModel.GetComponent<D540ScriptRunner>();
			if ((bool)component3)
			{
				component3.enabled = false;
			}
		});
	}

	private void ShowBoss(bool show)
	{
		if (bossModel != null)
		{
			AIControl component = bossModel.GetComponent<AIControl>();
			if ((bool)component)
			{
				component.enabled = show;
			}
			if (bossModel.active != show)
			{
				bossModel.SetActive(show);
			}
		}
		if (raidInfo != null)
		{
			raidInfo.SkipLimitTime = !show;
			raidInfo.bossHpBar.transform.parent.gameObject.SetActive(show);
			raidInfo.timeLimitLabel.transform.parent.parent.gameObject.SetActive(show);
			raidInfo.comboBgPanel.gameObject.SetActive(show);
		}
		SetValidButton(joinButtonValidCtrl, show);
	}

	public override void SceneUpdate()
	{
		if (SceneChanger.isCompletelyReady && !base.IsChangingSituation && !InventoryOverDialog.IsOpenInventoryOverDialog() && !stoneList.IsDialogUpdating(this) && !hasOpenedEscapeDialog)
		{
			if (mode != lastMode)
			{
				InitMode();
			}
			UpdateMode();
		}
	}

	private void InitMode()
	{
		if (mode == lastMode)
		{
			return;
		}
		if (mode != WORLD_RAID_MODE.Log)
		{
			ChangeSituation(GetSituation((int)mode), mode != WORLD_RAID_MODE.StoneShop);
		}
		bool show = true;
		if (mode != WORLD_RAID_MODE.LastRaidFinish && (!isDiscovered || isNoRaid || isDead))
		{
			show = false;
		}
		SwitchCamera(isCutScene: false);
		lastMode = mode;
		if (mode == WORLD_RAID_MODE.Info)
		{
			ShowBoss(show);
		}
		else if (mode == WORLD_RAID_MODE.Help)
		{
			InitFriendPetList();
			ShowBoss(show: true);
		}
		else if (mode == WORLD_RAID_MODE.Conf)
		{
			DeckSelector.selFrMapet(curFrPet, curFrPet != null && curFrPet.IsFriend);
			DeckSelector.UpdateEquip();
			ShowBoss(show: true);
		}
		else if (mode == WORLD_RAID_MODE.LastRaidFinish)
		{
			LastDiscoverDate = string.Empty;
			if (PhotonClientMain.BossIsDead && isDiscovered)
			{
				PhotonClientMain.BossIsDead = false;
				InfomationBarHUD.UpdateText(MTexts.Msg("$WR_RAID_NEW_BOSS_TITLE"));
				Dialog dialog = OpenDialog(MTexts.Msg("$WR_RAID_NEW_BOSS_RESULT_DEAD"), onlyOK: true);
				dialog.CloseHandler = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
				{
					Initialize();
				};
			}
			else if (isDiscovered)
			{
				InfomationBarHUD.UpdateText(MTexts.Msg("$WR_RAID_NEW_BOSS_TITLE"));
				Dialog dialog = OpenDialog(MTexts.Msg("$WR_RAID_NEW_BOSS"), onlyOK: true);
				dialog.CloseHandler = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
				{
					Initialize();
				};
			}
			else
			{
				BossEscaped();
			}
		}
		else if (mode == WORLD_RAID_MODE.RaidDiscover)
		{
			__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ endFunc = delegate
			{
				ChangeMode(WORLD_RAID_MODE.Info);
				GameSoundManager.Reset = true;
				SwitchCamera(isCutScene: false);
				doCutScene = false;
			};
			if (enabledCutscene && DiscoverBossMain.DiscoverRaidBoss(gameObject, bossMonsterId, endFunc))
			{
				SwitchCamera(isCutScene: true);
				doCutScene = true;
			}
			else
			{
				ChangeMode(WORLD_RAID_MODE.Info);
				GameSoundManager.Reset = true;
			}
		}
	}

	private void UpdateMode()
	{
		if (mode == WORLD_RAID_MODE.Help)
		{
			FriendPetListCtrl();
		}
		else if (mode == WORLD_RAID_MODE.Conf)
		{
			ConfQuestCtrl();
		}
	}

	private void SetSceneTitle(MAreas areas)
	{
		if (areas != null)
		{
			string displayName = areas.DisplayName;
			if (!string.IsNullOrEmpty(displayName))
			{
				SceneTitleHUD.UpdateTitle(displayName);
			}
		}
	}

	private void BossEscaped()
	{
		if (!finishBossEscaped && !hasOpenedEscapeDialog)
		{
			string text = null;
			Dialog dialog = null;
			if (IsEscaping(raidBattle))
			{
				text = MTexts.Msg("$WR_RAID_ESCAPING_BOSS_TITLE");
				dialog = OpenDialog(MTexts.Msg("$WR_RAID_ESCAPING_BOSS"), onlyOK: true);
			}
			else
			{
				text = MTexts.Msg("$WR_RAID_NO_BOSS_TITLE");
				dialog = OpenDialog(MTexts.Msg("$WR_RAID_NO_BOSS"), onlyOK: true);
			}
			InfomationBarHUD.UpdateText(text);
			GetSituation(0).help = text;
			hasOpenedEscapeDialog = true;
			dialog.CloseHandler = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				canRaidConnection = false;
				hasOpenedEscapeDialog = false;
				finishBossEscaped = true;
				ModalCollider.SetActive(this, active: false);
				ChangeMode(WORLD_RAID_MODE.Info);
			};
		}
	}

	private void NoneBoss()
	{
		SceneReload();
	}

	private void SceneReload()
	{
		SceneChanger.ChangeTo(SceneID.Ui_WorldRaid);
	}

	private void RetrunToWorldMap()
	{
		SceneChanger.Change("Ui_World");
	}

	private Dialog OpenDialog(string msg, bool onlyOK)
	{
		Dialog dialog = null;
		dialog = ((!onlyOK) ? DialogManager.Open(msg, string.Empty, new string[2]
		{
			MTexts.Msg("$WR_RAID_DIALOG_BACK"),
			MTexts.Msg("$WR_RAID_DIALOG_NEXT")
		}) : DialogManager.Open(msg, string.Empty));
		if (dialog == null)
		{
		}
		return dialog;
	}

	private bool IsEndRaid()
	{
		int result;
		if (IsTutorial)
		{
			result = 0;
		}
		else
		{
			bool flag = raidBattle == null;
			bool num = flag;
			if (!num)
			{
				num = !raidBattle.IsEnableRaid;
			}
			bool flag2 = num;
			bool flag3 = !((float)UserData.Current.userRaidInfo.getRaidLimitSec() > 0f);
			result = ((flag || flag2 || flag3 || debug_endResultTest) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	private void PushHelp(GameObject obj)
	{
		if (base.IsChangingSituation)
		{
			return;
		}
		if (IsEndRaid())
		{
			NoneBoss();
			return;
		}
		if (curFrPet != null)
		{
			DeckSelector.selFrMapet(curFrPet, curFrPet.IsFriend);
		}
		ChangeMode(WORLD_RAID_MODE.Help);
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024PushHelp_0024coroutine_00243176_002422376(this).GetEnumerator();
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private void PushDecide(GameObject obj)
	{
		SelectPet();
	}

	public override void SelectPet()
	{
		if (!base.IsChangingSituation)
		{
			if (IsEndRaid())
			{
				NoneBoss();
			}
			else if (mode == WORLD_RAID_MODE.Help && curFrPet != null)
			{
				questManager.CurPoppet = curPet;
				questManager.CurFrPoppet = curFrPet;
				questManager.CurWeapon = curWeapon;
				DeckSelector.selFrMapet(curFrPet, curFrPet.IsFriend);
				ChangeMode(WORLD_RAID_MODE.Conf);
			}
		}
	}

	public virtual void GotoMyhome(MyHomeEquipMain.MY_HOME_EQUIP_START_MODE startMode)
	{
		if (!stoneListBusy && mode == WORLD_RAID_MODE.Conf)
		{
			MyHomeEquipMain.BackScene = "Ui_WorldRaid";
			MyHomeEquipMain.StartMode = startMode;
			MyHomeEquipMain.BgSpriteName = "map";
			questManager.CurQuest = curQuest;
			ChangeSceneLikeQuestSubScene(SceneID.Ui_MyHomeEquip);
		}
	}

	private void PushSort(string key)
	{
		if (!base.IsChangingSituation)
		{
			LockTouch(on: false);
			if (mode == WORLD_RAID_MODE.Help)
			{
				mapetList.PushSort(key);
			}
		}
	}

	private void PushDetail(GameObject obj)
	{
		if (!base.IsChangingSituation)
		{
			LockTouch(on: false);
			if (curFrPet != null && (bool)detailPoppetInfo && !detailPoppetInfo.active)
			{
				detailPoppetInfo.SetMuppet(curFrPet, ignoreUnknown: true);
				UIAutoTweenerStandAloneEx.In(detailPoppetInfo.gameObject);
				ChangeMode(WORLD_RAID_MODE.Detail);
			}
		}
	}

	private void PushUnion()
	{
		if (unionButtonValidCtrl != null && !unionButtonValidCtrl.isValidColor)
		{
			LockTouch(on: false);
		}
		else if (!base.IsChangingSituation)
		{
			LockTouch(on: false);
			TownShopTopMain.backScene = SceneChanger.CurrentSceneName;
			TownShopTopMain.readTown = false;
			MessageBoard.BgSpriteName = "map";
			MessageBoard.StartMode = MessageBoard.START_MODE.union;
			ChangeSceneLikeQuestSubScene(SceneID.Ui_MessageBoard);
			QuestMenuBase.respFriends = null;
		}
	}

	private void PushLog()
	{
		if (base.IsChangingSituation)
		{
			return;
		}
		if (mode != 0)
		{
			LockTouch(on: false);
			return;
		}
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024PushLog_0024showLogPage_00243217_002422380(this).GetEnumerator();
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private void PushBack(GameObject obj)
	{
		if (base.IsChangingSituation)
		{
			return;
		}
		if (CurrentSituation == stoneList.Situation)
		{
			stoneList.PushCancel();
		}
		else if (mode == WORLD_RAID_MODE.Info)
		{
			RetrunToWorldMap();
			QuestMenuBase.respFriends = null;
		}
		else if (mode == WORLD_RAID_MODE.Help)
		{
			ChangeMode(WORLD_RAID_MODE.Info);
		}
		else if (mode == WORLD_RAID_MODE.Conf)
		{
			if (IsShowConfQuestSupportDialog)
			{
				ConfQuest.ShowSupportDialog(aValid: false);
			}
			else if (!DeckSelector.isSwipe)
			{
				confQuest.Close();
				ChangeMode(WORLD_RAID_MODE.Help);
			}
		}
		else if (mode == WORLD_RAID_MODE.Detail)
		{
			ChangeMode(WORLD_RAID_MODE.Help);
			UIAutoTweenerStandAloneEx.Out(detailPoppetInfo.gameObject);
		}
		else if (mode == WORLD_RAID_MODE.Log)
		{
			ChangeMode(WORLD_RAID_MODE.Info);
			listTween.Out();
			pageTween.Out();
		}
	}

	private void PushStartPlayerRaid(int index)
	{
		if (base.IsChangingSituation || DeckSelector.isSwipe)
		{
			return;
		}
		if (IsEndRaid())
		{
			NoneBoss();
		}
		else
		{
			if (canRaidConnection || stoneListBusy)
			{
				return;
			}
			UserData current = UserData.Current;
			int num = 0;
			switch (index)
			{
			case 0:
				num = 3;
				break;
			case 1:
				num = 1;
				break;
			default:
				return;
			}
			if (current.Rp < num)
			{
				stoneListBusy = true;
				stoneList.ShowCureRpDialog();
				stoneList.OnEnd = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34___0024211.Adapt(delegate
				{
					stoneListBusy = false;
					lastMode = WORLD_RAID_MODE.None;
				});
			}
			else
			{
				ModalCollider.SetActive(this, active: true);
				IEnumerator enumerator = StartRaidCore(num);
				if (enumerator != null)
				{
					StartCoroutine(enumerator);
				}
			}
		}
	}

	public override void ConfQuestCtrl()
	{
		if (!initConfQuest)
		{
			DeckSelector.SetCurEquip();
			initConfQuest = true;
		}
		bool flag = null != curFrPet;
		if (IsTutorial)
		{
			bool num = flag;
			if (num)
			{
				num = null != curQuest;
			}
			flag = num;
		}
		if (flag)
		{
			if ((bool)confQuestButtonValidCtrl)
			{
				confQuestButtonValidCtrl.isValidColor = true;
			}
			if ((bool)confQuestButton2ValidCtrl)
			{
				confQuestButton2ValidCtrl.isValidColor = true;
			}
		}
		else
		{
			if ((bool)confQuestButtonValidCtrl)
			{
				confQuestButtonValidCtrl.isValidColor = false;
			}
			if ((bool)confQuestButton2ValidCtrl)
			{
				confQuestButton2ValidCtrl.isValidColor = false;
			}
		}
	}

	private IEnumerator StartRaidCore(int needRp)
	{
		return new _0024StartRaidCore_002422351(needRp, this).GetEnumerator();
	}

	private void Debug_LocalRaidPostSceneChangeEvent(SceneID sceneId, string sceneName)
	{
		SceneChanger.ScenePostChangeEvent -= Debug_LocalRaidPostSceneChangeEvent;
		PhotonClientMain photonClientMain = (PhotonClientMain)UnityEngine.Object.FindObjectOfType(typeof(PhotonClientMain));
		GameObject gameObject = photonClientMain.gameObject;
		LocalRaidViewer localRaidViewer = (LocalRaidViewer)gameObject.AddComponent(typeof(LocalRaidViewer));
		localRaidViewer.計測テストモード = photonClientMain.testMode;
		localRaidViewer.開始演出プレハブ = photonClientMain.openingPrefab;
		localRaidViewer.開始演出待ち時間 = photonClientMain.openingTime;
		localRaidViewer.タイムアウト時間 = photonClientMain.timeout;
		localRaidViewer.ゲームオーバー用プレハブ = photonClientMain.gameOverPrefab;
		localRaidViewer.ゲームオーバー待ち時間 = photonClientMain.gameOverWaitTime;
		localRaidViewer.ゲームオーバー時戻り先シーン名 = "Ui_WorldRaid";
		localRaidViewer.プレーヤー初期位置 = photonClientMain.playerInitialPos;
		localRaidViewer.全力エフェクト = photonClientMain.fullPowerEffect;
		localRaidViewer.登場エフェクト = photonClientMain.enterEffect;
		localRaidViewer.退室エフェクト = photonClientMain.leaveEffect;
		localRaidViewer.ボステリトリ半径 = photonClientMain.bossTerritoryRadius;
		localRaidViewer.smokeEffect = photonClientMain.smokeEffect;
		localRaidViewer.setReady(b: true);
		UnityEngine.Object.Destroy(photonClientMain);
	}

	private bool isLocalRaidActive()
	{
		int num = 0;
		MCycleSchedules[] all = MCycleSchedules.All;
		int length = all.Length;
		int result;
		while (true)
		{
			if (num < length)
			{
				if (all[num].EndDate == LocalRaidViewer.RAID_END_DATE_REGARD_AS_LOCAL_RAID)
				{
					result = 1;
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = 0;
			break;
		}
		return (byte)result != 0;
	}

	internal bool _0024SceneInitialize_0024closure_00243161()
	{
		return mode != WORLD_RAID_MODE.Help;
	}

	internal void _0024SceneStart_0024closure_00243162()
	{
		DeckSelector.Init(UserData.Current.userDeckData2.CurrentDeck, UserData.Current.userDeckData2.deckNum());
		if (debug_localRaid)
		{
			SendDummyRequestRaidBattle();
		}
		else
		{
			SendRequestRaidBattle();
		}
	}

	internal IEnumerator _0024SendRequestRaidBattle_0024send_00243163()
	{
		return new _0024_0024SendRequestRaidBattle_0024send_00243163_002422366(this).GetEnumerator();
	}

	internal IEnumerator _0024Initialize_0024send_00243165()
	{
		return new _0024_0024Initialize_0024send_00243165_002422371(this).GetEnumerator();
	}

	internal IEnumerator _0024SendDummyRequestRaidBattle_0024send_00243166()
	{
		UserData current = UserData.Current;
		bool flag = false;
		RespTCycleRaidBattle respTCycleRaidBattle = current.userRaidInfo.raidBattle;
		if (respTCycleRaidBattle != null && LastRaidCycleId != respTCycleRaidBattle.TCycleId)
		{
			if (respTCycleRaidBattle.IsEnableRaid)
			{
				LastRaidCycleId = respTCycleRaidBattle.TCycleId;
			}
			LastBattleDate = string.Empty;
			LastDiscoverDate = string.Empty;
			ChangeMode(WORLD_RAID_MODE.RaidDiscover);
			enabledCutscene = true;
		}
		raidInfo.UpdateFlag = true;
		isDiscovered = HasDiscovered(respTCycleRaidBattle);
		if (respTCycleRaidBattle != null && respTCycleRaidBattle.IsEnableRaid)
		{
			isDead = respTCycleRaidBattle.Hp <= 0;
		}
		Initialize();
		return null;
	}

	internal void _0024InitializeHelpPlayer_0024closure_00243167()
	{
		SceneReload();
		QuestMenuBase.respFriends = null;
	}

	internal void _0024InitializeHelpPlayer_0024closure_00243168(ApiFriendPlayerSearch req)
	{
		if (isNoRaid || isDead || !isDiscovered)
		{
			return;
		}
		if (req == null)
		{
			SceneReload();
			QuestMenuBase.respFriends = null;
			return;
		}
		ApiFriendPlayerSearch.Resp response = req.GetResponse();
		if (response == null)
		{
			throw new AssertionFailedException("resp != null");
		}
		QuestMenuBase.respFriends = response.Friends;
		curFrPet = null;
	}

	internal void _0024LoadBossModel_0024closure_00243169(GameObject go)
	{
		if (!(go != null))
		{
			throw new AssertionFailedException("go != null");
		}
		if (bossModel != null)
		{
			UnityEngine.Object.DestroyObject(bossModel);
			bossModel = null;
		}
		bossModel = go;
		CharacterController component = bossModel.GetComponent<CharacterController>();
		component.enabled = false;
		PicBookContents component2 = bossModel.GetComponent<PicBookContents>();
		if (component2 != null)
		{
			bossModel.transform.localScale = component2.PicBookDisplayScale;
			bossModel.transform.localPosition = component2.PicBookDisplayPosition;
			bossModel.transform.localEulerAngles = component2.PicBookDisplayRotation;
		}
		else
		{
			bossModel.transform.localPosition = new Vector3(0f, 0f, 0f);
		}
		D540ScriptRunner component3 = bossModel.GetComponent<D540ScriptRunner>();
		if ((bool)component3)
		{
			component3.enabled = false;
		}
	}

	internal void _0024InitMode_0024closure_00243170()
	{
		Initialize();
	}

	internal void _0024InitMode_0024closure_00243171()
	{
		Initialize();
	}

	internal void _0024InitMode_0024callback_00243172()
	{
		ChangeMode(WORLD_RAID_MODE.Info);
		GameSoundManager.Reset = true;
		SwitchCamera(isCutScene: false);
		doCutScene = false;
	}

	internal void _0024BossEscaped_0024closure_00243175()
	{
		canRaidConnection = false;
		hasOpenedEscapeDialog = false;
		finishBossEscaped = true;
		ModalCollider.SetActive(this, active: false);
		ChangeMode(WORLD_RAID_MODE.Info);
	}

	internal IEnumerator _0024PushHelp_0024coroutine_00243176()
	{
		return new _0024_0024PushHelp_0024coroutine_00243176_002422376(this).GetEnumerator();
	}

	internal IEnumerator _0024PushLog_0024showLogPage_00243217()
	{
		return new _0024_0024PushLog_0024showLogPage_00243217_002422380(this).GetEnumerator();
	}

	internal void _0024_0024PushLog_0024showLogPage_00243217_0024closure_00243218()
	{
		pageTween.InHandler = null;
		listTween.In(_0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024172.Adapt(delegate
		{
			listTween.InHandler = null;
			LockTouch(on: false);
		}));
	}

	internal void _0024_0024_0024PushLog_0024showLogPage_00243217_0024closure_00243218_0024closure_00243219()
	{
		listTween.InHandler = null;
		LockTouch(on: false);
	}

	internal void _0024PushStartPlayerRaid_0024closure_00243220()
	{
		stoneListBusy = false;
		lastMode = WORLD_RAID_MODE.None;
	}

	internal void _0024StartRaidCore_0024closure_00243222(ApiGuildRaidStart req)
	{
		canRaidConnection = false;
		ModalCollider.SetActive(this, active: false);
		SceneReload();
	}

	internal void _0024StartRaidCore_0024closure_00243223(ApiGuildRaidStart req)
	{
		PhotonClientMain.RaidStartResponse = req.GetResponse();
		if (req.IsOk)
		{
			PhotonClientMain.SavePlayInfo(req.GetResponse());
			SceneChanger.ChangeTo(SceneID.RaidBattle);
			QuestMenuBase.respFriends = null;
			LastBattleDate = raidBattle.DiscoverDate.ToString();
		}
		canRaidConnection = false;
	}

	internal IEnumerator _0024SendDeck2_002422363()
	{
		return SendDeck2();
	}

	internal bool _0024get_IsChangingSituation_002422384()
	{
		return base.IsChangingSituation;
	}
}
