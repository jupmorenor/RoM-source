using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MWarps : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	public int _0024var_0024SceneToWarp;

	public string _0024var_0024PositionObject;

	public bool _0024var_0024NoSmoke;

	[NonSerialized]
	private MScenes SceneToWarp__cache;

	[NonSerialized]
	private static Dictionary<int, MWarps> _0024mst_0024117 = new Dictionary<int, MWarps>();

	[NonSerialized]
	private static MWarps[] All_cache;

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

	public MScenes SceneToWarp
	{
		get
		{
			if (SceneToWarp__cache == null)
			{
				SceneToWarp__cache = MScenes.Get(_0024var_0024SceneToWarp);
			}
			return SceneToWarp__cache;
		}
	}

	public string PositionObject => _0024var_0024PositionObject;

	public bool NoSmoke => _0024var_0024NoSmoke;

	public static MWarps[] All
	{
		get
		{
			MWarps[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MWarps");
				MWarps[] array = (MWarps[])Builtins.array(typeof(MWarps), _0024mst_0024117.Values);
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
		return new StringBuilder("MWarps(").Append((object)Id).Append(":").Append(Progname)
			.Append(" to ")
			.Append(SceneToWarp)
			.Append(")")
			.ToString();
	}

	public static MWarps Get(int _id)
	{
		MerlinMaster.GetHandler("MWarps");
		return (!_0024mst_0024117.ContainsKey(_id)) ? null : _0024mst_0024117[_id];
	}

	public static void Unload()
	{
		_0024mst_0024117.Clear();
		All_cache = null;
	}

	public static MWarps New(Hashtable data)
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
			MWarps mWarps = Create(data);
			if (!_0024mst_0024117.ContainsKey(mWarps.Id))
			{
				_0024mst_0024117[mWarps.Id] = mWarps;
			}
			result = mWarps;
		}
		return (MWarps)result;
	}

	public static MWarps New2(string[] keys, object[] vals)
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
		return (MWarps)result;
	}

	public static MWarps Entry(MWarps mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024117[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MWarps)result;
	}

	public static void AddMst(MWarps mst)
	{
		if (mst != null)
		{
			_0024mst_0024117[mst.Id] = mst;
		}
	}

	public static MWarps Create(Hashtable data)
	{
		MWarps mWarps = new MWarps();
		MWarps result;
		if (data == null)
		{
			result = mWarps;
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
				mWarps.setField((string)obj, data[current]);
			}
			result = mWarps;
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
		case "SceneToWarp":
			_0024var_0024SceneToWarp = MasterBaseClass.ToInt(val);
			break;
		case "PositionObject":
			_0024var_0024PositionObject = MasterBaseClass.ToStringValue(val);
			break;
		case "NoSmoke":
			_0024var_0024NoSmoke = MasterBaseClass.ToBool(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Progname" => true, 
			"SceneToWarp" => true, 
			"PositionObject" => true, 
			"NoSmoke" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[5] { "Id", "Progname", "SceneToWarp", "PositionObject", "NoSmoke" });
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
						_0024var_0024SceneToWarp = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024PositionObject = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024NoSmoke = MasterBaseClass.ParseBool(vals[4]);
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
