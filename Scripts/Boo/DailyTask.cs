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
public class DailyTask : MonoBehaviour
{
	[Serializable]
	internal class _0024main_0024locals_002414337
	{
		internal bool _0024ok;
	}

	[Serializable]
	internal class _0024NewDay_0024locals_002414338
	{
		internal bool _0024ok;
	}

	[Serializable]
	internal class _0024main_0024closure_00243260
	{
		internal _0024main_0024locals_002414337 _0024_0024locals_002414781;

		public _0024main_0024closure_00243260(_0024main_0024locals_002414337 _0024_0024locals_002414781)
		{
			this._0024_0024locals_002414781 = _0024_0024locals_002414781;
		}

		public void Invoke()
		{
			_0024_0024locals_002414781._0024ok = true;
		}
	}

	[Serializable]
	internal class _0024NewDay_0024closure_00243261
	{
		internal _0024NewDay_0024locals_002414338 _0024_0024locals_002414782;

		public _0024NewDay_0024closure_00243261(_0024NewDay_0024locals_002414338 _0024_0024locals_002414782)
		{
			this._0024_0024locals_002414782 = _0024_0024locals_002414782;
		}

		public void Invoke(object button)
		{
			_0024_0024locals_002414782._0024ok = true;
		}
	}

	[Serializable]
	internal class _0024NewDay_0024closure_00243262
	{
		internal _0024NewDay_0024locals_002414338 _0024_0024locals_002414783;

		public _0024NewDay_0024closure_00243262(_0024NewDay_0024locals_002414338 _0024_0024locals_002414783)
		{
			this._0024_0024locals_002414783 = _0024_0024locals_002414783;
		}

		public void Invoke(bool result)
		{
			_0024_0024locals_002414783._0024ok = true;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002416681 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_sec_0024temp_00241191_002416682;

			internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024cb_002416683;

			internal IEnumerator _0024_0024sco_0024temp_00241192_002416684;

			internal _0024main_0024locals_002414337 _0024_0024locals_002416685;

			internal DailyTask _0024self__002416686;

			public _0024(DailyTask self_)
			{
				_0024self__002416686 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002416685 = new _0024main_0024locals_002414337();
					if (TutorialFlowControl.IsInTutorial)
					{
						goto case 1;
					}
					_0024_0024wait_sec_0024temp_00241191_002416682 = delay;
					goto case 2;
				case 2:
					if (_0024_0024wait_sec_0024temp_00241191_002416682 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241191_002416682 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					delay = 0f;
					goto IL_0084;
				case 3:
					if (!SceneChanger.isFadeOut || IPauseWindow.IsPaused || MerlinServer.Instance.IsBusy || CutSceneManager.IsBusy || GameLevelManager.IsBusy || TutorialEvent.IsBusy || NpcTalkControl.IsBusy || BattleHUDShortcut.IsOpen)
					{
						goto IL_0084;
					}
					if (!NewInformation.IsEnableNewInformation())
					{
						goto case 1;
					}
					TimeScaleUtil.Zero();
					TheWorld.StopWorldForPause();
					goto case 4;
				case 4:
					if (!FaderCore.Instance.isCompleted)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024_0024locals_002416685._0024ok = false;
					_0024cb_002416683 = new _0024main_0024closure_00243260(_0024_0024locals_002416685).Invoke;
					_0024_0024sco_0024temp_00241192_002416684 = _0024self__002416686.NewDay(_0024cb_002416683);
					if (_0024_0024sco_0024temp_00241192_002416684 != null)
					{
						_0024self__002416686.StartCoroutine(_0024_0024sco_0024temp_00241192_002416684);
					}
					goto case 5;
				case 5:
					if (!_0024_0024locals_002416685._0024ok)
					{
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					TheWorld.RestartWorldForPause();
					TimeScaleUtil.One();
					_0024self__002416686.taskFinished = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0084:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal DailyTask _0024self__002416687;

		public _0024main_002416681(DailyTask self_)
		{
			_0024self__002416687 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416687);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024NewDay_002416688 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024title_002416689;

			internal string _0024msg_002416690;

			internal ApiGetVersion _0024verApi_002416691;

			internal ApiCampaignURLScheme _0024ffrkReq_002416692;

			internal _0024NewDay_0024locals_002414338 _0024_0024locals_002416693;

			internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024callBack_002416694;

			public _0024(__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ callBack)
			{
				_0024callBack_002416694 = callBack;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002416693 = new _0024NewDay_0024locals_002414338();
					_0024_0024locals_002416693._0024ok = false;
					_0024title_002416689 = string.Empty;
					_0024msg_002416690 = "日付がかわりました";
					ErrorDialog.FatalError(_0024msg_002416690, _0024title_002416689, jumpBoot: true, string.Empty, _0024adaptor_0024__LotteryBase_LoadResource_0024callable41_00241986_51___0024__QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38___0024127.Adapt(new _0024NewDay_0024closure_00243261(_0024_0024locals_002416693).Invoke));
					goto case 2;
				case 2:
					if (!_0024_0024locals_002416693._0024ok)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024_0024locals_002416693._0024ok = false;
					MerlinServer.ExRequest(ApiLocalDataUpload.WithUserData());
					MerlinServer.ExRequest(new ApiPlatformAccessInfo());
					MerlinServer.ExRequest(new ApiHome());
					_0024verApi_002416691 = new ApiGetVersion();
					MerlinServer.ExRequest(_0024verApi_002416691);
					goto case 3;
				case 3:
					if (!_0024verApi_002416691.IsEnd)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024ffrkReq_002416692 = ApiCampaignURLScheme.CreateFFRKColaboApiReq();
					if (_0024ffrkReq_002416692 != null)
					{
						MerlinServer.Request(_0024ffrkReq_002416692);
						goto case 4;
					}
					goto IL_0146;
				case 4:
					if (!_0024ffrkReq_002416692.IsEnd)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					goto IL_0146;
				case 5:
					if (!_0024_0024locals_002416693._0024ok)
					{
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					UserData.Current.userMiscInfo.flagData.updateCondition();
					Save(MerlinDateTime.Now);
					if (_0024callBack_002416694 != null)
					{
						_0024callBack_002416694();
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0146:
					_0024_0024locals_002416693._0024ok = false;
					WebBannerTown.InitTownWebBannerHtml(new _0024NewDay_0024closure_00243262(_0024_0024locals_002416693).Invoke);
					goto case 5;
				}
				return (byte)result != 0;
			}
		}

		internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024callBack_002416695;

		public _0024NewDay_002416688(__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ callBack)
		{
			_0024callBack_002416695 = callBack;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024callBack_002416695);
		}
	}

	[NonSerialized]
	private const string LAST_PLAY_DATE_KEY = "Merlin-Last-Play-DateTime";

	[NonSerialized]
	private static float delay;

	private bool taskFinished;

	public static DateTime LastPlayDate
	{
		get
		{
			DateTime now = MerlinDateTime.Now;
			try
			{
				string @string = PlayerPrefs.GetString("Merlin-Last-Play-DateTime", now.ToString());
				return DateTime.Parse(@string);
			}
			catch (Exception)
			{
				Save(now);
				return now;
			}
		}
		set
		{
			Save(value);
		}
	}

	public static bool IsNewDay
	{
		get
		{
			DateTime lastPlayDate = LastPlayDate;
			DateTime now = MerlinDateTime.Now;
			return lastPlayDate.Day != now.Day;
		}
	}

	public static float Delay
	{
		get
		{
			return delay;
		}
		set
		{
			delay = value;
		}
	}

	public static void DebugSaveYesterday()
	{
		Save(MerlinDateTime.Now - TimeSpan.FromDays(1.0));
	}

	private static void Save(DateTime dt)
	{
		PlayerPrefs.SetString("Merlin-Last-Play-DateTime", dt.ToString());
		PlayerPrefs.Save();
	}

	public static void UpdateCheckDailyTask(GameObject go)
	{
		if (!(go != null))
		{
			throw new AssertionFailedException("DailyTask 用の gameobject がnullですた。");
		}
		if (IsNewDay && !(go.GetComponent<DailyTask>() != null))
		{
			go.AddComponent<DailyTask>();
		}
	}

	public void Start()
	{
		MerlinTaskQueue.Task task = new MerlinTaskQueue.Task();
		task.Priority = 100;
		task.OnStart = delegate
		{
			taskFinished = false;
			IEnumerator enumerator = main();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		};
		task.IsCompleted = () => taskFinished;
		task.OnExit = delegate
		{
		};
		bool flag = false;
		MerlinTaskQueue.Instance.Enqueue(task);
	}

	private IEnumerator main()
	{
		return new _0024main_002416681(this).GetEnumerator();
	}

	public IEnumerator NewDay(__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ callBack)
	{
		return new _0024NewDay_002416688(callBack).GetEnumerator();
	}

	internal void _0024Start_0024closure_00243088()
	{
		taskFinished = false;
		IEnumerator enumerator = main();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	internal bool _0024Start_0024closure_00243089()
	{
		return taskFinished;
	}

	internal void _0024Start_0024closure_00243090()
	{
	}
}
