using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MChangePoppetDecks : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024PoppetItemId;

	public int _0024var_0024WeaponItemId;

	[NonSerialized]
	private MPoppets PoppetItemId__cache;

	[NonSerialized]
	private MWeapons WeaponItemId__cache;

	[NonSerialized]
	private static Dictionary<int, MChangePoppetDecks> _0024mst_0024141 = new Dictionary<int, MChangePoppetDecks>();

	[NonSerialized]
	private static MChangePoppetDecks[] All_cache;

	public int Id => _0024var_0024Id;

	public MPoppets PoppetItemId
	{
		get
		{
			if (PoppetItemId__cache == null)
			{
				PoppetItemId__cache = MPoppets.Get(_0024var_0024PoppetItemId);
			}
			return PoppetItemId__cache;
		}
	}

	public MWeapons WeaponItemId
	{
		get
		{
			if (WeaponItemId__cache == null)
			{
				WeaponItemId__cache = MWeapons.Get(_0024var_0024WeaponItemId);
			}
			return WeaponItemId__cache;
		}
	}

	public static MChangePoppetDecks[] All
	{
		get
		{
			MChangePoppetDecks[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MChangePoppetDecks");
				MChangePoppetDecks[] array = (MChangePoppetDecks[])Builtins.array(typeof(MChangePoppetDecks), _0024mst_0024141.Values);
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

	public static MChangePoppetDecks Get(int _id)
	{
		MerlinMaster.GetHandler("MChangePoppetDecks");
		return (!_0024mst_0024141.ContainsKey(_id)) ? null : _0024mst_0024141[_id];
	}

	public static void Unload()
	{
		_0024mst_0024141.Clear();
		All_cache = null;
	}

	public static MChangePoppetDecks New(Hashtable data)
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
			MChangePoppetDecks mChangePoppetDecks = Create(data);
			if (!_0024mst_0024141.ContainsKey(mChangePoppetDecks.Id))
			{
				_0024mst_0024141[mChangePoppetDecks.Id] = mChangePoppetDecks;
			}
			result = mChangePoppetDecks;
		}
		return (MChangePoppetDecks)result;
	}

	public static MChangePoppetDecks New2(string[] keys, object[] vals)
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
		return (MChangePoppetDecks)result;
	}

	public static MChangePoppetDecks Entry(MChangePoppetDecks mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024141[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MChangePoppetDecks)result;
	}

	public static void AddMst(MChangePoppetDecks mst)
	{
		if (mst != null)
		{
			_0024mst_0024141[mst.Id] = mst;
		}
	}

	public static MChangePoppetDecks Create(Hashtable data)
	{
		MChangePoppetDecks mChangePoppetDecks = new MChangePoppetDecks();
		MChangePoppetDecks result;
		if (data == null)
		{
			result = mChangePoppetDecks;
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
				mChangePoppetDecks.setField((string)obj, data[current]);
			}
			result = mChangePoppetDecks;
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
		case "PoppetItemId":
			_0024var_0024PoppetItemId = MasterBaseClass.ToInt(val);
			break;
		case "WeaponItemId":
			_0024var_0024WeaponItemId = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"PoppetItemId" => true, 
			"WeaponItemId" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[3] { "Id", "PoppetItemId", "WeaponItemId" });
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
					_0024var_0024PoppetItemId = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024WeaponItemId = MasterBaseClass.ParseInt(vals[2]);
					}
					int num = 3;
					result = num;
				}
			}
		}
		return result;
	}
}
