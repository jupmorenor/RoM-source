using System;

namespace MerlinAPI;

[Serializable]
public class ApiColosseumBattleResult : RequestBase
{
	public string TicketId;

	public int GameResultIs;

	public int Hp;

	public int OpponentHp;

	public int MaxGivenDamage;

	public int TotalGivenDamage;

	public int MaxDamage;

	public int TotalDamage;

	public string DataKey;

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

	public override string ApiPath => "/Colosseum/BattleResult";

	public override ServerType Server => ServerType.Game;

	public RespColosseumBattleResult GetResponse()
	{
		return ResponseObj as RespColosseumBattleResult;
	}

	public override Type responseType()
	{
		return typeof(RespColosseumBattleResult);
	}
}
