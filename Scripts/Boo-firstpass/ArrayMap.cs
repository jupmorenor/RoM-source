using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class ArrayMap
{
	public static MRaidBattles[] AllMRaidBattles()
	{
		System.Collections.Generic.List<MRaidBattles> list = new System.Collections.Generic.List<MRaidBattles>();
		int i = 0;
		MRaidBattles[] all = MRaidBattles.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			list.Add(all[i]);
		}
		return list.ToArray();
	}

	public static string[] AllMRaidBattlesToStr(__ArrayMap_AllMRaidBattlesToStr_0024callable0_002418_50__ f)
	{
		System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
		int i = 0;
		MRaidBattles[] all = MRaidBattles.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			list.Add(f(all[i]));
		}
		return list.ToArray();
	}

	public static string[] AllEnumNames(Type enumType)
	{
		System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
		IEnumerator enumerator = Enum.GetValues(enumType).GetEnumerator();
		while (enumerator.MoveNext())
		{
			object current = enumerator.Current;
			list.Add(current.ToString());
		}
		return list.ToArray();
	}

	public static MQuests[] AllMQuests()
	{
		System.Collections.Generic.List<MQuests> list = new System.Collections.Generic.List<MQuests>();
		int i = 0;
		MQuests[] all = MQuests.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			list.Add(all[i]);
		}
		return list.ToArray();
	}

	public static MItemGroupChilds[] FilterMItemGroupChilds(__ArrayMap_FilterMItemGroupChilds_0024callable1_002438_55__ pred)
	{
		System.Collections.Generic.List<MItemGroupChilds> list = new System.Collections.Generic.List<MItemGroupChilds>();
		int i = 0;
		MItemGroupChilds[] all = MItemGroupChilds.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (pred(all[i]))
			{
				list.Add(all[i]);
			}
		}
		return list.ToArray();
	}

	public static MAreas[] AllMAreas()
	{
		System.Collections.Generic.List<MAreas> list = new System.Collections.Generic.List<MAreas>();
		int i = 0;
		MAreas[] all = MAreas.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			list.Add(all[i]);
		}
		return list.ToArray();
	}

	public static string[] AllMAreasToStr(__ArrayMap_AllMAreasToStr_0024callable2_002451_44__ f)
	{
		System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
		int i = 0;
		MAreas[] all = MAreas.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			list.Add(f(all[i]));
		}
		return list.ToArray();
	}

	public static MQuests[] FilterMQuests(__ArrayMap_FilterMQuests_0024callable3_002457_46__ pred)
	{
		System.Collections.Generic.List<MQuests> list = new System.Collections.Generic.List<MQuests>();
		int i = 0;
		MQuests[] all = MQuests.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (pred(all[i]))
			{
				list.Add(all[i]);
			}
		}
		return list.ToArray();
	}

	public static string[] AllMQuestsToStr(__ArrayMap_AllMQuestsToStr_0024callable4_002464_45__ f)
	{
		System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
		int i = 0;
		MQuests[] all = MQuests.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			list.Add(f(all[i]));
		}
		return list.ToArray();
	}

	public static MSkillEffectTypes[] AllMSkillEffectTypes()
	{
		System.Collections.Generic.List<MSkillEffectTypes> list = new System.Collections.Generic.List<MSkillEffectTypes>();
		int i = 0;
		MSkillEffectTypes[] all = MSkillEffectTypes.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			list.Add(all[i]);
		}
		return list.ToArray();
	}

	public static string[] AllMSkillEffectTypesToStr(__ArrayMap_AllMSkillEffectTypesToStr_0024callable5_002476_55__ f)
	{
		System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
		int i = 0;
		MSkillEffectTypes[] all = MSkillEffectTypes.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			list.Add(f(all[i]));
		}
		return list.ToArray();
	}

	public static string[] IntToStr(int[] ints, __ArrayMap_IntToStr_0024callable6_002482_53__ f)
	{
		System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
		int i = 0;
		for (int length = ints.Length; i < length; i = checked(i + 1))
		{
			list.Add(f(ints[i]));
		}
		return list.ToArray();
	}

	public static string[] SingleToStr(float[] vals, __ArrayMap_SingleToStr_0024callable7_002488_59__ f)
	{
		System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
		int i = 0;
		for (int length = vals.Length; i < length; i = checked(i + 1))
		{
			list.Add(f(vals[i]));
		}
		return list.ToArray();
	}

	public static int[] Range(int n)
	{
		System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
		int num = 0;
		if (n < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < n)
		{
			int item = num;
			num++;
			list.Add(item);
		}
		return list.ToArray();
	}

	public static int[] Range(int n, __ArrayMap_Range_0024callable8_0024101_45__ f)
	{
		System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
		int num = 0;
		if (n < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < n)
		{
			int arg = num;
			num++;
			list.Add(f(arg));
		}
		return list.ToArray();
	}

	public static string[] RangeToStr(int n, __ArrayMap_IntToStr_0024callable6_002482_53__ f)
	{
		System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
		int num = 0;
		if (n < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < n)
		{
			int arg = num;
			num++;
			list.Add(f(arg));
		}
		return list.ToArray();
	}

	public static string[] AllMMonstersToStr(__ArrayMap_AllMMonstersToStr_0024callable9_0024115_47__ f)
	{
		System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
		int i = 0;
		MMonsters[] all = MMonsters.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			list.Add(f(all[i]));
		}
		return list.ToArray();
	}

	public static string[] AllMPoppetsToStr(__ArrayMap_AllMPoppetsToStr_0024callable10_0024122_46__ f)
	{
		System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
		int i = 0;
		MPoppets[] all = MPoppets.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			list.Add(f(all[i]));
		}
		return list.ToArray();
	}

	public static MMonsters[] FilterAllMMonsters(__ArrayMap_FilterAllMMonsters_0024callable11_0024128_51__ pred)
	{
		System.Collections.Generic.List<MMonsters> list = new System.Collections.Generic.List<MMonsters>();
		int i = 0;
		MMonsters[] all = MMonsters.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (pred(all[i]))
			{
				list.Add(all[i]);
			}
		}
		return list.ToArray();
	}

	public static MShopMessage[] FilterAllMShopMessages(__ArrayMap_FilterAllMShopMessages_0024callable12_0024135_55__ pred)
	{
		System.Collections.Generic.List<MShopMessage> list = new System.Collections.Generic.List<MShopMessage>();
		int i = 0;
		MShopMessage[] all = MShopMessage.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (pred(all[i]))
			{
				list.Add(all[i]);
			}
		}
		return list.ToArray();
	}

	public static MFlags[] FilterMFlags(MFlags[] flags, __ArrayMap_FilterMFlags_0024callable13_0024142_64__ pred)
	{
		System.Collections.Generic.List<MFlags> list = new System.Collections.Generic.List<MFlags>();
		int i = 0;
		for (int length = flags.Length; i < length; i = checked(i + 1))
		{
			if (pred(flags[i]))
			{
				list.Add(flags[i]);
			}
		}
		return list.ToArray();
	}

	public static string[] MRaidWordsToStr(MRaidWords[] words, __ArrayMap_MRaidWordsToStr_0024callable14_0024149_68__ f)
	{
		System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
		int i = 0;
		for (int length = words.Length; i < length; i = checked(i + 1))
		{
			list.Add(f(words[i]));
		}
		return list.ToArray();
	}

	public static Vector3[] GameObjectsToPositions(GameObject[] gs)
	{
		System.Collections.Generic.List<Vector3> list = new System.Collections.Generic.List<Vector3>();
		int i = 0;
		for (int length = gs.Length; i < length; i = checked(i + 1))
		{
			list.Add(gs[i].transform.position);
		}
		return list.ToArray();
	}

	public static MWeapons[] FilterAllMWeapons(__ArrayMap_FilterAllMWeapons_0024callable15_0024161_50__ pred)
	{
		System.Collections.Generic.List<MWeapons> list = new System.Collections.Generic.List<MWeapons>();
		int i = 0;
		MWeapons[] all = MWeapons.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (pred(all[i]))
			{
				list.Add(all[i]);
			}
		}
		return list.ToArray();
	}

	public static MPoppets[] FilterAllMPoppets(__ArrayMap_FilterAllMPoppets_0024callable16_0024168_50__ pred)
	{
		System.Collections.Generic.List<MPoppets> list = new System.Collections.Generic.List<MPoppets>();
		int i = 0;
		MPoppets[] all = MPoppets.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (pred(all[i]))
			{
				list.Add(all[i]);
			}
		}
		return list.ToArray();
	}

	public static int[] MastersToIds(MLoginRewards[] ms)
	{
		System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
		int i = 0;
		for (int length = ms.Length; i < length; i = checked(i + 1))
		{
			list.Add(ms[i].Id);
		}
		return list.ToArray();
	}

	public static string[] ToStrArray(List src)
	{
		System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
		IEnumerator<object> enumerator = src.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				list.Add(current as string);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		return list.ToArray();
	}

	public static int[] ToIntArray(List src)
	{
		System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
		IEnumerator<object> enumerator = src.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				list.Add(RuntimeServices.UnboxInt32(current));
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		return list.ToArray();
	}

	public static Component[] NonNulls(Component[] objs)
	{
		System.Collections.Generic.List<Component> list = new System.Collections.Generic.List<Component>();
		int i = 0;
		for (int length = objs.Length; i < length; i = checked(i + 1))
		{
			if (objs[i] != null)
			{
				list.Add(objs[i]);
			}
		}
		return list.ToArray();
	}

	public static GameObject[] ComponentsToGameObjects(Component[] objs)
	{
		System.Collections.Generic.List<GameObject> list = new System.Collections.Generic.List<GameObject>();
		int i = 0;
		for (int length = objs.Length; i < length; i = checked(i + 1))
		{
			if (objs[i] != null)
			{
				list.Add(objs[i].gameObject);
			}
		}
		return list.ToArray();
	}

	public static List AllMFlagBooList()
	{
		List list = new List();
		int i = 0;
		MFlags[] all = MFlags.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			list.Add(all[i]);
		}
		return list;
	}

	public static List FilterMFlagBooList(__ArrayMap_FilterMFlags_0024callable13_0024142_64__ pred)
	{
		List list = new List();
		int i = 0;
		MFlags[] all = MFlags.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (pred(all[i]))
			{
				list.Add(all[i]);
			}
		}
		return list;
	}

	public static string[] FilterStrings(string[] strs, __ArrayMap_FilterStrings_0024callable17_0024218_64__ pred)
	{
		System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
		int i = 0;
		for (int length = strs.Length; i < length; i = checked(i + 1))
		{
			if (pred(strs[i]))
			{
				list.Add(strs[i]);
			}
		}
		return list.ToArray();
	}

	public static List FilterStrings(List strs, __ArrayMap_FilterStrings_0024callable17_0024218_64__ pred)
	{
		List list = new List();
		IEnumerator<object> enumerator = strs.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string text = (string)obj;
				if (pred(text))
				{
					list.Add(text);
				}
			}
			return list;
		}
		finally
		{
			enumerator.Dispose();
		}
	}
}
