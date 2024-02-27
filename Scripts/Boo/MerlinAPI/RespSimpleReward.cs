using System;

namespace MerlinAPI;

[Serializable]
public class RespSimpleReward : JsonBase
{
	public int Id;

	public int TypeValue;

	public bool IsGet;

	public int ItemId;

	public int Level;

	public int Quantity;

	public int No;

	public bool IsExp => TypeValue == 1;

	public bool IsCoin => TypeValue == 2;

	public bool IsWeapon => TypeValue == 3;

	public MWeapons WeaponMaster => (!IsWeapon) ? null : MWeapons.Get(ItemId);

	public bool IsPoppet => TypeValue == 4;

	public MPoppets PoppetMaster => (!IsPoppet) ? null : MPoppets.Get(ItemId);

	public bool IsRare => CheckRare(EnumRares.rare);

	public bool IsSpecialRare => CheckRare(EnumRares.special_rare);

	public bool IsCandy => TypeValue == 5;

	public bool IsFayStone => TypeValue == 6;

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

	public bool IsKeyItem => TypeValue == 7;

	public MKeyItems KeyItem => (!IsKeyItem) ? null : MKeyItems.Get(ItemId);

	public RespSimpleReward()
	{
		Level = 1;
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
}
