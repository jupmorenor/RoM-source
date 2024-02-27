using System;

namespace MerlinAPI;

[Serializable]
public class ApiQuestStart : RequestBase
{
	public string DataKey;

	public int Id;

	public int RecommendId;

	public int Option;

	[NonSerialized]
	private static int errcnt;

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

	public override string ApiPath => "/Quest/Start";

	public override ServerType Server => ServerType.Game;

	public RespQuestStart GetResponse()
	{
		return ResponseObj as RespQuestStart;
	}

	public override Type responseType()
	{
		return typeof(RespQuestStart);
	}

	protected override string adjustDateTime()
	{
		return null;
	}
}
