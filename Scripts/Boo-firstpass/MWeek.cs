using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MWeek : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	public string _0024var_0024Name;

	[NonSerialized]
	private static Dictionary<int, MWeek> _0024mst_002431 = new Dictionary<int, MWeek>();

	[NonSerialized]
	private static MWeek[] All_cache;

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

	public string Name => _0024var_0024Name;

	public static MWeek[] All
	{
		get
		{
			MWeek[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MWeek");
				MWeek[] array = (MWeek[])Builtins.array(typeof(MWeek), _0024mst_002431.Values);
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
		return new StringBuilder("MWeek(").Append((object)Id).Append(",").Append(Progname)
			.Append(")")
			.ToString();
	}

	public static MWeek Get(int _id)
	{
		MerlinMaster.GetHandler("MWeek");
		return (!_0024mst_002431.ContainsKey(_id)) ? null : _0024mst_002431[_id];
	}

	public static void Unload()
	{
		_0024mst_002431.Clear();
		All_cache = null;
	}

	public static MWeek New(Hashtable data)
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
			MWeek mWeek = Create(data);
			if (!_0024mst_002431.ContainsKey(mWeek.Id))
			{
				_0024mst_002431[mWeek.Id] = mWeek;
			}
			result = mWeek;
		}
		return (MWeek)result;
	}

	public static MWeek New2(string[] keys, object[] vals)
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
		return (MWeek)result;
	}

	public static MWeek Entry(MWeek mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002431[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MWeek)result;
	}

	public static void AddMst(MWeek mst)
	{
		if (mst != null)
		{
			_0024mst_002431[mst.Id] = mst;
		}
	}

	public static MWeek Create(Hashtable data)
	{
		MWeek mWeek = new MWeek();
		MWeek result;
		if (data == null)
		{
			result = mWeek;
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
				mWeek.setField((string)obj, data[current]);
			}
			result = mWeek;
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
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Progname" => true, 
			"Name" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[3] { "Id", "Progname", "Name" });
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
					int num = 3;
					result = num;
				}
			}
		}
		return result;
	}
}
