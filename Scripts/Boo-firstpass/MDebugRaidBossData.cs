using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MDebugRaidBossData : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MonsterId;

	public int _0024var_0024Level;

	[NonSerialized]
	private static Dictionary<int, MDebugRaidBossData> _0024mst_002435 = new Dictionary<int, MDebugRaidBossData>();

	[NonSerialized]
	private static MDebugRaidBossData[] All_cache;

	public int Id => _0024var_0024Id;

	public int MonsterId => _0024var_0024MonsterId;

	public int Level => _0024var_0024Level;

	public static MDebugRaidBossData[] All
	{
		get
		{
			MDebugRaidBossData[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MDebugRaidBossData");
				MDebugRaidBossData[] array = (MDebugRaidBossData[])Builtins.array(typeof(MDebugRaidBossData), _0024mst_002435.Values);
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
		return new StringBuilder("MDebugRaidBossData(").Append((object)MonsterId).Append(") lv:").Append((object)Level)
			.Append(")")
			.ToString();
	}

	public static MDebugRaidBossData Get(int _id)
	{
		MerlinMaster.GetHandler("MDebugRaidBossData");
		return (!_0024mst_002435.ContainsKey(_id)) ? null : _0024mst_002435[_id];
	}

	public static void Unload()
	{
		_0024mst_002435.Clear();
		All_cache = null;
	}

	public static MDebugRaidBossData New(Hashtable data)
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
			MDebugRaidBossData mDebugRaidBossData = Create(data);
			if (!_0024mst_002435.ContainsKey(mDebugRaidBossData.Id))
			{
				_0024mst_002435[mDebugRaidBossData.Id] = mDebugRaidBossData;
			}
			result = mDebugRaidBossData;
		}
		return (MDebugRaidBossData)result;
	}

	public static MDebugRaidBossData New2(string[] keys, object[] vals)
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
		return (MDebugRaidBossData)result;
	}

	public static MDebugRaidBossData Entry(MDebugRaidBossData mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002435[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MDebugRaidBossData)result;
	}

	public static void AddMst(MDebugRaidBossData mst)
	{
		if (mst != null)
		{
			_0024mst_002435[mst.Id] = mst;
		}
	}

	public static MDebugRaidBossData Create(Hashtable data)
	{
		MDebugRaidBossData mDebugRaidBossData = new MDebugRaidBossData();
		MDebugRaidBossData result;
		if (data == null)
		{
			result = mDebugRaidBossData;
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
				mDebugRaidBossData.setField((string)obj, data[current]);
			}
			result = mDebugRaidBossData;
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
		case "MonsterId":
			_0024var_0024MonsterId = MasterBaseClass.ToInt(val);
			break;
		case "Level":
			_0024var_0024Level = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"MonsterId" => true, 
			"Level" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[3] { "Id", "MonsterId", "Level" });
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
					_0024var_0024MonsterId = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024Level = MasterBaseClass.ParseInt(vals[2]);
					}
					int num = 3;
					result = num;
				}
			}
		}
		return result;
	}
}
