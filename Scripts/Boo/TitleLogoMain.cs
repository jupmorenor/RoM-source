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
public class TitleLogoMain : UIMain
{
	[Serializable]
	public enum TITLE_MODE
	{
		None = -1,
		Menu = 0,
		Continue = 2,
		WebView = 1,
		WebViewContact = 3,
		CacheClear = 4,
		Max = 5
	}

	[Serializable]
	internal class _0024clearCacheRoutine_0024locals_002414538
	{
		internal int _0024btn;

		internal bool _0024ok;
	}

	[Serializable]
	internal class _0024clearCacheRoutine_0024closure_00245102
	{
		internal _0024clearCacheRoutine_0024locals_002414538 _0024_0024locals_002415199;

		public _0024clearCacheRoutine_0024closure_00245102(_0024clearCacheRoutine_0024locals_002414538 _0024_0024locals_002415199)
		{
			this._0024_0024locals_002415199 = _0024_0024locals_002415199;
		}

		public void Invoke(int n)
		{
			_0024_0024locals_002415199._0024btn = n;
		}
	}

	[Serializable]
	internal class _0024clearCacheRoutine_0024closure_00245103
	{
		internal _0024clearCacheRoutine_0024locals_002414538 _0024_0024locals_002415200;

		public _0024clearCacheRoutine_0024closure_00245103(_0024clearCacheRoutine_0024locals_002414538 _0024_0024locals_002415200)
		{
			this._0024_0024locals_002415200 = _0024_0024locals_002415200;
		}

		public bool Invoke()
		{
			return _0024_0024locals_002415200._0024ok = true;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024jumpToNextScreen_002421914 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiPlatformExtServer _0024extreq_002421915;

			internal bool _0024hasUUID_002421916;

			internal ApiPlatformAccessInfo _0024req_002421917;

			internal ApiIsCreate _0024req2_002421918;

			internal int _0024cnt_002421919;

			internal TitleLogoMain _0024self__002421920;

			public _0024(TitleLogoMain self_)
			{
				_0024self__002421920 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					MerlinServer.Busy = true;
					_0024self__002421920.LockTouch(on: true);
					_0024extreq_002421915 = new ApiPlatformExtServer();
					MerlinServer.ExRequest(_0024extreq_002421915);
					goto case 2;
				case 2:
					if (!_0024extreq_002421915.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024extreq_002421915.IsOk)
					{
						_0024self__002421920.SceneChangeTo(SceneID.Boot);
						MerlinServer.Busy = false;
						goto case 1;
					}
					result = (Yield(3, _0024self__002421920.StartCoroutine(JoinDeviceFlow.TryRestore())) ? 1 : 0);
					break;
				case 3:
					_0024hasUUID_002421916 = CurrentInfo.HasUUID;
					if (!_0024hasUUID_002421916)
					{
						_0024self__002421920.SceneChangeTo(SceneID.Ui_CreateUserID);
						MerlinServer.Busy = false;
						goto case 1;
					}
					_0024req_002421917 = new ApiPlatformAccessInfo();
					_0024req_002421917.ErrorHandler = delegate
					{
						_0024self__002421920.LockTouch(on: false);
					};
					MerlinServer.ExRequest(_0024req_002421917);
					goto case 4;
				case 4:
					if (!_0024req_002421917.IsEnd)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					if (!_0024req_002421917.IsOk)
					{
						goto IL_023e;
					}
					DailyTask.LastPlayDate = MerlinDateTime.Now;
					_0024req2_002421918 = new ApiIsCreate();
					_0024req2_002421918.ErrorHandler = delegate
					{
						_0024self__002421920.LockTouch(on: false);
					};
					MerlinServer.ExRequest(_0024req2_002421918);
					goto case 5;
				case 5:
					if (!_0024req2_002421918.IsEnd)
					{
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					if (!_0024req2_002421918.IsOk)
					{
						goto IL_023e;
					}
					_0024cnt_002421919 = 0;
					goto case 6;
				case 6:
					if (ClientMasterArchive.IsReadingMasterArchive())
					{
						if (checked(++_0024cnt_002421919) > 60)
						{
							_0024cnt_002421919 = 0;
						}
						result = (YieldDefault(6) ? 1 : 0);
						break;
					}
					GameSoundManager.Instance.InitSeTableBySeMaster();
					if (_0024req2_002421918.GetResponse().Created)
					{
						GameSoundManager.Reset = true;
						TutorialFlowControl.Create();
					}
					else
					{
						_0024self__002421920.SceneChangeTo(SceneID.Ui_CharMake);
					}
					MerlinServer.Busy = false;
					goto IL_023e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_023e:
					MerlinServer.Busy = false;
					if (!_0024req_002421917.IsOk)
					{
						_0024self__002421920.SceneChangeTo(SceneID.Boot);
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal TitleLogoMain _0024self__002421921;

		public _0024jumpToNextScreen_002421914(TitleLogoMain self_)
		{
			_0024self__002421921 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002421921);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024clearCacheRoutine_002421922 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal DialogManager _0024dlgMan_002421923;

			internal string _0024msg_002421924;

			internal Dialog _0024d_002421925;

			internal _0024clearCacheRoutine_0024locals_002414538 _0024_0024locals_002421926;

			internal TitleLogoMain _0024self__002421927;

			public _0024(TitleLogoMain self_)
			{
				_0024self__002421927 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002421926 = new _0024clearCacheRoutine_0024locals_002414538();
					_0024self__002421927.mode = TITLE_MODE.CacheClear;
					_0024dlgMan_002421923 = DialogManager.Instance;
					_0024self__002421927.title = "ダウンロードデータ削除";
					_0024msg_002421924 = "これによって\nゲーム容量が削減されます。\n<RED>※セーブデータは削除されません。<COLOR_INIT>\n削除しますか？";
					_0024d_002421925 = _0024dlgMan_002421923.OpenDialog(_0024msg_002421924, _0024self__002421927.title, DialogManager.MB_FLAG.MB_ICONQUESTION, new string[2] { "いいえ", "はい" });
					_0024_0024locals_002421926._0024btn = -1;
					_0024d_002421925.ButtonHandler = new _0024clearCacheRoutine_0024closure_00245102(_0024_0024locals_002421926).Invoke;
					goto case 2;
				case 2:
					if (_0024_0024locals_002421926._0024btn < 0)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024_0024locals_002421926._0024btn == 1)
					{
						_0024self__002421927.mode = TITLE_MODE.Menu;
						goto case 1;
					}
					ClearData.ClearDownloadedData();
					_0024self__002421927.title = string.Empty;
					_0024msg_002421924 = "ダウンロードデータを\n削除しました。\nゲームを始めると\n再度ダウンロードを開始します";
					_0024_0024locals_002421926._0024ok = false;
					_0024d_002421925 = _0024dlgMan_002421923.OpenDialog(_0024msg_002421924, _0024self__002421927.title, DialogManager.MB_FLAG.MB_ICONQUESTION, new string[1] { "OK" });
					_0024d_002421925.ButtonHandler = _0024adaptor_0024__LotterySequence_startUpdateFunc_0024callable42_002410_31___0024__QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38___0024208.Adapt(new _0024clearCacheRoutine_0024closure_00245103(_0024_0024locals_002421926).Invoke);
					goto case 3;
				case 3:
					if (!_0024_0024locals_002421926._0024ok)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__002421927.mode = TITLE_MODE.Menu;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TitleLogoMain _0024self__002421928;

		public _0024clearCacheRoutine_002421922(TitleLogoMain self_)
		{
			_0024self__002421928 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421928);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024PushBack_0024back_00245092_002421929 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal TitleLogoMain _0024self__002421930;

			public _0024(TitleLogoMain self_)
			{
				_0024self__002421930 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if ((bool)_0024self__002421930.curWebView)
					{
						UIAutoTweenerStandAloneEx.Out(_0024self__002421930.webPanel);
						result = (Yield(2, _0024self__002421930.StartCoroutine(JoinDeviceFlow.TryRestoreFromWebClose())) ? 1 : 0);
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

		internal TitleLogoMain _0024self__002421931;

		public _0024_0024PushBack_0024back_00245092_002421929(TitleLogoMain self_)
		{
			_0024self__002421931 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002421931);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024TouchChange_0024closure_00245099_002421932 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiPlatformExtServer _0024extreq_002421933;

			internal TitleLogoMain _0024self__002421934;

			public _0024(TitleLogoMain self_)
			{
				_0024self__002421934 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024extreq_002421933 = new ApiPlatformExtServer();
					MerlinServer.ExRequest(_0024extreq_002421933);
					goto case 2;
				case 2:
					if (!_0024extreq_002421933.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024extreq_002421933.IsOk)
					{
						_0024self__002421934.SceneChangeTo(SceneID.Boot);
						goto case 1;
					}
					goto case 3;
				case 3:
					result = (((!(_0024self__002421934.buttonWait > 0f)) ? Yield(4, _0024self__002421934.StartCoroutine(JoinDeviceFlow.TryRestore())) : YieldDefault(3)) ? 1 : 0);
					break;
				case 4:
					JoinDeviceFlow.BackupUUID();
					CurrentInfo.UUID = ServerUtilModule.GenerateUUID();
					_0024self__002421934.GotTokenCallback(null);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TitleLogoMain _0024self__002421935;

		public _0024_0024TouchChange_0024closure_00245099_002421932(TitleLogoMain self_)
		{
			_0024self__002421935 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002421935);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024TouchContact_0024closure_00245101_002421936 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ApiPlatformExtServer _0024extreq_002421937;

			internal ApiPlatformAccessInfo _0024tokreq_002421938;

			internal ApiWebContact _0024conreq_002421939;

			internal TitleLogoMain _0024self__002421940;

			public _0024(TitleLogoMain self_)
			{
				_0024self__002421940 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024extreq_002421937 = new ApiPlatformExtServer();
					MerlinServer.ExRequest(_0024extreq_002421937);
					goto case 2;
				case 2:
					if (!_0024extreq_002421937.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024extreq_002421937.IsOk)
					{
						_0024self__002421940.SceneChangeTo(SceneID.Boot);
						goto case 1;
					}
					_0024tokreq_002421938 = new ApiPlatformAccessInfo();
					MerlinServer.ExRequest(_0024tokreq_002421938);
					goto case 3;
				case 3:
					if (!_0024tokreq_002421938.IsEnd)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (!_0024tokreq_002421938.IsOk)
					{
						_0024self__002421940.SceneChangeTo(SceneID.Boot);
						goto case 1;
					}
					_0024conreq_002421939 = new ApiWebContact();
					MerlinServer.ExRequest(_0024conreq_002421939);
					goto case 4;
				case 4:
					if (!_0024conreq_002421939.IsEnd)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					if (!_0024conreq_002421939.IsOk)
					{
						_0024self__002421940.SceneChangeTo(SceneID.Boot);
						goto case 1;
					}
					goto case 5;
				case 5:
					if (_0024self__002421940.buttonWait > 0f)
					{
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					_0024self__002421940.ShowWebHtml(_0024conreq_002421939.Result);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TitleLogoMain _0024self__002421941;

		public _0024_0024TouchContact_0024closure_00245101_002421936(TitleLogoMain self_)
		{
			_0024self__002421941 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421941);
		}
	}

	public int count;

	public BoxCollider startButton;

	public BoxCollider sqexButton;

	public string sqexButtonUrl;

	public BoxCollider webButton;

	public BoxCollider contactButton;

	public BoxCollider cacheClearButton;

	public GameObject[] skipAnimLogo;

	private TITLE_MODE mode;

	private TITLE_MODE lastMode;

	public GameObject webPanel;

	private WebView curWebView;

	protected bool skip;

	public UITweener[] tweens;

	protected int endTweensCount;

	protected float buttonWait;

	protected float buttonDisableTime;

	protected bool IsButtonDisabled => buttonDisableTime > 0f;

	public TitleLogoMain()
	{
		sqexButtonUrl = "https://sqex-bridge.jp/";
		tweens = new UITweener[0];
	}

	public override void LockTouch(bool on)
	{
		UIButtonMessage.AllDisable = on;
		base.LockTouch(on);
	}

	private void InitContinueButton()
	{
		SceneChanger.ScenePreChangeEvent += OffLockTouch;
	}

	private void OffLockTouch(string str)
	{
		LockTouch(on: false);
		SceneChanger.ScenePreChangeEvent -= OffLockTouch;
	}

	public override void SceneStart()
	{
		MerlinServer instance = MerlinServer.Instance;
		instance.EnableLoadingLabel = true;
		SQEX_SoundPlayer.Instance.StopAllSe(1000);
		RuntimeAssetBundleDB.Instance.unloadAll();
		TownShopTopMain.DestroyTownModel(destroy: true);
		MyhomeSubSceneTopMain.DestroyMyhomeModel(destroy: true);
		MyHomeMain.NeedOshirase = true;
		NewInformation.Shown = false;
		count = 0;
		mode = TITLE_MODE.Menu;
		lastMode = TITLE_MODE.None;
		webPanel.SetActive(value: false);
		webPanel.gameObject.GetComponentsInChildren<WebView>(includeInactive: true).First().CloseCallback = PushBack;
		endTweensCount = 0;
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>();
		int i = 0;
		UITweener[] array = componentsInChildren;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if ((bool)array[i] && array[i].style == UITweener.Style.Once)
				{
					tweens = (UITweener[])RuntimeServices.AddArrays(typeof(UITweener), tweens, new UITweener[1] { array[i] });
					array[i].onFinished = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024OnFinished_0024157.Adapt(delegate
					{
						endTweensCount++;
					});
				}
			}
			InitContinueButton();
			buttonDisableTime = 3f;
		}
	}

	public override void SceneUpdate()
	{
		__TitleLogoMain_SceneUpdate_0024callable187_0024109_13__ _TitleLogoMain_SceneUpdate_0024callable187_0024109_13__ = delegate(BoxCollider b, bool on)
		{
			if (!(b == null))
			{
				if (on)
				{
					b.gameObject.SetActive(value: true);
					b.enabled = true;
				}
				else
				{
					b.gameObject.SetActive(value: false);
				}
			}
		};
		if (mode != lastMode)
		{
			lastMode = mode;
			if (mode == TITLE_MODE.Menu)
			{
				if ((bool)startButton)
				{
					startButton.enabled = true;
				}
				if ((bool)sqexButton)
				{
					sqexButton.enabled = true;
				}
				if ((bool)webButton)
				{
					webButton.enabled = true;
				}
				if (contactButton != null)
				{
					_TitleLogoMain_SceneUpdate_0024callable187_0024109_13__(contactButton, CurrentInfo.HasUUID);
				}
				if (cacheClearButton != null)
				{
					_TitleLogoMain_SceneUpdate_0024callable187_0024109_13__(cacheClearButton, CurrentInfo.DownloadCompleted);
				}
			}
			else
			{
				if ((bool)startButton)
				{
					startButton.enabled = false;
				}
				if ((bool)sqexButton)
				{
					sqexButton.enabled = false;
				}
				if ((bool)webButton)
				{
					webButton.enabled = false;
				}
				if (contactButton != null)
				{
					contactButton.enabled = false;
				}
				if (cacheClearButton != null)
				{
					cacheClearButton.enabled = false;
				}
			}
			SetupAllNullButton();
			buttonWait = 1f;
		}
		if (!(buttonWait <= 0f))
		{
			buttonWait -= Time.deltaTime;
		}
		if (!(buttonDisableTime <= 0f))
		{
			buttonDisableTime -= Time.deltaTime;
		}
	}

	public bool SkipTitleDemo()
	{
		int result;
		checked
		{
			if (endTweensCount < tweens.Length && !skip)
			{
				skip = true;
				int i = 0;
				UITweener[] array = tweens;
				for (int length = array.Length; i < length; i++)
				{
					if ((bool)array[i])
					{
						array[i].delay = 0f;
						if (array[i].style == UITweener.Style.Once)
						{
							array[i].Sample(1f, isFinished: true);
						}
						array[i].enabled = false;
					}
				}
				if (skipAnimLogo != null)
				{
					int j = 0;
					GameObject[] array2 = skipAnimLogo;
					for (int length2 = array2.Length; j < length2; j++)
					{
						if ((bool)array2[j])
						{
							array2[j].SetActive(value: false);
						}
					}
				}
				LockTouch(on: false);
				buttonDisableTime = 0f;
				result = 1;
			}
			else
			{
				result = 0;
			}
		}
		return (byte)result != 0;
	}

	public void TouchStart()
	{
		if (!SkipTitleDemo())
		{
			TouchContinue();
		}
	}

	public void TouchContinue()
	{
		if (!SkipTitleDemo() && !RuntimeDebugMode.Instance.IsInDebugMode)
		{
			mode = TITLE_MODE.Continue;
			IEnumerator enumerator = jumpToNextScreen();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	private IEnumerator jumpToNextScreen()
	{
		return new _0024jumpToNextScreen_002421914(this).GetEnumerator();
	}

	public void TouchSQEXSite()
	{
		if (!IsButtonDisabled)
		{
			Application.OpenURL(sqexButtonUrl);
		}
	}

	public void TouchChange()
	{
		if (mode == TITLE_MODE.Menu && !IsButtonDisabled)
		{
			mode = TITLE_MODE.WebView;
			__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024TouchChange_0024closure_00245099_002421932(this).GetEnumerator();
			IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	public void GotTokenCallback(RequestBase r)
	{
		ApiEntryJoinDevice apiEntryJoinDevice = new ApiEntryJoinDevice();
		apiEntryJoinDevice.marketCode = 1;
		apiEntryJoinDevice.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
		{
			LockTouch(on: false);
		});
		apiEntryJoinDevice.DeviceUUID = CurrentInfo.UUID;
		MerlinServer.Request(apiEntryJoinDevice, ShowWebHtml);
	}

	public void TouchContact()
	{
		if (mode == TITLE_MODE.Menu && !IsButtonDisabled)
		{
			mode = TITLE_MODE.WebViewContact;
			__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024TouchContact_0024closure_00245101_002421936(this).GetEnumerator();
			IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	public void TouchCacheClear()
	{
		if (mode == TITLE_MODE.Menu && !IsButtonDisabled)
		{
			IEnumerator enumerator = clearCacheRoutine();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	private IEnumerator clearCacheRoutine()
	{
		return new _0024clearCacheRoutine_002421922(this).GetEnumerator();
	}

	public void ShowWebHtml(RequestBase req)
	{
		ShowWebHtml(req.Result);
		if (curWebView != null)
		{
			JoinDeviceFlow.SetWebView(curWebView);
		}
	}

	public void ShowWebHtml(string html)
	{
		if ((bool)curWebView)
		{
			UIAutoTweenerStandAloneEx.Out(webPanel);
		}
		curWebView = null;
		curWebView = webPanel.GetComponentsInChildren<WebView>(includeInactive: true).FirstOrDefault();
		if ((bool)curWebView)
		{
			UIAutoTweenerStandAloneEx.In(webPanel);
			curWebView.OpenHtml(html, ServerURL.GameServerUrl("/"));
			string nextUrl = WebViewBase.GetNextUrl();
		}
	}

	public void TouchCreate()
	{
		SceneChangeTo(SceneID.Ui_CreateUserID);
	}

	private void SceneChangeTo(SceneID id)
	{
		SceneChanger.ChangeTo(id);
	}

	public void PushBack()
	{
		TITLE_MODE tITLE_MODE = mode;
		mode = TITLE_MODE.Menu;
		switch (tITLE_MODE)
		{
		case TITLE_MODE.WebView:
		{
			__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024PushBack_0024back_00245092_002421929(this).GetEnumerator();
			IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
			break;
		}
		case TITLE_MODE.WebViewContact:
			UIAutoTweenerStandAloneEx.Out(webPanel);
			break;
		}
	}

	internal IEnumerator _0024PushBack_0024back_00245092()
	{
		return new _0024_0024PushBack_0024back_00245092_002421929(this).GetEnumerator();
	}

	internal void _0024SceneStart_0024closure_00245095()
	{
		checked
		{
			endTweensCount++;
		}
	}

	internal void _0024SceneUpdate_0024_enableButton_00245096(BoxCollider b, bool on)
	{
		if (!(b == null))
		{
			if (on)
			{
				b.gameObject.SetActive(value: true);
				b.enabled = true;
			}
			else
			{
				b.gameObject.SetActive(value: false);
			}
		}
	}

	internal void _0024jumpToNextScreen_0024closure_00245097(RequestBase r)
	{
		LockTouch(on: false);
	}

	internal void _0024jumpToNextScreen_0024closure_00245098(RequestBase r)
	{
		LockTouch(on: false);
	}

	internal IEnumerator _0024TouchChange_0024closure_00245099()
	{
		return new _0024_0024TouchChange_0024closure_00245099_002421932(this).GetEnumerator();
	}

	internal void _0024GotTokenCallback_0024closure_00245100()
	{
		LockTouch(on: false);
	}

	internal IEnumerator _0024TouchContact_0024closure_00245101()
	{
		return new _0024_0024TouchContact_0024closure_00245101_002421936(this).GetEnumerator();
	}
}
