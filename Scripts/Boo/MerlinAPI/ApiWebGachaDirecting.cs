using System;

namespace MerlinAPI;

[Serializable]
public class ApiWebGachaDirecting : RequestBase
{
	public int SaleGachaId;

	private bool _0024initialized__MerlinAPI_ApiWebGachaDirecting_0024;

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

	public override string ApiPath => "/Web/Gacha/Directing";

	public override ServerType Server => ServerType.Game;

	public ApiWebGachaDirecting()
	{
		if (!_0024initialized__MerlinAPI_ApiWebGachaDirecting_0024)
		{
			_0024initialized__MerlinAPI_ApiWebGachaDirecting_0024 = true;
		}
	}

	public ApiWebGachaDirecting(int gachaId)
	{
		if (!_0024initialized__MerlinAPI_ApiWebGachaDirecting_0024)
		{
			_0024initialized__MerlinAPI_ApiWebGachaDirecting_0024 = true;
		}
		SaleGachaId = gachaId;
	}

	public GameApiResponseBase GetResponse()
	{
		return ResponseObj as GameApiResponseBase;
	}

	public override Type responseType()
	{
		return typeof(GameApiResponseBase);
	}
}
