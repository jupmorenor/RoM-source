using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MTraits : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024TraitId;

	public string _0024var_0024Name;

	public float _0024var_0024AttackCoefficient;

	public float _0024var_0024HpCoefficient;

	public string _0024var_0024SpriteName;

	[NonSerialized]
	private static Dictionary<int, MTraits> _0024mst_0024154 = new Dictionary<int, MTraits>();

	[NonSerialized]
	private static MTraits[] All_cache;

	public int Id => _0024var_0024Id;

	public int TraitId => _0024var_0024TraitId;

	public string Name => _0024var_0024Name;

	public float AttackCoefficient => _0024var_0024AttackCoefficient;

	public float HpCoefficient => _0024var_0024HpCoefficient;

	public string SpriteName => _0024var_0024SpriteName;

	public static MTraits[] All
	{
		get
		{
			MTraits[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MTraits");
				MTraits[] array = (MTraits[])Builtins.array(typeof(MTraits), _0024mst_0024154.Values);
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

	public static MTraits GetTrait(int traitId)
	{
		int num = 0;
		MTraits[] all = All;
		int length = all.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (all[num].TraitId == traitId)
				{
					result = all[num];
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = null;
			break;
		}
		return (MTraits)result;
	}

	public static float GetAttackCoef(int traitId)
	{
		return GetTrait(traitId)?.AttackCoefficient ?? 1f;
	}

	public static float GetHpCoef(int traitId)
	{
		return GetTrait(traitId)?.HpCoefficient ?? 1f;
	}

	public static string GetSpriteName(int traitId)
	{
		MTraits trait = GetTrait(traitId);
		object result;
		if (trait != null)
		{
			if (string.IsNullOrEmpty(trait.SpriteName))
			{
			}
			result = trait.SpriteName;
		}
		else
		{
			result = null;
		}
		return (string)result;
	}

	public static MTraits Get(int _id)
	{
		MerlinMaster.GetHandler("MTraits");
		return (!_0024mst_0024154.ContainsKey(_id)) ? null : _0024mst_0024154[_id];
	}

	public static void Unload()
	{
		_0024mst_0024154.Clear();
		All_cache = null;
	}

	public static MTraits New(Hashtable data)
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
			MTraits mTraits = Create(data);
			if (!_0024mst_0024154.ContainsKey(mTraits.Id))
			{
				_0024mst_0024154[mTraits.Id] = mTraits;
			}
			result = mTraits;
		}
		return (MTraits)result;
	}

	public static MTraits New2(string[] keys, object[] vals)
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
		return (MTraits)result;
	}

	public static MTraits Entry(MTraits mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024154[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MTraits)result;
	}

	public static void AddMst(MTraits mst)
	{
		if (mst != null)
		{
			_0024mst_0024154[mst.Id] = mst;
		}
	}

	public static MTraits Create(Hashtable data)
	{
		MTraits mTraits = new MTraits();
		MTraits result;
		if (data == null)
		{
			result = mTraits;
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
				mTraits.setField((string)obj, data[current]);
			}
			result = mTraits;
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
		case "TraitId":
			_0024var_0024TraitId = MasterBaseClass.ToInt(val);
			break;
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		case "AttackCoefficient":
			_0024var_0024AttackCoefficient = MasterBaseClass.ToSingle(val);
			break;
		case "HpCoefficient":
			_0024var_0024HpCoefficient = MasterBaseClass.ToSingle(val);
			break;
		case "SpriteName":
			_0024var_0024SpriteName = MasterBaseClass.ToStringValue(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"TraitId" => true, 
			"Name" => true, 
			"AttackCoefficient" => true, 
			"HpCoefficient" => true, 
			"SpriteName" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[6] { "Id", "TraitId", "Name", "AttackCoefficient", "HpCoefficient", "SpriteName" });
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
					_0024var_0024TraitId = MasterBaseClass.ParseInt(vals[1]);
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
							_0024var_0024AttackCoefficient = MasterBaseClass.ParseSingle(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024HpCoefficient = MasterBaseClass.ParseSingle(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024SpriteName = vals[5];
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
