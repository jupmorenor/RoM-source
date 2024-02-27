using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MPlayerDeckMains : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MPlayerId;

	public int _0024var_0024No;

	public int _0024var_0024AngelItemId;

	public int _0024var_0024DevilItemId;

	public int _0024var_0024PoppetItemId;

	[NonSerialized]
	private static Dictionary<int, MPlayerDeckMains> _0024mst_0024120 = new Dictionary<int, MPlayerDeckMains>();

	[NonSerialized]
	private static MPlayerDeckMains[] All_cache;

	public int Id => _0024var_0024Id;

	public int MPlayerId => _0024var_0024MPlayerId;

	public int No => _0024var_0024No;

	public int AngelItemId => _0024var_0024AngelItemId;

	public int DevilItemId => _0024var_0024DevilItemId;

	public int PoppetItemId => _0024var_0024PoppetItemId;

	public static MPlayerDeckMains[] All
	{
		get
		{
			MPlayerDeckMains[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MPlayerDeckMains");
				MPlayerDeckMains[] array = (MPlayerDeckMains[])Builtins.array(typeof(MPlayerDeckMains), _0024mst_0024120.Values);
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

	public static MPlayerDeckMains Get(int _id)
	{
		MerlinMaster.GetHandler("MPlayerDeckMains");
		return (!_0024mst_0024120.ContainsKey(_id)) ? null : _0024mst_0024120[_id];
	}

	public static void Unload()
	{
		_0024mst_0024120.Clear();
		All_cache = null;
	}

	public static MPlayerDeckMains New(Hashtable data)
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
			MPlayerDeckMains mPlayerDeckMains = Create(data);
			if (!_0024mst_0024120.ContainsKey(mPlayerDeckMains.Id))
			{
				_0024mst_0024120[mPlayerDeckMains.Id] = mPlayerDeckMains;
			}
			result = mPlayerDeckMains;
		}
		return (MPlayerDeckMains)result;
	}

	public static MPlayerDeckMains New2(string[] keys, object[] vals)
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
		return (MPlayerDeckMains)result;
	}

	public static MPlayerDeckMains Entry(MPlayerDeckMains mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024120[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MPlayerDeckMains)result;
	}

	public static void AddMst(MPlayerDeckMains mst)
	{
		if (mst != null)
		{
			_0024mst_0024120[mst.Id] = mst;
		}
	}

	public static MPlayerDeckMains Create(Hashtable data)
	{
		MPlayerDeckMains mPlayerDeckMains = new MPlayerDeckMains();
		MPlayerDeckMains result;
		if (data == null)
		{
			result = mPlayerDeckMains;
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
				mPlayerDeckMains.setField((string)obj, data[current]);
			}
			result = mPlayerDeckMains;
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
		case "AngelItemId":
			_0024var_0024AngelItemId = MasterBaseClass.ToInt(val);
			break;
		case "DevilItemId":
			_0024var_0024DevilItemId = MasterBaseClass.ToInt(val);
			break;
		case "PoppetItemId":
			_0024var_0024PoppetItemId = MasterBaseClass.ToInt(val);
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
			"AngelItemId" => true, 
			"DevilItemId" => true, 
			"PoppetItemId" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[6] { "Id", "MPlayerId", "No", "AngelItemId", "DevilItemId", "PoppetItemId" });
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
							_0024var_0024AngelItemId = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024DevilItemId = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024PoppetItemId = MasterBaseClass.ParseInt(vals[5]);
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
