using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MShortcutChildIcons : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	public string _0024var_0024Icon;

	public string _0024var_0024DisplayName;

	public string _0024var_0024DisplayName_En;

	public int _0024var_0024AreaGroup;

	public string _0024var_0024DirectSceneName_1;

	public string _0024var_0024DirectSceneName_2;

	public float _0024var_0024ScaleX;

	public float _0024var_0024ScaleY;

	public int _0024var_0024MShortcutIconId;

	public int _0024var_0024Condition_1;

	public int _0024var_0024Condition_2;

	public int _0024var_0024Condition_3;

	public int _0024var_0024Condition_4;

	public int _0024var_0024Condition_5;

	public int _0024var_0024Condition_6;

	public int _0024var_0024Condition_7;

	public int _0024var_0024Condition_8;

	public int _0024var_0024NotCondition_1;

	public int _0024var_0024NotCondition_2;

	public int _0024var_0024NotCondition_3;

	public int _0024var_0024NotCondition_4;

	public int _0024var_0024NotCondition_5;

	public int _0024var_0024NotCondition_6;

	public int _0024var_0024NotCondition_7;

	public int _0024var_0024NotCondition_8;

	[NonSerialized]
	private MAreaGroups AreaGroup__cache;

	[NonSerialized]
	private MShortcutIcons MShortcutIconId__cache;

	[NonSerialized]
	private MFlags Condition_1__cache;

	[NonSerialized]
	private MFlags Condition_2__cache;

	[NonSerialized]
	private MFlags Condition_3__cache;

	[NonSerialized]
	private MFlags Condition_4__cache;

	[NonSerialized]
	private MFlags Condition_5__cache;

	[NonSerialized]
	private MFlags Condition_6__cache;

	[NonSerialized]
	private MFlags Condition_7__cache;

	[NonSerialized]
	private MFlags Condition_8__cache;

	[NonSerialized]
	private MFlags NotCondition_1__cache;

	[NonSerialized]
	private MFlags NotCondition_2__cache;

	[NonSerialized]
	private MFlags NotCondition_3__cache;

	[NonSerialized]
	private MFlags NotCondition_4__cache;

	[NonSerialized]
	private MFlags NotCondition_5__cache;

	[NonSerialized]
	private MFlags NotCondition_6__cache;

	[NonSerialized]
	private MFlags NotCondition_7__cache;

	[NonSerialized]
	private MFlags NotCondition_8__cache;

	[NonSerialized]
	private static Dictionary<int, MShortcutChildIcons> _0024mst_0024101 = new Dictionary<int, MShortcutChildIcons>();

	[NonSerialized]
	private static MShortcutChildIcons[] All_cache;

	public MFlags[] AllConditions
	{
		get
		{
			System.Collections.Generic.List<MFlags> list = new System.Collections.Generic.List<MFlags>();
			if (Condition_1 != null)
			{
				list.Add(Condition_1);
			}
			if (Condition_2 != null)
			{
				list.Add(Condition_2);
			}
			if (Condition_3 != null)
			{
				list.Add(Condition_3);
			}
			if (Condition_4 != null)
			{
				list.Add(Condition_4);
			}
			if (Condition_5 != null)
			{
				list.Add(Condition_5);
			}
			if (Condition_6 != null)
			{
				list.Add(Condition_6);
			}
			if (Condition_7 != null)
			{
				list.Add(Condition_7);
			}
			if (Condition_8 != null)
			{
				list.Add(Condition_8);
			}
			return list.ToArray();
		}
	}

	public MFlags[] AllNotConditions
	{
		get
		{
			System.Collections.Generic.List<MFlags> list = new System.Collections.Generic.List<MFlags>();
			if (NotCondition_1 != null)
			{
				list.Add(NotCondition_1);
			}
			if (NotCondition_2 != null)
			{
				list.Add(NotCondition_2);
			}
			if (NotCondition_3 != null)
			{
				list.Add(NotCondition_3);
			}
			if (NotCondition_4 != null)
			{
				list.Add(NotCondition_4);
			}
			if (NotCondition_5 != null)
			{
				list.Add(NotCondition_5);
			}
			if (NotCondition_6 != null)
			{
				list.Add(NotCondition_6);
			}
			if (NotCondition_7 != null)
			{
				list.Add(NotCondition_7);
			}
			if (NotCondition_8 != null)
			{
				list.Add(NotCondition_8);
			}
			return list.ToArray();
		}
	}

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

	public string Icon => _0024var_0024Icon;

	public string DisplayName => _0024var_0024DisplayName;

	public string DisplayName_En => _0024var_0024DisplayName_En;

	public MAreaGroups AreaGroup
	{
		get
		{
			if (AreaGroup__cache == null)
			{
				AreaGroup__cache = MAreaGroups.Get(_0024var_0024AreaGroup);
			}
			return AreaGroup__cache;
		}
	}

	public string DirectSceneName_1 => _0024var_0024DirectSceneName_1;

	public string DirectSceneName_2 => _0024var_0024DirectSceneName_2;

	public float ScaleX => _0024var_0024ScaleX;

	public float ScaleY => _0024var_0024ScaleY;

	public MShortcutIcons MShortcutIconId
	{
		get
		{
			if (MShortcutIconId__cache == null)
			{
				MShortcutIconId__cache = MShortcutIcons.Get(_0024var_0024MShortcutIconId);
			}
			return MShortcutIconId__cache;
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

	public MFlags NotCondition_1
	{
		get
		{
			if (NotCondition_1__cache == null)
			{
				NotCondition_1__cache = MFlags.Get(_0024var_0024NotCondition_1);
			}
			return NotCondition_1__cache;
		}
	}

	public MFlags NotCondition_2
	{
		get
		{
			if (NotCondition_2__cache == null)
			{
				NotCondition_2__cache = MFlags.Get(_0024var_0024NotCondition_2);
			}
			return NotCondition_2__cache;
		}
	}

	public MFlags NotCondition_3
	{
		get
		{
			if (NotCondition_3__cache == null)
			{
				NotCondition_3__cache = MFlags.Get(_0024var_0024NotCondition_3);
			}
			return NotCondition_3__cache;
		}
	}

	public MFlags NotCondition_4
	{
		get
		{
			if (NotCondition_4__cache == null)
			{
				NotCondition_4__cache = MFlags.Get(_0024var_0024NotCondition_4);
			}
			return NotCondition_4__cache;
		}
	}

	public MFlags NotCondition_5
	{
		get
		{
			if (NotCondition_5__cache == null)
			{
				NotCondition_5__cache = MFlags.Get(_0024var_0024NotCondition_5);
			}
			return NotCondition_5__cache;
		}
	}

	public MFlags NotCondition_6
	{
		get
		{
			if (NotCondition_6__cache == null)
			{
				NotCondition_6__cache = MFlags.Get(_0024var_0024NotCondition_6);
			}
			return NotCondition_6__cache;
		}
	}

	public MFlags NotCondition_7
	{
		get
		{
			if (NotCondition_7__cache == null)
			{
				NotCondition_7__cache = MFlags.Get(_0024var_0024NotCondition_7);
			}
			return NotCondition_7__cache;
		}
	}

	public MFlags NotCondition_8
	{
		get
		{
			if (NotCondition_8__cache == null)
			{
				NotCondition_8__cache = MFlags.Get(_0024var_0024NotCondition_8);
			}
			return NotCondition_8__cache;
		}
	}

	public static MShortcutChildIcons[] All
	{
		get
		{
			MShortcutChildIcons[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MShortcutChildIcons");
				MShortcutChildIcons[] array = (MShortcutChildIcons[])Builtins.array(typeof(MShortcutChildIcons), _0024mst_0024101.Values);
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

	public MShortcutChildIcons()
	{
		_0024var_0024ScaleX = 1f;
		_0024var_0024ScaleY = 1f;
	}

	public string GetName()
	{
		return (MerlinLanguageSetting.GetCurrentLanguage() != 0) ? DisplayName_En : DisplayName;
	}

	public static MShortcutChildIcons Get(int _id)
	{
		MerlinMaster.GetHandler("MShortcutChildIcons");
		return (!_0024mst_0024101.ContainsKey(_id)) ? null : _0024mst_0024101[_id];
	}

	public static void Unload()
	{
		_0024mst_0024101.Clear();
		All_cache = null;
	}

	public static MShortcutChildIcons New(Hashtable data)
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
			MShortcutChildIcons mShortcutChildIcons = Create(data);
			if (!_0024mst_0024101.ContainsKey(mShortcutChildIcons.Id))
			{
				_0024mst_0024101[mShortcutChildIcons.Id] = mShortcutChildIcons;
			}
			result = mShortcutChildIcons;
		}
		return (MShortcutChildIcons)result;
	}

	public static MShortcutChildIcons New2(string[] keys, object[] vals)
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
		return (MShortcutChildIcons)result;
	}

	public static MShortcutChildIcons Entry(MShortcutChildIcons mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024101[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MShortcutChildIcons)result;
	}

	public static void AddMst(MShortcutChildIcons mst)
	{
		if (mst != null)
		{
			_0024mst_0024101[mst.Id] = mst;
		}
	}

	public static MShortcutChildIcons Create(Hashtable data)
	{
		MShortcutChildIcons mShortcutChildIcons = new MShortcutChildIcons();
		MShortcutChildIcons result;
		if (data == null)
		{
			result = mShortcutChildIcons;
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
				mShortcutChildIcons.setField((string)obj, data[current]);
			}
			result = mShortcutChildIcons;
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
		case "Icon":
			_0024var_0024Icon = MasterBaseClass.ToStringValue(val);
			break;
		case "DisplayName":
			_0024var_0024DisplayName = MasterBaseClass.ToStringValue(val);
			break;
		case "DisplayName_En":
			_0024var_0024DisplayName_En = MasterBaseClass.ToStringValue(val);
			break;
		case "AreaGroup":
			_0024var_0024AreaGroup = MasterBaseClass.ToInt(val);
			break;
		case "DirectSceneName_1":
			_0024var_0024DirectSceneName_1 = MasterBaseClass.ToStringValue(val);
			break;
		case "DirectSceneName_2":
			_0024var_0024DirectSceneName_2 = MasterBaseClass.ToStringValue(val);
			break;
		case "ScaleX":
			_0024var_0024ScaleX = MasterBaseClass.ToSingle(val);
			break;
		case "ScaleY":
			_0024var_0024ScaleY = MasterBaseClass.ToSingle(val);
			break;
		case "MShortcutIconId":
			_0024var_0024MShortcutIconId = MasterBaseClass.ToInt(val);
			break;
		case "Condition_1":
			_0024var_0024Condition_1 = MasterBaseClass.ToInt(val);
			break;
		case "Condition_2":
			_0024var_0024Condition_2 = MasterBaseClass.ToInt(val);
			break;
		case "Condition_3":
			_0024var_0024Condition_3 = MasterBaseClass.ToInt(val);
			break;
		case "Condition_4":
			_0024var_0024Condition_4 = MasterBaseClass.ToInt(val);
			break;
		case "Condition_5":
			_0024var_0024Condition_5 = MasterBaseClass.ToInt(val);
			break;
		case "Condition_6":
			_0024var_0024Condition_6 = MasterBaseClass.ToInt(val);
			break;
		case "Condition_7":
			_0024var_0024Condition_7 = MasterBaseClass.ToInt(val);
			break;
		case "Condition_8":
			_0024var_0024Condition_8 = MasterBaseClass.ToInt(val);
			break;
		case "NotCondition_1":
			_0024var_0024NotCondition_1 = MasterBaseClass.ToInt(val);
			break;
		case "NotCondition_2":
			_0024var_0024NotCondition_2 = MasterBaseClass.ToInt(val);
			break;
		case "NotCondition_3":
			_0024var_0024NotCondition_3 = MasterBaseClass.ToInt(val);
			break;
		case "NotCondition_4":
			_0024var_0024NotCondition_4 = MasterBaseClass.ToInt(val);
			break;
		case "NotCondition_5":
			_0024var_0024NotCondition_5 = MasterBaseClass.ToInt(val);
			break;
		case "NotCondition_6":
			_0024var_0024NotCondition_6 = MasterBaseClass.ToInt(val);
			break;
		case "NotCondition_7":
			_0024var_0024NotCondition_7 = MasterBaseClass.ToInt(val);
			break;
		case "NotCondition_8":
			_0024var_0024NotCondition_8 = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Progname" => true, 
			"Icon" => true, 
			"DisplayName" => true, 
			"DisplayName_En" => true, 
			"AreaGroup" => true, 
			"DirectSceneName_1" => true, 
			"DirectSceneName_2" => true, 
			"ScaleX" => true, 
			"ScaleY" => true, 
			"MShortcutIconId" => true, 
			"Condition_1" => true, 
			"Condition_2" => true, 
			"Condition_3" => true, 
			"Condition_4" => true, 
			"Condition_5" => true, 
			"Condition_6" => true, 
			"Condition_7" => true, 
			"Condition_8" => true, 
			"NotCondition_1" => true, 
			"NotCondition_2" => true, 
			"NotCondition_3" => true, 
			"NotCondition_4" => true, 
			"NotCondition_5" => true, 
			"NotCondition_6" => true, 
			"NotCondition_7" => true, 
			"NotCondition_8" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[27]
		{
			"Id", "Progname", "Icon", "DisplayName", "DisplayName_En", "AreaGroup", "DirectSceneName_1", "DirectSceneName_2", "ScaleX", "ScaleY",
			"MShortcutIconId", "Condition_1", "Condition_2", "Condition_3", "Condition_4", "Condition_5", "Condition_6", "Condition_7", "Condition_8", "NotCondition_1",
			"NotCondition_2", "NotCondition_3", "NotCondition_4", "NotCondition_5", "NotCondition_6", "NotCondition_7", "NotCondition_8"
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
						_0024var_0024Icon = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024DisplayName = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024DisplayName_En = vals[4];
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024AreaGroup = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024DirectSceneName_1 = vals[6];
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024DirectSceneName_2 = vals[7];
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024ScaleX = MasterBaseClass.ParseSingle(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024ScaleY = MasterBaseClass.ParseSingle(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024MShortcutIconId = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024Condition_1 = MasterBaseClass.ParseInt(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024Condition_2 = MasterBaseClass.ParseInt(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024Condition_3 = MasterBaseClass.ParseInt(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024Condition_4 = MasterBaseClass.ParseInt(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null)
																		{
																			_0024var_0024Condition_5 = MasterBaseClass.ParseInt(vals[15]);
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null)
																			{
																				_0024var_0024Condition_6 = MasterBaseClass.ParseInt(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null)
																				{
																					_0024var_0024Condition_7 = MasterBaseClass.ParseInt(vals[17]);
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
																					if (length <= 19)
																					{
																						result = 19;
																					}
																					else
																					{
																						if (vals[19] != null)
																						{
																							_0024var_0024NotCondition_1 = MasterBaseClass.ParseInt(vals[19]);
																						}
																						if (length <= 20)
																						{
																							result = 20;
																						}
																						else
																						{
																							if (vals[20] != null)
																							{
																								_0024var_0024NotCondition_2 = MasterBaseClass.ParseInt(vals[20]);
																							}
																							if (length <= 21)
																							{
																								result = 21;
																							}
																							else
																							{
																								if (vals[21] != null)
																								{
																									_0024var_0024NotCondition_3 = MasterBaseClass.ParseInt(vals[21]);
																								}
																								if (length <= 22)
																								{
																									result = 22;
																								}
																								else
																								{
																									if (vals[22] != null)
																									{
																										_0024var_0024NotCondition_4 = MasterBaseClass.ParseInt(vals[22]);
																									}
																									if (length <= 23)
																									{
																										result = 23;
																									}
																									else
																									{
																										if (vals[23] != null)
																										{
																											_0024var_0024NotCondition_5 = MasterBaseClass.ParseInt(vals[23]);
																										}
																										if (length <= 24)
																										{
																											result = 24;
																										}
																										else
																										{
																											if (vals[24] != null)
																											{
																												_0024var_0024NotCondition_6 = MasterBaseClass.ParseInt(vals[24]);
																											}
																											if (length <= 25)
																											{
																												result = 25;
																											}
																											else
																											{
																												if (vals[25] != null)
																												{
																													_0024var_0024NotCondition_7 = MasterBaseClass.ParseInt(vals[25]);
																												}
																												if (length <= 26)
																												{
																													result = 26;
																												}
																												else
																												{
																													if (vals[26] != null)
																													{
																														_0024var_0024NotCondition_8 = MasterBaseClass.ParseInt(vals[26]);
																													}
																													int num = 27;
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
