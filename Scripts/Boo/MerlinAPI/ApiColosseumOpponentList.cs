using System;

namespace MerlinAPI;

[Serializable]
public class ApiColosseumOpponentList : RequestBase
{
	[Serializable]
	public class RespColosseumOpponentList : GameApiResponseBase
	{
		public RespOpponent[] Opponent;
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

	public override string ApiPath => "/Colosseum/OpponentList";

	public override ServerType Server => ServerType.Game;

	public RespColosseumOpponentList GetResponse()
	{
		return ResponseObj as RespColosseumOpponentList;
	}

	public override Type responseType()
	{
		return typeof(RespColosseumOpponentList);
	}
}
