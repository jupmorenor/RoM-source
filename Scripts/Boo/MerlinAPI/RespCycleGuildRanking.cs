using System;

namespace MerlinAPI;

[Serializable]
public class RespCycleGuildRanking : JsonBase
{
	public int Id;

	public int TCycleId;

	public int TCycleGuildId;

	public int Ranking;

	public long RankingPoint;

	public bool IsPresented;
}
