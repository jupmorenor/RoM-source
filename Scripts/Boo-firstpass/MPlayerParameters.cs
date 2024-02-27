using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MPlayerParameters : MerlinMaster
{
	public int _0024var_0024Id;

	public int _0024var_0024Level;

	public int _0024var_0024Ap;

	public int _0024var_0024BoxSize;

	public int _0024var_0024FriendUpperLimit;

	public int _0024var_0024Experience;

	[NonSerialized]
	private static Dictionary<int, MPlayerParameters> _0024mst_002426 = new Dictionary<int, MPlayerParameters>();

	[NonSerialized]
	private static MPlayerParameters[] All_cache;

	public int Id => _0024var_0024Id;

	public int Level => _0024var_0024Level;

	public int Ap => _0024var_0024Ap;

	public int BoxSize => _0024var_0024BoxSize;

	public int FriendUpperLimit => _0024var_0024FriendUpperLimit;

	public int Experience => _0024var_0024Experience;

	public static MPlayerParameters[] All
	{
		get
		{
			MPlayerParameters[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MPlayerParameters");
				MPlayerParameters[] array = (MPlayerParameters[])Builtins.array(typeof(MPlayerParameters), _0024mst_002426.Values);
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
		return new StringBuilder("MPlayerParameters(").Append((object)Id).Append(" ").Append((object)Level)
			.Append(" ")
			.Append((object)Ap)
			.Append(" ")
			.Append((object)BoxSize)
			.Append(" ")
			.Append((object)FriendUpperLimit)
			.Append(" ")
			.Append((object)Experience)
			.Append(")")
			.ToString();
	}

	public static MPlayerParameters GetLevelParam(int lv)
	{
		if (lv < 0)
		{
			lv = 1;
		}
		MPlayerParameters mPlayerParameters = Get(lv);
		if (mPlayerParameters == null)
		{
		}
		return mPlayerParameters;
	}

	public static MPlayerParameters Get(int _id)
	{
		MerlinMaster.GetHandler("MPlayerParameters");
		return (!_0024mst_002426.ContainsKey(_id)) ? null : _0024mst_002426[_id];
	}

	public static void Unload()
	{
		_0024mst_002426.Clear();
		All_cache = null;
	}

	public static MPlayerParameters New(Hashtable data)
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
			MPlayerParameters mPlayerParameters = Create(data);
			if (!_0024mst_002426.ContainsKey(mPlayerParameters.Id))
			{
				_0024mst_002426[mPlayerParameters.Id] = mPlayerParameters;
			}
			result = mPlayerParameters;
		}
		return (MPlayerParameters)result;
	}

	public static MPlayerParameters New2(string[] keys, object[] vals)
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
		return (MPlayerParameters)result;
	}

	public static MPlayerParameters Entry(MPlayerParameters mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002426[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MPlayerParameters)result;
	}

	public static void AddMst(MPlayerParameters mst)
	{
		if (mst != null)
		{
			_0024mst_002426[mst.Id] = mst;
		}
	}

	public static MPlayerParameters Create(Hashtable data)
	{
		MPlayerParameters mPlayerParameters = new MPlayerParameters();
		MPlayerParameters result;
		if (data == null)
		{
			result = mPlayerParameters;
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
				mPlayerParameters.setField((string)obj, data[current]);
			}
			result = mPlayerParameters;
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
		case "Level":
			_0024var_0024Level = MasterBaseClass.ToInt(val);
			break;
		case "Ap":
			_0024var_0024Ap = MasterBaseClass.ToInt(val);
			break;
		case "BoxSize":
			_0024var_0024BoxSize = MasterBaseClass.ToInt(val);
			break;
		case "FriendUpperLimit":
			_0024var_0024FriendUpperLimit = MasterBaseClass.ToInt(val);
			break;
		case "Experience":
			_0024var_0024Experience = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Level" => true, 
			"Ap" => true, 
			"BoxSize" => true, 
			"FriendUpperLimit" => true, 
			"Experience" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[6] { "Id", "Level", "Ap", "BoxSize", "FriendUpperLimit", "Experience" });
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
					_0024var_0024Level = MasterBaseClass.ParseInt(vals[1]);
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
							_0024var_0024BoxSize = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024FriendUpperLimit = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Experience = MasterBaseClass.ParseInt(vals[5]);
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
