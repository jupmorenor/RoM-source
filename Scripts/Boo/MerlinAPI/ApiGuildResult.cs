using System;

namespace MerlinAPI;

[Serializable]
public class ApiGuildResult : RequestBase
{
	[Serializable]
	public class Resp : GameApiResponseBase
	{
		public RespPlayerPresentBox[] PresentBox;

		public int Point;

		public long TotalPoint;

		public RespTCycleRaidBattle RaidBattle;

		public RespPlayerInfo PlayerInfo;

		public bool IsCallLeave;

		public RespCycleGuildPlayerRanking PlayerRanking;

		public RespCycleGuildRanking GuildRanking;

		public int Damage;

		public Resp()
		{
			IsCallLeave = true;
		}
	}

	public int CycleId;

	public int Damage;

	public bool IsDead;

	public string TicketId;

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

	public override string ApiPath => "/Guild/Result";

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
