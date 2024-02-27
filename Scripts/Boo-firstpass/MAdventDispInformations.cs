using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MAdventDispInformations : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public string _0024var_0024Explain;

	public int _0024var_0024MQuestId;

	public bool _0024var_0024IsNotice;

	public int _0024var_0024NoticeIssuePriodDay;

	public string _0024var_0024NoticeChangesPlacePath;

	public string _0024var_0024InfoChangesPlacePath;

	public string _0024var_0024GachaChangesPlacePath;

	public string _0024var_0024TownChangesPlacePath;

	public int _0024var_0024MSaleGachaId;

	public int _0024var_0024Sort;

	public bool _0024var_0024IsApple;

	public bool _0024var_0024IsAndroid;

	[NonSerialized]
	private MQuests MQuestId__cache;

	[NonSerialized]
	private MSaleGachas MSaleGachaId__cache;

	[NonSerialized]
	private static Dictionary<int, MAdventDispInformations> _0024mst_00241 = new Dictionary<int, MAdventDispInformations>();

	[NonSerialized]
	private static MAdventDispInformations[] All_cache;

	public int Id => _0024var_0024Id;

	public string Name => _0024var_0024Name;

	public string Explain => _0024var_0024Explain;

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

	public bool IsNotice => _0024var_0024IsNotice;

	public int NoticeIssuePriodDay => _0024var_0024NoticeIssuePriodDay;

	public string NoticeChangesPlacePath => _0024var_0024NoticeChangesPlacePath;

	public string InfoChangesPlacePath => _0024var_0024InfoChangesPlacePath;

	public string GachaChangesPlacePath => _0024var_0024GachaChangesPlacePath;

	public string TownChangesPlacePath => _0024var_0024TownChangesPlacePath;

	public MSaleGachas MSaleGachaId
	{
		get
		{
			if (MSaleGachaId__cache == null)
			{
				MSaleGachaId__cache = MSaleGachas.Get(_0024var_0024MSaleGachaId);
			}
			return MSaleGachaId__cache;
		}
	}

	public int Sort => _0024var_0024Sort;

	public bool IsApple => _0024var_0024IsApple;

	public bool IsAndroid => _0024var_0024IsAndroid;

	public static MAdventDispInformations[] All
	{
		get
		{
			MAdventDispInformations[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MAdventDispInformations");
				MAdventDispInformations[] array = (MAdventDispInformations[])Builtins.array(typeof(MAdventDispInformations), _0024mst_00241.Values);
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

	public static MAdventDispInformations Get(int _id)
	{
		MerlinMaster.GetHandler("MAdventDispInformations");
		return (!_0024mst_00241.ContainsKey(_id)) ? null : _0024mst_00241[_id];
	}

	public static void Unload()
	{
		_0024mst_00241.Clear();
		All_cache = null;
	}

	public static MAdventDispInformations New(Hashtable data)
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
			MAdventDispInformations mAdventDispInformations = Create(data);
			if (!_0024mst_00241.ContainsKey(mAdventDispInformations.Id))
			{
				_0024mst_00241[mAdventDispInformations.Id] = mAdventDispInformations;
			}
			result = mAdventDispInformations;
		}
		return (MAdventDispInformations)result;
	}

	public static MAdventDispInformations New2(string[] keys, object[] vals)
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
		return (MAdventDispInformations)result;
	}

	public static MAdventDispInformations Entry(MAdventDispInformations mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_00241[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MAdventDispInformations)result;
	}

	public static void AddMst(MAdventDispInformations mst)
	{
		if (mst != null)
		{
			_0024mst_00241[mst.Id] = mst;
		}
	}

	public static MAdventDispInformations Create(Hashtable data)
	{
		MAdventDispInformations mAdventDispInformations = new MAdventDispInformations();
		MAdventDispInformations result;
		if (data == null)
		{
			result = mAdventDispInformations;
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
				mAdventDispInformations.setField((string)obj, data[current]);
			}
			result = mAdventDispInformations;
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
		case "Explain":
			_0024var_0024Explain = MasterBaseClass.ToStringValue(val);
			break;
		case "MQuestId":
			_0024var_0024MQuestId = MasterBaseClass.ToInt(val);
			break;
		case "IsNotice":
			_0024var_0024IsNotice = MasterBaseClass.ToBool(val);
			break;
		case "NoticeIssuePriodDay":
			_0024var_0024NoticeIssuePriodDay = MasterBaseClass.ToInt(val);
			break;
		case "NoticeChangesPlacePath":
			_0024var_0024NoticeChangesPlacePath = MasterBaseClass.ToStringValue(val);
			break;
		case "InfoChangesPlacePath":
			_0024var_0024InfoChangesPlacePath = MasterBaseClass.ToStringValue(val);
			break;
		case "GachaChangesPlacePath":
			_0024var_0024GachaChangesPlacePath = MasterBaseClass.ToStringValue(val);
			break;
		case "TownChangesPlacePath":
			_0024var_0024TownChangesPlacePath = MasterBaseClass.ToStringValue(val);
			break;
		case "MSaleGachaId":
			_0024var_0024MSaleGachaId = MasterBaseClass.ToInt(val);
			break;
		case "Sort":
			_0024var_0024Sort = MasterBaseClass.ToInt(val);
			break;
		case "IsApple":
			_0024var_0024IsApple = MasterBaseClass.ToBool(val);
			break;
		case "IsAndroid":
			_0024var_0024IsAndroid = MasterBaseClass.ToBool(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Name" => true, 
			"Explain" => true, 
			"MQuestId" => true, 
			"IsNotice" => true, 
			"NoticeIssuePriodDay" => true, 
			"NoticeChangesPlacePath" => true, 
			"InfoChangesPlacePath" => true, 
			"GachaChangesPlacePath" => true, 
			"TownChangesPlacePath" => true, 
			"MSaleGachaId" => true, 
			"Sort" => true, 
			"IsApple" => true, 
			"IsAndroid" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[14]
		{
			"Id", "Name", "Explain", "MQuestId", "IsNotice", "NoticeIssuePriodDay", "NoticeChangesPlacePath", "InfoChangesPlacePath", "GachaChangesPlacePath", "TownChangesPlacePath",
			"MSaleGachaId", "Sort", "IsApple", "IsAndroid"
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
						_0024var_0024Explain = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024MQuestId = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024IsNotice = MasterBaseClass.ParseBool(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024NoticeIssuePriodDay = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024NoticeChangesPlacePath = vals[6];
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024InfoChangesPlacePath = vals[7];
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024GachaChangesPlacePath = vals[8];
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024TownChangesPlacePath = vals[9];
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024MSaleGachaId = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024Sort = MasterBaseClass.ParseInt(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024IsApple = MasterBaseClass.ParseBool(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024IsAndroid = MasterBaseClass.ParseBool(vals[13]);
																}
																int num = 14;
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
			}
		}
		return result;
	}
}
