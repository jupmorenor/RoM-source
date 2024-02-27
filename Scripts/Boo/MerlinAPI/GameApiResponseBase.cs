using System;

namespace MerlinAPI;

[Serializable]
public class GameApiResponseBase : JsonBase
{
	public string StatusCode;

	public string Message;

	public int OSType;

	public bool IsPublished;

	public bool IsSupported;

	public string ClientVersion;

	public string DataVersion;

	public string MasterVersion;

	public string RequestDate;

	public bool HasValidVersionInfo
	{
		get
		{
			bool num = ClientVersion != "0";
			if (num)
			{
				num = DataVersion != "0";
			}
			if (num)
			{
				num = MasterVersion != "0";
			}
			return num;
		}
	}

	public bool IsOkStatusCode
	{
		get
		{
			bool num = !string.IsNullOrEmpty(StatusCode);
			if (num)
			{
				num = StatusCode == "0";
				if (!num)
				{
					num = StatusCode.ToLower() == "ok";
				}
			}
			return num;
		}
	}

	public GameApiResponseBase()
	{
		StatusCode = string.Empty;
		Message = string.Empty;
		ClientVersion = "0";
		DataVersion = "0";
		MasterVersion = "0";
	}

	public DateTime ParseRequestDate()
	{
		try
		{
			return DateTime.Parse(RequestDate);
		}
		catch (Exception)
		{
			return MerlinDateTime.UtcNow;
		}
	}
}
