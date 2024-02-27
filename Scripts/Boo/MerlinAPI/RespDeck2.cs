using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;

namespace MerlinAPI;

[Serializable]
public class RespDeck2 : JsonBase
{
	public bool IsEquip;

	public int No;

	public BoxId AngelBoxId;

	public BoxId DevilBoxId;

	public BoxId PoppetBoxId;

	public RespDeck2Support[] Supports;

	public RespWeapon AngelWeapon
	{
		get
		{
			UserData current = UserData.Current;
			if (current == null)
			{
				throw new AssertionFailedException("ud != null");
			}
			return current.boxWeapon(AngelBoxId);
		}
	}

	public RespWeapon DevilWeapon
	{
		get
		{
			UserData current = UserData.Current;
			if (current == null)
			{
				throw new AssertionFailedException("ud != null");
			}
			return current.boxWeapon(DevilBoxId);
		}
	}

	public RespPoppet MainPoppet
	{
		get
		{
			UserData current = UserData.Current;
			if (current == null)
			{
				throw new AssertionFailedException("ud != null");
			}
			return current.boxPoppet(PoppetBoxId);
		}
	}

	public RespDeck2Support[] OrderedSupports
	{
		get
		{
			object result;
			if (Supports == null)
			{
				result = null;
			}
			else
			{
				RespDeck2Support[] array = new RespDeck2Support[Supports.Length];
				Array.Copy(Supports, array, Supports.Length);
				Array.Sort(array, _0024adaptor_0024__ResponseExtensions_0024callable355_00241581_38___0024Comparison_0024170.Adapt((RespDeck2Support a, RespDeck2Support b) => checked(a.No - b.No)));
				result = array;
			}
			return (RespDeck2Support[])result;
		}
	}

	public RespDeck2 clone()
	{
		RespDeck2 respDeck = new RespDeck2();
		respDeck.No = No;
		respDeck.AngelBoxId = AngelBoxId;
		respDeck.DevilBoxId = DevilBoxId;
		respDeck.PoppetBoxId = PoppetBoxId;
		if (Supports != null)
		{
			int length = Supports.Length;
			respDeck.Supports = new RespDeck2Support[length];
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
				RespDeck2Support[] supports = Supports;
				if (supports[RuntimeServices.NormalizeArrayIndex(supports, index)] != null)
				{
					RespDeck2Support[] supports2 = respDeck.Supports;
					int num3 = RuntimeServices.NormalizeArrayIndex(supports2, index);
					RespDeck2Support[] supports3 = Supports;
					supports2[num3] = supports3[RuntimeServices.NormalizeArrayIndex(supports3, index)].clone();
				}
			}
		}
		return respDeck;
	}

	public void init(RespDeck2 templDecks2)
	{
		if (templDecks2 == null)
		{
			return;
		}
		No = templDecks2.No;
		if (templDecks2.Supports == null)
		{
			return;
		}
		int length = templDecks2.Supports.Length;
		Supports = new RespDeck2Support[length];
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
			RespDeck2Support[] supports = templDecks2.Supports;
			if (supports[RuntimeServices.NormalizeArrayIndex(supports, index)] != null)
			{
				RespDeck2Support[] supports2 = Supports;
				supports2[RuntimeServices.NormalizeArrayIndex(supports2, index)] = new RespDeck2Support();
				RespDeck2Support[] supports3 = Supports;
				RespDeck2Support obj = supports3[RuntimeServices.NormalizeArrayIndex(supports3, index)];
				RespDeck2Support[] supports4 = templDecks2.Supports;
				obj.No = supports4[RuntimeServices.NormalizeArrayIndex(supports4, index)].No;
				RespDeck2Support[] supports5 = Supports;
				RespDeck2Support obj2 = supports5[RuntimeServices.NormalizeArrayIndex(supports5, index)];
				RespDeck2Support[] supports6 = templDecks2.Supports;
				obj2.FormType = supports6[RuntimeServices.NormalizeArrayIndex(supports6, index)].FormType;
				RespDeck2Support[] supports7 = Supports;
				RespDeck2Support obj3 = supports7[RuntimeServices.NormalizeArrayIndex(supports7, index)];
				RespDeck2Support[] supports8 = templDecks2.Supports;
				obj3.ItemType = supports8[RuntimeServices.NormalizeArrayIndex(supports8, index)].ItemType;
			}
		}
	}

	public BoxId[] allWeaponBoxIds()
	{
		return (BoxId[])RuntimeServices.AddArrays(typeof(BoxId), new BoxId[2] { AngelBoxId, DevilBoxId }, allSupportWeaponBoxIds());
	}

	public BoxId[] allPoppetBoxIds()
	{
		return (BoxId[])RuntimeServices.AddArrays(typeof(BoxId), new BoxId[1] { PoppetBoxId }, allSupportPoppetBoxIds());
	}

	public BoxId[] allSupportWeaponBoxIds()
	{
		return supportBoxIdsOf((RespDeck2Support r) => r.IsWeapon);
	}

	public BoxId[] allSupportPoppetBoxIds()
	{
		return supportBoxIdsOf((RespDeck2Support r) => r.IsPoppet);
	}

	public BoxId[] allBoxIds()
	{
		return (BoxId[])RuntimeServices.AddArrays(typeof(BoxId), (BoxId[])RuntimeServices.AddArrays(typeof(BoxId), allWeaponBoxIds(), new BoxId[1] { PoppetBoxId }), allSupportBoxIds());
	}

	public BoxId[] allSupportBoxIds()
	{
		return supportBoxIdsOf(null);
	}

	public BoxId[] supportBoxIdsOf(__RespDeck2_supportBoxIdsOf_0024callable91_00241562_41__ pred)
	{
		System.Collections.Generic.List<BoxId> list = new System.Collections.Generic.List<BoxId>();
		int i = 0;
		RespDeck2Support[] orderedSupports = OrderedSupports;
		for (int length = orderedSupports.Length; i < length; i = checked(i + 1))
		{
			if (orderedSupports[i] != null && (pred == null || pred(orderedSupports[i])))
			{
				list.Add(orderedSupports[i].BoxId);
			}
		}
		return (BoxId[])Builtins.array(typeof(BoxId), list);
	}

	public RespDeck2Support[] supportsOf(__RespDeck2_supportBoxIdsOf_0024callable91_00241562_41__ pred)
	{
		System.Collections.Generic.List<RespDeck2Support> list = new System.Collections.Generic.List<RespDeck2Support>();
		int i = 0;
		RespDeck2Support[] orderedSupports = OrderedSupports;
		for (int length = orderedSupports.Length; i < length; i = checked(i + 1))
		{
			if (orderedSupports[i] != null && (pred == null || pred(orderedSupports[i])))
			{
				list.Add(orderedSupports[i]);
			}
		}
		return (RespDeck2Support[])Builtins.array(typeof(RespDeck2Support), list);
	}

	public RespWeapon[] getSupportWeapons(RACE_TYPE race)
	{
		object result;
		if (Supports == null)
		{
			result = new RespWeapon[0];
		}
		else
		{
			RespDeck2Support[] orderedSupports = OrderedSupports;
			System.Collections.Generic.List<RespWeapon> list = new System.Collections.Generic.List<RespWeapon>();
			Deck2FormTypes deck2FormTypes = ((race == RACE_TYPE.Tensi) ? Deck2FormTypes.Angel : Deck2FormTypes.Devil);
			int i = 0;
			RespDeck2Support[] array = orderedSupports;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (array[i].FormType == (int)deck2FormTypes && array[i].IsWeapon)
				{
					RespWeapon boxWeapon = array[i].BoxWeapon;
					if (boxWeapon != null)
					{
						list.Add(boxWeapon);
					}
				}
			}
			result = (RespWeapon[])Builtins.array(typeof(RespWeapon), list);
		}
		return (RespWeapon[])result;
	}

	public RespPoppet[] getSupportPoppets(RACE_TYPE race)
	{
		object result;
		if (Supports == null)
		{
			result = new RespPoppet[0];
		}
		else
		{
			RespDeck2Support[] orderedSupports = OrderedSupports;
			System.Collections.Generic.List<RespPoppet> list = new System.Collections.Generic.List<RespPoppet>();
			Deck2FormTypes deck2FormTypes = ((race == RACE_TYPE.Tensi) ? Deck2FormTypes.Angel : Deck2FormTypes.Devil);
			int i = 0;
			RespDeck2Support[] array = orderedSupports;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (array[i].FormType == (int)deck2FormTypes && array[i].IsPoppet)
				{
					RespPoppet boxPoppet = array[i].BoxPoppet;
					if (boxPoppet != null)
					{
						list.Add(boxPoppet);
					}
				}
			}
			result = (RespPoppet[])Builtins.array(typeof(RespPoppet), list);
		}
		return (RespPoppet[])result;
	}

	public void fromEquipments(RespDeck2 templDecks2, WeaponEquipments wep, PoppetEquipments pet)
	{
		init(templDecks2);
		if (wep != null)
		{
			if (wep.MainTenshiWeapon != null)
			{
				AngelBoxId = wep.MainTenshiWeapon.Id;
			}
			if (wep.MainTenshiWeapon != null)
			{
				DevilBoxId = wep.MainAkumaWeapon.Id;
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int length = Supports.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num5 < length)
			{
				int index = num5;
				num5++;
				RespDeck2Support[] supports = Supports;
				RespDeck2Support respDeck2Support = supports[RuntimeServices.NormalizeArrayIndex(supports, index)];
				checked
				{
					if (respDeck2Support.FormType == 1)
					{
						if (respDeck2Support.ItemType == 1)
						{
							RespWeapon[] subTenshiWeapons = wep.SubTenshiWeapons;
							if (subTenshiWeapons[RuntimeServices.NormalizeArrayIndex(subTenshiWeapons, num)] != null && num < wep.SubTenshiWeapons.Length)
							{
								RespWeapon[] subTenshiWeapons2 = wep.SubTenshiWeapons;
								respDeck2Support.BoxId = subTenshiWeapons2[RuntimeServices.NormalizeArrayIndex(subTenshiWeapons2, num)].Id;
							}
							num++;
						}
						else if (respDeck2Support.ItemType == 2)
						{
							RespPoppet[] subTenshiPoppets = wep.SubTenshiPoppets;
							if (subTenshiPoppets[RuntimeServices.NormalizeArrayIndex(subTenshiPoppets, num3)] != null && num3 < wep.SubTenshiPoppets.Length)
							{
								RespPoppet[] subTenshiPoppets2 = wep.SubTenshiPoppets;
								respDeck2Support.BoxId = subTenshiPoppets2[RuntimeServices.NormalizeArrayIndex(subTenshiPoppets2, num3)].Id;
							}
							num3++;
						}
					}
					else
					{
						if (respDeck2Support.FormType != 2)
						{
							continue;
						}
						if (respDeck2Support.ItemType == 1)
						{
							RespWeapon[] subAkumaWeapons = wep.SubAkumaWeapons;
							if (subAkumaWeapons[RuntimeServices.NormalizeArrayIndex(subAkumaWeapons, num2)] != null && num2 < wep.SubAkumaWeapons.Length)
							{
								RespWeapon[] subAkumaWeapons2 = wep.SubAkumaWeapons;
								respDeck2Support.BoxId = subAkumaWeapons2[RuntimeServices.NormalizeArrayIndex(subAkumaWeapons2, num2)].Id;
							}
							num2++;
						}
						else if (respDeck2Support.ItemType == 2)
						{
							RespPoppet[] subAkumaPoppets = wep.SubAkumaPoppets;
							if (subAkumaPoppets[RuntimeServices.NormalizeArrayIndex(subAkumaPoppets, num4)] != null && num4 < wep.SubAkumaPoppets.Length)
							{
								RespPoppet[] subAkumaPoppets2 = wep.SubAkumaPoppets;
								respDeck2Support.BoxId = subAkumaPoppets2[RuntimeServices.NormalizeArrayIndex(subAkumaPoppets2, num4)].Id;
							}
							num4++;
						}
					}
				}
			}
		}
		if (pet != null && pet.MainPoppet != null)
		{
			PoppetBoxId = pet.MainPoppet.Id;
		}
	}

	internal int _0024get_OrderedSupports_0024closure_00242824(RespDeck2Support a, RespDeck2Support b)
	{
		return checked(a.No - b.No);
	}

	internal bool _0024allSupportWeaponBoxIds_0024closure_00243278(RespDeck2Support r)
	{
		return r.IsWeapon;
	}

	internal bool _0024allSupportPoppetBoxIds_0024closure_00243279(RespDeck2Support r)
	{
		return r.IsPoppet;
	}
}
