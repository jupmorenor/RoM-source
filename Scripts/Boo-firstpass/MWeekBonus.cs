using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MWeekBonus : MerlinMaster
{
	public int _0024var_0024Id;

	public EnumWeek _0024var_0024Week;

	public EnumElements _0024var_0024MElementId;

	public EnumStyles _0024var_0024MStyleId;

	[NonSerialized]
	private static Dictionary<int, MWeekBonus> _0024mst_0024103 = new Dictionary<int, MWeekBonus>();

	[NonSerialized]
	private static MWeekBonus[] All_cache;

	public int Id => _0024var_0024Id;

	public EnumWeek Week => _0024var_0024Week;

	public EnumElements MElementId => _0024var_0024MElementId;

	public EnumStyles MStyleId => _0024var_0024MStyleId;

	public static MWeekBonus[] All
	{
		get
		{
			MWeekBonus[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MWeekBonus");
				MWeekBonus[] array = (MWeekBonus[])Builtins.array(typeof(MWeekBonus), _0024mst_0024103.Values);
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
		return new StringBuilder("MWeekBonus(").Append((object)Id).Append(",").Append(Week)
			.Append(",")
			.Append(MElementId)
			.Append(",")
			.Append(MStyleId)
			.Append(")")
			.ToString();
	}

	public static MWeekBonus Get(int _id)
	{
		MerlinMaster.GetHandler("MWeekBonus");
		return (!_0024mst_0024103.ContainsKey(_id)) ? null : _0024mst_0024103[_id];
	}

	public static void Unload()
	{
		_0024mst_0024103.Clear();
		All_cache = null;
	}

	public static MWeekBonus New(Hashtable data)
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
			MWeekBonus mWeekBonus = Create(data);
			if (!_0024mst_0024103.ContainsKey(mWeekBonus.Id))
			{
				_0024mst_0024103[mWeekBonus.Id] = mWeekBonus;
			}
			result = mWeekBonus;
		}
		return (MWeekBonus)result;
	}

	public static MWeekBonus New2(string[] keys, object[] vals)
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
		return (MWeekBonus)result;
	}

	public static MWeekBonus Entry(MWeekBonus mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024103[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MWeekBonus)result;
	}

	public static void AddMst(MWeekBonus mst)
	{
		if (mst != null)
		{
			_0024mst_0024103[mst.Id] = mst;
		}
	}

	public static MWeekBonus Create(Hashtable data)
	{
		MWeekBonus mWeekBonus = new MWeekBonus();
		MWeekBonus result;
		if (data == null)
		{
			result = mWeekBonus;
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
				mWeekBonus.setField((string)obj, data[current]);
			}
			result = mWeekBonus;
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
		case "Week":
			if (typeof(EnumWeek).IsEnum)
			{
				_0024var_0024Week = (EnumWeek)MasterBaseClass.ToEnum(val);
			}
			break;
		case "MElementId":
			if (typeof(EnumElements).IsEnum)
			{
				_0024var_0024MElementId = (EnumElements)MasterBaseClass.ToEnum(val);
			}
			break;
		case "MStyleId":
			if (typeof(EnumStyles).IsEnum)
			{
				_0024var_0024MStyleId = (EnumStyles)MasterBaseClass.ToEnum(val);
			}
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Week" => true, 
			"MElementId" => true, 
			"MStyleId" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[4] { "Id", "Week", "MElementId", "MStyleId" });
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
				if (vals[1] != null && typeof(EnumWeek).IsEnum)
				{
					_0024var_0024Week = (EnumWeek)MasterBaseClass.ParseEnum(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null && typeof(EnumElements).IsEnum)
					{
						_0024var_0024MElementId = (EnumElements)MasterBaseClass.ParseEnum(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null && typeof(EnumStyles).IsEnum)
						{
							_0024var_0024MStyleId = (EnumStyles)MasterBaseClass.ParseEnum(vals[3]);
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
