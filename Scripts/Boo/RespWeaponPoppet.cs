using System;
using Boo.Lang;
using Boo.Lang.Runtime;
using MerlinAPI;

[Serializable]
public class RespWeaponPoppet
{
	private RespWeapon weapon;

	private RespPoppet poppet;

	public bool IsWeapon => weapon != null;

	public bool IsPoppet => poppet != null;

	public JsonBase data => (!IsWeapon) ? ((JsonBase)poppet) : ((JsonBase)weapon);

	public int ItemTypeByInt => IsWeapon ? 1 : 2;

	public BoxId Id
	{
		get
		{
			return (!IsWeapon) ? poppet.Id : weapon.Id;
		}
		set
		{
			if (IsWeapon)
			{
				weapon.Id = value;
			}
			else
			{
				poppet.Id = value;
			}
		}
	}

	public int MasterId
	{
		get
		{
			return (!IsWeapon) ? poppet.MPoppetId : weapon.MWeaponId;
		}
		set
		{
			if (IsWeapon)
			{
				weapon.MWeaponId = value;
			}
			else
			{
				poppet.MPoppetId = value;
			}
		}
	}

	public int LimitBreakCount
	{
		get
		{
			return (!IsWeapon) ? poppet.LimitBreakCount : weapon.LimitBreakCount;
		}
		set
		{
			if (IsWeapon)
			{
				weapon.LimitBreakCount = value;
			}
			else
			{
				poppet.LimitBreakCount = value;
			}
		}
	}

	public int Exp
	{
		get
		{
			return (!IsWeapon) ? poppet.Exp : weapon.Exp;
		}
		set
		{
			if (IsWeapon)
			{
				weapon.Exp = value;
			}
			else
			{
				poppet.Exp = value;
			}
		}
	}

	public int Level
	{
		get
		{
			return (!IsWeapon) ? poppet.Level : weapon.Level;
		}
		set
		{
			if (IsWeapon)
			{
				weapon.Level = value;
			}
			else
			{
				poppet.Level = value;
			}
		}
	}

	public int TraitId
	{
		get
		{
			return (!IsWeapon) ? poppet.TraitId : weapon.TraitId;
		}
		set
		{
			if (IsWeapon)
			{
				weapon.TraitId = value;
			}
			else
			{
				poppet.TraitId = value;
			}
		}
	}

	public int HpBonus
	{
		get
		{
			return (!IsWeapon) ? poppet.HpBonus : weapon.HpBonus;
		}
		set
		{
			if (IsWeapon)
			{
				weapon.HpBonus = value;
			}
			else
			{
				poppet.HpBonus = value;
			}
		}
	}

	public int AttackBonus
	{
		get
		{
			return (!IsWeapon) ? poppet.AttackBonus : weapon.AttackBonus;
		}
		set
		{
			if (IsWeapon)
			{
				weapon.AttackBonus = value;
			}
			else
			{
				poppet.AttackBonus = value;
			}
		}
	}

	public int HpPlusBonus
	{
		get
		{
			return (!IsWeapon) ? poppet.HpPlusBonus : weapon.HpPlusBonus;
		}
		set
		{
			if (IsWeapon)
			{
				weapon.HpPlusBonus = value;
			}
			else
			{
				poppet.HpPlusBonus = value;
			}
		}
	}

	public int AttackPlusBonus
	{
		get
		{
			return (!IsWeapon) ? poppet.AttackPlusBonus : weapon.AttackPlusBonus;
		}
		set
		{
			if (IsWeapon)
			{
				weapon.AttackPlusBonus = value;
			}
			else
			{
				poppet.AttackPlusBonus = value;
			}
		}
	}

	public int SkillLevel_1
	{
		get
		{
			return (!IsWeapon) ? poppet.CoverSkillLevel_1 : weapon.AngelSkillLevel;
		}
		set
		{
			if (IsWeapon)
			{
				weapon.AngelSkillLevel = value;
			}
			else
			{
				poppet.CoverSkillLevel_1 = value;
			}
		}
	}

	public int SkillLevel_2
	{
		get
		{
			return (!IsWeapon) ? poppet.CoverSkillLevel_2 : weapon.DemonSkillLevel;
		}
		set
		{
			if (IsWeapon)
			{
				weapon.DemonSkillLevel = value;
			}
			else
			{
				poppet.CoverSkillLevel_2 = value;
			}
		}
	}

	public int SkillLevel_3
	{
		get
		{
			return (!IsWeapon) ? poppet.ChainSkillLevel : weapon.CoverSkillLevel;
		}
		set
		{
			if (IsWeapon)
			{
				weapon.CoverSkillLevel = value;
			}
			else
			{
				poppet.ChainSkillLevel = value;
			}
		}
	}

	public string Name => (!IsWeapon) ? poppet.Name : weapon.Name;

	public int Rare => (!IsWeapon) ? poppet.Rare.Id : weapon.Rare.Id;

	public MElements Element => (!IsWeapon) ? poppet.Element : weapon.Element;

	public int CapExp => (!IsWeapon) ? poppet.CapExp : weapon.CapExp;

	public int LevelMaxExp => checked((int)((!IsWeapon) ? ((float)poppet.Master.exp(CurrentLevelLimit)) : weapon.Master.exp(CurrentLevelLimit)));

	public int LevelExpDist => (!IsWeapon) ? poppet.LevelExpDist : weapon.LevelExpDist;

	public int LevelUpExpDist => (!IsWeapon) ? poppet.LevelUpExpDist : weapon.LevelUpExpDist;

	public int AcqExp => (!IsWeapon) ? poppet.AcqExp : weapon.AcqExp;

	public int LimitBreakCountLimit => (!IsWeapon) ? poppet.LimitBreakCountLimit : weapon.LimitBreakCountLimit;

	public int CurrentLevelLimit => (!IsWeapon) ? poppet.CurrentLevelLimit : weapon.CurrentLevelLimit;

	public int EvoCost => (!IsWeapon) ? poppet.Master.EvoCost : weapon.Master.EvoCost;

	public bool CanMorePowup => (!IsWeapon) ? poppet.CanMorePowup : weapon.CanMorePowup;

	public bool CanEvolution => (!IsWeapon) ? poppet.CanEvolution : weapon.CanEvolution;

	public bool CanUltEvolution => (!IsWeapon) ? poppet.CanUltEvolution : weapon.CanUltEvolution;

	public bool IsLimitBreak => (!IsWeapon) ? poppet.Master.IsLimitBreak : weapon.Master.IsLimitBreak;

	public bool IsSkillLvUp => (!IsWeapon) ? poppet.Master.IsSkillLvUp : weapon.Master.IsSkillLvUp;

	public int LevelUpType => (int)((!IsWeapon) ? poppet.Master.LevelUpType : weapon.Master.LevelUpType);

	public RespPlayerBox RefPlayerBox => (!IsWeapon) ? poppet.RefPlayerBox : weapon.RefPlayerBox;

	public bool IsFavorite => UserData.Current.IsFavorite(RefPlayerBox);

	public int StyleOrRace => RuntimeServices.UnboxInt32((!IsWeapon) ? ((object)poppet.Race) : ((object)weapon.StyleId));

	public int SellPrice => (!IsWeapon) ? poppet.SellPrice : weapon.SellPrice;

	public int SellManaFragment => (!IsWeapon) ? poppet.Master.SellManaFragment : weapon.Master.SellManaFragment;

	public int HP => (!IsWeapon) ? poppet.HP : weapon.HP;

	public int Attack => (!IsWeapon) ? poppet.Attack : weapon.Attack;

	public int ActualHP => (!IsWeapon) ? poppet.ActualHP : weapon.ActualHP;

	public int ActualAttack => (!IsWeapon) ? poppet.ActualAttack : weapon.ActualAttack;

	public int PlusBonusMax => (!IsWeapon) ? poppet.PlusBonusMax : weapon.PlusBonusMax;

	public int SumPlusBonus => (!IsWeapon) ? poppet.SumPlusBonus : weapon.SumPlusBonus;

	public bool IsAttackPlusBonusMax => (!IsWeapon) ? poppet.IsAttackPlusBonusMax : weapon.IsAttackPlusBonusMax;

	public bool IsHpPlusBonusMax => (!IsWeapon) ? poppet.IsHpPlusBonusMax : weapon.IsHpPlusBonusMax;

	public int EvolutionId => (!IsWeapon) ? poppet.Master.EvolutionPoppetId.Id : weapon.Master.EvolutionWeaponId.Id;

	public string EvolutionName => (!IsWeapon) ? poppet.Master.EvolutionPoppetId.Name.ToString() : weapon.Master.EvolutionWeaponId.Name.ToString();

	public int[] EvolutionMaterialIds
	{
		get
		{
			List<int> list = new List<int>();
			checked
			{
				if (IsWeapon)
				{
					int i = 0;
					MWeapons[] evolutionMaterials = weapon.EvolutionMaterials;
					for (int length = evolutionMaterials.Length; i < length; i++)
					{
						list.Add((evolutionMaterials[i] != null) ? evolutionMaterials[i].Id : 0);
					}
				}
				else
				{
					int j = 0;
					MPoppets[] evolutionMaterials2 = poppet.EvolutionMaterials;
					for (int length2 = evolutionMaterials2.Length; j < length2; j++)
					{
						list.Add((evolutionMaterials2[j] != null) ? evolutionMaterials2[j].Id : 0);
					}
				}
				return list.ToArray();
			}
		}
	}

	public int SkillId_1 => IsWeapon ? weapon.Master.AngelSkillId.Id : ((poppet.Master.CoverSkillId_1 != null) ? poppet.Master.CoverSkillId_1.Id : 0);

	public int SkillId_2 => IsWeapon ? weapon.Master.DemonSkillId.Id : ((poppet.Master.CoverSkillId_2 != null) ? poppet.Master.CoverSkillId_2.Id : 0);

	public int SkillId_3 => (!IsWeapon) ? poppet.Master.ChainSkillId.Id : ((weapon.Master.CoverSkillId != null) ? weapon.Master.CoverSkillId.Id : 0);

	public RespWeaponPoppet(JsonBase jb)
	{
		if (jb == null)
		{
			throw new AssertionFailedException("jb != null");
		}
		if (jb is RespPlayerBox respPlayerBox)
		{
			if (respPlayerBox.IsWeapon)
			{
				weapon = respPlayerBox.toRespWeapon();
			}
			else
			{
				poppet = respPlayerBox.toRespPoppet();
			}
		}
		else
		{
			weapon = jb as RespWeapon;
			poppet = jb as RespPoppet;
		}
		if (!IsWeapon && !IsPoppet)
		{
			throw new AssertionFailedException("武器でも魔ペットでもない物をRespWeaponPoppetに入れないで下さい!!!!!");
		}
	}

	public static bool Know(JsonBase jb)
	{
		return new RespWeaponPoppet(jb).know();
	}

	public RespWeaponPoppet Clone()
	{
		return (!IsWeapon) ? new RespWeaponPoppet(poppet.Clone()) : new RespWeaponPoppet(weapon.Clone());
	}

	public RespWeaponPoppet CreateUltEvolution(int index)
	{
		return CreateEvolution(UltEvoId(index));
	}

	public RespWeaponPoppet CreateEvolution()
	{
		return CreateEvolution(EvolutionId);
	}

	private RespWeaponPoppet CreateEvolution(int mid)
	{
		RespWeaponPoppet respWeaponPoppet = null;
		respWeaponPoppet = ((!IsWeapon) ? new RespWeaponPoppet(new RespPoppet(mid)) : new RespWeaponPoppet(new RespWeapon(mid)));
		checked
		{
			if (respWeaponPoppet != null)
			{
				respWeaponPoppet.Level = 1;
				respWeaponPoppet.TraitId = TraitId;
				int param = MGameParameters.findByGameParameterId(10).Param;
				respWeaponPoppet.HpBonus = (int)((float)ActualHP * ((float)param / 100f));
				respWeaponPoppet.AttackBonus = (int)((float)ActualAttack * ((float)param / 100f));
				respWeaponPoppet.HpPlusBonus = HpPlusBonus;
				respWeaponPoppet.AttackPlusBonus = AttackPlusBonus;
				bool flag = 7 <= respWeaponPoppet.Rare;
				if (respWeaponPoppet.SkillId_1 == SkillId_1 || flag)
				{
					respWeaponPoppet.SkillLevel_1 = SkillLevel_1;
				}
				if (respWeaponPoppet.SkillId_2 == SkillId_2 || flag)
				{
					respWeaponPoppet.SkillLevel_2 = SkillLevel_2;
				}
				if (respWeaponPoppet.SkillId_3 == SkillId_3 || flag)
				{
					respWeaponPoppet.SkillLevel_3 = SkillLevel_3;
				}
			}
			return respWeaponPoppet;
		}
	}

	public bool LevelUpSimulate(RespWeaponPoppet[] mats, ref int dstNewExp, ref int dstNeedCost)
	{
		JsonBase[] array = null;
		array = ((!IsWeapon) ? ((JsonBase[])ArrayMapMain.ToRespPoppets(mats, (RespWeaponPoppet mat) => mat.data as RespPoppet)) : ((JsonBase[])ArrayMapMain.ToRespWeapons(mats, (RespWeaponPoppet mat) => mat.data as RespWeapon)));
		return LevelUpSimulate(array, ref dstNewExp, ref dstNeedCost);
	}

	public bool LevelUpSimulate(JsonBase[] mats, ref int dstNewExp, ref int dstNeedCost)
	{
		return !(mats == null) && (!(mats as RespWeapon[] == null) || !(mats as RespPoppet[] == null)) && ((!IsWeapon) ? poppet.LevelUpSimulate(mats as RespPoppet[], ref dstNewExp, ref dstNeedCost) : weapon.LevelUpSimulate(mats as RespWeapon[], ref dstNewExp, ref dstNeedCost));
	}

	public int exp_to_level(int exp)
	{
		return exp_to_level(exp, Level);
	}

	public int exp_to_level(int exp, int now)
	{
		return (!IsWeapon) ? poppet.Master.exp_to_level(exp, now) : weapon.Master.exp_to_level(exp, now);
	}

	public bool know()
	{
		UserData current = UserData.Current;
		return (!IsWeapon) ? current.userBoxData.knowMPoppet(poppet.Master) : current.userBoxData.knowMWeapon(weapon.Master);
	}

	public bool canLimitBreak(RespWeaponPoppet item)
	{
		return IsWeapon == item.IsWeapon && (MasterId == item.MasterId || (item.IsLimitBreak ? true : false));
	}

	public MEvolutionInformations[] GetUltEvoInfos()
	{
		return MEvolutionInformations.SearchToSourceId(ItemTypeByInt, MasterId);
	}

	public int UltEvoCost(int index)
	{
		MEvolutionInformations[] ultEvoInfos = GetUltEvoInfos();
		return ultEvoInfos[RuntimeServices.NormalizeArrayIndex(ultEvoInfos, index)].EvoCost;
	}

	public int UltEvoId(int index)
	{
		MEvolutionInformations[] ultEvoInfos = GetUltEvoInfos();
		return ultEvoInfos[RuntimeServices.NormalizeArrayIndex(ultEvoInfos, index)].EvolutionDestinationId;
	}

	internal RespWeapon _0024LevelUpSimulate_0024closure_00242924(RespWeaponPoppet mat)
	{
		return mat.data as RespWeapon;
	}

	internal RespPoppet _0024LevelUpSimulate_0024closure_00242925(RespWeaponPoppet mat)
	{
		return mat.data as RespPoppet;
	}
}
