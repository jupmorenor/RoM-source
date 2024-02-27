using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MGachas : MerlinMaster
{
	public int _0024var_0024Id;

	public EnumGachaTypeValues _0024var_0024GachaTyepValue;

	public int _0024var_0024GachaItemValue;

	[NonSerialized]
	private static Dictionary<int, MGachas> _0024mst_002448 = new Dictionary<int, MGachas>();

	[NonSerialized]
	private static MGachas[] All_cache;

	public int Id => _0024var_0024Id;

	public EnumGachaTypeValues GachaTyepValue => _0024var_0024GachaTyepValue;

	public int GachaItemValue => _0024var_0024GachaItemValue;

	public static MGachas[] All
	{
		get
		{
			MGachas[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MGachas");
				MGachas[] array = (MGachas[])Builtins.array(typeof(MGachas), _0024mst_002448.Values);
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
		return new StringBuilder("MGachas(").Append((object)Id).Append(":").Append(GachaTyepValue)
			.Append(":")
			.Append((object)GachaItemValue)
			.Append(")")
			.ToString();
	}

	public static MGachas Get(int _id)
	{
		MerlinMaster.GetHandler("MGachas");
		return (!_0024mst_002448.ContainsKey(_id)) ? null : _0024mst_002448[_id];
	}

	public static void Unload()
	{
		_0024mst_002448.Clear();
		All_cache = null;
	}

	public static MGachas New(Hashtable data)
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
			MGachas mGachas = Create(data);
			if (!_0024mst_002448.ContainsKey(mGachas.Id))
			{
				_0024mst_002448[mGachas.Id] = mGachas;
			}
			result = mGachas;
		}
		return (MGachas)result;
	}

	public static MGachas New2(string[] keys, object[] vals)
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
		return (MGachas)result;
	}

	public static MGachas Entry(MGachas mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002448[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MGachas)result;
	}

	public static void AddMst(MGachas mst)
	{
		if (mst != null)
		{
			_0024mst_002448[mst.Id] = mst;
		}
	}

	public static MGachas Create(Hashtable data)
	{
		MGachas mGachas = new MGachas();
		MGachas result;
		if (data == null)
		{
			result = mGachas;
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
				mGachas.setField((string)obj, data[current]);
			}
			result = mGachas;
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
		case "GachaTyepValue":
			if (typeof(EnumGachaTypeValues).IsEnum)
			{
				_0024var_0024GachaTyepValue = (EnumGachaTypeValues)MasterBaseClass.ToEnum(val);
			}
			break;
		case "GachaItemValue":
			_0024var_0024GachaItemValue = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"GachaTyepValue" => true, 
			"GachaItemValue" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[3] { "Id", "GachaTyepValue", "GachaItemValue" });
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
				if (vals[1] != null && typeof(EnumGachaTypeValues).IsEnum)
				{
					_0024var_0024GachaTyepValue = (EnumGachaTypeValues)MasterBaseClass.ParseEnum(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024GachaItemValue = MasterBaseClass.ParseInt(vals[2]);
					}
					int num = 3;
					result = num;
				}
			}
		}
		return result;
	}
}
