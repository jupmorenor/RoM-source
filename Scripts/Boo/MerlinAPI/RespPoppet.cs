using System;
using System.Collections;
using System.Text;
using Boo.Lang.Runtime;
using CompilerGenerated;
using ParamCalc;
using UnityEngine;

namespace MerlinAPI;

[Serializable]
public class RespPoppet : JsonBase
{
	[Serializable]
	internal class _0024CalcAddPlusBonusCost_0024locals_002414455
	{
		internal int _0024plusRate;
	}

	[Serializable]
	internal class _0024CalcAddPlusBonusCost_0024f_00244019
	{
		internal _0024CalcAddPlusBonusCost_0024locals_002414455 _0024_0024locals_002415009;

		public _0024CalcAddPlusBonusCost_0024f_00244019(_0024CalcAddPlusBonusCost_0024locals_002414455 _0024_0024locals_002415009)
		{
			this._0024_0024locals_002415009 = _0024_0024locals_002415009;
		}

		public int Invoke(int n)
		{
			return checked((int)((float)_0024_0024locals_002415009._0024plusRate * (0.5f * (float)n * (float)(n + 1))));
		}
	}

	private RespPlayerBox _refPlayerBox;

	private int _favorite;

	private bool _0024initialized__MerlinAPI_RespPoppet_0024;

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
			if (value.IsValid && UserData.Current != null && UserData.Current.userMiscInfo.poppetFavoriteData.isFavor(value))
			{
				_favorite = 1;
			}
		}
	}

	public int MPoppetId
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

	public int ChainSkillLevel
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

	public int CoverSkillLevel_1
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

	public int CoverSkillLevel_2
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

	public bool IsValidMaster => MPoppets.Get(MPoppetId) != null;

	public bool IsValidInBox => Id.IsValid;

	public MPoppets Master
	{
		get
		{
			MPoppets mPoppets = MPoppets.Get(MPoppetId);
			if (mPoppets == null)
			{
				throw new AssertionFailedException(new StringBuilder("魔ペットマスターエラー!: BoxID:").Append(Id).Append(" MPoppetId=").Append((object)MPoppetId)
					.Append(" == null")
					.ToString());
			}
			return mPoppets;
		}
	}

	public MMonsters MonsterMaster => MMonsters.Get(MPoppetId);

	public string Name
	{
		get
		{
			MTexts name = Master.Name;
			if (name == null)
			{
				throw new AssertionFailedException(new StringBuilder("魔ペットマスターエラー(no name)!: BoxID:").Append(Id).Append(" MPoppetId=").Append((object)MPoppetId)
					.Append(" == null")
					.ToString());
			}
			return UIBasicUtility.GetItemNameAddID(name, Master.Id);
		}
	}

	public string Detail => "???";

	public string Icon => Master.Icon;

	public MElements Element => Master.MElementId;

	public int ElementId => (Element != null) ? Element.Id : 0;

	public string ElementIcon => Element.PoppetIcon;

	public string ElementMainIcon => (Element == null) ? string.Empty : Element.MainIcon;

	public EnumRaces Race => (EnumRaces)Master.MRaceId.Id;

	public MRares Rare => Master.Rare;

	public MChainSkills ChainSkill => Master.ChainSkillId;

	public int Cost => Master.Cost;

	public int DeckCost => Master.DeckCost;

	public float RequiredMagicPoint => ChainSkill?.getEffectValue(ChainSkillLevel) ?? 0f;

	public MCoverSkills CoverSkill1 => Master.CoverSkillId_1;

	public MCoverSkills CoverSkill2 => Master.CoverSkillId_2;

	public float ChainSkillValue => (ChainSkill != null) ? ChainSkill.getEffectValue(ChainSkillLevel) : 0f;

	public float ChainSkillValueAsRate => (ChainSkill != null) ? ChainSkill.getEffectValueAsRate(ChainSkillLevel) : 0f;

	public MPoppets[] EvolutionMaterials => new MPoppets[5] { Master.EvoMaterialId_1, Master.EvoMaterialId_2, Master.EvoMaterialId_3, Master.EvoMaterialId_4, Master.EvoMaterialId_5 };

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

	public bool IsChainSkillLevelMax => ChainSkill.LevelMax <= ChainSkillLevel;

	public bool IsCoverSkill1LevelMax => CoverSkill1 == null || CoverSkill1.LevelMax <= CoverSkillLevel_1;

	public bool IsCoverSkill2LevelMax => CoverSkill2 == null || CoverSkill2.LevelMax <= CoverSkillLevel_2;

	public int CapExp => Mathf.Clamp(Exp, LevelExp, LevelUpExp);

	public int LevelUpNeedExp => checked(LevelUpExpDist - LevelExpDist);

	public int LevelExpDist => checked(Exp - LevelExp);

	public int LevelUpExpDist => checked(LevelUpExp - LevelExp);

	public int LevelExp => Master.exp(Level);

	public int LevelUpExp => Master.exp(Mathf.Clamp(checked(Level + 1), Level, CurrentLevelLimit));

	public int LevelLimitMax => Master.LevelLimitMax;

	public int LevelLimitMin => Master.LevelLimitMin;

	public int CurrentLevelLimit => checked(Master.LevelLimitMin + LimitBrakeAdd);

	public int LimitBrakeAddLevel => MGameParameters.findByGameParameterId(9).Param;

	public int LimitBrakeAdd => checked(LimitBreakCount * LimitBrakeAddLevel);

	public int LimitBreakCountLimit => checked(LevelLimitMax - LevelLimitMin) / LimitBrakeAddLevel;

	public bool IsLimitBrakeLimit => LimitBreakCountLimit <= LimitBreakCount;

	public Color LevelColor => IsLimitBrakeLimit ? StaticLevelColor.LIMIT_BREAK_MAX : ((0 >= LimitBreakCount) ? StaticLevelColor.NORMAL : StaticLevelColor.LIMIT_BREAK);

	public int AcqExp => ParamCalcModule.ComputeGrowthInt(Level, LevelLimitMax, Master.AcqExpMin, Master.AcqExpMax, Master.AcqExpExp, "素材魔ペットの合成経験値");

	public int SellPrice => checked(Master.price(Level) + SumPlusBonus * MGameParameters.findByGameParameterId(66).Param);

	public int ActualAttack => checked(Attack + AttackBonus);

	public int ActualHP => checked(HP + HpBonus);

	public float TotalAttack => Mathf.Floor((float)ActualAttack * TraitAttackScale + PlusAttackStatus);

	public float TotalHP => Mathf.Floor((float)ActualHP * TraitHPScale + PlusHPStatus);

	public float PlusAttackStatus => RefPlayerBox.PlusAttackStatus;

	public float PlusHPStatus => RefPlayerBox.PlusHPStatus;

	public float TraitAttackScale => MTraits.GetAttackCoef(TraitId);

	public float TraitHPScale => MTraits.GetHpCoef(TraitId);

	public int Attack => Master.attack(Level);

	public int HP => Master.hp(Level);

	public int Critical => Master.critical(Level);

	public int BreakPow => Master.breakPow(Level);

	public int Resist => Master.resist(Level);

	public int Defense => Master.defense(Level);

	public string PrefabPath => "Prefab/Character/Tukaima/" + Master.PrefabName;

	public bool ColosseumChainDisabled
	{
		get
		{
			bool num = Master.ChainSkillId != null;
			if (num)
			{
				num = Master.ChainSkillId.DisableColosseum;
			}
			return num;
		}
	}

	public bool ColosseumCover1Disabled
	{
		get
		{
			bool num = Master.CoverSkillId_1 != null;
			if (num)
			{
				num = Master.CoverSkillId_1.DisableColosseum;
			}
			return num;
		}
	}

	public bool ColosseumCover2Disabled
	{
		get
		{
			bool num = Master.CoverSkillId_2 != null;
			if (num)
			{
				num = Master.CoverSkillId_2.DisableColosseum;
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
					bool isChainSkillLevelMax = IsChainSkillLevelMax;
					bool isCoverSkill1LevelMax = IsCoverSkill1LevelMax;
					bool isCoverSkill2LevelMax = IsCoverSkill2LevelMax;
					bool isAttackPlusBonusMax = IsAttackPlusBonusMax;
					bool isHpPlusBonusMax = IsHpPlusBonusMax;
					if (isChainSkillLevelMax && isCoverSkill1LevelMax && isCoverSkill2LevelMax && isAttackPlusBonusMax && isHpPlusBonusMax)
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

	public bool CanEvolution => Master.EvolutionPoppetId != null;

	public bool CanUltEvolution => MEvolutionInformations.Has(2, Master.Id);

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

	public RespPoppet()
	{
		if (!_0024initialized__MerlinAPI_RespPoppet_0024)
		{
			_0024initialized__MerlinAPI_RespPoppet_0024 = true;
		}
	}

	public RespPoppet(int mstid)
	{
		if (!_0024initialized__MerlinAPI_RespPoppet_0024)
		{
			_0024initialized__MerlinAPI_RespPoppet_0024 = true;
		}
		init(MPoppets.Get(mstid));
	}

	public RespPoppet(MPoppets mst)
	{
		if (!_0024initialized__MerlinAPI_RespPoppet_0024)
		{
			_0024initialized__MerlinAPI_RespPoppet_0024 = true;
		}
		init(mst);
	}

	public RespPoppet(MMonsters m)
	{
		if (!_0024initialized__MerlinAPI_RespPoppet_0024)
		{
			_0024initialized__MerlinAPI_RespPoppet_0024 = true;
		}
		if (m == null)
		{
			init(MPoppets.Get(1));
		}
		else
		{
			init(MPoppets.Get(m.Id));
		}
	}

	public RespPoppet(RespMonster m)
	{
		if (!_0024initialized__MerlinAPI_RespPoppet_0024)
		{
			_0024initialized__MerlinAPI_RespPoppet_0024 = true;
		}
		if (m == null || m.Master == null)
		{
			init(MPoppets.Get(1));
		}
		else
		{
			init(MPoppets.Get(m.Master.Id));
		}
	}

	public RespPoppet Clone()
	{
		RespPoppet respPoppet = new RespPoppet(RefPlayerBox.ItemType);
		respPoppet.RefPlayerBox = RefPlayerBox.Clone();
		if (UserData.Current != null)
		{
			respPoppet.favorite = (UserData.Current.IsFavorite(RefPlayerBox) ? 1 : 0);
		}
		return respPoppet;
	}

	public bool isSameMaster(RespPoppet ppt)
	{
		bool num = ppt != null;
		if (num)
		{
			num = ppt.IsValidMaster;
		}
		if (num)
		{
			num = IsValidMaster;
		}
		if (num)
		{
			num = Master.Id == ppt.Master.Id;
		}
		return num;
	}

	public bool LevelUpSimulate(RespPoppet[] respPoppets, ref int dstNewExp, ref int dstNeedCost)
	{
		dstNewExp = Exp;
		dstNeedCost = 0;
		int num = 0;
		int num2 = SumPlusBonus;
		int i = 0;
		int result;
		checked
		{
			for (int length = respPoppets.Length; i < length; i++)
			{
				if (respPoppets[i] != null)
				{
					num++;
					int num3 = respPoppets[i].AcqExp;
					unchecked
					{
						if (RuntimeServices.EqualityOperator(Element, respPoppets[i].Element))
						{
							num3 = checked(num3 * 3) / 2;
						}
					}
					dstNewExp += num3;
					num2 += respPoppets[i].SumPlusBonus;
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
		_0024CalcAddPlusBonusCost_0024locals_002414455 _0024CalcAddPlusBonusCost_0024locals_0024 = new _0024CalcAddPlusBonusCost_0024locals_002414455();
		_0024CalcAddPlusBonusCost_0024locals_0024._0024plusRate = MGameParameters.findByGameParameterId(62).Param;
		__RespWeapon_CalcAddPlusBonusCost_0024callable180_0024358_13__ _RespWeapon_CalcAddPlusBonusCost_0024callable180_0024358_13__ = new _0024CalcAddPlusBonusCost_0024f_00244019(_0024CalcAddPlusBonusCost_0024locals_0024).Invoke;
		return checked(_RespWeapon_CalcAddPlusBonusCost_0024callable180_0024358_13__(next) - _RespWeapon_CalcAddPlusBonusCost_0024callable180_0024358_13__(prev));
	}

	public int damageScale(EnumElements vs)
	{
		return 80;
	}

	public void init(MPoppets mst)
	{
		if (mst == null)
		{
		}
		RefPlayerBox = new RespPlayerBox();
		RefPlayerBox.ItemType = 2;
		ChainSkillLevel = 1;
		AttackBonus = 0;
		CoverSkillLevel_1 = 1;
		CoverSkillLevel_2 = 1;
		Exp = 0;
		HpBonus = 0;
		Id = BoxId.InvalidId;
		Level = 1;
		LevelMax = 1;
		MPoppetId = mst?.Id ?? 0;
		TPlayerId = 0;
		_favorite = 0;
		TraitId = 0;
	}

	public override string ToString()
	{
		return new StringBuilder("RespPoppet(").Append(Id).Append(",").Append(Name)
			.Append(",TotalAtk:")
			.Append(TotalAttack)
			.Append(",Cost:")
			.Append((object)Cost)
			.Append(")")
			.ToString();
	}

	public string toNguiJson()
	{
		Hashtable hashtable = new Hashtable();
		hashtable["MPoppetId"] = MPoppetId;
		hashtable["AttackBonus"] = AttackBonus;
		hashtable["AttackPlusBonus"] = AttackPlusBonus;
		hashtable["ChainSkillLevel"] = ChainSkillLevel;
		hashtable["CoverSkillLevel_1"] = CoverSkillLevel_1;
		hashtable["CoverSkillLevel_2"] = CoverSkillLevel_2;
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

	public static RespPoppet fromNguiJson(string nj)
	{
		RespPoppet respPoppet = new RespPoppet();
		respPoppet.RefPlayerBox = new RespPlayerBox();
		respPoppet.Id = BoxId.InvalidId;
		Hashtable hashtable = NGUIJson.jsonDecode(nj) as Hashtable;
		if (hashtable.ContainsKey("MPoppetId"))
		{
			respPoppet.MPoppetId = RuntimeServices.UnboxInt32(hashtable["MPoppetId"]);
		}
		if (hashtable.ContainsKey("AttackBonus"))
		{
			respPoppet.AttackBonus = RuntimeServices.UnboxInt32(hashtable["AttackBonus"]);
		}
		if (hashtable.ContainsKey("AttackPlusBonus"))
		{
			respPoppet.AttackPlusBonus = RuntimeServices.UnboxInt32(hashtable["AttackPlusBonus"]);
		}
		if (hashtable.ContainsKey("ChainSkillLevel"))
		{
			respPoppet.ChainSkillLevel = RuntimeServices.UnboxInt32(hashtable["ChainSkillLevel"]);
		}
		if (hashtable.ContainsKey("CoverSkillLevel_1"))
		{
			respPoppet.CoverSkillLevel_1 = RuntimeServices.UnboxInt32(hashtable["CoverSkillLevel_1"]);
		}
		if (hashtable.ContainsKey("CoverSkillLevel_2"))
		{
			respPoppet.CoverSkillLevel_2 = RuntimeServices.UnboxInt32(hashtable["CoverSkillLevel_2"]);
		}
		if (hashtable.ContainsKey("Exp"))
		{
			respPoppet.Exp = RuntimeServices.UnboxInt32(hashtable["Exp"]);
		}
		if (hashtable.ContainsKey("HpBonus"))
		{
			respPoppet.HpBonus = RuntimeServices.UnboxInt32(hashtable["HpBonus"]);
		}
		if (hashtable.ContainsKey("HpPlusBonus"))
		{
			respPoppet.HpPlusBonus = RuntimeServices.UnboxInt32(hashtable["HpPlusBonus"]);
		}
		if (hashtable.ContainsKey("Level"))
		{
			respPoppet.Level = RuntimeServices.UnboxInt32(hashtable["Level"]);
		}
		if (hashtable.ContainsKey("LevelMax"))
		{
			respPoppet.LevelMax = RuntimeServices.UnboxInt32(hashtable["LevelMax"]);
		}
		if (hashtable.ContainsKey("LimitBreakCount"))
		{
			respPoppet.LimitBreakCount = RuntimeServices.UnboxInt32(hashtable["LimitBreakCount"]);
		}
		if (hashtable.ContainsKey("TPlayerId"))
		{
			respPoppet.TPlayerId = RuntimeServices.UnboxInt32(hashtable["TPlayerId"]);
		}
		if (hashtable.ContainsKey("TraitId"))
		{
			respPoppet.TraitId = RuntimeServices.UnboxInt32(hashtable["TraitId"]);
		}
		return respPoppet;
	}
}
