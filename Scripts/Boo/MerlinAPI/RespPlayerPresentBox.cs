using System;

namespace MerlinAPI;

[Serializable]
public class RespPlayerPresentBox : JsonBase
{
	public int Id;

	public int PresentType;

	public int TPlayerId;

	public bool IsReceive;

	public string FromName;

	public DateTime SendDate;

	public string Title;

	public int ItemId;

	public string Explain;

	public string ItemInfo;

	public string ItemData;

	public string GetMultiLineExplain()
	{
		return TextTagCheck.ReplaceMultiLine(Explain);
	}

	public RespReward GetReward()
	{
		return RespReward.JsonToRespReward(ItemData);
	}
}
