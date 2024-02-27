using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MParameterCorrects : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public string _0024var_0024Progname;

	public float _0024var_0024CoinRate;

	public float _0024var_0024ExpRate;

	public DateTime _0024var_0024BeginDate;

	public DateTime _0024var_0024EndDate;

	[NonSerialized]
	private static Dictionary<int, MParameterCorrects> _0024mst_002478 = new Dictionary<int, MParameterCorrects>();

	[NonSerialized]
	private static MParameterCorrects[] All_cache;

	public int Id => _0024var_0024Id;

	public string Name => _0024var_0024Name;

	public string Progname => _0024var_0024Progname;

	public float CoinRate => _0024var_0024CoinRate;

	public float ExpRate => _0024var_0024ExpRate;

	public DateTime BeginDate => _0024var_0024BeginDate;

	public DateTime EndDate => _0024var_0024EndDate;

	public static MParameterCorrects[] All
	{
		get
		{
			MParameterCorrects[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MParameterCorrects");
				MParameterCorrects[] array = (MParameterCorrects[])Builtins.array(typeof(MParameterCorrects), _0024mst_002478.Values);
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

	public static MParameterCorrects Get(int _id)
	{
		MerlinMaster.GetHandler("MParameterCorrects");
		return (!_0024mst_002478.ContainsKey(_id)) ? null : _0024mst_002478[_id];
	}

	public static void Unload()
	{
		_0024mst_002478.Clear();
		All_cache = null;
	}

	public static MParameterCorrects New(Hashtable data)
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
			MParameterCorrects mParameterCorrects = Create(data);
			if (!_0024mst_002478.ContainsKey(mParameterCorrects.Id))
			{
				_0024mst_002478[mParameterCorrects.Id] = mParameterCorrects;
			}
			result = mParameterCorrects;
		}
		return (MParameterCorrects)result;
	}

	public static MParameterCorrects New2(string[] keys, object[] vals)
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
		return (MParameterCorrects)result;
	}

	public static MParameterCorrects Entry(MParameterCorrects mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002478[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MParameterCorrects)result;
	}

	public static void AddMst(MParameterCorrects mst)
	{
		if (mst != null)
		{
			_0024mst_002478[mst.Id] = mst;
		}
	}

	public static MParameterCorrects Create(Hashtable data)
	{
		MParameterCorrects mParameterCorrects = new MParameterCorrects();
		MParameterCorrects result;
		if (data == null)
		{
			result = mParameterCorrects;
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
				mParameterCorrects.setField((string)obj, data[current]);
			}
			result = mParameterCorrects;
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
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		case "Progname":
			_0024var_0024Progname = MasterBaseClass.ToStringValue(val);
			break;
		case "CoinRate":
			_0024var_0024CoinRate = MasterBaseClass.ToSingle(val);
			break;
		case "ExpRate":
			_0024var_0024ExpRate = MasterBaseClass.ToSingle(val);
			break;
		case "BeginDate":
		{
			object obj2 = val;
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			_0024var_0024BeginDate = DateTime.Parse((string)obj2);
			break;
		}
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
			"Name" => true, 
			"Progname" => true, 
			"CoinRate" => true, 
			"ExpRate" => true, 
			"BeginDate" => true, 
			"EndDate" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[7] { "Id", "Name", "Progname", "CoinRate", "ExpRate", "BeginDate", "EndDate" });
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
					_0024var_0024Name = vals[1];
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024Progname = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024CoinRate = MasterBaseClass.ParseSingle(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024ExpRate = MasterBaseClass.ParseSingle(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024BeginDate = MasterBaseClass.ParseDateTime(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024EndDate = MasterBaseClass.ParseDateTime(vals[6]);
									}
									int num = 7;
									result = num;
								}
							}
						}
					}
				}
			}
		}
		return result;
	}
}
