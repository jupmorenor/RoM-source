using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MLots : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public int _0024var_0024sellType;

	public string _0024var_0024Icon;

	[NonSerialized]
	private MTexts Name__cache;

	[NonSerialized]
	private MSellTypes sellType__cache;

	[NonSerialized]
	private static Dictionary<int, MLots> _0024mst_002419 = new Dictionary<int, MLots>();

	[NonSerialized]
	private static MLots[] All_cache;

	public int Id => _0024var_0024Id;

	public MTexts Name
	{
		get
		{
			if (Name__cache == null)
			{
				Name__cache = MTexts.Get(_0024var_0024Name);
			}
			return Name__cache;
		}
	}

	public MSellTypes sellType
	{
		get
		{
			if (sellType__cache == null)
			{
				sellType__cache = MSellTypes.Get(_0024var_0024sellType);
			}
			return sellType__cache;
		}
	}

	public string Icon => _0024var_0024Icon;

	public static MLots[] All
	{
		get
		{
			MLots[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MLots");
				MLots[] array = (MLots[])Builtins.array(typeof(MLots), _0024mst_002419.Values);
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

	public static MLots Get(int _id)
	{
		MerlinMaster.GetHandler("MLots");
		return (!_0024mst_002419.ContainsKey(_id)) ? null : _0024mst_002419[_id];
	}

	public static void Unload()
	{
		_0024mst_002419.Clear();
		All_cache = null;
	}

	public static MLots New(Hashtable data)
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
			MLots mLots = Create(data);
			if (!_0024mst_002419.ContainsKey(mLots.Id))
			{
				_0024mst_002419[mLots.Id] = mLots;
			}
			result = mLots;
		}
		return (MLots)result;
	}

	public static MLots New2(string[] keys, object[] vals)
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
		return (MLots)result;
	}

	public static MLots Entry(MLots mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002419[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MLots)result;
	}

	public static void AddMst(MLots mst)
	{
		if (mst != null)
		{
			_0024mst_002419[mst.Id] = mst;
		}
	}

	public static MLots Create(Hashtable data)
	{
		MLots mLots = new MLots();
		MLots result;
		if (data == null)
		{
			result = mLots;
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
				mLots.setField((string)obj, data[current]);
			}
			result = mLots;
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
		case "sellType":
			_0024var_0024sellType = MasterBaseClass.ToInt(val);
			break;
		case "Icon":
			_0024var_0024Icon = MasterBaseClass.ToStringValue(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Name" => true, 
			"sellType" => true, 
			"Icon" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[4] { "Id", "Name", "sellType", "Icon" });
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
						_0024var_0024sellType = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Icon = vals[3];
						}
						int num = 4;
						result = num;
					}
				}
			}
		}
		return result;
	}
}
