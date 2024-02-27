using System;
using System.Text;
using Boo.Lang.Runtime;

namespace MerlinAPI;

[Serializable]
public class ApiPlatformAccessInfo : RequestBase
{
	[Serializable]
	public class Resp : JsonBase
	{
		public string Token;

		public RespWebServer WebServer;

		public RespExtServer[] ExtServer;

		public string StatusCode;
	}

	public string uuid;

	public override string ApiPath => "/Merlin/AccessInfo";

	public override ServerType Server => ServerType.Platform;

	public override bool InfRetry => true;

	public override bool IsOk
	{
		get
		{
			Resp resp = GetResponse();
			bool num = resp != null;
			if (num)
			{
				num = string.IsNullOrEmpty(resp.StatusCode);
			}
			if (num)
			{
				num = !string.IsNullOrEmpty(resp.Token);
			}
			if (num)
			{
				num = resp.WebServer != null;
			}
			return num;
		}
	}

	public Resp GetResponse()
	{
		return ResponseObj as Resp;
	}

	public override Type responseType()
	{
		return typeof(Resp);
	}

	protected override void preRequestJob()
	{
		if (string.IsNullOrEmpty(uuid))
		{
			throw new AssertionFailedException("not string.IsNullOrEmpty(uuid)");
		}
	}

	protected override void doPostRequestJob()
	{
		Resp resp = GetResponse();
		if (resp != null && resp.WebServer != null && !string.IsNullOrEmpty(resp.Token))
		{
			ServerURL.GAME_SRV_URL = resp.WebServer.HostName;
			CurrentInfo.Token = resp.Token;
			TestFlightUnity.PassCheckpoint(new StringBuilder("Token:").Append(resp.Token).ToString());
		}
		else if (resp != null && resp.StatusCode == "CoApi999")
		{
			MerlinServer.MaintenanceDialog(this);
		}
		else
		{
			Error = "unknown error: AccessInfo resp=" + resp;
		}
	}
}
