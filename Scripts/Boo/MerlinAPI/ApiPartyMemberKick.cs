using System;

namespace MerlinAPI;

[Serializable]
public class ApiPartyMemberKick : RequestBase
{
	[Serializable]
	public class Resp : GameApiResponseBase
	{
		public RespMember[] Members;
	}

	public int Id;

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

	public override string ApiPath => "/Party/MemberKick";

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
		if (resp.Members != null)
		{
			UpdateMembers(resp.Members);
		}
	}
}
