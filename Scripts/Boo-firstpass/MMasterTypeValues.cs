using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MMasterTypeValues : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public string _0024var_0024Progname;

	public string _0024var_0024Icon;

	public string _0024var_0024Name_DisplayFormat;

	[NonSerialized]
	private MTexts Name__cache;

	[NonSerialized]
	private MTexts Name_DisplayFormat__cache;

	[NonSerialized]
	private static Dictionary<int, MMasterTypeValues> _0024mst_002421 = new Dictionary<int, MMasterTypeValues>();

	[NonSerialized]
	private static MMasterTypeValues[] All_cache;

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

	public string Icon => _0024var_0024Icon;

	public MTexts Name_DisplayFormat
	{
		get
		{
			if (Name_DisplayFormat__cache == null)
			{
				Name_DisplayFormat__cache = MTexts.Get(_0024var_0024Name_DisplayFormat);
			}
			return Name_DisplayFormat__cache;
		}
	}

	public static MMasterTypeValues[] All
	{
		get
		{
			MMasterTypeValues[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MMasterTypeValues");
				MMasterTypeValues[] array = (MMasterTypeValues[])Builtins.array(typeof(MMasterTypeValues), _0024mst_002421.Values);
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
		return new StringBuilder("MMasterTypeValues(").Append((object)Id).Append(":").Append(Progname)
			.Append(":")
			.Append(Name)
			.Append(")")
			.ToString();
	}

	public static implicit operator int(MMasterTypeValues m)
	{
		return m.Id;
	}

	public static MMasterTypeValues Get(int _id)
	{
		MerlinMaster.GetHandler("MMasterTypeValues");
		return (!_0024mst_002421.ContainsKey(_id)) ? null : _0024mst_002421[_id];
	}

	public static void Unload()
	{
		_0024mst_002421.Clear();
		All_cache = null;
	}

	public static MMasterTypeValues New(Hashtable data)
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
			MMasterTypeValues mMasterTypeValues = Create(data);
			if (!_0024mst_002421.ContainsKey(mMasterTypeValues.Id))
			{
				_0024mst_002421[mMasterTypeValues.Id] = mMasterTypeValues;
			}
			result = mMasterTypeValues;
		}
		return (MMasterTypeValues)result;
	}

	public static MMasterTypeValues New2(string[] keys, object[] vals)
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
		return (MMasterTypeValues)result;
	}

	public static MMasterTypeValues Entry(MMasterTypeValues mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002421[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MMasterTypeValues)result;
	}

	public static void AddMst(MMasterTypeValues mst)
	{
		if (mst != null)
		{
			_0024mst_002421[mst.Id] = mst;
		}
	}

	public static MMasterTypeValues Create(Hashtable data)
	{
		MMasterTypeValues mMasterTypeValues = new MMasterTypeValues();
		MMasterTypeValues result;
		if (data == null)
		{
			result = mMasterTypeValues;
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
				mMasterTypeValues.setField((string)obj, data[current]);
			}
			result = mMasterTypeValues;
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
		case "Icon":
			_0024var_0024Icon = MasterBaseClass.ToStringValue(val);
			break;
		case "Name_DisplayFormat":
			_0024var_0024Name_DisplayFormat = MasterBaseClass.ToStringValue(val);
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
			"Icon" => true, 
			"Name_DisplayFormat" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[5] { "Id", "Name", "Progname", "Icon", "Name_DisplayFormat" });
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
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024Name_DisplayFormat = vals[4];
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
