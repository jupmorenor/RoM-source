using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MStories : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	public int _0024var_0024GroupId;

	public int _0024var_0024PrevGroupId;

	public string _0024var_0024DisplayName;

	public string _0024var_0024Explain;

	public string _0024var_0024DisplayName_En;

	public string _0024var_0024Explain_En;

	public int _0024var_0024MQuestId;

	public bool _0024var_0024IsTutorial;

	public bool _0024var_0024IsOnlyOnce;

	public bool _0024var_0024Practice;

	[NonSerialized]
	private MStoryGroups GroupId__cache;

	[NonSerialized]
	private MStoryGroups PrevGroupId__cache;

	[NonSerialized]
	private MQuests MQuestId__cache;

	[NonSerialized]
	private static Dictionary<int, MStories> _0024mst_002470 = new Dictionary<int, MStories>();

	[NonSerialized]
	private static MStories[] All_cache;

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

	public MStoryGroups GroupId
	{
		get
		{
			if (GroupId__cache == null)
			{
				GroupId__cache = MStoryGroups.Get(_0024var_0024GroupId);
			}
			return GroupId__cache;
		}
	}

	public MStoryGroups PrevGroupId
	{
		get
		{
			if (PrevGroupId__cache == null)
			{
				PrevGroupId__cache = MStoryGroups.Get(_0024var_0024PrevGroupId);
			}
			return PrevGroupId__cache;
		}
	}

	public string DisplayName => _0024var_0024DisplayName;

	public string Explain => _0024var_0024Explain;

	public string DisplayName_En => _0024var_0024DisplayName_En;

	public string Explain_En => _0024var_0024Explain_En;

	public MQuests MQuestId
	{
		get
		{
			if (MQuestId__cache == null)
			{
				MQuestId__cache = MQuests.Get(_0024var_0024MQuestId);
			}
			return MQuestId__cache;
		}
	}

	public bool IsTutorial => _0024var_0024IsTutorial;

	public bool IsOnlyOnce => _0024var_0024IsOnlyOnce;

	public bool Practice => _0024var_0024Practice;

	public static MStories[] All
	{
		get
		{
			MStories[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MStories");
				MStories[] array = (MStories[])Builtins.array(typeof(MStories), _0024mst_002470.Values);
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

	public string GetName()
	{
		return (MerlinLanguageSetting.GetCurrentLanguage() != 0) ? DisplayName_En : DisplayName;
	}

	public string GetExplain()
	{
		return (MerlinLanguageSetting.GetCurrentLanguage() != 0) ? Explain_En : Explain;
	}

	public override string ToString()
	{
		return new StringBuilder("MStories(").Append((object)Id).Append(",").Append(Progname)
			.Append(",")
			.Append(MQuestId)
			.Append(")")
			.ToString();
	}

	public static MStories Get(int _id)
	{
		MerlinMaster.GetHandler("MStories");
		return (!_0024mst_002470.ContainsKey(_id)) ? null : _0024mst_002470[_id];
	}

	public static void Unload()
	{
		_0024mst_002470.Clear();
		All_cache = null;
	}

	public static MStories New(Hashtable data)
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
			MStories mStories = Create(data);
			if (!_0024mst_002470.ContainsKey(mStories.Id))
			{
				_0024mst_002470[mStories.Id] = mStories;
			}
			result = mStories;
		}
		return (MStories)result;
	}

	public static MStories New2(string[] keys, object[] vals)
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
		return (MStories)result;
	}

	public static MStories Entry(MStories mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002470[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MStories)result;
	}

	public static void AddMst(MStories mst)
	{
		if (mst != null)
		{
			_0024mst_002470[mst.Id] = mst;
		}
	}

	public static MStories Create(Hashtable data)
	{
		MStories mStories = new MStories();
		MStories result;
		if (data == null)
		{
			result = mStories;
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
				mStories.setField((string)obj, data[current]);
			}
			result = mStories;
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
		case "Progname":
			_0024var_0024Progname = MasterBaseClass.ToStringValue(val);
			break;
		case "GroupId":
			_0024var_0024GroupId = MasterBaseClass.ToInt(val);
			break;
		case "PrevGroupId":
			_0024var_0024PrevGroupId = MasterBaseClass.ToInt(val);
			break;
		case "DisplayName":
			_0024var_0024DisplayName = MasterBaseClass.ToStringValue(val);
			break;
		case "Explain":
			_0024var_0024Explain = MasterBaseClass.ToStringValue(val);
			break;
		case "DisplayName_En":
			_0024var_0024DisplayName_En = MasterBaseClass.ToStringValue(val);
			break;
		case "Explain_En":
			_0024var_0024Explain_En = MasterBaseClass.ToStringValue(val);
			break;
		case "MQuestId":
			_0024var_0024MQuestId = MasterBaseClass.ToInt(val);
			break;
		case "IsTutorial":
			_0024var_0024IsTutorial = MasterBaseClass.ToBool(val);
			break;
		case "IsOnlyOnce":
			_0024var_0024IsOnlyOnce = MasterBaseClass.ToBool(val);
			break;
		case "Practice":
			_0024var_0024Practice = MasterBaseClass.ToBool(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Progname" => true, 
			"GroupId" => true, 
			"PrevGroupId" => true, 
			"DisplayName" => true, 
			"Explain" => true, 
			"DisplayName_En" => true, 
			"Explain_En" => true, 
			"MQuestId" => true, 
			"IsTutorial" => true, 
			"IsOnlyOnce" => true, 
			"Practice" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[12]
		{
			"Id", "Progname", "GroupId", "PrevGroupId", "DisplayName", "Explain", "DisplayName_En", "Explain_En", "MQuestId", "IsTutorial",
			"IsOnlyOnce", "Practice"
		});
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
					_0024var_0024Progname = vals[1];
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024GroupId = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024PrevGroupId = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024DisplayName = vals[4];
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Explain = vals[5];
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024DisplayName_En = vals[6];
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024Explain_En = vals[7];
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024MQuestId = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024IsTutorial = MasterBaseClass.ParseBool(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024IsOnlyOnce = MasterBaseClass.ParseBool(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024Practice = MasterBaseClass.ParseBool(vals[11]);
														}
														int num = 12;
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
				}
			}
		}
		return result;
	}
}
