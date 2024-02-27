using System;

namespace MerlinAPI;

[Serializable]
public class RespPlayerInfo : JsonBase
{
	public int Id;

	public int AngelGender;

	public string AngelName;

	public int Ap;

	public DateTime BeforeApRecoveryDateTime;

	public DateTime BeforeRpRecoveryDateTime;

	public int BoxExtensionCount;

	public int BoxSize;

	public int Coin;

	public int DemonGender;

	public string DemonName;

	public int Exp;

	public int FayStone;

	public int Fp;

	public int FriendLimit;

	public bool IsTutorialFin;

	public int Level;

	public string PoppetName;

	public int Rgp;

	public int Rp;

	public string TGuildCd;

	public int TPartyId;

	public int TPlayerDeckNo;

	public int TPlayerId;

	public int TSocialPlayerId;

	public int TutorialStep;

	public DateTime CreateDate;

	public int WeaponCostLimit;

	public int ManaFragment;

	public int Bp;

	public DateTime BeforeBpRecoveryDateTime;

	public int TPlayerPoppetDeckNo;

	public RespPlayerInfo()
	{
		AngelName = "<?>";
		DemonName = "<?>";
		Level = 1;
		PoppetName = "<?>";
	}
}
