using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class ColosseumBattleStartHUD : MonoBehaviour
{
	[Serializable]
	internal class _0024Play_0024locals_002414374
	{
		internal bool _0024playing;
	}

	[Serializable]
	internal class _0024Play_0024closure_00244383
	{
		internal _0024Play_0024locals_002414374 _0024_0024locals_002414854;

		public _0024Play_0024closure_00244383(_0024Play_0024locals_002414374 _0024_0024locals_002414854)
		{
			this._0024_0024locals_002414854 = _0024_0024locals_002414854;
		}

		public void Invoke(GameObject obj)
		{
			_0024_0024locals_002414854._0024playing = true;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TweenerIn_002417382 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241437_002417383;

			internal ColosseumBattleStartHUD _0024self__002417384;

			public _0024(ColosseumBattleStartHUD self_)
			{
				_0024self__002417384 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024sco_0024temp_00241437_002417383 = _0024self__002417384.WaitForLoad();
					if (_0024_0024sco_0024temp_00241437_002417383 != null)
					{
						result = (Yield(2, _0024self__002417384.StartCoroutine(_0024_0024sco_0024temp_00241437_002417383)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					UIAutoTweenerStandAloneEx.In(_0024self__002417384.gameObject);
					GameSoundManager.PlaySe(_0024self__002417384.playFightSE, 0);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal ColosseumBattleStartHUD _0024self__002417385;

		public _0024TweenerIn_002417382(ColosseumBattleStartHUD self_)
		{
			_0024self__002417385 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002417385);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024WaitForLoad_002417386 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_until_0024temp_00241438_002417387;

			internal float _0024_0024wait_until_0024temp_00241439_002417388;

			internal float _0024_0024wait_until_0024temp_00241440_002417389;

			internal float _0024_0024wait_until_0024temp_00241441_002417390;

			internal float _0024_0024wait_until_0024temp_00241442_002417391;

			internal float _0024_0024wait_until_0024temp_00241443_002417392;

			internal ColosseumBattleStartHUD _0024self__002417393;

			public _0024(ColosseumBattleStartHUD self_)
			{
				_0024self__002417393 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024wait_until_0024temp_00241438_002417387 = 2f;
					_0024_0024wait_until_0024temp_00241439_002417388 = Time.realtimeSinceStartup;
					goto case 2;
				case 2:
					if (!_0024self__002417393.leftTeam.IsIconLoaded() && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00241439_002417388 < _0024_0024wait_until_0024temp_00241438_002417387)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024_0024wait_until_0024temp_00241440_002417389 = 2f;
					_0024_0024wait_until_0024temp_00241441_002417390 = Time.realtimeSinceStartup;
					goto case 3;
				case 3:
					if (!_0024self__002417393.rightTeam.IsIconLoaded() && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00241441_002417390 < _0024_0024wait_until_0024temp_00241440_002417389)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024_0024wait_until_0024temp_00241442_002417391 = 2f;
					_0024_0024wait_until_0024temp_00241443_002417392 = Time.realtimeSinceStartup;
					goto case 4;
				case 4:
					if (!SQEX_SoundPlayer.Instance.IsLoadSe(_0024self__002417393.playFightSE) && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00241443_002417392 < _0024_0024wait_until_0024temp_00241442_002417391)
					{
						result = (YieldDefault(4) ? 1 : 0);
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

		internal ColosseumBattleStartHUD _0024self__002417394;

		public _0024WaitForLoad_002417386(ColosseumBattleStartHUD self_)
		{
			_0024self__002417394 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002417394);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Play_002417395 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241444_002417396;

			internal _0024Play_0024locals_002414374 _0024_0024locals_002417397;

			internal ColosseumBattleStartHUD _0024self__002417398;

			public _0024(ColosseumBattleStartHUD self_)
			{
				_0024self__002417398 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002417397 = new _0024Play_0024locals_002414374();
					_0024_0024locals_002417397._0024playing = false;
					result = (Yield(2, new WaitForSeconds(_0024self__002417398.startDelay)) ? 1 : 0);
					break;
				case 2:
					_0024_0024sco_0024temp_00241444_002417396 = _0024self__002417398.battleControl.waitForInitTeams();
					if (_0024_0024sco_0024temp_00241444_002417396 != null)
					{
						result = (Yield(3, _0024self__002417398.StartCoroutine(_0024_0024sco_0024temp_00241444_002417396)) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					UIAutoTweenerStandAloneEx.Out(_0024self__002417398.gameObject, new _0024Play_0024closure_00244383(_0024_0024locals_002417397).Invoke);
					goto case 4;
				case 4:
					if (!_0024_0024locals_002417397._0024playing)
					{
						result = (YieldDefault(4) ? 1 : 0);
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

		internal ColosseumBattleStartHUD _0024self__002417399;

		public _0024Play_002417395(ColosseumBattleStartHUD self_)
		{
			_0024self__002417399 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024self__002417399);
		}
	}

	public ColosseumBattleStartTeamHUD leftTeam;

	public ColosseumBattleStartTeamHUD rightTeam;

	public float startDelay;

	public UIAutoTweenerStandAloneEx autoTweener;

	public GameObject promoteFight;

	public string promoteFightSE;

	public GameObject demoteFight;

	public string demoteFightSE;

	public string startSE;

	private ColosseumBattleControl battleControl;

	private GameSoundManager sndmgr;

	private string playFightSE;

	private bool isInit;

	public ColosseumBattleStartHUD()
	{
		startDelay = 2f;
		promoteFightSE = "se_arena_fight_start";
		demoteFightSE = "se_arena_fight_start";
		startSE = "se_arena_fight_start";
		playFightSE = "se_arena_fight_start";
	}

	public void Awake()
	{
		sndmgr = GameSoundManager.Instance;
	}

	public void Init(ColosseumBattleControl setBattleControl)
	{
		isInit = true;
		battleControl = setBattleControl;
		ApiColosseumBattleStart.Resp battleStartResponse = battleControl.BattleStartResponse;
		if (battleStartResponse != null)
		{
			ShowFightType(battleStartResponse.MaybePromoted, battleStartResponse.MaybeDemoted);
		}
		else
		{
			ShowFightType(promoted: false, demoted: false);
		}
	}

	private void ShowFightType(bool promoted, bool demoted)
	{
		if (promoted)
		{
			UnityEngine.Object.Destroy(demoteFight.gameObject);
			playFightSE = promoteFightSE;
		}
		else if (demoted)
		{
			UnityEngine.Object.Destroy(promoteFight.gameObject);
			playFightSE = demoteFightSE;
		}
		else
		{
			UnityEngine.Object.Destroy(demoteFight.gameObject);
			UnityEngine.Object.Destroy(promoteFight.gameObject);
			playFightSE = startSE;
		}
		sndmgr.LoadSe(playFightSE);
	}

	public void SetTeamData(ColosseumTeam setLeft, ColosseumTeam setRight)
	{
		leftTeam.Init(setLeft);
		rightTeam.Init(setRight);
		StartCoroutine(TweenerIn());
	}

	public IEnumerator TweenerIn()
	{
		return new _0024TweenerIn_002417382(this).GetEnumerator();
	}

	public IEnumerator WaitForLoad()
	{
		return new _0024WaitForLoad_002417386(this).GetEnumerator();
	}

	public IEnumerator Play()
	{
		return new _0024Play_002417395(this).GetEnumerator();
	}

	public void OnDestroy()
	{
		if (isInit)
		{
			sndmgr.UnloadSe(playFightSE);
		}
	}
}
