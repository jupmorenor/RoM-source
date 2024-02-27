using System;

namespace MerlinAPI;

[Serializable]
public class RespQuestResult : GameApiResponseBase
{
	public int Exp;

	public int Coin;

	public string BoxId;

	public RespPlayerInfo PlayerInfo;

	public RespPlayerBox[] Box;

	public bool IsRaidDiscover;

	public RespTCycleRaidBattle RaidBattle;

	public long ChallengePoint;

	public long StoredChallengePoint;

	public bool IsFirstComplete;

	public int[] FirstCompleteReward;

	public string FirstClearReward;

	public RespQuestMission[] ClearQuestMissions;

	public int[] NewQuestMissionIds;

	public bool IsHasNewMission;

	public RespQuestMission[] QuestMissions;

	public RespReward[] createFirstClearRewards()
	{
		return RespReward.JsonArrayToRespRewards(FirstClearReward);
	}

	public int[] getDropBoxIds()
	{
		return (!string.IsNullOrEmpty(BoxId)) ? ApiGachaExec.Csv2Ints(BoxId) : new int[0];
	}
}
