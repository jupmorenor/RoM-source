using System;
using MerlinAPI;

[Serializable]
public class UserRaidData
{
	public RespCycleGuildRanking guildRanking;

	public RespCycleGuildPlayerRanking guildPlayerRanking;

	public RespFriend[] guildPlayers;

	public RespTCycleRaidBattle raidBattle;

	[NonSerialized]
	private const int raidMaxTime = 3600;

	public static int RaidMaxTime => 3600;

	public void setGuildPlayerRanking(RespCycleGuildPlayerRanking d)
	{
		if (d != null)
		{
			guildPlayerRanking = d;
		}
	}

	public void setGuildRanking(RespCycleGuildRanking d)
	{
		if (d != null)
		{
			guildRanking = d;
		}
	}

	public void setGuildPlayers(RespFriend[] d)
	{
		if (!(d == null))
		{
			guildPlayers = d;
		}
	}

	public void setRaidBattle(RespTCycleRaidBattle d)
	{
		if (d != null)
		{
			raidBattle = d;
		}
	}

	public int getRaidLimitSec()
	{
		int result;
		if (raidBattle == null)
		{
			result = 0;
		}
		else
		{
			DateTime utcNow = MerlinDateTime.UtcNow;
			DateTime discoverDate = raidBattle.DiscoverDate;
			if ((int)discoverDate.Ticks == 0)
			{
				result = 0;
			}
			else
			{
				int num = checked(RaidMaxTime - (int)(utcNow - discoverDate).TotalSeconds);
				result = num;
			}
		}
		return result;
	}

	public int getRaidComboSec()
	{
		int result;
		if (raidBattle == null)
		{
			result = 0;
		}
		else
		{
			MComboBonus mComboBonus = MComboBonus.FindByLevel(raidBattle.ComboLevel);
			if (mComboBonus == null)
			{
				result = 0;
			}
			else
			{
				DateTime utcNow = MerlinDateTime.UtcNow;
				DateTime comboStartDate = raidBattle.ComboStartDate;
				if ((int)comboStartDate.Ticks == 0)
				{
					result = 0;
				}
				else
				{
					double totalSeconds = (mComboBonus.Duration - (utcNow - comboStartDate)).TotalSeconds;
					result = ((totalSeconds > 0.0) ? checked((int)totalSeconds) : 0);
				}
			}
		}
		return result;
	}
}
