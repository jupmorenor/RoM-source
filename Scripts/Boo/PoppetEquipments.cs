using System;
using Boo.Lang.Runtime;
using MerlinAPI;

[Serializable]
public class PoppetEquipments : EquipmentsBase
{
	private RespPoppet mainPoppet;

	private RespPoppet friendPoppet;

	public RespPoppet MainPoppet
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

	public RespPoppet FriendPoppet
	{
		get
		{
			return friendPoppet;
		}
		set
		{
			friendPoppet = value;
		}
	}

	public static PoppetEquipments FromUserData()
	{
		PoppetEquipments poppetEquipments = new PoppetEquipments();
		poppetEquipments.fromUserData();
		return poppetEquipments;
	}

	public static PoppetEquipments FromDeckIndex(int aDeckIndex)
	{
		PoppetEquipments result = null;
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

	public static PoppetEquipments FromRespDeck2(RespDeck2 aDeck2)
	{
		PoppetEquipments poppetEquipments = new PoppetEquipments();
		poppetEquipments.fromRespDeck2(aDeck2);
		return poppetEquipments;
	}

	private void initDerivedAttributes()
	{
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
			else
			{
				mainPoppet = current.CurrentPoppet;
			}
		}
	}

	private void fromRespDeck2(RespDeck2 aDeck2)
	{
		mainPoppet = aDeck2.MainPoppet;
		if (mainPoppet == null)
		{
		}
		friendPoppet = null;
		initDerivedAttributes();
	}

	public PoppetEquipments Clone()
	{
		PoppetEquipments dstPet = new PoppetEquipments();
		return Copy(ref dstPet);
	}

	public PoppetEquipments Copy(ref PoppetEquipments dstPet)
	{
		dstPet.mainPoppet = mainPoppet;
		dstPet.friendPoppet = friendPoppet;
		return dstPet;
	}
}
