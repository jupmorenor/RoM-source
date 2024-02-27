using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MCampaigns : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Key;

	public int _0024var_0024Value;

	public string _0024var_0024Name;

	public string _0024var_0024Explain;

	public DateTime _0024var_0024BeginDate;

	public DateTime _0024var_0024EndDate;

	public float _0024var_0024ApRecoveryFastTimeEffectValue;

	public float _0024var_0024ApRecoveryFastTimeEffectExplain;

	public float _0024var_0024RpRecoveryFastTimeEffectValue;

	public float _0024var_0024RpRecoveryFastTimeEffectExplain;

	public float _0024var_0024GetCoinUpEffectValue;

	public float _0024var_0024GetCoinUpEffectExplain;

	public float _0024var_0024CompositionCostDownEffectValue;

	public float _0024var_0024CompositionCostDownEffectExplain;

	public float _0024var_0024CompositionExpUpEffectValue;

	public float _0024var_0024CompositionExpUpEffectExplain;

	public float _0024var_0024DropUpEffectValue;

	public float _0024var_0024DropUpEffectExplain;

	public float _0024var_0024GetExpUpEffectValue;

	public float _0024var_0024GetExpUpEffectExplain;

	public string _0024var_0024TargetStoryIds;

	public string _0024var_0024ExcludeStoryIds;

	public bool _0024var_0024IsDuplicate;

	public int _0024var_0024Priority;

	public EnumCampaignSegmentTypes _0024var_0024SegmentTypeValue;

	[NonSerialized]
	protected static Dictionary<int, MCampaigns[]> questTable;

	[NonSerialized]
	protected static Dictionary<int, HashSet<int>> excludeQuestTable;

	[NonSerialized]
	private static Dictionary<int, MCampaigns> _0024mst_002485 = new Dictionary<int, MCampaigns>();

	[NonSerialized]
	private static MCampaigns[] All_cache;

	public float ExplainValueForApRecoveryFastTimeEffectValue => (ApRecoveryFastTimeEffectExplain <= 0f) ? ApRecoveryFastTimeEffectValue : ApRecoveryFastTimeEffectExplain;

	public float ExplainValueForRpRecoveryFastTimeEffectValue => (RpRecoveryFastTimeEffectExplain <= 0f) ? RpRecoveryFastTimeEffectValue : RpRecoveryFastTimeEffectExplain;

	public float ExplainValueForGetCoinUpEffectValue => (GetCoinUpEffectExplain <= 0f) ? GetCoinUpEffectValue : GetCoinUpEffectExplain;

	public float ExplainValueForCompositionCostDownEffectValue => (CompositionCostDownEffectExplain <= 0f) ? CompositionCostDownEffectValue : CompositionCostDownEffectExplain;

	public float ExplainValueForCompositionExpUpEffectValue => (CompositionExpUpEffectExplain <= 0f) ? CompositionExpUpEffectValue : CompositionExpUpEffectExplain;

	public float ExplainValueForDropUpEffectValue => (DropUpEffectExplain <= 0f) ? DropUpEffectValue : DropUpEffectExplain;

	public float ExplainValueForGetExpUpEffectValue => (GetExpUpEffectExplain <= 0f) ? GetExpUpEffectValue : GetExpUpEffectExplain;

	public int Id => _0024var_0024Id;

	public string Key => _0024var_0024Key;

	public int Value => _0024var_0024Value;

	public string Name => _0024var_0024Name;

	public string Explain => _0024var_0024Explain;

	public DateTime BeginDate => _0024var_0024BeginDate;

	public DateTime EndDate => _0024var_0024EndDate;

	public float ApRecoveryFastTimeEffectValue => _0024var_0024ApRecoveryFastTimeEffectValue;

	public float ApRecoveryFastTimeEffectExplain => _0024var_0024ApRecoveryFastTimeEffectExplain;

	public float RpRecoveryFastTimeEffectValue => _0024var_0024RpRecoveryFastTimeEffectValue;

	public float RpRecoveryFastTimeEffectExplain => _0024var_0024RpRecoveryFastTimeEffectExplain;

	public float GetCoinUpEffectValue => _0024var_0024GetCoinUpEffectValue;

	public float GetCoinUpEffectExplain => _0024var_0024GetCoinUpEffectExplain;

	public float CompositionCostDownEffectValue => _0024var_0024CompositionCostDownEffectValue;

	public float CompositionCostDownEffectExplain => _0024var_0024CompositionCostDownEffectExplain;

	public float CompositionExpUpEffectValue => _0024var_0024CompositionExpUpEffectValue;

	public float CompositionExpUpEffectExplain => _0024var_0024CompositionExpUpEffectExplain;

	public float DropUpEffectValue => _0024var_0024DropUpEffectValue;

	public float DropUpEffectExplain => _0024var_0024DropUpEffectExplain;

	public float GetExpUpEffectValue => _0024var_0024GetExpUpEffectValue;

	public float GetExpUpEffectExplain => _0024var_0024GetExpUpEffectExplain;

	public string TargetStoryIds => _0024var_0024TargetStoryIds;

	public string ExcludeStoryIds => _0024var_0024ExcludeStoryIds;

	public bool IsDuplicate => _0024var_0024IsDuplicate;

	public int Priority => _0024var_0024Priority;

	public EnumCampaignSegmentTypes SegmentTypeValue => _0024var_0024SegmentTypeValue;

	public static MCampaigns[] All
	{
		get
		{
			MCampaigns[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MCampaigns");
				MCampaigns[] array = (MCampaigns[])Builtins.array(typeof(MCampaigns), _0024mst_002485.Values);
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

	public MCampaigns()
	{
		_0024var_0024BeginDate = DateTime.Parse("2001/01/01");
		_0024var_0024EndDate = DateTime.Parse("2099/01/01");
		_0024var_0024ApRecoveryFastTimeEffectValue = 1f;
		_0024var_0024ApRecoveryFastTimeEffectExplain = -1f;
		_0024var_0024RpRecoveryFastTimeEffectValue = 1f;
		_0024var_0024RpRecoveryFastTimeEffectExplain = -1f;
		_0024var_0024GetCoinUpEffectValue = 1f;
		_0024var_0024GetCoinUpEffectExplain = -1f;
		_0024var_0024CompositionCostDownEffectValue = 1f;
		_0024var_0024CompositionCostDownEffectExplain = -1f;
		_0024var_0024CompositionExpUpEffectValue = 1f;
		_0024var_0024CompositionExpUpEffectExplain = -1f;
		_0024var_0024DropUpEffectValue = 1f;
		_0024var_0024DropUpEffectExplain = -1f;
		_0024var_0024GetExpUpEffectValue = 1f;
		_0024var_0024GetExpUpEffectExplain = -1f;
		_0024var_0024Priority = 100;
		_0024var_0024SegmentTypeValue = EnumCampaignSegmentTypes.CampaignSegmentType_New;
	}

	public override string ToString()
	{
		return new StringBuilder("MCampaigns(").Append((object)Id).Append(",").Append(Name)
			.Append(",Key:")
			.Append(Key)
			.Append(")")
			.ToString();
	}

	public static MCampaigns Get(int _id)
	{
		MerlinMaster.GetHandler("MCampaigns");
		return (!_0024mst_002485.ContainsKey(_id)) ? null : _0024mst_002485[_id];
	}

	public static void Unload()
	{
		_0024mst_002485.Clear();
		All_cache = null;
	}

	public static MCampaigns New(Hashtable data)
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
			MCampaigns mCampaigns = Create(data);
			if (!_0024mst_002485.ContainsKey(mCampaigns.Id))
			{
				_0024mst_002485[mCampaigns.Id] = mCampaigns;
			}
			result = mCampaigns;
		}
		return (MCampaigns)result;
	}

	public static MCampaigns New2(string[] keys, object[] vals)
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
		return (MCampaigns)result;
	}

	public static MCampaigns Entry(MCampaigns mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002485[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MCampaigns)result;
	}

	public static void AddMst(MCampaigns mst)
	{
		if (mst != null)
		{
			_0024mst_002485[mst.Id] = mst;
		}
	}

	public static MCampaigns Create(Hashtable data)
	{
		MCampaigns mCampaigns = new MCampaigns();
		MCampaigns result;
		if (data == null)
		{
			result = mCampaigns;
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
				mCampaigns.setField((string)obj, data[current]);
			}
			result = mCampaigns;
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
		case "Key":
			_0024var_0024Key = MasterBaseClass.ToStringValue(val);
			break;
		case "Value":
			_0024var_0024Value = MasterBaseClass.ToInt(val);
			break;
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		case "Explain":
			_0024var_0024Explain = MasterBaseClass.ToStringValue(val);
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
		case "ApRecoveryFastTimeEffectValue":
			_0024var_0024ApRecoveryFastTimeEffectValue = MasterBaseClass.ToSingle(val);
			break;
		case "ApRecoveryFastTimeEffectExplain":
			_0024var_0024ApRecoveryFastTimeEffectExplain = MasterBaseClass.ToSingle(val);
			break;
		case "RpRecoveryFastTimeEffectValue":
			_0024var_0024RpRecoveryFastTimeEffectValue = MasterBaseClass.ToSingle(val);
			break;
		case "RpRecoveryFastTimeEffectExplain":
			_0024var_0024RpRecoveryFastTimeEffectExplain = MasterBaseClass.ToSingle(val);
			break;
		case "GetCoinUpEffectValue":
			_0024var_0024GetCoinUpEffectValue = MasterBaseClass.ToSingle(val);
			break;
		case "GetCoinUpEffectExplain":
			_0024var_0024GetCoinUpEffectExplain = MasterBaseClass.ToSingle(val);
			break;
		case "CompositionCostDownEffectValue":
			_0024var_0024CompositionCostDownEffectValue = MasterBaseClass.ToSingle(val);
			break;
		case "CompositionCostDownEffectExplain":
			_0024var_0024CompositionCostDownEffectExplain = MasterBaseClass.ToSingle(val);
			break;
		case "CompositionExpUpEffectValue":
			_0024var_0024CompositionExpUpEffectValue = MasterBaseClass.ToSingle(val);
			break;
		case "CompositionExpUpEffectExplain":
			_0024var_0024CompositionExpUpEffectExplain = MasterBaseClass.ToSingle(val);
			break;
		case "DropUpEffectValue":
			_0024var_0024DropUpEffectValue = MasterBaseClass.ToSingle(val);
			break;
		case "DropUpEffectExplain":
			_0024var_0024DropUpEffectExplain = MasterBaseClass.ToSingle(val);
			break;
		case "GetExpUpEffectValue":
			_0024var_0024GetExpUpEffectValue = MasterBaseClass.ToSingle(val);
			break;
		case "GetExpUpEffectExplain":
			_0024var_0024GetExpUpEffectExplain = MasterBaseClass.ToSingle(val);
			break;
		case "TargetStoryIds":
			_0024var_0024TargetStoryIds = MasterBaseClass.ToStringValue(val);
			break;
		case "ExcludeStoryIds":
			_0024var_0024ExcludeStoryIds = MasterBaseClass.ToStringValue(val);
			break;
		case "IsDuplicate":
			_0024var_0024IsDuplicate = MasterBaseClass.ToBool(val);
			break;
		case "Priority":
			_0024var_0024Priority = MasterBaseClass.ToInt(val);
			break;
		case "SegmentTypeValue":
			if (typeof(EnumCampaignSegmentTypes).IsEnum)
			{
				_0024var_0024SegmentTypeValue = (EnumCampaignSegmentTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Key" => true, 
			"Value" => true, 
			"Name" => true, 
			"Explain" => true, 
			"BeginDate" => true, 
			"EndDate" => true, 
			"ApRecoveryFastTimeEffectValue" => true, 
			"ApRecoveryFastTimeEffectExplain" => true, 
			"RpRecoveryFastTimeEffectValue" => true, 
			"RpRecoveryFastTimeEffectExplain" => true, 
			"GetCoinUpEffectValue" => true, 
			"GetCoinUpEffectExplain" => true, 
			"CompositionCostDownEffectValue" => true, 
			"CompositionCostDownEffectExplain" => true, 
			"CompositionExpUpEffectValue" => true, 
			"CompositionExpUpEffectExplain" => true, 
			"DropUpEffectValue" => true, 
			"DropUpEffectExplain" => true, 
			"GetExpUpEffectValue" => true, 
			"GetExpUpEffectExplain" => true, 
			"TargetStoryIds" => true, 
			"ExcludeStoryIds" => true, 
			"IsDuplicate" => true, 
			"Priority" => true, 
			"SegmentTypeValue" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[26]
		{
			"Id", "Key", "Value", "Name", "Explain", "BeginDate", "EndDate", "ApRecoveryFastTimeEffectValue", "ApRecoveryFastTimeEffectExplain", "RpRecoveryFastTimeEffectValue",
			"RpRecoveryFastTimeEffectExplain", "GetCoinUpEffectValue", "GetCoinUpEffectExplain", "CompositionCostDownEffectValue", "CompositionCostDownEffectExplain", "CompositionExpUpEffectValue", "CompositionExpUpEffectExplain", "DropUpEffectValue", "DropUpEffectExplain", "GetExpUpEffectValue",
			"GetExpUpEffectExplain", "TargetStoryIds", "ExcludeStoryIds", "IsDuplicate", "Priority", "SegmentTypeValue"
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
					_0024var_0024Key = vals[1];
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024Value = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Name = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024Explain = vals[4];
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
											_0024var_0024ApRecoveryFastTimeEffectValue = MasterBaseClass.ParseSingle(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024ApRecoveryFastTimeEffectExplain = MasterBaseClass.ParseSingle(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024RpRecoveryFastTimeEffectValue = MasterBaseClass.ParseSingle(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024RpRecoveryFastTimeEffectExplain = MasterBaseClass.ParseSingle(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024GetCoinUpEffectValue = MasterBaseClass.ParseSingle(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024GetCoinUpEffectExplain = MasterBaseClass.ParseSingle(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024CompositionCostDownEffectValue = MasterBaseClass.ParseSingle(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024CompositionCostDownEffectExplain = MasterBaseClass.ParseSingle(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null)
																		{
																			_0024var_0024CompositionExpUpEffectValue = MasterBaseClass.ParseSingle(vals[15]);
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null)
																			{
																				_0024var_0024CompositionExpUpEffectExplain = MasterBaseClass.ParseSingle(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null)
																				{
																					_0024var_0024DropUpEffectValue = MasterBaseClass.ParseSingle(vals[17]);
																				}
																				if (length <= 18)
																				{
																					result = 18;
																				}
																				else
																				{
																					if (vals[18] != null)
																					{
																						_0024var_0024DropUpEffectExplain = MasterBaseClass.ParseSingle(vals[18]);
																					}
																					if (length <= 19)
																					{
																						result = 19;
																					}
																					else
																					{
																						if (vals[19] != null)
																						{
																							_0024var_0024GetExpUpEffectValue = MasterBaseClass.ParseSingle(vals[19]);
																						}
																						if (length <= 20)
																						{
																							result = 20;
																						}
																						else
																						{
																							if (vals[20] != null)
																							{
																								_0024var_0024GetExpUpEffectExplain = MasterBaseClass.ParseSingle(vals[20]);
																							}
																							if (length <= 21)
																							{
																								result = 21;
																							}
																							else
																							{
																								if (vals[21] != null)
																								{
																									_0024var_0024TargetStoryIds = vals[21];
																								}
																								if (length <= 22)
																								{
																									result = 22;
																								}
																								else
																								{
																									if (vals[22] != null)
																									{
																										_0024var_0024ExcludeStoryIds = vals[22];
																									}
																									if (length <= 23)
																									{
																										result = 23;
																									}
																									else
																									{
																										if (vals[23] != null)
																										{
																											_0024var_0024IsDuplicate = MasterBaseClass.ParseBool(vals[23]);
																										}
																										if (length <= 24)
																										{
																											result = 24;
																										}
																										else
																										{
																											if (vals[24] != null)
																											{
																												_0024var_0024Priority = MasterBaseClass.ParseInt(vals[24]);
																											}
																											if (length <= 25)
																											{
																												result = 25;
																											}
																											else
																											{
																												if (vals[25] != null && typeof(EnumCampaignSegmentTypes).IsEnum)
																												{
																													_0024var_0024SegmentTypeValue = (EnumCampaignSegmentTypes)MasterBaseClass.ParseEnum(vals[25]);
																												}
																												int num = 26;
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
						}
					}
				}
			}
		}
		return result;
	}
}
