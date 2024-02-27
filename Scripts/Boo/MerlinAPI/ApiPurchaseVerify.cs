using System;

namespace MerlinAPI;

[Serializable]
public class ApiPurchaseVerify : RequestBase
{
	[Serializable]
	public class Resp : GameApiResponseBase
	{
		public RespPlayerInfo PlayerInfo;
	}

	public string TransactionId;

	public string ProductId;

	public string Receipt;

	public string Signature;

	public DateTime PurchaseDate;

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

	public override string ApiPath => "/Purchase/Verify";

	public override ServerType Server => ServerType.Game;

	public ApiPurchaseVerify()
	{
		TransactionId = string.Empty;
		ProductId = "4";
		Receipt = "hoge";
		Signature = string.Empty;
		PurchaseDate = MerlinDateTime.UtcNow;
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
