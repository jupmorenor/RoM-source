using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MInAppProducts : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024ProductIdCode;

	public string _0024var_0024Name;

	public int _0024var_0024Price;

	public int _0024var_0024Quantity;

	public float _0024var_0024Sort;

	public EnumMarketTypeValues _0024var_0024MarketTypeValue;

	public EnumProductSalesTypeValues _0024var_0024ProductSalesTypeValue;

	public int _0024var_0024ProductSalesLimitCount;

	public DateTime _0024var_0024BeginDate;

	public DateTime _0024var_0024EndDate;

	[NonSerialized]
	private static Dictionary<int, MInAppProducts> _0024mst_002483 = new Dictionary<int, MInAppProducts>();

	[NonSerialized]
	private static MInAppProducts[] All_cache;

	public int Id => _0024var_0024Id;

	public string ProductIdCode => _0024var_0024ProductIdCode;

	public string Name => _0024var_0024Name;

	public int Price => _0024var_0024Price;

	public int Quantity => _0024var_0024Quantity;

	public float Sort => _0024var_0024Sort;

	public EnumMarketTypeValues MarketTypeValue => _0024var_0024MarketTypeValue;

	public EnumProductSalesTypeValues ProductSalesTypeValue => _0024var_0024ProductSalesTypeValue;

	public int ProductSalesLimitCount => _0024var_0024ProductSalesLimitCount;

	public DateTime BeginDate => _0024var_0024BeginDate;

	public DateTime EndDate => _0024var_0024EndDate;

	public static MInAppProducts[] All
	{
		get
		{
			MInAppProducts[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MInAppProducts");
				MInAppProducts[] array = (MInAppProducts[])Builtins.array(typeof(MInAppProducts), _0024mst_002483.Values);
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

	public MInAppProducts()
	{
		_0024var_0024BeginDate = DateTime.Parse("2001/01/01");
		_0024var_0024EndDate = DateTime.Parse("2099/01/01");
	}

	public static MInAppProducts Get(int _id)
	{
		MerlinMaster.GetHandler("MInAppProducts");
		return (!_0024mst_002483.ContainsKey(_id)) ? null : _0024mst_002483[_id];
	}

	public static void Unload()
	{
		_0024mst_002483.Clear();
		All_cache = null;
	}

	public static MInAppProducts New(Hashtable data)
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
			MInAppProducts mInAppProducts = Create(data);
			if (!_0024mst_002483.ContainsKey(mInAppProducts.Id))
			{
				_0024mst_002483[mInAppProducts.Id] = mInAppProducts;
			}
			result = mInAppProducts;
		}
		return (MInAppProducts)result;
	}

	public static MInAppProducts New2(string[] keys, object[] vals)
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
		return (MInAppProducts)result;
	}

	public static MInAppProducts Entry(MInAppProducts mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002483[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MInAppProducts)result;
	}

	public static void AddMst(MInAppProducts mst)
	{
		if (mst != null)
		{
			_0024mst_002483[mst.Id] = mst;
		}
	}

	public static MInAppProducts Create(Hashtable data)
	{
		MInAppProducts mInAppProducts = new MInAppProducts();
		MInAppProducts result;
		if (data == null)
		{
			result = mInAppProducts;
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
				mInAppProducts.setField((string)obj, data[current]);
			}
			result = mInAppProducts;
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
		case "ProductIdCode":
			_0024var_0024ProductIdCode = MasterBaseClass.ToStringValue(val);
			break;
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		case "Price":
			_0024var_0024Price = MasterBaseClass.ToInt(val);
			break;
		case "Quantity":
			_0024var_0024Quantity = MasterBaseClass.ToInt(val);
			break;
		case "Sort":
			_0024var_0024Sort = MasterBaseClass.ToSingle(val);
			break;
		case "MarketTypeValue":
			if (typeof(EnumMarketTypeValues).IsEnum)
			{
				_0024var_0024MarketTypeValue = (EnumMarketTypeValues)MasterBaseClass.ToEnum(val);
			}
			break;
		case "ProductSalesTypeValue":
			if (typeof(EnumProductSalesTypeValues).IsEnum)
			{
				_0024var_0024ProductSalesTypeValue = (EnumProductSalesTypeValues)MasterBaseClass.ToEnum(val);
			}
			break;
		case "ProductSalesLimitCount":
			_0024var_0024ProductSalesLimitCount = MasterBaseClass.ToInt(val);
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
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"ProductIdCode" => true, 
			"Name" => true, 
			"Price" => true, 
			"Quantity" => true, 
			"Sort" => true, 
			"MarketTypeValue" => true, 
			"ProductSalesTypeValue" => true, 
			"ProductSalesLimitCount" => true, 
			"BeginDate" => true, 
			"EndDate" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[11]
		{
			"Id", "ProductIdCode", "Name", "Price", "Quantity", "Sort", "MarketTypeValue", "ProductSalesTypeValue", "ProductSalesLimitCount", "BeginDate",
			"EndDate"
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
					_0024var_0024ProductIdCode = vals[1];
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
							_0024var_0024Price = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024Quantity = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Sort = MasterBaseClass.ParseSingle(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null && typeof(EnumMarketTypeValues).IsEnum)
									{
										_0024var_0024MarketTypeValue = (EnumMarketTypeValues)MasterBaseClass.ParseEnum(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null && typeof(EnumProductSalesTypeValues).IsEnum)
										{
											_0024var_0024ProductSalesTypeValue = (EnumProductSalesTypeValues)MasterBaseClass.ParseEnum(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024ProductSalesLimitCount = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024BeginDate = MasterBaseClass.ParseDateTime(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024EndDate = MasterBaseClass.ParseDateTime(vals[10]);
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
