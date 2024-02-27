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
public class WorldQuestResultMain : UIMain
{
	[Serializable]
	public enum WORLD_QUEST_RESULT_MODE
	{
		None = -1,
		Result,
		Friend,
		WeaponDetail,
		PetDetail,
		FriendDetail,
		ResultFinish,
		Sell,
		SellConf,
		ResultShortcut,
		Mission,
		MissionDetail
	}

	[Serializable]
	private class TempMainData
	{
		public bool clearFlag;

		public bool alreadyClearFlag;

		public MStories mstory;

		public RespQuestResult qresult;

		public bool failed;

		public override string ToString()
		{
			string lhs = "TempMainData {\n";
			lhs += "\tclearFlag: " + clearFlag.ToString() + "\n";
			lhs += "\talreadyClearFlag: " + alreadyClearFlag.ToString() + "\n";
			lhs += "\tmstory: " + ((mstory == null) ? "null" : mstory.ToString()) + "\n";
			lhs += "\tqresult: " + ((qresult == null) ? "null" : qresult.ToString()) + "\n";
			lhs += "\tfailed: " + failed.ToString() + "\n";
			return lhs + "}";
		}
	}

	[Serializable]
	private class ResultShortcutData
	{
		public EnumQuestTypes questType;

		public SceneID nextSceneId;

		public EnumAreaTypes nextArea;

		public ResultShortcut.IntoScene intoScene;
	}

	[Serializable]
	internal class _0024flowTutoRaid_0024locals_002414563
	{
		internal ApiTutorialPutInBox _0024tutoItemRequest;

		internal RespPlayerBox[] _0024oldBox;

		internal bool _0024ok;
	}

	[Serializable]
	internal class _0024PushYes_0024locals_002414564
	{
		internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024endFunc;
	}

	[Serializable]
	internal class _0024SendSell_0024locals_002414565
	{
		internal BoxId[] _0024sellItemIds;
	}

	[Serializable]
	internal class _0024ChangeScene_0024locals_002414566
	{
		internal bool _0024gotoNextScene;

		internal SceneID _0024nextScene;
	}

	[Serializable]
	internal class _0024flowTutoRaid_0024closure_00244245
	{
		internal WorldQuestResultMain _0024this_002415251;

		internal _0024flowTutoRaid_0024locals_002414563 _0024_0024locals_002415252;

		public _0024flowTutoRaid_0024closure_00244245(WorldQuestResultMain _0024this_002415251, _0024flowTutoRaid_0024locals_002414563 _0024_0024locals_002415252)
		{
			this._0024this_002415251 = _0024this_002415251;
			this._0024_0024locals_002415252 = _0024_0024locals_002415252;
		}

		public void Invoke()
		{
			_0024_0024locals_002415252._0024ok = true;
			RespPlayerBox[] box = _0024_0024locals_002415252._0024tutoItemRequest.GetResponse().Box;
			_0024this_002415251.tutoItemRewards = (RespReward[])RuntimeServices.AddArrays(typeof(RespReward), _0024this_002415251.tutoItemRewards, _0024this_002415251.CreateTutorialItemRewards(_0024_0024locals_002415252._0024oldBox, box));
		}
	}

	[Serializable]
	internal class _0024PushYes_0024closure_00244270
	{
		internal _0024PushYes_0024locals_002414564 _0024_0024locals_002415253;

		public _0024PushYes_0024closure_00244270(_0024PushYes_0024locals_002414564 _0024_0024locals_002415253)
		{
			this._0024_0024locals_002415253 = _0024_0024locals_002415253;
		}

		public void Invoke()
		{
			_0024_0024locals_002415253._0024endFunc();
		}
	}

	[Serializable]
	internal class _0024PushYes_0024closure_00244271
	{
		internal _0024PushYes_0024locals_002414564 _0024_0024locals_002415254;

		public _0024PushYes_0024closure_00244271(_0024PushYes_0024locals_002414564 _0024_0024locals_002415254)
		{
			this._0024_0024locals_002415254 = _0024_0024locals_002415254;
		}

		public void Invoke(RequestBase r)
		{
			if (r.ResponseObj is GameApiResponseBase { StatusCode: var statusCode })
			{
				string text = statusCode.ToLower();
				string text2 = text;
				if (text2 == "frapp005")
				{
					_0024_0024locals_002415254._0024endFunc();
				}
				else if (text2 == "frapp002")
				{
					_0024_0024locals_002415254._0024endFunc();
				}
			}
		}
	}

	[Serializable]
	internal class _0024PushYes_0024closure_00244272
	{
		internal _0024PushYes_0024locals_002414564 _0024_0024locals_002415255;

		public _0024PushYes_0024closure_00244272(_0024PushYes_0024locals_002414564 _0024_0024locals_002415255)
		{
			this._0024_0024locals_002415255 = _0024_0024locals_002415255;
		}

		public void Invoke()
		{
			_0024_0024locals_002415255._0024endFunc();
		}
	}

	[Serializable]
	internal class _0024SendSell_0024callback_00244273
	{
		internal _0024SendSell_0024locals_002414565 _0024_0024locals_002415256;

		internal WorldQuestResultMain _0024this_002415257;

		public _0024SendSell_0024callback_00244273(_0024SendSell_0024locals_002414565 _0024_0024locals_002415256, WorldQuestResultMain _0024this_002415257)
		{
			this._0024_0024locals_002415256 = _0024_0024locals_002415256;
			this._0024this_002415257 = _0024this_002415257;
		}

		public void Invoke()
		{
			_0024this_002415257.SetRewards(_0024this_002415257.rewardList.ToArray(), _0024_0024locals_002415256._0024sellItemIds);
			_0024this_002415257.mode = WORLD_QUEST_RESULT_MODE.ResultFinish;
			StorageHUD.DoUpdateNow();
		}
	}

	[Serializable]
	internal class _0024ChangeScene_0024waitCoroutine_00244274
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002422330 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal _0024ChangeScene_0024waitCoroutine_00244274 _0024self__002422331;

				public _0024(_0024ChangeScene_0024waitCoroutine_00244274 self_)
				{
					_0024self__002422331 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						if (!_0024self__002422331._0024_0024locals_002415258._0024gotoNextScene)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						UserData.Current.userMiscInfo.Backup();
						SceneChanger.ChangeTo(_0024self__002422331._0024_0024locals_002415258._0024nextScene);
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
					return (byte)result != 0;
				}
			}

			internal _0024ChangeScene_0024waitCoroutine_00244274 _0024self__002422332;

			public _0024Invoke_002422330(_0024ChangeScene_0024waitCoroutine_00244274 self_)
			{
				_0024self__002422332 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002422332);
			}
		}

		internal _0024ChangeScene_0024locals_002414566 _0024_0024locals_002415258;

		public _0024ChangeScene_0024waitCoroutine_00244274(_0024ChangeScene_0024locals_002414566 _0024_0024locals_002415258)
		{
			this._0024_0024locals_002415258 = _0024_0024locals_002415258;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002422330(this).GetEnumerator();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002422224 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal TempMainData _0024tempData_002422225;

			internal IEnumerator _0024_0024sco_0024temp_00242687_002422226;

			internal IEnumerator _0024_0024sco_0024temp_00242688_002422227;

			internal IEnumerator _0024_0024sco_0024temp_00242689_002422228;

			internal IEnumerator _0024_0024sco_0024temp_00242690_002422229;

			internal IEnumerator _0024_0024sco_0024temp_00242691_002422230;

			internal WorldQuestResultMain _0024self__002422231;

			public _0024(WorldQuestResultMain self_)
			{
				_0024self__002422231 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024tempData_002422225 = new TempMainData();
					_0024self__002422231.flowInit(ref _0024tempData_002422225);
					if (_0024self__002422231.raidFlag)
					{
						_0024_0024sco_0024temp_00242687_002422226 = _0024self__002422231.flowRaidResult(ref _0024tempData_002422225);
						if (_0024_0024sco_0024temp_00242687_002422226 != null)
						{
							result = (Yield(2, _0024self__002422231.StartCoroutine(_0024_0024sco_0024temp_00242687_002422226)) ? 1 : 0);
							break;
						}
					}
					else
					{
						_0024_0024sco_0024temp_00242688_002422227 = _0024self__002422231.flowQuestResult(ref _0024tempData_002422225);
						if (_0024_0024sco_0024temp_00242688_002422227 != null)
						{
							result = (Yield(3, _0024self__002422231.StartCoroutine(_0024_0024sco_0024temp_00242688_002422227)) ? 1 : 0);
							break;
						}
					}
					goto case 2;
				case 2:
				case 3:
					if (_0024tempData_002422225.failed)
					{
						goto case 1;
					}
					_0024self__002422231.flowFriend();
					_0024_0024sco_0024temp_00242689_002422228 = _0024self__002422231.flowTutoRaid(ref _0024tempData_002422225);
					if (_0024_0024sco_0024temp_00242689_002422228 != null)
					{
						result = (Yield(4, _0024self__002422231.StartCoroutine(_0024_0024sco_0024temp_00242689_002422228)) ? 1 : 0);
						break;
					}
					goto case 4;
				case 4:
					if (_0024tempData_002422225.failed)
					{
						goto case 1;
					}
					if (_0024self__002422231.specialRewardInfo != null)
					{
						_0024self__002422231.flowSpecialReward(ref _0024tempData_002422225);
					}
					_0024_0024sco_0024temp_00242690_002422229 = _0024self__002422231.flowFinish();
					if (_0024_0024sco_0024temp_00242690_002422229 != null)
					{
						result = (Yield(5, _0024self__002422231.StartCoroutine(_0024_0024sco_0024temp_00242690_002422229)) ? 1 : 0);
						break;
					}
					goto case 5;
				case 5:
					_0024self__002422231.isNetBusy = false;
					_0024_0024sco_0024temp_00242691_002422230 = _0024self__002422231.flowOpenIcon();
					if (_0024_0024sco_0024temp_00242691_002422230 != null)
					{
						result = (Yield(6, _0024self__002422231.StartCoroutine(_0024_0024sco_0024temp_00242691_002422230)) ? 1 : 0);
						break;
					}
					goto case 6;
				case 6:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal WorldQuestResultMain _0024self__002422232;

		public _0024main_002422224(WorldQuestResultMain self_)
		{
			_0024self__002422232 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422232);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024flowFinish_002422233 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal WorldQuestResultMain _0024self__002422234;

			public _0024(WorldQuestResultMain self_)
			{
				_0024self__002422234 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__002422234.raidTutorial)
					{
						FacebookBridge.CompletedTutorial();
						MerlinServer.Request(ApiUpdateTutorial.RaidOpened());
					}
					_0024self__002422234.isMission = false;
					if (_0024self__002422234.curQuest != null && null != _0024self__002422234.missionList)
					{
						_0024self__002422234.isMission = _0024self__002422234.missionList.SetQuest(_0024self__002422234.curQuest, MissionList.ListType.Result);
						if (_0024self__002422234.enableMissionReward)
						{
							_0024self__002422234.missionList.EnablePushItemNewMissionAnimation = false;
						}
						else
						{
							_0024self__002422234.missionList.EnablePushItemNewMissionAnimation = true;
						}
						_0024self__002422234.missionList.eventNewMissionAnimationFinish += delegate
						{
							if (_0024self__002422234.missionOkButtonSet != null)
							{
								UIBasicUtility.SetButtonValid(_0024self__002422234.missionOkButtonSet, e: true);
							}
						};
					}
					MerlinGameCenter.Instance.CheckAchievements();
					MerlinServer.Busy = false;
					goto case 2;
				case 2:
					if (MerlinServer.Instance.IsBusy)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002422234.mode = WORLD_QUEST_RESULT_MODE.Result;
					_0024self__002422234.lastMode = WORLD_QUEST_RESULT_MODE.None;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal WorldQuestResultMain _0024self__002422235;

		public _0024flowFinish_002422233(WorldQuestResultMain self_)
		{
			_0024self__002422235 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002422235);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024flowQuestResult_002422236 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00242692_002422237;

			internal TempMainData _0024tempData_002422238;

			internal WorldQuestResultMain _0024self__002422239;

			public _0024(TempMainData tempData, WorldQuestResultMain self_)
			{
				_0024tempData_002422238 = tempData;
				_0024self__002422239 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (TutorialFlowControl.IsInTutorial)
					{
						_0024self__002422239.flowTutorial(ref _0024tempData_002422238);
					}
					else if (_0024self__002422239.debug_Connection)
					{
						_0024self__002422239.flowDebugConnection(ref _0024tempData_002422238);
					}
					else
					{
						_0024_0024sco_0024temp_00242692_002422237 = _0024self__002422239.flowQuestResultRequest(ref _0024tempData_002422238);
						if (_0024_0024sco_0024temp_00242692_002422237 != null)
						{
							result = (Yield(2, _0024self__002422239.StartCoroutine(_0024_0024sco_0024temp_00242692_002422237)) ? 1 : 0);
							break;
						}
					}
					goto case 2;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
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

		internal TempMainData _0024tempData_002422240;

		internal WorldQuestResultMain _0024self__002422241;

		public _0024flowQuestResult_002422236(TempMainData tempData, WorldQuestResultMain self_)
		{
			_0024tempData_002422240 = tempData;
			_0024self__002422241 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024tempData_002422240, _0024self__002422241);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024flowQuestResultRequest_002422242 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal MQuests _0024mquest_002422243;

			internal string _0024qname_002422244;

			internal ApiQuestResult _0024ereq_002422245;

			internal UserData _0024ud_002422246;

			internal RespQuestResult _0024qresult_002422247;

			internal ApiPresent _0024apiPresent_002422248;

			internal TempMainData _0024td_002422249;

			internal WorldQuestResultMain _0024self__002422250;

			public _0024(TempMainData td, WorldQuestResultMain self_)
			{
				_0024td_002422249 = td;
				_0024self__002422250 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024mquest_002422243 = QuestSession.Quest;
					_0024td_002422249.mstory = QuestSession.Story;
					if ((bool)_0024self__002422250.questNameLabel && _0024mquest_002422243 != null)
					{
						_0024qname_002422244 = string.Empty;
						if (_0024mquest_002422243.IsChallenge)
						{
							_0024qname_002422244 = MTexts.Msg("$WQR_CHALLENGE_NAME");
						}
						else
						{
							_0024qname_002422244 = _0024mquest_002422243.GetName();
						}
						UIBasicUtility.SetLabel(_0024self__002422250.questNameLabel, _0024qname_002422244, show: true);
					}
					if (QuestSession.IsSessionSucceeded)
					{
						if ((bool)_0024self__002422250.cleqStamp)
						{
							_0024self__002422250.cleqStamp.SetActive(value: true);
						}
						_0024td_002422249.clearFlag = true;
					}
					else if (!QuestSession.IsSessionFailed)
					{
						_0024td_002422249.clearFlag = true;
					}
					_0024ereq_002422245 = QuestSession.EndQuest();
					if (QuestSession.WithServer)
					{
						goto case 2;
					}
					goto IL_0171;
				case 2:
					if (!_0024ereq_002422245.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024ereq_002422245.IsOk)
					{
						goto IL_0171;
					}
					MerlinServer.Busy = false;
					SceneChanger.ChangeTo(SceneID.Town);
					_0024td_002422249.failed = true;
					goto case 1;
				case 3:
					if (!_0024apiPresent_002422248.IsEnd)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__002422250.presents = _0024apiPresent_002422248.GetResponse().PresentBox;
					goto IL_0405;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0405:
					YieldDefault(1);
					goto case 1;
					IL_0171:
					_0024ud_002422246 = UserData.Current;
					if (_0024ud_002422246 == null)
					{
						throw new AssertionFailedException("ud != null");
					}
					MerlinServer.Busy = true;
					if (_0024td_002422249.clearFlag && _0024self__002422250.curQuest != null)
					{
						_0024ud_002422246.userMiscInfo.questData.clear(_0024self__002422250.curQuest.Id);
					}
					_0024self__002422250.newLevel = _0024ud_002422246.Level;
					_0024self__002422250.newCoin = _0024ud_002422246.Coin;
					_0024self__002422250.newExp = _0024ud_002422246.Exp;
					_0024self__002422250.newAp = _0024ud_002422246.MaxAp;
					_0024self__002422250.newBoxCount = _0024ud_002422246.BoxCapacity;
					_0024self__002422250.newFriendCount = _0024ud_002422246.FriendMax;
					_0024self__002422250.newFriendPoint = _0024ud_002422246.Fp;
					if (_0024self__002422250.lastStartResponse != null)
					{
						_0024self__002422250.oldFriendPoint = checked(_0024self__002422250.newFriendPoint - _0024self__002422250.lastStartResponse.FriendPoint);
					}
					_0024qresult_002422247 = QuestSession.GetLastResult();
					if (_0024qresult_002422247 != null)
					{
						_0024self__002422250.resultCoin = _0024qresult_002422247.Coin;
						_0024self__002422250.resultExp = _0024qresult_002422247.Exp;
						_0024self__002422250.newChallengPoint = _0024qresult_002422247.ChallengePoint;
						_0024self__002422250.oldTotalChallengePoint = _0024qresult_002422247.StoredChallengePoint;
						if (_0024ud_002422246.userChallengeInfo.challengRanking != null && (int)_0024self__002422250.oldTotalChallengePoint == 0)
						{
							_0024self__002422250.oldTotalChallengePoint = _0024ud_002422246.userChallengeInfo.challengRanking.RankingPoint;
						}
					}
					_0024td_002422249.qresult = _0024qresult_002422247;
					if (QuestSession.WithServer)
					{
						_0024self__002422250.friend = QuestSession.LastStartResponse.Fellow;
					}
					_0024self__002422250.oldPresents = QuestSession.GetLastPresents();
					if (_0024self__002422250.oldPresents != null)
					{
						_0024apiPresent_002422248 = new ApiPresent();
						MerlinServer.Request(_0024apiPresent_002422248);
						goto case 3;
					}
					goto IL_0405;
				}
				return (byte)result != 0;
			}
		}

		internal TempMainData _0024td_002422251;

		internal WorldQuestResultMain _0024self__002422252;

		public _0024flowQuestResultRequest_002422242(TempMainData td, WorldQuestResultMain self_)
		{
			_0024td_002422251 = td;
			_0024self__002422252 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024td_002422251, _0024self__002422252);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024flowRaidResult_002422253 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal UserData _0024ud_002422254;

			internal ApiPresent _0024apiPresent_002422255;

			internal ApiGuildResult _0024apiRaid_002422256;

			internal ApiGuildResult.Resp _0024resRaid_002422257;

			internal string _0024msg_002422258;

			internal string _0024title_002422259;

			internal int _0024damage_002422260;

			internal TempMainData _0024td_002422261;

			internal WorldQuestResultMain _0024self__002422262;

			public _0024(TempMainData td, WorldQuestResultMain self_)
			{
				_0024td_002422261 = td;
				_0024self__002422262 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024ud_002422254 = UserData.Current;
						if (_0024ud_002422254 == null)
						{
							throw new AssertionFailedException("ud != null");
						}
						if (PhotonClientMain.RaidStartResponse != null)
						{
							_0024apiPresent_002422255 = new ApiPresent();
							MerlinServer.Request(_0024apiPresent_002422255);
							goto case 2;
						}
						if (!_0024self__002422262.debug_Connection)
						{
							_0024td_002422261.failed = true;
							if (0 == 0)
							{
								throw new AssertionFailedException("PhotonClientMain.RaidStartResponse is null");
							}
						}
						goto IL_031b;
					case 2:
						if (!_0024apiPresent_002422255.IsEnd)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024self__002422262.friend = QuestManager.Instance.CurFrPoppet.RespFriend;
						_0024apiRaid_002422256 = new ApiGuildResult();
						_0024apiRaid_002422256.CycleId = PhotonClientMain.RaidStartResponse.CycleId;
						_0024apiRaid_002422256.Damage = PhotonClientMain.AllSendedDamage;
						_0024apiRaid_002422256.IsDead = PhotonClientMain.BossIsDead;
						_0024apiRaid_002422256.TicketId = PhotonClientMain.RaidStartResponse.TicketId;
						_0024td_002422261.clearFlag = _0024apiRaid_002422256.IsDead;
						MerlinServer.Request(_0024apiRaid_002422256);
						goto case 3;
					case 3:
						if (!_0024apiRaid_002422256.IsEnd)
						{
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						if (!_0024apiRaid_002422256.IsOk)
						{
							SceneChanger.ChangeTo(SceneID.Ui_WorldRaid);
							_0024td_002422261.failed = true;
						}
						else
						{
							PhotonClientMain.DeleteSaveData();
							_0024resRaid_002422257 = _0024apiRaid_002422256.GetResponse();
							if (_0024resRaid_002422257.IsCallLeave)
							{
								if (_0024td_002422261.clearFlag)
								{
									UserData.Current.userMiscInfo.raidData.LastBattleRaidDiscoverDate = string.Empty;
								}
								_0024self__002422262.newRaidPoint = _0024resRaid_002422257.Point;
								_0024self__002422262.oldTotalRaidPoint = _0024resRaid_002422257.TotalPoint - (long)_0024resRaid_002422257.Point;
								_0024self__002422262.oldFriendPoint = _0024ud_002422254.Fp - PhotonClientMain.RaidStartResponse.FriendPoint;
								_0024self__002422262.newFriendPoint = _0024ud_002422254.Fp;
								_0024damage_002422260 = _0024resRaid_002422257.Damage;
								UIBasicUtility.SetLabel(_0024self__002422262.damageLabel, _0024damage_002422260.ToString("#,#,#,#,0"), show: true);
								_0024self__002422262.oldPresents = _0024apiPresent_002422255.GetResponse().PresentBox;
								_0024self__002422262.presents = _0024resRaid_002422257.PresentBox;
								goto IL_031b;
							}
							_0024msg_002422258 = MTexts.Msg("$WQR_RAID_ERROR");
							_0024title_002422259 = MTexts.Msg("$WQR_RAID_ERROR_TITLE");
							ErrorDialog.FatalError(_0024msg_002422258, _0024title_002422259, jumpBoot: true, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38___00242.Adapt(delegate
							{
								SceneChanger.ChangeTo(SceneID.Ui_WorldRaid);
							}));
							_0024self__002422262.isNetBusy = false;
							MerlinServer.Busy = false;
							_0024td_002422261.failed = true;
						}
						goto case 1;
					case 1:
						{
							result = 0;
							break;
						}
						IL_031b:
						YieldDefault(1);
						goto case 1;
					}
				}
				return (byte)result != 0;
			}
		}

		internal TempMainData _0024td_002422263;

		internal WorldQuestResultMain _0024self__002422264;

		public _0024flowRaidResult_002422253(TempMainData td, WorldQuestResultMain self_)
		{
			_0024td_002422263 = td;
			_0024self__002422264 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024td_002422263, _0024self__002422264);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024flowTutoRaid_002422265 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal MTutorialItems _0024tutoItem_002422266;

			internal UserData _0024ud_002422267;

			internal _0024flowTutoRaid_0024locals_002414563 _0024_0024locals_002422268;

			internal TempMainData _0024td_002422269;

			internal WorldQuestResultMain _0024self__002422270;

			public _0024(TempMainData td, WorldQuestResultMain self_)
			{
				_0024td_002422269 = td;
				_0024self__002422270 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002422268 = new _0024flowTutoRaid_0024locals_002414563();
					if (_0024self__002422270.curQuest == null || _0024self__002422270.curQuest.QuestType != EnumQuestTypes.Tutorial || _0024td_002422269.alreadyClearFlag || !_0024td_002422269.clearFlag)
					{
						goto case 1;
					}
					_0024tutoItem_002422266 = _0024self__002422270.curQuest.MTutorialItemId;
					if (0 < _0024tutoItem_002422266.Id)
					{
						_0024ud_002422267 = UserData.Current;
						_0024_0024locals_002422268._0024tutoItemRequest = new ApiTutorialPutInBox(_0024tutoItem_002422266.Id);
						_0024_0024locals_002422268._0024oldBox = _0024ud_002422267.userBoxData.AllItems;
						_0024_0024locals_002422268._0024ok = false;
						MerlinServer.Request(_0024_0024locals_002422268._0024tutoItemRequest, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024flowTutoRaid_0024closure_00244245(_0024self__002422270, _0024_0024locals_002422268).Invoke));
						goto case 2;
					}
					goto IL_014e;
				case 2:
					if (!_0024_0024locals_002422268._0024ok)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024_0024locals_002422268._0024ok = false;
					goto IL_014e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_014e:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal TempMainData _0024td_002422271;

		internal WorldQuestResultMain _0024self__002422272;

		public _0024flowTutoRaid_002422265(TempMainData td, WorldQuestResultMain self_)
		{
			_0024td_002422271 = td;
			_0024self__002422272 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024td_002422271, _0024self__002422272);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024flowOpenIcon_002422273 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal System.Collections.Generic.List<GameObject> _0024list_002422274;

			internal Transform _0024t_002422275;

			internal HUDSwitcher _0024s_002422276;

			internal GameObject _0024t_002422277;

			internal UIButtonMessage _0024btnMsg_002422278;

			internal RespReward[] _0024rewards_002422279;

			internal UserData _0024ud_002422280;

			internal RespWeapon[] _0024wpns_002422281;

			internal RespReward _0024r0_002422282;

			internal RespReward _0024r1_002422283;

			internal RespReward _0024r2_002422284;

			internal RespReward[] _0024dummyRewads_002422285;

			internal IEnumerator _0024_0024sco_0024temp_00242693_002422286;

			internal GameObject _0024t_002422287;

			internal RewardIconInfo _0024iconInfo_002422288;

			internal RespReward _0024reward_002422289;

			internal float _0024_0024wait_sec_0024temp_00242694_002422290;

			internal float _0024_0024wait_sec_0024temp_00242695_002422291;

			internal GameObject _0024t_002422292;

			internal int _0024_002411936_002422293;

			internal GameObject[] _0024_002411937_002422294;

			internal int _0024_002411938_002422295;

			internal int _0024_002411940_002422296;

			internal GameObject[] _0024_002411941_002422297;

			internal int _0024_002411942_002422298;

			internal int _0024_002411944_002422299;

			internal GameObject[] _0024_002411945_002422300;

			internal int _0024_002411946_002422301;

			internal IEnumerator _0024_0024iterator_002414196_002422302;

			internal WorldQuestResultMain _0024self__002422303;

			public _0024(WorldQuestResultMain self_)
			{
				_0024self__002422303 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024self__002422303.isEffect = true;
						goto case 2;
					case 2:
						if (_0024self__002422303.lastMode != 0)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024self__002422303.SetScreenTouch(b: false);
						if (_0024self__002422303.resultWindow != null)
						{
							_0024list_002422274 = new System.Collections.Generic.List<GameObject>();
							if (_0024self__002422303.treasureTabel != null)
							{
								_0024_0024iterator_002414196_002422302 = _0024self__002422303.treasureTabel.transform.GetEnumerator();
								while (_0024_0024iterator_002414196_002422302.MoveNext())
								{
									object obj = _0024_0024iterator_002414196_002422302.Current;
									if (!(obj is Transform))
									{
										obj = RuntimeServices.Coerce(obj, typeof(Transform));
									}
									_0024t_002422275 = (Transform)obj;
									_0024s_002422276 = _0024t_002422275.gameObject.GetComponent<HUDSwitcher>();
									if ((bool)_0024s_002422276)
									{
										_0024list_002422274.Add(_0024s_002422276.gameObject);
									}
								}
							}
							_0024list_002422274.Sort((GameObject a, GameObject b) => string.Compare(a.name, b.name));
							_0024self__002422303.treasureList = (GameObject[])Builtins.array(typeof(GameObject), _0024list_002422274);
							_0024_002411936_002422293 = 0;
							_0024_002411937_002422294 = _0024self__002422303.treasureList;
							_0024_002411938_002422295 = _0024_002411937_002422294.Length;
							while (_0024_002411936_002422293 < _0024_002411938_002422295 && (bool)_0024_002411937_002422294[_0024_002411936_002422293])
							{
								_0024btnMsg_002422278 = _0024_002411937_002422294[_0024_002411936_002422293].GetComponent<UIButtonMessage>();
								if (_0024btnMsg_002422278 != null)
								{
									_0024btnMsg_002422278.sendMessage = false;
								}
								_0024_002411936_002422293++;
							}
							_0024rewards_002422279 = new RespReward[0];
							if (_0024self__002422303.curQuest != null && _0024self__002422303.curQuest.QuestType == EnumQuestTypes.Tutorial)
							{
								_0024rewards_002422279 = (RespReward[])RuntimeServices.AddArrays(typeof(RespReward), _0024rewards_002422279, _0024self__002422303.tutoItemRewards);
							}
							if (!_0024self__002422303.raidFlag && TutorialFlowControl.IsInTutorial)
							{
								_0024ud_002422280 = UserData.Current;
								if (_0024ud_002422280 == null)
								{
									throw new AssertionFailedException("ud != null");
								}
								_0024self__002422303.oldCoin = 0;
								_0024self__002422303.resultCoin = _0024ud_002422280.Coin;
								_0024wpns_002422281 = _0024ud_002422280.CurrentWeapons;
								_0024r0_002422282 = _0024wpns_002422281[0].ToReward(1);
								_0024r1_002422283 = _0024wpns_002422281[1].ToReward(2);
								_0024r2_002422284 = _0024wpns_002422281[2].ToReward(3);
								_0024self__002422303.SetRewards(new RespReward[3] { _0024r0_002422282, _0024r1_002422283, _0024r2_002422284 });
							}
							else if (_0024self__002422303.debug_Connection)
							{
								_0024dummyRewads_002422285 = _0024self__002422303.CreateDummyRewards(UnityEngine.Random.Range(1, 10), -1);
								_0024rewards_002422279 = (RespReward[])RuntimeServices.AddArrays(typeof(RespReward), _0024rewards_002422279, _0024dummyRewads_002422285);
								_0024self__002422303.SetRewards(_0024rewards_002422279);
							}
							else
							{
								_0024rewards_002422279 = (RespReward[])RuntimeServices.AddArrays(typeof(RespReward), _0024rewards_002422279, QuestSession.ResultCollectedDrops());
								_0024self__002422303._genRewardsTrait(ref _0024rewards_002422279);
								_0024self__002422303.SetRewards(_0024rewards_002422279);
							}
							_0024_0024sco_0024temp_00242693_002422286 = _0024self__002422303.flowLevelUp();
							if (_0024_0024sco_0024temp_00242693_002422286 != null)
							{
								result = (Yield(3, _0024self__002422303.StartCoroutine(_0024_0024sco_0024temp_00242693_002422286)) ? 1 : 0);
								break;
							}
							goto case 3;
						}
						goto IL_06a3;
					case 3:
						_0024self__002422303.SetScreenTouch(b: true);
						_0024self__002422303.ShowBackButton(show: false);
						UIBasicUtility.SetButtonValid(_0024self__002422303.sellSwitchButtonSet, e: false);
						UIBasicUtility.SetButtonValid(_0024self__002422303.nextButtonSet, e: false);
						_0024_002411940_002422296 = 0;
						_0024_002411941_002422297 = _0024self__002422303.treasureList;
						_0024_002411942_002422298 = _0024_002411941_002422297.Length;
						goto IL_05f4;
					case 4:
						if (_0024_0024wait_sec_0024temp_00242694_002422290 > 0f)
						{
							_0024_0024wait_sec_0024temp_00242694_002422290 -= Time.deltaTime;
							result = (YieldDefault(4) ? 1 : 0);
							break;
						}
						if (_0024self__002422303.GetNewItemDemo(_0024reward_002422289))
						{
							PlayerParameter.SetActive(a: false);
							InfomationBarHUD.SetActive(a: false);
							SceneTitleHUD.SetActive(a: false);
							StorageHUD.SetActive(a: false);
							goto case 5;
						}
						goto IL_05da;
					case 5:
						if (_0024self__002422303.isNewItemDemo)
						{
							result = (YieldDefault(5) ? 1 : 0);
							break;
						}
						PlayerParameter.SetActive(a: true);
						InfomationBarHUD.SetActive(a: true);
						SceneTitleHUD.SetActive(a: true);
						StorageHUD.SetActive(a: true);
						_0024_0024wait_sec_0024temp_00242695_002422291 = 0.25f;
						goto case 6;
					case 6:
						if (_0024_0024wait_sec_0024temp_00242695_002422291 > 0f)
						{
							_0024_0024wait_sec_0024temp_00242695_002422291 -= Time.deltaTime;
							result = (YieldDefault(6) ? 1 : 0);
							break;
						}
						goto IL_05da;
					case 7:
						_0024self__002422303.isEffect = false;
						_0024self__002422303.SetScreenTouch(_0024self__002422303.raidFlag);
						UIBasicUtility.SetButtonValid(_0024self__002422303.sellSwitchButtonSet, _0024self__002422303.showSellSwitchButton);
						UIBasicUtility.SetButtonValid(_0024self__002422303.nextButtonSet, e: true);
						_0024self__002422303.mode = WORLD_QUEST_RESULT_MODE.ResultFinish;
						YieldDefault(1);
						goto case 1;
					case 1:
						{
							result = 0;
							break;
						}
						IL_06a3:
						result = (YieldDefault(7) ? 1 : 0);
						break;
						IL_05da:
						_0024iconInfo_002422288.OpenIcon(enableSe: true);
						goto IL_05e6;
						IL_05e6:
						_0024_002411940_002422296++;
						goto IL_05f4;
						IL_05f4:
						if (_0024_002411940_002422296 < _0024_002411942_002422298 && _0024_002411941_002422297[_0024_002411940_002422296].activeInHierarchy)
						{
							_0024iconInfo_002422288 = _0024_002411941_002422297[_0024_002411940_002422296].GetComponent<RewardIconInfo>();
							if (!_0024iconInfo_002422288)
							{
								goto IL_05e6;
							}
							_0024reward_002422289 = _0024iconInfo_002422288.CurReward;
							_0024_0024wait_sec_0024temp_00242694_002422290 = 0.25f;
							goto case 4;
						}
						_0024_002411944_002422299 = 0;
						_0024_002411945_002422300 = _0024self__002422303.treasureList;
						_0024_002411946_002422301 = _0024_002411945_002422300.Length;
						while (_0024_002411944_002422299 < _0024_002411946_002422301 && (bool)_0024_002411945_002422300[_0024_002411944_002422299])
						{
							_0024btnMsg_002422278 = _0024_002411945_002422300[_0024_002411944_002422299].GetComponent<UIButtonMessage>();
							if (_0024btnMsg_002422278 != null)
							{
								_0024btnMsg_002422278.sendMessage = true;
							}
							_0024_002411944_002422299++;
						}
						goto IL_06a3;
					}
				}
				return (byte)result != 0;
			}
		}

		internal WorldQuestResultMain _0024self__002422304;

		public _0024flowOpenIcon_002422273(WorldQuestResultMain self_)
		{
			_0024self__002422304 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422304);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024flowLevelUp_002422305 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024coin_002422306;

			internal int _0024exp_002422307;

			internal long _0024raidPoint_002422308;

			internal long _0024challengPoint_002422309;

			internal int _0024restExp_002422310;

			internal int _0024nextExp_002422311;

			internal MPlayerParameters _0024lvParam_002422312;

			internal int _0024subExp_002422313;

			internal float _0024realTime_002422314;

			internal float _0024lastRealTime_002422315;

			internal float _0024resultMoveMSec_002422316;

			internal float _0024delta_002422317;

			internal int _0024tmpCoin_002422318;

			internal long _0024tmpRaidPoint_002422319;

			internal long _0024tmpChallengPoint_002422320;

			internal int _0024tmpWait_002422321;

			internal int _0024tmpExp_002422322;

			internal int _0024tmpRestExp_002422323;

			internal WorldQuestResultMain _0024self__002422324;

			public _0024(WorldQuestResultMain self_)
			{
				_0024self__002422324 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024self__002422324.resultMoveSkip = false;
						_0024coin_002422306 = _0024self__002422324.resultCoin;
						_0024exp_002422307 = _0024self__002422324.resultExp;
						_0024raidPoint_002422308 = _0024self__002422324.newRaidPoint;
						_0024challengPoint_002422309 = _0024self__002422324.newChallengPoint;
						_0024restExp_002422310 = 0;
						_0024nextExp_002422311 = 0;
						_0024lvParam_002422312 = MPlayerParameters.GetLevelParam(_0024self__002422324.oldLevel + 1);
						if (_0024lvParam_002422312 != null)
						{
							_0024nextExp_002422311 = _0024lvParam_002422312.Experience;
						}
						_0024restExp_002422310 = _0024nextExp_002422311 - _0024self__002422324.oldExp;
						_0024subExp_002422313 = 0;
						ApRpExp.CureApRp();
						_0024self__002422324.resultWindow.Coin = 0;
						_0024self__002422324.resultWindow.Exp = 0;
						_0024self__002422324.resultWindow.RaidPoint = 0L;
						_0024self__002422324.resultWindow.TotalRaidPoint = _0024self__002422324.oldTotalRaidPoint;
						_0024self__002422324.resultWindow.ChallengePoint = 0L;
						_0024self__002422324.resultWindow.TotalChallengePoint = _0024self__002422324.oldTotalChallengePoint;
						_0024self__002422324.resultWindow.NextLevelExp = _0024restExp_002422310;
						goto case 2;
					case 2:
						if (_0024self__002422324.IsChangingSituation)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024realTime_002422314 = Time.realtimeSinceStartup;
						_0024lastRealTime_002422315 = _0024realTime_002422314;
						_0024resultMoveMSec_002422316 = _0024self__002422324.initResultMoveMSec;
						goto IL_03a3;
					case 3:
						_0024realTime_002422314 = Time.realtimeSinceStartup;
						if (!(_0024lastRealTime_002422315 <= 0f))
						{
							_0024delta_002422317 = (_0024realTime_002422314 - _0024lastRealTime_002422315) * 1000f;
						}
						_0024lastRealTime_002422315 = _0024realTime_002422314;
						_0024resultMoveMSec_002422316 -= _0024delta_002422317;
						if (!(_0024resultMoveMSec_002422316 >= 0f))
						{
							_0024resultMoveMSec_002422316 = 0f;
						}
						_0024tmpCoin_002422318 = (int)((float)_0024coin_002422306 * (_0024self__002422324.initResultMoveMSec - _0024resultMoveMSec_002422316) / _0024self__002422324.initResultMoveMSec);
						if (_0024tmpCoin_002422318 > _0024coin_002422306)
						{
							_0024tmpCoin_002422318 = _0024coin_002422306;
						}
						_0024self__002422324.resultWindow.Coin = _0024tmpCoin_002422318;
						_0024tmpRaidPoint_002422319 = (long)((float)_0024raidPoint_002422308 * (_0024self__002422324.initResultMoveMSec - _0024resultMoveMSec_002422316) / _0024self__002422324.initResultMoveMSec);
						if (_0024tmpRaidPoint_002422319 > _0024raidPoint_002422308)
						{
							_0024tmpRaidPoint_002422319 = _0024raidPoint_002422308;
						}
						_0024self__002422324.resultWindow.RaidPoint = _0024tmpRaidPoint_002422319;
						_0024self__002422324.resultWindow.TotalRaidPoint = _0024self__002422324.oldTotalRaidPoint + _0024tmpRaidPoint_002422319;
						_0024tmpChallengPoint_002422320 = (long)((float)_0024challengPoint_002422309 * (_0024self__002422324.initResultMoveMSec - _0024resultMoveMSec_002422316) / _0024self__002422324.initResultMoveMSec);
						if (_0024tmpChallengPoint_002422320 > _0024challengPoint_002422309)
						{
							_0024tmpChallengPoint_002422320 = _0024challengPoint_002422309;
						}
						_0024self__002422324.resultWindow.ChallengePoint = _0024tmpChallengPoint_002422320;
						_0024self__002422324.resultWindow.TotalChallengePoint = _0024self__002422324.oldTotalChallengePoint + _0024tmpChallengPoint_002422320;
						goto IL_03a3;
					case 4:
						_0024realTime_002422314 = Time.realtimeSinceStartup;
						if (!(_0024lastRealTime_002422315 <= 0f))
						{
							_0024delta_002422317 = (_0024realTime_002422314 - _0024lastRealTime_002422315) * 1000f;
						}
						_0024lastRealTime_002422315 = _0024realTime_002422314;
						if (_0024self__002422324.levelupFlag)
						{
							_0024tmpWait_002422321 = 200;
						}
						else if (_0024tmpWait_002422321 > 0)
						{
							_0024tmpWait_002422321 = (int)((float)_0024tmpWait_002422321 - _0024delta_002422317);
						}
						else
						{
							_0024resultMoveMSec_002422316 -= _0024delta_002422317;
							if (!(_0024resultMoveMSec_002422316 >= 0f))
							{
								_0024resultMoveMSec_002422316 = 0f;
							}
							_0024tmpExp_002422322 = (int)((float)_0024exp_002422307 * (_0024self__002422324.initResultMoveMSec - _0024resultMoveMSec_002422316) / _0024self__002422324.initResultMoveMSec);
							if (_0024tmpExp_002422322 > _0024exp_002422307)
							{
								_0024tmpExp_002422322 = _0024exp_002422307;
							}
							_0024self__002422324.resultWindow.Exp = _0024tmpExp_002422322;
							_0024tmpExp_002422322 -= _0024subExp_002422313;
							_0024tmpRestExp_002422323 = _0024nextExp_002422311 - _0024self__002422324.oldExp - _0024tmpExp_002422322;
							if (_0024tmpRestExp_002422323 < 0)
							{
								_0024tmpRestExp_002422323 = 0;
							}
							_0024self__002422324.resultWindow.NextLevelExp = _0024tmpRestExp_002422323;
							if (_0024tmpRestExp_002422323 <= 0)
							{
								_0024self__002422324.PalyLevelUpEffect(_0024self__002422324.oldLevel, _0024self__002422324.oldLevel + 1);
								_0024subExp_002422313 += _0024nextExp_002422311 - _0024self__002422324.oldExp;
								_0024self__002422324.oldLevel++;
								_0024self__002422324.oldExp = 0;
								_0024lvParam_002422312 = MPlayerParameters.GetLevelParam(_0024self__002422324.oldLevel);
								if (_0024lvParam_002422312 != null)
								{
									_0024self__002422324.oldAp = _0024lvParam_002422312.Ap;
									_0024self__002422324.oldBoxCount = _0024lvParam_002422312.BoxSize;
									_0024self__002422324.oldFriendCount = _0024lvParam_002422312.FriendUpperLimit;
								}
								_0024lvParam_002422312 = MPlayerParameters.GetLevelParam(_0024self__002422324.oldLevel + 1);
								if (_0024lvParam_002422312 != null)
								{
									_0024nextExp_002422311 = _0024lvParam_002422312.Experience;
								}
								_0024restExp_002422310 = _0024nextExp_002422311;
							}
						}
						goto IL_0738;
					case 5:
						if (_0024self__002422324.levelupFlag)
						{
							result = (YieldDefault(5) ? 1 : 0);
							break;
						}
						YieldDefault(1);
						goto case 1;
					case 1:
						{
							result = 0;
							break;
						}
						IL_0738:
						if (!(_0024resultMoveMSec_002422316 <= 0f) && _0024exp_002422307 > 0 && !_0024self__002422324.resultMoveSkip)
						{
							result = (YieldDefault(4) ? 1 : 0);
							break;
						}
						_0024lvParam_002422312 = MPlayerParameters.GetLevelParam(_0024self__002422324.newLevel + 1);
						_0024self__002422324.resultWindow.Exp = _0024exp_002422307;
						if (_0024lvParam_002422312 != null)
						{
							_0024nextExp_002422311 = _0024lvParam_002422312.Experience;
						}
						_0024self__002422324.resultWindow.NextLevelExp = _0024nextExp_002422311 - _0024self__002422324.newExp;
						if (_0024self__002422324.oldLevel + 1 <= _0024self__002422324.newLevel)
						{
							_0024lvParam_002422312 = MPlayerParameters.GetLevelParam(_0024self__002422324.newLevel - 1);
							if (_0024lvParam_002422312 != null)
							{
								_0024self__002422324.oldAp = _0024lvParam_002422312.Ap;
								_0024self__002422324.oldBoxCount = _0024lvParam_002422312.BoxSize;
								_0024self__002422324.oldFriendCount = _0024lvParam_002422312.FriendUpperLimit;
							}
							_0024self__002422324.PalyLevelUpEffect(_0024self__002422324.newLevel - 1, _0024self__002422324.newLevel);
						}
						goto case 5;
						IL_03a3:
						if (!(_0024resultMoveMSec_002422316 <= 0f) && (_0024coin_002422306 > 0 || _0024raidPoint_002422308 > 0 || _0024challengPoint_002422309 > 0) && !_0024self__002422324.resultMoveSkip)
						{
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						_0024self__002422324.resultWindow.Coin = _0024coin_002422306;
						_0024self__002422324.resultWindow.RaidPoint = _0024raidPoint_002422308;
						_0024self__002422324.resultWindow.TotalRaidPoint = _0024self__002422324.oldTotalRaidPoint + _0024raidPoint_002422308;
						_0024self__002422324.resultWindow.ChallengePoint = _0024challengPoint_002422309;
						_0024self__002422324.resultWindow.TotalChallengePoint = _0024self__002422324.oldTotalChallengePoint + _0024challengPoint_002422309;
						_0024realTime_002422314 = Time.realtimeSinceStartup;
						_0024lastRealTime_002422315 = _0024realTime_002422314;
						_0024self__002422324.levelupFlag = false;
						_0024resultMoveMSec_002422316 = _0024self__002422324.initResultMoveMSec;
						_0024tmpWait_002422321 = 0;
						goto IL_0738;
					}
				}
				return (byte)result != 0;
			}
		}

		internal WorldQuestResultMain _0024self__002422325;

		public _0024flowLevelUp_002422305(WorldQuestResultMain self_)
		{
			_0024self__002422325 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002422325);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024StartMissionReward_0024closure_00244247_002422326 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_sec_0024temp_00242701_002422327;

			internal WorldQuestResultMain _0024self__002422328;

			public _0024(WorldQuestResultMain self_)
			{
				_0024self__002422328 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002422328.isEffect = true;
					goto case 2;
				case 2:
					if (_0024self__002422328.IsChangingSituation)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024_0024wait_sec_0024temp_00242701_002422327 = 1f;
					goto case 3;
				case 3:
					if (_0024_0024wait_sec_0024temp_00242701_002422327 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242701_002422327 -= Time.deltaTime;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__002422328.missionRewards = _0024self__002422328.CreateMissionRewards();
					_0024self__002422328.MissionReward(null);
					goto case 4;
				case 4:
					if (_0024self__002422328.missionRewardsCount < _0024self__002422328.missionRewards.Length)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024self__002422328.isEffect = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal WorldQuestResultMain _0024self__002422329;

		public _0024_0024StartMissionReward_0024closure_00244247_002422326(WorldQuestResultMain self_)
		{
			_0024self__002422329 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002422329);
		}
	}

	private WeaponInfo weaponDetailInfo;

	private MuppetInfo petDetailInfo;

	public QuestResultWindow resultWindow;

	public FriendInfo friendPanel;

	public FriendInfo noFriendPanel;

	public UILabelBase fpLabel;

	public UILabelBase damageLabel;

	public UILabelBase questNameLabel;

	public GameObject cleqStamp;

	public GameObject leveupWindow;

	private PlayerLevelUpInfo leveupInfo;

	private bool levelupFlag;

	private readonly string levelup_se;

	private readonly string get_item_se;

	private readonly string get_sr_item_se;

	public GameObject specialRewardWindow;

	private RewardPopupWindow specialRewardInfo;

	private int specialRewardIndex;

	private RespReward[] specialRewards;

	private RespReward[] tutoItemRewards;

	public GameObject bg3DModelPrefab;

	private bool isFriend;

	private bool doRaid;

	public GameObject treasureTabel;

	private GameObject[] treasureList;

	public GameObject screenTouch;

	public GameObject bgFilter;

	public GameObject demoAnimPrefab;

	private GameObject demoAnim;

	private WORLD_QUEST_RESULT_MODE mode;

	private WORLD_QUEST_RESULT_MODE lastMode;

	private bool isEffect;

	private DialogManager dlgMan;

	private bool isNetBusy;

	private bool isNewItemDemo;

	private int resultCoin;

	private int oldCoin;

	private int newCoin;

	private int resultExp;

	private int oldExp;

	private int newExp;

	private int oldLevel;

	private int newLevel;

	private int oldAp;

	private int newAp;

	private int offsetAp;

	private int oldBoxCount;

	private int newBoxCount;

	private int offsetBoxCount;

	private int oldFriendCount;

	private int newFriendCount;

	private int offsetFriendCount;

	private int oldFriendPoint;

	private int newFriendPoint;

	private long newRaidPoint;

	private long oldTotalRaidPoint;

	private long newChallengPoint;

	private long oldTotalChallengePoint;

	private int resultMoveMSec;

	private bool resultMoveSkip;

	public GameObject detailPoppetInfoPrefab;

	public GameObject detailWeaponInfoPrefab;

	public Transform detailInfoParent;

	private GameObject detailInfoPanel;

	private RespQuestStart lastStartResponse;

	private bool raidFlag;

	public bool raidTutorial;

	private MQuests curQuest;

	private RespFriend friend;

	private bool initFlag;

	private RespPlayerPresentBox[] oldPresents;

	private RespPlayerPresentBox[] presents;

	private Hashtable lastWeaponPicBookTable;

	private Hashtable lastPoppetPicBookTable;

	public float initResultMoveMSec;

	public int debugCoin;

	public int debugExp;

	public int debugPoint;

	public int debugLevel;

	public int debugRewardWeapon;

	public int debugRewardPoppet;

	public UIButtonMessage nextButton;

	public UIButtonMessage sellSwitchButton;

	private UIBasicUtility.ButtonSet nextButtonSet;

	private UIBasicUtility.ButtonSet sellSwitchButtonSet;

	private bool showSellSwitchButton;

	private System.Collections.Generic.List<RespReward> rewardList;

	public BoxItemList sellList;

	public MissionList missionList;

	public bool isMission;

	public UIButtonMessage missionOkButton;

	private UIBasicUtility.ButtonSet missionOkButtonSet;

	public bool enableMissionReward;

	private RespReward[] missionRewards;

	private int missionRewardsCount;

	public int debugCurrentQuest;

	public bool debug_Connection;

	private bool firstSetRewards;

	private BoxId[] soldList;

	private int prevSelectCount;

	private int specialRewardsCount;

	private int endDemoCount;

	public UIButtonMessage sellDicideButton;

	private UIBasicUtility.ButtonSet sellDicideButtonSet;

	public UILabelBase sellClearButtonLabel;

	public UISprite sellClearButtonBG;

	private int lastSelectCount;

	private bool isShowDetail;

	public BoxListItem[] selectItemDisplay;

	public UILabelBase selectCountLabel;

	public UILabelBase selectCountMaxLabel;

	public UILabelBase topSumPriceLabel;

	public UILabelBase winSumPriceLabel;

	public UILabelBase manaSumPriceLabel;

	public UILabelBase warningRareLabel;

	private ResultShortcutData resultShortcutData;

	private bool isAlradyPushRetry;

	public WorldQuestResultMain()
	{
		levelup_se = "se_system_levelup2";
		get_item_se = "se_system_new_item";
		get_sr_item_se = "se_system_new_item2";
		specialRewards = new RespReward[0];
		tutoItemRewards = new RespReward[0];
		treasureList = new GameObject[9];
		initResultMoveMSec = 1000f;
		debugCoin = 10;
		debugExp = 10;
		debugPoint = 10;
		debugRewardWeapon = -1;
		debugRewardPoppet = -1;
		missionRewards = new RespReward[0];
		firstSetRewards = true;
		soldList = new BoxId[0];
		prevSelectCount = -1;
	}

	private void SetScreenTouch(bool b)
	{
		screenTouch.SetActive(b);
	}

	public override void SceneStart()
	{
		LoadD540Patch();
		TheWorld.Init();
		ButtonBackHUD.SetActive(setActive: false);
		mode = WORLD_QUEST_RESULT_MODE.None;
		lastMode = WORLD_QUEST_RESULT_MODE.None;
		object obj = UserData.Current.userMiscInfo.weaponBookData.Flags.Clone();
		if (!(obj is Hashtable))
		{
			obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
		}
		lastWeaponPicBookTable = (Hashtable)obj;
		object obj2 = UserData.Current.userMiscInfo.poppetBookData.Flags.Clone();
		if (!(obj2 is Hashtable))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(Hashtable));
		}
		lastPoppetPicBookTable = (Hashtable)obj2;
		if (TutorialFlowControl.IsInTutorial)
		{
			IconAtlasPool.PreLoadBoxItemAtlases();
		}
		else
		{
			preLoadDropIconAtlases();
		}
		SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
		if ((bool)instance)
		{
			instance.StopBgm();
		}
		lastStartResponse = QuestSession.LastStartResponse;
		if ((bool)bg3DModelPrefab)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(bg3DModelPrefab);
			gameObject.transform.position = new Vector3(0f, -1f, 1.5f);
			gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
			gameObject.transform.localScale = new Vector3(0.08f, 0.08f, 0.08f);
		}
		GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(detailPoppetInfoPrefab);
		petDetailInfo = gameObject2.GetComponent<MuppetInfo>();
		gameObject2.transform.parent = detailInfoParent;
		gameObject2.transform.localPosition = new Vector3(0f, 0f, -200f);
		gameObject2.transform.localScale = Vector3.one;
		gameObject2.SetActive(value: false);
		GameObject gameObject3 = (GameObject)UnityEngine.Object.Instantiate(detailWeaponInfoPrefab);
		weaponDetailInfo = gameObject3.GetComponent<WeaponInfo>();
		gameObject3.transform.parent = detailInfoParent;
		gameObject3.transform.localPosition = new Vector3(0f, 0f, -200f);
		gameObject3.transform.localScale = Vector3.one;
		gameObject3.SetActive(value: false);
		if (leveupWindow != null)
		{
			leveupInfo = leveupWindow.GetComponentsInChildren<PlayerLevelUpInfo>(includeInactive: true).FirstOrDefault();
			leveupWindow.SetActive(value: false);
		}
		if (specialRewardWindow != null)
		{
			specialRewardInfo = specialRewardWindow.GetComponentsInChildren<RewardPopupWindow>(includeInactive: true).FirstOrDefault();
			specialRewardWindow.SetActive(value: false);
		}
		UserData current = UserData.Current;
		checked
		{
			if (current != null)
			{
				oldExp = current.Exp;
				oldCoin = current.Coin;
				oldLevel = current.Level;
				oldAp = current.MaxAp;
				oldBoxCount = current.BoxCapacity;
				oldFriendCount = current.FriendMax;
				MPlayerParameters levelParam = MPlayerParameters.GetLevelParam(oldLevel);
				if (levelParam != null)
				{
					offsetAp = current.MaxAp - levelParam.Ap;
					offsetBoxCount = current.BoxCapacity - levelParam.BoxSize;
					offsetFriendCount = current.FriendMax - levelParam.FriendUpperLimit;
					oldAp = levelParam.Ap;
					oldBoxCount = levelParam.BoxSize;
					oldFriendCount = levelParam.FriendUpperLimit;
				}
				oldFriendPoint = current.Fp;
			}
			UIBasicUtility.SetLabel(questNameLabel, string.Empty, show: true);
			if (cleqStamp != null)
			{
				cleqStamp.SetActive(value: false);
			}
			MerlinServer.EditorCommunicationInitialize((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				Initialize();
			});
			if (SceneChanger.CurrentScene != SceneID.Ui_WorldRaidResult)
			{
				SceneTitleHUD.UpdateTitle(MTexts.Msg("$WQR_QUEST_RESULT_TITLE"));
			}
			else
			{
				SceneTitleHUD.UpdateTitle(MTexts.Msg("$WQR_RAID_RESULT_TITLE"));
			}
			InfomationBarHUD.SetActive(a: true);
			dlgMan = DialogManager.Instance;
			ShowBackButton(show: false);
			SetScreenTouch(b: false);
			UIBasicUtility.SetLabel(damageLabel, "0", show: true);
			if (TutorialFlowControl.IsInTutorial)
			{
				sellSwitchButton.gameObject.SetActive(value: false);
				showSellSwitchButton = false;
				return;
			}
			sellSwitchButtonSet = UIBasicUtility.CreateButtonSet(sellSwitchButton);
			nextButtonSet = UIBasicUtility.CreateButtonSet(nextButton);
			if (null != missionOkButton)
			{
				missionOkButtonSet = UIBasicUtility.CreateButtonSet(missionOkButton);
			}
			UIBasicUtility.SetButtonValid(sellSwitchButtonSet, e: false);
			UIBasicUtility.SetButtonValid(nextButtonSet, e: false);
			if (missionOkButtonSet != null)
			{
				UIBasicUtility.SetButtonValid(missionOkButtonSet, e: false);
			}
		}
	}

	private void Initialize()
	{
		initFlag = true;
		StorageHUD.DoUpdateNow();
	}

	private void LoadD540Patch()
	{
		RuntimeAssetBundleDB.Instance.instantiatePrefab("ZPatch001QuestResultMain");
	}

	private void preLoadDropIconAtlases()
	{
		HashSet<string> hashSet = new HashSet<string>();
		int i = 0;
		RespSimpleReward[] array = QuestSession.AllCollectedDrops();
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			MWeapons weaponMaster = array[i].WeaponMaster;
			if (weaponMaster != null)
			{
				hashSet.Add(weaponMaster.Icon);
			}
			MPoppets poppetMaster = array[i].PoppetMaster;
			if (poppetMaster != null)
			{
				hashSet.Add(poppetMaster.Icon);
			}
		}
		IconAtlasPool.PreLoadAtlasesOfSprites((string[])Builtins.array(typeof(string), hashSet));
	}

	private void Setup()
	{
		initFlag = false;
		IEnumerator enumerator = main();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator main()
	{
		return new _0024main_002422224(this).GetEnumerator();
	}

	private void flowInit(ref TempMainData td)
	{
		isNetBusy = true;
		debug_Connection = false;
		debugCurrentQuest = 0;
		MerlinServer.Busy = true;
		raidFlag = SceneChanger.CurrentScene == SceneID.Ui_WorldRaidResult;
		curQuest = QuestSession.Quest;
		if (debug_Connection && debugCurrentQuest != 0)
		{
			curQuest = MQuests.Get(debugCurrentQuest);
		}
		friend = null;
		td.clearFlag = false;
		td.alreadyClearFlag = false;
		td.mstory = null;
		td.qresult = null;
		td.failed = false;
		if (curQuest != null && curQuest.QuestType == EnumQuestTypes.RaidTutorial)
		{
			raidTutorial = true;
			raidFlag = false;
			td.alreadyClearFlag = UserData.Current.userMiscInfo.questData.isClear(curQuest.Id);
			td.mstory = QuestSession.Story;
		}
		ResultShortcut.Activate(activate: false);
	}

	private IEnumerator flowFinish()
	{
		return new _0024flowFinish_002422233(this).GetEnumerator();
	}

	private IEnumerator flowQuestResult(ref TempMainData tempData)
	{
		return new _0024flowQuestResult_002422236(tempData, this).GetEnumerator();
	}

	private void flowTutorial(ref TempMainData td)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud != null");
		}
		td.mstory = TutorialFlowControl.GetTutorialQuestStory();
		MQuests mQuests = QuestSession.Quest;
		if (mQuests == null && td.mstory != null)
		{
			mQuests = td.mstory.MQuestId;
		}
		string empty = string.Empty;
		if (mQuests != null)
		{
			empty = mQuests.GetName();
		}
		UIBasicUtility.SetLabel(questNameLabel, empty, show: true);
		isFriend = false;
		oldCoin = 0;
		resultCoin = current.Coin;
		td.clearFlag = true;
	}

	private IEnumerator flowQuestResultRequest(ref TempMainData td)
	{
		return new _0024flowQuestResultRequest_002422242(td, this).GetEnumerator();
	}

	private void flowDebugConnection(ref TempMainData tempData)
	{
		isFriend = UnityEngine.Random.Range(0, 1) == 0;
		RespFriend respFriend = new RespFriend();
		respFriend.ItemId = 1;
		respFriend.SkillLevel_1 = 1;
		respFriend.SkillLevel_2 = 1;
		respFriend.SkillLevel_3 = 1;
		respFriend.AttackBonus = 1;
		respFriend.AttackPlusBonus = 1;
		respFriend.HpBonus = 1;
		respFriend.HpPlusBonus = 1;
		respFriend.PoppetLevel = 1;
		friend = respFriend;
	}

	private IEnumerator flowRaidResult(ref TempMainData td)
	{
		return new _0024flowRaidResult_002422253(td, this).GetEnumerator();
	}

	private void flowFriend()
	{
		UserData current = UserData.Current;
		if (friend != null || QuestSession.WithServer)
		{
		}
		if (friend != null)
		{
			if (friend.GetFriendPet() != null)
			{
				friendPanel.SetFriend(friend);
				friendPanel.SetFriendPoint(oldFriendPoint, newFriendPoint);
				noFriendPanel.SetFriend(friend);
				noFriendPanel.SetFriendPoint(oldFriendPoint, newFriendPoint);
			}
			isFriend = current.userFriendListData.find(friend.TSocialPlayerId) != null;
		}
		if (isFriend)
		{
			friendPanel.gameObject.SetActive(value: true);
			noFriendPanel.gameObject.SetActive(value: false);
		}
		else
		{
			friendPanel.gameObject.SetActive(value: false);
			noFriendPanel.gameObject.SetActive(value: true);
		}
	}

	private IEnumerator flowTutoRaid(ref TempMainData td)
	{
		return new _0024flowTutoRaid_002422265(td, this).GetEnumerator();
	}

	private void flowSpecialReward(ref TempMainData td)
	{
		specialRewards = new RespReward[0];
		RespReward[] array = new RespReward[0];
		checked
		{
			if (raidTutorial)
			{
				specialRewards = (RespReward[])RuntimeServices.AddArrays(typeof(RespReward), specialRewards, CreateRaidTutorialRewards());
			}
			else if (debug_Connection)
			{
				specialRewards = (RespReward[])RuntimeServices.AddArrays(typeof(RespReward), specialRewards, CreateRaidTutorialRewards());
				array = (RespReward[])RuntimeServices.AddArrays(typeof(RespReward), array, CreateDummyRewards(10, 0));
			}
			else if (presents != null)
			{
				RespReward[] array2 = new RespReward[0];
				if (oldPresents != null)
				{
					int i = 0;
					RespPlayerPresentBox[] array3 = presents;
					for (int length = array3.Length; i < length; i++)
					{
						if (array3[i].IsReceive)
						{
							continue;
						}
						bool flag = false;
						int j = 0;
						RespPlayerPresentBox[] array4 = oldPresents;
						for (int length2 = array4.Length; j < length2; j++)
						{
							if (array4[j].Id == array3[i].Id)
							{
								flag = true;
								break;
							}
						}
						if (flag)
						{
							continue;
						}
						RespReward respReward = GetSpecialReward(array3[i]);
						if (respReward == null)
						{
							continue;
						}
						int k = 0;
						RespReward[] array5 = array2;
						for (int length3 = array5.Length; k < length3; k++)
						{
							if (RespReward.Equals(respReward, array5[k]))
							{
								array5[k].Quantity = array5[k].Quantity + respReward.Quantity;
								respReward = null;
								break;
							}
						}
						if (respReward != null)
						{
							array2 = (RespReward[])RuntimeServices.AddArrays(typeof(RespReward), array2, new RespReward[1] { respReward });
						}
					}
				}
				specialRewards = (RespReward[])RuntimeServices.AddArrays(typeof(RespReward), specialRewards, array2);
			}
			if (td.qresult != null && oldPresents == null)
			{
				array = (RespReward[])RuntimeServices.AddArrays(typeof(RespReward), array, CreateFirstClearRewards(td.qresult));
			}
			specialRewards = (RespReward[])RuntimeServices.AddArrays(typeof(RespReward), specialRewards, array);
		}
	}

	private void SetRewards(RespReward[] rewards)
	{
		SetRewards(rewards, null);
	}

	private void SetRewards(RespReward[] rewards, BoxId[] solds)
	{
		if (treasureList.Length <= 0)
		{
			return;
		}
		IEnumerator<int> enumerator = Enumerable.Range(0, treasureList.Length).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				int current = enumerator.Current;
				GameObject[] array = treasureList;
				array[RuntimeServices.NormalizeArrayIndex(array, current)].SetActive(value: false);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		if (!firstSetRewards)
		{
			soldList = (BoxId[])RuntimeServices.AddArrays(typeof(BoxId), soldList, solds);
		}
		RespPlayerBox[] dropFromBox = GetDropFromBox(ref rewards, soldList);
		if (dropFromBox.Length <= 0)
		{
			showSellSwitchButton = false;
			if (sellSwitchButton != null)
			{
				UIBasicUtility.SetButtonValid(sellSwitchButtonSet, e: false);
			}
		}
		else
		{
			showSellSwitchButton = true;
		}
		if (rewards == null || rewards.Length <= 0)
		{
			return;
		}
		checked
		{
			if (rewardList == null)
			{
				rewardList = new System.Collections.Generic.List<RespReward>();
				int i = 0;
				RespReward[] array2 = rewards;
				for (int length = array2.Length; i < length && array2[i] != null; i++)
				{
					rewardList.Add(array2[i]);
				}
			}
			Hashtable hashtable = new Hashtable();
			int num = 0;
			int j = 0;
			RespReward[] array3 = rewards;
			for (int length2 = array3.Length; j < length2; j++)
			{
				if (array3[j] == null || (!array3[j].IsWeapon && !array3[j].IsPoppet) || IsSoldId(array3[j].BoxId, soldList))
				{
					continue;
				}
				if (num < treasureList.Length)
				{
					GameObject[] array4 = treasureList;
					RewardIconInfo component = array4[RuntimeServices.NormalizeArrayIndex(array4, num)].GetComponent<RewardIconInfo>();
					component.SetRespReward(array3[j]);
					GameObject[] array5 = treasureList;
					array5[RuntimeServices.NormalizeArrayIndex(array5, num)].SetActive(value: true);
					if (!firstSetRewards)
					{
						component.DirectOpenIcon();
					}
				}
				num++;
				if (firstSetRewards)
				{
					string text = null;
					if (array3[j].IsWeapon)
					{
						text = "w" + array3[j].ItemId;
					}
					else if (array3[j].IsPoppet)
					{
						text = "p" + array3[j].ItemId;
					}
					if (!string.IsNullOrEmpty(text))
					{
						int num2 = 0;
						num2 = ((!hashtable.ContainsKey(text)) ? 1 : (RuntimeServices.UnboxInt32(hashtable[text]) + 1));
						hashtable[text] = num2;
					}
				}
			}
			if (QuestSession.Quest != null && 0 < ((ICollection)hashtable).Count)
			{
				UserData.Current.userMiscInfo.treasureData.set(QuestSession.Quest.Id.ToString(), hashtable);
			}
			if (sellList != null)
			{
				sellList.ClearSelectItems();
				sellList.SetInputBoxList(dropFromBox.ToArray());
			}
			firstSetRewards = false;
		}
	}

	private RespPlayerBox[] GetDropFromBox(ref RespReward[] rewards, BoxId[] solds)
	{
		System.Collections.Generic.List<RespPlayerBox> list = new System.Collections.Generic.List<RespPlayerBox>();
		checked
		{
			if (rewards != null && 0 < rewards.Length)
			{
				if (debug_Connection)
				{
					int i = 0;
					RespReward[] array = rewards;
					for (int length = array.Length; i < length; i++)
					{
						RespPlayerBox respPlayerBox = ConvertRewardToBox(array[i]);
						if (respPlayerBox != null)
						{
							if (!respPlayerBox.Id.IsValid)
							{
								respPlayerBox.Id = new BoxId(array[i].ItemId + UnityEngine.Random.Range(0, 1000000));
							}
							if (!IsSoldId(respPlayerBox.Id, solds))
							{
								list.Add(respPlayerBox);
							}
						}
					}
				}
				else
				{
					RespQuestResult lastResult = QuestSession.GetLastResult();
					if (lastResult != null && !string.IsNullOrEmpty(lastResult.BoxId))
					{
						RespPlayerBox[] box = lastResult.Box;
						string[] array2 = lastResult.BoxId.Split(',');
						if (array2 != null && 0 < array2.Length)
						{
							int j = 0;
							string[] array3 = array2;
							for (int length2 = array3.Length; j < length2; j++)
							{
								if (string.IsNullOrEmpty(array3[j]))
								{
									continue;
								}
								BoxId boxId = new BoxId(long.Parse(array3[j]));
								if (IsSoldId(boxId, solds))
								{
									continue;
								}
								int k = 0;
								RespPlayerBox[] array4 = box;
								for (int length3 = array4.Length; k < length3; k++)
								{
									if (RuntimeServices.EqualityOperator(array4[k].Id, boxId))
									{
										list.Add(array4[k]);
										break;
									}
								}
							}
						}
					}
				}
			}
			if (rewards != null)
			{
				foreach (RespPlayerBox item in list)
				{
					int l = 0;
					RespReward[] array5 = rewards;
					for (int length4 = array5.Length; l < length4; l++)
					{
						if ((array5[l].IsWeapon || array5[l].IsPoppet) && !array5[l].BoxId.IsValid)
						{
							RespPlayerBox respPlayerBox = ConvertRewardToBox(array5[l]);
							if (IsSameItem(respPlayerBox, item) && !RuntimeServices.EqualityOperator(array5[l].BoxId, item.Id))
							{
								array5[l].BoxId = item.Id;
								break;
							}
						}
					}
				}
			}
			return list.ToArray();
		}
	}

	private bool IsSameItem(RespPlayerBox reward, RespPlayerBox drop)
	{
		int num;
		if (reward == null || drop == null)
		{
			num = 0;
		}
		else
		{
			bool flag = reward.ItemType == drop.ItemType;
			bool flag2 = reward.IsWeapon == drop.IsWeapon;
			bool flag3 = reward.IsPoppet == drop.IsPoppet;
			bool flag4 = reward.ItemId == drop.ItemId;
			bool flag5 = reward.Level == drop.Level;
			bool flag6 = reward.TraitId == drop.TraitId;
			num = (flag ? 1 : 0);
			if (num != 0)
			{
				num = (flag2 ? 1 : 0);
			}
			if (num != 0)
			{
				num = (flag3 ? 1 : 0);
			}
			if (num != 0)
			{
				num = (flag4 ? 1 : 0);
			}
			if (num != 0)
			{
				num = (flag5 ? 1 : 0);
			}
			if (num != 0)
			{
				num = (flag6 ? 1 : 0);
			}
		}
		return (byte)num != 0;
	}

	private bool IsSoldId(BoxId id, BoxId[] solds)
	{
		bool result = false;
		if (solds != null && 0 < solds.Length)
		{
			int i = 0;
			for (int length = solds.Length; i < length; i = checked(i + 1))
			{
				if (RuntimeServices.EqualityOperator(solds[i], id))
				{
					result = true;
					break;
				}
			}
		}
		return result;
	}

	private RespReward[] _genRewardsTrait(ref RespReward[] rewards)
	{
		RespPlayerBox[] dropFromBox = GetDropFromBox(ref rewards, soldList);
		checked
		{
			__RespWeapon_CalcAddPlusBonusCost_0024callable180_0024358_13__ _RespWeapon_CalcAddPlusBonusCost_0024callable180_0024358_13__ = (int itemid) => itemid + 2;
			System.Collections.Generic.List<Hashtable> list = new System.Collections.Generic.List<Hashtable>();
			int i = 0;
			RespPlayerBox[] array = dropFromBox;
			for (int length = array.Length; i < length; i++)
			{
				list.Add(new Hash
				{
					{
						"ItemId",
						array[i].ItemId
					},
					{
						"Level",
						array[i].Level
					},
					{
						"TypeValue",
						_RespWeapon_CalcAddPlusBonusCost_0024callable180_0024358_13__(array[i].ItemType)
					},
					{
						"TraitId",
						array[i].TraitId
					},
					{ "USED", false }
				});
			}
			int j = 0;
			RespReward[] array2 = rewards;
			for (int length2 = array2.Length; j < length2; j++)
			{
				if (array2[j] == null || (!array2[j].IsWeapon && !array2[j].IsPoppet))
				{
					continue;
				}
				foreach (Hashtable item in list)
				{
					if (RuntimeServices.EqualityOperator(item["USED"], false) && RuntimeServices.EqualityOperator(item["ItemId"], array2[j].ItemId) && RuntimeServices.EqualityOperator(item["TypeValue"], array2[j].MasterTypeValue) && RuntimeServices.EqualityOperator(item["Level"], array2[j].Level))
					{
						item["USED"] = true;
						array2[j].TraitId = RuntimeServices.UnboxInt32(item["TraitId"]);
						break;
					}
				}
			}
			return null;
		}
	}

	public RespPlayerBox ConvertRewardToBox(RespReward reward)
	{
		RespPlayerBox result = null;
		if (reward.TypeValue == 3)
		{
			RespWeapon respWeapon = reward.toRespWeapon();
			if (debug_Connection && respWeapon != null)
			{
				UserData.Current.userMiscInfo.weaponBookData.look(respWeapon.Master);
			}
			result = respWeapon.RefPlayerBox;
		}
		if (reward.TypeValue == 4)
		{
			RespPoppet respPoppet = reward.toRespPoppet();
			if (debug_Connection && respPoppet != null)
			{
				UserData.Current.userMiscInfo.poppetBookData.look(respPoppet.Master);
			}
			result = respPoppet.RefPlayerBox;
		}
		return result;
	}

	private RespReward[] CreateDummyRewards(int num, int rewardType)
	{
		RespReward[] array = new RespReward[num];
		int num2 = 0;
		int length = array.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < length)
		{
			int index = num2;
			num2++;
			RespReward respReward = new RespReward();
			respReward.Id = 10;
			int num3 = 0;
			int num4 = 1;
			int itemId = 1;
			if (rewardType < 0)
			{
				num3 = ((UnityEngine.Random.Range(0, 10) >= 5) ? 4 : 3);
			}
			if (rewardType == 0)
			{
				num3 = UnityEngine.Random.Range(1, 9 + 1);
			}
			switch (num3)
			{
			case 3:
				num4 = 259;
				itemId = UnityEngine.Random.Range(0, num4);
				if (0 < debugRewardWeapon)
				{
					itemId = debugRewardWeapon;
				}
				break;
			case 4:
				num4 = 312;
				itemId = UnityEngine.Random.Range(0, num4);
				if (0 < debugRewardPoppet)
				{
					itemId = debugRewardPoppet;
				}
				break;
			}
			respReward.IsGet = true;
			respReward.ItemId = itemId;
			respReward.Level = 1;
			respReward.Quantity = 1;
			respReward.Title = "ダミー報酬";
			respReward.Explain = new StringBuilder("ダミー報酬です(").Append((object)num3).Append(")").ToString();
			if (rewardType < 0)
			{
				respReward.MasterTypeValue = num3;
			}
			else
			{
				respReward.RewardType = (RespReward.Type)UnityEngine.Random.Range(0, 3);
			}
			array[RuntimeServices.NormalizeArrayIndex(array, index)] = respReward;
		}
		return array;
	}

	private RespReward[] CreateTutorialItemRewards(RespPlayerBox[] oldBox, RespPlayerBox[] newBox)
	{
		checked
		{
			RespReward[] result;
			if (!debug_Connection && curQuest == null)
			{
				result = new RespReward[0];
			}
			else
			{
				System.Collections.Generic.List<RespReward> list = new System.Collections.Generic.List<RespReward>();
				if (oldBox != null && newBox != null)
				{
					string text = MTexts.Msg("$WQR_RAID_REWARD_TITLE");
					string message = MTexts.Msg("$WQR_RAID_REWARD");
					RespReward.Type rtype = RespReward.Type.Raid;
					int i = 0;
					for (int length = newBox.Length; i < length; i++)
					{
						int j = 0;
						for (int length2 = oldBox.Length; j < length2; j++)
						{
							if (RuntimeServices.EqualityOperator(newBox[i].Id, oldBox[j].Id))
							{
								newBox[i] = null;
								break;
							}
						}
						if (newBox[i] != null)
						{
							if (newBox[i].ItemType == 1)
							{
								list.Add(RespReward.Weapon(newBox[i].ItemId, newBox[i].Level, text, message, rtype));
							}
							else if (newBox[i].ItemType == 2)
							{
								list.Add(RespReward.Poppet(newBox[i].ItemId, newBox[i].Level, text, message, rtype));
							}
						}
					}
				}
				result = list.ToArray();
			}
			return result;
		}
	}

	private RespReward[] CreateRaidTutorialRewards()
	{
		checked
		{
			RespReward[] result;
			if (!debug_Connection && curQuest != null)
			{
				result = new RespReward[0];
			}
			else
			{
				string text = MTexts.Msg("$WQR_RAID_REWARD_TITLE");
				string message = MTexts.Msg("$WQR_RAID_REWARD");
				RespReward.Type rtype = RespReward.Type.Raid;
				System.Collections.Generic.List<RespReward> list = new System.Collections.Generic.List<RespReward>();
				int i = 0;
				MRaidTutorialRewards[] all = MRaidTutorialRewards.All;
				for (int length = all.Length; i < length; i++)
				{
					if (debug_Connection || RuntimeServices.EqualityOperator(all[i].MQuestId, curQuest))
					{
						int j = 0;
						MWeapons[] weapons = all[i].Weapons;
						for (int length2 = weapons.Length; j < length2; j++)
						{
							list.Add(RespReward.Weapon(weapons[j].Id, 1, text, message, rtype));
						}
						int k = 0;
						MPoppets[] poppets = all[i].Poppets;
						for (int length3 = poppets.Length; k < length3; k++)
						{
							list.Add(RespReward.Poppet(poppets[k].Id, 1, text, message, rtype));
						}
					}
				}
				result = list.ToArray();
			}
			return result;
		}
	}

	private RespReward[] CreateFirstClearRewards(RespQuestResult respQuestRes)
	{
		RespReward[] result;
		if (!debug_Connection && respQuestRes == null)
		{
			result = new RespReward[0];
		}
		else
		{
			RespReward[] array = respQuestRes.createFirstClearRewards();
			string text = MTexts.Msg("$WQR_QUEST_FIRST_REWARD_TITLE");
			string message = MTexts.Msg("$WQR_QUEST_FIRST_REWARD");
			RespReward.SetFields(array, text, message, RespReward.Type.FirstClear);
			result = array;
		}
		return result;
	}

	private void ShowBackButton(bool show)
	{
		if (ButtonBackHUD.IsActive != show)
		{
			ButtonBackHUD.SetActive(show);
		}
	}

	public override void SceneUpdate()
	{
		if (!FaderCore.Instance.isCompleted || !SceneChanger.isCompletelyReady || isNetBusy || MerlinServer.Instance.IsBusy)
		{
			return;
		}
		if (initFlag)
		{
			Setup();
		}
		if (IsChangingSituation)
		{
			return;
		}
		if (mode != lastMode)
		{
			if (mode != WORLD_QUEST_RESULT_MODE.WeaponDetail && mode != WORLD_QUEST_RESULT_MODE.PetDetail)
			{
				ChangeSituation(GetSituation((int)mode));
			}
			if (mode == WORLD_QUEST_RESULT_MODE.Friend)
			{
				if (weaponDetailInfo.gameObject.active)
				{
					UIAutoTweenerStandAloneEx.Out(weaponDetailInfo.gameObject);
				}
				if (petDetailInfo.gameObject.active)
				{
					UIAutoTweenerStandAloneEx.Out(petDetailInfo.gameObject);
				}
				SetScreenTouch(b: false);
				if (isFriend)
				{
					string help = GetSituation(0).help;
					InfomationBarHUD.UpdateText(help);
					InfomationBarHUD.SetActive(a: true);
				}
			}
			else if (mode == WORLD_QUEST_RESULT_MODE.Result)
			{
				ShowBackButton(show: false);
			}
			else if (mode == WORLD_QUEST_RESULT_MODE.ResultFinish)
			{
				StorageHUD.DoUpdateNow();
				ShowBackButton(show: false);
			}
			else if (mode == WORLD_QUEST_RESULT_MODE.WeaponDetail)
			{
				ShowBackButton(show: true);
			}
			else if (mode == WORLD_QUEST_RESULT_MODE.PetDetail)
			{
				ShowBackButton(show: true);
			}
			else if (mode == WORLD_QUEST_RESULT_MODE.FriendDetail)
			{
				ShowBackButton(show: true);
			}
			else if (mode == WORLD_QUEST_RESULT_MODE.Sell)
			{
				lastSelectCount = -1;
				StorageHUD.DoUpdateNow();
				ShowBackButton(show: true);
			}
			else if (mode == WORLD_QUEST_RESULT_MODE.SellConf)
			{
				ShowBackButton(show: false);
			}
			else if (mode == WORLD_QUEST_RESULT_MODE.ResultShortcut)
			{
				ShowBackButton(show: false);
				ResultShortcut.Activate(activate: true);
			}
			else if (mode == WORLD_QUEST_RESULT_MODE.Mission)
			{
				ShowBackButton(show: false);
				if (weaponDetailInfo.gameObject.active)
				{
					UIAutoTweenerStandAloneEx.Out(weaponDetailInfo.gameObject);
				}
				if (petDetailInfo.gameObject.active)
				{
					UIAutoTweenerStandAloneEx.Out(petDetailInfo.gameObject);
				}
				SetScreenTouch(b: false);
				if (lastMode != WORLD_QUEST_RESULT_MODE.MissionDetail)
				{
					StartMissionReward();
				}
			}
			else if (mode == WORLD_QUEST_RESULT_MODE.MissionDetail)
			{
				ShowBackButton(show: true);
			}
			lastMode = mode;
		}
		if (mode == WORLD_QUEST_RESULT_MODE.Sell)
		{
			UpdateClearButtonText();
			UpdatePriceText();
		}
	}

	private void UpdateClearButtonText()
	{
		if (!(sellList == null) && lastSelectCount != sellList.selectCount)
		{
			if (0 < sellList.selectCount)
			{
				UIBasicUtility.SetLabel(sellClearButtonLabel, "選択解除", show: true);
				UIBasicUtility.SetSprite(sellClearButtonBG, "button04", null, show: true);
			}
			else
			{
				UIBasicUtility.SetLabel(sellClearButtonLabel, "一括選択", show: true);
				UIBasicUtility.SetSprite(sellClearButtonBG, "button07", null, show: true);
			}
			lastSelectCount = sellList.selectCount;
		}
	}

	private void SetSumPrice(int sum, int manaSum)
	{
		UIBasicUtility.SetLabel(topSumPriceLabel, sum.ToString("#,0"), show: true);
		UIBasicUtility.SetLabel(winSumPriceLabel, MTexts.Format("exp_ruku", sum.ToString("#,0")), show: true);
		UIBasicUtility.SetLabel(manaSumPriceLabel, manaSum.ToString("#,0"), show: true);
	}

	private void SetDicedeButtonValid(bool valid)
	{
		if (sellDicideButtonSet == null)
		{
			sellDicideButtonSet = UIBasicUtility.CreateButtonSet(sellDicideButton);
		}
		UIBasicUtility.SetButtonValid(sellDicideButtonSet, valid);
	}

	private void UpdatePriceText()
	{
		if (prevSelectCount != sellList.SelectItems.Count())
		{
			prevSelectCount = sellList.SelectItems.Count();
			SetSumPrice(BlacksmithSellMain.GetSumPrice(sellList, isMana: false), BlacksmithSellMain.GetSumPrice(sellList, isMana: true));
			UIBasicUtility.SetLabel(selectCountLabel, prevSelectCount.ToString(), show: true);
			UIBasicUtility.SetLabel(selectCountMaxLabel, "/" + sellList.Count().ToString(" 0"), show: true);
			SetDicedeButtonValid(0 < prevSelectCount);
		}
	}

	private IEnumerator flowOpenIcon()
	{
		return new _0024flowOpenIcon_002422273(this).GetEnumerator();
	}

	private IEnumerator flowLevelUp()
	{
		return new _0024flowLevelUp_002422305(this).GetEnumerator();
	}

	private void PushQuestResultWindow(GameObject obj)
	{
		if (IsChangingSituation || mode == WORLD_QUEST_RESULT_MODE.Sell || mode == WORLD_QUEST_RESULT_MODE.SellConf || mode == WORLD_QUEST_RESULT_MODE.ResultFinish)
		{
			return;
		}
		if (mode == WORLD_QUEST_RESULT_MODE.Result)
		{
			if ((!leveupWindow || !leveupWindow.active) && !resultMoveSkip)
			{
				resultMoveSkip = true;
				PushLevelUpOk(null);
			}
		}
		else if (mode == WORLD_QUEST_RESULT_MODE.ResultFinish)
		{
			EndTreasureEffect(obj);
		}
	}

	private void PushNext(GameObject obj)
	{
		if (IsChangingSituation || mode == WORLD_QUEST_RESULT_MODE.Sell || mode == WORLD_QUEST_RESULT_MODE.SellConf)
		{
			return;
		}
		if (mode == WORLD_QUEST_RESULT_MODE.Result)
		{
			if (isNewItemDemo)
			{
				PushSkipDemo(null);
			}
			else if (levelupFlag)
			{
				levelupFlag = false;
			}
			else if (!resultMoveSkip)
			{
				resultMoveSkip = true;
				PushLevelUpOk(null);
			}
		}
		else if (mode == WORLD_QUEST_RESULT_MODE.ResultFinish)
		{
			if (!raidFlag && !raidTutorial && (obj.transform.parent == null || obj.transform.parent.name != "NextButton"))
			{
				return;
			}
			SetScreenTouch(b: true);
			if (nextButton != null)
			{
				nextButton.cantTouchHandler = delegate
				{
					nextButton.collider.enabled = false;
					nextButton.cantTouchHandler = null;
				};
			}
			EndTreasureEffect(null);
		}
		else
		{
			PushBack(null);
		}
	}

	private void PushLevelUpOk(GameObject obj)
	{
		if (IsChangingSituation)
		{
			return;
		}
		if (leveupWindow != null && leveupWindow.active)
		{
			UIAutoTweenerStandAloneEx.Out(leveupWindow, delegate
			{
				levelupFlag = false;
				if (leveupWindow != null)
				{
					leveupWindow.SetActive(value: false);
				}
				ApRpExp.CureApRp();
			});
		}
		else if (mode == WORLD_QUEST_RESULT_MODE.ResultFinish)
		{
			EndTreasureEffect(obj);
		}
	}

	private void PushRewardOk(GameObject obj)
	{
		if (IsChangingSituation || specialRewardWindow == null || !specialRewardWindow.active)
		{
			return;
		}
		UIAutoTweenerStandAloneEx.Out(specialRewardWindow, delegate(GameObject obj)
		{
			if (specialRewardWindow != null)
			{
				specialRewardWindow.SetActive(value: false);
			}
			if (mode == WORLD_QUEST_RESULT_MODE.ResultFinish)
			{
				EndTreasureEffect(obj);
			}
			else if (mode == WORLD_QUEST_RESULT_MODE.Mission)
			{
				MissionReward(obj);
			}
		});
	}

	private void SetupLevelupInfo(int oldLv, int newLv)
	{
		GameSoundManager.PlaySe(levelup_se, 0);
		SetScreenTouch(b: false);
		if (leveupWindow != null)
		{
			UIAutoTweenerStandAloneEx.In(leveupWindow);
		}
		checked
		{
			if (leveupInfo != null)
			{
				leveupInfo.Init();
				leveupInfo.oldLevel = oldLv;
				leveupInfo.newLevel = newLv;
				MPlayerParameters levelParam = MPlayerParameters.GetLevelParam(oldLv);
				MPlayerParameters levelParam2 = MPlayerParameters.GetLevelParam(newLv);
				if (levelParam2.Ap > levelParam.Ap)
				{
					leveupInfo.oldStatus = oldAp + offsetAp;
					leveupInfo.newStatus = oldAp + offsetAp + (levelParam2.Ap - levelParam.Ap);
					leveupInfo.newStatusMessage = MTexts.Msg("$WQR_AP_UP");
				}
				else if (levelParam2.BoxSize > levelParam.BoxSize)
				{
					leveupInfo.oldStatus = oldBoxCount + offsetBoxCount;
					leveupInfo.newStatus = oldBoxCount + offsetBoxCount + offsetAp + (levelParam2.BoxSize - levelParam.BoxSize);
					leveupInfo.newStatusMessage = MTexts.Msg("$WQR_BOX_UP");
				}
				else if (levelParam2.FriendUpperLimit > levelParam.FriendUpperLimit)
				{
					leveupInfo.oldStatus = oldFriendCount + offsetFriendCount;
					leveupInfo.newStatus = oldFriendCount + offsetFriendCount + (levelParam2.FriendUpperLimit - levelParam.FriendUpperLimit);
					leveupInfo.newStatusMessage = MTexts.Msg("$WQR_FRIEND_UP");
				}
			}
		}
	}

	private RespReward GetSpecialReward(RespPlayerPresentBox respPresent)
	{
		object result;
		if (respPresent == null)
		{
			result = null;
		}
		else if (raidFlag && respPresent.PresentType != 1)
		{
			result = null;
		}
		else if (respPresent.PresentType == 12)
		{
			result = null;
		}
		else
		{
			RespReward respReward = RespReward.FromPresent(respPresent);
			respReward.RewardType = RespReward.Type.Raid;
			EnumPresentTypes presentType = (EnumPresentTypes)respPresent.PresentType;
			if (string.IsNullOrEmpty(respReward.Title) && string.IsNullOrEmpty(respReward.Message))
			{
				switch (presentType)
				{
				case EnumPresentTypes.Raid:
					respReward.Title = MTexts.Msg("$WQR_UNION_REWARD_TITLE");
					respReward.Explain = MTexts.Msg("$WQR_UNION_REWARD");
					respReward.RewardType = RespReward.Type.Raid;
					break;
				case EnumPresentTypes.RaidPlayerRanking:
					respReward.Title = MTexts.Msg("$WQR_UNION_REWARD_TITLE");
					respReward.Explain = MTexts.Msg("$WQR_UNION_REWARD");
					respReward.RewardType = RespReward.Type.Raid;
					break;
				case EnumPresentTypes.RaidGuildRanking:
					respReward.Title = MTexts.Msg("$WQR_UNION_REWARD_TITLE");
					respReward.Explain = MTexts.Msg("$WQR_UNION_REWARD");
					respReward.RewardType = RespReward.Type.Raid;
					break;
				case EnumPresentTypes.EventQuestRanking:
					respReward.Title = MTexts.Msg("$WQR_CHALLENGE_REWARD_TITLE");
					respReward.Explain = MTexts.Msg("$WQR_CHALLENGE_REWARD");
					respReward.RewardType = RespReward.Type.Challenge;
					break;
				}
			}
			result = respReward;
		}
		return (RespReward)result;
	}

	private void EmitSpecialReward(RespReward spReward)
	{
		if (specialRewardWindow == null)
		{
			return;
		}
		SetScreenTouch(b: false);
		UIBasicUtility.SetButtonValid(sellSwitchButtonSet, e: false);
		UIBasicUtility.SetButtonValid(nextButtonSet, e: false);
		UIAutoTweenerStandAloneEx.In(specialRewardWindow);
		bool flag = false;
		switch (spReward.TypeValue)
		{
		case 3:
		{
			RespWeapon respWeapon = spReward.toRespWeapon();
			if (respWeapon != null && respWeapon.Master.Rare.Id >= 5)
			{
				flag = true;
			}
			break;
		}
		case 4:
		{
			RespPoppet respPoppet = spReward.toRespPoppet();
			if (respPoppet != null && respPoppet.Master.Rare.Id >= 5)
			{
				flag = true;
			}
			break;
		}
		}
		if (flag)
		{
			GameSoundManager.PlaySe(get_sr_item_se, 0);
		}
		else
		{
			GameSoundManager.PlaySe(get_item_se, 0);
		}
		RewardPopupWindow.Type type = RewardPopupWindow.Type.rewardTypeNormal;
		if ((spReward.RewardType == RespReward.Type.Challenge || spReward.RewardType == RespReward.Type.Raid) && !string.IsNullOrEmpty(spReward.Title))
		{
			type = RewardPopupWindow.Type.rewardTypeRaid;
		}
		specialRewardInfo.SetRespRewards(type, new RespReward[1] { spReward }, spReward.Title, spReward.Message, PushSpecialDetail);
	}

	private void PushSpecialDetail(RespReward reward)
	{
		if (reward == null)
		{
			return;
		}
		switch (reward.TypeValue)
		{
		case 3:
			if (!weaponDetailInfo.active)
			{
				if (mode != WORLD_QUEST_RESULT_MODE.Mission)
				{
					mode = WORLD_QUEST_RESULT_MODE.WeaponDetail;
				}
				else
				{
					mode = WORLD_QUEST_RESULT_MODE.MissionDetail;
				}
				RespWeapon weapon = reward.toRespWeapon();
				weaponDetailInfo.SetWeapon(weapon, ignoreUnknown: true);
				UIAutoTweenerStandAloneEx.In(weaponDetailInfo.gameObject);
			}
			break;
		case 4:
			if (!petDetailInfo.active)
			{
				if (mode != WORLD_QUEST_RESULT_MODE.Mission)
				{
					mode = WORLD_QUEST_RESULT_MODE.PetDetail;
				}
				else
				{
					mode = WORLD_QUEST_RESULT_MODE.MissionDetail;
				}
				RespPoppet muppet = reward.toRespPoppet();
				petDetailInfo.SetMuppet(muppet, ignoreUnknown: true);
				UIAutoTweenerStandAloneEx.In(petDetailInfo.gameObject);
			}
			break;
		}
	}

	private void PalyLevelUpEffect(int oldLv, int newLv)
	{
		if (leveupWindow != null && newLv > oldLv && !levelupFlag)
		{
			SetupLevelupInfo(oldLv, newLv);
			levelupFlag = true;
		}
	}

	private void EndTreasureEffect(GameObject obj)
	{
		UIBasicUtility.SetButtonValid(sellSwitchButtonSet, e: false);
		UIBasicUtility.SetButtonValid(nextButtonSet, e: false);
		checked
		{
			if (specialRewardInfo != null && specialRewardsCount < specialRewards.Length)
			{
				RespReward[] array = specialRewards;
				EmitSpecialReward(array[RuntimeServices.NormalizeArrayIndex(array, specialRewardsCount)]);
				specialRewardsCount++;
			}
			else if (mode == WORLD_QUEST_RESULT_MODE.ResultFinish)
			{
				if (!raidFlag && TutorialFlowControl.IsInTutorial)
				{
					TutorialFlowControl.GotoMyHomeFromTutorialQuest();
				}
				else if (QuestSession.WithServer)
				{
					ChangeFriendMode();
				}
				else
				{
					StartResultShortcut();
				}
			}
		}
	}

	private void ChangeFriendMode()
	{
		if ((!(specialRewardWindow != null) || !specialRewardWindow.active) && (!(leveupWindow != null) || !leveupWindow.active) && mode == WORLD_QUEST_RESULT_MODE.ResultFinish)
		{
			mode = WORLD_QUEST_RESULT_MODE.Friend;
		}
	}

	private void PushNo(GameObject obj)
	{
		if (mode == WORLD_QUEST_RESULT_MODE.SellConf)
		{
			mode = WORLD_QUEST_RESULT_MODE.Sell;
		}
		else if (isMission)
		{
			mode = WORLD_QUEST_RESULT_MODE.Mission;
		}
		else
		{
			StartResultShortcut();
		}
	}

	private void PushYes(GameObject obj)
	{
		_0024PushYes_0024locals_002414564 _0024PushYes_0024locals_0024 = new _0024PushYes_0024locals_002414564();
		UserData current = UserData.Current;
		if (mode == WORLD_QUEST_RESULT_MODE.SellConf)
		{
			SendSell();
			return;
		}
		_0024PushYes_0024locals_0024._0024endFunc = delegate
		{
			if (isMission)
			{
				mode = WORLD_QUEST_RESULT_MODE.Mission;
			}
			else
			{
				StartResultShortcut();
			}
		};
		if (debug_Connection)
		{
			_0024PushYes_0024locals_0024._0024endFunc();
			return;
		}
		if ((bool)dlgMan && current != null && current.userFriendListData.friends != null)
		{
			int friendMax = current.FriendMax;
			int num = current.userFriendListData.friends.Count();
			if (friendMax <= num)
			{
				Dialog dialog = DialogManager.Open(MTexts.Msg("$WQR_FRIEND_MAX_ERROR"), string.Empty);
				dialog.CloseHandler = new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024PushYes_0024closure_00244270(_0024PushYes_0024locals_0024).Invoke);
				return;
			}
		}
		ApiFriendApply apiFriendApply = new ApiFriendApply();
		apiFriendApply.IgnoreErrorCodes = new string[2] { "FrApp005", "FrApp002" };
		if (SceneChanger.CurrentScene != SceneID.Ui_WorldRaidResult)
		{
			apiFriendApply.Id = QuestSession.LastStartResponse.Fellow.TSocialPlayerId;
		}
		else
		{
			RespFriendPoppet curFrPoppet = QuestManager.Instance.CurFrPoppet;
			apiFriendApply.Id = curFrPoppet.RespFriend.TSocialPlayerId;
		}
		apiFriendApply.ErrorHandler = new _0024PushYes_0024closure_00244271(_0024PushYes_0024locals_0024).Invoke;
		MerlinServer.Request(apiFriendApply, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024PushYes_0024closure_00244272(_0024PushYes_0024locals_0024).Invoke));
	}

	private void PushOK(GameObject obj)
	{
		if (!IsChangingSituation)
		{
			if (isMission)
			{
				mode = WORLD_QUEST_RESULT_MODE.Mission;
			}
			else
			{
				StartResultShortcut();
			}
		}
	}

	private void SwtichSellMode(bool toSell)
	{
		if (toSell)
		{
			mode = WORLD_QUEST_RESULT_MODE.Sell;
		}
		else
		{
			mode = WORLD_QUEST_RESULT_MODE.ResultFinish;
		}
	}

	private void SendSell()
	{
		_0024SendSell_0024locals_002414565 _0024SendSell_0024locals_0024 = new _0024SendSell_0024locals_002414565();
		if (!(sellList == null))
		{
			System.Collections.Generic.List<RespPlayerBox> list = new System.Collections.Generic.List<RespPlayerBox>();
			RespPlayerBox[] items = ArrayMapMain.UIListItemsToRespPlayerBox(sellList.SelectItems);
			_0024SendSell_0024locals_0024._0024sellItemIds = ArrayMapMain.NonNullIds(items);
			__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ = new _0024SendSell_0024callback_00244273(_0024SendSell_0024locals_0024, this).Invoke;
			if (debug_Connection)
			{
				_ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__();
				return;
			}
			ApiSellBox apiSellBox = new ApiSellBox();
			apiSellBox.set(_0024SendSell_0024locals_0024._0024sellItemIds);
			MerlinServer.Request(apiSellBox, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(_ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__));
		}
	}

	private void PushSellSwitch(GameObject obj)
	{
		if (!IsChangingSituation && mode >= WORLD_QUEST_RESULT_MODE.ResultFinish)
		{
			if (mode == WORLD_QUEST_RESULT_MODE.ResultFinish)
			{
				SwtichSellMode(toSell: true);
			}
			else
			{
				SwtichSellMode(toSell: false);
			}
		}
	}

	private void PushItem(GameObject obj)
	{
		PushDetail(obj);
	}

	private void PushDetail(GameObject obj)
	{
		if (IsChangingSituation || isEffect)
		{
			return;
		}
		if (mode == WORLD_QUEST_RESULT_MODE.ResultFinish)
		{
			if (specialRewardWindow.active)
			{
				return;
			}
			RewardIconInfo component = obj.GetComponent<RewardIconInfo>();
			if (component.isWeapon)
			{
				if (!weaponDetailInfo.active)
				{
					mode = WORLD_QUEST_RESULT_MODE.WeaponDetail;
					weaponDetailInfo.SetWeapon(component.GetWeaponData(), ignoreUnknown: true);
					UIAutoTweenerStandAloneEx.In(weaponDetailInfo.gameObject);
					UIBasicUtility.SetButtonValid(sellSwitchButtonSet, e: false);
					UIBasicUtility.SetButtonValid(nextButtonSet, e: false);
				}
			}
			else if (component.isPet && !petDetailInfo.active)
			{
				mode = WORLD_QUEST_RESULT_MODE.PetDetail;
				petDetailInfo.SetMuppet(component.GetPetData(), ignoreUnknown: true);
				UIAutoTweenerStandAloneEx.In(petDetailInfo.gameObject);
				UIBasicUtility.SetButtonValid(sellSwitchButtonSet, e: false);
				UIBasicUtility.SetButtonValid(nextButtonSet, e: false);
			}
		}
		else if (mode == WORLD_QUEST_RESULT_MODE.Friend)
		{
			if (friend != null && !petDetailInfo.active)
			{
				mode = WORLD_QUEST_RESULT_MODE.FriendDetail;
				petDetailInfo.SetMuppet(friend.GetFriendPet(), ignoreUnknown: true);
				UIAutoTweenerStandAloneEx.In(petDetailInfo.gameObject);
				SetupAllNullButton();
			}
		}
		else if (mode == WORLD_QUEST_RESULT_MODE.Sell)
		{
			RespPlayerBox focusData = sellList.GetFocusData<RespPlayerBox>();
			if (focusData.IsWeapon)
			{
				UIAutoTweenerStandAloneEx.In(weaponDetailInfo.gameObject);
				weaponDetailInfo.SetWeapon(focusData.toRespWeapon(), ignoreUnknown: true);
				mode = WORLD_QUEST_RESULT_MODE.WeaponDetail;
			}
			else if (focusData.IsPoppet)
			{
				UIAutoTweenerStandAloneEx.In(petDetailInfo.gameObject);
				petDetailInfo.SetMuppet(focusData.toRespPoppet(), ignoreUnknown: true);
				mode = WORLD_QUEST_RESULT_MODE.PetDetail;
			}
			isShowDetail = true;
		}
		else
		{
			if (mode != WORLD_QUEST_RESULT_MODE.Mission)
			{
				return;
			}
			MapetListItem componentInChildren = obj.GetComponentInChildren<MapetListItem>();
			WeaponListItem componentInChildren2 = obj.GetComponentInChildren<WeaponListItem>();
			if (null != componentInChildren)
			{
				if (componentInChildren.mapetInfo == null || null == petDetailInfo || petDetailInfo.active)
				{
					return;
				}
				petDetailInfo.SetMuppet(componentInChildren.mapetInfo, ignoreUnknown: true);
				UIAutoTweenerStandAloneEx.In(petDetailInfo.gameObject);
				mode = WORLD_QUEST_RESULT_MODE.MissionDetail;
			}
			else if (null != componentInChildren2)
			{
				if (componentInChildren2.weaponInfo == null || null == weaponDetailInfo || weaponDetailInfo.active)
				{
					return;
				}
				weaponDetailInfo.SetWeapon(componentInChildren2.weaponInfo, ignoreUnknown: true);
				UIAutoTweenerStandAloneEx.In(weaponDetailInfo.gameObject);
				mode = WORLD_QUEST_RESULT_MODE.MissionDetail;
			}
			isShowDetail = true;
		}
	}

	private void PushChangeScene(GameObject obj)
	{
		SceneID nextScene = SceneID.Town;
		switch (obj.name)
		{
		case "Gift":
			nextScene = SceneID.Ui_MyHomeGift;
			break;
		case "Bag":
			nextScene = SceneID.Lottery_UI;
			break;
		case "BlackSmith":
			nextScene = SceneID.Ui_TownBlacksmith;
			break;
		case "Challenge":
			nextScene = SceneID.Ui_WorldChallenge;
			break;
		case "Myhome":
			nextScene = SceneID.Myhome;
			break;
		case "Raid":
			nextScene = SceneID.Ui_WorldRaid;
			break;
		case "Special":
			nextScene = SceneID.Ui_WorldQuest;
			break;
		case "StoneShop":
			nextScene = SceneID.Ui_TownStoneShop;
			break;
		case "Town":
			nextScene = SceneID.Town;
			break;
		case "WorldMap":
			nextScene = SceneID.Ui_World;
			break;
		}
		ChangeScene(nextScene);
	}

	private void ChangeScene(SceneID nextScene)
	{
		_0024ChangeScene_0024locals_002414566 _0024ChangeScene_0024locals_0024 = new _0024ChangeScene_0024locals_002414566();
		_0024ChangeScene_0024locals_0024._0024nextScene = nextScene;
		UserData current = UserData.Current;
		if (current == null)
		{
			return;
		}
		bool flag = false;
		if (debug_Connection)
		{
			flag = true;
		}
		doRaid = false;
		_0024ChangeScene_0024locals_0024._0024gotoNextScene = false;
		if (raidFlag)
		{
			_0024ChangeScene_0024locals_0024._0024gotoNextScene = true;
			if (!raidTutorial)
			{
				RespTCycleRaidBattle raidBattle = UserData.Current.userRaidInfo.raidBattle;
				if (raidBattle != null && raidBattle.IsEnableRaid)
				{
					_0024ChangeScene_0024locals_0024._0024nextScene = SceneID.Ui_WorldRaid;
				}
			}
		}
		else
		{
			_0024ChangeScene_0024locals_0024._0024gotoNextScene = true;
			if (flag)
			{
				doRaid = true;
			}
			else
			{
				doRaid = QuestSession.GetLastResult()?.IsRaidDiscover ?? false;
			}
		}
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024ChangeScene_0024waitCoroutine_00244274(_0024ChangeScene_0024locals_0024).Invoke;
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private void CloseDetailWindonw(GameObject window)
	{
		if (!isShowDetail)
		{
			ShowBackButton(show: false);
		}
		UIAutoTweenerStandAloneEx.Out(window, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024172.Adapt(delegate
		{
			UIBasicUtility.SetButtonValid(sellSwitchButtonSet, showSellSwitchButton);
			UIBasicUtility.SetButtonValid(nextButtonSet, e: true);
			if (isShowDetail)
			{
				mode = WORLD_QUEST_RESULT_MODE.Sell;
				isShowDetail = false;
			}
			else
			{
				mode = WORLD_QUEST_RESULT_MODE.ResultFinish;
			}
		}));
	}

	private void PushBack(GameObject obj)
	{
		if (mode == WORLD_QUEST_RESULT_MODE.WeaponDetail)
		{
			CloseDetailWindonw(weaponDetailInfo.gameObject);
		}
		else if (mode == WORLD_QUEST_RESULT_MODE.PetDetail)
		{
			CloseDetailWindonw(petDetailInfo.gameObject);
		}
		else if (mode == WORLD_QUEST_RESULT_MODE.FriendDetail)
		{
			mode = WORLD_QUEST_RESULT_MODE.Friend;
			UIAutoTweenerStandAloneEx.Out(petDetailInfo.gameObject);
			ShowBackButton(show: false);
		}
		else if (mode == WORLD_QUEST_RESULT_MODE.Sell)
		{
			PushSellSwitch(obj);
			ShowBackButton(show: false);
		}
		else if (mode == WORLD_QUEST_RESULT_MODE.SellConf)
		{
			mode = WORLD_QUEST_RESULT_MODE.Sell;
		}
		else if (mode == WORLD_QUEST_RESULT_MODE.Mission)
		{
			ShowBackButton(show: false);
		}
		else if (mode == WORLD_QUEST_RESULT_MODE.MissionDetail)
		{
			ShowBackButton(show: false);
			isShowDetail = false;
			mode = WORLD_QUEST_RESULT_MODE.Mission;
			if (weaponDetailInfo.gameObject.active)
			{
				UIAutoTweenerStandAloneEx.Out(weaponDetailInfo.gameObject);
			}
			if (petDetailInfo.gameObject.active)
			{
				UIAutoTweenerStandAloneEx.Out(petDetailInfo.gameObject);
			}
		}
	}

	private void PushSkipDemo(GameObject obj)
	{
		if (demoAnim != null)
		{
			Gousei3D component = demoAnim.GetComponent<Gousei3D>();
			if (component != null)
			{
				component.skip = true;
			}
		}
		PushEndDemo(null);
	}

	private void PushEndDemo(GameObject obj)
	{
		UISituation[] array;
		checked
		{
			endDemoCount++;
			if (bgFilter != null)
			{
				bgFilter.gameObject.SetActive(value: true);
			}
			array = situations;
		}
		if (array[RuntimeServices.NormalizeArrayIndex(array, (int)mode)] != null)
		{
			UISituation[] array2 = situations;
			array2[RuntimeServices.NormalizeArrayIndex(array2, (int)mode)].gameObject.SetActive(value: true);
		}
		isNewItemDemo = false;
		CleanDemoObject();
	}

	private void CleanDemoObject()
	{
		UnityEngine.Object.DestroyImmediate(demoAnim);
		demoAnim = null;
	}

	private bool GetNewItemDemo(RespReward reward)
	{
		UserData current = UserData.Current;
		int result;
		RespWeapon respWeapon;
		RespPoppet respPoppet;
		bool flag;
		checked
		{
			if (reward == null)
			{
				result = 0;
			}
			else
			{
				respWeapon = null;
				respPoppet = null;
				flag = default(bool);
				int num = 0;
				if (reward.TypeValue == 3)
				{
					respWeapon = reward.toRespWeapon();
					if (respWeapon != null)
					{
						if (lastWeaponPicBookTable.ContainsKey(respWeapon.Master.Id.ToString()))
						{
							num = RuntimeServices.UnboxInt32(lastWeaponPicBookTable[respWeapon.Master.Id.ToString()]);
							flag = num > 0;
						}
						lastWeaponPicBookTable[respWeapon.Master.Id.ToString()] = num + 1;
						goto IL_015f;
					}
					result = 0;
				}
				else if (reward.TypeValue == 4)
				{
					respPoppet = reward.toRespPoppet();
					if (respPoppet != null)
					{
						if (lastPoppetPicBookTable.ContainsKey(respPoppet.Master.Id.ToString()))
						{
							num = RuntimeServices.UnboxInt32(lastPoppetPicBookTable[respPoppet.Master.Id.ToString()]);
							flag = num > 0;
						}
						lastPoppetPicBookTable[respPoppet.Master.Id.ToString()] = num + 1;
						goto IL_015f;
					}
					result = 0;
				}
				else
				{
					result = 0;
				}
			}
			goto IL_03d6;
		}
		IL_015f:
		if (flag)
		{
			result = 0;
		}
		else
		{
			CleanDemoObject();
			if (demoAnimPrefab != null)
			{
				demoAnim = (GameObject)UnityEngine.Object.Instantiate(demoAnimPrefab);
			}
			if (demoAnim == null)
			{
				result = 0;
			}
			else
			{
				SceneTitleHUD.SetActive(a: false);
				Gousei3D component = demoAnim.GetComponent<Gousei3D>();
				if (respWeapon != null)
				{
					component.mode = Gousei3D.Mode.WeaponGet;
					int num2;
					int length;
					checked
					{
						component.atkValue = (int)respWeapon.TotalAttack;
						component.hpValue = (int)respWeapon.TotalHP;
						component.targetWeapon = respWeapon;
						component.baseWeapon = null;
						component.rare = respWeapon.Master.Rare.Id;
						component.traitSpriteName = respWeapon.TraitSpriteName;
						num2 = 0;
						length = component.materialWeapon.Length;
						if (length < 0)
						{
							throw new ArgumentOutOfRangeException("max");
						}
					}
					while (num2 < length)
					{
						int index = num2;
						num2++;
						RespWeapon[] materialWeapon = component.materialWeapon;
						materialWeapon[RuntimeServices.NormalizeArrayIndex(materialWeapon, index)] = null;
					}
				}
				else if (respPoppet != null)
				{
					component.mode = Gousei3D.Mode.PoppetGet;
					int num3;
					int length2;
					checked
					{
						component.atkValue = (int)respPoppet.TotalAttack;
						component.hpValue = (int)respPoppet.TotalHP;
						component.targetPoppet = respPoppet;
						component.basePoppet = null;
						component.rare = respPoppet.Master.Rare.Id;
						component.traitSpriteName = respPoppet.TraitSpriteName;
						num3 = 0;
						length2 = component.materialPoppet.Length;
						if (length2 < 0)
						{
							throw new ArgumentOutOfRangeException("max");
						}
					}
					while (num3 < length2)
					{
						int index2 = num3;
						num3++;
						RespPoppet[] materialPoppet = component.materialPoppet;
						materialPoppet[RuntimeServices.NormalizeArrayIndex(materialPoppet, index2)] = null;
					}
				}
				component.testMode = false;
				component.seiko = 0;
				component.IsLevelUp = false;
				component.IsSkillUp = false;
				component.IsLimitOver = false;
				component.elevatedLevel = 0;
				component.endFuncObject = gameObject;
				component.endFunction = "PushEndDemo";
				demoAnim.SetActive(value: true);
				if ((bool)bgFilter)
				{
					bgFilter.gameObject.SetActive(value: false);
				}
				UISituation[] array = situations;
				if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, (int)mode)])
				{
					UISituation[] array2 = situations;
					array2[RuntimeServices.NormalizeArrayIndex(array2, (int)mode)].gameObject.SetActive(value: false);
				}
				isNewItemDemo = true;
				result = 1;
			}
		}
		goto IL_03d6;
		IL_03d6:
		return (byte)result != 0;
	}

	private void PushClear()
	{
		if (IsChangingSituation || isShowDetail)
		{
			return;
		}
		if (0 < sellList.selectCount)
		{
			sellList.ClearSelectItems();
			return;
		}
		int num = 0;
		int num2 = sellList.Count();
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			GameObject gameObject = sellList.At(index);
			if (!(gameObject == null))
			{
				UIListItem component = gameObject.GetComponent<UIListItem>();
				if (!component.Disable)
				{
					sellList.SelectItem(index);
				}
			}
		}
	}

	private void PushSell()
	{
		if (!IsChangingSituation && !isShowDetail)
		{
			RespPlayerBox[] array = ArrayMapMain.UIListItemsToRespPlayerBox(sellList.SelectItems);
			if (array.Count() > 0)
			{
				SellCheck(array);
			}
		}
	}

	private void SellCheck(RespPlayerBox[] selects)
	{
		string text = MTexts.Msg("$blk_sell_selection");
		if (PowupBase.IsCheckRareItem(selects))
		{
			text = MTexts.Msg("$blk_sell_rare");
		}
		UIBasicUtility.SetLabel(warningRareLabel, text, show: true);
		int i = 0;
		BoxListItem[] array = selectItemDisplay;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			UnityEngine.Object.DestroyImmediate(array[i].Instance);
		}
		int num = 0;
		int length2 = selectItemDisplay.Length;
		if (length2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length2)
		{
			int num2 = num;
			num++;
			BoxListItem[] array2 = selectItemDisplay;
			BoxListItem boxListItem = array2[RuntimeServices.NormalizeArrayIndex(array2, num2)];
			if (num2 < selects.Length)
			{
				RespPlayerBox respPlayerBox = selects[RuntimeServices.NormalizeArrayIndex(selects, num2)];
				if (respPlayerBox != null && !RuntimeServices.EqualityOperator(boxListItem.ID, respPlayerBox.Id))
				{
					boxListItem.gameObject.SetActive(value: true);
					UIListItem.Data data = new UIListItem.Data();
					data.core = respPlayerBox;
					boxListItem.SetData(data);
					boxListItem.Init();
				}
			}
			else
			{
				boxListItem.gameObject.SetActive(value: false);
			}
		}
		mode = WORLD_QUEST_RESULT_MODE.SellConf;
		ShowBackButton(show: false);
	}

	public void PushEndMission(GameObject obj)
	{
		if (!IsChangingSituation && mode == WORLD_QUEST_RESULT_MODE.Mission)
		{
			StartResultShortcut();
		}
	}

	private RespReward[] CreateMissionRewards()
	{
		RespReward[] array = new RespReward[0];
		RespReward[] result;
		if (curQuest == null)
		{
			result = array;
		}
		else
		{
			RespQuestMission[] clearMissionsOf = UserData.Current.userQuestMission.getClearMissionsOf(curQuest);
			if (clearMissionsOf != null)
			{
				int i = 0;
				RespQuestMission[] array2 = clearMissionsOf;
				for (int length = array2.Length; i < length; i = checked(i + 1))
				{
					if (array2[i] != null && !(null == array2[i].Rewards))
					{
						array = (RespReward[])RuntimeServices.AddArrays(typeof(RespReward), array, array2[i].Rewards);
					}
				}
			}
			result = array;
		}
		return result;
	}

	private void StartMissionReward()
	{
		if (enableMissionReward)
		{
			__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024StartMissionReward_0024closure_00244247_002422326(this).GetEnumerator();
			IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	private void MissionReward(GameObject obj)
	{
		UIBasicUtility.SetButtonValid(sellSwitchButtonSet, e: false);
		UIBasicUtility.SetButtonValid(nextButtonSet, e: false);
		checked
		{
			if (specialRewardInfo != null && missionRewardsCount < missionRewards.Length)
			{
				RespReward[] array = missionRewards;
				EmitSpecialReward(array[RuntimeServices.NormalizeArrayIndex(array, missionRewardsCount)]);
				missionRewardsCount++;
			}
			else
			{
				missionList.AutoStartNewMissionAnimation = true;
			}
		}
	}

	private void StartResultShortcut()
	{
		InitResultShortcut();
		if (EnableResutlShortcut())
		{
			mode = WORLD_QUEST_RESULT_MODE.ResultShortcut;
		}
		else
		{
			SceneChanger.ChangeTo(resultShortcutData.nextSceneId);
		}
	}

	private bool EnableResutlShortcut()
	{
		return ResultShortcut.IsEnabled(resultShortcutData.intoScene);
	}

	private void InitResultShortcut()
	{
		isAlradyPushRetry = false;
		EnumQuestTypes enumQuestTypes = EnumQuestTypes.Normal;
		if (debugCurrentQuest != 0)
		{
			enumQuestTypes = (EnumQuestTypes)debugCurrentQuest;
		}
		else if (curQuest != null)
		{
			enumQuestTypes = curQuest.QuestType;
		}
		bool valid = true;
		SceneID nextSceneId = SceneID.Town;
		EnumAreaTypes enumAreaTypes = EnumAreaTypes.Town;
		ResultShortcut.IntoScene intoScene = ResultShortcut.IntoScene.Normal;
		if (DailyTask.IsNewDay)
		{
			valid = false;
			nextSceneId = SceneID.Myhome;
			enumAreaTypes = EnumAreaTypes.Myhome;
			intoScene = ResultShortcut.IntoScene.Max;
		}
		else if (raidFlag)
		{
			nextSceneId = SceneID.Ui_WorldRaid;
			enumAreaTypes = EnumAreaTypes.Raid;
			intoScene = ResultShortcut.IntoScene.Raid;
		}
		else
		{
			switch (enumQuestTypes)
			{
			case EnumQuestTypes.Normal:
				nextSceneId = SceneID.Town;
				enumAreaTypes = EnumAreaTypes.Town;
				intoScene = ResultShortcut.IntoScene.Normal;
				break;
			case EnumQuestTypes.Challenge:
				nextSceneId = SceneID.Town;
				enumAreaTypes = EnumAreaTypes.Challenge;
				intoScene = ResultShortcut.IntoScene.Challenge;
				break;
			case EnumQuestTypes.Special:
				nextSceneId = SceneID.Town;
				enumAreaTypes = EnumAreaTypes.SpecialQuest;
				intoScene = ResultShortcut.IntoScene.Limited;
				break;
			case EnumQuestTypes.LongTerm:
				nextSceneId = SceneID.Town;
				enumAreaTypes = EnumAreaTypes.SpecialQuest;
				intoScene = ResultShortcut.IntoScene.Limited;
				break;
			case EnumQuestTypes.Boost:
				nextSceneId = SceneID.Town;
				enumAreaTypes = EnumAreaTypes.BoostQuest;
				intoScene = ResultShortcut.IntoScene.Grow;
				break;
			}
		}
		if (ResultShortcut.ValidArea(enumAreaTypes) && ResultShortcut.GetArea(enumAreaTypes) == null)
		{
			valid = false;
		}
		if (ResultShortcut.IsEnabled(intoScene))
		{
			ResultShortcut.Initialize(intoScene, valid);
		}
		resultShortcutData = new ResultShortcutData();
		resultShortcutData.questType = enumQuestTypes;
		resultShortcutData.nextSceneId = nextSceneId;
		resultShortcutData.intoScene = intoScene;
		resultShortcutData.nextArea = enumAreaTypes;
	}

	private void PushRetry()
	{
		if (!isAlradyPushRetry)
		{
			ResultShortcut.Retry(resultShortcutData.nextArea);
			isAlradyPushRetry = true;
		}
	}

	private void PushEnd()
	{
		ResultShortcut.End();
	}

	internal void _0024SceneStart_0024closure_00244242()
	{
		Initialize();
	}

	internal void _0024flowFinish_0024closure_00244243()
	{
		if (missionOkButtonSet != null)
		{
			UIBasicUtility.SetButtonValid(missionOkButtonSet, e: true);
		}
	}

	internal void _0024flowRaidResult_0024closure_00244244()
	{
		SceneChanger.ChangeTo(SceneID.Ui_WorldRaid);
	}

	internal int _0024_genRewardsTrait_0024itemType2TypeValue_00244246(int itemid)
	{
		return checked(itemid + 2);
	}

	internal IEnumerator _0024StartMissionReward_0024closure_00244247()
	{
		return new _0024_0024StartMissionReward_0024closure_00244247_002422326(this).GetEnumerator();
	}

	internal int _0024flowOpenIcon_0024closure_00244264(GameObject a, GameObject b)
	{
		return string.Compare(a.name, b.name);
	}

	internal void _0024PushNext_0024closure_00244265()
	{
		nextButton.collider.enabled = false;
		nextButton.cantTouchHandler = null;
	}

	internal void _0024PushLevelUpOk_0024closure_00244266(GameObject obj)
	{
		levelupFlag = false;
		if (leveupWindow != null)
		{
			leveupWindow.SetActive(value: false);
		}
		ApRpExp.CureApRp();
	}

	internal void _0024PushRewardOk_0024closure_00244267(GameObject obj)
	{
		if (specialRewardWindow != null)
		{
			specialRewardWindow.SetActive(value: false);
		}
		if (mode == WORLD_QUEST_RESULT_MODE.ResultFinish)
		{
			EndTreasureEffect(obj);
		}
		else if (mode == WORLD_QUEST_RESULT_MODE.Mission)
		{
			MissionReward(obj);
		}
	}

	internal void _0024PushYes_0024closure_00244269()
	{
		if (isMission)
		{
			mode = WORLD_QUEST_RESULT_MODE.Mission;
		}
		else
		{
			StartResultShortcut();
		}
	}

	internal void _0024CloseDetailWindonw_0024closure_00244275()
	{
		UIBasicUtility.SetButtonValid(sellSwitchButtonSet, showSellSwitchButton);
		UIBasicUtility.SetButtonValid(nextButtonSet, e: true);
		if (isShowDetail)
		{
			mode = WORLD_QUEST_RESULT_MODE.Sell;
			isShowDetail = false;
		}
		else
		{
			mode = WORLD_QUEST_RESULT_MODE.ResultFinish;
		}
	}
}
