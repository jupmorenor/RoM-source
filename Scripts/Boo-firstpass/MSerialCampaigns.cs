using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MSerialCampaigns : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024TitleName;

	public int _0024var_0024MItemGroupId;

	public DateTime _0024var_0024StartDate;

	public DateTime _0024var_0024EndDate;

	public bool _0024var_0024IsDelete;

	public int _0024var_0024DuplicateTypeValue;

	public bool _0024var_0024IsExternalCampaign;

	public bool _0024var_0024IsOnlyOnce;

	[NonSerialized]
	private MItemGroups MItemGroupId__cache;

	[NonSerialized]
	private static Dictionary<int, MSerialCampaigns> _0024mst_002484 = new Dictionary<int, MSerialCampaigns>();

	[NonSerialized]
	private static MSerialCampaigns[] All_cache;

	public int Id => _0024var_0024Id;

	public string TitleName => _0024var_0024TitleName;

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

	public DateTime StartDate => _0024var_0024StartDate;

	public DateTime EndDate => _0024var_0024EndDate;

	public bool IsDelete => _0024var_0024IsDelete;

	public int DuplicateTypeValue => _0024var_0024DuplicateTypeValue;

	public bool IsExternalCampaign => _0024var_0024IsExternalCampaign;

	public bool IsOnlyOnce => _0024var_0024IsOnlyOnce;

	public static MSerialCampaigns[] All
	{
		get
		{
			MSerialCampaigns[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MSerialCampaigns");
				MSerialCampaigns[] array = (MSerialCampaigns[])Builtins.array(typeof(MSerialCampaigns), _0024mst_002484.Values);
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

	public MSerialCampaigns()
	{
		_0024var_0024StartDate = DateTime.Parse("2001/01/01");
		_0024var_0024EndDate = DateTime.Parse("2099/01/01");
	}

	public static MSerialCampaigns Get(int _id)
	{
		MerlinMaster.GetHandler("MSerialCampaigns");
		return (!_0024mst_002484.ContainsKey(_id)) ? null : _0024mst_002484[_id];
	}

	public static void Unload()
	{
		_0024mst_002484.Clear();
		All_cache = null;
	}

	public static MSerialCampaigns New(Hashtable data)
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
			MSerialCampaigns mSerialCampaigns = Create(data);
			if (!_0024mst_002484.ContainsKey(mSerialCampaigns.Id))
			{
				_0024mst_002484[mSerialCampaigns.Id] = mSerialCampaigns;
			}
			result = mSerialCampaigns;
		}
		return (MSerialCampaigns)result;
	}

	public static MSerialCampaigns New2(string[] keys, object[] vals)
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
		return (MSerialCampaigns)result;
	}

	public static MSerialCampaigns Entry(MSerialCampaigns mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002484[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MSerialCampaigns)result;
	}

	public static void AddMst(MSerialCampaigns mst)
	{
		if (mst != null)
		{
			_0024mst_002484[mst.Id] = mst;
		}
	}

	public static MSerialCampaigns Create(Hashtable data)
	{
		MSerialCampaigns mSerialCampaigns = new MSerialCampaigns();
		MSerialCampaigns result;
		if (data == null)
		{
			result = mSerialCampaigns;
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
				mSerialCampaigns.setField((string)obj, data[current]);
			}
			result = mSerialCampaigns;
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
		case "TitleName":
			_0024var_0024TitleName = MasterBaseClass.ToStringValue(val);
			break;
		case "MItemGroupId":
			_0024var_0024MItemGroupId = MasterBaseClass.ToInt(val);
			break;
		case "StartDate":
		{
			object obj2 = val;
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			_0024var_0024StartDate = DateTime.Parse((string)obj2);
			break;
		}
		case "EndDate":
		{
			object obj = val;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			_0024var_0024EndDate = DateTime.Parse((string)obj);
			break;
		}
		case "IsDelete":
			_0024var_0024IsDelete = MasterBaseClass.ToBool(val);
			break;
		case "DuplicateTypeValue":
			_0024var_0024DuplicateTypeValue = MasterBaseClass.ToInt(val);
			break;
		case "IsExternalCampaign":
			_0024var_0024IsExternalCampaign = MasterBaseClass.ToBool(val);
			break;
		case "IsOnlyOnce":
			_0024var_0024IsOnlyOnce = MasterBaseClass.ToBool(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"TitleName" => true, 
			"MItemGroupId" => true, 
			"StartDate" => true, 
			"EndDate" => true, 
			"IsDelete" => true, 
			"DuplicateTypeValue" => true, 
			"IsExternalCampaign" => true, 
			"IsOnlyOnce" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[9] { "Id", "TitleName", "MItemGroupId", "StartDate", "EndDate", "IsDelete", "DuplicateTypeValue", "IsExternalCampaign", "IsOnlyOnce" });
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
					_0024var_0024TitleName = vals[1];
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
							_0024var_0024StartDate = MasterBaseClass.ParseDateTime(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024EndDate = MasterBaseClass.ParseDateTime(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024IsDelete = MasterBaseClass.ParseBool(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024DuplicateTypeValue = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024IsExternalCampaign = MasterBaseClass.ParseBool(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024IsOnlyOnce = MasterBaseClass.ParseBool(vals[8]);
											}
											int num = 9;
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
		return result;
	}
}
