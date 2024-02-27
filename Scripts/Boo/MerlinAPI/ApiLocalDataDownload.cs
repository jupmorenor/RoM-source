using System;
using Boo.Lang.Runtime;

namespace MerlinAPI;

[Serializable]
public class ApiLocalDataDownload : RequestBase
{
	[Serializable]
	public class Resp : GameApiResponseBase
	{
		public string Data;

		public override string ToString()
		{
			object result;
			checked
			{
				string text2;
				try
				{
					string text = Data;
					if (!string.IsNullOrEmpty(text) && text[0] == '"' && text[text.Length - 1] == '"')
					{
						text = RuntimeServices.Mid(text, 1, text.Length - 1);
					}
					text2 = text;
				}
				catch (Exception)
				{
					goto IL_0057;
				}
				result = text2;
				goto IL_005b;
			}
			IL_005b:
			return (string)result;
			IL_0057:
			result = null;
			goto IL_005b;
		}
	}

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

	public override string ApiPath => "/LocalData/DownLoad";

	public override ServerType Server => ServerType.Game;

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
		SetLastGameResponse();
		if (UserData.Current.userMiscInfo == null)
		{
			return;
		}
		Resp resp = GetResponse();
		if (resp != null)
		{
			string text = resp.ToString();
			if (!string.IsNullOrEmpty(text))
			{
				UserData.Current.userMiscInfo.LoadFromStringWidthMd5(text);
				UserData.Current.userMiscInfo.Save();
			}
		}
	}
}
