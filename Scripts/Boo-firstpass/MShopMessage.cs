using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MShopMessage : MerlinMaster
{
	public int _0024var_0024Id;

	public EnumShopMessageTypes _0024var_0024ShopMessageType;

	public string _0024var_0024DefaultMessage;

	public string _0024var_0024Message_1;

	public int _0024var_0024Condition_1;

	public string _0024var_0024Message_2;

	public int _0024var_0024Condition_2;

	public string _0024var_0024Message_3;

	public int _0024var_0024Condition_3;

	public string _0024var_0024Message_4;

	public int _0024var_0024Condition_4;

	public string _0024var_0024Message_5;

	public int _0024var_0024Condition_5;

	public string _0024var_0024Message_6;

	public int _0024var_0024Condition_6;

	public string _0024var_0024Message_7;

	public int _0024var_0024Condition_7;

	public string _0024var_0024Message_8;

	public int _0024var_0024Condition_8;

	[NonSerialized]
	public static int MSG_NUM = 8;

	[NonSerialized]
	private MTexts DefaultMessage__cache;

	[NonSerialized]
	private MTexts Message_1__cache;

	[NonSerialized]
	private MFlags Condition_1__cache;

	[NonSerialized]
	private MTexts Message_2__cache;

	[NonSerialized]
	private MFlags Condition_2__cache;

	[NonSerialized]
	private MTexts Message_3__cache;

	[NonSerialized]
	private MFlags Condition_3__cache;

	[NonSerialized]
	private MTexts Message_4__cache;

	[NonSerialized]
	private MFlags Condition_4__cache;

	[NonSerialized]
	private MTexts Message_5__cache;

	[NonSerialized]
	private MFlags Condition_5__cache;

	[NonSerialized]
	private MTexts Message_6__cache;

	[NonSerialized]
	private MFlags Condition_6__cache;

	[NonSerialized]
	private MTexts Message_7__cache;

	[NonSerialized]
	private MFlags Condition_7__cache;

	[NonSerialized]
	private MTexts Message_8__cache;

	[NonSerialized]
	private MFlags Condition_8__cache;

	[NonSerialized]
	private static Dictionary<int, MShopMessage> _0024mst_0024111 = new Dictionary<int, MShopMessage>();

	[NonSerialized]
	private static MShopMessage[] All_cache;

	public MFlags[] AllConditions
	{
		get
		{
			System.Collections.Generic.List<MFlags> list = new System.Collections.Generic.List<MFlags>();
			list.Add(Condition_1);
			list.Add(Condition_2);
			list.Add(Condition_3);
			list.Add(Condition_4);
			list.Add(Condition_5);
			list.Add(Condition_6);
			list.Add(Condition_7);
			list.Add(Condition_8);
			return list.ToArray();
		}
	}

	public MTexts[] AllMessages
	{
		get
		{
			System.Collections.Generic.List<MTexts> list = new System.Collections.Generic.List<MTexts>();
			list.Add(Message_1);
			list.Add(Message_2);
			list.Add(Message_3);
			list.Add(Message_4);
			list.Add(Message_5);
			list.Add(Message_6);
			list.Add(Message_7);
			list.Add(Message_8);
			return list.ToArray();
		}
	}

	public int Id => _0024var_0024Id;

	public EnumShopMessageTypes ShopMessageType => _0024var_0024ShopMessageType;

	public MTexts DefaultMessage
	{
		get
		{
			if (DefaultMessage__cache == null)
			{
				DefaultMessage__cache = MTexts.Get(_0024var_0024DefaultMessage);
			}
			return DefaultMessage__cache;
		}
	}

	public MTexts Message_1
	{
		get
		{
			if (Message_1__cache == null)
			{
				Message_1__cache = MTexts.Get(_0024var_0024Message_1);
			}
			return Message_1__cache;
		}
	}

	public MFlags Condition_1
	{
		get
		{
			if (Condition_1__cache == null)
			{
				Condition_1__cache = MFlags.Get(_0024var_0024Condition_1);
			}
			return Condition_1__cache;
		}
	}

	public MTexts Message_2
	{
		get
		{
			if (Message_2__cache == null)
			{
				Message_2__cache = MTexts.Get(_0024var_0024Message_2);
			}
			return Message_2__cache;
		}
	}

	public MFlags Condition_2
	{
		get
		{
			if (Condition_2__cache == null)
			{
				Condition_2__cache = MFlags.Get(_0024var_0024Condition_2);
			}
			return Condition_2__cache;
		}
	}

	public MTexts Message_3
	{
		get
		{
			if (Message_3__cache == null)
			{
				Message_3__cache = MTexts.Get(_0024var_0024Message_3);
			}
			return Message_3__cache;
		}
	}

	public MFlags Condition_3
	{
		get
		{
			if (Condition_3__cache == null)
			{
				Condition_3__cache = MFlags.Get(_0024var_0024Condition_3);
			}
			return Condition_3__cache;
		}
	}

	public MTexts Message_4
	{
		get
		{
			if (Message_4__cache == null)
			{
				Message_4__cache = MTexts.Get(_0024var_0024Message_4);
			}
			return Message_4__cache;
		}
	}

	public MFlags Condition_4
	{
		get
		{
			if (Condition_4__cache == null)
			{
				Condition_4__cache = MFlags.Get(_0024var_0024Condition_4);
			}
			return Condition_4__cache;
		}
	}

	public MTexts Message_5
	{
		get
		{
			if (Message_5__cache == null)
			{
				Message_5__cache = MTexts.Get(_0024var_0024Message_5);
			}
			return Message_5__cache;
		}
	}

	public MFlags Condition_5
	{
		get
		{
			if (Condition_5__cache == null)
			{
				Condition_5__cache = MFlags.Get(_0024var_0024Condition_5);
			}
			return Condition_5__cache;
		}
	}

	public MTexts Message_6
	{
		get
		{
			if (Message_6__cache == null)
			{
				Message_6__cache = MTexts.Get(_0024var_0024Message_6);
			}
			return Message_6__cache;
		}
	}

	public MFlags Condition_6
	{
		get
		{
			if (Condition_6__cache == null)
			{
				Condition_6__cache = MFlags.Get(_0024var_0024Condition_6);
			}
			return Condition_6__cache;
		}
	}

	public MTexts Message_7
	{
		get
		{
			if (Message_7__cache == null)
			{
				Message_7__cache = MTexts.Get(_0024var_0024Message_7);
			}
			return Message_7__cache;
		}
	}

	public MFlags Condition_7
	{
		get
		{
			if (Condition_7__cache == null)
			{
				Condition_7__cache = MFlags.Get(_0024var_0024Condition_7);
			}
			return Condition_7__cache;
		}
	}

	public MTexts Message_8
	{
		get
		{
			if (Message_8__cache == null)
			{
				Message_8__cache = MTexts.Get(_0024var_0024Message_8);
			}
			return Message_8__cache;
		}
	}

	public MFlags Condition_8
	{
		get
		{
			if (Condition_8__cache == null)
			{
				Condition_8__cache = MFlags.Get(_0024var_0024Condition_8);
			}
			return Condition_8__cache;
		}
	}

	public static MShopMessage[] All
	{
		get
		{
			MShopMessage[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MShopMessage");
				MShopMessage[] array = (MShopMessage[])Builtins.array(typeof(MShopMessage), _0024mst_0024111.Values);
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

	public static MShopMessage Get(int _id)
	{
		MerlinMaster.GetHandler("MShopMessage");
		return (!_0024mst_0024111.ContainsKey(_id)) ? null : _0024mst_0024111[_id];
	}

	public static void Unload()
	{
		_0024mst_0024111.Clear();
		All_cache = null;
	}

	public static MShopMessage New(Hashtable data)
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
			MShopMessage mShopMessage = Create(data);
			if (!_0024mst_0024111.ContainsKey(mShopMessage.Id))
			{
				_0024mst_0024111[mShopMessage.Id] = mShopMessage;
			}
			result = mShopMessage;
		}
		return (MShopMessage)result;
	}

	public static MShopMessage New2(string[] keys, object[] vals)
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
		return (MShopMessage)result;
	}

	public static MShopMessage Entry(MShopMessage mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024111[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MShopMessage)result;
	}

	public static void AddMst(MShopMessage mst)
	{
		if (mst != null)
		{
			_0024mst_0024111[mst.Id] = mst;
		}
	}

	public static MShopMessage Create(Hashtable data)
	{
		MShopMessage mShopMessage = new MShopMessage();
		MShopMessage result;
		if (data == null)
		{
			result = mShopMessage;
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
				mShopMessage.setField((string)obj, data[current]);
			}
			result = mShopMessage;
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
		case "ShopMessageType":
			if (typeof(EnumShopMessageTypes).IsEnum)
			{
				_0024var_0024ShopMessageType = (EnumShopMessageTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "DefaultMessage":
			_0024var_0024DefaultMessage = MasterBaseClass.ToStringValue(val);
			break;
		case "Message_1":
			_0024var_0024Message_1 = MasterBaseClass.ToStringValue(val);
			break;
		case "Condition_1":
			_0024var_0024Condition_1 = MasterBaseClass.ToInt(val);
			break;
		case "Message_2":
			_0024var_0024Message_2 = MasterBaseClass.ToStringValue(val);
			break;
		case "Condition_2":
			_0024var_0024Condition_2 = MasterBaseClass.ToInt(val);
			break;
		case "Message_3":
			_0024var_0024Message_3 = MasterBaseClass.ToStringValue(val);
			break;
		case "Condition_3":
			_0024var_0024Condition_3 = MasterBaseClass.ToInt(val);
			break;
		case "Message_4":
			_0024var_0024Message_4 = MasterBaseClass.ToStringValue(val);
			break;
		case "Condition_4":
			_0024var_0024Condition_4 = MasterBaseClass.ToInt(val);
			break;
		case "Message_5":
			_0024var_0024Message_5 = MasterBaseClass.ToStringValue(val);
			break;
		case "Condition_5":
			_0024var_0024Condition_5 = MasterBaseClass.ToInt(val);
			break;
		case "Message_6":
			_0024var_0024Message_6 = MasterBaseClass.ToStringValue(val);
			break;
		case "Condition_6":
			_0024var_0024Condition_6 = MasterBaseClass.ToInt(val);
			break;
		case "Message_7":
			_0024var_0024Message_7 = MasterBaseClass.ToStringValue(val);
			break;
		case "Condition_7":
			_0024var_0024Condition_7 = MasterBaseClass.ToInt(val);
			break;
		case "Message_8":
			_0024var_0024Message_8 = MasterBaseClass.ToStringValue(val);
			break;
		case "Condition_8":
			_0024var_0024Condition_8 = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"ShopMessageType" => true, 
			"DefaultMessage" => true, 
			"Message_1" => true, 
			"Condition_1" => true, 
			"Message_2" => true, 
			"Condition_2" => true, 
			"Message_3" => true, 
			"Condition_3" => true, 
			"Message_4" => true, 
			"Condition_4" => true, 
			"Message_5" => true, 
			"Condition_5" => true, 
			"Message_6" => true, 
			"Condition_6" => true, 
			"Message_7" => true, 
			"Condition_7" => true, 
			"Message_8" => true, 
			"Condition_8" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[19]
		{
			"Id", "ShopMessageType", "DefaultMessage", "Message_1", "Condition_1", "Message_2", "Condition_2", "Message_3", "Condition_3", "Message_4",
			"Condition_4", "Message_5", "Condition_5", "Message_6", "Condition_6", "Message_7", "Condition_7", "Message_8", "Condition_8"
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
				if (vals[1] != null && typeof(EnumShopMessageTypes).IsEnum)
				{
					_0024var_0024ShopMessageType = (EnumShopMessageTypes)MasterBaseClass.ParseEnum(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024DefaultMessage = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Message_1 = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024Condition_1 = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Message_2 = vals[5];
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024Condition_2 = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024Message_3 = vals[7];
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024Condition_3 = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024Message_4 = vals[9];
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024Condition_4 = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024Message_5 = vals[11];
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024Condition_5 = MasterBaseClass.ParseInt(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024Message_6 = vals[13];
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024Condition_6 = MasterBaseClass.ParseInt(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null)
																		{
																			_0024var_0024Message_7 = vals[15];
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null)
																			{
																				_0024var_0024Condition_7 = MasterBaseClass.ParseInt(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null)
																				{
																					_0024var_0024Message_8 = vals[17];
																				}
																				if (length <= 18)
																				{
																					result = 18;
																				}
																				else
																				{
																					if (vals[18] != null)
																					{
																						_0024var_0024Condition_8 = MasterBaseClass.ParseInt(vals[18]);
																					}
																					int num = 19;
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
						}
					}
				}
			}
		}
		return result;
	}
}
