using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;

[Serializable]
public class MAutoFlowPoint : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	public int _0024var_0024SceneId;

	public AutoFlowPointTypes _0024var_0024Type;

	public string _0024var_0024Param;

	public string _0024var_0024Name;

	[NonSerialized]
	private MScenes SceneId__cache;

	[NonSerialized]
	private static Dictionary<int, MAutoFlowPoint> _0024mst_0024133 = new Dictionary<int, MAutoFlowPoint>();

	[NonSerialized]
	private static MAutoFlowPoint[] All_cache;

	public MNpcTalks Talk_NpcTalks => MasterUtil.FindNpcTalk(Name);

	public string FlagAndPos_Name => Name;

	public string FlagAndPos_PosInfo => Param;

	public string Object_GameObjectName => Name;

	public string Pos_PositionInfo => Param;

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

	public MScenes SceneId
	{
		get
		{
			if (SceneId__cache == null)
			{
				SceneId__cache = MScenes.Get(_0024var_0024SceneId);
			}
			return SceneId__cache;
		}
	}

	public AutoFlowPointTypes Type => _0024var_0024Type;

	public string Param => _0024var_0024Param;

	public string Name => _0024var_0024Name;

	public static MAutoFlowPoint[] All
	{
		get
		{
			MAutoFlowPoint[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MAutoFlowPoint");
				MAutoFlowPoint[] array = (MAutoFlowPoint[])Builtins.array(typeof(MAutoFlowPoint), _0024mst_0024133.Values);
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

	public static MAutoFlowPoint[] GetAllFlowPoints(MQuests q)
	{
		Boo.Lang.List<MAutoFlowPoint> list = new Boo.Lang.List<MAutoFlowPoint>();
		int i = 0;
		MAutoFlowPoint[] all = All;
		checked
		{
			for (int length = all.Length; i < length; i++)
			{
				if (all[i] != null && all[i].SceneId != null && RuntimeServices.EqualityOperator(all[i].SceneId.MQuestId, q))
				{
					list.Add(all[i]);
				}
			}
			list.Sort(_0024adaptor_0024__MastersAutoBattle_0024callable70_0024111_20___0024Comparison_00244.Adapt((MAutoFlowPoint a, MAutoFlowPoint b) => a.Id - b.Id));
			return (MAutoFlowPoint[])Builtins.array(typeof(MAutoFlowPoint), list);
		}
	}

	public override string ToString()
	{
		return new StringBuilder("MAutoFlowPoint(").Append((object)Id).Append(" Type:").Append(Type)
			.Append(" Name:")
			.Append(Name)
			.Append(" Param:")
			.Append(Param)
			.Append(")")
			.ToString();
	}

	public static MAutoFlowPoint Get(int _id)
	{
		MerlinMaster.GetHandler("MAutoFlowPoint");
		return (!_0024mst_0024133.ContainsKey(_id)) ? null : _0024mst_0024133[_id];
	}

	public static void Unload()
	{
		_0024mst_0024133.Clear();
		All_cache = null;
	}

	public static MAutoFlowPoint New(Hashtable data)
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
			MAutoFlowPoint mAutoFlowPoint = Create(data);
			if (!_0024mst_0024133.ContainsKey(mAutoFlowPoint.Id))
			{
				_0024mst_0024133[mAutoFlowPoint.Id] = mAutoFlowPoint;
			}
			result = mAutoFlowPoint;
		}
		return (MAutoFlowPoint)result;
	}

	public static MAutoFlowPoint New2(string[] keys, object[] vals)
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
		return (MAutoFlowPoint)result;
	}

	public static MAutoFlowPoint Entry(MAutoFlowPoint mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024133[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MAutoFlowPoint)result;
	}

	public static void AddMst(MAutoFlowPoint mst)
	{
		if (mst != null)
		{
			_0024mst_0024133[mst.Id] = mst;
		}
	}

	public static MAutoFlowPoint Create(Hashtable data)
	{
		MAutoFlowPoint mAutoFlowPoint = new MAutoFlowPoint();
		MAutoFlowPoint result;
		if (data == null)
		{
			result = mAutoFlowPoint;
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
				mAutoFlowPoint.setField((string)obj, data[current]);
			}
			result = mAutoFlowPoint;
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
		case "SceneId":
			_0024var_0024SceneId = MasterBaseClass.ToInt(val);
			break;
		case "Type":
			if (typeof(AutoFlowPointTypes).IsEnum)
			{
				_0024var_0024Type = (AutoFlowPointTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "Param":
			_0024var_0024Param = MasterBaseClass.ToStringValue(val);
			break;
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Progname" => true, 
			"SceneId" => true, 
			"Type" => true, 
			"Param" => true, 
			"Name" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[6] { "Id", "Progname", "SceneId", "Type", "Param", "Name" });
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
						_0024var_0024SceneId = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null && typeof(AutoFlowPointTypes).IsEnum)
						{
							_0024var_0024Type = (AutoFlowPointTypes)MasterBaseClass.ParseEnum(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024Param = vals[4];
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Name = vals[5];
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

	internal static int _0024GetAllFlowPoints_0024closure_0024260(MAutoFlowPoint a, MAutoFlowPoint b)
	{
		return checked(a.Id - b.Id);
	}
}
