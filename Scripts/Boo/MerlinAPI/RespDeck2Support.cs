using System;

namespace MerlinAPI;

[Serializable]
public class RespDeck2Support : JsonBase
{
	public int FormType;

	public int ItemType;

	public int No;

	public BoxId BoxId;

	public bool IsWeapon => ItemType == 1;

	public bool IsPoppet => ItemType == 2;

	public RespWeapon BoxWeapon
	{
		get
		{
			UserData current = UserData.Current;
			return (current != null && IsWeapon) ? current.boxWeapon(BoxId) : null;
		}
	}

	public RespPoppet BoxPoppet
	{
		get
		{
			UserData current = UserData.Current;
			return (current != null && IsPoppet) ? current.boxPoppet(BoxId) : null;
		}
	}

	public bool IsTenshiSupport => FormType == 1;

	public bool IsAkumaSupport => FormType == 2;

	public RespDeck2Support clone()
	{
		RespDeck2Support respDeck2Support = new RespDeck2Support();
		respDeck2Support.FormType = FormType;
		respDeck2Support.ItemType = ItemType;
		respDeck2Support.No = No;
		respDeck2Support.BoxId = BoxId;
		return respDeck2Support;
	}

	public static RespDeck2Support FromWeaponBoxIdOfAngel(BoxId boxId)
	{
		RespDeck2Support respDeck2Support = new RespDeck2Support();
		respDeck2Support.fromWeaponBoxId(boxId, Deck2FormTypes.Angel);
		return respDeck2Support;
	}

	public static RespDeck2Support FromWeaponBoxIdOfDevil(BoxId boxId)
	{
		RespDeck2Support respDeck2Support = new RespDeck2Support();
		respDeck2Support.fromWeaponBoxId(boxId, Deck2FormTypes.Devil);
		return respDeck2Support;
	}

	public static RespDeck2Support FromPoppetBoxIdOfAngel(BoxId boxId)
	{
		RespDeck2Support respDeck2Support = new RespDeck2Support();
		respDeck2Support.fromPoppetBoxId(boxId, Deck2FormTypes.Angel);
		return respDeck2Support;
	}

	public static RespDeck2Support FromPoppetBoxIdOfDevil(BoxId boxId)
	{
		RespDeck2Support respDeck2Support = new RespDeck2Support();
		respDeck2Support.fromPoppetBoxId(boxId, Deck2FormTypes.Devil);
		return respDeck2Support;
	}

	public void fromWeaponBoxId(BoxId boxId, Deck2FormTypes ftype)
	{
		FormType = (int)ftype;
		ItemType = 1;
		No = 1;
		BoxId = boxId;
	}

	public void fromPoppetBoxId(BoxId boxId, Deck2FormTypes ftype)
	{
		FormType = (int)ftype;
		ItemType = 2;
		No = 1;
		BoxId = boxId;
	}
}
