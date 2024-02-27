using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class DebugSubWebView : RuntimeDebugModeGuiMixin
{
	[Serializable]
	public class ActionBase
	{
		public ActionEnum _0024act_0024t_0024645;

		public string _0024act_0024t_0024646;

		public __ActionBase__0024act_0024t_0024647_0024callable36_002450_5__ _0024act_0024t_0024647;

		public __ActionBase__0024act_0024t_0024647_0024callable36_002450_5__ _0024act_0024t_0024648;

		public __ActionBase__0024act_0024t_0024647_0024callable36_002450_5__ _0024act_0024t_0024649;

		public __ActionBase__0024act_0024t_0024647_0024callable36_002450_5__ _0024act_0024t_0024650;

		public __ActionBase__0024act_0024t_0024647_0024callable36_002450_5__ _0024act_0024t_0024651;

		public __ActionBase__0024act_0024t_0024647_0024callable36_002450_5__ _0024act_0024t_0024652;

		public __ActionBase__0024act_0024t_0024653_0024callable37_002450_5__ _0024act_0024t_0024653;

		public IEnumerator _0024act_0024t_0024657;

		public float actionTime;

		public float preActionTime;

		public float realActionTimeInit;

		public float actionFrame;

		public string myName => _0024act_0024t_0024645.ToString();

		public float realActionTime => Time.time - realActionTimeInit;
	}

	[Serializable]
	public class ActionClassmainMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClasswebReqMode : ActionBase
	{
		public RequestBase r;

		public bool viewed;

		public string nextUrl;
	}

	[Serializable]
	public enum ActionEnum
	{
		webReqMode,
		mainMode,
		NUM,
		_noaction_
	}

	[Serializable]
	internal class _0024_0024createDatamainMode_0024closure_00243531_0024locals_002414318
	{
		internal RequestBase _0024r;
	}

	[Serializable]
	internal class _0024_0024createDatamainMode_0024closure_00243531_0024closure_00243532
	{
		internal int _0024i_002414741;

		internal _0024_0024createDatamainMode_0024closure_00243531_0024locals_002414318 _0024_0024locals_002414742;

		public _0024_0024createDatamainMode_0024closure_00243531_0024closure_00243532(int _0024i_002414741, _0024_0024createDatamainMode_0024closure_00243531_0024locals_002414318 _0024_0024locals_002414742)
		{
			this._0024i_002414741 = _0024i_002414741;
			this._0024_0024locals_002414742 = _0024_0024locals_002414742;
		}

		public void Invoke()
		{
			int num = 0;
			while (num < 4)
			{
				int num2 = num;
				num++;
				int num3 = checked(_0024i_002414741 * 4 + num2 + 1);
				if (RuntimeDebugModeGuiMixin.button(new StringBuilder("id:").Append((object)num3).ToString()))
				{
					_0024_0024locals_002414742._0024r = new ApiWebGachaDirecting(num3);
				}
			}
		}
	}

	protected WebView wview;

	private Dictionary<string, ActionBase> _0024act_0024t_0024654;

	private Dictionary<string, ActionEnum> _0024act_0024t_0024656;

	private ActionBase[] tmpActBuf;

	private int _0024act_0024t_0024655;

	public bool actionDebugFlag;

	public bool IsmainMode => currActionID("$default$") == ActionEnum.mainMode;

	public float actionTime => currActionTime("$default$");

	public ActionClassmainMode mainModeData => currAction("$default$") as ActionClassmainMode;

	public bool IswebReqMode => currActionID("$default$") == ActionEnum.webReqMode;

	public ActionClasswebReqMode webReqModeData => currAction("$default$") as ActionClasswebReqMode;

	public DebugSubWebView()
	{
		_0024act_0024t_0024654 = new Dictionary<string, ActionBase>();
		_0024act_0024t_0024656 = new Dictionary<string, ActionEnum>();
		tmpActBuf = new ActionBase[32];
	}

	public override bool AutoReturn()
	{
		return false;
	}

	public override void Exit()
	{
		closeWebView();
	}

	private void closeWebView()
	{
		if (wview != null)
		{
			UnityEngine.Object.Destroy(wview.gameObject);
		}
		wview = null;
	}

	private void openWebView()
	{
		if (!(wview != null))
		{
			GameObject gameObject = (GameObject)Resources.Load("Prefab/GUI/WebView", typeof(GameObject));
			if (!(gameObject != null))
			{
				throw new AssertionFailedException("prefab != null");
			}
			GameObject gameObject2 = GameAssetModule.Instantiate(gameObject) as GameObject;
			if (!(gameObject2 != null))
			{
				throw new AssertionFailedException("obj != null");
			}
			wview = gameObject2.GetComponent<WebView>();
			if (!(wview != null))
			{
				throw new AssertionFailedException("wview != null");
			}
			wview.fullScreen = true;
			wview.enableLinkJump = true;
			wview.CommandCloseIsEndWebView = true;
		}
	}

	public override void Init()
	{
		mainMode();
	}

	public override void Update()
	{
		actUpdate();
	}

	public override void LateUpdate()
	{
		actLateUpdate();
	}

	public override void FixedUpdate()
	{
		actFixedUpdate();
	}

	public override void OnGUI()
	{
		actOnGUI();
	}

	public void setActionDebugMode(bool b)
	{
		actionDebugFlag = b;
	}

	public ActionBase currAction()
	{
		return currAction("$default$");
	}

	public ActionEnum currActionID()
	{
		return currActionID("$default$");
	}

	public ActionBase currAction(string grp)
	{
		return (string.IsNullOrEmpty(grp) || !_0024act_0024t_0024654.ContainsKey(grp)) ? null : _0024act_0024t_0024654[grp];
	}

	public ActionEnum currActionID(string grp)
	{
		return (!_0024act_0024t_0024656.ContainsKey(grp)) ? ActionEnum._noaction_ : _0024act_0024t_0024656[grp];
	}

	public float currActionTime(string grp)
	{
		return (!_0024act_0024t_0024654.ContainsKey(grp)) ? 0f : _0024act_0024t_0024654[grp].actionTime;
	}

	public float currPreActionTime(string grp)
	{
		return (!_0024act_0024t_0024654.ContainsKey(grp)) ? 0f : _0024act_0024t_0024654[grp].preActionTime;
	}

	public float currActionFrame(string grp)
	{
		return (!_0024act_0024t_0024654.ContainsKey(grp)) ? 0f : _0024act_0024t_0024654[grp].actionFrame;
	}

	public bool isExecuting(ActionEnum aid)
	{
		bool flag;
		foreach (ActionEnum value in _0024act_0024t_0024656.Values)
		{
			if (value != aid)
			{
				continue;
			}
			flag = true;
			goto IL_004c;
		}
		int result = 0;
		goto IL_004d;
		IL_004c:
		result = (flag ? 1 : 0);
		goto IL_004d;
		IL_004d:
		return (byte)result != 0;
	}

	public bool isExecuting(ActionBase act)
	{
		return act != null && !string.IsNullOrEmpty(act._0024act_0024t_0024646) && _0024act_0024t_0024654.ContainsKey(act._0024act_0024t_0024646) && RuntimeServices.EqualityOperator(act, _0024act_0024t_0024654[act._0024act_0024t_0024646]);
	}

	public static bool IsValidActionID(ActionEnum aid)
	{
		bool num = ActionEnum.webReqMode <= aid;
		if (num)
		{
			num = aid < ActionEnum.NUM;
		}
		return num;
	}

	protected void setCurrAction(ActionBase act)
	{
		if (act != null)
		{
			if (string.IsNullOrEmpty(act._0024act_0024t_0024646))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(act.$act$t$646)");
			}
			_0024act_0024t_0024654[act._0024act_0024t_0024646] = act;
			_0024act_0024t_0024656[act._0024act_0024t_0024646] = act._0024act_0024t_0024645;
			act.realActionTimeInit = Time.time;
		}
	}

	protected void changeAction(ActionBase act)
	{
		if (checked(++_0024act_0024t_0024655) > 100)
		{
			throw new Exception("update無しに" + 100 + "回以上action遷移しました");
		}
		ActionBase actionBase = currAction(act._0024act_0024t_0024646);
		if (act == null || RuntimeServices.EqualityOperator(actionBase, act))
		{
			return;
		}
		if (actionDebugFlag)
		{
			if (actionBase == null)
			{
				Builtins.print(new StringBuilder("act_method: change <no action> -> ").Append(act.myName).Append(" (group: ").Append(act._0024act_0024t_0024646)
					.Append(")")
					.ToString());
			}
			else
			{
				Builtins.print(new StringBuilder("act_method: change ").Append(actionBase.myName).Append(" -> ").Append(act.myName)
					.Append(" (group: ")
					.Append(act._0024act_0024t_0024646)
					.Append(")")
					.ToString());
			}
		}
		if (actionBase != null && actionBase._0024act_0024t_0024648 != null)
		{
			actionBase._0024act_0024t_0024648(actionBase);
		}
		if (actionBase == null || isExecuting(actionBase))
		{
			setCurrAction(act);
			if (act._0024act_0024t_0024647 != null)
			{
				act._0024act_0024t_0024647(act);
			}
			if (isExecuting(act) && act._0024act_0024t_0024653 != null)
			{
				act._0024act_0024t_0024657 = act._0024act_0024t_0024653(act);
			}
		}
	}

	public void changeAction(ActionEnum actID)
	{
		ActionBase actionBase = createActionData(actID);
		if (actionBase != null)
		{
			changeAction(actionBase);
		}
	}

	private int copyActsToTmpActBuf()
	{
		int result = 0;
		foreach (ActionBase value in _0024act_0024t_0024654.Values)
		{
			ActionBase[] array = tmpActBuf;
			array[RuntimeServices.NormalizeArrayIndex(array, checked(result++))] = value;
		}
		return result;
	}

	public void actUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_0024655 = 0;
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int index = num2;
			num2++;
			ActionBase[] array = tmpActBuf;
			ActionBase actionBase = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if (actionBase._0024act_0024t_0024649 != null)
			{
				actionBase._0024act_0024t_0024649(actionBase);
			}
			if (isExecuting(actionBase) && actionBase._0024act_0024t_0024657 != null && !actionBase._0024act_0024t_0024657.MoveNext())
			{
				actionBase._0024act_0024t_0024657 = null;
			}
		}
		foreach (ActionBase value in _0024act_0024t_0024654.Values)
		{
			value.preActionTime = value.actionTime;
			if (value != null)
			{
				value.actionTime += Time.deltaTime;
			}
			value.actionFrame += 1f;
		}
	}

	public void actFixedUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_0024655 = 0;
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int index = num2;
			num2++;
			ActionBase[] array = tmpActBuf;
			ActionBase actionBase = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if (actionBase._0024act_0024t_0024650 != null)
			{
				actionBase._0024act_0024t_0024650(actionBase);
			}
		}
	}

	public void actOnGUI()
	{
		_0024act_0024t_0024655 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024654.Keys);
		int i = 0;
		string[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				ActionBase actionBase = _0024act_0024t_0024654[array2[i]];
				if (actionBase._0024act_0024t_0024651 != null)
				{
					actionBase._0024act_0024t_0024651(actionBase);
				}
			}
			if (!actionDebugFlag)
			{
				return;
			}
			int num = 100;
			foreach (ActionBase value in _0024act_0024t_0024654.Values)
			{
				GUI.Label(new Rect(200f, num, 400f, 20f), "act:" + value._0024act_0024t_0024646 + " - " + value._0024act_0024t_0024645 + " tm:" + value.actionTime + " fr:" + value.actionFrame);
				num += 20;
			}
		}
	}

	public void actLateUpdate()
	{
		_0024act_0024t_0024655 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024654.Keys);
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			ActionBase actionBase = _0024act_0024t_0024654[array2[i]];
			if (actionBase._0024act_0024t_0024652 != null)
			{
				actionBase._0024act_0024t_0024652(actionBase);
			}
		}
	}

	protected ActionBase createActionData(ActionEnum actID)
	{
		if (!IsValidActionID(actID))
		{
			throw new Exception("invalid " + "DebugSubWebView" + " enum: " + actID);
		}
		return actID switch
		{
			ActionEnum.mainMode => createDatamainMode(), 
			ActionEnum.webReqMode => createDatawebReqMode(), 
			_ => null, 
		};
	}

	public ActionClassmainMode mainMode()
	{
		ActionClassmainMode actionClassmainMode = createmainMode();
		changeAction(actionClassmainMode);
		return actionClassmainMode;
	}

	public ActionClassmainMode createDatamainMode()
	{
		ActionClassmainMode actionClassmainMode = new ActionClassmainMode();
		actionClassmainMode._0024act_0024t_0024645 = ActionEnum.mainMode;
		actionClassmainMode._0024act_0024t_0024646 = "$default$";
		actionClassmainMode._0024act_0024t_0024651 = _0024adaptor_0024__DebugSubWebView_0024callable307_002450_5___0024__ActionBase__0024act_0024t_0024647_0024callable36_002450_5___0024111.Adapt(delegate
		{
			_0024_0024createDatamainMode_0024closure_00243531_0024locals_002414318 _0024_0024createDatamainMode_0024closure_00243531_0024locals_0024 = new _0024_0024createDatamainMode_0024closure_00243531_0024locals_002414318();
			_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = null;
			if (RuntimeDebugModeGuiMixin.button("お知らせトップ画面"))
			{
				_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiInfo();
			}
			if (RuntimeDebugModeGuiMixin.button("ヘルプ一覧画面"))
			{
				_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiHelp();
			}
			if (RuntimeDebugModeGuiMixin.button("問い合わせID表示画面"))
			{
				_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiWebContact();
			}
			if (RuntimeDebugModeGuiMixin.button("スタッフクレジット表示画面"))
			{
				_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiWebStaffCredit();
			}
			if (RuntimeDebugModeGuiMixin.button("シリアルコード一覧画面"))
			{
				_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiWebSerialCode();
			}
			if (RuntimeDebugModeGuiMixin.button("招待コード画面"))
			{
				_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiFriendInvite();
			}
			if (RuntimeDebugModeGuiMixin.button("招待入力画面"))
			{
				_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiWebFriendInviteInput();
			}
			if (RuntimeDebugModeGuiMixin.button("特定商取引法についての説明画面"))
			{
				_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiWebSpecificTrade();
			}
			if (RuntimeDebugModeGuiMixin.button("チャレンジバナー"))
			{
				_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiWebChallengeBanner();
			}
			if (RuntimeDebugModeGuiMixin.button("チャレンジクエスト詳細画面"))
			{
				_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiWebChallengeDetail();
			}
			if (RuntimeDebugModeGuiMixin.button("ランキング一覧画面"))
			{
				_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiWebRanking();
			}
			if (RuntimeDebugModeGuiMixin.button("くじ引き"))
			{
				_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiGacha();
			}
			if (RuntimeDebugModeGuiMixin.button("くじ引き説明画面"))
			{
				_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiGachaDetails();
			}
			if (RuntimeDebugModeGuiMixin.button("町バナー"))
			{
				_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiInfoWindow();
			}
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.label("くじ引き新規演出ページ");
			int num = 0;
			while (num < 2)
			{
				int _0024i_0024 = num;
				num++;
				RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDatamainMode_0024closure_00243531_0024closure_00243532(_0024i_0024, _0024_0024createDatamainMode_0024closure_00243531_0024locals_0024).Invoke));
			}
			RuntimeDebugModeGuiMixin.space(20);
			if (RuntimeDebugModeGuiMixin.button("アプリサイト"))
			{
				MerlinServer.OpenApplicationSite();
			}
			if (RuntimeDebugModeGuiMixin.button("端末追加"))
			{
				_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiEntryJoinDevice();
			}
			if (RuntimeDebugModeGuiMixin.button("本登録メール送信"))
			{
				_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiEntryAuthData();
			}
			if (_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r != null)
			{
				webReqMode(_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r);
			}
		});
		actionClassmainMode._0024act_0024t_0024649 = _0024adaptor_0024__DebugSubWebView_0024callable307_002450_5___0024__ActionBase__0024act_0024t_0024647_0024callable36_002450_5___0024111.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				KillMe();
			}
		});
		return actionClassmainMode;
	}

	public ActionClassmainMode createmainMode()
	{
		return createDatamainMode();
	}

	public bool IsAtTime(float t)
	{
		int num2;
		if (_0024act_0024t_0024654.ContainsKey("$default$"))
		{
			ActionBase actionBase = _0024act_0024t_0024654["$default$"];
			float realActionTime = actionBase.realActionTime;
			float num = actionBase.realActionTime - t;
			num2 = ((num > 0f) ? 1 : 0);
			if (num2 != 0)
			{
				num2 = ((!(num > Time.deltaTime)) ? 1 : 0);
			}
		}
		else
		{
			num2 = 0;
		}
		return (byte)num2 != 0;
	}

	public ActionClasswebReqMode webReqMode(RequestBase r)
	{
		ActionClasswebReqMode actionClasswebReqMode = createwebReqMode(r);
		changeAction(actionClasswebReqMode);
		return actionClasswebReqMode;
	}

	public ActionClasswebReqMode createDatawebReqMode()
	{
		ActionClasswebReqMode actionClasswebReqMode = new ActionClasswebReqMode();
		actionClasswebReqMode._0024act_0024t_0024645 = ActionEnum.webReqMode;
		actionClasswebReqMode._0024act_0024t_0024646 = "$default$";
		actionClasswebReqMode._0024act_0024t_0024647 = _0024adaptor_0024__DebugSubWebView_0024callable308_0024117_5___0024__ActionBase__0024act_0024t_0024647_0024callable36_002450_5___0024112.Adapt(delegate(ActionClasswebReqMode _0024act_0024t_0024660)
		{
			_0024act_0024t_0024660.viewed = false;
			MerlinServer.Request(_0024act_0024t_0024660.r);
		});
		actionClasswebReqMode._0024act_0024t_0024648 = _0024adaptor_0024__DebugSubWebView_0024callable308_0024117_5___0024__ActionBase__0024act_0024t_0024647_0024callable36_002450_5___0024112.Adapt(delegate
		{
			closeWebView();
		});
		actionClasswebReqMode._0024act_0024t_0024651 = _0024adaptor_0024__DebugSubWebView_0024callable308_0024117_5___0024__ActionBase__0024act_0024t_0024647_0024callable36_002450_5___0024112.Adapt(delegate(ActionClasswebReqMode _0024act_0024t_0024660)
		{
			RuntimeDebugModeGuiMixin.label(new StringBuilder("通信中 - IsEnd:").Append(_0024act_0024t_0024660.r.IsEnd).Append(" IsOk:").Append(_0024act_0024t_0024660.r.IsOk)
				.Append(" Status:")
				.Append((object)_0024act_0024t_0024660.r.Status)
				.ToString());
			if (RuntimeDebugModeGuiMixin.button("戻る"))
			{
				mainMode();
			}
			else if (_0024act_0024t_0024660.r.IsEnd)
			{
				if (_0024act_0024t_0024660.r.IsOk)
				{
					RuntimeDebugModeGuiMixin.label("OK!");
					if (wview == null)
					{
						openWebView();
					}
					if (wview != null && !_0024act_0024t_0024660.viewed)
					{
						string result = _0024act_0024t_0024660.r.Result;
						wview.Open(string.Empty);
						wview.OpenHtml(result, ServerURL.GameServerUrl("/"));
						_0024act_0024t_0024660.viewed = true;
					}
				}
				else
				{
					RuntimeDebugModeGuiMixin.label("通信エラー");
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(_0024act_0024t_0024660.r.Error).ToString());
					RuntimeDebugModeGuiMixin.textArea(_0024act_0024t_0024660.r.Result);
				}
			}
		});
		actionClasswebReqMode._0024act_0024t_0024649 = _0024adaptor_0024__DebugSubWebView_0024callable308_0024117_5___0024__ActionBase__0024act_0024t_0024647_0024callable36_002450_5___0024112.Adapt(delegate(ActionClasswebReqMode _0024act_0024t_0024660)
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
			string nextUrl = WebViewBase.Instance.nextUrl;
			if (nextUrl != _0024act_0024t_0024660.nextUrl)
			{
				_0024act_0024t_0024660.nextUrl = nextUrl;
			}
		});
		return actionClasswebReqMode;
	}

	public ActionClasswebReqMode createwebReqMode(RequestBase r)
	{
		ActionClasswebReqMode actionClasswebReqMode = createDatawebReqMode();
		actionClasswebReqMode.r = r;
		return actionClasswebReqMode;
	}

	internal void _0024createDatamainMode_0024closure_00243531(ActionClassmainMode _0024act_0024t_0024644)
	{
		_0024_0024createDatamainMode_0024closure_00243531_0024locals_002414318 _0024_0024createDatamainMode_0024closure_00243531_0024locals_0024 = new _0024_0024createDatamainMode_0024closure_00243531_0024locals_002414318();
		_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = null;
		if (RuntimeDebugModeGuiMixin.button("お知らせトップ画面"))
		{
			_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiInfo();
		}
		if (RuntimeDebugModeGuiMixin.button("ヘルプ一覧画面"))
		{
			_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiHelp();
		}
		if (RuntimeDebugModeGuiMixin.button("問い合わせID表示画面"))
		{
			_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiWebContact();
		}
		if (RuntimeDebugModeGuiMixin.button("スタッフクレジット表示画面"))
		{
			_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiWebStaffCredit();
		}
		if (RuntimeDebugModeGuiMixin.button("シリアルコード一覧画面"))
		{
			_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiWebSerialCode();
		}
		if (RuntimeDebugModeGuiMixin.button("招待コード画面"))
		{
			_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiFriendInvite();
		}
		if (RuntimeDebugModeGuiMixin.button("招待入力画面"))
		{
			_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiWebFriendInviteInput();
		}
		if (RuntimeDebugModeGuiMixin.button("特定商取引法についての説明画面"))
		{
			_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiWebSpecificTrade();
		}
		if (RuntimeDebugModeGuiMixin.button("チャレンジバナー"))
		{
			_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiWebChallengeBanner();
		}
		if (RuntimeDebugModeGuiMixin.button("チャレンジクエスト詳細画面"))
		{
			_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiWebChallengeDetail();
		}
		if (RuntimeDebugModeGuiMixin.button("ランキング一覧画面"))
		{
			_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiWebRanking();
		}
		if (RuntimeDebugModeGuiMixin.button("くじ引き"))
		{
			_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiGacha();
		}
		if (RuntimeDebugModeGuiMixin.button("くじ引き説明画面"))
		{
			_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiGachaDetails();
		}
		if (RuntimeDebugModeGuiMixin.button("町バナー"))
		{
			_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiInfoWindow();
		}
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.label("くじ引き新規演出ページ");
		int num = 0;
		while (num < 2)
		{
			int _0024i_0024 = num;
			num++;
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDatamainMode_0024closure_00243531_0024closure_00243532(_0024i_0024, _0024_0024createDatamainMode_0024closure_00243531_0024locals_0024).Invoke));
		}
		RuntimeDebugModeGuiMixin.space(20);
		if (RuntimeDebugModeGuiMixin.button("アプリサイト"))
		{
			MerlinServer.OpenApplicationSite();
		}
		if (RuntimeDebugModeGuiMixin.button("端末追加"))
		{
			_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiEntryJoinDevice();
		}
		if (RuntimeDebugModeGuiMixin.button("本登録メール送信"))
		{
			_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r = new ApiEntryAuthData();
		}
		if (_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r != null)
		{
			webReqMode(_0024_0024createDatamainMode_0024closure_00243531_0024locals_0024._0024r);
		}
	}

	internal void _0024createDatamainMode_0024closure_00243533(ActionClassmainMode _0024act_0024t_0024644)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			KillMe();
		}
	}

	internal void _0024createDatawebReqMode_0024closure_00243534(ActionClasswebReqMode _0024act_0024t_0024660)
	{
		_0024act_0024t_0024660.viewed = false;
		MerlinServer.Request(_0024act_0024t_0024660.r);
	}

	internal void _0024createDatawebReqMode_0024closure_00243535(ActionClasswebReqMode _0024act_0024t_0024660)
	{
		closeWebView();
	}

	internal void _0024createDatawebReqMode_0024closure_00243536(ActionClasswebReqMode _0024act_0024t_0024660)
	{
		RuntimeDebugModeGuiMixin.label(new StringBuilder("通信中 - IsEnd:").Append(_0024act_0024t_0024660.r.IsEnd).Append(" IsOk:").Append(_0024act_0024t_0024660.r.IsOk)
			.Append(" Status:")
			.Append((object)_0024act_0024t_0024660.r.Status)
			.ToString());
		if (RuntimeDebugModeGuiMixin.button("戻る"))
		{
			mainMode();
		}
		else
		{
			if (!_0024act_0024t_0024660.r.IsEnd)
			{
				return;
			}
			if (_0024act_0024t_0024660.r.IsOk)
			{
				RuntimeDebugModeGuiMixin.label("OK!");
				if (wview == null)
				{
					openWebView();
				}
				if (wview != null && !_0024act_0024t_0024660.viewed)
				{
					string result = _0024act_0024t_0024660.r.Result;
					wview.Open(string.Empty);
					wview.OpenHtml(result, ServerURL.GameServerUrl("/"));
					_0024act_0024t_0024660.viewed = true;
				}
			}
			else
			{
				RuntimeDebugModeGuiMixin.label("通信エラー");
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(_0024act_0024t_0024660.r.Error).ToString());
				RuntimeDebugModeGuiMixin.textArea(_0024act_0024t_0024660.r.Result);
			}
		}
	}

	internal void _0024createDatawebReqMode_0024closure_00243537(ActionClasswebReqMode _0024act_0024t_0024660)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
		string nextUrl = WebViewBase.Instance.nextUrl;
		if (nextUrl != _0024act_0024t_0024660.nextUrl)
		{
			_0024act_0024t_0024660.nextUrl = nextUrl;
		}
	}
}
