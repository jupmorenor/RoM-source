using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MRaidWords : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public EnumRaidWordTypes _0024var_0024WordType;

	public int _0024var_0024RandomGroup;

	[NonSerialized]
	private MTexts Name__cache;

	[NonSerialized]
	private static Dictionary<int, MRaidWords> _0024mst_002437 = new Dictionary<int, MRaidWords>();

	[NonSerialized]
	private static MRaidWords[] All_cache;

	public static int[] AllRandomGroup
	{
		get
		{
			HashSet<int> hashSet = new HashSet<int>();
			int i = 0;
			MRaidWords[] all = All;
			for (int length = all.Length; i < length; i = checked(i + 1))
			{
				hashSet.Add(all[i].RandomGroup);
			}
			return (int[])Builtins.array(typeof(int), hashSet);
		}
	}

	public int Id => _0024var_0024Id;

	public MTexts Name
	{
		get
		{
			if (Name__cache == null)
			{
				Name__cache = MTexts.Get(_0024var_0024Name);
			}
			return Name__cache;
		}
	}

	public EnumRaidWordTypes WordType => _0024var_0024WordType;

	public int RandomGroup => _0024var_0024RandomGroup;

	public static MRaidWords[] All
	{
		get
		{
			MRaidWords[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MRaidWords");
				MRaidWords[] array = (MRaidWords[])Builtins.array(typeof(MRaidWords), _0024mst_002437.Values);
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

	public static MRaidWords[] getWords(EnumRaidWordTypes type)
	{
		System.Collections.Generic.List<MRaidWords> list = new System.Collections.Generic.List<MRaidWords>();
		int i = 0;
		MRaidWords[] all = All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (all[i].WordType == type)
			{
				list.Add(all[i]);
			}
		}
		return list.ToArray();
	}

	public override string ToString()
	{
		return new StringBuilder("MRaidWords(").Append((object)Id).Append(",type:").Append(WordType)
			.Append(",randomGroup:")
			.Append((object)RandomGroup)
			.Append(")")
			.ToString();
	}

	public static MRaidWords Get(int _id)
	{
		MerlinMaster.GetHandler("MRaidWords");
		return (!_0024mst_002437.ContainsKey(_id)) ? null : _0024mst_002437[_id];
	}

	public static void Unload()
	{
		_0024mst_002437.Clear();
		All_cache = null;
	}

	public static MRaidWords New(Hashtable data)
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
			MRaidWords mRaidWords = Create(data);
			if (!_0024mst_002437.ContainsKey(mRaidWords.Id))
			{
				_0024mst_002437[mRaidWords.Id] = mRaidWords;
			}
			result = mRaidWords;
		}
		return (MRaidWords)result;
	}

	public static MRaidWords New2(string[] keys, object[] vals)
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
		return (MRaidWords)result;
	}

	public static MRaidWords Entry(MRaidWords mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002437[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MRaidWords)result;
	}

	public static void AddMst(MRaidWords mst)
	{
		if (mst != null)
		{
			_0024mst_002437[mst.Id] = mst;
		}
	}

	public static MRaidWords Create(Hashtable data)
	{
		MRaidWords mRaidWords = new MRaidWords();
		MRaidWords result;
		if (data == null)
		{
			result = mRaidWords;
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
				mRaidWords.setField((string)obj, data[current]);
			}
			result = mRaidWords;
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
		case "WordType":
			if (typeof(EnumRaidWordTypes).IsEnum)
			{
				_0024var_0024WordType = (EnumRaidWordTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "RandomGroup":
			_0024var_0024RandomGroup = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Name" => true, 
			"WordType" => true, 
			"RandomGroup" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[4] { "Id", "Name", "WordType", "RandomGroup" });
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
					if (vals[2] != null && typeof(EnumRaidWordTypes).IsEnum)
					{
						_0024var_0024WordType = (EnumRaidWordTypes)MasterBaseClass.ParseEnum(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024RandomGroup = MasterBaseClass.ParseInt(vals[3]);
						}
						int num = 4;
						result = num;
					}
				}
			}
		}
		return result;
	}
}
