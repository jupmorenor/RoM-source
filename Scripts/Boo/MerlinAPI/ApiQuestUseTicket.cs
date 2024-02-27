using System;

namespace MerlinAPI;

[Serializable]
public class ApiQuestUseTicket : RequestBase
{
	[Serializable]
	public class Resp : GameApiResponseBase
	{
		public RespQuestTicket[] QuestTickets;
	}

	public int Id;

	private bool _0024initialized__MerlinAPI_ApiQuestUseTicket_0024;

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

	public override string ApiPath => "/Quest/UseTicket";

	public override ServerType Server => ServerType.Game;

	public ApiQuestUseTicket()
	{
		if (!_0024initialized__MerlinAPI_ApiQuestUseTicket_0024)
		{
			_0024initialized__MerlinAPI_ApiQuestUseTicket_0024 = true;
		}
	}

	public ApiQuestUseTicket(int ticketId)
	{
		if (!_0024initialized__MerlinAPI_ApiQuestUseTicket_0024)
		{
			_0024initialized__MerlinAPI_ApiQuestUseTicket_0024 = true;
		}
		Id = ticketId;
	}

	public Resp GetResponse()
	{
		return ResponseObj as Resp;
	}

	public override Type responseType()
	{
		return typeof(Resp);
	}
}
