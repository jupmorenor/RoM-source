using System;

namespace MerlinAPI;

[Serializable]
public class RespPlayerLogin : JsonBase
{
	public int Id;

	public int TPlayerId;

	public int MLoginBonusId;

	public int LoginNum;

	public DateTime LastGetDate;

	public bool IsLoginBonus;
}
