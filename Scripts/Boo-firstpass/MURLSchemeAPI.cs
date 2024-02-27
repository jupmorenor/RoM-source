using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MURLSchemeAPI : MerlinMaster
{
	public int _0024var_0024Id;

	public bool _0024var_0024IsFFRK;

	public DateTime _0024var_0024EndDate;

	[NonSerialized]
	private static Dictionary<int, MURLSchemeAPI> _0024mst_0024156 = new Dictionary<int, MURLSchemeAPI>();

	[NonSerialized]
	private static MURLSchemeAPI[] All_cache;

	public int Id => _0024var_0024Id;

	public bool IsFFRK => _0024var_0024IsFFRK;

	public DateTime EndDate => _0024var_0024EndDate;

	public static MURLSchemeAPI[] All
	{
		get
		{
			MURLSchemeAPI[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MURLSchemeAPI");
				MURLSchemeAPI[] array = (MURLSchemeAPI[])Builtins.array(typeof(MURLSchemeAPI), _0024mst_0024156.Values);
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

	public static bool IsFFRKExpired()
	{
		int num = 0;
		MURLSchemeAPI[] all = All;
		int length = all.Length;
		int result;
		while (true)
		{
			if (num < length)
			{
				if (all[num].IsFFRK)
				{
					result = ((MerlinDateTime.UtcNow > all[num].EndDate) ? 1 : 0);
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = 0;
			break;
		}
		return (byte)result != 0;
	}

	public static MURLSchemeAPI Get(int _id)
	{
		MerlinMaster.GetHandler("MURLSchemeAPI");
		return (!_0024mst_0024156.ContainsKey(_id)) ? null : _0024mst_0024156[_id];
	}

	public static void Unload()
	{
		_0024mst_0024156.Clear();
		All_cache = null;
	}

	public static MURLSchemeAPI New(Hashtable data)
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
			MURLSchemeAPI mURLSchemeAPI = Create(data);
			if (!_0024mst_0024156.ContainsKey(mURLSchemeAPI.Id))
			{
				_0024mst_0024156[mURLSchemeAPI.Id] = mURLSchemeAPI;
			}
			result = mURLSchemeAPI;
		}
		return (MURLSchemeAPI)result;
	}

	public static MURLSchemeAPI New2(string[] keys, object[] vals)
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
		return (MURLSchemeAPI)result;
	}

	public static MURLSchemeAPI Entry(MURLSchemeAPI mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024156[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MURLSchemeAPI)result;
	}

	public static void AddMst(MURLSchemeAPI mst)
	{
		if (mst != null)
		{
			_0024mst_0024156[mst.Id] = mst;
		}
	}

	public static MURLSchemeAPI Create(Hashtable data)
	{
		MURLSchemeAPI mURLSchemeAPI = new MURLSchemeAPI();
		MURLSchemeAPI result;
		if (data == null)
		{
			result = mURLSchemeAPI;
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
				mURLSchemeAPI.setField((string)obj, data[current]);
			}
			result = mURLSchemeAPI;
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
		case "IsFFRK":
			_0024var_0024IsFFRK = MasterBaseClass.ToBool(val);
			break;
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
			"IsFFRK" => true, 
			"EndDate" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[3] { "Id", "IsFFRK", "EndDate" });
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
					_0024var_0024IsFFRK = MasterBaseClass.ParseBool(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024EndDate = MasterBaseClass.ParseDateTime(vals[2]);
					}
					int num = 3;
					result = num;
				}
			}
		}
		return result;
	}
}
