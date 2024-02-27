using System;
using Boo.Lang.Runtime;

namespace MerlinAPI;

[Serializable]
public class RespPoppetDeck : JsonBase
{
	public bool IsEquip;

	public int No;

	public RespPlayerPoppetDeck[] PlayerPoppetDecks;

	public RespPoppetDeck clone()
	{
		RespPoppetDeck respPoppetDeck = new RespPoppetDeck();
		respPoppetDeck.No = No;
		if (PlayerPoppetDecks != null)
		{
			int length = PlayerPoppetDecks.Length;
			respPoppetDeck.PlayerPoppetDecks = new RespPlayerPoppetDeck[length];
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
				RespPlayerPoppetDeck[] playerPoppetDecks = PlayerPoppetDecks;
				if (playerPoppetDecks[RuntimeServices.NormalizeArrayIndex(playerPoppetDecks, index)] != null)
				{
					RespPlayerPoppetDeck[] playerPoppetDecks2 = respPoppetDeck.PlayerPoppetDecks;
					int num3 = RuntimeServices.NormalizeArrayIndex(playerPoppetDecks2, index);
					RespPlayerPoppetDeck[] playerPoppetDecks3 = PlayerPoppetDecks;
					playerPoppetDecks2[num3] = playerPoppetDecks3[RuntimeServices.NormalizeArrayIndex(playerPoppetDecks3, index)].clone();
				}
			}
		}
		return respPoppetDeck;
	}

	public void init(RespPoppetDeck templDecks)
	{
		if (templDecks == null)
		{
			return;
		}
		No = templDecks.No;
		if (templDecks.PlayerPoppetDecks == null)
		{
			return;
		}
		int length = templDecks.PlayerPoppetDecks.Length;
		PlayerPoppetDecks = new RespPlayerPoppetDeck[length];
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
			RespPlayerPoppetDeck[] playerPoppetDecks = templDecks.PlayerPoppetDecks;
			if (playerPoppetDecks[RuntimeServices.NormalizeArrayIndex(playerPoppetDecks, index)] != null)
			{
				RespPlayerPoppetDeck[] playerPoppetDecks2 = templDecks.PlayerPoppetDecks;
				RespPlayerPoppetDeck respPlayerPoppetDeck = playerPoppetDecks2[RuntimeServices.NormalizeArrayIndex(playerPoppetDecks2, index)];
				RespPlayerPoppetDeck[] playerPoppetDecks3 = PlayerPoppetDecks;
				playerPoppetDecks3[RuntimeServices.NormalizeArrayIndex(playerPoppetDecks3, index)] = new RespPlayerPoppetDeck();
				RespPlayerPoppetDeck[] playerPoppetDecks4 = PlayerPoppetDecks;
				playerPoppetDecks4[RuntimeServices.NormalizeArrayIndex(playerPoppetDecks4, index)].InDeckNo = respPlayerPoppetDeck.InDeckNo;
				RespPlayerPoppetDeck[] playerPoppetDecks5 = PlayerPoppetDecks;
				playerPoppetDecks5[RuntimeServices.NormalizeArrayIndex(playerPoppetDecks5, index)].PoppetBoxId = respPlayerPoppetDeck.PoppetBoxId;
				RespPlayerPoppetDeck[] playerPoppetDecks6 = PlayerPoppetDecks;
				playerPoppetDecks6[RuntimeServices.NormalizeArrayIndex(playerPoppetDecks6, index)].WeaponBoxId = respPlayerPoppetDeck.WeaponBoxId;
				RespPlayerPoppetDeck[] playerPoppetDecks7 = PlayerPoppetDecks;
				playerPoppetDecks7[RuntimeServices.NormalizeArrayIndex(playerPoppetDecks7, index)].IsLeader = respPlayerPoppetDeck.IsLeader;
			}
		}
	}

	public void fromEquipments(RespPoppetDeck templDecks, ColosseumEquipments col)
	{
		init(templDecks);
		checked
		{
			if (col != null)
			{
				int num = 0;
				RespPlayerPoppetDeck[] playerPoppetDecks = PlayerPoppetDecks;
				playerPoppetDecks[RuntimeServices.NormalizeArrayIndex(playerPoppetDecks, num)].PoppetBoxId = col.MainPoppet.Poppet.Id;
				RespPlayerPoppetDeck[] playerPoppetDecks2 = PlayerPoppetDecks;
				playerPoppetDecks2[RuntimeServices.NormalizeArrayIndex(playerPoppetDecks2, num)].WeaponBoxId = col.MainPoppet.Weapon.Id;
				RespPlayerPoppetDeck[] playerPoppetDecks3 = PlayerPoppetDecks;
				playerPoppetDecks3[RuntimeServices.NormalizeArrayIndex(playerPoppetDecks3, num)].IsLeader = true;
				num++;
				RespPlayerPoppetDeck[] playerPoppetDecks4 = PlayerPoppetDecks;
				playerPoppetDecks4[RuntimeServices.NormalizeArrayIndex(playerPoppetDecks4, num)].PoppetBoxId = col.SubPoppets[0].Poppet.Id;
				RespPlayerPoppetDeck[] playerPoppetDecks5 = PlayerPoppetDecks;
				playerPoppetDecks5[RuntimeServices.NormalizeArrayIndex(playerPoppetDecks5, num)].WeaponBoxId = col.SubPoppets[0].Weapon.Id;
				RespPlayerPoppetDeck[] playerPoppetDecks6 = PlayerPoppetDecks;
				playerPoppetDecks6[RuntimeServices.NormalizeArrayIndex(playerPoppetDecks6, num)].IsLeader = false;
				num++;
				RespPlayerPoppetDeck[] playerPoppetDecks7 = PlayerPoppetDecks;
				playerPoppetDecks7[RuntimeServices.NormalizeArrayIndex(playerPoppetDecks7, num)].PoppetBoxId = col.SubPoppets[1].Poppet.Id;
				RespPlayerPoppetDeck[] playerPoppetDecks8 = PlayerPoppetDecks;
				playerPoppetDecks8[RuntimeServices.NormalizeArrayIndex(playerPoppetDecks8, num)].WeaponBoxId = col.SubPoppets[1].Weapon.Id;
				RespPlayerPoppetDeck[] playerPoppetDecks9 = PlayerPoppetDecks;
				playerPoppetDecks9[RuntimeServices.NormalizeArrayIndex(playerPoppetDecks9, num)].IsLeader = false;
			}
		}
	}

	public BoxId[] allBoxIds()
	{
		BoxId[] array = new BoxId[0];
		int i = 0;
		RespPlayerPoppetDeck[] playerPoppetDecks = PlayerPoppetDecks;
		for (int length = playerPoppetDecks.Length; i < length; i = checked(i + 1))
		{
			if (playerPoppetDecks[i] != null)
			{
				array = (BoxId[])RuntimeServices.AddArrays(typeof(BoxId), array, playerPoppetDecks[i].allBoxIds());
			}
		}
		return array;
	}
}
