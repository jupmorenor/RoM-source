using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MTexts : MerlinMaster
{
	public string _0024var_0024Id;

	public string _0024var_0024Jp;

	public string _0024var_0024En;

	[NonSerialized]
	private static Dictionary<string, MTexts> _0024mst_00242 = new Dictionary<string, MTexts>();

	[NonSerialized]
	private static MTexts[] All_cache;

	public string msg => (MerlinLanguageSetting.GetCurrentLanguage() != 0) ? En : Jp;

	public string Id => _0024var_0024Id;

	public string Jp => _0024var_0024Jp;

	public string En => _0024var_0024En;

	public static MTexts[] All
	{
		get
		{
			MTexts[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MTexts");
				MTexts[] array = (MTexts[])Builtins.array(typeof(MTexts), _0024mst_00242.Values);
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

	public MTexts()
	{
		_0024var_0024Jp = string.Empty;
		_0024var_0024En = string.Empty;
	}

	public static string Msg(string id)
	{
		MTexts mTexts = Get(id);
		return (mTexts != null) ? mTexts.msg : string.Empty;
	}

	public static string Format(string id, object arg0)
	{
		return string.Format(Msg(id), arg0);
	}

	public static string Format(string id, object arg0, object arg1)
	{
		return string.Format(Msg(id), arg0, arg1);
	}

	public static string Format(string id, object arg0, object arg1, object arg2)
	{
		return string.Format(Msg(id), arg0, arg1, arg2);
	}

	public override string ToString()
	{
		return msg;
	}

	public static MTexts Get(string _id)
	{
		MerlinMaster.GetHandler("MTexts");
		return (!_0024mst_00242.ContainsKey(_id)) ? null : _0024mst_00242[_id];
	}

	public static void Unload()
	{
		_0024mst_00242.Clear();
		All_cache = null;
	}

	public static MTexts New(Hashtable data)
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
			MTexts mTexts = Create(data);
			if (!_0024mst_00242.ContainsKey(mTexts.Id))
			{
				_0024mst_00242[mTexts.Id] = mTexts;
			}
			result = mTexts;
		}
		return (MTexts)result;
	}

	public static MTexts New2(string[] keys, object[] vals)
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
		return (MTexts)result;
	}

	public static MTexts Entry(MTexts mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			Dictionary<string, MTexts> dictionary = _0024mst_00242;
			object obj = id;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			dictionary[(string)obj] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MTexts)result;
	}

	public static void AddMst(MTexts mst)
	{
		if (mst != null)
		{
			_0024mst_00242[mst.Id] = mst;
		}
	}

	public static MTexts Create(Hashtable data)
	{
		MTexts mTexts = new MTexts();
		MTexts result;
		if (data == null)
		{
			result = mTexts;
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
				mTexts.setField((string)obj, data[current]);
			}
			result = mTexts;
		}
		return result;
	}

	public void setField(string key, object val)
	{
		switch (key)
		{
		case "Id":
			_0024var_0024Id = MasterBaseClass.ToStringValue(val);
			break;
		case "Jp":
			_0024var_0024Jp = MasterBaseClass.ToStringValue(val);
			break;
		case "En":
			_0024var_0024En = MasterBaseClass.ToStringValue(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Jp" => true, 
			"En" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[3] { "Id", "Jp", "En" });
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
				_0024var_0024Id = vals[0];
			}
			if (length <= 1)
			{
				result = 1;
			}
			else
			{
				if (vals[1] != null)
				{
					_0024var_0024Jp = vals[1];
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024En = vals[2];
					}
					int num = 3;
					result = num;
				}
			}
		}
		return result;
	}
}
