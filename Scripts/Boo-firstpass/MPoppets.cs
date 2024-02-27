using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using ParamCalc;

[Serializable]
public class MPoppets : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public string _0024var_0024PrefabName;

	public string _0024var_0024Icon;

	public int _0024var_0024MRaceId;

	public int _0024var_0024Rare;

	public int _0024var_0024MElementId;

	public int _0024var_0024LevelLimitMin;

	public int _0024var_0024LevelLimitMax;

	public int _0024var_0024EvoMaterialId_1;

	public int _0024var_0024EvoMaterialId_2;

	public int _0024var_0024EvoMaterialId_3;

	public int _0024var_0024EvoMaterialId_4;

	public int _0024var_0024EvoMaterialId_5;

	public int _0024var_0024EvolutionPoppetId;

	public int _0024var_0024ChainSkillId;

	public int _0024var_0024CoverSkillId_1;

	public int _0024var_0024CoverSkillId_2;

	public int _0024var_0024EvoCost;

	public bool _0024var_0024startEquip;

	public BasicBattleParameters _0024var_0024BattleParams;

	public int _0024var_0024AcqExpMin;

	public int _0024var_0024AcqExpMax;

	public float _0024var_0024AcqExpExp;

	public int _0024var_0024SellPrice;

	public EnumPoppetPersonalities _0024var_0024Personality;

	public EnumLevelUpTypes _0024var_0024LevelUpType;

	public int _0024var_0024DefenseMin;

	public int _0024var_0024DefenseMax;

	public float _0024var_0024DefenseExp;

	public int _0024var_0024Cost;

	public bool _0024var_0024NoChainElementEffect;

	public bool _0024var_0024IsLimitBreak;

	public bool _0024var_0024IsSkillLvUp;

	public int _0024var_0024SellManaFragment;

	public bool _0024var_0024IsEvolutionInformation;

	public bool _0024var_0024IsAvailable;

	public int _0024var_0024DeckCost;

	[NonSerialized]
	private MTexts Name__cache;

	[NonSerialized]
	private MRaces MRaceId__cache;

	[NonSerialized]
	private MRares Rare__cache;

	[NonSerialized]
	private MElements MElementId__cache;

	[NonSerialized]
	private MPoppets EvoMaterialId_1__cache;

	[NonSerialized]
	private MPoppets EvoMaterialId_2__cache;

	[NonSerialized]
	private MPoppets EvoMaterialId_3__cache;

	[NonSerialized]
	private MPoppets EvoMaterialId_4__cache;

	[NonSerialized]
	private MPoppets EvoMaterialId_5__cache;

	[NonSerialized]
	private MPoppets EvolutionPoppetId__cache;

	[NonSerialized]
	private MChainSkills ChainSkillId__cache;

	[NonSerialized]
	private MCoverSkills CoverSkillId_1__cache;

	[NonSerialized]
	private MCoverSkills CoverSkillId_2__cache;

	[NonSerialized]
	private static Dictionary<int, MPoppets> _0024mst_002412 = new Dictionary<int, MPoppets>();

	[NonSerialized]
	private static MPoppets[] All_cache;

	public MMonsters Monster => MMonsters.Get(Id);

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

	public string PrefabName => _0024var_0024PrefabName;

	public string Icon => _0024var_0024Icon;

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

	public MRares Rare
	{
		get
		{
			if (Rare__cache == null)
			{
				Rare__cache = MRares.Get(_0024var_0024Rare);
			}
			return Rare__cache;
		}
	}

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

	public int LevelLimitMin => _0024var_0024LevelLimitMin;

	public int LevelLimitMax => _0024var_0024LevelLimitMax;

	public MPoppets EvoMaterialId_1
	{
		get
		{
			if (EvoMaterialId_1__cache == null)
			{
				EvoMaterialId_1__cache = Get(_0024var_0024EvoMaterialId_1);
			}
			return EvoMaterialId_1__cache;
		}
	}

	public MPoppets EvoMaterialId_2
	{
		get
		{
			if (EvoMaterialId_2__cache == null)
			{
				EvoMaterialId_2__cache = Get(_0024var_0024EvoMaterialId_2);
			}
			return EvoMaterialId_2__cache;
		}
	}

	public MPoppets EvoMaterialId_3
	{
		get
		{
			if (EvoMaterialId_3__cache == null)
			{
				EvoMaterialId_3__cache = Get(_0024var_0024EvoMaterialId_3);
			}
			return EvoMaterialId_3__cache;
		}
	}

	public MPoppets EvoMaterialId_4
	{
		get
		{
			if (EvoMaterialId_4__cache == null)
			{
				EvoMaterialId_4__cache = Get(_0024var_0024EvoMaterialId_4);
			}
			return EvoMaterialId_4__cache;
		}
	}

	public MPoppets EvoMaterialId_5
	{
		get
		{
			if (EvoMaterialId_5__cache == null)
			{
				EvoMaterialId_5__cache = Get(_0024var_0024EvoMaterialId_5);
			}
			return EvoMaterialId_5__cache;
		}
	}

	public MPoppets EvolutionPoppetId
	{
		get
		{
			if (EvolutionPoppetId__cache == null)
			{
				EvolutionPoppetId__cache = Get(_0024var_0024EvolutionPoppetId);
			}
			return EvolutionPoppetId__cache;
		}
	}

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

	public MCoverSkills CoverSkillId_1
	{
		get
		{
			if (CoverSkillId_1__cache == null)
			{
				CoverSkillId_1__cache = MCoverSkills.Get(_0024var_0024CoverSkillId_1);
			}
			return CoverSkillId_1__cache;
		}
	}

	public MCoverSkills CoverSkillId_2
	{
		get
		{
			if (CoverSkillId_2__cache == null)
			{
				CoverSkillId_2__cache = MCoverSkills.Get(_0024var_0024CoverSkillId_2);
			}
			return CoverSkillId_2__cache;
		}
	}

	public int EvoCost => _0024var_0024EvoCost;

	public bool startEquip => _0024var_0024startEquip;

	public BasicBattleParameters BattleParams => _0024var_0024BattleParams;

	public int AcqExpMin => _0024var_0024AcqExpMin;

	public int AcqExpMax => _0024var_0024AcqExpMax;

	public float AcqExpExp => _0024var_0024AcqExpExp;

	public int SellPrice => _0024var_0024SellPrice;

	public EnumPoppetPersonalities Personality => _0024var_0024Personality;

	public EnumLevelUpTypes LevelUpType => _0024var_0024LevelUpType;

	public int DefenseMin => _0024var_0024DefenseMin;

	public int DefenseMax => _0024var_0024DefenseMax;

	public float DefenseExp => _0024var_0024DefenseExp;

	public int Cost => _0024var_0024Cost;

	public bool NoChainElementEffect => _0024var_0024NoChainElementEffect;

	public bool IsLimitBreak => _0024var_0024IsLimitBreak;

	public bool IsSkillLvUp => _0024var_0024IsSkillLvUp;

	public int SellManaFragment => _0024var_0024SellManaFragment;

	public bool IsEvolutionInformation => _0024var_0024IsEvolutionInformation;

	public bool IsAvailable => _0024var_0024IsAvailable;

	public int DeckCost => _0024var_0024DeckCost;

	public static MPoppets[] All
	{
		get
		{
			MPoppets[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MPoppets");
				MPoppets[] array = (MPoppets[])Builtins.array(typeof(MPoppets), _0024mst_002412.Values);
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

	public MPoppets()
	{
		_0024var_0024LevelLimitMin = 1;
		_0024var_0024LevelLimitMax = 10;
		_0024var_0024BattleParams = new BasicBattleParameters();
		_0024var_0024AcqExpMax = 10;
		_0024var_0024AcqExpExp = 1f;
		_0024var_0024LevelUpType = EnumLevelUpTypes.balance;
		_0024var_0024DeckCost = 10;
	}

	public int defense(int level)
	{
		return ParamCalcModule.ComputeGrowthInt(level, LevelLimitMax, DefenseMin, DefenseMax, DefenseExp, ToString());
	}

	public int price(int level)
	{
		return checked(SellPrice * level);
	}

	public int exp(int level)
	{
		return BattleParams.exp(level, LevelLimitMax, ToString());
	}

	public int attack(int level)
	{
		return BattleParams.attack(level, LevelLimitMax, ToString());
	}

	public int hp(int level)
	{
		return BattleParams.hp(level, LevelLimitMax, ToString());
	}

	public int critical(int level)
	{
		return BattleParams.critical(level, LevelLimitMax, ToString());
	}

	public int breakPow(int level)
	{
		return BattleParams.breakPow(level, LevelLimitMax, ToString());
	}

	public int resist(int level)
	{
		return BattleParams.resist(level, LevelLimitMax, ToString());
	}

	public int exp_to_level(int e, int now)
	{
		int result = now;
		int num;
		int num2;
		int num3;
		checked
		{
			num = now + 1;
			num2 = LevelLimitMax + 1;
			num3 = 1;
			if (num2 < num)
			{
				num3 = -1;
			}
		}
		while (num != num2)
		{
			int num4 = num;
			num += num3;
			if (e < exp(num4))
			{
				break;
			}
			result = num4;
		}
		return result;
	}

	public bool CanPowup()
	{
		bool num = LevelUpType != EnumLevelUpTypes.enhancement;
		if (num)
		{
			num = LevelUpType != EnumLevelUpTypes.evolution;
		}
		if (num)
		{
			num = !IsLimitBreak;
		}
		if (num)
		{
			num = !IsSkillLvUp;
		}
		return num;
	}

	public override string ToString()
	{
		return new StringBuilder("MPoppets(").Append((object)Id).Append(":").Append(PrefabName)
			.Append(")")
			.ToString();
	}

	public static MPoppets Get(int _id)
	{
		MerlinMaster.GetHandler("MPoppets");
		return (!_0024mst_002412.ContainsKey(_id)) ? null : _0024mst_002412[_id];
	}

	public static void Unload()
	{
		_0024mst_002412.Clear();
		All_cache = null;
	}

	public static MPoppets New(Hashtable data)
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
			MPoppets mPoppets = Create(data);
			if (!_0024mst_002412.ContainsKey(mPoppets.Id))
			{
				_0024mst_002412[mPoppets.Id] = mPoppets;
			}
			result = mPoppets;
		}
		return (MPoppets)result;
	}

	public static MPoppets New2(string[] keys, object[] vals)
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
		return (MPoppets)result;
	}

	public static MPoppets Entry(MPoppets mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002412[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MPoppets)result;
	}

	public static void AddMst(MPoppets mst)
	{
		if (mst != null)
		{
			_0024mst_002412[mst.Id] = mst;
		}
	}

	public static MPoppets Create(Hashtable data)
	{
		MPoppets mPoppets = new MPoppets();
		MPoppets result;
		if (data == null)
		{
			result = mPoppets;
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
				mPoppets.setField((string)obj, data[current]);
			}
			result = mPoppets;
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
		case "PrefabName":
			_0024var_0024PrefabName = MasterBaseClass.ToStringValue(val);
			break;
		case "Icon":
			_0024var_0024Icon = MasterBaseClass.ToStringValue(val);
			break;
		case "MRaceId":
			_0024var_0024MRaceId = MasterBaseClass.ToInt(val);
			break;
		case "Rare":
			_0024var_0024Rare = MasterBaseClass.ToInt(val);
			break;
		case "MElementId":
			_0024var_0024MElementId = MasterBaseClass.ToInt(val);
			break;
		case "LevelLimitMin":
			_0024var_0024LevelLimitMin = MasterBaseClass.ToInt(val);
			break;
		case "LevelLimitMax":
			_0024var_0024LevelLimitMax = MasterBaseClass.ToInt(val);
			break;
		case "EvoMaterialId_1":
			_0024var_0024EvoMaterialId_1 = MasterBaseClass.ToInt(val);
			break;
		case "EvoMaterialId_2":
			_0024var_0024EvoMaterialId_2 = MasterBaseClass.ToInt(val);
			break;
		case "EvoMaterialId_3":
			_0024var_0024EvoMaterialId_3 = MasterBaseClass.ToInt(val);
			break;
		case "EvoMaterialId_4":
			_0024var_0024EvoMaterialId_4 = MasterBaseClass.ToInt(val);
			break;
		case "EvoMaterialId_5":
			_0024var_0024EvoMaterialId_5 = MasterBaseClass.ToInt(val);
			break;
		case "EvolutionPoppetId":
			_0024var_0024EvolutionPoppetId = MasterBaseClass.ToInt(val);
			break;
		case "ChainSkillId":
			_0024var_0024ChainSkillId = MasterBaseClass.ToInt(val);
			break;
		case "CoverSkillId_1":
			_0024var_0024CoverSkillId_1 = MasterBaseClass.ToInt(val);
			break;
		case "CoverSkillId_2":
			_0024var_0024CoverSkillId_2 = MasterBaseClass.ToInt(val);
			break;
		case "EvoCost":
			_0024var_0024EvoCost = MasterBaseClass.ToInt(val);
			break;
		case "startEquip":
			_0024var_0024startEquip = MasterBaseClass.ToBool(val);
			break;
		case "BattleParams":
		{
			object obj = val;
			if (!(obj is Hashtable))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
			}
			_0024var_0024BattleParams = BasicBattleParameters.Create((Hashtable)obj);
			break;
		}
		case "AcqExpMin":
			_0024var_0024AcqExpMin = MasterBaseClass.ToInt(val);
			break;
		case "AcqExpMax":
			_0024var_0024AcqExpMax = MasterBaseClass.ToInt(val);
			break;
		case "AcqExpExp":
			_0024var_0024AcqExpExp = MasterBaseClass.ToSingle(val);
			break;
		case "SellPrice":
			_0024var_0024SellPrice = MasterBaseClass.ToInt(val);
			break;
		case "Personality":
			if (typeof(EnumPoppetPersonalities).IsEnum)
			{
				_0024var_0024Personality = (EnumPoppetPersonalities)MasterBaseClass.ToEnum(val);
			}
			break;
		case "LevelUpType":
			if (typeof(EnumLevelUpTypes).IsEnum)
			{
				_0024var_0024LevelUpType = (EnumLevelUpTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "DefenseMin":
			_0024var_0024DefenseMin = MasterBaseClass.ToInt(val);
			break;
		case "DefenseMax":
			_0024var_0024DefenseMax = MasterBaseClass.ToInt(val);
			break;
		case "DefenseExp":
			_0024var_0024DefenseExp = MasterBaseClass.ToSingle(val);
			break;
		case "Cost":
			_0024var_0024Cost = MasterBaseClass.ToInt(val);
			break;
		case "NoChainElementEffect":
			_0024var_0024NoChainElementEffect = MasterBaseClass.ToBool(val);
			break;
		case "IsLimitBreak":
			_0024var_0024IsLimitBreak = MasterBaseClass.ToBool(val);
			break;
		case "IsSkillLvUp":
			_0024var_0024IsSkillLvUp = MasterBaseClass.ToBool(val);
			break;
		case "SellManaFragment":
			_0024var_0024SellManaFragment = MasterBaseClass.ToInt(val);
			break;
		case "IsEvolutionInformation":
			_0024var_0024IsEvolutionInformation = MasterBaseClass.ToBool(val);
			break;
		case "IsAvailable":
			_0024var_0024IsAvailable = MasterBaseClass.ToBool(val);
			break;
		case "DeckCost":
			_0024var_0024DeckCost = MasterBaseClass.ToInt(val);
			break;
		default:
			if (BasicBattleParameters.HasKey(key))
			{
				_0024var_0024BattleParams.setField(key, val);
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
			"PrefabName" => true, 
			"Icon" => true, 
			"MRaceId" => true, 
			"Rare" => true, 
			"MElementId" => true, 
			"LevelLimitMin" => true, 
			"LevelLimitMax" => true, 
			"EvoMaterialId_1" => true, 
			"EvoMaterialId_2" => true, 
			"EvoMaterialId_3" => true, 
			"EvoMaterialId_4" => true, 
			"EvoMaterialId_5" => true, 
			"EvolutionPoppetId" => true, 
			"ChainSkillId" => true, 
			"CoverSkillId_1" => true, 
			"CoverSkillId_2" => true, 
			"EvoCost" => true, 
			"startEquip" => true, 
			"BattleParams" => true, 
			"AcqExpMin" => true, 
			"AcqExpMax" => true, 
			"AcqExpExp" => true, 
			"SellPrice" => true, 
			"Personality" => true, 
			"LevelUpType" => true, 
			"DefenseMin" => true, 
			"DefenseMax" => true, 
			"DefenseExp" => true, 
			"Cost" => true, 
			"NoChainElementEffect" => true, 
			"IsLimitBreak" => true, 
			"IsSkillLvUp" => true, 
			"SellManaFragment" => true, 
			"IsEvolutionInformation" => true, 
			"IsAvailable" => true, 
			"DeckCost" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		lhs = (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[37]
		{
			"Id", "Name", "PrefabName", "Icon", "MRaceId", "Rare", "MElementId", "LevelLimitMin", "LevelLimitMax", "EvoMaterialId_1",
			"EvoMaterialId_2", "EvoMaterialId_3", "EvoMaterialId_4", "EvoMaterialId_5", "EvolutionPoppetId", "ChainSkillId", "CoverSkillId_1", "CoverSkillId_2", "EvoCost", "startEquip",
			"AcqExpMin", "AcqExpMax", "AcqExpExp", "SellPrice", "Personality", "LevelUpType", "DefenseMin", "DefenseMax", "DefenseExp", "Cost",
			"NoChainElementEffect", "IsLimitBreak", "IsSkillLvUp", "SellManaFragment", "IsEvolutionInformation", "IsAvailable", "DeckCost"
		});
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, BasicBattleParameters.KeyNameList());
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
						_0024var_0024PrefabName = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Icon = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024MRaceId = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Rare = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024MElementId = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024LevelLimitMin = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024LevelLimitMax = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024EvoMaterialId_1 = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024EvoMaterialId_2 = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024EvoMaterialId_3 = MasterBaseClass.ParseInt(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024EvoMaterialId_4 = MasterBaseClass.ParseInt(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024EvoMaterialId_5 = MasterBaseClass.ParseInt(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024EvolutionPoppetId = MasterBaseClass.ParseInt(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null)
																		{
																			_0024var_0024ChainSkillId = MasterBaseClass.ParseInt(vals[15]);
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null)
																			{
																				_0024var_0024CoverSkillId_1 = MasterBaseClass.ParseInt(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null)
																				{
																					_0024var_0024CoverSkillId_2 = MasterBaseClass.ParseInt(vals[17]);
																				}
																				if (length <= 18)
																				{
																					result = 18;
																				}
																				else
																				{
																					if (vals[18] != null)
																					{
																						_0024var_0024EvoCost = MasterBaseClass.ParseInt(vals[18]);
																					}
																					if (length <= 19)
																					{
																						result = 19;
																					}
																					else
																					{
																						if (vals[19] != null)
																						{
																							_0024var_0024startEquip = MasterBaseClass.ParseBool(vals[19]);
																						}
																						if (length <= 20)
																						{
																							result = 20;
																						}
																						else
																						{
																							if (vals[20] != null)
																							{
																								_0024var_0024AcqExpMin = MasterBaseClass.ParseInt(vals[20]);
																							}
																							if (length <= 21)
																							{
																								result = 21;
																							}
																							else
																							{
																								if (vals[21] != null)
																								{
																									_0024var_0024AcqExpMax = MasterBaseClass.ParseInt(vals[21]);
																								}
																								if (length <= 22)
																								{
																									result = 22;
																								}
																								else
																								{
																									if (vals[22] != null)
																									{
																										_0024var_0024AcqExpExp = MasterBaseClass.ParseSingle(vals[22]);
																									}
																									if (length <= 23)
																									{
																										result = 23;
																									}
																									else
																									{
																										if (vals[23] != null)
																										{
																											_0024var_0024SellPrice = MasterBaseClass.ParseInt(vals[23]);
																										}
																										if (length <= 24)
																										{
																											result = 24;
																										}
																										else
																										{
																											if (vals[24] != null && typeof(EnumPoppetPersonalities).IsEnum)
																											{
																												_0024var_0024Personality = (EnumPoppetPersonalities)MasterBaseClass.ParseEnum(vals[24]);
																											}
																											if (length <= 25)
																											{
																												result = 25;
																											}
																											else
																											{
																												if (vals[25] != null && typeof(EnumLevelUpTypes).IsEnum)
																												{
																													_0024var_0024LevelUpType = (EnumLevelUpTypes)MasterBaseClass.ParseEnum(vals[25]);
																												}
																												if (length <= 26)
																												{
																													result = 26;
																												}
																												else
																												{
																													if (vals[26] != null)
																													{
																														_0024var_0024DefenseMin = MasterBaseClass.ParseInt(vals[26]);
																													}
																													if (length <= 27)
																													{
																														result = 27;
																													}
																													else
																													{
																														if (vals[27] != null)
																														{
																															_0024var_0024DefenseMax = MasterBaseClass.ParseInt(vals[27]);
																														}
																														if (length <= 28)
																														{
																															result = 28;
																														}
																														else
																														{
																															if (vals[28] != null)
																															{
																																_0024var_0024DefenseExp = MasterBaseClass.ParseSingle(vals[28]);
																															}
																															if (length <= 29)
																															{
																																result = 29;
																															}
																															else
																															{
																																if (vals[29] != null)
																																{
																																	_0024var_0024Cost = MasterBaseClass.ParseInt(vals[29]);
																																}
																																if (length <= 30)
																																{
																																	result = 30;
																																}
																																else
																																{
																																	if (vals[30] != null)
																																	{
																																		_0024var_0024NoChainElementEffect = MasterBaseClass.ParseBool(vals[30]);
																																	}
																																	if (length <= 31)
																																	{
																																		result = 31;
																																	}
																																	else
																																	{
																																		if (vals[31] != null)
																																		{
																																			_0024var_0024IsLimitBreak = MasterBaseClass.ParseBool(vals[31]);
																																		}
																																		if (length <= 32)
																																		{
																																			result = 32;
																																		}
																																		else
																																		{
																																			if (vals[32] != null)
																																			{
																																				_0024var_0024IsSkillLvUp = MasterBaseClass.ParseBool(vals[32]);
																																			}
																																			if (length <= 33)
																																			{
																																				result = 33;
																																			}
																																			else
																																			{
																																				if (vals[33] != null)
																																				{
																																					_0024var_0024SellManaFragment = MasterBaseClass.ParseInt(vals[33]);
																																				}
																																				if (length <= 34)
																																				{
																																					result = 34;
																																				}
																																				else
																																				{
																																					if (vals[34] != null)
																																					{
																																						_0024var_0024IsEvolutionInformation = MasterBaseClass.ParseBool(vals[34]);
																																					}
																																					if (length <= 35)
																																					{
																																						result = 35;
																																					}
																																					else
																																					{
																																						if (vals[35] != null)
																																						{
																																							_0024var_0024IsAvailable = MasterBaseClass.ParseBool(vals[35]);
																																						}
																																						if (length <= 36)
																																						{
																																							result = 36;
																																						}
																																						else
																																						{
																																							if (vals[36] != null)
																																							{
																																								_0024var_0024DeckCost = MasterBaseClass.ParseInt(vals[36]);
																																							}
																																							int num = 37;
																																							if (length > num)
																																							{
																																								num = checked(num + _0024var_0024BattleParams.setStringValues((string[])RuntimeServices.GetRange1(vals, num)));
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
