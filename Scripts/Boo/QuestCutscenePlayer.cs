using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class QuestCutscenePlayer : MonoBehaviour
{
	[Serializable]
	internal class _0024playCutScene_0024locals_002414419
	{
		internal bool _0024endOfCS;
	}

	[Serializable]
	internal class _0024playCutScene_0024closure_00243012
	{
		internal _0024playCutScene_0024locals_002414419 _0024_0024locals_002414958;

		public _0024playCutScene_0024closure_00243012(_0024playCutScene_0024locals_002414419 _0024_0024locals_002414958)
		{
			this._0024_0024locals_002414958 = _0024_0024locals_002414958;
		}

		public void Invoke()
		{
			_0024_0024locals_002414958._0024endOfCS = true;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024playPreBattleCutscene_002418753 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal string _0024preCutScene_002418754;

			internal IEnumerator _0024_0024sco_0024temp_00241700_002418755;

			internal MStageBattles _0024stageBattle_002418756;

			internal QuestCutscenePlayer _0024self__002418757;

			public _0024(MStageBattles stageBattle, QuestCutscenePlayer self_)
			{
				_0024stageBattle_002418756 = stageBattle;
				_0024self__002418757 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024stageBattle_002418756 == null)
					{
						throw new AssertionFailedException("stageBattle != null");
					}
					_0024preCutScene_002418754 = _0024stageBattle_002418756.PreBattleCutScene;
					if (!string.IsNullOrEmpty(_0024preCutScene_002418754))
					{
						if (_0024stageBattle_002418756.PreBattleCutSceneFade)
						{
							FaderCore.Instance.fadeIn();
							goto case 2;
						}
						goto IL_008c;
					}
					goto case 3;
				case 2:
					if (!FaderCore.Instance.isCompleted)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto IL_008c;
				case 3:
					YieldDefault(1);
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_008c:
					_0024_0024sco_0024temp_00241700_002418755 = _0024self__002418757.playCutSceneFadeSafe(_0024preCutScene_002418754);
					if (_0024_0024sco_0024temp_00241700_002418755 != null)
					{
						result = (Yield(3, _0024self__002418757.StartCoroutine(_0024_0024sco_0024temp_00241700_002418755)) ? 1 : 0);
						break;
					}
					goto case 3;
				}
				return (byte)result != 0;
			}
		}

		internal MStageBattles _0024stageBattle_002418758;

		internal QuestCutscenePlayer _0024self__002418759;

		public _0024playPreBattleCutscene_002418753(MStageBattles stageBattle, QuestCutscenePlayer self_)
		{
			_0024stageBattle_002418758 = stageBattle;
			_0024self__002418759 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024stageBattle_002418758, _0024self__002418759);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024playPostBattleCutscene_002418760 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal float _0024_0024wait_until_0024temp_00241701_002418761;

			internal float _0024_0024wait_until_0024temp_00241702_002418762;

			internal string _0024postCutScene_002418763;

			internal IEnumerator _0024_0024sco_0024temp_00241703_002418764;

			internal string _0024postPos_002418765;

			internal MStageBattles _0024stageBattle_002418766;

			internal PlayerControl _0024player_002418767;

			internal QuestCutscenePlayer _0024self__002418768;

			public _0024(MStageBattles stageBattle, PlayerControl player, QuestCutscenePlayer self_)
			{
				_0024stageBattle_002418766 = stageBattle;
				_0024player_002418767 = player;
				_0024self__002418768 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024stageBattle_002418766 == null)
					{
						throw new AssertionFailedException("stageBattle != null");
					}
					if (_0024stageBattle_002418766.HasPostBattleCutScene)
					{
						_0024_0024wait_until_0024temp_00241701_002418761 = 10f;
						_0024_0024wait_until_0024temp_00241702_002418762 = Time.realtimeSinceStartup;
						goto case 2;
					}
					goto IL_0157;
				case 2:
					if (!IsAllEnemiesCompletelyDead() && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00241702_002418762 < _0024_0024wait_until_0024temp_00241701_002418761)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024stageBattle_002418766.PostBattleCutSceneFade)
					{
						FaderCore.Instance.fadeIn();
						goto case 3;
					}
					goto IL_00c5;
				case 3:
					if (!FaderCore.Instance.isCompleted)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto IL_00c5;
				case 4:
					_0024postPos_002418765 = _0024stageBattle_002418766.PostBattleCutScenePos;
					if (!string.IsNullOrEmpty(_0024postPos_002418765))
					{
						GameLevelManager.SetNpcPos(_0024player_002418767.transform, _0024postPos_002418765);
						_0024player_002418767.forceToIdle();
					}
					goto IL_0157;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00c5:
					_0024postCutScene_002418763 = _0024stageBattle_002418766.PostBattleCutScene;
					_0024_0024sco_0024temp_00241703_002418764 = _0024self__002418768.playCutSceneFadeSafe(_0024postCutScene_002418763);
					if (_0024_0024sco_0024temp_00241703_002418764 != null)
					{
						result = (Yield(4, _0024self__002418768.StartCoroutine(_0024_0024sco_0024temp_00241703_002418764)) ? 1 : 0);
						break;
					}
					goto case 4;
					IL_0157:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal MStageBattles _0024stageBattle_002418769;

		internal PlayerControl _0024player_002418770;

		internal QuestCutscenePlayer _0024self__002418771;

		public _0024playPostBattleCutscene_002418760(MStageBattles stageBattle, PlayerControl player, QuestCutscenePlayer self_)
		{
			_0024stageBattle_002418769 = stageBattle;
			_0024player_002418770 = player;
			_0024self__002418771 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024stageBattle_002418769, _0024player_002418770, _0024self__002418771);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024playCutSceneFadeSafe_002418772 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241704_002418773;

			internal string _0024cutscene_002418774;

			internal QuestCutscenePlayer _0024self__002418775;

			public _0024(string cutscene, QuestCutscenePlayer self_)
			{
				_0024cutscene_002418774 = cutscene;
				_0024self__002418775 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024sco_0024temp_00241704_002418773 = _0024self__002418775.playCutScene(_0024cutscene_002418774, FaderCore.Instance.fadeOut);
					if (_0024_0024sco_0024temp_00241704_002418773 != null)
					{
						result = (Yield(2, _0024self__002418775.StartCoroutine(_0024_0024sco_0024temp_00241704_002418773)) ? 1 : 0);
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

		internal string _0024cutscene_002418776;

		internal QuestCutscenePlayer _0024self__002418777;

		public _0024playCutSceneFadeSafe_002418772(string cutscene, QuestCutscenePlayer self_)
		{
			_0024cutscene_002418776 = cutscene;
			_0024self__002418777 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024cutscene_002418776, _0024self__002418777);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024playCutScene_002418778 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal CutSceneManager _0024cs_002418779;

			internal bool _0024readyInvoked_002418780;

			internal _0024playCutScene_0024locals_002414419 _0024_0024locals_002418781;

			internal string _0024cutSceneName_002418782;

			internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024readyHandler_002418783;

			public _0024(string cutSceneName, __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ readyHandler)
			{
				_0024cutSceneName_002418782 = cutSceneName;
				_0024readyHandler_002418783 = readyHandler;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002418781 = new _0024playCutScene_0024locals_002414419();
					if (string.IsNullOrEmpty(_0024cutSceneName_002418782))
					{
						goto case 1;
					}
					_0024cs_002418779 = CutSceneManager.CutSceneEx(_0024cutSceneName_002418782, null, _0024cutSceneName_002418782, autoStart: true);
					_0024_0024locals_002418781._0024endOfCS = false;
					_0024cs_002418779.CloseHandler = new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024playCutScene_0024closure_00243012(_0024_0024locals_002418781).Invoke);
					if (!_0024cs_002418779.autoStartFlag)
					{
						_0024cs_002418779.StartCutScene();
					}
					_0024readyInvoked_002418780 = false;
					goto IL_00ed;
				case 2:
					if (CutSceneManager.Instance.IsSceneReady && !_0024readyInvoked_002418780)
					{
						if (_0024readyHandler_002418783 != null)
						{
							_0024readyHandler_002418783();
						}
						_0024readyInvoked_002418780 = true;
					}
					goto IL_00ed;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00ed:
					if (!_0024_0024locals_002418781._0024endOfCS)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024readyInvoked_002418780 && _0024readyHandler_002418783 != null)
					{
						_0024readyHandler_002418783();
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024cutSceneName_002418784;

		internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024readyHandler_002418785;

		public _0024playCutScene_002418778(string cutSceneName, __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ readyHandler)
		{
			_0024cutSceneName_002418784 = cutSceneName;
			_0024readyHandler_002418785 = readyHandler;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024cutSceneName_002418784, _0024readyHandler_002418785);
		}
	}

	[NonSerialized]
	private static QuestCutscenePlayer __instance;

	[NonSerialized]
	protected static bool quitApp;

	public static QuestCutscenePlayer Instance
	{
		get
		{
			QuestCutscenePlayer _instance;
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
				__instance = ((QuestCutscenePlayer)UnityEngine.Object.FindObjectOfType(typeof(QuestCutscenePlayer))) as QuestCutscenePlayer;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static QuestCutscenePlayer CurrentInstance => __instance;

	public void _0024singleton_0024awake_00241698()
	{
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00241698();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static QuestCutscenePlayer _createInstance()
	{
		string text = "__" + "QuestCutscenePlayer" + "__";
		GameObject gameObject = new GameObject(text);
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		QuestCutscenePlayer questCutscenePlayer = ExtensionsModule.SetComponent<QuestCutscenePlayer>(gameObject);
		if ((bool)questCutscenePlayer)
		{
			questCutscenePlayer._createInstance_callback();
		}
		return questCutscenePlayer;
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

	public void _0024singleton_0024appQuit_00241699()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00241699();
		quitApp = true;
	}

	public IEnumerator playPreBattleCutscene(MStageBattles stageBattle)
	{
		return new _0024playPreBattleCutscene_002418753(stageBattle, this).GetEnumerator();
	}

	public IEnumerator playPostBattleCutscene(MStageBattles stageBattle, PlayerControl player)
	{
		return new _0024playPostBattleCutscene_002418760(stageBattle, player, this).GetEnumerator();
	}

	public IEnumerator playCutSceneFadeSafe(string cutscene)
	{
		return new _0024playCutSceneFadeSafe_002418772(cutscene, this).GetEnumerator();
	}

	public IEnumerator playCutScene(string cutSceneName, __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ readyHandler)
	{
		return new _0024playCutScene_002418778(cutSceneName, readyHandler).GetEnumerator();
	}

	private static bool IsAllEnemiesCompletelyDead()
	{
		int num = 0;
		string text = AIControl.TargetCharTag(is_player: true);
		int i = 0;
		BaseControl[] allControls = BaseControl.AllControls;
		checked
		{
			for (int length = allControls.Length; i < length; i++)
			{
				AIControl aIControl = allControls[i] as AIControl;
				if (!(aIControl == null) && aIControl.gameObject.tag == text && !aIControl.IS_END_OF_MOTION)
				{
					num++;
				}
			}
			return num <= 0;
		}
	}
}
