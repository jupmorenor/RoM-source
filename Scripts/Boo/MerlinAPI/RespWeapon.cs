using System;
using System.Collections;
using System.Text;
using Boo.Lang.Runtime;
using CompilerGenerated;
using ParamCalc;
using UnityEngine;

namespace MerlinAPI;

[Serializable]
public class RespWeapon : JsonBase
{
	[Serializable]
	internal class _0024CalcAddPlusBonusCost_0024locals_002414454
	{
		internal int _0024plusRate;
	}

	[Serializable]
	internal class _0024CalcAddPlusBonusCost_0024f_00244006
	{
		internal _0024CalcAddPlusBonusCost_0024locals_002414454 _0024_0024locals_002415008;

		public _0024CalcAddPlusBonusCost_0024f_00244006(_0024CalcAddPlusBonusCost_0024locals_002414454 _0024_0024locals_002415008)
		{
			this._0024_0024locals_002415008 = _0024_0024locals_002415008;
		}

		public int Invoke(int n)
		{
			return checked((int)((float)_0024_0024locals_002415008._0024plusRate * (0.5f * (float)n * (float)(n + 1))));
		}
	}

	private RespPlayerBox _refPlayerBox;

	private int _favorite;

	private bool _0024initialized__MerlinAPI_RespWeapon_0024;

	public RespPlayerBox RefPlayerBox
	{
		get
		{
			return _refPlayerBox;
		}
		set
		{
			if (value != null)
			{
				_refPlayerBox = value;
			}
		}
	}

	public BoxId Id
	{
		get
		{
			return RefPlayerBox.Id;
		}
		set
		{
			RefPlayerBox.Id = value;
			if (value.IsValid && UserData.Current != null && UserData.Current.userMiscInfo.weaponFavoriteData.isFavor(value))
			{
				_favorite = 1;
			}
		}
	}

	public int MWeaponId
	{
		get
		{
			return RefPlayerBox.ItemId;
		}
		set
		{
			RefPlayerBox.ItemId = value;
		}
	}

	public int AngelSkillLevel
	{
		get
		{
			return RefPlayerBox.SkillLevel_1;
		}
		set
		{
			RefPlayerBox.SkillLevel_1 = value;
		}
	}

	public int AttackBonus
	{
		get
		{
			return RefPlayerBox.AttackBonus;
		}
		set
		{
			RefPlayerBox.AttackBonus = value;
		}
	}

	public int AttackPlusBonus
	{
		get
		{
			return RefPlayerBox.AttackPlusBonus;
		}
		set
		{
			RefPlayerBox.AttackPlusBonus = value;
		}
	}

	public int CoverSkillLevel
	{
		get
		{
			return RefPlayerBox.SkillLevel_3;
		}
		set
		{
			RefPlayerBox.SkillLevel_3 = value;
		}
	}

	public int DemonSkillLevel
	{
		get
		{
			return RefPlayerBox.SkillLevel_2;
		}
		set
		{
			RefPlayerBox.SkillLevel_2 = value;
		}
	}

	public int Exp
	{
		get
		{
			return RefPlayerBox.Exp;
		}
		set
		{
			RefPlayerBox.Exp = value;
		}
	}

	public int HpBonus
	{
		get
		{
			return RefPlayerBox.HpBonus;
		}
		set
		{
			RefPlayerBox.HpBonus = value;
		}
	}

	public int HpPlusBonus
	{
		get
		{
			return RefPlayerBox.HpPlusBonus;
		}
		set
		{
			RefPlayerBox.HpPlusBonus = value;
		}
	}

	public int Level
	{
		get
		{
			return RefPlayerBox.Level;
		}
		set
		{
			RefPlayerBox.Level = value;
		}
	}

	public int LevelMax
	{
		get
		{
			return RefPlayerBox.LevelMax;
		}
		set
		{
			RefPlayerBox.LevelMax = value;
		}
	}

	public int LimitBreakCount
	{
		get
		{
			return RefPlayerBox.LimitBreakCount;
		}
		set
		{
			RefPlayerBox.LimitBreakCount = value;
		}
	}

	public int TPlayerId
	{
		get
		{
			return RefPlayerBox.TPlayerId;
		}
		set
		{
			RefPlayerBox.TPlayerId = value;
		}
	}

	public int TraitId
	{
		get
		{
			return RefPlayerBox.TraitId;
		}
		set
		{
			RefPlayerBox.TraitId = value;
		}
	}

	public bool IsValidMaster => MWeapons.Get(MWeaponId) != null;

	public bool IsValidInBox => Id.IsValid;

	public MWeapons Master
	{
		get
		{
			MWeapons mWeapons = MWeapons.Get(MWeaponId);
			if (mWeapons == null)
			{
				throw new AssertionFailedException(new StringBuilder("武器マスターエラー！ BoxID:").Append(Id).Append(" MWeaponID=").Append((object)MWeaponId)
					.Append(" == null")
					.ToString());
			}
			return mWeapons;
		}
	}

	public string Name => UIBasicUtility.GetItemNameAddID(Master.Name, Master.Id);

	public string Detail => Master.Explain.ToString();

	public string Icon => Master.Icon;

	public MElements Element => Master.MElementId;

	public int ElementId => (Element != null) ? Element.Id : 0;

	public string ElementIcon => (Element == null) ? string.Empty : Element.WeaponIcon;

	public string ElementMainIcon => (Element == null) ? string.Empty : Element.MainIcon;

	public int Cost => Master.Cost;

	public int DeckCost => Master.DeckCost;

	public MStyles Style => Master.StyleId;

	public int StyleId => (Master.StyleId != null) ? Master.StyleId.Id : 0;

	public MRares Rare => Master.Rare;

	public MWeapons[] EvolutionMaterials => new MWeapons[5] { Master.EvoMaterialId_1, Master.EvoMaterialId_2, Master.EvoMaterialId_3, Master.EvoMaterialId_4, Master.EvoMaterialId_5 };

	public bool IsLevelLimit
	{
		get
		{
			bool num = LevelLimitMax <= Level;
			if (!num)
			{
				num = CurrentLevelLimit <= Level;
			}
			return num;
		}
	}

	public bool IsAngelSkillLevelLimit => AngelSkill.LevelMax <= AngelSkillLevel;

	public bool IsDemonSkillLevelLimit => DemonSkill.LevelMax <= DemonSkillLevel;

	public bool IsCoverSkillLevelLimit => CoverSkill == null || CoverSkill.LevelMax <= CoverSkillLevel;

	public int CapExp => Mathf.Clamp(Exp, LevelExp, LevelUpExp);

	public int LevelUpNeedExp => checked(LevelUpExpDist - LevelExpDist);

	public int LevelExpDist => checked(Exp - LevelExp);

	public int LevelUpExpDist => checked(LevelUpExp - LevelExp);

	public int LevelExp => checked((int)Master.exp(Level));

	public int LevelUpExp => checked((int)Master.exp(Mathf.Clamp(Level + 1, Level, CurrentLevelLimit)));

	public int LevelLimitMax => Master.LevelLimitMax;

	public int LevelLimitMin => Master.LevelLimitMin;

	public int CurrentLevelLimit => checked(Master.LevelLimitMin + LimitBrakeAdd);

	public int LimitBrakeAddLevel => MGameParameters.findByGameParameterId(9).Param;

	public int LimitBrakeAdd => checked(LimitBreakCount * LimitBrakeAddLevel);

	public int LimitBreakCountLimit => checked(LevelLimitMax - LevelLimitMin) / LimitBrakeAddLevel;

	public bool IsLimitBrakeLimit => LimitBreakCountLimit <= LimitBreakCount;

	public Color LevelColor => IsLimitBrakeLimit ? StaticLevelColor.LIMIT_BREAK_MAX : ((0 >= LimitBreakCount) ? StaticLevelColor.NORMAL : StaticLevelColor.LIMIT_BREAK);

	public int AcqExp => ParamCalcModule.ComputeGrowthInt(Level, LevelLimitMax, Master.AcqExpMin, Master.AcqExpMax, Master.AcqExpExp, "素材武器の合成経験値");

	public MWeaponSkills AngelSkill => Master.AngelSkillId;

	public MWeaponSkills DemonSkill => Master.DemonSkillId;

	public MCoverSkills CoverSkill => Master.CoverSkillId;

	public float AngelSkillCoolDown => AngelSkill.CurrentCoolDown(AngelSkillLevel);

	public float DemonSkillCoolDown => DemonSkill.CurrentCoolDown(DemonSkillLevel);

	public int SellPrice => checked(Master.price(Level) + SumPlusBonus * MGameParameters.findByGameParameterId(66).Param);

	public int ActualAttack => checked(Attack + AttackBonus);

	public int ActualHP => checked(HP + HpBonus);

	public float TotalAttack => Mathf.Floor((float)ActualAttack * TraitAttackScale + PlusAttackStatus);

	public float TotalHP => Mathf.Floor((float)ActualHP * TraitHPScale + PlusHPStatus);

	public float PlusAttackStatus => RefPlayerBox.PlusAttackStatus;

	public float PlusHPStatus => RefPlayerBox.PlusHPStatus;

	public float TraitAttackScale => MTraits.GetAttackCoef(TraitId);

	public float TraitHPScale => MTraits.GetHpCoef(TraitId);

	public int Attack => checked((int)Master.attack(Level));

	public int HP => checked((int)Master.hp(Level));

	public int Critical => checked((int)Master.critical(Level));

	public int BreakPow => checked((int)Master.breakPow(Level));

	public int Resist => checked((int)Master.resist(Level));

	public string PrefabPath
	{
		get
		{
			string prefabName = Master.PrefabName;
			return "Prefab/Weapons/" + prefabName.Substring(0, prefabName.IndexOf("_")) + "/" + prefabName;
		}
	}

	public bool ColosseumCoverDisabled
	{
		get
		{
			bool num = Master.CoverSkillId != null;
			if (num)
			{
				num = Master.CoverSkillId.DisableColosseum;
			}
			return num;
		}
	}

	public string TraitSpriteName => MTraits.GetSpriteName(TraitId);

	public int PlusBonusMax => MGameParameters.findByGameParameterId(61).Param;

	public int SumPlusBonus => checked(AttackPlusBonus + HpPlusBonus);

	public bool IsAttackPlusBonusMax => PlusBonusMax <= AttackPlusBonus;

	public bool IsHpPlusBonusMax => PlusBonusMax <= HpPlusBonus;

	public bool CanMorePowup
	{
		get
		{
			int result;
			if (!Master.CanPowup())
			{
				result = 0;
			}
			else
			{
				if (LevelLimitMax <= Level)
				{
					bool isCoverSkillLevelLimit = IsCoverSkillLevelLimit;
					bool isAngelSkillLevelLimit = IsAngelSkillLevelLimit;
					bool isDemonSkillLevelLimit = IsDemonSkillLevelLimit;
					bool isAttackPlusBonusMax = IsAttackPlusBonusMax;
					bool isHpPlusBonusMax = IsHpPlusBonusMax;
					if (isCoverSkillLevelLimit && isAngelSkillLevelLimit && isDemonSkillLevelLimit && isAttackPlusBonusMax && isHpPlusBonusMax)
					{
						result = 0;
						goto IL_0071;
					}
				}
				result = 1;
			}
			goto IL_0071;
			IL_0071:
			return (byte)result != 0;
		}
	}

	public bool CanEvolution => Master.EvolutionWeaponId != null;

	public bool CanUltEvolution => MEvolutionInformations.Has(1, Master.Id);

	public int favorite
	{
		get
		{
			return _favorite;
		}
		set
		{
			_favorite = value;
		}
	}

	public RespWeapon()
	{
		if (!_0024initialized__MerlinAPI_RespWeapon_0024)
		{
			_0024initialized__MerlinAPI_RespWeapon_0024 = true;
		}
	}

	public RespWeapon(int mstid)
	{
		if (!_0024initialized__MerlinAPI_RespWeapon_0024)
		{
			_0024initialized__MerlinAPI_RespWeapon_0024 = true;
		}
		init(MWeapons.Get(mstid));
	}

	public RespWeapon(MWeapons mst)
	{
		if (!_0024initialized__MerlinAPI_RespWeapon_0024)
		{
			_0024initialized__MerlinAPI_RespWeapon_0024 = true;
		}
		init(mst);
	}

	public override string ToString()
	{
		return new StringBuilder("RespWeapon(").Append((object)MWeaponId).Append(":").Append(Name)
			.Append(":lv")
			.Append((object)Level)
			.Append(":atk=")
			.Append(TotalAttack)
			.Append(":hp=")
			.Append(TotalHP)
			.Append(")")
			.ToString();
	}

	public RespReward ToReward(int tmpId)
	{
		RespReward respReward = new RespReward();
		respReward.Id = tmpId;
		respReward.MasterTypeValue = 3;
		respReward.IsGet = true;
		respReward.ItemId = Master.Id;
		respReward.Level = Level;
		respReward.Quantity = 1;
		respReward.Title = Name;
		respReward.Explain = Name;
		respReward.TraitId = TraitId;
		return respReward;
	}

	public void init(MWeapons mst)
	{
		if (mst == null)
		{
		}
		RefPlayerBox = new RespPlayerBox();
		RefPlayerBox.ItemType = 1;
		AngelSkillLevel = 1;
		AttackBonus = 0;
		CoverSkillLevel = 1;
		DemonSkillLevel = 1;
		Exp = 0;
		HpBonus = 0;
		Id = BoxId.InvalidId;
		Level = 1;
		LevelMax = 1;
		MWeaponId = mst?.Id ?? 0;
		TPlayerId = 0;
		_favorite = 0;
		TraitId = 0;
	}

	public RespWeapon Clone()
	{
		RespWeapon respWeapon = new RespWeapon(RefPlayerBox.ItemType);
		respWeapon.RefPlayerBox = RefPlayerBox.Clone();
		if (UserData.Current != null)
		{
			respWeapon.favorite = (UserData.Current.IsFavorite(RefPlayerBox) ? 1 : 0);
		}
		return respWeapon;
	}

	public bool LevelUpSimulate(RespWeapon[] respWeapons, ref int dstNewExp, ref int dstNeedCost)
	{
		dstNewExp = Exp;
		dstNeedCost = 0;
		int num = 0;
		int num2 = SumPlusBonus;
		int i = 0;
		int result;
		checked
		{
			for (int length = respWeapons.Length; i < length; i++)
			{
				if (respWeapons[i] != null)
				{
					num++;
					int acqExp = respWeapons[i].AcqExp;
					int num3 = 10;
					if (RuntimeServices.EqualityOperator(Element, respWeapons[i].Element))
					{
						num3 += 5;
					}
					if (StyleId == respWeapons[i].StyleId)
					{
						num3 += 5;
					}
					acqExp = (int)((float)acqExp * ((float)num3 / 10f));
					dstNewExp += acqExp;
					num2 += respWeapons[i].SumPlusBonus;
				}
			}
			num2 = Mathf.Clamp(num2, SumPlusBonus, PlusBonusMax * 2);
			if (num == 0)
			{
				result = 0;
			}
			else
			{
				dstNeedCost = Level * 100 * num + CalcAddPlusBonusCost(SumPlusBonus, num2);
				result = 1;
			}
		}
		return (byte)result != 0;
	}

	public int CalcAddPlusBonusCost(int prev, int next)
	{
		_0024CalcAddPlusBonusCost_0024locals_002414454 _0024CalcAddPlusBonusCost_0024locals_0024 = new _0024CalcAddPlusBonusCost_0024locals_002414454();
		_0024CalcAddPlusBonusCost_0024locals_0024._0024plusRate = MGameParameters.findByGameParameterId(62).Param;
		__RespWeapon_CalcAddPlusBonusCost_0024callable180_0024358_13__ _RespWeapon_CalcAddPlusBonusCost_0024callable180_0024358_13__ = new _0024CalcAddPlusBonusCost_0024f_00244006(_0024CalcAddPlusBonusCost_0024locals_0024).Invoke;
		return checked(_RespWeapon_CalcAddPlusBonusCost_0024callable180_0024358_13__(next) - _RespWeapon_CalcAddPlusBonusCost_0024callable180_0024358_13__(prev));
	}

	public float damageScale(EnumElements vs)
	{
		return MElementCorrelations.GetRate((EnumElements)Element.Id, vs);
	}

	public string toNguiJson()
	{
		Hashtable hashtable = new Hashtable();
		hashtable["MWeaponId"] = MWeaponId;
		hashtable["AngelSkillLevel"] = AngelSkillLevel;
		hashtable["AttackBonus"] = AttackBonus;
		hashtable["AttackPlusBonus"] = AttackPlusBonus;
		hashtable["CoverSkillLevel"] = CoverSkillLevel;
		hashtable["DemonSkillLevel"] = DemonSkillLevel;
		hashtable["Exp"] = Exp;
		hashtable["HpBonus"] = HpBonus;
		hashtable["HpPlusBonus"] = HpPlusBonus;
		hashtable["Level"] = Level;
		hashtable["LevelMax"] = LevelMax;
		hashtable["LimitBreakCount"] = LimitBreakCount;
		hashtable["TPlayerId"] = TPlayerId;
		hashtable["TraitId"] = TraitId;
		return NGUIJson.jsonEncode(hashtable);
	}

	public static RespWeapon fromNguiJson(string nj)
	{
		RespWeapon respWeapon = new RespWeapon();
		respWeapon.RefPlayerBox = new RespPlayerBox();
		respWeapon.Id = BoxId.InvalidId;
		Hashtable hashtable = NGUIJson.jsonDecode(nj) as Hashtable;
		if (hashtable.ContainsKey("MWeaponId"))
		{
			respWeapon.MWeaponId = RuntimeServices.UnboxInt32(hashtable["MWeaponId"]);
		}
		if (hashtable.ContainsKey("AngelSkillLevel"))
		{
			respWeapon.AngelSkillLevel = RuntimeServices.UnboxInt32(hashtable["AngelSkillLevel"]);
		}
		if (hashtable.ContainsKey("AttackBonus"))
		{
			respWeapon.AttackBonus = RuntimeServices.UnboxInt32(hashtable["AttackBonus"]);
		}
		if (hashtable.ContainsKey("AttackPlusBonus"))
		{
			respWeapon.AttackPlusBonus = RuntimeServices.UnboxInt32(hashtable["AttackPlusBonus"]);
		}
		if (hashtable.ContainsKey("CoverSkillLevel"))
		{
			respWeapon.CoverSkillLevel = RuntimeServices.UnboxInt32(hashtable["CoverSkillLevel"]);
		}
		if (hashtable.ContainsKey("DemonSkillLevel"))
		{
			respWeapon.DemonSkillLevel = RuntimeServices.UnboxInt32(hashtable["DemonSkillLevel"]);
		}
		if (hashtable.ContainsKey("Exp"))
		{
			respWeapon.Exp = RuntimeServices.UnboxInt32(hashtable["Exp"]);
		}
		if (hashtable.ContainsKey("HpBonus"))
		{
			respWeapon.HpBonus = RuntimeServices.UnboxInt32(hashtable["HpBonus"]);
		}
		if (hashtable.ContainsKey("HpPlusBonus"))
		{
			respWeapon.HpPlusBonus = RuntimeServices.UnboxInt32(hashtable["HpPlusBonus"]);
		}
		if (hashtable.ContainsKey("Level"))
		{
			respWeapon.Level = RuntimeServices.UnboxInt32(hashtable["Level"]);
		}
		if (hashtable.ContainsKey("LevelMax"))
		{
			respWeapon.LevelMax = RuntimeServices.UnboxInt32(hashtable["LevelMax"]);
		}
		if (hashtable.ContainsKey("LimitBreakCount"))
		{
			respWeapon.LimitBreakCount = RuntimeServices.UnboxInt32(hashtable["LimitBreakCount"]);
		}
		if (hashtable.ContainsKey("TPlayerId"))
		{
			respWeapon.TPlayerId = RuntimeServices.UnboxInt32(hashtable["TPlayerId"]);
		}
		if (hashtable.ContainsKey("TraitId"))
		{
			respWeapon.TraitId = RuntimeServices.UnboxInt32(hashtable["TraitId"]);
		}
		return respWeapon;
	}
}
