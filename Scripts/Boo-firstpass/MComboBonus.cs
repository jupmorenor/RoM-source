using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MComboBonus : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024Level;

	public float _0024var_0024Bonus;

	public TimeSpan _0024var_0024Duration;

	[NonSerialized]
	private static Dictionary<int, MComboBonus> _0024mst_002428 = new Dictionary<int, MComboBonus>();

	[NonSerialized]
	private static MComboBonus[] All_cache;

	public int Id => _0024var_0024Id;

	public int Level => _0024var_0024Level;

	public float Bonus => _0024var_0024Bonus;

	public TimeSpan Duration => _0024var_0024Duration;

	public static MComboBonus[] All
	{
		get
		{
			MComboBonus[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MComboBonus");
				MComboBonus[] array = (MComboBonus[])Builtins.array(typeof(MComboBonus), _0024mst_002428.Values);
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

	public static MComboBonus FindByLevel(int level)
	{
		int num = 0;
		MComboBonus[] all = All;
		int length = all.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (all[num].Level == level)
				{
					result = all[num];
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = Get(1);
			break;
		}
		return (MComboBonus)result;
	}

	public static int GetMaxLevel()
	{
		int num = 0;
		int i = 0;
		MComboBonus[] all = All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (num < all[i].Level)
			{
				num = all[i].Level;
			}
		}
		return num;
	}

	public override string ToString()
	{
		return new StringBuilder("MComboBonus(").Append((object)Id).Append(" lv:").Append((object)Level)
			.Append(" bonus:")
			.Append(Bonus)
			.Append(" duration:")
			.Append(Duration)
			.Append(")")
			.ToString();
	}

	public static MComboBonus Get(int _id)
	{
		MerlinMaster.GetHandler("MComboBonus");
		return (!_0024mst_002428.ContainsKey(_id)) ? null : _0024mst_002428[_id];
	}

	public static void Unload()
	{
		_0024mst_002428.Clear();
		All_cache = null;
	}

	public static MComboBonus New(Hashtable data)
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
			MComboBonus mComboBonus = Create(data);
			if (!_0024mst_002428.ContainsKey(mComboBonus.Id))
			{
				_0024mst_002428[mComboBonus.Id] = mComboBonus;
			}
			result = mComboBonus;
		}
		return (MComboBonus)result;
	}

	public static MComboBonus New2(string[] keys, object[] vals)
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
		return (MComboBonus)result;
	}

	public static MComboBonus Entry(MComboBonus mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002428[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MComboBonus)result;
	}

	public static void AddMst(MComboBonus mst)
	{
		if (mst != null)
		{
			_0024mst_002428[mst.Id] = mst;
		}
	}

	public static MComboBonus Create(Hashtable data)
	{
		MComboBonus mComboBonus = new MComboBonus();
		MComboBonus result;
		if (data == null)
		{
			result = mComboBonus;
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
				mComboBonus.setField((string)obj, data[current]);
			}
			result = mComboBonus;
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
		case "Level":
			_0024var_0024Level = MasterBaseClass.ToInt(val);
			break;
		case "Bonus":
			_0024var_0024Bonus = MasterBaseClass.ToSingle(val);
			break;
		case "Duration":
		{
			object obj = val;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			_0024var_0024Duration = TimeSpan.Parse((string)obj);
			break;
		}
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Level" => true, 
			"Bonus" => true, 
			"Duration" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[4] { "Id", "Level", "Bonus", "Duration" });
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
					_0024var_0024Level = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024Bonus = MasterBaseClass.ParseSingle(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Duration = MasterBaseClass.ParseTimeSpan(vals[3]);
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
