using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MStages : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MAreaId;

	[NonSerialized]
	private MAreas MAreaId__cache;

	[NonSerialized]
	private static Dictionary<int, MStages> _0024mst_002467 = new Dictionary<int, MStages>();

	[NonSerialized]
	private static MStages[] All_cache;

	public int Id => _0024var_0024Id;

	public MAreas MAreaId
	{
		get
		{
			if (MAreaId__cache == null)
			{
				MAreaId__cache = MAreas.Get(_0024var_0024MAreaId);
			}
			return MAreaId__cache;
		}
	}

	public static MStages[] All
	{
		get
		{
			MStages[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MStages");
				MStages[] array = (MStages[])Builtins.array(typeof(MStages), _0024mst_002467.Values);
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
		return new StringBuilder("MStages(Id:").Append((object)Id).Append(")").ToString();
	}

	public static MStages Get(int _id)
	{
		MerlinMaster.GetHandler("MStages");
		return (!_0024mst_002467.ContainsKey(_id)) ? null : _0024mst_002467[_id];
	}

	public static void Unload()
	{
		_0024mst_002467.Clear();
		All_cache = null;
	}

	public static MStages New(Hashtable data)
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
			MStages mStages = Create(data);
			if (!_0024mst_002467.ContainsKey(mStages.Id))
			{
				_0024mst_002467[mStages.Id] = mStages;
			}
			result = mStages;
		}
		return (MStages)result;
	}

	public static MStages New2(string[] keys, object[] vals)
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
		return (MStages)result;
	}

	public static MStages Entry(MStages mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002467[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MStages)result;
	}

	public static void AddMst(MStages mst)
	{
		if (mst != null)
		{
			_0024mst_002467[mst.Id] = mst;
		}
	}

	public static MStages Create(Hashtable data)
	{
		MStages mStages = new MStages();
		MStages result;
		if (data == null)
		{
			result = mStages;
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
				mStages.setField((string)obj, data[current]);
			}
			result = mStages;
		}
		return result;
	}

	public void setField(string key, object val)
	{
		if (key == "Id")
		{
			_0024var_0024Id = MasterBaseClass.ToInt(val);
		}
		else if (key == "MAreaId")
		{
			_0024var_0024MAreaId = MasterBaseClass.ToInt(val);
		}
	}

	public static bool HasKey(string key)
	{
		return key == "Id" || key == "MAreaId";
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[2] { "Id", "MAreaId" });
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
					_0024var_0024MAreaId = MasterBaseClass.ParseInt(vals[1]);
				}
				int num = 2;
				result = num;
			}
		}
		return result;
	}
}
