using System;

namespace MerlinAPI;

[Serializable]
public class ApiEntryCreateUser : RequestBase
{
	[Serializable]
	public class Resp : GameApiResponseBase
	{
		public string UUID;
	}

	public string uuid;

	public string name;

	public int marketCode;

	private bool setUUID;

	public override string ApiPath => "/API/Entry/Create";

	public override ServerType Server => ServerType.Entry;

	public override bool InfRetry
	{
		get
		{
			int num;
			if (UnderMaintenance)
			{
				num = 0;
			}
			else
			{
				Resp resp = GetResponse();
				num = ((resp.StatusCode != "EnCrt001") ? 1 : 0);
			}
			return (byte)num != 0;
		}
	}

	public override bool IsOk
	{
		get
		{
			Resp resp = GetResponse();
			int num;
			if (!base.IsOk)
			{
				num = 0;
			}
			else
			{
				num = ((resp == null) ? 1 : 0);
				if (num == 0)
				{
					num = ((resp.StatusCode == "OK") ? 1 : 0);
					if (num != 0)
					{
						num = ((!string.IsNullOrEmpty(resp.UUID)) ? 1 : 0);
					}
				}
			}
			return (byte)num != 0;
		}
	}

	public ApiEntryCreateUser()
	{
		marketCode = GetMarketCode();
	}

	public Resp GetResponse()
	{
		return ResponseObj as Resp;
	}

	public override Type responseType()
	{
		return typeof(Resp);
	}

	public static int GetMarketCode()
	{
		return 1;
	}

	public override void doPostRequestJob()
	{
		if (!UnderMaintenance)
		{
			CurrentInfo.UUID = uuid;
		}
	}

	protected override void preRequestJob()
	{
		if (string.IsNullOrEmpty(uuid))
		{
			uuid = ServerUtilModule.GenerateUUID();
		}
		else
		{
			setUUID = true;
		}
	}

	protected override void retryJob()
	{
		if (!setUUID)
		{
			uuid = ServerUtilModule.GenerateUUID();
		}
	}
}
