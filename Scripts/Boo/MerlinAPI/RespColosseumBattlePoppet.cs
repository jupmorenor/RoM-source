using System;

namespace MerlinAPI;

[Serializable]
public class RespColosseumBattlePoppet : JsonBase
{
	public bool IsLeader;

	public int PoppetItemId;

	public int PoppetLevel;

	public int PoppetAtkBonus;

	public int PoppetHpBonus;

	public int PoppetAtkPlusBonus;

	public int PoppetHpPlusBonus;

	public int PoppetSkill1Level;

	public int PoppetSkill2Level;

	public int PoppetSkill3Level;

	public int PoppetTraitId;

	public int WeaponItemId;

	public int WeaponLevel;

	public int WeaponAtkBonus;

	public int WeaponHpBonus;

	public int WeaponAtkPlusBonus;

	public int WeaponHpPlusBonus;

	public int WeaponSkill1Level;

	public int WeaponSkill2Level;

	public int WeaponSkill3Level;

	public int WeaponTraitId;

	public RespPoppet PoppetData
	{
		get
		{
			RespPoppet respPoppet = new RespPoppet(PoppetItemId);
			respPoppet.Level = PoppetLevel;
			respPoppet.AttackBonus = PoppetAtkBonus;
			respPoppet.HpBonus = PoppetHpBonus;
			respPoppet.AttackPlusBonus = PoppetAtkPlusBonus;
			respPoppet.HpPlusBonus = PoppetHpPlusBonus;
			respPoppet.RefPlayerBox.SkillLevel_1 = PoppetSkill1Level;
			respPoppet.RefPlayerBox.SkillLevel_2 = PoppetSkill2Level;
			respPoppet.RefPlayerBox.SkillLevel_3 = PoppetSkill3Level;
			respPoppet.TraitId = PoppetTraitId;
			return respPoppet;
		}
	}

	public RespWeapon WeaponData
	{
		get
		{
			RespWeapon respWeapon = new RespWeapon(WeaponItemId);
			respWeapon.Level = WeaponLevel;
			respWeapon.AttackBonus = WeaponAtkBonus;
			respWeapon.HpBonus = WeaponHpBonus;
			respWeapon.AttackPlusBonus = WeaponAtkPlusBonus;
			respWeapon.HpPlusBonus = WeaponHpPlusBonus;
			respWeapon.RefPlayerBox.SkillLevel_1 = WeaponSkill1Level;
			respWeapon.RefPlayerBox.SkillLevel_2 = WeaponSkill2Level;
			respWeapon.RefPlayerBox.SkillLevel_3 = WeaponSkill3Level;
			respWeapon.TraitId = WeaponTraitId;
			return respWeapon;
		}
	}
}
