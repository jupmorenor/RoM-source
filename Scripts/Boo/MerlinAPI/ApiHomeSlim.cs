using System;
using System.Text;

namespace MerlinAPI;

[Serializable]
public class ApiHomeSlim : RequestBase
{
	[Serializable]
	public class Resp : GameApiResponseBase
	{
		public RespPlayer Player;

		public RespPlayerInfo PlayerInfo;

		public RespDeck[] Decks;

		public RespCycleGuildPlayerRanking PlayerRanking;

		public RespPlayerPresentBox[] PresentBox;

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

	public override string ApiPath => "/home/Slim";

	public override ServerType Server => ServerType.Game;

	public Resp GetResponse()
	{
		return ResponseObj as Resp;
	}

	public override Type responseType()
	{
		return typeof(Resp);
	}
}
