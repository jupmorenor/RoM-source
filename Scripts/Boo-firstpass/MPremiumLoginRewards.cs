using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MPremiumLoginRewards : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MPremiumLoginBonusId;

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
	private MPremiumLoginBonuses MPremiumLoginBonusId__cache;

	[NonSerialized]
	private static Dictionary<int, MPremiumLoginRewards> _0024mst_0024152 = new Dictionary<int, MPremiumLoginRewards>();

	[NonSerialized]
	private static MPremiumLoginRewards[] All_cache;

	public int Id => _0024var_0024Id;

	public MPremiumLoginBonuses MPremiumLoginBonusId
	{
		get
		{
			if (MPremiumLoginBonusId__cache == null)
			{
				MPremiumLoginBonusId__cache = MPremiumLoginBonuses.Get(_0024var_0024MPremiumLoginBonusId);
			}
			return MPremiumLoginBonusId__cache;
		}
	}

	public int MItemGroupId => _0024var_0024MItemGroupId;

	public int MItemGroupId_2 => _0024var_0024MItemGroupId_2;

	public int MItemGroupId_3 => _0024var_0024MItemGroupId_3;

	public int MItemGroupId_4 => _0024var_0024MItemGroupId_4;

	public int MItemGroupId_5 => _0024var_0024MItemGroupId_5;

	public int MItemGroupId_6 => _0024var_0024MItemGroupId_6;

	public int MItemGroupId_7 => _0024var_0024MItemGroupId_7;

	public int MItemGroupId_8 => _0024var_0024MItemGroupId_8;

	public int MItemGroupId_9 => _0024var_0024MItemGroupId_9;

	public int MItemGroupId_10 => _0024var_0024MItemGroupId_10;

	public int Num => _0024var_0024Num;

	public static MPremiumLoginRewards[] All
	{
		get
		{
			MPremiumLoginRewards[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MPremiumLoginRewards");
				MPremiumLoginRewards[] array = (MPremiumLoginRewards[])Builtins.array(typeof(MPremiumLoginRewards), _0024mst_0024152.Values);
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
		return new StringBuilder("MPremiumLoginRewards(").Append((object)Id).Append(" MPremiumLoginBonusId:").Append(MPremiumLoginBonusId)
			.Append(")")
			.ToString();
	}

	public static MPremiumLoginRewards Get(int _id)
	{
		MerlinMaster.GetHandler("MPremiumLoginRewards");
		return (!_0024mst_0024152.ContainsKey(_id)) ? null : _0024mst_0024152[_id];
	}

	public static void Unload()
	{
		_0024mst_0024152.Clear();
		All_cache = null;
	}

	public static MPremiumLoginRewards New(Hashtable data)
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
			MPremiumLoginRewards mPremiumLoginRewards = Create(data);
			if (!_0024mst_0024152.ContainsKey(mPremiumLoginRewards.Id))
			{
				_0024mst_0024152[mPremiumLoginRewards.Id] = mPremiumLoginRewards;
			}
			result = mPremiumLoginRewards;
		}
		return (MPremiumLoginRewards)result;
	}

	public static MPremiumLoginRewards New2(string[] keys, object[] vals)
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
		return (MPremiumLoginRewards)result;
	}

	public static MPremiumLoginRewards Entry(MPremiumLoginRewards mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024152[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MPremiumLoginRewards)result;
	}

	public static void AddMst(MPremiumLoginRewards mst)
	{
		if (mst != null)
		{
			_0024mst_0024152[mst.Id] = mst;
		}
	}

	public static MPremiumLoginRewards Create(Hashtable data)
	{
		MPremiumLoginRewards mPremiumLoginRewards = new MPremiumLoginRewards();
		MPremiumLoginRewards result;
		if (data == null)
		{
			result = mPremiumLoginRewards;
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
				mPremiumLoginRewards.setField((string)obj, data[current]);
			}
			result = mPremiumLoginRewards;
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
		case "MPremiumLoginBonusId":
			_0024var_0024MPremiumLoginBonusId = MasterBaseClass.ToInt(val);
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
			"MPremiumLoginBonusId" => true, 
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
			"Id", "MPremiumLoginBonusId", "MItemGroupId", "MItemGroupId_2", "MItemGroupId_3", "MItemGroupId_4", "MItemGroupId_5", "MItemGroupId_6", "MItemGroupId_7", "MItemGroupId_8",
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
					_0024var_0024MPremiumLoginBonusId = MasterBaseClass.ParseInt(vals[1]);
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
