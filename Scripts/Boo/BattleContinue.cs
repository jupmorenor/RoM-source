using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class BattleContinue : MonoBehaviour
{
	[Serializable]
	public enum Choise
	{
		Selecting,
		Yes,
		No
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024watchPlayerRoutine_002418387 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241651_002418388;

			internal BattleContinue _0024self__002418389;

			public _0024(BattleContinue self_)
			{
				_0024self__002418389 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				default:
					if (_0024self__002418389.lastChoise != Choise.No)
					{
						if (_0024self__002418389.NeedContinueRoutine)
						{
							_0024_0024sco_0024temp_00241651_002418388 = _0024self__002418389.continueRoutine();
							if (_0024_0024sco_0024temp_00241651_002418388 != null)
							{
								result = (Yield(2, _0024self__002418389.StartCoroutine(_0024_0024sco_0024temp_00241651_002418388)) ? 1 : 0);
								break;
							}
						}
						goto case 2;
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

		internal BattleContinue _0024self__002418390;

		public _0024watchPlayerRoutine_002418387(BattleContinue self_)
		{
			_0024self__002418390 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002418390);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024continueRoutine_002418391 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal DialogManager _0024dlgMgr_002418392;

			internal float _0024wtm_002418393;

			internal float _0024_0024wait_until_0024temp_00241652_002418394;

			internal float _0024_0024wait_until_0024temp_00241653_002418395;

			internal float _0024_0024wait_sec_0024temp_00241654_002418396;

			internal IEnumerator _0024_0024sco_0024temp_00241655_002418397;

			internal UserData _0024ud_002418398;

			internal IEnumerator _0024_0024sco_0024temp_00241656_002418399;

			internal IEnumerator _0024_0024sco_0024temp_00241657_002418400;

			internal BattleContinue _0024self__002418401;

			public _0024(BattleContinue self_)
			{
				_0024self__002418401 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_InContinueSelectMode = true;
					_0024dlgMgr_002418392 = DialogManager.Instance;
					if (!(_0024dlgMgr_002418392 != null))
					{
						throw new AssertionFailedException("dlgMgr != null");
					}
					_0024self__002418401.init();
					if (!QuestSession.IsBattleStoppedBeforeContinue)
					{
						_0024self__002418401.saveCurrentSession(afterContinue: false, string.Empty);
					}
					if (_0024self__002418401.player != null && !_0024self__002418401.player.IS_ANIM_YARARE_DEAD)
					{
						_0024self__002418401.player.kill();
					}
					_0024wtm_002418393 = 0f;
					_0024_0024wait_until_0024temp_00241652_002418394 = 30f;
					_0024_0024wait_until_0024temp_00241653_002418395 = Time.realtimeSinceStartup;
					goto case 2;
				case 2:
					if (!_0024self__002418401.isStabilizedAllAICharacters() && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00241653_002418395 < _0024_0024wait_until_0024temp_00241652_002418394)
					{
						_0024wtm_002418393 += Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (QuestSession.HasBattleStoppedData)
					{
						goto case 3;
					}
					goto IL_0160;
				case 3:
					if (!QuestBattleStarter.IsPlaying)
					{
						_0024wtm_002418393 += Time.deltaTime;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto IL_0160;
				case 4:
					if (_0024_0024wait_sec_0024temp_00241654_002418396 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241654_002418396 -= Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					if (QuestSession.IsSessionEnded)
					{
						_InContinueSelectMode = false;
						goto case 1;
					}
					PlayerEventDispatcher.InvokePause();
					_0024self__002418401.checkRetire = true;
					goto case 6;
				case 5:
					if (DialogManager.LastResult != 1 && DialogManager.LastResult != 2)
					{
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					if (DialogManager.LastResult == 1)
					{
						_0024dlgMgr_002418392.OnButton(0);
						_0024_0024sco_0024temp_00241655_002418397 = _0024self__002418401.confRoutine(_0024dlgMgr_002418392);
						if (_0024_0024sco_0024temp_00241655_002418397 != null)
						{
							result = (Yield(6, _0024self__002418401.StartCoroutine(_0024_0024sco_0024temp_00241655_002418397)) ? 1 : 0);
							break;
						}
					}
					else if (DialogManager.LastResult == 2)
					{
						_0024dlgMgr_002418392.OnButton(0);
						_0024ud_002418398 = UserData.Current;
						if (0 < _0024ud_002418398.FayStone)
						{
							_0024self__002418401.openConfirmationDialog(_0024dlgMgr_002418392);
							goto case 7;
						}
						_0024_0024sco_0024temp_00241657_002418400 = _0024self__002418401.buyFaystoneRoutine();
						if (_0024_0024sco_0024temp_00241657_002418400 != null)
						{
							result = (Yield(9, _0024self__002418401.StartCoroutine(_0024_0024sco_0024temp_00241657_002418400)) ? 1 : 0);
							break;
						}
					}
					goto case 6;
				case 7:
					if (DialogManager.LastResult != 1 && DialogManager.LastResult != 2)
					{
						result = (YieldDefault(7) ? 1 : 0);
						break;
					}
					if (DialogManager.LastResult == 2)
					{
						_0024_0024sco_0024temp_00241656_002418399 = _0024self__002418401.yesRoutine(_0024dlgMgr_002418392);
						if (_0024_0024sco_0024temp_00241656_002418399 != null)
						{
							result = (Yield(8, _0024self__002418401.StartCoroutine(_0024_0024sco_0024temp_00241656_002418399)) ? 1 : 0);
							break;
						}
						goto case 8;
					}
					goto case 6;
				case 8:
					if (_0024self__002418401.lastChoise == Choise.Yes)
					{
						goto IL_0381;
					}
					goto case 6;
				case 6:
				case 9:
					if (_0024self__002418401.checkRetire)
					{
						_0024self__002418401.openDialog(_0024dlgMgr_002418392);
						goto case 5;
					}
					goto IL_0381;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0160:
					_0024_0024wait_sec_0024temp_00241654_002418396 = Mathf.Max(3f - _0024wtm_002418393, 0f);
					goto case 4;
					IL_0381:
					PlayerEventDispatcher.InvokeUnpause();
					_0024self__002418401.end();
					_InContinueSelectMode = false;
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal BattleContinue _0024self__002418402;

		public _0024continueRoutine_002418391(BattleContinue self_)
		{
			_0024self__002418402 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002418402);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024confRoutine_002418403 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal DialogManager _0024dlgMgr_002418404;

			internal BattleContinue _0024self__002418405;

			public _0024(DialogManager dlgMgr, BattleContinue self_)
			{
				_0024dlgMgr_002418404 = dlgMgr;
				_0024self__002418405 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024dlgMgr_002418404.OnButton(0);
					_0024self__002418405.dialog = _0024dlgMgr_002418404.OpenDialog(_0024self__002418405.retireText, _0024self__002418405.retireTitle, DialogManager.MB_FLAG.MB_NONE, new string[2] { "いいえ", "はい" }).GetComponent<Dialog>();
					goto case 2;
				case 2:
					if (DialogManager.LastResult == 0)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (DialogManager.LastResult == 1)
					{
						goto case 1;
					}
					_0024dlgMgr_002418404.OnButton(0);
					_0024self__002418405.dialog = _0024dlgMgr_002418404.OpenDialog(_0024self__002418405.retireFinalText, _0024self__002418405.retireFinalTitle, DialogManager.MB_FLAG.MB_NONE, new string[1] { "OK" }).GetComponent<Dialog>();
					goto case 3;
				case 3:
					if (DialogManager.LastResult == 0)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__002418405.noRoutine(_0024dlgMgr_002418404);
					_0024self__002418405.checkRetire = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal DialogManager _0024dlgMgr_002418406;

		internal BattleContinue _0024self__002418407;

		public _0024confRoutine_002418403(DialogManager dlgMgr, BattleContinue self_)
		{
			_0024dlgMgr_002418406 = dlgMgr;
			_0024self__002418407 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024dlgMgr_002418406, _0024self__002418407);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024yesRoutine_002418408 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ApiContinue _0024req_002418409;

			internal DialogManager _0024dlgMgr_002418410;

			internal BattleContinue _0024self__002418411;

			public _0024(DialogManager dlgMgr, BattleContinue self_)
			{
				_0024dlgMgr_002418410 = dlgMgr;
				_0024self__002418411 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req_002418409 = new ApiContinue();
					_0024self__002418411.saveCurrentSession(afterContinue: true, _0024req_002418409.ApiKey);
					MerlinServer.Request(_0024req_002418409);
					goto case 2;
				case 2:
					if (!_0024req_002418409.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024req_002418409.IsOk)
					{
						_0024self__002418411.noRoutine(_0024dlgMgr_002418410);
						goto case 1;
					}
					ReviveForBattleContinue(_0024self__002418411.player);
					DownAllEnemiesWithEffect(_0024self__002418411.player);
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					_0024self__002418411.lastChoise = Choise.Yes;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal DialogManager _0024dlgMgr_002418412;

		internal BattleContinue _0024self__002418413;

		public _0024yesRoutine_002418408(DialogManager dlgMgr, BattleContinue self_)
		{
			_0024dlgMgr_002418412 = dlgMgr;
			_0024self__002418413 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024dlgMgr_002418412, _0024self__002418413);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024buyFaystoneRoutine_002418414 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ _0024onEnd_002418415;

			internal __GouseiSequense_S540_init_0024callable40_002410_5__ _0024buyCoroutine_002418416;

			internal IEnumerator _0024_0024sco_0024temp_00241658_002418417;

			internal BattleContinue _0024self__002418418;

			public _0024(BattleContinue self_)
			{
				_0024self__002418418 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					BattleHUDWave.hide();
					_0024self__002418418.uiParent = _0024self__002418418.findTransform("Camera/0 Main/AnchorCenter");
					_0024self__002418418.hudParent = _0024self__002418418.findTransform("1 HUD/Panel");
					_0024self__002418418.endBuyFaystone = false;
					_0024onEnd_002418415 = delegate
					{
						_0024self__002418418.stoneList.gameObject.SetActive(value: false);
						_0024self__002418418.stoneList.Close();
						_0024self__002418418.endBuyFaystone = true;
					};
					if (!_0024self__002418418.stoneList)
					{
						_0024self__002418418.stoneList = StoneList.Create(_0024self__002418418.uiParent, _0024onEnd_002418415);
					}
					_0024self__002418418.stoneList.CreateBackButton(_0024self__002418418.stoneList.gameObject, _0024self__002418418.hudParent);
					_0024self__002418418.stoneList.gameObject.SetActive(value: false);
					ButtonBackHUD.SetActive(setActive: false);
					_0024buyCoroutine_002418416 = () => new _0024_0024buyFaystoneRoutine_0024buyCoroutine_00243007_002418420(_0024self__002418418).GetEnumerator();
					_0024_0024sco_0024temp_00241658_002418417 = _0024buyCoroutine_002418416();
					if (_0024_0024sco_0024temp_00241658_002418417 != null)
					{
						result = (Yield(2, _0024self__002418418.StartCoroutine(_0024_0024sco_0024temp_00241658_002418417)) ? 1 : 0);
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

		internal BattleContinue _0024self__002418419;

		public _0024buyFaystoneRoutine_002418414(BattleContinue self_)
		{
			_0024self__002418419 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002418419);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024buyFaystoneRoutine_0024buyCoroutine_00243007_002418420 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal BattleContinue _0024self__002418421;

			public _0024(BattleContinue self_)
			{
				_0024self__002418421 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002418421.stoneList.ShowDialog(StoneList.DIALOG_MODE.Buy);
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
				case 3:
					if (MerlinServer.Instance.IsBusy)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto case 4;
				case 4:
				case 5:
				case 6:
					if (!_0024self__002418421.endBuyFaystone && (bool)_0024self__002418421.stoneList)
					{
						if (!_0024self__002418421.stoneList.canStarted)
						{
							result = (YieldDefault(4) ? 1 : 0);
							break;
						}
						if (_0024self__002418421.stoneList.IsDialogUpdating(null))
						{
							result = (YieldDefault(5) ? 1 : 0);
							break;
						}
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

		internal BattleContinue _0024self__002418422;

		public _0024_0024buyFaystoneRoutine_0024buyCoroutine_00243007_002418420(BattleContinue self_)
		{
			_0024self__002418422 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002418422);
		}
	}

	[NonSerialized]
	private static bool _InContinueSelectMode;

	private Choise lastChoise;

	private Dialog dialog;

	private PlayerControl player;

	private StoneList stoneList;

	private Transform uiParent;

	private Transform hudParent;

	protected bool checkRetire;

	protected bool endBuyFaystone;

	public bool Determined => lastChoise != Choise.Selecting;

	public bool ChoosedYes => lastChoise == Choise.Yes;

	public bool ChoosedNo => lastChoise == Choise.No;

	private string continueTitle => dialogText("$d-mboard-{0}-continue-title");

	private string continueMessage => dialogText("$d-mboard-{0}-continue-message");

	private string continueConfirmationTitle => dialogText("$d-mboard-{0}-confirm-title");

	private string continueConfirmationMessage => dialogText("$d-mboard-{0}-confirm-message");

	private string continueConfirmationYes => dialogText("$d-mboard-{0}-confirm-yes");

	private string continueConfirmationNo => dialogText("$d-mboard-{0}-confirm-no");

	private string yesText => dialogText("$d-mboard-{0}-continue-yes");

	private string noText => dialogText("$d-mboard-{0}-continue-no");

	private string retireTitle => dialogText("$d-mboard-{0}-retire-title");

	private string retireText => dialogText("$d-mboard-{0}-retire-text");

	private string retireFinalTitle => dialogText("$d-mboard-{0}-retire-final-title");

	private string retireFinalText => dialogText("$d-mboard-{0}-retire-final-text");

	private bool NeedContinueRoutine
	{
		get
		{
			int num;
			if (!QuestInitializer.IsInPlay)
			{
				num = 0;
			}
			else if (QuestLinkRoutine.Instance.IsJumpingNow)
			{
				num = 0;
			}
			else if (QuestSession.IsSessionEnded)
			{
				num = 0;
			}
			else
			{
				num = ((player != null) ? 1 : 0);
				if (num != 0)
				{
					num = (player.IsDead ? 1 : 0);
				}
			}
			return (byte)num != 0;
		}
	}

	public static bool IsRunning => _InContinueSelectMode;

	public PlayerControl Player
	{
		get
		{
			return player;
		}
		set
		{
			player = value;
		}
	}

	public BattleContinue()
	{
		lastChoise = Choise.Selecting;
	}

	private string dialogText(string tmpl)
	{
		string id = UIBasicUtility.SafeFormat(tmpl, "quest");
		MQuests quest = QuestSession.Quest;
		if (quest != null && quest.IsChallenge)
		{
			id = UIBasicUtility.SafeFormat(tmpl, "challenge");
		}
		MTexts mTexts = MTexts.Get(id);
		return (mTexts == null) ? string.Empty : mTexts.msg;
	}

	public void Start()
	{
		IEnumerator enumerator = watchPlayerRoutine();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator watchPlayerRoutine()
	{
		return new _0024watchPlayerRoutine_002418387(this).GetEnumerator();
	}

	private IEnumerator continueRoutine()
	{
		return new _0024continueRoutine_002418391(this).GetEnumerator();
	}

	private void init()
	{
		setAllAID540(b: false);
		player.resetAbnormalState();
		player.useHUD = false;
		BattleHUD.Hide();
		setAllCharNoHit();
		lastChoise = Choise.Selecting;
	}

	private void end()
	{
		if (lastChoise == Choise.Yes)
		{
			setAllAID540(b: true);
			unsetAllCharNoHit();
			QuestSession.ClearBattleSessionData();
			player.setBonusNoHit(3f);
		}
		BattleHUDWave.hide();
	}

	private void setAllCharNoHit()
	{
		int i = 0;
		MerlinActionControl[] array = (MerlinActionControl[])UnityEngine.Object.FindObjectsOfType(typeof(MerlinActionControl));
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			array[i].ActionParameters.setNoAttackHit();
		}
	}

	private void unsetAllCharNoHit()
	{
		int i = 0;
		MerlinActionControl[] array = (MerlinActionControl[])UnityEngine.Object.FindObjectsOfType(typeof(MerlinActionControl));
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			array[i].clearNoHitAndGuard();
		}
	}

	private bool isStabilizedAllAICharacters()
	{
		int num = 0;
		BaseControl[] allControls = BaseControl.AllControls;
		int length = allControls.Length;
		int result;
		while (true)
		{
			if (num < length)
			{
				if (allControls[num] is AIControl)
				{
					AIControl aIControl = allControls[num] as AIControl;
					if (!aIControl.IS_ANIM_IDLE && !aIControl.IS_ANIM_YARARE_DEAD && !aIControl.IS_ANIM_RUN)
					{
						result = 0;
						break;
					}
				}
				num = checked(num + 1);
				continue;
			}
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	private void setAllAID540(bool b)
	{
		int i = 0;
		AIControl[] array = (AIControl[])UnityEngine.Object.FindObjectsOfType(typeof(AIControl));
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			D540ScriptRunner component = array[i].gameObject.GetComponent<D540ScriptRunner>();
			component.enabled = b;
		}
	}

	private void openDialog(DialogManager dlgMgr)
	{
		UserData current = UserData.Current;
		string message = UIBasicUtility.SafeFormat(continueMessage, current.FayStone);
		dlgMgr.OnButton(0);
		dialog = dlgMgr.OpenDialog(message, continueTitle, DialogManager.MB_FLAG.MB_NONE, new string[2] { noText, yesText });
	}

	private void openConfirmationDialog(DialogManager dlgMgr)
	{
		dlgMgr.OnButton(0);
		dialog = dlgMgr.OpenDialog(continueConfirmationMessage, continueConfirmationTitle, DialogManager.MB_FLAG.MB_NONE, new string[2] { continueConfirmationNo, continueConfirmationYes });
	}

	private IEnumerator confRoutine(DialogManager dlgMgr)
	{
		return new _0024confRoutine_002418403(dlgMgr, this).GetEnumerator();
	}

	private void noRoutine(DialogManager dlgMgr)
	{
		if ((bool)dlgMgr)
		{
			dlgMgr.OnClose((Dialog)UnityEngine.Object.FindObjectOfType(typeof(Dialog)));
		}
		QuestClearConditionChecker.Instance.doFail();
		lastChoise = Choise.No;
	}

	private IEnumerator yesRoutine(DialogManager dlgMgr)
	{
		return new _0024yesRoutine_002418408(dlgMgr, this).GetEnumerator();
	}

	public static void ReviveForBattleContinue(PlayerControl player)
	{
		if (!(player == null))
		{
			player.useHUD = true;
			BattleHUD.Show();
			player.reviveForContinue();
			player.revivePoppetsForContinue();
			if (QuestBattleStarter.IsPlaying)
			{
				player.setBattleMode();
			}
		}
	}

	public static void DownAllEnemiesWithEffect(PlayerControl player)
	{
		DownAllEnemies();
		if (player != null)
		{
			player.emitContinueAttackEffect();
		}
	}

	public static void DownAllEnemies()
	{
		int i = 0;
		BaseControl[] allControls = BaseControl.AllControls;
		for (int length = allControls.Length; i < length; i = checked(i + 1))
		{
			AIControl aIControl = allControls[i] as AIControl;
			if (!(aIControl == null) && !aIControl.IsPlayer && !aIControl.IsDead)
			{
				aIControl.playAnimationByType(PlayerAnimationTypes.YarareDown);
			}
		}
	}

	private Transform findTransform(string objName)
	{
		GameObject gameObject = GameObject.Find(objName);
		if (!(gameObject != null))
		{
			throw new AssertionFailedException(new StringBuilder().Append(objName).Append("が見つからない！").ToString());
		}
		return gameObject.transform;
	}

	private IEnumerator buyFaystoneRoutine()
	{
		return new _0024buyFaystoneRoutine_002418414(this).GetEnumerator();
	}

	private void saveCurrentSession(bool afterContinue, string continueApiKey)
	{
		QuestBattleStarter.WriteSessionIfPlaying(afterContinue, continueApiKey);
		QuestSession.Save();
	}

	internal void _0024buyFaystoneRoutine_0024onEnd_00243006(bool cancel)
	{
		stoneList.gameObject.SetActive(value: false);
		stoneList.Close();
		endBuyFaystone = true;
	}

	internal IEnumerator _0024buyFaystoneRoutine_0024buyCoroutine_00243007()
	{
		return new _0024_0024buyFaystoneRoutine_0024buyCoroutine_00243007_002418420(this).GetEnumerator();
	}
}
