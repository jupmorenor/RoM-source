using System;

namespace MerlinAPI;

[Serializable]
public class RespPlayerPoppetDeck : JsonBase
{
	public int InDeckNo;

	public BoxId PoppetBoxId;

	public BoxId WeaponBoxId;

	public bool IsLeader;

	public RespPoppet BoxPoppet
	{
		get
		{
			UserData current = UserData.Current;
			return current.boxPoppet(PoppetBoxId);
		}
	}

	public RespWeapon BoxWeapon
	{
		get
		{
			UserData current = UserData.Current;
			return current.boxWeapon(WeaponBoxId);
		}
	}

	public RespPlayerPoppetDeck clone()
	{
		RespPlayerPoppetDeck respPlayerPoppetDeck = new RespPlayerPoppetDeck();
		respPlayerPoppetDeck.PoppetBoxId = PoppetBoxId;
		respPlayerPoppetDeck.WeaponBoxId = WeaponBoxId;
		respPlayerPoppetDeck.InDeckNo = InDeckNo;
		respPlayerPoppetDeck.IsLeader = IsLeader;
		return respPlayerPoppetDeck;
	}

	public BoxId[] allBoxIds()
	{
		return new BoxId[2] { PoppetBoxId, WeaponBoxId };
	}
}
