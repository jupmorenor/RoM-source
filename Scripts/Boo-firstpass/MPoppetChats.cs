using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MPoppetChats : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Text;

	public string _0024var_0024Text_En;

	public EnumPoppetChatTimings _0024var_0024Condition;

	public string _0024var_0024StoryName;

	public string _0024var_0024AreaGroupName;

	public EnumPoppetPersonalities _0024var_0024Personality;

	public int _0024var_0024Priority;

	public float _0024var_0024Rate;

	[NonSerialized]
	private static Dictionary<int, MPoppetChats> _0024mst_002499 = new Dictionary<int, MPoppetChats>();

	[NonSerialized]
	private static MPoppetChats[] All_cache;

	public int Id => _0024var_0024Id;

	public string Text => _0024var_0024Text;

	public string Text_En => _0024var_0024Text_En;

	public EnumPoppetChatTimings Condition => _0024var_0024Condition;

	public string StoryName => _0024var_0024StoryName;

	public string AreaGroupName => _0024var_0024AreaGroupName;

	public EnumPoppetPersonalities Personality => _0024var_0024Personality;

	public int Priority => _0024var_0024Priority;

	public float Rate => _0024var_0024Rate;

	public static MPoppetChats[] All
	{
		get
		{
			MPoppetChats[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MPoppetChats");
				MPoppetChats[] array = (MPoppetChats[])Builtins.array(typeof(MPoppetChats), _0024mst_002499.Values);
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

	public MPoppetChats()
	{
		_0024var_0024Rate = 25f;
	}

	public string GetText()
	{
		return (MerlinLanguageSetting.GetCurrentLanguage() != 0) ? Text_En : Text;
	}

	public static MPoppetChats[] filterByPersonality(MPoppets p)
	{
		if (p == null)
		{
			throw new AssertionFailedException("p != null");
		}
		return filterByPersonality(p.Personality);
	}

	public static MPoppetChats[] filterByPersonality(EnumPoppetPersonalities p)
	{
		System.Collections.Generic.List<MPoppetChats> list = new System.Collections.Generic.List<MPoppetChats>();
		int i = 0;
		MPoppetChats[] all = All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (all[i].Personality == p)
			{
				list.Add(all[i]);
			}
		}
		return (MPoppetChats[])Builtins.array(typeof(MPoppetChats), list);
	}

	public static MPoppetChats Get(int _id)
	{
		MerlinMaster.GetHandler("MPoppetChats");
		return (!_0024mst_002499.ContainsKey(_id)) ? null : _0024mst_002499[_id];
	}

	public static void Unload()
	{
		_0024mst_002499.Clear();
		All_cache = null;
	}

	public static MPoppetChats New(Hashtable data)
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
			MPoppetChats mPoppetChats = Create(data);
			if (!_0024mst_002499.ContainsKey(mPoppetChats.Id))
			{
				_0024mst_002499[mPoppetChats.Id] = mPoppetChats;
			}
			result = mPoppetChats;
		}
		return (MPoppetChats)result;
	}

	public static MPoppetChats New2(string[] keys, object[] vals)
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
		return (MPoppetChats)result;
	}

	public static MPoppetChats Entry(MPoppetChats mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002499[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MPoppetChats)result;
	}

	public static void AddMst(MPoppetChats mst)
	{
		if (mst != null)
		{
			_0024mst_002499[mst.Id] = mst;
		}
	}

	public static MPoppetChats Create(Hashtable data)
	{
		MPoppetChats mPoppetChats = new MPoppetChats();
		MPoppetChats result;
		if (data == null)
		{
			result = mPoppetChats;
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
				mPoppetChats.setField((string)obj, data[current]);
			}
			result = mPoppetChats;
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
		case "Text":
			_0024var_0024Text = MasterBaseClass.ToStringValue(val);
			break;
		case "Text_En":
			_0024var_0024Text_En = MasterBaseClass.ToStringValue(val);
			break;
		case "Condition":
			if (typeof(EnumPoppetChatTimings).IsEnum)
			{
				_0024var_0024Condition = (EnumPoppetChatTimings)MasterBaseClass.ToEnum(val);
			}
			break;
		case "StoryName":
			_0024var_0024StoryName = MasterBaseClass.ToStringValue(val);
			break;
		case "AreaGroupName":
			_0024var_0024AreaGroupName = MasterBaseClass.ToStringValue(val);
			break;
		case "Personality":
			if (typeof(EnumPoppetPersonalities).IsEnum)
			{
				_0024var_0024Personality = (EnumPoppetPersonalities)MasterBaseClass.ToEnum(val);
			}
			break;
		case "Priority":
			_0024var_0024Priority = MasterBaseClass.ToInt(val);
			break;
		case "Rate":
			_0024var_0024Rate = MasterBaseClass.ToSingle(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Text" => true, 
			"Text_En" => true, 
			"Condition" => true, 
			"StoryName" => true, 
			"AreaGroupName" => true, 
			"Personality" => true, 
			"Priority" => true, 
			"Rate" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[9] { "Id", "Text", "Text_En", "Condition", "StoryName", "AreaGroupName", "Personality", "Priority", "Rate" });
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
					_0024var_0024Text = vals[1];
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024Text_En = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null && typeof(EnumPoppetChatTimings).IsEnum)
						{
							_0024var_0024Condition = (EnumPoppetChatTimings)MasterBaseClass.ParseEnum(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024StoryName = vals[4];
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024AreaGroupName = vals[5];
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null && typeof(EnumPoppetPersonalities).IsEnum)
									{
										_0024var_0024Personality = (EnumPoppetPersonalities)MasterBaseClass.ParseEnum(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024Priority = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024Rate = MasterBaseClass.ParseSingle(vals[8]);
											}
											int num = 9;
											result = num;
										}
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
