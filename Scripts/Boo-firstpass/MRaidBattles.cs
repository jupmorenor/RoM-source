using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class MRaidBattles : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024MMonsterId;

	public string _0024var_0024Name;

	public string _0024var_0024DiscoveryCutScene_1;

	public string _0024var_0024DiscoveryCutScene_2;

	public int _0024var_0024Bgm;

	[NonSerialized]
	private MBgm Bgm__cache;

	[NonSerialized]
	private static Dictionary<int, MRaidBattles> _0024mst_002439 = new Dictionary<int, MRaidBattles>();

	[NonSerialized]
	private static MRaidBattles[] All_cache;

	public string[] AllDiscoveryCutScenes
	{
		get
		{
			Boo.Lang.List<string> list = new Boo.Lang.List<string>();
			if (DiscoveryCutScene_1 != null)
			{
				list.Add(DiscoveryCutScene_1);
			}
			if (DiscoveryCutScene_2 != null)
			{
				list.Add(DiscoveryCutScene_2);
			}
			return list.ToArray();
		}
	}

	public int Id => _0024var_0024Id;

	public int MMonsterId => _0024var_0024MMonsterId;

	public string Name => _0024var_0024Name;

	public string DiscoveryCutScene_1 => _0024var_0024DiscoveryCutScene_1;

	public string DiscoveryCutScene_2 => _0024var_0024DiscoveryCutScene_2;

	public MBgm Bgm
	{
		get
		{
			if (Bgm__cache == null)
			{
				Bgm__cache = MBgm.Get(_0024var_0024Bgm);
			}
			return Bgm__cache;
		}
	}

	public static MRaidBattles[] All
	{
		get
		{
			MRaidBattles[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MRaidBattles");
				MRaidBattles[] array = (MRaidBattles[])Builtins.array(typeof(MRaidBattles), _0024mst_002439.Values);
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

	public MRaidBattles()
	{
		_0024var_0024Bgm = -1;
	}

	public static MRaidBattles FindByMonster(int monsterId)
	{
		int num = 0;
		MRaidBattles[] all = All;
		int length = all.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (all[num].MMonsterId == monsterId)
				{
					result = all[num];
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = null;
			break;
		}
		return (MRaidBattles)result;
	}

	public override string ToString()
	{
		return new StringBuilder("MRaidBattles(").Append((object)Id).Append(" ").Append((object)MMonsterId)
			.Append(" ")
			.Append(Name)
			.Append(" ")
			.Append(DiscoveryCutScene_1)
			.Append(" ")
			.Append(DiscoveryCutScene_2)
			.Append(" )")
			.ToString();
	}

	public string GetRadomDiscoveryCutScenes()
	{
		return (string.IsNullOrEmpty(DiscoveryCutScene_1) && string.IsNullOrEmpty(DiscoveryCutScene_2)) ? ((UnityEngine.Random.RandomRange(0, 100) < 50) ? DiscoveryCutScene_2 : DiscoveryCutScene_1) : (string.IsNullOrEmpty(DiscoveryCutScene_1) ? DiscoveryCutScene_1 : ((!string.IsNullOrEmpty(DiscoveryCutScene_2)) ? null : DiscoveryCutScene_1));
	}

	public static MRaidBattles Get(int _id)
	{
		MerlinMaster.GetHandler("MRaidBattles");
		return (!_0024mst_002439.ContainsKey(_id)) ? null : _0024mst_002439[_id];
	}

	public static void Unload()
	{
		_0024mst_002439.Clear();
		All_cache = null;
	}

	public static MRaidBattles New(Hashtable data)
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
			MRaidBattles mRaidBattles = Create(data);
			if (!_0024mst_002439.ContainsKey(mRaidBattles.Id))
			{
				_0024mst_002439[mRaidBattles.Id] = mRaidBattles;
			}
			result = mRaidBattles;
		}
		return (MRaidBattles)result;
	}

	public static MRaidBattles New2(string[] keys, object[] vals)
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
		return (MRaidBattles)result;
	}

	public static MRaidBattles Entry(MRaidBattles mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002439[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MRaidBattles)result;
	}

	public static void AddMst(MRaidBattles mst)
	{
		if (mst != null)
		{
			_0024mst_002439[mst.Id] = mst;
		}
	}

	public static MRaidBattles Create(Hashtable data)
	{
		MRaidBattles mRaidBattles = new MRaidBattles();
		MRaidBattles result;
		if (data == null)
		{
			result = mRaidBattles;
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
				mRaidBattles.setField((string)obj, data[current]);
			}
			result = mRaidBattles;
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
		case "MMonsterId":
			_0024var_0024MMonsterId = MasterBaseClass.ToInt(val);
			break;
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		case "DiscoveryCutScene_1":
			_0024var_0024DiscoveryCutScene_1 = MasterBaseClass.ToStringValue(val);
			break;
		case "DiscoveryCutScene_2":
			_0024var_0024DiscoveryCutScene_2 = MasterBaseClass.ToStringValue(val);
			break;
		case "Bgm":
			_0024var_0024Bgm = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"MMonsterId" => true, 
			"Name" => true, 
			"DiscoveryCutScene_1" => true, 
			"DiscoveryCutScene_2" => true, 
			"Bgm" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[6] { "Id", "MMonsterId", "Name", "DiscoveryCutScene_1", "DiscoveryCutScene_2", "Bgm" });
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
					_0024var_0024MMonsterId = MasterBaseClass.ParseInt(vals[1]);
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
							_0024var_0024DiscoveryCutScene_1 = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024DiscoveryCutScene_2 = vals[4];
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Bgm = MasterBaseClass.ParseInt(vals[5]);
								}
								int num = 6;
								result = num;
							}
						}
					}
				}
			}
		}
		return result;
	}
}
