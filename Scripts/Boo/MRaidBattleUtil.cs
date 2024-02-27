using System;
using MerlinAPI;

[Serializable]
public class MRaidBattleUtil
{
	public static MBgm RaidBossBgm(RespTCycleRaidBattle raidBattle)
	{
		return (raidBattle == null) ? null : MRaidBattles.FindByMonster(raidBattle.MMonsterId)?.Bgm;
	}
}
