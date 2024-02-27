using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MPoints : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public string _0024var_0024Explain;

	public string _0024var_0024Progname;

	[NonSerialized]
	private static Dictionary<int, MPoints> _0024mst_0024126 = new Dictionary<int, MPoints>();

	[NonSerialized]
	private static MPoints[] All_cache;

	public int Id => _0024var_0024Id;

	public string Name => _0024var_0024Name;

	public string Explain => _0024var_0024Explain;

	public string Progname => _0024var_0024Progname;

	public static MPoints[] All
	{
		get
		{
			MPoints[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MPoints");
				MPoints[] array = (MPoints[])Builtins.array(typeof(MPoints), _0024mst_0024126.Values);
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
		return new StringBuilder("MPoints(").Append((object)Id).Append(",").Append(Name)
			.Append(")")
			.ToString();
	}

	public static MPoints Get(int _id)
	{
		MerlinMaster.GetHandler("MPoints");
		return (!_0024mst_0024126.ContainsKey(_id)) ? null : _0024mst_0024126[_id];
	}

	public static void Unload()
	{
		_0024mst_0024126.Clear();
		All_cache = null;
	}

	public static MPoints New(Hashtable data)
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
			MPoints mPoints = Create(data);
			if (!_0024mst_0024126.ContainsKey(mPoints.Id))
			{
				_0024mst_0024126[mPoints.Id] = mPoints;
			}
			result = mPoints;
		}
		return (MPoints)result;
	}

	public static MPoints New2(string[] keys, object[] vals)
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
		return (MPoints)result;
	}

	public static MPoints Entry(MPoints mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024126[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MPoints)result;
	}

	public static void AddMst(MPoints mst)
	{
		if (mst != null)
		{
			_0024mst_0024126[mst.Id] = mst;
		}
	}

	public static MPoints Create(Hashtable data)
	{
		MPoints mPoints = new MPoints();
		MPoints result;
		if (data == null)
		{
			result = mPoints;
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
				mPoints.setField((string)obj, data[current]);
			}
			result = mPoints;
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
		case "Explain":
			_0024var_0024Explain = MasterBaseClass.ToStringValue(val);
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
			"Explain" => true, 
			"Progname" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[4] { "Id", "Name", "Explain", "Progname" });
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
						_0024var_0024Explain = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Progname = vals[3];
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
