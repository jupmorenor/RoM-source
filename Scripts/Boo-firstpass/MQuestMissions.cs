using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MQuestMissions : MerlinMaster
{
	public int _0024var_0024Id;

	public EnumMissionTypeValues _0024var_0024MissionTypeValue;

	public DateTime _0024var_0024BeginDate;

	public DateTime _0024var_0024EndDate;

	public int _0024var_0024MQuestId;

	public EnumMissionConditionTypes _0024var_0024ConditionTypeValue1;

	public EnumMissionConditionTypes _0024var_0024ConditionTypeValue2;

	public int _0024var_0024ConditionParameter1;

	public int _0024var_0024ConditionParameter2;

	public int _0024var_0024Number;

	public string _0024var_0024Detail;

	[NonSerialized]
	private MQuests MQuestId__cache;

	[NonSerialized]
	private static Dictionary<int, MQuestMissions> _0024mst_0024146 = new Dictionary<int, MQuestMissions>();

	[NonSerialized]
	private static MQuestMissions[] All_cache;

	public int Id => _0024var_0024Id;

	public EnumMissionTypeValues MissionTypeValue => _0024var_0024MissionTypeValue;

	public DateTime BeginDate => _0024var_0024BeginDate;

	public DateTime EndDate => _0024var_0024EndDate;

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

	public EnumMissionConditionTypes ConditionTypeValue1 => _0024var_0024ConditionTypeValue1;

	public EnumMissionConditionTypes ConditionTypeValue2 => _0024var_0024ConditionTypeValue2;

	public int ConditionParameter1 => _0024var_0024ConditionParameter1;

	public int ConditionParameter2 => _0024var_0024ConditionParameter2;

	public int Number => _0024var_0024Number;

	public string Detail => _0024var_0024Detail;

	public static MQuestMissions[] All
	{
		get
		{
			MQuestMissions[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MQuestMissions");
				MQuestMissions[] array = (MQuestMissions[])Builtins.array(typeof(MQuestMissions), _0024mst_0024146.Values);
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
		return new StringBuilder("MQuestMissions(").Append((object)Id).Append(" type=").Append(MissionTypeValue)
			.Append(" ")
			.Append(BeginDate)
			.Append("-")
			.Append(EndDate)
			.Append(")")
			.ToString();
	}

	public static MQuestMissions Get(int _id)
	{
		MerlinMaster.GetHandler("MQuestMissions");
		return (!_0024mst_0024146.ContainsKey(_id)) ? null : _0024mst_0024146[_id];
	}

	public static void Unload()
	{
		_0024mst_0024146.Clear();
		All_cache = null;
	}

	public static MQuestMissions New(Hashtable data)
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
			MQuestMissions mQuestMissions = Create(data);
			if (!_0024mst_0024146.ContainsKey(mQuestMissions.Id))
			{
				_0024mst_0024146[mQuestMissions.Id] = mQuestMissions;
			}
			result = mQuestMissions;
		}
		return (MQuestMissions)result;
	}

	public static MQuestMissions New2(string[] keys, object[] vals)
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
		return (MQuestMissions)result;
	}

	public static MQuestMissions Entry(MQuestMissions mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024146[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MQuestMissions)result;
	}

	public static void AddMst(MQuestMissions mst)
	{
		if (mst != null)
		{
			_0024mst_0024146[mst.Id] = mst;
		}
	}

	public static MQuestMissions Create(Hashtable data)
	{
		MQuestMissions mQuestMissions = new MQuestMissions();
		MQuestMissions result;
		if (data == null)
		{
			result = mQuestMissions;
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
				mQuestMissions.setField((string)obj, data[current]);
			}
			result = mQuestMissions;
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
		case "MissionTypeValue":
			if (typeof(EnumMissionTypeValues).IsEnum)
			{
				_0024var_0024MissionTypeValue = (EnumMissionTypeValues)MasterBaseClass.ToEnum(val);
			}
			break;
		case "BeginDate":
		{
			object obj = val;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			_0024var_0024BeginDate = DateTime.Parse((string)obj);
			break;
		}
		case "EndDate":
		{
			object obj2 = val;
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			_0024var_0024EndDate = DateTime.Parse((string)obj2);
			break;
		}
		case "MQuestId":
			_0024var_0024MQuestId = MasterBaseClass.ToInt(val);
			break;
		case "ConditionTypeValue1":
			if (typeof(EnumMissionConditionTypes).IsEnum)
			{
				_0024var_0024ConditionTypeValue1 = (EnumMissionConditionTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "ConditionTypeValue2":
			if (typeof(EnumMissionConditionTypes).IsEnum)
			{
				_0024var_0024ConditionTypeValue2 = (EnumMissionConditionTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "ConditionParameter1":
			_0024var_0024ConditionParameter1 = MasterBaseClass.ToInt(val);
			break;
		case "ConditionParameter2":
			_0024var_0024ConditionParameter2 = MasterBaseClass.ToInt(val);
			break;
		case "Number":
			_0024var_0024Number = MasterBaseClass.ToInt(val);
			break;
		case "Detail":
			_0024var_0024Detail = MasterBaseClass.ToStringValue(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"MissionTypeValue" => true, 
			"BeginDate" => true, 
			"EndDate" => true, 
			"MQuestId" => true, 
			"ConditionTypeValue1" => true, 
			"ConditionTypeValue2" => true, 
			"ConditionParameter1" => true, 
			"ConditionParameter2" => true, 
			"Number" => true, 
			"Detail" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[11]
		{
			"Id", "MissionTypeValue", "BeginDate", "EndDate", "MQuestId", "ConditionTypeValue1", "ConditionTypeValue2", "ConditionParameter1", "ConditionParameter2", "Number",
			"Detail"
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
				if (vals[1] != null && typeof(EnumMissionTypeValues).IsEnum)
				{
					_0024var_0024MissionTypeValue = (EnumMissionTypeValues)MasterBaseClass.ParseEnum(vals[1]);
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
								_0024var_0024MQuestId = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null && typeof(EnumMissionConditionTypes).IsEnum)
								{
									_0024var_0024ConditionTypeValue1 = (EnumMissionConditionTypes)MasterBaseClass.ParseEnum(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null && typeof(EnumMissionConditionTypes).IsEnum)
									{
										_0024var_0024ConditionTypeValue2 = (EnumMissionConditionTypes)MasterBaseClass.ParseEnum(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024ConditionParameter1 = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024ConditionParameter2 = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024Number = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024Detail = vals[10];
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
