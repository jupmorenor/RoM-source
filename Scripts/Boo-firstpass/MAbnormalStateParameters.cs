using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MAbnormalStateParameters : MerlinMaster
{
	public int _0024var_0024Id;

	public EnumAbnormalStates _0024var_0024Effect;

	public int _0024var_0024SetupType;

	public float _0024var_0024Time;

	public int _0024var_0024Speed;

	public int _0024var_0024DecLife;

	public int _0024var_0024Attack;

	public int _0024var_0024Damage;

	public int _0024var_0024Size;

	public int _0024var_0024EmitCond;

	public string _0024var_0024Prefab;

	public string _0024var_0024MonsterPrefab;

	public string _0024var_0024ParentBone;

	public int _0024var_0024EmitSource;

	public bool _0024var_0024EndEmit;

	public int _0024var_0024MotionSpeed;

	public bool _0024var_0024PlayYarare;

	public bool _0024var_0024Anger;

	public bool _0024var_0024DisableMove;

	public bool _0024var_0024DisableAttack;

	public bool _0024var_0024DisableChain;

	public bool _0024var_0024DisableSkill;

	public bool _0024var_0024MonsterBlind;

	public bool _0024var_0024SimpleAttack;

	[NonSerialized]
	private static Dictionary<int, MAbnormalStateParameters> _0024mst_002434 = new Dictionary<int, MAbnormalStateParameters>();

	[NonSerialized]
	private static MAbnormalStateParameters[] All_cache;

	public bool HasPrefab => !string.IsNullOrEmpty(Prefab);

	public int Id => _0024var_0024Id;

	public EnumAbnormalStates Effect => _0024var_0024Effect;

	public int SetupType => _0024var_0024SetupType;

	public float Time => _0024var_0024Time;

	public int Speed => _0024var_0024Speed;

	public int DecLife => _0024var_0024DecLife;

	public int Attack => _0024var_0024Attack;

	public int Damage => _0024var_0024Damage;

	public int Size => _0024var_0024Size;

	public int EmitCond => _0024var_0024EmitCond;

	public string Prefab => _0024var_0024Prefab;

	public string MonsterPrefab => _0024var_0024MonsterPrefab;

	public string ParentBone => _0024var_0024ParentBone;

	public int EmitSource => _0024var_0024EmitSource;

	public bool EndEmit => _0024var_0024EndEmit;

	public int MotionSpeed => _0024var_0024MotionSpeed;

	public bool PlayYarare => _0024var_0024PlayYarare;

	public bool Anger => _0024var_0024Anger;

	public bool DisableMove => _0024var_0024DisableMove;

	public bool DisableAttack => _0024var_0024DisableAttack;

	public bool DisableChain => _0024var_0024DisableChain;

	public bool DisableSkill => _0024var_0024DisableSkill;

	public bool MonsterBlind => _0024var_0024MonsterBlind;

	public bool SimpleAttack => _0024var_0024SimpleAttack;

	public static MAbnormalStateParameters[] All
	{
		get
		{
			MAbnormalStateParameters[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MAbnormalStateParameters");
				MAbnormalStateParameters[] array = (MAbnormalStateParameters[])Builtins.array(typeof(MAbnormalStateParameters), _0024mst_002434.Values);
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

	public static MAbnormalStateParameters Find(EnumAbnormalStates ef, int setupType)
	{
		int num = 0;
		MAbnormalStateParameters[] all = All;
		int length = all.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (all[num].SetupType == setupType && all[num].Effect == ef)
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
		return (MAbnormalStateParameters)result;
	}

	public override string ToString()
	{
		return new StringBuilder("MAbnormalStateParameters(").Append((object)Id).Append(",").Append(Effect)
			.Append(",")
			.Append((object)SetupType)
			.Append(")")
			.ToString();
	}

	public static MAbnormalStateParameters Get(int _id)
	{
		MerlinMaster.GetHandler("MAbnormalStateParameters");
		return (!_0024mst_002434.ContainsKey(_id)) ? null : _0024mst_002434[_id];
	}

	public static void Unload()
	{
		_0024mst_002434.Clear();
		All_cache = null;
	}

	public static MAbnormalStateParameters New(Hashtable data)
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
			MAbnormalStateParameters mAbnormalStateParameters = Create(data);
			if (!_0024mst_002434.ContainsKey(mAbnormalStateParameters.Id))
			{
				_0024mst_002434[mAbnormalStateParameters.Id] = mAbnormalStateParameters;
			}
			result = mAbnormalStateParameters;
		}
		return (MAbnormalStateParameters)result;
	}

	public static MAbnormalStateParameters New2(string[] keys, object[] vals)
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
		return (MAbnormalStateParameters)result;
	}

	public static MAbnormalStateParameters Entry(MAbnormalStateParameters mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002434[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MAbnormalStateParameters)result;
	}

	public static void AddMst(MAbnormalStateParameters mst)
	{
		if (mst != null)
		{
			_0024mst_002434[mst.Id] = mst;
		}
	}

	public static MAbnormalStateParameters Create(Hashtable data)
	{
		MAbnormalStateParameters mAbnormalStateParameters = new MAbnormalStateParameters();
		MAbnormalStateParameters result;
		if (data == null)
		{
			result = mAbnormalStateParameters;
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
				mAbnormalStateParameters.setField((string)obj, data[current]);
			}
			result = mAbnormalStateParameters;
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
		case "Effect":
			if (typeof(EnumAbnormalStates).IsEnum)
			{
				_0024var_0024Effect = (EnumAbnormalStates)MasterBaseClass.ToEnum(val);
			}
			break;
		case "SetupType":
			_0024var_0024SetupType = MasterBaseClass.ToInt(val);
			break;
		case "Time":
			_0024var_0024Time = MasterBaseClass.ToSingle(val);
			break;
		case "Speed":
			_0024var_0024Speed = MasterBaseClass.ToInt(val);
			break;
		case "DecLife":
			_0024var_0024DecLife = MasterBaseClass.ToInt(val);
			break;
		case "Attack":
			_0024var_0024Attack = MasterBaseClass.ToInt(val);
			break;
		case "Damage":
			_0024var_0024Damage = MasterBaseClass.ToInt(val);
			break;
		case "Size":
			_0024var_0024Size = MasterBaseClass.ToInt(val);
			break;
		case "EmitCond":
			_0024var_0024EmitCond = MasterBaseClass.ToInt(val);
			break;
		case "Prefab":
			_0024var_0024Prefab = MasterBaseClass.ToStringValue(val);
			break;
		case "MonsterPrefab":
			_0024var_0024MonsterPrefab = MasterBaseClass.ToStringValue(val);
			break;
		case "ParentBone":
			_0024var_0024ParentBone = MasterBaseClass.ToStringValue(val);
			break;
		case "EmitSource":
			_0024var_0024EmitSource = MasterBaseClass.ToInt(val);
			break;
		case "EndEmit":
			_0024var_0024EndEmit = MasterBaseClass.ToBool(val);
			break;
		case "MotionSpeed":
			_0024var_0024MotionSpeed = MasterBaseClass.ToInt(val);
			break;
		case "PlayYarare":
			_0024var_0024PlayYarare = MasterBaseClass.ToBool(val);
			break;
		case "Anger":
			_0024var_0024Anger = MasterBaseClass.ToBool(val);
			break;
		case "DisableMove":
			_0024var_0024DisableMove = MasterBaseClass.ToBool(val);
			break;
		case "DisableAttack":
			_0024var_0024DisableAttack = MasterBaseClass.ToBool(val);
			break;
		case "DisableChain":
			_0024var_0024DisableChain = MasterBaseClass.ToBool(val);
			break;
		case "DisableSkill":
			_0024var_0024DisableSkill = MasterBaseClass.ToBool(val);
			break;
		case "MonsterBlind":
			_0024var_0024MonsterBlind = MasterBaseClass.ToBool(val);
			break;
		case "SimpleAttack":
			_0024var_0024SimpleAttack = MasterBaseClass.ToBool(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Effect" => true, 
			"SetupType" => true, 
			"Time" => true, 
			"Speed" => true, 
			"DecLife" => true, 
			"Attack" => true, 
			"Damage" => true, 
			"Size" => true, 
			"EmitCond" => true, 
			"Prefab" => true, 
			"MonsterPrefab" => true, 
			"ParentBone" => true, 
			"EmitSource" => true, 
			"EndEmit" => true, 
			"MotionSpeed" => true, 
			"PlayYarare" => true, 
			"Anger" => true, 
			"DisableMove" => true, 
			"DisableAttack" => true, 
			"DisableChain" => true, 
			"DisableSkill" => true, 
			"MonsterBlind" => true, 
			"SimpleAttack" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[24]
		{
			"Id", "Effect", "SetupType", "Time", "Speed", "DecLife", "Attack", "Damage", "Size", "EmitCond",
			"Prefab", "MonsterPrefab", "ParentBone", "EmitSource", "EndEmit", "MotionSpeed", "PlayYarare", "Anger", "DisableMove", "DisableAttack",
			"DisableChain", "DisableSkill", "MonsterBlind", "SimpleAttack"
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
				if (vals[1] != null && typeof(EnumAbnormalStates).IsEnum)
				{
					_0024var_0024Effect = (EnumAbnormalStates)MasterBaseClass.ParseEnum(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024SetupType = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Time = MasterBaseClass.ParseSingle(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024Speed = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024DecLife = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024Attack = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024Damage = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024Size = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024EmitCond = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024Prefab = vals[10];
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024MonsterPrefab = vals[11];
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024ParentBone = vals[12];
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024EmitSource = MasterBaseClass.ParseInt(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024EndEmit = MasterBaseClass.ParseBool(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null)
																		{
																			_0024var_0024MotionSpeed = MasterBaseClass.ParseInt(vals[15]);
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null)
																			{
																				_0024var_0024PlayYarare = MasterBaseClass.ParseBool(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null)
																				{
																					_0024var_0024Anger = MasterBaseClass.ParseBool(vals[17]);
																				}
																				if (length <= 18)
																				{
																					result = 18;
																				}
																				else
																				{
																					if (vals[18] != null)
																					{
																						_0024var_0024DisableMove = MasterBaseClass.ParseBool(vals[18]);
																					}
																					if (length <= 19)
																					{
																						result = 19;
																					}
																					else
																					{
																						if (vals[19] != null)
																						{
																							_0024var_0024DisableAttack = MasterBaseClass.ParseBool(vals[19]);
																						}
																						if (length <= 20)
																						{
																							result = 20;
																						}
																						else
																						{
																							if (vals[20] != null)
																							{
																								_0024var_0024DisableChain = MasterBaseClass.ParseBool(vals[20]);
																							}
																							if (length <= 21)
																							{
																								result = 21;
																							}
																							else
																							{
																								if (vals[21] != null)
																								{
																									_0024var_0024DisableSkill = MasterBaseClass.ParseBool(vals[21]);
																								}
																								if (length <= 22)
																								{
																									result = 22;
																								}
																								else
																								{
																									if (vals[22] != null)
																									{
																										_0024var_0024MonsterBlind = MasterBaseClass.ParseBool(vals[22]);
																									}
																									if (length <= 23)
																									{
																										result = 23;
																									}
																									else
																									{
																										if (vals[23] != null)
																										{
																											_0024var_0024SimpleAttack = MasterBaseClass.ParseBool(vals[23]);
																										}
																										int num = 24;
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
		return result;
	}
}
