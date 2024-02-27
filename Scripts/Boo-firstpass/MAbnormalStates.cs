using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class MAbnormalStates : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	public string _0024var_0024Name;

	public string _0024var_0024Icon;

	[NonSerialized]
	private static Dictionary<int, MAbnormalStates> _0024mst_002433 = new Dictionary<int, MAbnormalStates>();

	[NonSerialized]
	private static MAbnormalStates[] All_cache;

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

	public string Name => _0024var_0024Name;

	public string Icon => _0024var_0024Icon;

	public static MAbnormalStates[] All
	{
		get
		{
			MAbnormalStates[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MAbnormalStates");
				MAbnormalStates[] array = (MAbnormalStates[])Builtins.array(typeof(MAbnormalStates), _0024mst_002433.Values);
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
		return new StringBuilder("MAbnormalStates(").Append((object)Id).Append(",").Append(Progname)
			.Append(" Time:")
			.Append(typeof(Time))
			.Append(")")
			.ToString();
	}

	public static MAbnormalStates Get(int _id)
	{
		MerlinMaster.GetHandler("MAbnormalStates");
		return (!_0024mst_002433.ContainsKey(_id)) ? null : _0024mst_002433[_id];
	}

	public static void Unload()
	{
		_0024mst_002433.Clear();
		All_cache = null;
	}

	public static MAbnormalStates New(Hashtable data)
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
			MAbnormalStates mAbnormalStates = Create(data);
			if (!_0024mst_002433.ContainsKey(mAbnormalStates.Id))
			{
				_0024mst_002433[mAbnormalStates.Id] = mAbnormalStates;
			}
			result = mAbnormalStates;
		}
		return (MAbnormalStates)result;
	}

	public static MAbnormalStates New2(string[] keys, object[] vals)
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
		return (MAbnormalStates)result;
	}

	public static MAbnormalStates Entry(MAbnormalStates mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002433[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MAbnormalStates)result;
	}

	public static void AddMst(MAbnormalStates mst)
	{
		if (mst != null)
		{
			_0024mst_002433[mst.Id] = mst;
		}
	}

	public static MAbnormalStates Create(Hashtable data)
	{
		MAbnormalStates mAbnormalStates = new MAbnormalStates();
		MAbnormalStates result;
		if (data == null)
		{
			result = mAbnormalStates;
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
				mAbnormalStates.setField((string)obj, data[current]);
			}
			result = mAbnormalStates;
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
			"Progname" => true, 
			"Name" => true, 
			"Icon" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[4] { "Id", "Progname", "Name", "Icon" });
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