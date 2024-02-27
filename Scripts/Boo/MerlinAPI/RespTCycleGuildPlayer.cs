using System;

namespace MerlinAPI;

[Serializable]
public class RespTCycleGuildPlayer : JsonBase
{
	public int Id;

	public long DailyRankingPoint;

	public long TotalRankingPoint;

	public int TCycleId;

	public int TCycleGuildId;

	public int TSocialPlayerId;

	public DateTime LastExitDate;

	public int ComboLevel;

	public double DamageMagnification;

	public bool IsRaidStart;
}
