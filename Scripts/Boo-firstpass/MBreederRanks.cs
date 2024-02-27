using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MBreederRanks : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024Rank;

	public int _0024var_0024NecessaryPoint;

	public string _0024var_0024DisplayName;

	public string _0024var_0024Progname;

	public bool _0024var_0024IsDemote;

	public int _0024var_0024RankingPointCorrection;

	[NonSerialized]
	private static Dictionary<int, MBreederRanks> _0024mst_0024136 = new Dictionary<int, MBreederRanks>();

	[NonSerialized]
	private static MBreederRanks[] All_cache;

	public int Id => _0024var_0024Id;

	public int Rank => _0024var_0024Rank;

	public int NecessaryPoint => _0024var_0024NecessaryPoint;

	public string DisplayName => _0024var_0024DisplayName;

	public string Progname => _0024var_0024Progname;

	public bool IsDemote => _0024var_0024IsDemote;

	public int RankingPointCorrection => _0024var_0024RankingPointCorrection;

	public static MBreederRanks[] All
	{
		get
		{
			MBreederRanks[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MBreederRanks");
				MBreederRanks[] array = (MBreederRanks[])Builtins.array(typeof(MBreederRanks), _0024mst_0024136.Values);
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

	public MBreederRanks()
	{
		_0024var_0024RankingPointCorrection = 20;
	}

	public static bool IsMaxRank(int id)
	{
		return IsMaxRank(Get(id));
	}

	public static bool IsMaxRank(MBreederRanks obj)
	{
		if (obj == null)
		{
			throw new AssertionFailedException("obj に null をいれないで下さい.");
		}
		int num = 0;
		int i = 0;
		MBreederRanks[] all = All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (num < all[i].Rank)
			{
				num = all[i].Rank;
			}
		}
		return (obj.Rank == num) ? true : false;
	}

	public static MBreederRanks GetNextRank(int id)
	{
		return GetNextRank(Get(id));
	}

	public static MBreederRanks GetNextRank(MBreederRanks obj)
	{
		if (obj == null)
		{
			throw new AssertionFailedException("obj に null をいれないで下さい.");
		}
		int num = 0;
		MBreederRanks[] all = All;
		int length = all.Length;
		checked
		{
			object result;
			while (true)
			{
				if (num < length)
				{
					if (obj.Rank + 1 == all[num].Rank)
					{
						result = all[num];
						break;
					}
					num++;
					continue;
				}
				result = null;
				break;
			}
			return (MBreederRanks)result;
		}
	}

	public static MBreederRanks Get(int _id)
	{
		MerlinMaster.GetHandler("MBreederRanks");
		return (!_0024mst_0024136.ContainsKey(_id)) ? null : _0024mst_0024136[_id];
	}

	public static void Unload()
	{
		_0024mst_0024136.Clear();
		All_cache = null;
	}

	public static MBreederRanks New(Hashtable data)
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
			MBreederRanks mBreederRanks = Create(data);
			if (!_0024mst_0024136.ContainsKey(mBreederRanks.Id))
			{
				_0024mst_0024136[mBreederRanks.Id] = mBreederRanks;
			}
			result = mBreederRanks;
		}
		return (MBreederRanks)result;
	}

	public static MBreederRanks New2(string[] keys, object[] vals)
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
		return (MBreederRanks)result;
	}

	public static MBreederRanks Entry(MBreederRanks mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024136[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MBreederRanks)result;
	}

	public static void AddMst(MBreederRanks mst)
	{
		if (mst != null)
		{
			_0024mst_0024136[mst.Id] = mst;
		}
	}

	public static MBreederRanks Create(Hashtable data)
	{
		MBreederRanks mBreederRanks = new MBreederRanks();
		MBreederRanks result;
		if (data == null)
		{
			result = mBreederRanks;
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
				mBreederRanks.setField((string)obj, data[current]);
			}
			result = mBreederRanks;
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
		case "Rank":
			_0024var_0024Rank = MasterBaseClass.ToInt(val);
			break;
		case "NecessaryPoint":
			_0024var_0024NecessaryPoint = MasterBaseClass.ToInt(val);
			break;
		case "DisplayName":
			_0024var_0024DisplayName = MasterBaseClass.ToStringValue(val);
			break;
		case "Progname":
			_0024var_0024Progname = MasterBaseClass.ToStringValue(val);
			break;
		case "IsDemote":
			_0024var_0024IsDemote = MasterBaseClass.ToBool(val);
			break;
		case "RankingPointCorrection":
			_0024var_0024RankingPointCorrection = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Rank" => true, 
			"NecessaryPoint" => true, 
			"DisplayName" => true, 
			"Progname" => true, 
			"IsDemote" => true, 
			"RankingPointCorrection" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[7] { "Id", "Rank", "NecessaryPoint", "DisplayName", "Progname", "IsDemote", "RankingPointCorrection" });
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
					_0024var_0024Rank = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024NecessaryPoint = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024DisplayName = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024Progname = vals[4];
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024IsDemote = MasterBaseClass.ParseBool(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024RankingPointCorrection = MasterBaseClass.ParseInt(vals[6]);
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
