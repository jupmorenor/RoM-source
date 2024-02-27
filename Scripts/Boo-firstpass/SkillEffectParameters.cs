using System;
using System.Collections;
using System.Text;
using Boo.Lang.Runtime;
using ParamCalc;

[Serializable]
public class SkillEffectParameters : MasterBaseClass
{
	public int _0024var_0024MSkillEffectTypeId;

	public int _0024var_0024ValueMin;

	public int _0024var_0024ValueMax;

	public float _0024var_0024ValueExp;

	public int _0024var_0024MElementId;

	public int _0024var_0024MElement1Id;

	public int _0024var_0024MElement2Id;

	public int _0024var_0024MStyleId;

	public int _0024var_0024MRaceId;

	public int _0024var_0024UnderHP;

	public int _0024var_0024MAbnormalStateId;

	public int _0024var_0024Count;

	public int _0024var_0024Rate;

	[NonSerialized]
	private MSkillEffectTypes MSkillEffectTypeId__cache;

	[NonSerialized]
	private MElements MElementId__cache;

	[NonSerialized]
	private MElements MElement1Id__cache;

	[NonSerialized]
	private MElements MElement2Id__cache;

	[NonSerialized]
	private MStyles MStyleId__cache;

	[NonSerialized]
	private MRaces MRaceId__cache;

	[NonSerialized]
	private MAbnormalStates MAbnormalStateId__cache;

	public EnumElements Element => (MElementId != null) ? ((EnumElements)MElementId.Id) : ((EnumElements)0);

	public EnumElements ElementPrm1 => (MElement1Id != null) ? ((EnumElements)MElement1Id.Id) : ((EnumElements)0);

	public EnumElements ElementPrm2 => (MElement2Id != null) ? ((EnumElements)MElement2Id.Id) : ((EnumElements)0);

	public EnumStyles Style => (MStyleId != null) ? ((EnumStyles)MStyleId.Id) : EnumStyles.None;

	public EnumRaces Race => (MRaceId != null) ? ((EnumRaces)MRaceId.Id) : ((EnumRaces)0);

	public EnumAbnormalStates AbnormalState => (MAbnormalStateId != null) ? ((EnumAbnormalStates)MAbnormalStateId.Id) : EnumAbnormalStates.None;

	public EnumSkillEffectTypes SkillEffectType => (EnumSkillEffectTypes)(MSkillEffectTypeId?.Id ?? 0);

	public float UnderHPAsRate => (float)UnderHP / 100f;

	public MSkillEffectTypes MSkillEffectTypeId
	{
		get
		{
			if (MSkillEffectTypeId__cache == null)
			{
				MSkillEffectTypeId__cache = MSkillEffectTypes.Get(_0024var_0024MSkillEffectTypeId);
			}
			return MSkillEffectTypeId__cache;
		}
	}

	public int ValueMin => _0024var_0024ValueMin;

	public int ValueMax => _0024var_0024ValueMax;

	public float ValueExp => _0024var_0024ValueExp;

	public MElements MElementId
	{
		get
		{
			if (MElementId__cache == null)
			{
				MElementId__cache = MElements.Get(_0024var_0024MElementId);
			}
			return MElementId__cache;
		}
	}

	public MElements MElement1Id
	{
		get
		{
			if (MElement1Id__cache == null)
			{
				MElement1Id__cache = MElements.Get(_0024var_0024MElement1Id);
			}
			return MElement1Id__cache;
		}
	}

	public MElements MElement2Id
	{
		get
		{
			if (MElement2Id__cache == null)
			{
				MElement2Id__cache = MElements.Get(_0024var_0024MElement2Id);
			}
			return MElement2Id__cache;
		}
	}

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

	public MRaces MRaceId
	{
		get
		{
			if (MRaceId__cache == null)
			{
				MRaceId__cache = MRaces.Get(_0024var_0024MRaceId);
			}
			return MRaceId__cache;
		}
	}

	public int UnderHP => _0024var_0024UnderHP;

	public MAbnormalStates MAbnormalStateId
	{
		get
		{
			if (MAbnormalStateId__cache == null)
			{
				MAbnormalStateId__cache = MAbnormalStates.Get(_0024var_0024MAbnormalStateId);
			}
			return MAbnormalStateId__cache;
		}
	}

	public int Count => _0024var_0024Count;

	public int Rate => _0024var_0024Rate;

	public float getEffectValue(int level, int levelMax, string msg)
	{
		return ParamCalcModule.ComputeGrowth(level, levelMax, ValueMin, ValueMax, ValueExp, msg);
	}

	public float getEffectValueAsRate(int level, int levelMax, string msg)
	{
		return getEffectValue(level, levelMax, msg) / 100f;
	}

	public override string ToString()
	{
		return new StringBuilder("SkillEffectParameters - ").Append(MSkillEffectTypeId).ToString();
	}

	public static SkillEffectParameters Create(Hashtable data)
	{
		SkillEffectParameters skillEffectParameters = new SkillEffectParameters();
		SkillEffectParameters result;
		if (data == null)
		{
			result = skillEffectParameters;
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
				skillEffectParameters.setField((string)obj, data[current]);
			}
			result = skillEffectParameters;
		}
		return result;
	}

	public void setField(string key, object val)
	{
		switch (key)
		{
		case "MSkillEffectTypeId":
			_0024var_0024MSkillEffectTypeId = MasterBaseClass.ToInt(val);
			break;
		case "ValueMin":
			_0024var_0024ValueMin = MasterBaseClass.ToInt(val);
			break;
		case "ValueMax":
			_0024var_0024ValueMax = MasterBaseClass.ToInt(val);
			break;
		case "ValueExp":
			_0024var_0024ValueExp = MasterBaseClass.ToSingle(val);
			break;
		case "MElementId":
			_0024var_0024MElementId = MasterBaseClass.ToInt(val);
			break;
		case "MElement1Id":
			_0024var_0024MElement1Id = MasterBaseClass.ToInt(val);
			break;
		case "MElement2Id":
			_0024var_0024MElement2Id = MasterBaseClass.ToInt(val);
			break;
		case "MStyleId":
			_0024var_0024MStyleId = MasterBaseClass.ToInt(val);
			break;
		case "MRaceId":
			_0024var_0024MRaceId = MasterBaseClass.ToInt(val);
			break;
		case "UnderHP":
			_0024var_0024UnderHP = MasterBaseClass.ToInt(val);
			break;
		case "MAbnormalStateId":
			_0024var_0024MAbnormalStateId = MasterBaseClass.ToInt(val);
			break;
		case "Count":
			_0024var_0024Count = MasterBaseClass.ToInt(val);
			break;
		case "Rate":
			_0024var_0024Rate = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"MSkillEffectTypeId" => true, 
			"ValueMin" => true, 
			"ValueMax" => true, 
			"ValueExp" => true, 
			"MElementId" => true, 
			"MElement1Id" => true, 
			"MElement2Id" => true, 
			"MStyleId" => true, 
			"MRaceId" => true, 
			"UnderHP" => true, 
			"MAbnormalStateId" => true, 
			"Count" => true, 
			"Rate" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[13]
		{
			"MSkillEffectTypeId", "ValueMin", "ValueMax", "ValueExp", "MElementId", "MElement1Id", "MElement2Id", "MStyleId", "MRaceId", "UnderHP",
			"MAbnormalStateId", "Count", "Rate"
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
				_0024var_0024MSkillEffectTypeId = MasterBaseClass.ParseInt(vals[0]);
			}
			if (length <= 1)
			{
				result = 1;
			}
			else
			{
				if (vals[1] != null)
				{
					_0024var_0024ValueMin = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024ValueMax = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024ValueExp = MasterBaseClass.ParseSingle(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024MElementId = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024MElement1Id = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024MElement2Id = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024MStyleId = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024MRaceId = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024UnderHP = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024MAbnormalStateId = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024Count = MasterBaseClass.ParseInt(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024Rate = MasterBaseClass.ParseInt(vals[12]);
															}
															int num = 13;
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
		return result;
	}
}
