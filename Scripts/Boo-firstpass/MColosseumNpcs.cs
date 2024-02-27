using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MColosseumNpcs : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MColosseumEventId;

	public string _0024var_0024Name;

	public int _0024var_0024Level;

	public int _0024var_0024MBreederRankId;

	public int _0024var_0024BreederRankPoint;

	[NonSerialized]
	private MColosseumEvents MColosseumEventId__cache;

	[NonSerialized]
	private MBreederRanks MBreederRankId__cache;

	[NonSerialized]
	private static Dictionary<int, MColosseumNpcs> _0024mst_0024139 = new Dictionary<int, MColosseumNpcs>();

	[NonSerialized]
	private static MColosseumNpcs[] All_cache;

	public int Id => _0024var_0024Id;

	public MColosseumEvents MColosseumEventId
	{
		get
		{
			if (MColosseumEventId__cache == null)
			{
				MColosseumEventId__cache = MColosseumEvents.Get(_0024var_0024MColosseumEventId);
			}
			return MColosseumEventId__cache;
		}
	}

	public string Name => _0024var_0024Name;

	public int Level => _0024var_0024Level;

	public MBreederRanks MBreederRankId
	{
		get
		{
			if (MBreederRankId__cache == null)
			{
				MBreederRankId__cache = MBreederRanks.Get(_0024var_0024MBreederRankId);
			}
			return MBreederRankId__cache;
		}
	}

	public int BreederRankPoint => _0024var_0024BreederRankPoint;

	public static MColosseumNpcs[] All
	{
		get
		{
			MColosseumNpcs[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MColosseumNpcs");
				MColosseumNpcs[] array = (MColosseumNpcs[])Builtins.array(typeof(MColosseumNpcs), _0024mst_0024139.Values);
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

	public static MColosseumNpcs Get(int _id)
	{
		MerlinMaster.GetHandler("MColosseumNpcs");
		return (!_0024mst_0024139.ContainsKey(_id)) ? null : _0024mst_0024139[_id];
	}

	public static void Unload()
	{
		_0024mst_0024139.Clear();
		All_cache = null;
	}

	public static MColosseumNpcs New(Hashtable data)
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
			MColosseumNpcs mColosseumNpcs = Create(data);
			if (!_0024mst_0024139.ContainsKey(mColosseumNpcs.Id))
			{
				_0024mst_0024139[mColosseumNpcs.Id] = mColosseumNpcs;
			}
			result = mColosseumNpcs;
		}
		return (MColosseumNpcs)result;
	}

	public static MColosseumNpcs New2(string[] keys, object[] vals)
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
		return (MColosseumNpcs)result;
	}

	public static MColosseumNpcs Entry(MColosseumNpcs mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024139[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MColosseumNpcs)result;
	}

	public static void AddMst(MColosseumNpcs mst)
	{
		if (mst != null)
		{
			_0024mst_0024139[mst.Id] = mst;
		}
	}

	public static MColosseumNpcs Create(Hashtable data)
	{
		MColosseumNpcs mColosseumNpcs = new MColosseumNpcs();
		MColosseumNpcs result;
		if (data == null)
		{
			result = mColosseumNpcs;
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
				mColosseumNpcs.setField((string)obj, data[current]);
			}
			result = mColosseumNpcs;
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
		case "MColosseumEventId":
			_0024var_0024MColosseumEventId = MasterBaseClass.ToInt(val);
			break;
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		case "Level":
			_0024var_0024Level = MasterBaseClass.ToInt(val);
			break;
		case "MBreederRankId":
			_0024var_0024MBreederRankId = MasterBaseClass.ToInt(val);
			break;
		case "BreederRankPoint":
			_0024var_0024BreederRankPoint = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"MColosseumEventId" => true, 
			"Name" => true, 
			"Level" => true, 
			"MBreederRankId" => true, 
			"BreederRankPoint" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[6] { "Id", "MColosseumEventId", "Name", "Level", "MBreederRankId", "BreederRankPoint" });
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
					_0024var_0024MColosseumEventId = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024Name = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Level = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024MBreederRankId = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024BreederRankPoint = MasterBaseClass.ParseInt(vals[5]);
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
