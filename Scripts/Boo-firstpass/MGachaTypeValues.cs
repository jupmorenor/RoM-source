using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MGachaTypeValues : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public string _0024var_0024Progname;

	[NonSerialized]
	private MTexts Name__cache;

	[NonSerialized]
	private static Dictionary<int, MGachaTypeValues> _0024mst_002424 = new Dictionary<int, MGachaTypeValues>();

	[NonSerialized]
	private static MGachaTypeValues[] All_cache;

	public int Id => _0024var_0024Id;

	public MTexts Name
	{
		get
		{
			if (Name__cache == null)
			{
				Name__cache = MTexts.Get(_0024var_0024Name);
			}
			return Name__cache;
		}
	}

	public string Progname => _0024var_0024Progname;

	public static MGachaTypeValues[] All
	{
		get
		{
			MGachaTypeValues[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MGachaTypeValues");
				MGachaTypeValues[] array = (MGachaTypeValues[])Builtins.array(typeof(MGachaTypeValues), _0024mst_002424.Values);
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
		return new StringBuilder("MGachaTypeValues(").Append((object)Id).Append(":").Append(Progname)
			.Append(":")
			.Append(Name)
			.Append(")")
			.ToString();
	}

	public static MGachaTypeValues Get(int _id)
	{
		MerlinMaster.GetHandler("MGachaTypeValues");
		return (!_0024mst_002424.ContainsKey(_id)) ? null : _0024mst_002424[_id];
	}

	public static void Unload()
	{
		_0024mst_002424.Clear();
		All_cache = null;
	}

	public static MGachaTypeValues New(Hashtable data)
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
			MGachaTypeValues mGachaTypeValues = Create(data);
			if (!_0024mst_002424.ContainsKey(mGachaTypeValues.Id))
			{
				_0024mst_002424[mGachaTypeValues.Id] = mGachaTypeValues;
			}
			result = mGachaTypeValues;
		}
		return (MGachaTypeValues)result;
	}

	public static MGachaTypeValues New2(string[] keys, object[] vals)
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
		return (MGachaTypeValues)result;
	}

	public static MGachaTypeValues Entry(MGachaTypeValues mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002424[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MGachaTypeValues)result;
	}

	public static void AddMst(MGachaTypeValues mst)
	{
		if (mst != null)
		{
			_0024mst_002424[mst.Id] = mst;
		}
	}

	public static MGachaTypeValues Create(Hashtable data)
	{
		MGachaTypeValues mGachaTypeValues = new MGachaTypeValues();
		MGachaTypeValues result;
		if (data == null)
		{
			result = mGachaTypeValues;
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
				mGachaTypeValues.setField((string)obj, data[current]);
			}
			result = mGachaTypeValues;
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
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		case "Progname":
			_0024var_0024Progname = MasterBaseClass.ToStringValue(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Name" => true, 
			"Progname" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[3] { "Id", "Name", "Progname" });
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
					_0024var_0024Name = vals[1];
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
					int num = 3;
					result = num;
				}
			}
		}
		return result;
	}
}
