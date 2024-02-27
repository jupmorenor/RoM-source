using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MPremiumSkillUpRates : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MPremiumEffectId;

	public int _0024var_0024SkillLevelFrom;

	public int _0024var_0024SkillLevelUpRate;

	[NonSerialized]
	private MPremiumEffects MPremiumEffectId__cache;

	[NonSerialized]
	private static Dictionary<int, MPremiumSkillUpRates> _0024mst_0024153 = new Dictionary<int, MPremiumSkillUpRates>();

	[NonSerialized]
	private static MPremiumSkillUpRates[] All_cache;

	public int Id => _0024var_0024Id;

	public MPremiumEffects MPremiumEffectId
	{
		get
		{
			if (MPremiumEffectId__cache == null)
			{
				MPremiumEffectId__cache = MPremiumEffects.Get(_0024var_0024MPremiumEffectId);
			}
			return MPremiumEffectId__cache;
		}
	}

	public int SkillLevelFrom => _0024var_0024SkillLevelFrom;

	public int SkillLevelUpRate => _0024var_0024SkillLevelUpRate;

	public static MPremiumSkillUpRates[] All
	{
		get
		{
			MPremiumSkillUpRates[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MPremiumSkillUpRates");
				MPremiumSkillUpRates[] array = (MPremiumSkillUpRates[])Builtins.array(typeof(MPremiumSkillUpRates), _0024mst_0024153.Values);
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
		return new StringBuilder("MPremiumSkillUpRates(").Append((object)Id).Append(" MPremiumEffectId:").Append(MPremiumEffectId)
			.Append(")")
			.ToString();
	}

	public static MPremiumSkillUpRates Get(int _id)
	{
		MerlinMaster.GetHandler("MPremiumSkillUpRates");
		return (!_0024mst_0024153.ContainsKey(_id)) ? null : _0024mst_0024153[_id];
	}

	public static void Unload()
	{
		_0024mst_0024153.Clear();
		All_cache = null;
	}

	public static MPremiumSkillUpRates New(Hashtable data)
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
			MPremiumSkillUpRates mPremiumSkillUpRates = Create(data);
			if (!_0024mst_0024153.ContainsKey(mPremiumSkillUpRates.Id))
			{
				_0024mst_0024153[mPremiumSkillUpRates.Id] = mPremiumSkillUpRates;
			}
			result = mPremiumSkillUpRates;
		}
		return (MPremiumSkillUpRates)result;
	}

	public static MPremiumSkillUpRates New2(string[] keys, object[] vals)
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
		return (MPremiumSkillUpRates)result;
	}

	public static MPremiumSkillUpRates Entry(MPremiumSkillUpRates mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024153[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MPremiumSkillUpRates)result;
	}

	public static void AddMst(MPremiumSkillUpRates mst)
	{
		if (mst != null)
		{
			_0024mst_0024153[mst.Id] = mst;
		}
	}

	public static MPremiumSkillUpRates Create(Hashtable data)
	{
		MPremiumSkillUpRates mPremiumSkillUpRates = new MPremiumSkillUpRates();
		MPremiumSkillUpRates result;
		if (data == null)
		{
			result = mPremiumSkillUpRates;
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
				mPremiumSkillUpRates.setField((string)obj, data[current]);
			}
			result = mPremiumSkillUpRates;
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
		case "MPremiumEffectId":
			_0024var_0024MPremiumEffectId = MasterBaseClass.ToInt(val);
			break;
		case "SkillLevelFrom":
			_0024var_0024SkillLevelFrom = MasterBaseClass.ToInt(val);
			break;
		case "SkillLevelUpRate":
			_0024var_0024SkillLevelUpRate = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"MPremiumEffectId" => true, 
			"SkillLevelFrom" => true, 
			"SkillLevelUpRate" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[4] { "Id", "MPremiumEffectId", "SkillLevelFrom", "SkillLevelUpRate" });
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
					_0024var_0024MPremiumEffectId = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024SkillLevelFrom = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024SkillLevelUpRate = MasterBaseClass.ParseInt(vals[3]);
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
