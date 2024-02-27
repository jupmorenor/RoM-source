using System;
using System.Text;

[Serializable]
public class MFlagsUtil
{
	public static string QuestClearFlagName(MQuests q)
	{
		return (q == null) ? string.Empty : ("q" + q.Progname);
	}

	public static MFlags QuestClearFlag(MQuests q)
	{
		return Find(QuestClearFlagName(q));
	}

	public static string SceneVisitFlagName(string sname)
	{
		return new StringBuilder("v").Append(sname).ToString();
	}

	public static string SceneVisitFlagName(SceneID sceneID)
	{
		return new StringBuilder("v").Append(sceneID).ToString();
	}

	public static MFlags SceneVisitFlag(string sname)
	{
		return Find(SceneVisitFlagName(sname));
	}

	public static MFlags Find(string name)
	{
		int num = 0;
		MFlags[] all = MFlags.All;
		int length = all.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (all[num].Progname == name)
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
		return (MFlags)result;
	}

	public static MFlags Find(int id)
	{
		int num = 0;
		MFlags[] all = MFlags.All;
		int length = all.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (all[num].Id == id)
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
		return (MFlags)result;
	}
}
