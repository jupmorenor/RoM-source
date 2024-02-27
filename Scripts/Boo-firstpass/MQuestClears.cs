using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MQuestClears : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	public string _0024var_0024Explain;

	public string _0024var_0024Explain_En;

	public EnumQuestClearTypes _0024var_0024ClearType;

	public string _0024var_0024Target;

	public int _0024var_0024Target2;

	public int _0024var_0024Value;

	public int _0024var_0024Flag;

	public int _0024var_0024NotFlag;

	[NonSerialized]
	private MFlags Flag__cache;

	[NonSerialized]
	private MFlags NotFlag__cache;

	[NonSerialized]
	private static Dictionary<int, MQuestClears> _0024mst_002475 = new Dictionary<int, MQuestClears>();

	[NonSerialized]
	private static MQuestClears[] All_cache;

	public int KusamushiNum => Value;

	public MKusamushi KusamushiMaster => MKusamushi.Get(Target2);

	public int TalkId => Target2;

	public MNpcTalks NpcTalk => MNpcTalks.Get(Target2);

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

	public string Explain => _0024var_0024Explain;

	public string Explain_En => _0024var_0024Explain_En;

	public EnumQuestClearTypes ClearType => _0024var_0024ClearType;

	public string Target => _0024var_0024Target;

	public int Target2 => _0024var_0024Target2;

	public int Value => _0024var_0024Value;

	public MFlags Flag
	{
		get
		{
			if (Flag__cache == null)
			{
				Flag__cache = MFlags.Get(_0024var_0024Flag);
			}
			return Flag__cache;
		}
	}

	public MFlags NotFlag
	{
		get
		{
			if (NotFlag__cache == null)
			{
				NotFlag__cache = MFlags.Get(_0024var_0024NotFlag);
			}
			return NotFlag__cache;
		}
	}

	public static MQuestClears[] All
	{
		get
		{
			MQuestClears[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MQuestClears");
				MQuestClears[] array = (MQuestClears[])Builtins.array(typeof(MQuestClears), _0024mst_002475.Values);
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
		return (ClearType == EnumQuestClearTypes.Boss) ? "Boss" : ((ClearType == EnumQuestClearTypes.Kusamushi) ? ("Kusamushi: Id=" + Target2 + "(" + MKusamushi.Get(Target2) + ")") : ((ClearType == EnumQuestClearTypes.AllEnemies) ? "AllEnemies" : ((ClearType == EnumQuestClearTypes.SomeEnemies) ? ("SomeEnemies: Target=" + MMonsters.Get(Target2) + " num=" + Value) : ((ClearType == EnumQuestClearTypes.Talk) ? ("Talk: Target2(NpcTalkId)=" + Target2) : ((ClearType == EnumQuestClearTypes.Arrive) ? ("Arrive: Target=" + Target) : ((ClearType == EnumQuestClearTypes.Sec) ? "Sec?" : ((ClearType != EnumQuestClearTypes.True) ? new StringBuilder("MQuestClears(").Append((object)Id).Append(",").Append(Progname)
			.Append(":")
			.Append(ClearType)
			.Append(" Target:")
			.Append(Target)
			.Append(" Value:")
			.Append((object)Value)
			.Append(")")
			.ToString() : "True")))))));
	}

	public string GetExplain()
	{
		return (MerlinLanguageSetting.GetCurrentLanguage() != 0) ? Explain_En : Explain;
	}

	public static MQuestClears Get(int _id)
	{
		MerlinMaster.GetHandler("MQuestClears");
		return (!_0024mst_002475.ContainsKey(_id)) ? null : _0024mst_002475[_id];
	}

	public static void Unload()
	{
		_0024mst_002475.Clear();
		All_cache = null;
	}

	public static MQuestClears New(Hashtable data)
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
			MQuestClears mQuestClears = Create(data);
			if (!_0024mst_002475.ContainsKey(mQuestClears.Id))
			{
				_0024mst_002475[mQuestClears.Id] = mQuestClears;
			}
			result = mQuestClears;
		}
		return (MQuestClears)result;
	}

	public static MQuestClears New2(string[] keys, object[] vals)
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
		return (MQuestClears)result;
	}

	public static MQuestClears Entry(MQuestClears mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002475[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MQuestClears)result;
	}

	public static void AddMst(MQuestClears mst)
	{
		if (mst != null)
		{
			_0024mst_002475[mst.Id] = mst;
		}
	}

	public static MQuestClears Create(Hashtable data)
	{
		MQuestClears mQuestClears = new MQuestClears();
		MQuestClears result;
		if (data == null)
		{
			result = mQuestClears;
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
				mQuestClears.setField((string)obj, data[current]);
			}
			result = mQuestClears;
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
		case "Explain":
			_0024var_0024Explain = MasterBaseClass.ToStringValue(val);
			break;
		case "Explain_En":
			_0024var_0024Explain_En = MasterBaseClass.ToStringValue(val);
			break;
		case "ClearType":
			if (typeof(EnumQuestClearTypes).IsEnum)
			{
				_0024var_0024ClearType = (EnumQuestClearTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "Target":
			_0024var_0024Target = MasterBaseClass.ToStringValue(val);
			break;
		case "Target2":
			_0024var_0024Target2 = MasterBaseClass.ToInt(val);
			break;
		case "Value":
			_0024var_0024Value = MasterBaseClass.ToInt(val);
			break;
		case "Flag":
			_0024var_0024Flag = MasterBaseClass.ToInt(val);
			break;
		case "NotFlag":
			_0024var_0024NotFlag = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Progname" => true, 
			"Explain" => true, 
			"Explain_En" => true, 
			"ClearType" => true, 
			"Target" => true, 
			"Target2" => true, 
			"Value" => true, 
			"Flag" => true, 
			"NotFlag" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[10] { "Id", "Progname", "Explain", "Explain_En", "ClearType", "Target", "Target2", "Value", "Flag", "NotFlag" });
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
							_0024var_0024Explain_En = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null && typeof(EnumQuestClearTypes).IsEnum)
							{
								_0024var_0024ClearType = (EnumQuestClearTypes)MasterBaseClass.ParseEnum(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Target = vals[5];
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024Target2 = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024Value = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024Flag = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024NotFlag = MasterBaseClass.ParseInt(vals[9]);
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
