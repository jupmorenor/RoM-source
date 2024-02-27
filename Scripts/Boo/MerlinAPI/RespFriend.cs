using System;
using System.Collections;
using Boo.Lang.Runtime;

namespace MerlinAPI;

[Serializable]
public class RespFriend : JsonBase
{
	public int TSocialPlayerId;

	public int TPlayerId;

	public string AngelName;

	public string DemonName;

	public int AngelGender;

	public int DemonGender;

	public string PoppetName;

	public int CharacterLevel;

	public int ItemId;

	public int PoppetLevel;

	public int HpPlusBonus;

	public int AttackPlusBonus;

	public int HpBonus;

	public int AttackBonus;

	public int SkillLevel_1;

	public int SkillLevel_2;

	public int SkillLevel_3;

	public bool IsSolo;

	public int WeaponItemId;

	public int WeaponLevel;

	public int WeaponHpPlusBonus;

	public int WeaponAttackPlusBonus;

	public int WeaponHpBonus;

	public int WeaponAttackBonus;

	public int WeaponSkillLevel_1;

	public int WeaponSkillLevel_2;

	public int WeaponSkillLevel_3;

	public DateTime LastAccessDate;

	public string Name;

	public int WeaponLimitBreakCount;

	public int PoppetLimitBreakCount;

	public int DevilWeaponItemId;

	public int DevilWeaponLevel;

	public int DevilWeaponHpPlusBonus;

	public int DevilWeaponAttackPlusBonus;

	public int DevilWeaponHpBonus;

	public int DevilWeaponAttackBonus;

	public int DevilWeaponSkillLevel_1;

	public int DevilWeaponSkillLevel_2;

	public int DevilWeaponSkillLevel_3;

	public int DevilWeaponLimitBreakCount;

	public int PoppetTraitId;

	public int AngelWeaponTraitId;

	public int DevilWeaponTraitId;

	public int AngelAttackPlusBonus;

	public int AngelHpPlusBonus;

	public int DevilAttackPlusBonus;

	public int DevilHpPlusBonus;

	public int PoppetAttackPlusBonus;

	public int PoppetHpPlusBonus;

	public RespFriend()
	{
		AngelName = "<?>";
		DemonName = "<?>";
		PoppetName = string.Empty;
		Name = "<?>";
	}

	public RespPoppet GetFriendPet()
	{
		RespPoppet respPoppet = new RespPoppet(1);
		respPoppet.RefPlayerBox = new RespPlayerBox();
		respPoppet.MPoppetId = ItemId;
		respPoppet.Level = PoppetLevel;
		respPoppet.HpBonus = HpBonus;
		respPoppet.HpPlusBonus = HpPlusBonus;
		respPoppet.AttackBonus = AttackBonus;
		respPoppet.AttackPlusBonus = AttackPlusBonus;
		respPoppet.CoverSkillLevel_1 = SkillLevel_1;
		respPoppet.CoverSkillLevel_2 = SkillLevel_2;
		respPoppet.ChainSkillLevel = SkillLevel_3;
		respPoppet.LimitBreakCount = PoppetLimitBreakCount;
		respPoppet.TraitId = PoppetTraitId;
		return respPoppet;
	}

	public RespWeapon GetFriendWeapon()
	{
		return GetFriendWeapon(RACE_TYPE.Tensi);
	}

	public RespWeapon GetFriendWeapon(RACE_TYPE aType)
	{
		int num = WeaponItemId;
		if (aType == RACE_TYPE.Akuma)
		{
			num = DevilWeaponItemId;
		}
		RespWeapon respWeapon = new RespWeapon(num);
		respWeapon.RefPlayerBox = new RespPlayerBox();
		respWeapon.MWeaponId = num;
		if (aType == RACE_TYPE.Tensi)
		{
			respWeapon.Level = WeaponLevel;
			respWeapon.HpBonus = WeaponHpBonus;
			respWeapon.HpPlusBonus = WeaponHpPlusBonus;
			respWeapon.AttackPlusBonus = WeaponAttackPlusBonus;
			respWeapon.AttackBonus = WeaponAttackBonus;
			respWeapon.AngelSkillLevel = WeaponSkillLevel_1;
			respWeapon.DemonSkillLevel = WeaponSkillLevel_2;
			respWeapon.CoverSkillLevel = WeaponSkillLevel_3;
			respWeapon.LimitBreakCount = WeaponLimitBreakCount;
			respWeapon.TraitId = AngelWeaponTraitId;
		}
		else
		{
			respWeapon.Level = DevilWeaponLevel;
			respWeapon.HpBonus = DevilWeaponHpBonus;
			respWeapon.HpPlusBonus = DevilWeaponHpPlusBonus;
			respWeapon.AttackPlusBonus = DevilWeaponAttackPlusBonus;
			respWeapon.AttackBonus = DevilWeaponAttackBonus;
			respWeapon.AngelSkillLevel = DevilWeaponSkillLevel_1;
			respWeapon.DemonSkillLevel = DevilWeaponSkillLevel_2;
			respWeapon.CoverSkillLevel = DevilWeaponSkillLevel_3;
			respWeapon.LimitBreakCount = DevilWeaponLimitBreakCount;
			respWeapon.TraitId = DevilWeaponTraitId;
		}
		return respWeapon;
	}

	public string toNguiJson()
	{
		Hashtable hashtable = new Hashtable();
		hashtable["TSocialPlayerId"] = TSocialPlayerId;
		hashtable["TPlayerId"] = TPlayerId;
		hashtable["AngelName"] = AngelName;
		hashtable["DemonName"] = DemonName;
		hashtable["AngelGender"] = AngelGender;
		hashtable["DemonGender"] = DemonGender;
		hashtable["PoppetName"] = PoppetName;
		hashtable["CharacterLevel"] = CharacterLevel;
		hashtable["ItemId"] = ItemId;
		hashtable["PoppetLevel"] = PoppetLevel;
		hashtable["HpPlusBonus"] = HpPlusBonus;
		hashtable["AttackPlusBonus"] = AttackPlusBonus;
		hashtable["HpBonus"] = HpBonus;
		hashtable["AttackBonus"] = AttackBonus;
		hashtable["SkillLevel_1"] = SkillLevel_1;
		hashtable["SkillLevel_2"] = SkillLevel_2;
		hashtable["SkillLevel_3"] = SkillLevel_3;
		hashtable["IsSolo"] = IsSolo;
		hashtable["WeaponItemId"] = WeaponItemId;
		hashtable["WeaponLevel"] = WeaponLevel;
		hashtable["WeaponHpPlusBonus"] = WeaponHpPlusBonus;
		hashtable["WeaponAttackPlusBonus"] = WeaponAttackPlusBonus;
		hashtable["WeaponHpBonus"] = WeaponHpBonus;
		hashtable["WeaponAttackBonus"] = WeaponAttackBonus;
		hashtable["WeaponSkillLevel_1"] = WeaponSkillLevel_1;
		hashtable["WeaponSkillLevel_2"] = WeaponSkillLevel_2;
		hashtable["WeaponSkillLevel_3"] = WeaponSkillLevel_3;
		hashtable["LastAccessDate"] = LastAccessDate.ToBinary();
		hashtable["Name"] = Name;
		hashtable["WeaponLimitBreakCount"] = WeaponLimitBreakCount;
		hashtable["PoppetLimitBreakCount"] = PoppetLimitBreakCount;
		hashtable["PoppetTraitId"] = PoppetTraitId;
		hashtable["AngelWeaponTraitId"] = AngelWeaponTraitId;
		hashtable["DevilWeaponTraitId"] = DevilWeaponTraitId;
		hashtable["AngelAttackPlusBonus"] = AngelAttackPlusBonus;
		hashtable["AngelHpPlusBonus"] = AngelHpPlusBonus;
		hashtable["DevilAttackPlusBonus"] = DevilAttackPlusBonus;
		hashtable["DevilHpPlusBonus"] = DevilHpPlusBonus;
		hashtable["PoppetAttackPlusBonus"] = PoppetAttackPlusBonus;
		hashtable["PoppetHpPlusBonus"] = PoppetHpPlusBonus;
		return NGUIJson.jsonEncode(hashtable);
	}

	public static RespFriend fromNguiJson(string nj)
	{
		RespFriend respFriend = new RespFriend();
		Hashtable hashtable = NGUIJson.jsonDecode(nj) as Hashtable;
		if (hashtable.ContainsKey("TSocialPlayerId"))
		{
			respFriend.TSocialPlayerId = RuntimeServices.UnboxInt32(hashtable["TSocialPlayerId"]);
		}
		if (hashtable.ContainsKey("TPlayerId"))
		{
			respFriend.TPlayerId = RuntimeServices.UnboxInt32(hashtable["TPlayerId"]);
		}
		if (hashtable.ContainsKey("AngelName"))
		{
			respFriend.AngelName = hashtable["AngelName"] as string;
		}
		if (hashtable.ContainsKey("DemonName"))
		{
			respFriend.DemonName = hashtable["DemonName"] as string;
		}
		if (hashtable.ContainsKey("AngelGender"))
		{
			respFriend.AngelGender = RuntimeServices.UnboxInt32(hashtable["AngelGender"]);
		}
		if (hashtable.ContainsKey("DemonGender"))
		{
			respFriend.DemonGender = RuntimeServices.UnboxInt32(hashtable["DemonGender"]);
		}
		if (hashtable.ContainsKey("PoppetName"))
		{
			respFriend.PoppetName = hashtable["PoppetName"] as string;
		}
		if (hashtable.ContainsKey("CharacterLevel"))
		{
			respFriend.CharacterLevel = RuntimeServices.UnboxInt32(hashtable["CharacterLevel"]);
		}
		if (hashtable.ContainsKey("ItemId"))
		{
			respFriend.ItemId = RuntimeServices.UnboxInt32(hashtable["ItemId"]);
		}
		if (hashtable.ContainsKey("PoppetLevel"))
		{
			respFriend.PoppetLevel = RuntimeServices.UnboxInt32(hashtable["PoppetLevel"]);
		}
		if (hashtable.ContainsKey("HpPlusBonus"))
		{
			respFriend.HpPlusBonus = RuntimeServices.UnboxInt32(hashtable["HpPlusBonus"]);
		}
		if (hashtable.ContainsKey("AttackPlusBonus"))
		{
			respFriend.AttackPlusBonus = RuntimeServices.UnboxInt32(hashtable["AttackPlusBonus"]);
		}
		if (hashtable.ContainsKey("HpBonus"))
		{
			respFriend.HpBonus = RuntimeServices.UnboxInt32(hashtable["HpBonus"]);
		}
		if (hashtable.ContainsKey("AttackBonus"))
		{
			respFriend.AttackBonus = RuntimeServices.UnboxInt32(hashtable["AttackBonus"]);
		}
		if (hashtable.ContainsKey("SkillLevel_1"))
		{
			respFriend.SkillLevel_1 = RuntimeServices.UnboxInt32(hashtable["SkillLevel_1"]);
		}
		if (hashtable.ContainsKey("SkillLevel_2"))
		{
			respFriend.SkillLevel_2 = RuntimeServices.UnboxInt32(hashtable["SkillLevel_2"]);
		}
		if (hashtable.ContainsKey("SkillLevel_3"))
		{
			respFriend.SkillLevel_3 = RuntimeServices.UnboxInt32(hashtable["SkillLevel_3"]);
		}
		if (hashtable.ContainsKey("IsSolo"))
		{
			respFriend.IsSolo = RuntimeServices.UnboxBoolean(hashtable["IsSolo"]);
		}
		if (hashtable.ContainsKey("WeaponItemId"))
		{
			respFriend.WeaponItemId = RuntimeServices.UnboxInt32(hashtable["WeaponItemId"]);
		}
		if (hashtable.ContainsKey("WeaponLevel"))
		{
			respFriend.WeaponLevel = RuntimeServices.UnboxInt32(hashtable["WeaponLevel"]);
		}
		if (hashtable.ContainsKey("WeaponHpPlusBonus"))
		{
			respFriend.WeaponHpPlusBonus = RuntimeServices.UnboxInt32(hashtable["WeaponHpPlusBonus"]);
		}
		if (hashtable.ContainsKey("WeaponAttackPlusBonus"))
		{
			respFriend.WeaponAttackPlusBonus = RuntimeServices.UnboxInt32(hashtable["WeaponAttackPlusBonus"]);
		}
		if (hashtable.ContainsKey("WeaponHpBonus"))
		{
			respFriend.WeaponHpBonus = RuntimeServices.UnboxInt32(hashtable["WeaponHpBonus"]);
		}
		if (hashtable.ContainsKey("WeaponAttackBonus"))
		{
			respFriend.WeaponAttackBonus = RuntimeServices.UnboxInt32(hashtable["WeaponAttackBonus"]);
		}
		if (hashtable.ContainsKey("WeaponSkillLevel_1"))
		{
			respFriend.WeaponSkillLevel_1 = RuntimeServices.UnboxInt32(hashtable["WeaponSkillLevel_1"]);
		}
		if (hashtable.ContainsKey("WeaponSkillLevel_2"))
		{
			respFriend.WeaponSkillLevel_2 = RuntimeServices.UnboxInt32(hashtable["WeaponSkillLevel_2"]);
		}
		if (hashtable.ContainsKey("WeaponSkillLevel_3"))
		{
			respFriend.WeaponSkillLevel_3 = RuntimeServices.UnboxInt32(hashtable["WeaponSkillLevel_3"]);
		}
		if (hashtable.ContainsKey("LastAccessDate"))
		{
			long dateData = RuntimeServices.UnboxInt64(hashtable["LastAccessDate"]);
			respFriend.LastAccessDate = DateTime.FromBinary(dateData);
		}
		if (hashtable.ContainsKey("Name"))
		{
			respFriend.Name = hashtable["Name"] as string;
		}
		if (hashtable.ContainsKey("WeaponLimitBreakCount"))
		{
			respFriend.WeaponLimitBreakCount = RuntimeServices.UnboxInt32(hashtable["WeaponLimitBreakCount"]);
		}
		if (hashtable.ContainsKey("PoppetLimitBreakCount"))
		{
			respFriend.PoppetLimitBreakCount = RuntimeServices.UnboxInt32(hashtable["PoppetLimitBreakCount"]);
		}
		if (hashtable.ContainsKey("PoppetTraitId"))
		{
			respFriend.PoppetTraitId = RuntimeServices.UnboxInt32(hashtable["PoppetTraitId"]);
		}
		if (hashtable.ContainsKey("AngelWeaponTraitId"))
		{
			respFriend.AngelWeaponTraitId = RuntimeServices.UnboxInt32(hashtable["AngelWeaponTraitId"]);
		}
		if (hashtable.ContainsKey("DevilWeaponTraitId"))
		{
			respFriend.DevilWeaponTraitId = RuntimeServices.UnboxInt32(hashtable["DevilWeaponTraitId"]);
		}
		if (hashtable.ContainsKey("AngelAttackPlusBonus"))
		{
			respFriend.AngelAttackPlusBonus = RuntimeServices.UnboxInt32(hashtable["AngelAttackPlusBonus"]);
		}
		if (hashtable.ContainsKey("AngelHpPlusBonus"))
		{
			respFriend.AngelHpPlusBonus = RuntimeServices.UnboxInt32(hashtable["AngelHpPlusBonus"]);
		}
		if (hashtable.ContainsKey("DevilAttackPlusBonus"))
		{
			respFriend.DevilAttackPlusBonus = RuntimeServices.UnboxInt32(hashtable["DevilAttackPlusBonus"]);
		}
		if (hashtable.ContainsKey("DevilHpPlusBonus"))
		{
			respFriend.DevilHpPlusBonus = RuntimeServices.UnboxInt32(hashtable["DevilHpPlusBonus"]);
		}
		if (hashtable.ContainsKey("PoppetAttackPlusBonus"))
		{
			respFriend.PoppetAttackPlusBonus = RuntimeServices.UnboxInt32(hashtable["PoppetAttackPlusBonus"]);
		}
		if (hashtable.ContainsKey("PoppetHpPlusBonus"))
		{
			respFriend.PoppetHpPlusBonus = RuntimeServices.UnboxInt32(hashtable["PoppetHpPlusBonus"]);
		}
		return respFriend;
	}
}
