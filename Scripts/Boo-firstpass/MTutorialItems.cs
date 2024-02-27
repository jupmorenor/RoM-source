using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MTutorialItems : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	public int _0024var_0024MItemGroupId;

	public string _0024var_0024Remarks;

	[NonSerialized]
	private MItemGroups MItemGroupId__cache;

	[NonSerialized]
	private static Dictionary<int, MTutorialItems> _0024mst_0024108 = new Dictionary<int, MTutorialItems>();

	[NonSerialized]
	private static MTutorialItems[] All_cache;

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

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

	public string Remarks => _0024var_0024Remarks;

	public static MTutorialItems[] All
	{
		get
		{
			MTutorialItems[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MTutorialItems");
				MTutorialItems[] array = (MTutorialItems[])Builtins.array(typeof(MTutorialItems), _0024mst_0024108.Values);
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

	public static MTutorialItems FindByName(string n)
	{
		int num = 0;
		MTutorialItems[] all = All;
		int length = all.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (all[num].Progname == n)
				{
					result = all[num];
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = null;
			break;
		}
		return (MTutorialItems)result;
	}

	public override string ToString()
	{
		return new StringBuilder("MTutorialItems(").Append((object)Id).Append(",").Append(MItemGroupId)
			.Append(")")
			.ToString();
	}

	public static MTutorialItems Get(int _id)
	{
		MerlinMaster.GetHandler("MTutorialItems");
		return (!_0024mst_0024108.ContainsKey(_id)) ? null : _0024mst_0024108[_id];
	}

	public static void Unload()
	{
		_0024mst_0024108.Clear();
		All_cache = null;
	}

	public static MTutorialItems New(Hashtable data)
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
			MTutorialItems mTutorialItems = Create(data);
			if (!_0024mst_0024108.ContainsKey(mTutorialItems.Id))
			{
				_0024mst_0024108[mTutorialItems.Id] = mTutorialItems;
			}
			result = mTutorialItems;
		}
		return (MTutorialItems)result;
	}

	public static MTutorialItems New2(string[] keys, object[] vals)
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
		return (MTutorialItems)result;
	}

	public static MTutorialItems Entry(MTutorialItems mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024108[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MTutorialItems)result;
	}

	public static void AddMst(MTutorialItems mst)
	{
		if (mst != null)
		{
			_0024mst_0024108[mst.Id] = mst;
		}
	}

	public static MTutorialItems Create(Hashtable data)
	{
		MTutorialItems mTutorialItems = new MTutorialItems();
		MTutorialItems result;
		if (data == null)
		{
			result = mTutorialItems;
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
				mTutorialItems.setField((string)obj, data[current]);
			}
			result = mTutorialItems;
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
		case "Progname":
			_0024var_0024Progname = MasterBaseClass.ToStringValue(val);
			break;
		case "MItemGroupId":
			_0024var_0024MItemGroupId = MasterBaseClass.ToInt(val);
			break;
		case "Remarks":
			_0024var_0024Remarks = MasterBaseClass.ToStringValue(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Progname" => true, 
			"MItemGroupId" => true, 
			"Remarks" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[4] { "Id", "Progname", "MItemGroupId", "Remarks" });
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
					_0024var_0024Progname = vals[1];
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024MItemGroupId = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Remarks = vals[3];
						}
						int num = 4;
						result = num;
					}
				}
			}
		}
		return result;
	}
}
