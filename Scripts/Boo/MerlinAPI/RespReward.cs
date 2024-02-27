using System;
using System.Collections;
using System.Text;
using Boo.Lang.Runtime;
using UnityEngine;

namespace MerlinAPI;

[Serializable]
public class RespReward : JsonBase
{
	[Serializable]
	public enum Type
	{
		FirstClear,
		Raid,
		Challenge
	}

	public int Id;

	public int MasterTypeValue;

	public int ItemId;

	public int Level;

	public int Quantity;

	public string Title;

	public string Explain;

	public string Name;

	public int Unit;

	public int Rate;

	public int TraitId;

	public int AttackPlusBonus;

	public int HpPlusBonus;

	public int SkillLevel_1;

	public int SkillLevel_2;

	public int SkillLevel_3;

	public int No;

	public bool IsGet;

	public int MItemGroupId;

	public BoxId BoxId;

	public Type RewardType;

	public int TypeValue => MasterTypeValue;

	public string Message => Explain;

	public bool IsExp => MasterTypeValue == 1;

	public bool IsCoin => MasterTypeValue == 2;

	public bool IsWeapon => MasterTypeValue == 3;

	public MWeapons WeaponMaster => (!IsWeapon) ? null : MWeapons.Get(ItemId);

	public bool IsPoppet => MasterTypeValue == 4;

	public MPoppets PoppetMaster => (!IsPoppet) ? null : MPoppets.Get(ItemId);

	public bool IsRare => CheckRare(EnumRares.rare);

	public bool IsSpecialRare => CheckRare(EnumRares.special_rare);

	public bool IsCandy => MasterTypeValue == 5;

	public bool IsFayStone => MasterTypeValue == 6;

	public bool IsDrop
	{
		get
		{
			bool num = IsCandy;
			if (!num)
			{
				num = IsWeapon;
			}
			if (!num)
			{
				num = IsPoppet;
			}
			if (!num)
			{
				num = IsKeyItem;
			}
			return num;
		}
	}

	public bool IsKeyItem => MasterTypeValue == 7;

	public MKeyItems KeyItem => (!IsKeyItem) ? null : MKeyItems.Get(ItemId);

	public RespReward()
	{
		Level = 1;
		Title = string.Empty;
		Explain = string.Empty;
		Name = string.Empty;
		SkillLevel_1 = 1;
		SkillLevel_2 = 1;
		SkillLevel_3 = 1;
	}

	public RespReward clone()
	{
		RespReward respReward = new RespReward();
		respReward.Id = Id;
		respReward.MasterTypeValue = MasterTypeValue;
		respReward.ItemId = ItemId;
		respReward.Level = Level;
		respReward.Quantity = Quantity;
		respReward.Title = Title;
		respReward.Explain = Explain;
		respReward.Name = Name;
		respReward.Unit = Unit;
		respReward.Rate = Rate;
		respReward.TraitId = TraitId;
		respReward.AttackPlusBonus = AttackPlusBonus;
		respReward.HpPlusBonus = HpPlusBonus;
		respReward.No = No;
		respReward.IsGet = IsGet;
		respReward.MItemGroupId = MItemGroupId;
		respReward.BoxId = BoxId;
		respReward.SkillLevel_1 = SkillLevel_1;
		respReward.SkillLevel_2 = SkillLevel_2;
		respReward.SkillLevel_3 = SkillLevel_3;
		return respReward;
	}

	public bool CheckRare(EnumRares r)
	{
		int num;
		if (IsWeapon)
		{
			MWeapons mWeapons = MWeapons.Get(ItemId);
			num = ((mWeapons != null) ? 1 : 0);
			if (num != 0)
			{
				num = ((mWeapons.Rare.Id >= (int)r) ? 1 : 0);
			}
		}
		else if (IsPoppet)
		{
			MPoppets mPoppets = MPoppets.Get(ItemId);
			num = ((mPoppets != null) ? 1 : 0);
			if (num != 0)
			{
				num = ((mPoppets.Rare.Id >= (int)r) ? 1 : 0);
			}
		}
		else
		{
			num = 0;
		}
		return (byte)num != 0;
	}

	public EnumRares GetRare()
	{
		return IsWeapon ? ((EnumRares)MWeapons.Get(ItemId).Rare.Id) : ((!IsPoppet) ? EnumRares.normal : ((EnumRares)MPoppets.Get(ItemId).Rare.Id));
	}

	public static bool Equals(RespReward a, RespReward b)
	{
		int num;
		if (a == null || b == null)
		{
			num = 0;
		}
		else
		{
			bool flag = a.MasterTypeValue == b.MasterTypeValue;
			bool flag2 = a.ItemId == b.ItemId;
			bool flag3 = a.Title == b.Title;
			bool flag4 = a.Message == b.Message;
			bool flag5 = a.RewardType == b.RewardType;
			num = (flag ? 1 : 0);
			if (num != 0)
			{
				num = (flag2 ? 1 : 0);
			}
			if (num != 0)
			{
				num = (flag3 ? 1 : 0);
			}
			if (num != 0)
			{
				num = (flag4 ? 1 : 0);
			}
			if (num != 0)
			{
				num = (flag5 ? 1 : 0);
			}
		}
		return (byte)num != 0;
	}

	public RespPlayerBox toRespPlayerBox()
	{
		if (!IsWeapon && !IsPoppet)
		{
			throw new AssertionFailedException("IsWeapon or IsPoppet");
		}
		RespPlayerBox respPlayerBox = new RespPlayerBox();
		if (IsWeapon)
		{
			respPlayerBox.ItemType = 1;
		}
		else
		{
			respPlayerBox.ItemType = 2;
		}
		respPlayerBox.LevelMax = LevelLimitMin((EnumMasterTypeValues)MasterTypeValue, ItemId);
		respPlayerBox.ItemId = ItemId;
		respPlayerBox.Level = Level;
		respPlayerBox.TraitId = TraitId;
		respPlayerBox.AttackPlusBonus = AttackPlusBonus;
		respPlayerBox.HpPlusBonus = HpPlusBonus;
		respPlayerBox.SkillLevel_1 = SkillLevel_1;
		respPlayerBox.SkillLevel_2 = SkillLevel_2;
		respPlayerBox.SkillLevel_3 = SkillLevel_3;
		return respPlayerBox;
	}

	private static int LevelLimitMin(EnumMasterTypeValues type, int itemId)
	{
		return type switch
		{
			EnumMasterTypeValues.Weapon => MWeapons.Get(itemId).LevelLimitMin, 
			EnumMasterTypeValues.Poppet => MPoppets.Get(itemId).LevelLimitMin, 
			_ => 1, 
		};
	}

	public RespWeapon toRespWeapon()
	{
		RespWeapon respWeapon = new RespWeapon();
		if (ItemId <= 0)
		{
			respWeapon.RefPlayerBox = new RespPlayerBox();
			respWeapon.RefPlayerBox.ItemType = 1;
			respWeapon.Id = new BoxId(checked(ItemId + UnityEngine.Random.Range(0, 1000000)));
			respWeapon.MWeaponId = ItemId;
			respWeapon.AngelSkillLevel = 1;
			respWeapon.AttackBonus = 0;
			respWeapon.AttackPlusBonus = 0;
			respWeapon.CoverSkillLevel = 1;
			respWeapon.DemonSkillLevel = 1;
			respWeapon.LevelMax = Level;
			respWeapon.Exp = 0;
			respWeapon.HpBonus = 0;
			respWeapon.HpPlusBonus = 0;
			respWeapon.LimitBreakCount = 0;
			respWeapon.TPlayerId = 1;
			respWeapon.TraitId = 0;
		}
		else
		{
			respWeapon = new RespWeapon(ItemId);
			respWeapon.Id = BoxId;
			respWeapon.TraitId = TraitId;
			respWeapon.AttackPlusBonus = AttackPlusBonus;
			respWeapon.HpPlusBonus = HpPlusBonus;
			respWeapon.AngelSkillLevel = SkillLevel_1;
			respWeapon.DemonSkillLevel = SkillLevel_2;
			respWeapon.CoverSkillLevel = SkillLevel_3;
		}
		respWeapon.Level = Level;
		return respWeapon;
	}

	public RespPoppet toRespPoppet()
	{
		RespPoppet respPoppet = new RespPoppet();
		if (ItemId <= 0)
		{
			respPoppet.RefPlayerBox = new RespPlayerBox();
			respPoppet.RefPlayerBox.ItemType = 2;
			respPoppet.Id = new BoxId(checked(ItemId + UnityEngine.Random.Range(0, 1000000)));
			respPoppet.MPoppetId = ItemId;
			respPoppet.AttackBonus = 0;
			respPoppet.AttackPlusBonus = 0;
			respPoppet.ChainSkillLevel = 1;
			respPoppet.CoverSkillLevel_1 = 1;
			respPoppet.CoverSkillLevel_2 = 1;
			respPoppet.LevelMax = Level;
			respPoppet.Exp = 0;
			respPoppet.HpBonus = 0;
			respPoppet.HpPlusBonus = 0;
			respPoppet.LimitBreakCount = 0;
			respPoppet.TPlayerId = 1;
			respPoppet.TraitId = 0;
		}
		else
		{
			respPoppet = new RespPoppet(ItemId);
			respPoppet.Id = BoxId;
			respPoppet.TraitId = TraitId;
			respPoppet.AttackPlusBonus = AttackPlusBonus;
			respPoppet.HpPlusBonus = HpPlusBonus;
			respPoppet.CoverSkillLevel_1 = SkillLevel_1;
			respPoppet.CoverSkillLevel_2 = SkillLevel_2;
			respPoppet.ChainSkillLevel = SkillLevel_3;
		}
		respPoppet.Level = Level;
		return respPoppet;
	}

	public override string ToString()
	{
		object result;
		if (MasterTypeValue <= 0)
		{
			result = new StringBuilder("HAZURE IsGet:").Append(IsGet).ToString();
		}
		else if (MasterTypeValue == 1)
		{
			result = new StringBuilder("Exp:").Append((object)Quantity).Append(" IsGet:").Append(IsGet)
				.ToString();
		}
		else if (MasterTypeValue == 2)
		{
			result = new StringBuilder("Coin:").Append((object)Quantity).Append(" IsGet:").Append(IsGet)
				.ToString();
		}
		else if (MasterTypeValue == 3)
		{
			MWeapons mWeapons = MWeapons.Get(ItemId);
			string value = ((mWeapons != null) ? mWeapons.Name.ToString() : string.Empty);
			result = new StringBuilder("Weapon: id:").Append((object)ItemId).Append(" ").Append(value)
				.Append(" IsGet:")
				.Append(IsGet)
				.Append(" SkillLevel_1:")
				.Append((object)SkillLevel_1)
				.Append(" SkillLevel_2:")
				.Append((object)SkillLevel_2)
				.Append(" SkillLevel_3:")
				.Append((object)SkillLevel_3)
				.ToString();
		}
		else if (MasterTypeValue != 4)
		{
			result = ((MasterTypeValue == 5) ? new StringBuilder("Candy IsGet:").Append(IsGet).ToString() : ((MasterTypeValue != 7) ? new StringBuilder("ID:").Append((object)Id).Append(" MasterTypeValue:").Append((EnumMasterTypeValues)MasterTypeValue)
				.Append(" IsGet:")
				.Append(IsGet)
				.Append(" ItemId:")
				.Append((object)ItemId)
				.Append(" Level:")
				.Append((object)Level)
				.Append(" Quantity:")
				.Append((object)Quantity)
				.Append(" SkillLevel_1:")
				.Append((object)SkillLevel_1)
				.Append(" SkillLevel_2:")
				.Append((object)SkillLevel_2)
				.Append(" SkillLevel_3:")
				.Append((object)SkillLevel_3)
				.ToString() : new StringBuilder("KeyItem IsGet:").Append(IsGet).Append(" ").Append(KeyItem)
				.ToString()));
		}
		else
		{
			MPoppets mPoppets = MPoppets.Get(ItemId);
			string value2 = ((mPoppets != null) ? mPoppets.Name.ToString() : string.Empty);
			result = new StringBuilder("Poppet: id:").Append((object)ItemId).Append(" ").Append(value2)
				.Append(" IsGet:")
				.Append(IsGet)
				.Append(" SkillLevel_1:")
				.Append((object)SkillLevel_1)
				.Append(" SkillLevel_2:")
				.Append((object)SkillLevel_2)
				.Append(" SkillLevel_3:")
				.Append((object)SkillLevel_3)
				.ToString();
		}
		return (string)result;
	}

	public static RespReward FromSimpleReward(RespSimpleReward sr)
	{
		RespReward respReward = new RespReward();
		if (sr != null)
		{
			respReward.Id = sr.Id;
			respReward.MasterTypeValue = sr.TypeValue;
			respReward.IsGet = sr.IsGet;
			respReward.ItemId = sr.ItemId;
			respReward.Level = sr.Level;
			respReward.Quantity = sr.Quantity;
			respReward.No = sr.No;
		}
		return respReward;
	}

	public static RespReward[] FromSimpleRewardList(RespSimpleReward[] srlist)
	{
		RespReward[] result;
		if (srlist == null)
		{
			result = new RespReward[0];
		}
		else
		{
			int length = srlist.Length;
			RespReward[] array = new RespReward[length];
			int num = 0;
			int num2 = length;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int index = num;
				num++;
				array[RuntimeServices.NormalizeArrayIndex(array, index)] = FromSimpleReward(srlist[RuntimeServices.NormalizeArrayIndex(srlist, index)]);
			}
			result = array;
		}
		return result;
	}

	public static RespReward Weapon(int mstId, int lv, string title, string message, Type rtype)
	{
		RespReward respReward = new RespReward();
		respReward.Id = 1;
		respReward.MasterTypeValue = 3;
		respReward.IsGet = true;
		respReward.ItemId = mstId;
		respReward.Level = lv;
		respReward.Quantity = 1;
		respReward.Title = title;
		respReward.Explain = message;
		respReward.RewardType = rtype;
		respReward.SkillLevel_1 = 1;
		respReward.SkillLevel_2 = 1;
		respReward.SkillLevel_3 = 1;
		return respReward;
	}

	public static RespReward Poppet(int mstId, int lv, string title, string message, Type rtype)
	{
		RespReward respReward = new RespReward();
		respReward.Id = 1;
		respReward.MasterTypeValue = 4;
		respReward.IsGet = true;
		respReward.ItemId = mstId;
		respReward.Level = lv;
		respReward.Quantity = 1;
		respReward.Title = title;
		respReward.Explain = message;
		respReward.RewardType = rtype;
		respReward.SkillLevel_1 = 1;
		respReward.SkillLevel_2 = 1;
		respReward.SkillLevel_3 = 1;
		return respReward;
	}

	public static RespReward FromPresent(RespPlayerPresentBox present)
	{
		return (present == null) ? null : JsonToRespReward(present.ItemData);
	}

	public static RespReward FromPlayerBox(RespPlayerBox box)
	{
		object result;
		if (box == null)
		{
			result = null;
		}
		else if (!box.IsWeapon && !box.IsPoppet)
		{
			result = null;
		}
		else
		{
			RespReward respReward = new RespReward();
			respReward.Id = 1;
			if (box.IsWeapon)
			{
				respReward.MasterTypeValue = 3;
			}
			else
			{
				respReward.MasterTypeValue = 4;
			}
			respReward.ItemId = box.ItemId;
			respReward.Level = box.Level;
			respReward.Quantity = 1;
			respReward.TraitId = box.TraitId;
			respReward.AttackPlusBonus = box.AttackPlusBonus;
			respReward.HpPlusBonus = box.HpPlusBonus;
			respReward.IsGet = true;
			respReward.BoxId = box.Id;
			respReward.SkillLevel_1 = box.SkillLevel_1;
			respReward.SkillLevel_2 = box.SkillLevel_2;
			respReward.SkillLevel_3 = box.SkillLevel_3;
			result = respReward;
		}
		return (RespReward)result;
	}

	public static RespReward JsonToRespReward(string jsonStr)
	{
		object result;
		if (string.IsNullOrEmpty(jsonStr))
		{
			result = null;
		}
		else
		{
			object obj = NGUIJson.jsonDecode(jsonStr);
			if (!(obj is Hashtable))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
			}
			Hashtable hashtable = (Hashtable)obj;
			result = ((hashtable == null) ? null : (JsonBase.CreateFromJson(typeof(RespReward), hashtable) as RespReward));
		}
		return (RespReward)result;
	}

	public static RespReward[] JsonArrayToRespRewards(string jsonStr)
	{
		RespReward[] result = new RespReward[0];
		if (!string.IsNullOrEmpty(jsonStr))
		{
			object obj = NGUIJson.jsonDecode(jsonStr);
			if (obj != null)
			{
				result = JsonBase.CreateFromJson(typeof(RespReward[]), obj) as RespReward[];
			}
		}
		return result;
	}

	public static object SetFields(RespReward[] rewards, string title, string message, Type rtype)
	{
		object result;
		if (rewards == null)
		{
			result = null;
		}
		else
		{
			int i = 0;
			for (int length = rewards.Length; i < length; i = checked(i + 1))
			{
				if (rewards[i] != null)
				{
					rewards[i].Title = title;
					rewards[i].Explain = message;
					rewards[i].RewardType = rtype;
				}
			}
			result = null;
		}
		return result;
	}
}
