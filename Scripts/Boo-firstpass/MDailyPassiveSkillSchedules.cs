using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MDailyPassiveSkillSchedules : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MColosseumEventId;

	public DateTime _0024var_0024BeginDate;

	public DateTime _0024var_0024EndDate;

	public int _0024var_0024MCoverSkillId;

	[NonSerialized]
	private MColosseumEvents MColosseumEventId__cache;

	[NonSerialized]
	private MCoverSkills MCoverSkillId__cache;

	[NonSerialized]
	private static Dictionary<int, MDailyPassiveSkillSchedules> _0024mst_0024145 = new Dictionary<int, MDailyPassiveSkillSchedules>();

	[NonSerialized]
	private static MDailyPassiveSkillSchedules[] All_cache;

	public int Id => _0024var_0024Id;

	public MColosseumEvents MColosseumEventId
	{
		get
		{
			if (MColosseumEventId__cache == null)
			{
				MColosseumEventId__cache = MColosseumEvents.Get(_0024var_0024MColosseumEventId);
			}
			return MColosseumEventId__cache;
		}
	}

	public DateTime BeginDate => _0024var_0024BeginDate;

	public DateTime EndDate => _0024var_0024EndDate;

	public MCoverSkills MCoverSkillId
	{
		get
		{
			if (MCoverSkillId__cache == null)
			{
				MCoverSkillId__cache = MCoverSkills.Get(_0024var_0024MCoverSkillId);
			}
			return MCoverSkillId__cache;
		}
	}

	public static MDailyPassiveSkillSchedules[] All
	{
		get
		{
			MDailyPassiveSkillSchedules[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MDailyPassiveSkillSchedules");
				MDailyPassiveSkillSchedules[] array = (MDailyPassiveSkillSchedules[])Builtins.array(typeof(MDailyPassiveSkillSchedules), _0024mst_0024145.Values);
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

	public static MDailyPassiveSkillSchedules Get(int _id)
	{
		MerlinMaster.GetHandler("MDailyPassiveSkillSchedules");
		return (!_0024mst_0024145.ContainsKey(_id)) ? null : _0024mst_0024145[_id];
	}

	public static void Unload()
	{
		_0024mst_0024145.Clear();
		All_cache = null;
	}

	public static MDailyPassiveSkillSchedules New(Hashtable data)
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
			MDailyPassiveSkillSchedules mDailyPassiveSkillSchedules = Create(data);
			if (!_0024mst_0024145.ContainsKey(mDailyPassiveSkillSchedules.Id))
			{
				_0024mst_0024145[mDailyPassiveSkillSchedules.Id] = mDailyPassiveSkillSchedules;
			}
			result = mDailyPassiveSkillSchedules;
		}
		return (MDailyPassiveSkillSchedules)result;
	}

	public static MDailyPassiveSkillSchedules New2(string[] keys, object[] vals)
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
		return (MDailyPassiveSkillSchedules)result;
	}

	public static MDailyPassiveSkillSchedules Entry(MDailyPassiveSkillSchedules mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024145[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MDailyPassiveSkillSchedules)result;
	}

	public static void AddMst(MDailyPassiveSkillSchedules mst)
	{
		if (mst != null)
		{
			_0024mst_0024145[mst.Id] = mst;
		}
	}

	public static MDailyPassiveSkillSchedules Create(Hashtable data)
	{
		MDailyPassiveSkillSchedules mDailyPassiveSkillSchedules = new MDailyPassiveSkillSchedules();
		MDailyPassiveSkillSchedules result;
		if (data == null)
		{
			result = mDailyPassiveSkillSchedules;
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
				mDailyPassiveSkillSchedules.setField((string)obj, data[current]);
			}
			result = mDailyPassiveSkillSchedules;
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
		case "MColosseumEventId":
			_0024var_0024MColosseumEventId = MasterBaseClass.ToInt(val);
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
		case "MCoverSkillId":
			_0024var_0024MCoverSkillId = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"MColosseumEventId" => true, 
			"BeginDate" => true, 
			"EndDate" => true, 
			"MCoverSkillId" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[5] { "Id", "MColosseumEventId", "BeginDate", "EndDate", "MCoverSkillId" });
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
					_0024var_0024MColosseumEventId = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024BeginDate = MasterBaseClass.ParseDateTime(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024EndDate = MasterBaseClass.ParseDateTime(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024MCoverSkillId = MasterBaseClass.ParseInt(vals[4]);
							}
							int num = 5;
							result = num;
						}
					}
				}
			}
		}
		return result;
	}
}
