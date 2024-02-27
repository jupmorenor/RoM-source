using System;

namespace MerlinAPI;

[Serializable]
public class ApiWebGachaDirectingWeapon : RequestBase
{
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

	public override string ApiPath => "/Web/Gacha/DirectingWeapon";

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
