using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MPlayers : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024Coin;

	public int _0024var_0024Ap;

	public int _0024var_0024Rp;

	public int _0024var_0024Cost;

	public int _0024var_0024Friend;

	public int _0024var_0024BoxSize;

	public int _0024var_0024MainWeaponId;

	public int _0024var_0024SubWeaponId_1;

	public int _0024var_0024SubWeaponId_2;

	public int _0024var_0024PopPetId;

	public int _0024var_0024Bp;

	public BasicBattleParameters _0024var_0024BattleParams;

	[NonSerialized]
	private const int GROWTH_CURVE_LEVEL_MAX = 100;

	[NonSerialized]
	private static Dictionary<int, MPlayers> _0024mst_00243 = new Dictionary<int, MPlayers>();

	[NonSerialized]
	private static MPlayers[] All_cache;

	public int Id => _0024var_0024Id;

	public int Coin => _0024var_0024Coin;

	public int Ap => _0024var_0024Ap;

	public int Rp => _0024var_0024Rp;

	public int Cost => _0024var_0024Cost;

	public int Friend => _0024var_0024Friend;

	public int BoxSize => _0024var_0024BoxSize;

	public int MainWeaponId => _0024var_0024MainWeaponId;

	public int SubWeaponId_1 => _0024var_0024SubWeaponId_1;

	public int SubWeaponId_2 => _0024var_0024SubWeaponId_2;

	public int PopPetId => _0024var_0024PopPetId;

	public int Bp => _0024var_0024Bp;

	public BasicBattleParameters BattleParams => _0024var_0024BattleParams;

	public static MPlayers[] All
	{
		get
		{
			MPlayers[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MPlayers");
				MPlayers[] array = (MPlayers[])Builtins.array(typeof(MPlayers), _0024mst_00243.Values);
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

	public MPlayers()
	{
		_0024var_0024Coin = 10;
		_0024var_0024Ap = 10;
		_0024var_0024Rp = 10;
		_0024var_0024Cost = 10;
		_0024var_0024Friend = 10;
		_0024var_0024BoxSize = 10;
		_0024var_0024Bp = 10;
		_0024var_0024BattleParams = new BasicBattleParameters();
	}

	public float exp(int level)
	{
		return BattleParams.exp(level, 100, "MPlayers経験値");
	}

	public static MPlayers Get(int _id)
	{
		MerlinMaster.GetHandler("MPlayers");
		return (!_0024mst_00243.ContainsKey(_id)) ? null : _0024mst_00243[_id];
	}

	public static void Unload()
	{
		_0024mst_00243.Clear();
		All_cache = null;
	}

	public static MPlayers New(Hashtable data)
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
			MPlayers mPlayers = Create(data);
			if (!_0024mst_00243.ContainsKey(mPlayers.Id))
			{
				_0024mst_00243[mPlayers.Id] = mPlayers;
			}
			result = mPlayers;
		}
		return (MPlayers)result;
	}

	public static MPlayers New2(string[] keys, object[] vals)
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
		return (MPlayers)result;
	}

	public static MPlayers Entry(MPlayers mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_00243[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MPlayers)result;
	}

	public static void AddMst(MPlayers mst)
	{
		if (mst != null)
		{
			_0024mst_00243[mst.Id] = mst;
		}
	}

	public static MPlayers Create(Hashtable data)
	{
		MPlayers mPlayers = new MPlayers();
		MPlayers result;
		if (data == null)
		{
			result = mPlayers;
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
				mPlayers.setField((string)obj, data[current]);
			}
			result = mPlayers;
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
		case "Coin":
			_0024var_0024Coin = MasterBaseClass.ToInt(val);
			break;
		case "Ap":
			_0024var_0024Ap = MasterBaseClass.ToInt(val);
			break;
		case "Rp":
			_0024var_0024Rp = MasterBaseClass.ToInt(val);
			break;
		case "Cost":
			_0024var_0024Cost = MasterBaseClass.ToInt(val);
			break;
		case "Friend":
			_0024var_0024Friend = MasterBaseClass.ToInt(val);
			break;
		case "BoxSize":
			_0024var_0024BoxSize = MasterBaseClass.ToInt(val);
			break;
		case "MainWeaponId":
			_0024var_0024MainWeaponId = MasterBaseClass.ToInt(val);
			break;
		case "SubWeaponId_1":
			_0024var_0024SubWeaponId_1 = MasterBaseClass.ToInt(val);
			break;
		case "SubWeaponId_2":
			_0024var_0024SubWeaponId_2 = MasterBaseClass.ToInt(val);
			break;
		case "PopPetId":
			_0024var_0024PopPetId = MasterBaseClass.ToInt(val);
			break;
		case "Bp":
			_0024var_0024Bp = MasterBaseClass.ToInt(val);
			break;
		case "BattleParams":
		{
			object obj = val;
			if (!(obj is Hashtable))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
			}
			_0024var_0024BattleParams = BasicBattleParameters.Create((Hashtable)obj);
			break;
		}
		default:
			if (BasicBattleParameters.HasKey(key))
			{
				_0024var_0024BattleParams.setField(key, val);
			}
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Coin" => true, 
			"Ap" => true, 
			"Rp" => true, 
			"Cost" => true, 
			"Friend" => true, 
			"BoxSize" => true, 
			"MainWeaponId" => true, 
			"SubWeaponId_1" => true, 
			"SubWeaponId_2" => true, 
			"PopPetId" => true, 
			"Bp" => true, 
			"BattleParams" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		lhs = (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[12]
		{
			"Id", "Coin", "Ap", "Rp", "Cost", "Friend", "BoxSize", "MainWeaponId", "SubWeaponId_1", "SubWeaponId_2",
			"PopPetId", "Bp"
		});
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, BasicBattleParameters.KeyNameList());
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
					_0024var_0024Coin = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024Ap = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Rp = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024Cost = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Friend = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024BoxSize = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024MainWeaponId = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024SubWeaponId_1 = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024SubWeaponId_2 = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024PopPetId = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024Bp = MasterBaseClass.ParseInt(vals[11]);
														}
														int num = 12;
														if (length > num)
														{
															num = checked(num + _0024var_0024BattleParams.setStringValues((string[])RuntimeServices.GetRange1(vals, num)));
															result = num;
														}
														else
														{
															result = 0;
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
