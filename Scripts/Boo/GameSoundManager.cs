using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using UnityEngine;

[Serializable]
public class GameSoundManager : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024PlaySeJingleRoutine_002419714 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal SQEX_SoundPlayer _0024sndmgr_002419715;

			internal int _0024seId_002419716;

			internal string _0024seName_002419717;

			internal int _0024seStartDelayMsec_002419718;

			internal bool _0024resumeBgm_002419719;

			internal GameSoundManager _0024self__002419720;

			public _0024(string seName, int seStartDelayMsec, bool resumeBgm, GameSoundManager self_)
			{
				_0024seName_002419717 = seName;
				_0024seStartDelayMsec_002419718 = seStartDelayMsec;
				_0024resumeBgm_002419719 = resumeBgm;
				_0024self__002419720 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024sndmgr_002419715 = SQEX_SoundPlayer.Instance;
						if (!_0024sndmgr_002419715 || string.IsNullOrEmpty(_0024seName_002419717))
						{
							goto case 1;
						}
						if (_0024resumeBgm_002419719)
						{
							_0024self__002419720.jingleResetRequest = true;
							_0024self__002419720.jingleResetRequestCount++;
						}
						_0024sndmgr_002419715.StopAllSe(_0024seStartDelayMsec_002419718);
						if (_0024sndmgr_002419715.IsPlayBgm())
						{
							_0024sndmgr_002419715.StopBgm(2000);
						}
						_0024seId_002419716 = _0024sndmgr_002419715.PlaySe(_0024seName_002419717, _0024seStartDelayMsec_002419718, _0024self__002419720.gameObject.GetInstanceID());
						LastSeId = _0024seId_002419716;
						_0024sndmgr_002419715.SetSeVoulme(_0024seId_002419716, 0.65f);
						goto case 2;
					case 2:
						if (_0024sndmgr_002419715.IsPlaySe(_0024seId_002419716))
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (_0024resumeBgm_002419719)
						{
							_0024self__002419720.jingleResetRequestCount--;
						}
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

		internal string _0024seName_002419721;

		internal int _0024seStartDelayMsec_002419722;

		internal bool _0024resumeBgm_002419723;

		internal GameSoundManager _0024self__002419724;

		public _0024PlaySeJingleRoutine_002419714(string seName, int seStartDelayMsec, bool resumeBgm, GameSoundManager self_)
		{
			_0024seName_002419721 = seName;
			_0024seStartDelayMsec_002419722 = seStartDelayMsec;
			_0024resumeBgm_002419723 = resumeBgm;
			_0024self__002419724 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024seName_002419721, _0024seStartDelayMsec_002419722, _0024resumeBgm_002419723, _0024self__002419724);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024PlayBgmRoutine_002419725 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal SQEX_SoundPlayer _0024sndmgr_002419726;

			internal bool _0024checkBgm_002419727;

			internal string _0024loadBgmFile_002419728;

			internal string _0024bgmFile_002419729;

			internal float _0024vol_002419730;

			internal float _0024pan_002419731;

			internal int _0024delayMsec_002419732;

			internal int _0024loop_002419733;

			internal GameSoundManager _0024self__002419734;

			public _0024(string bgmFile, float vol, float pan, int delayMsec, int loop, GameSoundManager self_)
			{
				_0024bgmFile_002419729 = bgmFile;
				_0024vol_002419730 = vol;
				_0024pan_002419731 = pan;
				_0024delayMsec_002419732 = delayMsec;
				_0024loop_002419733 = loop;
				_0024self__002419734 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__002419734.nowLoading)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					curBgmFile = _0024bgmFile_002419729;
					_0024sndmgr_002419726 = SQEX_SoundPlayer.Instance;
					if ((bool)_0024sndmgr_002419726 && SQEX_SoundPlayer.MasterBgmVolume > 0f && (!_0024sndmgr_002419726.IsPlayBgm() || !_0024sndmgr_002419726.IsLastBgm(_0024bgmFile_002419729)))
					{
						_0024checkBgm_002419727 = true;
						if (!_0024checkBgm_002419727 || UserData.Current.userMiscInfo.bgmLoad)
						{
							_0024loadBgmFile_002419728 = SQEX_SoundPlayer.GetOsSoundFile(_0024bgmFile_002419729);
							if (!_0024loadBgmFile_002419728.EndsWith(".bytes"))
							{
								_0024loadBgmFile_002419728 += ".bytes";
							}
							_0024self__002419734.StartCoroutine(_0024self__002419734.loadBgmFromAssetBundle(_0024loadBgmFile_002419728, "BGM", _0024loop_002419733));
							_0024sndmgr_002419726.StopBgm(_0024delayMsec_002419732);
							result = (Yield(3, new WaitForSeconds((float)_0024delayMsec_002419732 * 0.001f)) ? 1 : 0);
							break;
						}
						_0024sndmgr_002419726.StopBgm(_0024delayMsec_002419732);
					}
					goto case 1;
				case 3:
				case 4:
					if (_0024self__002419734.nowLoading)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					if (curBgmFile == _0024bgmFile_002419729 && _0024self__002419734.isBgm)
					{
						SQEX_SoundPlayer.BgmVolume = _0024vol_002419730;
						_0024sndmgr_002419726.SetBgmPan(_0024pan_002419731);
						_0024sndmgr_002419726.PauseBgm(pause: false);
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

		internal string _0024bgmFile_002419735;

		internal float _0024vol_002419736;

		internal float _0024pan_002419737;

		internal int _0024delayMsec_002419738;

		internal int _0024loop_002419739;

		internal GameSoundManager _0024self__002419740;

		public _0024PlayBgmRoutine_002419725(string bgmFile, float vol, float pan, int delayMsec, int loop, GameSoundManager self_)
		{
			_0024bgmFile_002419735 = bgmFile;
			_0024vol_002419736 = vol;
			_0024pan_002419737 = pan;
			_0024delayMsec_002419738 = delayMsec;
			_0024loop_002419739 = loop;
			_0024self__002419740 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024bgmFile_002419735, _0024vol_002419736, _0024pan_002419737, _0024delayMsec_002419738, _0024loop_002419739, _0024self__002419740);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024loadBgmFromAssetBundle_002419741 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RuntimeAssetBundleDB _0024abdb_002419742;

			internal RuntimeAssetBundleDB.Req _0024r_002419743;

			internal SQEX_SoundPlayer _0024sndmgr_002419744;

			internal string _0024bgmFile_002419745;

			internal int _0024loop_002419746;

			internal GameSoundManager _0024self__002419747;

			public _0024(string bgmFile, int loop, GameSoundManager self_)
			{
				_0024bgmFile_002419745 = bgmFile;
				_0024loop_002419746 = loop;
				_0024self__002419747 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002419747.nowLoading = true;
					_0024self__002419747.isBgm = false;
					_0024self__002419747.bgmData = null;
					_0024abdb_002419742 = RuntimeAssetBundleDB.Instance;
					_0024r_002419743 = _0024abdb_002419742.loadAsset(_0024bgmFile_002419745, typeof(TextAsset));
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
				case 3:
					if (!_0024r_002419743.IsEnd)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (_0024r_002419743.IsOk)
					{
						_0024self__002419747.bgmData = _0024r_002419743.Asset as TextAsset;
					}
					if ((bool)_0024self__002419747.bgmData)
					{
						_0024self__002419747.isBgm = true;
					}
					if (_0024self__002419747.isBgm)
					{
						_0024sndmgr_002419744 = SQEX_SoundPlayer.Instance;
						if (!_0024sndmgr_002419744)
						{
							goto case 1;
						}
						_0024sndmgr_002419744.PlayBgm(_0024self__002419747.bgmData, _0024bgmFile_002419745, _0024loop_002419746, 0, -1);
						_0024sndmgr_002419744.PauseBgm(pause: true);
					}
					_0024self__002419747.nowLoading = false;
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024bgmFile_002419748;

		internal int _0024loop_002419749;

		internal GameSoundManager _0024self__002419750;

		public _0024loadBgmFromAssetBundle_002419741(string bgmFile, int loop, GameSoundManager self_)
		{
			_0024bgmFile_002419748 = bgmFile;
			_0024loop_002419749 = loop;
			_0024self__002419750 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024bgmFile_002419748, _0024loop_002419749, _0024self__002419750);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024loadSeFromAssetBundle_002419751 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024seName_002419752;

			internal TextAsset _0024seData_002419753;

			internal RuntimeAssetBundleDB _0024abdb_002419754;

			internal RuntimeAssetBundleDB.Req _0024r_002419755;

			internal bool _0024res_002419756;

			internal int _0024seIndex_002419757;

			internal __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ _0024callback_002419758;

			public _0024(int seIndex, __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ callback)
			{
				_0024seIndex_002419757 = seIndex;
				_0024callback_002419758 = callback;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					string[] seList = SQEX_SoundPlayerData.seList;
					_0024seName_002419752 = seList[RuntimeServices.NormalizeArrayIndex(seList, _0024seIndex_002419757)];
					_0024seName_002419752 = SQEX_SoundPlayer.GetOsSoundFile(_0024seName_002419752);
					if (!_0024seName_002419752.EndsWith(".bytes"))
					{
						_0024seName_002419752 += ".bytes";
					}
					_0024seData_002419753 = null;
					try
					{
						_0024abdb_002419754 = RuntimeAssetBundleDB.Instance;
						_0024r_002419755 = _0024abdb_002419754.loadAsset(_0024seName_002419752, typeof(TextAsset));
					}
					catch (Exception)
					{
						if (_0024callback_002419758 != null)
						{
							_0024callback_002419758(arg0: false);
						}
						goto case 1;
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				}
				case 2:
				case 3:
					if (!_0024r_002419755.IsEnd)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (_0024r_002419755.IsOk)
					{
						_0024seData_002419753 = _0024r_002419755.Asset as TextAsset;
					}
					_0024res_002419756 = false;
					if ((bool)_0024seData_002419753)
					{
						_0024res_002419756 = SQEX_SoundPlayer.Instance.RegisterSeBankFromBytes(_0024seIndex_002419757, _0024seName_002419752, _0024seData_002419753.bytes) >= 0;
					}
					if (_0024callback_002419758 != null)
					{
						_0024callback_002419758(_0024res_002419756);
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

		internal int _0024seIndex_002419759;

		internal __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ _0024callback_002419760;

		public _0024loadSeFromAssetBundle_002419751(int seIndex, __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ callback)
		{
			_0024seIndex_002419759 = seIndex;
			_0024callback_002419760 = callback;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024seIndex_002419759, _0024callback_002419760);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024LoadCommonSeFromBinPack_0024_routine_00243094_002419761 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RuntimeAssetBundleDB.Req _0024r_002419762;

			internal GameSoundManager _0024self__002419763;

			public _0024(GameSoundManager self_)
			{
				_0024self__002419763 = self_;
			}

			public override bool MoveNext()
			{
				bool flag;
				try
				{
					switch (_state)
					{
					default:
						_0024self__002419763.nowSeLoading = checked(_0024self__002419763.nowSeLoading + 1);
						_state = 2;
						_0024r_002419762 = RuntimeAssetBundleDB.Instance.loadAsset("CommonSEPack", typeof(TextAsset));
						break;
					case 3:
						break;
					case 1:
					case 2:
						goto end_IL_0000;
					}
					if (!_0024r_002419762.IsEnd)
					{
						flag = YieldDefault(3);
						goto IL_00ee;
					}
					if (_0024r_002419762.IsOk && _0024r_002419762.Asset is TextAsset)
					{
						_0024self__002419763.LoadSeInBinPack((_0024r_002419762.Asset as TextAsset).bytes);
					}
					_state = 1;
					_0024ensure2();
					YieldDefault(1);
					end_IL_0000:;
				}
				catch
				{
					//try-fault
					Dispose();
					throw;
				}
				int result = 0;
				goto IL_00ef;
				IL_00ee:
				result = (flag ? 1 : 0);
				goto IL_00ef;
				IL_00ef:
				return (byte)result != 0;
			}

			private void _0024ensure2()
			{
				_0024self__002419763.nowSeLoading = checked(_0024self__002419763.nowSeLoading - 1);
			}

			public override void Dispose()
			{
				switch (_state)
				{
				default:
					_state = 1;
					break;
				case 2:
				case 3:
					_state = 1;
					_0024ensure2();
					break;
				}
			}
		}

		internal GameSoundManager _0024self__002419764;

		public _0024_0024LoadCommonSeFromBinPack_0024_routine_00243094_002419761(GameSoundManager self_)
		{
			_0024self__002419764 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419764);
		}
	}

	[NonSerialized]
	public const string DEFAULT_PREFAB_PATH = "Prefab/Sound/SoundManager";

	[NonSerialized]
	private static GameSoundManager __instance;

	[NonSerialized]
	protected static bool quitApp;

	[NonSerialized]
	public const string BINPACK_FILENAME = "CommonSEPack";

	[NonSerialized]
	public static readonly string BINPACK_FILENAME_WITH_EXTENSION = "CommonSEPack" + ".bytes";

	protected MScenes curMScene;

	protected MScenes lastMScene;

	protected MQuests curMQuest;

	protected MQuests lastMQuest;

	protected bool waitCutScene;

	protected bool cutsceneBusy;

	protected bool checkCutScene;

	public bool ignoreUnityEditor;

	[NonSerialized]
	protected static bool reset;

	[NonSerialized]
	protected static string curBgmFile;

	[NonSerialized]
	protected static bool fromShortcut;

	[NonSerialized]
	protected static int lastSeId;

	protected bool jingleResetRequest;

	protected int jingleResetRequestCount;

	protected string lastSceneName;

	protected string nextSceneName;

	protected MBgm curMBgm;

	protected MBgm nextMBgm;

	protected float defWaitMSec;

	protected float waitMSec;

	protected bool nowLoading;

	protected int nowSeLoading;

	protected bool isBgm;

	protected TextAsset bgmData;

	protected bool initSeTable;

	protected Boo.Lang.List<int> sceneSeList;

	protected string[] ignoreQuestScene;

	public static GameSoundManager Instance
	{
		get
		{
			GameSoundManager _instance;
			if (quitApp)
			{
				_instance = __instance;
			}
			else if (__instance != null)
			{
				_instance = __instance;
			}
			else
			{
				__instance = ((GameSoundManager)UnityEngine.Object.FindObjectOfType(typeof(GameSoundManager))) as GameSoundManager;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static GameSoundManager CurrentInstance => __instance;

	public MScenes CurMScene
	{
		set
		{
			curMScene = value;
		}
	}

	public MQuests CurMQuest
	{
		set
		{
			curMQuest = value;
			if (!RuntimeServices.EqualityOperator(curMQuest, lastMQuest))
			{
				WaitCutScene = true;
			}
		}
	}

	public bool WaitCutScene
	{
		set
		{
			checkCutScene = false;
			cutsceneBusy = false;
			waitCutScene = value;
		}
	}

	public bool NowLoading
	{
		get
		{
			bool num = nowLoading;
			if (!num)
			{
				num = nowSeLoading > 0;
			}
			return num;
		}
	}

	public float TimeScale
	{
		set
		{
			Time.timeScale = value;
		}
	}

	public static bool Reset
	{
		get
		{
			return reset;
		}
		set
		{
			reset = value;
		}
	}

	public static string CurBgmFile
	{
		get
		{
			return curBgmFile;
		}
		set
		{
			curBgmFile = value;
		}
	}

	public static bool FromShortcut
	{
		get
		{
			return fromShortcut;
		}
		set
		{
			fromShortcut = value;
		}
	}

	public static int LastSeId
	{
		get
		{
			return lastSeId;
		}
		set
		{
			lastSeId = value;
		}
	}

	public MBgm CurMBgm => curMBgm;

	public GameSoundManager()
	{
		lastSceneName = string.Empty;
		nextSceneName = string.Empty;
		defWaitMSec = 2000f;
		sceneSeList = new Boo.Lang.List<int>();
		ignoreQuestScene = new string[3] { "Ui_WorldQuestResult", "Ui_WorldRaidResult", "Ui_WorldChallengeResult" };
	}

	public void _0024singleton_0024awake_00241848()
	{
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00241848();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static GameSoundManager _createInstance()
	{
		GameObject gameObject = (GameObject)GameAssetModule.LoadPrefab("Prefab/Sound/SoundManager");
		GameObject gameObject2;
		if (gameObject == null)
		{
			gameObject2 = new GameObject();
		}
		else
		{
			gameObject2 = ((GameObject)UnityEngine.Object.Instantiate(gameObject)) as GameObject;
			if (gameObject2 == null)
			{
				gameObject2 = new GameObject();
			}
		}
		gameObject2.name = "__" + "GameSoundManager" + "__";
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject2);
		GameSoundManager gameSoundManager = ExtensionsModule.SetComponent<GameSoundManager>(gameObject2);
		if ((bool)gameSoundManager)
		{
			gameSoundManager._createInstance_callback();
		}
		return gameSoundManager;
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

	public void _0024singleton_0024appQuit_00241849()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00241849();
		quitApp = true;
	}

	public static void ScenePreChangeEvent()
	{
		SQEX_SoundPlayer.Instance.StopAllSe(1000);
	}

	public void Start()
	{
		ignoreUnityEditor = true;
		SceneChanger.ScenePreChangeEvent += _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__Req_FailHandler_0024callable6_0024440_32___0024148.Adapt(ScenePreChangeEvent);
		GameParameter.Load();
	}

	public void OnEnable()
	{
		SceneChanger.ScenePreChangeEvent += SetNextScene;
	}

	public void OnDisalbe()
	{
		SceneChanger.ScenePreChangeEvent -= SetNextScene;
	}

	public void SetNextScene(string sceneName)
	{
		nextSceneName = sceneName;
		lastMScene = null;
		lastMQuest = null;
		UnloadSceneSound();
	}

	public void OnDestory()
	{
		SceneChanger.ScenePreChangeEvent -= _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__Req_FailHandler_0024callable6_0024440_32___0024148.Adapt(ScenePreChangeEvent);
		UnityEngine.Object.DestroyObject(gameObject);
	}

	public void InitSeTableBySeMaster()
	{
		CreateSeTable();
		initSeTable = true;
	}

	public void Update()
	{
		SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
		if (instance.IsMute != GameParameter.soundMute)
		{
			instance.IsMute = GameParameter.soundMute;
		}
		if ((bool)CutSceneManager.Instance && CutSceneManager.Instance.isBusy)
		{
			cutsceneBusy = true;
			return;
		}
		if (jingleResetRequest && jingleResetRequestCount <= 0)
		{
			jingleResetRequestCount = 0;
			reset = true;
			jingleResetRequest = false;
		}
		if (reset)
		{
			nextSceneName = lastSceneName;
			lastSceneName = string.Empty;
			lastMQuest = null;
			lastMScene = null;
			curBgmFile = string.Empty;
			reset = false;
		}
		if (IsNewScene())
		{
			BgmProc();
		}
		if (RuntimeServices.EqualityOperator(nextMBgm, curMBgm) || waitMSec <= 0f)
		{
			return;
		}
		waitMSec -= Time.deltaTime * 1000f;
		if (!(waitMSec > 0f))
		{
			curMBgm = nextMBgm;
			if (curMBgm != null)
			{
				instance.PauseBgm(pause: false);
			}
		}
	}

	public void CreateSeTable()
	{
		SQEX_SoundPlayerData.seList = new string[0];
		SQEX_SoundPlayerData.seNames.Clear();
		SQEX_SoundPlayerData.seTypes.Clear();
		SQEX_SoundPlayerData.seGroups.Clear();
		int i = 0;
		MSe[] all = MSe.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			int id = all[i].Id;
			if (id < 0)
			{
				continue;
			}
			string text = all[i].File;
			if (string.IsNullOrEmpty(text))
			{
				text = string.Empty;
			}
			if (SQEX_SoundPlayerData.seList == null)
			{
				SQEX_SoundPlayerData.seList = new string[1] { text };
			}
			else
			{
				SQEX_SoundPlayerData.seList = (string[])RuntimeServices.AddArrays(typeof(string), SQEX_SoundPlayerData.seList, new string[1] { text });
			}
			if (string.IsNullOrEmpty(text))
			{
				continue;
			}
			SQEX_SoundPlayerData.seNames[text] = id;
			int type = (int)all[i].Type;
			if (type >= 0)
			{
				if (!SQEX_SoundPlayerData.seTypes.ContainsKey(type))
				{
					SQEX_SoundPlayerData.seTypes[type] = new int[1] { id };
				}
				else
				{
					SQEX_SoundPlayerData.seTypes[type] = (int[])RuntimeServices.AddArrays(typeof(int), SQEX_SoundPlayerData.seTypes[type], new int[1] { id });
				}
			}
			string group = all[i].Group;
			if (string.IsNullOrEmpty(group))
			{
				continue;
			}
			string[] array = group.Split(',');
			int j = 0;
			string[] array2 = array;
			for (int length2 = array2.Length; j < length2; j = checked(j + 1))
			{
				if (!string.IsNullOrEmpty(array2[j]))
				{
					if (!SQEX_SoundPlayerData.seGroups.ContainsKey(array2[j]))
					{
						SQEX_SoundPlayerData.seGroups[array2[j]] = new int[1] { id };
					}
					else
					{
						SQEX_SoundPlayerData.seGroups[array2[j]] = (int[])RuntimeServices.AddArrays(typeof(int), SQEX_SoundPlayerData.seGroups[array2[j]], new int[1] { id });
					}
				}
			}
		}
	}

	private bool IsNewScene()
	{
		int result;
		if (waitCutScene && IsQuestScene(nextSceneName) && curMQuest != null && !RuntimeServices.EqualityOperator(curMQuest, lastMQuest))
		{
			if (MQuestsUtil.MustPlayStartCutScene(curMQuest) && curMQuest.BgmId != null && curMQuest.BgmId.Id >= 0)
			{
				if (!checkCutScene)
				{
					if (SQEX_SoundPlayer.Instance.IsPlayBgm())
					{
						SQEX_SoundPlayer.Instance.StopBgm(2000);
					}
					checkCutScene = true;
				}
				if (CutSceneManager.Instance.isBusy)
				{
					cutsceneBusy = true;
				}
				else if (cutsceneBusy)
				{
					WaitCutScene = false;
					result = 1;
					goto IL_017c;
				}
				result = 0;
				goto IL_017c;
			}
			WaitCutScene = false;
		}
		result = ((IsQuestScene(nextSceneName) && curMQuest != null && !RuntimeServices.EqualityOperator(curMQuest, lastMQuest) && curMQuest.BgmId != null && curMQuest.BgmId.Id >= 0) ? 1 : ((nextSceneName != lastSceneName && !string.IsNullOrEmpty(nextSceneName)) ? 1 : 0));
		goto IL_017c;
		IL_017c:
		return (byte)result != 0;
	}

	public bool IsQuestScene(string sceneName)
	{
		return (QuestSession.IsInPlay && !RuntimeServices.op_Member(sceneName, ignoreQuestScene)) ? true : false;
	}

	private void BgmProc()
	{
		string text = nextSceneName;
		SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
		int num = 0;
		MBgm mBgm = null;
		bool flag = fromShortcut;
		fromShortcut = false;
		if (IsQuestScene(text))
		{
			if (curMQuest != null)
			{
				if (curMQuest.BgmId != null && curMQuest.BgmId.Id > -1)
				{
					mBgm = curMQuest.BgmId;
				}
				else
				{
					curMQuest = null;
				}
			}
		}
		else
		{
			curMQuest = null;
		}
		lastMQuest = curMQuest;
		checked
		{
			if (mBgm == null)
			{
				int i = 0;
				MSceneBgm[] all = MSceneBgm.All;
				for (int length = all.Length; i < length; i++)
				{
					if (string.IsNullOrEmpty(all[i].IncludeSceneName))
					{
						continue;
					}
					string[] array = all[i].IncludeSceneName.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
					string[] array2 = new string[0];
					if (!flag && !string.IsNullOrEmpty(lastSceneName) && !string.IsNullOrEmpty(all[i].IgnorePrevSceneName))
					{
						array2 = all[i].IgnorePrevSceneName.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
					}
					int j = 0;
					string[] array3 = array;
					for (int length2 = array3.Length; j < length2; j++)
					{
						array3[j] = array3[j].Trim();
						if (!text.StartsWith(array3[j]) || num >= array3[j].Length)
						{
							continue;
						}
						num = array3[j].Length;
						MBgm mBgm2 = all[i].Bgm;
						int k = 0;
						string[] array4 = array2;
						for (int length3 = array4.Length; k < length3; k++)
						{
							array4[k] = array4[k].Trim();
							if (lastSceneName.StartsWith(array4[k]))
							{
								mBgm2 = null;
								break;
							}
						}
						if (mBgm2 != null)
						{
							mBgm = mBgm2;
							break;
						}
					}
				}
			}
			bool flag2 = !RuntimeServices.EqualityOperator(nextMBgm, mBgm);
			if (mBgm != null)
			{
				if (!instance.IsPlayBgm(checkPause: true))
				{
					flag2 = true;
				}
				if (!instance.IsLastBgm(mBgm.File))
				{
					flag2 = true;
				}
				if (curBgmFile != mBgm.File)
				{
					flag2 = true;
				}
			}
			if (flag2)
			{
				nextMBgm = mBgm;
				waitMSec = defWaitMSec;
				if (nextMBgm != null && !string.IsNullOrEmpty(nextMBgm.File))
				{
					PlayBgmDirectCore(nextMBgm.File, 0.65f, 0f, 2000, -1);
				}
			}
			lastSceneName = text;
		}
	}

	public static void PlaySeJingle(string seName, int seStartDelayMsec, bool resumeBgm)
	{
		if (!(CurrentInstance == null))
		{
			CurrentInstance.PlaySeJingleCore(seName, seStartDelayMsec, resumeBgm);
		}
	}

	private void PlaySeJingleCore(string seName, int seStartDelayMsec, bool resumeBgm)
	{
		StartCoroutine(PlaySeJingleRoutine(seName, seStartDelayMsec, resumeBgm));
	}

	public IEnumerator PlaySeJingleRoutine(string seName, int seStartDelayMsec, bool resumeBgm)
	{
		return new _0024PlaySeJingleRoutine_002419714(seName, seStartDelayMsec, resumeBgm, this).GetEnumerator();
	}

	public static int PlaySe(string seName, int seStartDelayMsec)
	{
		SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
		int result;
		if (!instance)
		{
			result = -1;
		}
		else if (!CurrentInstance)
		{
			result = -1;
		}
		else
		{
			int num2 = (LastSeId = instance.PlaySe(seName, seStartDelayMsec, CurrentInstance.gameObject.GetInstanceID()));
			instance.SetSeVoulme(num2, 0.65f);
			result = num2;
		}
		return result;
	}

	public static bool PlayBgmId(int bgmId)
	{
		return !(CurrentInstance == null) && CurrentInstance.PlayBgmCore(bgmId);
	}

	public static bool PlayBgmId(string bgmId)
	{
		return !(CurrentInstance == null) && CurrentInstance.PlayBgmCore(bgmId);
	}

	public static void PlayBgm(MBgm bgm)
	{
		if (bgm != null && 0 <= bgm.Id)
		{
			PlayBgmDirect(bgm.File);
		}
	}

	public static void PlayBgmDirect(string bgmName)
	{
		PlayBgmDirect(bgmName, 1f, 0f, 2000, -1);
	}

	public static void PlayBgmDirect(string bgmName, float vol, float pan, int delayMsec, int loop)
	{
		if (!(CurrentInstance == null))
		{
			CurrentInstance.PlayBgmDirectCore(bgmName, 0.65f * vol, pan, delayMsec, loop);
		}
	}

	private bool PlayBgmCore(string bgmId)
	{
		int result;
		bool flag;
		if (string.IsNullOrEmpty(bgmId))
		{
			result = 0;
		}
		else
		{
			int num = -1;
			try
			{
				num = RuntimeServices.UnboxInt32(Enum.Parse(typeof(SQEX_SoundPlayerData.BGM), bgmId));
			}
			catch (Exception)
			{
				flag = false;
				goto IL_0044;
			}
			result = (PlayBgmCore(num) ? 1 : 0);
		}
		goto IL_0045;
		IL_0044:
		result = (flag ? 1 : 0);
		goto IL_0045;
		IL_0045:
		return (byte)result != 0;
	}

	private bool PlayBgmCore(int id)
	{
		int result;
		if (id == -1)
		{
			result = 0;
		}
		else
		{
			string[] bgmList = SQEX_SoundPlayerData.bgmList;
			string text = bgmList[RuntimeServices.NormalizeArrayIndex(bgmList, id)];
			SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
			if (!instance)
			{
				result = 0;
			}
			else if (!instance.IsPlayBgm() || !(curBgmFile == text))
			{
				IEnumerator enumerator = PlayBgmRoutine(text, 0.65f, 0f, 2000, -1);
				if (enumerator != null)
				{
					StartCoroutine(enumerator);
				}
				result = 1;
			}
			else
			{
				result = 0;
			}
		}
		return (byte)result != 0;
	}

	private void PlayBgmDirectCore(string bgmName, float vol, float pan, int delayMsec, int loop)
	{
		if (!string.IsNullOrEmpty(bgmName))
		{
			int num = bgmName.IndexOf(".");
			if (num >= 0)
			{
				bgmName = bgmName.Substring(0, num);
			}
		}
		SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
		if (!(null == instance) && (!instance.IsPlayBgm() || !(curBgmFile == bgmName)))
		{
			IEnumerator enumerator = PlayBgmRoutine(bgmName, vol, pan, delayMsec, loop);
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	private IEnumerator PlayBgmRoutine(string bgmFile, float vol, float pan, int delayMsec, int loop)
	{
		return new _0024PlayBgmRoutine_002419725(bgmFile, vol, pan, delayMsec, loop, this).GetEnumerator();
	}

	public void LoadCommonSe()
	{
		if (initSeTable)
		{
			LoadSeType(0);
			LoadSeType(3);
			LoadSeType(4);
		}
	}

	public void LoadCommonSeFromBinPack()
	{
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024LoadCommonSeFromBinPack_0024_routine_00243094_002419761(this).GetEnumerator();
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void LoadSeInBinPack(byte[] bin)
	{
		if (!initSeTable || bin == null)
		{
			return;
		}
		BinPackLoader binPackLoader = new BinPackLoader(bin);
		int num = 0;
		IEnumerator<BinPackLoader.FileInfo> enumerator = binPackLoader.FileInfos.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BinPackLoader.FileInfo current = enumerator.Current;
				string text = current.fileName;
				int num2 = text.IndexOf(".");
				if (num2 >= 0)
				{
					text = RuntimeServices.Mid(text, 0, num2);
				}
				if (RegistSe(text, current.data))
				{
					num = checked(num + 1);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public IEnumerator loadBgmFromAssetBundle(string bgmFile, string assetBundleName, int loop)
	{
		return new _0024loadBgmFromAssetBundle_002419741(bgmFile, loop, this).GetEnumerator();
	}

	private bool isLoadSe(int seIndex, __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ callback)
	{
		int result;
		if (seIndex < 0 || SQEX_SoundPlayerData.seList.Length <= seIndex)
		{
			callback?.Invoke(arg0: false);
			result = 0;
		}
		else
		{
			SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
			if (!instance)
			{
				callback?.Invoke(arg0: false);
				result = 0;
			}
			else if (instance.IsLoadSe(seIndex))
			{
				callback?.Invoke(arg0: true);
				result = 0;
			}
			else
			{
				string[] seList = SQEX_SoundPlayerData.seList;
				string value = seList[RuntimeServices.NormalizeArrayIndex(seList, seIndex)];
				if (string.IsNullOrEmpty(value))
				{
					callback?.Invoke(arg0: false);
					result = 0;
				}
				else
				{
					result = 1;
				}
			}
		}
		return (byte)result != 0;
	}

	public IEnumerator loadSeFromAssetBundle(int seIndex, string assetBundleName, __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ callback)
	{
		return new _0024loadSeFromAssetBundle_002419751(seIndex, callback).GetEnumerator();
	}

	private bool RegistSe(string seName, byte[] data)
	{
		int result;
		if (!string.IsNullOrEmpty(seName) && !(data == null) && data.Length > 0)
		{
			if (!SQEX_SoundPlayerData.seNames.ContainsKey(seName))
			{
				result = 0;
			}
			else
			{
				int index = SQEX_SoundPlayerData.seNames[seName];
				SQEX_SoundPlayer.Instance.RegisterSeBankFromBytes(index, seName, data);
				result = 1;
			}
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public bool LoadSe(int seIndex)
	{
		int result;
		checked
		{
			if (seIndex < 0 || SQEX_SoundPlayerData.seList.Length <= seIndex)
			{
				result = 0;
			}
			else
			{
				nowSeLoading++;
				__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ callback = delegate
				{
					nowSeLoading--;
				};
				if (!isLoadSe(seIndex, callback))
				{
					result = 0;
				}
				else
				{
					IEnumerator enumerator = loadSeFromAssetBundle(seIndex, "SE", callback);
					if (enumerator != null)
					{
						StartCoroutine(enumerator);
					}
					result = 1;
				}
			}
		}
		return (byte)result != 0;
	}

	public bool LoadSe(int[] seIndexArray)
	{
		int i = 0;
		for (int length = seIndexArray.Length; i < length; i = checked(i + 1))
		{
			LoadSe(seIndexArray[i]);
		}
		return true;
	}

	public bool LoadSe(string seName)
	{
		return !string.IsNullOrEmpty(seName) && SQEX_SoundPlayerData.seNames.ContainsKey(seName) && LoadSe(SQEX_SoundPlayerData.seNames[seName]);
	}

	public bool LoadSe(string[] seNameArray)
	{
		int i = 0;
		for (int length = seNameArray.Length; i < length; i = checked(i + 1))
		{
			LoadSe(seNameArray[i]);
		}
		return true;
	}

	public bool LoadSeType(int seType)
	{
		int result;
		checked
		{
			if (!SQEX_SoundPlayerData.seTypes.ContainsKey(seType))
			{
				result = 0;
			}
			else
			{
				int[] array = SQEX_SoundPlayerData.seTypes[seType];
				int num = 0;
				int i = 0;
				int[] array2 = array;
				for (int length = array2.Length; i < length; i++)
				{
					if (array2[i] >= 0 && SQEX_SoundPlayerData.seList.Length > array2[i])
					{
						nowSeLoading++;
						__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ callback = delegate
						{
							nowSeLoading--;
						};
						IEnumerator enumerator = loadSeFromAssetBundle(array2[i], "SE", callback);
						if (enumerator != null)
						{
							StartCoroutine(enumerator);
						}
						num++;
					}
				}
				result = ((num > 0) ? 1 : 0);
			}
		}
		return (byte)result != 0;
	}

	public bool LoadSeGroup(string seGroup)
	{
		int result;
		checked
		{
			if (!SQEX_SoundPlayerData.seGroups.ContainsKey(seGroup))
			{
				result = 0;
			}
			else
			{
				int[] array = SQEX_SoundPlayerData.seGroups[seGroup];
				int num = 0;
				int i = 0;
				int[] array2 = array;
				for (int length = array2.Length; i < length; i++)
				{
					if (array2[i] >= 0 && SQEX_SoundPlayerData.seList.Length > array2[i])
					{
						nowSeLoading++;
						__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ callback = delegate
						{
							nowSeLoading--;
						};
						IEnumerator enumerator = loadSeFromAssetBundle(array2[i], "SE", callback);
						if (enumerator != null)
						{
							StartCoroutine(enumerator);
						}
						num++;
					}
				}
				result = ((num > 0) ? 1 : 0);
			}
		}
		return (byte)result != 0;
	}

	public bool UnloadSe(int seIndex)
	{
		SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
		return (bool)instance && instance.UnregisterSeBank(seIndex);
	}

	public bool UnloadSe(int[] seIndexArray)
	{
		bool result = true;
		int i = 0;
		for (int length = seIndexArray.Length; i < length; i = checked(i + 1))
		{
			if (!UnloadSe(seIndexArray[i]))
			{
				result = false;
			}
		}
		return result;
	}

	public bool UnloadSe(string seName)
	{
		return !string.IsNullOrEmpty(seName) && SQEX_SoundPlayerData.seNames.ContainsKey(seName) && UnloadSe(SQEX_SoundPlayerData.seNames[seName]);
	}

	public bool UnloadSe(string[] seNameArray)
	{
		bool result = true;
		int i = 0;
		for (int length = seNameArray.Length; i < length; i = checked(i + 1))
		{
			if (!UnloadSe(seNameArray[i]))
			{
				result = false;
			}
		}
		return result;
	}

	public bool UnloadSeType(int seType)
	{
		SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
		return (bool)instance && instance.UnloadSeType(seType);
	}

	public bool UnloadSeGroup(string seGroup)
	{
		SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
		return (bool)instance && instance.UnloadSeGroup(seGroup);
	}

	public void UnloadSceneSound()
	{
		UnloadSe(sceneSeList.ToArray());
		sceneSeList.Clear();
	}

	public void LoadSceneSe(MScenes scene)
	{
		if (scene != null)
		{
			int i = 0;
			MSe[] allSe = scene.AllSe;
			for (int length = allSe.Length; i < length; i = checked(i + 1))
			{
				sceneSeList.Add(allSe[i].Id);
				LoadSe(allSe[i].File);
			}
		}
	}

	internal IEnumerator _0024LoadCommonSeFromBinPack_0024_routine_00243094()
	{
		return new _0024_0024LoadCommonSeFromBinPack_0024_routine_00243094_002419761(this).GetEnumerator();
	}

	internal void _0024LoadSe_0024closure_00243816(bool res)
	{
		checked
		{
			nowSeLoading--;
		}
	}

	internal void _0024LoadSeType_0024closure_00243817(bool res)
	{
		checked
		{
			nowSeLoading--;
		}
	}

	internal void _0024LoadSeGroup_0024closure_00243818(bool res)
	{
		checked
		{
			nowSeLoading--;
		}
	}
}
