using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MQuestTypes : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	[NonSerialized]
	private static Dictionary<int, MQuestTypes> _0024mst_002473 = new Dictionary<int, MQuestTypes>();

	[NonSerialized]
	private static MQuestTypes[] All_cache;

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

	public static MQuestTypes[] All
	{
		get
		{
			MQuestTypes[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MQuestTypes");
				MQuestTypes[] array = (MQuestTypes[])Builtins.array(typeof(MQuestTypes), _0024mst_002473.Values);
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

	public static MQuestTypes Get(int _id)
	{
		MerlinMaster.GetHandler("MQuestTypes");
		return (!_0024mst_002473.ContainsKey(_id)) ? null : _0024mst_002473[_id];
	}

	public static void Unload()
	{
		_0024mst_002473.Clear();
		All_cache = null;
	}

	public static MQuestTypes New(Hashtable data)
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
			MQuestTypes mQuestTypes = Create(data);
			if (!_0024mst_002473.ContainsKey(mQuestTypes.Id))
			{
				_0024mst_002473[mQuestTypes.Id] = mQuestTypes;
			}
			result = mQuestTypes;
		}
		return (MQuestTypes)result;
	}

	public static MQuestTypes New2(string[] keys, object[] vals)
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
		return (MQuestTypes)result;
	}

	public static MQuestTypes Entry(MQuestTypes mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002473[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MQuestTypes)result;
	}

	public static void AddMst(MQuestTypes mst)
	{
		if (mst != null)
		{
			_0024mst_002473[mst.Id] = mst;
		}
	}

	public static MQuestTypes Create(Hashtable data)
	{
		MQuestTypes mQuestTypes = new MQuestTypes();
		MQuestTypes result;
		if (data == null)
		{
			result = mQuestTypes;
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
				mQuestTypes.setField((string)obj, data[current]);
			}
			result = mQuestTypes;
		}
		return result;
	}

	public void setField(string key, object val)
	{
		if (key == "Id")
		{
			_0024var_0024Id = MasterBaseClass.ToInt(val);
		}
		else if (key == "Progname")
		{
			_0024var_0024Progname = MasterBaseClass.ToStringValue(val);
		}
	}

	public static bool HasKey(string key)
	{
		return key == "Id" || key == "Progname";
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[2] { "Id", "Progname" });
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
				int num = 2;
				result = num;
			}
		}
		return result;
	}
}
