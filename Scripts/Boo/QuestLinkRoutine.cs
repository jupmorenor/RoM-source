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
public class QuestLinkRoutine : MonoBehaviour
{
	[Serializable]
	public class JumpParams
	{
		public EnumMapLinkDir jumpFrom;

		public MScenes sceneToJump;

		public bool keepRunning;

		public bool controlQuestTimer;

		public bool putPlayerOnLastQuestInitializerPos;

		public JumpParams()
		{
			jumpFrom = EnumMapLinkDir.N;
			keepRunning = true;
			controlQuestTimer = true;
		}
	}

	[Serializable]
	public class WarpParams
	{
		public MWarps warpData;

		public bool IsValid => warpData != null;
	}

	[Serializable]
	internal class _0024warpRoutine_0024locals_002414421
	{
		internal bool _0024warpOk;
	}

	[Serializable]
	internal class _0024warpRoutine_0024closure_00243005
	{
		internal _0024warpRoutine_0024locals_002414421 _0024_0024locals_002414960;

		public _0024warpRoutine_0024closure_00243005(_0024warpRoutine_0024locals_002414421 _0024_0024locals_002414960)
		{
			this._0024_0024locals_002414960 = _0024_0024locals_002414960;
		}

		public void Invoke()
		{
			_0024_0024locals_002414960._0024warpOk = true;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024jumpRoutine_002418836 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal PlayerControl _0024player_002418837;

			internal CameraControl _0024cameraControl_002418838;

			internal PlayerInputControl _0024oldInput_002418839;

			internal MScenes _0024sceneToJump_002418840;

			internal EnumMapLinkDir _0024jumpTo_002418841;

			internal MasterEffectPack _0024masterEffectPack_002418842;

			internal QuestMapper _0024qm_002418843;

			internal Vector3 _0024setPos_002418844;

			internal int _0024i_002418845;

			internal QuestLinkPosition _0024pos_002418846;

			internal float _0024_0024wait_until_0024temp_00241712_002418847;

			internal float _0024_0024wait_until_0024temp_00241713_002418848;

			internal QuestLinkPosition _0024c_002418849;

			internal IEnumerator _0024_0024sco_0024temp_00241714_002418850;

			internal int _0024_00249449_002418851;

			internal int _0024_00249450_002418852;

			internal QuestLinkPosition[] _0024_00249451_002418853;

			internal int _0024_00249452_002418854;

			internal JumpParams _0024params_002418855;

			internal QuestLinkRoutine _0024self__002418856;

			public _0024(JumpParams @params, QuestLinkRoutine self_)
			{
				_0024params_002418855 = @params;
				_0024self__002418856 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002418856.jumpingNow = true;
					raise_JumpStartEvent(_0024params_002418855.sceneToJump);
					PlayerEventDispatcher.InvokeJumpStart();
					if (_0024params_002418855.controlQuestTimer)
					{
						QuestClearConditionChecker.Instance.pauseTimer();
					}
					if (_0024self__002418856.logging)
					{
					}
					_0024player_002418837 = PlayerControl.CurrentPlayer;
					if (!(_0024player_002418837 != null))
					{
						throw new AssertionFailedException("プレーヤーがいないよ...");
					}
					_0024cameraControl_002418838 = CameraControl.Current;
					_0024oldInput_002418839 = _0024self__002418856.setInputToKeepRunning(_0024player_002418837, _0024params_002418855.keepRunning);
					_0024cameraControl_002418838.FieldCameraActive = false;
					_0024sceneToJump_002418840 = ((_0024params_002418855.sceneToJump == null) ? QuestSession.GotoStage(_0024params_002418855.jumpFrom) : _0024params_002418855.sceneToJump);
					if (_0024sceneToJump_002418840 == null)
					{
						goto case 1;
					}
					_0024jumpTo_002418841 = QuestSession.JumpToDir;
					CharacterCache.Instance.dispose();
					_0024masterEffectPack_002418842 = MasterEffectPack.Instance;
					SceneChanger.Instance().dontReveal = true;
					if (!_0024self__002418856.logging)
					{
					}
					goto case 2;
				case 2:
					if (!SceneChanger.isSceneChanged)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024qm_002418843 = null;
					goto case 3;
				case 3:
					_0024qm_002418843 = (QuestMapper)UnityEngine.Object.FindObjectOfType(typeof(QuestMapper));
					if (_0024qm_002418843 != null)
					{
						goto case 4;
					}
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 4:
					if (!_0024qm_002418843.Initialized)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					if (_0024self__002418856.logging)
					{
					}
					_0024self__002418856.disablePlayerInput(_0024player_002418837);
					if (_0024params_002418855.putPlayerOnLastQuestInitializerPos)
					{
						_0024setPos_002418844 = QuestInitializer.LastMyPosition;
						_0024player_002418837.transform.position = _0024setPos_002418844;
						_0024player_002418837.forceToIdle();
						_0024player_002418837.clearTrajectory();
						_0024_00249449_002418851 = 0;
						goto case 5;
					}
					_0024pos_002418846 = null;
					_0024_0024wait_until_0024temp_00241712_002418847 = 60f;
					_0024_0024wait_until_0024temp_00241713_002418848 = Time.realtimeSinceStartup;
					goto case 6;
				case 5:
					if (_0024_00249449_002418851 < 3)
					{
						_0024i_002418845 = _0024_00249449_002418851;
						_0024_00249449_002418851++;
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					QuestInitializer.SetPoppetInitialPosition(_0024player_002418837.Poppets, _0024setPos_002418844);
					goto IL_0430;
				case 6:
					checked
					{
						if (!(_0024pos_002418846 != null) && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00241713_002418848 < _0024_0024wait_until_0024temp_00241712_002418847)
						{
							if (_0024self__002418856.logging)
							{
							}
							_0024_00249450_002418852 = 0;
							_0024_00249451_002418853 = (QuestLinkPosition[])UnityEngine.Object.FindObjectsOfType(typeof(QuestLinkPosition));
							for (_0024_00249452_002418854 = _0024_00249451_002418853.Length; _0024_00249450_002418852 < _0024_00249452_002418854; _0024_00249450_002418852++)
							{
								if (_0024_00249451_002418853[_0024_00249450_002418852].Direction == _0024jumpTo_002418841)
								{
									_0024pos_002418846 = _0024_00249451_002418853[_0024_00249450_002418852];
								}
							}
							result = (YieldDefault(6) ? 1 : 0);
							break;
						}
						if (!(_0024pos_002418846 != null))
						{
							throw new AssertionFailedException(new StringBuilder("QuestLinkPosition(").Append(QuestSession.JumpToDir).Append(")がみつからない").ToString());
						}
						if (_0024self__002418856.logging)
						{
						}
						if (_0024self__002418856.logging)
						{
						}
						_0024self__002418856.setPlayerPosition(_0024player_002418837, _0024pos_002418846);
						if (_0024self__002418856.logging)
						{
						}
						_0024self__002418856.setPoppetsPosition(_0024pos_002418846);
						goto IL_0430;
					}
				case 7:
					result = (YieldDefault(8) ? 1 : 0);
					break;
				case 8:
					if (_0024self__002418856.logging)
					{
					}
					_0024self__002418856.setupCameraForCurrentScene(_0024cameraControl_002418838, SceneChanger.CurrentSceneName);
					QuestSession.Save();
					ResourceClearner.CleanUpForQuest();
					result = (Yield(9, UnloadResource.UnloadUnusedAssets()) ? 1 : 0);
					break;
				case 9:
					SceneChanger.Instance().dontReveal = false;
					goto case 10;
				case 10:
					if (!SceneChanger.isFadeOut)
					{
						result = (YieldDefault(10) ? 1 : 0);
						break;
					}
					_0024self__002418856.enablePlayerInput(_0024player_002418837, _0024oldInput_002418839);
					_0024player_002418837.InputActive = true;
					_0024player_002418837.EnableControllerDeviceChecking = true;
					if (_0024params_002418855.controlQuestTimer)
					{
						QuestClearConditionChecker.Instance.unpauseTimer();
					}
					_0024self__002418856.jumpingNow = false;
					raise_JumpEndEvent();
					PlayerEventDispatcher.InvokeJumpEnd();
					YieldDefault(1);
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0430:
					_0024_0024sco_0024temp_00241714_002418850 = _0024self__002418856.cacheAllMonsters(_0024sceneToJump_002418840);
					if (_0024_0024sco_0024temp_00241714_002418850 != null)
					{
						result = (Yield(7, _0024self__002418856.StartCoroutine(_0024_0024sco_0024temp_00241714_002418850)) ? 1 : 0);
						break;
					}
					goto case 7;
				}
				return (byte)result != 0;
			}
		}

		internal JumpParams _0024params_002418857;

		internal QuestLinkRoutine _0024self__002418858;

		public _0024jumpRoutine_002418836(JumpParams @params, QuestLinkRoutine self_)
		{
			_0024params_002418857 = @params;
			_0024self__002418858 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024params_002418857, _0024self__002418858);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024cacheAllMonsters_002418859 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal CharacterCache _0024cache_002418860;

			internal MStageBattles _0024stgbtl_002418861;

			internal MStageMonsters _0024stgmon_002418862;

			internal MMonsters _0024mm_002418863;

			internal int _0024_00249458_002418864;

			internal MStageMonsters[] _0024_00249459_002418865;

			internal int _0024_00249460_002418866;

			internal int _0024_00249462_002418867;

			internal MStageBattles[] _0024_00249463_002418868;

			internal int _0024_00249464_002418869;

			internal MScenes _0024scn_002418870;

			public _0024(MScenes scn)
			{
				_0024scn_002418870 = scn;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (_0024scn_002418870 == null)
						{
							goto case 1;
						}
						_0024cache_002418860 = CharacterCache.Instance;
						_0024_00249462_002418867 = 0;
						_0024_00249463_002418868 = _0024scn_002418870.AllStageBattles;
						for (_0024_00249464_002418869 = _0024_00249463_002418868.Length; _0024_00249462_002418867 < _0024_00249464_002418869; _0024_00249462_002418867++)
						{
							_0024_00249458_002418864 = 0;
							_0024_00249459_002418865 = _0024_00249463_002418868[_0024_00249462_002418867].AllStageMonsters;
							for (_0024_00249460_002418866 = _0024_00249459_002418865.Length; _0024_00249458_002418864 < _0024_00249460_002418866; _0024_00249458_002418864++)
							{
								_0024mm_002418863 = _0024_00249459_002418865[_0024_00249458_002418864].MMonsterId;
								if (string.IsNullOrEmpty(_0024mm_002418863.PrefabName))
								{
									throw new AssertionFailedException(new StringBuilder().Append(_0024scn_002418870).Append("の MStageMonster ").Append(_0024_00249459_002418865[_0024_00249458_002418864])
										.Append(" のプレハブ名が空 master:")
										.Append(_0024mm_002418863)
										.ToString());
								}
								_0024cache_002418860.load(_0024mm_002418863.PrefabName);
							}
						}
						goto case 2;
					case 2:
						if (_0024cache_002418860.IsWorking)
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
				}
				return (byte)result != 0;
			}
		}

		internal MScenes _0024scn_002418871;

		public _0024cacheAllMonsters_002418859(MScenes scn)
		{
			_0024scn_002418871 = scn;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024scn_002418871);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024warpRoutine_002418872 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal MWarps _0024wdata_002418873;

			internal PlayerControl _0024player_002418874;

			internal PlayerInputControl _0024oldInput_002418875;

			internal CameraControl _0024cameraControl_002418876;

			internal float _0024_0024wait_sec_0024temp_00241716_002418877;

			internal QuestMapper _0024qm_002418878;

			internal object _0024pos_002418879;

			internal object _0024rot_002418880;

			internal IEnumerator _0024_0024sco_0024temp_00241717_002418881;

			internal object[] _0024_002413699_002418882;

			internal _0024warpRoutine_0024locals_002414421 _0024_0024locals_002418883;

			internal WarpParams _0024params_002418884;

			internal QuestLinkRoutine _0024self__002418885;

			public _0024(WarpParams @params, QuestLinkRoutine self_)
			{
				_0024params_002418884 = @params;
				_0024self__002418885 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002418883 = new _0024warpRoutine_0024locals_002414421();
					if (!_0024params_002418884.IsValid)
					{
						goto case 1;
					}
					_0024self__002418885.jumpingNow = true;
					_0024wdata_002418873 = _0024params_002418884.warpData;
					QuestClearConditionChecker.Instance.pauseTimer();
					PlayerEventDispatcher.InvokeJumpStart();
					_0024player_002418874 = PlayerControl.CurrentPlayer;
					if (!(_0024player_002418874 != null))
					{
						throw new AssertionFailedException("プレーヤーがいないよ...");
					}
					goto case 2;
				case 2:
					if (!_0024player_002418874.IsReady)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024oldInput_002418875 = _0024self__002418885.setInputToWarp(_0024player_002418874);
					_0024cameraControl_002418876 = CameraControl.Current;
					_0024cameraControl_002418876.FieldCameraActive = false;
					if (!_0024wdata_002418873.NoSmoke)
					{
						QuestAssets.Instance.instantiatePopSmoke(_0024player_002418874.transform.position, _0024player_002418874.transform.rotation);
					}
					_0024_0024wait_sec_0024temp_00241716_002418877 = 0.5f;
					goto case 3;
				case 3:
					if (_0024_0024wait_sec_0024temp_00241716_002418877 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241716_002418877 -= Time.deltaTime;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024_0024locals_002418883._0024warpOk = false;
					QuestSession.GotoStage(_0024wdata_002418873.SceneToWarp, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__QuestLinkRoutine_JumpStartEvent_0024callable78_002412_36___0024155.Adapt(new _0024warpRoutine_0024closure_00243005(_0024_0024locals_002418883).Invoke));
					if (!_0024_0024locals_002418883._0024warpOk)
					{
					}
					CharacterCache.Instance.dispose();
					SceneChanger.Instance().dontReveal = true;
					goto case 4;
				case 4:
					if (!SceneChanger.isSceneChanged)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024qm_002418878 = null;
					goto case 5;
				case 5:
					_0024qm_002418878 = (QuestMapper)UnityEngine.Object.FindObjectOfType(typeof(QuestMapper));
					if (_0024qm_002418878 != null)
					{
						goto case 6;
					}
					result = (YieldDefault(5) ? 1 : 0);
					break;
				case 6:
					if (!_0024qm_002418878.Initialized)
					{
						result = (YieldDefault(6) ? 1 : 0);
						break;
					}
					_0024_002413699_002418882 = GameLevelManager.ParseNpcPos(_0024wdata_002418873.PositionObject, Vector3.zero, Quaternion.identity);
					_0024pos_002418879 = _0024_002413699_002418882[0];
					_0024rot_002418880 = _0024_002413699_002418882[1];
					_0024player_002418874.transform.position = (Vector3)_0024pos_002418879;
					_0024player_002418874.transform.rotation = (Quaternion)_0024rot_002418880;
					_0024player_002418874.forceToIdle();
					_0024player_002418874.clearTrajectory();
					QuestInitializer.SetPoppetInitialPosition(_0024player_002418874.Poppets, (Vector3)_0024pos_002418879);
					result = (YieldDefault(7) ? 1 : 0);
					break;
				case 7:
					_0024_0024sco_0024temp_00241717_002418881 = _0024self__002418885.cacheAllMonsters(_0024wdata_002418873.SceneToWarp);
					if (_0024_0024sco_0024temp_00241717_002418881 != null)
					{
						result = (Yield(8, _0024self__002418885.StartCoroutine(_0024_0024sco_0024temp_00241717_002418881)) ? 1 : 0);
						break;
					}
					goto case 8;
				case 8:
					if (!_0024wdata_002418873.NoSmoke)
					{
						QuestAssets.Instance.instantiatePopSmoke((Vector3)_0024pos_002418879, Quaternion.identity);
					}
					SceneChanger.Instance().dontReveal = false;
					if (_0024self__002418885.logging)
					{
					}
					_0024self__002418885.setupCameraForCurrentScene(_0024cameraControl_002418876, SceneChanger.CurrentSceneName);
					QuestSession.Save();
					goto case 9;
				case 9:
					if (!SceneChanger.isFadeOut)
					{
						result = (YieldDefault(9) ? 1 : 0);
						break;
					}
					_0024self__002418885.restorePlayerInput(_0024player_002418874, _0024oldInput_002418875);
					_0024player_002418874.InputActive = true;
					QuestClearConditionChecker.Instance.unpauseTimer();
					_0024self__002418885.jumpingNow = false;
					PlayerEventDispatcher.InvokeJumpEnd();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal WarpParams _0024params_002418886;

		internal QuestLinkRoutine _0024self__002418887;

		public _0024warpRoutine_002418872(WarpParams @params, QuestLinkRoutine self_)
		{
			_0024params_002418886 = @params;
			_0024self__002418887 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024params_002418886, _0024self__002418887);
		}
	}

	[NonSerialized]
	private static QuestLinkRoutine __instance;

	[NonSerialized]
	protected static bool quitApp;

	private bool jumpingNow;

	private bool logging;

	[NonSerialized]
	private static __QuestLinkRoutine_JumpStartEvent_0024callable78_002412_36__ _0024event_0024JumpStartEvent;

	[NonSerialized]
	private static __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024event_0024JumpEndEvent;

	public static QuestLinkRoutine Instance
	{
		get
		{
			QuestLinkRoutine _instance;
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
				__instance = ((QuestLinkRoutine)UnityEngine.Object.FindObjectOfType(typeof(QuestLinkRoutine))) as QuestLinkRoutine;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static QuestLinkRoutine CurrentInstance => __instance;

	public bool IsJumpingNow => jumpingNow;

	public static event __QuestLinkRoutine_JumpStartEvent_0024callable78_002412_36__ JumpStartEvent
	{
		add
		{
			_0024event_0024JumpStartEvent = (__QuestLinkRoutine_JumpStartEvent_0024callable78_002412_36__)Delegate.Combine(_0024event_0024JumpStartEvent, value);
		}
		remove
		{
			_0024event_0024JumpStartEvent = (__QuestLinkRoutine_JumpStartEvent_0024callable78_002412_36__)Delegate.Remove(_0024event_0024JumpStartEvent, value);
		}
	}

	public static event __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ JumpEndEvent
	{
		add
		{
			_0024event_0024JumpEndEvent = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)Delegate.Combine(_0024event_0024JumpEndEvent, value);
		}
		remove
		{
			_0024event_0024JumpEndEvent = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)Delegate.Remove(_0024event_0024JumpEndEvent, value);
		}
	}

	public QuestLinkRoutine()
	{
		logging = true;
	}

	public void _0024singleton_0024awake_00241710()
	{
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00241710();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static QuestLinkRoutine _createInstance()
	{
		string text = "__" + "QuestLinkRoutine" + "__";
		GameObject gameObject = new GameObject(text);
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		QuestLinkRoutine questLinkRoutine = ExtensionsModule.SetComponent<QuestLinkRoutine>(gameObject);
		if ((bool)questLinkRoutine)
		{
			questLinkRoutine._createInstance_callback();
		}
		return questLinkRoutine;
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

	public void _0024singleton_0024appQuit_00241711()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00241711();
		quitApp = true;
	}

	[SpecialName]
	protected internal static void raise_JumpStartEvent(MScenes arg0)
	{
		_0024event_0024JumpStartEvent?.Invoke(arg0);
	}

	[SpecialName]
	protected internal static void raise_JumpEndEvent()
	{
		_0024event_0024JumpEndEvent?.Invoke();
	}

	public void jump(EnumMapLinkDir jumpFrom)
	{
		if (!jumpingNow)
		{
			JumpParams jumpParams = new JumpParams();
			jumpParams.jumpFrom = jumpFrom;
			StartCoroutine(jumpRoutine(jumpParams));
		}
	}

	public IEnumerator jumpRoutine(JumpParams @params)
	{
		return new _0024jumpRoutine_002418836(@params, this).GetEnumerator();
	}

	private PlayerInputControl setInputToKeepRunning(PlayerControl player, bool keepRunning)
	{
		PlayerInputControl inputControl = player.InputControl;
		if (keepRunning)
		{
			player.InputControl = new MapJumpInput(player);
		}
		player.EnableControllerDeviceChecking = false;
		return inputControl;
	}

	private PlayerInputControl setInputToWarp(PlayerControl player)
	{
		PlayerInputControl inputControl = player.InputControl;
		player.InputControl = new WarpInput(player);
		player.EnableControllerDeviceChecking = false;
		return inputControl;
	}

	private void disablePlayerInput(PlayerControl player)
	{
		player.InputActive = false;
	}

	private void setPlayerPosition(PlayerControl player, QuestLinkPosition pos)
	{
		player.transform.position = BattleUtil.AdjustYpos(pos.Position);
		player.forceToIdle();
	}

	private PlayerInputControl restorePlayerInput(PlayerControl player, PlayerInputControl oldInput)
	{
		if (oldInput == null)
		{
			throw new AssertionFailedException("oldInput != null");
		}
		player.InputControl = oldInput;
		player.EnableControllerDeviceChecking = true;
		return null;
	}

	private void enablePlayerInput(PlayerControl player, PlayerInputControl restoreInput)
	{
		player.InputControl = restoreInput;
		restoreInput?.clear();
		player.InputActive = true;
	}

	private void setPoppetsPosition(QuestLinkPosition pos)
	{
		BoxCollider component = pos.gameObject.GetComponent<BoxCollider>();
		int i = 0;
		AIControl[] array = (AIControl[])UnityEngine.Object.FindObjectsOfType(typeof(AIControl));
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			Vector3 vector = default(Vector3);
			vector = ((!(component == null)) ? QuestBattlePopPosGetter.randomPopPos(new GameObject[1] { pos.gameObject }) : QuestBattlePopPosGetter.randomPopPos(pos.Position, 4f, 4f));
			array[i].transform.position = vector;
			array[i].forceToIdle();
		}
	}

	private IEnumerator cacheAllMonsters(MScenes scn)
	{
		return new _0024cacheAllMonsters_002418859(scn).GetEnumerator();
	}

	public void warp(MWarps wm)
	{
		WarpParams warpParams = new WarpParams();
		warpParams.warpData = wm;
		IEnumerator enumerator = warpRoutine(warpParams);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public IEnumerator warpRoutine(WarpParams @params)
	{
		return new _0024warpRoutine_002418872(@params, this).GetEnumerator();
	}

	private void setupCameraForCurrentScene(CameraControl cc, string sceneName)
	{
		cc.setAreaParameter(sceneName);
		cc.FieldCameraActive = true;
		cc.fieldCameraReset();
	}
}
