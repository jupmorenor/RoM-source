using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using GameAsset;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class NewInformation : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024WaitClose_002421398 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal bool _0024playing_002421399;

			internal UIAutoTweener _0024tween_002421400;

			internal int _0024_002410843_002421401;

			internal UIAutoTweener[] _0024_002410844_002421402;

			internal int _0024_002410845_002421403;

			internal NewInformation _0024self__002421404;

			public _0024(NewInformation self_)
			{
				_0024self__002421404 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (null == _0024self__002421404.webViewGo)
						{
							goto case 1;
						}
						_0024playing_002421399 = true;
						goto case 2;
					case 2:
						if (_0024playing_002421399)
						{
							_0024playing_002421399 = false;
							_0024_002410843_002421401 = 0;
							_0024_002410844_002421402 = _0024self__002421404.webViewGo.GetComponentsInChildren<UIAutoTweener>();
							for (_0024_002410845_002421403 = _0024_002410844_002421402.Length; _0024_002410843_002421401 < _0024_002410845_002421403; _0024_002410843_002421401++)
							{
								if (_0024_002410844_002421402[_0024_002410843_002421401].isPlayingAnimation)
								{
									_0024playing_002421399 = true;
									break;
								}
							}
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024self__002421404._closed = true;
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

		internal NewInformation _0024self__002421405;

		public _0024WaitClose_002421398(NewInformation self_)
		{
			_0024self__002421405 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421405);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ShowImpl_002421406 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ApiInfo _0024req_002421407;

			internal GameObject _0024rootPrefab_002421408;

			internal GameObject _0024webPrefab_002421409;

			internal GameObject _0024rootObj_002421410;

			internal GameObject _0024go_002421411;

			internal Camera _0024parent_002421412;

			internal UIAutoTweener _0024tween_002421413;

			internal WebView _0024wv_002421414;

			internal int _0024_002410851_002421415;

			internal UIAutoTweener[] _0024_002410852_002421416;

			internal int _0024_002410853_002421417;

			internal NewInformation _0024self__002421418;

			public _0024(NewInformation self_)
			{
				_0024self__002421418 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (!IsEnableNewInformation())
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024self__002421418.pause = false;
						if (!TheWorld.WorldIsStopped)
						{
							TimeScaleUtil.Zero();
							TheWorld.StopWorldForPause();
							_0024self__002421418.pause = true;
						}
						_0024req_002421407 = new ApiInfo();
						_0024req_002421407.realtimeRetyrTimerAndNoRetryDialog();
						MerlinServer.Request(_0024req_002421407);
						goto case 3;
					case 3:
						if (!_0024req_002421407.IsEnd)
						{
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						if (_0024req_002421407.IsOk)
						{
							_0024rootPrefab_002421408 = GameAssetModule.LoadPrefab("Prefab/HUD/NewInformation UI Root") as GameObject;
							_0024webPrefab_002421409 = GameAssetModule.LoadPrefab("Prefab/GUI/WebFullScreen") as GameObject;
							_0024rootObj_002421410 = ((GameObject)UnityEngine.Object.Instantiate(_0024rootPrefab_002421408)) as GameObject;
							_0024go_002421411 = ((GameObject)UnityEngine.Object.Instantiate(_0024webPrefab_002421409)) as GameObject;
							_0024parent_002421412 = (Camera)UnityEngine.Object.FindObjectOfType(typeof(Camera));
							if (!(_0024parent_002421412 != null))
							{
								throw new AssertionFailedException("parent != null");
							}
							_0024go_002421411.transform.parent = _0024parent_002421412.transform;
							_0024go_002421411.transform.localPosition = _0024webPrefab_002421409.transform.localPosition;
							_0024go_002421411.transform.localScale = Vector3.one;
							_0024go_002421411.SetActive(value: false);
							_0024self__002421418.webViewGo = _0024go_002421411;
							_0024_002410851_002421415 = 0;
							_0024_002410852_002421416 = _0024go_002421411.GetComponentsInChildren<UIAutoTweener>(includeInactive: true);
							for (_0024_002410853_002421417 = _0024_002410852_002421416.Length; _0024_002410851_002421415 < _0024_002410853_002421417; _0024_002410851_002421415++)
							{
								_0024_002410852_002421416[_0024_002410851_002421415].Reset(null);
							}
							_0024self__002421418.closeButton = ExtensionsModule.FindChild(_0024go_002421411, "Button").GetComponentsInChildren<UIButtonMessage>(includeInactive: true).FirstOrDefault();
							_0024self__002421418.closeButton.target = _0024self__002421418.gameObject;
							_0024self__002421418.closeButton.functionName = "OnPushClose";
							_0024wv_002421414 = _0024go_002421411.GetComponentsInChildren<WebView>(includeInactive: true).FirstOrDefault();
							_0024go_002421411.SetActive(value: true);
							_0024wv_002421414.OpenHtml(_0024req_002421407.Result, ServerURL.GameServerUrl("/"));
							goto case 4;
						}
						goto IL_0326;
					case 4:
						if (!WebViewBase.IsPageFinish() && !_0024self__002421418._closed)
						{
							result = (YieldDefault(4) ? 1 : 0);
							break;
						}
						if (!WebViewBase.IsUsableWebView())
						{
							_0024self__002421418._closed = true;
						}
						goto case 5;
					case 5:
						if (!_0024self__002421418._closed)
						{
							result = (YieldDefault(5) ? 1 : 0);
							break;
						}
						shown = true;
						goto IL_0326;
					case 1:
						{
							result = 0;
							break;
						}
						IL_0326:
						if (_0024self__002421418.pause)
						{
							TimeScaleUtil.One();
							TheWorld.RestartWorldForPause();
							_0024self__002421418.pause = false;
						}
						if ((bool)_0024self__002421418.webViewGo)
						{
							UnityEngine.Object.Destroy(_0024self__002421418.webViewGo);
						}
						UnityEngine.Object.Destroy(_0024self__002421418.gameObject);
						UnityEngine.Object.Destroy(_0024rootObj_002421410);
						BattleHUD.ShowForTown();
						if (callBack != null)
						{
							callBack.Call(new object[0]);
						}
						YieldDefault(1);
						goto case 1;
					}
				}
				return (byte)result != 0;
			}
		}

		internal NewInformation _0024self__002421419;

		public _0024ShowImpl_002421406(NewInformation self_)
		{
			_0024self__002421419 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421419);
		}
	}

	[NonSerialized]
	private static bool shown;

	[NonSerialized]
	private static ICallable callBack;

	[NonSerialized]
	private static bool skipInfo;

	private GameObject webViewGo;

	private bool _closed;

	private bool pause;

	private UIButtonMessage closeButton;

	public static bool Shown
	{
		get
		{
			return shown;
		}
		set
		{
			shown = value;
		}
	}

	public static bool SkipInfo
	{
		get
		{
			return skipInfo;
		}
		set
		{
			skipInfo = value;
		}
	}

	public static YieldInstruction Show()
	{
		return Show(null);
	}

	public static YieldInstruction Show(ICallable func)
	{
		object result;
		if (skipInfo)
		{
			func?.Call(new object[0]);
			skipInfo = false;
			result = null;
		}
		else
		{
			callBack = func;
			GameObject gameObject = new GameObject();
			NewInformation newInformation = gameObject.AddComponent<NewInformation>();
			BattleHUD.ShowForPauseTown();
			result = newInformation.StartCoroutine(newInformation.ShowImpl());
		}
		return (YieldInstruction)result;
	}

	private IEnumerator WaitClose()
	{
		return new _0024WaitClose_002421398(this).GetEnumerator();
	}

	private void OnPushClose(object param)
	{
		if (!(null == closeButton) && !(null == webViewGo))
		{
			closeButton.functionName = string.Empty;
			int i = 0;
			UIAutoTweener[] componentsInChildren = webViewGo.GetComponentsInChildren<UIAutoTweener>();
			for (int length = componentsInChildren.Length; i < length; i = checked(i + 1))
			{
				componentsInChildren[i].PlayAnimation(forward: false);
			}
			StartCoroutine(WaitClose());
		}
	}

	public static bool IsEnableNewInformation()
	{
		return UserData.Current != null && DialogManager.DialogCount <= 0 && !MerlinServer.Instance.IsBusy && SceneChanger.isFadeOut && FaderCore.Instance.isOutCompleted && (SceneChanger.CurrentScene == SceneID.Town || SceneChanger.CurrentScene == SceneID.Myhome) && !CutSceneManager.IsBusy && !TutorialEvent.IsBusy && !GameLevelManager.IsBusy && !NpcTalkControl.IsBusy && !BattleHUDShortcut.IsOpen;
	}

	public void OnDestroy()
	{
		if (pause)
		{
			TimeScaleUtil.One();
			TheWorld.RestartWorldForPause();
			pause = false;
		}
	}

	private IEnumerator ShowImpl()
	{
		return new _0024ShowImpl_002421406(this).GetEnumerator();
	}
}
