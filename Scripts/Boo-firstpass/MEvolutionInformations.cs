using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MEvolutionInformations : MerlinMaster
{
	[NonSerialized]
	private const bool UseUltEvolution = true;

	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public string _0024var_0024Explain;

	public int _0024var_0024EvolutionItemTypeValue;

	public int _0024var_0024EvolutionSourceId;

	public int _0024var_0024EvolutionDestinationId;

	public int _0024var_0024EvoMaterialId_1;

	public int _0024var_0024EvoMaterialId_2;

	public int _0024var_0024EvoMaterialId_3;

	public int _0024var_0024EvoMaterialId_4;

	public int _0024var_0024EvoMaterialId_5;

	public int _0024var_0024EvoCost;

	[NonSerialized]
	private static Dictionary<int, MEvolutionInformations> _0024mst_002440 = new Dictionary<int, MEvolutionInformations>();

	[NonSerialized]
	private static MEvolutionInformations[] All_cache;

	public int[] AllMaterialIds
	{
		get
		{
			Boo.Lang.List<int> list = new Boo.Lang.List<int>(5);
			if (EvoMaterialId_1 > 0)
			{
				list.Add(EvoMaterialId_1);
			}
			if (EvoMaterialId_2 > 0)
			{
				list.Add(EvoMaterialId_2);
			}
			if (EvoMaterialId_3 > 0)
			{
				list.Add(EvoMaterialId_3);
			}
			if (EvoMaterialId_4 > 0)
			{
				list.Add(EvoMaterialId_4);
			}
			if (EvoMaterialId_5 > 0)
			{
				list.Add(EvoMaterialId_5);
			}
			return (int[])Builtins.array(typeof(int), list);
		}
	}

	public int Id => _0024var_0024Id;

	public string Name => _0024var_0024Name;

	public string Explain => _0024var_0024Explain;

	public int EvolutionItemTypeValue => _0024var_0024EvolutionItemTypeValue;

	public int EvolutionSourceId => _0024var_0024EvolutionSourceId;

	public int EvolutionDestinationId => _0024var_0024EvolutionDestinationId;

	public int EvoMaterialId_1 => _0024var_0024EvoMaterialId_1;

	public int EvoMaterialId_2 => _0024var_0024EvoMaterialId_2;

	public int EvoMaterialId_3 => _0024var_0024EvoMaterialId_3;

	public int EvoMaterialId_4 => _0024var_0024EvoMaterialId_4;

	public int EvoMaterialId_5 => _0024var_0024EvoMaterialId_5;

	public int EvoCost => _0024var_0024EvoCost;

	public static MEvolutionInformations[] All
	{
		get
		{
			MEvolutionInformations[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MEvolutionInformations");
				MEvolutionInformations[] array = (MEvolutionInformations[])Builtins.array(typeof(MEvolutionInformations), _0024mst_002440.Values);
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

	public static bool Has(int itemType, int id)
	{
		int num;
		if (true)
		{
			MEvolutionInformations[] array = SearchToSourceId(itemType, id);
			num = ((array != null) ? 1 : 0);
			if (num != 0)
			{
				num = ((0 < array.Length) ? 1 : 0);
			}
		}
		else
		{
			num = 0;
		}
		return (byte)num != 0;
	}

	public static MEvolutionInformations[] SearchToSourceId(int itemType, int id)
	{
		object result;
		if (true)
		{
			MEvolutionInformations[] array = new MEvolutionInformations[0];
			int i = 0;
			MEvolutionInformations[] all = All;
			for (int length = all.Length; i < length; i = checked(i + 1))
			{
				if (all[i].EvolutionItemTypeValue == itemType && all[i].EvolutionSourceId == id)
				{
					array = (MEvolutionInformations[])RuntimeServices.AddArrays(typeof(MEvolutionInformations), array, new MEvolutionInformations[1] { all[i] });
				}
			}
			result = array;
		}
		else
		{
			result = null;
		}
		return (MEvolutionInformations[])result;
	}

	public static MEvolutionInformations SearchToDestinationId(int itemType, int id)
	{
		int num;
		MEvolutionInformations[] all;
		if (true)
		{
			num = 0;
			all = All;
			int length = all.Length;
			while (num < length)
			{
				if (all[num].EvolutionItemTypeValue != itemType || all[num].EvolutionDestinationId != id)
				{
					num = checked(num + 1);
					continue;
				}
				goto IL_003b;
			}
		}
		object result = null;
		goto IL_004f;
		IL_004f:
		return (MEvolutionInformations)result;
		IL_003b:
		result = all[num];
		goto IL_004f;
	}

	public override string ToString()
	{
		return new StringBuilder("MEvolutionInformations(").Append((object)Id).Append(",").Append(Name)
			.Append(",")
			.Append(Explain)
			.Append(",")
			.Append((object)EvolutionItemTypeValue)
			.Append(",")
			.Append((object)EvolutionSourceId)
			.Append(",")
			.Append((object)EvolutionDestinationId)
			.Append(")")
			.ToString();
	}

	public static MEvolutionInformations Get(int _id)
	{
		MerlinMaster.GetHandler("MEvolutionInformations");
		return (!_0024mst_002440.ContainsKey(_id)) ? null : _0024mst_002440[_id];
	}

	public static void Unload()
	{
		_0024mst_002440.Clear();
		All_cache = null;
	}

	public static MEvolutionInformations New(Hashtable data)
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
			MEvolutionInformations mEvolutionInformations = Create(data);
			if (!_0024mst_002440.ContainsKey(mEvolutionInformations.Id))
			{
				_0024mst_002440[mEvolutionInformations.Id] = mEvolutionInformations;
			}
			result = mEvolutionInformations;
		}
		return (MEvolutionInformations)result;
	}

	public static MEvolutionInformations New2(string[] keys, object[] vals)
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
		return (MEvolutionInformations)result;
	}

	public static MEvolutionInformations Entry(MEvolutionInformations mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002440[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MEvolutionInformations)result;
	}

	public static void AddMst(MEvolutionInformations mst)
	{
		if (mst != null)
		{
			_0024mst_002440[mst.Id] = mst;
		}
	}

	public static MEvolutionInformations Create(Hashtable data)
	{
		MEvolutionInformations mEvolutionInformations = new MEvolutionInformations();
		MEvolutionInformations result;
		if (data == null)
		{
			result = mEvolutionInformations;
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
				mEvolutionInformations.setField((string)obj, data[current]);
			}
			result = mEvolutionInformations;
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
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		case "Explain":
			_0024var_0024Explain = MasterBaseClass.ToStringValue(val);
			break;
		case "EvolutionItemTypeValue":
			_0024var_0024EvolutionItemTypeValue = MasterBaseClass.ToInt(val);
			break;
		case "EvolutionSourceId":
			_0024var_0024EvolutionSourceId = MasterBaseClass.ToInt(val);
			break;
		case "EvolutionDestinationId":
			_0024var_0024EvolutionDestinationId = MasterBaseClass.ToInt(val);
			break;
		case "EvoMaterialId_1":
			_0024var_0024EvoMaterialId_1 = MasterBaseClass.ToInt(val);
			break;
		case "EvoMaterialId_2":
			_0024var_0024EvoMaterialId_2 = MasterBaseClass.ToInt(val);
			break;
		case "EvoMaterialId_3":
			_0024var_0024EvoMaterialId_3 = MasterBaseClass.ToInt(val);
			break;
		case "EvoMaterialId_4":
			_0024var_0024EvoMaterialId_4 = MasterBaseClass.ToInt(val);
			break;
		case "EvoMaterialId_5":
			_0024var_0024EvoMaterialId_5 = MasterBaseClass.ToInt(val);
			break;
		case "EvoCost":
			_0024var_0024EvoCost = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Name" => true, 
			"Explain" => true, 
			"EvolutionItemTypeValue" => true, 
			"EvolutionSourceId" => true, 
			"EvolutionDestinationId" => true, 
			"EvoMaterialId_1" => true, 
			"EvoMaterialId_2" => true, 
			"EvoMaterialId_3" => true, 
			"EvoMaterialId_4" => true, 
			"EvoMaterialId_5" => true, 
			"EvoCost" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[12]
		{
			"Id", "Name", "Explain", "EvolutionItemTypeValue", "EvolutionSourceId", "EvolutionDestinationId", "EvoMaterialId_1", "EvoMaterialId_2", "EvoMaterialId_3", "EvoMaterialId_4",
			"EvoMaterialId_5", "EvoCost"
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
					_0024var_0024Name = vals[1];
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024Explain = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024EvolutionItemTypeValue = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024EvolutionSourceId = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024EvolutionDestinationId = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024EvoMaterialId_1 = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024EvoMaterialId_2 = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024EvoMaterialId_3 = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024EvoMaterialId_4 = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024EvoMaterialId_5 = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024EvoCost = MasterBaseClass.ParseInt(vals[11]);
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
