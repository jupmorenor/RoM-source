using System;
using System.Text;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class MasterUtil
{
	public static EnumMapLinkDir OppositeDirection(EnumMapLinkDir fromDir)
	{
		if (fromDir <= (EnumMapLinkDir)0)
		{
			throw new AssertionFailedException(new StringBuilder().Append(fromDir).Append("というEnumMapLinkDir 値は無い").ToString());
		}
		int num = (int)checked(fromDir - 1);
		return (EnumMapLinkDir)checked(unchecked(checked(num + 4) % 8) + 1);
	}

	public static Vector3 StrToPos(string s)
	{
		string[] array = s.Split(',');
		try
		{
			float[] array2 = new float[array.Length];
			int num = 0;
			int length = array.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int index = num;
				num++;
				array2[RuntimeServices.NormalizeArrayIndex(array2, index)] = float.Parse(array[RuntimeServices.NormalizeArrayIndex(array, index)]);
			}
			int length2 = array2.Length;
			Vector3 result = default(Vector3);
			if (length2 >= 1)
			{
				result.x = array2[0];
			}
			if (length2 >= 2)
			{
				result.y = array2[1];
			}
			if (length2 >= 3)
			{
				result.z = array2[2];
			}
			return result;
		}
		catch (Exception)
		{
			string message = new StringBuilder("position string format error: '").Append(s).Append("'").ToString();
			throw new Exception(message);
		}
	}

	public static MNpcTalks FindNpcTalk(string progname)
	{
		object result;
		if (string.IsNullOrEmpty(progname))
		{
			result = null;
		}
		else
		{
			int num = 0;
			MNpcTalks[] all = MNpcTalks.All;
			int length = all.Length;
			while (true)
			{
				if (num < length)
				{
					if (all[num].Progname == progname)
					{
						result = all[num];
						break;
					}
					num = checked(num + 1);
					continue;
				}
				result = null;
				break;
			}
		}
		return (MNpcTalks)result;
	}

	public static MTutorials FindTutorial(string progname)
	{
		object result;
		if (string.IsNullOrEmpty(progname))
		{
			result = null;
		}
		else
		{
			int num = 0;
			MTutorials[] all = MTutorials.All;
			int length = all.Length;
			while (true)
			{
				if (num < length)
				{
					if (all[num].Progname == progname)
					{
						result = all[num];
						break;
					}
					num = checked(num + 1);
					continue;
				}
				result = null;
				break;
			}
		}
		return (MTutorials)result;
	}

	public static MNpcs FindNpcByTalk(MNpcTalks _npcTalk)
	{
		checked
		{
			object result;
			if (_npcTalk == null)
			{
				result = null;
			}
			else
			{
				int id = _npcTalk.Id;
				int num = 0;
				MNpcs[] all = MNpcs.All;
				int length = all.Length;
				while (true)
				{
					if (num < length)
					{
						int num2 = 0;
						MNpcTalks[] allNpcTalks = all[num].AllNpcTalks;
						int length2 = allNpcTalks.Length;
						while (num2 < length2)
						{
							if (allNpcTalks[num2].Id != id)
							{
								num2++;
								continue;
							}
							goto IL_0056;
						}
						num++;
						continue;
					}
					result = null;
					break;
					IL_0056:
					result = all[num];
					break;
				}
			}
			return (MNpcs)result;
		}
	}

	public static MScenes FindSceneByNpc(MNpcs _npc)
	{
		checked
		{
			object result;
			if (_npc == null)
			{
				result = null;
			}
			else
			{
				int id = _npc.Id;
				int num = 0;
				MScenes[] all = MScenes.All;
				int length = all.Length;
				while (true)
				{
					if (num < length)
					{
						int num2 = 0;
						MNpcs[] allNpcs = all[num].AllNpcs;
						int length2 = allNpcs.Length;
						while (num2 < length2)
						{
							if (allNpcs[num2].Id != id)
							{
								num2++;
								continue;
							}
							goto IL_0056;
						}
						num++;
						continue;
					}
					result = null;
					break;
					IL_0056:
					result = all[num];
					break;
				}
			}
			return (MScenes)result;
		}
	}

	public static MQuestClears FindClearCondition(MQuests q, EnumQuestClearTypes type)
	{
		int num = 0;
		MQuestClears[] clearConditions = q.ClearConditions;
		int length = clearConditions.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (clearConditions[num].ClearType == type)
				{
					result = clearConditions[num];
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = null;
			break;
		}
		return (MQuestClears)result;
	}
}
