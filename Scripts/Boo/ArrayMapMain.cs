using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class ArrayMapMain
{
	public static int[] RespsToInts(RespFriend[] resps, __ArrayMapMain_RespsToInts_0024callable111_00249_64__ f)
	{
		System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
		int i = 0;
		for (int length = resps.Length; i < length; i = checked(i + 1))
		{
			list.Add(f(resps[i]));
		}
		return list.ToArray();
	}

	public static int[] RespsToInts(RespApplyInfo[] resps, __ArrayMapMain_RespsToInts_0024callable112_002415_67__ f)
	{
		System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
		int i = 0;
		for (int length = resps.Length; i < length; i = checked(i + 1))
		{
			list.Add(f(resps[i]));
		}
		return list.ToArray();
	}

	public static int[] RespsToInts(RespPlayerPresentBox[] resps, __ArrayMapMain_RespsToInts_0024callable113_002421_74__ f)
	{
		System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
		int i = 0;
		for (int length = resps.Length; i < length; i = checked(i + 1))
		{
			list.Add(f(resps[i]));
		}
		return list.ToArray();
	}

	public static RespPlayerPresentBox[] FilterResps(RespPlayerPresentBox[] resps, __ArrayMapMain_FilterResps_0024callable114_002427_77__ pred)
	{
		System.Collections.Generic.List<RespPlayerPresentBox> list = new System.Collections.Generic.List<RespPlayerPresentBox>();
		int i = 0;
		for (int length = resps.Length; i < length; i = checked(i + 1))
		{
			if (pred(resps[i]))
			{
				list.Add(resps[i]);
			}
		}
		return list.ToArray();
	}

	public static RespFriend[] FilterResps(RespFriend[] resps, __ArrayMapMain_FilterResps_0024callable115_002434_67__ pred)
	{
		System.Collections.Generic.List<RespFriend> list = new System.Collections.Generic.List<RespFriend>();
		int i = 0;
		for (int length = resps.Length; i < length; i = checked(i + 1))
		{
			if (pred(resps[i]))
			{
				list.Add(resps[i]);
			}
		}
		return list.ToArray();
	}

	public static RespMember[] FilterResps(RespMember[] resps, __ArrayMapMain_FilterResps_0024callable116_002441_67__ pred)
	{
		System.Collections.Generic.List<RespMember> list = new System.Collections.Generic.List<RespMember>();
		int i = 0;
		for (int length = resps.Length; i < length; i = checked(i + 1))
		{
			if (pred(resps[i]))
			{
				list.Add(resps[i]);
			}
		}
		return list.ToArray();
	}

	public static string[] RespsToStr(RespWeaponPoppet[] resps, __ArrayMapMain_RespsToStr_0024callable117_002448_69__ f)
	{
		System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
		int i = 0;
		for (int length = resps.Length; i < length; i = checked(i + 1))
		{
			list.Add(f(resps[i]));
		}
		return list.ToArray();
	}

	public static RespWeapon[] ToRespWeapons(RespWeaponPoppet[] resps, __ArrayMapMain_ToRespWeapons_0024callable118_002454_72__ f)
	{
		System.Collections.Generic.List<RespWeapon> list = new System.Collections.Generic.List<RespWeapon>();
		int i = 0;
		for (int length = resps.Length; i < length; i = checked(i + 1))
		{
			list.Add(f(resps[i]));
		}
		return list.ToArray();
	}

	public static RespPoppet[] ToRespPoppets(RespWeaponPoppet[] resps, __ArrayMapMain_ToRespPoppets_0024callable119_002460_72__ f)
	{
		System.Collections.Generic.List<RespPoppet> list = new System.Collections.Generic.List<RespPoppet>();
		int i = 0;
		for (int length = resps.Length; i < length; i = checked(i + 1))
		{
			list.Add(f(resps[i]));
		}
		return list.ToArray();
	}

	public static int[] RespsToInts(RespSimpleReward[] resps, __ArrayMapMain_RespsToInts_0024callable120_002466_70__ f)
	{
		System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
		int i = 0;
		for (int length = resps.Length; i < length; i = checked(i + 1))
		{
			list.Add(f(resps[i]));
		}
		return list.ToArray();
	}

	public static MWeapons[] RewardsToWeapons(RespSimpleReward[] resps)
	{
		System.Collections.Generic.List<MWeapons> list = new System.Collections.Generic.List<MWeapons>();
		int i = 0;
		for (int length = resps.Length; i < length; i = checked(i + 1))
		{
			list.Add(MWeapons.Get(resps[i].ItemId));
		}
		return list.ToArray();
	}

	public static MPoppets[] RewardsToPoppets(RespSimpleReward[] resps)
	{
		System.Collections.Generic.List<MPoppets> list = new System.Collections.Generic.List<MPoppets>();
		int i = 0;
		for (int length = resps.Length; i < length; i = checked(i + 1))
		{
			list.Add(MPoppets.Get(resps[i].ItemId));
		}
		return list.ToArray();
	}

	public static RespSimpleReward[] FilterRewards(RespSimpleReward[] resps, __ArrayMapMain_FilterRewards_0024callable121_002484_75__ pred)
	{
		System.Collections.Generic.List<RespSimpleReward> list = new System.Collections.Generic.List<RespSimpleReward>();
		int i = 0;
		for (int length = resps.Length; i < length; i = checked(i + 1))
		{
			if (pred(resps[i]))
			{
				list.Add(resps[i]);
			}
		}
		return list.ToArray();
	}

	public static int[] RespsToInts(RespMonster[] resps, __ArrayMapMain_RespsToInts_0024callable122_002491_65__ f)
	{
		System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
		int i = 0;
		for (int length = resps.Length; i < length; i = checked(i + 1))
		{
			list.Add(f(resps[i]));
		}
		return list.ToArray();
	}

	public static NPCControl[] NonNulls(NPCControl[] npcs)
	{
		System.Collections.Generic.List<NPCControl> list = new System.Collections.Generic.List<NPCControl>();
		int i = 0;
		for (int length = npcs.Length; i < length; i = checked(i + 1))
		{
			if (npcs[i] != null)
			{
				list.Add(npcs[i]);
			}
		}
		return list.ToArray();
	}

	public static GameObject[] NpcsToGameObjects(NPCControl[] npcs)
	{
		System.Collections.Generic.List<GameObject> list = new System.Collections.Generic.List<GameObject>();
		int i = 0;
		for (int length = npcs.Length; i < length; i = checked(i + 1))
		{
			if (npcs[i] != null)
			{
				list.Add(npcs[i].gameObject);
			}
		}
		return list.ToArray();
	}

	public static BoxId[] RangeToBoxIds(int n, __ArrayMapMain_RangeToBoxIds_0024callable123_0024109_53__ f, __ArrayMapMain_RangeToBoxIds_0024callable124_0024109_87__ pred)
	{
		System.Collections.Generic.List<BoxId> list = new System.Collections.Generic.List<BoxId>();
		int num = 0;
		if (n < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < n)
		{
			int arg = num;
			num++;
			if (pred(arg))
			{
				list.Add(f(arg));
			}
		}
		return list.ToArray();
	}

	public static RespWeaponPoppet[] UIListItemsToRespWeaponPoppet(Boo.Lang.List<UIListItem> items)
	{
		return UIListItemsToRespWeaponPoppet(items.ToArray());
	}

	public static RespWeaponPoppet[] UIListItemsToRespWeaponPoppet(UIListItem[] items)
	{
		System.Collections.Generic.List<RespWeaponPoppet> list = new System.Collections.Generic.List<RespWeaponPoppet>();
		int i = 0;
		for (int length = items.Length; i < length; i = checked(i + 1))
		{
			list.Add(new RespWeaponPoppet(items[i].GetData<RespPlayerBox>()));
		}
		return list.ToArray();
	}

	public static RespPlayerBox[] UIListItemsToRespPlayerBox(Boo.Lang.List<UIListItem> items)
	{
		return UIListItemsToRespPlayerBox(items.ToArray());
	}

	public static RespPlayerBox[] UIListItemsToRespPlayerBox(UIListItem[] items)
	{
		System.Collections.Generic.List<RespPlayerBox> list = new System.Collections.Generic.List<RespPlayerBox>();
		int i = 0;
		for (int length = items.Length; i < length; i = checked(i + 1))
		{
			list.Add(items[i].GetData<RespPlayerBox>());
		}
		return list.ToArray();
	}

	public static RespWeaponPoppet[] UIListItemDataToRespWeaponPoppet(UIListItem.Data[] itemData)
	{
		System.Collections.Generic.List<RespWeaponPoppet> list = new System.Collections.Generic.List<RespWeaponPoppet>();
		int i = 0;
		for (int length = itemData.Length; i < length; i = checked(i + 1))
		{
			object obj = itemData[i].core;
			if (!(obj is JsonBase))
			{
				obj = RuntimeServices.Coerce(obj, typeof(JsonBase));
			}
			list.Add(new RespWeaponPoppet((JsonBase)obj));
		}
		return list.ToArray();
	}

	public static RespPlayerBox[] NonNulls(RespPlayerBox[] items)
	{
		System.Collections.Generic.List<RespPlayerBox> list = new System.Collections.Generic.List<RespPlayerBox>();
		int i = 0;
		for (int length = items.Length; i < length; i = checked(i + 1))
		{
			if (items[i] != null)
			{
				list.Add(items[i]);
			}
		}
		return list.ToArray();
	}

	public static BoxId[] NonNullIds(RespPlayerBox[] items)
	{
		System.Collections.Generic.List<BoxId> list = new System.Collections.Generic.List<BoxId>();
		int i = 0;
		for (int length = items.Length; i < length; i = checked(i + 1))
		{
			if (items[i] != null)
			{
				list.Add(items[i].Id);
			}
		}
		return list.ToArray();
	}

	public static RespWeapon[] ToRespWeapons(object[] objs)
	{
		System.Collections.Generic.List<RespWeapon> list = new System.Collections.Generic.List<RespWeapon>();
		int i = 0;
		for (int length = objs.Length; i < length; i = checked(i + 1))
		{
			list.Add(objs[i] as RespWeapon);
		}
		return list.ToArray();
	}

	public static RespPoppet[] ToRespPoppets(object[] objs)
	{
		System.Collections.Generic.List<RespPoppet> list = new System.Collections.Generic.List<RespPoppet>();
		int i = 0;
		for (int length = objs.Length; i < length; i = checked(i + 1))
		{
			list.Add(objs[i] as RespPoppet);
		}
		return list.ToArray();
	}
}
