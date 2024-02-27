using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MQuestTickets : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public DateTime _0024var_0024BeginDate;

	public DateTime _0024var_0024EndDate;

	public EnumWeek _0024var_0024Week;

	public int _0024var_0024Quantity;

	public int _0024var_0024EffectiveDate;

	public TimeSpan _0024var_0024EffectiveTime;

	public string _0024var_0024QuestIdList;

	public string _0024var_0024Icon;

	public string _0024var_0024Explain;

	[NonSerialized]
	private static Dictionary<int, MQuestTickets> _0024mst_0024123 = new Dictionary<int, MQuestTickets>();

	[NonSerialized]
	private static MQuestTickets[] All_cache;

	public int Id => _0024var_0024Id;

	public string Name => _0024var_0024Name;

	public DateTime BeginDate => _0024var_0024BeginDate;

	public DateTime EndDate => _0024var_0024EndDate;

	public EnumWeek Week => _0024var_0024Week;

	public int Quantity => _0024var_0024Quantity;

	public int EffectiveDate => _0024var_0024EffectiveDate;

	public TimeSpan EffectiveTime => _0024var_0024EffectiveTime;

	public string QuestIdList => _0024var_0024QuestIdList;

	public string Icon => _0024var_0024Icon;

	public string Explain => _0024var_0024Explain;

	public static MQuestTickets[] All
	{
		get
		{
			MQuestTickets[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MQuestTickets");
				MQuestTickets[] array = (MQuestTickets[])Builtins.array(typeof(MQuestTickets), _0024mst_0024123.Values);
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

	public MQuestTickets()
	{
		_0024var_0024Name = string.Empty;
		_0024var_0024BeginDate = DateTime.Parse("2001/01/01");
		_0024var_0024EndDate = DateTime.Parse("2001/01/01");
		_0024var_0024Quantity = 1;
		_0024var_0024EffectiveDate = 1;
		_0024var_0024EffectiveTime = TimeSpan.Parse("01:00:00");
	}

	public override string ToString()
	{
		return new StringBuilder("MQuestTickets(").Append((object)Id).Append(", ").Append(BeginDate)
			.Append(" ~ ")
			.Append(EndDate)
			.Append(", week:")
			.Append(Week)
			.Append(", days:")
			.Append((object)EffectiveDate)
			.Append(", time:")
			.Append(EffectiveTime)
			.Append(")")
			.ToString();
	}

	public static MQuestTickets Get(int _id)
	{
		MerlinMaster.GetHandler("MQuestTickets");
		return (!_0024mst_0024123.ContainsKey(_id)) ? null : _0024mst_0024123[_id];
	}

	public static void Unload()
	{
		_0024mst_0024123.Clear();
		All_cache = null;
	}

	public static MQuestTickets New(Hashtable data)
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
			MQuestTickets mQuestTickets = Create(data);
			if (!_0024mst_0024123.ContainsKey(mQuestTickets.Id))
			{
				_0024mst_0024123[mQuestTickets.Id] = mQuestTickets;
			}
			result = mQuestTickets;
		}
		return (MQuestTickets)result;
	}

	public static MQuestTickets New2(string[] keys, object[] vals)
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
		return (MQuestTickets)result;
	}

	public static MQuestTickets Entry(MQuestTickets mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024123[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MQuestTickets)result;
	}

	public static void AddMst(MQuestTickets mst)
	{
		if (mst != null)
		{
			_0024mst_0024123[mst.Id] = mst;
		}
	}

	public static MQuestTickets Create(Hashtable data)
	{
		MQuestTickets mQuestTickets = new MQuestTickets();
		MQuestTickets result;
		if (data == null)
		{
			result = mQuestTickets;
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
				mQuestTickets.setField((string)obj, data[current]);
			}
			result = mQuestTickets;
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
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
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
			object obj3 = val;
			if (!(obj3 is string))
			{
				obj3 = RuntimeServices.Coerce(obj3, typeof(string));
			}
			_0024var_0024EndDate = DateTime.Parse((string)obj3);
			break;
		}
		case "Week":
			if (typeof(EnumWeek).IsEnum)
			{
				_0024var_0024Week = (EnumWeek)MasterBaseClass.ToEnum(val);
			}
			break;
		case "Quantity":
			_0024var_0024Quantity = MasterBaseClass.ToInt(val);
			break;
		case "EffectiveDate":
			_0024var_0024EffectiveDate = MasterBaseClass.ToInt(val);
			break;
		case "EffectiveTime":
		{
			object obj = val;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			_0024var_0024EffectiveTime = TimeSpan.Parse((string)obj);
			break;
		}
		case "QuestIdList":
			_0024var_0024QuestIdList = MasterBaseClass.ToStringValue(val);
			break;
		case "Icon":
			_0024var_0024Icon = MasterBaseClass.ToStringValue(val);
			break;
		case "Explain":
			_0024var_0024Explain = MasterBaseClass.ToStringValue(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Name" => true, 
			"BeginDate" => true, 
			"EndDate" => true, 
			"Week" => true, 
			"Quantity" => true, 
			"EffectiveDate" => true, 
			"EffectiveTime" => true, 
			"QuestIdList" => true, 
			"Icon" => true, 
			"Explain" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[11]
		{
			"Id", "Name", "BeginDate", "EndDate", "Week", "Quantity", "EffectiveDate", "EffectiveTime", "QuestIdList", "Icon",
			"Explain"
		});
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
					_0024var_0024Name = vals[1];
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
							if (vals[4] != null && typeof(EnumWeek).IsEnum)
							{
								_0024var_0024Week = (EnumWeek)MasterBaseClass.ParseEnum(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Quantity = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024EffectiveDate = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024EffectiveTime = MasterBaseClass.ParseTimeSpan(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024QuestIdList = vals[8];
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024Icon = vals[9];
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024Explain = vals[10];
													}
													int num = 11;
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
			}
		}
		return result;
	}
}
