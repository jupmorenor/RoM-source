using System;
using System.Collections.Generic;
using Boo.Lang.Runtime;

[Serializable]
public class MWeekEventsUtil
{
	[NonSerialized]
	public static Dictionary<int, MWeekEvents[]> questTable;

	public static void CreateQuestTable()
	{
		if (questTable == null)
		{
			questTable = new Dictionary<int, MWeekEvents[]>();
		}
		else
		{
			questTable.Clear();
		}
		int playerGroupId = UserData.Current.PlayerGroupId;
		int i = 0;
		MWeekEvents[] all = MWeekEvents.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (all[i].PlayerGroupId == playerGroupId && all[i].MStoryId != null && all[i].MStoryId.MQuestId != null)
			{
				int id = all[i].MStoryId.MQuestId.Id;
				if (questTable.ContainsKey(id))
				{
					questTable[id] = (MWeekEvents[])RuntimeServices.AddArrays(typeof(MWeekEvents), questTable[id], new MWeekEvents[1] { all[i] });
				}
				else
				{
					questTable[id] = new MWeekEvents[1] { all[i] };
				}
			}
		}
	}

	public static MWeekEvents[] GetWeekEvent(int questId)
	{
		if (questTable == null)
		{
			CreateQuestTable();
		}
		return (!questTable.ContainsKey(questId)) ? null : questTable[questId];
	}
}
