using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MWeekEvents : MerlinMaster
{
	public int _0024var_0024Id;

	public DateTime _0024var_0024BeginDate;

	public DateTime _0024var_0024EndDate;

	public EnumWeek _0024var_0024Week;

	public int _0024var_0024PlayerGroupId;

	public TimeSpan _0024var_0024BeginTime;

	public TimeSpan _0024var_0024EndTime;

	public int _0024var_0024MStoryId;

	public string _0024var_0024Mark;

	[NonSerialized]
	private MStories MStoryId__cache;

	[NonSerialized]
	private static Dictionary<int, MWeekEvents> _0024mst_002495 = new Dictionary<int, MWeekEvents>();

	[NonSerialized]
	private static MWeekEvents[] All_cache;

	public int Id => _0024var_0024Id;

	public DateTime BeginDate => _0024var_0024BeginDate;

	public DateTime EndDate => _0024var_0024EndDate;

	public EnumWeek Week => _0024var_0024Week;

	public int PlayerGroupId => _0024var_0024PlayerGroupId;

	public TimeSpan BeginTime => _0024var_0024BeginTime;

	public TimeSpan EndTime => _0024var_0024EndTime;

	public MStories MStoryId
	{
		get
		{
			if (MStoryId__cache == null)
			{
				MStoryId__cache = MStories.Get(_0024var_0024MStoryId);
			}
			return MStoryId__cache;
		}
	}

	public string Mark => _0024var_0024Mark;

	public static MWeekEvents[] All
	{
		get
		{
			MWeekEvents[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MWeekEvents");
				MWeekEvents[] array = (MWeekEvents[])Builtins.array(typeof(MWeekEvents), _0024mst_002495.Values);
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

	public MWeekEvents()
	{
		_0024var_0024BeginDate = DateTime.Parse("2001/01/01");
		_0024var_0024EndDate = DateTime.Parse("2099/01/01");
	}

	public override string ToString()
	{
		return new StringBuilder("MWeekEvents(").Append((object)Id).Append(", ").Append(BeginDate)
			.Append(" ~ ")
			.Append(EndDate)
			.Append(", ")
			.Append(MStoryId)
			.Append(")")
			.ToString();
	}

	public override string ToDebugModeString()
	{
		return new StringBuilder("PGID:").Append((object)PlayerGroupId).Append(" ").Append(Week)
			.Append(" ")
			.Append(BeginTime)
			.Append(" ~ ")
			.Append(EndTime)
			.ToString();
	}

	public static MWeekEvents Get(int _id)
	{
		MerlinMaster.GetHandler("MWeekEvents");
		return (!_0024mst_002495.ContainsKey(_id)) ? null : _0024mst_002495[_id];
	}

	public static void Unload()
	{
		_0024mst_002495.Clear();
		All_cache = null;
	}

	public static MWeekEvents New(Hashtable data)
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
			MWeekEvents mWeekEvents = Create(data);
			if (!_0024mst_002495.ContainsKey(mWeekEvents.Id))
			{
				_0024mst_002495[mWeekEvents.Id] = mWeekEvents;
			}
			result = mWeekEvents;
		}
		return (MWeekEvents)result;
	}

	public static MWeekEvents New2(string[] keys, object[] vals)
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
		return (MWeekEvents)result;
	}

	public static MWeekEvents Entry(MWeekEvents mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002495[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MWeekEvents)result;
	}

	public static void AddMst(MWeekEvents mst)
	{
		if (mst != null)
		{
			_0024mst_002495[mst.Id] = mst;
		}
	}

	public static MWeekEvents Create(Hashtable data)
	{
		MWeekEvents mWeekEvents = new MWeekEvents();
		MWeekEvents result;
		if (data == null)
		{
			result = mWeekEvents;
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
				mWeekEvents.setField((string)obj, data[current]);
			}
			result = mWeekEvents;
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
			object obj4 = val;
			if (!(obj4 is string))
			{
				obj4 = RuntimeServices.Coerce(obj4, typeof(string));
			}
			_0024var_0024EndDate = DateTime.Parse((string)obj4);
			break;
		}
		case "Week":
			if (typeof(EnumWeek).IsEnum)
			{
				_0024var_0024Week = (EnumWeek)MasterBaseClass.ToEnum(val);
			}
			break;
		case "PlayerGroupId":
			_0024var_0024PlayerGroupId = MasterBaseClass.ToInt(val);
			break;
		case "BeginTime":
		{
			object obj3 = val;
			if (!(obj3 is string))
			{
				obj3 = RuntimeServices.Coerce(obj3, typeof(string));
			}
			_0024var_0024BeginTime = TimeSpan.Parse((string)obj3);
			break;
		}
		case "EndTime":
		{
			object obj = val;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			_0024var_0024EndTime = TimeSpan.Parse((string)obj);
			break;
		}
		case "MStoryId":
			_0024var_0024MStoryId = MasterBaseClass.ToInt(val);
			break;
		case "Mark":
			_0024var_0024Mark = MasterBaseClass.ToStringValue(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"BeginDate" => true, 
			"EndDate" => true, 
			"Week" => true, 
			"PlayerGroupId" => true, 
			"BeginTime" => true, 
			"EndTime" => true, 
			"MStoryId" => true, 
			"Mark" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[9] { "Id", "BeginDate", "EndDate", "Week", "PlayerGroupId", "BeginTime", "EndTime", "MStoryId", "Mark" });
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
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null && typeof(EnumWeek).IsEnum)
						{
							_0024var_0024Week = (EnumWeek)MasterBaseClass.ParseEnum(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024PlayerGroupId = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024BeginTime = MasterBaseClass.ParseTimeSpan(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024EndTime = MasterBaseClass.ParseTimeSpan(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024MStoryId = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024Mark = vals[8];
											}
											int num = 9;
											result = num;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		return result;
	}
}
