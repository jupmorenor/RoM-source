using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MShopItems : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024ShopTypeValue;

	public string _0024var_0024Name;

	public string _0024var_0024Explain;

	public int _0024var_0024Price;

	public int _0024var_0024MItemGroupId;

	public DateTime _0024var_0024BeginDate;

	public DateTime _0024var_0024EndDate;

	public int _0024var_0024MPointId;

	public int _0024var_0024Sort;

	public int _0024var_0024PointStoreDispTypeValue;

	[NonSerialized]
	private MItemGroups MItemGroupId__cache;

	[NonSerialized]
	private MPoints MPointId__cache;

	[NonSerialized]
	private static Dictionary<int, MShopItems> _0024mst_0024125 = new Dictionary<int, MShopItems>();

	[NonSerialized]
	private static MShopItems[] All_cache;

	public int Id => _0024var_0024Id;

	public int ShopTypeValue => _0024var_0024ShopTypeValue;

	public string Name => _0024var_0024Name;

	public string Explain => _0024var_0024Explain;

	public int Price => _0024var_0024Price;

	public MItemGroups MItemGroupId
	{
		get
		{
			if (MItemGroupId__cache == null)
			{
				MItemGroupId__cache = MItemGroups.Get(_0024var_0024MItemGroupId);
			}
			return MItemGroupId__cache;
		}
	}

	public DateTime BeginDate => _0024var_0024BeginDate;

	public DateTime EndDate => _0024var_0024EndDate;

	public MPoints MPointId
	{
		get
		{
			if (MPointId__cache == null)
			{
				MPointId__cache = MPoints.Get(_0024var_0024MPointId);
			}
			return MPointId__cache;
		}
	}

	public int Sort => _0024var_0024Sort;

	public int PointStoreDispTypeValue => _0024var_0024PointStoreDispTypeValue;

	public static MShopItems[] All
	{
		get
		{
			MShopItems[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MShopItems");
				MShopItems[] array = (MShopItems[])Builtins.array(typeof(MShopItems), _0024mst_0024125.Values);
				if (array.Length > 0)
				{
					All_cache = array;
					result = All_cache;
				}
				else
				{
					result = array;
				}
			}
			else
			{
				result = All_cache;
			}
			return result;
		}
	}

	public MShopItems()
	{
		_0024var_0024Price = 1;
		_0024var_0024BeginDate = DateTime.Parse("2001/01/01");
		_0024var_0024EndDate = DateTime.Parse("2001/01/01");
	}

	public override string ToString()
	{
		return new StringBuilder("MShopItems(").Append((object)Id).Append(",Name:").Append(Name)
			.Append(",Price:")
			.Append((object)Price)
			.Append(",MItemGroups:")
			.Append(MItemGroupId)
			.Append(",BeginDate:")
			.Append(BeginDate)
			.Append(",EndDate:")
			.Append(EndDate)
			.Append(")")
			.ToString();
	}

	public static MShopItems Get(int _id)
	{
		MerlinMaster.GetHandler("MShopItems");
		return (!_0024mst_0024125.ContainsKey(_id)) ? null : _0024mst_0024125[_id];
	}

	public static void Unload()
	{
		_0024mst_0024125.Clear();
		All_cache = null;
	}

	public static MShopItems New(Hashtable data)
	{
		object result;
		if (data == null || data.Count <= 0)
		{
			result = null;
		}
		else if (!data.ContainsKey("Id"))
		{
			result = null;
		}
		else
		{
			MShopItems mShopItems = Create(data);
			if (!_0024mst_0024125.ContainsKey(mShopItems.Id))
			{
				_0024mst_0024125[mShopItems.Id] = mShopItems;
			}
			result = mShopItems;
		}
		return (MShopItems)result;
	}

	public static MShopItems New2(string[] keys, object[] vals)
	{
		object result;
		if (keys == null || vals == null)
		{
			result = null;
		}
		else if (keys.Length <= 0 || vals.Length <= 0)
		{
			result = null;
		}
		else
		{
			Hashtable hashtable = new Hashtable();
			int num = ((vals.Length >= keys.Length) ? keys.Length : vals.Length);
			int num2 = 0;
			int num3 = num;
			if (num3 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num2 < num3)
			{
				int index = num2;
				num2++;
				hashtable[keys[RuntimeServices.NormalizeArrayIndex(keys, index)]] = vals[RuntimeServices.NormalizeArrayIndex(vals, index)];
			}
			result = New(hashtable);
		}
		return (MShopItems)result;
	}

	public static MShopItems Entry(MShopItems mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024125[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MShopItems)result;
	}

	public static void AddMst(MShopItems mst)
	{
		if (mst != null)
		{
			_0024mst_0024125[mst.Id] = mst;
		}
	}

	public static MShopItems Create(Hashtable data)
	{
		MShopItems mShopItems = new MShopItems();
		MShopItems result;
		if (data == null)
		{
			result = mShopItems;
		}
		else
		{
			IEnumerator enumerator = data.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				object obj = current;
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				mShopItems.setField((string)obj, data[current]);
			}
			result = mShopItems;
		}
		return result;
	}

	public void setField(string key, object val)
	{
		switch (key)
		{
		case "Id":
			_0024var_0024Id = MasterBaseClass.ToInt(val);
			break;
		case "ShopTypeValue":
			_0024var_0024ShopTypeValue = MasterBaseClass.ToInt(val);
			break;
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		case "Explain":
			_0024var_0024Explain = MasterBaseClass.ToStringValue(val);
			break;
		case "Price":
			_0024var_0024Price = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupId":
			_0024var_0024MItemGroupId = MasterBaseClass.ToInt(val);
			break;
		case "BeginDate":
		{
			object obj2 = val;
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			_0024var_0024BeginDate = DateTime.Parse((string)obj2);
			break;
		}
		case "EndDate":
		{
			object obj = val;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			_0024var_0024EndDate = DateTime.Parse((string)obj);
			break;
		}
		case "MPointId":
			_0024var_0024MPointId = MasterBaseClass.ToInt(val);
			break;
		case "Sort":
			_0024var_0024Sort = MasterBaseClass.ToInt(val);
			break;
		case "PointStoreDispTypeValue":
			_0024var_0024PointStoreDispTypeValue = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"ShopTypeValue" => true, 
			"Name" => true, 
			"Explain" => true, 
			"Price" => true, 
			"MItemGroupId" => true, 
			"BeginDate" => true, 
			"EndDate" => true, 
			"MPointId" => true, 
			"Sort" => true, 
			"PointStoreDispTypeValue" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[11]
		{
			"Id", "ShopTypeValue", "Name", "Explain", "Price", "MItemGroupId", "BeginDate", "EndDate", "MPointId", "Sort",
			"PointStoreDispTypeValue"
		});
	}

	public int setStringValues(string[] vals)
	{
		int length = vals.Length;
		int result;
		if (length <= 0)
		{
			result = 0;
		}
		else
		{
			if (vals[0] != null)
			{
				_0024var_0024Id = MasterBaseClass.ParseInt(vals[0]);
			}
			if (length <= 1)
			{
				result = 1;
			}
			else
			{
				if (vals[1] != null)
				{
					_0024var_0024ShopTypeValue = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024Name = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Explain = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024Price = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024MItemGroupId = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024BeginDate = MasterBaseClass.ParseDateTime(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024EndDate = MasterBaseClass.ParseDateTime(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024MPointId = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024Sort = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024PointStoreDispTypeValue = MasterBaseClass.ParseInt(vals[10]);
													}
													int num = 11;
													result = num;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		return result;
	}
}
