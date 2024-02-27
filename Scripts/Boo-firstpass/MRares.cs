using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MRares : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Abbr;

	public string _0024var_0024Name;

	public string _0024var_0024Icon;

	[NonSerialized]
	private MTexts Name__cache;

	[NonSerialized]
	private static Dictionary<int, MRares> _0024mst_00247 = new Dictionary<int, MRares>();

	[NonSerialized]
	private static MRares[] All_cache;

	public int Id => _0024var_0024Id;

	public string Abbr => _0024var_0024Abbr;

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

	public string Icon => _0024var_0024Icon;

	public static MRares[] All
	{
		get
		{
			MRares[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MRares");
				MRares[] array = (MRares[])Builtins.array(typeof(MRares), _0024mst_00247.Values);
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
		return new StringBuilder("MRares(").Append((object)Id).Append(":").Append(Abbr)
			.Append(":")
			.Append(Name)
			.Append(")")
			.ToString();
	}

	public static implicit operator int(MRares m)
	{
		return m.Id;
	}

	public static MRares Get(int _id)
	{
		MerlinMaster.GetHandler("MRares");
		return (!_0024mst_00247.ContainsKey(_id)) ? null : _0024mst_00247[_id];
	}

	public static void Unload()
	{
		_0024mst_00247.Clear();
		All_cache = null;
	}

	public static MRares New(Hashtable data)
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
			MRares mRares = Create(data);
			if (!_0024mst_00247.ContainsKey(mRares.Id))
			{
				_0024mst_00247[mRares.Id] = mRares;
			}
			result = mRares;
		}
		return (MRares)result;
	}

	public static MRares New2(string[] keys, object[] vals)
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
		return (MRares)result;
	}

	public static MRares Entry(MRares mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_00247[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MRares)result;
	}

	public static void AddMst(MRares mst)
	{
		if (mst != null)
		{
			_0024mst_00247[mst.Id] = mst;
		}
	}

	public static MRares Create(Hashtable data)
	{
		MRares mRares = new MRares();
		MRares result;
		if (data == null)
		{
			result = mRares;
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
				mRares.setField((string)obj, data[current]);
			}
			result = mRares;
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
		case "Abbr":
			_0024var_0024Abbr = MasterBaseClass.ToStringValue(val);
			break;
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		case "Icon":
			_0024var_0024Icon = MasterBaseClass.ToStringValue(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Abbr" => true, 
			"Name" => true, 
			"Icon" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[4] { "Id", "Abbr", "Name", "Icon" });
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
					_0024var_0024Abbr = vals[1];
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024Name = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Icon = vals[3];
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
