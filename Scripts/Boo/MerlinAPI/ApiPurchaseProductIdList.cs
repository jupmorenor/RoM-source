using System;
using System.Text;

namespace MerlinAPI;

[Serializable]
public class ApiPurchaseProductIdList : RequestBase
{
	[Serializable]
	public class Resp : GameApiResponseBase
	{
		public RespInAppProduct[] ProductInfo;

		public RespProductSummaryInfo AddedProductId;

		public int SqmkPoint;

		public override string ToString()
		{
			checked
			{
				string result;
				if (ProductInfo == null)
				{
					result = string.Empty;
				}
				else
				{
					string lhs = "{";
					int num = 0;
					int i = 0;
					RespInAppProduct[] productInfo = ProductInfo;
					for (int length = productInfo.Length; i < length; i++)
					{
						lhs += new StringBuilder("\"").Append((object)num).Append("\":{\"Id\":\"").Append((object)productInfo[i].Id)
							.Append("\",\"Name\":\"")
							.Append(productInfo[i].Name)
							.Append("\",\"ProductIdCode\":\"")
							.Append(productInfo[i].ProductIdCode)
							.Append("\",\"Price\":\"")
							.Append((object)productInfo[i].Price)
							.Append("\",\"Quantity\":\"")
							.Append((object)productInfo[i].Quantity)
							.Append("\"},")
							.ToString();
						num++;
					}
					lhs += "}";
					result = lhs;
				}
				return result;
			}
		}
	}

	public string SqmkSessionId;

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

	public override string ApiPath => "/Purchase/ProductIdList";

	public override ServerType Server => ServerType.Game;

	public Resp GetResponse()
	{
		return ResponseObj as Resp;
	}

	public override Type responseType()
	{
		return typeof(Resp);
	}
}
