using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MHonors : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024FlagName;

	public string _0024var_0024IOSName;

	public string _0024var_0024AndroidName;

	[NonSerialized]
	private static Dictionary<int, MHonors> _0024mst_0024115 = new Dictionary<int, MHonors>();

	[NonSerialized]
	private static MHonors[] All_cache;

	public int Id => _0024var_0024Id;

	public string FlagName => _0024var_0024FlagName;

	public string IOSName => _0024var_0024IOSName;

	public string AndroidName => _0024var_0024AndroidName;

	public static MHonors[] All
	{
		get
		{
			MHonors[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MHonors");
				MHonors[] array = (MHonors[])Builtins.array(typeof(MHonors), _0024mst_0024115.Values);
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
		return new StringBuilder("MFlags(").Append((object)Id).Append(",").Append(FlagName)
			.Append(",")
			.Append(IOSName)
			.Append(",")
			.Append(AndroidName)
			.Append(")")
			.ToString();
	}

	public static MHonors FindByFlagName(string n)
	{
		int num = 0;
		MHonors[] all = All;
		int length = all.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (all[num].FlagName == n)
				{
					result = all[num];
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = null;
			break;
		}
		return (MHonors)result;
	}

	public static MHonors Get(int _id)
	{
		MerlinMaster.GetHandler("MHonors");
		return (!_0024mst_0024115.ContainsKey(_id)) ? null : _0024mst_0024115[_id];
	}

	public static void Unload()
	{
		_0024mst_0024115.Clear();
		All_cache = null;
	}

	public static MHonors New(Hashtable data)
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
			MHonors mHonors = Create(data);
			if (!_0024mst_0024115.ContainsKey(mHonors.Id))
			{
				_0024mst_0024115[mHonors.Id] = mHonors;
			}
			result = mHonors;
		}
		return (MHonors)result;
	}

	public static MHonors New2(string[] keys, object[] vals)
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
		return (MHonors)result;
	}

	public static MHonors Entry(MHonors mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024115[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MHonors)result;
	}

	public static void AddMst(MHonors mst)
	{
		if (mst != null)
		{
			_0024mst_0024115[mst.Id] = mst;
		}
	}

	public static MHonors Create(Hashtable data)
	{
		MHonors mHonors = new MHonors();
		MHonors result;
		if (data == null)
		{
			result = mHonors;
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
				mHonors.setField((string)obj, data[current]);
			}
			result = mHonors;
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
		case "FlagName":
			_0024var_0024FlagName = MasterBaseClass.ToStringValue(val);
			break;
		case "IOSName":
			_0024var_0024IOSName = MasterBaseClass.ToStringValue(val);
			break;
		case "AndroidName":
			_0024var_0024AndroidName = MasterBaseClass.ToStringValue(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"FlagName" => true, 
			"IOSName" => true, 
			"AndroidName" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[4] { "Id", "FlagName", "IOSName", "AndroidName" });
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
					_0024var_0024FlagName = vals[1];
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024IOSName = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024AndroidName = vals[3];
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
