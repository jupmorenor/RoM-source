using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MSaleGachas : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MGachaId;

	public EnumSaleTypeValues _0024var_0024SaleTypeValue;

	public string _0024var_0024Name;

	public string _0024var_0024Description;

	public int _0024var_0024Price;

	public DateTime _0024var_0024StartDate;

	public DateTime _0024var_0024EndDate;

	public int _0024var_0024Sort;

	public int _0024var_0024MSaleGachaGroupId;

	public int _0024var_0024Step;

	public EnumStepGachaTypes _0024var_0024SaleGachaTypeIs;

	public bool _0024var_0024IsFirstOfStepUnLimited;

	public bool _0024var_0024IsFixedTurn;

	public int _0024var_0024FixedTurn;

	public bool _0024var_0024IsFixedPrice;

	public int _0024var_0024FixedPrice;

	public bool _0024var_0024IsSrEmission;

	public int _0024var_0024SrEmission;

	public EnumGachaTypesForClient _0024var_0024TypeForClient;

	public bool _0024var_0024IsFixedEmission;

	public int _0024var_0024FixedEmission;

	public bool _0024var_0024IsAppendix;

	public int _0024var_0024Appendix;

	public int _0024var_0024MPointId;

	public string _0024var_0024PointNumValues;

	[NonSerialized]
	private MGachas MGachaId__cache;

	[NonSerialized]
	private MSaleGachaGroups MSaleGachaGroupId__cache;

	[NonSerialized]
	private MPoints MPointId__cache;

	[NonSerialized]
	private static Dictionary<int, MSaleGachas> _0024mst_002452 = new Dictionary<int, MSaleGachas>();

	[NonSerialized]
	private static MSaleGachas[] All_cache;

	public int Id => _0024var_0024Id;

	public MGachas MGachaId
	{
		get
		{
			if (MGachaId__cache == null)
			{
				MGachaId__cache = MGachas.Get(_0024var_0024MGachaId);
			}
			return MGachaId__cache;
		}
	}

	public EnumSaleTypeValues SaleTypeValue => _0024var_0024SaleTypeValue;

	public string Name => _0024var_0024Name;

	public string Description => _0024var_0024Description;

	public int Price => _0024var_0024Price;

	public DateTime StartDate => _0024var_0024StartDate;

	public DateTime EndDate => _0024var_0024EndDate;

	public int Sort => _0024var_0024Sort;

	public MSaleGachaGroups MSaleGachaGroupId
	{
		get
		{
			if (MSaleGachaGroupId__cache == null)
			{
				MSaleGachaGroupId__cache = MSaleGachaGroups.Get(_0024var_0024MSaleGachaGroupId);
			}
			return MSaleGachaGroupId__cache;
		}
	}

	public int Step => _0024var_0024Step;

	public EnumStepGachaTypes SaleGachaTypeIs => _0024var_0024SaleGachaTypeIs;

	public bool IsFirstOfStepUnLimited => _0024var_0024IsFirstOfStepUnLimited;

	public bool IsFixedTurn => _0024var_0024IsFixedTurn;

	public int FixedTurn => _0024var_0024FixedTurn;

	public bool IsFixedPrice => _0024var_0024IsFixedPrice;

	public int FixedPrice => _0024var_0024FixedPrice;

	public bool IsSrEmission => _0024var_0024IsSrEmission;

	public int SrEmission => _0024var_0024SrEmission;

	public EnumGachaTypesForClient TypeForClient => _0024var_0024TypeForClient;

	public bool IsFixedEmission => _0024var_0024IsFixedEmission;

	public int FixedEmission => _0024var_0024FixedEmission;

	public bool IsAppendix => _0024var_0024IsAppendix;

	public int Appendix => _0024var_0024Appendix;

	public MPoints MPointId
	{
		get
		{
			if (MPointId__cache == null)
			{
				MPointId__cache = MPoints.Get(_0024var_0024MPointId);
			}
			return MPointId__cache;
		}
	}

	public string PointNumValues => _0024var_0024PointNumValues;

	public static MSaleGachas[] All
	{
		get
		{
			MSaleGachas[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MSaleGachas");
				MSaleGachas[] array = (MSaleGachas[])Builtins.array(typeof(MSaleGachas), _0024mst_002452.Values);
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

	public MSaleGachas()
	{
		_0024var_0024StartDate = DateTime.Parse("2001/01/01");
		_0024var_0024EndDate = DateTime.Parse("2099/01/01");
		_0024var_0024Step = 1;
		_0024var_0024SaleGachaTypeIs = EnumStepGachaTypes.NO_STEP;
		_0024var_0024PointNumValues = string.Empty;
	}

	public void GetPriceAndTurn(ref int price, ref int turn)
	{
		turn = 1;
		if (IsFixedTurn)
		{
			turn = FixedTurn;
		}
		price = checked(Price * turn);
		if (IsFixedPrice)
		{
			price = FixedPrice;
		}
	}

	public override string ToString()
	{
		return new StringBuilder("MGachas(").Append((object)Id).Append(",").Append(MGachaId)
			.Append(",")
			.Append(SaleTypeValue)
			.Append(",")
			.Append(Name)
			.Append(",")
			.Append(Description)
			.Append(",")
			.Append((object)Price)
			.Append(")")
			.ToString();
	}

	public static MSaleGachas Get(int _id)
	{
		MerlinMaster.GetHandler("MSaleGachas");
		return (!_0024mst_002452.ContainsKey(_id)) ? null : _0024mst_002452[_id];
	}

	public static void Unload()
	{
		_0024mst_002452.Clear();
		All_cache = null;
	}

	public static MSaleGachas New(Hashtable data)
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
			MSaleGachas mSaleGachas = Create(data);
			if (!_0024mst_002452.ContainsKey(mSaleGachas.Id))
			{
				_0024mst_002452[mSaleGachas.Id] = mSaleGachas;
			}
			result = mSaleGachas;
		}
		return (MSaleGachas)result;
	}

	public static MSaleGachas New2(string[] keys, object[] vals)
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
		return (MSaleGachas)result;
	}

	public static MSaleGachas Entry(MSaleGachas mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002452[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MSaleGachas)result;
	}

	public static void AddMst(MSaleGachas mst)
	{
		if (mst != null)
		{
			_0024mst_002452[mst.Id] = mst;
		}
	}

	public static MSaleGachas Create(Hashtable data)
	{
		MSaleGachas mSaleGachas = new MSaleGachas();
		MSaleGachas result;
		if (data == null)
		{
			result = mSaleGachas;
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
				mSaleGachas.setField((string)obj, data[current]);
			}
			result = mSaleGachas;
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
		case "MGachaId":
			_0024var_0024MGachaId = MasterBaseClass.ToInt(val);
			break;
		case "SaleTypeValue":
			if (typeof(EnumSaleTypeValues).IsEnum)
			{
				_0024var_0024SaleTypeValue = (EnumSaleTypeValues)MasterBaseClass.ToEnum(val);
			}
			break;
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		case "Description":
			_0024var_0024Description = MasterBaseClass.ToStringValue(val);
			break;
		case "Price":
			_0024var_0024Price = MasterBaseClass.ToInt(val);
			break;
		case "StartDate":
		{
			object obj2 = val;
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			_0024var_0024StartDate = DateTime.Parse((string)obj2);
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
		case "Sort":
			_0024var_0024Sort = MasterBaseClass.ToInt(val);
			break;
		case "MSaleGachaGroupId":
			_0024var_0024MSaleGachaGroupId = MasterBaseClass.ToInt(val);
			break;
		case "Step":
			_0024var_0024Step = MasterBaseClass.ToInt(val);
			break;
		case "SaleGachaTypeIs":
			if (typeof(EnumStepGachaTypes).IsEnum)
			{
				_0024var_0024SaleGachaTypeIs = (EnumStepGachaTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "IsFirstOfStepUnLimited":
			_0024var_0024IsFirstOfStepUnLimited = MasterBaseClass.ToBool(val);
			break;
		case "IsFixedTurn":
			_0024var_0024IsFixedTurn = MasterBaseClass.ToBool(val);
			break;
		case "FixedTurn":
			_0024var_0024FixedTurn = MasterBaseClass.ToInt(val);
			break;
		case "IsFixedPrice":
			_0024var_0024IsFixedPrice = MasterBaseClass.ToBool(val);
			break;
		case "FixedPrice":
			_0024var_0024FixedPrice = MasterBaseClass.ToInt(val);
			break;
		case "IsSrEmission":
			_0024var_0024IsSrEmission = MasterBaseClass.ToBool(val);
			break;
		case "SrEmission":
			_0024var_0024SrEmission = MasterBaseClass.ToInt(val);
			break;
		case "TypeForClient":
			if (typeof(EnumGachaTypesForClient).IsEnum)
			{
				_0024var_0024TypeForClient = (EnumGachaTypesForClient)MasterBaseClass.ToEnum(val);
			}
			break;
		case "IsFixedEmission":
			_0024var_0024IsFixedEmission = MasterBaseClass.ToBool(val);
			break;
		case "FixedEmission":
			_0024var_0024FixedEmission = MasterBaseClass.ToInt(val);
			break;
		case "IsAppendix":
			_0024var_0024IsAppendix = MasterBaseClass.ToBool(val);
			break;
		case "Appendix":
			_0024var_0024Appendix = MasterBaseClass.ToInt(val);
			break;
		case "MPointId":
			_0024var_0024MPointId = MasterBaseClass.ToInt(val);
			break;
		case "PointNumValues":
			_0024var_0024PointNumValues = MasterBaseClass.ToStringValue(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"MGachaId" => true, 
			"SaleTypeValue" => true, 
			"Name" => true, 
			"Description" => true, 
			"Price" => true, 
			"StartDate" => true, 
			"EndDate" => true, 
			"Sort" => true, 
			"MSaleGachaGroupId" => true, 
			"Step" => true, 
			"SaleGachaTypeIs" => true, 
			"IsFirstOfStepUnLimited" => true, 
			"IsFixedTurn" => true, 
			"FixedTurn" => true, 
			"IsFixedPrice" => true, 
			"FixedPrice" => true, 
			"IsSrEmission" => true, 
			"SrEmission" => true, 
			"TypeForClient" => true, 
			"IsFixedEmission" => true, 
			"FixedEmission" => true, 
			"IsAppendix" => true, 
			"Appendix" => true, 
			"MPointId" => true, 
			"PointNumValues" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[26]
		{
			"Id", "MGachaId", "SaleTypeValue", "Name", "Description", "Price", "StartDate", "EndDate", "Sort", "MSaleGachaGroupId",
			"Step", "SaleGachaTypeIs", "IsFirstOfStepUnLimited", "IsFixedTurn", "FixedTurn", "IsFixedPrice", "FixedPrice", "IsSrEmission", "SrEmission", "TypeForClient",
			"IsFixedEmission", "FixedEmission", "IsAppendix", "Appendix", "MPointId", "PointNumValues"
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
					_0024var_0024MGachaId = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null && typeof(EnumSaleTypeValues).IsEnum)
					{
						_0024var_0024SaleTypeValue = (EnumSaleTypeValues)MasterBaseClass.ParseEnum(vals[2]);
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
								_0024var_0024Description = vals[4];
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Price = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024StartDate = MasterBaseClass.ParseDateTime(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024EndDate = MasterBaseClass.ParseDateTime(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024Sort = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024MSaleGachaGroupId = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024Step = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null && typeof(EnumStepGachaTypes).IsEnum)
														{
															_0024var_0024SaleGachaTypeIs = (EnumStepGachaTypes)MasterBaseClass.ParseEnum(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024IsFirstOfStepUnLimited = MasterBaseClass.ParseBool(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024IsFixedTurn = MasterBaseClass.ParseBool(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024FixedTurn = MasterBaseClass.ParseInt(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null)
																		{
																			_0024var_0024IsFixedPrice = MasterBaseClass.ParseBool(vals[15]);
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null)
																			{
																				_0024var_0024FixedPrice = MasterBaseClass.ParseInt(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null)
																				{
																					_0024var_0024IsSrEmission = MasterBaseClass.ParseBool(vals[17]);
																				}
																				if (length <= 18)
																				{
																					result = 18;
																				}
																				else
																				{
																					if (vals[18] != null)
																					{
																						_0024var_0024SrEmission = MasterBaseClass.ParseInt(vals[18]);
																					}
																					if (length <= 19)
																					{
																						result = 19;
																					}
																					else
																					{
																						if (vals[19] != null && typeof(EnumGachaTypesForClient).IsEnum)
																						{
																							_0024var_0024TypeForClient = (EnumGachaTypesForClient)MasterBaseClass.ParseEnum(vals[19]);
																						}
																						if (length <= 20)
																						{
																							result = 20;
																						}
																						else
																						{
																							if (vals[20] != null)
																							{
																								_0024var_0024IsFixedEmission = MasterBaseClass.ParseBool(vals[20]);
																							}
																							if (length <= 21)
																							{
																								result = 21;
																							}
																							else
																							{
																								if (vals[21] != null)
																								{
																									_0024var_0024FixedEmission = MasterBaseClass.ParseInt(vals[21]);
																								}
																								if (length <= 22)
																								{
																									result = 22;
																								}
																								else
																								{
																									if (vals[22] != null)
																									{
																										_0024var_0024IsAppendix = MasterBaseClass.ParseBool(vals[22]);
																									}
																									if (length <= 23)
																									{
																										result = 23;
																									}
																									else
																									{
																										if (vals[23] != null)
																										{
																											_0024var_0024Appendix = MasterBaseClass.ParseInt(vals[23]);
																										}
																										if (length <= 24)
																										{
																											result = 24;
																										}
																										else
																										{
																											if (vals[24] != null)
																											{
																												_0024var_0024MPointId = MasterBaseClass.ParseInt(vals[24]);
																											}
																											if (length <= 25)
																											{
																												result = 25;
																											}
																											else
																											{
																												if (vals[25] != null)
																												{
																													_0024var_0024PointNumValues = vals[25];
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
