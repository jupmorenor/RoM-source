using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MTutorials : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	public bool _0024var_0024WorldStopFlag;

	public string _0024var_0024PrefabName;

	public int _0024var_0024MTutorialMessageId_1;

	public int _0024var_0024MTutorialMessageId_2;

	public int _0024var_0024MTutorialMessageId_3;

	public int _0024var_0024MTutorialMessageId_4;

	public int _0024var_0024MTutorialMessageId_5;

	public int _0024var_0024MTutorialMessageId_6;

	public int _0024var_0024MTutorialMessageId_7;

	public int _0024var_0024MTutorialMessageId_8;

	[NonSerialized]
	private MTutorialMessages MTutorialMessageId_1__cache;

	[NonSerialized]
	private MTutorialMessages MTutorialMessageId_2__cache;

	[NonSerialized]
	private MTutorialMessages MTutorialMessageId_3__cache;

	[NonSerialized]
	private MTutorialMessages MTutorialMessageId_4__cache;

	[NonSerialized]
	private MTutorialMessages MTutorialMessageId_5__cache;

	[NonSerialized]
	private MTutorialMessages MTutorialMessageId_6__cache;

	[NonSerialized]
	private MTutorialMessages MTutorialMessageId_7__cache;

	[NonSerialized]
	private MTutorialMessages MTutorialMessageId_8__cache;

	[NonSerialized]
	private static Dictionary<int, MTutorials> _0024mst_0024128 = new Dictionary<int, MTutorials>();

	[NonSerialized]
	private static MTutorials[] All_cache;

	public MTutorialMessages[] AllTutorialMessages
	{
		get
		{
			System.Collections.Generic.List<MTutorialMessages> list = new System.Collections.Generic.List<MTutorialMessages>();
			if (MTutorialMessageId_1 != null)
			{
				list.Add(MTutorialMessageId_1);
			}
			if (MTutorialMessageId_2 != null)
			{
				list.Add(MTutorialMessageId_2);
			}
			if (MTutorialMessageId_3 != null)
			{
				list.Add(MTutorialMessageId_3);
			}
			if (MTutorialMessageId_4 != null)
			{
				list.Add(MTutorialMessageId_4);
			}
			if (MTutorialMessageId_5 != null)
			{
				list.Add(MTutorialMessageId_5);
			}
			if (MTutorialMessageId_6 != null)
			{
				list.Add(MTutorialMessageId_6);
			}
			if (MTutorialMessageId_7 != null)
			{
				list.Add(MTutorialMessageId_7);
			}
			if (MTutorialMessageId_8 != null)
			{
				list.Add(MTutorialMessageId_8);
			}
			return list.ToArray();
		}
	}

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

	public bool WorldStopFlag => _0024var_0024WorldStopFlag;

	public string PrefabName => _0024var_0024PrefabName;

	public MTutorialMessages MTutorialMessageId_1
	{
		get
		{
			if (MTutorialMessageId_1__cache == null)
			{
				MTutorialMessageId_1__cache = MTutorialMessages.Get(_0024var_0024MTutorialMessageId_1);
			}
			return MTutorialMessageId_1__cache;
		}
	}

	public MTutorialMessages MTutorialMessageId_2
	{
		get
		{
			if (MTutorialMessageId_2__cache == null)
			{
				MTutorialMessageId_2__cache = MTutorialMessages.Get(_0024var_0024MTutorialMessageId_2);
			}
			return MTutorialMessageId_2__cache;
		}
	}

	public MTutorialMessages MTutorialMessageId_3
	{
		get
		{
			if (MTutorialMessageId_3__cache == null)
			{
				MTutorialMessageId_3__cache = MTutorialMessages.Get(_0024var_0024MTutorialMessageId_3);
			}
			return MTutorialMessageId_3__cache;
		}
	}

	public MTutorialMessages MTutorialMessageId_4
	{
		get
		{
			if (MTutorialMessageId_4__cache == null)
			{
				MTutorialMessageId_4__cache = MTutorialMessages.Get(_0024var_0024MTutorialMessageId_4);
			}
			return MTutorialMessageId_4__cache;
		}
	}

	public MTutorialMessages MTutorialMessageId_5
	{
		get
		{
			if (MTutorialMessageId_5__cache == null)
			{
				MTutorialMessageId_5__cache = MTutorialMessages.Get(_0024var_0024MTutorialMessageId_5);
			}
			return MTutorialMessageId_5__cache;
		}
	}

	public MTutorialMessages MTutorialMessageId_6
	{
		get
		{
			if (MTutorialMessageId_6__cache == null)
			{
				MTutorialMessageId_6__cache = MTutorialMessages.Get(_0024var_0024MTutorialMessageId_6);
			}
			return MTutorialMessageId_6__cache;
		}
	}

	public MTutorialMessages MTutorialMessageId_7
	{
		get
		{
			if (MTutorialMessageId_7__cache == null)
			{
				MTutorialMessageId_7__cache = MTutorialMessages.Get(_0024var_0024MTutorialMessageId_7);
			}
			return MTutorialMessageId_7__cache;
		}
	}

	public MTutorialMessages MTutorialMessageId_8
	{
		get
		{
			if (MTutorialMessageId_8__cache == null)
			{
				MTutorialMessageId_8__cache = MTutorialMessages.Get(_0024var_0024MTutorialMessageId_8);
			}
			return MTutorialMessageId_8__cache;
		}
	}

	public static MTutorials[] All
	{
		get
		{
			MTutorials[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MTutorials");
				MTutorials[] array = (MTutorials[])Builtins.array(typeof(MTutorials), _0024mst_0024128.Values);
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

	public static MTutorials Get(int _id)
	{
		MerlinMaster.GetHandler("MTutorials");
		return (!_0024mst_0024128.ContainsKey(_id)) ? null : _0024mst_0024128[_id];
	}

	public static void Unload()
	{
		_0024mst_0024128.Clear();
		All_cache = null;
	}

	public static MTutorials New(Hashtable data)
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
			MTutorials mTutorials = Create(data);
			if (!_0024mst_0024128.ContainsKey(mTutorials.Id))
			{
				_0024mst_0024128[mTutorials.Id] = mTutorials;
			}
			result = mTutorials;
		}
		return (MTutorials)result;
	}

	public static MTutorials New2(string[] keys, object[] vals)
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
		return (MTutorials)result;
	}

	public static MTutorials Entry(MTutorials mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024128[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MTutorials)result;
	}

	public static void AddMst(MTutorials mst)
	{
		if (mst != null)
		{
			_0024mst_0024128[mst.Id] = mst;
		}
	}

	public static MTutorials Create(Hashtable data)
	{
		MTutorials mTutorials = new MTutorials();
		MTutorials result;
		if (data == null)
		{
			result = mTutorials;
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
				mTutorials.setField((string)obj, data[current]);
			}
			result = mTutorials;
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
		case "PrefabName":
			_0024var_0024PrefabName = MasterBaseClass.ToStringValue(val);
			break;
		case "MTutorialMessageId_1":
			_0024var_0024MTutorialMessageId_1 = MasterBaseClass.ToInt(val);
			break;
		case "MTutorialMessageId_2":
			_0024var_0024MTutorialMessageId_2 = MasterBaseClass.ToInt(val);
			break;
		case "MTutorialMessageId_3":
			_0024var_0024MTutorialMessageId_3 = MasterBaseClass.ToInt(val);
			break;
		case "MTutorialMessageId_4":
			_0024var_0024MTutorialMessageId_4 = MasterBaseClass.ToInt(val);
			break;
		case "MTutorialMessageId_5":
			_0024var_0024MTutorialMessageId_5 = MasterBaseClass.ToInt(val);
			break;
		case "MTutorialMessageId_6":
			_0024var_0024MTutorialMessageId_6 = MasterBaseClass.ToInt(val);
			break;
		case "MTutorialMessageId_7":
			_0024var_0024MTutorialMessageId_7 = MasterBaseClass.ToInt(val);
			break;
		case "MTutorialMessageId_8":
			_0024var_0024MTutorialMessageId_8 = MasterBaseClass.ToInt(val);
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
			"PrefabName" => true, 
			"MTutorialMessageId_1" => true, 
			"MTutorialMessageId_2" => true, 
			"MTutorialMessageId_3" => true, 
			"MTutorialMessageId_4" => true, 
			"MTutorialMessageId_5" => true, 
			"MTutorialMessageId_6" => true, 
			"MTutorialMessageId_7" => true, 
			"MTutorialMessageId_8" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[12]
		{
			"Id", "Progname", "WorldStopFlag", "PrefabName", "MTutorialMessageId_1", "MTutorialMessageId_2", "MTutorialMessageId_3", "MTutorialMessageId_4", "MTutorialMessageId_5", "MTutorialMessageId_6",
			"MTutorialMessageId_7", "MTutorialMessageId_8"
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
							_0024var_0024PrefabName = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024MTutorialMessageId_1 = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024MTutorialMessageId_2 = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024MTutorialMessageId_3 = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024MTutorialMessageId_4 = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024MTutorialMessageId_5 = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024MTutorialMessageId_6 = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024MTutorialMessageId_7 = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024MTutorialMessageId_8 = MasterBaseClass.ParseInt(vals[11]);
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
