using System;
using System.Collections;
using Boo.Lang.Runtime;

namespace MerlinAPI;

[Serializable]
public class ApiPoppetDeckUpdate : RequestBase
{
	[Serializable]
	public class Resp : GameApiResponseBase
	{
		public RespPlayerInfo PlayerInfo;

		public RespPoppetDeck[] PoppetDecks;
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

	public override string ApiPath => "/PoppetDeck/Update";

	public override ServerType Server => ServerType.Game;

	public ApiPoppetDeckUpdate()
	{
		__REQUEST__ = new ArrayList();
	}

	public RespPoppetDeckUpdate GetResponse()
	{
		return ResponseObj as RespPoppetDeckUpdate;
	}

	public override Type responseType()
	{
		return typeof(RespPoppetDeckUpdate);
	}

	public void fromDecks(RespPoppetDeck[] decks, int equipDeckNo)
	{
		if (decks == null && decks.Length > 0)
		{
			throw new AssertionFailedException("(decks != null) or (len(decks) <= 0)");
		}
		__REQUEST__.Clear();
		bool flag = false;
		int num = 1;
		int i = 0;
		for (int length = decks.Length; i < length; i = checked(i + 1))
		{
			if (decks[i] == null)
			{
				throw new AssertionFailedException("d != null");
			}
			decks[i] = decks[i].clone();
			decks[i].IsEquip = decks[i].No == equipDeckNo;
			if (decks[i].IsEquip)
			{
				flag = true;
			}
			if (decks[i].PlayerPoppetDecks != null)
			{
				int num2 = 0;
				int length2 = decks[i].PlayerPoppetDecks.Length;
				if (length2 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num2 < length2)
				{
					int num3 = num2;
					num2++;
					RespPlayerPoppetDeck[] playerPoppetDecks = decks[i].PlayerPoppetDecks;
					playerPoppetDecks[RuntimeServices.NormalizeArrayIndex(playerPoppetDecks, num3)].InDeckNo = checked(num3 + 1);
				}
			}
			__REQUEST__.Add(decks[i]);
		}
		if (!flag)
		{
			(__REQUEST__[0] as RespPoppetDeck).IsEquip = true;
		}
	}

	public static ApiPoppetDeckUpdate FromDecks(RespPoppetDeck[] decks, int equipDeckNo)
	{
		ApiPoppetDeckUpdate apiPoppetDeckUpdate = new ApiPoppetDeckUpdate();
		apiPoppetDeckUpdate.fromDecks(decks, equipDeckNo);
		return apiPoppetDeckUpdate;
	}
}
