using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MGachaRewards : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	public int _0024var_0024MGachaId;

	public int _0024var_0024MItemGroupId;

	public int _0024var_0024Rate;

	[NonSerialized]
	private MGachas MGachaId__cache;

	[NonSerialized]
	private MItemGroups MItemGroupId__cache;

	[NonSerialized]
	private static Dictionary<int, MGachaRewards> _0024mst_002445 = new Dictionary<int, MGachaRewards>();

	[NonSerialized]
	private static MGachaRewards[] All_cache;

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

	public MGachas MGachaId
	{
		get
		{
			if (MGachaId__cache == null)
			{
				MGachaId__cache = MGachas.Get(_0024var_0024MGachaId);
			}
			return MGachaId__cache;
		}
	}

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

	public int Rate => _0024var_0024Rate;

	public static MGachaRewards[] All
	{
		get
		{
			MGachaRewards[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MGachaRewards");
				MGachaRewards[] array = (MGachaRewards[])Builtins.array(typeof(MGachaRewards), _0024mst_002445.Values);
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
		return new StringBuilder("MGachaRewards(").Append((object)Id).Append(":").Append(Progname)
			.Append(":")
			.Append(typeof(MGachas))
			.Append(":")
			.Append(MItemGroupId)
			.Append(")")
			.ToString();
	}

	public static MGachaRewards Get(int _id)
	{
		MerlinMaster.GetHandler("MGachaRewards");
		return (!_0024mst_002445.ContainsKey(_id)) ? null : _0024mst_002445[_id];
	}

	public static void Unload()
	{
		_0024mst_002445.Clear();
		All_cache = null;
	}

	public static MGachaRewards New(Hashtable data)
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
			MGachaRewards mGachaRewards = Create(data);
			if (!_0024mst_002445.ContainsKey(mGachaRewards.Id))
			{
				_0024mst_002445[mGachaRewards.Id] = mGachaRewards;
			}
			result = mGachaRewards;
		}
		return (MGachaRewards)result;
	}

	public static MGachaRewards New2(string[] keys, object[] vals)
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
		return (MGachaRewards)result;
	}

	public static MGachaRewards Entry(MGachaRewards mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002445[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MGachaRewards)result;
	}

	public static void AddMst(MGachaRewards mst)
	{
		if (mst != null)
		{
			_0024mst_002445[mst.Id] = mst;
		}
	}

	public static MGachaRewards Create(Hashtable data)
	{
		MGachaRewards mGachaRewards = new MGachaRewards();
		MGachaRewards result;
		if (data == null)
		{
			result = mGachaRewards;
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
				mGachaRewards.setField((string)obj, data[current]);
			}
			result = mGachaRewards;
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
		case "MGachaId":
			_0024var_0024MGachaId = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupId":
			_0024var_0024MItemGroupId = MasterBaseClass.ToInt(val);
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
			"Progname" => true, 
			"MGachaId" => true, 
			"MItemGroupId" => true, 
			"Rate" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[5] { "Id", "Progname", "MGachaId", "MItemGroupId", "Rate" });
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
						_0024var_0024MGachaId = MasterBaseClass.ParseInt(vals[2]);
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
							if (vals[4] != null)
							{
								_0024var_0024Rate = MasterBaseClass.ParseInt(vals[4]);
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
