using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MPlusBonus : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024PlusBonusGroupId;

	public string _0024var_0024Name;

	public string _0024var_0024Explain;

	public int _0024var_0024Value;

	public int _0024var_0024Rate;

	[NonSerialized]
	private static Dictionary<int, MPlusBonus> _0024mst_0024149 = new Dictionary<int, MPlusBonus>();

	[NonSerialized]
	private static MPlusBonus[] All_cache;

	public int Id => _0024var_0024Id;

	public int PlusBonusGroupId => _0024var_0024PlusBonusGroupId;

	public string Name => _0024var_0024Name;

	public string Explain => _0024var_0024Explain;

	public int Value => _0024var_0024Value;

	public int Rate => _0024var_0024Rate;

	public static MPlusBonus[] All
	{
		get
		{
			MPlusBonus[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MPlusBonus");
				MPlusBonus[] array = (MPlusBonus[])Builtins.array(typeof(MPlusBonus), _0024mst_0024149.Values);
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
		return new StringBuilder("MPlusBonus(").Append((object)Id).Append(" group:").Append((object)PlusBonusGroupId)
			.Append(" value:")
			.Append((object)Value)
			.Append(" rate:")
			.Append((object)Rate)
			.Append(")")
			.ToString();
	}

	public static MPlusBonus Get(int _id)
	{
		MerlinMaster.GetHandler("MPlusBonus");
		return (!_0024mst_0024149.ContainsKey(_id)) ? null : _0024mst_0024149[_id];
	}

	public static void Unload()
	{
		_0024mst_0024149.Clear();
		All_cache = null;
	}

	public static MPlusBonus New(Hashtable data)
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
			MPlusBonus mPlusBonus = Create(data);
			if (!_0024mst_0024149.ContainsKey(mPlusBonus.Id))
			{
				_0024mst_0024149[mPlusBonus.Id] = mPlusBonus;
			}
			result = mPlusBonus;
		}
		return (MPlusBonus)result;
	}

	public static MPlusBonus New2(string[] keys, object[] vals)
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
		return (MPlusBonus)result;
	}

	public static MPlusBonus Entry(MPlusBonus mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024149[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MPlusBonus)result;
	}

	public static void AddMst(MPlusBonus mst)
	{
		if (mst != null)
		{
			_0024mst_0024149[mst.Id] = mst;
		}
	}

	public static MPlusBonus Create(Hashtable data)
	{
		MPlusBonus mPlusBonus = new MPlusBonus();
		MPlusBonus result;
		if (data == null)
		{
			result = mPlusBonus;
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
				mPlusBonus.setField((string)obj, data[current]);
			}
			result = mPlusBonus;
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
		case "PlusBonusGroupId":
			_0024var_0024PlusBonusGroupId = MasterBaseClass.ToInt(val);
			break;
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		case "Explain":
			_0024var_0024Explain = MasterBaseClass.ToStringValue(val);
			break;
		case "Value":
			_0024var_0024Value = MasterBaseClass.ToInt(val);
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
			"PlusBonusGroupId" => true, 
			"Name" => true, 
			"Explain" => true, 
			"Value" => true, 
			"Rate" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[6] { "Id", "PlusBonusGroupId", "Name", "Explain", "Value", "Rate" });
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
					_0024var_0024PlusBonusGroupId = MasterBaseClass.ParseInt(vals[1]);
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
							_0024var_0024Explain = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024Value = MasterBaseClass.ParseInt(vals[4]);
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
