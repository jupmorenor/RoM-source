using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MColosseumEvents : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	public string _0024var_0024Name;

	public bool _0024var_0024IsFriendCompetition;

	public int _0024var_0024NoFrCompeOpponentListCount;

	public DateTime _0024var_0024BeginDate;

	public DateTime _0024var_0024EndDate;

	public int _0024var_0024BpCost;

	public int _0024var_0024MItemGroupId;

	public bool _0024var_0024IsRankingEvent;

	public bool _0024var_0024IsCostLimit;

	public int _0024var_0024CostLimit;

	public bool _0024var_0024IsElementLimit;

	public EnumElements _0024var_0024ElementLimit;

	public bool _0024var_0024IsStyleLimit;

	public EnumStyles _0024var_0024StyleLimit;

	public bool _0024var_0024IsMinRarityLimit;

	public EnumRares _0024var_0024MinRarityLimit;

	public bool _0024var_0024IsMaxRarityLimit;

	public EnumRares _0024var_0024MaxRarityLimit;

	public string _0024var_0024BannerHtml;

	[NonSerialized]
	private MItemGroups MItemGroupId__cache;

	[NonSerialized]
	private static Dictionary<int, MColosseumEvents> _0024mst_0024137 = new Dictionary<int, MColosseumEvents>();

	[NonSerialized]
	private static MColosseumEvents[] All_cache;

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

	public string Name => _0024var_0024Name;

	public bool IsFriendCompetition => _0024var_0024IsFriendCompetition;

	public int NoFrCompeOpponentListCount => _0024var_0024NoFrCompeOpponentListCount;

	public DateTime BeginDate => _0024var_0024BeginDate;

	public DateTime EndDate => _0024var_0024EndDate;

	public int BpCost => _0024var_0024BpCost;

	public MItemGroups MItemGroupId
	{
		get
		{
			if (MItemGroupId__cache == null)
			{
				MItemGroupId__cache = MItemGroups.Get(_0024var_0024MItemGroupId);
			}
			return MItemGroupId__cache;
		}
	}

	public bool IsRankingEvent => _0024var_0024IsRankingEvent;

	public bool IsCostLimit => _0024var_0024IsCostLimit;

	public int CostLimit => _0024var_0024CostLimit;

	public bool IsElementLimit => _0024var_0024IsElementLimit;

	public EnumElements ElementLimit => _0024var_0024ElementLimit;

	public bool IsStyleLimit => _0024var_0024IsStyleLimit;

	public EnumStyles StyleLimit => _0024var_0024StyleLimit;

	public bool IsMinRarityLimit => _0024var_0024IsMinRarityLimit;

	public EnumRares MinRarityLimit => _0024var_0024MinRarityLimit;

	public bool IsMaxRarityLimit => _0024var_0024IsMaxRarityLimit;

	public EnumRares MaxRarityLimit => _0024var_0024MaxRarityLimit;

	public string BannerHtml => _0024var_0024BannerHtml;

	public static MColosseumEvents[] All
	{
		get
		{
			MColosseumEvents[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MColosseumEvents");
				MColosseumEvents[] array = (MColosseumEvents[])Builtins.array(typeof(MColosseumEvents), _0024mst_0024137.Values);
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

	public bool isInTime()
	{
		return isInTime(MerlinDateTime.UtcNow);
	}

	public bool isInTime(DateTime utc)
	{
		bool num = BeginDate <= utc;
		if (num)
		{
			num = utc < EndDate;
		}
		return num;
	}

	public static MColosseumEvents GetActiveFriendEvent()
	{
		MColosseumEvents result = null;
		int i = 0;
		MColosseumEvents[] all = All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (all[i].isInTime() && all[i].IsFriendCompetition)
			{
				result = all[i];
			}
		}
		return result;
	}

	public static MColosseumEvents Get(int _id)
	{
		MerlinMaster.GetHandler("MColosseumEvents");
		return (!_0024mst_0024137.ContainsKey(_id)) ? null : _0024mst_0024137[_id];
	}

	public static void Unload()
	{
		_0024mst_0024137.Clear();
		All_cache = null;
	}

	public static MColosseumEvents New(Hashtable data)
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
			MColosseumEvents mColosseumEvents = Create(data);
			if (!_0024mst_0024137.ContainsKey(mColosseumEvents.Id))
			{
				_0024mst_0024137[mColosseumEvents.Id] = mColosseumEvents;
			}
			result = mColosseumEvents;
		}
		return (MColosseumEvents)result;
	}

	public static MColosseumEvents New2(string[] keys, object[] vals)
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
		return (MColosseumEvents)result;
	}

	public static MColosseumEvents Entry(MColosseumEvents mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024137[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MColosseumEvents)result;
	}

	public static void AddMst(MColosseumEvents mst)
	{
		if (mst != null)
		{
			_0024mst_0024137[mst.Id] = mst;
		}
	}

	public static MColosseumEvents Create(Hashtable data)
	{
		MColosseumEvents mColosseumEvents = new MColosseumEvents();
		MColosseumEvents result;
		if (data == null)
		{
			result = mColosseumEvents;
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
				mColosseumEvents.setField((string)obj, data[current]);
			}
			result = mColosseumEvents;
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
		case "Progname":
			_0024var_0024Progname = MasterBaseClass.ToStringValue(val);
			break;
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		case "IsFriendCompetition":
			_0024var_0024IsFriendCompetition = MasterBaseClass.ToBool(val);
			break;
		case "NoFrCompeOpponentListCount":
			_0024var_0024NoFrCompeOpponentListCount = MasterBaseClass.ToInt(val);
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
		case "BpCost":
			_0024var_0024BpCost = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupId":
			_0024var_0024MItemGroupId = MasterBaseClass.ToInt(val);
			break;
		case "IsRankingEvent":
			_0024var_0024IsRankingEvent = MasterBaseClass.ToBool(val);
			break;
		case "IsCostLimit":
			_0024var_0024IsCostLimit = MasterBaseClass.ToBool(val);
			break;
		case "CostLimit":
			_0024var_0024CostLimit = MasterBaseClass.ToInt(val);
			break;
		case "IsElementLimit":
			_0024var_0024IsElementLimit = MasterBaseClass.ToBool(val);
			break;
		case "ElementLimit":
			if (typeof(EnumElements).IsEnum)
			{
				_0024var_0024ElementLimit = (EnumElements)MasterBaseClass.ToEnum(val);
			}
			break;
		case "IsStyleLimit":
			_0024var_0024IsStyleLimit = MasterBaseClass.ToBool(val);
			break;
		case "StyleLimit":
			if (typeof(EnumStyles).IsEnum)
			{
				_0024var_0024StyleLimit = (EnumStyles)MasterBaseClass.ToEnum(val);
			}
			break;
		case "IsMinRarityLimit":
			_0024var_0024IsMinRarityLimit = MasterBaseClass.ToBool(val);
			break;
		case "MinRarityLimit":
			if (typeof(EnumRares).IsEnum)
			{
				_0024var_0024MinRarityLimit = (EnumRares)MasterBaseClass.ToEnum(val);
			}
			break;
		case "IsMaxRarityLimit":
			_0024var_0024IsMaxRarityLimit = MasterBaseClass.ToBool(val);
			break;
		case "MaxRarityLimit":
			if (typeof(EnumRares).IsEnum)
			{
				_0024var_0024MaxRarityLimit = (EnumRares)MasterBaseClass.ToEnum(val);
			}
			break;
		case "BannerHtml":
			_0024var_0024BannerHtml = MasterBaseClass.ToStringValue(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Progname" => true, 
			"Name" => true, 
			"IsFriendCompetition" => true, 
			"NoFrCompeOpponentListCount" => true, 
			"BeginDate" => true, 
			"EndDate" => true, 
			"BpCost" => true, 
			"MItemGroupId" => true, 
			"IsRankingEvent" => true, 
			"IsCostLimit" => true, 
			"CostLimit" => true, 
			"IsElementLimit" => true, 
			"ElementLimit" => true, 
			"IsStyleLimit" => true, 
			"StyleLimit" => true, 
			"IsMinRarityLimit" => true, 
			"MinRarityLimit" => true, 
			"IsMaxRarityLimit" => true, 
			"MaxRarityLimit" => true, 
			"BannerHtml" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[21]
		{
			"Id", "Progname", "Name", "IsFriendCompetition", "NoFrCompeOpponentListCount", "BeginDate", "EndDate", "BpCost", "MItemGroupId", "IsRankingEvent",
			"IsCostLimit", "CostLimit", "IsElementLimit", "ElementLimit", "IsStyleLimit", "StyleLimit", "IsMinRarityLimit", "MinRarityLimit", "IsMaxRarityLimit", "MaxRarityLimit",
			"BannerHtml"
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
					_0024var_0024Progname = vals[1];
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024Name = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024IsFriendCompetition = MasterBaseClass.ParseBool(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024NoFrCompeOpponentListCount = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024BeginDate = MasterBaseClass.ParseDateTime(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024EndDate = MasterBaseClass.ParseDateTime(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024BpCost = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024MItemGroupId = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024IsRankingEvent = MasterBaseClass.ParseBool(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024IsCostLimit = MasterBaseClass.ParseBool(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024CostLimit = MasterBaseClass.ParseInt(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024IsElementLimit = MasterBaseClass.ParseBool(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null && typeof(EnumElements).IsEnum)
																{
																	_0024var_0024ElementLimit = (EnumElements)MasterBaseClass.ParseEnum(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024IsStyleLimit = MasterBaseClass.ParseBool(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null && typeof(EnumStyles).IsEnum)
																		{
																			_0024var_0024StyleLimit = (EnumStyles)MasterBaseClass.ParseEnum(vals[15]);
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null)
																			{
																				_0024var_0024IsMinRarityLimit = MasterBaseClass.ParseBool(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null && typeof(EnumRares).IsEnum)
																				{
																					_0024var_0024MinRarityLimit = (EnumRares)MasterBaseClass.ParseEnum(vals[17]);
																				}
																				if (length <= 18)
																				{
																					result = 18;
																				}
																				else
																				{
																					if (vals[18] != null)
																					{
																						_0024var_0024IsMaxRarityLimit = MasterBaseClass.ParseBool(vals[18]);
																					}
																					if (length <= 19)
																					{
																						result = 19;
																					}
																					else
																					{
																						if (vals[19] != null && typeof(EnumRares).IsEnum)
																						{
																							_0024var_0024MaxRarityLimit = (EnumRares)MasterBaseClass.ParseEnum(vals[19]);
																						}
																						if (length <= 20)
																						{
																							result = 20;
																						}
																						else
																						{
																							if (vals[20] != null)
																							{
																								_0024var_0024BannerHtml = vals[20];
																							}
																							int num = 21;
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
