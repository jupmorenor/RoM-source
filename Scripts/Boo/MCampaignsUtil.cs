using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang.Runtime;

[Serializable]
public class MCampaignsUtil
{
	[NonSerialized]
	protected static Dictionary<int, MCampaigns[]> questTable;

	[NonSerialized]
	protected static Dictionary<int, HashSet<int>> excludeQuestTable;

	public static void InitQuestTable()
	{
		questTable = new Dictionary<int, MCampaigns[]>();
		excludeQuestTable = new Dictionary<int, HashSet<int>>();
		int i = 0;
		MCampaigns[] all = MCampaigns.All;
		checked
		{
			for (int length = all.Length; i < length; i++)
			{
				string[] array;
				if (string.IsNullOrEmpty(all[i].TargetStoryIds))
				{
					if (!questTable.ContainsKey(0))
					{
						questTable[0] = new MCampaigns[0];
					}
					questTable[0] = (MCampaigns[])RuntimeServices.AddArrays(typeof(MCampaigns), questTable[0], new MCampaigns[1] { all[i] });
					if (string.IsNullOrEmpty(all[i].TargetStoryIds))
					{
						continue;
					}
					HashSet<int> hashSet = new HashSet<int>();
					array = all[i].ExcludeStoryIds.Split(',');
					int j = 0;
					string[] array2 = array;
					for (int length2 = array2.Length; j < length2; j++)
					{
						int result = 0;
						if (int.TryParse(array2[j], out result))
						{
							MStories mStories = MStories.Get(result);
							if (mStories != null && mStories.MQuestId != null && mStories.MQuestId.Id > 0)
							{
								hashSet.Add(mStories.MQuestId.Id);
							}
						}
					}
					excludeQuestTable[all[i].Id] = hashSet;
					continue;
				}
				array = all[i].TargetStoryIds.Split(',');
				int k = 0;
				string[] array3 = array;
				for (int length3 = array3.Length; k < length3; k++)
				{
					int result = 0;
					if (!int.TryParse(array3[k], out result))
					{
						continue;
					}
					MStories mStories = MStories.Get(result);
					if (mStories != null && mStories.MQuestId != null && mStories.MQuestId.Id > 0)
					{
						if (!questTable.ContainsKey(mStories.MQuestId.Id))
						{
							questTable[mStories.MQuestId.Id] = new MCampaigns[0];
						}
						questTable[mStories.MQuestId.Id] = (MCampaigns[])RuntimeServices.AddArrays(typeof(MCampaigns), questTable[mStories.MQuestId.Id], new MCampaigns[1] { all[i] });
					}
				}
			}
		}
	}

	public static MCampaigns[] GetCurrentQuestCampaign(MQuests mquest)
	{
		if (questTable == null)
		{
			InitQuestTable();
		}
		DateTime utcNow = MerlinDateTime.UtcNow;
		DateTime createDate = UserData.Current.userStatus.CreateDate;
		MCampaigns[] array = new MCampaigns[0];
		IEnumerable enumerable = null;
		MCampaigns[] result;
		if (mquest != null)
		{
			if (!questTable.ContainsKey(mquest.Id))
			{
				result = array;
				goto IL_01d8;
			}
			enumerable = questTable[mquest.Id];
		}
		else if (questTable.ContainsKey(0))
		{
			enumerable = questTable[0];
		}
		if (enumerable != null)
		{
			IEnumerator enumerator = enumerable.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is MCampaigns))
				{
					obj = RuntimeServices.Coerce(obj, typeof(MCampaigns));
				}
				MCampaigns mCampaigns = (MCampaigns)obj;
				if (utcNow < mCampaigns.BeginDate || (mCampaigns.EndDate <= utcNow && (int)mCampaigns.EndDate.Ticks != 0) || (mCampaigns.SegmentTypeValue == EnumCampaignSegmentTypes.CampaignSegmentType_New && ((int)createDate.Ticks == 0 || createDate < mCampaigns.BeginDate || (mCampaigns.EndDate <= createDate && (int)mCampaigns.EndDate.Ticks != 0))))
				{
					continue;
				}
				if (excludeQuestTable.ContainsKey(mCampaigns.Id))
				{
					HashSet<int> hashSet = excludeQuestTable[mCampaigns.Id];
					if (hashSet != null && !hashSet.Contains(mquest.Id))
					{
						continue;
					}
				}
				array = (MCampaigns[])RuntimeServices.AddArrays(typeof(MCampaigns), array, new MCampaigns[1] { mCampaigns });
			}
		}
		result = array;
		goto IL_01d8;
		IL_01d8:
		return result;
	}

	public static MCampaigns[] GetCurrentCampaign()
	{
		DateTime utcNow = MerlinDateTime.UtcNow;
		DateTime createDate = UserData.Current.userStatus.CreateDate;
		MCampaigns[] array = new MCampaigns[0];
		int i = 0;
		MCampaigns[] all = MCampaigns.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (!(utcNow < all[i].BeginDate) && (!(all[i].EndDate <= utcNow) || (int)all[i].EndDate.Ticks == 0) && (all[i].SegmentTypeValue != EnumCampaignSegmentTypes.CampaignSegmentType_New || ((int)createDate.Ticks != 0 && !(createDate < all[i].BeginDate) && (!(all[i].EndDate <= createDate) || (int)all[i].EndDate.Ticks == 0))))
			{
				array = (MCampaigns[])RuntimeServices.AddArrays(typeof(MCampaigns), array, new MCampaigns[1] { all[i] });
			}
		}
		return array;
	}
}
