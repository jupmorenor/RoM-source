using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang.Runtime;
using MerlinAPI;

[Serializable]
public class UserDeckData
{
	private Dictionary<int, RespDeck> decks;

	public UserDeckData()
	{
		decks = new Dictionary<int, RespDeck>();
		int num = 1;
		while (num < 6)
		{
			int key = num;
			num++;
			decks[key] = new RespDeck();
		}
	}

	public int deckNum()
	{
		return decks.Count;
	}

	public RespDeck[] all()
	{
		List<int> list = new List<int>(decks.Keys);
		list.Sort();
		RespDeck[] array = new RespDeck[((ICollection)list).Count];
		int num = 0;
		int count = ((ICollection)list).Count;
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < count)
		{
			int index = num;
			num++;
			array[RuntimeServices.NormalizeArrayIndex(array, index)] = decks[list[index]];
		}
		return array;
	}

	public RespDeck get(int no)
	{
		return (!decks.ContainsKey(no)) ? null : decks[no];
	}

	public void set(RespDeck[] _decks)
	{
		decks.Clear();
		int i = 0;
		for (int length = _decks.Length; i < length; i = checked(i + 1))
		{
			if (_decks[i] == null)
			{
				throw new AssertionFailedException("d != null");
			}
			decks[_decks[i].No] = _decks[i];
		}
	}
}
