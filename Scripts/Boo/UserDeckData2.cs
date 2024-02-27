using System;
using Boo.Lang.Runtime;
using MerlinAPI;

[Serializable]
public class UserDeckData2
{
	[NonSerialized]
	public const int DECK2_NUM = 5;

	private RespDeck2[] decks2;

	[NonSerialized]
	private static WeaponEquipments[] weaponEquipments = new WeaponEquipments[5];

	private PoppetEquipments[] poppetEquipments;

	private UserConfigData.DeckTypes[] deckTypes;

	private int currentDeck;

	public bool IsValid => decks2 != null;

	public static WeaponEquipments[] WepEquips
	{
		get
		{
			return weaponEquipments;
		}
		set
		{
			if (value == null)
			{
				throw new AssertionFailedException("null != weps");
			}
			if (value.Length != 5)
			{
				throw new AssertionFailedException("weps.Length == DECK2_NUM");
			}
			if (value == null)
			{
				throw new AssertionFailedException("null != weps");
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
					throw new AssertionFailedException("null != weps[i]");
				}
				WeaponEquipments[] array = weaponEquipments;
				array[RuntimeServices.NormalizeArrayIndex(array, index)] = value[RuntimeServices.NormalizeArrayIndex(value, index)];
			}
		}
	}

	public PoppetEquipments[] PetEquips
	{
		get
		{
			return poppetEquipments;
		}
		set
		{
			if (value == null)
			{
				throw new AssertionFailedException("null != pets");
			}
			if (value.Length != 5)
			{
				throw new AssertionFailedException("pets.Length == DECK2_NUM");
			}
			if (value == null)
			{
				throw new AssertionFailedException("null != pets");
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
					throw new AssertionFailedException("null != pets[i]");
				}
				PoppetEquipments[] array = poppetEquipments;
				array[RuntimeServices.NormalizeArrayIndex(array, index)] = value[RuntimeServices.NormalizeArrayIndex(value, index)];
			}
		}
	}

	public UserConfigData.DeckTypes[] DeckTypes
	{
		get
		{
			return deckTypes;
		}
		set
		{
			if (value == null)
			{
				throw new AssertionFailedException("null != types");
			}
			if (value.Length != 5)
			{
				throw new AssertionFailedException("types.Length == DECK2_NUM");
			}
			if (value == null)
			{
				throw new AssertionFailedException("null != types");
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
				UserConfigData.DeckTypes[] array = deckTypes;
				array[RuntimeServices.NormalizeArrayIndex(array, index)] = value[RuntimeServices.NormalizeArrayIndex(value, index)];
			}
		}
	}

	public RespDeck2[] All => decks2;

	public RespDeck2[] Decks2 => decks2;

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

	public UserDeckData2()
	{
		poppetEquipments = new PoppetEquipments[5];
		deckTypes = new UserConfigData.DeckTypes[5];
		object obj = null;
	}

	public int deckNum()
	{
		return (!(decks2 == null)) ? decks2.Length : 0;
	}

	public RespDeck2[] all()
	{
		return decks2;
	}

	public BoxId[] allBoxIds()
	{
		BoxId[] array = new BoxId[0];
		int i = 0;
		RespDeck2[] array2 = decks2;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			array = (BoxId[])RuntimeServices.AddArrays(typeof(BoxId), array, array2[i].allBoxIds());
		}
		return array;
	}

	public BoxId[] allWeaponBoxIds()
	{
		BoxId[] array = new BoxId[0];
		int i = 0;
		RespDeck2[] array2 = decks2;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			array = (BoxId[])RuntimeServices.AddArrays(typeof(BoxId), array, array2[i].allWeaponBoxIds());
		}
		return array;
	}

	public BoxId[] allPoppetBoxIds()
	{
		BoxId[] array = new BoxId[0];
		int i = 0;
		RespDeck2[] array2 = decks2;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			array = (BoxId[])RuntimeServices.AddArrays(typeof(BoxId), array, array2[i].allPoppetBoxIds());
		}
		return array;
	}

	public RespDeck2 get(int no)
	{
		object result;
		if (decks2 == null)
		{
			result = null;
		}
		else
		{
			int num = 0;
			RespDeck2[] array = decks2;
			int length = array.Length;
			while (true)
			{
				if (num < length)
				{
					if (array[num].No == no)
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
		return (RespDeck2)result;
	}

	public void set(RespDeck2[] _decks)
	{
		decks2 = _decks;
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
			if (num3 < decks2.Length)
			{
				RespDeck2[] array = decks2;
				if (array[RuntimeServices.NormalizeArrayIndex(array, num3)] != null)
				{
					WeaponEquipments[] array2 = weaponEquipments;
					int num4 = RuntimeServices.NormalizeArrayIndex(array2, num3);
					RespDeck2[] array3 = decks2;
					array2[num4] = WeaponEquipments.FromRespDeck2(array3[RuntimeServices.NormalizeArrayIndex(array3, num3)]);
					PoppetEquipments[] array4 = poppetEquipments;
					int num5 = RuntimeServices.NormalizeArrayIndex(array4, num3);
					RespDeck2[] array5 = decks2;
					array4[num5] = PoppetEquipments.FromRespDeck2(array5[RuntimeServices.NormalizeArrayIndex(array5, num3)]);
					continue;
				}
			}
			throw new AssertionFailedException("(i < decks2.Length) and (null != decks2[i])");
		}
		currentDeck = checked(UserData.Current.userStatus.TPlayerDeckNo - 1);
	}

	public ApiUpdateDeck2 createRequest()
	{
		RespDeck2[] lhs = new RespDeck2[0];
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
			RespDeck2 respDeck = new RespDeck2();
			RespDeck2[] array = decks2;
			RespDeck2 templDecks = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			WeaponEquipments[] array2 = weaponEquipments;
			WeaponEquipments wep = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
			PoppetEquipments[] array3 = poppetEquipments;
			respDeck.fromEquipments(templDecks, wep, array3[RuntimeServices.NormalizeArrayIndex(array3, index)]);
			lhs = (RespDeck2[])RuntimeServices.AddArrays(typeof(RespDeck2), lhs, new RespDeck2[1] { respDeck });
		}
		return ApiUpdateDeck2.FromDecks(lhs, checked(currentDeck + 1));
	}
}
