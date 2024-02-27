using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MChainSkills : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public string _0024var_0024Progname;

	public string _0024var_0024Detail;

	public string _0024var_0024Icon;

	public string _0024var_0024Motion;

	public string _0024var_0024PlayerMotion;

	public int _0024var_0024PowerBase;

	public int _0024var_0024ExpirationTime;

	public int _0024var_0024LevelMax;

	public string _0024var_0024EffectPrefab;

	public SkillEffectParameters _0024var_0024SkillEffect;

	public float _0024var_0024Attack_Range;

	public float _0024var_0024Attack_Move;

	public int _0024var_0024Enemy_Count;

	public bool _0024var_0024Enemy_Extra;

	public bool _0024var_0024Enemy_AndOr;

	public int _0024var_0024Pc_ComparisonOperator;

	public int _0024var_0024Pc_StatType;

	public int _0024var_0024Pc_StatValueMin;

	public int _0024var_0024Pc_StatValueMax;

	public float _0024var_0024Pc_StatValueExp;

	public bool _0024var_0024Pc_AbnormalState;

	public bool _0024var_0024DisableColosseum;

	[NonSerialized]
	private MTexts Name__cache;

	[NonSerialized]
	private MTexts Detail__cache;

	[NonSerialized]
	private static Dictionary<int, MChainSkills> _0024mst_002417 = new Dictionary<int, MChainSkills>();

	[NonSerialized]
	private static MChainSkills[] All_cache;

	public float PowerRate => (float)PowerBase / 100f;

	public int Id => _0024var_0024Id;

	public MTexts Name
	{
		get
		{
			if (Name__cache == null)
			{
				Name__cache = MTexts.Get(_0024var_0024Name);
			}
			return Name__cache;
		}
	}

	public string Progname => _0024var_0024Progname;

	public MTexts Detail
	{
		get
		{
			if (Detail__cache == null)
			{
				Detail__cache = MTexts.Get(_0024var_0024Detail);
			}
			return Detail__cache;
		}
	}

	public string Icon => _0024var_0024Icon;

	public string Motion => _0024var_0024Motion;

	public string PlayerMotion => _0024var_0024PlayerMotion;

	public int PowerBase => _0024var_0024PowerBase;

	public int ExpirationTime => _0024var_0024ExpirationTime;

	public int LevelMax => _0024var_0024LevelMax;

	public string EffectPrefab => _0024var_0024EffectPrefab;

	public SkillEffectParameters SkillEffect => _0024var_0024SkillEffect;

	public float Attack_Range => _0024var_0024Attack_Range;

	public float Attack_Move => _0024var_0024Attack_Move;

	public int Enemy_Count => _0024var_0024Enemy_Count;

	public bool Enemy_Extra => _0024var_0024Enemy_Extra;

	public bool Enemy_AndOr => _0024var_0024Enemy_AndOr;

	public int Pc_ComparisonOperator => _0024var_0024Pc_ComparisonOperator;

	public int Pc_StatType => _0024var_0024Pc_StatType;

	public int Pc_StatValueMin => _0024var_0024Pc_StatValueMin;

	public int Pc_StatValueMax => _0024var_0024Pc_StatValueMax;

	public float Pc_StatValueExp => _0024var_0024Pc_StatValueExp;

	public bool Pc_AbnormalState => _0024var_0024Pc_AbnormalState;

	public bool DisableColosseum => _0024var_0024DisableColosseum;

	public static MChainSkills[] All
	{
		get
		{
			MChainSkills[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MChainSkills");
				MChainSkills[] array = (MChainSkills[])Builtins.array(typeof(MChainSkills), _0024mst_002417.Values);
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

	public MChainSkills()
	{
		_0024var_0024ExpirationTime = 10;
		_0024var_0024SkillEffect = new SkillEffectParameters();
	}

	public float getEffectValue(int level)
	{
		return SkillEffect.getEffectValue(level, LevelMax, ToString());
	}

	public float getEffectValueAsRate(int level)
	{
		return SkillEffect.getEffectValueAsRate(level, LevelMax, ToString());
	}

	public override string ToString()
	{
		return new StringBuilder("MChainSkills(").Append((object)Id).Append(",").Append(Progname)
			.Append(")")
			.ToString();
	}

	public static MChainSkills Get(int _id)
	{
		MerlinMaster.GetHandler("MChainSkills");
		return (!_0024mst_002417.ContainsKey(_id)) ? null : _0024mst_002417[_id];
	}

	public static void Unload()
	{
		_0024mst_002417.Clear();
		All_cache = null;
	}

	public static MChainSkills New(Hashtable data)
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
			MChainSkills mChainSkills = Create(data);
			if (!_0024mst_002417.ContainsKey(mChainSkills.Id))
			{
				_0024mst_002417[mChainSkills.Id] = mChainSkills;
			}
			result = mChainSkills;
		}
		return (MChainSkills)result;
	}

	public static MChainSkills New2(string[] keys, object[] vals)
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
		return (MChainSkills)result;
	}

	public static MChainSkills Entry(MChainSkills mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002417[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MChainSkills)result;
	}

	public static void AddMst(MChainSkills mst)
	{
		if (mst != null)
		{
			_0024mst_002417[mst.Id] = mst;
		}
	}

	public static MChainSkills Create(Hashtable data)
	{
		MChainSkills mChainSkills = new MChainSkills();
		MChainSkills result;
		if (data == null)
		{
			result = mChainSkills;
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
				mChainSkills.setField((string)obj, data[current]);
			}
			result = mChainSkills;
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
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		case "Progname":
			_0024var_0024Progname = MasterBaseClass.ToStringValue(val);
			break;
		case "Detail":
			_0024var_0024Detail = MasterBaseClass.ToStringValue(val);
			break;
		case "Icon":
			_0024var_0024Icon = MasterBaseClass.ToStringValue(val);
			break;
		case "Motion":
			_0024var_0024Motion = MasterBaseClass.ToStringValue(val);
			break;
		case "PlayerMotion":
			_0024var_0024PlayerMotion = MasterBaseClass.ToStringValue(val);
			break;
		case "PowerBase":
			_0024var_0024PowerBase = MasterBaseClass.ToInt(val);
			break;
		case "ExpirationTime":
			_0024var_0024ExpirationTime = MasterBaseClass.ToInt(val);
			break;
		case "LevelMax":
			_0024var_0024LevelMax = MasterBaseClass.ToInt(val);
			break;
		case "EffectPrefab":
			_0024var_0024EffectPrefab = MasterBaseClass.ToStringValue(val);
			break;
		case "SkillEffect":
		{
			object obj = val;
			if (!(obj is Hashtable))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
			}
			_0024var_0024SkillEffect = SkillEffectParameters.Create((Hashtable)obj);
			break;
		}
		case "Attack_Range":
			_0024var_0024Attack_Range = MasterBaseClass.ToSingle(val);
			break;
		case "Attack_Move":
			_0024var_0024Attack_Move = MasterBaseClass.ToSingle(val);
			break;
		case "Enemy_Count":
			_0024var_0024Enemy_Count = MasterBaseClass.ToInt(val);
			break;
		case "Enemy_Extra":
			_0024var_0024Enemy_Extra = MasterBaseClass.ToBool(val);
			break;
		case "Enemy_AndOr":
			_0024var_0024Enemy_AndOr = MasterBaseClass.ToBool(val);
			break;
		case "Pc_ComparisonOperator":
			_0024var_0024Pc_ComparisonOperator = MasterBaseClass.ToInt(val);
			break;
		case "Pc_StatType":
			_0024var_0024Pc_StatType = MasterBaseClass.ToInt(val);
			break;
		case "Pc_StatValueMin":
			_0024var_0024Pc_StatValueMin = MasterBaseClass.ToInt(val);
			break;
		case "Pc_StatValueMax":
			_0024var_0024Pc_StatValueMax = MasterBaseClass.ToInt(val);
			break;
		case "Pc_StatValueExp":
			_0024var_0024Pc_StatValueExp = MasterBaseClass.ToSingle(val);
			break;
		case "Pc_AbnormalState":
			_0024var_0024Pc_AbnormalState = MasterBaseClass.ToBool(val);
			break;
		case "DisableColosseum":
			_0024var_0024DisableColosseum = MasterBaseClass.ToBool(val);
			break;
		default:
			if (SkillEffectParameters.HasKey(key))
			{
				_0024var_0024SkillEffect.setField(key, val);
			}
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Name" => true, 
			"Progname" => true, 
			"Detail" => true, 
			"Icon" => true, 
			"Motion" => true, 
			"PlayerMotion" => true, 
			"PowerBase" => true, 
			"ExpirationTime" => true, 
			"LevelMax" => true, 
			"EffectPrefab" => true, 
			"SkillEffect" => true, 
			"Attack_Range" => true, 
			"Attack_Move" => true, 
			"Enemy_Count" => true, 
			"Enemy_Extra" => true, 
			"Enemy_AndOr" => true, 
			"Pc_ComparisonOperator" => true, 
			"Pc_StatType" => true, 
			"Pc_StatValueMin" => true, 
			"Pc_StatValueMax" => true, 
			"Pc_StatValueExp" => true, 
			"Pc_AbnormalState" => true, 
			"DisableColosseum" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		lhs = (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[23]
		{
			"Id", "Name", "Progname", "Detail", "Icon", "Motion", "PlayerMotion", "PowerBase", "ExpirationTime", "LevelMax",
			"EffectPrefab", "Attack_Range", "Attack_Move", "Enemy_Count", "Enemy_Extra", "Enemy_AndOr", "Pc_ComparisonOperator", "Pc_StatType", "Pc_StatValueMin", "Pc_StatValueMax",
			"Pc_StatValueExp", "Pc_AbnormalState", "DisableColosseum"
		});
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, SkillEffectParameters.KeyNameList());
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
					_0024var_0024Name = vals[1];
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024Progname = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Detail = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024Icon = vals[4];
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Motion = vals[5];
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024PlayerMotion = vals[6];
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024PowerBase = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024ExpirationTime = MasterBaseClass.ParseInt(vals[8]);
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
														_0024var_0024EffectPrefab = vals[10];
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024Attack_Range = MasterBaseClass.ParseSingle(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024Attack_Move = MasterBaseClass.ParseSingle(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024Enemy_Count = MasterBaseClass.ParseInt(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024Enemy_Extra = MasterBaseClass.ParseBool(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null)
																		{
																			_0024var_0024Enemy_AndOr = MasterBaseClass.ParseBool(vals[15]);
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null)
																			{
																				_0024var_0024Pc_ComparisonOperator = MasterBaseClass.ParseInt(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null)
																				{
																					_0024var_0024Pc_StatType = MasterBaseClass.ParseInt(vals[17]);
																				}
																				if (length <= 18)
																				{
																					result = 18;
																				}
																				else
																				{
																					if (vals[18] != null)
																					{
																						_0024var_0024Pc_StatValueMin = MasterBaseClass.ParseInt(vals[18]);
																					}
																					if (length <= 19)
																					{
																						result = 19;
																					}
																					else
																					{
																						if (vals[19] != null)
																						{
																							_0024var_0024Pc_StatValueMax = MasterBaseClass.ParseInt(vals[19]);
																						}
																						if (length <= 20)
																						{
																							result = 20;
																						}
																						else
																						{
																							if (vals[20] != null)
																							{
																								_0024var_0024Pc_StatValueExp = MasterBaseClass.ParseSingle(vals[20]);
																							}
																							if (length <= 21)
																							{
																								result = 21;
																							}
																							else
																							{
																								if (vals[21] != null)
																								{
																									_0024var_0024Pc_AbnormalState = MasterBaseClass.ParseBool(vals[21]);
																								}
																								if (length <= 22)
																								{
																									result = 22;
																								}
																								else
																								{
																									if (vals[22] != null)
																									{
																										_0024var_0024DisableColosseum = MasterBaseClass.ParseBool(vals[22]);
																									}
																									int num = 23;
																									if (length > num)
																									{
																										num = checked(num + _0024var_0024SkillEffect.setStringValues((string[])RuntimeServices.GetRange1(vals, num)));
																										result = num;
																									}
																									else
																									{
																										result = 0;
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
