using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;

[Serializable]
public class UserQuestMission
{
	private RespQuestMission[] clearQuestMissions;

	public int[] newQuestMissionIds;

	public bool isHasNewMission;

	public RespQuestMission[] questMissions;

	public RespQuestMission[] ClearQuestMissions
	{
		get
		{
			return clearQuestMissions;
		}
		set
		{
			clearQuestMissions = value;
		}
	}

	public int[] NewQuestMissionIds
	{
		get
		{
			return newQuestMissionIds;
		}
		set
		{
			newQuestMissionIds = value;
		}
	}

	public bool IsHasNewMission
	{
		get
		{
			return isHasNewMission;
		}
		set
		{
			isHasNewMission = value;
		}
	}

	public RespQuestMission[] QuestMissions
	{
		get
		{
			return questMissions;
		}
		set
		{
			questMissions = value;
		}
	}

	public UserQuestMission()
	{
		clearQuestMissions = new RespQuestMission[0];
		newQuestMissionIds = new int[0];
		questMissions = new RespQuestMission[0];
	}

	public RespQuestMission[] getMissionsOf(MQuests q)
	{
		checked
		{
			object result;
			if (q == null)
			{
				result = new RespQuestMission[0];
			}
			else
			{
				System.Collections.Generic.List<RespQuestMission> list = new System.Collections.Generic.List<RespQuestMission>();
				int i = 0;
				RespQuestMission[] array = questMissions;
				for (int length = array.Length; i < length; i++)
				{
					if (array[i] != null && array[i].MQuestId == q.Id)
					{
						list.Add(array[i]);
					}
				}
				list.Sort(_0024adaptor_0024__UserData_0024callable348_00242490_20___0024Comparison_0024151.Adapt((RespQuestMission a, RespQuestMission b) => a.Id - b.Id));
				result = (RespQuestMission[])Builtins.array(typeof(RespQuestMission), list);
			}
			return (RespQuestMission[])result;
		}
	}

	public RespQuestMission[] getMissionsOfIncludeClear(MQuests q)
	{
		checked
		{
			object result;
			if (q == null)
			{
				result = new RespQuestMission[0];
			}
			else
			{
				System.Collections.Generic.List<RespQuestMission> list = new System.Collections.Generic.List<RespQuestMission>();
				int i = 0;
				RespQuestMission[] array = questMissions;
				for (int length = array.Length; i < length; i++)
				{
					if (array[i] != null && array[i].MQuestId == q.Id)
					{
						list.Add(array[i]);
					}
				}
				int j = 0;
				RespQuestMission[] array2 = clearQuestMissions;
				for (int length2 = array2.Length; j < length2; j++)
				{
					if (array2[j] != null && array2[j].MQuestId == q.Id)
					{
						list.Add(array2[j]);
					}
				}
				list.Sort(_0024adaptor_0024__UserData_0024callable348_00242490_20___0024Comparison_0024151.Adapt((RespQuestMission a, RespQuestMission b) => a.Id - b.Id));
				result = (RespQuestMission[])Builtins.array(typeof(RespQuestMission), list);
			}
			return (RespQuestMission[])result;
		}
	}

	public bool hasClearTimeMission(MQuests q)
	{
		int result;
		if (q == null)
		{
			result = 0;
		}
		else
		{
			RespQuestMission[] missionsOf = getMissionsOf(q);
			int num = 0;
			RespQuestMission[] array = missionsOf;
			int length = array.Length;
			while (true)
			{
				if (num < length)
				{
					if (array[num].HasClearTimeCondition)
					{
						result = 1;
						break;
					}
					num = checked(num + 1);
					continue;
				}
				result = 0;
				break;
			}
		}
		return (byte)result != 0;
	}

	public RespQuestMission[] getClearMissionsOf(MQuests q)
	{
		checked
		{
			object result;
			if (q == null)
			{
				result = new RespQuestMission[0];
			}
			else
			{
				System.Collections.Generic.List<RespQuestMission> list = new System.Collections.Generic.List<RespQuestMission>();
				int i = 0;
				RespQuestMission[] array = clearQuestMissions;
				for (int length = array.Length; i < length; i++)
				{
					if (array[i] != null && array[i].MQuestId == q.Id)
					{
						list.Add(array[i]);
					}
				}
				list.Sort(_0024adaptor_0024__UserData_0024callable348_00242490_20___0024Comparison_0024151.Adapt((RespQuestMission a, RespQuestMission b) => a.Id - b.Id));
				result = (RespQuestMission[])Builtins.array(typeof(RespQuestMission), list);
			}
			return (RespQuestMission[])result;
		}
	}

	public RespQuestMission[] getNewMissionsOf(MQuests q)
	{
		RespQuestMission[] array = new RespQuestMission[0];
		checked
		{
			RespQuestMission[] result;
			if (null == newQuestMissionIds)
			{
				result = array;
			}
			else
			{
				RespQuestMission[] missionsOf = getMissionsOf(q);
				int i = 0;
				RespQuestMission[] array2 = missionsOf;
				for (int length = array2.Length; i < length; i++)
				{
					int j = 0;
					int[] array3 = newQuestMissionIds;
					for (int length2 = array3.Length; j < length2; j++)
					{
						if (array2[i] != null && array2[i].Id == array3[j])
						{
							array = (RespQuestMission[])RuntimeServices.AddArrays(typeof(RespQuestMission), array, new RespQuestMission[1] { array2[i] });
							break;
						}
					}
				}
				result = array;
			}
			return result;
		}
	}

	internal int _0024getMissionsOf_0024closure_00244016(RespQuestMission a, RespQuestMission b)
	{
		return checked(a.Id - b.Id);
	}

	internal int _0024getMissionsOfIncludeClear_0024closure_00244017(RespQuestMission a, RespQuestMission b)
	{
		return checked(a.Id - b.Id);
	}

	internal int _0024getClearMissionsOf_0024closure_00244018(RespQuestMission a, RespQuestMission b)
	{
		return checked(a.Id - b.Id);
	}
}
