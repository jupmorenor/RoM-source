using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Boo.Lang;
using CompilerGenerated;
using GameAsset;
using MerlinAPI;
using ObjUtil;
using UnityEngine;

[Serializable]
public class WebBannerTown : MonoBehaviour
{
	[Serializable]
	internal class _0024OpenFullWebView_0024locals_002414494
	{
		internal bool _0024closeFlag;

		internal UIAutoTweener[] _0024tweens;
	}

	[Serializable]
	internal class _0024InitTownWebBannerHtml_0024locals_002414495
	{
		internal RequestBase _0024req;

		internal __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ _0024callback;
	}

	[Serializable]
	internal class _0024OpenFullWebView_0024closure_00243085
	{
		internal _0024OpenFullWebView_0024locals_002414494 _0024_0024locals_002415085;

		public _0024OpenFullWebView_0024closure_00243085(_0024OpenFullWebView_0024locals_002414494 _0024_0024locals_002415085)
		{
			this._0024_0024locals_002415085 = _0024_0024locals_002415085;
		}

		public void Invoke()
		{
			_0024_0024locals_002415085._0024closeFlag = true;
			int i = 0;
			UIAutoTweener[] _0024tweens = _0024_0024locals_002415085._0024tweens;
			for (int length = _0024tweens.Length; i < length; i = checked(i + 1))
			{
				_0024tweens[i].PlayAnimation(forward: false);
			}
		}
	}

	[Serializable]
	internal class _0024InitTownWebBannerHtml_0024closure_00243086
	{
		internal _0024InitTownWebBannerHtml_0024locals_002414495 _0024_0024locals_002415086;

		public _0024InitTownWebBannerHtml_0024closure_00243086(_0024InitTownWebBannerHtml_0024locals_002414495 _0024_0024locals_002415086)
		{
			this._0024_0024locals_002415086 = _0024_0024locals_002415086;
		}

		public void Invoke()
		{
			bool arg = false;
			if (_0024_0024locals_002415086._0024req.IsOk)
			{
				arg = true;
				htmlBanner = _0024_0024locals_002415086._0024req.Result;
			}
			if (_0024_0024locals_002415086._0024callback != null)
			{
				_0024_0024locals_002415086._0024callback(arg);
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024OpenFullWebView_002421513 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024webPrefab_002421514;

			internal UIAutoTweener _0024tween_002421515;

			internal UIButtonMessage _0024closeButton_002421516;

			internal float _0024_0024wait_sec_0024temp_00242574_002421517;

			internal int _0024_002411227_002421518;

			internal UIAutoTweener[] _0024_002411228_002421519;

			internal int _0024_002411229_002421520;

			internal _0024OpenFullWebView_0024locals_002414494 _0024_0024locals_002421521;

			internal string _0024url_002421522;

			internal WebBannerTown _0024self__002421523;

			public _0024(string url, WebBannerTown self_)
			{
				_0024url_002421522 = url;
				_0024self__002421523 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024_0024locals_002421521 = new _0024OpenFullWebView_0024locals_002414494();
						_0024self__002421523.fullWebViewFlag = true;
						if ((bool)_0024self__002421523.curWebView)
						{
							goto case 2;
						}
						goto IL_0082;
					case 2:
						if (_0024self__002421523.curWebView.gameObject.active)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						goto IL_0082;
					case 3:
						if (IsEnableWebBannerTown())
						{
							_0024_0024locals_002421521._0024closeFlag = false;
							if ((bool)_0024self__002421523.fullWebViewObj)
							{
								goto IL_0181;
							}
							_0024webPrefab_002421514 = (GameObject)GameAssetModule.LoadPrefab("Prefab/GUI/WebFullScreen");
							if ((bool)_0024webPrefab_002421514)
							{
								_0024self__002421523.fullWebViewObj = (GameObject)UnityEngine.Object.Instantiate(_0024webPrefab_002421514);
								if ((bool)_0024self__002421523.fullWebViewObj)
								{
									_0024self__002421523.fullWebViewObj.transform.parent = _0024self__002421523.transform.parent;
									_0024self__002421523.fullWebViewObj.transform.localPosition = _0024webPrefab_002421514.transform.localPosition;
									_0024self__002421523.fullWebViewObj.transform.localScale = Vector3.one;
									goto IL_0181;
								}
							}
						}
						goto case 1;
					case 4:
						if (!string.IsNullOrEmpty(_0024url_002421522))
						{
							_0024self__002421523.fullWebView.Open(_0024url_002421522);
						}
						goto case 5;
					case 5:
						if (!_0024_0024locals_002421521._0024closeFlag)
						{
							result = (YieldDefault(5) ? 1 : 0);
							break;
						}
						_0024self__002421523.fullWebView.gameObject.SetActive(value: false);
						result = (YieldDefault(6) ? 1 : 0);
						break;
					case 6:
						UnityEngine.Object.DestroyObject(_0024self__002421523.fullWebViewObj);
						_0024self__002421523.fullWebViewObj = null;
						_0024self__002421523.fullWebView = null;
						_0024_0024wait_sec_0024temp_00242574_002421517 = 1f;
						goto case 7;
					case 7:
						if (_0024_0024wait_sec_0024temp_00242574_002421517 > 0f)
						{
							_0024_0024wait_sec_0024temp_00242574_002421517 -= Time.deltaTime;
							result = (YieldDefault(7) ? 1 : 0);
							break;
						}
						_0024self__002421523.curWebView.nextUrl = string.Empty;
						_0024self__002421523.lastCommand = string.Empty;
						_0024self__002421523.fullWebViewFlag = false;
						YieldDefault(1);
						goto case 1;
					case 1:
						{
							result = 0;
							break;
						}
						IL_0082:
						result = (YieldDefault(3) ? 1 : 0);
						break;
						IL_0181:
						if ((bool)_0024self__002421523.fullWebViewObj)
						{
							_0024self__002421523.fullWebViewObj.SetActive(value: false);
							_0024_0024locals_002421521._0024tweens = _0024self__002421523.fullWebViewObj.GetComponentsInChildren<UIAutoTweener>(includeInactive: true);
							_0024_002411227_002421518 = 0;
							_0024_002411228_002421519 = _0024_0024locals_002421521._0024tweens;
							for (_0024_002411229_002421520 = _0024_002411228_002421519.Length; _0024_002411227_002421518 < _0024_002411229_002421520; _0024_002411227_002421518++)
							{
								_0024_002411228_002421519[_0024_002411227_002421518].Reset(null);
							}
							_0024closeButton_002421516 = ExtensionsModule.FindChild(_0024self__002421523.fullWebViewObj, "Button").GetComponentsInChildren<UIButtonMessage>(includeInactive: true).FirstOrDefault();
							_0024closeButton_002421516.eventHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024EventHandler_0024156.Adapt(new _0024OpenFullWebView_0024closure_00243085(_0024_0024locals_002421521).Invoke);
							if (!_0024self__002421523.fullWebView)
							{
								_0024self__002421523.fullWebView = _0024self__002421523.fullWebViewObj.GetComponentsInChildren<WebView>(includeInactive: true).FirstOrDefault();
							}
							if ((bool)_0024self__002421523.fullWebView)
							{
								_0024self__002421523.fullWebView.enableLinkJump = true;
								_0024self__002421523.fullWebView.Clear();
								if ((bool)_0024self__002421523.fullWebViewObj)
								{
									_0024self__002421523.fullWebViewObj.SetActive(value: true);
								}
								result = (YieldDefault(4) ? 1 : 0);
								break;
							}
						}
						goto case 1;
					}
				}
				return (byte)result != 0;
			}
		}

		internal string _0024url_002421524;

		internal WebBannerTown _0024self__002421525;

		public _0024OpenFullWebView_002421513(string url, WebBannerTown self_)
		{
			_0024url_002421524 = url;
			_0024self__002421525 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024url_002421524, _0024self__002421525);
		}
	}

	protected WebView curWebView;

	protected WebView fullWebView;

	protected GameObject fullWebViewObj;

	protected string lastCommand;

	protected bool fullWebViewFlag;

	protected int delay;

	[NonSerialized]
	protected static string htmlBanner;

	[NonSerialized]
	public static bool debugWebBanner;

	public WebBannerTown()
	{
		delay = 5;
	}

	public void Start()
	{
		curWebView = gameObject.GetComponentsInChildren<WebView>(includeInactive: true).FirstOrDefault();
		if ((bool)curWebView)
		{
			curWebView.CommandLinkHandler = WebBannerTownCommandLinkHandler;
		}
	}

	public bool WebBannerTownCommandLinkHandler(string command)
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
			curWebView.gameObject.SetActive(value: false);
			string text = "browser:";
			if (command.StartsWith(text))
			{
				command = command.Substring(text.Length);
				Application.OpenURL(command);
				result = 1;
			}
			else
			{
				string value = "http:";
				string value2 = "https:";
				if (command.StartsWith(value) || command.StartsWith(value2))
				{
					IEnumerator enumerator = OpenFullWebView(command);
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
		}
		return (byte)result != 0;
	}

	public IEnumerator OpenFullWebView(string url)
	{
		return new _0024OpenFullWebView_002421513(url, this).GetEnumerator();
	}

	public void Update()
	{
		checked
		{
			if ((bool)fullWebViewObj && fullWebViewObj.active)
			{
				if ((bool)curWebView)
				{
					curWebView.gameObject.SetActive(value: false);
				}
			}
			else if (!fullWebViewFlag)
			{
				if (!IsEnableWebBannerTown())
				{
					delay = 5;
				}
				if (delay > 0)
				{
					delay--;
				}
				if ((bool)curWebView)
				{
					curWebView.gameObject.SetActive(delay <= 0);
				}
			}
		}
	}

	public static void InitTownWebBannerHtml(__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ callback)
	{
		_0024InitTownWebBannerHtml_0024locals_002414495 _0024InitTownWebBannerHtml_0024locals_0024 = new _0024InitTownWebBannerHtml_0024locals_002414495();
		_0024InitTownWebBannerHtml_0024locals_0024._0024callback = callback;
		_0024InitTownWebBannerHtml_0024locals_0024._0024req = null;
		if (debugWebBanner)
		{
			_0024InitTownWebBannerHtml_0024locals_0024._0024req = new ApiInfo();
		}
		else
		{
			_0024InitTownWebBannerHtml_0024locals_0024._0024req = new ApiInfoWindow();
		}
		_0024InitTownWebBannerHtml_0024locals_0024._0024req.realtimeRetyrTimerAndNoRetryDialog();
		MerlinServer.StealthRequest(_0024InitTownWebBannerHtml_0024locals_0024._0024req, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024InitTownWebBannerHtml_0024closure_00243086(_0024InitTownWebBannerHtml_0024locals_0024).Invoke));
	}

	public static void InitTownWebBanner()
	{
		__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ _LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ = delegate(bool res)
		{
			if (res)
			{
				GameUIRoot gameUIRoot = (GameUIRoot)UnityEngine.Object.FindObjectOfType(typeof(GameUIRoot));
				if ((bool)gameUIRoot)
				{
					Transform transform = ObjUtilModule.Find1stDescendant(gameUIRoot.transform, "1 HUD");
					if ((bool)transform)
					{
						GameObject gameObject = GameAssetModule.LoadPrefab("Prefab/GUI/WebBannerTown") as GameObject;
						GameObject gameObject2 = default(GameObject);
						if ((bool)gameObject)
						{
							gameObject2 = (GameObject)UnityEngine.Object.Instantiate(gameObject, Vector3.zero, Quaternion.identity);
						}
						if ((bool)gameObject2)
						{
							gameObject2.SetActive(value: false);
							WebView webView = gameObject2.GetComponentsInChildren<WebView>(includeInactive: true).FirstOrDefault();
							if ((bool)webView)
							{
								gameObject2.transform.parent = transform;
								gameObject2.transform.localPosition = Vector3.zero;
								gameObject2.transform.localScale = Vector3.one;
								webView.Clear();
								webView.OpenHtml(htmlBanner, ServerURL.GameServerUrl("/"));
								gameObject2.SetActive(value: true);
							}
						}
					}
				}
			}
		};
		if (string.IsNullOrEmpty(htmlBanner))
		{
			InitTownWebBannerHtml(_LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__);
		}
		else
		{
			_LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__(arg0: true);
		}
	}

	public static void Reset()
	{
		htmlBanner = null;
	}

	public static bool IsEnableWebBannerTown()
	{
		return BattleHUDShortcut.IsShow && SceneChanger.isCompletelyReady && !MerlinServer.Instance.IsBusy && FaderCore.Instance.isCompleted && !CutSceneManager.IsBusy && MerlinTaskQueue.Instance.IsEmpty && !BattleHUDShortcut.IsOpen && DialogManager.DialogCount <= 0 && !EventWindow.isWindow && !StartButton.Paused && !RuntimeDebugMode.Instance.IsInDebugMode;
	}

	internal static void _0024InitTownWebBanner_0024closure_00243087(bool res)
	{
		if (!res)
		{
			return;
		}
		GameUIRoot gameUIRoot = (GameUIRoot)UnityEngine.Object.FindObjectOfType(typeof(GameUIRoot));
		if (!gameUIRoot)
		{
			return;
		}
		Transform transform = ObjUtilModule.Find1stDescendant(gameUIRoot.transform, "1 HUD");
		if (!transform)
		{
			return;
		}
		GameObject gameObject = GameAssetModule.LoadPrefab("Prefab/GUI/WebBannerTown") as GameObject;
		GameObject gameObject2 = default(GameObject);
		if ((bool)gameObject)
		{
			gameObject2 = (GameObject)UnityEngine.Object.Instantiate(gameObject, Vector3.zero, Quaternion.identity);
		}
		if ((bool)gameObject2)
		{
			gameObject2.SetActive(value: false);
			WebView webView = gameObject2.GetComponentsInChildren<WebView>(includeInactive: true).FirstOrDefault();
			if ((bool)webView)
			{
				gameObject2.transform.parent = transform;
				gameObject2.transform.localPosition = Vector3.zero;
				gameObject2.transform.localScale = Vector3.one;
				webView.Clear();
				webView.OpenHtml(htmlBanner, ServerURL.GameServerUrl("/"));
				gameObject2.SetActive(value: true);
			}
		}
	}
}
