using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MColosseumEventRankingPointNormaRewards : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MColosseumEventId;

	public double _0024var_0024From;

	public double _0024var_0024To;

	[NonSerialized]
	private MColosseumEvents MColosseumEventId__cache;

	[NonSerialized]
	private static Dictionary<int, MColosseumEventRankingPointNormaRewards> _0024mst_0024138 = new Dictionary<int, MColosseumEventRankingPointNormaRewards>();

	[NonSerialized]
	private static MColosseumEventRankingPointNormaRewards[] All_cache;

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

	public double From => _0024var_0024From;

	public double To => _0024var_0024To;

	public static MColosseumEventRankingPointNormaRewards[] All
	{
		get
		{
			MColosseumEventRankingPointNormaRewards[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MColosseumEventRankingPointNormaRewards");
				MColosseumEventRankingPointNormaRewards[] array = (MColosseumEventRankingPointNormaRewards[])Builtins.array(typeof(MColosseumEventRankingPointNormaRewards), _0024mst_0024138.Values);
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

	public static MColosseumEventRankingPointNormaRewards Get(int _id)
	{
		MerlinMaster.GetHandler("MColosseumEventRankingPointNormaRewards");
		return (!_0024mst_0024138.ContainsKey(_id)) ? null : _0024mst_0024138[_id];
	}

	public static void Unload()
	{
		_0024mst_0024138.Clear();
		All_cache = null;
	}

	public static MColosseumEventRankingPointNormaRewards New(Hashtable data)
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
			MColosseumEventRankingPointNormaRewards mColosseumEventRankingPointNormaRewards = Create(data);
			if (!_0024mst_0024138.ContainsKey(mColosseumEventRankingPointNormaRewards.Id))
			{
				_0024mst_0024138[mColosseumEventRankingPointNormaRewards.Id] = mColosseumEventRankingPointNormaRewards;
			}
			result = mColosseumEventRankingPointNormaRewards;
		}
		return (MColosseumEventRankingPointNormaRewards)result;
	}

	public static MColosseumEventRankingPointNormaRewards New2(string[] keys, object[] vals)
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
		return (MColosseumEventRankingPointNormaRewards)result;
	}

	public static MColosseumEventRankingPointNormaRewards Entry(MColosseumEventRankingPointNormaRewards mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024138[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MColosseumEventRankingPointNormaRewards)result;
	}

	public static void AddMst(MColosseumEventRankingPointNormaRewards mst)
	{
		if (mst != null)
		{
			_0024mst_0024138[mst.Id] = mst;
		}
	}

	public static MColosseumEventRankingPointNormaRewards Create(Hashtable data)
	{
		MColosseumEventRankingPointNormaRewards mColosseumEventRankingPointNormaRewards = new MColosseumEventRankingPointNormaRewards();
		MColosseumEventRankingPointNormaRewards result;
		if (data == null)
		{
			result = mColosseumEventRankingPointNormaRewards;
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
				mColosseumEventRankingPointNormaRewards.setField((string)obj, data[current]);
			}
			result = mColosseumEventRankingPointNormaRewards;
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
		case "From":
			if (typeof(double).IsEnum)
			{
				_0024var_0024From = RuntimeServices.UnboxDouble(MasterBaseClass.ToEnum(val));
			}
			break;
		case "To":
			if (typeof(double).IsEnum)
			{
				_0024var_0024To = RuntimeServices.UnboxDouble(MasterBaseClass.ToEnum(val));
			}
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"MColosseumEventId" => true, 
			"From" => true, 
			"To" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[4] { "Id", "MColosseumEventId", "From", "To" });
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
					if (vals[2] != null && typeof(double).IsEnum)
					{
						_0024var_0024From = RuntimeServices.UnboxDouble(MasterBaseClass.ParseEnum(vals[2]));
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null && typeof(double).IsEnum)
						{
							_0024var_0024To = RuntimeServices.UnboxDouble(MasterBaseClass.ParseEnum(vals[3]));
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
