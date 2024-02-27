using System;
using Boo.Lang.Runtime;
using MerlinAPI;

[Serializable]
public class ColosseumEquipments : EquipmentsBase
{
	[Serializable]
	public class PoppetBattleUnit
	{
		private RespPoppet poppet;

		private RespWeapon weapon;

		public RespPoppet Poppet
		{
			get
			{
				return poppet;
			}
			set
			{
				poppet = value;
			}
		}

		public RespWeapon Weapon
		{
			get
			{
				return weapon;
			}
			set
			{
				weapon = value;
			}
		}

		public PoppetBattleUnit Clone()
		{
			PoppetBattleUnit dstPet = new PoppetBattleUnit();
			return Copy(ref dstPet);
		}

		public PoppetBattleUnit Copy(ref PoppetBattleUnit dstPet)
		{
			dstPet.Poppet = poppet;
			dstPet.Weapon = weapon;
			return dstPet;
		}

		public int GetCost()
		{
			int num = default(int);
			if (poppet != null)
			{
				num = poppet.DeckCost;
			}
			if (weapon != null)
			{
				num = checked(num + weapon.DeckCost);
			}
			return num;
		}

		public int GetAtk()
		{
			float num = DamageCalc.ColosseumPoppetAttack(poppet, weapon);
			return checked((int)num);
		}

		public int GetHp()
		{
			float num = DamageCalc.ColosseumPoppetHP(poppet, weapon);
			return checked((int)num);
		}

		public bool CheckEnableRarity(int lmitedRarity)
		{
			int result;
			if (lmitedRarity <= 0)
			{
				result = 1;
			}
			else
			{
				if (poppet != null)
				{
					MRares rare = poppet.Rare;
					if (rare.Id < lmitedRarity)
					{
						result = 0;
						goto IL_0060;
					}
				}
				if (weapon != null)
				{
					MRares rare2 = weapon.Rare;
					if (rare2.Id < lmitedRarity)
					{
						result = 0;
						goto IL_0060;
					}
				}
				result = 1;
			}
			goto IL_0060;
			IL_0060:
			return (byte)result != 0;
		}
	}

	[NonSerialized]
	public static bool POPPET_BATTLE_EQUIPMENTS_DUMMY_PARAMETER = true;

	[NonSerialized]
	public const int POPPET_NUM = 3;

	[NonSerialized]
	public const int SUBPOPPET_NUM = 2;

	private PoppetBattleUnit mainPoppet;

	private PoppetBattleUnit[] subPoppets;

	public PoppetBattleUnit MainPoppet
	{
		get
		{
			return mainPoppet;
		}
		set
		{
			mainPoppet = value;
		}
	}

	public PoppetBattleUnit[] SubPoppets
	{
		get
		{
			return subPoppets;
		}
		set
		{
			subPoppets = value;
		}
	}

	public int GetCost()
	{
		int num = default(int);
		if (mainPoppet != null)
		{
			num = mainPoppet.GetCost();
		}
		checked
		{
			if (subPoppets != null)
			{
				int i = 0;
				PoppetBattleUnit[] array = subPoppets;
				for (int length = array.Length; i < length; i++)
				{
					if (array[i] != null)
					{
						num += array[i].GetCost();
					}
				}
			}
			return num;
		}
	}

	public int GetAtk()
	{
		int num = default(int);
		if (mainPoppet != null)
		{
			num = mainPoppet.GetAtk();
		}
		checked
		{
			if (subPoppets != null)
			{
				int i = 0;
				PoppetBattleUnit[] array = subPoppets;
				for (int length = array.Length; i < length; i++)
				{
					if (array[i] != null)
					{
						num += array[i].GetAtk();
					}
				}
			}
			return num;
		}
	}

	public int GetHp()
	{
		int num = default(int);
		if (mainPoppet != null)
		{
			num = mainPoppet.GetHp();
		}
		checked
		{
			if (subPoppets != null)
			{
				int i = 0;
				PoppetBattleUnit[] array = subPoppets;
				for (int length = array.Length; i < length; i++)
				{
					if (array[i] != null)
					{
						num += array[i].GetHp();
					}
				}
			}
			return num;
		}
	}

	public bool CheckEnableRarity(int lmitedRarity)
	{
		int result;
		if (lmitedRarity <= 0)
		{
			result = 1;
		}
		else
		{
			bool flag = default(bool);
			if (mainPoppet != null)
			{
				flag = mainPoppet.CheckEnableRarity(lmitedRarity);
			}
			if (!flag)
			{
				result = 0;
			}
			else
			{
				if (subPoppets != null)
				{
					int num = 0;
					PoppetBattleUnit[] array = subPoppets;
					int length = array.Length;
					while (num < length)
					{
						if (array[num] != null)
						{
							flag = array[num].CheckEnableRarity(lmitedRarity);
						}
						if (flag)
						{
							num = checked(num + 1);
							continue;
						}
						goto IL_006a;
					}
				}
				result = 1;
			}
		}
		goto IL_007d;
		IL_007d:
		return (byte)result != 0;
		IL_006a:
		result = 0;
		goto IL_007d;
	}

	public static ColosseumEquipments FromUserData()
	{
		ColosseumEquipments colosseumEquipments = new ColosseumEquipments();
		colosseumEquipments.fromUserData();
		return colosseumEquipments;
	}

	public static ColosseumEquipments FromDeck2Index(int aDeckIndex)
	{
		ColosseumEquipments result = null;
		UserData current = UserData.Current;
		if (0 <= aDeckIndex)
		{
			RespDeck2[] decks = current.userDeckData2.Decks2;
			if (aDeckIndex < decks.Length)
			{
				result = FromRespDeck2(decks[RuntimeServices.NormalizeArrayIndex(decks, aDeckIndex)]);
			}
		}
		return result;
	}

	public static ColosseumEquipments FromRespDeck2(RespDeck2 aDeck2)
	{
		ColosseumEquipments colosseumEquipments = new ColosseumEquipments();
		colosseumEquipments.fromRespDeck2(aDeck2);
		return colosseumEquipments;
	}

	public static ColosseumEquipments FromRespDeck(RespPoppetDeck aDeck)
	{
		ColosseumEquipments colosseumEquipments = new ColosseumEquipments();
		return (!colosseumEquipments.fromRespDeck(aDeck)) ? null : colosseumEquipments;
	}

	private void initDerivedAttributes()
	{
	}

	private bool fromUserData()
	{
		UserData current = UserData.Current;
		return current != null && fromRespDeck(current.CurrentPoppetDeck);
	}

	private bool fromRespDeck(RespPoppetDeck aDeck)
	{
		mainPoppet = new PoppetBattleUnit();
		PoppetBattleUnit poppetBattleUnit = new PoppetBattleUnit();
		PoppetBattleUnit poppetBattleUnit2 = new PoppetBattleUnit();
		subPoppets = new PoppetBattleUnit[2] { poppetBattleUnit, poppetBattleUnit2 };
		if (aDeck == null)
		{
			throw new AssertionFailedException("null != aDeck");
		}
		if (aDeck.PlayerPoppetDecks == null)
		{
			throw new AssertionFailedException("null != aDeck.PlayerPoppetDecks");
		}
		RespPlayerPoppetDeck[] playerPoppetDecks = aDeck.PlayerPoppetDecks;
		if (3 != playerPoppetDecks.Length)
		{
			throw new AssertionFailedException("POPPET_NUM == pets.Length");
		}
		RespPlayerPoppetDeck respPlayerPoppetDeck = null;
		RespPlayerPoppetDeck[] array = new RespPlayerPoppetDeck[0];
		int num = 0;
		RespPlayerPoppetDeck[] array2 = playerPoppetDecks;
		int length = array2.Length;
		int result;
		while (true)
		{
			if (num < length)
			{
				if (array2[num] == null)
				{
					result = 0;
					break;
				}
				if (respPlayerPoppetDeck == null && array2[num].IsLeader)
				{
					respPlayerPoppetDeck = array2[num];
				}
				else
				{
					array = (RespPlayerPoppetDeck[])RuntimeServices.AddArrays(typeof(RespPlayerPoppetDeck), array, new RespPlayerPoppetDeck[1] { array2[num] });
				}
				num = checked(num + 1);
				continue;
			}
			if (respPlayerPoppetDeck == null)
			{
				respPlayerPoppetDeck = array[0];
				array[0] = array[1];
				array[1] = array[2];
			}
			UserData current = UserData.Current;
			mainPoppet.Poppet = current.boxPoppet(respPlayerPoppetDeck.PoppetBoxId);
			mainPoppet.Weapon = current.boxWeapon(respPlayerPoppetDeck.WeaponBoxId);
			poppetBattleUnit.Poppet = current.boxPoppet(array[0].PoppetBoxId);
			poppetBattleUnit.Weapon = current.boxWeapon(array[0].WeaponBoxId);
			poppetBattleUnit2.Poppet = current.boxPoppet(array[1].PoppetBoxId);
			poppetBattleUnit2.Weapon = current.boxWeapon(array[1].WeaponBoxId);
			initDerivedAttributes();
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	private void fromRespDeck2(RespDeck2 aDeck2)
	{
		if (POPPET_BATTLE_EQUIPMENTS_DUMMY_PARAMETER)
		{
			mainPoppet = new PoppetBattleUnit();
			PoppetBattleUnit poppetBattleUnit = new PoppetBattleUnit();
			PoppetBattleUnit poppetBattleUnit2 = new PoppetBattleUnit();
			mainPoppet.Poppet = aDeck2.MainPoppet;
			RespWeapon[] supportWeapons = aDeck2.getSupportWeapons(RACE_TYPE.Tensi);
			if (supportWeapons != null)
			{
				mainPoppet.Weapon = supportWeapons[0];
			}
			subPoppets = new PoppetBattleUnit[2] { poppetBattleUnit, poppetBattleUnit2 };
			RespPoppet[] supportPoppets = aDeck2.getSupportPoppets(RACE_TYPE.Tensi);
			if (supportPoppets != null)
			{
				poppetBattleUnit.Poppet = supportPoppets[0];
			}
			poppetBattleUnit.Weapon = aDeck2.AngelWeapon;
			RespPoppet[] supportPoppets2 = aDeck2.getSupportPoppets(RACE_TYPE.Akuma);
			if (supportPoppets2 != null)
			{
				poppetBattleUnit2.Poppet = supportPoppets2[0];
			}
			poppetBattleUnit2.Weapon = aDeck2.DevilWeapon;
		}
		initDerivedAttributes();
	}

	public ColosseumEquipments Clone()
	{
		ColosseumEquipments dstPet = new ColosseumEquipments();
		return Copy(ref dstPet);
	}

	public ColosseumEquipments Copy(ref ColosseumEquipments dstPet)
	{
		PoppetBattleUnit poppetBattleUnit = null;
		if (mainPoppet != null)
		{
			poppetBattleUnit = mainPoppet.Clone();
		}
		dstPet.mainPoppet = poppetBattleUnit;
		if (dstPet.subPoppets != null)
		{
			int i = 0;
			PoppetBattleUnit[] array = dstPet.subPoppets;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				poppetBattleUnit = null;
				if (array[i] != null)
				{
					poppetBattleUnit = array[i].Clone();
				}
				dstPet.subPoppets = (PoppetBattleUnit[])RuntimeServices.AddArrays(typeof(PoppetBattleUnit), dstPet.subPoppets, new PoppetBattleUnit[1] { poppetBattleUnit });
			}
		}
		return dstPet;
	}
}
