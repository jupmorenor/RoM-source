using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MPackedSceneMap : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024SceneName;

	public string _0024var_0024PackName;

	public string _0024var_0024DirName;

	public string _0024var_0024PrefabName;

	public string _0024var_0024PrefabPath;

	[NonSerialized]
	private static Dictionary<int, MPackedSceneMap> _0024mst_0024112 = new Dictionary<int, MPackedSceneMap>();

	[NonSerialized]
	private static MPackedSceneMap[] All_cache;

	public int Id => _0024var_0024Id;

	public string SceneName => _0024var_0024SceneName;

	public string PackName => _0024var_0024PackName;

	public string DirName => _0024var_0024DirName;

	public string PrefabName => _0024var_0024PrefabName;

	public string PrefabPath => _0024var_0024PrefabPath;

	public static MPackedSceneMap[] All
	{
		get
		{
			MPackedSceneMap[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MPackedSceneMap");
				MPackedSceneMap[] array = (MPackedSceneMap[])Builtins.array(typeof(MPackedSceneMap), _0024mst_0024112.Values);
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
		return new StringBuilder("MPackedSceneMap(").Append((object)Id).Append(" ").Append(PrefabName)
			.Append(" in ")
			.Append(PackName)
			.Append(")")
			.ToString();
	}

	public static MPackedSceneMap Get(int _id)
	{
		MerlinMaster.GetHandler("MPackedSceneMap");
		return (!_0024mst_0024112.ContainsKey(_id)) ? null : _0024mst_0024112[_id];
	}

	public static void Unload()
	{
		_0024mst_0024112.Clear();
		All_cache = null;
	}

	public static MPackedSceneMap New(Hashtable data)
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
			MPackedSceneMap mPackedSceneMap = Create(data);
			if (!_0024mst_0024112.ContainsKey(mPackedSceneMap.Id))
			{
				_0024mst_0024112[mPackedSceneMap.Id] = mPackedSceneMap;
			}
			result = mPackedSceneMap;
		}
		return (MPackedSceneMap)result;
	}

	public static MPackedSceneMap New2(string[] keys, object[] vals)
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
		return (MPackedSceneMap)result;
	}

	public static MPackedSceneMap Entry(MPackedSceneMap mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024112[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MPackedSceneMap)result;
	}

	public static void AddMst(MPackedSceneMap mst)
	{
		if (mst != null)
		{
			_0024mst_0024112[mst.Id] = mst;
		}
	}

	public static MPackedSceneMap Create(Hashtable data)
	{
		MPackedSceneMap mPackedSceneMap = new MPackedSceneMap();
		MPackedSceneMap result;
		if (data == null)
		{
			result = mPackedSceneMap;
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
				mPackedSceneMap.setField((string)obj, data[current]);
			}
			result = mPackedSceneMap;
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
		case "SceneName":
			_0024var_0024SceneName = MasterBaseClass.ToStringValue(val);
			break;
		case "PackName":
			_0024var_0024PackName = MasterBaseClass.ToStringValue(val);
			break;
		case "DirName":
			_0024var_0024DirName = MasterBaseClass.ToStringValue(val);
			break;
		case "PrefabName":
			_0024var_0024PrefabName = MasterBaseClass.ToStringValue(val);
			break;
		case "PrefabPath":
			_0024var_0024PrefabPath = MasterBaseClass.ToStringValue(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"SceneName" => true, 
			"PackName" => true, 
			"DirName" => true, 
			"PrefabName" => true, 
			"PrefabPath" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[6] { "Id", "SceneName", "PackName", "DirName", "PrefabName", "PrefabPath" });
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
					_0024var_0024SceneName = vals[1];
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024PackName = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024DirName = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024PrefabName = vals[4];
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024PrefabPath = vals[5];
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
