using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MNpcTalkIcons : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public string _0024var_0024Icon;

	[NonSerialized]
	private static Dictionary<int, MNpcTalkIcons> _0024mst_002461 = new Dictionary<int, MNpcTalkIcons>();

	[NonSerialized]
	private static MNpcTalkIcons[] All_cache;

	public int Id => _0024var_0024Id;

	public string Name => _0024var_0024Name;

	public string Icon => _0024var_0024Icon;

	public static MNpcTalkIcons[] All
	{
		get
		{
			MNpcTalkIcons[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MNpcTalkIcons");
				MNpcTalkIcons[] array = (MNpcTalkIcons[])Builtins.array(typeof(MNpcTalkIcons), _0024mst_002461.Values);
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

	public static MNpcTalkIcons Get(int _id)
	{
		MerlinMaster.GetHandler("MNpcTalkIcons");
		return (!_0024mst_002461.ContainsKey(_id)) ? null : _0024mst_002461[_id];
	}

	public static void Unload()
	{
		_0024mst_002461.Clear();
		All_cache = null;
	}

	public static MNpcTalkIcons New(Hashtable data)
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
			MNpcTalkIcons mNpcTalkIcons = Create(data);
			if (!_0024mst_002461.ContainsKey(mNpcTalkIcons.Id))
			{
				_0024mst_002461[mNpcTalkIcons.Id] = mNpcTalkIcons;
			}
			result = mNpcTalkIcons;
		}
		return (MNpcTalkIcons)result;
	}

	public static MNpcTalkIcons New2(string[] keys, object[] vals)
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
		return (MNpcTalkIcons)result;
	}

	public static MNpcTalkIcons Entry(MNpcTalkIcons mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002461[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MNpcTalkIcons)result;
	}

	public static void AddMst(MNpcTalkIcons mst)
	{
		if (mst != null)
		{
			_0024mst_002461[mst.Id] = mst;
		}
	}

	public static MNpcTalkIcons Create(Hashtable data)
	{
		MNpcTalkIcons mNpcTalkIcons = new MNpcTalkIcons();
		MNpcTalkIcons result;
		if (data == null)
		{
			result = mNpcTalkIcons;
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
				mNpcTalkIcons.setField((string)obj, data[current]);
			}
			result = mNpcTalkIcons;
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
			"Icon" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[3] { "Id", "Name", "Icon" });
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
						_0024var_0024Icon = vals[2];
					}
					int num = 3;
					result = num;
				}
			}
		}
		return result;
	}
}
