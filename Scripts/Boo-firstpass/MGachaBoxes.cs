using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MGachaBoxes : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MGachaId;

	public int _0024var_0024AvailableGetNum;

	[NonSerialized]
	private MGachas MGachaId__cache;

	[NonSerialized]
	private static Dictionary<int, MGachaBoxes> _0024mst_002449 = new Dictionary<int, MGachaBoxes>();

	[NonSerialized]
	private static MGachaBoxes[] All_cache;

	public int Id => _0024var_0024Id;

	public MGachas MGachaId
	{
		get
		{
			if (MGachaId__cache == null)
			{
				MGachaId__cache = MGachas.Get(_0024var_0024MGachaId);
			}
			return MGachaId__cache;
		}
	}

	public int AvailableGetNum => _0024var_0024AvailableGetNum;

	public static MGachaBoxes[] All
	{
		get
		{
			MGachaBoxes[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MGachaBoxes");
				MGachaBoxes[] array = (MGachaBoxes[])Builtins.array(typeof(MGachaBoxes), _0024mst_002449.Values);
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

	public static MGachaBoxes Get(int _id)
	{
		MerlinMaster.GetHandler("MGachaBoxes");
		return (!_0024mst_002449.ContainsKey(_id)) ? null : _0024mst_002449[_id];
	}

	public static void Unload()
	{
		_0024mst_002449.Clear();
		All_cache = null;
	}

	public static MGachaBoxes New(Hashtable data)
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
			MGachaBoxes mGachaBoxes = Create(data);
			if (!_0024mst_002449.ContainsKey(mGachaBoxes.Id))
			{
				_0024mst_002449[mGachaBoxes.Id] = mGachaBoxes;
			}
			result = mGachaBoxes;
		}
		return (MGachaBoxes)result;
	}

	public static MGachaBoxes New2(string[] keys, object[] vals)
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
		return (MGachaBoxes)result;
	}

	public static MGachaBoxes Entry(MGachaBoxes mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002449[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MGachaBoxes)result;
	}

	public static void AddMst(MGachaBoxes mst)
	{
		if (mst != null)
		{
			_0024mst_002449[mst.Id] = mst;
		}
	}

	public static MGachaBoxes Create(Hashtable data)
	{
		MGachaBoxes mGachaBoxes = new MGachaBoxes();
		MGachaBoxes result;
		if (data == null)
		{
			result = mGachaBoxes;
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
				mGachaBoxes.setField((string)obj, data[current]);
			}
			result = mGachaBoxes;
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
		case "MGachaId":
			_0024var_0024MGachaId = MasterBaseClass.ToInt(val);
			break;
		case "AvailableGetNum":
			_0024var_0024AvailableGetNum = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"MGachaId" => true, 
			"AvailableGetNum" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[3] { "Id", "MGachaId", "AvailableGetNum" });
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
					_0024var_0024MGachaId = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024AvailableGetNum = MasterBaseClass.ParseInt(vals[2]);
					}
					int num = 3;
					result = num;
				}
			}
		}
		return result;
	}
}
