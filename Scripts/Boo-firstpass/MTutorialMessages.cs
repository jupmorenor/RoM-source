using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MTutorialMessages : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	public bool _0024var_0024WorldStopFlag;

	public string _0024var_0024Title_Ja;

	public string _0024var_0024Text_Ja;

	public string _0024var_0024Title_En;

	public string _0024var_0024Text_En;

	public bool _0024var_0024PrefabFlag;

	public string _0024var_0024PrefabName;

	public EnumWindowTypes _0024var_0024WindowType;

	[NonSerialized]
	private static Dictionary<int, MTutorialMessages> _0024mst_0024129 = new Dictionary<int, MTutorialMessages>();

	[NonSerialized]
	private static MTutorialMessages[] All_cache;

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

	public bool WorldStopFlag => _0024var_0024WorldStopFlag;

	public string Title_Ja => _0024var_0024Title_Ja;

	public string Text_Ja => _0024var_0024Text_Ja;

	public string Title_En => _0024var_0024Title_En;

	public string Text_En => _0024var_0024Text_En;

	public bool PrefabFlag => _0024var_0024PrefabFlag;

	public string PrefabName => _0024var_0024PrefabName;

	public EnumWindowTypes WindowType => _0024var_0024WindowType;

	public static MTutorialMessages[] All
	{
		get
		{
			MTutorialMessages[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MTutorialMessages");
				MTutorialMessages[] array = (MTutorialMessages[])Builtins.array(typeof(MTutorialMessages), _0024mst_0024129.Values);
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

	public MTutorialMessages()
	{
		_0024var_0024WindowType = EnumWindowTypes.TALK_U_NONAME;
	}

	public string GetTitle()
	{
		return (MerlinLanguageSetting.GetCurrentLanguage() != 0) ? Title_En : Title_Ja;
	}

	public string GetText()
	{
		return (MerlinLanguageSetting.GetCurrentLanguage() != 0) ? Text_En : Text_Ja;
	}

	public static MTutorialMessages Get(int _id)
	{
		MerlinMaster.GetHandler("MTutorialMessages");
		return (!_0024mst_0024129.ContainsKey(_id)) ? null : _0024mst_0024129[_id];
	}

	public static void Unload()
	{
		_0024mst_0024129.Clear();
		All_cache = null;
	}

	public static MTutorialMessages New(Hashtable data)
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
			MTutorialMessages mTutorialMessages = Create(data);
			if (!_0024mst_0024129.ContainsKey(mTutorialMessages.Id))
			{
				_0024mst_0024129[mTutorialMessages.Id] = mTutorialMessages;
			}
			result = mTutorialMessages;
		}
		return (MTutorialMessages)result;
	}

	public static MTutorialMessages New2(string[] keys, object[] vals)
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
		return (MTutorialMessages)result;
	}

	public static MTutorialMessages Entry(MTutorialMessages mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024129[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MTutorialMessages)result;
	}

	public static void AddMst(MTutorialMessages mst)
	{
		if (mst != null)
		{
			_0024mst_0024129[mst.Id] = mst;
		}
	}

	public static MTutorialMessages Create(Hashtable data)
	{
		MTutorialMessages mTutorialMessages = new MTutorialMessages();
		MTutorialMessages result;
		if (data == null)
		{
			result = mTutorialMessages;
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
				mTutorialMessages.setField((string)obj, data[current]);
			}
			result = mTutorialMessages;
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
		case "WorldStopFlag":
			_0024var_0024WorldStopFlag = MasterBaseClass.ToBool(val);
			break;
		case "Title_Ja":
			_0024var_0024Title_Ja = MasterBaseClass.ToStringValue(val);
			break;
		case "Text_Ja":
			_0024var_0024Text_Ja = MasterBaseClass.ToStringValue(val);
			break;
		case "Title_En":
			_0024var_0024Title_En = MasterBaseClass.ToStringValue(val);
			break;
		case "Text_En":
			_0024var_0024Text_En = MasterBaseClass.ToStringValue(val);
			break;
		case "PrefabFlag":
			_0024var_0024PrefabFlag = MasterBaseClass.ToBool(val);
			break;
		case "PrefabName":
			_0024var_0024PrefabName = MasterBaseClass.ToStringValue(val);
			break;
		case "WindowType":
			if (typeof(EnumWindowTypes).IsEnum)
			{
				_0024var_0024WindowType = (EnumWindowTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Progname" => true, 
			"WorldStopFlag" => true, 
			"Title_Ja" => true, 
			"Text_Ja" => true, 
			"Title_En" => true, 
			"Text_En" => true, 
			"PrefabFlag" => true, 
			"PrefabName" => true, 
			"WindowType" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[10] { "Id", "Progname", "WorldStopFlag", "Title_Ja", "Text_Ja", "Title_En", "Text_En", "PrefabFlag", "PrefabName", "WindowType" });
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
						_0024var_0024WorldStopFlag = MasterBaseClass.ParseBool(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Title_Ja = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024Text_Ja = vals[4];
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Title_En = vals[5];
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024Text_En = vals[6];
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024PrefabFlag = MasterBaseClass.ParseBool(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024PrefabName = vals[8];
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null && typeof(EnumWindowTypes).IsEnum)
												{
													_0024var_0024WindowType = (EnumWindowTypes)MasterBaseClass.ParseEnum(vals[9]);
												}
												int num = 10;
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
		return result;
	}
}
