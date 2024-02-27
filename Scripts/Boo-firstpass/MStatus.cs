using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MStatus : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024krName;

	public string _0024var_0024Progname;

	public string _0024var_0024Name;

	public string _0024var_0024Explain;

	[NonSerialized]
	private MTexts Explain__cache;

	[NonSerialized]
	private static Dictionary<int, MStatus> _0024mst_0024131 = new Dictionary<int, MStatus>();

	[NonSerialized]
	private static MStatus[] All_cache;

	public int Id => _0024var_0024Id;

	public string krName => _0024var_0024krName;

	public string Progname => _0024var_0024Progname;

	public string Name => _0024var_0024Name;

	public MTexts Explain
	{
		get
		{
			if (Explain__cache == null)
			{
				Explain__cache = MTexts.Get(_0024var_0024Explain);
			}
			return Explain__cache;
		}
	}

	public static MStatus[] All
	{
		get
		{
			MStatus[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MStatus");
				MStatus[] array = (MStatus[])Builtins.array(typeof(MStatus), _0024mst_0024131.Values);
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

	public static MStatus Get(int _id)
	{
		MerlinMaster.GetHandler("MStatus");
		return (!_0024mst_0024131.ContainsKey(_id)) ? null : _0024mst_0024131[_id];
	}

	public static void Unload()
	{
		_0024mst_0024131.Clear();
		All_cache = null;
	}

	public static MStatus New(Hashtable data)
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
			MStatus mStatus = Create(data);
			if (!_0024mst_0024131.ContainsKey(mStatus.Id))
			{
				_0024mst_0024131[mStatus.Id] = mStatus;
			}
			result = mStatus;
		}
		return (MStatus)result;
	}

	public static MStatus New2(string[] keys, object[] vals)
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
		return (MStatus)result;
	}

	public static MStatus Entry(MStatus mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024131[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MStatus)result;
	}

	public static void AddMst(MStatus mst)
	{
		if (mst != null)
		{
			_0024mst_0024131[mst.Id] = mst;
		}
	}

	public static MStatus Create(Hashtable data)
	{
		MStatus mStatus = new MStatus();
		MStatus result;
		if (data == null)
		{
			result = mStatus;
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
				mStatus.setField((string)obj, data[current]);
			}
			result = mStatus;
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
		case "krName":
			_0024var_0024krName = MasterBaseClass.ToStringValue(val);
			break;
		case "Progname":
			_0024var_0024Progname = MasterBaseClass.ToStringValue(val);
			break;
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		case "Explain":
			_0024var_0024Explain = MasterBaseClass.ToStringValue(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"krName" => true, 
			"Progname" => true, 
			"Name" => true, 
			"Explain" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[5] { "Id", "krName", "Progname", "Name", "Explain" });
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
					_0024var_0024krName = vals[1];
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
							_0024var_0024Name = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024Explain = vals[4];
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
