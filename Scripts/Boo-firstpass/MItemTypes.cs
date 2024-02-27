using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MItemTypes : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024ItemTypeName;

	[NonSerialized]
	private static Dictionary<int, MItemTypes> _0024mst_002482 = new Dictionary<int, MItemTypes>();

	[NonSerialized]
	private static MItemTypes[] All_cache;

	public int Id => _0024var_0024Id;

	public string ItemTypeName => _0024var_0024ItemTypeName;

	public static MItemTypes[] All
	{
		get
		{
			MItemTypes[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MItemTypes");
				MItemTypes[] array = (MItemTypes[])Builtins.array(typeof(MItemTypes), _0024mst_002482.Values);
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

	public static MItemTypes Get(int _id)
	{
		MerlinMaster.GetHandler("MItemTypes");
		return (!_0024mst_002482.ContainsKey(_id)) ? null : _0024mst_002482[_id];
	}

	public static void Unload()
	{
		_0024mst_002482.Clear();
		All_cache = null;
	}

	public static MItemTypes New(Hashtable data)
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
			MItemTypes mItemTypes = Create(data);
			if (!_0024mst_002482.ContainsKey(mItemTypes.Id))
			{
				_0024mst_002482[mItemTypes.Id] = mItemTypes;
			}
			result = mItemTypes;
		}
		return (MItemTypes)result;
	}

	public static MItemTypes New2(string[] keys, object[] vals)
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
		return (MItemTypes)result;
	}

	public static MItemTypes Entry(MItemTypes mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002482[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MItemTypes)result;
	}

	public static void AddMst(MItemTypes mst)
	{
		if (mst != null)
		{
			_0024mst_002482[mst.Id] = mst;
		}
	}

	public static MItemTypes Create(Hashtable data)
	{
		MItemTypes mItemTypes = new MItemTypes();
		MItemTypes result;
		if (data == null)
		{
			result = mItemTypes;
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
				mItemTypes.setField((string)obj, data[current]);
			}
			result = mItemTypes;
		}
		return result;
	}

	public void setField(string key, object val)
	{
		if (key == "Id")
		{
			_0024var_0024Id = MasterBaseClass.ToInt(val);
		}
		else if (key == "ItemTypeName")
		{
			_0024var_0024ItemTypeName = MasterBaseClass.ToStringValue(val);
		}
	}

	public static bool HasKey(string key)
	{
		return key == "Id" || key == "ItemTypeName";
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[2] { "Id", "ItemTypeName" });
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
					_0024var_0024ItemTypeName = vals[1];
				}
				int num = 2;
				result = num;
			}
		}
		return result;
	}
}
