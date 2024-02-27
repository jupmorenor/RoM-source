using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MColosseumNpcOrganizes : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MColosseumNpcId;

	public int _0024var_0024InDeckNo;

	public bool _0024var_0024IsLeader;

	public int _0024var_0024StrategyId;

	public int _0024var_0024PoppetItemId;

	public int _0024var_0024PoppetLevel;

	public int _0024var_0024PoppetLevelMax;

	public int _0024var_0024PoppetAtkBonus;

	public int _0024var_0024PoppetHpBonus;

	public int _0024var_0024PoppetAtkPlusBonus;

	public int _0024var_0024PoppetHpPlusBonus;

	public int _0024var_0024PoppetSkill1Level;

	public int _0024var_0024PoppetSkill2Level;

	public int _0024var_0024PoppetSkill3Level;

	public int _0024var_0024PoppetTraitId;

	public int _0024var_0024WeaponItemId;

	public int _0024var_0024WeaponLevel;

	public int _0024var_0024WeaponLevelMax;

	public int _0024var_0024WeaponAtkBonus;

	public int _0024var_0024WeaponHpBonus;

	public int _0024var_0024WeaponAtkPlusBonus;

	public int _0024var_0024WeaponHpPlusBonus;

	public int _0024var_0024WeaponSkill1Level;

	public int _0024var_0024WeaponSkill2Level;

	public int _0024var_0024WeaponSkill3Level;

	public int _0024var_0024WeaponTraitId;

	[NonSerialized]
	private MColosseumNpcs MColosseumNpcId__cache;

	[NonSerialized]
	private MPoppets PoppetItemId__cache;

	[NonSerialized]
	private MWeapons WeaponItemId__cache;

	[NonSerialized]
	private static Dictionary<int, MColosseumNpcOrganizes> _0024mst_0024140 = new Dictionary<int, MColosseumNpcOrganizes>();

	[NonSerialized]
	private static MColosseumNpcOrganizes[] All_cache;

	public int Id => _0024var_0024Id;

	public MColosseumNpcs MColosseumNpcId
	{
		get
		{
			if (MColosseumNpcId__cache == null)
			{
				MColosseumNpcId__cache = MColosseumNpcs.Get(_0024var_0024MColosseumNpcId);
			}
			return MColosseumNpcId__cache;
		}
	}

	public int InDeckNo => _0024var_0024InDeckNo;

	public bool IsLeader => _0024var_0024IsLeader;

	public int StrategyId => _0024var_0024StrategyId;

	public MPoppets PoppetItemId
	{
		get
		{
			if (PoppetItemId__cache == null)
			{
				PoppetItemId__cache = MPoppets.Get(_0024var_0024PoppetItemId);
			}
			return PoppetItemId__cache;
		}
	}

	public int PoppetLevel => _0024var_0024PoppetLevel;

	public int PoppetLevelMax => _0024var_0024PoppetLevelMax;

	public int PoppetAtkBonus => _0024var_0024PoppetAtkBonus;

	public int PoppetHpBonus => _0024var_0024PoppetHpBonus;

	public int PoppetAtkPlusBonus => _0024var_0024PoppetAtkPlusBonus;

	public int PoppetHpPlusBonus => _0024var_0024PoppetHpPlusBonus;

	public int PoppetSkill1Level => _0024var_0024PoppetSkill1Level;

	public int PoppetSkill2Level => _0024var_0024PoppetSkill2Level;

	public int PoppetSkill3Level => _0024var_0024PoppetSkill3Level;

	public int PoppetTraitId => _0024var_0024PoppetTraitId;

	public MWeapons WeaponItemId
	{
		get
		{
			if (WeaponItemId__cache == null)
			{
				WeaponItemId__cache = MWeapons.Get(_0024var_0024WeaponItemId);
			}
			return WeaponItemId__cache;
		}
	}

	public int WeaponLevel => _0024var_0024WeaponLevel;

	public int WeaponLevelMax => _0024var_0024WeaponLevelMax;

	public int WeaponAtkBonus => _0024var_0024WeaponAtkBonus;

	public int WeaponHpBonus => _0024var_0024WeaponHpBonus;

	public int WeaponAtkPlusBonus => _0024var_0024WeaponAtkPlusBonus;

	public int WeaponHpPlusBonus => _0024var_0024WeaponHpPlusBonus;

	public int WeaponSkill1Level => _0024var_0024WeaponSkill1Level;

	public int WeaponSkill2Level => _0024var_0024WeaponSkill2Level;

	public int WeaponSkill3Level => _0024var_0024WeaponSkill3Level;

	public int WeaponTraitId => _0024var_0024WeaponTraitId;

	public static MColosseumNpcOrganizes[] All
	{
		get
		{
			MColosseumNpcOrganizes[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MColosseumNpcOrganizes");
				MColosseumNpcOrganizes[] array = (MColosseumNpcOrganizes[])Builtins.array(typeof(MColosseumNpcOrganizes), _0024mst_0024140.Values);
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

	public static MColosseumNpcOrganizes Get(int _id)
	{
		MerlinMaster.GetHandler("MColosseumNpcOrganizes");
		return (!_0024mst_0024140.ContainsKey(_id)) ? null : _0024mst_0024140[_id];
	}

	public static void Unload()
	{
		_0024mst_0024140.Clear();
		All_cache = null;
	}

	public static MColosseumNpcOrganizes New(Hashtable data)
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
			MColosseumNpcOrganizes mColosseumNpcOrganizes = Create(data);
			if (!_0024mst_0024140.ContainsKey(mColosseumNpcOrganizes.Id))
			{
				_0024mst_0024140[mColosseumNpcOrganizes.Id] = mColosseumNpcOrganizes;
			}
			result = mColosseumNpcOrganizes;
		}
		return (MColosseumNpcOrganizes)result;
	}

	public static MColosseumNpcOrganizes New2(string[] keys, object[] vals)
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
		return (MColosseumNpcOrganizes)result;
	}

	public static MColosseumNpcOrganizes Entry(MColosseumNpcOrganizes mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024140[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MColosseumNpcOrganizes)result;
	}

	public static void AddMst(MColosseumNpcOrganizes mst)
	{
		if (mst != null)
		{
			_0024mst_0024140[mst.Id] = mst;
		}
	}

	public static MColosseumNpcOrganizes Create(Hashtable data)
	{
		MColosseumNpcOrganizes mColosseumNpcOrganizes = new MColosseumNpcOrganizes();
		MColosseumNpcOrganizes result;
		if (data == null)
		{
			result = mColosseumNpcOrganizes;
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
				mColosseumNpcOrganizes.setField((string)obj, data[current]);
			}
			result = mColosseumNpcOrganizes;
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
		case "MColosseumNpcId":
			_0024var_0024MColosseumNpcId = MasterBaseClass.ToInt(val);
			break;
		case "InDeckNo":
			_0024var_0024InDeckNo = MasterBaseClass.ToInt(val);
			break;
		case "IsLeader":
			_0024var_0024IsLeader = MasterBaseClass.ToBool(val);
			break;
		case "StrategyId":
			_0024var_0024StrategyId = MasterBaseClass.ToInt(val);
			break;
		case "PoppetItemId":
			_0024var_0024PoppetItemId = MasterBaseClass.ToInt(val);
			break;
		case "PoppetLevel":
			_0024var_0024PoppetLevel = MasterBaseClass.ToInt(val);
			break;
		case "PoppetLevelMax":
			_0024var_0024PoppetLevelMax = MasterBaseClass.ToInt(val);
			break;
		case "PoppetAtkBonus":
			_0024var_0024PoppetAtkBonus = MasterBaseClass.ToInt(val);
			break;
		case "PoppetHpBonus":
			_0024var_0024PoppetHpBonus = MasterBaseClass.ToInt(val);
			break;
		case "PoppetAtkPlusBonus":
			_0024var_0024PoppetAtkPlusBonus = MasterBaseClass.ToInt(val);
			break;
		case "PoppetHpPlusBonus":
			_0024var_0024PoppetHpPlusBonus = MasterBaseClass.ToInt(val);
			break;
		case "PoppetSkill1Level":
			_0024var_0024PoppetSkill1Level = MasterBaseClass.ToInt(val);
			break;
		case "PoppetSkill2Level":
			_0024var_0024PoppetSkill2Level = MasterBaseClass.ToInt(val);
			break;
		case "PoppetSkill3Level":
			_0024var_0024PoppetSkill3Level = MasterBaseClass.ToInt(val);
			break;
		case "PoppetTraitId":
			_0024var_0024PoppetTraitId = MasterBaseClass.ToInt(val);
			break;
		case "WeaponItemId":
			_0024var_0024WeaponItemId = MasterBaseClass.ToInt(val);
			break;
		case "WeaponLevel":
			_0024var_0024WeaponLevel = MasterBaseClass.ToInt(val);
			break;
		case "WeaponLevelMax":
			_0024var_0024WeaponLevelMax = MasterBaseClass.ToInt(val);
			break;
		case "WeaponAtkBonus":
			_0024var_0024WeaponAtkBonus = MasterBaseClass.ToInt(val);
			break;
		case "WeaponHpBonus":
			_0024var_0024WeaponHpBonus = MasterBaseClass.ToInt(val);
			break;
		case "WeaponAtkPlusBonus":
			_0024var_0024WeaponAtkPlusBonus = MasterBaseClass.ToInt(val);
			break;
		case "WeaponHpPlusBonus":
			_0024var_0024WeaponHpPlusBonus = MasterBaseClass.ToInt(val);
			break;
		case "WeaponSkill1Level":
			_0024var_0024WeaponSkill1Level = MasterBaseClass.ToInt(val);
			break;
		case "WeaponSkill2Level":
			_0024var_0024WeaponSkill2Level = MasterBaseClass.ToInt(val);
			break;
		case "WeaponSkill3Level":
			_0024var_0024WeaponSkill3Level = MasterBaseClass.ToInt(val);
			break;
		case "WeaponTraitId":
			_0024var_0024WeaponTraitId = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"MColosseumNpcId" => true, 
			"InDeckNo" => true, 
			"IsLeader" => true, 
			"StrategyId" => true, 
			"PoppetItemId" => true, 
			"PoppetLevel" => true, 
			"PoppetLevelMax" => true, 
			"PoppetAtkBonus" => true, 
			"PoppetHpBonus" => true, 
			"PoppetAtkPlusBonus" => true, 
			"PoppetHpPlusBonus" => true, 
			"PoppetSkill1Level" => true, 
			"PoppetSkill2Level" => true, 
			"PoppetSkill3Level" => true, 
			"PoppetTraitId" => true, 
			"WeaponItemId" => true, 
			"WeaponLevel" => true, 
			"WeaponLevelMax" => true, 
			"WeaponAtkBonus" => true, 
			"WeaponHpBonus" => true, 
			"WeaponAtkPlusBonus" => true, 
			"WeaponHpPlusBonus" => true, 
			"WeaponSkill1Level" => true, 
			"WeaponSkill2Level" => true, 
			"WeaponSkill3Level" => true, 
			"WeaponTraitId" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[27]
		{
			"Id", "MColosseumNpcId", "InDeckNo", "IsLeader", "StrategyId", "PoppetItemId", "PoppetLevel", "PoppetLevelMax", "PoppetAtkBonus", "PoppetHpBonus",
			"PoppetAtkPlusBonus", "PoppetHpPlusBonus", "PoppetSkill1Level", "PoppetSkill2Level", "PoppetSkill3Level", "PoppetTraitId", "WeaponItemId", "WeaponLevel", "WeaponLevelMax", "WeaponAtkBonus",
			"WeaponHpBonus", "WeaponAtkPlusBonus", "WeaponHpPlusBonus", "WeaponSkill1Level", "WeaponSkill2Level", "WeaponSkill3Level", "WeaponTraitId"
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
					_0024var_0024MColosseumNpcId = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024InDeckNo = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024IsLeader = MasterBaseClass.ParseBool(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024StrategyId = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024PoppetItemId = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024PoppetLevel = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024PoppetLevelMax = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024PoppetAtkBonus = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024PoppetHpBonus = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024PoppetAtkPlusBonus = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024PoppetHpPlusBonus = MasterBaseClass.ParseInt(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024PoppetSkill1Level = MasterBaseClass.ParseInt(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024PoppetSkill2Level = MasterBaseClass.ParseInt(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024PoppetSkill3Level = MasterBaseClass.ParseInt(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null)
																		{
																			_0024var_0024PoppetTraitId = MasterBaseClass.ParseInt(vals[15]);
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null)
																			{
																				_0024var_0024WeaponItemId = MasterBaseClass.ParseInt(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null)
																				{
																					_0024var_0024WeaponLevel = MasterBaseClass.ParseInt(vals[17]);
																				}
																				if (length <= 18)
																				{
																					result = 18;
																				}
																				else
																				{
																					if (vals[18] != null)
																					{
																						_0024var_0024WeaponLevelMax = MasterBaseClass.ParseInt(vals[18]);
																					}
																					if (length <= 19)
																					{
																						result = 19;
																					}
																					else
																					{
																						if (vals[19] != null)
																						{
																							_0024var_0024WeaponAtkBonus = MasterBaseClass.ParseInt(vals[19]);
																						}
																						if (length <= 20)
																						{
																							result = 20;
																						}
																						else
																						{
																							if (vals[20] != null)
																							{
																								_0024var_0024WeaponHpBonus = MasterBaseClass.ParseInt(vals[20]);
																							}
																							if (length <= 21)
																							{
																								result = 21;
																							}
																							else
																							{
																								if (vals[21] != null)
																								{
																									_0024var_0024WeaponAtkPlusBonus = MasterBaseClass.ParseInt(vals[21]);
																								}
																								if (length <= 22)
																								{
																									result = 22;
																								}
																								else
																								{
																									if (vals[22] != null)
																									{
																										_0024var_0024WeaponHpPlusBonus = MasterBaseClass.ParseInt(vals[22]);
																									}
																									if (length <= 23)
																									{
																										result = 23;
																									}
																									else
																									{
																										if (vals[23] != null)
																										{
																											_0024var_0024WeaponSkill1Level = MasterBaseClass.ParseInt(vals[23]);
																										}
																										if (length <= 24)
																										{
																											result = 24;
																										}
																										else
																										{
																											if (vals[24] != null)
																											{
																												_0024var_0024WeaponSkill2Level = MasterBaseClass.ParseInt(vals[24]);
																											}
																											if (length <= 25)
																											{
																												result = 25;
																											}
																											else
																											{
																												if (vals[25] != null)
																												{
																													_0024var_0024WeaponSkill3Level = MasterBaseClass.ParseInt(vals[25]);
																												}
																												if (length <= 26)
																												{
																													result = 26;
																												}
																												else
																												{
																													if (vals[26] != null)
																													{
																														_0024var_0024WeaponTraitId = MasterBaseClass.ParseInt(vals[26]);
																													}
																													int num = 27;
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
		return result;
	}
}
