using System;

namespace MerlinAPI;

[Serializable]
public class RespColosseumEventRanking : JsonBase
{
	public int MColosseumEventId;

	public int TSocialPlayerId;

	public int Ranking;

	public double RankingPoint;
}
