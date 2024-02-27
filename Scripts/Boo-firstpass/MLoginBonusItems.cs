using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MLoginBonusItems : MerlinMaster
{
	[Serializable]
	public class Item
	{
		public EnumMasterTypeValues ItemType;

		public int ItemId;

		public int Quantity;

		public Item(EnumMasterTypeValues type, int id, int q)
		{
			ItemType = type;
			ItemId = id;
			Quantity = q;
		}
	}

	public int _0024var_0024Id;

	public int _0024var_0024BonusId;

	public int _0024var_0024Num;

	public EnumMasterTypeValues _0024var_0024ItemType1;

	public int _0024var_0024ItemId1;

	public int _0024var_0024Quantity1;

	public EnumMasterTypeValues _0024var_0024ItemType2;

	public int _0024var_0024ItemId2;

	public int _0024var_0024Quantity2;

	public EnumMasterTypeValues _0024var_0024ItemType3;

	public int _0024var_0024ItemId3;

	public int _0024var_0024Quantity3;

	public EnumMasterTypeValues _0024var_0024ItemType4;

	public int _0024var_0024ItemId4;

	public int _0024var_0024Quantity4;

	public EnumMasterTypeValues _0024var_0024ItemType5;

	public int _0024var_0024ItemId5;

	public int _0024var_0024Quantity5;

	public EnumMasterTypeValues _0024var_0024ItemType6;

	public int _0024var_0024ItemId6;

	public int _0024var_0024Quantity6;

	public EnumMasterTypeValues _0024var_0024ItemType7;

	public int _0024var_0024ItemId7;

	public int _0024var_0024Quantity7;

	public EnumMasterTypeValues _0024var_0024ItemType8;

	public int _0024var_0024ItemId8;

	public int _0024var_0024Quantity8;

	public EnumMasterTypeValues _0024var_0024ItemType9;

	public int _0024var_0024ItemId9;

	public int _0024var_0024Quantity9;

	public EnumMasterTypeValues _0024var_0024ItemType10;

	public int _0024var_0024ItemId10;

	public int _0024var_0024Quantity10;

	[NonSerialized]
	private static Dictionary<int, MLoginBonusItems> _0024mst_0024102 = new Dictionary<int, MLoginBonusItems>();

	[NonSerialized]
	private static MLoginBonusItems[] All_cache;

	public EnumMasterTypeValues ItemType => ItemType1;

	public int ItemId => ItemId1;

	public int Quantity => Quantity1;

	public Item[] AllItems
	{
		get
		{
			System.Collections.Generic.List<Item> list = new System.Collections.Generic.List<Item>();
			if (ItemType1 != 0)
			{
				list.Add(new Item(ItemType1, ItemId1, Quantity1));
			}
			if (ItemType2 != 0)
			{
				list.Add(new Item(ItemType2, ItemId2, Quantity2));
			}
			if (ItemType3 != 0)
			{
				list.Add(new Item(ItemType3, ItemId3, Quantity3));
			}
			if (ItemType4 != 0)
			{
				list.Add(new Item(ItemType4, ItemId4, Quantity4));
			}
			if (ItemType5 != 0)
			{
				list.Add(new Item(ItemType5, ItemId5, Quantity5));
			}
			if (ItemType6 != 0)
			{
				list.Add(new Item(ItemType6, ItemId6, Quantity6));
			}
			if (ItemType7 != 0)
			{
				list.Add(new Item(ItemType7, ItemId7, Quantity7));
			}
			if (ItemType8 != 0)
			{
				list.Add(new Item(ItemType8, ItemId8, Quantity8));
			}
			if (ItemType9 != 0)
			{
				list.Add(new Item(ItemType9, ItemId9, Quantity9));
			}
			if (ItemType10 != 0)
			{
				list.Add(new Item(ItemType10, ItemId10, Quantity10));
			}
			return (Item[])Builtins.array(typeof(Item), list);
		}
	}

	public int Id => _0024var_0024Id;

	public int BonusId => _0024var_0024BonusId;

	public int Num => _0024var_0024Num;

	public EnumMasterTypeValues ItemType1 => _0024var_0024ItemType1;

	public int ItemId1 => _0024var_0024ItemId1;

	public int Quantity1 => _0024var_0024Quantity1;

	public EnumMasterTypeValues ItemType2 => _0024var_0024ItemType2;

	public int ItemId2 => _0024var_0024ItemId2;

	public int Quantity2 => _0024var_0024Quantity2;

	public EnumMasterTypeValues ItemType3 => _0024var_0024ItemType3;

	public int ItemId3 => _0024var_0024ItemId3;

	public int Quantity3 => _0024var_0024Quantity3;

	public EnumMasterTypeValues ItemType4 => _0024var_0024ItemType4;

	public int ItemId4 => _0024var_0024ItemId4;

	public int Quantity4 => _0024var_0024Quantity4;

	public EnumMasterTypeValues ItemType5 => _0024var_0024ItemType5;

	public int ItemId5 => _0024var_0024ItemId5;

	public int Quantity5 => _0024var_0024Quantity5;

	public EnumMasterTypeValues ItemType6 => _0024var_0024ItemType6;

	public int ItemId6 => _0024var_0024ItemId6;

	public int Quantity6 => _0024var_0024Quantity6;

	public EnumMasterTypeValues ItemType7 => _0024var_0024ItemType7;

	public int ItemId7 => _0024var_0024ItemId7;

	public int Quantity7 => _0024var_0024Quantity7;

	public EnumMasterTypeValues ItemType8 => _0024var_0024ItemType8;

	public int ItemId8 => _0024var_0024ItemId8;

	public int Quantity8 => _0024var_0024Quantity8;

	public EnumMasterTypeValues ItemType9 => _0024var_0024ItemType9;

	public int ItemId9 => _0024var_0024ItemId9;

	public int Quantity9 => _0024var_0024Quantity9;

	public EnumMasterTypeValues ItemType10 => _0024var_0024ItemType10;

	public int ItemId10 => _0024var_0024ItemId10;

	public int Quantity10 => _0024var_0024Quantity10;

	public static MLoginBonusItems[] All
	{
		get
		{
			MLoginBonusItems[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MLoginBonusItems");
				MLoginBonusItems[] array = (MLoginBonusItems[])Builtins.array(typeof(MLoginBonusItems), _0024mst_0024102.Values);
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

	public MLoginBonusItems()
	{
		_0024var_0024ItemType1 = EnumMasterTypeValues.None;
		_0024var_0024ItemType2 = EnumMasterTypeValues.None;
		_0024var_0024ItemType3 = EnumMasterTypeValues.None;
		_0024var_0024ItemType4 = EnumMasterTypeValues.None;
		_0024var_0024ItemType5 = EnumMasterTypeValues.None;
		_0024var_0024ItemType6 = EnumMasterTypeValues.None;
		_0024var_0024ItemType7 = EnumMasterTypeValues.None;
		_0024var_0024ItemType8 = EnumMasterTypeValues.None;
		_0024var_0024ItemType9 = EnumMasterTypeValues.None;
		_0024var_0024ItemType10 = EnumMasterTypeValues.None;
	}

	public override string ToString()
	{
		return new StringBuilder("MLoginBonusItems(").Append((object)Id).Append(")").ToString();
	}

	public static MLoginBonusItems Get(int _id)
	{
		MerlinMaster.GetHandler("MLoginBonusItems");
		return (!_0024mst_0024102.ContainsKey(_id)) ? null : _0024mst_0024102[_id];
	}

	public static void Unload()
	{
		_0024mst_0024102.Clear();
		All_cache = null;
	}

	public static MLoginBonusItems New(Hashtable data)
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
			MLoginBonusItems mLoginBonusItems = Create(data);
			if (!_0024mst_0024102.ContainsKey(mLoginBonusItems.Id))
			{
				_0024mst_0024102[mLoginBonusItems.Id] = mLoginBonusItems;
			}
			result = mLoginBonusItems;
		}
		return (MLoginBonusItems)result;
	}

	public static MLoginBonusItems New2(string[] keys, object[] vals)
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
		return (MLoginBonusItems)result;
	}

	public static MLoginBonusItems Entry(MLoginBonusItems mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024102[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MLoginBonusItems)result;
	}

	public static void AddMst(MLoginBonusItems mst)
	{
		if (mst != null)
		{
			_0024mst_0024102[mst.Id] = mst;
		}
	}

	public static MLoginBonusItems Create(Hashtable data)
	{
		MLoginBonusItems mLoginBonusItems = new MLoginBonusItems();
		MLoginBonusItems result;
		if (data == null)
		{
			result = mLoginBonusItems;
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
				mLoginBonusItems.setField((string)obj, data[current]);
			}
			result = mLoginBonusItems;
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
		case "BonusId":
			_0024var_0024BonusId = MasterBaseClass.ToInt(val);
			break;
		case "Num":
			_0024var_0024Num = MasterBaseClass.ToInt(val);
			break;
		case "ItemType1":
			if (typeof(EnumMasterTypeValues).IsEnum)
			{
				_0024var_0024ItemType1 = (EnumMasterTypeValues)MasterBaseClass.ToEnum(val);
			}
			break;
		case "ItemId1":
			_0024var_0024ItemId1 = MasterBaseClass.ToInt(val);
			break;
		case "Quantity1":
			_0024var_0024Quantity1 = MasterBaseClass.ToInt(val);
			break;
		case "ItemType2":
			if (typeof(EnumMasterTypeValues).IsEnum)
			{
				_0024var_0024ItemType2 = (EnumMasterTypeValues)MasterBaseClass.ToEnum(val);
			}
			break;
		case "ItemId2":
			_0024var_0024ItemId2 = MasterBaseClass.ToInt(val);
			break;
		case "Quantity2":
			_0024var_0024Quantity2 = MasterBaseClass.ToInt(val);
			break;
		case "ItemType3":
			if (typeof(EnumMasterTypeValues).IsEnum)
			{
				_0024var_0024ItemType3 = (EnumMasterTypeValues)MasterBaseClass.ToEnum(val);
			}
			break;
		case "ItemId3":
			_0024var_0024ItemId3 = MasterBaseClass.ToInt(val);
			break;
		case "Quantity3":
			_0024var_0024Quantity3 = MasterBaseClass.ToInt(val);
			break;
		case "ItemType4":
			if (typeof(EnumMasterTypeValues).IsEnum)
			{
				_0024var_0024ItemType4 = (EnumMasterTypeValues)MasterBaseClass.ToEnum(val);
			}
			break;
		case "ItemId4":
			_0024var_0024ItemId4 = MasterBaseClass.ToInt(val);
			break;
		case "Quantity4":
			_0024var_0024Quantity4 = MasterBaseClass.ToInt(val);
			break;
		case "ItemType5":
			if (typeof(EnumMasterTypeValues).IsEnum)
			{
				_0024var_0024ItemType5 = (EnumMasterTypeValues)MasterBaseClass.ToEnum(val);
			}
			break;
		case "ItemId5":
			_0024var_0024ItemId5 = MasterBaseClass.ToInt(val);
			break;
		case "Quantity5":
			_0024var_0024Quantity5 = MasterBaseClass.ToInt(val);
			break;
		case "ItemType6":
			if (typeof(EnumMasterTypeValues).IsEnum)
			{
				_0024var_0024ItemType6 = (EnumMasterTypeValues)MasterBaseClass.ToEnum(val);
			}
			break;
		case "ItemId6":
			_0024var_0024ItemId6 = MasterBaseClass.ToInt(val);
			break;
		case "Quantity6":
			_0024var_0024Quantity6 = MasterBaseClass.ToInt(val);
			break;
		case "ItemType7":
			if (typeof(EnumMasterTypeValues).IsEnum)
			{
				_0024var_0024ItemType7 = (EnumMasterTypeValues)MasterBaseClass.ToEnum(val);
			}
			break;
		case "ItemId7":
			_0024var_0024ItemId7 = MasterBaseClass.ToInt(val);
			break;
		case "Quantity7":
			_0024var_0024Quantity7 = MasterBaseClass.ToInt(val);
			break;
		case "ItemType8":
			if (typeof(EnumMasterTypeValues).IsEnum)
			{
				_0024var_0024ItemType8 = (EnumMasterTypeValues)MasterBaseClass.ToEnum(val);
			}
			break;
		case "ItemId8":
			_0024var_0024ItemId8 = MasterBaseClass.ToInt(val);
			break;
		case "Quantity8":
			_0024var_0024Quantity8 = MasterBaseClass.ToInt(val);
			break;
		case "ItemType9":
			if (typeof(EnumMasterTypeValues).IsEnum)
			{
				_0024var_0024ItemType9 = (EnumMasterTypeValues)MasterBaseClass.ToEnum(val);
			}
			break;
		case "ItemId9":
			_0024var_0024ItemId9 = MasterBaseClass.ToInt(val);
			break;
		case "Quantity9":
			_0024var_0024Quantity9 = MasterBaseClass.ToInt(val);
			break;
		case "ItemType10":
			if (typeof(EnumMasterTypeValues).IsEnum)
			{
				_0024var_0024ItemType10 = (EnumMasterTypeValues)MasterBaseClass.ToEnum(val);
			}
			break;
		case "ItemId10":
			_0024var_0024ItemId10 = MasterBaseClass.ToInt(val);
			break;
		case "Quantity10":
			_0024var_0024Quantity10 = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"BonusId" => true, 
			"Num" => true, 
			"ItemType1" => true, 
			"ItemId1" => true, 
			"Quantity1" => true, 
			"ItemType2" => true, 
			"ItemId2" => true, 
			"Quantity2" => true, 
			"ItemType3" => true, 
			"ItemId3" => true, 
			"Quantity3" => true, 
			"ItemType4" => true, 
			"ItemId4" => true, 
			"Quantity4" => true, 
			"ItemType5" => true, 
			"ItemId5" => true, 
			"Quantity5" => true, 
			"ItemType6" => true, 
			"ItemId6" => true, 
			"Quantity6" => true, 
			"ItemType7" => true, 
			"ItemId7" => true, 
			"Quantity7" => true, 
			"ItemType8" => true, 
			"ItemId8" => true, 
			"Quantity8" => true, 
			"ItemType9" => true, 
			"ItemId9" => true, 
			"Quantity9" => true, 
			"ItemType10" => true, 
			"ItemId10" => true, 
			"Quantity10" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[33]
		{
			"Id", "BonusId", "Num", "ItemType1", "ItemId1", "Quantity1", "ItemType2", "ItemId2", "Quantity2", "ItemType3",
			"ItemId3", "Quantity3", "ItemType4", "ItemId4", "Quantity4", "ItemType5", "ItemId5", "Quantity5", "ItemType6", "ItemId6",
			"Quantity6", "ItemType7", "ItemId7", "Quantity7", "ItemType8", "ItemId8", "Quantity8", "ItemType9", "ItemId9", "Quantity9",
			"ItemType10", "ItemId10", "Quantity10"
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
					_0024var_0024BonusId = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024Num = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null && typeof(EnumMasterTypeValues).IsEnum)
						{
							_0024var_0024ItemType1 = (EnumMasterTypeValues)MasterBaseClass.ParseEnum(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024ItemId1 = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Quantity1 = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null && typeof(EnumMasterTypeValues).IsEnum)
									{
										_0024var_0024ItemType2 = (EnumMasterTypeValues)MasterBaseClass.ParseEnum(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024ItemId2 = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024Quantity2 = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null && typeof(EnumMasterTypeValues).IsEnum)
												{
													_0024var_0024ItemType3 = (EnumMasterTypeValues)MasterBaseClass.ParseEnum(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024ItemId3 = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024Quantity3 = MasterBaseClass.ParseInt(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null && typeof(EnumMasterTypeValues).IsEnum)
															{
																_0024var_0024ItemType4 = (EnumMasterTypeValues)MasterBaseClass.ParseEnum(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024ItemId4 = MasterBaseClass.ParseInt(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024Quantity4 = MasterBaseClass.ParseInt(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null && typeof(EnumMasterTypeValues).IsEnum)
																		{
																			_0024var_0024ItemType5 = (EnumMasterTypeValues)MasterBaseClass.ParseEnum(vals[15]);
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null)
																			{
																				_0024var_0024ItemId5 = MasterBaseClass.ParseInt(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null)
																				{
																					_0024var_0024Quantity5 = MasterBaseClass.ParseInt(vals[17]);
																				}
																				if (length <= 18)
																				{
																					result = 18;
																				}
																				else
																				{
																					if (vals[18] != null && typeof(EnumMasterTypeValues).IsEnum)
																					{
																						_0024var_0024ItemType6 = (EnumMasterTypeValues)MasterBaseClass.ParseEnum(vals[18]);
																					}
																					if (length <= 19)
																					{
																						result = 19;
																					}
																					else
																					{
																						if (vals[19] != null)
																						{
																							_0024var_0024ItemId6 = MasterBaseClass.ParseInt(vals[19]);
																						}
																						if (length <= 20)
																						{
																							result = 20;
																						}
																						else
																						{
																							if (vals[20] != null)
																							{
																								_0024var_0024Quantity6 = MasterBaseClass.ParseInt(vals[20]);
																							}
																							if (length <= 21)
																							{
																								result = 21;
																							}
																							else
																							{
																								if (vals[21] != null && typeof(EnumMasterTypeValues).IsEnum)
																								{
																									_0024var_0024ItemType7 = (EnumMasterTypeValues)MasterBaseClass.ParseEnum(vals[21]);
																								}
																								if (length <= 22)
																								{
																									result = 22;
																								}
																								else
																								{
																									if (vals[22] != null)
																									{
																										_0024var_0024ItemId7 = MasterBaseClass.ParseInt(vals[22]);
																									}
																									if (length <= 23)
																									{
																										result = 23;
																									}
																									else
																									{
																										if (vals[23] != null)
																										{
																											_0024var_0024Quantity7 = MasterBaseClass.ParseInt(vals[23]);
																										}
																										if (length <= 24)
																										{
																											result = 24;
																										}
																										else
																										{
																											if (vals[24] != null && typeof(EnumMasterTypeValues).IsEnum)
																											{
																												_0024var_0024ItemType8 = (EnumMasterTypeValues)MasterBaseClass.ParseEnum(vals[24]);
																											}
																											if (length <= 25)
																											{
																												result = 25;
																											}
																											else
																											{
																												if (vals[25] != null)
																												{
																													_0024var_0024ItemId8 = MasterBaseClass.ParseInt(vals[25]);
																												}
																												if (length <= 26)
																												{
																													result = 26;
																												}
																												else
																												{
																													if (vals[26] != null)
																													{
																														_0024var_0024Quantity8 = MasterBaseClass.ParseInt(vals[26]);
																													}
																													if (length <= 27)
																													{
																														result = 27;
																													}
																													else
																													{
																														if (vals[27] != null && typeof(EnumMasterTypeValues).IsEnum)
																														{
																															_0024var_0024ItemType9 = (EnumMasterTypeValues)MasterBaseClass.ParseEnum(vals[27]);
																														}
																														if (length <= 28)
																														{
																															result = 28;
																														}
																														else
																														{
																															if (vals[28] != null)
																															{
																																_0024var_0024ItemId9 = MasterBaseClass.ParseInt(vals[28]);
																															}
																															if (length <= 29)
																															{
																																result = 29;
																															}
																															else
																															{
																																if (vals[29] != null)
																																{
																																	_0024var_0024Quantity9 = MasterBaseClass.ParseInt(vals[29]);
																																}
																																if (length <= 30)
																																{
																																	result = 30;
																																}
																																else
																																{
																																	if (vals[30] != null && typeof(EnumMasterTypeValues).IsEnum)
																																	{
																																		_0024var_0024ItemType10 = (EnumMasterTypeValues)MasterBaseClass.ParseEnum(vals[30]);
																																	}
																																	if (length <= 31)
																																	{
																																		result = 31;
																																	}
																																	else
																																	{
																																		if (vals[31] != null)
																																		{
																																			_0024var_0024ItemId10 = MasterBaseClass.ParseInt(vals[31]);
																																		}
																																		if (length <= 32)
																																		{
																																			result = 32;
																																		}
																																		else
																																		{
																																			if (vals[32] != null)
																																			{
																																				_0024var_0024Quantity10 = MasterBaseClass.ParseInt(vals[32]);
																																			}
																																			int num = 33;
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
