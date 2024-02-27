using System;

namespace MerlinAPI;

[Serializable]
public class ApiFriendApplyList : RequestBase
{
	[Serializable]
	public class Resp : GameApiResponseBase
	{
		public RespApplyInfo[] Applies;
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

	public override string ApiPath => "/Friend/ApplyList";

	public override ServerType Server => ServerType.Game;

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
		Resp resp = GetResponse();
		if (resp.Applies != null)
		{
			UpdateFriendApplies(resp.Applies);
		}
	}
}
