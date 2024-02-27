using System;

namespace MerlinAPI;

[Serializable]
public class RespDeck : JsonBase
{
	public int Id;

	public int No;

	public int TPlayerId;

	public BoxId TPoppetBoxId;

	public BoxId TWeaponBoxId_1;

	public BoxId TWeaponBoxId_2;

	public BoxId TWeaponBoxId_3;

	public BoxId[] ToApiBoxIdArray => new BoxId[4] { TWeaponBoxId_1, TWeaponBoxId_2, TWeaponBoxId_3, TPoppetBoxId };

	public BoxId[] WeaponIds => new BoxId[3] { TWeaponBoxId_1, TWeaponBoxId_2, TWeaponBoxId_3 };
}
