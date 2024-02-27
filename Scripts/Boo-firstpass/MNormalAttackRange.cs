using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MNormalAttackRange : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MStyleId;

	public string _0024var_0024RunAttack_Name;

	public int _0024var_0024RunAttack_Index;

	public float _0024var_0024RunAttack_Move;

	public float _0024var_0024RunAttack_Range;

	public string _0024var_0024Attack1_Name;

	public int _0024var_0024Attack1_Index;

	public float _0024var_0024Attack1_Move;

	public float _0024var_0024Attack1_Range;

	public string _0024var_0024Attack2_Name;

	public int _0024var_0024Attack2_Index;

	public float _0024var_0024Attack2_Move;

	public float _0024var_0024Attack2_Range;

	public string _0024var_0024Attack3_Name;

	public int _0024var_0024Attack3_Index;

	public float _0024var_0024Attack3_Move;

	public float _0024var_0024Attack3_Range;

	public string _0024var_0024Attack4_Name;

	public int _0024var_0024Attack4_Index;

	public float _0024var_0024Attack4_Move;

	public float _0024var_0024Attack4_Range;

	[NonSerialized]
	private MStyles MStyleId__cache;

	[NonSerialized]
	private static Dictionary<int, MNormalAttackRange> _0024mst_0024130 = new Dictionary<int, MNormalAttackRange>();

	[NonSerialized]
	private static MNormalAttackRange[] All_cache;

	public int Id => _0024var_0024Id;

	public MStyles MStyleId
	{
		get
		{
			if (MStyleId__cache == null)
			{
				MStyleId__cache = MStyles.Get(_0024var_0024MStyleId);
			}
			return MStyleId__cache;
		}
	}

	public string RunAttack_Name => _0024var_0024RunAttack_Name;

	public int RunAttack_Index => _0024var_0024RunAttack_Index;

	public float RunAttack_Move => _0024var_0024RunAttack_Move;

	public float RunAttack_Range => _0024var_0024RunAttack_Range;

	public string Attack1_Name => _0024var_0024Attack1_Name;

	public int Attack1_Index => _0024var_0024Attack1_Index;

	public float Attack1_Move => _0024var_0024Attack1_Move;

	public float Attack1_Range => _0024var_0024Attack1_Range;

	public string Attack2_Name => _0024var_0024Attack2_Name;

	public int Attack2_Index => _0024var_0024Attack2_Index;

	public float Attack2_Move => _0024var_0024Attack2_Move;

	public float Attack2_Range => _0024var_0024Attack2_Range;

	public string Attack3_Name => _0024var_0024Attack3_Name;

	public int Attack3_Index => _0024var_0024Attack3_Index;

	public float Attack3_Move => _0024var_0024Attack3_Move;

	public float Attack3_Range => _0024var_0024Attack3_Range;

	public string Attack4_Name => _0024var_0024Attack4_Name;

	public int Attack4_Index => _0024var_0024Attack4_Index;

	public float Attack4_Move => _0024var_0024Attack4_Move;

	public float Attack4_Range => _0024var_0024Attack4_Range;

	public static MNormalAttackRange[] All
	{
		get
		{
			MNormalAttackRange[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MNormalAttackRange");
				MNormalAttackRange[] array = (MNormalAttackRange[])Builtins.array(typeof(MNormalAttackRange), _0024mst_0024130.Values);
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

	public override string ToString()
	{
		return new StringBuilder("MNormalAttackRange(").Append((object)Id).Append(",").Append(MStyleId)
			.Append(",")
			.Append(RunAttack_Name)
			.Append(",&{RunAttack_Index},")
			.Append(RunAttack_Move)
			.Append(",")
			.Append(RunAttack_Range)
			.Append(",")
			.Append(Attack1_Name)
			.Append(",")
			.Append((object)Attack1_Index)
			.Append(",")
			.Append(Attack1_Move)
			.Append(",")
			.Append(Attack1_Range)
			.Append(",")
			.Append(Attack2_Name)
			.Append(",")
			.Append((object)Attack2_Index)
			.Append(",")
			.Append(Attack2_Move)
			.Append(",")
			.Append(Attack2_Range)
			.Append(",")
			.Append(Attack3_Name)
			.Append(",")
			.Append((object)Attack3_Index)
			.Append(",")
			.Append(Attack3_Move)
			.Append(",")
			.Append(Attack3_Range)
			.Append(",")
			.Append(Attack4_Name)
			.Append(",")
			.Append((object)Attack4_Index)
			.Append(",")
			.Append(Attack4_Move)
			.Append(",")
			.Append(Attack4_Range)
			.Append(")")
			.ToString();
	}

	public static MNormalAttackRange FindByStyleId(MStyles styleID)
	{
		int num = 0;
		MNormalAttackRange[] all = All;
		int length = all.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (RuntimeServices.EqualityOperator(all[num].MStyleId, styleID))
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
		return (MNormalAttackRange)result;
	}

	public static MNormalAttackRange Get(int _id)
	{
		MerlinMaster.GetHandler("MNormalAttackRange");
		return (!_0024mst_0024130.ContainsKey(_id)) ? null : _0024mst_0024130[_id];
	}

	public static void Unload()
	{
		_0024mst_0024130.Clear();
		All_cache = null;
	}

	public static MNormalAttackRange New(Hashtable data)
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
			MNormalAttackRange mNormalAttackRange = Create(data);
			if (!_0024mst_0024130.ContainsKey(mNormalAttackRange.Id))
			{
				_0024mst_0024130[mNormalAttackRange.Id] = mNormalAttackRange;
			}
			result = mNormalAttackRange;
		}
		return (MNormalAttackRange)result;
	}

	public static MNormalAttackRange New2(string[] keys, object[] vals)
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
		return (MNormalAttackRange)result;
	}

	public static MNormalAttackRange Entry(MNormalAttackRange mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024130[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MNormalAttackRange)result;
	}

	public static void AddMst(MNormalAttackRange mst)
	{
		if (mst != null)
		{
			_0024mst_0024130[mst.Id] = mst;
		}
	}

	public static MNormalAttackRange Create(Hashtable data)
	{
		MNormalAttackRange mNormalAttackRange = new MNormalAttackRange();
		MNormalAttackRange result;
		if (data == null)
		{
			result = mNormalAttackRange;
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
				mNormalAttackRange.setField((string)obj, data[current]);
			}
			result = mNormalAttackRange;
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
		case "MStyleId":
			_0024var_0024MStyleId = MasterBaseClass.ToInt(val);
			break;
		case "RunAttack_Name":
			_0024var_0024RunAttack_Name = MasterBaseClass.ToStringValue(val);
			break;
		case "RunAttack_Index":
			_0024var_0024RunAttack_Index = MasterBaseClass.ToInt(val);
			break;
		case "RunAttack_Move":
			_0024var_0024RunAttack_Move = MasterBaseClass.ToSingle(val);
			break;
		case "RunAttack_Range":
			_0024var_0024RunAttack_Range = MasterBaseClass.ToSingle(val);
			break;
		case "Attack1_Name":
			_0024var_0024Attack1_Name = MasterBaseClass.ToStringValue(val);
			break;
		case "Attack1_Index":
			_0024var_0024Attack1_Index = MasterBaseClass.ToInt(val);
			break;
		case "Attack1_Move":
			_0024var_0024Attack1_Move = MasterBaseClass.ToSingle(val);
			break;
		case "Attack1_Range":
			_0024var_0024Attack1_Range = MasterBaseClass.ToSingle(val);
			break;
		case "Attack2_Name":
			_0024var_0024Attack2_Name = MasterBaseClass.ToStringValue(val);
			break;
		case "Attack2_Index":
			_0024var_0024Attack2_Index = MasterBaseClass.ToInt(val);
			break;
		case "Attack2_Move":
			_0024var_0024Attack2_Move = MasterBaseClass.ToSingle(val);
			break;
		case "Attack2_Range":
			_0024var_0024Attack2_Range = MasterBaseClass.ToSingle(val);
			break;
		case "Attack3_Name":
			_0024var_0024Attack3_Name = MasterBaseClass.ToStringValue(val);
			break;
		case "Attack3_Index":
			_0024var_0024Attack3_Index = MasterBaseClass.ToInt(val);
			break;
		case "Attack3_Move":
			_0024var_0024Attack3_Move = MasterBaseClass.ToSingle(val);
			break;
		case "Attack3_Range":
			_0024var_0024Attack3_Range = MasterBaseClass.ToSingle(val);
			break;
		case "Attack4_Name":
			_0024var_0024Attack4_Name = MasterBaseClass.ToStringValue(val);
			break;
		case "Attack4_Index":
			_0024var_0024Attack4_Index = MasterBaseClass.ToInt(val);
			break;
		case "Attack4_Move":
			_0024var_0024Attack4_Move = MasterBaseClass.ToSingle(val);
			break;
		case "Attack4_Range":
			_0024var_0024Attack4_Range = MasterBaseClass.ToSingle(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"MStyleId" => true, 
			"RunAttack_Name" => true, 
			"RunAttack_Index" => true, 
			"RunAttack_Move" => true, 
			"RunAttack_Range" => true, 
			"Attack1_Name" => true, 
			"Attack1_Index" => true, 
			"Attack1_Move" => true, 
			"Attack1_Range" => true, 
			"Attack2_Name" => true, 
			"Attack2_Index" => true, 
			"Attack2_Move" => true, 
			"Attack2_Range" => true, 
			"Attack3_Name" => true, 
			"Attack3_Index" => true, 
			"Attack3_Move" => true, 
			"Attack3_Range" => true, 
			"Attack4_Name" => true, 
			"Attack4_Index" => true, 
			"Attack4_Move" => true, 
			"Attack4_Range" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[22]
		{
			"Id", "MStyleId", "RunAttack_Name", "RunAttack_Index", "RunAttack_Move", "RunAttack_Range", "Attack1_Name", "Attack1_Index", "Attack1_Move", "Attack1_Range",
			"Attack2_Name", "Attack2_Index", "Attack2_Move", "Attack2_Range", "Attack3_Name", "Attack3_Index", "Attack3_Move", "Attack3_Range", "Attack4_Name", "Attack4_Index",
			"Attack4_Move", "Attack4_Range"
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
					_0024var_0024MStyleId = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024RunAttack_Name = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024RunAttack_Index = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024RunAttack_Move = MasterBaseClass.ParseSingle(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024RunAttack_Range = MasterBaseClass.ParseSingle(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024Attack1_Name = vals[6];
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024Attack1_Index = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024Attack1_Move = MasterBaseClass.ParseSingle(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024Attack1_Range = MasterBaseClass.ParseSingle(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024Attack2_Name = vals[10];
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024Attack2_Index = MasterBaseClass.ParseInt(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024Attack2_Move = MasterBaseClass.ParseSingle(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024Attack2_Range = MasterBaseClass.ParseSingle(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024Attack3_Name = vals[14];
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null)
																		{
																			_0024var_0024Attack3_Index = MasterBaseClass.ParseInt(vals[15]);
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null)
																			{
																				_0024var_0024Attack3_Move = MasterBaseClass.ParseSingle(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null)
																				{
																					_0024var_0024Attack3_Range = MasterBaseClass.ParseSingle(vals[17]);
																				}
																				if (length <= 18)
																				{
																					result = 18;
																				}
																				else
																				{
																					if (vals[18] != null)
																					{
																						_0024var_0024Attack4_Name = vals[18];
																					}
																					if (length <= 19)
																					{
																						result = 19;
																					}
																					else
																					{
																						if (vals[19] != null)
																						{
																							_0024var_0024Attack4_Index = MasterBaseClass.ParseInt(vals[19]);
																						}
																						if (length <= 20)
																						{
																							result = 20;
																						}
																						else
																						{
																							if (vals[20] != null)
																							{
																								_0024var_0024Attack4_Move = MasterBaseClass.ParseSingle(vals[20]);
																							}
																							if (length <= 21)
																							{
																								result = 21;
																							}
																							else
																							{
																								if (vals[21] != null)
																								{
																									_0024var_0024Attack4_Range = MasterBaseClass.ParseSingle(vals[21]);
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
