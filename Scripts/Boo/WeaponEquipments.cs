using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;

[Serializable]
public class WeaponEquipments : EquipmentsBase
{
	[NonSerialized]
	public const int SUPPORT_WEAPON_NUM = 3;

	[NonSerialized]
	public const int SUPPORT_POPPET_NUM = 1;

	[NonSerialized]
	private const int RACE_NUM = 2;

	[NonSerialized]
	private static readonly int TOTAL_WEAPON_NUM = 8;

	[NonSerialized]
	private static readonly int TOTAL_POPPET_NUM = 2;

	private RACE_TYPE curRace;

	private RespWeapon mainTenshiWeapon;

	private RespWeapon mainAkumaWeapon;

	private RespWeapon[] subTenshiWeapons;

	private RespWeapon[] subAkumaWeapons;

	private RespPoppet[] subTenshiPoppets;

	private RespPoppet[] subAkumaPoppets;

	private RespWeapon[] allTenshiWeapons;

	private RespWeapon[] allAkumaWeapons;

	public bool IsValid
	{
		get
		{
			__LotterySequence_startUpdateFunc_0024callable42_002410_31__ _LotterySequence_startUpdateFunc_0024callable42_002410_31__ = () => mainTenshiWeapon != null && mainAkumaWeapon != null && !(subTenshiWeapons == null) && !(subAkumaWeapons == null) && !(subTenshiPoppets == null) && !(subAkumaPoppets == null);
			return _LotterySequence_startUpdateFunc_0024callable42_002410_31__() ? true : false;
		}
	}

	public bool IsStrictlyValid
	{
		get
		{
			int result;
			checked
			{
				if (!IsValid)
				{
					result = 0;
				}
				else
				{
					UserData current = UserData.Current;
					if (!current.haveWeapon(mainTenshiWeapon.Id))
					{
						result = 0;
					}
					else if (!current.haveWeapon(mainAkumaWeapon.Id))
					{
						result = 0;
					}
					else
					{
						int num = 0;
						RespWeapon[] array = (RespWeapon[])RuntimeServices.AddArrays(typeof(RespWeapon), subTenshiWeapons, subAkumaWeapons);
						int length = array.Length;
						while (true)
						{
							if (num < length)
							{
								if (!current.haveWeapon(array[num].Id))
								{
									result = 0;
									break;
								}
								num++;
								continue;
							}
							int num2 = 0;
							RespPoppet[] array2 = (RespPoppet[])RuntimeServices.AddArrays(typeof(RespPoppet), subTenshiPoppets, subAkumaPoppets);
							int length2 = array2.Length;
							while (true)
							{
								if (num2 < length2)
								{
									if (!current.havePoppet(array2[num2].Id))
									{
										result = 0;
										break;
									}
									num2++;
									continue;
								}
								result = 1;
								break;
							}
							break;
						}
					}
				}
			}
			return (byte)result != 0;
		}
	}

	public RespWeapon MainWeapon
	{
		get
		{
			return getMainWeapon(curRace);
		}
		set
		{
			if (curRace == RACE_TYPE.Tensi)
			{
				MainTenshiWeapon = value;
			}
			else
			{
				MainAkumaWeapon = value;
			}
		}
	}

	public RespWeapon AltWeapon => getMainWeapon(AlternativeRaceType(curRace));

	public RespWeapon[] MainWeaponList => new RespWeapon[2] { MainTenshiWeapon, MainAkumaWeapon };

	public RespWeapon[] SubWeapons => getSubWeapons(curRace);

	public RespWeapon[] AllWeapons => getAllWeapons(curRace);

	public MWeaponSkills MainWeaponSkill => getMainWeaponSkill(curRace);

	public MWeaponSkills AltWeaponSkill => getMainWeaponSkill(AlternativeRaceType(curRace));

	public int MainWeaponSkillLevel => getMainWeaponSkillLevel(curRace);

	public RespWeapon MainTenshiWeapon
	{
		get
		{
			return mainTenshiWeapon;
		}
		set
		{
			if (value == null)
			{
				throw new AssertionFailedException("value != null");
			}
			mainTenshiWeapon = value;
			initDerivedAttributes();
		}
	}

	public RespWeapon MainAkumaWeapon
	{
		get
		{
			return mainAkumaWeapon;
		}
		set
		{
			if (value == null)
			{
				throw new AssertionFailedException("value != null");
			}
			mainAkumaWeapon = value;
			initDerivedAttributes();
		}
	}

	public RespWeapon[] SubTenshiWeapons
	{
		get
		{
			return subTenshiWeapons;
		}
		set
		{
			if (value == null)
			{
				throw new AssertionFailedException("value != null");
			}
			subTenshiWeapons = new RespWeapon[value.Length];
			Array.Copy(value, subTenshiWeapons, value.Length);
			initDerivedAttributes();
		}
	}

	public RespWeapon[] SubAkumaWeapons
	{
		get
		{
			return subAkumaWeapons;
		}
		set
		{
			if (value == null)
			{
				throw new AssertionFailedException("value != null");
			}
			subAkumaWeapons = new RespWeapon[value.Length];
			Array.Copy(value, subAkumaWeapons, value.Length);
			initDerivedAttributes();
		}
	}

	public RespPoppet[] SubTenshiPoppets
	{
		get
		{
			return subTenshiPoppets;
		}
		set
		{
			if (value == null)
			{
				throw new AssertionFailedException("value != null");
			}
			subTenshiPoppets = value;
			initDerivedAttributes();
		}
	}

	public RespPoppet[] SubAkumaPoppets
	{
		get
		{
			return subAkumaPoppets;
		}
		set
		{
			if (value == null)
			{
				throw new AssertionFailedException("value != null");
			}
			subAkumaPoppets = value;
			initDerivedAttributes();
		}
	}

	public RACE_TYPE Race
	{
		get
		{
			return curRace;
		}
		set
		{
			curRace = value;
		}
	}

	public WeaponEquipments()
	{
		curRace = RACE_TYPE.Tensi;
		subTenshiWeapons = new RespWeapon[0];
		subAkumaWeapons = new RespWeapon[0];
		subTenshiPoppets = new RespPoppet[0];
		subAkumaPoppets = new RespPoppet[0];
		allTenshiWeapons = new RespWeapon[0];
		allAkumaWeapons = new RespWeapon[0];
	}

	public void setMainWeapon(RACE_TYPE race, RespWeapon wpn)
	{
		if (wpn == null)
		{
			throw new AssertionFailedException("wpn != null");
		}
		if (race == RACE_TYPE.Tensi)
		{
			MainTenshiWeapon = wpn;
		}
		else
		{
			MainAkumaWeapon = wpn;
		}
	}

	public void setSubWeapons(RACE_TYPE race, RespWeapon[] wpns)
	{
		if (wpns == null)
		{
			throw new AssertionFailedException("wpns != null");
		}
		if (race == RACE_TYPE.Tensi)
		{
			SubTenshiWeapons = wpns;
		}
		else
		{
			SubAkumaWeapons = wpns;
		}
	}

	public RespWeapon getMainWeapon(RACE_TYPE race)
	{
		return (race != 0) ? MainAkumaWeapon : MainTenshiWeapon;
	}

	public RespWeapon[] getSubWeapons(RACE_TYPE race)
	{
		return (race != 0) ? SubAkumaWeapons : SubTenshiWeapons;
	}

	public RespWeapon[] getAllWeapons(RACE_TYPE race)
	{
		return (race != 0) ? allAkumaWeapons : allTenshiWeapons;
	}

	public RespPoppet[] getSubPoppets(RACE_TYPE race)
	{
		return (race != 0) ? subAkumaPoppets : subTenshiPoppets;
	}

	public void setSubPoppets(RACE_TYPE race, RespPoppet[] ppts)
	{
		if (ppts == null)
		{
			throw new AssertionFailedException("ppts != null");
		}
		if (race == RACE_TYPE.Tensi)
		{
			SubTenshiPoppets = ppts;
		}
		else
		{
			SubAkumaPoppets = ppts;
		}
	}

	public MWeaponSkills getMainWeaponSkill(RACE_TYPE race)
	{
		return (race != 0) ? MainAkumaWeapon.DemonSkill : MainTenshiWeapon.AngelSkill;
	}

	public int getMainWeaponSkillLevel(RACE_TYPE race)
	{
		return (race != 0) ? MainAkumaWeapon.DemonSkillLevel : MainTenshiWeapon.AngelSkillLevel;
	}

	public static WeaponEquipments FromWeaponArray(RespWeapon[] wpns)
	{
		return null;
	}

	public static WeaponEquipments Default()
	{
		WeaponEquipments weaponEquipments = new WeaponEquipments();
		weaponEquipments.initAsDefault();
		return weaponEquipments;
	}

	private void initAsDefault()
	{
		mainTenshiWeapon = new RespWeapon(1);
		subTenshiWeapons = (RespWeapon[])(new RespWeapon[1]
		{
			new RespWeapon(1)
		} * 3);
		mainAkumaWeapon = new RespWeapon(1);
		subAkumaWeapons = (RespWeapon[])(new RespWeapon[1]
		{
			new RespWeapon(1)
		} * 3);
		subTenshiPoppets = (RespPoppet[])(new RespPoppet[1]
		{
			new RespPoppet(1)
		} * 1);
		subAkumaPoppets = (RespPoppet[])(new RespPoppet[1]
		{
			new RespPoppet(1)
		} * 1);
		initDerivedAttributes();
	}

	public static WeaponEquipments FromUserData()
	{
		WeaponEquipments weaponEquipments = new WeaponEquipments();
		weaponEquipments.fromUserData();
		return weaponEquipments;
	}

	public static WeaponEquipments FromOldWeaponArray(RespWeapon[] wpns)
	{
		WeaponEquipments weaponEquipments = new WeaponEquipments();
		weaponEquipments.fromOldWeaponArray(wpns);
		return weaponEquipments;
	}

	public static WeaponEquipments FromDeckIndex(int aDeckIndex)
	{
		WeaponEquipments result = null;
		UserData current = UserData.Current;
		if (current.IsValidDeck2 && 0 <= aDeckIndex)
		{
			RespDeck2[] decks = current.userDeckData2.Decks2;
			if (aDeckIndex < decks.Length)
			{
				result = FromRespDeck2(decks[RuntimeServices.NormalizeArrayIndex(decks, aDeckIndex)]);
			}
		}
		return result;
	}

	public static WeaponEquipments FromRespDeck2(RespDeck2 aDeck2)
	{
		WeaponEquipments weaponEquipments = new WeaponEquipments();
		weaponEquipments.fromRespDeck2(aDeck2);
		return weaponEquipments;
	}

	private void initDerivedAttributes()
	{
		allTenshiWeapons = (RespWeapon[])RuntimeServices.AddArrays(typeof(RespWeapon), new RespWeapon[1] { mainTenshiWeapon }, subTenshiWeapons);
		allAkumaWeapons = (RespWeapon[])RuntimeServices.AddArrays(typeof(RespWeapon), new RespWeapon[1] { mainAkumaWeapon }, subAkumaWeapons);
	}

	private void fromWeaponArray(RespWeapon[] wpns, RespPoppet[] ppts)
	{
		checked
		{
			if (!(wpns == null) && !(ppts == null) && wpns.Length > 0)
			{
				int num = 0;
				int num2 = 3;
				int num3 = num + 1 + num2;
				mainTenshiWeapon = wpns[RuntimeServices.NormalizeArrayIndex(wpns, num)];
				subTenshiWeapons = (RespWeapon[])RuntimeServices.GetRange2(wpns, num + 1, num + 1 + num2);
				mainAkumaWeapon = wpns[RuntimeServices.NormalizeArrayIndex(wpns, num3)];
				subAkumaWeapons = (RespWeapon[])RuntimeServices.GetRange2(wpns, num3 + 1, num3 + 1 + num2);
				subTenshiPoppets = new RespPoppet[1] { (ppts.Length <= 0) ? null : ppts[0] };
				subAkumaPoppets = new RespPoppet[1] { (ppts.Length <= 1) ? null : ppts[1] };
				initDerivedAttributes();
			}
		}
	}

	public RespWeapon[] allWeaponsArray()
	{
		return (RespWeapon[])RuntimeServices.AddArrays(typeof(RespWeapon), allTenshiWeapons, allAkumaWeapons);
	}

	public RespPoppet[] allPoppetsArray()
	{
		return (RespPoppet[])RuntimeServices.AddArrays(typeof(RespPoppet), subTenshiPoppets, subAkumaPoppets);
	}

	private void fromUserData()
	{
		UserData current = UserData.Current;
		if (current != null)
		{
			if (current.IsValidDeck2)
			{
				fromRespDeck2(current.CurrentDeck2);
			}
			else if (current.IsValidOldCurrentWeapons)
			{
				mainTenshiWeapon = current.MainWeapon;
				subTenshiWeapons = (RespWeapon[])(new RespWeapon[1] { current.SubWeapon2 } * 3);
				mainAkumaWeapon = current.SubWeapon1;
				subAkumaWeapons = (RespWeapon[])(new RespWeapon[1] { current.SubWeapon2 } * 3);
				subTenshiPoppets = (RespPoppet[])(new RespPoppet[1] { current.CurrentPoppet } * 1);
				subAkumaPoppets = (RespPoppet[])(new RespPoppet[1] { current.CurrentPoppet } * 1);
				initDerivedAttributes();
			}
			else
			{
				initAsDefault();
			}
		}
	}

	private void fromRespDeck2(RespDeck2 aDeck2)
	{
		mainTenshiWeapon = aDeck2.AngelWeapon;
		if (mainTenshiWeapon == null)
		{
		}
		subTenshiWeapons = aDeck2.getSupportWeapons(RACE_TYPE.Tensi);
		if (subTenshiWeapons == null)
		{
		}
		mainAkumaWeapon = aDeck2.DevilWeapon;
		if (mainAkumaWeapon == null)
		{
		}
		subAkumaWeapons = aDeck2.getSupportWeapons(RACE_TYPE.Akuma);
		if (subAkumaWeapons == null)
		{
		}
		subTenshiPoppets = aDeck2.getSupportPoppets(RACE_TYPE.Tensi);
		if (subTenshiPoppets == null)
		{
		}
		subAkumaPoppets = aDeck2.getSupportPoppets(RACE_TYPE.Akuma);
		if (subAkumaPoppets == null)
		{
		}
		initDerivedAttributes();
	}

	private void fromOldWeaponArray(RespWeapon[] wpns)
	{
		if (!(wpns == null) && wpns.Length >= 3)
		{
			mainTenshiWeapon = wpns[0];
			subTenshiWeapons = (RespWeapon[])(new RespWeapon[1] { wpns[2] } * 3);
			mainAkumaWeapon = wpns[1];
			subAkumaWeapons = (RespWeapon[])(new RespWeapon[1] { wpns[2] } * 3);
			subTenshiPoppets = (RespPoppet[])(new RespPoppet[1]
			{
				new RespPoppet(1)
			} * 1);
			subAkumaPoppets = (RespPoppet[])(new RespPoppet[1]
			{
				new RespPoppet(1)
			} * 1);
			initDerivedAttributes();
		}
	}

	public WeaponEquipments Clone()
	{
		WeaponEquipments dstWep = new WeaponEquipments();
		return Copy(ref dstWep);
	}

	public WeaponEquipments Copy(ref WeaponEquipments dstWep)
	{
		dstWep.MainTenshiWeapon = MainTenshiWeapon;
		dstWep.SubTenshiWeapons = SubTenshiWeapons;
		dstWep.MainAkumaWeapon = MainAkumaWeapon;
		dstWep.SubAkumaWeapons = SubAkumaWeapons;
		dstWep.SubTenshiPoppets = SubTenshiPoppets;
		dstWep.SubAkumaPoppets = SubAkumaPoppets;
		dstWep.initDerivedAttributes();
		return dstWep;
	}

	public string serialize()
	{
		Boo.Lang.List<string> list = new Boo.Lang.List<string>();
		RespWeapon[] array = (RespWeapon[])RuntimeServices.AddArrays(typeof(RespWeapon), (RespWeapon[])RuntimeServices.AddArrays(typeof(RespWeapon), (RespWeapon[])RuntimeServices.AddArrays(typeof(RespWeapon), new RespWeapon[1] { mainTenshiWeapon }, new RespWeapon[1] { mainAkumaWeapon }), subTenshiWeapons), subAkumaWeapons);
		if (array.Length != TOTAL_WEAPON_NUM)
		{
			throw new AssertionFailedException("len(a) == TOTAL_WEAPON_NUM");
		}
		int i = 0;
		RespWeapon[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				list.Add(array2[i].toNguiJson());
			}
			RespPoppet[] array3 = (RespPoppet[])RuntimeServices.AddArrays(typeof(RespPoppet), subTenshiPoppets, subAkumaPoppets);
			if (array3.Length != TOTAL_POPPET_NUM)
			{
				throw new AssertionFailedException("len(b) == TOTAL_POPPET_NUM");
			}
			int j = 0;
			RespPoppet[] array4 = array3;
			for (int length2 = array4.Length; j < length2; j++)
			{
				list.Add(array4[j].toNguiJson());
			}
			return PhotonClientMain.toNguiJsonArrayString((string[])Builtins.array(typeof(string), list));
		}
	}

	public static WeaponEquipments Deserialize(string json)
	{
		WeaponEquipments weaponEquipments = new WeaponEquipments();
		weaponEquipments.deserialize(json);
		return weaponEquipments;
	}

	private WeaponEquipments deserialize(string json)
	{
		string[] array = PhotonClientMain.fromNguiJsonArrayString(json);
		checked
		{
			object result;
			if (array.Length != TOTAL_WEAPON_NUM + TOTAL_POPPET_NUM)
			{
				WeaponEquipments weaponEquipments = new WeaponEquipments();
				weaponEquipments.fromUserData();
				result = weaponEquipments;
			}
			else
			{
				Boo.Lang.List<RespWeapon> list = new Boo.Lang.List<RespWeapon>();
				int num = 0;
				int tOTAL_WEAPON_NUM = TOTAL_WEAPON_NUM;
				if (tOTAL_WEAPON_NUM < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num < tOTAL_WEAPON_NUM)
				{
					int index = num;
					num = unchecked(num + 1);
					RespWeapon respWeapon = RespWeapon.fromNguiJson(array[RuntimeServices.NormalizeArrayIndex(array, index)]);
					if (respWeapon != null)
					{
						list.Add(respWeapon);
					}
				}
				if (((ICollection)list).Count != TOTAL_WEAPON_NUM)
				{
					throw new AssertionFailedException("len(wlist) == TOTAL_WEAPON_NUM");
				}
				RespWeapon[] array2 = (RespWeapon[])Builtins.array(typeof(RespWeapon), list);
				Boo.Lang.List<RespPoppet> list2 = new Boo.Lang.List<RespPoppet>();
				int num2 = TOTAL_WEAPON_NUM;
				int num3 = TOTAL_WEAPON_NUM + TOTAL_POPPET_NUM;
				int num4 = 1;
				if (num3 < num2)
				{
					num4 = -1;
				}
				while (num2 != num3)
				{
					int index2 = num2;
					num2 = unchecked(num2 + num4);
					RespPoppet respPoppet = RespPoppet.fromNguiJson(array[RuntimeServices.NormalizeArrayIndex(array, index2)]);
					if (respPoppet != null)
					{
						list2.Add(respPoppet);
					}
				}
				if (((ICollection)list2).Count != TOTAL_POPPET_NUM)
				{
					throw new AssertionFailedException("len(plist) == TOTAL_POPPET_NUM");
				}
				RespPoppet[] source = (RespPoppet[])Builtins.array(typeof(RespPoppet), list2);
				int num5 = 0;
				mainTenshiWeapon = array2[RuntimeServices.NormalizeArrayIndex(array2, num5++)];
				mainAkumaWeapon = array2[RuntimeServices.NormalizeArrayIndex(array2, num5++)];
				subTenshiWeapons = (RespWeapon[])RuntimeServices.GetRange2(array2, num5, num5 + 3);
				num5 += 3;
				subAkumaWeapons = (RespWeapon[])RuntimeServices.GetRange2(array2, num5, num5 + 3);
				subTenshiPoppets = (RespPoppet[])RuntimeServices.GetRange2(source, 0, 1);
				subAkumaPoppets = (RespPoppet[])RuntimeServices.GetRange2(source, 1, 2);
				initDerivedAttributes();
				result = null;
			}
			return (WeaponEquipments)result;
		}
	}

	public bool isSameAs(WeaponEquipments weq)
	{
		return weq != null && RuntimeServices.EqualityOperator(mainAkumaWeapon.Id, weq.mainAkumaWeapon.Id) && (RuntimeServices.EqualityOperator(mainTenshiWeapon.Id, weq.mainTenshiWeapon.Id) ? true : false);
	}

	public float totalPlayerHP()
	{
		float num = weaponHP(RACE_TYPE.Tensi);
		float num2 = weaponHP(RACE_TYPE.Akuma);
		float num3 = 0f;
		num3 += supportPoppetHP(RACE_TYPE.Tensi);
		num3 += supportPoppetHP(RACE_TYPE.Akuma);
		return num + num2 + num3;
	}

	public float totalPlayerAttack()
	{
		float num = weaponAtk(RACE_TYPE.Tensi);
		float num2 = weaponAtk(RACE_TYPE.Akuma);
		float num3 = 0f;
		num3 += supportPoppetAttack(RACE_TYPE.Tensi);
		num3 += supportPoppetAttack(RACE_TYPE.Akuma);
		return num + num2 + num3;
	}

	public float weaponHP(RACE_TYPE race)
	{
		RespWeapon mainWeapon = getMainWeapon(race);
		RespWeapon[] subWeapons = getSubWeapons(race);
		return (mainWeapon == null || subWeapons == null) ? 0f : DamageCalc.TotalWeaponHP(mainWeapon, subWeapons);
	}

	public float weaponAtk(RACE_TYPE race)
	{
		RespWeapon mainWeapon = getMainWeapon(race);
		RespWeapon[] subWeapons = getSubWeapons(race);
		return (mainWeapon == null || subWeapons == null) ? 0f : DamageCalc.TotalWeaponAttack(mainWeapon, subWeapons);
	}

	public float supportPoppetHP(RACE_TYPE race)
	{
		RespWeapon mainWeapon = getMainWeapon(race);
		RespPoppet[] subPoppets = getSubPoppets(race);
		return SupportPoppetHP(mainWeapon, subPoppets);
	}

	public float supportPoppetAttack(RACE_TYPE race)
	{
		RespWeapon mainWeapon = getMainWeapon(race);
		RespPoppet[] subPoppets = getSubPoppets(race);
		return SupportPoppetAttack(mainWeapon, subPoppets);
	}

	public static float SupportPoppetHP(RespWeapon mainWeapon, RespPoppet[] poppets)
	{
		float num = 0f;
		if (poppets != null)
		{
			int i = 0;
			for (int length = poppets.Length; i < length; i = checked(i + 1))
			{
				num += DamageCalc.PoppetHpRevice(poppets[i], mainWeapon);
			}
		}
		return num;
	}

	public static float SupportPoppetAttack(RespWeapon mainWeapon, RespPoppet[] poppets)
	{
		float num = 0f;
		if (poppets != null)
		{
			int i = 0;
			for (int length = poppets.Length; i < length; i = checked(i + 1))
			{
				num += DamageCalc.PoppetAttackRevice(poppets[i], mainWeapon);
			}
		}
		return num;
	}

	public static WeaponEquipments GetBestAtkWeapons()
	{
		WeaponEquipments weaponEquipments = new WeaponEquipments();
		weaponEquipments.fromUserData();
		PoppetEquipments petEq = new PoppetEquipments();
		PoppetEquipments.FromUserData();
		return GetBestAtkWeapons(weaponEquipments, petEq);
	}

	public static WeaponEquipments GetBestAtkWeapons(WeaponEquipments wepEq, PoppetEquipments petEq)
	{
		return GetBestAtkHpWeapons(wepEq, petEq, atkFlag: true);
	}

	public static WeaponEquipments GetBestHpWeapons()
	{
		WeaponEquipments weaponEquipments = new WeaponEquipments();
		weaponEquipments.fromUserData();
		PoppetEquipments petEq = new PoppetEquipments();
		PoppetEquipments.FromUserData();
		return GetBestHpWeapons(weaponEquipments, petEq);
	}

	public static WeaponEquipments GetBestHpWeapons(WeaponEquipments wepEq, PoppetEquipments petEq)
	{
		return GetBestAtkHpWeapons(wepEq, petEq, atkFlag: false);
	}

	public static WeaponEquipments GetBestAtkHpWeapons(WeaponEquipments wepEq, PoppetEquipments petEq, bool atkFlag)
	{
		if (wepEq == null)
		{
			throw new AssertionFailedException("wepEq");
		}
		if (petEq == null)
		{
			throw new AssertionFailedException("petEq");
		}
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		int[] bestWeapons = GetBestWeapons(wepEq.mainTenshiWeapon, wepEq.mainAkumaWeapon, atkFlag);
		wepEq.subTenshiWeapons = new RespWeapon[3]
		{
			current.boxWeapon(new BoxId(bestWeapons[0])),
			current.boxWeapon(new BoxId(bestWeapons[1])),
			current.boxWeapon(new BoxId(bestWeapons[2]))
		};
		wepEq.subAkumaWeapons = new RespWeapon[3]
		{
			current.boxWeapon(new BoxId(bestWeapons[3])),
			current.boxWeapon(new BoxId(bestWeapons[4])),
			current.boxWeapon(new BoxId(bestWeapons[5]))
		};
		bestWeapons = GetBestPoppets(wepEq.mainTenshiWeapon, wepEq.mainAkumaWeapon, petEq.MainPoppet, atkFlag);
		wepEq.subTenshiPoppets = new RespPoppet[1] { current.boxPoppet(new BoxId(bestWeapons[0])) };
		wepEq.subAkumaPoppets = new RespPoppet[1] { current.boxPoppet(new BoxId(bestWeapons[1])) };
		return wepEq;
	}

	public static int[] GetBestWeapons(RespWeapon mainTenshiWeapon, RespWeapon mainAkumaWeapon, bool atkFlag)
	{
		Boo.Lang.List<KeyValuePair<int, float>> list = new Boo.Lang.List<KeyValuePair<int, float>>();
		Boo.Lang.List<KeyValuePair<int, float>> list2 = new Boo.Lang.List<KeyValuePair<int, float>>();
		if (atkFlag)
		{
		}
		int i = 0;
		RespWeapon[] boxWeapons = UserData.Current.BoxWeapons;
		Boo.Lang.List<KeyValuePair<int, float>> list3;
		Boo.Lang.List<KeyValuePair<int, float>> list4;
		int num;
		checked
		{
			float value = default(float);
			for (int length = boxWeapons.Length; i < length; i++)
			{
				if (!RuntimeServices.EqualityOperator(boxWeapons[i].Id, mainTenshiWeapon.Id) && !RuntimeServices.EqualityOperator(boxWeapons[i].Id, mainAkumaWeapon.Id))
				{
					if (atkFlag)
					{
						value = DamageCalc.SupportWeaponAttackRevise(boxWeapons[i], mainTenshiWeapon);
					}
					if (!atkFlag)
					{
						value = DamageCalc.SupportWeaponHpRevise(boxWeapons[i], mainTenshiWeapon);
					}
					list.Add(new KeyValuePair<int, float>((int)boxWeapons[i].Id.Value, value));
					if (atkFlag)
					{
						value = DamageCalc.SupportWeaponAttackRevise(boxWeapons[i], mainAkumaWeapon);
					}
					if (!atkFlag)
					{
						value = DamageCalc.SupportWeaponHpRevise(boxWeapons[i], mainAkumaWeapon);
					}
					list2.Add(new KeyValuePair<int, float>((int)boxWeapons[i].Id.Value, value));
				}
			}
			list.Sort(_0024adaptor_0024__Equipments_0024callable331_0024606_26___0024Comparison_0024131.Adapt((KeyValuePair<int, float> o1, KeyValuePair<int, float> o2) => o2.Value - o1.Value));
			list2.Sort(_0024adaptor_0024__Equipments_0024callable331_0024606_26___0024Comparison_0024131.Adapt((KeyValuePair<int, float> o1, KeyValuePair<int, float> o2) => o2.Value - o1.Value));
			list3 = new Boo.Lang.List<KeyValuePair<int, float>>();
			list4 = new Boo.Lang.List<KeyValuePair<int, float>>();
			num = 0;
		}
		while (num < 6)
		{
			int num2 = num;
			num++;
			if (num2 < list.Count)
			{
				list3.Add(list[num2]);
			}
			else
			{
				list3.Add(new KeyValuePair<int, float>(1, 0f));
			}
			if (num2 < list2.Count)
			{
				list4.Add(list2[num2]);
			}
			else
			{
				list4.Add(new KeyValuePair<int, float>(1, 0f));
			}
		}
		Boo.Lang.List<KeyValuePair<int[], float>> list5 = new Boo.Lang.List<KeyValuePair<int[], float>>();
		int num3 = 0;
		while (num3 < 6)
		{
			int num4 = num3;
			num3++;
			int key = list3[num4].Key;
			int[] lhs = new int[1] { key };
			float value2 = list3[num4].Value;
			int num5 = checked(num4 + 1);
			int num6 = 1;
			if (6 < num5)
			{
				num6 = -1;
			}
			while (num5 != 6)
			{
				int num7 = num5;
				num5 += num6;
				int key2 = list3[num7].Key;
				int[] lhs2 = (int[])RuntimeServices.AddArrays(typeof(int), lhs, new int[1] { key2 });
				float num8 = value2 + list3[num7].Value;
				int num9 = checked(num7 + 1);
				int num10 = 1;
				if (6 < num9)
				{
					num10 = -1;
				}
				while (num9 != 6)
				{
					int index = num9;
					num9 += num10;
					int key3 = list3[index].Key;
					int[] array = (int[])RuntimeServices.AddArrays(typeof(int), lhs2, new int[1] { key3 });
					float num11 = num8 + list3[index].Value;
					int num12 = 0;
					int num13 = 0;
					while (num13 < 6)
					{
						int index2 = num13;
						num13++;
						int key4 = list4[index2].Key;
						if (key4 != key && key4 != key2 && key4 != key3)
						{
							array = (int[])RuntimeServices.AddArrays(typeof(int), array, new int[1] { key4 });
							num11 += list4[index2].Value;
							num12 = checked(num12 + 1);
							if (num12 == 3)
							{
								list5.Add(new KeyValuePair<int[], float>(array, num11));
								break;
							}
						}
					}
				}
			}
		}
		list5.Sort(_0024adaptor_0024__Equipments_0024callable332_0024650_22___0024Comparison_0024132.Adapt((KeyValuePair<int[], float> o1, KeyValuePair<int[], float> o2) => o2.Value - o1.Value));
		int[] array2 = new int[0];
		int[] key5 = list5[0].Key;
		UserData current = UserData.Current;
		int num14 = 0;
		while (num14 < 6)
		{
			int num15 = num14;
			num14++;
			if (num15 < 3)
			{
				Type typeFromHandle = typeof(int);
				int[] lhs3 = array2;
				int[] array3 = new int[1];
				array3[0] = key5[RuntimeServices.NormalizeArrayIndex(key5, num15)];
				array2 = (int[])RuntimeServices.AddArrays(typeFromHandle, lhs3, array3);
			}
			else
			{
				Type typeFromHandle2 = typeof(int);
				int[] lhs4 = array2;
				int[] array4 = new int[1];
				array4[0] = key5[RuntimeServices.NormalizeArrayIndex(key5, num15)];
				array2 = (int[])RuntimeServices.AddArrays(typeFromHandle2, lhs4, array4);
			}
		}
		return array2;
	}

	public static int[] GetBestPoppets(RespWeapon mainTenshiWeapon, RespWeapon mainAkumaWeapon, RespPoppet mainPoppet, bool atkFlag)
	{
		Boo.Lang.List<KeyValuePair<int, float>> list = new Boo.Lang.List<KeyValuePair<int, float>>();
		Boo.Lang.List<KeyValuePair<int, float>> list2 = new Boo.Lang.List<KeyValuePair<int, float>>();
		if (atkFlag)
		{
		}
		int i = 0;
		RespPoppet[] boxPoppets = UserData.Current.BoxPoppets;
		Boo.Lang.List<KeyValuePair<int, float>> list3;
		Boo.Lang.List<KeyValuePair<int, float>> list4;
		int num;
		checked
		{
			float value = default(float);
			for (int length = boxPoppets.Length; i < length; i++)
			{
				if (!RuntimeServices.EqualityOperator(boxPoppets[i].Id, mainPoppet.Id))
				{
					if (atkFlag)
					{
						value = DamageCalc.TotalPoppetPlayerAttackRevise(new RespPoppet[1] { boxPoppets[i] }, mainTenshiWeapon);
					}
					if (!atkFlag)
					{
						value = DamageCalc.TotalPoppetPlayerHpRevise(new RespPoppet[1] { boxPoppets[i] }, mainTenshiWeapon);
					}
					list.Add(new KeyValuePair<int, float>((int)boxPoppets[i].Id.Value, value));
					if (atkFlag)
					{
						value = DamageCalc.TotalPoppetPlayerAttackRevise(new RespPoppet[1] { boxPoppets[i] }, mainAkumaWeapon);
					}
					if (!atkFlag)
					{
						value = DamageCalc.TotalPoppetPlayerHpRevise(new RespPoppet[1] { boxPoppets[i] }, mainAkumaWeapon);
					}
					list2.Add(new KeyValuePair<int, float>((int)boxPoppets[i].Id.Value, value));
				}
			}
			list.Sort(_0024adaptor_0024__Equipments_0024callable331_0024606_26___0024Comparison_0024131.Adapt((KeyValuePair<int, float> o1, KeyValuePair<int, float> o2) => o2.Value - o1.Value));
			list2.Sort(_0024adaptor_0024__Equipments_0024callable331_0024606_26___0024Comparison_0024131.Adapt((KeyValuePair<int, float> o1, KeyValuePair<int, float> o2) => o2.Value - o1.Value));
			list3 = new Boo.Lang.List<KeyValuePair<int, float>>();
			list4 = new Boo.Lang.List<KeyValuePair<int, float>>();
			num = 0;
		}
		while (num < 2)
		{
			int num2 = num;
			num++;
			if (num2 < list.Count)
			{
				list3.Add(list[num2]);
			}
			else
			{
				list3.Add(new KeyValuePair<int, float>(1, 0f));
			}
			if (num2 < list2.Count)
			{
				list4.Add(list2[num2]);
			}
			else
			{
				list4.Add(new KeyValuePair<int, float>(1, 0f));
			}
		}
		Boo.Lang.List<KeyValuePair<int[], float>> list5 = new Boo.Lang.List<KeyValuePair<int[], float>>();
		int num3 = 0;
		while (num3 < 2)
		{
			int index = num3;
			num3++;
			int key = list3[index].Key;
			int[] lhs = new int[1] { key };
			float value2 = list3[index].Value;
			int num4 = 0;
			while (num4 < 2)
			{
				int index2 = num4;
				num4++;
				int key2 = list4[index2].Key;
				if (key2 != key)
				{
					int[] key3 = (int[])RuntimeServices.AddArrays(typeof(int), lhs, new int[1] { key2 });
					float value3 = value2 + list4[index2].Value;
					list5.Add(new KeyValuePair<int[], float>(key3, value3));
					break;
				}
			}
		}
		list5.Sort(_0024adaptor_0024__Equipments_0024callable332_0024650_22___0024Comparison_0024132.Adapt((KeyValuePair<int[], float> o1, KeyValuePair<int[], float> o2) => o2.Value - o1.Value));
		int[] array = new int[0];
		int[] key4 = list5[0].Key;
		UserData current = UserData.Current;
		int num5 = 0;
		while (num5 < 2)
		{
			int num6 = num5;
			num5++;
			if (num6 < 2)
			{
				Type typeFromHandle = typeof(int);
				int[] lhs2 = array;
				int[] array2 = new int[1];
				array2[0] = key4[RuntimeServices.NormalizeArrayIndex(key4, num6)];
				array = (int[])RuntimeServices.AddArrays(typeFromHandle, lhs2, array2);
			}
			else
			{
				Type typeFromHandle2 = typeof(int);
				int[] lhs3 = array;
				int[] array3 = new int[1];
				array3[0] = key4[RuntimeServices.NormalizeArrayIndex(key4, num6)];
				array = (int[])RuntimeServices.AddArrays(typeFromHandle2, lhs3, array3);
			}
		}
		return array;
	}

	private static RACE_TYPE AlternativeRaceType(RACE_TYPE r)
	{
		return (r == RACE_TYPE.Tensi) ? RACE_TYPE.Akuma : RACE_TYPE.Tensi;
	}

	public override string ToString()
	{
		string text = new StringBuilder("WeaponEquipments: tenshi main = ").Append(mainTenshiWeapon).Append(" akuma main = ").Append(mainAkumaWeapon)
			.ToString();
		int i = 0;
		RespWeapon[] array = SubTenshiWeapons;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				text += new StringBuilder("tenshi sup = ").Append(array[i]).ToString();
			}
			int j = 0;
			RespWeapon[] array2 = SubAkumaWeapons;
			for (int length2 = array2.Length; j < length2; j++)
			{
				text += new StringBuilder("akuma sup = ").Append(array2[j]).ToString();
			}
			int k = 0;
			RespPoppet[] array3 = SubTenshiPoppets;
			for (int length3 = array3.Length; k < length3; k++)
			{
				text += new StringBuilder("tenshi pet = ").Append(array3[k]).ToString();
			}
			int l = 0;
			RespPoppet[] array4 = SubAkumaPoppets;
			for (int length4 = array4.Length; l < length4; l++)
			{
				text += new StringBuilder("akuma pet = ").Append(array4[l]).ToString();
			}
			return text;
		}
	}

	internal bool _0024get_IsValid_0024_isValid_00242794()
	{
		return mainTenshiWeapon != null && mainAkumaWeapon != null && !(subTenshiWeapons == null) && !(subAkumaWeapons == null) && !(subTenshiPoppets == null) && !(subAkumaPoppets == null);
	}

	internal static float _0024GetBestWeapons_0024closure_00244009(KeyValuePair<int, float> o1, KeyValuePair<int, float> o2)
	{
		return o2.Value - o1.Value;
	}

	internal static float _0024GetBestWeapons_0024closure_00244010(KeyValuePair<int, float> o1, KeyValuePair<int, float> o2)
	{
		return o2.Value - o1.Value;
	}

	internal static float _0024GetBestWeapons_0024closure_00244011(KeyValuePair<int[], float> o1, KeyValuePair<int[], float> o2)
	{
		return o2.Value - o1.Value;
	}

	internal static float _0024GetBestPoppets_0024closure_00244012(KeyValuePair<int, float> o1, KeyValuePair<int, float> o2)
	{
		return o2.Value - o1.Value;
	}

	internal static float _0024GetBestPoppets_0024closure_00244013(KeyValuePair<int, float> o1, KeyValuePair<int, float> o2)
	{
		return o2.Value - o1.Value;
	}

	internal static float _0024GetBestPoppets_0024closure_00244014(KeyValuePair<int[], float> o1, KeyValuePair<int[], float> o2)
	{
		return o2.Value - o1.Value;
	}
}
