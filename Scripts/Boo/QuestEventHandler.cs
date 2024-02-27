using System;
using System.Collections;
using Boo.Lang.Runtime;
using MerlinAPI;

[Serializable]
public class QuestEventHandler : PlayerEventAdapter
{
	[NonSerialized]
	private static QuestBattleStatistics _BattleInfo = new QuestBattleStatistics();

	private bool listeningEnabled;

	private int pauseCount;

	public static int BattleTotalDamageCount => _BattleInfo.battleTotalDamageCount;

	public static int PlayerAbnormalStateCount => _BattleInfo.playerAbnormalStateCount;

	public static int PlayerDamageCount => _BattleInfo.playerDamageCount;

	public static float PlayerCurrentPlayTime => _BattleInfo.playerCurrentPlayTime;

	public static float PlayerTotalAttack => _BattleInfo.playerTotalAttack;

	public static float PlayerTotalHP => _BattleInfo.playerTotalHP;

	public static float PlayerLastHP => _BattleInfo.playerLastHp;

	private static void SetBattleInfo(QuestBattleStatistics btlInfo)
	{
		if (btlInfo != null)
		{
			_BattleInfo = btlInfo;
		}
		else
		{
			_BattleInfo.reset();
		}
	}

	public static void InitBattleInfo(float atk, float hp)
	{
		_BattleInfo.reset();
		_BattleInfo.playerTotalAttack = atk;
		_BattleInfo.playerTotalHP = hp;
	}

	public static string SerializeToJson()
	{
		return NGUIJson.jsonEncode(RequestBase.ToJsonData(_BattleInfo));
	}

	public static QuestBattleStatistics DeserializeFromJson(string json)
	{
		QuestBattleStatistics questBattleStatistics = null;
		if (!string.IsNullOrEmpty(json))
		{
			object obj = NGUIJson.jsonDecode(json);
			if (!(obj is Hashtable))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
			}
			Hashtable data = (Hashtable)obj;
			object obj2 = JsonBase.CreateFromJson(typeof(QuestBattleStatistics), data);
			if (!(obj2 is QuestBattleStatistics))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(QuestBattleStatistics));
			}
			questBattleStatistics = (QuestBattleStatistics)obj2;
			if (questBattleStatistics != null)
			{
				SetBattleInfo(questBattleStatistics);
			}
		}
		return questBattleStatistics;
	}

	public void updatePlayTime(float sec)
	{
		if (pauseCount <= 0 && listeningEnabled)
		{
			_BattleInfo.playerCurrentPlayTime += sec;
		}
	}

	public override void eventQuestStart(PlayerControl player)
	{
		listeningEnabled = true;
		pauseCount = 0;
		InitBattleInfo(player.totalPlayerAttack(), player.totalPlayerHP());
	}

	public override void eventQuestRestart(PlayerControl player)
	{
		listeningEnabled = true;
		pauseCount = 0;
	}

	public override void eventQuestEnd(PlayerControl player)
	{
		listeningEnabled = false;
		_BattleInfo.playerLastHp = player.HitPoint;
	}

	public override void eventPlayerDamage(MerlinActionControl player)
	{
		checked
		{
			if (listeningEnabled && !player.IsDead)
			{
				_BattleInfo.battleTotalDamageCount++;
				_BattleInfo.playerDamageCount++;
			}
		}
	}

	public override void eventPoppetDamage(MerlinActionControl attacker, MerlinActionControl poppet, float damage)
	{
		if (listeningEnabled && !poppet.IsDead)
		{
			_BattleInfo.battleTotalDamageCount = checked(_BattleInfo.battleTotalDamageCount + 1);
		}
	}

	public override void eventMonsterDamage(MerlinActionControl monster)
	{
		if (listeningEnabled && !monster.IsDead)
		{
			_BattleInfo.battleTotalDamageCount = checked(_BattleInfo.battleTotalDamageCount + 1);
		}
	}

	public override void eventPlayerDown(MerlinActionControl player)
	{
		checked
		{
			if (listeningEnabled && !player.IsDead)
			{
				_BattleInfo.battleTotalDamageCount++;
				_BattleInfo.playerDamageCount++;
			}
		}
	}

	public override void eventPoppetDown(MerlinActionControl attacker, MerlinActionControl poppet, float damage)
	{
		if (listeningEnabled && !poppet.IsDead)
		{
			_BattleInfo.battleTotalDamageCount = checked(_BattleInfo.battleTotalDamageCount + 1);
		}
	}

	public override void eventMonsterDown(MerlinActionControl monster)
	{
		if (listeningEnabled && !monster.IsDead)
		{
			_BattleInfo.battleTotalDamageCount = checked(_BattleInfo.battleTotalDamageCount + 1);
		}
	}

	public override void eventResistAbnormalStateAttack(EnumAbnormalStates state, MerlinActionControl resister, MerlinActionControl attacker)
	{
		if (listeningEnabled && !resister.IsDead)
		{
			PlayerControl playerControl = resister as PlayerControl;
			if (playerControl != null && playerControl.useHUD)
			{
				BattleSignalHUD.resistAbnormalState(state);
			}
		}
	}

	public override void eventInfectAbnormalState(EnumAbnormalStates state, MerlinActionControl patient, MerlinActionControl attacker)
	{
		if (listeningEnabled && !patient.IsDead && patient is PlayerControl)
		{
			_BattleInfo.playerAbnormalStateCount = checked(_BattleInfo.playerAbnormalStateCount + 1);
		}
	}

	public override void eventPause()
	{
		checked
		{
			pauseCount++;
		}
	}

	public override void eventUnpause()
	{
		checked
		{
			if (pauseCount > 0)
			{
				pauseCount--;
			}
		}
	}

	public override void eventJumpStart()
	{
		checked
		{
			pauseCount++;
		}
	}

	public override void eventJumpEnd()
	{
		checked
		{
			pauseCount--;
		}
	}
}
