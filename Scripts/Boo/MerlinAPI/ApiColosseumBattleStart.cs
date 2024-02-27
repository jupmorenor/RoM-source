using System;

namespace MerlinAPI;

[Serializable]
public class ApiColosseumBattleStart : RequestBase
{
	[Serializable]
	public class Resp : GameApiResponseBase
	{
		public bool MaybePromoted;

		public bool MaybeDemoted;

		public RespOpponentWithOrganize Opponent;
	}

	public bool IsNPC;

	public int Id;

	public string DataKey;

	public string RequestDate;

	public int[] DailyPassiveSkills;

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

	public override string ApiPath => "/Colosseum/BattleStart";

	public override ServerType Server => ServerType.Game;

	public ApiColosseumBattleStart()
	{
		DailyPassiveSkills = new int[0];
		RequestDate = MerlinDateTime.UtcNow.ToString();
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
