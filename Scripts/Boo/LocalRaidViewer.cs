using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.PatternMatching;
using Boo.Lang.Runtime;
using CompilerGenerated;
using ExitGames.Client.Photon;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class LocalRaidViewer : PhotonClientMain
{
	[Serializable]
	internal class _0024Awake_0024locals_002414438
	{
		internal bool _0024ok;
	}

	[Serializable]
	internal class _0024Awake_0024closure_00243221
	{
		internal _0024Awake_0024locals_002414438 _0024_0024locals_002414989;

		public _0024Awake_0024closure_00243221(_0024Awake_0024locals_002414438 _0024_0024locals_002414989)
		{
			this._0024_0024locals_002414989 = _0024_0024locals_002414989;
		}

		public void Invoke()
		{
			_0024_0024locals_002414989._0024ok = true;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Awake_002418969 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal _0024Awake_0024locals_002414438 _0024_0024locals_002418970;

			internal LocalRaidViewer _0024self__002418971;

			public _0024(LocalRaidViewer self_)
			{
				_0024self__002418971 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002418970 = new _0024Awake_0024locals_002414438();
					_0024self__002418971.is_ready = false;
					_0024self__002418971.myName = PlayerPrefs.GetString("raid.test.myname");
					_0024_0024locals_002418970._0024ok = false;
					MerlinServer.EditorCommunicationInitialize(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024Awake_0024closure_00243221(_0024_0024locals_002418970).Invoke));
					goto case 2;
				case 2:
					if (!_0024_0024locals_002418970._0024ok)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					PhotonClientMain._allSendedDamage = 0;
					PhotonClientMain.bossIsDead = false;
					_0024self__002418971.playerCap = PerformanceSettingBase.raidPlayerCap;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal LocalRaidViewer _0024self__002418972;

		public _0024Awake_002418969(LocalRaidViewer self_)
		{
			_0024self__002418972 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002418972);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024debugMain_002418973 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024i_002418974;

			internal UserData _0024ud_002418975;

			internal IEnumerator<object> _0024_0024sco_0024temp_00241735_002418976;

			internal IEnumerator<object> _0024_0024sco_0024temp_00241736_002418977;

			internal Cameras _0024cams_002418978;

			internal bool _0024tmp_002418979;

			internal IEnumerator<object> _0024_0024sco_0024temp_00241737_002418980;

			internal IEnumerator<object> _0024_0024sco_0024temp_00241738_002418981;

			internal BattleHUD _0024hud_002418982;

			internal BattleState _0024btlState_002418983;

			internal float _0024playTime_002418984;

			internal float _0024_0024wait_sec_0024temp_00241739_002418985;

			internal float _0024_0024wait_sec_0024temp_00241740_002418986;

			internal float _0024_0024wait_sec_0024temp_00241741_002418987;

			internal BattleState _0024_0024match_00241745_002418988;

			internal IEnumerator<object> _0024_0024sco_0024temp_00241742_002418989;

			internal IEnumerator<object> _0024_0024sco_0024temp_00241743_002418990;

			internal IEnumerator<object> _0024_0024sco_0024temp_00241744_002418991;

			internal int _0024_00249810_002418992;

			internal LocalRaidViewer _0024self__002418993;

			public _0024(LocalRaidViewer self_)
			{
				_0024self__002418993 = self_;
			}

			public override bool MoveNext()
			{
				bool flag;
				try
				{
					switch (_state)
					{
					default:
						if (!_0024self__002418993.is_ready)
						{
							flag = YieldDefault(2);
							goto IL_0651;
						}
						PhotonClientMain.bInitializing = true;
						SceneChanger.Instance().dontReveal = true;
						MerlinServer.Busy = true;
						_0024self__002418993.clearQueuePlayer();
						_0024_00249810_002418992 = 0;
						goto case 3;
					case 3:
						if (_0024_00249810_002418992 < 2)
						{
							_0024i_002418974 = _0024_00249810_002418992;
							_0024_00249810_002418992++;
							flag = YieldDefault(3);
						}
						else
						{
							BattleHUDAutoBattle.DeactivateGameObject();
							_0024self__002418993.setupBossBgm();
							_state = 4;
							_0024ud_002418975 = UserData.Current;
							_0024_0024sco_0024temp_00241735_002418976 = _0024self__002418993.createAndDisableBoss();
							if (_0024_0024sco_0024temp_00241735_002418976 == null)
							{
								goto case 5;
							}
							flag = Yield(5, _0024self__002418993.StartCoroutine(_0024_0024sco_0024temp_00241735_002418976));
						}
						goto IL_0651;
					case 5:
						_0024_0024sco_0024temp_00241736_002418977 = _0024self__002418993.createOwnedPlayer();
						if (_0024_0024sco_0024temp_00241736_002418977 == null)
						{
							goto case 6;
						}
						flag = Yield(6, _0024self__002418993.StartCoroutine(_0024_0024sco_0024temp_00241736_002418977));
						goto IL_0651;
					case 6:
						if (!(_0024self__002418993.ownedPlayer != null))
						{
							throw new AssertionFailedException("ownedPlayer != null");
						}
						_0024self__002418993.setPlayerHandlers();
						BattleHUD.HideTemporary();
						_0024cams_002418978 = new Cameras(_0024self__002418993.ownedPlayer);
						_0024self__002418993.showBoss();
						if (_0024self__002418993.raidStartResponse != null && _0024self__002418993.raidStartResponse.RaidBattle != null)
						{
							_0024tmp_002418979 = _0024self__002418993.boss.noDamage;
							_0024self__002418993.boss.noDamage = false;
							_0024self__002418993.boss.forceSetHitPoint(_0024self__002418993.raidStartResponse.RaidBattle.Hp);
							_0024self__002418993.boss.noDamage = _0024tmp_002418979;
						}
						_state = 1;
						_0024ensure4();
						_0024_0024sco_0024temp_00241737_002418980 = _0024self__002418993.startOpeningEffect();
						if (_0024_0024sco_0024temp_00241737_002418980 != null)
						{
							_0024self__002418993.StartCoroutine(_0024_0024sco_0024temp_00241737_002418980);
						}
						_0024_0024sco_0024temp_00241738_002418981 = _0024self__002418993.startLogging();
						if (_0024_0024sco_0024temp_00241738_002418981 != null)
						{
							_0024self__002418993.StartCoroutine(_0024_0024sco_0024temp_00241738_002418981);
						}
						goto case 7;
					case 7:
						if (!(BattleHUD.CurrentInstance != null))
						{
							flag = YieldDefault(7);
							goto IL_0651;
						}
						_0024hud_002418982 = BattleHUD.CurrentInstance;
						_0024self__002418993.makePlayable();
						_0024self__002418993.activateBoss();
						BattleHUD.RestoreTemporaryHide();
						HUDHappaTimer.Show();
						_0024self__002418993.rpcRandomWord(EnumRaidWordTypes.Start, aOwn: true, 0.5f);
						_0024btlState_002418983 = BattleState.Alived;
						PhotonClientMain.lastRecvDateTime = DateTime.Now;
						_0024playTime_002418984 = _0024self__002418993.timeout;
						PhotonClientMain.bInitializing = false;
						goto case 8;
					case 8:
						_0024playTime_002418984 -= Time.deltaTime;
						HUDHappaTimer.SetTime(_0024playTime_002418984, _0024self__002418993.timeout);
						if (!(_0024playTime_002418984 > 0f))
						{
							_0024btlState_002418983 = BattleState.Timeover;
						}
						else
						{
							_0024self__002418993.bossDeadExitTimer -= Time.deltaTime;
							if (!PhotonClientMain.bossIsDead && !(_0024self__002418993.boss.HitPoint > 1f))
							{
								_0024self__002418993._0024eventBossDead_002418994();
							}
							if (PhotonClientMain.bossIsDead && !(_0024self__002418993.bossDeadExitTimer >= 0f))
							{
								_0024btlState_002418983 = BattleState.Defeated;
							}
							else
							{
								if (!_0024self__002418993.ownedPlayer.IsDead)
								{
									flag = YieldDefault(8);
									goto IL_0651;
								}
								_0024self__002418993.rpcRandomWord(EnumRaidWordTypes.Dead, aOwn: true, 1f);
								_0024btlState_002418983 = BattleState.Dead;
							}
						}
						_0024self__002418993.makeNotPlayable();
						if (_0024btlState_002418983 == BattleState.Dead)
						{
							_0024self__002418993.ownedPlayer.PCon.kill();
							_0024_0024wait_sec_0024temp_00241739_002418985 = 2f;
							goto case 9;
						}
						goto IL_0480;
					case 9:
						if (!(_0024_0024wait_sec_0024temp_00241739_002418985 > 0f))
						{
							goto IL_0480;
						}
						_0024_0024wait_sec_0024temp_00241739_002418985 -= Time.deltaTime;
						flag = YieldDefault(9);
						goto IL_0651;
					case 10:
						if (_0024_0024wait_sec_0024temp_00241740_002418986 > 0f)
						{
							_0024_0024wait_sec_0024temp_00241740_002418986 -= Time.deltaTime;
							flag = YieldDefault(10);
							goto IL_0651;
						}
						_0024self__002418993.closeGame(_0024cams_002418978);
						_0024self__002418993.startLeavingEffect();
						_0024self__002418993.hideOwnedPlayerMesh();
						_0024_0024wait_sec_0024temp_00241741_002418987 = 1f;
						break;
					case 11:
						break;
					case 1:
					case 4:
						goto end_IL_0000;
						IL_0480:
						_0024_0024wait_sec_0024temp_00241740_002418986 = 1f;
						goto case 10;
					}
					if (_0024_0024wait_sec_0024temp_00241741_002418987 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241741_002418987 -= Time.deltaTime;
						flag = YieldDefault(11);
						goto IL_0651;
					}
					_0024_0024match_00241745_002418988 = _0024btlState_002418983;
					if (_0024_0024match_00241745_002418988 != 0)
					{
						if (_0024_0024match_00241745_002418988 == BattleState.Dead)
						{
							_0024_0024sco_0024temp_00241742_002418989 = _0024self__002418993.gameOver(timeOver: false);
							if (_0024_0024sco_0024temp_00241742_002418989 != null)
							{
								_0024self__002418993.StartCoroutine(_0024_0024sco_0024temp_00241742_002418989);
							}
						}
						else if (_0024_0024match_00241745_002418988 == BattleState.Defeated)
						{
							_0024_0024sco_0024temp_00241743_002418990 = _0024self__002418993.gameClear();
							if (_0024_0024sco_0024temp_00241743_002418990 != null)
							{
								_0024self__002418993.StartCoroutine(_0024_0024sco_0024temp_00241743_002418990);
							}
						}
						else if (_0024_0024match_00241745_002418988 == BattleState.Timeover)
						{
							_0024_0024sco_0024temp_00241744_002418991 = _0024self__002418993.gameOver(timeOver: true);
							if (_0024_0024sco_0024temp_00241744_002418991 != null)
							{
								_0024self__002418993.StartCoroutine(_0024_0024sco_0024temp_00241744_002418991);
							}
						}
						else if (_0024_0024match_00241745_002418988 != BattleState.Error)
						{
							throw new MatchError(new StringBuilder("`btlState` failed to match `").Append(_0024_0024match_00241745_002418988).Append("`").ToString());
						}
					}
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
				goto IL_0652;
				IL_0652:
				return (byte)result != 0;
				IL_0651:
				result = (flag ? 1 : 0);
				goto IL_0652;
			}

			private void _0024ensure4()
			{
				SceneChanger.Instance().dontReveal = false;
				MerlinServer.Busy = false;
			}

			public override void Dispose()
			{
				switch (_state)
				{
				default:
					_state = 1;
					break;
				case 4:
				case 5:
				case 6:
					_state = 1;
					_0024ensure4();
					break;
				}
			}
		}

		internal LocalRaidViewer _0024self__002418995;

		public _0024debugMain_002418973(LocalRaidViewer self_)
		{
			_0024self__002418995 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002418995);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024createOwnedPlayer_002418996 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal PlayerPoppetCache.PlayerParams _0024prm_002418997;

			internal PlayerControl _0024pcon_002418998;

			internal PhotonPlayer _0024pl_002418999;

			internal PlayerRaidData _0024rdata_002419000;

			internal MComboBonus _0024mcombo_002419001;

			internal LocalRaidViewer _0024self__002419002;

			public _0024(LocalRaidViewer self_)
			{
				_0024self__002419002 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002419002.ownedPlayer = null;
					_0024prm_002418997 = new PlayerPoppetCache.PlayerParams();
					_0024prm_002418997.isBattleMode = true;
					if (_0024self__002419002.playerInitialPos != null)
					{
						_0024prm_002418997.position = _0024self__002419002.playerInitialPos.position;
					}
					_0024pcon_002418998 = PlayerPoppetCache.Instance.getPlayer(_0024prm_002418997);
					goto case 2;
				case 2:
					if (!(_0024pcon_002418998 != null))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!(_0024pcon_002418998 != null))
					{
						throw new AssertionFailedException("pcon != null");
					}
					_0024pl_002418999 = _0024self__002419002.setupRaidComponents(_0024pcon_002418998);
					goto case 3;
				case 3:
					if (!_0024pl_002418999.IsReady)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024pl_002418999.myName = _0024self__002419002.myName;
					_0024pl_002418999.name = "PLAYER OWNED";
					_0024pl_002418999.IsOwner = false;
					_0024self__002419002.setPlayerParameterWithPoppetAdjust(_0024pl_002418999.PCon);
					_0024rdata_002419000 = _0024pl_002418999.PCon.RaidData;
					_0024rdata_002419000.isRaid = true;
					_0024rdata_002419000.bonusWeaponElement = (EnumElements)_0024self__002419002.raidStartResponse.RaidBattle.ElementId;
					_0024rdata_002419000.bonusWeaponStyle = (EnumStyles)_0024self__002419002.raidStartResponse.RaidBattle.StyleId;
					_0024mcombo_002419001 = MComboBonus.FindByLevel(_0024self__002419002.raidStartResponse.RaidBattle.ComboLevel);
					_0024rdata_002419000.comboBonus = _0024mcombo_002419001.Bonus;
					_0024self__002419002.ownedPlayer = _0024pl_002418999;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal LocalRaidViewer _0024self__002419003;

		public _0024createOwnedPlayer_002418996(LocalRaidViewer self_)
		{
			_0024self__002419003 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419003);
		}
	}

	[NonSerialized]
	public static readonly DateTime RAID_END_DATE_REGARD_AS_LOCAL_RAID = DateTime.Parse("5540/05/04");

	private bool is_ready;

	public new IEnumerable<object> Awake()
	{
		return new _0024Awake_002418969(this);
	}

	public ApiGuildRaidStart.Resp frameupRaidResp()
	{
		RespTCycleRaidBattle respTCycleRaidBattle = new RespTCycleRaidBattle();
		ApiGuildRaidStart.Resp resp = new ApiGuildRaidStart.Resp();
		resp.Server = string.Empty;
		resp.RoomName = string.Empty;
		resp.CycleId = respTCycleRaidBattle.TCycleId;
		resp.RaidBattle = UserData.Current.userRaidInfo.raidBattle;
		resp.FriendPoint = 200;
		resp.TicketId = string.Empty;
		return resp;
	}

	public override void Start()
	{
		raidStartResponse = frameupRaidResp();
		transform.position = Vector3.zero;
		transform.rotation = Quaternion.identity;
		IEnumerator<object> enumerator = debugMain();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator<object> debugMain()
	{
		return new _0024debugMain_002418973(this).GetEnumerator();
	}

	public new IEnumerator<object> createOwnedPlayer()
	{
		return new _0024createOwnedPlayer_002418996(this).GetEnumerator();
	}

	private new void connectToServer()
	{
	}

	private new void disconnectFromServer()
	{
	}

	private new IEnumerator<object> reqActorNamesRoutine()
	{
		return null;
	}

	private new void operationRespJoin(OperationResponse resp)
	{
	}

	private new void operationRespGetProperties(OperationResponse resp)
	{
	}

	public override void Update()
	{
	}

	protected new void closeGame(Cameras cams)
	{
		StartButton.ForceDestroy();
		DebugReturn("exit in room");
		disconnectFromServer();
		DebugReturn("destroyed");
		destroyOthers();
		unloadSe();
	}

	public void setReady(bool b)
	{
		is_ready = b;
	}

	internal void _0024eventBossDead_002418994()
	{
		eventBossDead();
	}
}
