using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MPlayerPoppetDecks : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MPlayerId;

	public int _0024var_0024No;

	public int _0024var_0024PoppetItemId;

	public int _0024var_0024WeaponItemId;

	[NonSerialized]
	private MPoppets PoppetItemId__cache;

	[NonSerialized]
	private MWeapons WeaponItemId__cache;

	[NonSerialized]
	private static Dictionary<int, MPlayerPoppetDecks> _0024mst_0024142 = new Dictionary<int, MPlayerPoppetDecks>();

	[NonSerialized]
	private static MPlayerPoppetDecks[] All_cache;

	public int Id => _0024var_0024Id;

	public int MPlayerId => _0024var_0024MPlayerId;

	public int No => _0024var_0024No;

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

	public static MPlayerPoppetDecks[] All
	{
		get
		{
			MPlayerPoppetDecks[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MPlayerPoppetDecks");
				MPlayerPoppetDecks[] array = (MPlayerPoppetDecks[])Builtins.array(typeof(MPlayerPoppetDecks), _0024mst_0024142.Values);
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

	public static MPlayerPoppetDecks Get(int _id)
	{
		MerlinMaster.GetHandler("MPlayerPoppetDecks");
		return (!_0024mst_0024142.ContainsKey(_id)) ? null : _0024mst_0024142[_id];
	}

	public static void Unload()
	{
		_0024mst_0024142.Clear();
		All_cache = null;
	}

	public static MPlayerPoppetDecks New(Hashtable data)
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
			MPlayerPoppetDecks mPlayerPoppetDecks = Create(data);
			if (!_0024mst_0024142.ContainsKey(mPlayerPoppetDecks.Id))
			{
				_0024mst_0024142[mPlayerPoppetDecks.Id] = mPlayerPoppetDecks;
			}
			result = mPlayerPoppetDecks;
		}
		return (MPlayerPoppetDecks)result;
	}

	public static MPlayerPoppetDecks New2(string[] keys, object[] vals)
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
		return (MPlayerPoppetDecks)result;
	}

	public static MPlayerPoppetDecks Entry(MPlayerPoppetDecks mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024142[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MPlayerPoppetDecks)result;
	}

	public static void AddMst(MPlayerPoppetDecks mst)
	{
		if (mst != null)
		{
			_0024mst_0024142[mst.Id] = mst;
		}
	}

	public static MPlayerPoppetDecks Create(Hashtable data)
	{
		MPlayerPoppetDecks mPlayerPoppetDecks = new MPlayerPoppetDecks();
		MPlayerPoppetDecks result;
		if (data == null)
		{
			result = mPlayerPoppetDecks;
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
				mPlayerPoppetDecks.setField((string)obj, data[current]);
			}
			result = mPlayerPoppetDecks;
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
		case "MPlayerId":
			_0024var_0024MPlayerId = MasterBaseClass.ToInt(val);
			break;
		case "No":
			_0024var_0024No = MasterBaseClass.ToInt(val);
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
			"MPlayerId" => true, 
			"No" => true, 
			"PoppetItemId" => true, 
			"WeaponItemId" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[5] { "Id", "MPlayerId", "No", "PoppetItemId", "WeaponItemId" });
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
					_0024var_0024MPlayerId = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024No = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024PoppetItemId = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024WeaponItemId = MasterBaseClass.ParseInt(vals[4]);
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
