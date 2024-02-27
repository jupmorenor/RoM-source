using System;

namespace MerlinAPI;

[Serializable]
public class RespBreeder : JsonBase
{
	public int Loss;

	public int Win;

	public long BreederRankPoint;

	public int BreederRankId;

	public RespBreeder()
	{
		BreederRankId = 1;
	}
}
