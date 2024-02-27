using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MKusamushi : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	[NonSerialized]
	private static Dictionary<int, MKusamushi> _0024mst_002477 = new Dictionary<int, MKusamushi>();

	[NonSerialized]
	private static MKusamushi[] All_cache;

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

	public static MKusamushi[] All
	{
		get
		{
			MKusamushi[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MKusamushi");
				MKusamushi[] array = (MKusamushi[])Builtins.array(typeof(MKusamushi), _0024mst_002477.Values);
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
		return new StringBuilder("MKusamushi(").Append((object)Id).Append(",").Append(Progname)
			.Append(")")
			.ToString();
	}

	public static MKusamushi Get(int _id)
	{
		MerlinMaster.GetHandler("MKusamushi");
		return (!_0024mst_002477.ContainsKey(_id)) ? null : _0024mst_002477[_id];
	}

	public static void Unload()
	{
		_0024mst_002477.Clear();
		All_cache = null;
	}

	public static MKusamushi New(Hashtable data)
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
			MKusamushi mKusamushi = Create(data);
			if (!_0024mst_002477.ContainsKey(mKusamushi.Id))
			{
				_0024mst_002477[mKusamushi.Id] = mKusamushi;
			}
			result = mKusamushi;
		}
		return (MKusamushi)result;
	}

	public static MKusamushi New2(string[] keys, object[] vals)
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
		return (MKusamushi)result;
	}

	public static MKusamushi Entry(MKusamushi mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002477[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MKusamushi)result;
	}

	public static void AddMst(MKusamushi mst)
	{
		if (mst != null)
		{
			_0024mst_002477[mst.Id] = mst;
		}
	}

	public static MKusamushi Create(Hashtable data)
	{
		MKusamushi mKusamushi = new MKusamushi();
		MKusamushi result;
		if (data == null)
		{
			result = mKusamushi;
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
				mKusamushi.setField((string)obj, data[current]);
			}
			result = mKusamushi;
		}
		return result;
	}

	public void setField(string key, object val)
	{
		if (key == "Id")
		{
			_0024var_0024Id = MasterBaseClass.ToInt(val);
		}
		else if (key == "Progname")
		{
			_0024var_0024Progname = MasterBaseClass.ToStringValue(val);
		}
	}

	public static bool HasKey(string key)
	{
		return key == "Id" || key == "Progname";
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[2] { "Id", "Progname" });
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
				int num = 2;
				result = num;
			}
		}
		return result;
	}
}
