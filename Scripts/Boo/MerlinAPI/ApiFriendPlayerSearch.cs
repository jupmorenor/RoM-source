using System;

namespace MerlinAPI;

[Serializable]
public class ApiFriendPlayerSearch : RequestBase
{
	[Serializable]
	public class Resp : GameApiResponseBase
	{
		public RespFriend[] Friends;
	}

	public bool IsRecommend;

	public int Id;

	public string Name;

	public int Num;

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

	public override string ApiPath => "/Friend/PlayerSearch";

	public override ServerType Server => ServerType.Game;

	public ApiFriendPlayerSearch()
	{
		Name = string.Empty;
		Num = 10;
	}

	public Resp GetResponse()
	{
		return ResponseObj as Resp;
	}

	public override Type responseType()
	{
		return typeof(Resp);
	}

	protected override void setCurrentUserData()
	{
	}
}
