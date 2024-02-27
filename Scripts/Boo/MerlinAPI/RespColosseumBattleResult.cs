using System;

namespace MerlinAPI;

[Serializable]
public class RespColosseumBattleResult : GameApiResponseBase
{
	public RespBreeder Breeder;

	public RespPlayerPresentBox[] PresentBox;

	public long BreederRankPoint;

	public string BreederRankRewards;

	public string EventRankRewards;

	public int Coin;

	public int FriendPoint;

	public int ManaFragment;

	public RespPlayerInfo PlayerInfo;

	public RespColosseumEvent ColosseumEvent;

	public RespColosseumEventRanking ColosseumEventRanking;

	public double ColosseumEventTotalRankingPoint;

	public double ColosseumEventRankPoint;

	public int ColosseumEventNeedToNextNormaRankPoint;

	public RespReward[] createBreederRankRewards()
	{
		return RespReward.JsonArrayToRespRewards(BreederRankRewards);
	}

	public RespReward[] createEventRankRewards()
	{
		return RespReward.JsonArrayToRespRewards(EventRankRewards);
	}
}
