using System;

namespace MerlinAPI;

[Serializable]
public class ApiGuildRaidStart : RequestBase
{
	[Serializable]
	public class Resp : GameApiResponseBase
	{
		public string Server;

		public string RoomName;

		public int CycleId;

		public RespTCycleRaidBattle RaidBattle;

		public int FriendPoint;

		public string TicketId;
	}

	public int UseRp;

	public int RecommendId;

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

	public override string ApiPath => "/Guild/RaidStart";

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
