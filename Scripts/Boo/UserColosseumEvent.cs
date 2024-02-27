using System;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;

[Serializable]
public class UserColosseumEvent
{
	private RespColosseumEvent[] colosseumEvent;

	private RespColosseumEventRanking colosseumEventRanking;

	private double colosseumEventTotalRankingPoint;

	private int[] dailyPassiveSkills;

	public RespColosseumEvent[] ColosseumEvent => colosseumEvent;

	public RespColosseumEventRanking ColosseumEventRanking => colosseumEventRanking;

	public double ColosseumEventTotalRankingPoint => colosseumEventTotalRankingPoint;

	public int[] DailyPassiveSkills => dailyPassiveSkills;

	public UserColosseumEvent()
	{
		colosseumEvent = new RespColosseumEvent[0];
		dailyPassiveSkills = new int[0];
	}

	public void setColosseumEvent(RespColosseumEvent[] events)
	{
		if (events != null)
		{
			colosseumEvent = events;
			if (Array.Find(events, _0024adaptor_0024__UserData_0024callable347_00242443_43___0024Predicate_0024150.Adapt((RespColosseumEvent e) => e.IsFriendCompetition)) == null)
			{
				MColosseumEvents activeFriendEvent = MColosseumEvents.GetActiveFriendEvent();
				if (activeFriendEvent != null)
				{
					colosseumEvent = (RespColosseumEvent[])RuntimeServices.AddArrays(typeof(RespColosseumEvent), colosseumEvent, new RespColosseumEvent[1] { RespColosseumEvent.FromMaster(activeFriendEvent) });
				}
			}
		}
		else
		{
			colosseumEvent = new RespColosseumEvent[0];
		}
	}

	public void setColosseumEventRanking(RespColosseumEventRanking ranking)
	{
		colosseumEventRanking = ranking;
	}

	public void setColosseumEventTotalRankingPoint(double pnt)
	{
		colosseumEventTotalRankingPoint = pnt;
	}

	public void setDailyPassiveSkills(int[] skillIds)
	{
		if (skillIds != null)
		{
			dailyPassiveSkills = skillIds;
		}
		else
		{
			dailyPassiveSkills = new int[0];
		}
	}

	internal bool _0024setColosseumEvent_0024closure_00244015(RespColosseumEvent e)
	{
		return e.IsFriendCompetition;
	}
}
