using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MRaidTutorialRewards : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MQuestId;

	public int _0024var_0024MWeaponId_1;

	public int _0024var_0024MWeaponId_2;

	public int _0024var_0024MWeaponId_3;

	public int _0024var_0024MWeaponId_4;

	public int _0024var_0024MWeaponId_5;

	public int _0024var_0024MWeaponId_6;

	public int _0024var_0024MWeaponId_7;

	public int _0024var_0024MWeaponId_8;

	public int _0024var_0024MPoppetId_1;

	public int _0024var_0024MPoppetId_2;

	public int _0024var_0024MPoppetId_3;

	public int _0024var_0024MPoppetId_4;

	public int _0024var_0024MPoppetId_5;

	public int _0024var_0024MPoppetId_6;

	public int _0024var_0024MPoppetId_7;

	public int _0024var_0024MPoppetId_8;

	[NonSerialized]
	private MQuests MQuestId__cache;

	[NonSerialized]
	private MWeapons MWeaponId_1__cache;

	[NonSerialized]
	private MWeapons MWeaponId_2__cache;

	[NonSerialized]
	private MWeapons MWeaponId_3__cache;

	[NonSerialized]
	private MWeapons MWeaponId_4__cache;

	[NonSerialized]
	private MWeapons MWeaponId_5__cache;

	[NonSerialized]
	private MWeapons MWeaponId_6__cache;

	[NonSerialized]
	private MWeapons MWeaponId_7__cache;

	[NonSerialized]
	private MWeapons MWeaponId_8__cache;

	[NonSerialized]
	private MPoppets MPoppetId_1__cache;

	[NonSerialized]
	private MPoppets MPoppetId_2__cache;

	[NonSerialized]
	private MPoppets MPoppetId_3__cache;

	[NonSerialized]
	private MPoppets MPoppetId_4__cache;

	[NonSerialized]
	private MPoppets MPoppetId_5__cache;

	[NonSerialized]
	private MPoppets MPoppetId_6__cache;

	[NonSerialized]
	private MPoppets MPoppetId_7__cache;

	[NonSerialized]
	private MPoppets MPoppetId_8__cache;

	[NonSerialized]
	private static Dictionary<int, MRaidTutorialRewards> _0024mst_002491 = new Dictionary<int, MRaidTutorialRewards>();

	[NonSerialized]
	private static MRaidTutorialRewards[] All_cache;

	public MWeapons[] Weapons
	{
		get
		{
			System.Collections.Generic.List<MWeapons> list = new System.Collections.Generic.List<MWeapons>();
			if (MWeaponId_1 != null)
			{
				list.Add(MWeaponId_1);
			}
			if (MWeaponId_2 != null)
			{
				list.Add(MWeaponId_2);
			}
			if (MWeaponId_3 != null)
			{
				list.Add(MWeaponId_3);
			}
			if (MWeaponId_4 != null)
			{
				list.Add(MWeaponId_4);
			}
			if (MWeaponId_5 != null)
			{
				list.Add(MWeaponId_5);
			}
			if (MWeaponId_6 != null)
			{
				list.Add(MWeaponId_6);
			}
			if (MWeaponId_7 != null)
			{
				list.Add(MWeaponId_7);
			}
			if (MWeaponId_8 != null)
			{
				list.Add(MWeaponId_8);
			}
			return list.ToArray();
		}
	}

	public MPoppets[] Poppets
	{
		get
		{
			System.Collections.Generic.List<MPoppets> list = new System.Collections.Generic.List<MPoppets>();
			if (MPoppetId_1 != null)
			{
				list.Add(MPoppetId_1);
			}
			if (MPoppetId_2 != null)
			{
				list.Add(MPoppetId_2);
			}
			if (MPoppetId_3 != null)
			{
				list.Add(MPoppetId_3);
			}
			if (MPoppetId_4 != null)
			{
				list.Add(MPoppetId_4);
			}
			if (MPoppetId_5 != null)
			{
				list.Add(MPoppetId_5);
			}
			if (MPoppetId_6 != null)
			{
				list.Add(MPoppetId_6);
			}
			if (MPoppetId_7 != null)
			{
				list.Add(MPoppetId_7);
			}
			if (MPoppetId_8 != null)
			{
				list.Add(MPoppetId_8);
			}
			return list.ToArray();
		}
	}

	public int Id => _0024var_0024Id;

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

	public MWeapons MWeaponId_1
	{
		get
		{
			if (MWeaponId_1__cache == null)
			{
				MWeaponId_1__cache = MWeapons.Get(_0024var_0024MWeaponId_1);
			}
			return MWeaponId_1__cache;
		}
	}

	public MWeapons MWeaponId_2
	{
		get
		{
			if (MWeaponId_2__cache == null)
			{
				MWeaponId_2__cache = MWeapons.Get(_0024var_0024MWeaponId_2);
			}
			return MWeaponId_2__cache;
		}
	}

	public MWeapons MWeaponId_3
	{
		get
		{
			if (MWeaponId_3__cache == null)
			{
				MWeaponId_3__cache = MWeapons.Get(_0024var_0024MWeaponId_3);
			}
			return MWeaponId_3__cache;
		}
	}

	public MWeapons MWeaponId_4
	{
		get
		{
			if (MWeaponId_4__cache == null)
			{
				MWeaponId_4__cache = MWeapons.Get(_0024var_0024MWeaponId_4);
			}
			return MWeaponId_4__cache;
		}
	}

	public MWeapons MWeaponId_5
	{
		get
		{
			if (MWeaponId_5__cache == null)
			{
				MWeaponId_5__cache = MWeapons.Get(_0024var_0024MWeaponId_5);
			}
			return MWeaponId_5__cache;
		}
	}

	public MWeapons MWeaponId_6
	{
		get
		{
			if (MWeaponId_6__cache == null)
			{
				MWeaponId_6__cache = MWeapons.Get(_0024var_0024MWeaponId_6);
			}
			return MWeaponId_6__cache;
		}
	}

	public MWeapons MWeaponId_7
	{
		get
		{
			if (MWeaponId_7__cache == null)
			{
				MWeaponId_7__cache = MWeapons.Get(_0024var_0024MWeaponId_7);
			}
			return MWeaponId_7__cache;
		}
	}

	public MWeapons MWeaponId_8
	{
		get
		{
			if (MWeaponId_8__cache == null)
			{
				MWeaponId_8__cache = MWeapons.Get(_0024var_0024MWeaponId_8);
			}
			return MWeaponId_8__cache;
		}
	}

	public MPoppets MPoppetId_1
	{
		get
		{
			if (MPoppetId_1__cache == null)
			{
				MPoppetId_1__cache = MPoppets.Get(_0024var_0024MPoppetId_1);
			}
			return MPoppetId_1__cache;
		}
	}

	public MPoppets MPoppetId_2
	{
		get
		{
			if (MPoppetId_2__cache == null)
			{
				MPoppetId_2__cache = MPoppets.Get(_0024var_0024MPoppetId_2);
			}
			return MPoppetId_2__cache;
		}
	}

	public MPoppets MPoppetId_3
	{
		get
		{
			if (MPoppetId_3__cache == null)
			{
				MPoppetId_3__cache = MPoppets.Get(_0024var_0024MPoppetId_3);
			}
			return MPoppetId_3__cache;
		}
	}

	public MPoppets MPoppetId_4
	{
		get
		{
			if (MPoppetId_4__cache == null)
			{
				MPoppetId_4__cache = MPoppets.Get(_0024var_0024MPoppetId_4);
			}
			return MPoppetId_4__cache;
		}
	}

	public MPoppets MPoppetId_5
	{
		get
		{
			if (MPoppetId_5__cache == null)
			{
				MPoppetId_5__cache = MPoppets.Get(_0024var_0024MPoppetId_5);
			}
			return MPoppetId_5__cache;
		}
	}

	public MPoppets MPoppetId_6
	{
		get
		{
			if (MPoppetId_6__cache == null)
			{
				MPoppetId_6__cache = MPoppets.Get(_0024var_0024MPoppetId_6);
			}
			return MPoppetId_6__cache;
		}
	}

	public MPoppets MPoppetId_7
	{
		get
		{
			if (MPoppetId_7__cache == null)
			{
				MPoppetId_7__cache = MPoppets.Get(_0024var_0024MPoppetId_7);
			}
			return MPoppetId_7__cache;
		}
	}

	public MPoppets MPoppetId_8
	{
		get
		{
			if (MPoppetId_8__cache == null)
			{
				MPoppetId_8__cache = MPoppets.Get(_0024var_0024MPoppetId_8);
			}
			return MPoppetId_8__cache;
		}
	}

	public static MRaidTutorialRewards[] All
	{
		get
		{
			MRaidTutorialRewards[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MRaidTutorialRewards");
				MRaidTutorialRewards[] array = (MRaidTutorialRewards[])Builtins.array(typeof(MRaidTutorialRewards), _0024mst_002491.Values);
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

	public static MRaidTutorialRewards Get(int _id)
	{
		MerlinMaster.GetHandler("MRaidTutorialRewards");
		return (!_0024mst_002491.ContainsKey(_id)) ? null : _0024mst_002491[_id];
	}

	public static void Unload()
	{
		_0024mst_002491.Clear();
		All_cache = null;
	}

	public static MRaidTutorialRewards New(Hashtable data)
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
			MRaidTutorialRewards mRaidTutorialRewards = Create(data);
			if (!_0024mst_002491.ContainsKey(mRaidTutorialRewards.Id))
			{
				_0024mst_002491[mRaidTutorialRewards.Id] = mRaidTutorialRewards;
			}
			result = mRaidTutorialRewards;
		}
		return (MRaidTutorialRewards)result;
	}

	public static MRaidTutorialRewards New2(string[] keys, object[] vals)
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
		return (MRaidTutorialRewards)result;
	}

	public static MRaidTutorialRewards Entry(MRaidTutorialRewards mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002491[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MRaidTutorialRewards)result;
	}

	public static void AddMst(MRaidTutorialRewards mst)
	{
		if (mst != null)
		{
			_0024mst_002491[mst.Id] = mst;
		}
	}

	public static MRaidTutorialRewards Create(Hashtable data)
	{
		MRaidTutorialRewards mRaidTutorialRewards = new MRaidTutorialRewards();
		MRaidTutorialRewards result;
		if (data == null)
		{
			result = mRaidTutorialRewards;
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
				mRaidTutorialRewards.setField((string)obj, data[current]);
			}
			result = mRaidTutorialRewards;
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
		case "MWeaponId_1":
			_0024var_0024MWeaponId_1 = MasterBaseClass.ToInt(val);
			break;
		case "MWeaponId_2":
			_0024var_0024MWeaponId_2 = MasterBaseClass.ToInt(val);
			break;
		case "MWeaponId_3":
			_0024var_0024MWeaponId_3 = MasterBaseClass.ToInt(val);
			break;
		case "MWeaponId_4":
			_0024var_0024MWeaponId_4 = MasterBaseClass.ToInt(val);
			break;
		case "MWeaponId_5":
			_0024var_0024MWeaponId_5 = MasterBaseClass.ToInt(val);
			break;
		case "MWeaponId_6":
			_0024var_0024MWeaponId_6 = MasterBaseClass.ToInt(val);
			break;
		case "MWeaponId_7":
			_0024var_0024MWeaponId_7 = MasterBaseClass.ToInt(val);
			break;
		case "MWeaponId_8":
			_0024var_0024MWeaponId_8 = MasterBaseClass.ToInt(val);
			break;
		case "MPoppetId_1":
			_0024var_0024MPoppetId_1 = MasterBaseClass.ToInt(val);
			break;
		case "MPoppetId_2":
			_0024var_0024MPoppetId_2 = MasterBaseClass.ToInt(val);
			break;
		case "MPoppetId_3":
			_0024var_0024MPoppetId_3 = MasterBaseClass.ToInt(val);
			break;
		case "MPoppetId_4":
			_0024var_0024MPoppetId_4 = MasterBaseClass.ToInt(val);
			break;
		case "MPoppetId_5":
			_0024var_0024MPoppetId_5 = MasterBaseClass.ToInt(val);
			break;
		case "MPoppetId_6":
			_0024var_0024MPoppetId_6 = MasterBaseClass.ToInt(val);
			break;
		case "MPoppetId_7":
			_0024var_0024MPoppetId_7 = MasterBaseClass.ToInt(val);
			break;
		case "MPoppetId_8":
			_0024var_0024MPoppetId_8 = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"MQuestId" => true, 
			"MWeaponId_1" => true, 
			"MWeaponId_2" => true, 
			"MWeaponId_3" => true, 
			"MWeaponId_4" => true, 
			"MWeaponId_5" => true, 
			"MWeaponId_6" => true, 
			"MWeaponId_7" => true, 
			"MWeaponId_8" => true, 
			"MPoppetId_1" => true, 
			"MPoppetId_2" => true, 
			"MPoppetId_3" => true, 
			"MPoppetId_4" => true, 
			"MPoppetId_5" => true, 
			"MPoppetId_6" => true, 
			"MPoppetId_7" => true, 
			"MPoppetId_8" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[18]
		{
			"Id", "MQuestId", "MWeaponId_1", "MWeaponId_2", "MWeaponId_3", "MWeaponId_4", "MWeaponId_5", "MWeaponId_6", "MWeaponId_7", "MWeaponId_8",
			"MPoppetId_1", "MPoppetId_2", "MPoppetId_3", "MPoppetId_4", "MPoppetId_5", "MPoppetId_6", "MPoppetId_7", "MPoppetId_8"
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
						_0024var_0024MWeaponId_1 = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024MWeaponId_2 = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024MWeaponId_3 = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024MWeaponId_4 = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024MWeaponId_5 = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024MWeaponId_6 = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024MWeaponId_7 = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024MWeaponId_8 = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024MPoppetId_1 = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024MPoppetId_2 = MasterBaseClass.ParseInt(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024MPoppetId_3 = MasterBaseClass.ParseInt(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024MPoppetId_4 = MasterBaseClass.ParseInt(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024MPoppetId_5 = MasterBaseClass.ParseInt(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null)
																		{
																			_0024var_0024MPoppetId_6 = MasterBaseClass.ParseInt(vals[15]);
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null)
																			{
																				_0024var_0024MPoppetId_7 = MasterBaseClass.ParseInt(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null)
																				{
																					_0024var_0024MPoppetId_8 = MasterBaseClass.ParseInt(vals[17]);
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
