using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MCoverSkills : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public string _0024var_0024Motion;

	public string _0024var_0024Detail;

	public string _0024var_0024Icon;

	public int _0024var_0024LevelMax;

	public SkillEffectParameters _0024var_0024SkillEffect;

	public bool _0024var_0024DisableColosseum;

	[NonSerialized]
	private MTexts Name__cache;

	[NonSerialized]
	private MTexts Detail__cache;

	[NonSerialized]
	private static Dictionary<int, MCoverSkills> _0024mst_002414 = new Dictionary<int, MCoverSkills>();

	[NonSerialized]
	private static MCoverSkills[] All_cache;

	public int Id => _0024var_0024Id;

	public MTexts Name
	{
		get
		{
			if (Name__cache == null)
			{
				Name__cache = MTexts.Get(_0024var_0024Name);
			}
			return Name__cache;
		}
	}

	public string Motion => _0024var_0024Motion;

	public MTexts Detail
	{
		get
		{
			if (Detail__cache == null)
			{
				Detail__cache = MTexts.Get(_0024var_0024Detail);
			}
			return Detail__cache;
		}
	}

	public string Icon => _0024var_0024Icon;

	public int LevelMax => _0024var_0024LevelMax;

	public SkillEffectParameters SkillEffect => _0024var_0024SkillEffect;

	public bool DisableColosseum => _0024var_0024DisableColosseum;

	public static MCoverSkills[] All
	{
		get
		{
			MCoverSkills[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MCoverSkills");
				MCoverSkills[] array = (MCoverSkills[])Builtins.array(typeof(MCoverSkills), _0024mst_002414.Values);
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

	public MCoverSkills()
	{
		_0024var_0024SkillEffect = new SkillEffectParameters();
	}

	public override string ToString()
	{
		return new StringBuilder("MCoverSkills(").Append((object)Id).Append(",").Append(Name)
			.Append(")")
			.ToString();
	}

	public static MCoverSkills Get(int _id)
	{
		MerlinMaster.GetHandler("MCoverSkills");
		return (!_0024mst_002414.ContainsKey(_id)) ? null : _0024mst_002414[_id];
	}

	public static void Unload()
	{
		_0024mst_002414.Clear();
		All_cache = null;
	}

	public static MCoverSkills New(Hashtable data)
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
			MCoverSkills mCoverSkills = Create(data);
			if (!_0024mst_002414.ContainsKey(mCoverSkills.Id))
			{
				_0024mst_002414[mCoverSkills.Id] = mCoverSkills;
			}
			result = mCoverSkills;
		}
		return (MCoverSkills)result;
	}

	public static MCoverSkills New2(string[] keys, object[] vals)
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
		return (MCoverSkills)result;
	}

	public static MCoverSkills Entry(MCoverSkills mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002414[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MCoverSkills)result;
	}

	public static void AddMst(MCoverSkills mst)
	{
		if (mst != null)
		{
			_0024mst_002414[mst.Id] = mst;
		}
	}

	public static MCoverSkills Create(Hashtable data)
	{
		MCoverSkills mCoverSkills = new MCoverSkills();
		MCoverSkills result;
		if (data == null)
		{
			result = mCoverSkills;
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
				mCoverSkills.setField((string)obj, data[current]);
			}
			result = mCoverSkills;
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
		case "Motion":
			_0024var_0024Motion = MasterBaseClass.ToStringValue(val);
			break;
		case "Detail":
			_0024var_0024Detail = MasterBaseClass.ToStringValue(val);
			break;
		case "Icon":
			_0024var_0024Icon = MasterBaseClass.ToStringValue(val);
			break;
		case "LevelMax":
			_0024var_0024LevelMax = MasterBaseClass.ToInt(val);
			break;
		case "SkillEffect":
		{
			object obj = val;
			if (!(obj is Hashtable))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
			}
			_0024var_0024SkillEffect = SkillEffectParameters.Create((Hashtable)obj);
			break;
		}
		case "DisableColosseum":
			_0024var_0024DisableColosseum = MasterBaseClass.ToBool(val);
			break;
		default:
			if (SkillEffectParameters.HasKey(key))
			{
				_0024var_0024SkillEffect.setField(key, val);
			}
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Name" => true, 
			"Motion" => true, 
			"Detail" => true, 
			"Icon" => true, 
			"LevelMax" => true, 
			"SkillEffect" => true, 
			"DisableColosseum" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		lhs = (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[7] { "Id", "Name", "Motion", "Detail", "Icon", "LevelMax", "DisableColosseum" });
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, SkillEffectParameters.KeyNameList());
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
						_0024var_0024Motion = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Detail = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024Icon = vals[4];
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024LevelMax = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024DisableColosseum = MasterBaseClass.ParseBool(vals[6]);
									}
									int num = 7;
									if (length > num)
									{
										num = checked(num + _0024var_0024SkillEffect.setStringValues((string[])RuntimeServices.GetRange1(vals, num)));
										result = num;
									}
									else
									{
										result = 0;
									}
								}
							}
						}
					}
				}
			}
		}
		return result;
	}
}
