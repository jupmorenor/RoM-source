using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.PatternMatching;
using Boo.Lang.Runtime;
using CompilerGenerated;
using ExitGames.Client.Photon;
using ExitGames.Client.Photon.Lite;
using MerlinAPI;
using ObjUtil;
using UnityEngine;

[Serializable]
public class PhotonClientMain : PhotonClient
{
	[Serializable]
	public enum MerlinActionCommandType
	{
		UPDATE_PLAYER = 1,
		USE_SKILL1 = 3,
		USE_SKILL2 = 4,
		USE_SKILL3 = 5,
		DEAD = 6,
		WORD = 7,
		INFECT_ABST = 8
	}

	[Serializable]
	public enum ReturnCode
	{
		OK,
		FAIL,
		FAIL_INVALID_USER
	}

	[Serializable]
	public enum MerlinActionCommandDataKey
	{
		Type = 1,
		Serial = 101,
		Nonce = 102,
		RootArray = 128
	}

	[Serializable]
	public enum MerlinOpeCode
	{
		Attack = 1,
		ActionCommand = 211,
		Leave = 254,
		Join = 255
	}

	[Serializable]
	public enum MerlinOpeParamKey
	{
		SKILLID = 4,
		IsTenshi = 5,
		Hp = 54,
		JoinName = 55,
		EffPos = 56,
		PlayerData = 57,
		AngelGender = 59,
		DemonGender = 60,
		WordType = 61,
		WordIndex = 62,
		Weapons = 63,
		Poppets = 64,
		Friend = 65,
		PlayerRaidData = 66,
		AbnormalStateId = 67,
		RaidInitialHp = 101,
		RaidHp = 102,
		RaidDead = 103,
		Token = 200,
		Rp = 202,
		TCycleId = 203,
		TicketId = 205,
		Attack = 210,
		CommandData = 211,
		ActorProperties = 249,
		ActorNo = 254,
		GameId = 255
	}

	[Serializable]
	public enum BattleState
	{
		Alived,
		Dead,
		Defeated,
		Timeover,
		Error
	}

	[Serializable]
	public enum CommType
	{
		Event,
		Response,
		Join,
		Leave,
		Disconnect
	}

	[Serializable]
	public class CommTickData
	{
		public int code;

		public int actor;

		public CommType type;

		public float time;

		public float delta;

		public float frame;

		public float serial;

		public string dateTime;
	}

	[Serializable]
	public class Cameras
	{
		public CameraControl cam;

		public RaidCamera cam2;

		public Cameras(PhotonPlayer player)
		{
			if (!(player != null))
			{
				throw new AssertionFailedException("player != null");
			}
			cam = (CameraControl)UnityEngine.Object.FindObjectOfType(typeof(CameraControl));
			if (cam != null)
			{
				cam.target = player.transform;
			}
			cam2 = (RaidCamera)UnityEngine.Object.FindObjectOfType(typeof(RaidCamera));
			if (cam2 != null)
			{
				cam2.player = player.transform;
			}
		}

		public void reset()
		{
			if (cam != null)
			{
				cam.target = null;
			}
			if (cam2 != null)
			{
				cam2.player = null;
			}
		}
	}

	[Serializable]
	public class AnoCommand
	{
		protected byte nAno_;

		protected Hashtable cCommandData_;

		protected MerlinActionCommandType nCommandDataType;

		protected long nCreateTime_;

		public byte Ano => nAno_;

		public Hashtable CommandData => cCommandData_;

		public MerlinActionCommandType CommandDataType => nCommandDataType;

		public long CreateTime => nCreateTime_;

		public AnoCommand(byte ano, Hashtable commandData)
		{
			nAno_ = ano;
			cCommandData_ = commandData;
			nCommandDataType = (MerlinActionCommandType)commandData[(byte)1];
			nCreateTime_ = RuntimeServices.UnboxInt64(commandData[(byte)102]);
		}
	}

	[Serializable]
	public class AnoCommandCollection
	{
		protected System.Collections.Generic.List<AnoCommand> cList_;

		protected Dictionary<byte, int> cDic_;

		public System.Collections.Generic.List<AnoCommand> OrderList => cList_;

		public AnoCommandCollection()
		{
			cList_ = new System.Collections.Generic.List<AnoCommand>();
		}

		public void addAnoCommand(AnoCommand anoCommand)
		{
			int num = cList_.Count;
			int num2 = 0;
			bool flag = true;
			checked
			{
				while (num2 < num)
				{
					AnoCommand anoCommand2 = cList_[num2];
					if (anoCommand2.CreateTime <= anoCommand.CreateTime)
					{
						if (anoCommand.CommandDataType == anoCommand2.CommandDataType)
						{
							bool flag2 = true;
							MerlinActionCommandType commandDataType = anoCommand.CommandDataType;
							if (commandDataType == MerlinActionCommandType.WORD)
							{
								flag2 = false;
							}
							if (flag2 && anoCommand.Ano != anoCommand2.Ano)
							{
								num2++;
								continue;
							}
							cList_.RemoveAt(num2);
							num2--;
							num--;
						}
					}
					else if (anoCommand.CommandDataType == anoCommand2.CommandDataType)
					{
						flag = false;
						break;
					}
					num2++;
				}
				if (flag)
				{
					cList_.Add(anoCommand);
				}
			}
		}
	}

	[Serializable]
	internal class _0024createAndDisableBoss_0024locals_002414439
	{
		internal MMonsters _0024bossMaster;

		internal GameObject _0024bossGo;
	}

	[Serializable]
	internal class _0024errorStop_0024locals_002414440
	{
		internal bool _0024ok;
	}

	[Serializable]
	internal class _0024createAndDisableBoss_0024closure_00243097
	{
		internal PhotonClientMain _0024this_002414990;

		internal _0024createAndDisableBoss_0024locals_002414439 _0024_0024locals_002414991;

		public _0024createAndDisableBoss_0024closure_00243097(PhotonClientMain _0024this_002414990, _0024createAndDisableBoss_0024locals_002414439 _0024_0024locals_002414991)
		{
			this._0024this_002414990 = _0024this_002414990;
			this._0024_0024locals_002414991 = _0024_0024locals_002414991;
		}

		public void Invoke(GameObject go)
		{
			_0024_0024locals_002414991._0024bossGo = go;
			_0024this_002414990.boss = _0024_0024locals_002414991._0024bossGo.GetComponent<AIControl>();
			_0024this_002414990.boss.setupRaidBoss(_0024_0024locals_002414991._0024bossMaster, _0024this_002414990.raidStartResponse.RaidBattle.CurrentLevel, 19f);
			if (_0024this_002414990.boss.MonsterData != null)
			{
				_0024this_002414990.loadSe(new RespMonster[1] { _0024this_002414990.boss.MonsterData });
			}
			string name = "HitPointBar/BattleNameFont";
			GameObject gameObject = GameObject.Find(name);
			if (!(gameObject == null))
			{
				int i = 0;
				UIDynamicFontLabel[] componentsInChildren = gameObject.GetComponentsInChildren<UIDynamicFontLabel>();
				for (int length = componentsInChildren.Length; i < length; i = checked(i + 1))
				{
					componentsInChildren[i].Text = _0024_0024locals_002414991._0024bossMaster.Name.msg;
				}
			}
		}
	}

	[Serializable]
	internal class _0024errorStop_0024closure_00243102
	{
		internal _0024errorStop_0024locals_002414440 _0024_0024locals_002414992;

		internal PhotonClientMain _0024this_002414993;

		public _0024errorStop_0024closure_00243102(_0024errorStop_0024locals_002414440 _0024_0024locals_002414992, PhotonClientMain _0024this_002414993)
		{
			this._0024_0024locals_002414992 = _0024_0024locals_002414992;
			this._0024this_002414993 = _0024this_002414993;
		}

		public void Invoke()
		{
			_0024_0024locals_002414992._0024ok = true;
			_0024this_002414993.goBack();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002419004 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal bool _0024fullAttackMode_002419005;

			internal int _0024i_002419006;

			internal UserData _0024ud_002419007;

			internal IEnumerator<object> _0024_0024sco_0024temp_00241748_002419008;

			internal IEnumerator<object> _0024_0024sco_0024temp_00241749_002419009;

			internal Cameras _0024cams_002419010;

			internal IEnumerator<object> _0024_0024sco_0024temp_00241750_002419011;

			internal float _0024_0024wait_until_0024temp_00241751_002419012;

			internal float _0024_0024wait_until_0024temp_00241752_002419013;

			internal IEnumerator<object> _0024_0024sco_0024temp_00241753_002419014;

			internal IEnumerator<object> _0024_0024sco_0024temp_00241754_002419015;

			internal IEnumerator<object> _0024_0024sco_0024temp_00241755_002419016;

			internal BattleHUD _0024hud_002419017;

			internal BattleState _0024btlState_002419018;

			internal float _0024playTime_002419019;

			internal TimeSpan _0024dt_002419020;

			internal IEnumerator<object> _0024_0024sco_0024temp_00241756_002419021;

			internal float _0024_0024wait_sec_0024temp_00241757_002419022;

			internal IEnumerator<object> _0024_0024sco_0024temp_00241758_002419023;

			internal float _0024_0024wait_sec_0024temp_00241759_002419024;

			internal float _0024_0024wait_sec_0024temp_00241760_002419025;

			internal float _0024_0024wait_until_0024temp_00241761_002419026;

			internal float _0024_0024wait_until_0024temp_00241762_002419027;

			internal BattleState _0024_0024match_00241766_002419028;

			internal IEnumerator<object> _0024_0024sco_0024temp_00241763_002419029;

			internal IEnumerator<object> _0024_0024sco_0024temp_00241764_002419030;

			internal IEnumerator<object> _0024_0024sco_0024temp_00241765_002419031;

			internal int _0024_00249811_002419032;

			internal PhotonClientMain _0024self__002419033;

			public _0024(PhotonClientMain self_)
			{
				_0024self__002419033 = self_;
			}

			public override bool MoveNext()
			{
				bool flag;
				try
				{
					switch (_state)
					{
					default:
						_0024self__002419033.DebugReturn("start main()");
						bInitializing = true;
						SceneChanger.Instance().dontReveal = true;
						MerlinServer.Busy = true;
						_0024fullAttackMode_002419005 = _0024self__002419033.raidStartRequest.UseRp > 1;
						_0024self__002419033.clearQueuePlayer();
						_0024_00249811_002419032 = 0;
						goto case 2;
					case 2:
						if (_0024_00249811_002419032 < 2)
						{
							_0024i_002419006 = _0024_00249811_002419032;
							_0024_00249811_002419032++;
							flag = YieldDefault(2);
						}
						else
						{
							BattleHUDAutoBattle.DeactivateGameObject();
							_0024self__002419033.setupBossBgm();
							_state = 3;
							_0024self__002419033.connectToServer();
							_0024ud_002419007 = UserData.Current;
							_0024_0024sco_0024temp_00241748_002419008 = _0024self__002419033.createAndDisableBoss();
							if (_0024_0024sco_0024temp_00241748_002419008 == null)
							{
								goto case 4;
							}
							flag = Yield(4, _0024self__002419033.StartCoroutine(_0024_0024sco_0024temp_00241748_002419008));
						}
						goto IL_0917;
					case 4:
						_0024self__002419033.battleEventListener = new RaidBattleEventListener();
						_0024self__002419033.battleEventListener.AbnormalStateInfection += _0024self__002419033.bossAbnormalStateInfection;
						_0024_0024sco_0024temp_00241749_002419009 = _0024self__002419033.createOwnedPlayer();
						if (_0024_0024sco_0024temp_00241749_002419009 == null)
						{
							goto case 5;
						}
						flag = Yield(5, _0024self__002419033.StartCoroutine(_0024_0024sco_0024temp_00241749_002419009));
						goto IL_0917;
					case 5:
						if (!(_0024self__002419033.ownedPlayer != null))
						{
							throw new AssertionFailedException("ownedPlayer != null");
						}
						_0024self__002419033.setPlayerHandlers();
						BattleHUD.HideTemporary();
						_0024cams_002419010 = new Cameras(_0024self__002419033.ownedPlayer);
						_0024self__002419033.showBoss();
						_0024self__002419033.commTickData.Clear();
						_0024_0024sco_0024temp_00241750_002419011 = _0024self__002419033.waitConnectingAndJoinInRoom();
						if (_0024_0024sco_0024temp_00241750_002419011 != null)
						{
							_0024self__002419033.StartCoroutine(_0024_0024sco_0024temp_00241750_002419011);
						}
						_0024_0024wait_until_0024temp_00241751_002419012 = 15f;
						_0024_0024wait_until_0024temp_00241752_002419013 = Time.realtimeSinceStartup;
						goto case 6;
					case 6:
						if (_0024self__002419033.State != ClientState.InRoom && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00241752_002419013 < _0024_0024wait_until_0024temp_00241751_002419012)
						{
							flag = YieldDefault(6);
							goto IL_0917;
						}
						if (_0024self__002419033.raidStartResponse != null && _0024self__002419033.raidStartResponse.RaidBattle != null)
						{
							_0024self__002419033.boss.forceSetHitPoint(_0024self__002419033.raidStartResponse.RaidBattle.Hp);
						}
						_state = 1;
						_0024ensure3();
						if (_0024self__002419033.State == ClientState.InRoom)
						{
							_0024_0024sco_0024temp_00241754_002419015 = _0024self__002419033.startOpeningEffect();
							if (_0024_0024sco_0024temp_00241754_002419015 != null)
							{
								_0024self__002419033.StartCoroutine(_0024_0024sco_0024temp_00241754_002419015);
							}
							_0024_0024sco_0024temp_00241755_002419016 = _0024self__002419033.startLogging();
							if (_0024_0024sco_0024temp_00241755_002419016 != null)
							{
								_0024self__002419033.StartCoroutine(_0024_0024sco_0024temp_00241755_002419016);
							}
							goto case 8;
						}
						_0024self__002419033.closeGame(_0024cams_002419010);
						_0024_0024sco_0024temp_00241753_002419014 = _0024self__002419033.errorStop("通信エラーが発生しました(1)。");
						if (_0024_0024sco_0024temp_00241753_002419014 != null)
						{
							flag = Yield(7, _0024self__002419033.StartCoroutine(_0024_0024sco_0024temp_00241753_002419014));
							goto IL_0917;
						}
						goto end_IL_0000;
					case 7:
						goto end_IL_0000;
					case 8:
						if (!(BattleHUD.CurrentInstance != null))
						{
							flag = YieldDefault(8);
							goto IL_0917;
						}
						_0024hud_002419017 = BattleHUD.CurrentInstance;
						_0024self__002419033.makePlayable();
						_0024self__002419033.activateBoss();
						BattleHUD.RestoreTemporaryHide();
						HUDHappaTimer.Show();
						_0024self__002419033.rpcRandomWord(EnumRaidWordTypes.Start, aOwn: true, 0.5f);
						if (_0024fullAttackMode_002419005)
						{
							_0024self__002419033.emitFullPowerAttack();
						}
						_0024btlState_002419018 = BattleState.Alived;
						_0024self__002419033.rpcDamage(0);
						lastRecvDateTime = DateTime.Now;
						_0024playTime_002419019 = _0024self__002419033.timeout;
						lastRemainingTime = _0024playTime_002419019;
						bInitializing = false;
						goto case 10;
					case 9:
						goto end_IL_0000;
					case 10:
						if (_0024self__002419033.State != ClientState.InRoom)
						{
							goto IL_05c4;
						}
						_0024playTime_002419019 -= Time.deltaTime;
						lastRemainingTime = _0024playTime_002419019;
						HUDHappaTimer.SetTime(_0024playTime_002419019, _0024self__002419033.timeout);
						if (!(_0024playTime_002419019 > 0f))
						{
							_0024btlState_002419018 = BattleState.Timeover;
							_0024self__002419033.rpcRandomWord(EnumRaidWordTypes.Dead, aOwn: true, 1f);
							goto IL_05c4;
						}
						_0024self__002419033.bossDeadExitTimer -= Time.deltaTime;
						if (bossIsDead && !(_0024self__002419033.bossDeadExitTimer >= 0f))
						{
							_0024btlState_002419018 = BattleState.Defeated;
							goto IL_05c4;
						}
						_0024self__002419033.sendAction();
						if (_0024self__002419033.ownedPlayer.IsDead)
						{
							_0024self__002419033.rpcRandomWord(EnumRaidWordTypes.Dead, aOwn: true, 1f);
							_0024btlState_002419018 = BattleState.Dead;
							goto IL_05c4;
						}
						_0024dt_002419020 = DateTime.Now - lastRecvDateTime;
						if (_0024dt_002419020.Seconds <= 6)
						{
							flag = YieldDefault(10);
							goto IL_0917;
						}
						_0024_0024sco_0024temp_00241756_002419021 = _0024self__002419033.errorStop("通信エラーが発生しました(2)。");
						if (_0024_0024sco_0024temp_00241756_002419021 != null)
						{
							flag = Yield(9, _0024self__002419033.StartCoroutine(_0024_0024sco_0024temp_00241756_002419021));
							goto IL_0917;
						}
						goto end_IL_0000;
					case 11:
						if (!(_0024_0024wait_sec_0024temp_00241757_002419022 > 0f))
						{
							goto IL_062a;
						}
						_0024_0024wait_sec_0024temp_00241757_002419022 -= Time.deltaTime;
						flag = YieldDefault(11);
						goto IL_0917;
					case 12:
						goto end_IL_0000;
					case 13:
						if (_0024_0024wait_sec_0024temp_00241759_002419024 > 0f)
						{
							_0024_0024wait_sec_0024temp_00241759_002419024 -= Time.deltaTime;
							flag = YieldDefault(13);
							goto IL_0917;
						}
						_0024self__002419033.DebugReturn(new StringBuilder("out room: ").Append(_0024self__002419033.State).ToString());
						_0024self__002419033.closeGame(_0024cams_002419010);
						_0024self__002419033.startLeavingEffect();
						_0024self__002419033.hideOwnedPlayerMesh();
						_0024_0024wait_sec_0024temp_00241760_002419025 = 1f;
						goto case 14;
					case 14:
						if (_0024_0024wait_sec_0024temp_00241760_002419025 > 0f)
						{
							_0024_0024wait_sec_0024temp_00241760_002419025 -= Time.deltaTime;
							flag = YieldDefault(14);
							goto IL_0917;
						}
						_0024_0024wait_until_0024temp_00241761_002419026 = 10f;
						_0024_0024wait_until_0024temp_00241762_002419027 = Time.realtimeSinceStartup;
						break;
					case 15:
						break;
					case 1:
					case 3:
						goto end_IL_0000;
						IL_05c4:
						_0024self__002419033.makeNotPlayable();
						if (_0024btlState_002419018 == BattleState.Dead)
						{
							_0024self__002419033.ownedPlayer.PCon.kill();
							_0024_0024wait_sec_0024temp_00241757_002419022 = 2f;
							goto case 11;
						}
						goto IL_062a;
						IL_062a:
						if (_0024self__002419033.State == ClientState.InRoom)
						{
							_0024self__002419033.OpLeave();
							_0024_0024wait_sec_0024temp_00241759_002419024 = 1f;
							goto case 13;
						}
						_0024_0024sco_0024temp_00241758_002419023 = _0024self__002419033.errorStop("通信エラーが発生しました(3)。");
						if (_0024_0024sco_0024temp_00241758_002419023 != null)
						{
							flag = Yield(12, _0024self__002419033.StartCoroutine(_0024_0024sco_0024temp_00241758_002419023));
							goto IL_0917;
						}
						goto end_IL_0000;
					}
					if (_0024self__002419033.State != 0 && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00241762_002419027 < _0024_0024wait_until_0024temp_00241761_002419026)
					{
						flag = YieldDefault(15);
						goto IL_0917;
					}
					_0024self__002419033.DebugReturn("disconnected");
					if (!_0024self__002419033.testMode)
					{
						_0024_0024match_00241766_002419028 = _0024btlState_002419018;
						if (_0024_0024match_00241766_002419028 == BattleState.Alived)
						{
							_0024self__002419033.goBack();
						}
						else if (_0024_0024match_00241766_002419028 == BattleState.Dead)
						{
							_0024_0024sco_0024temp_00241763_002419029 = _0024self__002419033.gameOver(timeOver: false);
							if (_0024_0024sco_0024temp_00241763_002419029 != null)
							{
								_0024self__002419033.StartCoroutine(_0024_0024sco_0024temp_00241763_002419029);
							}
						}
						else if (_0024_0024match_00241766_002419028 == BattleState.Defeated)
						{
							_0024_0024sco_0024temp_00241764_002419030 = _0024self__002419033.gameClear();
							if (_0024_0024sco_0024temp_00241764_002419030 != null)
							{
								_0024self__002419033.StartCoroutine(_0024_0024sco_0024temp_00241764_002419030);
							}
						}
						else if (_0024_0024match_00241766_002419028 == BattleState.Timeover)
						{
							_0024_0024sco_0024temp_00241765_002419031 = _0024self__002419033.gameOver(timeOver: true);
							if (_0024_0024sco_0024temp_00241765_002419031 != null)
							{
								_0024self__002419033.StartCoroutine(_0024_0024sco_0024temp_00241765_002419031);
							}
						}
						else
						{
							if (_0024_0024match_00241766_002419028 != BattleState.Error)
							{
								throw new MatchError(new StringBuilder("`btlState` failed to match `").Append(_0024_0024match_00241766_002419028).Append("`").ToString());
							}
							_0024self__002419033.goBack();
						}
					}
					else
					{
						YieldDefault(1);
					}
					end_IL_0000:;
				}
				catch
				{
					//try-fault
					Dispose();
					throw;
				}
				int result = 0;
				goto IL_0918;
				IL_0918:
				return (byte)result != 0;
				IL_0917:
				result = (flag ? 1 : 0);
				goto IL_0918;
			}

			private void _0024ensure3()
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
				case 3:
				case 4:
				case 5:
				case 6:
					_state = 1;
					_0024ensure3();
					break;
				}
			}
		}

		internal PhotonClientMain _0024self__002419034;

		public _0024main_002419004(PhotonClientMain self_)
		{
			_0024self__002419034 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419034);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024startLogging_002419035 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024step_002419036;

			internal PhotonClientMain _0024self__002419037;

			public _0024(PhotonClientMain self_)
			{
				_0024self__002419037 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002419037.statsLogs.Clear();
					_0024step_002419036 = 0f;
					goto case 2;
				case 2:
					if (_0024self__002419037.State != ClientState.InRoom)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					if (_0024self__002419037.State == ClientState.InRoom)
					{
						if (_0024self__002419037.testMode || _0024self__002419037.logSendMode)
						{
							_0024step_002419036 += Time.deltaTime;
							if (!(_0024step_002419036 <= _0024self__002419037.loggingInterval))
							{
								_0024self__002419037.statsLogs.Add(_0024self__002419037.getStatsLog());
								_0024step_002419036 = 0f;
							}
						}
						result = (YieldDefault(3) ? 1 : 0);
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

		internal PhotonClientMain _0024self__002419038;

		public _0024startLogging_002419035(PhotonClientMain self_)
		{
			_0024self__002419038 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419038);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024createOwnedPlayer_002419039 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal PlayerPoppetCache.PlayerParams _0024prm_002419040;

			internal PlayerControl _0024pcon_002419041;

			internal PhotonPlayer _0024pl_002419042;

			internal PlayerRaidData _0024rdata_002419043;

			internal int _0024comboLevel_002419044;

			internal MComboBonus _0024mcombo_002419045;

			internal PhotonClientMain _0024self__002419046;

			public _0024(PhotonClientMain self_)
			{
				_0024self__002419046 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002419046.ownedPlayer = null;
					_0024prm_002419040 = new PlayerPoppetCache.PlayerParams();
					_0024prm_002419040.isBattleMode = true;
					if (_0024self__002419046.playerInitialPos != null)
					{
						_0024prm_002419040.position = _0024self__002419046.playerInitialPos.position;
					}
					_0024pcon_002419041 = PlayerPoppetCache.Instance.getPlayer(_0024prm_002419040);
					_0024pcon_002419041.forceSetAutoBattle(active: false);
					if (!(_0024pcon_002419041 != null))
					{
						throw new AssertionFailedException("pcon != null");
					}
					_0024pl_002419042 = _0024self__002419046.setupRaidComponents(_0024pcon_002419041);
					goto case 2;
				case 2:
					if (!_0024pl_002419042.IsReady)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024pl_002419042.myName = _0024self__002419046.myName;
					_0024pl_002419042.name = "PLAYER OWNED";
					_0024pl_002419042.IsOwner = false;
					_0024self__002419046.setPlayerParameterWithPoppetAdjust(_0024pl_002419042.PCon);
					_0024rdata_002419043 = _0024pl_002419042.PCon.RaidData;
					_0024rdata_002419043.isRaid = true;
					_0024rdata_002419043.bonusWeaponElement = (EnumElements)_0024self__002419046.raidStartResponse.RaidBattle.ElementId;
					_0024rdata_002419043.bonusWeaponStyle = (EnumStyles)_0024self__002419046.raidStartResponse.RaidBattle.StyleId;
					_0024comboLevel_002419044 = _0024self__002419046.raidStartResponse.RaidBattle.ComboLevel;
					_0024mcombo_002419045 = MComboBonus.FindByLevel(_0024comboLevel_002419044);
					_0024rdata_002419043.comboBonus = _0024mcombo_002419045.Bonus;
					_0024self__002419046.ownedPlayer = _0024pl_002419042;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PhotonClientMain _0024self__002419047;

		public _0024createOwnedPlayer_002419039(PhotonClientMain self_)
		{
			_0024self__002419047 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419047);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024startOpeningEffect_002419048 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024ctime_002419049;

			internal GameObject _0024opobj_002419050;

			internal GameObject _0024eobj_002419051;

			internal PhotonClientMain _0024self__002419052;

			public _0024(PhotonClientMain self_)
			{
				_0024self__002419052 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__002419052.openingPrefab != null)
					{
						_0024ctime_002419049 = Time.time;
						_0024opobj_002419050 = (GameObject)UnityEngine.Object.Instantiate(_0024self__002419052.openingPrefab);
						goto case 2;
					}
					goto IL_008b;
				case 2:
					if (Time.time - _0024ctime_002419049 <= _0024self__002419052.openingTime)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					UnityEngine.Object.Destroy(_0024opobj_002419050);
					goto IL_008b;
				case 1:
					{
						result = 0;
						break;
					}
					IL_008b:
					if (_0024self__002419052.enterEffect != null && _0024self__002419052.ownedPlayer != null)
					{
						_0024eobj_002419051 = (GameObject)UnityEngine.Object.Instantiate(_0024self__002419052.enterEffect);
						_0024eobj_002419051.transform.position = _0024self__002419052.ownedPlayer.transform.position;
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal PhotonClientMain _0024self__002419053;

		public _0024startOpeningEffect_002419048(PhotonClientMain self_)
		{
			_0024self__002419053 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419053);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024createAndDisableBoss_002419054 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RuntimeAssetBundleDB _0024abdb_002419055;

			internal float _0024_0024wait_until_0024temp_00241768_002419056;

			internal float _0024_0024wait_until_0024temp_00241769_002419057;

			internal _0024createAndDisableBoss_0024locals_002414439 _0024_0024locals_002419058;

			internal PhotonClientMain _0024self__002419059;

			public _0024(PhotonClientMain self_)
			{
				_0024self__002419059 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002419058 = new _0024createAndDisableBoss_0024locals_002414439();
					if (_0024self__002419059.raidStartResponse != null && _0024self__002419059.raidStartResponse.RaidBattle != null)
					{
						_0024_0024locals_002419058._0024bossMaster = MMonsters.Get(_0024self__002419059.raidStartResponse.RaidBattle.MMonsterId);
						if (_0024_0024locals_002419058._0024bossMaster != null)
						{
							_0024_0024locals_002419058._0024bossGo = null;
							_0024abdb_002419055 = RuntimeAssetBundleDB.Instance;
							_0024abdb_002419055.instantiatePrefab(_0024_0024locals_002419058._0024bossMaster.PrefabName, new _0024createAndDisableBoss_0024closure_00243097(_0024self__002419059, _0024_0024locals_002419058).Invoke);
							_0024_0024wait_until_0024temp_00241768_002419056 = 60f;
							_0024_0024wait_until_0024temp_00241769_002419057 = Time.realtimeSinceStartup;
							goto case 2;
						}
					}
					goto case 1;
				case 2:
					if (!(_0024_0024locals_002419058._0024bossGo != null) && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00241769_002419057 < _0024_0024wait_until_0024temp_00241768_002419056)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!(_0024_0024locals_002419058._0024bossGo != null))
					{
						throw new AssertionFailedException(new StringBuilder("ボス ").Append(_0024_0024locals_002419058._0024bossMaster).Append(" がロードできないよー！").ToString());
					}
					_0024self__002419059.bossD540 = _0024_0024locals_002419058._0024bossGo.GetComponent<D540ScriptRunner>();
					_0024self__002419059.deactivateBoss();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PhotonClientMain _0024self__002419060;

		public _0024createAndDisableBoss_002419054(PhotonClientMain self_)
		{
			_0024self__002419060 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419060);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024waitConnectingAndJoinInRoom_002419061 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_until_0024temp_00241770_002419062;

			internal float _0024_0024wait_until_0024temp_00241771_002419063;

			internal Hashtable _0024d_002419064;

			internal UserData _0024ud_002419065;

			internal string _0024weaponNguiJsonArrayString_002419066;

			internal System.Collections.Generic.List<string> _0024poppetNguiJsonList_002419067;

			internal RespPoppet _0024poppet_002419068;

			internal string _0024pstr_002419069;

			internal string _0024poppetNguiJsonArrayString_002419070;

			internal string _0024friendNguiJson_002419071;

			internal RespFriend _0024friend_002419072;

			internal string _0024playerRaidDataNguiJson_002419073;

			internal CommTickData _0024jctd_002419074;

			internal int _0024_00249812_002419075;

			internal RespPoppet[] _0024_00249813_002419076;

			internal int _0024_00249814_002419077;

			internal PhotonClientMain _0024self__002419078;

			public _0024(PhotonClientMain self_)
			{
				_0024self__002419078 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024_0024wait_until_0024temp_00241770_002419062 = 15f;
						_0024_0024wait_until_0024temp_00241771_002419063 = Time.realtimeSinceStartup;
						goto case 2;
					case 2:
						if (_0024self__002419078.State != ClientState.Connected && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00241771_002419063 < _0024_0024wait_until_0024temp_00241770_002419062)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (_0024self__002419078.State == ClientState.Connected)
						{
							_0024d_002419064 = new Hashtable();
							_0024ud_002419065 = UserData.Current;
							_0024self__002419078.roomName = _0024self__002419078.raidStartResponse.RoomName;
							_0024d_002419064[(byte)55] = _0024self__002419078.myName;
							if (CurrentInfo.HasToken)
							{
								_0024d_002419064[(byte)200] = CurrentInfo.Token;
							}
							_0024d_002419064[(byte)202] = _0024self__002419078.raidStartRequest.UseRp;
							_0024d_002419064[(byte)203] = _0024self__002419078.raidStartResponse.CycleId;
							_0024d_002419064[(byte)205] = _0024self__002419078.raidStartResponse.TicketId;
							_0024d_002419064[(byte)59] = _0024ud_002419065.AngelGender;
							_0024d_002419064[(byte)60] = _0024ud_002419065.DemonGender;
							_0024weaponNguiJsonArrayString_002419066 = _0024self__002419078.ownedPlayer.PCon.weaponEquipments.serialize();
							_0024d_002419064[(byte)63] = _0024weaponNguiJsonArrayString_002419066;
							_0024poppetNguiJsonList_002419067 = new System.Collections.Generic.List<string>();
							if (_0024self__002419078.ownedPlayer.PCon.IsReady)
							{
								_0024_00249812_002419075 = 0;
								_0024_00249813_002419076 = _0024self__002419078.ownedPlayer.PCon.CurrentPoppetData;
								for (_0024_00249814_002419077 = _0024_00249813_002419076.Length; _0024_00249812_002419075 < _0024_00249814_002419077; _0024_00249812_002419075++)
								{
									_0024pstr_002419069 = _0024_00249813_002419076[_0024_00249812_002419075].toNguiJson();
									_0024poppetNguiJsonList_002419067.Add(_0024pstr_002419069);
								}
							}
							_0024poppetNguiJsonArrayString_002419070 = toNguiJsonArrayString((string[])Builtins.array(typeof(string), _0024poppetNguiJsonList_002419067));
							_0024d_002419064[(byte)64] = _0024poppetNguiJsonArrayString_002419070;
							_0024friendNguiJson_002419071 = null;
							if (_raidFriendPoppet != null)
							{
								_0024friend_002419072 = _raidFriendPoppet.RespFriend;
								_0024friendNguiJson_002419071 = _0024friend_002419072.toNguiJson();
							}
							_0024d_002419064[(byte)65] = _0024friendNguiJson_002419071;
							_0024playerRaidDataNguiJson_002419073 = _0024self__002419078.ownedPlayer.PCon.RaidData.toNguiJson();
							_0024d_002419064[(byte)66] = _0024playerRaidDataNguiJson_002419073;
							_0024self__002419078.OpJoin(_0024self__002419078.roomName, _0024d_002419064);
							_0024jctd_002419074 = _0024self__002419078.newCommData(0, CommType.Join);
							_0024self__002419078.DebugReturn(new StringBuilder("in room: ").Append((object)_0024self__002419078.ActorNumber).Append(" room = ").Append(_0024self__002419078.roomName)
								.Append(" State=")
								.Append(_0024self__002419078.State)
								.ToString());
							YieldDefault(1);
						}
						goto case 1;
					case 1:
						result = 0;
						break;
					}
				}
				return (byte)result != 0;
			}
		}

		internal PhotonClientMain _0024self__002419079;

		public _0024waitConnectingAndJoinInRoom_002419061(PhotonClientMain self_)
		{
			_0024self__002419079 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419079);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024errorStop_002419080 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal _0024errorStop_0024locals_002414440 _0024_0024locals_002419081;

			internal string _0024msg_002419082;

			internal PhotonClientMain _0024self__002419083;

			public _0024(string msg, PhotonClientMain self_)
			{
				_0024msg_002419082 = msg;
				_0024self__002419083 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002419081 = new _0024errorStop_0024locals_002414440();
					_0024_0024locals_002419081._0024ok = false;
					ErrorDialog.FatalError(_0024msg_002419082, string.Empty, jumpBoot: true, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38___00242.Adapt(new _0024errorStop_0024closure_00243102(_0024_0024locals_002419081, _0024self__002419083).Invoke));
					_0024self__002419083.makeNotPlayable();
					_0024self__002419083.deactivateBoss();
					goto case 2;
				case 2:
					if (!_0024_0024locals_002419081._0024ok)
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

		internal string _0024msg_002419084;

		internal PhotonClientMain _0024self__002419085;

		public _0024errorStop_002419080(string msg, PhotonClientMain self_)
		{
			_0024msg_002419084 = msg;
			_0024self__002419085 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024msg_002419084, _0024self__002419085);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024gameOver_002419086 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024obj_002419087;

			internal float _0024_0024wait_sec_0024temp_00241772_002419088;

			internal bool _0024timeOver_002419089;

			internal PhotonClientMain _0024self__002419090;

			public _0024(bool timeOver, PhotonClientMain self_)
			{
				_0024timeOver_002419089 = timeOver;
				_0024self__002419090 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024timeOver_002419089)
					{
						if (_0024self__002419090.gameOverPrefab != null)
						{
							_0024obj_002419087 = (GameObject)UnityEngine.Object.Instantiate(_0024self__002419090.gameOverPrefab);
						}
						_0024_0024wait_sec_0024temp_00241772_002419088 = _0024self__002419090.gameOverWaitTime;
						goto case 2;
					}
					goto IL_0094;
				case 2:
					if (_0024_0024wait_sec_0024temp_00241772_002419088 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241772_002419088 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto IL_0094;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0094:
					_0024self__002419090.goBack();
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024timeOver_002419091;

		internal PhotonClientMain _0024self__002419092;

		public _0024gameOver_002419086(bool timeOver, PhotonClientMain self_)
		{
			_0024timeOver_002419091 = timeOver;
			_0024self__002419092 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024timeOver_002419091, _0024self__002419092);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024gameClear_002419093 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal PhotonClientMain _0024self__002419094;

			public _0024(PhotonClientMain self_)
			{
				_0024self__002419094 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					_0024self__002419094.goBack();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PhotonClientMain _0024self__002419095;

		public _0024gameClear_002419093(PhotonClientMain self_)
		{
			_0024self__002419095 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419095);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024reqActorNamesRoutine_002419096 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int[] _0024anoList_002419097;

			internal byte[] _0024ids_002419098;

			internal float _0024_0024wait_sec_0024temp_00241773_002419099;

			internal PhotonClientMain _0024self__002419100;

			public _0024(PhotonClientMain self_)
			{
				_0024self__002419100 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002419100.DebugReturn("start reqActorNamesRoutine");
					goto IL_002c;
				case 2:
					if (_0024_0024wait_sec_0024temp_00241773_002419099 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241773_002419099 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto IL_002c;
				case 1:
					{
						result = 0;
						break;
					}
					IL_002c:
					_0024anoList_002419097 = _0024self__002419100.getUnidentifyedActorNumbers();
					if (_0024anoList_002419097.Length > 0)
					{
						_0024ids_002419098 = new byte[7]
						{
							(byte)55,
							(byte)59,
							(byte)60,
							(byte)63,
							(byte)64,
							(byte)65,
							(byte)66
						};
						if (_0024self__002419100.Peer != null)
						{
							_0024self__002419100.Peer.OpGetPropertiesOfActor(_0024anoList_002419097, _0024ids_002419098, 0);
						}
						_0024self__002419100.DebugReturn(new StringBuilder("actor num=").Append((object)_0024anoList_002419097.Length).Append(": reqActorNamesRoutine").ToString());
					}
					_0024_0024wait_sec_0024temp_00241773_002419099 = 1f;
					goto case 2;
				}
				return (byte)result != 0;
			}
		}

		internal PhotonClientMain _0024self__002419101;

		public _0024reqActorNamesRoutine_002419096(PhotonClientMain self_)
		{
			_0024self__002419101 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419101);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024friendSpawnRoutine_002419102 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal PhotonPlayer _0024p_002419103;

			internal RespPoppet[] _0024poppetArray_002419104;

			internal RespFriendPoppet _0024friendPoppet_002419105;

			internal int _0024ano_002419106;

			internal string _0024aname_002419107;

			internal EnumGenders _0024angelGender_002419108;

			internal EnumGenders _0024demonGender_002419109;

			internal WeaponEquipments _0024weaponEquipments_002419110;

			internal System.Collections.Generic.List<RespPoppet> _0024poppetList_002419111;

			internal RespFriend _0024friend_002419112;

			internal PlayerRaidData _0024playerRaidData_002419113;

			internal PhotonClientMain _0024self__002419114;

			public _0024(int ano, string aname, EnumGenders angelGender, EnumGenders demonGender, WeaponEquipments weaponEquipments, System.Collections.Generic.List<RespPoppet> poppetList, RespFriend friend, PlayerRaidData playerRaidData, PhotonClientMain self_)
			{
				_0024ano_002419106 = ano;
				_0024aname_002419107 = aname;
				_0024angelGender_002419108 = angelGender;
				_0024demonGender_002419109 = demonGender;
				_0024weaponEquipments_002419110 = weaponEquipments;
				_0024poppetList_002419111 = poppetList;
				_0024friend_002419112 = friend;
				_0024playerRaidData_002419113 = playerRaidData;
				_0024self__002419114 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002419114.DebugReturn(new StringBuilder("friendSpawnRoutine ano=").Append((object)_0024ano_002419106).Append(" aname=").Append(_0024aname_002419107)
						.ToString());
					_0024self__002419114.rpcRandomWord(EnumRaidWordTypes.Welcome, aOwn: true, 0.5f);
					_0024p_002419103 = _0024self__002419114.instantiatePlayer(_0024angelGender_002419108, _0024demonGender_002419109, _0024weaponEquipments_002419110);
					_0024p_002419103.name = new StringBuilder("PLAYER Actor=").Append((object)_0024ano_002419106).ToString();
					_0024p_002419103.myName = _0024aname_002419107;
					_0024p_002419103.PCon.useHUD = false;
					_0024self__002419114.otherPlayers[_0024ano_002419106] = _0024p_002419103;
					goto case 2;
				case 2:
					if (!_0024p_002419103.IsReady)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024p_002419103.IsOwner = false;
					goto case 3;
				case 3:
					if (!_0024p_002419103.IsReady)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__002419114.rpcDamage(0);
					goto case 4;
				case 4:
					if (!_0024p_002419103.PCon.IsReady)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024self__002419114.rpcDamage(0);
					_0024poppetArray_002419104 = (RespPoppet[])Builtins.array(typeof(RespPoppet), _0024poppetList_002419111);
					_0024friendPoppet_002419105 = new RespFriendPoppet(_0024friend_002419112);
					_0024poppetList_002419111 = _0024poppetArray_002419104.ToList();
					_0024poppetList_002419111.Add(_0024friendPoppet_002419105);
					_0024poppetArray_002419104 = (RespPoppet[])Builtins.array(typeof(RespPoppet), _0024poppetList_002419111);
					_0024p_002419103.PCon.initPlayerParametersForRaid(_0024poppetArray_002419104);
					if (_0024playerRaidData_002419113 != null)
					{
						_0024p_002419103.PCon.RaidData.copyFrom(_0024playerRaidData_002419113);
					}
					_0024self__002419114.rpcDamage(0);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024ano_002419115;

		internal string _0024aname_002419116;

		internal EnumGenders _0024angelGender_002419117;

		internal EnumGenders _0024demonGender_002419118;

		internal WeaponEquipments _0024weaponEquipments_002419119;

		internal System.Collections.Generic.List<RespPoppet> _0024poppetList_002419120;

		internal RespFriend _0024friend_002419121;

		internal PlayerRaidData _0024playerRaidData_002419122;

		internal PhotonClientMain _0024self__002419123;

		public _0024friendSpawnRoutine_002419102(int ano, string aname, EnumGenders angelGender, EnumGenders demonGender, WeaponEquipments weaponEquipments, System.Collections.Generic.List<RespPoppet> poppetList, RespFriend friend, PlayerRaidData playerRaidData, PhotonClientMain self_)
		{
			_0024ano_002419115 = ano;
			_0024aname_002419116 = aname;
			_0024angelGender_002419117 = angelGender;
			_0024demonGender_002419118 = demonGender;
			_0024weaponEquipments_002419119 = weaponEquipments;
			_0024poppetList_002419120 = poppetList;
			_0024friend_002419121 = friend;
			_0024playerRaidData_002419122 = playerRaidData;
			_0024self__002419123 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024ano_002419115, _0024aname_002419116, _0024angelGender_002419117, _0024demonGender_002419118, _0024weaponEquipments_002419119, _0024poppetList_002419120, _0024friend_002419121, _0024playerRaidData_002419122, _0024self__002419123);
		}
	}

	[NonSerialized]
	protected const float FIELD_RADIUS = 19f;

	[NonSerialized]
	protected const int CONNECTION_TIMEOUT = 15;

	[NonSerialized]
	protected const int JOINING_TIMEOUT = 15;

	[NonSerialized]
	protected const int NO_RESPONSE_TIMEOUT = 6;

	[NonSerialized]
	protected const float DEFAULT_BOSS_TERRITORY_RADIUS = 2.5f;

	[NonSerialized]
	public const float WORD_PER_START = 0.5f;

	[NonSerialized]
	public const float WORD_PER_SKILL = 0.25f;

	[NonSerialized]
	public const float WORD_PER_DAMAGE = 0.25f;

	[NonSerialized]
	public const float WORD_PER_DEAD = 1f;

	[NonSerialized]
	public const float WORD_PER_KILLBOSS = 1f;

	[NonSerialized]
	public const float WORD_PER_WELCOME = 0.5f;

	public bool 爆発ぼかーんスイッチ;

	public bool 計測テストモード;

	public GameObject 開始演出プレハブ;

	public float 開始演出待ち時間;

	public float タイムアウト時間;

	[NonSerialized]
	public static float lastRemainingTime = 60f;

	public GameObject ゲームオーバー用プレハブ;

	public float ゲームオーバー待ち時間;

	[SceneIDEdit]
	public string ゲームオーバー時戻り先シーン名;

	public string[] ランダム名前テーブル;

	public Transform プレーヤー初期位置;

	public bool ログ送信;

	public GameObject 全力エフェクト;

	public GameObject 登場エフェクト;

	public GameObject 退室エフェクト;

	public float ボステリトリ半径;

	public int serverNo;

	public string[] serverList;

	public string serverApplicationName;

	public string roomName;

	public Transform spawn;

	public AIControl boss;

	public D540ScriptRunner bossD540;

	public GameObject smokeEffect;

	protected System.Collections.Generic.List<string> statsLogs;

	public float loggingInterval;

	public bool reliable;

	public PhotonPlayer ownedPlayer;

	public Dictionary<int, PhotonPlayer> otherPlayers;

	public System.Collections.Generic.List<int> queuePlayers;

	public HashSet<int> otherActorNumbers;

	protected int playerCap;

	private RaidBattleEventListener battleEventListener;

	protected string myName;

	protected float startTime;

	[NonSerialized]
	public const int RaidCostNormal = 1;

	[NonSerialized]
	public const int RaidCostFull = 3;

	protected System.Collections.Generic.List<CommTickData> commTickData;

	protected int eventSerial;

	protected ApiGuildRaidStart.Resp raidStartResponse;

	protected ApiGuildRaidStart raidStartRequest;

	[NonSerialized]
	protected static ApiGuildRaidStart.Resp _raidStartResponse;

	[NonSerialized]
	protected static ApiGuildRaidStart _raidStartRequest;

	[NonSerialized]
	protected static RespFriendPoppet _raidFriendPoppet;

	[NonSerialized]
	protected static int _allSendedDamage;

	protected float bossDeadExitTimer;

	[NonSerialized]
	protected static bool bossIsDead;

	[NonSerialized]
	protected static DateTime lastRecvDateTime;

	[NonSerialized]
	protected static bool bInitializing;

	protected int actorNo;

	protected System.Collections.Generic.List<object> buffer;

	protected float DefaultSendTimer;

	protected float sendTimer;

	[NonSerialized]
	protected const string SAVE_FILE_NAME = "riseofmana.raid";

	protected Transform transformBase => (!(boss != null)) ? transform : boss.transform;

	public string DeviceModel => SystemInfo.deviceModel.Replace(",", ".");

	public string DeviceName => SystemInfo.deviceName.Replace(",", ".");

	public static bool HasSavedData => LoadPlayInfo() != null;

	public bool explosionTest
	{
		get
		{
			return 爆発ぼかーんスイッチ;
		}
		set
		{
			爆発ぼかーんスイッチ = value;
		}
	}

	public bool testMode => 計測テストモード;

	public GameObject openingPrefab => 開始演出プレハブ;

	public float openingTime => 開始演出待ち時間;

	public float timeout => タイムアウト時間;

	public static float LastRemainingTime => lastRemainingTime;

	public GameObject gameOverPrefab => ゲームオーバー用プレハブ;

	public float gameOverWaitTime => ゲームオーバー待ち時間;

	public string sceneNameToBack => ゲームオーバー時戻り先シーン名;

	public string[] playerNames => ランダム名前テーブル;

	public Transform playerInitialPos => プレーヤー初期位置;

	public bool logSendMode => ログ送信;

	public GameObject fullPowerEffect => 全力エフェクト;

	public GameObject enterEffect => 登場エフェクト;

	public GameObject leaveEffect => 退室エフェクト;

	public float bossTerritoryRadius => ボステリトリ半径;

	public static ApiGuildRaidStart.Resp RaidStartResponse
	{
		get
		{
			return _raidStartResponse;
		}
		set
		{
			_raidStartResponse = value;
		}
	}

	public static ApiGuildRaidStart RaidStartRequest
	{
		get
		{
			return _raidStartRequest;
		}
		set
		{
			_raidStartRequest = value;
		}
	}

	public static RespFriendPoppet RaidFriendPoppet
	{
		get
		{
			return _raidFriendPoppet;
		}
		set
		{
			_raidFriendPoppet = value;
		}
	}

	public static int AllSendedDamage => _allSendedDamage;

	public static bool BossIsDead
	{
		get
		{
			return bossIsDead;
		}
		set
		{
			bossIsDead = value;
		}
	}

	public PhotonClientMain()
	{
		開始演出待ち時間 = 2f;
		タイムアウト時間 = 60f;
		ゲームオーバー待ち時間 = 3f;
		ゲームオーバー時戻り先シーン名 = "Town";
		ランダム名前テーブル = new string[7] { "Aさん", "Bさん", "Cさん", "Dさん", "Eさん", "Fさん", "Gさん" };
		ボステリトリ半径 = 2.5f;
		serverList = new string[2] { "65.52.177.19:5055", "192.168.2.104:5055" };
		serverApplicationName = "MerlinRaid2";
		roomName = "merlinroom";
		statsLogs = new System.Collections.Generic.List<string>();
		loggingInterval = 1f;
		reliable = true;
		otherPlayers = new Dictionary<int, PhotonPlayer>();
		queuePlayers = new System.Collections.Generic.List<int>();
		otherActorNumbers = new HashSet<int>();
		myName = "ABC";
		commTickData = new System.Collections.Generic.List<CommTickData>();
		actorNo = -1;
		buffer = new System.Collections.Generic.List<object>();
		DefaultSendTimer = 0.5f;
	}

	public void Awake()
	{
		if (testMode)
		{
			myName = PlayerPrefs.GetString("raid.test.myname");
		}
		else
		{
			UserData current = UserData.Current;
			if (current != null)
			{
				myName = current.PlayerName;
			}
			else
			{
				string[] array = playerNames;
				myName = array[RuntimeServices.NormalizeArrayIndex(array, UnityEngine.Random.Range(0, playerNames.Length))];
			}
		}
		_allSendedDamage = 0;
		bossIsDead = false;
		playerCap = PerformanceSettingBase.raidPlayerCap;
	}

	public override void Start()
	{
		transform.position = Vector3.zero;
		transform.rotation = Quaternion.identity;
		raidStartResponse = _raidStartResponse;
		raidStartRequest = _raidStartRequest;
		ServerAddress = raidStartResponse.Server;
		ServerApplication = serverApplicationName;
		IEnumerator<object> enumerator = main();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
		IEnumerator<object> enumerator2 = reqActorNamesRoutine();
		if (enumerator2 != null)
		{
			StartCoroutine(enumerator2);
		}
	}

	public void OnDisable()
	{
		disposeOwnedPlayerComponents();
	}

	protected IEnumerator<object> main()
	{
		return new _0024main_002419004(this).GetEnumerator();
	}

	protected IEnumerator<object> startLogging()
	{
		return new _0024startLogging_002419035(this).GetEnumerator();
	}

	protected void goBack()
	{
		SceneChanger.Change(sceneNameToBack);
	}

	protected void setupBossBgm()
	{
		if (raidStartResponse != null && raidStartResponse.RaidBattle != null)
		{
			MBgm mBgm = MRaidBattleUtil.RaidBossBgm(raidStartResponse.RaidBattle);
			if (mBgm != null)
			{
				GameSoundManager.PlayBgm(mBgm);
			}
		}
	}

	public IEnumerator<object> createOwnedPlayer()
	{
		return new _0024createOwnedPlayer_002419039(this).GetEnumerator();
	}

	public IEnumerator<object> startOpeningEffect()
	{
		return new _0024startOpeningEffect_002419048(this).GetEnumerator();
	}

	public void startLeavingEffect()
	{
		if (leaveEffect != null)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(leaveEffect);
			gameObject.transform.position = ownedPlayer.transform.position;
		}
	}

	protected IEnumerator<object> createAndDisableBoss()
	{
		return new _0024createAndDisableBoss_002419054(this).GetEnumerator();
	}

	protected void bossAbnormalStateInfection(EnumAbnormalStates state, MerlinActionControl patient, MerlinActionControl attacker)
	{
		if (!(boss == null) && !(boss != patient) && !(ownedPlayer == null) && !(ownedPlayer.PCon != attacker))
		{
			pushBossAbnormalState(state);
		}
	}

	protected void setPlayerHandlers()
	{
		if (!(ownedPlayer != null))
		{
			throw new AssertionFailedException("ownedPlayer != null");
		}
		ownedPlayer.HitAttackHandler = delegate
		{
		};
		ownedPlayer.HitAttackWithDamageHandler = delegate(int damage)
		{
			if (State == ClientState.InRoom)
			{
				rpcDamage(damage);
			}
		};
		ownedPlayer.SkillEventHandler = delegate(int skillID, bool isTensi)
		{
			if (State == ClientState.InRoom)
			{
				rpcUseSkillEvent(skillID, isTensi);
				rpcRandomWord(EnumRaidWordTypes.Skill, aOwn: true, 0.25f);
			}
		};
	}

	protected void makePlayable()
	{
		if (!(ownedPlayer == null))
		{
			ownedPlayer.IsOwner = true;
			if (ownedPlayer.PCon != null)
			{
				ownedPlayer.PCon.useHUD = true;
			}
		}
	}

	protected void makeNotPlayable()
	{
		if (!(ownedPlayer == null))
		{
			ownedPlayer.IsOwner = false;
		}
	}

	protected void showBoss()
	{
		if (!(boss != null))
		{
			throw new AssertionFailedException("boss != null");
		}
		boss.enabled = true;
		PhotonBoss photonBoss = ExtensionsModule.SetComponent<PhotonBoss>(boss.gameObject);
		photonBoss.HitDamageHandler = effectSender;
	}

	protected void activateBoss()
	{
		boss.noDamage = false;
		if (bossD540 != null)
		{
			bossD540.enabled = true;
		}
	}

	protected void deactivateBoss()
	{
		boss.enabled = false;
		boss.noDamage = true;
		if (bossD540 != null)
		{
			bossD540.enabled = true;
		}
	}

	protected void loadSe(RespMonster[] monsters)
	{
		QuestSession.InitializeBattleSE();
		QuestSession.InitializeMonsterSE(monsters);
	}

	protected void unloadSe()
	{
		SQEX_SoundPlayer.Instance.UnloadSeType(6);
		SQEX_SoundPlayer.Instance.UnloadSeType(7);
		SQEX_SoundPlayer.Instance.UnloadSeType(1);
		SQEX_SoundPlayer.Instance.UnloadSeType(2);
	}

	protected IEnumerator<object> waitConnectingAndJoinInRoom()
	{
		return new _0024waitConnectingAndJoinInRoom_002419061(this).GetEnumerator();
	}

	protected void setPlayerParameterWithPoppetAdjust(PlayerControl pl)
	{
		if (pl == null)
		{
			return;
		}
		UserData current = UserData.Current;
		if (current != null)
		{
			System.Collections.Generic.List<RespPoppet> list = new System.Collections.Generic.List<RespPoppet>();
			if (current.IsCurrentPoppetValid)
			{
				list.Add(current.CurrentDeck2.MainPoppet);
			}
			if (_raidFriendPoppet != null)
			{
				list.Add(_raidFriendPoppet);
			}
			pl.initPlayerParametersForRaid((RespPoppet[])Builtins.array(typeof(RespPoppet), list));
		}
	}

	protected IEnumerator<object> errorStop(string msg)
	{
		return new _0024errorStop_002419080(msg, this).GetEnumerator();
	}

	protected void closeGame(Cameras cams)
	{
		StartButton.ForceDestroy();
		DebugReturn("exit in room");
		disconnectFromServer();
		if (testMode)
		{
			killOwnedPlayer();
			cams.reset();
		}
		DebugReturn("destroyed");
		destroyOthers();
		unloadSe();
	}

	protected IEnumerator<object> gameOver(bool timeOver)
	{
		return new _0024gameOver_002419086(timeOver, this).GetEnumerator();
	}

	protected IEnumerator<object> gameClear()
	{
		return new _0024gameClear_002419093(this).GetEnumerator();
	}

	protected void emitFullPowerAttack()
	{
		if (fullPowerEffect != null)
		{
			UnityEngine.Object.Instantiate(fullPowerEffect, Vector3.zero, Quaternion.identity);
		}
		int raidFullPowerDamage = getRaidFullPowerDamage();
		boss.HitAttack(raidFullPowerDamage, YarareTypes.None, ownedPlayer.gameObject);
		DamageDisplay.DamageEnemySide(boss.transform.position, raidFullPowerDamage);
	}

	protected void connectToServer()
	{
		DebugReturn("connect to server");
		Peer = new LitePeer(this, tcpMode);
		LitePeer peer = Peer;
		bool num = enableTrafficStats;
		if (!num)
		{
			num = logSendMode;
		}
		peer.TrafficStatsEnabled = num;
		Peer.TrafficStatsReset();
		Connect();
	}

	protected int getRaidFullPowerDamage()
	{
		int cycleId = 0;
		if (raidStartResponse != null)
		{
			cycleId = raidStartResponse.CycleId;
		}
		return MCycleSchedules.GetByCycleId(cycleId)?.FullPowerDamage ?? 1000000;
	}

	protected void disconnectFromServer()
	{
		DebugReturn("disconnect from server:" + (Peer != null));
		newCommData(0, CommType.Disconnect);
		if (Peer != null)
		{
			Peer.Disconnect();
		}
	}

	protected string getStatsLog()
	{
		checked
		{
			string result;
			if (Peer != null)
			{
				TrafficStats trafficStatsIncoming = Peer.TrafficStatsIncoming;
				TrafficStats trafficStatsOutgoing = Peer.TrafficStatsOutgoing;
				TrafficStatsGameLevel trafficStatsGameLevel = Peer.TrafficStatsGameLevel;
				string lhs = myName + "," + SystemInfo.deviceModel.Replace(",", ".") + "," + SystemInfo.deviceName.Replace(",", ".") + ",";
				float num = 0f;
				float num2 = 0f;
				float num3 = 0f;
				long trafficStatsElapsedMs = Peer.TrafficStatsElapsedMs;
				if (trafficStatsElapsedMs > 0)
				{
					int num4 = trafficStatsIncoming.TotalPacketBytes * 8;
					int num5 = trafficStatsOutgoing.TotalPacketBytes * 8;
					int num6 = num4 + num5;
					num = (float)num6 / (float)trafficStatsElapsedMs;
					num2 = (float)num4 / (float)trafficStatsElapsedMs;
					num3 = (float)num5 / (float)trafficStatsElapsedMs;
				}
				lhs += "SUM," + num + "," + num2 + "," + num3 + ",";
				lhs += "TM," + Peer.LocalTimeInMilliSeconds + "," + Peer.ServerTimeInMilliSeconds + "," + (float)trafficStatsElapsedMs / 1000f + ",";
				lhs += "ENV," + Peer.UsedProtocol + "," + Peer.TimePingInterval + ",";
				lhs += "RND," + Peer.RoundTripTime + "," + Peer.RoundTripTimeVariance + ",";
				lhs += "IN," + statsToStr(trafficStatsIncoming) + ",";
				lhs += "OUT," + statsToStr(trafficStatsOutgoing) + ",";
				lhs += "GLS," + trafficStatsGameLevel.TotalOutgoingMessageCount + "," + trafficStatsGameLevel.TotalIncomingMessageCount + "," + trafficStatsGameLevel.TotalMessageCount + "," + trafficStatsGameLevel.LongestDeltaBetweenSending + "," + trafficStatsGameLevel.LongestDeltaBetweenDispatching + "," + trafficStatsGameLevel.LongestEventCallback + "," + trafficStatsGameLevel.LongestEventCallbackCode + "," + trafficStatsGameLevel.LongestOpResponseCallback + "," + trafficStatsGameLevel.LongestOpResponseCallbackOpCode;
				result = lhs;
			}
			else
			{
				result = new StringBuilder("<unknown:").Append(myName).Append(">").ToString();
			}
			return result;
		}
	}

	protected string statsToStr(TrafficStats s)
	{
		return (s != null) ? (s.TotalPacketCount + "," + s.TotalPacketBytes + "," + s.TotalCommandCount + "," + s.TotalCommandBytes + "," + s.ControlCommandCount + "," + s.ControlCommandBytes + "," + s.FragmentCommandCount + "," + s.FragmentCommandBytes + "," + s.PackageHeaderSize) : new StringBuilder("<unknown:").Append(myName).Append(">").ToString();
	}

	protected int[] getUnidentifyedActorNumbers()
	{
		System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
		foreach (int otherActorNumber in otherActorNumbers)
		{
			if (isUnknownActor(otherActorNumber))
			{
				list.Add(otherActorNumber);
			}
		}
		return list.ToArray();
	}

	protected IEnumerator<object> reqActorNamesRoutine()
	{
		return new _0024reqActorNamesRoutine_002419096(this).GetEnumerator();
	}

	protected void operationRespJoin(OperationResponse resp)
	{
		DebugReturn("resp join: " + (actorNo = RuntimeServices.UnboxInt32(resp.Parameters[(byte)254])));
	}

	protected void operationRespGetProperties(OperationResponse resp)
	{
		if (!(resp.Parameters[249] is Hashtable hashtable))
		{
			return;
		}
		byte b = (byte)59;
		byte b2 = (byte)60;
		byte b3 = (byte)55;
		IEnumerator enumerator = hashtable.Keys.GetEnumerator();
		checked
		{
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				if (isUnentriedPlayer(RuntimeServices.UnboxInt32(current)))
				{
					continue;
				}
				string aname = string.Empty;
				Hashtable hashtable2 = hashtable[current] as Hashtable;
				if (hashtable2.ContainsKey(b3))
				{
					object obj = hashtable2[b3];
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					aname = (string)obj;
				}
				if (!isRealizedPlayer(RuntimeServices.UnboxInt32(current)))
				{
					if (isQueuePlayer(RuntimeServices.UnboxInt32(current)) || queuePlayerNum() >= playerCap - 1)
					{
						continue;
					}
					queuePlayers.Add(RuntimeServices.UnboxInt32(current));
					EnumGenders angelGender = EnumGenders.male;
					if (hashtable2.ContainsKey(b))
					{
						angelGender = (EnumGenders)hashtable2[b];
					}
					EnumGenders demonGender = EnumGenders.male;
					if (hashtable2.ContainsKey(b2))
					{
						demonGender = (EnumGenders)hashtable2[b2];
					}
					WeaponEquipments weaponEquipments = new WeaponEquipments();
					byte b4 = (byte)63;
					if (hashtable2.ContainsKey(b4))
					{
						string json = hashtable2[b4] as string;
						weaponEquipments = WeaponEquipments.Deserialize(json);
					}
					System.Collections.Generic.List<RespPoppet> list = new System.Collections.Generic.List<RespPoppet>();
					byte b5 = (byte)64;
					if (hashtable2.ContainsKey(b5))
					{
						string str = hashtable2[b5] as string;
						string[] array = fromNguiJsonArrayString(str);
						int i = 0;
						string[] array2 = array;
						for (int length = array2.Length; i < length; i++)
						{
							RespPoppet item = RespPoppet.fromNguiJson(array2[i]);
							list.Add(item);
						}
					}
					RespFriend friend = null;
					byte b6 = (byte)65;
					if (hashtable2.ContainsKey(b6))
					{
						string nj = hashtable2[b6] as string;
						friend = RespFriend.fromNguiJson(nj);
					}
					PlayerRaidData playerRaidData = null;
					byte b7 = (byte)66;
					if (hashtable2.ContainsKey(b7))
					{
						string nj2 = hashtable2[b7] as string;
						playerRaidData = PlayerRaidData.fromNguiJson(nj2);
					}
					IEnumerator<object> enumerator2 = friendSpawnRoutine(RuntimeServices.UnboxInt32(current), aname, angelGender, demonGender, weaponEquipments, list, friend, playerRaidData);
					if (enumerator2 != null)
					{
						StartCoroutine(enumerator2);
					}
					restorePlayerHP();
					rpcDamage(0);
				}
				else
				{
					PhotonPlayer photonPlayer = otherPlayers[RuntimeServices.UnboxInt32(current)];
					if (photonPlayer.IsReady)
					{
						photonPlayer.myName = aname;
					}
				}
			}
		}
	}

	public override void Update()
	{
		if (Peer != null)
		{
			Peer.Service();
		}
	}

	protected void killOwnedPlayer()
	{
		if (ownedPlayer != null)
		{
			ownedPlayer.kill();
			ownedPlayer = null;
		}
	}

	protected void showOwnedPlayerMesh()
	{
		if (ownedPlayer != null && ownedPlayer.PCon != null)
		{
			ownedPlayer.PCon.activateMesh(string.Empty, b: true);
			ownedPlayer.PCon.showWeapons(show: true);
		}
	}

	protected void hideOwnedPlayerMesh()
	{
		if (ownedPlayer != null && ownedPlayer.PCon != null)
		{
			PlayerControl pCon = ownedPlayer.PCon;
			pCon.activateMesh(string.Empty, b: false);
			pCon.showWeapons(show: false);
		}
	}

	protected void destroyOthers()
	{
		foreach (PhotonPlayer value in otherPlayers.Values)
		{
			value.kill();
		}
		otherPlayers.Clear();
	}

	public override void OnEvent(EventData ev)
	{
		lastRecvDateTime = DateTime.Now;
		base.OnEvent(ev);
		CommTickData commTickData = eventCommData(ev.Code);
		if (ActorNumber > 0)
		{
			object value = ev[254];
			commTickData.actor = RuntimeServices.UnboxInt32(value);
			byte key = 245;
			Hashtable hashtable = null;
			if (ev.Parameters.ContainsKey(key))
			{
				hashtable = ev[key] as Hashtable;
			}
			if (ev[252] is int[] alist)
			{
				updateActorList(alist);
			}
			DebugReturn(new StringBuilder("ev ").Append((object)ev.Code).Append(" ano=").Append(value)
				.Append(" ")
				.ToString() + ev.ToStringFull());
			int num = ev.Code;
			if (num == 255)
			{
				tryEventEnter(RuntimeServices.UnboxInt32(value), ev.Parameters);
			}
			else if (num == 254)
			{
				eventLeave(RuntimeServices.UnboxInt32(value));
			}
		}
	}

	protected void rpcUseSkillEvent(int skillID, bool isTensi)
	{
		Hashtable hashtable = new Hashtable();
		hashtable[(byte)5] = isTensi;
		pushAction(3 + skillID, hashtable);
	}

	protected void eventUseSkillEvent(int ano, int skillID, Hashtable d)
	{
		if (isRealizedPlayer(ano))
		{
			PhotonPlayer photonPlayer = otherPlayers[ano];
			if (photonPlayer.IsReady)
			{
				object value = d[(byte)5];
				photonPlayer.execSkillCommand(skillID, RuntimeServices.UnboxBoolean(value));
			}
		}
	}

	protected void rpcDamage(int damage)
	{
		checked
		{
			if (!(0f >= ownedPlayer.PCon.HitPoint))
			{
				Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
				dictionary[(byte)210] = damage;
				opCustom(1, dictionary);
				_allSendedDamage += damage;
			}
		}
	}

	public override void OnOperationResponse(OperationResponse resp)
	{
		lastRecvDateTime = DateTime.Now;
		if (checked((int)resp.ReturnCode) != 0)
		{
			return;
		}
		CommTickData commTickData = respCommData(resp.OperationCode);
		DebugReturn("operation: actor no=" + ActorNumber + new StringBuilder(" resp=").Append(resp).ToString());
		byte operationCode = resp.OperationCode;
		switch (operationCode)
		{
		case byte.MaxValue:
			base.OnOperationResponse(resp);
			DebugReturn("resp " + resp.ToStringFull());
			operationRespJoin(resp);
			return;
		case 251:
			base.OnOperationResponse(resp);
			DebugReturn("resp " + resp.ToStringFull());
			operationRespGetProperties(resp);
			return;
		}
		if ((int)operationCode == 211)
		{
			if (!bInitializing)
			{
				operationActionCommand(resp);
			}
			operationActionCommand(resp);
		}
		else if ((int)operationCode == 1)
		{
			if (!bInitializing)
			{
				operationActionCommand(resp);
			}
			DebugReturn("resp " + resp.ToStringFull());
			operationAttack(resp);
		}
		else if ((int)operationCode == 254)
		{
			DebugReturn("resp " + resp.ToStringFull());
			operationLeave(resp);
		}
	}

	protected void operationActionCommand(OperationResponse resp)
	{
		checkBossLivenessFromServerResponse(resp, checkBossDead: true);
		if (!resp.Parameters.ContainsKey((byte)211))
		{
			return;
		}
		Dictionary<byte, Hashtable> dictionary = resp.Parameters[(byte)211] as Dictionary<byte, Hashtable>;
		AnoCommandCollection anoCommandCollection = new AnoCommandCollection();
		foreach (KeyValuePair<byte, Hashtable> item in dictionary)
		{
			byte key = item.Key;
			Hashtable value = item.Value;
			object[] array = value[(byte)128] as object[];
			IEnumerator enumerator2 = array.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				object obj = enumerator2.Current;
				if (!(obj is Hashtable))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
				}
				Hashtable commandData = (Hashtable)obj;
				AnoCommand anoCommand = new AnoCommand(key, commandData);
				anoCommandCollection.addAnoCommand(anoCommand);
			}
		}
		foreach (AnoCommand order in anoCommandCollection.OrderList)
		{
			MerlinActionCommandType commandDataType = order.CommandDataType;
			byte key = order.Ano;
			Hashtable commandData2 = order.CommandData;
			MerlinActionCommandType merlinActionCommandType = commandDataType;
			switch (merlinActionCommandType)
			{
			case MerlinActionCommandType.UPDATE_PLAYER:
				eventUpdatePlayer(key, commandData2);
				break;
			case MerlinActionCommandType.DEAD:
				eventUpdatePlayer(key, commandData2);
				break;
			case MerlinActionCommandType.USE_SKILL1:
				eventUseSkillEvent(key, 0, commandData2);
				break;
			case MerlinActionCommandType.USE_SKILL2:
				eventUseSkillEvent(key, 1, commandData2);
				break;
			case MerlinActionCommandType.USE_SKILL3:
				eventUseSkillEvent(key, 2, commandData2);
				break;
			case MerlinActionCommandType.WORD:
				eventWord(key, commandData2);
				break;
			case MerlinActionCommandType.INFECT_ABST:
				eventBossAbnormalState(key, commandData2);
				break;
			default:
				throw new MatchError(new StringBuilder("`commandDataType` failed to match `").Append(merlinActionCommandType).Append("`").ToString());
			}
		}
	}

	protected void operationLeave(OperationResponse resp)
	{
	}

	protected void checkBossLivenessFromServerResponse(OperationResponse resp, bool checkBossDead)
	{
		if (resp == null)
		{
			return;
		}
		byte key = (byte)102;
		byte key2 = (byte)101;
		byte key3 = (byte)103;
		if (resp.Parameters.ContainsKey(key) && resp.Parameters.ContainsKey(key2) && resp.Parameters.ContainsKey(key3))
		{
			int num = RuntimeServices.UnboxInt32(resp.Parameters[key]);
			int num2 = RuntimeServices.UnboxInt32(resp.Parameters[key2]);
			bool flag = RuntimeServices.UnboxBoolean(resp.Parameters[key3]);
			if (!checkBossDead)
			{
				num = Mathf.Max(1, num);
			}
			if (boss != null)
			{
				boss.MaxHitPoint = num2;
				setBossHPInBattle(num);
			}
			DebugReturn(new StringBuilder("attack! : life=").Append((object)num).Append(" lifemax=").Append((object)num2)
				.ToString());
			if (checkBossDead && flag)
			{
				eventBossDead();
			}
		}
	}

	protected void setBossHPInBattle(float life)
	{
		if (!(boss == null) && !(boss.HitPoint <= life))
		{
			boss.forceSetHitPoint(checked((int)life));
		}
	}

	protected void operationAttack(OperationResponse resp)
	{
		try
		{
			checkBossLivenessFromServerResponse(resp, checkBossDead: true);
		}
		catch (Exception)
		{
			if (resp == null)
			{
				return;
			}
			string lhs = string.Empty;
			foreach (byte key in resp.Parameters.Keys)
			{
				lhs += new StringBuilder().Append((object)key).Append("=").Append(resp.Parameters[key])
					.Append("\n")
					.ToString();
			}
		}
	}

	protected void raiseUpdatePlayer(PhotonPlayer p)
	{
		if (!(p == null) && p.HasSendData)
		{
			Hashtable hashtable = new Hashtable();
			hashtable[(byte)57] = ownedPlayer.SendData;
			pushAction(1, hashtable);
			ownedPlayer.clearSendData();
		}
	}

	protected PhotonPlayer instantiatePlayer(EnumGenders tenshiGender, EnumGenders akumaGender, WeaponEquipments weaponEquipments)
	{
		PlayerControl.SpawnParam spawnParam = new PlayerControl.SpawnParam(Vector3.zero, Quaternion.identity, tenshiGender, akumaGender, PlayerControl.BATTLE_MODE.Battle, withSkillPack: true);
		spawnParam.weaponEquipments = weaponEquipments;
		spawnParam.withAutoBattle = false;
		PlayerControl pl = PlayerControl.Spawn(spawnParam);
		PhotonPlayer photonPlayer = setupRaidComponents(pl);
		if (!(photonPlayer != null))
		{
			throw new AssertionFailedException("p != null");
		}
		return photonPlayer;
	}

	protected PhotonPlayer setupRaidComponents(PlayerControl pl)
	{
		if (!(pl != null))
		{
			throw new AssertionFailedException("pl != null");
		}
		GameObject gameObject = pl.gameObject;
		PhotonPlayer photonPlayer = ExtensionsModule.SetComponent<PhotonPlayer>(gameObject);
		if (!(photonPlayer != null))
		{
			throw new AssertionFailedException("p != null");
		}
		photonPlayer.ClientMain = this;
		GameObject gameObject2 = GameObject.Find("c0001_model");
		if (gameObject2 != null)
		{
			gameObject2.SetActive(value: false);
		}
		RaidRingWall.Constraint(gameObject, 19f);
		if (boss != null)
		{
			GameObject target = boss.gameObject;
			RaidBossTerritory.Constraint(pl.gameObject, target, bossTerritoryRadius);
		}
		return photonPlayer;
	}

	protected void disposeOwnedPlayerComponents()
	{
		if (!(ownedPlayer == null))
		{
			PhotonPlayer component = ownedPlayer.gameObject.GetComponent<PhotonPlayer>();
			if (component != null)
			{
				UnityEngine.Object.Destroy(component);
			}
			RaidRingWall component2 = ownedPlayer.gameObject.GetComponent<RaidRingWall>();
			if (component2 != null)
			{
				UnityEngine.Object.Destroy(component2);
			}
			RaidBossTerritory component3 = ownedPlayer.gameObject.GetComponent<RaidBossTerritory>();
			if (component3 != null)
			{
				UnityEngine.Object.Destroy(component3);
			}
		}
	}

	protected IEnumerator<object> friendSpawnRoutine(int ano, string aname, EnumGenders angelGender, EnumGenders demonGender, WeaponEquipments weaponEquipments, System.Collections.Generic.List<RespPoppet> poppetList, RespFriend friend, PlayerRaidData playerRaidData)
	{
		return new _0024friendSpawnRoutine_002419102(ano, aname, angelGender, demonGender, weaponEquipments, poppetList, friend, playerRaidData, this).GetEnumerator();
	}

	protected void restorePlayerHP()
	{
		if (!(ownedPlayer == null))
		{
			PlayerControl pCon = ownedPlayer.PCon;
			if (pCon != null)
			{
				float num = pCon.MaxHitPoint * 0.1f;
				pCon.addHP(num);
				Vector3 position = pCon.transform.position;
				DamageDisplay.Heal(position, checked((int)num));
			}
		}
	}

	protected void tryEventEnter(int ano, IDictionary<byte, object> p)
	{
		byte b = (byte)55;
		if (isUnentriedPlayer(ano))
		{
			otherActorNumbers.Add(ano);
		}
	}

	protected void eventLeave(int ano)
	{
		killOther(ano);
	}

	protected void eventOtherDead(object ano)
	{
		killOther(ano);
	}

	protected void killOther(object ano)
	{
		if (!isEntriedPlayer(RuntimeServices.UnboxInt32(ano)))
		{
			return;
		}
		if (isRealizedPlayer(RuntimeServices.UnboxInt32(ano)))
		{
			PhotonPlayer photonPlayer = otherPlayers[RuntimeServices.UnboxInt32(ano)];
			DebugReturn(new StringBuilder("delete player ").Append(ano).Append("=").Append(photonPlayer.name)
				.ToString());
			otherPlayers.Remove(RuntimeServices.UnboxInt32(ano));
			if (isQueuePlayer(RuntimeServices.UnboxInt32(ano)))
			{
				queuePlayers.Remove(RuntimeServices.UnboxInt32(ano));
			}
			Vector3 position = photonPlayer.transform.position;
			position.y = 0f;
			if (smokeEffect != null)
			{
				UnityEngine.Object.Instantiate(smokeEffect, position, Quaternion.identity);
			}
			UnityEngine.Object.Destroy(photonPlayer.gameObject);
		}
		if (isEntriedPlayer(RuntimeServices.UnboxInt32(ano)))
		{
			otherActorNumbers.Remove(RuntimeServices.UnboxInt32(ano));
		}
	}

	protected void eventBossDead()
	{
		DebugReturn(new StringBuilder("event BossDead!!! bossIsDead:").Append(bossIsDead).ToString());
		if (!bossIsDead)
		{
			if (boss != null)
			{
				boss.playAnimation(PlayerAnimationTypes.YarareDead);
				boss.forceSetHitPoint(0);
				rpcRandomWord(EnumRaidWordTypes.KillBoss, aOwn: true, 1f);
			}
			bossIsDead = true;
			bossDeadExitTimer = 2f;
			gameObject.SendMessage("explode", null, SendMessageOptions.DontRequireReceiver);
		}
	}

	protected void eventUpdatePlayer(int ano, Hashtable d)
	{
		if (!isRealizedPlayer(ano) || d == null || !d.ContainsKey((byte)57))
		{
			return;
		}
		PhotonPlayer photonPlayer = otherPlayers[ano];
		if (photonPlayer.IsReady)
		{
			object obj = d[(byte)57];
			if (!(obj is Hashtable))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
			}
			photonPlayer.setRecvData((Hashtable)obj);
		}
	}

	protected bool isUnentriedPlayer(int ano)
	{
		bool num = ano != ActorNumber;
		if (num)
		{
			num = !otherActorNumbers.Contains(ano);
		}
		return num;
	}

	protected bool isEntriedPlayer(int ano)
	{
		bool num = ano != ActorNumber;
		if (num)
		{
			num = otherActorNumbers.Contains(ano);
		}
		return num;
	}

	protected bool isRealizedPlayer(int ano)
	{
		bool num = ano != ActorNumber;
		if (num)
		{
			num = otherPlayers.ContainsKey(ano);
		}
		return num;
	}

	protected int realizedPlayerNum()
	{
		return ((ICollection)otherPlayers).Count;
	}

	protected void clearQueuePlayer()
	{
		queuePlayers.Clear();
	}

	protected bool isQueuePlayer(int ano)
	{
		bool num = ano != ActorNumber;
		if (num)
		{
			num = queuePlayers.Contains(ano);
		}
		return num;
	}

	protected int queuePlayerNum()
	{
		return ((ICollection)queuePlayers).Count;
	}

	protected bool isUnknownActor(int ano)
	{
		bool num = !isRealizedPlayer(ano);
		if (!num)
		{
			num = !otherPlayers[ano].HasName;
		}
		return num;
	}

	protected void updateActorList(int[] alist)
	{
		if (alist == null)
		{
			return;
		}
		int i = 0;
		checked
		{
			for (int length = alist.Length; i < length; i++)
			{
				tryEventEnter(alist[i], null);
			}
			int j = 0;
			int[] array = (int[])Builtins.array(typeof(int), otherPlayers.Keys);
			for (int length2 = array.Length; j < length2; j++)
			{
				bool flag = false;
				int k = 0;
				for (int length3 = alist.Length; k < length3; k++)
				{
					if (alist[k] == array[j])
					{
						flag = true;
					}
				}
				if (!flag)
				{
					eventLeave(array[j]);
				}
			}
		}
	}

	public short[] fixPositionOnBaseTransform(Vector3 pos)
	{
		Vector3 vector = positionOnBaseTransform(pos);
		return new short[3]
		{
			singleToFix16(vector.x),
			singleToFix16(vector.y),
			singleToFix16(vector.z)
		};
	}

	public Vector3 positionOnBaseTransform(Vector3 pos)
	{
		float x = pos.x - transformBase.position.x;
		float y = pos.y - transformBase.position.y;
		float z = pos.z - transformBase.position.z;
		return new Vector3(x, y, z);
	}

	public Vector3 positionOnWorldFromFix(short x, short y, short z)
	{
		float x2 = fix16ToSingle(x);
		float y2 = fix16ToSingle(y);
		float z2 = fix16ToSingle(z);
		return positionOnWorld(x2, y2, z2);
	}

	public Vector3 positionOnWorld(float x, float y, float z)
	{
		float x2 = x + transformBase.position.x;
		float y2 = y + transformBase.position.y;
		float z2 = z + transformBase.position.z;
		return new Vector3(x2, y2, z2);
	}

	public short fixRotationOnBaseTransformInRadian(Vector3 forward)
	{
		return singleToFix16(rotationOnBaseTransformInRadian(forward));
	}

	public float rotationOnBaseTransformInRadian(Vector3 forward)
	{
		return Mathf.Atan2(forward.x, forward.z);
	}

	public float rotationOnWorldInDegreeFromFix(short yInRadian)
	{
		return rotationOnWorldInDegree(fix16ToSingle(yInRadian));
	}

	public float rotationOnWorldInDegree(float yInRadian)
	{
		return 57.29578f * yInRadian;
	}

	public static short singleToFix16(float d)
	{
		return checked((short)(d / 100f * 30000f));
	}

	public static float fix16ToSingle(short d)
	{
		return (float)d * 100f / 30000f;
	}

	protected void effectSender(GameObject eff, Vector3 pos, Quaternion rot)
	{
		DebugReturn(new StringBuilder("Damage !!!! pos:").Append(pos).Append(" ").Append(rot)
			.ToString());
	}

	protected void effectReceiver(GameObject eff, Vector3 pos, Quaternion rot)
	{
	}

	protected void pushAction(int code, Hashtable commandData)
	{
		if (code != 1)
		{
			DebugReturn("action " + (MerlinActionCommandType)code);
		}
		if (commandData == null)
		{
			commandData = new Hashtable();
		}
		commandData[(byte)1] = code;
		commandData[(byte)101] = eventSerial;
		commandData[(byte)102] = MerlinDateTime.Now.ToBinary();
		buffer.Add(commandData);
	}

	protected void sendAction()
	{
		sendTimer -= Time.deltaTime;
		if (!(sendTimer > 0f))
		{
			raiseUpdatePlayer(ownedPlayer);
			Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
			Hashtable hashtable = new Hashtable();
			hashtable[(byte)128] = buffer.ToArray();
			dictionary[(byte)211] = hashtable;
			opCustom(211, dictionary);
			buffer.Clear();
			sendTimer = DefaultSendTimer;
		}
	}

	protected void opCustom(int op, Dictionary<byte, object> @params)
	{
		if (Peer != null)
		{
			if (@params == null)
			{
				@params = new Dictionary<byte, object>();
			}
			Peer.OpCustom(checked((byte)op), @params, reliable);
			Peer.SendOutgoingCommands();
		}
	}

	protected CommTickData eventCommData(int code)
	{
		CommTickData commTickData = newCommData(code, CommType.Event);
		commTickData.serial = checked(++eventSerial);
		return commTickData;
	}

	protected CommTickData respCommData(int code)
	{
		return newCommData(code, CommType.Response);
	}

	protected CommTickData newCommData(int code, CommType ctype)
	{
		CommTickData commTickData = new CommTickData();
		commTickData.code = code;
		commTickData.type = ctype;
		commTickData.time = Time.realtimeSinceStartup;
		commTickData.delta = ((this.commTickData.Count > 0) ? (commTickData.time - this.commTickData.Last().time) : 0f);
		commTickData.frame = Time.frameCount;
		commTickData.dateTime = MerlinDateTime.Now.ToString();
		this.commTickData.Add(commTickData);
		return commTickData;
	}

	protected void OpJoin(string roomName, Hashtable d)
	{
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[(byte)byte.MaxValue] = roomName;
		dictionary[(byte)249] = d;
		opCustom(255, dictionary);
	}

	protected void OpLeave()
	{
		Dictionary<byte, object> @params = new Dictionary<byte, object>();
		opCustom(254, @params);
	}

	protected string toStr(Hashtable d)
	{
		string text = string.Empty;
		IEnumerator enumerator = d.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object current = enumerator.Current;
			text += new StringBuilder().Append(current).Append(":").Append(d[current])
				.Append(" ")
				.ToString();
		}
		return text;
	}

	protected bool hasWord(EnumRaidWordTypes aType)
	{
		bool result = false;
		UserData current = UserData.Current;
		UserMiscInfo.RaidData raidData = current.userMiscInfo.raidData;
		int[] array = raidData.Get(aType);
		if (array != null)
		{
			int length = array.Length;
			result = length != 0;
		}
		return result;
	}

	protected int getRandomMasterWordIndex(EnumRaidWordTypes aType)
	{
		UserData current = UserData.Current;
		UserMiscInfo.RaidData raidData = current.userMiscInfo.raidData;
		int[] array = raidData.Get(aType);
		int length = array.Length;
		int index = UnityEngine.Random.Range(0, length);
		return array[RuntimeServices.NormalizeArrayIndex(array, index)];
	}

	protected string getWord(int aMasterIndex)
	{
		MRaidWords mRaidWords = MRaidWords.Get(aMasterIndex);
		return mRaidWords.Name.ToString();
	}

	protected void pushWord(EnumRaidWordTypes aType, int aMasterIndex)
	{
		Hashtable hashtable = new Hashtable();
		hashtable[(byte)61] = aType;
		hashtable[62] = aMasterIndex;
		pushAction(7, hashtable);
	}

	public int rpcRandomWord(EnumRaidWordTypes aType, bool aOwn, float aRnd)
	{
		int num = -1;
		bool flag = true;
		if (!(aRnd >= 1f))
		{
			float num2 = UnityEngine.Random.Range(0f, 1f);
			if (!(aRnd >= num2))
			{
				flag = false;
			}
		}
		if (flag && hasWord(aType))
		{
			num = getRandomMasterWordIndex(aType);
			if (aOwn)
			{
				string word = getWord(num);
				ownedPlayer.shoutWord(word);
			}
			pushWord(aType, num);
		}
		return num;
	}

	protected void eventWord(int ano, Hashtable d)
	{
		if (isRealizedPlayer(ano))
		{
			PhotonPlayer photonPlayer = otherPlayers[ano];
			if (photonPlayer.IsReady)
			{
				byte b = RuntimeServices.UnboxByte(d[(byte)61]);
				int aMasterIndex = RuntimeServices.UnboxInt32(d[62]);
				string word = getWord(aMasterIndex);
				photonPlayer.shoutWord(word);
			}
		}
	}

	protected void eventBossAbnormalState(int ano, Hashtable data)
	{
		if (!isRealizedPlayer(ano))
		{
			return;
		}
		PhotonPlayer photonPlayer = otherPlayers[ano];
		if (photonPlayer.IsReady)
		{
			EnumAbnormalStates enumAbnormalStates = (EnumAbnormalStates)data[(byte)67];
			if (enumAbnormalStates != 0)
			{
				boss.setAbnormalState(enumAbnormalStates);
			}
		}
	}

	protected void pushBossAbnormalState(EnumAbnormalStates abst)
	{
		Hashtable hashtable = new Hashtable();
		hashtable[(byte)67] = (int)abst;
		pushAction(8, hashtable);
	}

	public static void SavePlayInfo(ApiGuildRaidStart.Resp sresp)
	{
		if (sresp == null)
		{
			DeleteSaveData();
			return;
		}
		Hashtable hashtable = new Hashtable();
		hashtable["CycleId"] = sresp.CycleId;
		hashtable["TicketId"] = sresp.TicketId;
		ObjUtilModule.SaveString("riseofmana.raid", NGUIJson.jsonEncode(hashtable));
	}

	public static ApiGuildResult LoadPlayInfo()
	{
		string text = ObjUtilModule.LoadString("riseofmana.raid");
		object result;
		if (string.IsNullOrEmpty(text))
		{
			result = null;
		}
		else
		{
			object obj = NGUIJson.jsonDecode(text);
			if (obj is Hashtable)
			{
				Hashtable hashtable = obj as Hashtable;
				if (!hashtable.ContainsKey("CycleId"))
				{
					result = null;
				}
				else if (!hashtable.ContainsKey("TicketId"))
				{
					result = null;
				}
				else
				{
					ApiGuildResult apiGuildResult2;
					try
					{
						ApiGuildResult apiGuildResult = new ApiGuildResult();
						apiGuildResult.CycleId = RuntimeServices.UnboxInt32(hashtable["CycleId"]);
						object obj2 = hashtable["TicketId"];
						if (!(obj2 is string))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(string));
						}
						apiGuildResult.TicketId = (string)obj2;
						apiGuildResult2 = apiGuildResult;
					}
					catch (Exception)
					{
						apiGuildResult2 = null;
					}
					result = apiGuildResult2;
				}
			}
			else
			{
				result = null;
			}
		}
		return (ApiGuildResult)result;
	}

	public static void DeleteSaveData()
	{
		ObjUtilModule.DeletePersistenData("riseofmana.raid");
	}

	public static string toNguiJsonArrayString(string[] strs)
	{
		int i = 0;
		checked
		{
			for (int length = strs.Length; i < length; i++)
			{
			}
			string text = string.Empty;
			int j = 0;
			for (int length2 = strs.Length; j < length2; j++)
			{
				text += strs[j];
				text += "]]]]";
			}
			return text;
		}
	}

	public static string[] fromNguiJsonArrayString(string str)
	{
		string[] array = str.Split((char[])Builtins.array(typeof(char), "]]]]"), StringSplitOptions.RemoveEmptyEntries);
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
		}
		return array;
	}

	internal void _0024setPlayerHandlers_0024closure_00243098(GameObject ene)
	{
	}

	internal void _0024setPlayerHandlers_0024closure_00243099(int damage)
	{
		if (State == ClientState.InRoom)
		{
			rpcDamage(damage);
		}
	}

	internal void _0024setPlayerHandlers_0024closure_00243100(int skillID, bool isTensi)
	{
		if (State == ClientState.InRoom)
		{
			rpcUseSkillEvent(skillID, isTensi);
			rpcRandomWord(EnumRaidWordTypes.Skill, aOwn: true, 0.25f);
		}
	}
}
