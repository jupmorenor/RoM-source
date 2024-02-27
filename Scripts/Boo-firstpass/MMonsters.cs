using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using ParamCalc;

[Serializable]
public class MMonsters : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public string _0024var_0024Detail;

	public int _0024var_0024MRaceId;

	public int _0024var_0024MElementId;

	public string _0024var_0024Icon;

	public string _0024var_0024PrefabName;

	public BasicBattleParameters _0024var_0024BattleParams;

	public int _0024var_0024LevelMax;

	public int _0024var_0024DefenseMin;

	public int _0024var_0024DefenseMax;

	public float _0024var_0024DefenseExp;

	public int _0024var_0024AcqExpMin;

	public int _0024var_0024AcqExpMax;

	public float _0024var_0024AcqExpExp;

	public int _0024var_0024AcqCoinMin;

	public int _0024var_0024AcqCoinMax;

	public float _0024var_0024AcqCoinExp;

	public int _0024var_0024EliteResistMin;

	public int _0024var_0024EliteResistMax;

	public float _0024var_0024EliteResistExp;

	public EnumLevelUpTypes _0024var_0024LevelUpType;

	public float _0024var_0024EliteSpeedMult;

	public float _0024var_0024EliteAbnormalStateRateMult;

	public float _0024var_0024EliteColorR;

	public float _0024var_0024EliteColorG;

	public float _0024var_0024EliteColorB;

	public float _0024var_0024EliteColorA;

	public int _0024var_0024IkariLevel1;

	public int _0024var_0024IkariLevel2;

	public int _0024var_0024IkariLevel3;

	public int _0024var_0024IkariLevel4;

	public int _0024var_0024IkariLevel5;

	public int _0024var_0024IkariMotSpeed1;

	public int _0024var_0024IkariMotSpeed2;

	public int _0024var_0024IkariMotSpeed3;

	public int _0024var_0024IkariMotSpeed4;

	public int _0024var_0024IkariMotSpeed5;

	public YarareTypes _0024var_0024IkariYarare1;

	public YarareTypes _0024var_0024IkariYarare2;

	public YarareTypes _0024var_0024IkariYarare3;

	public YarareTypes _0024var_0024IkariYarare4;

	public YarareTypes _0024var_0024IkariYarare5;

	public EnumStyles _0024var_0024WeakStyle;

	public int _0024var_0024Poison;

	public int _0024var_0024Conflict;

	public int _0024var_0024Stun;

	public int _0024var_0024Slow;

	public int _0024var_0024Blind;

	public int _0024var_0024Burn;

	public int _0024var_0024Hate;

	public int _0024var_0024Small;

	public int _0024var_0024Freeze;

	[NonSerialized]
	private MTexts Name__cache;

	[NonSerialized]
	private MTexts Detail__cache;

	[NonSerialized]
	private MRaces MRaceId__cache;

	[NonSerialized]
	private MElements MElementId__cache;

	[NonSerialized]
	private static Dictionary<int, MMonsters> _0024mst_00245 = new Dictionary<int, MMonsters>();

	[NonSerialized]
	private static MMonsters[] All_cache;

	public string SoundID => (!string.IsNullOrEmpty(PrefabName)) ? PrefabName.Substring(0, 5).ToLower() : string.Empty;

	public MPoppets Poppet => MPoppets.Get(Id);

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

	public string Icon => _0024var_0024Icon;

	public string PrefabName => _0024var_0024PrefabName;

	public BasicBattleParameters BattleParams => _0024var_0024BattleParams;

	public int LevelMax => _0024var_0024LevelMax;

	public int DefenseMin => _0024var_0024DefenseMin;

	public int DefenseMax => _0024var_0024DefenseMax;

	public float DefenseExp => _0024var_0024DefenseExp;

	public int AcqExpMin => _0024var_0024AcqExpMin;

	public int AcqExpMax => _0024var_0024AcqExpMax;

	public float AcqExpExp => _0024var_0024AcqExpExp;

	public int AcqCoinMin => _0024var_0024AcqCoinMin;

	public int AcqCoinMax => _0024var_0024AcqCoinMax;

	public float AcqCoinExp => _0024var_0024AcqCoinExp;

	public int EliteResistMin => _0024var_0024EliteResistMin;

	public int EliteResistMax => _0024var_0024EliteResistMax;

	public float EliteResistExp => _0024var_0024EliteResistExp;

	public EnumLevelUpTypes LevelUpType => _0024var_0024LevelUpType;

	public float EliteSpeedMult => _0024var_0024EliteSpeedMult;

	public float EliteAbnormalStateRateMult => _0024var_0024EliteAbnormalStateRateMult;

	public float EliteColorR => _0024var_0024EliteColorR;

	public float EliteColorG => _0024var_0024EliteColorG;

	public float EliteColorB => _0024var_0024EliteColorB;

	public float EliteColorA => _0024var_0024EliteColorA;

	public int IkariLevel1 => _0024var_0024IkariLevel1;

	public int IkariLevel2 => _0024var_0024IkariLevel2;

	public int IkariLevel3 => _0024var_0024IkariLevel3;

	public int IkariLevel4 => _0024var_0024IkariLevel4;

	public int IkariLevel5 => _0024var_0024IkariLevel5;

	public int IkariMotSpeed1 => _0024var_0024IkariMotSpeed1;

	public int IkariMotSpeed2 => _0024var_0024IkariMotSpeed2;

	public int IkariMotSpeed3 => _0024var_0024IkariMotSpeed3;

	public int IkariMotSpeed4 => _0024var_0024IkariMotSpeed4;

	public int IkariMotSpeed5 => _0024var_0024IkariMotSpeed5;

	public YarareTypes IkariYarare1 => _0024var_0024IkariYarare1;

	public YarareTypes IkariYarare2 => _0024var_0024IkariYarare2;

	public YarareTypes IkariYarare3 => _0024var_0024IkariYarare3;

	public YarareTypes IkariYarare4 => _0024var_0024IkariYarare4;

	public YarareTypes IkariYarare5 => _0024var_0024IkariYarare5;

	public EnumStyles WeakStyle => _0024var_0024WeakStyle;

	public int Poison => _0024var_0024Poison;

	public int Conflict => _0024var_0024Conflict;

	public int Stun => _0024var_0024Stun;

	public int Slow => _0024var_0024Slow;

	public int Blind => _0024var_0024Blind;

	public int Burn => _0024var_0024Burn;

	public int Hate => _0024var_0024Hate;

	public int Small => _0024var_0024Small;

	public int Freeze => _0024var_0024Freeze;

	public static MMonsters[] All
	{
		get
		{
			MMonsters[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MMonsters");
				MMonsters[] array = (MMonsters[])Builtins.array(typeof(MMonsters), _0024mst_00245.Values);
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

	public MMonsters()
	{
		_0024var_0024BattleParams = new BasicBattleParameters();
		_0024var_0024LevelMax = 1;
		_0024var_0024LevelUpType = EnumLevelUpTypes.balance;
		_0024var_0024EliteSpeedMult = 1f;
		_0024var_0024EliteAbnormalStateRateMult = 1f;
		_0024var_0024EliteColorR = 0.6f;
		_0024var_0024EliteColorG = 0.8f;
		_0024var_0024EliteColorB = 1f;
		_0024var_0024EliteColorA = 1f;
		_0024var_0024IkariMotSpeed1 = 100;
		_0024var_0024IkariMotSpeed2 = 100;
		_0024var_0024IkariMotSpeed3 = 100;
		_0024var_0024IkariMotSpeed4 = 100;
		_0024var_0024IkariMotSpeed5 = 100;
		_0024var_0024IkariYarare1 = YarareTypes.None;
		_0024var_0024IkariYarare2 = YarareTypes.None;
		_0024var_0024IkariYarare3 = YarareTypes.None;
		_0024var_0024IkariYarare4 = YarareTypes.None;
		_0024var_0024IkariYarare5 = YarareTypes.None;
		_0024var_0024WeakStyle = EnumStyles.None;
	}

	public float eliteResist(int level)
	{
		return (EliteResistMin != 0 || EliteResistMax != 0) ? ((float)ParamCalcModule.ComputeGrowthInt(level, LevelMax, EliteResistMin, EliteResistMax, EliteResistExp, "eliteResist")) : ((float)resist(level));
	}

	public int ikariLevel(int hpRate100)
	{
		int[] array = new int[5] { IkariLevel1, IkariLevel2, IkariLevel3, IkariLevel4, IkariLevel5 };
		int result = 0;
		int num = 100;
		int num2 = 0;
		int length = array.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < length)
		{
			int num3 = num2;
			num2++;
			if (hpRate100 < array[RuntimeServices.NormalizeArrayIndex(array, num3)])
			{
				if (array[RuntimeServices.NormalizeArrayIndex(array, num3)] <= num)
				{
					result = checked(num3 + 1);
					num = array[RuntimeServices.NormalizeArrayIndex(array, num3)];
				}
			}
		}
		return result;
	}

	public float ikariMotSpeed(int ikariLevel)
	{
		return ikariLevel switch
		{
			1 => (float)IkariMotSpeed1 / 100f, 
			2 => (float)IkariMotSpeed2 / 100f, 
			3 => (float)IkariMotSpeed3 / 100f, 
			4 => (float)IkariMotSpeed4 / 100f, 
			5 => (float)IkariMotSpeed5 / 100f, 
			_ => 1f, 
		};
	}

	public YarareTypes ikariYarare(int ikariLevel)
	{
		return ikariLevel switch
		{
			1 => IkariYarare1, 
			2 => IkariYarare2, 
			3 => IkariYarare3, 
			4 => IkariYarare4, 
			5 => IkariYarare5, 
			_ => YarareTypes.None, 
		};
	}

	public float exp(int level)
	{
		return BattleParams.exp(level, LevelMax, ToString());
	}

	public int attack(int level)
	{
		return BattleParams.attack(level, LevelMax, ToString());
	}

	public int hp(int level)
	{
		return BattleParams.hp(level, LevelMax, ToString());
	}

	public int critical(int level)
	{
		return BattleParams.critical(level, LevelMax, ToString());
	}

	public int breakPow(int level)
	{
		return BattleParams.breakPow(level, LevelMax, ToString());
	}

	public int resist(int level)
	{
		return BattleParams.resist(level, LevelMax, ToString());
	}

	public int defense(int level)
	{
		return ParamCalcModule.ComputeGrowthInt(level, LevelMax, DefenseMin, DefenseMax, DefenseExp, ToString());
	}

	public override string ToString()
	{
		return new StringBuilder("MMonster(").Append((object)Id).Append(":").Append(Name)
			.Append(")")
			.ToString();
	}

	public static MMonsters Get(int _id)
	{
		MerlinMaster.GetHandler("MMonsters");
		return (!_0024mst_00245.ContainsKey(_id)) ? null : _0024mst_00245[_id];
	}

	public static void Unload()
	{
		_0024mst_00245.Clear();
		All_cache = null;
	}

	public static MMonsters New(Hashtable data)
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
			MMonsters mMonsters = Create(data);
			if (!_0024mst_00245.ContainsKey(mMonsters.Id))
			{
				_0024mst_00245[mMonsters.Id] = mMonsters;
			}
			result = mMonsters;
		}
		return (MMonsters)result;
	}

	public static MMonsters New2(string[] keys, object[] vals)
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
		return (MMonsters)result;
	}

	public static MMonsters Entry(MMonsters mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_00245[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MMonsters)result;
	}

	public static void AddMst(MMonsters mst)
	{
		if (mst != null)
		{
			_0024mst_00245[mst.Id] = mst;
		}
	}

	public static MMonsters Create(Hashtable data)
	{
		MMonsters mMonsters = new MMonsters();
		MMonsters result;
		if (data == null)
		{
			result = mMonsters;
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
				mMonsters.setField((string)obj, data[current]);
			}
			result = mMonsters;
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
		case "Detail":
			_0024var_0024Detail = MasterBaseClass.ToStringValue(val);
			break;
		case "MRaceId":
			_0024var_0024MRaceId = MasterBaseClass.ToInt(val);
			break;
		case "MElementId":
			_0024var_0024MElementId = MasterBaseClass.ToInt(val);
			break;
		case "Icon":
			_0024var_0024Icon = MasterBaseClass.ToStringValue(val);
			break;
		case "PrefabName":
			_0024var_0024PrefabName = MasterBaseClass.ToStringValue(val);
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
		case "LevelMax":
			_0024var_0024LevelMax = MasterBaseClass.ToInt(val);
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
		case "AcqExpMin":
			_0024var_0024AcqExpMin = MasterBaseClass.ToInt(val);
			break;
		case "AcqExpMax":
			_0024var_0024AcqExpMax = MasterBaseClass.ToInt(val);
			break;
		case "AcqExpExp":
			_0024var_0024AcqExpExp = MasterBaseClass.ToSingle(val);
			break;
		case "AcqCoinMin":
			_0024var_0024AcqCoinMin = MasterBaseClass.ToInt(val);
			break;
		case "AcqCoinMax":
			_0024var_0024AcqCoinMax = MasterBaseClass.ToInt(val);
			break;
		case "AcqCoinExp":
			_0024var_0024AcqCoinExp = MasterBaseClass.ToSingle(val);
			break;
		case "EliteResistMin":
			_0024var_0024EliteResistMin = MasterBaseClass.ToInt(val);
			break;
		case "EliteResistMax":
			_0024var_0024EliteResistMax = MasterBaseClass.ToInt(val);
			break;
		case "EliteResistExp":
			_0024var_0024EliteResistExp = MasterBaseClass.ToSingle(val);
			break;
		case "LevelUpType":
			if (typeof(EnumLevelUpTypes).IsEnum)
			{
				_0024var_0024LevelUpType = (EnumLevelUpTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "EliteSpeedMult":
			_0024var_0024EliteSpeedMult = MasterBaseClass.ToSingle(val);
			break;
		case "EliteAbnormalStateRateMult":
			_0024var_0024EliteAbnormalStateRateMult = MasterBaseClass.ToSingle(val);
			break;
		case "EliteColorR":
			_0024var_0024EliteColorR = MasterBaseClass.ToSingle(val);
			break;
		case "EliteColorG":
			_0024var_0024EliteColorG = MasterBaseClass.ToSingle(val);
			break;
		case "EliteColorB":
			_0024var_0024EliteColorB = MasterBaseClass.ToSingle(val);
			break;
		case "EliteColorA":
			_0024var_0024EliteColorA = MasterBaseClass.ToSingle(val);
			break;
		case "IkariLevel1":
			_0024var_0024IkariLevel1 = MasterBaseClass.ToInt(val);
			break;
		case "IkariLevel2":
			_0024var_0024IkariLevel2 = MasterBaseClass.ToInt(val);
			break;
		case "IkariLevel3":
			_0024var_0024IkariLevel3 = MasterBaseClass.ToInt(val);
			break;
		case "IkariLevel4":
			_0024var_0024IkariLevel4 = MasterBaseClass.ToInt(val);
			break;
		case "IkariLevel5":
			_0024var_0024IkariLevel5 = MasterBaseClass.ToInt(val);
			break;
		case "IkariMotSpeed1":
			_0024var_0024IkariMotSpeed1 = MasterBaseClass.ToInt(val);
			break;
		case "IkariMotSpeed2":
			_0024var_0024IkariMotSpeed2 = MasterBaseClass.ToInt(val);
			break;
		case "IkariMotSpeed3":
			_0024var_0024IkariMotSpeed3 = MasterBaseClass.ToInt(val);
			break;
		case "IkariMotSpeed4":
			_0024var_0024IkariMotSpeed4 = MasterBaseClass.ToInt(val);
			break;
		case "IkariMotSpeed5":
			_0024var_0024IkariMotSpeed5 = MasterBaseClass.ToInt(val);
			break;
		case "IkariYarare1":
			if (typeof(YarareTypes).IsEnum)
			{
				_0024var_0024IkariYarare1 = (YarareTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "IkariYarare2":
			if (typeof(YarareTypes).IsEnum)
			{
				_0024var_0024IkariYarare2 = (YarareTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "IkariYarare3":
			if (typeof(YarareTypes).IsEnum)
			{
				_0024var_0024IkariYarare3 = (YarareTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "IkariYarare4":
			if (typeof(YarareTypes).IsEnum)
			{
				_0024var_0024IkariYarare4 = (YarareTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "IkariYarare5":
			if (typeof(YarareTypes).IsEnum)
			{
				_0024var_0024IkariYarare5 = (YarareTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "WeakStyle":
			if (typeof(EnumStyles).IsEnum)
			{
				_0024var_0024WeakStyle = (EnumStyles)MasterBaseClass.ToEnum(val);
			}
			break;
		case "Poison":
			_0024var_0024Poison = MasterBaseClass.ToInt(val);
			break;
		case "Conflict":
			_0024var_0024Conflict = MasterBaseClass.ToInt(val);
			break;
		case "Stun":
			_0024var_0024Stun = MasterBaseClass.ToInt(val);
			break;
		case "Slow":
			_0024var_0024Slow = MasterBaseClass.ToInt(val);
			break;
		case "Blind":
			_0024var_0024Blind = MasterBaseClass.ToInt(val);
			break;
		case "Burn":
			_0024var_0024Burn = MasterBaseClass.ToInt(val);
			break;
		case "Hate":
			_0024var_0024Hate = MasterBaseClass.ToInt(val);
			break;
		case "Small":
			_0024var_0024Small = MasterBaseClass.ToInt(val);
			break;
		case "Freeze":
			_0024var_0024Freeze = MasterBaseClass.ToInt(val);
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
			"Detail" => true, 
			"MRaceId" => true, 
			"MElementId" => true, 
			"Icon" => true, 
			"PrefabName" => true, 
			"BattleParams" => true, 
			"LevelMax" => true, 
			"DefenseMin" => true, 
			"DefenseMax" => true, 
			"DefenseExp" => true, 
			"AcqExpMin" => true, 
			"AcqExpMax" => true, 
			"AcqExpExp" => true, 
			"AcqCoinMin" => true, 
			"AcqCoinMax" => true, 
			"AcqCoinExp" => true, 
			"EliteResistMin" => true, 
			"EliteResistMax" => true, 
			"EliteResistExp" => true, 
			"LevelUpType" => true, 
			"EliteSpeedMult" => true, 
			"EliteAbnormalStateRateMult" => true, 
			"EliteColorR" => true, 
			"EliteColorG" => true, 
			"EliteColorB" => true, 
			"EliteColorA" => true, 
			"IkariLevel1" => true, 
			"IkariLevel2" => true, 
			"IkariLevel3" => true, 
			"IkariLevel4" => true, 
			"IkariLevel5" => true, 
			"IkariMotSpeed1" => true, 
			"IkariMotSpeed2" => true, 
			"IkariMotSpeed3" => true, 
			"IkariMotSpeed4" => true, 
			"IkariMotSpeed5" => true, 
			"IkariYarare1" => true, 
			"IkariYarare2" => true, 
			"IkariYarare3" => true, 
			"IkariYarare4" => true, 
			"IkariYarare5" => true, 
			"WeakStyle" => true, 
			"Poison" => true, 
			"Conflict" => true, 
			"Stun" => true, 
			"Slow" => true, 
			"Blind" => true, 
			"Burn" => true, 
			"Hate" => true, 
			"Small" => true, 
			"Freeze" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		lhs = (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[52]
		{
			"Id", "Name", "Detail", "MRaceId", "MElementId", "Icon", "PrefabName", "LevelMax", "DefenseMin", "DefenseMax",
			"DefenseExp", "AcqExpMin", "AcqExpMax", "AcqExpExp", "AcqCoinMin", "AcqCoinMax", "AcqCoinExp", "EliteResistMin", "EliteResistMax", "EliteResistExp",
			"LevelUpType", "EliteSpeedMult", "EliteAbnormalStateRateMult", "EliteColorR", "EliteColorG", "EliteColorB", "EliteColorA", "IkariLevel1", "IkariLevel2", "IkariLevel3",
			"IkariLevel4", "IkariLevel5", "IkariMotSpeed1", "IkariMotSpeed2", "IkariMotSpeed3", "IkariMotSpeed4", "IkariMotSpeed5", "IkariYarare1", "IkariYarare2", "IkariYarare3",
			"IkariYarare4", "IkariYarare5", "WeakStyle", "Poison", "Conflict", "Stun", "Slow", "Blind", "Burn", "Hate",
			"Small", "Freeze"
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
						_0024var_0024Detail = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024MRaceId = MasterBaseClass.ParseInt(vals[3]);
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
										_0024var_0024PrefabName = vals[6];
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024LevelMax = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024DefenseMin = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024DefenseMax = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024DefenseExp = MasterBaseClass.ParseSingle(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024AcqExpMin = MasterBaseClass.ParseInt(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024AcqExpMax = MasterBaseClass.ParseInt(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024AcqExpExp = MasterBaseClass.ParseSingle(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024AcqCoinMin = MasterBaseClass.ParseInt(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null)
																		{
																			_0024var_0024AcqCoinMax = MasterBaseClass.ParseInt(vals[15]);
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null)
																			{
																				_0024var_0024AcqCoinExp = MasterBaseClass.ParseSingle(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null)
																				{
																					_0024var_0024EliteResistMin = MasterBaseClass.ParseInt(vals[17]);
																				}
																				if (length <= 18)
																				{
																					result = 18;
																				}
																				else
																				{
																					if (vals[18] != null)
																					{
																						_0024var_0024EliteResistMax = MasterBaseClass.ParseInt(vals[18]);
																					}
																					if (length <= 19)
																					{
																						result = 19;
																					}
																					else
																					{
																						if (vals[19] != null)
																						{
																							_0024var_0024EliteResistExp = MasterBaseClass.ParseSingle(vals[19]);
																						}
																						if (length <= 20)
																						{
																							result = 20;
																						}
																						else
																						{
																							if (vals[20] != null && typeof(EnumLevelUpTypes).IsEnum)
																							{
																								_0024var_0024LevelUpType = (EnumLevelUpTypes)MasterBaseClass.ParseEnum(vals[20]);
																							}
																							if (length <= 21)
																							{
																								result = 21;
																							}
																							else
																							{
																								if (vals[21] != null)
																								{
																									_0024var_0024EliteSpeedMult = MasterBaseClass.ParseSingle(vals[21]);
																								}
																								if (length <= 22)
																								{
																									result = 22;
																								}
																								else
																								{
																									if (vals[22] != null)
																									{
																										_0024var_0024EliteAbnormalStateRateMult = MasterBaseClass.ParseSingle(vals[22]);
																									}
																									if (length <= 23)
																									{
																										result = 23;
																									}
																									else
																									{
																										if (vals[23] != null)
																										{
																											_0024var_0024EliteColorR = MasterBaseClass.ParseSingle(vals[23]);
																										}
																										if (length <= 24)
																										{
																											result = 24;
																										}
																										else
																										{
																											if (vals[24] != null)
																											{
																												_0024var_0024EliteColorG = MasterBaseClass.ParseSingle(vals[24]);
																											}
																											if (length <= 25)
																											{
																												result = 25;
																											}
																											else
																											{
																												if (vals[25] != null)
																												{
																													_0024var_0024EliteColorB = MasterBaseClass.ParseSingle(vals[25]);
																												}
																												if (length <= 26)
																												{
																													result = 26;
																												}
																												else
																												{
																													if (vals[26] != null)
																													{
																														_0024var_0024EliteColorA = MasterBaseClass.ParseSingle(vals[26]);
																													}
																													if (length <= 27)
																													{
																														result = 27;
																													}
																													else
																													{
																														if (vals[27] != null)
																														{
																															_0024var_0024IkariLevel1 = MasterBaseClass.ParseInt(vals[27]);
																														}
																														if (length <= 28)
																														{
																															result = 28;
																														}
																														else
																														{
																															if (vals[28] != null)
																															{
																																_0024var_0024IkariLevel2 = MasterBaseClass.ParseInt(vals[28]);
																															}
																															if (length <= 29)
																															{
																																result = 29;
																															}
																															else
																															{
																																if (vals[29] != null)
																																{
																																	_0024var_0024IkariLevel3 = MasterBaseClass.ParseInt(vals[29]);
																																}
																																if (length <= 30)
																																{
																																	result = 30;
																																}
																																else
																																{
																																	if (vals[30] != null)
																																	{
																																		_0024var_0024IkariLevel4 = MasterBaseClass.ParseInt(vals[30]);
																																	}
																																	if (length <= 31)
																																	{
																																		result = 31;
																																	}
																																	else
																																	{
																																		if (vals[31] != null)
																																		{
																																			_0024var_0024IkariLevel5 = MasterBaseClass.ParseInt(vals[31]);
																																		}
																																		if (length <= 32)
																																		{
																																			result = 32;
																																		}
																																		else
																																		{
																																			if (vals[32] != null)
																																			{
																																				_0024var_0024IkariMotSpeed1 = MasterBaseClass.ParseInt(vals[32]);
																																			}
																																			if (length <= 33)
																																			{
																																				result = 33;
																																			}
																																			else
																																			{
																																				if (vals[33] != null)
																																				{
																																					_0024var_0024IkariMotSpeed2 = MasterBaseClass.ParseInt(vals[33]);
																																				}
																																				if (length <= 34)
																																				{
																																					result = 34;
																																				}
																																				else
																																				{
																																					if (vals[34] != null)
																																					{
																																						_0024var_0024IkariMotSpeed3 = MasterBaseClass.ParseInt(vals[34]);
																																					}
																																					if (length <= 35)
																																					{
																																						result = 35;
																																					}
																																					else
																																					{
																																						if (vals[35] != null)
																																						{
																																							_0024var_0024IkariMotSpeed4 = MasterBaseClass.ParseInt(vals[35]);
																																						}
																																						if (length <= 36)
																																						{
																																							result = 36;
																																						}
																																						else
																																						{
																																							if (vals[36] != null)
																																							{
																																								_0024var_0024IkariMotSpeed5 = MasterBaseClass.ParseInt(vals[36]);
																																							}
																																							if (length <= 37)
																																							{
																																								result = 37;
																																							}
																																							else
																																							{
																																								if (vals[37] != null && typeof(YarareTypes).IsEnum)
																																								{
																																									_0024var_0024IkariYarare1 = (YarareTypes)MasterBaseClass.ParseEnum(vals[37]);
																																								}
																																								if (length <= 38)
																																								{
																																									result = 38;
																																								}
																																								else
																																								{
																																									if (vals[38] != null && typeof(YarareTypes).IsEnum)
																																									{
																																										_0024var_0024IkariYarare2 = (YarareTypes)MasterBaseClass.ParseEnum(vals[38]);
																																									}
																																									if (length <= 39)
																																									{
																																										result = 39;
																																									}
																																									else
																																									{
																																										if (vals[39] != null && typeof(YarareTypes).IsEnum)
																																										{
																																											_0024var_0024IkariYarare3 = (YarareTypes)MasterBaseClass.ParseEnum(vals[39]);
																																										}
																																										if (length <= 40)
																																										{
																																											result = 40;
																																										}
																																										else
																																										{
																																											if (vals[40] != null && typeof(YarareTypes).IsEnum)
																																											{
																																												_0024var_0024IkariYarare4 = (YarareTypes)MasterBaseClass.ParseEnum(vals[40]);
																																											}
																																											if (length <= 41)
																																											{
																																												result = 41;
																																											}
																																											else
																																											{
																																												if (vals[41] != null && typeof(YarareTypes).IsEnum)
																																												{
																																													_0024var_0024IkariYarare5 = (YarareTypes)MasterBaseClass.ParseEnum(vals[41]);
																																												}
																																												if (length <= 42)
																																												{
																																													result = 42;
																																												}
																																												else
																																												{
																																													if (vals[42] != null && typeof(EnumStyles).IsEnum)
																																													{
																																														_0024var_0024WeakStyle = (EnumStyles)MasterBaseClass.ParseEnum(vals[42]);
																																													}
																																													if (length <= 43)
																																													{
																																														result = 43;
																																													}
																																													else
																																													{
																																														if (vals[43] != null)
																																														{
																																															_0024var_0024Poison = MasterBaseClass.ParseInt(vals[43]);
																																														}
																																														if (length <= 44)
																																														{
																																															result = 44;
																																														}
																																														else
																																														{
																																															if (vals[44] != null)
																																															{
																																																_0024var_0024Conflict = MasterBaseClass.ParseInt(vals[44]);
																																															}
																																															if (length <= 45)
																																															{
																																																result = 45;
																																															}
																																															else
																																															{
																																																if (vals[45] != null)
																																																{
																																																	_0024var_0024Stun = MasterBaseClass.ParseInt(vals[45]);
																																																}
																																																if (length <= 46)
																																																{
																																																	result = 46;
																																																}
																																																else
																																																{
																																																	if (vals[46] != null)
																																																	{
																																																		_0024var_0024Slow = MasterBaseClass.ParseInt(vals[46]);
																																																	}
																																																	if (length <= 47)
																																																	{
																																																		result = 47;
																																																	}
																																																	else
																																																	{
																																																		if (vals[47] != null)
																																																		{
																																																			_0024var_0024Blind = MasterBaseClass.ParseInt(vals[47]);
																																																		}
																																																		if (length <= 48)
																																																		{
																																																			result = 48;
																																																		}
																																																		else
																																																		{
																																																			if (vals[48] != null)
																																																			{
																																																				_0024var_0024Burn = MasterBaseClass.ParseInt(vals[48]);
																																																			}
																																																			if (length <= 49)
																																																			{
																																																				result = 49;
																																																			}
																																																			else
																																																			{
																																																				if (vals[49] != null)
																																																				{
																																																					_0024var_0024Hate = MasterBaseClass.ParseInt(vals[49]);
																																																				}
																																																				if (length <= 50)
																																																				{
																																																					result = 50;
																																																				}
																																																				else
																																																				{
																																																					if (vals[50] != null)
																																																					{
																																																						_0024var_0024Small = MasterBaseClass.ParseInt(vals[50]);
																																																					}
																																																					if (length <= 51)
																																																					{
																																																						result = 51;
																																																					}
																																																					else
																																																					{
																																																						if (vals[51] != null)
																																																						{
																																																							_0024var_0024Freeze = MasterBaseClass.ParseInt(vals[51]);
																																																						}
																																																						int num = 52;
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
