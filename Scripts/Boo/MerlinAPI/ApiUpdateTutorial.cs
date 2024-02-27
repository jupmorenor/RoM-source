using System;

namespace MerlinAPI;

[Serializable]
public class ApiUpdateTutorial : RequestBase
{
	public int TutorialStep;

	private bool _0024initialized__MerlinAPI_ApiUpdateTutorial_0024;

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

	public override string ApiPath => "/Player/UpdateTutorial";

	public override ServerType Server => ServerType.Game;

	public ApiUpdateTutorial()
	{
		if (!_0024initialized__MerlinAPI_ApiUpdateTutorial_0024)
		{
			_0024initialized__MerlinAPI_ApiUpdateTutorial_0024 = true;
		}
	}

	public ApiUpdateTutorial(int step)
	{
		if (!_0024initialized__MerlinAPI_ApiUpdateTutorial_0024)
		{
			_0024initialized__MerlinAPI_ApiUpdateTutorial_0024 = true;
		}
		TutorialStep = step;
	}

	public GameApiResponseBase GetResponse()
	{
		return ResponseObj as GameApiResponseBase;
	}

	public override Type responseType()
	{
		return typeof(GameApiResponseBase);
	}

	private void init()
	{
		IgnoreErrorCodes = new string[3] { "PlTuu001", "PlTuu003", "PlTuu002" };
	}

	protected override void doPostRequestJob()
	{
		base.doPostRequestJob();
		if (IsOk && UserData.Current.userStatus != null)
		{
			UserData.Current.userStatus.TutorialStep = TutorialStep;
		}
	}

	public static ApiUpdateTutorial RaidOpened()
	{
		return new ApiUpdateTutorial(500);
	}

	public static ApiUpdateTutorial PresentBoxOpened()
	{
		return new ApiUpdateTutorial(100);
	}
}
