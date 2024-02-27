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
public class TutorialFlowControl : MonoBehaviour
{
	[Serializable]
	public enum EProgress
	{
		Prologue,
		Opening,
		Quest,
		QuestResult,
		MyHome,
		Finished
	}

	[Serializable]
	internal class _0024main_0024locals_002414462
	{
		internal bool _0024repareOk;

		internal bool _0024ok;
	}

	[Serializable]
	internal class _0024askAndContinueQuest_0024locals_002414463
	{
		internal QuestSession.ContinueDataSet _0024cd;
	}

	[Serializable]
	internal class _0024askAndContinueColosseum_0024locals_002414464
	{
		internal ColosseumSession.ISessionState _0024cd;
	}

	[Serializable]
	internal class _0024askAndContinue_0024locals_002414465
	{
		internal int _0024btn;
	}

	[Serializable]
	internal class _0024askAndLoadOnlineData_0024locals_002414466
	{
		internal int _0024btn;
	}

	[Serializable]
	internal class _0024main_0024closure_00243093
	{
		internal _0024main_0024locals_002414462 _0024_0024locals_002415019;

		public _0024main_0024closure_00243093(_0024main_0024locals_002414462 _0024_0024locals_002415019)
		{
			this._0024_0024locals_002415019 = _0024_0024locals_002415019;
		}

		public void Invoke(bool res)
		{
			_0024_0024locals_002415019._0024repareOk = true;
		}
	}

	[Serializable]
	internal class _0024main_0024closure_00243095
	{
		internal _0024main_0024locals_002414462 _0024_0024locals_002415020;

		public _0024main_0024closure_00243095(_0024main_0024locals_002414462 _0024_0024locals_002415020)
		{
			this._0024_0024locals_002415020 = _0024_0024locals_002415020;
		}

		public void Invoke()
		{
			_0024_0024locals_002415020._0024ok = true;
		}
	}

	[Serializable]
	internal class _0024askAndContinueQuest_0024_yes_00243111
	{
		internal _0024askAndContinueQuest_0024locals_002414463 _0024_0024locals_002415021;

		public _0024askAndContinueQuest_0024_yes_00243111(_0024askAndContinueQuest_0024locals_002414463 _0024_0024locals_002415021)
		{
			this._0024_0024locals_002415021 = _0024_0024locals_002415021;
		}

		public void Invoke()
		{
			QuestSession.Continue(_0024_0024locals_002415021._0024cd);
		}
	}

	[Serializable]
	internal class _0024askAndContinueColosseum_0024_yes_00243113
	{
		internal _0024askAndContinueColosseum_0024locals_002414464 _0024_0024locals_002415022;

		public _0024askAndContinueColosseum_0024_yes_00243113(_0024askAndContinueColosseum_0024locals_002414464 _0024_0024locals_002415022)
		{
			this._0024_0024locals_002415022 = _0024_0024locals_002415022;
		}

		public void Invoke()
		{
			ColosseumSession.Instance.restart(_0024_0024locals_002415022._0024cd);
		}
	}

	[Serializable]
	internal class _0024askAndContinue_0024closure_00243115
	{
		internal _0024askAndContinue_0024locals_002414465 _0024_0024locals_002415023;

		public _0024askAndContinue_0024closure_00243115(_0024askAndContinue_0024locals_002414465 _0024_0024locals_002415023)
		{
			this._0024_0024locals_002415023 = _0024_0024locals_002415023;
		}

		public void Invoke(int n)
		{
			_0024_0024locals_002415023._0024btn = n;
		}
	}

	[Serializable]
	internal class _0024askAndLoadOnlineData_0024closure_00243116
	{
		internal _0024askAndLoadOnlineData_0024locals_002414466 _0024_0024locals_002415024;

		public _0024askAndLoadOnlineData_0024closure_00243116(_0024askAndLoadOnlineData_0024locals_002414466 _0024_0024locals_002415024)
		{
			this._0024_0024locals_002415024 = _0024_0024locals_002415024;
		}

		public void Invoke(int n)
		{
			_0024_0024locals_002415024._0024btn = n;
		}
	}

	[Serializable]
	internal class _0024askAndLoadOnlineData_0024closure_00243117
	{
		internal _0024askAndLoadOnlineData_0024locals_002414466 _0024_0024locals_002415025;

		public _0024askAndLoadOnlineData_0024closure_00243117(_0024askAndLoadOnlineData_0024locals_002414466 _0024_0024locals_002415025)
		{
			this._0024_0024locals_002415025 = _0024_0024locals_002415025;
		}

		public void Invoke(int n)
		{
			_0024_0024locals_002415025._0024btn = n;
		}
	}

	[Serializable]
	internal class _0024askAndLoadOnlineData_0024closure_00243119
	{
		internal _0024askAndLoadOnlineData_0024locals_002414466 _0024_0024locals_002415026;

		public _0024askAndLoadOnlineData_0024closure_00243119(_0024askAndLoadOnlineData_0024locals_002414466 _0024_0024locals_002415026)
		{
			this._0024_0024locals_002415026 = _0024_0024locals_002415026;
		}

		public void Invoke(int n)
		{
			_0024_0024locals_002415026._0024btn = n;
			SceneChanger.ChangeTo(SceneID.Boot, doFade: true);
			Kill();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002421157 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiHome _0024req_002421158;

			internal ApiCampaignURLScheme _0024ffrkReq_002421159;

			internal IEnumerator _0024_0024sco_0024temp_00242457_002421160;

			internal FaderCore _0024fader_002421161;

			internal bool _0024loaded_002421162;

			internal QuestSession.ContinueDataSet _0024cd_002421163;

			internal string _0024title_002421164;

			internal string _0024msg_002421165;

			internal IEnumerator _0024_0024sco_0024temp_00242458_002421166;

			internal ApiGuildResult _0024gr_002421167;

			internal ColosseumSession.ISessionState _0024colSession_002421168;

			internal IEnumerator _0024_0024sco_0024temp_00242459_002421169;

			internal PrologueMain _0024prmain_002421170;

			internal CutSceneOpening _0024opmain_002421171;

			internal bool _0024skip_002421172;

			internal PlayerControl _0024p_002421173;

			internal string _0024cutscene_002421174;

			internal IEnumerator _0024_0024sco_0024temp_00242460_002421175;

			internal _0024main_0024locals_002414462 _0024_0024locals_002421176;

			internal TutorialFlowControl _0024self__002421177;

			public _0024(TutorialFlowControl self_)
			{
				_0024self__002421177 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002421176 = new _0024main_0024locals_002414462();
					_0024req_002421158 = new ApiHome();
					MerlinServer.Request(_0024req_002421158);
					goto case 2;
				case 2:
					if (!_0024req_002421158.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024req_002421158.IsOk)
					{
						Kill();
						SceneChanger.ChangeTo(SceneID.Boot, doFade: true);
						goto case 1;
					}
					_0024ffrkReq_002421159 = ApiCampaignURLScheme.CreateFFRKColaboApiReq();
					if (_0024ffrkReq_002421159 != null)
					{
						MerlinServer.Request(_0024ffrkReq_002421159);
						goto case 3;
					}
					goto IL_012c;
				case 3:
					if (!_0024ffrkReq_002421159.IsEnd)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto IL_012c;
				case 4:
					if (!_0024_0024locals_002421176._0024repareOk)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					UserData.Current.userMiscInfo.Load();
					UserData.Current.userBoxData.haveAllBox();
					UserData.Current.Config.ReInitShowAutoBattleButtonFlag();
					MerlinServer.Busy = false;
					MerlinServer.Busy = true;
					if (!UserData.Current.userMiscInfo.IsAbleToSave)
					{
						_0024_0024sco_0024temp_00242457_002421160 = _0024self__002421177.askAndLoadOnlineData();
						if (_0024_0024sco_0024temp_00242457_002421160 != null)
						{
							result = (Yield(5, _0024self__002421177.StartCoroutine(_0024_0024sco_0024temp_00242457_002421160)) ? 1 : 0);
							break;
						}
					}
					goto case 5;
				case 5:
					MerlinServer.Busy = false;
					MerlinServer.Busy = true;
					if (CurrentInfo.DownloadCompleted)
					{
						GameSoundManager.Instance.LoadCommonSeFromBinPack();
					}
					if (CurrentInfo.DownloadCompleted)
					{
						IconAtlasPool.InitFromAssetbundles();
					}
					if (UserData.Current.userMiscInfo.bgmLoad && !DownloadMain.IsBgmCached())
					{
						Kill();
						DownloadMain.ChangeToBGMDownloadMode(SceneID.Boot);
						SceneChanger.ChangeTo(SceneID.Ui_Download);
					}
					else
					{
						MerlinServer.Busy = false;
						_0024fader_002421161 = FaderCore.Instance;
						_0024loaded_002421162 = false;
						_0024cd_002421163 = QuestSession.LoadContinueData();
						if (_0024cd_002421163.InvalidVersion)
						{
							_0024title_002421164 = string.Empty;
							_0024msg_002421165 = "アプリアップデートに伴い\n中断したクエストは破棄されます。";
							_0024_0024locals_002421176._0024ok = false;
							MerlinServer.FatalErrorDialog(_0024msg_002421165, _0024title_002421164, string.Empty, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024main_0024closure_00243095(_0024_0024locals_002421176).Invoke));
							goto case 6;
						}
						if (!_0024cd_002421163.IsLoaded)
						{
							goto IL_03da;
						}
						if (!(_0024cd_002421163.QuestProgname != "Story000Tutorial") && Progress < EProgress.Finished)
						{
							Progress = EProgress.Quest;
							_0024fader_002421161.fadeIn();
							goto case 7;
						}
						Progress = EProgress.Finished;
						_0024_0024sco_0024temp_00242458_002421166 = _0024self__002421177.askAndContinueQuest(_0024cd_002421163);
						if (_0024_0024sco_0024temp_00242458_002421166 != null)
						{
							_0024self__002421177.StartCoroutine(_0024_0024sco_0024temp_00242458_002421166);
						}
					}
					goto case 1;
				case 6:
					if (!_0024_0024locals_002421176._0024ok)
					{
						result = (YieldDefault(6) ? 1 : 0);
						break;
					}
					goto IL_03da;
				case 7:
					result = ((_0024fader_002421161.isInCompleted ? YieldDefault(8) : YieldDefault(7)) ? 1 : 0);
					break;
				case 8:
					if (QuestSession.Continue(_0024cd_002421163))
					{
						_0024loaded_002421162 = true;
					}
					goto IL_03da;
				case 9:
					result = ((_0024fader_002421161.isInCompleted ? YieldDefault(10) : YieldDefault(9)) ? 1 : 0);
					break;
				case 10:
					if (Progress == EProgress.Prologue)
					{
						MerlinServer.NotifyTutorialStep(10);
						Loading.Begin();
						SceneChanger.ChangeTo(SceneID.Prologue, doFade: false);
						_0024prmain_002421170 = null;
						goto case 11;
					}
					goto IL_05e3;
				case 11:
					_0024prmain_002421170 = (PrologueMain)UnityEngine.Object.FindObjectOfType(typeof(PrologueMain));
					if (!(_0024prmain_002421170 != null))
					{
						result = (YieldDefault(11) ? 1 : 0);
						break;
					}
					Loading.End();
					_0024fader_002421161.fadeOut();
					goto case 12;
				case 12:
					if (!_0024prmain_002421170.IsEndOfPlay)
					{
						result = (YieldDefault(12) ? 1 : 0);
						break;
					}
					_0024fader_002421161.fadeInEx(0f, 0f, 0f, 1f);
					goto case 13;
				case 13:
					result = ((_0024fader_002421161.isInCompleted ? YieldDefault(14) : YieldDefault(13)) ? 1 : 0);
					break;
				case 14:
					_0024self__002421177.next();
					goto IL_05e3;
				case 15:
					_0024opmain_002421171 = (CutSceneOpening)UnityEngine.Object.FindObjectOfType(typeof(CutSceneOpening));
					if (_0024opmain_002421171 != null)
					{
						goto case 16;
					}
					result = (YieldDefault(15) ? 1 : 0);
					break;
				case 16:
					if (!CutSceneManager.Instance.IsSceneReady)
					{
						result = (YieldDefault(16) ? 1 : 0);
						break;
					}
					Loading.End();
					_0024fader_002421161.fadeOut();
					goto case 17;
				case 17:
					if (!_0024opmain_002421171.IsEndOfPlay)
					{
						result = (YieldDefault(17) ? 1 : 0);
						break;
					}
					if (PlayerControl.CurrentPlayer != null)
					{
						PlayerControl.CurrentPlayer.gameObject.SetActive(value: false);
					}
					_0024self__002421177.next();
					_0024fader_002421161.fadeInEx(1f, 1f, 1f, 1f);
					goto case 18;
				case 18:
					result = ((_0024fader_002421161.isInCompleted ? YieldDefault(19) : YieldDefault(18)) ? 1 : 0);
					break;
				case 19:
					if (Progress == EProgress.Quest)
					{
						_0024skip_002421172 = false;
						Loading.Begin();
						if (!_0024loaded_002421162)
						{
							_0024self__002421177.startTutorialQuest();
						}
						else
						{
							if (!_0024cd_002421163.Sdata.ended)
							{
								goto case 20;
							}
							_0024skip_002421172 = true;
						}
						goto IL_07cb;
					}
					goto IL_089c;
				case 20:
					if (!PlayerControl.CurrentPlayer)
					{
						result = (YieldDefault(20) ? 1 : 0);
						break;
					}
					goto case 21;
				case 21:
					if (!PlayerControl.CurrentPlayer.IsReady)
					{
						result = (YieldDefault(21) ? 1 : 0);
						break;
					}
					if (!_0024fader_002421161.isOutCompleted)
					{
						_0024fader_002421161.fadeOut();
					}
					goto IL_07cb;
				case 22:
					if (!QuestClearConditionChecker.Instance.Finished)
					{
						result = (YieldDefault(22) ? 1 : 0);
						break;
					}
					goto IL_07fc;
				case 23:
					result = ((_0024fader_002421161.isInCompleted ? YieldDefault(24) : YieldDefault(23)) ? 1 : 0);
					break;
				case 24:
					QuestInitializer.DisposeAll();
					_0024self__002421177.next();
					goto IL_089c;
				case 25:
					if (Progress == EProgress.QuestResult)
					{
						result = (YieldDefault(25) ? 1 : 0);
						break;
					}
					_0024fader_002421161.fadeInEx(1f, 1f, 1f, 1f);
					goto case 26;
				case 26:
					result = ((_0024fader_002421161.isInCompleted ? YieldDefault(27) : YieldDefault(26)) ? 1 : 0);
					break;
				case 27:
					PyxisBridge.SendTutorialFinishingToFuckPyxisService();
					goto IL_0937;
				case 28:
					_0024p_002421173 = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
					if (_0024p_002421173 != null)
					{
						goto case 29;
					}
					result = (YieldDefault(28) ? 1 : 0);
					break;
				case 29:
					if (!_0024p_002421173.IsReady)
					{
						result = (YieldDefault(29) ? 1 : 0);
						break;
					}
					Loading.End();
					_0024cutscene_002421174 = "Merlin_CutSceneST01_ev01";
					_0024_0024sco_0024temp_00242460_002421175 = QuestCutscenePlayer.Instance.playCutSceneFadeSafe(_0024cutscene_002421174);
					if (_0024_0024sco_0024temp_00242460_002421175 != null)
					{
						result = (Yield(30, _0024self__002421177.StartCoroutine(_0024_0024sco_0024temp_00242460_002421175)) ? 1 : 0);
						break;
					}
					goto case 30;
				case 30:
					UserData.Current.setFlag("xEndOf1stMyhomeCutScene", 1);
					MyhomeScene.ControlFader = true;
					_0024self__002421177.next();
					goto IL_0a3f;
				case 1:
					{
						result = 0;
						break;
					}
					IL_07fc:
					if (QuestSession.Story == null || QuestSession.Quest == null)
					{
						Kill();
					}
					else
					{
						if (!(QuestSession.Quest.Progname != "Story000Tutorial"))
						{
							QuestSession.DeleteSaveData();
							setQuestClearFlag();
							_0024fader_002421161.fadeInEx(0f, 0f, 0f, 1f);
							goto case 23;
						}
						Kill();
					}
					goto case 1;
					IL_0937:
					if (Progress == EProgress.MyHome)
					{
						Loading.Begin();
						MerlinServer.NotifyTutorialStep(150);
						MyhomeScene.ControlFader = false;
						SceneChanger.ChangeTo(SceneID.Myhome, doFade: false);
						_0024p_002421173 = null;
						goto case 28;
					}
					goto IL_0a3f;
					IL_012c:
					MerlinServer.Busy = true;
					_0024_0024locals_002421176._0024repareOk = false;
					ReparePurchase.RepareStone(new _0024main_0024closure_00243093(_0024_0024locals_002421176).Invoke);
					goto case 4;
					IL_07cb:
					Loading.End();
					if (!_0024skip_002421172)
					{
						goto case 22;
					}
					goto IL_07fc;
					IL_0a3f:
					Kill();
					YieldDefault(1);
					goto case 1;
					IL_089c:
					if (Progress == EProgress.QuestResult)
					{
						Loading.Begin();
						MerlinServer.Request(ApiUpdateTutorial.PresentBoxOpened());
						QuestSession.InvalidateSession();
						Loading.End();
						SceneChanger.ChangeTo(SceneID.Ui_WorldQuestResult);
						goto case 25;
					}
					goto IL_0937;
					IL_05e3:
					if (Progress == EProgress.Opening)
					{
						MerlinServer.NotifyTutorialStep(20);
						Loading.Begin();
						SceneChanger.ChangeTo(SceneID.Opening, doFade: false);
						_0024opmain_002421171 = null;
						goto case 15;
					}
					goto case 19;
					IL_03da:
					_0024gr_002421167 = PhotonClientMain.LoadPlayInfo();
					if (_0024gr_002421167 != null)
					{
						_0024gr_002421167.Stealth = true;
						_0024gr_002421167.retryCount = 0;
						MerlinServer.Request(_0024gr_002421167);
						PhotonClientMain.DeleteSaveData();
					}
					_0024colSession_002421168 = ColosseumSession.Instance.load();
					if (_0024colSession_002421168 != null)
					{
						_0024_0024sco_0024temp_00242459_002421169 = _0024self__002421177.askAndContinueColosseum(_0024colSession_002421168);
						if (_0024_0024sco_0024temp_00242459_002421169 != null)
						{
							_0024self__002421177.StartCoroutine(_0024_0024sco_0024temp_00242459_002421169);
						}
					}
					else
					{
						if (Progress < EProgress.Finished)
						{
							SceneDontDestroyObject.dontDestroyOnLoad(_0024self__002421177.gameObject);
							UserData.Current.PlayerRace = RACE_TYPE.Tensi;
							if (!_0024fader_002421161.isInCompleted)
							{
								_0024fader_002421161.fadeIn();
								goto case 9;
							}
							goto case 10;
						}
						MyhomeScene.ControlFader = true;
						Kill();
						SceneChanger.ChangeTo(SceneID.Myhome, doFade: true);
					}
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialFlowControl _0024self__002421178;

		public _0024main_002421157(TutorialFlowControl self_)
		{
			_0024self__002421178 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002421178);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024askAndContinueQuest_002421179 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024_yes_002421180;

			internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024_no_002421181;

			internal IEnumerator _0024_0024sco_0024temp_00242461_002421182;

			internal _0024askAndContinueQuest_0024locals_002414463 _0024_0024locals_002421183;

			internal QuestSession.ContinueDataSet _0024cd_002421184;

			internal TutorialFlowControl _0024self__002421185;

			public _0024(QuestSession.ContinueDataSet cd, TutorialFlowControl self_)
			{
				_0024cd_002421184 = cd;
				_0024self__002421185 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002421183 = new _0024askAndContinueQuest_0024locals_002414463();
					_0024_0024locals_002421183._0024cd = _0024cd_002421184;
					_0024_yes_002421180 = new _0024askAndContinueQuest_0024_yes_00243111(_0024_0024locals_002421183).Invoke;
					_0024_no_002421181 = delegate
					{
						QuestSession.DeleteSaveData();
						Kill();
						SceneChanger.ChangeTo(SceneID.Myhome);
					};
					_0024_0024sco_0024temp_00242461_002421182 = _0024self__002421185.askAndContinue("クエストを中断しています。\n再開しますか？", "クエストプレイ中です", _0024_yes_002421180, _0024_no_002421181);
					if (_0024_0024sco_0024temp_00242461_002421182 != null)
					{
						result = (Yield(2, _0024self__002421185.StartCoroutine(_0024_0024sco_0024temp_00242461_002421182)) ? 1 : 0);
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

		internal QuestSession.ContinueDataSet _0024cd_002421186;

		internal TutorialFlowControl _0024self__002421187;

		public _0024askAndContinueQuest_002421179(QuestSession.ContinueDataSet cd, TutorialFlowControl self_)
		{
			_0024cd_002421186 = cd;
			_0024self__002421187 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024cd_002421186, _0024self__002421187);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024askAndContinueColosseum_002421188 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024_yes_002421189;

			internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024_no_002421190;

			internal IEnumerator _0024_0024sco_0024temp_00242462_002421191;

			internal _0024askAndContinueColosseum_0024locals_002414464 _0024_0024locals_002421192;

			internal ColosseumSession.ISessionState _0024cd_002421193;

			internal TutorialFlowControl _0024self__002421194;

			public _0024(ColosseumSession.ISessionState cd, TutorialFlowControl self_)
			{
				_0024cd_002421193 = cd;
				_0024self__002421194 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002421192 = new _0024askAndContinueColosseum_0024locals_002414464();
					_0024_0024locals_002421192._0024cd = _0024cd_002421193;
					_0024_yes_002421189 = new _0024askAndContinueColosseum_0024_yes_00243113(_0024_0024locals_002421192).Invoke;
					_0024_no_002421190 = delegate
					{
						ColosseumSession.Instance.clearSession();
						Kill();
						SceneChanger.ChangeTo(SceneID.Myhome);
					};
					_0024_0024sco_0024temp_00242462_002421191 = _0024self__002421194.askAndContinue("バトルを中断しています。\n再開しますか？", "闘技場プレイ中です", _0024_yes_002421189, _0024_no_002421190);
					if (_0024_0024sco_0024temp_00242462_002421191 != null)
					{
						result = (Yield(2, _0024self__002421194.StartCoroutine(_0024_0024sco_0024temp_00242462_002421191)) ? 1 : 0);
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

		internal ColosseumSession.ISessionState _0024cd_002421195;

		internal TutorialFlowControl _0024self__002421196;

		public _0024askAndContinueColosseum_002421188(ColosseumSession.ISessionState cd, TutorialFlowControl self_)
		{
			_0024cd_002421195 = cd;
			_0024self__002421196 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024cd_002421195, _0024self__002421196);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024askAndContinue_002421197 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal DialogManager _0024dlgMan_002421198;

			internal Dialog _0024d_002421199;

			internal _0024askAndContinue_0024locals_002414465 _0024_0024locals_002421200;

			internal string _0024title_002421201;

			internal string _0024message_002421202;

			internal ICallable _0024yesTask_002421203;

			internal ICallable _0024noTask_002421204;

			public _0024(string title, string message, ICallable yesTask, ICallable noTask)
			{
				_0024title_002421201 = title;
				_0024message_002421202 = message;
				_0024yesTask_002421203 = yesTask;
				_0024noTask_002421204 = noTask;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002421200 = new _0024askAndContinue_0024locals_002414465();
					_0024dlgMan_002421198 = DialogManager.Instance;
					_0024d_002421199 = _0024dlgMan_002421198.OpenDialog(_0024title_002421201, _0024message_002421202, DialogManager.MB_FLAG.MB_ICONQUESTION, new string[2] { "いいえ", "はい" });
					_0024_0024locals_002421200._0024btn = -1;
					_0024d_002421199.ButtonHandler = new _0024askAndContinue_0024closure_00243115(_0024_0024locals_002421200).Invoke;
					goto case 2;
				case 2:
					if (_0024_0024locals_002421200._0024btn < 0)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024_0024locals_002421200._0024btn == 1)
					{
						if (_0024noTask_002421204 != null)
						{
							_0024noTask_002421204.Call(new object[0]);
						}
					}
					else if (_0024_0024locals_002421200._0024btn == 2 && _0024yesTask_002421203 != null)
					{
						_0024yesTask_002421203.Call(new object[0]);
					}
					Kill();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024title_002421205;

		internal string _0024message_002421206;

		internal ICallable _0024yesTask_002421207;

		internal ICallable _0024noTask_002421208;

		public _0024askAndContinue_002421197(string title, string message, ICallable yesTask, ICallable noTask)
		{
			_0024title_002421205 = title;
			_0024message_002421206 = message;
			_0024yesTask_002421207 = yesTask;
			_0024noTask_002421208 = noTask;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024title_002421205, _0024message_002421206, _0024yesTask_002421207, _0024noTask_002421208);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024askAndLoadOnlineData_002421209 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal DialogManager _0024dlgMan_002421210;

			internal Dialog _0024d_002421211;

			internal ApiLocalDataDownload _0024reqlclDatDL_002421212;

			internal _0024askAndLoadOnlineData_0024locals_002414466 _0024_0024locals_002421213;

			internal TutorialFlowControl _0024self__002421214;

			public _0024(TutorialFlowControl self_)
			{
				_0024self__002421214 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002421213 = new _0024askAndLoadOnlineData_0024locals_002414466();
					_0024dlgMan_002421210 = DialogManager.Instance;
					_0024d_002421211 = _0024dlgMan_002421210.OpenDialog("データが破損している可能性が\nあります。サーバーからデータ\n復旧を試みますか？", "データ読み込みエラー", DialogManager.MB_FLAG.MB_ICONQUESTION, new string[2] { "いいえ", "はい" });
					_0024_0024locals_002421213._0024btn = -1;
					_0024d_002421211.ButtonHandler = new _0024askAndLoadOnlineData_0024closure_00243116(_0024_0024locals_002421213).Invoke;
					goto case 2;
				case 2:
					if (_0024_0024locals_002421213._0024btn < 0)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024_0024locals_002421213._0024btn == 1)
					{
						_0024_0024locals_002421213._0024btn = -1;
						_0024d_002421211 = _0024dlgMan_002421210.OpenDialog("現在のデータで上書きしてよろしいですか？", string.Empty, DialogManager.MB_FLAG.MB_ICONQUESTION, new string[2] { "いいえ", "はい" });
						_0024_0024locals_002421213._0024btn = -1;
						_0024d_002421211.ButtonHandler = new _0024askAndLoadOnlineData_0024closure_00243117(_0024_0024locals_002421213).Invoke;
						goto case 3;
					}
					if (_0024_0024locals_002421213._0024btn == 2)
					{
						_0024reqlclDatDL_002421212 = new ApiLocalDataDownload();
						_0024reqlclDatDL_002421212.ErrorHandler = delegate(RequestBase r)
						{
							if (!(r.ResponseObj is GameApiResponseBase { StatusCode: var statusCode }))
							{
							}
						};
						MerlinServer.ExRequest(_0024reqlclDatDL_002421212);
						goto case 4;
					}
					goto IL_028a;
				case 3:
					if (_0024_0024locals_002421213._0024btn < 0)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (_0024_0024locals_002421213._0024btn == 2)
					{
						UserData.Current.userMiscInfo.AllowToSave();
					}
					goto IL_028a;
				case 4:
					if (!_0024reqlclDatDL_002421212.IsEnd)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					if (!_0024reqlclDatDL_002421212.IsOk)
					{
						SceneChanger.ChangeTo(SceneID.Boot, doFade: true);
						Kill();
					}
					if (!UserData.Current.userMiscInfo.IsAbleToSave)
					{
						_0024d_002421211 = _0024dlgMan_002421210.OpenDialog("データ復旧に失敗しました。", "データ復旧エラー", DialogManager.MB_FLAG.MB_ICONQUESTION, new string[1] { "OK" });
						_0024_0024locals_002421213._0024btn = -1;
						_0024d_002421211.ButtonHandler = new _0024askAndLoadOnlineData_0024closure_00243119(_0024_0024locals_002421213).Invoke;
						goto case 5;
					}
					goto IL_028a;
				case 5:
					if (_0024_0024locals_002421213._0024btn < 0)
					{
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					goto IL_028a;
				case 1:
					{
						result = 0;
						break;
					}
					IL_028a:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialFlowControl _0024self__002421215;

		public _0024askAndLoadOnlineData_002421209(TutorialFlowControl self_)
		{
			_0024self__002421215 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421215);
		}
	}

	[NonSerialized]
	private const string TUTORIAL_QUEST_NAME = "Story000Tutorial";

	[NonSerialized]
	private const string MYHOME_CUTSCENE_NAME = "Merlin_CutSceneST01_ev01";

	[NonSerialized]
	private static readonly EProgress INITIAL_PROGRESS = EProgress.Prologue;

	[NonSerialized]
	private static GameObject CurrentObject;

	public static EProgress Progress
	{
		get
		{
			return (EProgress)GetProgress();
		}
		set
		{
			SetProgress((int)value);
		}
	}

	public static bool IsInTutorial
	{
		get
		{
			bool num = CurrentObject != null;
			if (num)
			{
				num = Progress < EProgress.Finished;
			}
			return num;
		}
	}

	public static MStories GetTutorialQuestStory()
	{
		int num = 0;
		MStories[] all = MStories.All;
		int length = all.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (all[num].IsTutorial && all[num].MQuestId.Progname == "Story000Tutorial")
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
		return (MStories)result;
	}

	public static void SetProgressFinished()
	{
		Progress = EProgress.Finished;
		setQuestClearFlag();
	}

	private void next()
	{
		Progress++;
		UserData.Current.userMiscInfo.Save();
	}

	public static void GotoMyHomeFromTutorialQuest()
	{
		if (Progress == EProgress.QuestResult)
		{
			Progress = EProgress.MyHome;
		}
	}

	public static void Create()
	{
		Kill();
		GameObject gameObject = new GameObject();
		gameObject.name = "TutorialFlowControl";
		TutorialFlowControl tutorialFlowControl = ExtensionsModule.SetComponent<TutorialFlowControl>(gameObject);
		CurrentObject = gameObject;
	}

	public static void Kill()
	{
		if (CurrentObject != null)
		{
			UnityEngine.Object.Destroy(CurrentObject);
			CurrentObject = null;
		}
	}

	public void Start()
	{
		IEnumerator enumerator = main();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator main()
	{
		return new _0024main_002421157(this).GetEnumerator();
	}

	private void startTutorialQuest()
	{
		MStories tutorialQuestStory = GetTutorialQuestStory();
		if (tutorialQuestStory != null)
		{
			QuestManager.Instance.CurQuest = tutorialQuestStory.MQuestId;
			QuestSessionParameters questSessionParameters = new QuestSessionParameters();
			questSessionParameters.withServer = false;
			questSessionParameters.storyId = tutorialQuestStory.Id;
			questSessionParameters.noSceneLoad = false;
			questSessionParameters.withSceneFade = false;
			questSessionParameters.needEndLogo = false;
			questSessionParameters.needResultMode = false;
			QuestSession.StartSession(questSessionParameters);
		}
	}

	private static void setQuestClearFlag()
	{
		MQuests quest = QuestSession.Quest;
		if (quest != null)
		{
			MFlags mFlags = MFlagsUtil.QuestClearFlag(quest);
			if (mFlags == null)
			{
				throw new AssertionFailedException(new StringBuilder("クエスト ").Append(quest).Append(" に対応するクリアフラグ ").Append(MFlagsUtil.QuestClearFlagName(quest))
					.Append("が定義されてない！バグだから西森へ報告！")
					.ToString());
			}
			UserData.Current.setFlag(mFlags);
			if (QuestSession.Story != null)
			{
				UserData.Current.userMiscInfo.storyData.play(QuestSession.Story.Progname);
			}
		}
	}

	public static void SetProgress(int progress)
	{
		UserData.Current.userMiscInfo.tutorialStep = progress;
	}

	public static int GetProgress()
	{
		return UserData.Current.userMiscInfo.tutorialStep;
	}

	private IEnumerator askAndContinueQuest(QuestSession.ContinueDataSet cd)
	{
		return new _0024askAndContinueQuest_002421179(cd, this).GetEnumerator();
	}

	private IEnumerator askAndContinueColosseum(ColosseumSession.ISessionState cd)
	{
		return new _0024askAndContinueColosseum_002421188(cd, this).GetEnumerator();
	}

	private IEnumerator askAndContinue(string title, string message, ICallable yesTask, ICallable noTask)
	{
		return new _0024askAndContinue_002421197(title, message, yesTask, noTask).GetEnumerator();
	}

	private IEnumerator askAndLoadOnlineData()
	{
		return new _0024askAndLoadOnlineData_002421209(this).GetEnumerator();
	}

	internal void _0024askAndContinueQuest_0024_no_00243112()
	{
		QuestSession.DeleteSaveData();
		Kill();
		SceneChanger.ChangeTo(SceneID.Myhome);
	}

	internal void _0024askAndContinueColosseum_0024_no_00243114()
	{
		ColosseumSession.Instance.clearSession();
		Kill();
		SceneChanger.ChangeTo(SceneID.Myhome);
	}

	internal void _0024askAndLoadOnlineData_0024closure_00243118(RequestBase r)
	{
		if (!(r.ResponseObj is GameApiResponseBase { StatusCode: var statusCode }))
		{
		}
	}
}
