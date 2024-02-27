using System;
using System.Collections;
using Boo.Lang.Runtime;

namespace MerlinAPI;

[Serializable]
public class RespShopItem : JsonBase
{
	[Serializable]
	public class Item
	{
		public EnumMasterTypeValues TypeValue;

		public int Quantity;

		public int ItemId;

		public int Level;
	}

	public int Id;

	public int ShopTypeValue;

	public string Name;

	public string Explain;

	public ArrayList ShopItems;

	public int Price;

	public DateTime BeginDate;

	public DateTime EndDate;

	public Item[] Items
	{
		get
		{
			Item[] array = new Item[0];
			if (ShopItems != null)
			{
				IEnumerator enumerator = ShopItems.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is Hashtable))
					{
						obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
					}
					Hashtable hashtable = (Hashtable)obj;
					if (hashtable != null)
					{
						Item item = new Item();
						item.TypeValue = (EnumMasterTypeValues)RuntimeServices.UnboxInt32(hashtable["TypeValue"]);
						item.Quantity = RuntimeServices.UnboxInt32(hashtable["Quantity"]);
						item.ItemId = RuntimeServices.UnboxInt32(hashtable["ItemId"]);
						item.Level = RuntimeServices.UnboxInt32(hashtable["Level"]);
						array = (Item[])RuntimeServices.AddArrays(typeof(Item), array, new Item[1] { item });
					}
				}
			}
			return array;
		}
	}
}
