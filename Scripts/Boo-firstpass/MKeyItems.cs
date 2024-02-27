using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MKeyItems : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public string _0024var_0024Progname;

	public string _0024var_0024Description;

	public string _0024var_0024Icon;

	public int _0024var_0024Point;

	[NonSerialized]
	private static Dictionary<int, MKeyItems> _0024mst_002479 = new Dictionary<int, MKeyItems>();

	[NonSerialized]
	private static MKeyItems[] All_cache;

	public int Id => _0024var_0024Id;

	public string Name => _0024var_0024Name;

	public string Progname => _0024var_0024Progname;

	public string Description => _0024var_0024Description;

	public string Icon => _0024var_0024Icon;

	public int Point => _0024var_0024Point;

	public static MKeyItems[] All
	{
		get
		{
			MKeyItems[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MKeyItems");
				MKeyItems[] array = (MKeyItems[])Builtins.array(typeof(MKeyItems), _0024mst_002479.Values);
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

	public MKeyItems()
	{
		_0024var_0024Point = 1;
	}

	public static MKeyItems Get(int _id)
	{
		MerlinMaster.GetHandler("MKeyItems");
		return (!_0024mst_002479.ContainsKey(_id)) ? null : _0024mst_002479[_id];
	}

	public static void Unload()
	{
		_0024mst_002479.Clear();
		All_cache = null;
	}

	public static MKeyItems New(Hashtable data)
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
			MKeyItems mKeyItems = Create(data);
			if (!_0024mst_002479.ContainsKey(mKeyItems.Id))
			{
				_0024mst_002479[mKeyItems.Id] = mKeyItems;
			}
			result = mKeyItems;
		}
		return (MKeyItems)result;
	}

	public static MKeyItems New2(string[] keys, object[] vals)
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
		return (MKeyItems)result;
	}

	public static MKeyItems Entry(MKeyItems mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002479[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MKeyItems)result;
	}

	public static void AddMst(MKeyItems mst)
	{
		if (mst != null)
		{
			_0024mst_002479[mst.Id] = mst;
		}
	}

	public static MKeyItems Create(Hashtable data)
	{
		MKeyItems mKeyItems = new MKeyItems();
		MKeyItems result;
		if (data == null)
		{
			result = mKeyItems;
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
				mKeyItems.setField((string)obj, data[current]);
			}
			result = mKeyItems;
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
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		case "Progname":
			_0024var_0024Progname = MasterBaseClass.ToStringValue(val);
			break;
		case "Description":
			_0024var_0024Description = MasterBaseClass.ToStringValue(val);
			break;
		case "Icon":
			_0024var_0024Icon = MasterBaseClass.ToStringValue(val);
			break;
		case "Point":
			_0024var_0024Point = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Name" => true, 
			"Progname" => true, 
			"Description" => true, 
			"Icon" => true, 
			"Point" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[6] { "Id", "Name", "Progname", "Description", "Icon", "Point" });
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
					_0024var_0024Name = vals[1];
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024Progname = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Description = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024Icon = vals[4];
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Point = MasterBaseClass.ParseInt(vals[5]);
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
