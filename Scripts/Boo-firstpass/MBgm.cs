using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MBgm : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	public string _0024var_0024File;

	[NonSerialized]
	private static Dictionary<int, MBgm> _0024mst_002492 = new Dictionary<int, MBgm>();

	[NonSerialized]
	private static MBgm[] All_cache;

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

	public string File => _0024var_0024File;

	public static MBgm[] All
	{
		get
		{
			MBgm[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MBgm");
				MBgm[] array = (MBgm[])Builtins.array(typeof(MBgm), _0024mst_002492.Values);
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
		return new StringBuilder("MBgm(").Append((object)Id).Append(",").Append(Progname)
			.Append(",")
			.Append(File)
			.Append(")")
			.ToString();
	}

	public static MBgm Get(int _id)
	{
		MerlinMaster.GetHandler("MBgm");
		return (!_0024mst_002492.ContainsKey(_id)) ? null : _0024mst_002492[_id];
	}

	public static void Unload()
	{
		_0024mst_002492.Clear();
		All_cache = null;
	}

	public static MBgm New(Hashtable data)
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
			MBgm mBgm = Create(data);
			if (!_0024mst_002492.ContainsKey(mBgm.Id))
			{
				_0024mst_002492[mBgm.Id] = mBgm;
			}
			result = mBgm;
		}
		return (MBgm)result;
	}

	public static MBgm New2(string[] keys, object[] vals)
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
		return (MBgm)result;
	}

	public static MBgm Entry(MBgm mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002492[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MBgm)result;
	}

	public static void AddMst(MBgm mst)
	{
		if (mst != null)
		{
			_0024mst_002492[mst.Id] = mst;
		}
	}

	public static MBgm Create(Hashtable data)
	{
		MBgm mBgm = new MBgm();
		MBgm result;
		if (data == null)
		{
			result = mBgm;
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
				mBgm.setField((string)obj, data[current]);
			}
			result = mBgm;
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
		case "File":
			_0024var_0024File = MasterBaseClass.ToStringValue(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Progname" => true, 
			"File" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[3] { "Id", "Progname", "File" });
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
						_0024var_0024File = vals[2];
					}
					int num = 3;
					result = num;
				}
			}
		}
		return result;
	}
}
