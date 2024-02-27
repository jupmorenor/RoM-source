using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MFixedEmissionGachas : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024SaleGachaId;

	public string _0024var_0024Name;

	public string _0024var_0024Description;

	public int _0024var_0024FixedEmissionItemTypeValue;

	public int _0024var_0024ItemId;

	public int _0024var_0024Level;

	public int _0024var_0024CharacteristicRateGroupId;

	public int _0024var_0024AttackPlusBonusGroupId;

	public int _0024var_0024HpPlusBonusGroupId;

	[NonSerialized]
	private MSaleGachas SaleGachaId__cache;

	[NonSerialized]
	private static Dictionary<int, MFixedEmissionGachas> _0024mst_002453 = new Dictionary<int, MFixedEmissionGachas>();

	[NonSerialized]
	private static MFixedEmissionGachas[] All_cache;

	public int Id => _0024var_0024Id;

	public MSaleGachas SaleGachaId
	{
		get
		{
			if (SaleGachaId__cache == null)
			{
				SaleGachaId__cache = MSaleGachas.Get(_0024var_0024SaleGachaId);
			}
			return SaleGachaId__cache;
		}
	}

	public string Name => _0024var_0024Name;

	public string Description => _0024var_0024Description;

	public int FixedEmissionItemTypeValue => _0024var_0024FixedEmissionItemTypeValue;

	public int ItemId => _0024var_0024ItemId;

	public int Level => _0024var_0024Level;

	public int CharacteristicRateGroupId => _0024var_0024CharacteristicRateGroupId;

	public int AttackPlusBonusGroupId => _0024var_0024AttackPlusBonusGroupId;

	public int HpPlusBonusGroupId => _0024var_0024HpPlusBonusGroupId;

	public static MFixedEmissionGachas[] All
	{
		get
		{
			MFixedEmissionGachas[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MFixedEmissionGachas");
				MFixedEmissionGachas[] array = (MFixedEmissionGachas[])Builtins.array(typeof(MFixedEmissionGachas), _0024mst_002453.Values);
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

	public MFixedEmissionGachas()
	{
		_0024var_0024Level = 1;
	}

	public override string ToString()
	{
		return new StringBuilder("MFixedEmissionGachas(").Append((object)Id).Append(",").Append(Name)
			.Append(")")
			.ToString();
	}

	public static MFixedEmissionGachas Get(int _id)
	{
		MerlinMaster.GetHandler("MFixedEmissionGachas");
		return (!_0024mst_002453.ContainsKey(_id)) ? null : _0024mst_002453[_id];
	}

	public static void Unload()
	{
		_0024mst_002453.Clear();
		All_cache = null;
	}

	public static MFixedEmissionGachas New(Hashtable data)
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
			MFixedEmissionGachas mFixedEmissionGachas = Create(data);
			if (!_0024mst_002453.ContainsKey(mFixedEmissionGachas.Id))
			{
				_0024mst_002453[mFixedEmissionGachas.Id] = mFixedEmissionGachas;
			}
			result = mFixedEmissionGachas;
		}
		return (MFixedEmissionGachas)result;
	}

	public static MFixedEmissionGachas New2(string[] keys, object[] vals)
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
		return (MFixedEmissionGachas)result;
	}

	public static MFixedEmissionGachas Entry(MFixedEmissionGachas mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002453[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MFixedEmissionGachas)result;
	}

	public static void AddMst(MFixedEmissionGachas mst)
	{
		if (mst != null)
		{
			_0024mst_002453[mst.Id] = mst;
		}
	}

	public static MFixedEmissionGachas Create(Hashtable data)
	{
		MFixedEmissionGachas mFixedEmissionGachas = new MFixedEmissionGachas();
		MFixedEmissionGachas result;
		if (data == null)
		{
			result = mFixedEmissionGachas;
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
				mFixedEmissionGachas.setField((string)obj, data[current]);
			}
			result = mFixedEmissionGachas;
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
		case "SaleGachaId":
			_0024var_0024SaleGachaId = MasterBaseClass.ToInt(val);
			break;
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		case "Description":
			_0024var_0024Description = MasterBaseClass.ToStringValue(val);
			break;
		case "FixedEmissionItemTypeValue":
			_0024var_0024FixedEmissionItemTypeValue = MasterBaseClass.ToInt(val);
			break;
		case "ItemId":
			_0024var_0024ItemId = MasterBaseClass.ToInt(val);
			break;
		case "Level":
			_0024var_0024Level = MasterBaseClass.ToInt(val);
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
			"SaleGachaId" => true, 
			"Name" => true, 
			"Description" => true, 
			"FixedEmissionItemTypeValue" => true, 
			"ItemId" => true, 
			"Level" => true, 
			"CharacteristicRateGroupId" => true, 
			"AttackPlusBonusGroupId" => true, 
			"HpPlusBonusGroupId" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[10] { "Id", "SaleGachaId", "Name", "Description", "FixedEmissionItemTypeValue", "ItemId", "Level", "CharacteristicRateGroupId", "AttackPlusBonusGroupId", "HpPlusBonusGroupId" });
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
					_0024var_0024SaleGachaId = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024Name = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Description = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024FixedEmissionItemTypeValue = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024ItemId = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024Level = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024CharacteristicRateGroupId = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024AttackPlusBonusGroupId = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024HpPlusBonusGroupId = MasterBaseClass.ParseInt(vals[9]);
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
