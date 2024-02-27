using System;
using System.Collections.Generic;
using Boo.Lang.Runtime;

namespace MerlinAPI;

[Serializable]
public class RespQuestTicket : JsonBase
{
	public int Id;

	public RespPlayer TPlayer;

	public bool IsUsed;

	public DateTime StartDate;

	public DateTime EndDate;

	public string EffectiveTime;

	public DateTime ExpirationDate;

	public string QuestIdList;

	public int MQuestTicketId;

	public string Icon;

	public string Explain;

	[NonSerialized]
	protected static Dictionary<int, RespQuestTicket[]> questTable = new Dictionary<int, RespQuestTicket[]>();

	public bool IsAvailable
	{
		get
		{
			DateTime utcNow = MerlinDateTime.UtcNow;
			bool num = !IsUsed;
			if (num)
			{
				num = utcNow < ExpirationDate;
			}
			return num;
		}
	}

	public bool IsOpened
	{
		get
		{
			DateTime utcNow = MerlinDateTime.UtcNow;
			bool num = IsUsed;
			if (num)
			{
				num = utcNow < EndDate;
			}
			return num;
		}
	}

	public int[] QuestIds => (!string.IsNullOrEmpty(QuestIdList)) ? ApiGachaExec.Csv2Ints(QuestIdList) : new int[0];

	public TimeSpan GetEffetiveTime()
	{
		return string.IsNullOrEmpty(EffectiveTime) ? TimeSpan.Parse("00:00:00") : TimeSpan.Parse(EffectiveTime);
	}

	public string GetIcon()
	{
		string result = Icon;
		if (DebugSubUserData.TicketDebug)
		{
			result = DebugSubUserData.TicketIcon;
		}
		return result;
	}

	public string GetExplain()
	{
		string result = Explain;
		if (DebugSubUserData.TicketDebug)
		{
			result = DebugSubUserData.TicketExplain;
		}
		return result;
	}

	public static void createQuestTable(RespQuestTicket[] tickets)
	{
		if (questTable == null)
		{
			questTable = new Dictionary<int, RespQuestTicket[]>();
		}
		questTable.Clear();
		int i = 0;
		checked
		{
			for (int length = tickets.Length; i < length; i++)
			{
				int j = 0;
				int[] questIds = tickets[i].QuestIds;
				for (int length2 = questIds.Length; j < length2; j++)
				{
					if (!questTable.ContainsKey(questIds[j]))
					{
						questTable[questIds[j]] = new RespQuestTicket[0];
					}
					questTable[questIds[j]] = (RespQuestTicket[])RuntimeServices.AddArrays(typeof(RespQuestTicket), questTable[questIds[j]], new RespQuestTicket[1] { tickets[i] });
				}
			}
		}
	}

	public static RespQuestTicket[] Get(int questId)
	{
		return (questTable == null) ? new RespQuestTicket[0] : (questTable.ContainsKey(questId) ? questTable[questId] : new RespQuestTicket[0]);
	}
}
