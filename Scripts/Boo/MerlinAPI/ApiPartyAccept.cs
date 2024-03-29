using System;

namespace MerlinAPI;

[Serializable]
public class ApiPartyAccept : RequestBase
{
	[Serializable]
	public class Resp : GameApiResponseBase
	{
		public RespApplyInfo[] Applies;

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

	public override string ApiPath => "/Party/Accept";

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
			UpdatePartyApplies(resp.Applies);
		}
		if (resp.Members != null)
		{
			RespParty party = RespParty.MakeParty(resp.Members);
			UpdateParty(party);
			UserData.Current.setParty(party);
		}
	}
}
