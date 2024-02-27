using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MPremiumEffects : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public bool _0024var_0024IsGuaranteeGreatSuccess;

	public double _0024var_0024GetExpUpEffectValue;

	public double _0024var_0024GetCoinUpEffectValue;

	public int _0024var_0024ApplicationDays;

	[NonSerialized]
	private static Dictionary<int, MPremiumEffects> _0024mst_0024150 = new Dictionary<int, MPremiumEffects>();

	[NonSerialized]
	private static MPremiumEffects[] All_cache;

	public int Id => _0024var_0024Id;

	public string Name => _0024var_0024Name;

	public bool IsGuaranteeGreatSuccess => _0024var_0024IsGuaranteeGreatSuccess;

	public double GetExpUpEffectValue => _0024var_0024GetExpUpEffectValue;

	public double GetCoinUpEffectValue => _0024var_0024GetCoinUpEffectValue;

	public int ApplicationDays => _0024var_0024ApplicationDays;

	public static MPremiumEffects[] All
	{
		get
		{
			MPremiumEffects[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MPremiumEffects");
				MPremiumEffects[] array = (MPremiumEffects[])Builtins.array(typeof(MPremiumEffects), _0024mst_0024150.Values);
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
		return new StringBuilder("MPremiumEffects(").Append((object)Id).Append(" Name:").Append(Name)
			.Append(" ApplicationDays:")
			.Append((object)ApplicationDays)
			.Append(")")
			.ToString();
	}

	public static MPremiumEffects Get(int _id)
	{
		MerlinMaster.GetHandler("MPremiumEffects");
		return (!_0024mst_0024150.ContainsKey(_id)) ? null : _0024mst_0024150[_id];
	}

	public static void Unload()
	{
		_0024mst_0024150.Clear();
		All_cache = null;
	}

	public static MPremiumEffects New(Hashtable data)
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
			MPremiumEffects mPremiumEffects = Create(data);
			if (!_0024mst_0024150.ContainsKey(mPremiumEffects.Id))
			{
				_0024mst_0024150[mPremiumEffects.Id] = mPremiumEffects;
			}
			result = mPremiumEffects;
		}
		return (MPremiumEffects)result;
	}

	public static MPremiumEffects New2(string[] keys, object[] vals)
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
		return (MPremiumEffects)result;
	}

	public static MPremiumEffects Entry(MPremiumEffects mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024150[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MPremiumEffects)result;
	}

	public static void AddMst(MPremiumEffects mst)
	{
		if (mst != null)
		{
			_0024mst_0024150[mst.Id] = mst;
		}
	}

	public static MPremiumEffects Create(Hashtable data)
	{
		MPremiumEffects mPremiumEffects = new MPremiumEffects();
		MPremiumEffects result;
		if (data == null)
		{
			result = mPremiumEffects;
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
				mPremiumEffects.setField((string)obj, data[current]);
			}
			result = mPremiumEffects;
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
		case "IsGuaranteeGreatSuccess":
			_0024var_0024IsGuaranteeGreatSuccess = MasterBaseClass.ToBool(val);
			break;
		case "GetExpUpEffectValue":
			if (typeof(double).IsEnum)
			{
				_0024var_0024GetExpUpEffectValue = RuntimeServices.UnboxDouble(MasterBaseClass.ToEnum(val));
			}
			break;
		case "GetCoinUpEffectValue":
			if (typeof(double).IsEnum)
			{
				_0024var_0024GetCoinUpEffectValue = RuntimeServices.UnboxDouble(MasterBaseClass.ToEnum(val));
			}
			break;
		case "ApplicationDays":
			_0024var_0024ApplicationDays = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Name" => true, 
			"IsGuaranteeGreatSuccess" => true, 
			"GetExpUpEffectValue" => true, 
			"GetCoinUpEffectValue" => true, 
			"ApplicationDays" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[6] { "Id", "Name", "IsGuaranteeGreatSuccess", "GetExpUpEffectValue", "GetCoinUpEffectValue", "ApplicationDays" });
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
						_0024var_0024IsGuaranteeGreatSuccess = MasterBaseClass.ParseBool(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null && typeof(double).IsEnum)
						{
							_0024var_0024GetExpUpEffectValue = RuntimeServices.UnboxDouble(MasterBaseClass.ParseEnum(vals[3]));
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null && typeof(double).IsEnum)
							{
								_0024var_0024GetCoinUpEffectValue = RuntimeServices.UnboxDouble(MasterBaseClass.ParseEnum(vals[4]));
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024ApplicationDays = MasterBaseClass.ParseInt(vals[5]);
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
