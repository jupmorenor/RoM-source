using System;

namespace MerlinAPI;

[Serializable]
public class RespChallengeQuestRankings : JsonBase
{
	public int Id;

	public int MQuestId;

	public int TSocialPlayerId;

	public int Ranking;

	public long RankingPoint;
}
