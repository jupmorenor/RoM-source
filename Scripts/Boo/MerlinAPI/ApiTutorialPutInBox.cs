using System;

namespace MerlinAPI;

[Serializable]
public class ApiTutorialPutInBox : RequestBase
{
	[Serializable]
	public class Resp : GameApiResponseBase
	{
		public RespPlayerBox[] Box;
	}

	public int Id;

	public bool IsRandom;

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

	public override string ApiPath => "/Tutorial/PutInBox";

	public override ServerType Server => ServerType.Game;

	public ApiTutorialPutInBox(int id)
	{
		Id = id;
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
