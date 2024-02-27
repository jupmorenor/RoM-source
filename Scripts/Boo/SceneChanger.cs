using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class SceneChanger : MonoBehaviour
{
	[Serializable]
	public enum Mode
	{
		WAIT_CHANGE,
		WAIT_FADE_IN,
		SCENE_CHANGE,
		UNLOAD_UNUSED_ASSETS,
		WAIT_FADE_OUT,
		CANCEL_CHANGE
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024mainRoutine_002415398 : GenericGenerator<AsyncOperation>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<AsyncOperation>, IEnumerator
		{
			internal string _0024_newScene_002415399;

			internal SceneID _0024sid_002415400;

			internal IEnumerator _0024_0024sco_0024temp_0024682_002415401;

			internal float _0024_0024wait_sec_0024temp_0024683_002415402;

			internal bool _0024needUnloadUnusedAssets_002415403;

			internal bool _0024isAssetBundleScene_002415404;

			internal GameObject[] _0024abObjs_002415405;

			internal int _0024i_002415406;

			internal float _0024_0024wait_until_0024temp_0024684_002415407;

			internal float _0024_0024wait_until_0024temp_0024685_002415408;

			internal float _0024_0024wait_until_0024temp_0024686_002415409;

			internal float _0024_0024wait_until_0024temp_0024687_002415410;

			internal int _0024_00248079_002415411;

			internal SceneChanger _0024self__002415412;

			public _0024(SceneChanger self_)
			{
				_0024self__002415412 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002415412.initFader();
					goto IL_0053;
				case 2:
					if (string.IsNullOrEmpty(_0024self__002415412.currentLoadingSceneName))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024_newScene_002415399 = _0024self__002415412.currentLoadingSceneName;
					if (hook != null)
					{
						_0024sid_002415400 = SceneIDModule.StrToSceneID(_0024_newScene_002415399);
						if (SceneIDModule.IsValidSceneID(_0024sid_002415400))
						{
							goto case 3;
						}
						goto IL_00e7;
					}
					goto IL_00ed;
				case 3:
					if (!hook(_0024sid_002415400, _0024_newScene_002415399))
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto IL_00e7;
				case 4:
					if (!_0024self__002415412.fader.isCompleted)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					goto IL_01ba;
				case 5:
					if (_0024_0024wait_sec_0024temp_0024683_002415402 > 0f)
					{
						_0024_0024wait_sec_0024temp_0024683_002415402 -= Time.deltaTime;
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					goto IL_0232;
				case 6:
					result = (Yield(7, UnloadResource.UnloadUnusedAssets()) ? 1 : 0);
					break;
				case 7:
					_0024_00248079_002415411 = 0;
					goto case 8;
				case 8:
					if (_0024_00248079_002415411 < 2)
					{
						_0024i_002415406 = _0024_00248079_002415411;
						_0024_00248079_002415411++;
						result = (YieldDefault(8) ? 1 : 0);
						break;
					}
					goto IL_034f;
				case 9:
					if (!_0024self__002415412.abReq.IsOk && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_0024685_002415408 < _0024_0024wait_until_0024temp_0024684_002415407)
					{
						result = (YieldDefault(9) ? 1 : 0);
						break;
					}
					_0024self__002415412.lastSceneName = _0024self__002415412.currentSceneName;
					_0024self__002415412.setCurrentScene(_0024_newScene_002415399);
					_0024abObjs_002415405 = _0024self__002415412.instantiateAssetBundleScene();
					_0024needUnloadUnusedAssets_002415403 = false;
					goto IL_0417;
				case 10:
					result = (YieldDefault(11) ? 1 : 0);
					break;
				case 11:
					ModalCollider.SetActive(_0024self__002415412, active: true);
					_0024_0024wait_until_0024temp_0024686_002415409 = 60f;
					_0024_0024wait_until_0024temp_0024687_002415410 = Time.realtimeSinceStartup;
					goto case 12;
				case 12:
					if (_0024self__002415412.dontReveal && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_0024687_002415410 < _0024_0024wait_until_0024temp_0024686_002415409)
					{
						result = (YieldDefault(12) ? 1 : 0);
						break;
					}
					mode = Mode.WAIT_FADE_OUT;
					if (_0024self__002415412.useFade)
					{
						_0024self__002415412.fader.fadeOutFromIn(ignoreTScale: true);
					}
					goto case 13;
				case 13:
					if (!_0024self__002415412.fader.isCompleted)
					{
						result = (YieldDefault(13) ? 1 : 0);
						break;
					}
					raise_SceneChangeEventAtFadeout(_0024self__002415412.currentSceneName);
					ModalCollider.SetActive(_0024self__002415412, active: false);
					raise_ScenePostChangeEvent(_0024self__002415412.currentScene, _0024self__002415412.currentSceneName);
					goto IL_0053;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00ed:
					if (mode == Mode.CANCEL_CHANGE)
					{
						_0024self__002415412.currentLoadingSceneName = null;
						goto IL_0053;
					}
					_0024_0024sco_0024temp_0024682_002415401 = _0024self__002415412.showNowLoading();
					if (_0024_0024sco_0024temp_0024682_002415401 != null)
					{
						_0024self__002415412.StartCoroutine(_0024_0024sco_0024temp_0024682_002415401);
					}
					if (_0024self__002415412.useFade)
					{
						mode = Mode.WAIT_FADE_IN;
						_0024self__002415412.fader.red = 0f;
						_0024self__002415412.fader.green = 0f;
						_0024self__002415412.fader.blue = 0f;
						_0024self__002415412.fader.fadeIn(ignoreTScale: true);
						goto case 4;
					}
					goto IL_01ba;
					IL_00e7:
					hook = null;
					goto IL_00ed;
					IL_034f:
					_0024_0024wait_until_0024temp_0024684_002415407 = 60f;
					_0024_0024wait_until_0024temp_0024685_002415408 = Time.realtimeSinceStartup;
					goto case 9;
					IL_0232:
					UserData.Current.userMiscInfo.Save();
					MerlinServer.Busy = false;
					UserData.Current.incFlag(MFlagsUtil.SceneVisitFlagName(_0024_newScene_002415399));
					_0024needUnloadUnusedAssets_002415403 = true;
					_0024isAssetBundleScene_002415404 = RuntimeAssetBundleDB.Instance.isPackedSceneName(_0024_newScene_002415399);
					_0024abObjs_002415405 = new GameObject[0];
					if (_0024isAssetBundleScene_002415404)
					{
						_0024self__002415412.abReq = RuntimeAssetBundleDB.Instance.loadPackedScenePrefab(_0024_newScene_002415399);
						if (_0024self__002415412.abReq == null)
						{
							throw new Exception(new StringBuilder().Append(_0024_newScene_002415399).Append(" error").ToString());
						}
						if (!SlipBlackSceneBetweenScenes)
						{
							Application.LoadLevel("Empty");
							result = (YieldDefault(6) ? 1 : 0);
							break;
						}
						goto IL_034f;
					}
					Application.LoadLevel(_0024_newScene_002415399);
					_0024self__002415412.lastSceneName = _0024self__002415412.currentSceneName;
					_0024self__002415412.setCurrentScene(_0024_newScene_002415399);
					goto IL_0417;
					IL_0053:
					mode = Mode.WAIT_CHANGE;
					goto case 2;
					IL_01ba:
					mode = Mode.SCENE_CHANGE;
					ModalCollider.SetActive(_0024self__002415412, active: true);
					raise_ScenePreChangeEvent(_0024self__002415412.currentLoadingSceneName);
					if (SlipBlackSceneBetweenScenes)
					{
						Application.LoadLevel("EmptyBlack");
					}
					if (Wait1SecAtChanging)
					{
						_0024_0024wait_sec_0024temp_0024683_002415402 = 1f;
						goto case 5;
					}
					goto IL_0232;
					IL_0417:
					TestFlightUnity.PassCheckpoint(new StringBuilder("Scene:").Append(_0024_newScene_002415399).ToString());
					raise_SceneChangeEvent(_0024self__002415412.currentScene, _0024self__002415412.currentSceneName);
					_0024self__002415412.currentLoadingSceneName = null;
					mode = Mode.UNLOAD_UNUSED_ASSETS;
					if (_0024needUnloadUnusedAssets_002415403)
					{
						result = (Yield(10, UnloadResource.UnloadUnusedAssets()) ? 1 : 0);
						break;
					}
					goto case 10;
				}
				return (byte)result != 0;
			}
		}

		internal SceneChanger _0024self__002415413;

		public _0024mainRoutine_002415398(SceneChanger self_)
		{
			_0024self__002415413 = self_;
		}

		public override IEnumerator<AsyncOperation> GetEnumerator()
		{
			return new _0024(_0024self__002415413);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024showNowLoading_002415414 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024nowLoadingObj_002415415;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (mode != Mode.SCENE_CHANGE && mode != Mode.WAIT_FADE_IN)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024nowLoadingObj_002415415 = null;
					if (mode == Mode.SCENE_CHANGE || mode == Mode.WAIT_FADE_IN)
					{
						Loading.Begin();
					}
					goto case 3;
				case 3:
					if (mode != Mode.WAIT_FADE_OUT && !MerlinServer.Busy && mode != 0)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto case 4;
				case 4:
					if (FaderCore.Instance.isOutCompleted)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					Loading.End();
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
	public static bool SlipBlackSceneBetweenScenes;

	[NonSerialized]
	public static bool Wait1SecAtChanging;

	[NonSerialized]
	protected const bool ENABLE_EF_HIT_TEST = false;

	[NonSerialized]
	public const string NOW_LOADING_PREFAB_PATH = "Fader";

	private SceneID currentScene;

	private string currentSceneName;

	[NonSerialized]
	protected const string initLastSceneName = "??????????";

	private string lastSceneName;

	[NonSerialized]
	protected static __SceneChanger_Hook_0024callable38_002438_20__ hook;

	private int _dontRevealCount;

	[NonSerialized]
	private static SceneChanger _instance;

	private string currentLoadingSceneName;

	private RuntimeAssetBundleDB.Req abReq;

	private Fader fader;

	[NonSerialized]
	private static Mode mode;

	private bool useFade;

	[NonSerialized]
	private static __Req_FailHandler_0024callable6_0024440_32__ _0024event_0024ScenePreChangeEvent;

	[NonSerialized]
	private static __SceneChanger_SceneChangeEvent_0024callable39_002444_38__ _0024event_0024SceneChangeEvent;

	[NonSerialized]
	private static __SceneChanger_SceneChangeEvent_0024callable39_002444_38__ _0024event_0024ScenePostChangeEvent;

	[NonSerialized]
	private static __Req_FailHandler_0024callable6_0024440_32__ _0024event_0024SceneChangeEventAtFadeout;

	public SceneID CurrentSceneID => currentScene;

	public bool dontReveal
	{
		get
		{
			return _dontRevealCount > 0;
		}
		set
		{
			checked
			{
				if (value)
				{
					_dontRevealCount++;
				}
				else
				{
					_dontRevealCount--;
				}
			}
		}
	}

	public static string CurrentSceneName => Instance().currentSceneName;

	public static SceneID CurrentScene => Instance().currentScene;

	public static SceneID CurrentLoadingScene => SceneIDModule.StrToSceneID(Instance().currentLoadingSceneName);

	public static string CurrentLoadingSceneName => Instance().currentLoadingSceneName;

	public static bool IsFirstScene => Instance().lastSceneName == "??????????";

	public static string LastSceneName => Instance().lastSceneName;

	public static SceneID LastScene => SceneIDModule.StrToSceneID(Instance().lastSceneName);

	public static bool isCompletelyReady => mode == Mode.WAIT_CHANGE;

	public static bool isFadeIn
	{
		get
		{
			bool num = mode == Mode.UNLOAD_UNUSED_ASSETS;
			if (!num)
			{
				num = mode == Mode.SCENE_CHANGE;
			}
			return num;
		}
	}

	public static bool isVeryBusy => mode == Mode.SCENE_CHANGE;

	public static bool isSceneChanged => mode >= Mode.UNLOAD_UNUSED_ASSETS;

	public static bool isFadeOut
	{
		get
		{
			bool num = mode == Mode.WAIT_CHANGE;
			if (num)
			{
				num = string.IsNullOrEmpty(CurrentLoadingSceneName);
			}
			return num;
		}
	}

	public static bool isStartFadeOut => mode == Mode.WAIT_FADE_OUT;

	public static __SceneChanger_Hook_0024callable38_002438_20__ Hook
	{
		get
		{
			return hook;
		}
		set
		{
			hook = value;
		}
	}

	public static event __Req_FailHandler_0024callable6_0024440_32__ ScenePreChangeEvent
	{
		add
		{
			_0024event_0024ScenePreChangeEvent = (__Req_FailHandler_0024callable6_0024440_32__)Delegate.Combine(_0024event_0024ScenePreChangeEvent, value);
		}
		remove
		{
			_0024event_0024ScenePreChangeEvent = (__Req_FailHandler_0024callable6_0024440_32__)Delegate.Remove(_0024event_0024ScenePreChangeEvent, value);
		}
	}

	public static event __SceneChanger_SceneChangeEvent_0024callable39_002444_38__ SceneChangeEvent
	{
		add
		{
			_0024event_0024SceneChangeEvent = (__SceneChanger_SceneChangeEvent_0024callable39_002444_38__)Delegate.Combine(_0024event_0024SceneChangeEvent, value);
		}
		remove
		{
			_0024event_0024SceneChangeEvent = (__SceneChanger_SceneChangeEvent_0024callable39_002444_38__)Delegate.Remove(_0024event_0024SceneChangeEvent, value);
		}
	}

	public static event __SceneChanger_SceneChangeEvent_0024callable39_002444_38__ ScenePostChangeEvent
	{
		add
		{
			_0024event_0024ScenePostChangeEvent = (__SceneChanger_SceneChangeEvent_0024callable39_002444_38__)Delegate.Combine(_0024event_0024ScenePostChangeEvent, value);
		}
		remove
		{
			_0024event_0024ScenePostChangeEvent = (__SceneChanger_SceneChangeEvent_0024callable39_002444_38__)Delegate.Remove(_0024event_0024ScenePostChangeEvent, value);
		}
	}

	public static event __Req_FailHandler_0024callable6_0024440_32__ SceneChangeEventAtFadeout
	{
		add
		{
			_0024event_0024SceneChangeEventAtFadeout = (__Req_FailHandler_0024callable6_0024440_32__)Delegate.Combine(_0024event_0024SceneChangeEventAtFadeout, value);
		}
		remove
		{
			_0024event_0024SceneChangeEventAtFadeout = (__Req_FailHandler_0024callable6_0024440_32__)Delegate.Remove(_0024event_0024SceneChangeEventAtFadeout, value);
		}
	}

	public SceneChanger()
	{
		currentSceneName = string.Empty;
		lastSceneName = "??????????";
		useFade = true;
	}

	private void setCurrentScene(SceneID sid)
	{
		currentScene = sid;
		currentSceneName = SceneIDModule.SceneIDToName(sid);
		if (currentSceneName == null)
		{
			currentSceneName = string.Empty;
		}
	}

	private void setCurrentScene(string sname)
	{
		if (!(sname != null))
		{
			throw new AssertionFailedException("sname != null");
		}
		currentScene = SceneIDModule.StrToSceneID(sname);
		currentSceneName = sname;
	}

	[SpecialName]
	protected internal static void raise_ScenePreChangeEvent(string arg0)
	{
		_0024event_0024ScenePreChangeEvent?.Invoke(arg0);
	}

	[SpecialName]
	protected internal static void raise_SceneChangeEvent(SceneID arg0, string arg1)
	{
		_0024event_0024SceneChangeEvent?.Invoke(arg0, arg1);
	}

	[SpecialName]
	protected internal static void raise_ScenePostChangeEvent(SceneID arg0, string arg1)
	{
		_0024event_0024ScenePostChangeEvent?.Invoke(arg0, arg1);
	}

	[SpecialName]
	protected internal static void raise_SceneChangeEventAtFadeout(string arg0)
	{
		_0024event_0024SceneChangeEventAtFadeout?.Invoke(arg0);
	}

	public static void Change(string sceneName)
	{
		Change(sceneName, doFade: true);
	}

	public static void Change(string sceneName, bool doFade)
	{
		Instance().changeSub(sceneName, doFade);
	}

	public static void ChangeTo(SceneID sceneID)
	{
		ChangeTo(sceneID, doFade: true);
	}

	public static void ChangeTo(SceneID sceneID, bool doFade)
	{
		Instance().changeSub(SceneIDModule.SceneIDToName(sceneID), doFade);
	}

	public static SceneChanger Instance()
	{
		if (_instance == null)
		{
			GameObject gameObject = new GameObject("__SceneChanger__");
			SceneChanger sceneChanger = ExtensionsModule.SetComponent<SceneChanger>(gameObject);
			if (!(sceneChanger != null))
			{
				throw new AssertionFailedException("c != null");
			}
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_instance = sceneChanger;
			hook = null;
		}
		return _instance;
	}

	public static void Kill()
	{
		if (_instance != null)
		{
			hook = null;
			UnityEngine.Object.Destroy(_instance.gameObject);
			_instance = null;
		}
	}

	public static bool Cancel()
	{
		int result;
		if (_instance != null && mode == Mode.WAIT_CHANGE)
		{
			mode = Mode.CANCEL_CHANGE;
			result = 1;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public void Awake()
	{
		IEnumerator enumerator = Enum.GetValues(typeof(SceneID)).GetEnumerator();
		while (enumerator.MoveNext())
		{
			SceneID e = (SceneID)enumerator.Current;
			if (SceneIDModule.SceneIDToName(e) == Application.loadedLevelName)
			{
				setCurrentScene(e);
				break;
			}
		}
		StartCoroutine(mainRoutine());
	}

	private void changeSub(string sceneName, bool doFade)
	{
		if (string.IsNullOrEmpty(sceneName) || !string.IsNullOrEmpty(currentLoadingSceneName))
		{
			return;
		}
		SceneID e = SceneIDModule.StrToSceneID(sceneName);
		if (SceneIDModule.IsValidSceneID(e))
		{
			currentLoadingSceneName = sceneName;
			abReq = null;
		}
		else
		{
			if (!RuntimeAssetBundleDB.Instance.isPackedSceneName(sceneName))
			{
				return;
			}
			currentLoadingSceneName = sceneName;
			abReq = null;
		}
		_dontRevealCount = 0;
		useFade = doFade;
	}

	public bool isValidSceneName(string sceneName)
	{
		return SceneIDModule.IsValidSceneID(SceneIDModule.StrToSceneID(sceneName)) || (RuntimeAssetBundleDB.Instance.isPackedSceneName(sceneName) ? true : false);
	}

	public IEnumerator mainRoutine()
	{
		return new _0024mainRoutine_002415398(this).GetEnumerator();
	}

	private GameObject[] instantiateAssetBundleScene()
	{
		if (abReq == null)
		{
			throw new AssertionFailedException("abReq != null");
		}
		GameObject[] result = new GameObject[0];
		if (abReq.IsOk && !(abReq.Prefab == null))
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(abReq.Prefab);
			if (gameObject != null)
			{
				AssetBundleLoader.ReloadShader(gameObject);
				result = decompositeChilds(gameObject);
			}
		}
		abReq = null;
		return result;
	}

	private IEnumerator showNowLoading()
	{
		return new _0024showNowLoading_002415414().GetEnumerator();
	}

	private GameObject[] decompositeChilds(GameObject go)
	{
		object result;
		if (go == null)
		{
			result = new GameObject[0];
		}
		else if (1 == 0)
		{
			result = new GameObject[1] { go };
		}
		else
		{
			go.name = new StringBuilder().Append(go.name).Append("-from-AssetBundle-").Append(abReq.BundleName)
				.ToString();
			Boo.Lang.List<GameObject> list = new Boo.Lang.List<GameObject>();
			IEnumerator enumerator = go.transform.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is Transform))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Transform));
				}
				Transform transform = (Transform)obj;
				if (!(transform == null))
				{
					transform.parent = null;
					list.Add(transform.gameObject);
				}
			}
			result = (GameObject[])Builtins.array(typeof(GameObject), list);
		}
		return (GameObject[])result;
	}

	private void initFader()
	{
		GameObject gameObject = Resources.Load("Fader") as GameObject;
		if (gameObject != null)
		{
			GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(gameObject);
			if (!(gameObject2 != null))
			{
				throw new AssertionFailedException("go != null");
			}
			fader = gameObject2.GetComponent<Fader>();
			if (!(fader != null))
			{
				throw new AssertionFailedException("fader != null");
			}
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject2);
		}
	}
}
