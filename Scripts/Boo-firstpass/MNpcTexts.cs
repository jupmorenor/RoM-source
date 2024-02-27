using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MNpcTexts : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	public string _0024var_0024Ja_M;

	public string _0024var_0024Ja_F;

	public string _0024var_0024En_M;

	public string _0024var_0024En_F;

	[NonSerialized]
	private static Dictionary<int, MNpcTexts> _0024mst_002460 = new Dictionary<int, MNpcTexts>();

	[NonSerialized]
	private static MNpcTexts[] All_cache;

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

	public string Ja_M => _0024var_0024Ja_M;

	public string Ja_F => _0024var_0024Ja_F;

	public string En_M => _0024var_0024En_M;

	public string En_F => _0024var_0024En_F;

	public static MNpcTexts[] All
	{
		get
		{
			MNpcTexts[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MNpcTexts");
				MNpcTexts[] array = (MNpcTexts[])Builtins.array(typeof(MNpcTexts), _0024mst_002460.Values);
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

	public static MNpcTexts Get(int _id)
	{
		MerlinMaster.GetHandler("MNpcTexts");
		return (!_0024mst_002460.ContainsKey(_id)) ? null : _0024mst_002460[_id];
	}

	public static void Unload()
	{
		_0024mst_002460.Clear();
		All_cache = null;
	}

	public static MNpcTexts New(Hashtable data)
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
			MNpcTexts mNpcTexts = Create(data);
			if (!_0024mst_002460.ContainsKey(mNpcTexts.Id))
			{
				_0024mst_002460[mNpcTexts.Id] = mNpcTexts;
			}
			result = mNpcTexts;
		}
		return (MNpcTexts)result;
	}

	public static MNpcTexts New2(string[] keys, object[] vals)
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
		return (MNpcTexts)result;
	}

	public static MNpcTexts Entry(MNpcTexts mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002460[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MNpcTexts)result;
	}

	public static void AddMst(MNpcTexts mst)
	{
		if (mst != null)
		{
			_0024mst_002460[mst.Id] = mst;
		}
	}

	public static MNpcTexts Create(Hashtable data)
	{
		MNpcTexts mNpcTexts = new MNpcTexts();
		MNpcTexts result;
		if (data == null)
		{
			result = mNpcTexts;
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
				mNpcTexts.setField((string)obj, data[current]);
			}
			result = mNpcTexts;
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
		case "Ja_M":
			_0024var_0024Ja_M = MasterBaseClass.ToStringValue(val);
			break;
		case "Ja_F":
			_0024var_0024Ja_F = MasterBaseClass.ToStringValue(val);
			break;
		case "En_M":
			_0024var_0024En_M = MasterBaseClass.ToStringValue(val);
			break;
		case "En_F":
			_0024var_0024En_F = MasterBaseClass.ToStringValue(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Progname" => true, 
			"Ja_M" => true, 
			"Ja_F" => true, 
			"En_M" => true, 
			"En_F" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[6] { "Id", "Progname", "Ja_M", "Ja_F", "En_M", "En_F" });
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
						_0024var_0024Ja_M = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Ja_F = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024En_M = vals[4];
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024En_F = vals[5];
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
