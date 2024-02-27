using System;

namespace MerlinAPI;

[Serializable]
public class ApiPlatformUpdateDeviceToken : RequestBase
{
	[Serializable]
	public class Resp : JsonBase
	{
		public bool Result;

		public string StatusCode;
	}

	public string uuid;

	public string deviceToken;

	public override string ApiPath => "/Merlin/UpdateDeviceToken";

	public override ServerType Server => ServerType.Platform;

	public override bool HasValidStatus
	{
		get
		{
			Resp resp = GetResponse();
			bool num = resp != null;
			if (num)
			{
				num = resp.Result;
			}
			return num;
		}
	}

	public override bool InfRetry => true;

	public Resp GetResponse()
	{
		return ResponseObj as Resp;
	}

	public override Type responseType()
	{
		return typeof(Resp);
	}

	protected override void doPostRequestJob()
	{
		Resp resp = GetResponse();
		if (resp != null && string.IsNullOrEmpty(resp.StatusCode))
		{
			base.doPostRequestJob();
		}
		else if (resp != null && resp.StatusCode == "CoApi999")
		{
			MerlinServer.MaintenanceDialog(this);
		}
		else
		{
			Error = "unknown error: UpdateDeviceToken=" + resp;
		}
	}
}
