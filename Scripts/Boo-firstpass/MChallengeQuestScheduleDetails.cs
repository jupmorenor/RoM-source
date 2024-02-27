using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MChallengeQuestScheduleDetails : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MChallengeQuestScheduleId;

	public int _0024var_0024MQuestId;

	[NonSerialized]
	private MChallengeQuestSchedules MChallengeQuestScheduleId__cache;

	[NonSerialized]
	private MQuests MQuestId__cache;

	[NonSerialized]
	private static Dictionary<int, MChallengeQuestScheduleDetails> _0024mst_0024135 = new Dictionary<int, MChallengeQuestScheduleDetails>();

	[NonSerialized]
	private static MChallengeQuestScheduleDetails[] All_cache;

	public int Id => _0024var_0024Id;

	public MChallengeQuestSchedules MChallengeQuestScheduleId
	{
		get
		{
			if (MChallengeQuestScheduleId__cache == null)
			{
				MChallengeQuestScheduleId__cache = MChallengeQuestSchedules.Get(_0024var_0024MChallengeQuestScheduleId);
			}
			return MChallengeQuestScheduleId__cache;
		}
	}

	public MQuests MQuestId
	{
		get
		{
			if (MQuestId__cache == null)
			{
				MQuestId__cache = MQuests.Get(_0024var_0024MQuestId);
			}
			return MQuestId__cache;
		}
	}

	public static MChallengeQuestScheduleDetails[] All
	{
		get
		{
			MChallengeQuestScheduleDetails[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MChallengeQuestScheduleDetails");
				MChallengeQuestScheduleDetails[] array = (MChallengeQuestScheduleDetails[])Builtins.array(typeof(MChallengeQuestScheduleDetails), _0024mst_0024135.Values);
				if (array.Length > 0)
				{
					All_cache = array;
					result = All_cache;
				}
				else
				{
					result = array;
				}
			}
			else
			{
				result = All_cache;
			}
			return result;
		}
	}

	public override string ToString()
	{
		return new StringBuilder("MChallengeQuestScheduleDetails(").Append((object)Id).Append(" ").Append(MChallengeQuestScheduleId)
			.Append(" ")
			.Append(MQuestId)
			.Append(")")
			.ToString();
	}

	public static MQuests[] GetOpenQuests()
	{
		return GetOpenQuests(MerlinDateTime.UtcNow);
	}

	public static MQuests[] GetOpenQuests(DateTime dt)
	{
		Boo.Lang.List<MQuests> list = new Boo.Lang.List<MQuests>();
		int i = 0;
		MChallengeQuestScheduleDetails[] all = All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			MChallengeQuestSchedules mChallengeQuestScheduleId = all[i].MChallengeQuestScheduleId;
			if (mChallengeQuestScheduleId != null && mChallengeQuestScheduleId.isInTime(dt) && all[i].MQuestId != null)
			{
				list.Add(all[i].MQuestId);
			}
		}
		return (MQuests[])Builtins.array(typeof(MQuests), list);
	}

	public static MChallengeQuestScheduleDetails Get(int _id)
	{
		MerlinMaster.GetHandler("MChallengeQuestScheduleDetails");
		return (!_0024mst_0024135.ContainsKey(_id)) ? null : _0024mst_0024135[_id];
	}

	public static void Unload()
	{
		_0024mst_0024135.Clear();
		All_cache = null;
	}

	public static MChallengeQuestScheduleDetails New(Hashtable data)
	{
		object result;
		if (data == null || data.Count <= 0)
		{
			result = null;
		}
		else if (!data.ContainsKey("Id"))
		{
			result = null;
		}
		else
		{
			MChallengeQuestScheduleDetails mChallengeQuestScheduleDetails = Create(data);
			if (!_0024mst_0024135.ContainsKey(mChallengeQuestScheduleDetails.Id))
			{
				_0024mst_0024135[mChallengeQuestScheduleDetails.Id] = mChallengeQuestScheduleDetails;
			}
			result = mChallengeQuestScheduleDetails;
		}
		return (MChallengeQuestScheduleDetails)result;
	}

	public static MChallengeQuestScheduleDetails New2(string[] keys, object[] vals)
	{
		object result;
		if (keys == null || vals == null)
		{
			result = null;
		}
		else if (keys.Length <= 0 || vals.Length <= 0)
		{
			result = null;
		}
		else
		{
			Hashtable hashtable = new Hashtable();
			int num = ((vals.Length >= keys.Length) ? keys.Length : vals.Length);
			int num2 = 0;
			int num3 = num;
			if (num3 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num2 < num3)
			{
				int index = num2;
				num2++;
				hashtable[keys[RuntimeServices.NormalizeArrayIndex(keys, index)]] = vals[RuntimeServices.NormalizeArrayIndex(vals, index)];
			}
			result = New(hashtable);
		}
		return (MChallengeQuestScheduleDetails)result;
	}

	public static MChallengeQuestScheduleDetails Entry(MChallengeQuestScheduleDetails mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024135[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MChallengeQuestScheduleDetails)result;
	}

	public static void AddMst(MChallengeQuestScheduleDetails mst)
	{
		if (mst != null)
		{
			_0024mst_0024135[mst.Id] = mst;
		}
	}

	public static MChallengeQuestScheduleDetails Create(Hashtable data)
	{
		MChallengeQuestScheduleDetails mChallengeQuestScheduleDetails = new MChallengeQuestScheduleDetails();
		MChallengeQuestScheduleDetails result;
		if (data == null)
		{
			result = mChallengeQuestScheduleDetails;
		}
		else
		{
			IEnumerator enumerator = data.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				object obj = current;
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				mChallengeQuestScheduleDetails.setField((string)obj, data[current]);
			}
			result = mChallengeQuestScheduleDetails;
		}
		return result;
	}

	public void setField(string key, object val)
	{
		switch (key)
		{
		case "Id":
			_0024var_0024Id = MasterBaseClass.ToInt(val);
			break;
		case "MChallengeQuestScheduleId":
			_0024var_0024MChallengeQuestScheduleId = MasterBaseClass.ToInt(val);
			break;
		case "MQuestId":
			_0024var_0024MQuestId = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"MChallengeQuestScheduleId" => true, 
			"MQuestId" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[3] { "Id", "MChallengeQuestScheduleId", "MQuestId" });
	}

	public int setStringValues(string[] vals)
	{
		int length = vals.Length;
		int result;
		if (length <= 0)
		{
			result = 0;
		}
		else
		{
			if (vals[0] != null)
			{
				_0024var_0024Id = MasterBaseClass.ParseInt(vals[0]);
			}
			if (length <= 1)
			{
				result = 1;
			}
			else
			{
				if (vals[1] != null)
				{
					_0024var_0024MChallengeQuestScheduleId = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024MQuestId = MasterBaseClass.ParseInt(vals[2]);
					}
					int num = 3;
					result = num;
				}
			}
		}
		return result;
	}
}
