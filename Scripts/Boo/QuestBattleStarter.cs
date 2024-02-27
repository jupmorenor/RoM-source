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
[RequireComponent(typeof(Collider))]
public class QuestBattleStarter : MonoBehaviour
{
	[Serializable]
	internal class _0024setQuestClearConditions_0024locals_002414411
	{
		internal QuestClearConditionChecker _0024qcc;
	}

	[Serializable]
	internal class _0024popEnemy_0024locals_002414412
	{
		internal Vector3 _0024pos;

		internal Quaternion _0024rot;

		internal Vector3 _0024altPopPos;
	}

	[Serializable]
	internal class _0024writeBattleSession_0024locals_002414413
	{
		internal QuestBattleSessionData _0024bd;
	}

	[Serializable]
	internal class _0024resetBattle_0024locals_002414414
	{
		internal Vector3 _0024playerPos;
	}

	[Serializable]
	internal class _0024setQuestClearConditions_0024closure_00243721
	{
		internal _0024setQuestClearConditions_0024locals_002414411 _0024_0024locals_002414948;

		public _0024setQuestClearConditions_0024closure_00243721(_0024setQuestClearConditions_0024locals_002414411 _0024_0024locals_002414948)
		{
			this._0024_0024locals_002414948 = _0024_0024locals_002414948;
		}

		public void Invoke(int mid)
		{
			_0024_0024locals_002414948._0024qcc.checkKilledMonster(mid);
		}
	}

	[Serializable]
	internal class _0024popEnemy_0024getRandomPos_00243724
	{
		internal QuestBattleStarter _0024this_002414949;

		internal _0024popEnemy_0024locals_002414412 _0024_0024locals_002414950;

		public _0024popEnemy_0024getRandomPos_00243724(QuestBattleStarter _0024this_002414949, _0024popEnemy_0024locals_002414412 _0024_0024locals_002414950)
		{
			this._0024this_002414949 = _0024this_002414949;
			this._0024_0024locals_002414950 = _0024_0024locals_002414950;
		}

		public void Invoke()
		{
			_0024_0024locals_002414950._0024pos = _0024this_002414949.popPosGetter.getMonsterPos(_0024_0024locals_002414950._0024altPopPos);
			_0024_0024locals_002414950._0024rot = Quaternion.identity;
		}
	}

	[Serializable]
	internal class _0024writeBattleSession_0024closure_00243725
	{
		internal _0024writeBattleSession_0024locals_002414413 _0024_0024locals_002414951;

		public _0024writeBattleSession_0024closure_00243725(_0024writeBattleSession_0024locals_002414413 _0024_0024locals_002414951)
		{
			this._0024_0024locals_002414951 = _0024_0024locals_002414951;
		}

		public void Invoke(QuestBattleEnemyAIPool.PopInfo pd)
		{
			QuestBattleSessionData.PoppedMonster item = new QuestBattleSessionData.PoppedMonster(pd.ai);
			_0024_0024locals_002414951._0024bd.pops.Add(item);
		}
	}

	[Serializable]
	internal class _0024resetBattle_0024closure_00243726
	{
		internal _0024resetBattle_0024locals_002414414 _0024_0024locals_002414952;

		internal QuestBattleStarter _0024this_002414953;

		public _0024resetBattle_0024closure_00243726(_0024resetBattle_0024locals_002414414 _0024_0024locals_002414952, QuestBattleStarter _0024this_002414953)
		{
			this._0024_0024locals_002414952 = _0024_0024locals_002414952;
			this._0024this_002414953 = _0024this_002414953;
		}

		public void Invoke(QuestBattleEnemyAIPool.PopInfo pd)
		{
			if (!pd.IsAntiBattleResetMonster)
			{
				AIControl ai = pd.ai;
				if (pd.IsPoppedAtNpcPos)
				{
					ai.transform.position = pd.PoppedNpcPos;
				}
				else
				{
					ai.transform.position = _0024this_002414953.popPosGetter.getMonsterPos(_0024_0024locals_002414952._0024playerPos);
				}
				ai.forceToIdle();
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002418629 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241664_002418630;

			internal Vector3 _0024initialPlayerPos_002418631;

			internal IEnumerator _0024_0024sco_0024temp_00241665_002418632;

			internal float _0024_0024wait_sec_0024temp_00241666_002418633;

			internal IEnumerator _0024_0024sco_0024temp_00241667_002418634;

			internal RespMonster[] _0024wavePops_002418635;

			internal IEnumerator _0024_0024sco_0024temp_00241668_002418636;

			internal bool _0024firstPop_002418637;

			internal float _0024_0024wait_sec_0024temp_00241669_002418638;

			internal int _0024aliveLim_002418639;

			internal IEnumerator _0024_0024sco_0024temp_00241670_002418640;

			internal RespMonster _0024m_002418641;

			internal float _0024_0024wait_sec_0024temp_00241671_002418642;

			internal float _0024_0024wait_until_0024temp_00241672_002418643;

			internal float _0024_0024wait_until_0024temp_00241673_002418644;

			internal IEnumerator _0024_0024sco_0024temp_00241674_002418645;

			internal IEnumerator<RespMonster> _0024_0024iterator_002413670_002418646;

			internal PlayerControl _0024player_002418647;

			internal QuestBattleSessionData _0024btlSession_002418648;

			internal QuestBattleStarter _0024self__002418649;

			public _0024(PlayerControl player, QuestBattleSessionData btlSession, QuestBattleStarter self_)
			{
				_0024player_002418647 = player;
				_0024btlSession_002418648 = btlSession;
				_0024self__002418649 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (!(_0024player_002418647 != null))
						{
							throw new AssertionFailedException("player != null");
						}
						if (GameParameter.questFreeRun)
						{
							UnityEngine.Object.Destroy(_0024self__002418649.gameObject);
							goto case 1;
						}
						_0024self__002418649.startedPlaying = true;
						if (!QuestSession.HasBattleStoppedData)
						{
							_0024_0024sco_0024temp_00241664_002418630 = QuestCutscenePlayer.Instance.playPreBattleCutscene(_0024self__002418649.stageBattle);
							if (_0024_0024sco_0024temp_00241664_002418630 != null)
							{
								result = (Yield(2, _0024self__002418649.StartCoroutine(_0024_0024sco_0024temp_00241664_002418630)) ? 1 : 0);
								break;
							}
						}
						goto case 2;
					case 2:
						_0024self__002418649.initBattle(_0024player_002418647, _0024btlSession_002418648);
						_0024initialPlayerPos_002418631 = _0024player_002418647.MYPOS;
						try
						{
							PlayerEventDispatcher.InvokeBattleStart();
						}
						catch (Exception)
						{
						}
						_CurrentBattle = _0024self__002418649;
						_0024self__002418649.showPoppetHPMiniBars(_0024player_002418647.Poppets);
						_0024_0024sco_0024temp_00241665_002418632 = _0024self__002418649.restoreMonstersAtContinuation(_0024btlSession_002418648);
						if (_0024_0024sco_0024temp_00241665_002418632 != null)
						{
							result = (Yield(3, _0024self__002418649.StartCoroutine(_0024_0024sco_0024temp_00241665_002418632)) ? 1 : 0);
							break;
						}
						goto case 3;
					case 3:
						if (_0024self__002418649.stageBattle.WaitSecToOpen > 0 && _0024btlSession_002418648 == null)
						{
							_0024_0024wait_sec_0024temp_00241666_002418633 = _0024self__002418649.stageBattle.WaitSecToOpen;
							goto case 4;
						}
						goto IL_01d3;
					case 4:
						if (_0024_0024wait_sec_0024temp_00241666_002418633 > 0f)
						{
							_0024_0024wait_sec_0024temp_00241666_002418633 -= Time.deltaTime;
							result = (YieldDefault(4) ? 1 : 0);
							break;
						}
						goto IL_01d3;
					case 8:
						_0024self__002418649.heartBeat++;
						if (GameParameter.noBattle)
						{
							_0024self__002418649.debugKillAllEnemies();
							goto IL_0489;
						}
						_0024_0024sco_0024temp_00241667_002418634 = _0024self__002418649.waveLoop(_0024player_002418647);
						if (_0024_0024sco_0024temp_00241667_002418634 != null)
						{
							result = (Yield(5, _0024self__002418649.StartCoroutine(_0024_0024sco_0024temp_00241667_002418634)) ? 1 : 0);
							break;
						}
						goto case 5;
					case 5:
						_0024wavePops_002418635 = _0024self__002418649.dequeueNextWaveMonsters();
						if (_0024wavePops_002418635 == null || _0024wavePops_002418635.Length <= 0)
						{
							if (_0024self__002418649.NumOfQueuedEnemies <= 0)
							{
							}
						}
						else if ((!(_0024wavePops_002418635 == null) && _0024wavePops_002418635.Length > 0) || _0024self__002418649.NumOfQueuedEnemies > 0)
						{
							_0024self__002418649.waveCount++;
							_0024self__002418649.waveSignIfNeed(_0024self__002418649.waveCount);
							_0024_0024sco_0024temp_00241668_002418636 = _0024self__002418649.bossSignIfNeed(_0024wavePops_002418635);
							if (_0024_0024sco_0024temp_00241668_002418636 != null)
							{
								result = (Yield(6, _0024self__002418649.StartCoroutine(_0024_0024sco_0024temp_00241668_002418636)) ? 1 : 0);
								break;
							}
							goto case 6;
						}
						goto IL_0489;
					case 6:
						_0024firstPop_002418637 = _0024self__002418649.waveCount == 1;
						if (!_0024firstPop_002418637)
						{
							_0024_0024wait_sec_0024temp_00241669_002418638 = 1.5f;
							goto case 7;
						}
						goto IL_0407;
					case 7:
						if (_0024_0024wait_sec_0024temp_00241669_002418638 > 0f)
						{
							_0024_0024wait_sec_0024temp_00241669_002418638 -= Time.deltaTime * _0024self__002418649.inBattleTimeScale;
							result = (YieldDefault(7) ? 1 : 0);
							break;
						}
						goto IL_0407;
					case 9:
						if (_0024_0024wait_sec_0024temp_00241671_002418642 > 0f)
						{
							_0024_0024wait_sec_0024temp_00241671_002418642 -= Time.deltaTime;
							result = (YieldDefault(9) ? 1 : 0);
							break;
						}
						TimeScaleUtil.Set(1f);
						goto IL_0601;
					case 10:
						if (ChainSkillRoutine.IsPlaying && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00241673_002418644 < _0024_0024wait_until_0024temp_00241672_002418643)
						{
							result = (YieldDefault(10) ? 1 : 0);
							break;
						}
						try
						{
							_0024self__002418649.restorePlayer(_0024player_002418647, _0024self__002418649.stageBattle.KeepBattleMode);
							_0024self__002418649.restorePoppets(_0024player_002418647.Poppets);
						}
						catch (Exception)
						{
						}
						ExtensionsModule.ActivateChildren(_0024self__002418649.gameObject, b: false);
						result = (YieldDefault(11) ? 1 : 0);
						break;
					case 11:
						_0024_0024sco_0024temp_00241674_002418645 = QuestCutscenePlayer.Instance.playPostBattleCutscene(_0024self__002418649.stageBattle, _0024player_002418647);
						if (_0024_0024sco_0024temp_00241674_002418645 != null)
						{
							result = (Yield(12, _0024self__002418649.StartCoroutine(_0024_0024sco_0024temp_00241674_002418645)) ? 1 : 0);
							break;
						}
						goto case 12;
					case 12:
						_0024player_002418647.ChangeBattleMode(PlayerControl.BATTLE_MODE.Non_Battle);
						_0024player_002418647.InputActive = true;
						_0024self__002418649.setQuestClearConditions();
						if (!QuestSession.IsSessionEnded)
						{
							QuestSession.Session.battleSession.clear();
							QuestSession.Save();
						}
						PlayerEventDispatcher.InvokeBattleComplete();
						YieldDefault(1);
						goto case 1;
					case 1:
						{
							result = 0;
							break;
						}
						IL_0489:
						try
						{
							PlayerEventDispatcher.InvokeBattleEnd();
						}
						catch (Exception)
						{
						}
						_CurrentBattle = null;
						_0024_0024iterator_002413670_002418646 = _0024self__002418649.allMonsters.GetEnumerator();
						try
						{
							while (_0024_0024iterator_002413670_002418646.MoveNext())
							{
								_0024m_002418641 = _0024_0024iterator_002413670_002418646.Current;
								QuestSession.GotMonsterDropAll(_0024m_002418641);
							}
						}
						finally
						{
							_0024_0024iterator_002413670_002418646.Dispose();
						}
						if (_0024self__002418649.stageBattle.HasPostBattleCutScene)
						{
							_0024player_002418647.InputActive = false;
						}
						if (_0024self__002418649.stageBattle.ClearFlag != null)
						{
							UserData.Current.setFlag(_0024self__002418649.stageBattle.ClearFlag.Progname);
						}
						if (_0024self__002418649.stageBattle.ClearNotFlag != null)
						{
							UserData.Current.setFlag(_0024self__002418649.stageBattle.ClearNotFlag.Progname);
						}
						_0024self__002418649.disablePlayerPenetrationChecker(_0024player_002418647);
						if (!GameParameter.noBattle && _0024self__002418649.allMonsters.Count > 0)
						{
							TimeScaleUtil.Set(0.2f);
							_0024_0024wait_sec_0024temp_00241671_002418642 = 0.25f;
							goto case 9;
						}
						goto IL_0601;
						IL_01d3:
						if (_0024btlSession_002418648 != null && _0024btlSession_002418648.afterContinue)
						{
							_0024self__002418649.restoreBattleContinueEffect(_0024player_002418647, _0024btlSession_002418648.afterContinue);
						}
						_0024self__002418649.waveCount = 0;
						if (_0024btlSession_002418648 != null)
						{
							_0024self__002418649.waveCount = _0024btlSession_002418648.wave;
						}
						goto case 8;
						IL_0601:
						_0024_0024wait_until_0024temp_00241672_002418643 = 30f;
						_0024_0024wait_until_0024temp_00241673_002418644 = Time.realtimeSinceStartup;
						goto case 10;
						IL_0407:
						_0024aliveLim_002418639 = ((_0024self__002418649.currentQuest == null) ? 3 : _0024self__002418649.currentQuest.AliveMonsterLimit);
						_0024_0024sco_0024temp_00241670_002418640 = _0024self__002418649.popWaveEnemies(_0024wavePops_002418635, _0024initialPlayerPos_002418631, _0024player_002418647, _0024aliveLim_002418639);
						if (_0024_0024sco_0024temp_00241670_002418640 != null)
						{
							result = (Yield(8, _0024self__002418649.StartCoroutine(_0024_0024sco_0024temp_00241670_002418640)) ? 1 : 0);
							break;
						}
						goto case 8;
					}
				}
				return (byte)result != 0;
			}
		}

		internal PlayerControl _0024player_002418650;

		internal QuestBattleSessionData _0024btlSession_002418651;

		internal QuestBattleStarter _0024self__002418652;

		public _0024main_002418629(PlayerControl player, QuestBattleSessionData btlSession, QuestBattleStarter self_)
		{
			_0024player_002418650 = player;
			_0024btlSession_002418651 = btlSession;
			_0024self__002418652 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024player_002418650, _0024btlSession_002418651, _0024self__002418652);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024waveLoop_002418653 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal BattleResetWatcher _0024resetWatcher_002418654;

			internal IEnumerator _0024_0024sco_0024temp_00241675_002418655;

			internal PlayerControl _0024player_002418656;

			internal QuestBattleStarter _0024self__002418657;

			public _0024(PlayerControl player, QuestBattleStarter self_)
			{
				_0024player_002418656 = player;
				_0024self__002418657 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024resetWatcher_002418654 = new BattleResetWatcher();
					goto case 3;
				case 3:
					_0024self__002418657.enemyPool.cleanupCorpse();
					if (_0024self__002418657.enemyPool.Count <= 0)
					{
						goto case 1;
					}
					if (!EventWindow.isWindow)
					{
						_0024resetWatcher_002418654.update(Time.deltaTime);
						if (_0024resetWatcher_002418654.NeedReset)
						{
							_0024resetWatcher_002418654.reset();
							_0024_0024sco_0024temp_00241675_002418655 = _0024self__002418657.resetBattle(_0024player_002418656);
							if (_0024_0024sco_0024temp_00241675_002418655 != null)
							{
								result = (Yield(2, _0024self__002418657.StartCoroutine(_0024_0024sco_0024temp_00241675_002418655)) ? 1 : 0);
								break;
							}
						}
					}
					goto case 2;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PlayerControl _0024player_002418658;

		internal QuestBattleStarter _0024self__002418659;

		public _0024waveLoop_002418653(PlayerControl player, QuestBattleStarter self_)
		{
			_0024player_002418658 = player;
			_0024self__002418659 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024player_002418658, _0024self__002418659);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024bossSignIfNeed_002418660 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_sec_0024temp_00241676_002418661;

			internal GameObject _0024go_002418662;

			internal float _0024_0024wait_sec_0024temp_00241677_002418663;

			internal RespMonster[] _0024wavePops_002418664;

			internal QuestBattleStarter _0024self__002418665;

			public _0024(RespMonster[] wavePops, QuestBattleStarter self_)
			{
				_0024wavePops_002418664 = wavePops;
				_0024self__002418665 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__002418665.containsBoss(_0024wavePops_002418664))
					{
						if (_0024self__002418665.currentQuest != null && _0024self__002418665.currentQuest.QuestType == EnumQuestTypes.Challenge)
						{
							_0024_0024wait_sec_0024temp_00241676_002418661 = 1.1f;
							goto case 2;
						}
						goto IL_0097;
					}
					goto IL_00fe;
				case 2:
					if (_0024_0024wait_sec_0024temp_00241676_002418661 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241676_002418661 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto IL_0097;
				case 3:
					if (_0024_0024wait_sec_0024temp_00241677_002418663 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241677_002418663 -= Time.deltaTime;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					UnityEngine.Object.Destroy(_0024go_002418662);
					goto IL_00fe;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0097:
					_0024go_002418662 = QuestAssets.Instance.instantiateBossSign();
					if (_0024go_002418662 != null)
					{
						_0024_0024wait_sec_0024temp_00241677_002418663 = 2f;
						goto case 3;
					}
					goto IL_00fe;
					IL_00fe:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal RespMonster[] _0024wavePops_002418666;

		internal QuestBattleStarter _0024self__002418667;

		public _0024bossSignIfNeed_002418660(RespMonster[] wavePops, QuestBattleStarter self_)
		{
			_0024wavePops_002418666 = wavePops;
			_0024self__002418667 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024wavePops_002418666, _0024self__002418667);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024popWaveEnemies_002418668 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal int _0024step_002418669;

			internal RespMonster _0024m_002418670;

			internal float _0024_0024wait_sec_0024temp_00241678_002418671;

			internal IEnumerator _0024_0024sco_0024temp_00241679_002418672;

			internal int _0024_00249385_002418673;

			internal RespMonster[] _0024_00249386_002418674;

			internal int _0024_00249387_002418675;

			internal RespMonster[] _0024pops_002418676;

			internal Vector3 _0024altPopPos_002418677;

			internal PlayerControl _0024player_002418678;

			internal int _0024aliveMonsterLimit_002418679;

			internal QuestBattleStarter _0024self__002418680;

			public _0024(RespMonster[] pops, Vector3 altPopPos, PlayerControl player, int aliveMonsterLimit, QuestBattleStarter self_)
			{
				_0024pops_002418676 = pops;
				_0024altPopPos_002418677 = altPopPos;
				_0024player_002418678 = player;
				_0024aliveMonsterLimit_002418679 = aliveMonsterLimit;
				_0024self__002418680 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (_0024aliveMonsterLimit_002418679 <= 0)
						{
							_0024aliveMonsterLimit_002418679 = int.MaxValue;
						}
						else
						{
							Array.Sort(_0024pops_002418676, _0024adaptor_0024__DebugSubModeQuest_0024callable208_0024179_45___0024Comparison_002440.Adapt((RespMonster a, RespMonster b) => a.Id - b.Id));
						}
						debuglog("popWaveEnemies");
						if (_0024pops_002418676 == null || _0024pops_002418676.Length <= 0)
						{
							goto case 1;
						}
						_0024step_002418669 = _0024pops_002418676[0].PopStep;
						_0024_00249385_002418673 = 0;
						_0024_00249386_002418674 = _0024pops_002418676;
						_0024_00249387_002418675 = _0024_00249386_002418674.Length;
						goto IL_020a;
					case 2:
						if (_0024_0024wait_sec_0024temp_00241678_002418671 > 0f)
						{
							_0024_0024wait_sec_0024temp_00241678_002418671 -= Time.deltaTime * _0024self__002418680.inBattleTimeScale;
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (_0024_00249386_002418674[_0024_00249385_002418673].PopStep != _0024step_002418669)
						{
						}
						_0024_0024sco_0024temp_00241679_002418672 = _0024self__002418680.popEnemy(_0024_00249386_002418674[_0024_00249385_002418673], _0024altPopPos_002418677);
						if (_0024_0024sco_0024temp_00241679_002418672 != null)
						{
							result = (Yield(3, _0024self__002418680.StartCoroutine(_0024_0024sco_0024temp_00241679_002418672)) ? 1 : 0);
							break;
						}
						goto case 3;
					case 3:
						_0024self__002418680.lockOnIfNeed(_0024player_002418678, _0024self__002418680.enemyPool.LastPopMonster);
						_0024self__002418680.playPopSound();
						if (_0024self__002418680.enemyPool.AliveCount >= _0024aliveMonsterLimit_002418679)
						{
							goto case 4;
						}
						goto IL_01f0;
					case 4:
						if (_0024self__002418680.enemyPool.AliveCount >= _0024aliveMonsterLimit_002418679)
						{
							result = (YieldDefault(4) ? 1 : 0);
							break;
						}
						goto IL_01f0;
					case 5:
						_0024_00249385_002418673++;
						goto IL_020a;
					case 1:
						{
							result = 0;
							break;
						}
						IL_01f0:
						result = (YieldDefault(5) ? 1 : 0);
						break;
						IL_020a:
						if (_0024_00249385_002418673 < _0024_00249387_002418675)
						{
							_0024_0024wait_sec_0024temp_00241678_002418671 = 0.4f;
							goto case 2;
						}
						debuglog("popWaveEnemies end");
						YieldDefault(1);
						goto case 1;
					}
				}
				return (byte)result != 0;
			}
		}

		internal RespMonster[] _0024pops_002418681;

		internal Vector3 _0024altPopPos_002418682;

		internal PlayerControl _0024player_002418683;

		internal int _0024aliveMonsterLimit_002418684;

		internal QuestBattleStarter _0024self__002418685;

		public _0024popWaveEnemies_002418668(RespMonster[] pops, Vector3 altPopPos, PlayerControl player, int aliveMonsterLimit, QuestBattleStarter self_)
		{
			_0024pops_002418681 = pops;
			_0024altPopPos_002418682 = altPopPos;
			_0024player_002418683 = player;
			_0024aliveMonsterLimit_002418684 = aliveMonsterLimit;
			_0024self__002418685 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024pops_002418681, _0024altPopPos_002418682, _0024player_002418683, _0024aliveMonsterLimit_002418684, _0024self__002418685);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024popEnemy_002418686 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal MMonsters _0024mm_002418687;

			internal MStageMonsters _0024stgMon_002418688;

			internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024getRandomPos_002418689;

			internal bool _0024useNPCPos_002418690;

			internal EnemyInstantiationData _0024ed_002418691;

			internal IEnumerator _0024_0024sco_0024temp_00241680_002418692;

			internal object[] _0024_002413675_002418693;

			internal _0024popEnemy_0024locals_002414412 _0024_0024locals_002418694;

			internal RespMonster _0024m_002418695;

			internal Vector3 _0024altPopPos_002418696;

			internal QuestBattleStarter _0024self__002418697;

			public _0024(RespMonster m, Vector3 altPopPos, QuestBattleStarter self_)
			{
				_0024m_002418695 = m;
				_0024altPopPos_002418696 = altPopPos;
				_0024self__002418697 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002418694 = new _0024popEnemy_0024locals_002414412();
					_0024_0024locals_002418694._0024altPopPos = _0024altPopPos_002418696;
					_0024mm_002418687 = _0024m_002418695.Master;
					_0024stgMon_002418688 = _0024m_002418695.StageMonsterMaster;
					if (_0024mm_002418687 == null)
					{
						throw new AssertionFailedException("通信モンスターデータ(RespMonter)のモンスターマスターが不正");
					}
					if (_0024stgMon_002418688 == null)
					{
						throw new AssertionFailedException("通信モンスターデータ(RespMonter)のMStageMonstersマスタが不正");
					}
					_0024_0024locals_002418694._0024pos = _0024_0024locals_002418694._0024altPopPos;
					_0024_0024locals_002418694._0024rot = Quaternion.identity;
					_0024getRandomPos_002418689 = new _0024popEnemy_0024getRandomPos_00243724(_0024self__002418697, _0024_0024locals_002418694).Invoke;
					_0024useNPCPos_002418690 = false;
					if (!string.IsNullOrEmpty(_0024stgMon_002418688.PositionObject))
					{
						_0024getRandomPos_002418689();
						_0024_002413675_002418693 = GameLevelManager.ParseNpcPos(_0024stgMon_002418688.PositionObject, _0024_0024locals_002418694._0024pos, _0024_0024locals_002418694._0024rot);
						_0024_0024locals_002418694._0024pos = (Vector3)_0024_002413675_002418693[0];
						_0024_0024locals_002418694._0024rot = (Quaternion)_0024_002413675_002418693[1];
					}
					else if (_0024stgMon_002418688.CorrespondentNpc != null)
					{
						_0024useNPCPos_002418690 = _0024self__002418697.getNpcPosAndHideNpc(_0024stgMon_002418688.CorrespondentNpc, ref _0024_0024locals_002418694._0024pos, ref _0024_0024locals_002418694._0024rot);
						if (!_0024useNPCPos_002418690)
						{
							_0024getRandomPos_002418689();
						}
					}
					else
					{
						_0024getRandomPos_002418689();
					}
					_0024ed_002418691 = new EnemyInstantiationData();
					_0024ed_002418691.monster = _0024m_002418695;
					_0024ed_002418691.withPopEffect = true;
					_0024ed_002418691.pos = _0024_0024locals_002418694._0024pos;
					_0024ed_002418691.rot = _0024_0024locals_002418694._0024rot;
					_0024ed_002418691.useNPCPos = _0024useNPCPos_002418690;
					_0024_0024sco_0024temp_00241680_002418692 = _0024self__002418697.enemyPool.instantiateEnemy(_0024ed_002418691);
					if (_0024_0024sco_0024temp_00241680_002418692 != null)
					{
						result = (Yield(2, _0024self__002418697.StartCoroutine(_0024_0024sco_0024temp_00241680_002418692)) ? 1 : 0);
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

		internal RespMonster _0024m_002418698;

		internal Vector3 _0024altPopPos_002418699;

		internal QuestBattleStarter _0024self__002418700;

		public _0024popEnemy_002418686(RespMonster m, Vector3 altPopPos, QuestBattleStarter self_)
		{
			_0024m_002418698 = m;
			_0024altPopPos_002418699 = altPopPos;
			_0024self__002418700 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024m_002418698, _0024altPopPos_002418699, _0024self__002418700);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024restoreMonstersAtContinuation_002418701 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal QuestBattleSessionData.PoppedMonster _0024p_002418702;

			internal EnemyInstantiationData _0024ed_002418703;

			internal IEnumerator _0024_0024sco_0024temp_00241681_002418704;

			internal IEnumerator<QuestBattleSessionData.PoppedMonster> _0024_0024iterator_002413676_002418705;

			internal QuestBattleSessionData _0024bs_002418706;

			internal QuestBattleStarter _0024self__002418707;

			public _0024(QuestBattleSessionData bs, QuestBattleStarter self_)
			{
				_0024bs_002418706 = bs;
				_0024self__002418707 = self_;
			}

			public override bool MoveNext()
			{
				bool flag;
				try
				{
					switch (_state)
					{
					default:
						if (_0024bs_002418706 == null || _0024bs_002418706.pops == null)
						{
							break;
						}
						_0024_0024iterator_002413676_002418705 = _0024bs_002418706.pops.GetEnumerator();
						_state = 2;
						goto IL_0111;
					case 3:
						_0024ed_002418703.resultAI.HitPoint = _0024p_002418702.hp;
						goto IL_0111;
					case 1:
					case 2:
						break;
						IL_0111:
						if (_0024_0024iterator_002413676_002418705.MoveNext())
						{
							_0024p_002418702 = _0024_0024iterator_002413676_002418705.Current;
							_0024ed_002418703 = new EnemyInstantiationData();
							_0024ed_002418703.monster = _0024p_002418702.data;
							_0024ed_002418703.withPopEffect = false;
							_0024ed_002418703.pos = _0024p_002418702.pos;
							_0024_0024sco_0024temp_00241681_002418704 = _0024self__002418707.enemyPool.instantiateEnemy(_0024ed_002418703);
							if (_0024_0024sco_0024temp_00241681_002418704 == null)
							{
								goto case 3;
							}
							flag = Yield(3, _0024self__002418707.StartCoroutine(_0024_0024sco_0024temp_00241681_002418704));
							goto IL_0145;
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
				goto IL_0146;
				IL_0145:
				result = (flag ? 1 : 0);
				goto IL_0146;
				IL_0146:
				return (byte)result != 0;
			}

			private void _0024ensure2()
			{
				_0024_0024iterator_002413676_002418705.Dispose();
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

		internal QuestBattleSessionData _0024bs_002418708;

		internal QuestBattleStarter _0024self__002418709;

		public _0024restoreMonstersAtContinuation_002418701(QuestBattleSessionData bs, QuestBattleStarter self_)
		{
			_0024bs_002418708 = bs;
			_0024self__002418709 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024bs_002418708, _0024self__002418709);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024restoreBattleContinueEffect_0024_routine_00243720_002418710 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024i_002418711;

			internal int _0024_00249393_002418712;

			internal PlayerControl _0024pl_002418713;

			public _0024(PlayerControl pl)
			{
				_0024pl_002418713 = pl;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_00249393_002418712 = 0;
					goto case 2;
				case 2:
					if (_0024_00249393_002418712 < 3)
					{
						_0024i_002418711 = _0024_00249393_002418712;
						_0024_00249393_002418712++;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					BattleContinue.DownAllEnemiesWithEffect(_0024pl_002418713);
					_0024pl_002418713.setBonusNoHit(3f);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PlayerControl _0024pl_002418714;

		public _0024_0024restoreBattleContinueEffect_0024_routine_00243720_002418710(PlayerControl pl)
		{
			_0024pl_002418714 = pl;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024pl_002418714);
		}
	}

	[NonSerialized]
	private const bool DEBUG_LOG = false;

	[NonSerialized]
	private const float TIME_SCALE_SLOW = 0.2f;

	public float inBattleTimeScale;

	[NonSerialized]
	private static QuestBattleStarter _CurrentBattle;

	[NonSerialized]
	public static MStageBattles LastStartedBattle;

	private MStageBattles stageBattle;

	private bool startedPlaying;

	private QuestBattleEnemyAIPool enemyPool;

	private Boo.Lang.List<RespMonster> allMonsters;

	private Queue<RespMonster> monsterQueue;

	private int waveCount;

	private QuestBattlePopPosGetter popPosGetter;

	private int heartBeat;

	private MQuests currentQuest;

	public static bool IsPlaying => _CurrentBattle != null;

	public int NumOfPoppedEnemies => enemyPool.Count;

	public int NumOfQueuedEnemies => ((ICollection)monsterQueue).Count;

	public int NumOfKilledEnemies => enemyPool.KillNum;

	public Vector3 BasePosition => transform.position;

	public float InBattleTimeScale => inBattleTimeScale;

	public static QuestBattleStarter CurrentBattle => _CurrentBattle;

	public MStageBattles StageBattle
	{
		get
		{
			return stageBattle;
		}
		set
		{
			stageBattle = value;
		}
	}

	public QuestBattleEnemyAIPool EnemyPool => enemyPool;

	public Boo.Lang.List<RespMonster> AllMonsters => allMonsters;

	public Queue<RespMonster> MonsterQueue => monsterQueue;

	public int WaveCount => waveCount;

	public int HeartBeat => heartBeat;

	public QuestBattleStarter()
	{
		inBattleTimeScale = 1f;
		enemyPool = new QuestBattleEnemyAIPool();
		allMonsters = new Boo.Lang.List<RespMonster>();
		monsterQueue = new Queue<RespMonster>();
	}

	public static void SetInBattleTimeScaleIfBattleNow(float t)
	{
		if (!(_CurrentBattle == null))
		{
			_CurrentBattle.inBattleTimeScale = t;
		}
	}

	public static QuestBattleStarter FindStarter(MStageBattles sbtl)
	{
		object result;
		if (sbtl == null)
		{
			result = null;
		}
		else
		{
			int num = 0;
			QuestBattleStarter[] array = (QuestBattleStarter[])UnityEngine.Object.FindObjectsOfType(typeof(QuestBattleStarter));
			int length = array.Length;
			while (true)
			{
				if (num < length)
				{
					if (array[num].StageBattle.Id == sbtl.Id)
					{
						result = array[num];
						break;
					}
					num = checked(num + 1);
					continue;
				}
				result = null;
				break;
			}
		}
		return (QuestBattleStarter)result;
	}

	public static void LoadAndStart(QuestBattleSessionData bs, PlayerControl player)
	{
		if (bs != null)
		{
			int i = 0;
			QuestBattleStarter[] array = (QuestBattleStarter[])UnityEngine.Object.FindObjectsOfType(typeof(QuestBattleStarter));
			for (int length = array.Length; i < length && !array[i].loadAndStartMain(bs, player); i = checked(i + 1))
			{
			}
		}
	}

	private bool loadAndStartMain(QuestBattleSessionData bs, PlayerControl player)
	{
		if (bs == null)
		{
			throw new AssertionFailedException("bs != null");
		}
		int result;
		if (bs.stageBattleId != stageBattle.Id)
		{
			result = 0;
		}
		else
		{
			IEnumerator enumerator = main(player, bs);
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	public void Awake()
	{
		ExtensionsModule.SetLayer(gameObject, "MAP_ENEMY_POP");
		Collider component = gameObject.GetComponent<Collider>();
		if (!(component != null))
		{
			throw new AssertionFailedException("c != null");
		}
		component.isTrigger = true;
	}

	public void Start()
	{
		currentQuest = QuestSession.Quest;
		if (currentQuest == null)
		{
			throw new AssertionFailedException("currentQuest != null");
		}
		ExtensionsModule.ActivateChildren(gameObject, b: false);
	}

	public void OnDisable()
	{
		if (_CurrentBattle == this)
		{
			_CurrentBattle = null;
		}
	}

	public void OnDestroy()
	{
		if (enemyPool != null)
		{
			enemyPool.dispose();
		}
	}

	public void OnTriggerEnter(Collider c)
	{
		OnTriggerStay(c);
	}

	public void OnTriggerStay(Collider c)
	{
		if (!QuestInitializer.IsInPlay || _CurrentBattle != null || startedPlaying || QuestLinkRoutine.Instance.IsJumpingNow || stageBattle == null || QuestSession.IsMarkedBattle(stageBattle) || !QuestSession.HasAnyMonsters(stageBattle) || !isSatisfyingOpenCondition(stageBattle))
		{
			return;
		}
		PlayerControl component = c.transform.root.GetComponent<PlayerControl>();
		if (!(component == null) && component.IsReady)
		{
			IEnumerator enumerator = main(component, null);
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	private bool isSatisfyingOpenCondition(MStageBattles stageBattle)
	{
		int result;
		if (stageBattle == null)
		{
			result = 1;
		}
		else
		{
			BattleOpenConditions openCondition = stageBattle.OpenCondition;
			result = ((openCondition != BattleOpenConditions.VisitAllScenes || QuestSession.IsAllScenesVisited) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	private IEnumerator main(PlayerControl player, QuestBattleSessionData btlSession)
	{
		return new _0024main_002418629(player, btlSession, this).GetEnumerator();
	}

	private void initBattle(PlayerControl player, QuestBattleSessionData btlSession)
	{
		if (stageBattle.PreBattleFlag != null)
		{
			UserData.Current.setFlag(stageBattle.PreBattleFlag.Progname);
		}
		if (GameParameter.killPoppetIfBattleOpen)
		{
			killPoppets(player);
		}
		if (stageBattle.IsRaidCameraMode)
		{
			ExtensionsModule.SetComponent<QuestRaidCameraSwitcher>(gameObject);
		}
		try
		{
			playBattleStartSound();
			popPosGetter = new QuestBattlePopPosGetter(gameObject, player.transform.position);
			QuestSession.MarkBattle(stageBattle);
			LastStartedBattle = stageBattle;
			ExtensionsModule.ActivateChildren(gameObject, b: true);
			initializePlayer(player, stageBattle);
			initializePoppets(player.Poppets, player);
			initializeBattleCamera();
			initMonsterQueue(stageBattle, btlSession);
			enablePlayerPenetrationChecker(player);
		}
		catch (Exception)
		{
		}
	}

	private void initializeBattleCamera()
	{
		if (stageBattle != null && !(Camera.main == null))
		{
			CameraControl component = Camera.main.GetComponent<CameraControl>();
			if (!(component == null))
			{
				component.SetBattleDistanceAndHeight(stageBattle.BattleCameraDistance, stageBattle.BattleCameraHeight);
			}
		}
	}

	private void setQuestClearConditions()
	{
		_0024setQuestClearConditions_0024locals_002414411 _0024setQuestClearConditions_0024locals_0024 = new _0024setQuestClearConditions_0024locals_002414411();
		_0024setQuestClearConditions_0024locals_0024._0024qcc = QuestClearConditionChecker.Instance;
		QuestSession.CloseBattle(stageBattle);
		if (QuestSession.ExistBattleNum <= 0)
		{
			_0024setQuestClearConditions_0024locals_0024._0024qcc.satisfyAllEnemies();
		}
		enemyPool.forAllKilledIds(new _0024setQuestClearConditions_0024closure_00243721(_0024setQuestClearConditions_0024locals_0024).Invoke);
		if (stageBattle.ContainsBoss)
		{
			_0024setQuestClearConditions_0024locals_0024._0024qcc.satisfyBoss();
		}
	}

	private IEnumerator waveLoop(PlayerControl player)
	{
		return new _0024waveLoop_002418653(player, this).GetEnumerator();
	}

	private void waveSignIfNeed(int waveCount)
	{
		if (currentQuest != null && currentQuest.QuestType == EnumQuestTypes.Challenge)
		{
			BattleHUDWave.dispWave(waveCount);
		}
	}

	private IEnumerator bossSignIfNeed(RespMonster[] wavePops)
	{
		return new _0024bossSignIfNeed_002418660(wavePops, this).GetEnumerator();
	}

	private bool containsBoss(RespMonster[] ms)
	{
		int result;
		if (ms == null || ms.Length <= 0)
		{
			result = 0;
		}
		else
		{
			int num = 0;
			int length = ms.Length;
			while (true)
			{
				if (num < length)
				{
					if (ms[num].IsBoss)
					{
						result = 1;
						break;
					}
					num = checked(num + 1);
					continue;
				}
				result = 0;
				break;
			}
		}
		return (byte)result != 0;
	}

	private CharacterPenetrationNotifier enablePlayerPenetrationChecker(PlayerControl player)
	{
		CharacterPenetrationNotifier characterPenetrationNotifier = ExtensionsModule.SetComponent<CharacterPenetrationNotifier>(player.gameObject);
		if (characterPenetrationNotifier != null)
		{
			characterPenetrationNotifier.activate();
			characterPenetrationNotifier.Message += wallPenetrationEvent;
		}
		return characterPenetrationNotifier;
	}

	private void disablePlayerPenetrationChecker(PlayerControl player)
	{
		if (!(player == null))
		{
			CharacterPenetrationNotifier component = player.gameObject.GetComponent<CharacterPenetrationNotifier>();
			if (component != null)
			{
				component.deactivate();
				component.Message -= wallPenetrationEvent;
			}
		}
	}

	private void wallPenetrationEvent(CharacterPenetrationNotifier c, GameObject go, Collider col)
	{
		resetPlayer(go);
	}

	private void initMonsterQueue(MStageBattles battle, QuestBattleSessionData bs)
	{
		if (!QuestSession.IsInPlay)
		{
			return;
		}
		Boo.Lang.List<RespMonster> list = new Boo.Lang.List<RespMonster>();
		int i = 0;
		RespMonster[] array = QuestSession.StageBattleMonster(battle);
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				list.Add(array[i]);
				debuglog(new StringBuilder("pop monster: ").Append(array[i]).ToString());
			}
			list.Sort(_0024adaptor_0024__DebugSubModeQuest_0024callable208_0024179_45___0024Comparison_002440.Adapt((RespMonster a, RespMonster b) => a.PopStep - b.PopStep));
			IEnumerator<RespMonster> enumerator = list.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					RespMonster current = enumerator.Current;
					if (!current.IsKill && (bs == null || !bs.contains(current)))
					{
						monsterQueue.Enqueue(current);
						if (currentQuest != null)
						{
							current.AttackAdjMult = currentQuest.AttackAdjMult;
							current.AttackAdjPlus = currentQuest.AttackAdjPlus;
							current.HpAdjMult = currentQuest.HpAdjMult;
							current.HpAdjPlus = currentQuest.HpAdjPlus;
							current.DefenseAdjMult = currentQuest.DefenseAdjMult;
							current.DefenseAdjPlus = currentQuest.DefenseAdjPlus;
						}
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			allMonsters = list;
			debuglog(new StringBuilder("initMonsterQueue: ").Append(battle).Append(" - mnum=").Append((object)((ICollection)monsterQueue).Count)
				.ToString());
			string lhs = new StringBuilder("MONSTER QUEUE ").Append(gameObject).Append(":\n").ToString();
			foreach (RespMonster item in monsterQueue)
			{
				lhs += new StringBuilder().Append(item).Append("\n").ToString();
			}
		}
	}

	private RespMonster[] dequeueNextWaveMonsters()
	{
		object result;
		if (((ICollection)monsterQueue).Count <= 0)
		{
			result = new RespMonster[0];
		}
		else
		{
			Boo.Lang.List<RespMonster> list = new Boo.Lang.List<RespMonster>();
			int popStep = monsterQueue.Peek().PopStep;
			while (((ICollection)monsterQueue).Count > 0 && monsterQueue.Peek().PopStep == popStep)
			{
				list.Add(monsterQueue.Dequeue());
			}
			result = (RespMonster[])Builtins.array(typeof(RespMonster), list);
		}
		return (RespMonster[])result;
	}

	private bool debugKillAllEnemies()
	{
		foreach (RespMonster item in monsterQueue)
		{
			QuestSession.KillMonster(item);
		}
		monsterQueue.Clear();
		return false;
	}

	private void initializePlayer(PlayerControl player, MStageBattles stageBattle)
	{
		player.ChangeBattleMode(PlayerControl.BATTLE_MODE.Battle);
		if (!string.IsNullOrEmpty(stageBattle.PreBattleCutScene) && !string.IsNullOrEmpty(stageBattle.PreBattleCutScenePos))
		{
			GameLevelManager.SetNpcPos(player.transform, stageBattle.PreBattleCutScenePos);
		}
	}

	private void initializePoppets(AIControl[] poppets, PlayerControl player)
	{
		int i = 0;
		for (int length = poppets.Length; i < length; i = checked(i + 1))
		{
			if (!(poppets[i] == null))
			{
				poppets[i].AIMODE_Battle();
				Vector3 position = player.transform.position;
				poppets[i].transform.position = popPosGetter.getPoppetPos(player);
			}
		}
	}

	private void showPoppetHPMiniBars(AIControl[] poppets)
	{
		if (poppets == null)
		{
			return;
		}
		int i = 0;
		for (int length = poppets.Length; i < length; i = checked(i + 1))
		{
			if (!(poppets[i] == null))
			{
				poppets[i].showHPMiniBar();
			}
		}
	}

	private void killPoppets(PlayerControl player)
	{
		if (player == null)
		{
			return;
		}
		int i = 0;
		AIControl[] poppets = player.Poppets;
		for (int length = poppets.Length; i < length; i = checked(i + 1))
		{
			if (!(poppets[i] == null))
			{
				poppets[i].kill();
			}
		}
	}

	private Vector3 getRandomPoppetPos(PlayerControl player, Vector3 basePos, Vector3 altPos)
	{
		Vector3 position = player.transform.position;
		Boo.Lang.List<Vector3> list = new Boo.Lang.List<Vector3>();
		IEnumerator<Vector3> enumerator = player.Trajectory.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (isInRange((Vector3)obj, position, 0.5f, 2f))
				{
					list.Add((Vector3)obj);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		Vector3[] array = (Vector3[])Builtins.array(typeof(Vector3), list);
		Vector3 result;
		if (array.Length > 0)
		{
			result = BattleUtil.AdjustYpos(array[RuntimeServices.NormalizeArrayIndex(array, UnityEngine.Random.Range(0, array.Length))]);
		}
		else
		{
			result = QuestBattlePopPosGetter.randomPopPos(BasePosition, 2f, 2f, altPos);
		}
		return result;
	}

	private bool isInRange(Vector3 pos, Vector3 target, float min, float max)
	{
		float magnitude = (pos - target).magnitude;
		bool num = !(min > magnitude);
		if (num)
		{
			num = !(max > magnitude);
		}
		return num;
	}

	private void restorePlayer(PlayerControl player, bool keepBattleMode)
	{
		if (!(player == null))
		{
			player.resetAbnormalState();
			player.resetCooldowns();
			if (keepBattleMode)
			{
				player.forceToIdle();
			}
			else
			{
				player.ChangeBattleMode(PlayerControl.BATTLE_MODE.Non_Battle);
			}
		}
	}

	private void restorePoppets(AIControl[] poppets)
	{
		int i = 0;
		for (int length = poppets.Length; i < length; i = checked(i + 1))
		{
			if (!(poppets[i] == null))
			{
				poppets[i].Revive();
				poppets[i].AIMODE_ChasePlayer();
			}
		}
	}

	private AIControl choosePoppetRandomly(AIControl[] poppets)
	{
		object result;
		if (poppets == null || poppets.Length <= 0)
		{
			result = null;
		}
		else
		{
			result = poppets[RuntimeServices.NormalizeArrayIndex(poppets, UnityEngine.Random.Range(0, poppets.Length))];
		}
		return (AIControl)result;
	}

	private IEnumerator popWaveEnemies(RespMonster[] pops, Vector3 altPopPos, PlayerControl player, int aliveMonsterLimit)
	{
		return new _0024popWaveEnemies_002418668(pops, altPopPos, player, aliveMonsterLimit, this).GetEnumerator();
	}

	private IEnumerator popEnemy(RespMonster m, Vector3 altPopPos)
	{
		return new _0024popEnemy_002418686(m, altPopPos, this).GetEnumerator();
	}

	private void lockOnIfNeed(PlayerControl player, AIControl ai)
	{
		if (!(player == null) && !(ai == null))
		{
			PlayerLockOnControl lockOnControl = player.LockOnControl;
			if (lockOnControl != null && !lockOnControl.IsLockedAliveTargetOn)
			{
				lockOnControl.startLockOn(ai.gameObject);
			}
		}
	}

	private bool getNpcPosAndHideNpc(MNpcs npc, ref Vector3 pos, ref Quaternion rot)
	{
		if (npc == null)
		{
			throw new AssertionFailedException("npc != null");
		}
		bool result = false;
		GameLevelManager instance = GameLevelManager.Instance;
		int id = npc.Id;
		Transform npcTransform = instance.GetNpcTransform(id);
		if (npcTransform != null)
		{
			pos = npcTransform.position;
			rot = npcTransform.rotation;
			result = true;
		}
		instance.HideNpc(id);
		return result;
	}

	public static void WriteSessionIfPlaying(bool afterContinue, string continueApiKey)
	{
		if (IsPlaying)
		{
			QuestBattleStarter currentBattle = CurrentBattle;
			QuestSession.ClearBattleSessionData();
			currentBattle.writeBattleSession(QuestSession.BattleSessionData, afterContinue, continueApiKey);
		}
	}

	private void writeBattleSession(QuestBattleSessionData bd, bool afterContinue, string continueApiKey)
	{
		_0024writeBattleSession_0024locals_002414413 _0024writeBattleSession_0024locals_0024 = new _0024writeBattleSession_0024locals_002414413();
		_0024writeBattleSession_0024locals_0024._0024bd = bd;
		if (!(_CurrentBattle == this))
		{
			throw new AssertionFailedException("_CurrentBattle == self");
		}
		if (_0024writeBattleSession_0024locals_0024._0024bd != null)
		{
			_0024writeBattleSession_0024locals_0024._0024bd.stopped = true;
			_0024writeBattleSession_0024locals_0024._0024bd.wave = waveCount;
			_0024writeBattleSession_0024locals_0024._0024bd.afterContinue = afterContinue;
			_0024writeBattleSession_0024locals_0024._0024bd.stageBattleId = stageBattle.Id;
			_0024writeBattleSession_0024locals_0024._0024bd.continueApiKey = continueApiKey;
			enemyPool.forAllAlives(new _0024writeBattleSession_0024closure_00243725(_0024writeBattleSession_0024locals_0024).Invoke);
		}
	}

	private IEnumerator restoreMonstersAtContinuation(QuestBattleSessionData bs)
	{
		return new _0024restoreMonstersAtContinuation_002418701(bs, this).GetEnumerator();
	}

	private void restoreBattleContinueEffect(PlayerControl player, bool withNoHitAndBom)
	{
		if (!(player == null) && withNoHitAndBom)
		{
			__QuestBattleStarter_restoreBattleContinueEffect_0024callable160_0024762_13__ _QuestBattleStarter_restoreBattleContinueEffect_0024callable160_0024762_13__ = (PlayerControl pl) => new _0024_0024restoreBattleContinueEffect_0024_routine_00243720_002418710(pl).GetEnumerator();
			IEnumerator enumerator = _QuestBattleStarter_restoreBattleContinueEffect_0024callable160_0024762_13__(player);
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	private void playBattleStartSound()
	{
		if (stageBattle.BattleBgm.Id > -1)
		{
			GameSoundManager.PlayBgmDirect(stageBattle.BattleBgm.File);
		}
		PlaySE(SQEX_SoundPlayerData.SE.ready);
	}

	private void playPopSound()
	{
		PlaySE(SQEX_SoundPlayerData.SE.mon_appear);
	}

	private void PlaySE(SQEX_SoundPlayerData.SE se)
	{
		SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
		if (instance != null)
		{
			instance.PlaySe((int)se, 0, gameObject.GetInstanceID());
		}
	}

	private static void debuglog(string msg)
	{
		if (0 == 0)
		{
		}
	}

	public void debugResetBattle()
	{
		PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
		if (!(currentPlayer == null))
		{
			IEnumerator enumerator = resetBattle(currentPlayer);
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	private IEnumerator resetBattle(PlayerControl player)
	{
		_0024resetBattle_0024locals_002414414 _0024resetBattle_0024locals_0024 = new _0024resetBattle_0024locals_002414414();
		if (!(player == null))
		{
			_0024resetBattle_0024locals_0024._0024playerPos = resetPlayer(player);
			int i = 0;
			AIControl[] poppets = player.Poppets;
			for (int length = poppets.Length; i < length; i = checked(i + 1))
			{
				if (!(poppets[i] == null) && !poppets[i].IsDead)
				{
					poppets[i].transform.position = popPosGetter.getPoppetPos(player);
					poppets[i].forceToIdle();
				}
			}
			enemyPool.forAllAlives(new _0024resetBattle_0024closure_00243726(_0024resetBattle_0024locals_0024, this).Invoke);
		}
		return null;
	}

	private Vector3 resetPlayer(GameObject playerGo)
	{
		Vector3 vector = default(Vector3);
		return (playerGo == null) ? vector : resetPlayer(playerGo.GetComponent<PlayerControl>());
	}

	private Vector3 resetPlayer(PlayerControl player)
	{
		Vector3 result;
		if (!(player == null))
		{
			Vector3 vector = QuestBattlePopPosGetter.randomPopPos(BasePosition, 4f, 4f);
			player.transform.position = vector;
			if (!player.IsDead)
			{
				player.forceToIdle();
			}
			result = vector;
		}
		else
		{
			Vector3 vector2 = default(Vector3);
			result = vector2;
		}
		return result;
	}

	internal IEnumerator _0024restoreBattleContinueEffect_0024_routine_00243720(PlayerControl pl)
	{
		return new _0024_0024restoreBattleContinueEffect_0024_routine_00243720_002418710(pl).GetEnumerator();
	}

	internal int _0024initMonsterQueue_0024closure_00243722(RespMonster a, RespMonster b)
	{
		return checked(a.PopStep - b.PopStep);
	}

	internal int _0024popWaveEnemies_0024closure_00243723(RespMonster a, RespMonster b)
	{
		return checked(a.Id - b.Id);
	}
}
