using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MPlayerDeckSupports : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MPlayerDeckMainId;

	public Deck2FormTypes _0024var_0024FormType;

	public Deck2ItemTypes _0024var_0024ItemType;

	public int _0024var_0024No;

	public int _0024var_0024ItemId;

	[NonSerialized]
	private MPlayerDeckMains MPlayerDeckMainId__cache;

	[NonSerialized]
	private static Dictionary<int, MPlayerDeckSupports> _0024mst_0024121 = new Dictionary<int, MPlayerDeckSupports>();

	[NonSerialized]
	private static MPlayerDeckSupports[] All_cache;

	public int Id => _0024var_0024Id;

	public MPlayerDeckMains MPlayerDeckMainId
	{
		get
		{
			if (MPlayerDeckMainId__cache == null)
			{
				MPlayerDeckMainId__cache = MPlayerDeckMains.Get(_0024var_0024MPlayerDeckMainId);
			}
			return MPlayerDeckMainId__cache;
		}
	}

	public Deck2FormTypes FormType => _0024var_0024FormType;

	public Deck2ItemTypes ItemType => _0024var_0024ItemType;

	public int No => _0024var_0024No;

	public int ItemId => _0024var_0024ItemId;

	public static MPlayerDeckSupports[] All
	{
		get
		{
			MPlayerDeckSupports[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MPlayerDeckSupports");
				MPlayerDeckSupports[] array = (MPlayerDeckSupports[])Builtins.array(typeof(MPlayerDeckSupports), _0024mst_0024121.Values);
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

	public static MPlayerDeckSupports Get(int _id)
	{
		MerlinMaster.GetHandler("MPlayerDeckSupports");
		return (!_0024mst_0024121.ContainsKey(_id)) ? null : _0024mst_0024121[_id];
	}

	public static void Unload()
	{
		_0024mst_0024121.Clear();
		All_cache = null;
	}

	public static MPlayerDeckSupports New(Hashtable data)
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
			MPlayerDeckSupports mPlayerDeckSupports = Create(data);
			if (!_0024mst_0024121.ContainsKey(mPlayerDeckSupports.Id))
			{
				_0024mst_0024121[mPlayerDeckSupports.Id] = mPlayerDeckSupports;
			}
			result = mPlayerDeckSupports;
		}
		return (MPlayerDeckSupports)result;
	}

	public static MPlayerDeckSupports New2(string[] keys, object[] vals)
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
		return (MPlayerDeckSupports)result;
	}

	public static MPlayerDeckSupports Entry(MPlayerDeckSupports mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024121[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MPlayerDeckSupports)result;
	}

	public static void AddMst(MPlayerDeckSupports mst)
	{
		if (mst != null)
		{
			_0024mst_0024121[mst.Id] = mst;
		}
	}

	public static MPlayerDeckSupports Create(Hashtable data)
	{
		MPlayerDeckSupports mPlayerDeckSupports = new MPlayerDeckSupports();
		MPlayerDeckSupports result;
		if (data == null)
		{
			result = mPlayerDeckSupports;
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
				mPlayerDeckSupports.setField((string)obj, data[current]);
			}
			result = mPlayerDeckSupports;
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
		case "MPlayerDeckMainId":
			_0024var_0024MPlayerDeckMainId = MasterBaseClass.ToInt(val);
			break;
		case "FormType":
			if (typeof(Deck2FormTypes).IsEnum)
			{
				_0024var_0024FormType = (Deck2FormTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "ItemType":
			if (typeof(Deck2ItemTypes).IsEnum)
			{
				_0024var_0024ItemType = (Deck2ItemTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "No":
			_0024var_0024No = MasterBaseClass.ToInt(val);
			break;
		case "ItemId":
			_0024var_0024ItemId = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"MPlayerDeckMainId" => true, 
			"FormType" => true, 
			"ItemType" => true, 
			"No" => true, 
			"ItemId" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[6] { "Id", "MPlayerDeckMainId", "FormType", "ItemType", "No", "ItemId" });
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
					_0024var_0024MPlayerDeckMainId = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null && typeof(Deck2FormTypes).IsEnum)
					{
						_0024var_0024FormType = (Deck2FormTypes)MasterBaseClass.ParseEnum(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null && typeof(Deck2ItemTypes).IsEnum)
						{
							_0024var_0024ItemType = (Deck2ItemTypes)MasterBaseClass.ParseEnum(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024No = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024ItemId = MasterBaseClass.ParseInt(vals[5]);
								}
								int num = 6;
								result = num;
							}
						}
					}
				}
			}
		}
		return result;
	}
}
