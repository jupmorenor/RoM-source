using System;

namespace MerlinAPI;

[Serializable]
public class RespOpponentWithOrganize : JsonBase
{
	public string TicketId;

	public bool IsNPC;

	public int TSocialPlayerId;

	public string Name;

	public int Level;

	public double BreederRankPoint;

	public int BreederRankId;

	public RespColosseumBattlePoppet[] Organize;
}
