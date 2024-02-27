using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MSceneBgm : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024Bgm;

	public string _0024var_0024IncludeSceneName;

	public string _0024var_0024IgnorePrevSceneName;

	[NonSerialized]
	private MBgm Bgm__cache;

	[NonSerialized]
	private static Dictionary<int, MSceneBgm> _0024mst_0024109 = new Dictionary<int, MSceneBgm>();

	[NonSerialized]
	private static MSceneBgm[] All_cache;

	public int Id => _0024var_0024Id;

	public MBgm Bgm
	{
		get
		{
			if (Bgm__cache == null)
			{
				Bgm__cache = MBgm.Get(_0024var_0024Bgm);
			}
			return Bgm__cache;
		}
	}

	public string IncludeSceneName => _0024var_0024IncludeSceneName;

	public string IgnorePrevSceneName => _0024var_0024IgnorePrevSceneName;

	public static MSceneBgm[] All
	{
		get
		{
			MSceneBgm[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MSceneBgm");
				MSceneBgm[] array = (MSceneBgm[])Builtins.array(typeof(MSceneBgm), _0024mst_0024109.Values);
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

	public MSceneBgm()
	{
		_0024var_0024Bgm = -1;
	}

	public static MSceneBgm Get(int _id)
	{
		MerlinMaster.GetHandler("MSceneBgm");
		return (!_0024mst_0024109.ContainsKey(_id)) ? null : _0024mst_0024109[_id];
	}

	public static void Unload()
	{
		_0024mst_0024109.Clear();
		All_cache = null;
	}

	public static MSceneBgm New(Hashtable data)
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
			MSceneBgm mSceneBgm = Create(data);
			if (!_0024mst_0024109.ContainsKey(mSceneBgm.Id))
			{
				_0024mst_0024109[mSceneBgm.Id] = mSceneBgm;
			}
			result = mSceneBgm;
		}
		return (MSceneBgm)result;
	}

	public static MSceneBgm New2(string[] keys, object[] vals)
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
		return (MSceneBgm)result;
	}

	public static MSceneBgm Entry(MSceneBgm mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024109[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MSceneBgm)result;
	}

	public static void AddMst(MSceneBgm mst)
	{
		if (mst != null)
		{
			_0024mst_0024109[mst.Id] = mst;
		}
	}

	public static MSceneBgm Create(Hashtable data)
	{
		MSceneBgm mSceneBgm = new MSceneBgm();
		MSceneBgm result;
		if (data == null)
		{
			result = mSceneBgm;
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
				mSceneBgm.setField((string)obj, data[current]);
			}
			result = mSceneBgm;
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
		case "Bgm":
			_0024var_0024Bgm = MasterBaseClass.ToInt(val);
			break;
		case "IncludeSceneName":
			_0024var_0024IncludeSceneName = MasterBaseClass.ToStringValue(val);
			break;
		case "IgnorePrevSceneName":
			_0024var_0024IgnorePrevSceneName = MasterBaseClass.ToStringValue(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Bgm" => true, 
			"IncludeSceneName" => true, 
			"IgnorePrevSceneName" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[4] { "Id", "Bgm", "IncludeSceneName", "IgnorePrevSceneName" });
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
					_0024var_0024Bgm = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024IncludeSceneName = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024IgnorePrevSceneName = vals[3];
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
