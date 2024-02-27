using System;
using System.Collections;
using Boo.Lang;
using Boo.Lang.Runtime;

namespace MerlinAPI;

[Serializable]
public class ApiUpdateDeck : RequestBase
{
	[Serializable]
	public class Set : JsonBase
	{
		public int No;

		public string Deck;

		public bool IsEquip;

		public Set(int no, BoxId[] list, bool isEquip)
		{
			No = no;
			Deck = Builtins.join(list, ",");
			IsEquip = isEquip;
		}
	}

	[Serializable]
	public class Resp : GameApiResponseBase
	{
		public RespPlayerInfo PlayerInfo;

		public RespDeck[] Decks;
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

	public override string ApiPath => "/Deck/Update";

	public override ServerType Server => ServerType.Game;

	public ApiUpdateDeck()
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

	public Set add(int no, BoxId[] list, bool isEquip)
	{
		if (no == 0)
		{
			throw new AssertionFailedException("デッキ番号は1はじまり,0を指定してはいけない");
		}
		__REQUEST__.Add(new Set(no, list, isEquip));
		return null;
	}
}
