using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MQuestMonsters : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MQuestId;

	public int _0024var_0024MMonsterId_1;

	public int _0024var_0024MMonsterId_2;

	public int _0024var_0024MMonsterId_3;

	public int _0024var_0024MMonsterId_4;

	public int _0024var_0024MMonsterId_5;

	public int _0024var_0024MMonsterId_6;

	public int _0024var_0024MMonsterId_7;

	public int _0024var_0024MMonsterId_8;

	public int _0024var_0024MMonsterId_9;

	public int _0024var_0024MMonsterId_10;

	public int _0024var_0024MMonsterId_11;

	public int _0024var_0024MMonsterId_12;

	public int _0024var_0024MMonsterId_13;

	public int _0024var_0024MMonsterId_14;

	public int _0024var_0024MMonsterId_15;

	public int _0024var_0024MMonsterId_16;

	[NonSerialized]
	private MMonsters MMonsterId_1__cache;

	[NonSerialized]
	private MMonsters MMonsterId_2__cache;

	[NonSerialized]
	private MMonsters MMonsterId_3__cache;

	[NonSerialized]
	private MMonsters MMonsterId_4__cache;

	[NonSerialized]
	private MMonsters MMonsterId_5__cache;

	[NonSerialized]
	private MMonsters MMonsterId_6__cache;

	[NonSerialized]
	private MMonsters MMonsterId_7__cache;

	[NonSerialized]
	private MMonsters MMonsterId_8__cache;

	[NonSerialized]
	private MMonsters MMonsterId_9__cache;

	[NonSerialized]
	private MMonsters MMonsterId_10__cache;

	[NonSerialized]
	private MMonsters MMonsterId_11__cache;

	[NonSerialized]
	private MMonsters MMonsterId_12__cache;

	[NonSerialized]
	private MMonsters MMonsterId_13__cache;

	[NonSerialized]
	private MMonsters MMonsterId_14__cache;

	[NonSerialized]
	private MMonsters MMonsterId_15__cache;

	[NonSerialized]
	private MMonsters MMonsterId_16__cache;

	[NonSerialized]
	private static Dictionary<int, MQuestMonsters> _0024mst_002490 = new Dictionary<int, MQuestMonsters>();

	[NonSerialized]
	private static MQuestMonsters[] All_cache;

	public MMonsters[] Monsters
	{
		get
		{
			System.Collections.Generic.List<MMonsters> list = new System.Collections.Generic.List<MMonsters>();
			if (MMonsterId_1 != null)
			{
				list.Add(MMonsterId_1);
			}
			if (MMonsterId_2 != null)
			{
				list.Add(MMonsterId_2);
			}
			if (MMonsterId_3 != null)
			{
				list.Add(MMonsterId_3);
			}
			if (MMonsterId_4 != null)
			{
				list.Add(MMonsterId_4);
			}
			if (MMonsterId_5 != null)
			{
				list.Add(MMonsterId_5);
			}
			if (MMonsterId_6 != null)
			{
				list.Add(MMonsterId_6);
			}
			if (MMonsterId_7 != null)
			{
				list.Add(MMonsterId_7);
			}
			if (MMonsterId_8 != null)
			{
				list.Add(MMonsterId_8);
			}
			if (MMonsterId_9 != null)
			{
				list.Add(MMonsterId_9);
			}
			if (MMonsterId_10 != null)
			{
				list.Add(MMonsterId_10);
			}
			if (MMonsterId_11 != null)
			{
				list.Add(MMonsterId_11);
			}
			if (MMonsterId_12 != null)
			{
				list.Add(MMonsterId_12);
			}
			if (MMonsterId_13 != null)
			{
				list.Add(MMonsterId_13);
			}
			if (MMonsterId_14 != null)
			{
				list.Add(MMonsterId_14);
			}
			if (MMonsterId_15 != null)
			{
				list.Add(MMonsterId_15);
			}
			if (MMonsterId_16 != null)
			{
				list.Add(MMonsterId_16);
			}
			return list.ToArray();
		}
	}

	public int Id => _0024var_0024Id;

	public int MQuestId => _0024var_0024MQuestId;

	public MMonsters MMonsterId_1
	{
		get
		{
			if (MMonsterId_1__cache == null)
			{
				MMonsterId_1__cache = MMonsters.Get(_0024var_0024MMonsterId_1);
			}
			return MMonsterId_1__cache;
		}
	}

	public MMonsters MMonsterId_2
	{
		get
		{
			if (MMonsterId_2__cache == null)
			{
				MMonsterId_2__cache = MMonsters.Get(_0024var_0024MMonsterId_2);
			}
			return MMonsterId_2__cache;
		}
	}

	public MMonsters MMonsterId_3
	{
		get
		{
			if (MMonsterId_3__cache == null)
			{
				MMonsterId_3__cache = MMonsters.Get(_0024var_0024MMonsterId_3);
			}
			return MMonsterId_3__cache;
		}
	}

	public MMonsters MMonsterId_4
	{
		get
		{
			if (MMonsterId_4__cache == null)
			{
				MMonsterId_4__cache = MMonsters.Get(_0024var_0024MMonsterId_4);
			}
			return MMonsterId_4__cache;
		}
	}

	public MMonsters MMonsterId_5
	{
		get
		{
			if (MMonsterId_5__cache == null)
			{
				MMonsterId_5__cache = MMonsters.Get(_0024var_0024MMonsterId_5);
			}
			return MMonsterId_5__cache;
		}
	}

	public MMonsters MMonsterId_6
	{
		get
		{
			if (MMonsterId_6__cache == null)
			{
				MMonsterId_6__cache = MMonsters.Get(_0024var_0024MMonsterId_6);
			}
			return MMonsterId_6__cache;
		}
	}

	public MMonsters MMonsterId_7
	{
		get
		{
			if (MMonsterId_7__cache == null)
			{
				MMonsterId_7__cache = MMonsters.Get(_0024var_0024MMonsterId_7);
			}
			return MMonsterId_7__cache;
		}
	}

	public MMonsters MMonsterId_8
	{
		get
		{
			if (MMonsterId_8__cache == null)
			{
				MMonsterId_8__cache = MMonsters.Get(_0024var_0024MMonsterId_8);
			}
			return MMonsterId_8__cache;
		}
	}

	public MMonsters MMonsterId_9
	{
		get
		{
			if (MMonsterId_9__cache == null)
			{
				MMonsterId_9__cache = MMonsters.Get(_0024var_0024MMonsterId_9);
			}
			return MMonsterId_9__cache;
		}
	}

	public MMonsters MMonsterId_10
	{
		get
		{
			if (MMonsterId_10__cache == null)
			{
				MMonsterId_10__cache = MMonsters.Get(_0024var_0024MMonsterId_10);
			}
			return MMonsterId_10__cache;
		}
	}

	public MMonsters MMonsterId_11
	{
		get
		{
			if (MMonsterId_11__cache == null)
			{
				MMonsterId_11__cache = MMonsters.Get(_0024var_0024MMonsterId_11);
			}
			return MMonsterId_11__cache;
		}
	}

	public MMonsters MMonsterId_12
	{
		get
		{
			if (MMonsterId_12__cache == null)
			{
				MMonsterId_12__cache = MMonsters.Get(_0024var_0024MMonsterId_12);
			}
			return MMonsterId_12__cache;
		}
	}

	public MMonsters MMonsterId_13
	{
		get
		{
			if (MMonsterId_13__cache == null)
			{
				MMonsterId_13__cache = MMonsters.Get(_0024var_0024MMonsterId_13);
			}
			return MMonsterId_13__cache;
		}
	}

	public MMonsters MMonsterId_14
	{
		get
		{
			if (MMonsterId_14__cache == null)
			{
				MMonsterId_14__cache = MMonsters.Get(_0024var_0024MMonsterId_14);
			}
			return MMonsterId_14__cache;
		}
	}

	public MMonsters MMonsterId_15
	{
		get
		{
			if (MMonsterId_15__cache == null)
			{
				MMonsterId_15__cache = MMonsters.Get(_0024var_0024MMonsterId_15);
			}
			return MMonsterId_15__cache;
		}
	}

	public MMonsters MMonsterId_16
	{
		get
		{
			if (MMonsterId_16__cache == null)
			{
				MMonsterId_16__cache = MMonsters.Get(_0024var_0024MMonsterId_16);
			}
			return MMonsterId_16__cache;
		}
	}

	public static MQuestMonsters[] All
	{
		get
		{
			MQuestMonsters[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MQuestMonsters");
				MQuestMonsters[] array = (MQuestMonsters[])Builtins.array(typeof(MQuestMonsters), _0024mst_002490.Values);
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

	public static MQuestMonsters Get(int _id)
	{
		MerlinMaster.GetHandler("MQuestMonsters");
		return (!_0024mst_002490.ContainsKey(_id)) ? null : _0024mst_002490[_id];
	}

	public static void Unload()
	{
		_0024mst_002490.Clear();
		All_cache = null;
	}

	public static MQuestMonsters New(Hashtable data)
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
			MQuestMonsters mQuestMonsters = Create(data);
			if (!_0024mst_002490.ContainsKey(mQuestMonsters.Id))
			{
				_0024mst_002490[mQuestMonsters.Id] = mQuestMonsters;
			}
			result = mQuestMonsters;
		}
		return (MQuestMonsters)result;
	}

	public static MQuestMonsters New2(string[] keys, object[] vals)
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
		return (MQuestMonsters)result;
	}

	public static MQuestMonsters Entry(MQuestMonsters mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002490[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MQuestMonsters)result;
	}

	public static void AddMst(MQuestMonsters mst)
	{
		if (mst != null)
		{
			_0024mst_002490[mst.Id] = mst;
		}
	}

	public static MQuestMonsters Create(Hashtable data)
	{
		MQuestMonsters mQuestMonsters = new MQuestMonsters();
		MQuestMonsters result;
		if (data == null)
		{
			result = mQuestMonsters;
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
				mQuestMonsters.setField((string)obj, data[current]);
			}
			result = mQuestMonsters;
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
		case "MQuestId":
			_0024var_0024MQuestId = MasterBaseClass.ToInt(val);
			break;
		case "MMonsterId_1":
			_0024var_0024MMonsterId_1 = MasterBaseClass.ToInt(val);
			break;
		case "MMonsterId_2":
			_0024var_0024MMonsterId_2 = MasterBaseClass.ToInt(val);
			break;
		case "MMonsterId_3":
			_0024var_0024MMonsterId_3 = MasterBaseClass.ToInt(val);
			break;
		case "MMonsterId_4":
			_0024var_0024MMonsterId_4 = MasterBaseClass.ToInt(val);
			break;
		case "MMonsterId_5":
			_0024var_0024MMonsterId_5 = MasterBaseClass.ToInt(val);
			break;
		case "MMonsterId_6":
			_0024var_0024MMonsterId_6 = MasterBaseClass.ToInt(val);
			break;
		case "MMonsterId_7":
			_0024var_0024MMonsterId_7 = MasterBaseClass.ToInt(val);
			break;
		case "MMonsterId_8":
			_0024var_0024MMonsterId_8 = MasterBaseClass.ToInt(val);
			break;
		case "MMonsterId_9":
			_0024var_0024MMonsterId_9 = MasterBaseClass.ToInt(val);
			break;
		case "MMonsterId_10":
			_0024var_0024MMonsterId_10 = MasterBaseClass.ToInt(val);
			break;
		case "MMonsterId_11":
			_0024var_0024MMonsterId_11 = MasterBaseClass.ToInt(val);
			break;
		case "MMonsterId_12":
			_0024var_0024MMonsterId_12 = MasterBaseClass.ToInt(val);
			break;
		case "MMonsterId_13":
			_0024var_0024MMonsterId_13 = MasterBaseClass.ToInt(val);
			break;
		case "MMonsterId_14":
			_0024var_0024MMonsterId_14 = MasterBaseClass.ToInt(val);
			break;
		case "MMonsterId_15":
			_0024var_0024MMonsterId_15 = MasterBaseClass.ToInt(val);
			break;
		case "MMonsterId_16":
			_0024var_0024MMonsterId_16 = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"MQuestId" => true, 
			"MMonsterId_1" => true, 
			"MMonsterId_2" => true, 
			"MMonsterId_3" => true, 
			"MMonsterId_4" => true, 
			"MMonsterId_5" => true, 
			"MMonsterId_6" => true, 
			"MMonsterId_7" => true, 
			"MMonsterId_8" => true, 
			"MMonsterId_9" => true, 
			"MMonsterId_10" => true, 
			"MMonsterId_11" => true, 
			"MMonsterId_12" => true, 
			"MMonsterId_13" => true, 
			"MMonsterId_14" => true, 
			"MMonsterId_15" => true, 
			"MMonsterId_16" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[18]
		{
			"Id", "MQuestId", "MMonsterId_1", "MMonsterId_2", "MMonsterId_3", "MMonsterId_4", "MMonsterId_5", "MMonsterId_6", "MMonsterId_7", "MMonsterId_8",
			"MMonsterId_9", "MMonsterId_10", "MMonsterId_11", "MMonsterId_12", "MMonsterId_13", "MMonsterId_14", "MMonsterId_15", "MMonsterId_16"
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
					_0024var_0024MQuestId = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024MMonsterId_1 = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024MMonsterId_2 = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024MMonsterId_3 = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024MMonsterId_4 = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024MMonsterId_5 = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024MMonsterId_6 = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024MMonsterId_7 = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024MMonsterId_8 = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024MMonsterId_9 = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024MMonsterId_10 = MasterBaseClass.ParseInt(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024MMonsterId_11 = MasterBaseClass.ParseInt(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024MMonsterId_12 = MasterBaseClass.ParseInt(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024MMonsterId_13 = MasterBaseClass.ParseInt(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null)
																		{
																			_0024var_0024MMonsterId_14 = MasterBaseClass.ParseInt(vals[15]);
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null)
																			{
																				_0024var_0024MMonsterId_15 = MasterBaseClass.ParseInt(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null)
																				{
																					_0024var_0024MMonsterId_16 = MasterBaseClass.ParseInt(vals[17]);
																				}
																				int num = 18;
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
		return result;
	}
}
