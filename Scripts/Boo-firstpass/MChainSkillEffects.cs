using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MChainSkillEffects : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024DebugName;

	public int _0024var_0024ChainSkillId;

	public int _0024var_0024EmitMode;

	public float _0024var_0024OfsX;

	public float _0024var_0024OfsY;

	public float _0024var_0024OfsZ;

	public bool _0024var_0024Once;

	public float _0024var_0024Damage;

	public YarareTypes _0024var_0024YarareType;

	public float _0024var_0024KnockBackPow;

	public float _0024var_0024EffKillTime;

	public bool _0024var_0024HasDownHit;

	public float _0024var_0024PlayerEmitDelay;

	public float _0024var_0024PoppetEmitDelay;

	public float _0024var_0024DownHitEffectDelay;

	public EnumAbnormalStates _0024var_0024AbnormalState;

	public int _0024var_0024AbnormalStateRate;

	public int _0024var_0024AbnormalStatePower;

	[NonSerialized]
	private MChainSkills ChainSkillId__cache;

	[NonSerialized]
	private static Dictionary<int, MChainSkillEffects> _0024mst_002418 = new Dictionary<int, MChainSkillEffects>();

	[NonSerialized]
	private static MChainSkillEffects[] All_cache;

	public int Id => _0024var_0024Id;

	public string DebugName => _0024var_0024DebugName;

	public MChainSkills ChainSkillId
	{
		get
		{
			if (ChainSkillId__cache == null)
			{
				ChainSkillId__cache = MChainSkills.Get(_0024var_0024ChainSkillId);
			}
			return ChainSkillId__cache;
		}
	}

	public int EmitMode => _0024var_0024EmitMode;

	public float OfsX => _0024var_0024OfsX;

	public float OfsY => _0024var_0024OfsY;

	public float OfsZ => _0024var_0024OfsZ;

	public bool Once => _0024var_0024Once;

	public float Damage => _0024var_0024Damage;

	public YarareTypes YarareType => _0024var_0024YarareType;

	public float KnockBackPow => _0024var_0024KnockBackPow;

	public float EffKillTime => _0024var_0024EffKillTime;

	public bool HasDownHit => _0024var_0024HasDownHit;

	public float PlayerEmitDelay => _0024var_0024PlayerEmitDelay;

	public float PoppetEmitDelay => _0024var_0024PoppetEmitDelay;

	public float DownHitEffectDelay => _0024var_0024DownHitEffectDelay;

	public EnumAbnormalStates AbnormalState => _0024var_0024AbnormalState;

	public int AbnormalStateRate => _0024var_0024AbnormalStateRate;

	public int AbnormalStatePower => _0024var_0024AbnormalStatePower;

	public static MChainSkillEffects[] All
	{
		get
		{
			MChainSkillEffects[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MChainSkillEffects");
				MChainSkillEffects[] array = (MChainSkillEffects[])Builtins.array(typeof(MChainSkillEffects), _0024mst_002418.Values);
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

	public MChainSkillEffects()
	{
		_0024var_0024PlayerEmitDelay = 1.08f;
	}

	public static MChainSkillEffects Find(MChainSkills cs)
	{
		object result;
		if (cs == null)
		{
			result = null;
		}
		else
		{
			int num = 0;
			MChainSkillEffects[] all = All;
			int length = all.Length;
			while (true)
			{
				if (num < length)
				{
					if (RuntimeServices.EqualityOperator(all[num].ChainSkillId, cs))
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
		}
		return (MChainSkillEffects)result;
	}

	public override string ToString()
	{
		return new StringBuilder("MChainSkillEffects(").Append((object)Id).Append(")").ToString();
	}

	public static MChainSkillEffects Get(int _id)
	{
		MerlinMaster.GetHandler("MChainSkillEffects");
		return (!_0024mst_002418.ContainsKey(_id)) ? null : _0024mst_002418[_id];
	}

	public static void Unload()
	{
		_0024mst_002418.Clear();
		All_cache = null;
	}

	public static MChainSkillEffects New(Hashtable data)
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
			MChainSkillEffects mChainSkillEffects = Create(data);
			if (!_0024mst_002418.ContainsKey(mChainSkillEffects.Id))
			{
				_0024mst_002418[mChainSkillEffects.Id] = mChainSkillEffects;
			}
			result = mChainSkillEffects;
		}
		return (MChainSkillEffects)result;
	}

	public static MChainSkillEffects New2(string[] keys, object[] vals)
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
		return (MChainSkillEffects)result;
	}

	public static MChainSkillEffects Entry(MChainSkillEffects mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002418[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MChainSkillEffects)result;
	}

	public static void AddMst(MChainSkillEffects mst)
	{
		if (mst != null)
		{
			_0024mst_002418[mst.Id] = mst;
		}
	}

	public static MChainSkillEffects Create(Hashtable data)
	{
		MChainSkillEffects mChainSkillEffects = new MChainSkillEffects();
		MChainSkillEffects result;
		if (data == null)
		{
			result = mChainSkillEffects;
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
				mChainSkillEffects.setField((string)obj, data[current]);
			}
			result = mChainSkillEffects;
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
		case "DebugName":
			_0024var_0024DebugName = MasterBaseClass.ToStringValue(val);
			break;
		case "ChainSkillId":
			_0024var_0024ChainSkillId = MasterBaseClass.ToInt(val);
			break;
		case "EmitMode":
			_0024var_0024EmitMode = MasterBaseClass.ToInt(val);
			break;
		case "OfsX":
			_0024var_0024OfsX = MasterBaseClass.ToSingle(val);
			break;
		case "OfsY":
			_0024var_0024OfsY = MasterBaseClass.ToSingle(val);
			break;
		case "OfsZ":
			_0024var_0024OfsZ = MasterBaseClass.ToSingle(val);
			break;
		case "Once":
			_0024var_0024Once = MasterBaseClass.ToBool(val);
			break;
		case "Damage":
			_0024var_0024Damage = MasterBaseClass.ToSingle(val);
			break;
		case "YarareType":
			if (typeof(YarareTypes).IsEnum)
			{
				_0024var_0024YarareType = (YarareTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "KnockBackPow":
			_0024var_0024KnockBackPow = MasterBaseClass.ToSingle(val);
			break;
		case "EffKillTime":
			_0024var_0024EffKillTime = MasterBaseClass.ToSingle(val);
			break;
		case "HasDownHit":
			_0024var_0024HasDownHit = MasterBaseClass.ToBool(val);
			break;
		case "PlayerEmitDelay":
			_0024var_0024PlayerEmitDelay = MasterBaseClass.ToSingle(val);
			break;
		case "PoppetEmitDelay":
			_0024var_0024PoppetEmitDelay = MasterBaseClass.ToSingle(val);
			break;
		case "DownHitEffectDelay":
			_0024var_0024DownHitEffectDelay = MasterBaseClass.ToSingle(val);
			break;
		case "AbnormalState":
			if (typeof(EnumAbnormalStates).IsEnum)
			{
				_0024var_0024AbnormalState = (EnumAbnormalStates)MasterBaseClass.ToEnum(val);
			}
			break;
		case "AbnormalStateRate":
			_0024var_0024AbnormalStateRate = MasterBaseClass.ToInt(val);
			break;
		case "AbnormalStatePower":
			_0024var_0024AbnormalStatePower = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"DebugName" => true, 
			"ChainSkillId" => true, 
			"EmitMode" => true, 
			"OfsX" => true, 
			"OfsY" => true, 
			"OfsZ" => true, 
			"Once" => true, 
			"Damage" => true, 
			"YarareType" => true, 
			"KnockBackPow" => true, 
			"EffKillTime" => true, 
			"HasDownHit" => true, 
			"PlayerEmitDelay" => true, 
			"PoppetEmitDelay" => true, 
			"DownHitEffectDelay" => true, 
			"AbnormalState" => true, 
			"AbnormalStateRate" => true, 
			"AbnormalStatePower" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[19]
		{
			"Id", "DebugName", "ChainSkillId", "EmitMode", "OfsX", "OfsY", "OfsZ", "Once", "Damage", "YarareType",
			"KnockBackPow", "EffKillTime", "HasDownHit", "PlayerEmitDelay", "PoppetEmitDelay", "DownHitEffectDelay", "AbnormalState", "AbnormalStateRate", "AbnormalStatePower"
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
					_0024var_0024DebugName = vals[1];
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024ChainSkillId = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024EmitMode = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024OfsX = MasterBaseClass.ParseSingle(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024OfsY = MasterBaseClass.ParseSingle(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024OfsZ = MasterBaseClass.ParseSingle(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024Once = MasterBaseClass.ParseBool(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024Damage = MasterBaseClass.ParseSingle(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null && typeof(YarareTypes).IsEnum)
												{
													_0024var_0024YarareType = (YarareTypes)MasterBaseClass.ParseEnum(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024KnockBackPow = MasterBaseClass.ParseSingle(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024EffKillTime = MasterBaseClass.ParseSingle(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024HasDownHit = MasterBaseClass.ParseBool(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024PlayerEmitDelay = MasterBaseClass.ParseSingle(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024PoppetEmitDelay = MasterBaseClass.ParseSingle(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null)
																		{
																			_0024var_0024DownHitEffectDelay = MasterBaseClass.ParseSingle(vals[15]);
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null && typeof(EnumAbnormalStates).IsEnum)
																			{
																				_0024var_0024AbnormalState = (EnumAbnormalStates)MasterBaseClass.ParseEnum(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null)
																				{
																					_0024var_0024AbnormalStateRate = MasterBaseClass.ParseInt(vals[17]);
																				}
																				if (length <= 18)
																				{
																					result = 18;
																				}
																				else
																				{
																					if (vals[18] != null)
																					{
																						_0024var_0024AbnormalStatePower = MasterBaseClass.ParseInt(vals[18]);
																					}
																					int num = 19;
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
		return result;
	}
}
