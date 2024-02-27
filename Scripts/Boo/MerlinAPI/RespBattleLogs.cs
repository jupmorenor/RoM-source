using System;

namespace MerlinAPI;

[Serializable]
public class RespBattleLogs : JsonBase
{
	public string Name;

	public int Level;

	public int Damage;

	public long Point;

	public bool IsKill;

	public DateTime LogTime;
}
