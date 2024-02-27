using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MElementCorrelations : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MElementId;

	public int _0024var_0024MToElementId;

	public int _0024var_0024Rate;

	[NonSerialized]
	private MElements MElementId__cache;

	[NonSerialized]
	private MElements MToElementId__cache;

	[NonSerialized]
	private static Dictionary<int, MElementCorrelations> _0024mst_002447 = new Dictionary<int, MElementCorrelations>();

	[NonSerialized]
	private static MElementCorrelations[] All_cache;

	public int Id => _0024var_0024Id;

	public MElements MElementId
	{
		get
		{
			if (MElementId__cache == null)
			{
				MElementId__cache = MElements.Get(_0024var_0024MElementId);
			}
			return MElementId__cache;
		}
	}

	public MElements MToElementId
	{
		get
		{
			if (MToElementId__cache == null)
			{
				MToElementId__cache = MElements.Get(_0024var_0024MToElementId);
			}
			return MToElementId__cache;
		}
	}

	public int Rate => _0024var_0024Rate;

	public static MElementCorrelations[] All
	{
		get
		{
			MElementCorrelations[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MElementCorrelations");
				MElementCorrelations[] array = (MElementCorrelations[])Builtins.array(typeof(MElementCorrelations), _0024mst_002447.Values);
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

	public static float GetRate(EnumElements myElem, EnumElements toElem)
	{
		int num = 0;
		MElementCorrelations[] all = All;
		int length = all.Length;
		float result;
		while (true)
		{
			if (num < length)
			{
				MElements mElementId = all[num].MElementId;
				MElements mToElementId = all[num].MToElementId;
				if (mElementId != null && mToElementId != null && mElementId.Id == (int)myElem && mToElementId.Id == (int)toElem)
				{
					result = (float)all[num].Rate / 100f;
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = 1f;
			break;
		}
		return result;
	}

	public static float GetRate(MElements myElem, MElements toElem)
	{
		return (myElem != null && toElem != null) ? GetRate((EnumElements)myElem.Id, (EnumElements)toElem.Id) : 1f;
	}

	public static MElementCorrelations Get(int _id)
	{
		MerlinMaster.GetHandler("MElementCorrelations");
		return (!_0024mst_002447.ContainsKey(_id)) ? null : _0024mst_002447[_id];
	}

	public static void Unload()
	{
		_0024mst_002447.Clear();
		All_cache = null;
	}

	public static MElementCorrelations New(Hashtable data)
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
			MElementCorrelations mElementCorrelations = Create(data);
			if (!_0024mst_002447.ContainsKey(mElementCorrelations.Id))
			{
				_0024mst_002447[mElementCorrelations.Id] = mElementCorrelations;
			}
			result = mElementCorrelations;
		}
		return (MElementCorrelations)result;
	}

	public static MElementCorrelations New2(string[] keys, object[] vals)
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
		return (MElementCorrelations)result;
	}

	public static MElementCorrelations Entry(MElementCorrelations mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002447[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MElementCorrelations)result;
	}

	public static void AddMst(MElementCorrelations mst)
	{
		if (mst != null)
		{
			_0024mst_002447[mst.Id] = mst;
		}
	}

	public static MElementCorrelations Create(Hashtable data)
	{
		MElementCorrelations mElementCorrelations = new MElementCorrelations();
		MElementCorrelations result;
		if (data == null)
		{
			result = mElementCorrelations;
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
				mElementCorrelations.setField((string)obj, data[current]);
			}
			result = mElementCorrelations;
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
		case "MElementId":
			_0024var_0024MElementId = MasterBaseClass.ToInt(val);
			break;
		case "MToElementId":
			_0024var_0024MToElementId = MasterBaseClass.ToInt(val);
			break;
		case "Rate":
			_0024var_0024Rate = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"MElementId" => true, 
			"MToElementId" => true, 
			"Rate" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[4] { "Id", "MElementId", "MToElementId", "Rate" });
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
					_0024var_0024MElementId = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024MToElementId = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Rate = MasterBaseClass.ParseInt(vals[3]);
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
