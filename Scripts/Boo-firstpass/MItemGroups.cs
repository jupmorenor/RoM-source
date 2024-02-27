using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MItemGroups : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public string _0024var_0024Title;

	public string _0024var_0024Explain;

	public string _0024var_0024ItemInfo;

	[NonSerialized]
	public static Hashtable MItemGroupChildIds = new Hashtable();

	[NonSerialized]
	public static bool isCreateAllChildIds;

	[NonSerialized]
	private static Dictionary<int, MItemGroups> _0024mst_002480 = new Dictionary<int, MItemGroups>();

	[NonSerialized]
	private static MItemGroups[] All_cache;

	public int Id => _0024var_0024Id;

	public string Name => _0024var_0024Name;

	public string Title => _0024var_0024Title;

	public string Explain => _0024var_0024Explain;

	public string ItemInfo => _0024var_0024ItemInfo;

	public static MItemGroups[] All
	{
		get
		{
			MItemGroups[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MItemGroups");
				MItemGroups[] array = (MItemGroups[])Builtins.array(typeof(MItemGroups), _0024mst_002480.Values);
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

	public MItemGroups()
	{
		_0024var_0024Title = string.Empty;
		_0024var_0024Explain = string.Empty;
		_0024var_0024ItemInfo = string.Empty;
	}

	public override string ToString()
	{
		return new StringBuilder("MItemGroupos(").Append((object)Id).Append(":").Append(Name)
			.Append(")")
			.ToString();
	}

	public static MItemGroups Get(int _id)
	{
		MerlinMaster.GetHandler("MItemGroups");
		return (!_0024mst_002480.ContainsKey(_id)) ? null : _0024mst_002480[_id];
	}

	public static void Unload()
	{
		_0024mst_002480.Clear();
		All_cache = null;
	}

	public static MItemGroups New(Hashtable data)
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
			MItemGroups mItemGroups = Create(data);
			if (!_0024mst_002480.ContainsKey(mItemGroups.Id))
			{
				_0024mst_002480[mItemGroups.Id] = mItemGroups;
			}
			result = mItemGroups;
		}
		return (MItemGroups)result;
	}

	public static MItemGroups New2(string[] keys, object[] vals)
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
		return (MItemGroups)result;
	}

	public static MItemGroups Entry(MItemGroups mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002480[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MItemGroups)result;
	}

	public static void AddMst(MItemGroups mst)
	{
		if (mst != null)
		{
			_0024mst_002480[mst.Id] = mst;
		}
	}

	public static MItemGroups Create(Hashtable data)
	{
		MItemGroups mItemGroups = new MItemGroups();
		MItemGroups result;
		if (data == null)
		{
			result = mItemGroups;
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
				mItemGroups.setField((string)obj, data[current]);
			}
			result = mItemGroups;
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
		case "Title":
			_0024var_0024Title = MasterBaseClass.ToStringValue(val);
			break;
		case "Explain":
			_0024var_0024Explain = MasterBaseClass.ToStringValue(val);
			break;
		case "ItemInfo":
			_0024var_0024ItemInfo = MasterBaseClass.ToStringValue(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Name" => true, 
			"Title" => true, 
			"Explain" => true, 
			"ItemInfo" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[5] { "Id", "Name", "Title", "Explain", "ItemInfo" });
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
						_0024var_0024Title = vals[2];
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
								_0024var_0024ItemInfo = vals[4];
							}
							int num = 5;
							result = num;
						}
					}
				}
			}
		}
		return result;
	}
}
