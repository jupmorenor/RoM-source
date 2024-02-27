using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MAppendixGachas : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024SaleGachaId;

	public string _0024var_0024Name;

	public string _0024var_0024Description;

	public int _0024var_0024ItemGroupId;

	public int _0024var_0024Rate;

	[NonSerialized]
	private MSaleGachas SaleGachaId__cache;

	[NonSerialized]
	private MItemGroups ItemGroupId__cache;

	[NonSerialized]
	private static Dictionary<int, MAppendixGachas> _0024mst_0024122 = new Dictionary<int, MAppendixGachas>();

	[NonSerialized]
	private static MAppendixGachas[] All_cache;

	public int Id => _0024var_0024Id;

	public MSaleGachas SaleGachaId
	{
		get
		{
			if (SaleGachaId__cache == null)
			{
				SaleGachaId__cache = MSaleGachas.Get(_0024var_0024SaleGachaId);
			}
			return SaleGachaId__cache;
		}
	}

	public string Name => _0024var_0024Name;

	public string Description => _0024var_0024Description;

	public MItemGroups ItemGroupId
	{
		get
		{
			if (ItemGroupId__cache == null)
			{
				ItemGroupId__cache = MItemGroups.Get(_0024var_0024ItemGroupId);
			}
			return ItemGroupId__cache;
		}
	}

	public int Rate => _0024var_0024Rate;

	public static MAppendixGachas[] All
	{
		get
		{
			MAppendixGachas[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MAppendixGachas");
				MAppendixGachas[] array = (MAppendixGachas[])Builtins.array(typeof(MAppendixGachas), _0024mst_0024122.Values);
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
		return new StringBuilder("MAppendixGachas(").Append((object)Id).Append(",SaleGacha:").Append(SaleGachaId)
			.Append(")")
			.ToString();
	}

	public static MAppendixGachas Get(int _id)
	{
		MerlinMaster.GetHandler("MAppendixGachas");
		return (!_0024mst_0024122.ContainsKey(_id)) ? null : _0024mst_0024122[_id];
	}

	public static void Unload()
	{
		_0024mst_0024122.Clear();
		All_cache = null;
	}

	public static MAppendixGachas New(Hashtable data)
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
			MAppendixGachas mAppendixGachas = Create(data);
			if (!_0024mst_0024122.ContainsKey(mAppendixGachas.Id))
			{
				_0024mst_0024122[mAppendixGachas.Id] = mAppendixGachas;
			}
			result = mAppendixGachas;
		}
		return (MAppendixGachas)result;
	}

	public static MAppendixGachas New2(string[] keys, object[] vals)
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
		return (MAppendixGachas)result;
	}

	public static MAppendixGachas Entry(MAppendixGachas mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024122[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MAppendixGachas)result;
	}

	public static void AddMst(MAppendixGachas mst)
	{
		if (mst != null)
		{
			_0024mst_0024122[mst.Id] = mst;
		}
	}

	public static MAppendixGachas Create(Hashtable data)
	{
		MAppendixGachas mAppendixGachas = new MAppendixGachas();
		MAppendixGachas result;
		if (data == null)
		{
			result = mAppendixGachas;
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
				mAppendixGachas.setField((string)obj, data[current]);
			}
			result = mAppendixGachas;
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
		case "SaleGachaId":
			_0024var_0024SaleGachaId = MasterBaseClass.ToInt(val);
			break;
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		case "Description":
			_0024var_0024Description = MasterBaseClass.ToStringValue(val);
			break;
		case "ItemGroupId":
			_0024var_0024ItemGroupId = MasterBaseClass.ToInt(val);
			break;
		case "Rate":
			_0024var_0024Rate = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"SaleGachaId" => true, 
			"Name" => true, 
			"Description" => true, 
			"ItemGroupId" => true, 
			"Rate" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[6] { "Id", "SaleGachaId", "Name", "Description", "ItemGroupId", "Rate" });
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
					_0024var_0024SaleGachaId = MasterBaseClass.ParseInt(vals[1]);
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
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Description = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024ItemGroupId = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Rate = MasterBaseClass.ParseInt(vals[5]);
								}
								int num = 6;
								result = num;
							}
						}
					}
				}
			}
		}
		return result;
	}
}
