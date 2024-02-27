using System;
using System.Collections;
using System.Text;
using Boo.Lang.Runtime;
using ParamCalc;

[Serializable]
public class BasicBattleParameters : MasterBaseClass
{
	public int _0024var_0024ExpMin;

	public int _0024var_0024ExpMax;

	public float _0024var_0024ExpExp;

	public int _0024var_0024AttackMin;

	public int _0024var_0024AttackMax;

	public float _0024var_0024AttackExp;

	public int _0024var_0024HpMin;

	public int _0024var_0024HpMax;

	public float _0024var_0024HpExp;

	public int _0024var_0024CriticalMin;

	public int _0024var_0024CriticalMax;

	public float _0024var_0024CriticalExp;

	public int _0024var_0024BreakMin;

	public int _0024var_0024BreakMax;

	public float _0024var_0024BreakExp;

	public int _0024var_0024ResistMin;

	public int _0024var_0024ResistMax;

	public float _0024var_0024ResistExp;

	public int ExpMin => _0024var_0024ExpMin;

	public int ExpMax => _0024var_0024ExpMax;

	public float ExpExp => _0024var_0024ExpExp;

	public int AttackMin => _0024var_0024AttackMin;

	public int AttackMax => _0024var_0024AttackMax;

	public float AttackExp => _0024var_0024AttackExp;

	public int HpMin => _0024var_0024HpMin;

	public int HpMax => _0024var_0024HpMax;

	public float HpExp => _0024var_0024HpExp;

	public int CriticalMin => _0024var_0024CriticalMin;

	public int CriticalMax => _0024var_0024CriticalMax;

	public float CriticalExp => _0024var_0024CriticalExp;

	public int BreakMin => _0024var_0024BreakMin;

	public int BreakMax => _0024var_0024BreakMax;

	public float BreakExp => _0024var_0024BreakExp;

	public int ResistMin => _0024var_0024ResistMin;

	public int ResistMax => _0024var_0024ResistMax;

	public float ResistExp => _0024var_0024ResistExp;

	public BasicBattleParameters()
	{
		_0024var_0024AttackMin = 1;
		_0024var_0024AttackMax = 10;
		_0024var_0024AttackExp = 1f;
		_0024var_0024HpMin = 1;
		_0024var_0024HpMax = 10;
		_0024var_0024HpExp = 1f;
		_0024var_0024CriticalMin = 1;
		_0024var_0024CriticalMax = 10;
		_0024var_0024CriticalExp = 1f;
		_0024var_0024BreakMin = 1;
		_0024var_0024BreakMax = 10;
		_0024var_0024BreakExp = 1f;
		_0024var_0024ResistMin = 1;
		_0024var_0024ResistMax = 10;
		_0024var_0024ResistExp = 1f;
	}

	public int exp(int level, int levelMax, string msg)
	{
		return ParamCalcModule.ComputeGrowthInt(level, levelMax, ExpMin, ExpMax, ExpExp, msg);
	}

	public int attack(int level, int levelMax, string msg)
	{
		return ParamCalcModule.ComputeGrowthInt(level, levelMax, AttackMin, AttackMax, AttackExp, msg);
	}

	public int hp(int level, int levelMax, string msg)
	{
		return ParamCalcModule.ComputeGrowthInt(level, levelMax, HpMin, HpMax, HpExp, msg);
	}

	public int critical(int level, int levelMax, string msg)
	{
		return ParamCalcModule.ComputeGrowthInt(level, levelMax, CriticalMin, CriticalMax, CriticalExp, msg);
	}

	public int breakPow(int level, int levelMax, string msg)
	{
		return ParamCalcModule.ComputeGrowthInt(level, levelMax, BreakMin, BreakMax, BreakExp, msg);
	}

	public int resist(int level, int levelMax, string msg)
	{
		return ParamCalcModule.ComputeGrowthInt(level, levelMax, ResistMin, ResistMax, ResistExp, msg);
	}

	public override string ToString()
	{
		return new StringBuilder("attack:").Append((object)AttackMin).Append(",").Append((object)AttackMax)
			.Append(",")
			.Append(AttackExp)
			.Append(" ")
			.ToString() + new StringBuilder("hp:").Append((object)HpMin).Append(",").Append((object)HpMax)
			.Append(",")
			.Append(HpExp)
			.Append(" ")
			.ToString() + new StringBuilder("critical:").Append((object)CriticalMin).Append(",").Append((object)CriticalMax)
			.Append(",")
			.Append(CriticalExp)
			.Append(" ")
			.ToString() + new StringBuilder("break:").Append((object)BreakMin).Append(",").Append((object)BreakMax)
			.Append(",")
			.Append(BreakExp)
			.Append(" ")
			.ToString() + new StringBuilder("resist:").Append((object)ResistMin).Append(",").Append((object)ResistMax)
			.Append(",")
			.Append(ResistExp)
			.Append(" ")
			.ToString();
	}

	public static BasicBattleParameters Create(Hashtable data)
	{
		BasicBattleParameters basicBattleParameters = new BasicBattleParameters();
		BasicBattleParameters result;
		if (data == null)
		{
			result = basicBattleParameters;
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
				basicBattleParameters.setField((string)obj, data[current]);
			}
			result = basicBattleParameters;
		}
		return result;
	}

	public void setField(string key, object val)
	{
		switch (key)
		{
		case "ExpMin":
			_0024var_0024ExpMin = MasterBaseClass.ToInt(val);
			break;
		case "ExpMax":
			_0024var_0024ExpMax = MasterBaseClass.ToInt(val);
			break;
		case "ExpExp":
			_0024var_0024ExpExp = MasterBaseClass.ToSingle(val);
			break;
		case "AttackMin":
			_0024var_0024AttackMin = MasterBaseClass.ToInt(val);
			break;
		case "AttackMax":
			_0024var_0024AttackMax = MasterBaseClass.ToInt(val);
			break;
		case "AttackExp":
			_0024var_0024AttackExp = MasterBaseClass.ToSingle(val);
			break;
		case "HpMin":
			_0024var_0024HpMin = MasterBaseClass.ToInt(val);
			break;
		case "HpMax":
			_0024var_0024HpMax = MasterBaseClass.ToInt(val);
			break;
		case "HpExp":
			_0024var_0024HpExp = MasterBaseClass.ToSingle(val);
			break;
		case "CriticalMin":
			_0024var_0024CriticalMin = MasterBaseClass.ToInt(val);
			break;
		case "CriticalMax":
			_0024var_0024CriticalMax = MasterBaseClass.ToInt(val);
			break;
		case "CriticalExp":
			_0024var_0024CriticalExp = MasterBaseClass.ToSingle(val);
			break;
		case "BreakMin":
			_0024var_0024BreakMin = MasterBaseClass.ToInt(val);
			break;
		case "BreakMax":
			_0024var_0024BreakMax = MasterBaseClass.ToInt(val);
			break;
		case "BreakExp":
			_0024var_0024BreakExp = MasterBaseClass.ToSingle(val);
			break;
		case "ResistMin":
			_0024var_0024ResistMin = MasterBaseClass.ToInt(val);
			break;
		case "ResistMax":
			_0024var_0024ResistMax = MasterBaseClass.ToInt(val);
			break;
		case "ResistExp":
			_0024var_0024ResistExp = MasterBaseClass.ToSingle(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"ExpMin" => true, 
			"ExpMax" => true, 
			"ExpExp" => true, 
			"AttackMin" => true, 
			"AttackMax" => true, 
			"AttackExp" => true, 
			"HpMin" => true, 
			"HpMax" => true, 
			"HpExp" => true, 
			"CriticalMin" => true, 
			"CriticalMax" => true, 
			"CriticalExp" => true, 
			"BreakMin" => true, 
			"BreakMax" => true, 
			"BreakExp" => true, 
			"ResistMin" => true, 
			"ResistMax" => true, 
			"ResistExp" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[18]
		{
			"ExpMin", "ExpMax", "ExpExp", "AttackMin", "AttackMax", "AttackExp", "HpMin", "HpMax", "HpExp", "CriticalMin",
			"CriticalMax", "CriticalExp", "BreakMin", "BreakMax", "BreakExp", "ResistMin", "ResistMax", "ResistExp"
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
				_0024var_0024ExpMin = MasterBaseClass.ParseInt(vals[0]);
			}
			if (length <= 1)
			{
				result = 1;
			}
			else
			{
				if (vals[1] != null)
				{
					_0024var_0024ExpMax = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024ExpExp = MasterBaseClass.ParseSingle(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024AttackMin = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024AttackMax = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024AttackExp = MasterBaseClass.ParseSingle(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024HpMin = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024HpMax = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024HpExp = MasterBaseClass.ParseSingle(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024CriticalMin = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024CriticalMax = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024CriticalExp = MasterBaseClass.ParseSingle(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024BreakMin = MasterBaseClass.ParseInt(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024BreakMax = MasterBaseClass.ParseInt(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024BreakExp = MasterBaseClass.ParseSingle(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null)
																		{
																			_0024var_0024ResistMin = MasterBaseClass.ParseInt(vals[15]);
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null)
																			{
																				_0024var_0024ResistMax = MasterBaseClass.ParseInt(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null)
																				{
																					_0024var_0024ResistExp = MasterBaseClass.ParseSingle(vals[17]);
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
