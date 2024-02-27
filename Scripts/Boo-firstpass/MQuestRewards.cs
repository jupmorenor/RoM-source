using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MQuestRewards : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MQuestId;

	public int _0024var_0024MItemGroupChildId_1;

	public int _0024var_0024MItemGroupChildId_2;

	public int _0024var_0024MItemGroupChildId_3;

	public int _0024var_0024MItemGroupChildId_4;

	public int _0024var_0024MItemGroupChildId_5;

	public int _0024var_0024MItemGroupChildId_6;

	public int _0024var_0024MItemGroupChildId_7;

	public int _0024var_0024MItemGroupChildId_8;

	public int _0024var_0024MItemGroupChildId_9;

	public int _0024var_0024MItemGroupChildId_10;

	[NonSerialized]
	private MQuests MQuestId__cache;

	[NonSerialized]
	private static Dictionary<int, MQuestRewards> _0024mst_002488 = new Dictionary<int, MQuestRewards>();

	[NonSerialized]
	private static MQuestRewards[] All_cache;

	public MItemGroupChilds[] RewardItems
	{
		get
		{
			System.Collections.Generic.List<MItemGroupChilds> list = new System.Collections.Generic.List<MItemGroupChilds>();
			if (_0024get_RewardItems_0024closure_0024726(MItemGroupChildId_1) is MItemGroupChilds item)
			{
				list.Add(item);
			}
			if (_0024get_RewardItems_0024closure_0024727(MItemGroupChildId_2) is MItemGroupChilds item2)
			{
				list.Add(item2);
			}
			if (_0024get_RewardItems_0024closure_0024728(MItemGroupChildId_3) is MItemGroupChilds item3)
			{
				list.Add(item3);
			}
			if (_0024get_RewardItems_0024closure_0024729(MItemGroupChildId_4) is MItemGroupChilds item4)
			{
				list.Add(item4);
			}
			if (_0024get_RewardItems_0024closure_0024730(MItemGroupChildId_5) is MItemGroupChilds item5)
			{
				list.Add(item5);
			}
			if (_0024get_RewardItems_0024closure_0024731(MItemGroupChildId_6) is MItemGroupChilds item6)
			{
				list.Add(item6);
			}
			if (_0024get_RewardItems_0024closure_0024732(MItemGroupChildId_7) is MItemGroupChilds item7)
			{
				list.Add(item7);
			}
			if (_0024get_RewardItems_0024closure_0024733(MItemGroupChildId_8) is MItemGroupChilds item8)
			{
				list.Add(item8);
			}
			if (_0024get_RewardItems_0024closure_0024734(MItemGroupChildId_9) is MItemGroupChilds item9)
			{
				list.Add(item9);
			}
			if (_0024get_RewardItems_0024closure_0024735(MItemGroupChildId_10) is MItemGroupChilds item10)
			{
				list.Add(item10);
			}
			return list.ToArray();
		}
	}

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

	public int MItemGroupChildId_1 => _0024var_0024MItemGroupChildId_1;

	public int MItemGroupChildId_2 => _0024var_0024MItemGroupChildId_2;

	public int MItemGroupChildId_3 => _0024var_0024MItemGroupChildId_3;

	public int MItemGroupChildId_4 => _0024var_0024MItemGroupChildId_4;

	public int MItemGroupChildId_5 => _0024var_0024MItemGroupChildId_5;

	public int MItemGroupChildId_6 => _0024var_0024MItemGroupChildId_6;

	public int MItemGroupChildId_7 => _0024var_0024MItemGroupChildId_7;

	public int MItemGroupChildId_8 => _0024var_0024MItemGroupChildId_8;

	public int MItemGroupChildId_9 => _0024var_0024MItemGroupChildId_9;

	public int MItemGroupChildId_10 => _0024var_0024MItemGroupChildId_10;

	public static MQuestRewards[] All
	{
		get
		{
			MQuestRewards[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MQuestRewards");
				MQuestRewards[] array = (MQuestRewards[])Builtins.array(typeof(MQuestRewards), _0024mst_002488.Values);
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

	public static MQuestRewards Get(int _id)
	{
		MerlinMaster.GetHandler("MQuestRewards");
		return (!_0024mst_002488.ContainsKey(_id)) ? null : _0024mst_002488[_id];
	}

	public static void Unload()
	{
		_0024mst_002488.Clear();
		All_cache = null;
	}

	public static MQuestRewards New(Hashtable data)
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
			MQuestRewards mQuestRewards = Create(data);
			if (!_0024mst_002488.ContainsKey(mQuestRewards.Id))
			{
				_0024mst_002488[mQuestRewards.Id] = mQuestRewards;
			}
			result = mQuestRewards;
		}
		return (MQuestRewards)result;
	}

	public static MQuestRewards New2(string[] keys, object[] vals)
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
		return (MQuestRewards)result;
	}

	public static MQuestRewards Entry(MQuestRewards mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002488[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MQuestRewards)result;
	}

	public static void AddMst(MQuestRewards mst)
	{
		if (mst != null)
		{
			_0024mst_002488[mst.Id] = mst;
		}
	}

	public static MQuestRewards Create(Hashtable data)
	{
		MQuestRewards mQuestRewards = new MQuestRewards();
		MQuestRewards result;
		if (data == null)
		{
			result = mQuestRewards;
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
				mQuestRewards.setField((string)obj, data[current]);
			}
			result = mQuestRewards;
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
		case "MItemGroupChildId_1":
			_0024var_0024MItemGroupChildId_1 = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupChildId_2":
			_0024var_0024MItemGroupChildId_2 = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupChildId_3":
			_0024var_0024MItemGroupChildId_3 = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupChildId_4":
			_0024var_0024MItemGroupChildId_4 = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupChildId_5":
			_0024var_0024MItemGroupChildId_5 = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupChildId_6":
			_0024var_0024MItemGroupChildId_6 = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupChildId_7":
			_0024var_0024MItemGroupChildId_7 = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupChildId_8":
			_0024var_0024MItemGroupChildId_8 = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupChildId_9":
			_0024var_0024MItemGroupChildId_9 = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupChildId_10":
			_0024var_0024MItemGroupChildId_10 = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"MQuestId" => true, 
			"MItemGroupChildId_1" => true, 
			"MItemGroupChildId_2" => true, 
			"MItemGroupChildId_3" => true, 
			"MItemGroupChildId_4" => true, 
			"MItemGroupChildId_5" => true, 
			"MItemGroupChildId_6" => true, 
			"MItemGroupChildId_7" => true, 
			"MItemGroupChildId_8" => true, 
			"MItemGroupChildId_9" => true, 
			"MItemGroupChildId_10" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[12]
		{
			"Id", "MQuestId", "MItemGroupChildId_1", "MItemGroupChildId_2", "MItemGroupChildId_3", "MItemGroupChildId_4", "MItemGroupChildId_5", "MItemGroupChildId_6", "MItemGroupChildId_7", "MItemGroupChildId_8",
			"MItemGroupChildId_9", "MItemGroupChildId_10"
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
						_0024var_0024MItemGroupChildId_1 = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024MItemGroupChildId_2 = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024MItemGroupChildId_3 = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024MItemGroupChildId_4 = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024MItemGroupChildId_5 = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024MItemGroupChildId_6 = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024MItemGroupChildId_7 = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024MItemGroupChildId_8 = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024MItemGroupChildId_9 = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024MItemGroupChildId_10 = MasterBaseClass.ParseInt(vals[11]);
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

	internal MItemGroupChilds _0024get_RewardItems_0024closure_0024726(int id)
	{
		return MItemGroupChilds.Get(id);
	}

	internal MItemGroupChilds _0024get_RewardItems_0024closure_0024727(int id)
	{
		return MItemGroupChilds.Get(id);
	}

	internal MItemGroupChilds _0024get_RewardItems_0024closure_0024728(int id)
	{
		return MItemGroupChilds.Get(id);
	}

	internal MItemGroupChilds _0024get_RewardItems_0024closure_0024729(int id)
	{
		return MItemGroupChilds.Get(id);
	}

	internal MItemGroupChilds _0024get_RewardItems_0024closure_0024730(int id)
	{
		return MItemGroupChilds.Get(id);
	}

	internal MItemGroupChilds _0024get_RewardItems_0024closure_0024731(int id)
	{
		return MItemGroupChilds.Get(id);
	}

	internal MItemGroupChilds _0024get_RewardItems_0024closure_0024732(int id)
	{
		return MItemGroupChilds.Get(id);
	}

	internal MItemGroupChilds _0024get_RewardItems_0024closure_0024733(int id)
	{
		return MItemGroupChilds.Get(id);
	}

	internal MItemGroupChilds _0024get_RewardItems_0024closure_0024734(int id)
	{
		return MItemGroupChilds.Get(id);
	}

	internal MItemGroupChilds _0024get_RewardItems_0024closure_0024735(int id)
	{
		return MItemGroupChilds.Get(id);
	}
}
