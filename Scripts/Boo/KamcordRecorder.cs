using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class KamcordRecorder : BaseRecorder
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_showView_002419124 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal KamcordRecorder _0024self__002419125;

			public _0024(KamcordRecorder self_)
			{
				_0024self__002419125 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002419125._setRecorderMode(RecorderMode.Play);
					_0024self__002419125.ShowViewEvent();
					Kamcord.ShowView();
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					_0024self__002419125._setRecorderMode(RecorderMode.Stop);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal KamcordRecorder _0024self__002419126;

		public _0024_showView_002419124(KamcordRecorder self_)
		{
			_0024self__002419126 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419126);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_showWatchView_002419127 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal KamcordRecorder _0024self__002419128;

			public _0024(KamcordRecorder self_)
			{
				_0024self__002419128 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002419128._setRecorderMode(RecorderMode.Play);
					_0024self__002419128.ShowViewEvent();
					Kamcord.ShowWatchView();
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					_0024self__002419128._setRecorderMode(RecorderMode.Stop);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal KamcordRecorder _0024self__002419129;

		public _0024_showWatchView_002419127(KamcordRecorder self_)
		{
			_0024self__002419129 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419129);
		}
	}

	[NonSerialized]
	private static KamcordRecorder __instance;

	[NonSerialized]
	protected static bool quitApp;

	[NonSerialized]
	private static KamcordRecorder _instance;

	private bool reqKamcordOff;

	private bool isView;

	public static KamcordRecorder Instance
	{
		get
		{
			KamcordRecorder result;
			if (quitApp)
			{
				result = __instance;
			}
			else if (__instance != null)
			{
				result = __instance;
			}
			else
			{
				__instance = ((KamcordRecorder)UnityEngine.Object.FindObjectOfType(typeof(KamcordRecorder))) as KamcordRecorder;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				result = __instance;
			}
			return result;
		}
	}

	public static KamcordRecorder CurrentInstance => __instance;

	public static KamcordRecorder instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Instance;
			}
			return _instance;
		}
	}

	public bool IsView => isView;

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00241780();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static KamcordRecorder _createInstance()
	{
		string text = "__" + "KamcordRecorder" + "__";
		GameObject gameObject = new GameObject(text);
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		KamcordRecorder kamcordRecorder = ExtensionsModule.SetComponent<KamcordRecorder>(gameObject);
		if ((bool)kamcordRecorder)
		{
			kamcordRecorder._createInstance_callback();
		}
		return kamcordRecorder;
	}

	public void _createInstance_callback()
	{
	}

	public static void DestroyInstance()
	{
		if ((bool)__instance)
		{
			UnityEngine.Object.DestroyObject(__instance.gameObject);
		}
		__instance = null;
	}

	public void _0024singleton_0024appQuit_00241781()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00241781();
		quitApp = true;
	}

	public void _0024singleton_0024awake_00241780()
	{
		Kamcord.kamcordViewDidDisappear += HideViewEvent;
		Kamcord.kamcordViewDidNotAppear += HideViewEvent;
		Kamcord.kamcordWatchViewDidDisappear += HideViewEvent;
	}

	public void OnDestroy()
	{
		Kamcord.kamcordViewDidDisappear -= HideViewEvent;
		Kamcord.kamcordViewDidNotAppear -= HideViewEvent;
		Kamcord.kamcordWatchViewDidDisappear -= HideViewEvent;
	}

	public void Update()
	{
		if (reqKamcordOff)
		{
			reqKamcordOff = false;
			ActivateVoiceOverlay(enabled: false);
		}
	}

	public override void startRecording()
	{
		if (isStop)
		{
			_setRecorderMode(RecorderMode.Record);
			bool flag = true;
			InitVoiceOverlay();
			Kamcord.StartRecording();
		}
	}

	public override void stopRecording()
	{
		if (isRecord)
		{
			_setRecorderMode(RecorderMode.Stop);
			Kamcord.StopRecording();
			ActivateVoiceOverlay(enabled: false);
		}
	}

	public override void showView()
	{
		if (isStop)
		{
			IEnumerator enumerator = _showView();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	public override void showWatchView()
	{
		if (isStop)
		{
			IEnumerator enumerator = _showWatchView();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	public void ActivateVoiceOverlay(bool enabled)
	{
		Kamcord.ActivateVoiceOverlay(enabled);
	}

	public bool VoiceOverlayActivated()
	{
		return Kamcord.VoiceOverlayActivated();
	}

	private void InitVoiceOverlay()
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		bool recVoiceOverlay = current.userMiscInfo.configData.RecVoiceOverlay;
		ActivateVoiceOverlay(recVoiceOverlay);
	}

	private void SaveVoiceOverlay()
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		bool recVoiceOverlay = VoiceOverlayActivated();
		current.userMiscInfo.configData.RecVoiceOverlay = recVoiceOverlay;
		ActivateVoiceOverlay(enabled: false);
		reqKamcordOff = true;
	}

	private void ShowViewEvent()
	{
		InitVoiceOverlay();
		isView = true;
	}

	private void HideViewEvent()
	{
		SaveVoiceOverlay();
		isView = false;
	}

	private IEnumerator _showView()
	{
		return new _0024_showView_002419124(this).GetEnumerator();
	}

	private IEnumerator _showWatchView()
	{
		return new _0024_showWatchView_002419127(this).GetEnumerator();
	}

	public void initialize()
	{
	}
}
