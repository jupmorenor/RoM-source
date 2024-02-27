using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using GameAsset;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class ColosseumBattleControl : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002417326 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241424_002417327;

			internal IEnumerator _0024_0024sco_0024temp_00241425_002417328;

			internal IEnumerator _0024_0024sco_0024temp_00241426_002417329;

			internal IEnumerator _0024_0024sco_0024temp_00241427_002417330;

			internal IEnumerator _0024_0024sco_0024temp_00241428_002417331;

			internal IEnumerator _0024_0024sco_0024temp_00241429_002417332;

			internal IEnumerator _0024_0024sco_0024temp_00241430_002417333;

			internal IEnumerator _0024_0024sco_0024temp_00241431_002417334;

			internal ColosseumBattleControl _0024self__002417335;

			public _0024(ColosseumBattleControl self_)
			{
				_0024self__002417335 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002417335.battleTimer = 60f;
					_LastBattleResult.clear();
					SceneDontDestroyObject.dontDestroyOnLoad(_0024self__002417335.gameObject);
					SQEX_SoundPlayer.Instance.StopBgm(2000);
					_0024self__002417335.commonSeLoad();
					_0024_0024sco_0024temp_00241424_002417327 = _0024self__002417335.loadBattleScene("colosseum");
					if (_0024_0024sco_0024temp_00241424_002417327 != null)
					{
						result = (Yield(2, _0024self__002417335.StartCoroutine(_0024_0024sco_0024temp_00241424_002417327)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					SceneChanger.Instance().dontReveal = true;
					_0024self__002417335.initHUD();
					_0024_0024sco_0024temp_00241425_002417328 = _0024self__002417335.waitForLoadHUD();
					if (_0024_0024sco_0024temp_00241425_002417328 != null)
					{
						result = (Yield(3, _0024self__002417335.StartCoroutine(_0024_0024sco_0024temp_00241425_002417328)) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					_0024self__002417335.initCamera();
					_0024_0024sco_0024temp_00241426_002417329 = _0024self__002417335.initTeams();
					if (_0024_0024sco_0024temp_00241426_002417329 != null)
					{
						_0024self__002417335.StartCoroutine(_0024_0024sco_0024temp_00241426_002417329);
					}
					_0024self__002417335.initBattleEventListener();
					_0024self__002417335.initHitPointMiniBars();
					SceneChanger.Instance().dontReveal = false;
					_0024_0024sco_0024temp_00241427_002417330 = _0024self__002417335.startHUD();
					if (_0024_0024sco_0024temp_00241427_002417330 != null)
					{
						result = (Yield(4, _0024self__002417335.StartCoroutine(_0024_0024sco_0024temp_00241427_002417330)) ? 1 : 0);
						break;
					}
					goto case 4;
				case 4:
					_0024_0024sco_0024temp_00241428_002417331 = _0024self__002417335.waitForInitTeams();
					if (_0024_0024sco_0024temp_00241428_002417331 != null)
					{
						result = (Yield(5, _0024self__002417335.StartCoroutine(_0024_0024sco_0024temp_00241428_002417331)) ? 1 : 0);
						break;
					}
					goto case 5;
				case 5:
					_0024self__002417335.startBattle();
					_0024self__002417335.startBGM();
					_0024_0024sco_0024temp_00241429_002417332 = _0024self__002417335.play();
					if (_0024_0024sco_0024temp_00241429_002417332 != null)
					{
						result = (Yield(6, _0024self__002417335.StartCoroutine(_0024_0024sco_0024temp_00241429_002417332)) ? 1 : 0);
						break;
					}
					goto case 6;
				case 6:
					_0024self__002417335.stopBattleEventListener();
					SQEX_SoundPlayer.Instance.StopBgm(2000);
					_0024_0024sco_0024temp_00241430_002417333 = _0024self__002417335.waitForChainSkill();
					if (_0024_0024sco_0024temp_00241430_002417333 != null)
					{
						result = (Yield(7, _0024self__002417335.StartCoroutine(_0024_0024sco_0024temp_00241430_002417333)) ? 1 : 0);
						break;
					}
					goto case 7;
				case 7:
					_0024self__002417335.stopBattle();
					_0024_0024sco_0024temp_00241431_002417334 = _0024self__002417335.result();
					if (_0024_0024sco_0024temp_00241431_002417334 != null)
					{
						result = (Yield(8, _0024self__002417335.StartCoroutine(_0024_0024sco_0024temp_00241431_002417334)) ? 1 : 0);
						break;
					}
					goto case 8;
				case 8:
					SceneChanger.Change(_0024self__002417335.nextScene);
					UnityEngine.Object.Destroy(_0024self__002417335.gameObject);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal ColosseumBattleControl _0024self__002417336;

		public _0024main_002417326(ColosseumBattleControl self_)
		{
			_0024self__002417336 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002417336);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024loadBattleScene_002417337 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024sceneName_002417338;

			public _0024(string sceneName)
			{
				_0024sceneName_002417338 = sceneName;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					SceneChanger.Change(_0024sceneName_002417338);
					goto case 2;
				case 2:
					if (!SceneChanger.isSceneChanged)
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

		internal string _0024sceneName_002417339;

		public _0024loadBattleScene_002417337(string sceneName)
		{
			_0024sceneName_002417339 = sceneName;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024sceneName_002417339);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024waitForLoadHUD_002417340 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241432_002417341;

			internal ColosseumBattleControl _0024self__002417342;

			public _0024(ColosseumBattleControl self_)
			{
				_0024self__002417342 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024sco_0024temp_00241432_002417341 = _0024self__002417342.colosseumUIRoot.WaitForLoad();
					if (_0024_0024sco_0024temp_00241432_002417341 != null)
					{
						result = (Yield(2, _0024self__002417342.StartCoroutine(_0024_0024sco_0024temp_00241432_002417341)) ? 1 : 0);
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

		internal ColosseumBattleControl _0024self__002417343;

		public _0024waitForLoadHUD_002417340(ColosseumBattleControl self_)
		{
			_0024self__002417343 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002417343);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024initTeams_002417344 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ColosseumTeam _0024team_002417345;

			internal ColosseumTeam _0024team_002417346;

			internal IEnumerator<ColosseumTeam> _0024_0024iterator_002413578_002417347;

			internal IEnumerator<ColosseumTeam> _0024_0024iterator_002413579_002417348;

			internal ColosseumBattleControl _0024self__002417349;

			public _0024(ColosseumBattleControl self_)
			{
				_0024self__002417349 = self_;
			}

			public override bool MoveNext()
			{
				bool flag;
				try
				{
					switch (_state)
					{
					default:
						_0024_0024iterator_002413578_002417347 = _0024self__002417349.teamList.GetEnumerator();
						try
						{
							while (_0024_0024iterator_002413578_002417347.MoveNext())
							{
								_0024team_002417345 = _0024_0024iterator_002413578_002417347.Current;
								_0024team_002417345.startSetup();
							}
						}
						finally
						{
							_0024_0024iterator_002413578_002417347.Dispose();
						}
						_0024_0024iterator_002413579_002417348 = _0024self__002417349.teamList.GetEnumerator();
						_state = 2;
						goto IL_00f2;
					case 3:
						if (!_0024team_002417346.IsEndOfInstantiation)
						{
							flag = YieldDefault(3);
							goto IL_0126;
						}
						_0024team_002417346.initSkill((MCoverSkills[])Builtins.array(typeof(MCoverSkills), _0024self__002417349.additionalCoverSkills));
						goto IL_00f2;
					case 1:
					case 2:
						break;
						IL_00f2:
						if (_0024_0024iterator_002413579_002417348.MoveNext())
						{
							_0024team_002417346 = _0024_0024iterator_002413579_002417348.Current;
							goto case 3;
						}
						_state = 1;
						_0024ensure2();
						YieldDefault(1);
						break;
					}
				}
				catch
				{
					//try-fault
					Dispose();
					throw;
				}
				int result = 0;
				goto IL_0127;
				IL_0126:
				result = (flag ? 1 : 0);
				goto IL_0127;
				IL_0127:
				return (byte)result != 0;
			}

			private void _0024ensure2()
			{
				_0024_0024iterator_002413579_002417348.Dispose();
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

		internal ColosseumBattleControl _0024self__002417350;

		public _0024initTeams_002417344(ColosseumBattleControl self_)
		{
			_0024self__002417350 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002417350);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024waitForInitTeams_002417351 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ColosseumTeam _0024team_002417352;

			internal float _0024_0024wait_until_0024temp_00241433_002417353;

			internal float _0024_0024wait_until_0024temp_00241434_002417354;

			internal IEnumerator<ColosseumTeam> _0024_0024iterator_002413580_002417355;

			internal ColosseumBattleControl _0024self__002417356;

			public _0024(ColosseumBattleControl self_)
			{
				_0024self__002417356 = self_;
			}

			public override bool MoveNext()
			{
				bool flag;
				try
				{
					switch (_state)
					{
					default:
						_0024_0024iterator_002413580_002417355 = _0024self__002417356.teamList.GetEnumerator();
						_state = 2;
						goto IL_009b;
					case 3:
						if (_0024team_002417352.IsEndOfInstantiation || !(Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00241434_002417354 < _0024_0024wait_until_0024temp_00241433_002417353))
						{
							goto IL_009b;
						}
						flag = YieldDefault(3);
						goto IL_00cf;
					case 1:
					case 2:
						break;
						IL_009b:
						if (_0024_0024iterator_002413580_002417355.MoveNext())
						{
							_0024team_002417352 = _0024_0024iterator_002413580_002417355.Current;
							_0024_0024wait_until_0024temp_00241433_002417353 = 10f;
							_0024_0024wait_until_0024temp_00241434_002417354 = Time.realtimeSinceStartup;
							goto case 3;
						}
						_state = 1;
						_0024ensure2();
						YieldDefault(1);
						break;
					}
				}
				catch
				{
					//try-fault
					Dispose();
					throw;
				}
				int result = 0;
				goto IL_00d0;
				IL_00cf:
				result = (flag ? 1 : 0);
				goto IL_00d0;
				IL_00d0:
				return (byte)result != 0;
			}

			private void _0024ensure2()
			{
				_0024_0024iterator_002413580_002417355.Dispose();
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

		internal ColosseumBattleControl _0024self__002417357;

		public _0024waitForInitTeams_002417351(ColosseumBattleControl self_)
		{
			_0024self__002417357 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002417357);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024startHUD_002417358 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241435_002417359;

			internal ColosseumBattleControl _0024self__002417360;

			public _0024(ColosseumBattleControl self_)
			{
				_0024self__002417360 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024sco_0024temp_00241435_002417359 = _0024self__002417360.colosseumUIRoot.StartHUD();
					if (_0024_0024sco_0024temp_00241435_002417359 != null)
					{
						result = (Yield(2, _0024self__002417360.StartCoroutine(_0024_0024sco_0024temp_00241435_002417359)) ? 1 : 0);
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

		internal ColosseumBattleControl _0024self__002417361;

		public _0024startHUD_002417358(ColosseumBattleControl self_)
		{
			_0024self__002417361 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002417361);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024play_002417362 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024dt_002417363;

			internal ColosseumTeam _0024team_002417364;

			internal IEnumerator<ColosseumTeam> _0024_0024iterator_002413582_002417365;

			internal ColosseumBattleControl _0024self__002417366;

			public _0024(ColosseumBattleControl self_)
			{
				_0024self__002417366 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__002417366.isEndOfBattle())
					{
						_0024dt_002417363 = Time.deltaTime;
						_0024_0024iterator_002413582_002417365 = _0024self__002417366.teamList.GetEnumerator();
						try
						{
							while (_0024_0024iterator_002413582_002417365.MoveNext())
							{
								_0024team_002417364 = _0024_0024iterator_002413582_002417365.Current;
								_0024team_002417364.updateBattle(_0024dt_002417363);
							}
						}
						finally
						{
							_0024_0024iterator_002413582_002417365.Dispose();
						}
						_0024self__002417366.battleTimer -= _0024dt_002417363;
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

		internal ColosseumBattleControl _0024self__002417367;

		public _0024play_002417362(ColosseumBattleControl self_)
		{
			_0024self__002417367 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002417367);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024waitForChainSkill_002417368 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (ChainSkillRoutine.IsPlaying)
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

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024result_002417369 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ColosseumTeam _0024playerTeam_002417370;

			internal ColosseumTeam _0024enemyTeam_002417371;

			internal bool _0024isWin_002417372;

			internal IEnumerator _0024_0024sco_0024temp_00241436_002417373;

			internal ColosseumBattleControl _0024self__002417374;

			public _0024(ColosseumBattleControl self_)
			{
				_0024self__002417374 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024playerTeam_002417370 = null;
						_0024enemyTeam_002417371 = null;
						if (_0024self__002417374.teamList[0].IsPlayerSide)
						{
							_0024playerTeam_002417370 = _0024self__002417374.teamList[0];
							_0024enemyTeam_002417371 = _0024self__002417374.teamList[1];
						}
						else
						{
							_0024playerTeam_002417370 = _0024self__002417374.teamList[1];
							_0024enemyTeam_002417371 = _0024self__002417374.teamList[0];
						}
						_0024isWin_002417372 = _0024playerTeam_002417370.Force > _0024enemyTeam_002417371.Force;
						_LastBattleResult.setResult(_0024isWin_002417372, (int)_0024self__002417374.teamList[0].Force, (int)_0024self__002417374.teamList[1].Force);
						_0024_0024sco_0024temp_00241436_002417373 = _0024self__002417374.colosseumUIRoot.ResultHUD(_0024isWin_002417372);
						if (_0024_0024sco_0024temp_00241436_002417373 != null)
						{
							result = (Yield(2, _0024self__002417374.StartCoroutine(_0024_0024sco_0024temp_00241436_002417373)) ? 1 : 0);
							break;
						}
						goto case 2;
					case 2:
						_0024self__002417374.colosseumCamera.enabled = false;
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

		internal ColosseumBattleControl _0024self__002417375;

		public _0024result_002417369(ColosseumBattleControl self_)
		{
			_0024self__002417375 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002417375);
		}
	}

	[NonSerialized]
	private const string BATTLE_SCENE_NAME = "colosseum";

	[NonSerialized]
	private const string HUD_PREFAB = "Prefab/HUD/Colosseum UI Root";

	[NonSerialized]
	private const string CAMERA_PREFAB = "Prefab/Colosseum/ColosseumMainCamera";

	[NonSerialized]
	private const int TEAM_NUM = 2;

	[NonSerialized]
	private static ColosseumBattleResult _LastBattleResult = new ColosseumBattleResult();

	private ColosseumBattleEventListener eventListener;

	private Boo.Lang.List<ColosseumTeam> teamList;

	private ColosseumCamera colosseumCamera;

	private ColosseumUIRoot colosseumUIRoot;

	private ApiColosseumBattleStart.Resp battleStartResponse;

	private string nextScene;

	private HashSet<MCoverSkills> additionalCoverSkills;

	private float battleTimer;

	private bool debugGUI;

	public int BattleTimer => Mathf.CeilToInt(battleTimer);

	public static ColosseumBattleResult LastBattleResult => _LastBattleResult;

	public ApiColosseumBattleStart.Resp BattleStartResponse
	{
		get
		{
			return battleStartResponse;
		}
		set
		{
			battleStartResponse = value;
		}
	}

	public string NextScene
	{
		get
		{
			return nextScene;
		}
		set
		{
			nextScene = value;
		}
	}

	public bool DebugGUI
	{
		get
		{
			return debugGUI;
		}
		set
		{
			debugGUI = value;
		}
	}

	public ColosseumBattleControl()
	{
		teamList = new Boo.Lang.List<ColosseumTeam>();
		nextScene = "ColosseumSelectTest";
		additionalCoverSkills = new HashSet<MCoverSkills>();
	}

	public static ColosseumBattleControl Create()
	{
		GameObject component = new GameObject("ColosseumBattleControl");
		ColosseumBattleControl colosseumBattleControl = ExtensionsModule.SetComponent<ColosseumBattleControl>(component);
		colosseumBattleControl.init();
		return colosseumBattleControl;
	}

	public void init()
	{
		init(new string[2] { "team0", "team1" });
	}

	public void init(string[] teamNames)
	{
		if (teamNames == null || teamNames.Length < 2)
		{
			throw new AssertionFailedException("(teamNames != null) and (len(teamNames) >= 2)");
		}
		IEnumerator<ColosseumTeam> enumerator = teamList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ColosseumTeam current = enumerator.Current;
				current.dispose();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		teamList.Clear();
		int num = 0;
		int num2 = 2;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			ColosseumTeam item = new ColosseumTeam(teamNames[RuntimeServices.NormalizeArrayIndex(teamNames, num3)], num3 == 0);
			teamList.Add(item);
		}
	}

	public void addMember(int teamId, RespPoppet ppt, RespWeapon wpn, bool isLeader)
	{
		if (0 > teamId || teamId >= ((ICollection)teamList).Count)
		{
			throw new AssertionFailedException("(0 <= teamId) and (teamId < len(teamList))");
		}
		if (ppt == null)
		{
			throw new AssertionFailedException("ppt != null");
		}
		ColosseumTeam colosseumTeam = teamList[teamId];
		Vector3 pos = _MemberInitialPos(teamId, colosseumTeam.MemberNum);
		teamList[teamId].add(ppt, wpn, pos, isLeader);
	}

	public void setTeamInfo(int teamId, string name, int level, double rankPoint, int rankId)
	{
		if (0 > teamId || teamId >= ((ICollection)teamList).Count)
		{
			throw new AssertionFailedException("(0 <= teamId) and (teamId < len(teamList))");
		}
		ColosseumTeam colosseumTeam = teamList[teamId];
		colosseumTeam.TeamInfo.userName = name;
		colosseumTeam.TeamInfo.userLevel = level;
		colosseumTeam.TeamInfo.rankPoint = rankPoint;
		colosseumTeam.TeamInfo.rankId = rankId;
	}

	private Vector3 _MemberInitialPos(int teamIndex, int memberIndex)
	{
		checked
		{
			int num = 5 - teamIndex * 10;
			int num2 = -3 + memberIndex * 3;
			return new Vector3(num, 0f, num2);
		}
	}

	public void addCoverSkill(MCoverSkills cskl)
	{
		if (cskl != null)
		{
			additionalCoverSkills.Add(cskl);
		}
	}

	public void exec()
	{
		if (((ICollection)teamList).Count < 2 || (teamList[0].MemberNum <= 0 && teamList[1].MemberNum <= 0))
		{
			defaultInit();
		}
		StartCoroutine(main());
	}

	public void Start()
	{
	}

	public void OnDestroy()
	{
		SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
		if (instance != null)
		{
			instance.UnloadSeType(6);
			instance.UnloadSeType(7);
			instance.UnloadSeType(1);
		}
		IEnumerator<ColosseumTeam> enumerator = teamList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ColosseumTeam current = enumerator.Current;
				current.dispose();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		teamList.Clear();
	}

	private void defaultInit()
	{
		init();
		addMember(0, new RespPoppet(10), new RespWeapon(2), isLeader: true);
		addMember(0, new RespPoppet(20), new RespWeapon(3), isLeader: false);
		addMember(0, new RespPoppet(30), new RespWeapon(4), isLeader: false);
		addMember(1, new RespPoppet(40), new RespWeapon(5), isLeader: true);
		addMember(1, new RespPoppet(80), new RespWeapon(6), isLeader: false);
		addMember(1, new RespPoppet(298), new RespWeapon(7), isLeader: false);
	}

	private IEnumerator main()
	{
		return new _0024main_002417326(this).GetEnumerator();
	}

	private void commonSeLoad()
	{
		GameSoundManager.Instance.LoadSeType(1);
		GameSoundManager.Instance.LoadSeGroup("e_common");
	}

	private IEnumerator loadBattleScene(string sceneName)
	{
		return new _0024loadBattleScene_002417337(sceneName).GetEnumerator();
	}

	private void initHUD()
	{
		GameObject gameObject = GameAssetModule.InstantiatePrefab("Prefab/HUD/Colosseum UI Root");
		colosseumUIRoot = gameObject.GetComponent<ColosseumUIRoot>();
		colosseumUIRoot.Init(this);
		colosseumUIRoot.SetTeamData(teamList[0], teamList[1]);
	}

	private IEnumerator waitForLoadHUD()
	{
		return new _0024waitForLoadHUD_002417340(this).GetEnumerator();
	}

	private IEnumerator initTeams()
	{
		return new _0024initTeams_002417344(this).GetEnumerator();
	}

	public IEnumerator waitForInitTeams()
	{
		return new _0024waitForInitTeams_002417351(this).GetEnumerator();
	}

	public void initHitPointMiniBars()
	{
		TargetHitPointBarMini.setDrawTime(999f);
	}

	private void initCamera()
	{
		GameObject gameObject = GameAssetModule.InstantiatePrefab("Prefab/Colosseum/ColosseumMainCamera");
		colosseumCamera = gameObject.GetComponent<ColosseumCamera>();
		colosseumCamera.Init();
		colosseumCamera.enabled = false;
	}

	private void initBattleEventListener()
	{
		eventListener = ExtensionsModule.SetComponent<ColosseumBattleEventListener>(gameObject);
		eventListener.setTeams(new ColosseumTeam[2]
		{
			teamList[0],
			teamList[1]
		});
		eventListener.setUpdateResult(_LastBattleResult);
	}

	private void stopBattleEventListener()
	{
		if (eventListener != null)
		{
			eventListener.enabled = false;
		}
	}

	private IEnumerator startHUD()
	{
		return new _0024startHUD_002417358(this).GetEnumerator();
	}

	private void startBattle()
	{
		IEnumerator<ColosseumTeam> enumerator = teamList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ColosseumTeam current = enumerator.Current;
				current.startBattle();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		colosseumCamera.enabled = true;
	}

	private void startBGM()
	{
		string text = null;
		if (BattleStartResponse != null && (BattleStartResponse.MaybePromoted || BattleStartResponse.MaybeDemoted))
		{
			string[] bgmList = SQEX_SoundPlayerData.bgmList;
			text = bgmList[RuntimeServices.NormalizeArrayIndex(bgmList, 7)];
		}
		else
		{
			string[] bgmList2 = SQEX_SoundPlayerData.bgmList;
			text = bgmList2[RuntimeServices.NormalizeArrayIndex(bgmList2, 6)];
		}
		float num;
		float num2;
		int num3;
		int num4;
		GameSoundManager.PlayBgmDirect(text, num = 1f, num2 = 0f, num3 = 0, num4 = -1);
	}

	private IEnumerator play()
	{
		return new _0024play_002417362(this).GetEnumerator();
	}

	private bool isEndOfBattle()
	{
		int num;
		bool flag;
		if (!(battleTimer > 0f))
		{
			num = 1;
		}
		else
		{
			IEnumerator<ColosseumTeam> enumerator = teamList.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ColosseumTeam current = enumerator.Current;
					if (!current.HasNoForce)
					{
						continue;
					}
					flag = true;
					goto IL_005a;
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			num = 0;
		}
		goto IL_005b;
		IL_005b:
		return (byte)num != 0;
		IL_005a:
		num = (flag ? 1 : 0);
		goto IL_005b;
	}

	private IEnumerator waitForChainSkill()
	{
		return new _0024waitForChainSkill_002417368().GetEnumerator();
	}

	private void stopBattle()
	{
		IEnumerator<ColosseumTeam> enumerator = teamList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ColosseumTeam current = enumerator.Current;
				current.stopBattle();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	private IEnumerator result()
	{
		return new _0024result_002417369(this).GetEnumerator();
	}

	public void OnLevelWasLoaded(int level)
	{
		if (SceneChanger.CurrentLoadingSceneName != "colosseum")
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public void OnGUI()
	{
		if (debugGUI && ((ICollection)teamList).Count > 0)
		{
			GUILayout.Space(20f);
			debugGUIChainSkillButtons();
			GUILayout.Space(20f);
			debugGUICharInfo();
		}
	}

	private void debugGUIChainSkillButtons()
	{
		ColosseumTeam colosseumTeam = teamList[0];
		int num = 0;
		int memberNum = colosseumTeam.MemberNum;
		if (memberNum < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < memberNum)
		{
			int num2 = num;
			num++;
			ColosseumTeamMember member = colosseumTeam.getMember(num2);
			GUILayout.Space(20f);
			if (GUILayout.Button(new StringBuilder().Append((object)num2).Append(" chain").ToString()))
			{
				member?.debugExecChainSkill();
			}
		}
	}

	private void debugGUICharInfo()
	{
		IEnumerator<ColosseumTeam> enumerator = teamList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ColosseumTeam current = enumerator.Current;
				GUILayout.Space(10f);
				string text = current.TeamName + "\n";
				int num = 0;
				int memberNum = current.MemberNum;
				if (memberNum < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num < memberNum)
				{
					int index = num;
					num++;
					ColosseumTeamMember member = current.getMember(index);
					AIControl aiControl = member.aiControl;
					if (aiControl != null)
					{
						text += new StringBuilder().Append(member.PoppetData).Append(" hp ").Append(aiControl.HitPoint)
							.Append("/")
							.Append(aiControl.MaxHitPoint)
							.Append(" magic:")
							.Append(member.MagicPoint)
							.Append("/")
							.Append(member.MaxMagicPoint)
							.Append("\n")
							.ToString();
					}
				}
				GUILayout.TextArea(text);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}
}
