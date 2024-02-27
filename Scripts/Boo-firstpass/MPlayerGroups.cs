using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MPlayerGroups : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024Digit;

	public int _0024var_0024PlayerGroupId;

	[NonSerialized]
	private static Dictionary<int, MPlayerGroups> _0024mst_002496 = new Dictionary<int, MPlayerGroups>();

	[NonSerialized]
	private static MPlayerGroups[] All_cache;

	public int Id => _0024var_0024Id;

	public int Digit => _0024var_0024Digit;

	public int PlayerGroupId => _0024var_0024PlayerGroupId;

	public static MPlayerGroups[] All
	{
		get
		{
			MPlayerGroups[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MPlayerGroups");
				MPlayerGroups[] array = (MPlayerGroups[])Builtins.array(typeof(MPlayerGroups), _0024mst_002496.Values);
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

	public static MPlayerGroups Get(int _id)
	{
		MerlinMaster.GetHandler("MPlayerGroups");
		return (!_0024mst_002496.ContainsKey(_id)) ? null : _0024mst_002496[_id];
	}

	public static void Unload()
	{
		_0024mst_002496.Clear();
		All_cache = null;
	}

	public static MPlayerGroups New(Hashtable data)
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
			MPlayerGroups mPlayerGroups = Create(data);
			if (!_0024mst_002496.ContainsKey(mPlayerGroups.Id))
			{
				_0024mst_002496[mPlayerGroups.Id] = mPlayerGroups;
			}
			result = mPlayerGroups;
		}
		return (MPlayerGroups)result;
	}

	public static MPlayerGroups New2(string[] keys, object[] vals)
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
		return (MPlayerGroups)result;
	}

	public static MPlayerGroups Entry(MPlayerGroups mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002496[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MPlayerGroups)result;
	}

	public static void AddMst(MPlayerGroups mst)
	{
		if (mst != null)
		{
			_0024mst_002496[mst.Id] = mst;
		}
	}

	public static MPlayerGroups Create(Hashtable data)
	{
		MPlayerGroups mPlayerGroups = new MPlayerGroups();
		MPlayerGroups result;
		if (data == null)
		{
			result = mPlayerGroups;
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
				mPlayerGroups.setField((string)obj, data[current]);
			}
			result = mPlayerGroups;
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
		case "Digit":
			_0024var_0024Digit = MasterBaseClass.ToInt(val);
			break;
		case "PlayerGroupId":
			_0024var_0024PlayerGroupId = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Digit" => true, 
			"PlayerGroupId" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[3] { "Id", "Digit", "PlayerGroupId" });
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
					_0024var_0024Digit = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024PlayerGroupId = MasterBaseClass.ParseInt(vals[2]);
					}
					int num = 3;
					result = num;
				}
			}
		}
		return result;
	}
}
