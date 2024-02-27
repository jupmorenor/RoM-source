using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MLoginRewards : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MLoginBonusId;

	public int _0024var_0024MItemGroupId;

	public int _0024var_0024MItemGroupId_2;

	public int _0024var_0024MItemGroupId_3;

	public int _0024var_0024MItemGroupId_4;

	public int _0024var_0024MItemGroupId_5;

	public int _0024var_0024MItemGroupId_6;

	public int _0024var_0024MItemGroupId_7;

	public int _0024var_0024MItemGroupId_8;

	public int _0024var_0024MItemGroupId_9;

	public int _0024var_0024MItemGroupId_10;

	public int _0024var_0024Num;

	[NonSerialized]
	private MLoginBonuses MLoginBonusId__cache;

	[NonSerialized]
	private MItemGroups MItemGroupId__cache;

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
	private static Dictionary<int, MLoginRewards> _0024mst_002443 = new Dictionary<int, MLoginRewards>();

	[NonSerialized]
	private static MLoginRewards[] All_cache;

	public MItemGroups MItemGroupId_1 => MItemGroupId;

	public MItemGroups[] AllItemGroups
	{
		get
		{
			System.Collections.Generic.List<MItemGroups> list = new System.Collections.Generic.List<MItemGroups>();
			if (MItemGroupId_1 != null)
			{
				list.Add(MItemGroupId_1);
			}
			if (MItemGroupId_2 != null)
			{
				list.Add(MItemGroupId_2);
			}
			if (MItemGroupId_3 != null)
			{
				list.Add(MItemGroupId_3);
			}
			if (MItemGroupId_4 != null)
			{
				list.Add(MItemGroupId_4);
			}
			if (MItemGroupId_5 != null)
			{
				list.Add(MItemGroupId_5);
			}
			if (MItemGroupId_6 != null)
			{
				list.Add(MItemGroupId_6);
			}
			if (MItemGroupId_7 != null)
			{
				list.Add(MItemGroupId_7);
			}
			if (MItemGroupId_8 != null)
			{
				list.Add(MItemGroupId_8);
			}
			if (MItemGroupId_9 != null)
			{
				list.Add(MItemGroupId_9);
			}
			if (MItemGroupId_10 != null)
			{
				list.Add(MItemGroupId_10);
			}
			return list.ToArray();
		}
	}

	public int Id => _0024var_0024Id;

	public MLoginBonuses MLoginBonusId
	{
		get
		{
			if (MLoginBonusId__cache == null)
			{
				MLoginBonusId__cache = MLoginBonuses.Get(_0024var_0024MLoginBonusId);
			}
			return MLoginBonusId__cache;
		}
	}

	public MItemGroups MItemGroupId
	{
		get
		{
			if (MItemGroupId__cache == null)
			{
				MItemGroupId__cache = MItemGroups.Get(_0024var_0024MItemGroupId);
			}
			return MItemGroupId__cache;
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

	public int Num => _0024var_0024Num;

	public static MLoginRewards[] All
	{
		get
		{
			MLoginRewards[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MLoginRewards");
				MLoginRewards[] array = (MLoginRewards[])Builtins.array(typeof(MLoginRewards), _0024mst_002443.Values);
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
		return new StringBuilder("MLoginRewards(").Append((object)Id).Append(",").Append(MLoginBonusId)
			.Append(",Num=")
			.Append((object)Num)
			.Append(")")
			.ToString();
	}

	public static MLoginRewards Get(int _id)
	{
		MerlinMaster.GetHandler("MLoginRewards");
		return (!_0024mst_002443.ContainsKey(_id)) ? null : _0024mst_002443[_id];
	}

	public static void Unload()
	{
		_0024mst_002443.Clear();
		All_cache = null;
	}

	public static MLoginRewards New(Hashtable data)
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
			MLoginRewards mLoginRewards = Create(data);
			if (!_0024mst_002443.ContainsKey(mLoginRewards.Id))
			{
				_0024mst_002443[mLoginRewards.Id] = mLoginRewards;
			}
			result = mLoginRewards;
		}
		return (MLoginRewards)result;
	}

	public static MLoginRewards New2(string[] keys, object[] vals)
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
		return (MLoginRewards)result;
	}

	public static MLoginRewards Entry(MLoginRewards mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002443[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MLoginRewards)result;
	}

	public static void AddMst(MLoginRewards mst)
	{
		if (mst != null)
		{
			_0024mst_002443[mst.Id] = mst;
		}
	}

	public static MLoginRewards Create(Hashtable data)
	{
		MLoginRewards mLoginRewards = new MLoginRewards();
		MLoginRewards result;
		if (data == null)
		{
			result = mLoginRewards;
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
				mLoginRewards.setField((string)obj, data[current]);
			}
			result = mLoginRewards;
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
		case "MLoginBonusId":
			_0024var_0024MLoginBonusId = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupId":
			_0024var_0024MItemGroupId = MasterBaseClass.ToInt(val);
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
		case "Num":
			_0024var_0024Num = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"MLoginBonusId" => true, 
			"MItemGroupId" => true, 
			"MItemGroupId_2" => true, 
			"MItemGroupId_3" => true, 
			"MItemGroupId_4" => true, 
			"MItemGroupId_5" => true, 
			"MItemGroupId_6" => true, 
			"MItemGroupId_7" => true, 
			"MItemGroupId_8" => true, 
			"MItemGroupId_9" => true, 
			"MItemGroupId_10" => true, 
			"Num" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[13]
		{
			"Id", "MLoginBonusId", "MItemGroupId", "MItemGroupId_2", "MItemGroupId_3", "MItemGroupId_4", "MItemGroupId_5", "MItemGroupId_6", "MItemGroupId_7", "MItemGroupId_8",
			"MItemGroupId_9", "MItemGroupId_10", "Num"
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
					_0024var_0024MLoginBonusId = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024MItemGroupId = MasterBaseClass.ParseInt(vals[2]);
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
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024Num = MasterBaseClass.ParseInt(vals[12]);
															}
															int num = 13;
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
		return result;
	}
}
