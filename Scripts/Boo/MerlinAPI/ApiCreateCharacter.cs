using System;

namespace MerlinAPI;

[Serializable]
public class ApiCreateCharacter : RequestBase
{
	public string AngelName;

	public string DemonName;

	public int AngelGender;

	public int DemonGender;

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

	public override string ApiPath => "/user/createCharacter";

	public override ServerType Server => ServerType.Game;

	public ApiCreateCharacter()
	{
		AngelName = "a";
		DemonName = "d";
		AngelGender = 1;
		DemonGender = 1;
	}

	public GameApiResponseBase GetResponse()
	{
		return ResponseObj as GameApiResponseBase;
	}

	public override Type responseType()
	{
		return typeof(GameApiResponseBase);
	}

	protected override void doPostRequestJob()
	{
		CurrentInfo.AlreadyCreatedCharacter = true;
		SetLastGameResponse();
	}
}
