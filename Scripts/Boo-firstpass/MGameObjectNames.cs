using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MGameObjectNames : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	public string _0024var_0024GameObjectName;

	[NonSerialized]
	private static Dictionary<int, MGameObjectNames> _0024mst_002430 = new Dictionary<int, MGameObjectNames>();

	[NonSerialized]
	private static MGameObjectNames[] All_cache;

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

	public string GameObjectName => _0024var_0024GameObjectName;

	public static MGameObjectNames[] All
	{
		get
		{
			MGameObjectNames[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MGameObjectNames");
				MGameObjectNames[] array = (MGameObjectNames[])Builtins.array(typeof(MGameObjectNames), _0024mst_002430.Values);
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

	public static string ObjectName(EnumGameObjectNames e)
	{
		MGameObjectNames mGameObjectNames = Get((int)e);
		return (mGameObjectNames == null) ? "unknown" : mGameObjectNames.GameObjectName;
	}

	public static MGameObjectNames Get(int _id)
	{
		MerlinMaster.GetHandler("MGameObjectNames");
		return (!_0024mst_002430.ContainsKey(_id)) ? null : _0024mst_002430[_id];
	}

	public static void Unload()
	{
		_0024mst_002430.Clear();
		All_cache = null;
	}

	public static MGameObjectNames New(Hashtable data)
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
			MGameObjectNames mGameObjectNames = Create(data);
			if (!_0024mst_002430.ContainsKey(mGameObjectNames.Id))
			{
				_0024mst_002430[mGameObjectNames.Id] = mGameObjectNames;
			}
			result = mGameObjectNames;
		}
		return (MGameObjectNames)result;
	}

	public static MGameObjectNames New2(string[] keys, object[] vals)
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
		return (MGameObjectNames)result;
	}

	public static MGameObjectNames Entry(MGameObjectNames mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002430[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MGameObjectNames)result;
	}

	public static void AddMst(MGameObjectNames mst)
	{
		if (mst != null)
		{
			_0024mst_002430[mst.Id] = mst;
		}
	}

	public static MGameObjectNames Create(Hashtable data)
	{
		MGameObjectNames mGameObjectNames = new MGameObjectNames();
		MGameObjectNames result;
		if (data == null)
		{
			result = mGameObjectNames;
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
				mGameObjectNames.setField((string)obj, data[current]);
			}
			result = mGameObjectNames;
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
		case "GameObjectName":
			_0024var_0024GameObjectName = MasterBaseClass.ToStringValue(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Progname" => true, 
			"GameObjectName" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[3] { "Id", "Progname", "GameObjectName" });
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
						_0024var_0024GameObjectName = vals[2];
					}
					int num = 3;
					result = num;
				}
			}
		}
		return result;
	}
}
