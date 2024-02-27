using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;

namespace MerlinAPI;

[Serializable]
public class RespPlayerBox : JsonBase
{
	[Serializable]
	public enum EnumItemType
	{
		WEAPON = 1,
		POPPET
	}

	[Serializable]
	internal class _0024GetNewItems_0024closure_00242793
	{
		internal RespPlayerBox[] _0024_00249931_002415006;

		internal int _0024_00249930_002415007;

		public _0024GetNewItems_0024closure_00242793(RespPlayerBox[] _0024_00249931_002415006, int _0024_00249930_002415007)
		{
			this._0024_00249931_002415006 = _0024_00249931_002415006;
			this._0024_00249930_002415007 = _0024_00249930_002415007;
		}

		public bool Invoke(RespPlayerBox o)
		{
			return RuntimeServices.EqualityOperator(o.Id, _0024_00249931_002415006[_0024_00249930_002415007].Id);
		}
	}

	public BoxId Id;

	public int TPlayerId;

	public int ItemType;

	public int ItemId;

	public int Exp;

	public int Level;

	public int LevelMax;

	public int LimitBreakCount;

	public int HpPlusBonus;

	public int AttackPlusBonus;

	public int HpBonus;

	public int AttackBonus;

	public int SkillLevel_1;

	public int SkillLevel_2;

	public int SkillLevel_3;

	public int TraitId;

	public bool IsWeapon => ItemType == 1;

	public bool IsPoppet => ItemType == 2;

	public float PlusAttackStatus => DamageCalc.AttackPlusValue(Rarity, AttackPlusBonus);

	public float PlusHPStatus => DamageCalc.HpPlusValue(Rarity, HpPlusBonus);

	public EnumRares Rarity => IsWeapon ? ((EnumRares)MWeapons.Get(ItemId).Rare.Id) : ((!IsPoppet) ? EnumRares.normal : ((EnumRares)MPoppets.Get(ItemId).Rare.Id));

	public static RespPlayerBox[] GetNewItems(RespPlayerBox[] oldBox, RespPlayerBox[] newBox)
	{
		System.Collections.Generic.List<RespPlayerBox> list = new System.Collections.Generic.List<RespPlayerBox>();
		int i = 0;
		for (int length = newBox.Length; i < length; i = checked(i + 1))
		{
			if (Array.Find(oldBox, _0024adaptor_0024__RespPlayerBox_GetNewItems_0024callable559_002411_52___0024Predicate_0024169.Adapt(new _0024GetNewItems_0024closure_00242793(newBox, i).Invoke)) == null)
			{
				list.Add(newBox[i]);
			}
		}
		return (RespPlayerBox[])Builtins.array(typeof(RespPlayerBox), list);
	}

	public static RespPlayerBox ConvertRespPlayerBox(JsonBase item)
	{
		if (item == null)
		{
			goto IL_0052;
		}
		object result;
		if (item is RespPlayerBox)
		{
			result = (RespPlayerBox)item;
		}
		else if (item is RespWeapon)
		{
			result = ((RespWeapon)item).RefPlayerBox;
		}
		else
		{
			if (!(item is RespPoppet))
			{
				goto IL_0052;
			}
			result = ((RespPoppet)item).RefPlayerBox;
		}
		goto IL_0053;
		IL_0052:
		result = null;
		goto IL_0053;
		IL_0053:
		return (RespPlayerBox)result;
	}

	public RespWeapon toRespWeapon()
	{
		if (ItemType != 1)
		{
			throw new AssertionFailedException("魔ペットBoxデータをtoRespWeapon()で武器化しようとした。");
		}
		RespWeapon respWeapon = new RespWeapon(ItemId);
		respWeapon.RefPlayerBox = this;
		if (UserData.Current != null)
		{
			respWeapon.favorite = (UserData.Current.IsFavorite(this) ? 1 : 0);
		}
		return respWeapon;
	}

	public RespPoppet toRespPoppet()
	{
		if (ItemType != 2)
		{
			throw new AssertionFailedException("武器BoxデータをtoRespPoppet()で魔ペット化しようとした。");
		}
		RespPoppet respPoppet = new RespPoppet(ItemId);
		respPoppet.RefPlayerBox = this;
		if (UserData.Current != null)
		{
			respPoppet.favorite = (UserData.Current.IsFavorite(this) ? 1 : 0);
		}
		return respPoppet;
	}

	public RespPlayerBox Clone()
	{
		RespPlayerBox respPlayerBox = new RespPlayerBox();
		respPlayerBox.Id = Id;
		respPlayerBox.ItemType = ItemType;
		respPlayerBox.ItemId = ItemId;
		respPlayerBox.AttackBonus = AttackBonus;
		respPlayerBox.AttackPlusBonus = AttackPlusBonus;
		respPlayerBox.SkillLevel_1 = SkillLevel_1;
		respPlayerBox.SkillLevel_2 = SkillLevel_2;
		respPlayerBox.SkillLevel_3 = SkillLevel_3;
		respPlayerBox.Exp = Exp;
		respPlayerBox.HpBonus = HpBonus;
		respPlayerBox.HpPlusBonus = HpPlusBonus;
		respPlayerBox.Level = Level;
		respPlayerBox.LevelMax = LevelMax;
		respPlayerBox.LimitBreakCount = LimitBreakCount;
		respPlayerBox.TPlayerId = TPlayerId;
		respPlayerBox.TraitId = TraitId;
		return respPlayerBox;
	}

	public MTraits getTrait()
	{
		return MTraits.Get(TraitId);
	}
}
