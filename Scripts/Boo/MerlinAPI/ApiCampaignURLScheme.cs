using System;
using System.Collections.Generic;

namespace MerlinAPI;

[Serializable]
public class ApiCampaignURLScheme : RequestBase
{
	[Serializable]
	public class Resp : GameApiResponseBase
	{
	}

	public string str;

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

	public override string ApiPath => "/Campaign/UrlScheme";

	public override ServerType Server => ServerType.Game;

	private ApiCampaignURLScheme(string strParam)
	{
		str = strParam;
		Stealth = true;
		UseRetryDialog = false;
		retryCount = 1;
	}

	public Resp GetResponse()
	{
		return ResponseObj as Resp;
	}

	public override Type responseType()
	{
		return typeof(Resp);
	}

	public static ApiCampaignURLScheme CreateFFRKColaboApiReq()
	{
		string fFRKColaboParam = GetFFRKColaboParam();
		return (!MURLSchemeAPI.IsFFRKExpired() && !string.IsNullOrEmpty(fFRKColaboParam)) ? new ApiCampaignURLScheme(fFRKColaboParam) : null;
	}

	private static string GetFFRKColaboParam()
	{
		Dictionary<string, string> fFRKParameters = URLScheme.GetFFRKParameters();
		return (!fFRKParameters.ContainsKey("str")) ? string.Empty : fFRKParameters["str"];
	}
}
