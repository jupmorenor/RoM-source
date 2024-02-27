using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MItemGroupChilds : MerlinMaster
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024AddAllGroupTable_00242333 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024n_00242334;

			internal MItemGroupChilds _0024itemChild_00242335;

			internal int _0024_00241866_00242336;

			internal MItemGroupChilds[] _0024_00241867_00242337;

			internal int _0024_00241868_00242338;

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (MItemGroups.isCreateAllChildIds)
						{
							goto case 1;
						}
						MItemGroups.isCreateAllChildIds = true;
						_0024n_00242334 = 0;
						_0024_00241866_00242336 = 0;
						_0024_00241867_00242337 = All;
						_0024_00241868_00242338 = _0024_00241867_00242337.Length;
						goto IL_00a9;
					case 2:
						_0024_00241867_00242337[_0024_00241866_00242336].AddGroupTable();
						_0024n_00242334++;
						_0024_00241866_00242336++;
						goto IL_00a9;
					case 1:
						{
							result = 0;
							break;
						}
						IL_00a9:
						if (_0024_00241866_00242336 < _0024_00241868_00242338)
						{
							if (_0024n_00242334 > 100)
							{
								_0024n_00242334 = 0;
								result = (YieldDefault(2) ? 1 : 0);
								break;
							}
							goto case 2;
						}
						YieldDefault(1);
						goto case 1;
					}
				}
				return (byte)result != 0;
			}
		}

		public override IEnumerator<object> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	public int _0024var_0024Id;

	public int _0024var_0024MItemGroupId;

	public int _0024var_0024ItemId;

	public EnumMasterTypeValues _0024var_0024MasterTypeValue;

	public int _0024var_0024Quantity;

	public int _0024var_0024Rate;

	public int _0024var_0024Unit;

	public int _0024var_0024DropRate;

	public int _0024var_0024Level;

	public string _0024var_0024Title;

	public string _0024var_0024Explain;

	public string _0024var_0024ItemInfo;

	public int _0024var_0024CharacteristicRateGroupId;

	public int _0024var_0024AttackPlusBonusGroupId;

	public int _0024var_0024HpPlusBonusGroupId;

	[NonSerialized]
	private MItemGroups MItemGroupId__cache;

	[NonSerialized]
	private static Dictionary<int, MItemGroupChilds> _0024mst_002481 = new Dictionary<int, MItemGroupChilds>();

	[NonSerialized]
	private static MItemGroupChilds[] All_cache;

	public int Id => _0024var_0024Id;

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

	public int ItemId => _0024var_0024ItemId;

	public EnumMasterTypeValues MasterTypeValue => _0024var_0024MasterTypeValue;

	public int Quantity => _0024var_0024Quantity;

	public int Rate => _0024var_0024Rate;

	public int Unit => _0024var_0024Unit;

	public int DropRate => _0024var_0024DropRate;

	public int Level => _0024var_0024Level;

	public string Title => _0024var_0024Title;

	public string Explain => _0024var_0024Explain;

	public string ItemInfo => _0024var_0024ItemInfo;

	public int CharacteristicRateGroupId => _0024var_0024CharacteristicRateGroupId;

	public int AttackPlusBonusGroupId => _0024var_0024AttackPlusBonusGroupId;

	public int HpPlusBonusGroupId => _0024var_0024HpPlusBonusGroupId;

	public static MItemGroupChilds[] All
	{
		get
		{
			MItemGroupChilds[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MItemGroupChilds");
				MItemGroupChilds[] array = (MItemGroupChilds[])Builtins.array(typeof(MItemGroupChilds), _0024mst_002481.Values);
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

	public MItemGroupChilds()
	{
		_0024var_0024Quantity = 1;
		_0024var_0024Title = string.Empty;
		_0024var_0024Explain = string.Empty;
		_0024var_0024ItemInfo = string.Empty;
	}

	public override string ToString()
	{
		return new StringBuilder("(").Append((object)Id).Append(" Type:").Append(MasterTypeValue)
			.Append(" ItemId:")
			.Append((object)ItemId)
			.Append(" n:")
			.Append((object)Quantity)
			.Append(" rate:")
			.Append((object)Rate)
			.Append(" lv:")
			.Append((object)Level)
			.Append(")")
			.ToString();
	}

	public void AddGroupTable()
	{
		MItemGroups mItemGroupId = MItemGroupId;
		if (mItemGroupId != null)
		{
			int id = MItemGroupId.Id;
			object obj = MItemGroups.MItemGroupChildIds[id];
			if (!(obj is int[]))
			{
				obj = RuntimeServices.Coerce(obj, typeof(int[]));
			}
			int[] array = (int[])obj;
			array = ((array == null) ? new int[1] { Id } : ((int[])RuntimeServices.AddArrays(typeof(int), array, new int[1] { Id })));
			MItemGroups.MItemGroupChildIds[id] = array;
		}
	}

	public static IEnumerator AddAllGroupTable()
	{
		return new _0024AddAllGroupTable_00242333().GetEnumerator();
	}

	public static MItemGroupChilds Get(int _id)
	{
		MerlinMaster.GetHandler("MItemGroupChilds");
		return (!_0024mst_002481.ContainsKey(_id)) ? null : _0024mst_002481[_id];
	}

	public static void Unload()
	{
		_0024mst_002481.Clear();
		All_cache = null;
	}

	public static MItemGroupChilds New(Hashtable data)
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
			MItemGroupChilds mItemGroupChilds = Create(data);
			if (!_0024mst_002481.ContainsKey(mItemGroupChilds.Id))
			{
				_0024mst_002481[mItemGroupChilds.Id] = mItemGroupChilds;
			}
			result = mItemGroupChilds;
		}
		return (MItemGroupChilds)result;
	}

	public static MItemGroupChilds New2(string[] keys, object[] vals)
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
		return (MItemGroupChilds)result;
	}

	public static MItemGroupChilds Entry(MItemGroupChilds mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002481[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MItemGroupChilds)result;
	}

	public static void AddMst(MItemGroupChilds mst)
	{
		if (mst != null)
		{
			_0024mst_002481[mst.Id] = mst;
		}
	}

	public static MItemGroupChilds Create(Hashtable data)
	{
		MItemGroupChilds mItemGroupChilds = new MItemGroupChilds();
		MItemGroupChilds result;
		if (data == null)
		{
			result = mItemGroupChilds;
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
				mItemGroupChilds.setField((string)obj, data[current]);
			}
			result = mItemGroupChilds;
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
		case "MItemGroupId":
			_0024var_0024MItemGroupId = MasterBaseClass.ToInt(val);
			break;
		case "ItemId":
			_0024var_0024ItemId = MasterBaseClass.ToInt(val);
			break;
		case "MasterTypeValue":
			if (typeof(EnumMasterTypeValues).IsEnum)
			{
				_0024var_0024MasterTypeValue = (EnumMasterTypeValues)MasterBaseClass.ToEnum(val);
			}
			break;
		case "Quantity":
			_0024var_0024Quantity = MasterBaseClass.ToInt(val);
			break;
		case "Rate":
			_0024var_0024Rate = MasterBaseClass.ToInt(val);
			break;
		case "Unit":
			_0024var_0024Unit = MasterBaseClass.ToInt(val);
			break;
		case "DropRate":
			_0024var_0024DropRate = MasterBaseClass.ToInt(val);
			break;
		case "Level":
			_0024var_0024Level = MasterBaseClass.ToInt(val);
			break;
		case "Title":
			_0024var_0024Title = MasterBaseClass.ToStringValue(val);
			break;
		case "Explain":
			_0024var_0024Explain = MasterBaseClass.ToStringValue(val);
			break;
		case "ItemInfo":
			_0024var_0024ItemInfo = MasterBaseClass.ToStringValue(val);
			break;
		case "CharacteristicRateGroupId":
			_0024var_0024CharacteristicRateGroupId = MasterBaseClass.ToInt(val);
			break;
		case "AttackPlusBonusGroupId":
			_0024var_0024AttackPlusBonusGroupId = MasterBaseClass.ToInt(val);
			break;
		case "HpPlusBonusGroupId":
			_0024var_0024HpPlusBonusGroupId = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"MItemGroupId" => true, 
			"ItemId" => true, 
			"MasterTypeValue" => true, 
			"Quantity" => true, 
			"Rate" => true, 
			"Unit" => true, 
			"DropRate" => true, 
			"Level" => true, 
			"Title" => true, 
			"Explain" => true, 
			"ItemInfo" => true, 
			"CharacteristicRateGroupId" => true, 
			"AttackPlusBonusGroupId" => true, 
			"HpPlusBonusGroupId" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[15]
		{
			"Id", "MItemGroupId", "ItemId", "MasterTypeValue", "Quantity", "Rate", "Unit", "DropRate", "Level", "Title",
			"Explain", "ItemInfo", "CharacteristicRateGroupId", "AttackPlusBonusGroupId", "HpPlusBonusGroupId"
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
					_0024var_0024MItemGroupId = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024ItemId = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null && typeof(EnumMasterTypeValues).IsEnum)
						{
							_0024var_0024MasterTypeValue = (EnumMasterTypeValues)MasterBaseClass.ParseEnum(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024Quantity = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Rate = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024Unit = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024DropRate = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024Level = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024Title = vals[9];
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024Explain = vals[10];
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024ItemInfo = vals[11];
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024CharacteristicRateGroupId = MasterBaseClass.ParseInt(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024AttackPlusBonusGroupId = MasterBaseClass.ParseInt(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024HpPlusBonusGroupId = MasterBaseClass.ParseInt(vals[14]);
																	}
																	int num = 15;
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
		return result;
	}
}
