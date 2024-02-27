using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MStyles : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public string _0024var_0024Progname;

	public string _0024var_0024MotPackName;

	public string _0024var_0024MotPackName2;

	public bool _0024var_0024IsLefty;

	public string _0024var_0024Icon;

	[NonSerialized]
	private MTexts Name__cache;

	[NonSerialized]
	private static Dictionary<int, MStyles> _0024mst_00246 = new Dictionary<int, MStyles>();

	[NonSerialized]
	private static MStyles[] All_cache;

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

	public string MotPackName => _0024var_0024MotPackName;

	public string MotPackName2 => _0024var_0024MotPackName2;

	public bool IsLefty => _0024var_0024IsLefty;

	public string Icon => _0024var_0024Icon;

	public static MStyles[] All
	{
		get
		{
			MStyles[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MStyles");
				MStyles[] array = (MStyles[])Builtins.array(typeof(MStyles), _0024mst_00246.Values);
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
		return new StringBuilder("MStyles(").Append((object)Id).Append(":").Append(Name)
			.Append(":")
			.Append(Progname)
			.Append(":")
			.Append(MotPackName)
			.Append(")")
			.ToString();
	}

	public static MStyles Get(int _id)
	{
		MerlinMaster.GetHandler("MStyles");
		return (!_0024mst_00246.ContainsKey(_id)) ? null : _0024mst_00246[_id];
	}

	public static void Unload()
	{
		_0024mst_00246.Clear();
		All_cache = null;
	}

	public static MStyles New(Hashtable data)
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
			MStyles mStyles = Create(data);
			if (!_0024mst_00246.ContainsKey(mStyles.Id))
			{
				_0024mst_00246[mStyles.Id] = mStyles;
			}
			result = mStyles;
		}
		return (MStyles)result;
	}

	public static MStyles New2(string[] keys, object[] vals)
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
		return (MStyles)result;
	}

	public static MStyles Entry(MStyles mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_00246[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MStyles)result;
	}

	public static void AddMst(MStyles mst)
	{
		if (mst != null)
		{
			_0024mst_00246[mst.Id] = mst;
		}
	}

	public static MStyles Create(Hashtable data)
	{
		MStyles mStyles = new MStyles();
		MStyles result;
		if (data == null)
		{
			result = mStyles;
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
				mStyles.setField((string)obj, data[current]);
			}
			result = mStyles;
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
		case "MotPackName":
			_0024var_0024MotPackName = MasterBaseClass.ToStringValue(val);
			break;
		case "MotPackName2":
			_0024var_0024MotPackName2 = MasterBaseClass.ToStringValue(val);
			break;
		case "IsLefty":
			_0024var_0024IsLefty = MasterBaseClass.ToBool(val);
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
			"Name" => true, 
			"Progname" => true, 
			"MotPackName" => true, 
			"MotPackName2" => true, 
			"IsLefty" => true, 
			"Icon" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[7] { "Id", "Name", "Progname", "MotPackName", "MotPackName2", "IsLefty", "Icon" });
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
							_0024var_0024MotPackName = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024MotPackName2 = vals[4];
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024IsLefty = MasterBaseClass.ParseBool(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024Icon = vals[6];
									}
									int num = 7;
									result = num;
								}
							}
						}
					}
				}
			}
		}
		return result;
	}
}
