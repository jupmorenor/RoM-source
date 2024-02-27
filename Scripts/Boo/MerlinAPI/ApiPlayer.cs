using System;
using System.Text;

namespace MerlinAPI;

[Serializable]
public class ApiPlayer : RequestBase
{
	[Serializable]
	public class Resp : GameApiResponseBase
	{
		public RespPlayer Player;

		public RespPlayerInfo PlayerInfo;

		public RespDeck[] Decks;

		public RespDeck2[] Decks2;

		public RespPlayerBox[] Box;

		public RespPoppetDeck[] PoppetDecks;

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(base.ToString() + "\n");
			stringBuilder.Append(Player.ToString() + "\n");
			stringBuilder.Append(PlayerInfo.ToString() + "\n");
			stringBuilder.Append(ServerUtilModule.ArrayToDebugString(Decks));
			stringBuilder.Append(ServerUtilModule.ArrayToDebugString(Box));
			return stringBuilder.ToString();
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

	public override string ApiPath => "/Player";

	public override ServerType Server => ServerType.Game;

	public Resp GetResponse()
	{
		return ResponseObj as Resp;
	}

	public override Type responseType()
	{
		return typeof(Resp);
	}
}
