using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MSe : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	public string _0024var_0024File;

	public EnumSeTypes _0024var_0024Type;

	public string _0024var_0024Group;

	[NonSerialized]
	private static Dictionary<int, MSe> _0024mst_002493 = new Dictionary<int, MSe>();

	[NonSerialized]
	private static MSe[] All_cache;

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

	public string File => _0024var_0024File;

	public EnumSeTypes Type => _0024var_0024Type;

	public string Group => _0024var_0024Group;

	public static MSe[] All
	{
		get
		{
			MSe[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MSe");
				MSe[] array = (MSe[])Builtins.array(typeof(MSe), _0024mst_002493.Values);
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

	public MSe()
	{
		_0024var_0024Type = (EnumSeTypes)(-1);
	}

	public override string ToString()
	{
		return new StringBuilder("MSe(").Append((object)Id).Append(",").Append(Progname)
			.Append(",")
			.Append(File)
			.Append(",")
			.Append(Type)
			.Append(")")
			.ToString();
	}

	public static MSe Get(int _id)
	{
		MerlinMaster.GetHandler("MSe");
		return (!_0024mst_002493.ContainsKey(_id)) ? null : _0024mst_002493[_id];
	}

	public static void Unload()
	{
		_0024mst_002493.Clear();
		All_cache = null;
	}

	public static MSe New(Hashtable data)
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
			MSe mSe = Create(data);
			if (!_0024mst_002493.ContainsKey(mSe.Id))
			{
				_0024mst_002493[mSe.Id] = mSe;
			}
			result = mSe;
		}
		return (MSe)result;
	}

	public static MSe New2(string[] keys, object[] vals)
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
		return (MSe)result;
	}

	public static MSe Entry(MSe mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002493[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MSe)result;
	}

	public static void AddMst(MSe mst)
	{
		if (mst != null)
		{
			_0024mst_002493[mst.Id] = mst;
		}
	}

	public static MSe Create(Hashtable data)
	{
		MSe mSe = new MSe();
		MSe result;
		if (data == null)
		{
			result = mSe;
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
				mSe.setField((string)obj, data[current]);
			}
			result = mSe;
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
		case "Type":
			if (typeof(EnumSeTypes).IsEnum)
			{
				_0024var_0024Type = (EnumSeTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "Group":
			_0024var_0024Group = MasterBaseClass.ToStringValue(val);
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
			"Type" => true, 
			"Group" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[5] { "Id", "Progname", "File", "Type", "Group" });
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
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null && typeof(EnumSeTypes).IsEnum)
						{
							_0024var_0024Type = (EnumSeTypes)MasterBaseClass.ParseEnum(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024Group = vals[4];
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
