using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MChangeDeckMains : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024AngelItemId;

	public int _0024var_0024DevilItemId;

	public int _0024var_0024PoppetItemId;

	[NonSerialized]
	private static Dictionary<int, MChangeDeckMains> _0024mst_0024118 = new Dictionary<int, MChangeDeckMains>();

	[NonSerialized]
	private static MChangeDeckMains[] All_cache;

	public int Id => _0024var_0024Id;

	public int AngelItemId => _0024var_0024AngelItemId;

	public int DevilItemId => _0024var_0024DevilItemId;

	public int PoppetItemId => _0024var_0024PoppetItemId;

	public static MChangeDeckMains[] All
	{
		get
		{
			MChangeDeckMains[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MChangeDeckMains");
				MChangeDeckMains[] array = (MChangeDeckMains[])Builtins.array(typeof(MChangeDeckMains), _0024mst_0024118.Values);
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
		return new StringBuilder("MChangeDeckMains(").Append((object)Id).Append(",Angel:").Append((object)AngelItemId)
			.Append(",Devil:")
			.Append((object)DevilItemId)
			.Append(",Poppet:")
			.Append((object)PoppetItemId)
			.Append(")")
			.ToString();
	}

	public static MChangeDeckMains Get(int _id)
	{
		MerlinMaster.GetHandler("MChangeDeckMains");
		return (!_0024mst_0024118.ContainsKey(_id)) ? null : _0024mst_0024118[_id];
	}

	public static void Unload()
	{
		_0024mst_0024118.Clear();
		All_cache = null;
	}

	public static MChangeDeckMains New(Hashtable data)
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
			MChangeDeckMains mChangeDeckMains = Create(data);
			if (!_0024mst_0024118.ContainsKey(mChangeDeckMains.Id))
			{
				_0024mst_0024118[mChangeDeckMains.Id] = mChangeDeckMains;
			}
			result = mChangeDeckMains;
		}
		return (MChangeDeckMains)result;
	}

	public static MChangeDeckMains New2(string[] keys, object[] vals)
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
		return (MChangeDeckMains)result;
	}

	public static MChangeDeckMains Entry(MChangeDeckMains mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024118[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MChangeDeckMains)result;
	}

	public static void AddMst(MChangeDeckMains mst)
	{
		if (mst != null)
		{
			_0024mst_0024118[mst.Id] = mst;
		}
	}

	public static MChangeDeckMains Create(Hashtable data)
	{
		MChangeDeckMains mChangeDeckMains = new MChangeDeckMains();
		MChangeDeckMains result;
		if (data == null)
		{
			result = mChangeDeckMains;
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
				mChangeDeckMains.setField((string)obj, data[current]);
			}
			result = mChangeDeckMains;
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
		case "AngelItemId":
			_0024var_0024AngelItemId = MasterBaseClass.ToInt(val);
			break;
		case "DevilItemId":
			_0024var_0024DevilItemId = MasterBaseClass.ToInt(val);
			break;
		case "PoppetItemId":
			_0024var_0024PoppetItemId = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"AngelItemId" => true, 
			"DevilItemId" => true, 
			"PoppetItemId" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[4] { "Id", "AngelItemId", "DevilItemId", "PoppetItemId" });
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
					_0024var_0024AngelItemId = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024DevilItemId = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024PoppetItemId = MasterBaseClass.ParseInt(vals[3]);
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
