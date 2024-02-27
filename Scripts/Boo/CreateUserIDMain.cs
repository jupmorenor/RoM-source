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
public class CreateUserIDMain : UIMain
{
	[Serializable]
	public enum MODE
	{
		None = -1,
		UserName,
		UserNameWait,
		FriendInviteConf,
		FriendInviteInit,
		FriendInvite,
		CharMake,
		Max
	}

	[Serializable]
	internal class _0024_0024SceneStart_0024closure_00245032_0024locals_002414498
	{
		internal bool _0024verCheckEnd;

		internal ApiIsCreate _0024req;

		internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024call;
	}

	[Serializable]
	internal class _0024_0024_0024SceneStart_0024closure_00245032_0024call_00245033_0024closure_00245034
	{
		internal _0024_0024SceneStart_0024closure_00245032_0024locals_002414498 _0024_0024locals_002415093;

		public _0024_0024_0024SceneStart_0024closure_00245032_0024call_00245033_0024closure_00245034(_0024_0024SceneStart_0024closure_00245032_0024locals_002414498 _0024_0024locals_002415093)
		{
			this._0024_0024locals_002415093 = _0024_0024locals_002415093;
		}

		public void Invoke(ApiIsCreate r)
		{
			_0024_0024locals_002415093._0024verCheckEnd = true;
		}
	}

	[Serializable]
	internal class _0024_0024SceneStart_0024closure_00245032_0024call_00245033
	{
		internal _0024_0024SceneStart_0024closure_00245032_0024locals_002414498 _0024_0024locals_002415094;

		public _0024_0024SceneStart_0024closure_00245032_0024call_00245033(_0024_0024SceneStart_0024closure_00245032_0024locals_002414498 _0024_0024locals_002415094)
		{
			this._0024_0024locals_002415094 = _0024_0024locals_002415094;
		}

		public void Invoke()
		{
			MerlinServer.Request(_0024_0024locals_002415094._0024req, _0024adaptor_0024___0024_0024SceneStart_0024closure_00245032_0024call_00245033_Invoke_0024callable579_002445_37___0024__MerlinServer_Request_0024callable86_0024160_56___0024186.Adapt(new _0024_0024_0024SceneStart_0024closure_00245032_0024call_00245033_0024closure_00245034(_0024_0024locals_002415094).Invoke));
		}
	}

	[Serializable]
	internal class _0024_0024SceneStart_0024closure_00245032_0024closure_00245035
	{
		internal _0024_0024SceneStart_0024closure_00245032_0024locals_002414498 _0024_0024locals_002415095;

		public _0024_0024SceneStart_0024closure_00245032_0024closure_00245035(_0024_0024SceneStart_0024closure_00245032_0024locals_002414498 _0024_0024locals_002415095)
		{
			this._0024_0024locals_002415095 = _0024_0024locals_002415095;
		}

		public void Invoke()
		{
			_0024_0024locals_002415095._0024call();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ShowInvite_002421553 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal FaderCore _0024fader_002421554;

			internal ApiWebFriendInviteInput _0024req_002421555;

			internal CreateUserIDMain _0024self__002421556;

			public _0024(ApiWebFriendInviteInput req, CreateUserIDMain self_)
			{
				_0024req_002421555 = req;
				_0024self__002421556 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024req_002421555.IsOk)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002421556.mode = MODE.FriendInvite;
					if ((bool)_0024self__002421556.webView)
					{
						WebViewBase.StartWebView();
						WebViewBase.OpenHtmlFile(_0024req_002421555.Result, ServerURL.GameApiUrl("/"));
						_0024fader_002421554 = FaderCore.Instance;
						_0024fader_002421554.fadeIn();
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

		internal ApiWebFriendInviteInput _0024req_002421557;

		internal CreateUserIDMain _0024self__002421558;

		public _0024ShowInvite_002421553(ApiWebFriendInviteInput req, CreateUserIDMain self_)
		{
			_0024req_002421557 = req;
			_0024self__002421558 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024req_002421557, _0024self__002421558);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024SceneStart_0024closure_00245032_002421559 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal _0024_0024SceneStart_0024closure_00245032_0024locals_002414498 _0024_0024locals_002421560;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002421560 = new _0024_0024SceneStart_0024closure_00245032_0024locals_002414498();
					_0024_0024locals_002421560._0024verCheckEnd = false;
					_0024_0024locals_002421560._0024req = new ApiIsCreate();
					_0024_0024locals_002421560._0024call = new _0024_0024SceneStart_0024closure_00245032_0024call_00245033(_0024_0024locals_002421560).Invoke;
					_0024_0024locals_002421560._0024req.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024_0024SceneStart_0024closure_00245032_0024closure_00245035(_0024_0024locals_002421560).Invoke);
					goto case 2;
				case 2:
					if (_0024_0024locals_002421560._0024verCheckEnd)
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

		public override IEnumerator<object> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	[NonSerialized]
	public const int NAME_STRING_MAX = 8;

	public UIInput userNameInput;

	private DialogManager dlgMan;

	public WebView webView;

	private MODE mode;

	private MODE lastMode;

	private bool skipInvite;

	public string userName
	{
		get
		{
			if (!(userNameInput != null))
			{
				throw new AssertionFailedException("userNameLabel がアタッチされていません！");
			}
			return userNameInput.text;
		}
	}

	public CreateUserIDMain()
	{
		skipInvite = true;
	}

	public override void SceneStart()
	{
		SceneTitleHUD.UpdateTitle("新規登録");
		dlgMan = DialogManager.Instance;
		skipInvite = true;
		SetLoadingRoutine(() => new _0024_0024SceneStart_0024closure_00245032_002421559().GetEnumerator());
	}

	public void OnDestroy()
	{
		if ((bool)webView)
		{
			WebViewBase.EndWebView();
		}
	}

	public override void SceneUpdate()
	{
		if (IsChangingSituation)
		{
			return;
		}
		if (mode != lastMode)
		{
			UISituation[] array = situations;
			if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, (int)mode)])
			{
				UISituation[] array2 = situations;
				ChangeSituation(array2[RuntimeServices.NormalizeArrayIndex(array2, (int)mode)]);
			}
		}
		if (mode != lastMode)
		{
			lastMode = mode;
			switch (mode)
			{
			case MODE.FriendInviteInit:
				PushInvite(null);
				break;
			}
		}
		switch (mode)
		{
		}
	}

	public void GoCharMake()
	{
		SceneChanger.ChangeTo(SceneID.Ui_CharMake);
		mode = MODE.CharMake;
	}

	public void StartInviteConf()
	{
		if (skipInvite)
		{
			GoCharMake();
		}
		else if (!ApiExamVer.IsExamVer)
		{
			Dialog dialog = dlgMan.OpenDialog("招待コードを入力しますか？\n<RED>※招待コードは後から\n入力することもできます。<COLOR_INIT>", string.Empty, DialogManager.MB_FLAG.MB_ICONQUESTION, new string[2] { "いいえ", "はい" });
			mode = MODE.FriendInviteConf;
			dialog.ButtonHandler = delegate(int btn)
			{
				switch (btn)
				{
				case 2:
					mode = MODE.FriendInviteInit;
					break;
				case 1:
					GoCharMake();
					break;
				}
			};
		}
		else
		{
			GoCharMake();
		}
	}

	public void CheckInputData()
	{
		string arg = UIDynamicFontLabel.EscapeFontTag(userName);
		if (string.IsNullOrEmpty(userName) || UIBasicUtility.IsSpaseOnly(userName, 8))
		{
			dlgMan.OpenDialog("プレイヤー名を入力してください。", string.Empty, DialogManager.MB_FLAG.MB_ICONWARNING, new string[1] { "OK" });
			return;
		}
		if (8 < userName.Length)
		{
			dlgMan.OpenDialog($"名前は{8}文字以内で入力してください", "文字数が多過ぎます！", DialogManager.MB_FLAG.MB_ICONWARNING, new string[1] { "OK" });
			return;
		}
		dlgMan.OnButton(0);
		Dialog dialog = dlgMan.OpenDialog($"名前は\n<RED>{arg}<COLOR_INIT>\nでよろしいですか？", "プレイヤー名確認", DialogManager.MB_FLAG.MB_ICONWARNING, new string[2] { "いいえ", "はい" });
		dialog.ButtonHandler = delegate(int btn)
		{
			if (btn == 2)
			{
				SendUserName();
			}
			else
			{
				dlgMan.OnButton(0);
			}
		};
	}

	private void SendUserName()
	{
		mode = MODE.UserNameWait;
		ApiEntryCreateUser apiEntryCreateUser = new ApiEntryCreateUser();
		string text = (apiEntryCreateUser.name = userName);
		ApiEntryCreateUser apiEntryCreateUser2 = apiEntryCreateUser;
		apiEntryCreateUser2.marketCode = 1;
		apiEntryCreateUser2.IgnoreErrorCodes = new string[1] { "EnCrt001" };
		apiEntryCreateUser2.ErrorHandler = delegate(RequestBase r)
		{
			if (r.ResponseObj is ApiEntryCreateUser.Resp { StatusCode: var statusCode })
			{
				string text2 = statusCode.ToLower();
				string text3 = text2;
				if (text3 == "encrt001")
				{
					dlgMan.OpenDialog("再度入力して下さい。", "不正なプレイヤー名です", DialogManager.MB_FLAG.MB_ICONWARNING, new string[1] { "OK" });
				}
				else
				{
					dlgMan.OpenDialog($"再度入力して下さい。\n{statusCode}", "ERROR！", DialogManager.MB_FLAG.MB_ICONWARNING, new string[1] { "OK" });
				}
			}
		};
		__MerlinServer_CreateUser_0024callable88_0024675_53__ from = delegate(ApiEntryCreateUser r)
		{
			bool flag = false;
			if (r != null && r.IsOk)
			{
				flag = true;
				StartInviteConf();
			}
			if (!flag)
			{
				dlgMan.OpenDialog("プレイヤー生成できませんでした。", "ERROR！", DialogManager.MB_FLAG.MB_ICONWARNING, new string[1] { "OK" });
				mode = MODE.UserName;
			}
		};
		MerlinServer.Request(apiEntryCreateUser2, _0024adaptor_0024__MerlinServer_CreateUser_0024callable88_0024675_53___0024__MerlinServer_Request_0024callable86_0024160_56___0024165.Adapt(from));
	}

	public void ModeChange()
	{
		SceneChanger.ChangeTo(SceneID.Ui_TerminalChange);
	}

	public void PushBack(GameObject obj)
	{
		if (mode == MODE.FriendInvite)
		{
			if ((bool)webView && webView.gameObject.active)
			{
				webView.gameObject.SetActive(value: false);
			}
			GoCharMake();
		}
		else
		{
			SceneChanger.ChangeTo(SceneID.Ui_TitleLogo);
		}
	}

	public void OnSubmitUserName()
	{
	}

	public void PushInvite(GameObject obj)
	{
		ApiPlatformAccessInfo apiPlatformAccessInfo = new ApiPlatformAccessInfo();
		string text = (apiPlatformAccessInfo.uuid = CurrentInfo.UUID);
		MerlinServer.Request(apiPlatformAccessInfo, _0024adaptor_0024__MerlinServer_AccessInfo_0024callable89_0024680_40___0024__MerlinServer_Request_0024callable86_0024160_56___0024166.Adapt(delegate
		{
			ApiWebFriendInviteInput apiWebFriendInviteInput = new ApiWebFriendInviteInput();
			apiWebFriendInviteInput.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
				SceneChanger.ChangeTo(SceneID.Ui_TitleLogo);
			});
			MerlinServer.RequestWithoutPrecedingRequests(apiWebFriendInviteInput, _0024adaptor_0024__CreateUserIDMain_0024callable363_0024202_65___0024__MerlinServer_Request_0024callable86_0024160_56___0024185.Adapt(delegate(ApiWebFriendInviteInput req)
			{
				StartCoroutine(ShowInvite(req));
			}));
		}));
	}

	public IEnumerator ShowInvite(ApiWebFriendInviteInput req)
	{
		return new _0024ShowInvite_002421553(req, this).GetEnumerator();
	}

	internal IEnumerator _0024SceneStart_0024closure_00245032()
	{
		return new _0024_0024SceneStart_0024closure_00245032_002421559().GetEnumerator();
	}

	internal void _0024StartInviteConf_0024closure_00245036(int btn)
	{
		switch (btn)
		{
		case 2:
			mode = MODE.FriendInviteInit;
			break;
		case 1:
			GoCharMake();
			break;
		}
	}

	internal void _0024CheckInputData_0024closure_00245037(int btn)
	{
		if (btn == 2)
		{
			SendUserName();
		}
		else
		{
			dlgMan.OnButton(0);
		}
	}

	internal void _0024SendUserName_0024closure_00245039(RequestBase r)
	{
		if (r.ResponseObj is ApiEntryCreateUser.Resp { StatusCode: var statusCode })
		{
			string text = statusCode.ToLower();
			string text2 = text;
			if (text2 == "encrt001")
			{
				dlgMan.OpenDialog("再度入力して下さい。", "不正なプレイヤー名です", DialogManager.MB_FLAG.MB_ICONWARNING, new string[1] { "OK" });
			}
			else
			{
				dlgMan.OpenDialog($"再度入力して下さい。\n{statusCode}", "ERROR！", DialogManager.MB_FLAG.MB_ICONWARNING, new string[1] { "OK" });
			}
		}
	}

	internal void _0024SendUserName_0024callback_00245040(ApiEntryCreateUser r)
	{
		bool flag = false;
		if (r != null && r.IsOk)
		{
			flag = true;
			StartInviteConf();
		}
		if (!flag)
		{
			dlgMan.OpenDialog("プレイヤー生成できませんでした。", "ERROR！", DialogManager.MB_FLAG.MB_ICONWARNING, new string[1] { "OK" });
			mode = MODE.UserName;
		}
	}

	internal void _0024PushInvite_0024closure_00245042(ApiPlatformAccessInfo arg)
	{
		ApiWebFriendInviteInput apiWebFriendInviteInput = new ApiWebFriendInviteInput();
		apiWebFriendInviteInput.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
		{
			SceneChanger.ChangeTo(SceneID.Ui_TitleLogo);
		});
		MerlinServer.RequestWithoutPrecedingRequests(apiWebFriendInviteInput, _0024adaptor_0024__CreateUserIDMain_0024callable363_0024202_65___0024__MerlinServer_Request_0024callable86_0024160_56___0024185.Adapt(delegate(ApiWebFriendInviteInput req)
		{
			StartCoroutine(ShowInvite(req));
		}));
	}

	internal void _0024_0024PushInvite_0024closure_00245042_0024closure_00245043()
	{
		SceneChanger.ChangeTo(SceneID.Ui_TitleLogo);
	}

	internal void _0024_0024PushInvite_0024closure_00245042_0024closure_00245044(ApiWebFriendInviteInput req)
	{
		StartCoroutine(ShowInvite(req));
	}
}
