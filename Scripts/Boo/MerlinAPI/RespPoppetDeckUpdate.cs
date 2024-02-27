using System;

namespace MerlinAPI;

[Serializable]
public class RespPoppetDeckUpdate : GameApiResponseBase
{
	public RespPlayerInfo PlayerInfo;

	public RespPoppetDeck[] PoppetDecks;
}
