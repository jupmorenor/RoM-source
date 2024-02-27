using System;
using System.Text;

namespace MerlinAPI;

[Serializable]
public class ApiHome : RequestBase
{
	[Serializable]
	public class Resp : GameApiResponseBase
	{
		public RespPlayer Player;

		public RespPlayerInfo PlayerInfo;

		public RespDeck[] Decks;

		public RespDeck2[] Decks2;

		public RespCycleGuildPlayerRanking PlayerRanking;

		public RespPlayerPresentBox[] PresentBox;

		public int[] SuccessfulStories;

		public RespFriend[] Friend;

		public RespApplyInfo[] FriendApplies;

		public RespParty PartyMember;

		public RespApplyInfo[] PartyApplies;

		public RespTCycleRaidBattle RaidBattle;

		public RespGuildPlayer[] GuildPlayer;

		public RespCampaign[] Campaigns;

		public RespPlayerBox[] Box;

		public RespPlayerKeyItem[] KeyItems;

		public RespCycleGuildRanking GuildRanking;

		public RespPlayerLogin[] PlayerLogin;

		public RespChallengeQuestRankings QuestRanking;

		public string InviteCode;

		public RespQuestTicket[] QuestTickets;

		public int[] CompBonusComleted;

		public int[] CompBonusAchieved;

		public RespPoppetDeck[] PoppetDecks;

		public RespBreeder Breeder;

		public RespColosseumEvent ColosseumEvent;

		public RespColosseumEventRanking ColosseumEventRanking;

		public double ColosseumEventTotalRankingPoint;

		public RespQuestMission[] ClearQuestMissions;

		public int[] NewQuestMissionIds;

		public bool IsHasNewMission;

		public RespQuestMission[] QuestMissions;

		public int[] DailyPassiveSkills;

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(base.ToString() + "\n");
			stringBuilder.Append(PlayerInfo.ToString() + "\n");
			stringBuilder.Append(ServerUtilModule.ArrayToDebugString(Decks));
			stringBuilder.Append(ServerUtilModule.ArrayToDebugString(Box));
			stringBuilder.Append(ServerUtilModule.ArrayToDebugString(Friend));
			return stringBuilder.ToString();
		}
	}

	public override bool IsOk
	{
		get
		{
			bool num;
			if (!(ResponseObj is GameApiResponseBase gameApiResponseBase))
			{
				num = base.IsOk;
			}
			else
			{
				num = base.IsOk;
				if (num)
				{
					num = gameApiResponseBase.IsOkStatusCode;
				}
			}
			return num;
		}
	}

	public override bool HasValidStatus
	{
		get
		{
			GameApiResponseBase gameApiResponseBase = ResponseObj as GameApiResponseBase;
			bool num = gameApiResponseBase != null;
			if (num)
			{
				num = !string.IsNullOrEmpty(gameApiResponseBase.StatusCode);
			}
			return num;
		}
	}

	public override string ApiPath => "/home/";

	public override ServerType Server => ServerType.Game;

	public Resp GetResponse()
	{
		return ResponseObj as Resp;
	}

	public override Type responseType()
	{
		return typeof(Resp);
	}

	protected override void doPostRequestJob()
	{
		base.doPostRequestJob();
		MerlinLocalNotification.activateNotification = true;
	}
}
