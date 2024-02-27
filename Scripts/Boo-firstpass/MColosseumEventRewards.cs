using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MColosseumEventRewards : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MColosseumEventId;

	public int _0024var_0024MBreederRankId;

	public int _0024var_0024Coin;

	public int _0024var_0024FriendPoint;

	public int _0024var_0024ManaFragment;

	[NonSerialized]
	private MColosseumEvents MColosseumEventId__cache;

	[NonSerialized]
	private MBreederRanks MBreederRankId__cache;

	[NonSerialized]
	private static Dictionary<int, MColosseumEventRewards> _0024mst_0024144 = new Dictionary<int, MColosseumEventRewards>();

	[NonSerialized]
	private static MColosseumEventRewards[] All_cache;

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

	public int Coin => _0024var_0024Coin;

	public int FriendPoint => _0024var_0024FriendPoint;

	public int ManaFragment => _0024var_0024ManaFragment;

	public static MColosseumEventRewards[] All
	{
		get
		{
			MColosseumEventRewards[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MColosseumEventRewards");
				MColosseumEventRewards[] array = (MColosseumEventRewards[])Builtins.array(typeof(MColosseumEventRewards), _0024mst_0024144.Values);
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

	public static MColosseumEventRewards Get(int _id)
	{
		MerlinMaster.GetHandler("MColosseumEventRewards");
		return (!_0024mst_0024144.ContainsKey(_id)) ? null : _0024mst_0024144[_id];
	}

	public static void Unload()
	{
		_0024mst_0024144.Clear();
		All_cache = null;
	}

	public static MColosseumEventRewards New(Hashtable data)
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
			MColosseumEventRewards mColosseumEventRewards = Create(data);
			if (!_0024mst_0024144.ContainsKey(mColosseumEventRewards.Id))
			{
				_0024mst_0024144[mColosseumEventRewards.Id] = mColosseumEventRewards;
			}
			result = mColosseumEventRewards;
		}
		return (MColosseumEventRewards)result;
	}

	public static MColosseumEventRewards New2(string[] keys, object[] vals)
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
		return (MColosseumEventRewards)result;
	}

	public static MColosseumEventRewards Entry(MColosseumEventRewards mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024144[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MColosseumEventRewards)result;
	}

	public static void AddMst(MColosseumEventRewards mst)
	{
		if (mst != null)
		{
			_0024mst_0024144[mst.Id] = mst;
		}
	}

	public static MColosseumEventRewards Create(Hashtable data)
	{
		MColosseumEventRewards mColosseumEventRewards = new MColosseumEventRewards();
		MColosseumEventRewards result;
		if (data == null)
		{
			result = mColosseumEventRewards;
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
				mColosseumEventRewards.setField((string)obj, data[current]);
			}
			result = mColosseumEventRewards;
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
		case "MBreederRankId":
			_0024var_0024MBreederRankId = MasterBaseClass.ToInt(val);
			break;
		case "Coin":
			_0024var_0024Coin = MasterBaseClass.ToInt(val);
			break;
		case "FriendPoint":
			_0024var_0024FriendPoint = MasterBaseClass.ToInt(val);
			break;
		case "ManaFragment":
			_0024var_0024ManaFragment = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"MColosseumEventId" => true, 
			"MBreederRankId" => true, 
			"Coin" => true, 
			"FriendPoint" => true, 
			"ManaFragment" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[6] { "Id", "MColosseumEventId", "MBreederRankId", "Coin", "FriendPoint", "ManaFragment" });
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
						_0024var_0024MBreederRankId = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Coin = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024FriendPoint = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024ManaFragment = MasterBaseClass.ParseInt(vals[5]);
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
