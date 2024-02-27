using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MStageMonsters : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	public int _0024var_0024MStageId;

	public int _0024var_0024MMonsterId;

	public bool _0024var_0024IsDummy;

	public bool _0024var_0024IsElite;

	public int _0024var_0024CorrespondentNpc;

	public int _0024var_0024IsBoss;

	public int _0024var_0024LevelMin;

	public int _0024var_0024LevelMax;

	public int _0024var_0024Quantity;

	public int _0024var_0024Rate;

	public string _0024var_0024PositionObject;

	public bool _0024var_0024IsNoIcon;

	public int _0024var_0024PopStep;

	public bool _0024var_0024NoPopEffect;

	public int _0024var_0024MItemGroupId;

	public int _0024var_0024Scale;

	public bool _0024var_0024AntiBattleReset;

	public int _0024var_0024DummyDropLevel;

	public int _0024var_0024DummyCoin;

	public bool _0024var_0024DontDestroyIfDead;

	[NonSerialized]
	private MMonsters MMonsterId__cache;

	[NonSerialized]
	private MNpcs CorrespondentNpc__cache;

	[NonSerialized]
	private MItemGroups MItemGroupId__cache;

	[NonSerialized]
	private static Dictionary<int, MStageMonsters> _0024mst_002469 = new Dictionary<int, MStageMonsters>();

	[NonSerialized]
	private static MStageMonsters[] All_cache;

	public bool HasScale => Scale > 0;

	public float PopScale => (Scale > 0) ? ((float)Scale / 100f) : 1f;

	public MStageBattles ParentStageBattle
	{
		get
		{
			int num = 0;
			MStageBattles[] all = MStageBattles.All;
			int length = all.Length;
			checked
			{
				object result;
				while (true)
				{
					if (num < length)
					{
						int num2 = 0;
						MStageMonsters[] allStageMonsters = all[num].AllStageMonsters;
						int length2 = allStageMonsters.Length;
						while (num2 < length2)
						{
							if (allStageMonsters[num2].Id != Id)
							{
								num2++;
								continue;
							}
							goto IL_0045;
						}
						num++;
						continue;
					}
					result = null;
					break;
					IL_0045:
					result = all[num];
					break;
				}
				return (MStageBattles)result;
			}
		}
	}

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

	public int MStageId => _0024var_0024MStageId;

	public MMonsters MMonsterId
	{
		get
		{
			if (MMonsterId__cache == null)
			{
				MMonsterId__cache = MMonsters.Get(_0024var_0024MMonsterId);
			}
			return MMonsterId__cache;
		}
	}

	public bool IsDummy => _0024var_0024IsDummy;

	public bool IsElite => _0024var_0024IsElite;

	public MNpcs CorrespondentNpc
	{
		get
		{
			if (CorrespondentNpc__cache == null)
			{
				CorrespondentNpc__cache = MNpcs.Get(_0024var_0024CorrespondentNpc);
			}
			return CorrespondentNpc__cache;
		}
	}

	public int IsBoss => _0024var_0024IsBoss;

	public int LevelMin => _0024var_0024LevelMin;

	public int LevelMax => _0024var_0024LevelMax;

	public int Quantity => _0024var_0024Quantity;

	public int Rate => _0024var_0024Rate;

	public string PositionObject => _0024var_0024PositionObject;

	public bool IsNoIcon => _0024var_0024IsNoIcon;

	public int PopStep => _0024var_0024PopStep;

	public bool NoPopEffect => _0024var_0024NoPopEffect;

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

	public int Scale => _0024var_0024Scale;

	public bool AntiBattleReset => _0024var_0024AntiBattleReset;

	public int DummyDropLevel => _0024var_0024DummyDropLevel;

	public int DummyCoin => _0024var_0024DummyCoin;

	public bool DontDestroyIfDead => _0024var_0024DontDestroyIfDead;

	public static MStageMonsters[] All
	{
		get
		{
			MStageMonsters[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MStageMonsters");
				MStageMonsters[] array = (MStageMonsters[])Builtins.array(typeof(MStageMonsters), _0024mst_002469.Values);
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

	public MStageMonsters()
	{
		_0024var_0024LevelMin = 1;
		_0024var_0024LevelMax = 1;
		_0024var_0024Quantity = 1;
		_0024var_0024Rate = 100;
	}

	public override string ToString()
	{
		string value = ((CorrespondentNpc == null) ? "x" : "o");
		return new StringBuilder("MStageMonsters(").Append((object)Id).Append(",").Append(Progname)
			.Append(",")
			.Append(MMonsterId)
			.Append(" stg:")
			.Append((object)MStageId)
			.Append(" boss:")
			.Append((object)IsBoss)
			.Append(" step:")
			.Append((object)PopStep)
			.Append(" npc:")
			.Append(value)
			.Append(")")
			.ToString();
	}

	public static MStageMonsters Get(int _id)
	{
		MerlinMaster.GetHandler("MStageMonsters");
		return (!_0024mst_002469.ContainsKey(_id)) ? null : _0024mst_002469[_id];
	}

	public static void Unload()
	{
		_0024mst_002469.Clear();
		All_cache = null;
	}

	public static MStageMonsters New(Hashtable data)
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
			MStageMonsters mStageMonsters = Create(data);
			if (!_0024mst_002469.ContainsKey(mStageMonsters.Id))
			{
				_0024mst_002469[mStageMonsters.Id] = mStageMonsters;
			}
			result = mStageMonsters;
		}
		return (MStageMonsters)result;
	}

	public static MStageMonsters New2(string[] keys, object[] vals)
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
		return (MStageMonsters)result;
	}

	public static MStageMonsters Entry(MStageMonsters mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002469[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MStageMonsters)result;
	}

	public static void AddMst(MStageMonsters mst)
	{
		if (mst != null)
		{
			_0024mst_002469[mst.Id] = mst;
		}
	}

	public static MStageMonsters Create(Hashtable data)
	{
		MStageMonsters mStageMonsters = new MStageMonsters();
		MStageMonsters result;
		if (data == null)
		{
			result = mStageMonsters;
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
				mStageMonsters.setField((string)obj, data[current]);
			}
			result = mStageMonsters;
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
		case "MStageId":
			_0024var_0024MStageId = MasterBaseClass.ToInt(val);
			break;
		case "MMonsterId":
			_0024var_0024MMonsterId = MasterBaseClass.ToInt(val);
			break;
		case "IsDummy":
			_0024var_0024IsDummy = MasterBaseClass.ToBool(val);
			break;
		case "IsElite":
			_0024var_0024IsElite = MasterBaseClass.ToBool(val);
			break;
		case "CorrespondentNpc":
			_0024var_0024CorrespondentNpc = MasterBaseClass.ToInt(val);
			break;
		case "IsBoss":
			_0024var_0024IsBoss = MasterBaseClass.ToInt(val);
			break;
		case "LevelMin":
			_0024var_0024LevelMin = MasterBaseClass.ToInt(val);
			break;
		case "LevelMax":
			_0024var_0024LevelMax = MasterBaseClass.ToInt(val);
			break;
		case "Quantity":
			_0024var_0024Quantity = MasterBaseClass.ToInt(val);
			break;
		case "Rate":
			_0024var_0024Rate = MasterBaseClass.ToInt(val);
			break;
		case "PositionObject":
			_0024var_0024PositionObject = MasterBaseClass.ToStringValue(val);
			break;
		case "IsNoIcon":
			_0024var_0024IsNoIcon = MasterBaseClass.ToBool(val);
			break;
		case "PopStep":
			_0024var_0024PopStep = MasterBaseClass.ToInt(val);
			break;
		case "NoPopEffect":
			_0024var_0024NoPopEffect = MasterBaseClass.ToBool(val);
			break;
		case "MItemGroupId":
			_0024var_0024MItemGroupId = MasterBaseClass.ToInt(val);
			break;
		case "Scale":
			_0024var_0024Scale = MasterBaseClass.ToInt(val);
			break;
		case "AntiBattleReset":
			_0024var_0024AntiBattleReset = MasterBaseClass.ToBool(val);
			break;
		case "DummyDropLevel":
			_0024var_0024DummyDropLevel = MasterBaseClass.ToInt(val);
			break;
		case "DummyCoin":
			_0024var_0024DummyCoin = MasterBaseClass.ToInt(val);
			break;
		case "DontDestroyIfDead":
			_0024var_0024DontDestroyIfDead = MasterBaseClass.ToBool(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Progname" => true, 
			"MStageId" => true, 
			"MMonsterId" => true, 
			"IsDummy" => true, 
			"IsElite" => true, 
			"CorrespondentNpc" => true, 
			"IsBoss" => true, 
			"LevelMin" => true, 
			"LevelMax" => true, 
			"Quantity" => true, 
			"Rate" => true, 
			"PositionObject" => true, 
			"IsNoIcon" => true, 
			"PopStep" => true, 
			"NoPopEffect" => true, 
			"MItemGroupId" => true, 
			"Scale" => true, 
			"AntiBattleReset" => true, 
			"DummyDropLevel" => true, 
			"DummyCoin" => true, 
			"DontDestroyIfDead" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[22]
		{
			"Id", "Progname", "MStageId", "MMonsterId", "IsDummy", "IsElite", "CorrespondentNpc", "IsBoss", "LevelMin", "LevelMax",
			"Quantity", "Rate", "PositionObject", "IsNoIcon", "PopStep", "NoPopEffect", "MItemGroupId", "Scale", "AntiBattleReset", "DummyDropLevel",
			"DummyCoin", "DontDestroyIfDead"
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
						_0024var_0024MStageId = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024MMonsterId = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024IsDummy = MasterBaseClass.ParseBool(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024IsElite = MasterBaseClass.ParseBool(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024CorrespondentNpc = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024IsBoss = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024LevelMin = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024LevelMax = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024Quantity = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024Rate = MasterBaseClass.ParseInt(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024PositionObject = vals[12];
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024IsNoIcon = MasterBaseClass.ParseBool(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024PopStep = MasterBaseClass.ParseInt(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null)
																		{
																			_0024var_0024NoPopEffect = MasterBaseClass.ParseBool(vals[15]);
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null)
																			{
																				_0024var_0024MItemGroupId = MasterBaseClass.ParseInt(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null)
																				{
																					_0024var_0024Scale = MasterBaseClass.ParseInt(vals[17]);
																				}
																				if (length <= 18)
																				{
																					result = 18;
																				}
																				else
																				{
																					if (vals[18] != null)
																					{
																						_0024var_0024AntiBattleReset = MasterBaseClass.ParseBool(vals[18]);
																					}
																					if (length <= 19)
																					{
																						result = 19;
																					}
																					else
																					{
																						if (vals[19] != null)
																						{
																							_0024var_0024DummyDropLevel = MasterBaseClass.ParseInt(vals[19]);
																						}
																						if (length <= 20)
																						{
																							result = 20;
																						}
																						else
																						{
																							if (vals[20] != null)
																							{
																								_0024var_0024DummyCoin = MasterBaseClass.ParseInt(vals[20]);
																							}
																							if (length <= 21)
																							{
																								result = 21;
																							}
																							else
																							{
																								if (vals[21] != null)
																								{
																									_0024var_0024DontDestroyIfDead = MasterBaseClass.ParseBool(vals[21]);
																								}
																								int num = 22;
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
		return result;
	}
}
