using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MWeapons : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public string _0024var_0024Explain;

	public string _0024var_0024PrefabName;

	public string _0024var_0024AltPrefabName;

	public string _0024var_0024Icon;

	public int _0024var_0024MStyleId;

	public int _0024var_0024Cost;

	public int _0024var_0024MElementId;

	public int _0024var_0024Rare;

	public int _0024var_0024AngelSkillId;

	public int _0024var_0024DemonSkillId;

	public int _0024var_0024GachaGroup;

	public int _0024var_0024CoverSkillId;

	public BasicBattleParameters _0024var_0024BattleParams;

	public int _0024var_0024LevelLimitMin;

	public int _0024var_0024LevelLimitMax;

	public int _0024var_0024SellPrice;

	public int _0024var_0024EvoMaterialId_1;

	public int _0024var_0024EvoMaterialId_2;

	public int _0024var_0024EvoMaterialId_3;

	public int _0024var_0024EvoMaterialId_4;

	public int _0024var_0024EvoMaterialId_5;

	public int _0024var_0024EvolutionWeaponId;

	public int _0024var_0024EvoCost;

	public int _0024var_0024AcqExpMin;

	public int _0024var_0024AcqExpMax;

	public float _0024var_0024AcqExpExp;

	public EnumLevelUpTypes _0024var_0024LevelUpType;

	public bool _0024var_0024startEquip;

	public bool _0024var_0024IsLimitBreak;

	public bool _0024var_0024IsSkillLvUp;

	public int _0024var_0024SellManaFragment;

	public bool _0024var_0024IsEvolutionInformation;

	public bool _0024var_0024IsAvailable;

	public int _0024var_0024DeckCost;

	[NonSerialized]
	private MTexts Name__cache;

	[NonSerialized]
	private MTexts Explain__cache;

	[NonSerialized]
	private MStyles MStyleId__cache;

	[NonSerialized]
	private MElements MElementId__cache;

	[NonSerialized]
	private MRares Rare__cache;

	[NonSerialized]
	private MWeaponSkills AngelSkillId__cache;

	[NonSerialized]
	private MWeaponSkills DemonSkillId__cache;

	[NonSerialized]
	private MCoverSkills CoverSkillId__cache;

	[NonSerialized]
	private MWeapons EvoMaterialId_1__cache;

	[NonSerialized]
	private MWeapons EvoMaterialId_2__cache;

	[NonSerialized]
	private MWeapons EvoMaterialId_3__cache;

	[NonSerialized]
	private MWeapons EvoMaterialId_4__cache;

	[NonSerialized]
	private MWeapons EvoMaterialId_5__cache;

	[NonSerialized]
	private MWeapons EvolutionWeaponId__cache;

	[NonSerialized]
	private static Dictionary<int, MWeapons> _0024mst_00244 = new Dictionary<int, MWeapons>();

	[NonSerialized]
	private static MWeapons[] All_cache;

	public MTexts Detail => Explain;

	public MStyles StyleId => MStyleId;

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

	public MTexts Explain
	{
		get
		{
			if (Explain__cache == null)
			{
				Explain__cache = MTexts.Get(_0024var_0024Explain);
			}
			return Explain__cache;
		}
	}

	public string PrefabName => _0024var_0024PrefabName;

	public string AltPrefabName => _0024var_0024AltPrefabName;

	public string Icon => _0024var_0024Icon;

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

	public int Cost => _0024var_0024Cost;

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

	public MWeaponSkills AngelSkillId
	{
		get
		{
			if (AngelSkillId__cache == null)
			{
				AngelSkillId__cache = MWeaponSkills.Get(_0024var_0024AngelSkillId);
			}
			return AngelSkillId__cache;
		}
	}

	public MWeaponSkills DemonSkillId
	{
		get
		{
			if (DemonSkillId__cache == null)
			{
				DemonSkillId__cache = MWeaponSkills.Get(_0024var_0024DemonSkillId);
			}
			return DemonSkillId__cache;
		}
	}

	public int GachaGroup => _0024var_0024GachaGroup;

	public MCoverSkills CoverSkillId
	{
		get
		{
			if (CoverSkillId__cache == null)
			{
				CoverSkillId__cache = MCoverSkills.Get(_0024var_0024CoverSkillId);
			}
			return CoverSkillId__cache;
		}
	}

	public BasicBattleParameters BattleParams => _0024var_0024BattleParams;

	public int LevelLimitMin => _0024var_0024LevelLimitMin;

	public int LevelLimitMax => _0024var_0024LevelLimitMax;

	public int SellPrice => _0024var_0024SellPrice;

	public MWeapons EvoMaterialId_1
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

	public MWeapons EvoMaterialId_2
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

	public MWeapons EvoMaterialId_3
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

	public MWeapons EvoMaterialId_4
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

	public MWeapons EvoMaterialId_5
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

	public MWeapons EvolutionWeaponId
	{
		get
		{
			if (EvolutionWeaponId__cache == null)
			{
				EvolutionWeaponId__cache = Get(_0024var_0024EvolutionWeaponId);
			}
			return EvolutionWeaponId__cache;
		}
	}

	public int EvoCost => _0024var_0024EvoCost;

	public int AcqExpMin => _0024var_0024AcqExpMin;

	public int AcqExpMax => _0024var_0024AcqExpMax;

	public float AcqExpExp => _0024var_0024AcqExpExp;

	public EnumLevelUpTypes LevelUpType => _0024var_0024LevelUpType;

	public bool startEquip => _0024var_0024startEquip;

	public bool IsLimitBreak => _0024var_0024IsLimitBreak;

	public bool IsSkillLvUp => _0024var_0024IsSkillLvUp;

	public int SellManaFragment => _0024var_0024SellManaFragment;

	public bool IsEvolutionInformation => _0024var_0024IsEvolutionInformation;

	public bool IsAvailable => _0024var_0024IsAvailable;

	public int DeckCost => _0024var_0024DeckCost;

	public static MWeapons[] All
	{
		get
		{
			MWeapons[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MWeapons");
				MWeapons[] array = (MWeapons[])Builtins.array(typeof(MWeapons), _0024mst_00244.Values);
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

	public MWeapons()
	{
		_0024var_0024BattleParams = new BasicBattleParameters();
		_0024var_0024LevelLimitMin = 1;
		_0024var_0024LevelLimitMax = 10;
		_0024var_0024AcqExpMax = 10;
		_0024var_0024AcqExpExp = 1f;
		_0024var_0024LevelUpType = EnumLevelUpTypes.balance;
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
		return new StringBuilder("MWeapons(").Append((object)Id).Append(":").Append(Name)
			.Append(")")
			.ToString();
	}

	public int price(int level)
	{
		return checked(SellPrice * level);
	}

	public float exp(int level)
	{
		return BattleParams.exp(level, LevelLimitMax, ToString());
	}

	public float attack(int level)
	{
		return BattleParams.attack(level, LevelLimitMax, ToString());
	}

	public float hp(int level)
	{
		return BattleParams.hp(level, LevelLimitMax, ToString());
	}

	public float critical(int level)
	{
		return BattleParams.critical(level, LevelLimitMax, ToString());
	}

	public float breakPow(int level)
	{
		return BattleParams.breakPow(level, LevelLimitMax, ToString());
	}

	public float resist(int level)
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
			if (!((float)e >= exp(num4)))
			{
				break;
			}
			result = num4;
		}
		return result;
	}

	public static MWeapons Get(int _id)
	{
		MerlinMaster.GetHandler("MWeapons");
		return (!_0024mst_00244.ContainsKey(_id)) ? null : _0024mst_00244[_id];
	}

	public static void Unload()
	{
		_0024mst_00244.Clear();
		All_cache = null;
	}

	public static MWeapons New(Hashtable data)
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
			MWeapons mWeapons = Create(data);
			if (!_0024mst_00244.ContainsKey(mWeapons.Id))
			{
				_0024mst_00244[mWeapons.Id] = mWeapons;
			}
			result = mWeapons;
		}
		return (MWeapons)result;
	}

	public static MWeapons New2(string[] keys, object[] vals)
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
		return (MWeapons)result;
	}

	public static MWeapons Entry(MWeapons mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_00244[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MWeapons)result;
	}

	public static void AddMst(MWeapons mst)
	{
		if (mst != null)
		{
			_0024mst_00244[mst.Id] = mst;
		}
	}

	public static MWeapons Create(Hashtable data)
	{
		MWeapons mWeapons = new MWeapons();
		MWeapons result;
		if (data == null)
		{
			result = mWeapons;
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
				mWeapons.setField((string)obj, data[current]);
			}
			result = mWeapons;
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
		case "Explain":
			_0024var_0024Explain = MasterBaseClass.ToStringValue(val);
			break;
		case "PrefabName":
			_0024var_0024PrefabName = MasterBaseClass.ToStringValue(val);
			break;
		case "AltPrefabName":
			_0024var_0024AltPrefabName = MasterBaseClass.ToStringValue(val);
			break;
		case "Icon":
			_0024var_0024Icon = MasterBaseClass.ToStringValue(val);
			break;
		case "MStyleId":
			_0024var_0024MStyleId = MasterBaseClass.ToInt(val);
			break;
		case "Cost":
			_0024var_0024Cost = MasterBaseClass.ToInt(val);
			break;
		case "MElementId":
			_0024var_0024MElementId = MasterBaseClass.ToInt(val);
			break;
		case "Rare":
			_0024var_0024Rare = MasterBaseClass.ToInt(val);
			break;
		case "AngelSkillId":
			_0024var_0024AngelSkillId = MasterBaseClass.ToInt(val);
			break;
		case "DemonSkillId":
			_0024var_0024DemonSkillId = MasterBaseClass.ToInt(val);
			break;
		case "GachaGroup":
			_0024var_0024GachaGroup = MasterBaseClass.ToInt(val);
			break;
		case "CoverSkillId":
			_0024var_0024CoverSkillId = MasterBaseClass.ToInt(val);
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
		case "LevelLimitMin":
			_0024var_0024LevelLimitMin = MasterBaseClass.ToInt(val);
			break;
		case "LevelLimitMax":
			_0024var_0024LevelLimitMax = MasterBaseClass.ToInt(val);
			break;
		case "SellPrice":
			_0024var_0024SellPrice = MasterBaseClass.ToInt(val);
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
		case "EvolutionWeaponId":
			_0024var_0024EvolutionWeaponId = MasterBaseClass.ToInt(val);
			break;
		case "EvoCost":
			_0024var_0024EvoCost = MasterBaseClass.ToInt(val);
			break;
		case "AcqExpMin":
			_0024var_0024AcqExpMin = MasterBaseClass.ToInt(val);
			break;
		case "AcqExpMax":
			_0024var_0024AcqExpMax = MasterBaseClass.ToInt(val);
			break;
		case "AcqExpExp":
			_0024var_0024AcqExpExp = MasterBaseClass.ToSingle(val);
			break;
		case "LevelUpType":
			if (typeof(EnumLevelUpTypes).IsEnum)
			{
				_0024var_0024LevelUpType = (EnumLevelUpTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "startEquip":
			_0024var_0024startEquip = MasterBaseClass.ToBool(val);
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
			"Explain" => true, 
			"PrefabName" => true, 
			"AltPrefabName" => true, 
			"Icon" => true, 
			"MStyleId" => true, 
			"Cost" => true, 
			"MElementId" => true, 
			"Rare" => true, 
			"AngelSkillId" => true, 
			"DemonSkillId" => true, 
			"GachaGroup" => true, 
			"CoverSkillId" => true, 
			"BattleParams" => true, 
			"LevelLimitMin" => true, 
			"LevelLimitMax" => true, 
			"SellPrice" => true, 
			"EvoMaterialId_1" => true, 
			"EvoMaterialId_2" => true, 
			"EvoMaterialId_3" => true, 
			"EvoMaterialId_4" => true, 
			"EvoMaterialId_5" => true, 
			"EvolutionWeaponId" => true, 
			"EvoCost" => true, 
			"AcqExpMin" => true, 
			"AcqExpMax" => true, 
			"AcqExpExp" => true, 
			"LevelUpType" => true, 
			"startEquip" => true, 
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
		lhs = (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[35]
		{
			"Id", "Name", "Explain", "PrefabName", "AltPrefabName", "Icon", "MStyleId", "Cost", "MElementId", "Rare",
			"AngelSkillId", "DemonSkillId", "GachaGroup", "CoverSkillId", "LevelLimitMin", "LevelLimitMax", "SellPrice", "EvoMaterialId_1", "EvoMaterialId_2", "EvoMaterialId_3",
			"EvoMaterialId_4", "EvoMaterialId_5", "EvolutionWeaponId", "EvoCost", "AcqExpMin", "AcqExpMax", "AcqExpExp", "LevelUpType", "startEquip", "IsLimitBreak",
			"IsSkillLvUp", "SellManaFragment", "IsEvolutionInformation", "IsAvailable", "DeckCost"
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
						_0024var_0024Explain = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024PrefabName = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024AltPrefabName = vals[4];
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Icon = vals[5];
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024MStyleId = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024Cost = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024MElementId = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024Rare = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024AngelSkillId = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024DemonSkillId = MasterBaseClass.ParseInt(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024GachaGroup = MasterBaseClass.ParseInt(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024CoverSkillId = MasterBaseClass.ParseInt(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024LevelLimitMin = MasterBaseClass.ParseInt(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null)
																		{
																			_0024var_0024LevelLimitMax = MasterBaseClass.ParseInt(vals[15]);
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null)
																			{
																				_0024var_0024SellPrice = MasterBaseClass.ParseInt(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null)
																				{
																					_0024var_0024EvoMaterialId_1 = MasterBaseClass.ParseInt(vals[17]);
																				}
																				if (length <= 18)
																				{
																					result = 18;
																				}
																				else
																				{
																					if (vals[18] != null)
																					{
																						_0024var_0024EvoMaterialId_2 = MasterBaseClass.ParseInt(vals[18]);
																					}
																					if (length <= 19)
																					{
																						result = 19;
																					}
																					else
																					{
																						if (vals[19] != null)
																						{
																							_0024var_0024EvoMaterialId_3 = MasterBaseClass.ParseInt(vals[19]);
																						}
																						if (length <= 20)
																						{
																							result = 20;
																						}
																						else
																						{
																							if (vals[20] != null)
																							{
																								_0024var_0024EvoMaterialId_4 = MasterBaseClass.ParseInt(vals[20]);
																							}
																							if (length <= 21)
																							{
																								result = 21;
																							}
																							else
																							{
																								if (vals[21] != null)
																								{
																									_0024var_0024EvoMaterialId_5 = MasterBaseClass.ParseInt(vals[21]);
																								}
																								if (length <= 22)
																								{
																									result = 22;
																								}
																								else
																								{
																									if (vals[22] != null)
																									{
																										_0024var_0024EvolutionWeaponId = MasterBaseClass.ParseInt(vals[22]);
																									}
																									if (length <= 23)
																									{
																										result = 23;
																									}
																									else
																									{
																										if (vals[23] != null)
																										{
																											_0024var_0024EvoCost = MasterBaseClass.ParseInt(vals[23]);
																										}
																										if (length <= 24)
																										{
																											result = 24;
																										}
																										else
																										{
																											if (vals[24] != null)
																											{
																												_0024var_0024AcqExpMin = MasterBaseClass.ParseInt(vals[24]);
																											}
																											if (length <= 25)
																											{
																												result = 25;
																											}
																											else
																											{
																												if (vals[25] != null)
																												{
																													_0024var_0024AcqExpMax = MasterBaseClass.ParseInt(vals[25]);
																												}
																												if (length <= 26)
																												{
																													result = 26;
																												}
																												else
																												{
																													if (vals[26] != null)
																													{
																														_0024var_0024AcqExpExp = MasterBaseClass.ParseSingle(vals[26]);
																													}
																													if (length <= 27)
																													{
																														result = 27;
																													}
																													else
																													{
																														if (vals[27] != null && typeof(EnumLevelUpTypes).IsEnum)
																														{
																															_0024var_0024LevelUpType = (EnumLevelUpTypes)MasterBaseClass.ParseEnum(vals[27]);
																														}
																														if (length <= 28)
																														{
																															result = 28;
																														}
																														else
																														{
																															if (vals[28] != null)
																															{
																																_0024var_0024startEquip = MasterBaseClass.ParseBool(vals[28]);
																															}
																															if (length <= 29)
																															{
																																result = 29;
																															}
																															else
																															{
																																if (vals[29] != null)
																																{
																																	_0024var_0024IsLimitBreak = MasterBaseClass.ParseBool(vals[29]);
																																}
																																if (length <= 30)
																																{
																																	result = 30;
																																}
																																else
																																{
																																	if (vals[30] != null)
																																	{
																																		_0024var_0024IsSkillLvUp = MasterBaseClass.ParseBool(vals[30]);
																																	}
																																	if (length <= 31)
																																	{
																																		result = 31;
																																	}
																																	else
																																	{
																																		if (vals[31] != null)
																																		{
																																			_0024var_0024SellManaFragment = MasterBaseClass.ParseInt(vals[31]);
																																		}
																																		if (length <= 32)
																																		{
																																			result = 32;
																																		}
																																		else
																																		{
																																			if (vals[32] != null)
																																			{
																																				_0024var_0024IsEvolutionInformation = MasterBaseClass.ParseBool(vals[32]);
																																			}
																																			if (length <= 33)
																																			{
																																				result = 33;
																																			}
																																			else
																																			{
																																				if (vals[33] != null)
																																				{
																																					_0024var_0024IsAvailable = MasterBaseClass.ParseBool(vals[33]);
																																				}
																																				if (length <= 34)
																																				{
																																					result = 34;
																																				}
																																				else
																																				{
																																					if (vals[34] != null)
																																					{
																																						_0024var_0024DeckCost = MasterBaseClass.ParseInt(vals[34]);
																																					}
																																					int num = 35;
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
		return result;
	}
}
