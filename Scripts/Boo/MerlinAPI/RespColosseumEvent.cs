using System;
using System.Text;

namespace MerlinAPI;

[Serializable]
public class RespColosseumEvent : JsonBase
{
	public int Id;

	public bool IsFriendCompetition;

	public int FriendPoint;

	public int Coin;

	public int BpCost;

	public int ManaFragment;

	public bool IsRankingEvent;

	public int MItemGroupId;

	public DateTime BeginDate;

	public DateTime EndDate;

	public bool IsCostLimit;

	public bool IsElementLimit;

	public bool IsStyleLimit;

	public bool IsMinRarityLimit;

	public bool IsMaxRarityLimit;

	public int CostLimit;

	public int ElementLimit;

	public int StyleLimit;

	public int MinRarityLimit;

	public int MaxRarityLimit;

	public string BannerHtml;

	public string Name
	{
		get
		{
			MColosseumEvents mColosseumEvents = MColosseumEvents.Get(Id);
			return (mColosseumEvents == null) ? new StringBuilder("闘技場イベント").Append((object)Id).ToString() : mColosseumEvents.Name;
		}
	}

	public static RespColosseumEvent FromMaster(MColosseumEvents m)
	{
		RespColosseumEvent respColosseumEvent = new RespColosseumEvent();
		respColosseumEvent.Id = m.Id;
		respColosseumEvent.IsFriendCompetition = m.IsFriendCompetition;
		respColosseumEvent.BpCost = m.BpCost;
		respColosseumEvent.IsRankingEvent = m.IsRankingEvent;
		respColosseumEvent.BeginDate = m.BeginDate;
		respColosseumEvent.EndDate = m.EndDate;
		respColosseumEvent.IsCostLimit = m.IsCostLimit;
		respColosseumEvent.IsElementLimit = m.IsElementLimit;
		respColosseumEvent.IsStyleLimit = m.IsStyleLimit;
		respColosseumEvent.IsMinRarityLimit = m.IsMinRarityLimit;
		respColosseumEvent.IsMaxRarityLimit = m.IsMaxRarityLimit;
		respColosseumEvent.CostLimit = m.CostLimit;
		respColosseumEvent.ElementLimit = (int)m.ElementLimit;
		respColosseumEvent.StyleLimit = (int)m.StyleLimit;
		respColosseumEvent.MinRarityLimit = (int)m.MinRarityLimit;
		respColosseumEvent.MaxRarityLimit = (int)m.MaxRarityLimit;
		return respColosseumEvent;
	}
}
