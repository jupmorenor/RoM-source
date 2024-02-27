using System;
using System.Text;

namespace MerlinAPI;

[Serializable]
public class ApiExamVer : RequestBase
{
	[Serializable]
	public class Resp : JsonBase
	{
		public string ClientVersion;
	}

	[NonSerialized]
	private static bool _IsExamVer;

	public override string ApiPath => "/examversion.json";

	public override ServerType Server => ServerType.ExamVer;

	public static bool IsExamVer => _IsExamVer;

	public Resp GetResponse()
	{
		return ResponseObj as Resp;
	}

	public override Type responseType()
	{
		return typeof(Resp);
	}

	public override void doPostRequestJob()
	{
		if (UnderMaintenance)
		{
			MerlinServer.MaintenanceDialog(this);
			return;
		}
		ServerURL.PLATFORM_URL_BY_EXAMVER = ServerURL.PLATFORM_AB_URL;
		Resp resp = GetResponse();
		string text = new StringBuilder().Append(CurrentInfo.ClientVersion).ToString();
		if (resp != null && !string.IsNullOrEmpty(resp.ClientVersion) && resp.ClientVersion.Trim() == text)
		{
			ServerURL.PLATFORM_URL_BY_EXAMVER = "review-pr-svc-pfm-meln.riseofmana.com";
			_IsExamVer = true;
		}
	}

	public static void SetExamVerMode(bool b)
	{
		_IsExamVer = b;
	}
}
