using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MChallengeQuestSchedules : MerlinMaster
{
	public int _0024var_0024Id;

	public DateTime _0024var_0024BeginDate;

	public DateTime _0024var_0024EndDate;

	[NonSerialized]
	private static Dictionary<int, MChallengeQuestSchedules> _0024mst_0024134 = new Dictionary<int, MChallengeQuestSchedules>();

	[NonSerialized]
	private static MChallengeQuestSchedules[] All_cache;

	public int Id => _0024var_0024Id;

	public DateTime BeginDate => _0024var_0024BeginDate;

	public DateTime EndDate => _0024var_0024EndDate;

	public static MChallengeQuestSchedules[] All
	{
		get
		{
			MChallengeQuestSchedules[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MChallengeQuestSchedules");
				MChallengeQuestSchedules[] array = (MChallengeQuestSchedules[])Builtins.array(typeof(MChallengeQuestSchedules), _0024mst_0024134.Values);
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
		return new StringBuilder("MChallengeQuestSchedules(").Append((object)Id).Append(" ").Append(BeginDate)
			.Append("-")
			.Append(EndDate)
			.Append(")")
			.ToString();
	}

	public bool isInTime(DateTime dt)
	{
		bool num = BeginDate <= dt;
		if (num)
		{
			num = dt < EndDate;
		}
		return num;
	}

	public static MChallengeQuestSchedules[] GetOpenSchedules()
	{
		return GetOpenSchedules(MerlinDateTime.UtcNow);
	}

	public static MChallengeQuestSchedules[] GetOpenSchedules(DateTime dt)
	{
		Boo.Lang.List<MChallengeQuestSchedules> list = new Boo.Lang.List<MChallengeQuestSchedules>();
		int i = 0;
		MChallengeQuestSchedules[] all = All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (all[i].isInTime(dt))
			{
				list.Add(all[i]);
			}
		}
		return (MChallengeQuestSchedules[])Builtins.array(typeof(MChallengeQuestSchedules), list);
	}

	public static MChallengeQuestSchedules Get(int _id)
	{
		MerlinMaster.GetHandler("MChallengeQuestSchedules");
		return (!_0024mst_0024134.ContainsKey(_id)) ? null : _0024mst_0024134[_id];
	}

	public static void Unload()
	{
		_0024mst_0024134.Clear();
		All_cache = null;
	}

	public static MChallengeQuestSchedules New(Hashtable data)
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
			MChallengeQuestSchedules mChallengeQuestSchedules = Create(data);
			if (!_0024mst_0024134.ContainsKey(mChallengeQuestSchedules.Id))
			{
				_0024mst_0024134[mChallengeQuestSchedules.Id] = mChallengeQuestSchedules;
			}
			result = mChallengeQuestSchedules;
		}
		return (MChallengeQuestSchedules)result;
	}

	public static MChallengeQuestSchedules New2(string[] keys, object[] vals)
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
		return (MChallengeQuestSchedules)result;
	}

	public static MChallengeQuestSchedules Entry(MChallengeQuestSchedules mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024134[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MChallengeQuestSchedules)result;
	}

	public static void AddMst(MChallengeQuestSchedules mst)
	{
		if (mst != null)
		{
			_0024mst_0024134[mst.Id] = mst;
		}
	}

	public static MChallengeQuestSchedules Create(Hashtable data)
	{
		MChallengeQuestSchedules mChallengeQuestSchedules = new MChallengeQuestSchedules();
		MChallengeQuestSchedules result;
		if (data == null)
		{
			result = mChallengeQuestSchedules;
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
				mChallengeQuestSchedules.setField((string)obj, data[current]);
			}
			result = mChallengeQuestSchedules;
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
		case "BeginDate":
		{
			object obj2 = val;
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			_0024var_0024BeginDate = DateTime.Parse((string)obj2);
			break;
		}
		case "EndDate":
		{
			object obj = val;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			_0024var_0024EndDate = DateTime.Parse((string)obj);
			break;
		}
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"BeginDate" => true, 
			"EndDate" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[3] { "Id", "BeginDate", "EndDate" });
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
					_0024var_0024BeginDate = MasterBaseClass.ParseDateTime(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024EndDate = MasterBaseClass.ParseDateTime(vals[2]);
					}
					int num = 3;
					result = num;
				}
			}
		}
		return result;
	}
}
