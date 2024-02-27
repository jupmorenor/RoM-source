using System;

namespace MerlinAPI;

[Serializable]
public class RespProgression : JsonBase
{
	public int Id;

	public int MStoryId;

	public int ProgressStatus;

	public int TPlayerId;
}
