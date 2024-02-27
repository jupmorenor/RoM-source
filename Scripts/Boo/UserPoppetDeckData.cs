using System;
using Boo.Lang.Runtime;
using MerlinAPI;

[Serializable]
public class UserPoppetDeckData
{
	[NonSerialized]
	public const int DECK_NUM = 5;

	private RespPoppetDeck[] poppetDecks;

	private ColosseumEquipments[] colosseumEquipments;

	private int currentDeck;

	public ColosseumEquipments[] ColEquips
	{
		get
		{
			return colosseumEquipments;
		}
		set
		{
			if (value == null)
			{
				throw new AssertionFailedException("null != cols");
			}
			if (value.Length != 5)
			{
				throw new AssertionFailedException("cols.Length == DECK_NUM");
			}
			if (value == null)
			{
				throw new AssertionFailedException("null != cols");
			}
			int num = 0;
			int num2 = 5;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int index = num;
				num++;
				if (value[RuntimeServices.NormalizeArrayIndex(value, index)] == null)
				{
					throw new AssertionFailedException("null != cols[i]");
				}
				ColosseumEquipments[] array = colosseumEquipments;
				array[RuntimeServices.NormalizeArrayIndex(array, index)] = value[RuntimeServices.NormalizeArrayIndex(value, index)];
			}
		}
	}

	public RespPoppetDeck[] All => poppetDecks;

	public int CurrentDeck
	{
		get
		{
			return currentDeck;
		}
		set
		{
			currentDeck = value;
		}
	}

	public UserPoppetDeckData()
	{
		colosseumEquipments = new ColosseumEquipments[5];
	}

	public BoxId[] allBoxIds()
	{
		BoxId[] array = new BoxId[0];
		if (poppetDecks != null)
		{
			int i = 0;
			RespPoppetDeck[] array2 = poppetDecks;
			for (int length = array2.Length; i < length; i = checked(i + 1))
			{
				if (array2[i] != null)
				{
					array = (BoxId[])RuntimeServices.AddArrays(typeof(BoxId), array, array2[i].allBoxIds());
				}
			}
		}
		return array;
	}

	public int deckNum()
	{
		return (!(poppetDecks == null)) ? poppetDecks.Length : 0;
	}

	public RespPoppetDeck get(int no)
	{
		object result;
		if (poppetDecks == null)
		{
			result = null;
		}
		else
		{
			int num = 0;
			RespPoppetDeck[] array = poppetDecks;
			int length = array.Length;
			while (true)
			{
				if (num < length)
				{
					if (array[num] != null && array[num].No == no)
					{
						result = array[num];
						break;
					}
					num = checked(num + 1);
					continue;
				}
				result = null;
				break;
			}
		}
		return (RespPoppetDeck)result;
	}

	public void set(RespPoppetDeck[] _poppetDecks)
	{
		if (_poppetDecks != null)
		{
			poppetDecks = _poppetDecks;
		}
		updateEquipments();
	}

	public void updateEquipments()
	{
		int num = 0;
		int num2 = 5;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			RespPoppetDeck[] array = poppetDecks;
			if (array[RuntimeServices.NormalizeArrayIndex(array, num3)] == null)
			{
				ColosseumEquipments[] array2 = colosseumEquipments;
				array2[RuntimeServices.NormalizeArrayIndex(array2, num3)] = ColosseumEquipments.FromDeck2Index(num3);
				continue;
			}
			ColosseumEquipments[] array3 = colosseumEquipments;
			int num4 = RuntimeServices.NormalizeArrayIndex(array3, num3);
			RespPoppetDeck[] array4 = poppetDecks;
			array3[num4] = ColosseumEquipments.FromRespDeck(array4[RuntimeServices.NormalizeArrayIndex(array4, num3)]);
			ColosseumEquipments[] array5 = colosseumEquipments;
			if (array5[RuntimeServices.NormalizeArrayIndex(array5, num3)] == null)
			{
				ColosseumEquipments[] array6 = colosseumEquipments;
				array6[RuntimeServices.NormalizeArrayIndex(array6, num3)] = ColosseumEquipments.FromDeck2Index(num3);
			}
		}
		currentDeck = checked(UserData.Current.userStatus.TPlayerPoppetDeckNo - 1);
	}

	public RequestBase createRequest()
	{
		object obj = null;
		RespPoppetDeck[] array = new RespPoppetDeck[0];
		int num = 0;
		int num2 = 5;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			RespPoppetDeck respPoppetDeck = new RespPoppetDeck();
			respPoppetDeck.No = checked(num3 + 1);
			RespPoppetDeck[] array2 = poppetDecks;
			RespPoppetDeck templDecks = array2[RuntimeServices.NormalizeArrayIndex(array2, num3)];
			ColosseumEquipments[] array3 = colosseumEquipments;
			respPoppetDeck.fromEquipments(templDecks, array3[RuntimeServices.NormalizeArrayIndex(array3, num3)]);
			array = (RespPoppetDeck[])RuntimeServices.AddArrays(typeof(RespPoppetDeck), array, new RespPoppetDeck[1] { respPoppetDeck });
		}
		obj = ApiPoppetDeckUpdate.FromDecks(array, checked(currentDeck + 1));
		object obj2 = obj;
		if (!(obj2 is RequestBase))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(RequestBase));
		}
		return (RequestBase)obj2;
	}
}
