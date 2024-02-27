using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MSkillEffectTypes : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public string _0024var_0024Progname;

	public int _0024var_0024SkillActionType;

	[NonSerialized]
	private static Dictionary<int, MSkillEffectTypes> _0024mst_002415 = new Dictionary<int, MSkillEffectTypes>();

	[NonSerialized]
	private static MSkillEffectTypes[] All_cache;

	public int Id => _0024var_0024Id;

	public string Name => _0024var_0024Name;

	public string Progname => _0024var_0024Progname;

	public int SkillActionType => _0024var_0024SkillActionType;

	public static MSkillEffectTypes[] All
	{
		get
		{
			MSkillEffectTypes[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MSkillEffectTypes");
				MSkillEffectTypes[] array = (MSkillEffectTypes[])Builtins.array(typeof(MSkillEffectTypes), _0024mst_002415.Values);
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
		return new StringBuilder("MSkillEffectTypes(").Append((object)Id).Append(":").Append(Progname)
			.Append(")")
			.ToString();
	}

	public static MSkillEffectTypes Get(int _id)
	{
		MerlinMaster.GetHandler("MSkillEffectTypes");
		return (!_0024mst_002415.ContainsKey(_id)) ? null : _0024mst_002415[_id];
	}

	public static void Unload()
	{
		_0024mst_002415.Clear();
		All_cache = null;
	}

	public static MSkillEffectTypes New(Hashtable data)
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
			MSkillEffectTypes mSkillEffectTypes = Create(data);
			if (!_0024mst_002415.ContainsKey(mSkillEffectTypes.Id))
			{
				_0024mst_002415[mSkillEffectTypes.Id] = mSkillEffectTypes;
			}
			result = mSkillEffectTypes;
		}
		return (MSkillEffectTypes)result;
	}

	public static MSkillEffectTypes New2(string[] keys, object[] vals)
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
		return (MSkillEffectTypes)result;
	}

	public static MSkillEffectTypes Entry(MSkillEffectTypes mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002415[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MSkillEffectTypes)result;
	}

	public static void AddMst(MSkillEffectTypes mst)
	{
		if (mst != null)
		{
			_0024mst_002415[mst.Id] = mst;
		}
	}

	public static MSkillEffectTypes Create(Hashtable data)
	{
		MSkillEffectTypes mSkillEffectTypes = new MSkillEffectTypes();
		MSkillEffectTypes result;
		if (data == null)
		{
			result = mSkillEffectTypes;
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
				mSkillEffectTypes.setField((string)obj, data[current]);
			}
			result = mSkillEffectTypes;
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
		case "Progname":
			_0024var_0024Progname = MasterBaseClass.ToStringValue(val);
			break;
		case "SkillActionType":
			_0024var_0024SkillActionType = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Name" => true, 
			"Progname" => true, 
			"SkillActionType" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[4] { "Id", "Name", "Progname", "SkillActionType" });
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
						_0024var_0024Progname = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024SkillActionType = MasterBaseClass.ParseInt(vals[3]);
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
