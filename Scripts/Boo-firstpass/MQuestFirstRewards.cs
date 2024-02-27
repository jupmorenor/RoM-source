using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MQuestFirstRewards : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MQuestId;

	public int _0024var_0024MItemGroupId_1;

	public int _0024var_0024MItemGroupId_2;

	public int _0024var_0024MItemGroupId_3;

	public int _0024var_0024MItemGroupId_4;

	public int _0024var_0024MItemGroupId_5;

	public int _0024var_0024MItemGroupId_6;

	public int _0024var_0024MItemGroupId_7;

	public int _0024var_0024MItemGroupId_8;

	public int _0024var_0024MItemGroupId_9;

	public int _0024var_0024MItemGroupId_10;

	[NonSerialized]
	private MQuests MQuestId__cache;

	[NonSerialized]
	private MItemGroups MItemGroupId_1__cache;

	[NonSerialized]
	private MItemGroups MItemGroupId_2__cache;

	[NonSerialized]
	private MItemGroups MItemGroupId_3__cache;

	[NonSerialized]
	private MItemGroups MItemGroupId_4__cache;

	[NonSerialized]
	private MItemGroups MItemGroupId_5__cache;

	[NonSerialized]
	private MItemGroups MItemGroupId_6__cache;

	[NonSerialized]
	private MItemGroups MItemGroupId_7__cache;

	[NonSerialized]
	private MItemGroups MItemGroupId_8__cache;

	[NonSerialized]
	private MItemGroups MItemGroupId_9__cache;

	[NonSerialized]
	private MItemGroups MItemGroupId_10__cache;

	[NonSerialized]
	private static Dictionary<int, MQuestFirstRewards> _0024mst_0024113 = new Dictionary<int, MQuestFirstRewards>();

	[NonSerialized]
	private static MQuestFirstRewards[] All_cache;

	public int Id => _0024var_0024Id;

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

	public MItemGroups MItemGroupId_1
	{
		get
		{
			if (MItemGroupId_1__cache == null)
			{
				MItemGroupId_1__cache = MItemGroups.Get(_0024var_0024MItemGroupId_1);
			}
			return MItemGroupId_1__cache;
		}
	}

	public MItemGroups MItemGroupId_2
	{
		get
		{
			if (MItemGroupId_2__cache == null)
			{
				MItemGroupId_2__cache = MItemGroups.Get(_0024var_0024MItemGroupId_2);
			}
			return MItemGroupId_2__cache;
		}
	}

	public MItemGroups MItemGroupId_3
	{
		get
		{
			if (MItemGroupId_3__cache == null)
			{
				MItemGroupId_3__cache = MItemGroups.Get(_0024var_0024MItemGroupId_3);
			}
			return MItemGroupId_3__cache;
		}
	}

	public MItemGroups MItemGroupId_4
	{
		get
		{
			if (MItemGroupId_4__cache == null)
			{
				MItemGroupId_4__cache = MItemGroups.Get(_0024var_0024MItemGroupId_4);
			}
			return MItemGroupId_4__cache;
		}
	}

	public MItemGroups MItemGroupId_5
	{
		get
		{
			if (MItemGroupId_5__cache == null)
			{
				MItemGroupId_5__cache = MItemGroups.Get(_0024var_0024MItemGroupId_5);
			}
			return MItemGroupId_5__cache;
		}
	}

	public MItemGroups MItemGroupId_6
	{
		get
		{
			if (MItemGroupId_6__cache == null)
			{
				MItemGroupId_6__cache = MItemGroups.Get(_0024var_0024MItemGroupId_6);
			}
			return MItemGroupId_6__cache;
		}
	}

	public MItemGroups MItemGroupId_7
	{
		get
		{
			if (MItemGroupId_7__cache == null)
			{
				MItemGroupId_7__cache = MItemGroups.Get(_0024var_0024MItemGroupId_7);
			}
			return MItemGroupId_7__cache;
		}
	}

	public MItemGroups MItemGroupId_8
	{
		get
		{
			if (MItemGroupId_8__cache == null)
			{
				MItemGroupId_8__cache = MItemGroups.Get(_0024var_0024MItemGroupId_8);
			}
			return MItemGroupId_8__cache;
		}
	}

	public MItemGroups MItemGroupId_9
	{
		get
		{
			if (MItemGroupId_9__cache == null)
			{
				MItemGroupId_9__cache = MItemGroups.Get(_0024var_0024MItemGroupId_9);
			}
			return MItemGroupId_9__cache;
		}
	}

	public MItemGroups MItemGroupId_10
	{
		get
		{
			if (MItemGroupId_10__cache == null)
			{
				MItemGroupId_10__cache = MItemGroups.Get(_0024var_0024MItemGroupId_10);
			}
			return MItemGroupId_10__cache;
		}
	}

	public static MQuestFirstRewards[] All
	{
		get
		{
			MQuestFirstRewards[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MQuestFirstRewards");
				MQuestFirstRewards[] array = (MQuestFirstRewards[])Builtins.array(typeof(MQuestFirstRewards), _0024mst_0024113.Values);
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
		return new StringBuilder("MQuestFirstRewards(").Append((object)Id).Append(",").Append(MQuestId)
			.Append(")")
			.ToString();
	}

	public static MQuestFirstRewards Get(int _id)
	{
		MerlinMaster.GetHandler("MQuestFirstRewards");
		return (!_0024mst_0024113.ContainsKey(_id)) ? null : _0024mst_0024113[_id];
	}

	public static void Unload()
	{
		_0024mst_0024113.Clear();
		All_cache = null;
	}

	public static MQuestFirstRewards New(Hashtable data)
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
			MQuestFirstRewards mQuestFirstRewards = Create(data);
			if (!_0024mst_0024113.ContainsKey(mQuestFirstRewards.Id))
			{
				_0024mst_0024113[mQuestFirstRewards.Id] = mQuestFirstRewards;
			}
			result = mQuestFirstRewards;
		}
		return (MQuestFirstRewards)result;
	}

	public static MQuestFirstRewards New2(string[] keys, object[] vals)
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
		return (MQuestFirstRewards)result;
	}

	public static MQuestFirstRewards Entry(MQuestFirstRewards mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024113[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MQuestFirstRewards)result;
	}

	public static void AddMst(MQuestFirstRewards mst)
	{
		if (mst != null)
		{
			_0024mst_0024113[mst.Id] = mst;
		}
	}

	public static MQuestFirstRewards Create(Hashtable data)
	{
		MQuestFirstRewards mQuestFirstRewards = new MQuestFirstRewards();
		MQuestFirstRewards result;
		if (data == null)
		{
			result = mQuestFirstRewards;
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
				mQuestFirstRewards.setField((string)obj, data[current]);
			}
			result = mQuestFirstRewards;
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
		case "MQuestId":
			_0024var_0024MQuestId = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupId_1":
			_0024var_0024MItemGroupId_1 = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupId_2":
			_0024var_0024MItemGroupId_2 = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupId_3":
			_0024var_0024MItemGroupId_3 = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupId_4":
			_0024var_0024MItemGroupId_4 = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupId_5":
			_0024var_0024MItemGroupId_5 = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupId_6":
			_0024var_0024MItemGroupId_6 = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupId_7":
			_0024var_0024MItemGroupId_7 = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupId_8":
			_0024var_0024MItemGroupId_8 = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupId_9":
			_0024var_0024MItemGroupId_9 = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupId_10":
			_0024var_0024MItemGroupId_10 = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"MQuestId" => true, 
			"MItemGroupId_1" => true, 
			"MItemGroupId_2" => true, 
			"MItemGroupId_3" => true, 
			"MItemGroupId_4" => true, 
			"MItemGroupId_5" => true, 
			"MItemGroupId_6" => true, 
			"MItemGroupId_7" => true, 
			"MItemGroupId_8" => true, 
			"MItemGroupId_9" => true, 
			"MItemGroupId_10" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[12]
		{
			"Id", "MQuestId", "MItemGroupId_1", "MItemGroupId_2", "MItemGroupId_3", "MItemGroupId_4", "MItemGroupId_5", "MItemGroupId_6", "MItemGroupId_7", "MItemGroupId_8",
			"MItemGroupId_9", "MItemGroupId_10"
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
					_0024var_0024MQuestId = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024MItemGroupId_1 = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024MItemGroupId_2 = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024MItemGroupId_3 = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024MItemGroupId_4 = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024MItemGroupId_5 = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024MItemGroupId_6 = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024MItemGroupId_7 = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024MItemGroupId_8 = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024MItemGroupId_9 = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024MItemGroupId_10 = MasterBaseClass.ParseInt(vals[11]);
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
