using System;
using System.Collections;
using Boo.Lang.Runtime;

namespace MerlinAPI;

[Serializable]
public class ApiUpdateDeck2 : RequestBase
{
	[Serializable]
	public class Resp : GameApiResponseBase
	{
		public RespPlayerInfo PlayerInfo;

		public RespDeck2[] Decks2;
	}

	public ArrayList __REQUEST__;

	public override bool IsOk
	{
		get
		{
			bool num;
			if (!(ResponseObj is GameApiResponseBase gameApiResponseBase))
			{
				num = base.IsOk;
			}
			else
			{
				num = base.IsOk;
				if (num)
				{
					num = gameApiResponseBase.IsOkStatusCode;
				}
			}
			return num;
		}
	}

	public override bool HasValidStatus
	{
		get
		{
			GameApiResponseBase gameApiResponseBase = ResponseObj as GameApiResponseBase;
			bool num = gameApiResponseBase != null;
			if (num)
			{
				num = !string.IsNullOrEmpty(gameApiResponseBase.StatusCode);
			}
			return num;
		}
	}

	public override string ApiPath => "/Deck2/Update";

	public override ServerType Server => ServerType.Game;

	public ApiUpdateDeck2()
	{
		__REQUEST__ = new ArrayList();
	}

	public Resp GetResponse()
	{
		return ResponseObj as Resp;
	}

	public override Type responseType()
	{
		return typeof(Resp);
	}

	public void fromDecks(RespDeck2[] decks2, int equipDeckNo)
	{
		if (decks2 == null && decks2.Length > 0)
		{
			throw new AssertionFailedException("(decks2 != null) or (len(decks2) <= 0)");
		}
		__REQUEST__.Clear();
		bool flag = false;
		int num = 1;
		int i = 0;
		for (int length = decks2.Length; i < length; i = checked(i + 1))
		{
			if (decks2[i] == null)
			{
				throw new AssertionFailedException("d != null");
			}
			decks2[i] = decks2[i].clone();
			decks2[i].IsEquip = decks2[i].No == equipDeckNo;
			if (decks2[i].IsEquip)
			{
				flag = true;
			}
			if (decks2[i].Supports != null)
			{
				int num2 = 0;
				int length2 = decks2[i].Supports.Length;
				if (length2 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num2 < length2)
				{
					int num3 = num2;
					num2++;
					RespDeck2Support[] supports = decks2[i].Supports;
					supports[RuntimeServices.NormalizeArrayIndex(supports, num3)].No = checked(num3 + 1);
				}
			}
			__REQUEST__.Add(decks2[i]);
		}
		if (!flag)
		{
			(__REQUEST__[0] as RespDeck2).IsEquip = true;
		}
	}

	public static ApiUpdateDeck2 FromDecks(RespDeck2[] decks2, int equipDeckNo)
	{
		ApiUpdateDeck2 apiUpdateDeck = new ApiUpdateDeck2();
		apiUpdateDeck.fromDecks(decks2, equipDeckNo);
		return apiUpdateDeck;
	}

	public static ApiUpdateDeck2 FromUserDataDeck2(int equipDeckNo)
	{
		ApiUpdateDeck2 apiUpdateDeck = new ApiUpdateDeck2();
		apiUpdateDeck.fromUserDataDeck2(equipDeckNo);
		return apiUpdateDeck;
	}

	private void fromUserDataDeck2(object equipDeckNo)
	{
		UserDeckData2 userDeckData = UserData.Current.userDeckData2;
		if (userDeckData != null)
		{
			fromDecks(userDeckData.all(), RuntimeServices.UnboxInt32(equipDeckNo));
		}
	}
}
