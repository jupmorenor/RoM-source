using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MLoginBonuses : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public EnumLoginBonusTypeValues _0024var_0024LoginBonusTypeValue;

	public TimeSpan _0024var_0024GrantTime;

	public DateTime _0024var_0024StartDate;

	public DateTime _0024var_0024EndDate;

	[NonSerialized]
	private static Dictionary<int, MLoginBonuses> _0024mst_002441 = new Dictionary<int, MLoginBonuses>();

	[NonSerialized]
	private static MLoginBonuses[] All_cache;

	public MLoginRewards[] Rewards
	{
		get
		{
			System.Collections.Generic.List<MLoginRewards> list = new System.Collections.Generic.List<MLoginRewards>();
			int i = 0;
			MLoginRewards[] all = MLoginRewards.All;
			for (int length = all.Length; i < length; i = checked(i + 1))
			{
				if (RuntimeServices.EqualityOperator(all[i].MLoginBonusId, this))
				{
					list.Add(all[i]);
				}
			}
			return (MLoginRewards[])Builtins.array(typeof(MLoginRewards), list);
		}
	}

	public int Id => _0024var_0024Id;

	public string Name => _0024var_0024Name;

	public EnumLoginBonusTypeValues LoginBonusTypeValue => _0024var_0024LoginBonusTypeValue;

	public TimeSpan GrantTime => _0024var_0024GrantTime;

	public DateTime StartDate => _0024var_0024StartDate;

	public DateTime EndDate => _0024var_0024EndDate;

	public static MLoginBonuses[] All
	{
		get
		{
			MLoginBonuses[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MLoginBonuses");
				MLoginBonuses[] array = (MLoginBonuses[])Builtins.array(typeof(MLoginBonuses), _0024mst_002441.Values);
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

	public MLoginBonuses()
	{
		_0024var_0024StartDate = DateTime.Parse("2001/01/01");
		_0024var_0024EndDate = DateTime.Parse("2099/01/01");
	}

	public override string ToString()
	{
		return new StringBuilder("MLoginBonuses(").Append((object)Id).Append(",").Append(Name)
			.Append(",")
			.Append(LoginBonusTypeValue)
			.Append(")")
			.ToString();
	}

	public static MLoginBonuses Get(int _id)
	{
		MerlinMaster.GetHandler("MLoginBonuses");
		return (!_0024mst_002441.ContainsKey(_id)) ? null : _0024mst_002441[_id];
	}

	public static void Unload()
	{
		_0024mst_002441.Clear();
		All_cache = null;
	}

	public static MLoginBonuses New(Hashtable data)
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
			MLoginBonuses mLoginBonuses = Create(data);
			if (!_0024mst_002441.ContainsKey(mLoginBonuses.Id))
			{
				_0024mst_002441[mLoginBonuses.Id] = mLoginBonuses;
			}
			result = mLoginBonuses;
		}
		return (MLoginBonuses)result;
	}

	public static MLoginBonuses New2(string[] keys, object[] vals)
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
		return (MLoginBonuses)result;
	}

	public static MLoginBonuses Entry(MLoginBonuses mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002441[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MLoginBonuses)result;
	}

	public static void AddMst(MLoginBonuses mst)
	{
		if (mst != null)
		{
			_0024mst_002441[mst.Id] = mst;
		}
	}

	public static MLoginBonuses Create(Hashtable data)
	{
		MLoginBonuses mLoginBonuses = new MLoginBonuses();
		MLoginBonuses result;
		if (data == null)
		{
			result = mLoginBonuses;
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
				mLoginBonuses.setField((string)obj, data[current]);
			}
			result = mLoginBonuses;
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
		case "LoginBonusTypeValue":
			if (typeof(EnumLoginBonusTypeValues).IsEnum)
			{
				_0024var_0024LoginBonusTypeValue = (EnumLoginBonusTypeValues)MasterBaseClass.ToEnum(val);
			}
			break;
		case "GrantTime":
		{
			object obj2 = val;
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			_0024var_0024GrantTime = TimeSpan.Parse((string)obj2);
			break;
		}
		case "StartDate":
		{
			object obj3 = val;
			if (!(obj3 is string))
			{
				obj3 = RuntimeServices.Coerce(obj3, typeof(string));
			}
			_0024var_0024StartDate = DateTime.Parse((string)obj3);
			break;
		}
		case "EndDate":
		{
			object obj = val;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			_0024var_0024EndDate = DateTime.Parse((string)obj);
			break;
		}
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Name" => true, 
			"LoginBonusTypeValue" => true, 
			"GrantTime" => true, 
			"StartDate" => true, 
			"EndDate" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[6] { "Id", "Name", "LoginBonusTypeValue", "GrantTime", "StartDate", "EndDate" });
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
					if (vals[2] != null && typeof(EnumLoginBonusTypeValues).IsEnum)
					{
						_0024var_0024LoginBonusTypeValue = (EnumLoginBonusTypeValues)MasterBaseClass.ParseEnum(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024GrantTime = MasterBaseClass.ParseTimeSpan(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024StartDate = MasterBaseClass.ParseDateTime(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024EndDate = MasterBaseClass.ParseDateTime(vals[5]);
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
