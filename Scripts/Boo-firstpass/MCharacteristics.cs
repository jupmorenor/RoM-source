using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MCharacteristics : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024CharacteristicRateGroupId;

	public int _0024var_0024ItemType;

	public int _0024var_0024MTraitTraitId;

	public int _0024var_0024Rate;

	[NonSerialized]
	private static Dictionary<int, MCharacteristics> _0024mst_0024155 = new Dictionary<int, MCharacteristics>();

	[NonSerialized]
	private static MCharacteristics[] All_cache;

	public int Id => _0024var_0024Id;

	public int CharacteristicRateGroupId => _0024var_0024CharacteristicRateGroupId;

	public int ItemType => _0024var_0024ItemType;

	public int MTraitTraitId => _0024var_0024MTraitTraitId;

	public int Rate => _0024var_0024Rate;

	public static MCharacteristics[] All
	{
		get
		{
			MCharacteristics[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MCharacteristics");
				MCharacteristics[] array = (MCharacteristics[])Builtins.array(typeof(MCharacteristics), _0024mst_0024155.Values);
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
		return new StringBuilder("MCharacteristics(").Append((object)Id).Append(" RateGroupId:").Append((object)CharacteristicRateGroupId)
			.Append(" TraitId:")
			.Append((object)MTraitTraitId)
			.Append(" type:")
			.Append((object)ItemType)
			.Append(")")
			.ToString();
	}

	public static MCharacteristics Get(int _id)
	{
		MerlinMaster.GetHandler("MCharacteristics");
		return (!_0024mst_0024155.ContainsKey(_id)) ? null : _0024mst_0024155[_id];
	}

	public static void Unload()
	{
		_0024mst_0024155.Clear();
		All_cache = null;
	}

	public static MCharacteristics New(Hashtable data)
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
			MCharacteristics mCharacteristics = Create(data);
			if (!_0024mst_0024155.ContainsKey(mCharacteristics.Id))
			{
				_0024mst_0024155[mCharacteristics.Id] = mCharacteristics;
			}
			result = mCharacteristics;
		}
		return (MCharacteristics)result;
	}

	public static MCharacteristics New2(string[] keys, object[] vals)
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
		return (MCharacteristics)result;
	}

	public static MCharacteristics Entry(MCharacteristics mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024155[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MCharacteristics)result;
	}

	public static void AddMst(MCharacteristics mst)
	{
		if (mst != null)
		{
			_0024mst_0024155[mst.Id] = mst;
		}
	}

	public static MCharacteristics Create(Hashtable data)
	{
		MCharacteristics mCharacteristics = new MCharacteristics();
		MCharacteristics result;
		if (data == null)
		{
			result = mCharacteristics;
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
				mCharacteristics.setField((string)obj, data[current]);
			}
			result = mCharacteristics;
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
		case "CharacteristicRateGroupId":
			_0024var_0024CharacteristicRateGroupId = MasterBaseClass.ToInt(val);
			break;
		case "ItemType":
			_0024var_0024ItemType = MasterBaseClass.ToInt(val);
			break;
		case "MTraitTraitId":
			_0024var_0024MTraitTraitId = MasterBaseClass.ToInt(val);
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
			"CharacteristicRateGroupId" => true, 
			"ItemType" => true, 
			"MTraitTraitId" => true, 
			"Rate" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[5] { "Id", "CharacteristicRateGroupId", "ItemType", "MTraitTraitId", "Rate" });
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
					_0024var_0024CharacteristicRateGroupId = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024ItemType = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024MTraitTraitId = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024Rate = MasterBaseClass.ParseInt(vals[4]);
							}
							int num = 5;
							result = num;
						}
					}
				}
			}
		}
		return result;
	}
}
