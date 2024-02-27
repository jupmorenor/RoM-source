using System;

namespace MerlinAPI;

[Serializable]
public class RespOpponent : JsonBase
{
	public bool IsNPC;

	public int TSocialPlayerId;

	public string Name;

	public int Level;

	public int BreederRankId;

	public double BreederRankPoint;
}
