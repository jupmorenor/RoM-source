using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MCycleSchedules : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024CycleId;

	public DateTime _0024var_0024BeginDate;

	public DateTime _0024var_0024EndDate;

	public int _0024var_0024RaidBossMonsterId;

	public int _0024var_0024RaidBossLevel;

	public DateTime _0024var_0024BatchExecutableBeginDate;

	public DateTime _0024var_0024BatchExecutableEndDate;

	public string _0024var_0024iOSNoticeJson;

	public string _0024var_0024AndroidNoticeJson;

	public DateTime _0024var_0024DraftBeginDate;

	public DateTime _0024var_0024DraftEndDate;

	public int _0024var_0024FullPowerDamage;

	[NonSerialized]
	private MMonsters RaidBossMonsterId__cache;

	[NonSerialized]
	private static Dictionary<int, MCycleSchedules> _0024mst_0024114 = new Dictionary<int, MCycleSchedules>();

	[NonSerialized]
	private static MCycleSchedules[] All_cache;

	public int Id => _0024var_0024Id;

	public int CycleId => _0024var_0024CycleId;

	public DateTime BeginDate => _0024var_0024BeginDate;

	public DateTime EndDate => _0024var_0024EndDate;

	public MMonsters RaidBossMonsterId
	{
		get
		{
			if (RaidBossMonsterId__cache == null)
			{
				RaidBossMonsterId__cache = MMonsters.Get(_0024var_0024RaidBossMonsterId);
			}
			return RaidBossMonsterId__cache;
		}
	}

	public int RaidBossLevel => _0024var_0024RaidBossLevel;

	public DateTime BatchExecutableBeginDate => _0024var_0024BatchExecutableBeginDate;

	public DateTime BatchExecutableEndDate => _0024var_0024BatchExecutableEndDate;

	public string iOSNoticeJson => _0024var_0024iOSNoticeJson;

	public string AndroidNoticeJson => _0024var_0024AndroidNoticeJson;

	public DateTime DraftBeginDate => _0024var_0024DraftBeginDate;

	public DateTime DraftEndDate => _0024var_0024DraftEndDate;

	public int FullPowerDamage => _0024var_0024FullPowerDamage;

	public static MCycleSchedules[] All
	{
		get
		{
			MCycleSchedules[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MCycleSchedules");
				MCycleSchedules[] array = (MCycleSchedules[])Builtins.array(typeof(MCycleSchedules), _0024mst_0024114.Values);
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

	public MCycleSchedules()
	{
		_0024var_0024BeginDate = DateTime.Parse("2001/01/01");
		_0024var_0024EndDate = DateTime.Parse("2099/01/01");
		_0024var_0024BatchExecutableBeginDate = DateTime.Parse("2001/01/01");
		_0024var_0024BatchExecutableEndDate = DateTime.Parse("2099/01/01");
		_0024var_0024DraftBeginDate = DateTime.Parse("2001/01/01");
		_0024var_0024DraftEndDate = DateTime.Parse("2099/01/01");
		_0024var_0024FullPowerDamage = 100000;
	}

	public static MCycleSchedules GetByCycleId(int cycleId)
	{
		int num = 0;
		MCycleSchedules[] all = All;
		int length = all.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (all[num].CycleId == cycleId)
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
		return (MCycleSchedules)result;
	}

	public override string ToString()
	{
		return new StringBuilder("MCycleSchedules(").Append((object)Id).Append(":").Append((object)CycleId)
			.Append(", ")
			.Append(RaidBossMonsterId)
			.Append("/Lv")
			.Append((object)RaidBossLevel)
			.Append(", ")
			.Append(BeginDate)
			.Append(" ~ ")
			.Append(EndDate)
			.Append(")")
			.ToString();
	}

	public static MCycleSchedules Get(int _id)
	{
		MerlinMaster.GetHandler("MCycleSchedules");
		return (!_0024mst_0024114.ContainsKey(_id)) ? null : _0024mst_0024114[_id];
	}

	public static void Unload()
	{
		_0024mst_0024114.Clear();
		All_cache = null;
	}

	public static MCycleSchedules New(Hashtable data)
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
			MCycleSchedules mCycleSchedules = Create(data);
			if (!_0024mst_0024114.ContainsKey(mCycleSchedules.Id))
			{
				_0024mst_0024114[mCycleSchedules.Id] = mCycleSchedules;
			}
			result = mCycleSchedules;
		}
		return (MCycleSchedules)result;
	}

	public static MCycleSchedules New2(string[] keys, object[] vals)
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
		return (MCycleSchedules)result;
	}

	public static MCycleSchedules Entry(MCycleSchedules mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024114[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MCycleSchedules)result;
	}

	public static void AddMst(MCycleSchedules mst)
	{
		if (mst != null)
		{
			_0024mst_0024114[mst.Id] = mst;
		}
	}

	public static MCycleSchedules Create(Hashtable data)
	{
		MCycleSchedules mCycleSchedules = new MCycleSchedules();
		MCycleSchedules result;
		if (data == null)
		{
			result = mCycleSchedules;
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
				mCycleSchedules.setField((string)obj, data[current]);
			}
			result = mCycleSchedules;
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
		case "CycleId":
			_0024var_0024CycleId = MasterBaseClass.ToInt(val);
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
			object obj5 = val;
			if (!(obj5 is string))
			{
				obj5 = RuntimeServices.Coerce(obj5, typeof(string));
			}
			_0024var_0024EndDate = DateTime.Parse((string)obj5);
			break;
		}
		case "RaidBossMonsterId":
			_0024var_0024RaidBossMonsterId = MasterBaseClass.ToInt(val);
			break;
		case "RaidBossLevel":
			_0024var_0024RaidBossLevel = MasterBaseClass.ToInt(val);
			break;
		case "BatchExecutableBeginDate":
		{
			object obj6 = val;
			if (!(obj6 is string))
			{
				obj6 = RuntimeServices.Coerce(obj6, typeof(string));
			}
			_0024var_0024BatchExecutableBeginDate = DateTime.Parse((string)obj6);
			break;
		}
		case "BatchExecutableEndDate":
		{
			object obj4 = val;
			if (!(obj4 is string))
			{
				obj4 = RuntimeServices.Coerce(obj4, typeof(string));
			}
			_0024var_0024BatchExecutableEndDate = DateTime.Parse((string)obj4);
			break;
		}
		case "iOSNoticeJson":
			_0024var_0024iOSNoticeJson = MasterBaseClass.ToStringValue(val);
			break;
		case "AndroidNoticeJson":
			_0024var_0024AndroidNoticeJson = MasterBaseClass.ToStringValue(val);
			break;
		case "DraftBeginDate":
		{
			object obj3 = val;
			if (!(obj3 is string))
			{
				obj3 = RuntimeServices.Coerce(obj3, typeof(string));
			}
			_0024var_0024DraftBeginDate = DateTime.Parse((string)obj3);
			break;
		}
		case "DraftEndDate":
		{
			object obj = val;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			_0024var_0024DraftEndDate = DateTime.Parse((string)obj);
			break;
		}
		case "FullPowerDamage":
			_0024var_0024FullPowerDamage = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"CycleId" => true, 
			"BeginDate" => true, 
			"EndDate" => true, 
			"RaidBossMonsterId" => true, 
			"RaidBossLevel" => true, 
			"BatchExecutableBeginDate" => true, 
			"BatchExecutableEndDate" => true, 
			"iOSNoticeJson" => true, 
			"AndroidNoticeJson" => true, 
			"DraftBeginDate" => true, 
			"DraftEndDate" => true, 
			"FullPowerDamage" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[13]
		{
			"Id", "CycleId", "BeginDate", "EndDate", "RaidBossMonsterId", "RaidBossLevel", "BatchExecutableBeginDate", "BatchExecutableEndDate", "iOSNoticeJson", "AndroidNoticeJson",
			"DraftBeginDate", "DraftEndDate", "FullPowerDamage"
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
					_0024var_0024CycleId = MasterBaseClass.ParseInt(vals[1]);
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
								_0024var_0024RaidBossMonsterId = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024RaidBossLevel = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024BatchExecutableBeginDate = MasterBaseClass.ParseDateTime(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024BatchExecutableEndDate = MasterBaseClass.ParseDateTime(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024iOSNoticeJson = vals[8];
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024AndroidNoticeJson = vals[9];
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024DraftBeginDate = MasterBaseClass.ParseDateTime(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024DraftEndDate = MasterBaseClass.ParseDateTime(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024FullPowerDamage = MasterBaseClass.ParseInt(vals[12]);
															}
															int num = 13;
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
			}
		}
		return result;
	}
}
