using System;

namespace MerlinAPI;

[Serializable]
public class ApiLocalDataUpload : RequestBase
{
	public string __REQUEST__;

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

	public override string ApiPath => "/LocalData/Upload";

	public override ServerType Server => ServerType.Game;

	public GameApiResponseBase GetResponse()
	{
		return ResponseObj as GameApiResponseBase;
	}

	public override Type responseType()
	{
		return typeof(GameApiResponseBase);
	}

	public static ApiLocalDataUpload WithUserData()
	{
		ApiLocalDataUpload apiLocalDataUpload = new ApiLocalDataUpload();
		if (UserData.Current.userMiscInfo != null)
		{
			apiLocalDataUpload.__REQUEST__ = UserData.Current.userMiscInfo.ToSaveStringWithMd5();
		}
		return apiLocalDataUpload;
	}
}
