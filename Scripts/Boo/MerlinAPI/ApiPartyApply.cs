using System;

namespace MerlinAPI;

[Serializable]
public class ApiPartyApply : RequestBase
{
	[NonSerialized]
	public static readonly string[] DefIgnoreErrorCodes = new string[4] { "PaApp001", "PaApp002", "PaApp003", "PaApp004" };

	public int Id;

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

	public override string ApiPath => "/Party/Apply";

	public override ServerType Server => ServerType.Game;

	public GameApiResponseBase GetResponse()
	{
		return ResponseObj as GameApiResponseBase;
	}

	public override Type responseType()
	{
		return typeof(GameApiResponseBase);
	}
}
