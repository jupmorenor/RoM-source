using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MRaces : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public string _0024var_0024Progname;

	[NonSerialized]
	private MTexts Name__cache;

	[NonSerialized]
	private static Dictionary<int, MRaces> _0024mst_00249 = new Dictionary<int, MRaces>();

	[NonSerialized]
	private static MRaces[] All_cache;

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

	public static MRaces[] All
	{
		get
		{
			MRaces[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MRaces");
				MRaces[] array = (MRaces[])Builtins.array(typeof(MRaces), _0024mst_00249.Values);
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
		return new StringBuilder("MRaces(").Append((object)Id).Append(":").Append(Progname)
			.Append(":")
			.Append(Name)
			.Append(")")
			.ToString();
	}

	public static implicit operator int(MRaces m)
	{
		return m.Id;
	}

	public static MRaces Get(int _id)
	{
		MerlinMaster.GetHandler("MRaces");
		return (!_0024mst_00249.ContainsKey(_id)) ? null : _0024mst_00249[_id];
	}

	public static void Unload()
	{
		_0024mst_00249.Clear();
		All_cache = null;
	}

	public static MRaces New(Hashtable data)
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
			MRaces mRaces = Create(data);
			if (!_0024mst_00249.ContainsKey(mRaces.Id))
			{
				_0024mst_00249[mRaces.Id] = mRaces;
			}
			result = mRaces;
		}
		return (MRaces)result;
	}

	public static MRaces New2(string[] keys, object[] vals)
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
		return (MRaces)result;
	}

	public static MRaces Entry(MRaces mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_00249[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MRaces)result;
	}

	public static void AddMst(MRaces mst)
	{
		if (mst != null)
		{
			_0024mst_00249[mst.Id] = mst;
		}
	}

	public static MRaces Create(Hashtable data)
	{
		MRaces mRaces = new MRaces();
		MRaces result;
		if (data == null)
		{
			result = mRaces;
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
				mRaces.setField((string)obj, data[current]);
			}
			result = mRaces;
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
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Name" => true, 
			"Progname" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[3] { "Id", "Name", "Progname" });
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
					int num = 3;
					result = num;
				}
			}
		}
		return result;
	}
}
