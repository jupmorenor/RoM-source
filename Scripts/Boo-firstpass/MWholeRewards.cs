using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MWholeRewards : MerlinMaster
{
	public int _0024var_0024Id;

	public RewardGroupTypes _0024var_0024RewardGroupIs;

	public int _0024var_0024RewardId;

	public int _0024var_0024MItemGroupId;

	public EnumPresentTypes _0024var_0024PresentIs;

	[NonSerialized]
	private MItemGroups MItemGroupId__cache;

	[NonSerialized]
	private static Dictionary<int, MWholeRewards> _0024mst_0024124 = new Dictionary<int, MWholeRewards>();

	[NonSerialized]
	private static MWholeRewards[] All_cache;

	public int Id => _0024var_0024Id;

	public RewardGroupTypes RewardGroupIs => _0024var_0024RewardGroupIs;

	public int RewardId => _0024var_0024RewardId;

	public MItemGroups MItemGroupId
	{
		get
		{
			if (MItemGroupId__cache == null)
			{
				MItemGroupId__cache = MItemGroups.Get(_0024var_0024MItemGroupId);
			}
			return MItemGroupId__cache;
		}
	}

	public EnumPresentTypes PresentIs => _0024var_0024PresentIs;

	public static MWholeRewards[] All
	{
		get
		{
			MWholeRewards[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MWholeRewards");
				MWholeRewards[] array = (MWholeRewards[])Builtins.array(typeof(MWholeRewards), _0024mst_0024124.Values);
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

	public override string ToString()
	{
		return new StringBuilder("MWholeRewards(").Append((object)Id).Append(",").Append(RewardGroupIs)
			.Append(",")
			.Append(PresentIs)
			.Append(")")
			.ToString();
	}

	public static MWholeRewards Get(int _id)
	{
		MerlinMaster.GetHandler("MWholeRewards");
		return (!_0024mst_0024124.ContainsKey(_id)) ? null : _0024mst_0024124[_id];
	}

	public static void Unload()
	{
		_0024mst_0024124.Clear();
		All_cache = null;
	}

	public static MWholeRewards New(Hashtable data)
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
			MWholeRewards mWholeRewards = Create(data);
			if (!_0024mst_0024124.ContainsKey(mWholeRewards.Id))
			{
				_0024mst_0024124[mWholeRewards.Id] = mWholeRewards;
			}
			result = mWholeRewards;
		}
		return (MWholeRewards)result;
	}

	public static MWholeRewards New2(string[] keys, object[] vals)
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
		return (MWholeRewards)result;
	}

	public static MWholeRewards Entry(MWholeRewards mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024124[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MWholeRewards)result;
	}

	public static void AddMst(MWholeRewards mst)
	{
		if (mst != null)
		{
			_0024mst_0024124[mst.Id] = mst;
		}
	}

	public static MWholeRewards Create(Hashtable data)
	{
		MWholeRewards mWholeRewards = new MWholeRewards();
		MWholeRewards result;
		if (data == null)
		{
			result = mWholeRewards;
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
				mWholeRewards.setField((string)obj, data[current]);
			}
			result = mWholeRewards;
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
		case "RewardGroupIs":
			if (typeof(RewardGroupTypes).IsEnum)
			{
				_0024var_0024RewardGroupIs = (RewardGroupTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "RewardId":
			_0024var_0024RewardId = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupId":
			_0024var_0024MItemGroupId = MasterBaseClass.ToInt(val);
			break;
		case "PresentIs":
			if (typeof(EnumPresentTypes).IsEnum)
			{
				_0024var_0024PresentIs = (EnumPresentTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"RewardGroupIs" => true, 
			"RewardId" => true, 
			"MItemGroupId" => true, 
			"PresentIs" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[5] { "Id", "RewardGroupIs", "RewardId", "MItemGroupId", "PresentIs" });
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
				if (vals[1] != null && typeof(RewardGroupTypes).IsEnum)
				{
					_0024var_0024RewardGroupIs = (RewardGroupTypes)MasterBaseClass.ParseEnum(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024RewardId = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024MItemGroupId = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null && typeof(EnumPresentTypes).IsEnum)
							{
								_0024var_0024PresentIs = (EnumPresentTypes)MasterBaseClass.ParseEnum(vals[4]);
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
