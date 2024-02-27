using System;

namespace MerlinAPI;

[Serializable]
public class RespPlayerKeyItem : JsonBase
{
	public int Id;

	public int TPlayerId;

	public int MKeyItemId;

	public int Quantity;

	public int Point;
}
