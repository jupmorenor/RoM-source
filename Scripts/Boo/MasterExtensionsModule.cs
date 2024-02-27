using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;

[CompilerGlobalScope]
public sealed class MasterExtensionsModule
{
	private MasterExtensionsModule()
	{
	}

	public static string MultiDetail(this MWeapons mw)
	{
		return TextTagCheck.ReplaceMultiLine(mw.Detail.ToString());
	}

	public static string MultiDetail(this MMonsters mm)
	{
		return TextTagCheck.ReplaceMultiLine(mm.Detail.ToString());
	}

	public static string MultiDetail(this MWeaponSkills mws)
	{
		return TextTagCheck.ReplaceMultiLine(mws.Detail.ToString());
	}

	public static string MultiDetail(this MCoverSkills mcs, int level)
	{
		if (mcs.SkillEffect == null)
		{
			throw new AssertionFailedException("SkillEffect == null");
		}
		if (mcs.Detail == null)
		{
			throw new AssertionFailedException("Detail == null");
		}
		return string.Format(TextTagCheck.ReplaceMultiLine(mcs.Detail.ToString()), mcs.SkillEffect.getEffectValue(level, mcs.LevelMax, string.Empty), mcs.SkillEffect.getEffectValueAsRate(level, mcs.LevelMax, string.Empty));
	}

	public static string MultiDetail(this MChainSkills mcs)
	{
		return TextTagCheck.ReplaceMultiLine(mcs.Detail.ToString());
	}

	public static RespQuestTicket[] Tickets(this MQuests qmst)
	{
		return RespQuestTicket.Get(qmst.Id);
	}

	public static int GetTicketCount(this MQuests qmst)
	{
		RespQuestTicket[] array = Tickets(qmst);
		int num = 0;
		int i = 0;
		RespQuestTicket[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				if (array2[i] != null)
				{
					if (array2[i].IsAvailable)
					{
						num++;
					}
					else if (array2[i].IsOpened)
					{
						num++;
					}
				}
			}
			return array.Length;
		}
	}

	public static bool IsTicket(this MQuests qmst)
	{
		RespQuestTicket[] array = Tickets(qmst);
		int num = 0;
		RespQuestTicket[] array2 = array;
		int length = array2.Length;
		int result;
		while (true)
		{
			if (num < length)
			{
				if (array2[num] != null)
				{
					if (array2[num].IsAvailable)
					{
						result = 1;
						break;
					}
					if (array2[num].IsOpened)
					{
						result = 1;
						break;
					}
				}
				num = checked(num + 1);
				continue;
			}
			result = 0;
			break;
		}
		return (byte)result != 0;
	}

	public static DateTime TicketExpirationDate(this MQuests qmst)
	{
		DateTime dateTime = DateTime.Parse("2099/12/31");
		RespQuestTicket[] array = Tickets(qmst);
		int i = 0;
		RespQuestTicket[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			if (array2[i] != null && array2[i].ExpirationDate < dateTime)
			{
				dateTime = array2[i].ExpirationDate;
			}
		}
		return dateTime;
	}

	public static int TicketMinimumId(this MQuests qmst)
	{
		long num = 4294967295L;
		RespQuestTicket[] array = Tickets(qmst);
		int i = 0;
		RespQuestTicket[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				if (array2[i] != null && (long)array2[i].Id < num)
				{
					num = array2[i].Id;
				}
			}
			return (int)num;
		}
	}

	public static bool IsOpen(this MQuests qmst)
	{
		return GetOpenTicket(qmst) != null;
	}

	public static RespQuestTicket GetCustomIconTicket(this MQuests qmst)
	{
		RespQuestTicket[] array = Tickets(qmst);
		int num = 0;
		RespQuestTicket[] array2 = array;
		int length = array2.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (array2[num] != null && (array2[num].IsAvailable || array2[num].IsOpened) && !string.IsNullOrEmpty(array2[num].GetIcon()))
				{
					result = array2[num];
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = null;
			break;
		}
		return (RespQuestTicket)result;
	}

	public static RespQuestTicket GetNotOpenTicket(this MQuests qmst)
	{
		RespQuestTicket[] array = Tickets(qmst);
		int num = 0;
		RespQuestTicket[] array2 = array;
		int length = array2.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (array2[num] != null && array2[num].IsAvailable)
				{
					result = array2[num];
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = null;
			break;
		}
		return (RespQuestTicket)result;
	}

	public static RespQuestTicket GetOpenTicket(this MQuests qmst)
	{
		RespQuestTicket[] array = Tickets(qmst);
		int num = 0;
		RespQuestTicket[] array2 = array;
		int length = array2.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (array2[num] != null && array2[num].IsOpened)
				{
					result = array2[num];
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = null;
			break;
		}
		return (RespQuestTicket)result;
	}

	public static int GetNotUseTicketCount(this MQuests qmst)
	{
		RespQuestTicket[] array = Tickets(qmst);
		int num = 0;
		int i = 0;
		RespQuestTicket[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				if (array2[i] != null && array2[i].IsAvailable)
				{
					num++;
				}
			}
			return num;
		}
	}

	public static void Open(this MQuests qmst)
	{
		Open(qmst, null);
	}

	public static bool Open(this MQuests qmst, ICallable callback)
	{
		RespQuestTicket[] array = Tickets(qmst);
		int num = 0;
		RespQuestTicket[] array2 = array;
		int length = array2.Length;
		int result;
		while (true)
		{
			if (num < length)
			{
				if (array2[num] != null && !array2[num].IsOpened && array2[num].IsAvailable)
				{
					ApiQuestUseTicket req = new ApiQuestUseTicket(array2[num].Id);
					MerlinServer.Request(req, (__MerlinServer_Request_0024callable86_0024160_56__)callback);
					result = 1;
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = 0;
			break;
		}
		return (byte)result != 0;
	}

	public static MTexts GetMessage(this MShopMessage mshopmsg)
	{
		object result;
		if (mshopmsg == null)
		{
			result = null;
		}
		else
		{
			MFlags[] allConditions = mshopmsg.AllConditions;
			MTexts[] allMessages = mshopmsg.AllMessages;
			MTexts mTexts = mshopmsg.DefaultMessage;
			IEnumerator<int> enumerator = Enumerable.Range(0, MShopMessage.MSG_NUM).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					int current = enumerator.Current;
					MFlags mFlags = allConditions[RuntimeServices.NormalizeArrayIndex(allConditions, current)];
					if (mFlags != null && GameLevelManager.CheckCondition(new MFlags[1] { mFlags }, notFlag: false))
					{
						mTexts = allMessages[RuntimeServices.NormalizeArrayIndex(allMessages, current)];
						break;
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			result = mTexts;
		}
		return (MTexts)result;
	}
}
