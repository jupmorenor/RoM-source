using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MNpcTalks : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	public int _0024var_0024Condition_1;

	public int _0024var_0024Condition_2;

	public int _0024var_0024Condition_3;

	public int _0024var_0024Condition_4;

	public int _0024var_0024Condition_5;

	public int _0024var_0024Condition_6;

	public int _0024var_0024Condition_7;

	public int _0024var_0024Condition_8;

	public int _0024var_0024NotCondition_1;

	public int _0024var_0024NotCondition_2;

	public int _0024var_0024NotCondition_3;

	public int _0024var_0024NotCondition_4;

	public int _0024var_0024NotCondition_5;

	public int _0024var_0024NotCondition_6;

	public int _0024var_0024NotCondition_7;

	public int _0024var_0024NotCondition_8;

	public int _0024var_0024FadeResult;

	public string _0024var_0024MSceneId;

	public string _0024var_0024TalkGroupId;

	public float _0024var_0024Rate;

	public int _0024var_0024MNpcTextId;

	public string _0024var_0024CutScene;

	public int _0024var_0024Result_1;

	public int _0024var_0024Result_2;

	public int _0024var_0024Result_3;

	public int _0024var_0024Result_4;

	public int _0024var_0024Result_5;

	public int _0024var_0024Result_6;

	public int _0024var_0024Result_7;

	public int _0024var_0024Result_8;

	public int _0024var_0024NotResult_1;

	public int _0024var_0024NotResult_2;

	public int _0024var_0024NotResult_3;

	public int _0024var_0024NotResult_4;

	public int _0024var_0024NotResult_5;

	public int _0024var_0024NotResult_6;

	public int _0024var_0024NotResult_7;

	public int _0024var_0024NotResult_8;

	public string _0024var_0024NextScene;

	public string _0024var_0024NextSceneKeepObjects;

	public string _0024var_0024ResultPlayerPosition;

	public string _0024var_0024ResultNpcPosition;

	public bool _0024var_0024TurnAround;

	public bool _0024var_0024BustShot;

	public EnumNpcTalkIcons _0024var_0024Icon;

	public EnumNpcTalkIcons _0024var_0024DistantIcon;

	public float _0024var_0024Distance;

	public float _0024var_0024Range;

	public string _0024var_0024Collision;

	public int _0024var_0024TalkCount;

	public EnumWindowTypes _0024var_0024WindowType;

	public EnumNpcTalkTypes _0024var_0024TalkType;

	public bool _0024var_0024NoResumeLastBgm;

	public int _0024var_0024StartBgm;

	public int _0024var_0024ResultBgm;

	public string _0024var_0024StartSe;

	public int _0024var_0024StartSeDelayMsec;

	public string _0024var_0024ResultSe;

	public int _0024var_0024ResultSeDelayMsec;

	public int _0024var_0024ResultAction;

	public int _0024var_0024ResultPlayerAction;

	public int _0024var_0024StartRace;

	public int _0024var_0024ResultRace;

	public int _0024var_0024Warp;

	[NonSerialized]
	private MFlags Condition_1__cache;

	[NonSerialized]
	private MFlags Condition_2__cache;

	[NonSerialized]
	private MFlags Condition_3__cache;

	[NonSerialized]
	private MFlags Condition_4__cache;

	[NonSerialized]
	private MFlags Condition_5__cache;

	[NonSerialized]
	private MFlags Condition_6__cache;

	[NonSerialized]
	private MFlags Condition_7__cache;

	[NonSerialized]
	private MFlags Condition_8__cache;

	[NonSerialized]
	private MFlags NotCondition_1__cache;

	[NonSerialized]
	private MFlags NotCondition_2__cache;

	[NonSerialized]
	private MFlags NotCondition_3__cache;

	[NonSerialized]
	private MFlags NotCondition_4__cache;

	[NonSerialized]
	private MFlags NotCondition_5__cache;

	[NonSerialized]
	private MFlags NotCondition_6__cache;

	[NonSerialized]
	private MFlags NotCondition_7__cache;

	[NonSerialized]
	private MFlags NotCondition_8__cache;

	[NonSerialized]
	private MFlags FadeResult__cache;

	[NonSerialized]
	private MNpcTexts MNpcTextId__cache;

	[NonSerialized]
	private MFlags Result_1__cache;

	[NonSerialized]
	private MFlags Result_2__cache;

	[NonSerialized]
	private MFlags Result_3__cache;

	[NonSerialized]
	private MFlags Result_4__cache;

	[NonSerialized]
	private MFlags Result_5__cache;

	[NonSerialized]
	private MFlags Result_6__cache;

	[NonSerialized]
	private MFlags Result_7__cache;

	[NonSerialized]
	private MFlags Result_8__cache;

	[NonSerialized]
	private MFlags NotResult_1__cache;

	[NonSerialized]
	private MFlags NotResult_2__cache;

	[NonSerialized]
	private MFlags NotResult_3__cache;

	[NonSerialized]
	private MFlags NotResult_4__cache;

	[NonSerialized]
	private MFlags NotResult_5__cache;

	[NonSerialized]
	private MFlags NotResult_6__cache;

	[NonSerialized]
	private MFlags NotResult_7__cache;

	[NonSerialized]
	private MFlags NotResult_8__cache;

	[NonSerialized]
	private MBgm StartBgm__cache;

	[NonSerialized]
	private MBgm ResultBgm__cache;

	[NonSerialized]
	private MCharacterActionTypes ResultAction__cache;

	[NonSerialized]
	private MCharacterActionTypes ResultPlayerAction__cache;

	[NonSerialized]
	private MPlayerRaces StartRace__cache;

	[NonSerialized]
	private MPlayerRaces ResultRace__cache;

	[NonSerialized]
	private MWarps Warp__cache;

	[NonSerialized]
	private static Dictionary<int, MNpcTalks> _0024mst_002459 = new Dictionary<int, MNpcTalks>();

	[NonSerialized]
	private static MNpcTalks[] All_cache;

	public MFlags[] AllConditions
	{
		get
		{
			System.Collections.Generic.List<MFlags> list = new System.Collections.Generic.List<MFlags>();
			if (Condition_1 != null)
			{
				list.Add(Condition_1);
			}
			if (Condition_2 != null)
			{
				list.Add(Condition_2);
			}
			if (Condition_3 != null)
			{
				list.Add(Condition_3);
			}
			if (Condition_4 != null)
			{
				list.Add(Condition_4);
			}
			if (Condition_5 != null)
			{
				list.Add(Condition_5);
			}
			if (Condition_6 != null)
			{
				list.Add(Condition_6);
			}
			if (Condition_7 != null)
			{
				list.Add(Condition_7);
			}
			if (Condition_8 != null)
			{
				list.Add(Condition_8);
			}
			return list.ToArray();
		}
	}

	public MFlags[] AllNotConditions
	{
		get
		{
			System.Collections.Generic.List<MFlags> list = new System.Collections.Generic.List<MFlags>();
			if (NotCondition_1 != null)
			{
				list.Add(NotCondition_1);
			}
			if (NotCondition_2 != null)
			{
				list.Add(NotCondition_2);
			}
			if (NotCondition_3 != null)
			{
				list.Add(NotCondition_3);
			}
			if (NotCondition_4 != null)
			{
				list.Add(NotCondition_4);
			}
			if (NotCondition_5 != null)
			{
				list.Add(NotCondition_5);
			}
			if (NotCondition_6 != null)
			{
				list.Add(NotCondition_6);
			}
			if (NotCondition_7 != null)
			{
				list.Add(NotCondition_7);
			}
			if (NotCondition_8 != null)
			{
				list.Add(NotCondition_8);
			}
			return list.ToArray();
		}
	}

	public MFlags[] AllResults
	{
		get
		{
			System.Collections.Generic.List<MFlags> list = new System.Collections.Generic.List<MFlags>();
			if (Result_1 != null)
			{
				list.Add(Result_1);
			}
			if (Result_2 != null)
			{
				list.Add(Result_2);
			}
			if (Result_3 != null)
			{
				list.Add(Result_3);
			}
			if (Result_4 != null)
			{
				list.Add(Result_4);
			}
			if (Result_5 != null)
			{
				list.Add(Result_5);
			}
			if (Result_6 != null)
			{
				list.Add(Result_6);
			}
			if (Result_7 != null)
			{
				list.Add(Result_7);
			}
			if (Result_8 != null)
			{
				list.Add(Result_8);
			}
			return list.ToArray();
		}
	}

	public MFlags[] AllNotResults
	{
		get
		{
			System.Collections.Generic.List<MFlags> list = new System.Collections.Generic.List<MFlags>();
			if (NotResult_1 != null)
			{
				list.Add(NotResult_1);
			}
			if (NotResult_2 != null)
			{
				list.Add(NotResult_2);
			}
			if (NotResult_3 != null)
			{
				list.Add(NotResult_3);
			}
			if (NotResult_4 != null)
			{
				list.Add(NotResult_4);
			}
			if (NotResult_5 != null)
			{
				list.Add(NotResult_5);
			}
			if (NotResult_6 != null)
			{
				list.Add(NotResult_6);
			}
			if (NotResult_7 != null)
			{
				list.Add(NotResult_7);
			}
			if (NotResult_8 != null)
			{
				list.Add(NotResult_8);
			}
			return list.ToArray();
		}
	}

	public MNpcTalkIcons IconMaster => MNpcTalkIcons.Get((int)Icon);

	public MNpcTalkIcons DistantIconMaster => MNpcTalkIcons.Get((int)DistantIcon);

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

	public MFlags Condition_1
	{
		get
		{
			if (Condition_1__cache == null)
			{
				Condition_1__cache = MFlags.Get(_0024var_0024Condition_1);
			}
			return Condition_1__cache;
		}
	}

	public MFlags Condition_2
	{
		get
		{
			if (Condition_2__cache == null)
			{
				Condition_2__cache = MFlags.Get(_0024var_0024Condition_2);
			}
			return Condition_2__cache;
		}
	}

	public MFlags Condition_3
	{
		get
		{
			if (Condition_3__cache == null)
			{
				Condition_3__cache = MFlags.Get(_0024var_0024Condition_3);
			}
			return Condition_3__cache;
		}
	}

	public MFlags Condition_4
	{
		get
		{
			if (Condition_4__cache == null)
			{
				Condition_4__cache = MFlags.Get(_0024var_0024Condition_4);
			}
			return Condition_4__cache;
		}
	}

	public MFlags Condition_5
	{
		get
		{
			if (Condition_5__cache == null)
			{
				Condition_5__cache = MFlags.Get(_0024var_0024Condition_5);
			}
			return Condition_5__cache;
		}
	}

	public MFlags Condition_6
	{
		get
		{
			if (Condition_6__cache == null)
			{
				Condition_6__cache = MFlags.Get(_0024var_0024Condition_6);
			}
			return Condition_6__cache;
		}
	}

	public MFlags Condition_7
	{
		get
		{
			if (Condition_7__cache == null)
			{
				Condition_7__cache = MFlags.Get(_0024var_0024Condition_7);
			}
			return Condition_7__cache;
		}
	}

	public MFlags Condition_8
	{
		get
		{
			if (Condition_8__cache == null)
			{
				Condition_8__cache = MFlags.Get(_0024var_0024Condition_8);
			}
			return Condition_8__cache;
		}
	}

	public MFlags NotCondition_1
	{
		get
		{
			if (NotCondition_1__cache == null)
			{
				NotCondition_1__cache = MFlags.Get(_0024var_0024NotCondition_1);
			}
			return NotCondition_1__cache;
		}
	}

	public MFlags NotCondition_2
	{
		get
		{
			if (NotCondition_2__cache == null)
			{
				NotCondition_2__cache = MFlags.Get(_0024var_0024NotCondition_2);
			}
			return NotCondition_2__cache;
		}
	}

	public MFlags NotCondition_3
	{
		get
		{
			if (NotCondition_3__cache == null)
			{
				NotCondition_3__cache = MFlags.Get(_0024var_0024NotCondition_3);
			}
			return NotCondition_3__cache;
		}
	}

	public MFlags NotCondition_4
	{
		get
		{
			if (NotCondition_4__cache == null)
			{
				NotCondition_4__cache = MFlags.Get(_0024var_0024NotCondition_4);
			}
			return NotCondition_4__cache;
		}
	}

	public MFlags NotCondition_5
	{
		get
		{
			if (NotCondition_5__cache == null)
			{
				NotCondition_5__cache = MFlags.Get(_0024var_0024NotCondition_5);
			}
			return NotCondition_5__cache;
		}
	}

	public MFlags NotCondition_6
	{
		get
		{
			if (NotCondition_6__cache == null)
			{
				NotCondition_6__cache = MFlags.Get(_0024var_0024NotCondition_6);
			}
			return NotCondition_6__cache;
		}
	}

	public MFlags NotCondition_7
	{
		get
		{
			if (NotCondition_7__cache == null)
			{
				NotCondition_7__cache = MFlags.Get(_0024var_0024NotCondition_7);
			}
			return NotCondition_7__cache;
		}
	}

	public MFlags NotCondition_8
	{
		get
		{
			if (NotCondition_8__cache == null)
			{
				NotCondition_8__cache = MFlags.Get(_0024var_0024NotCondition_8);
			}
			return NotCondition_8__cache;
		}
	}

	public MFlags FadeResult
	{
		get
		{
			if (FadeResult__cache == null)
			{
				FadeResult__cache = MFlags.Get(_0024var_0024FadeResult);
			}
			return FadeResult__cache;
		}
	}

	public string MSceneId => _0024var_0024MSceneId;

	public string TalkGroupId => _0024var_0024TalkGroupId;

	public float Rate => _0024var_0024Rate;

	public MNpcTexts MNpcTextId
	{
		get
		{
			if (MNpcTextId__cache == null)
			{
				MNpcTextId__cache = MNpcTexts.Get(_0024var_0024MNpcTextId);
			}
			return MNpcTextId__cache;
		}
	}

	public string CutScene => _0024var_0024CutScene;

	public MFlags Result_1
	{
		get
		{
			if (Result_1__cache == null)
			{
				Result_1__cache = MFlags.Get(_0024var_0024Result_1);
			}
			return Result_1__cache;
		}
	}

	public MFlags Result_2
	{
		get
		{
			if (Result_2__cache == null)
			{
				Result_2__cache = MFlags.Get(_0024var_0024Result_2);
			}
			return Result_2__cache;
		}
	}

	public MFlags Result_3
	{
		get
		{
			if (Result_3__cache == null)
			{
				Result_3__cache = MFlags.Get(_0024var_0024Result_3);
			}
			return Result_3__cache;
		}
	}

	public MFlags Result_4
	{
		get
		{
			if (Result_4__cache == null)
			{
				Result_4__cache = MFlags.Get(_0024var_0024Result_4);
			}
			return Result_4__cache;
		}
	}

	public MFlags Result_5
	{
		get
		{
			if (Result_5__cache == null)
			{
				Result_5__cache = MFlags.Get(_0024var_0024Result_5);
			}
			return Result_5__cache;
		}
	}

	public MFlags Result_6
	{
		get
		{
			if (Result_6__cache == null)
			{
				Result_6__cache = MFlags.Get(_0024var_0024Result_6);
			}
			return Result_6__cache;
		}
	}

	public MFlags Result_7
	{
		get
		{
			if (Result_7__cache == null)
			{
				Result_7__cache = MFlags.Get(_0024var_0024Result_7);
			}
			return Result_7__cache;
		}
	}

	public MFlags Result_8
	{
		get
		{
			if (Result_8__cache == null)
			{
				Result_8__cache = MFlags.Get(_0024var_0024Result_8);
			}
			return Result_8__cache;
		}
	}

	public MFlags NotResult_1
	{
		get
		{
			if (NotResult_1__cache == null)
			{
				NotResult_1__cache = MFlags.Get(_0024var_0024NotResult_1);
			}
			return NotResult_1__cache;
		}
	}

	public MFlags NotResult_2
	{
		get
		{
			if (NotResult_2__cache == null)
			{
				NotResult_2__cache = MFlags.Get(_0024var_0024NotResult_2);
			}
			return NotResult_2__cache;
		}
	}

	public MFlags NotResult_3
	{
		get
		{
			if (NotResult_3__cache == null)
			{
				NotResult_3__cache = MFlags.Get(_0024var_0024NotResult_3);
			}
			return NotResult_3__cache;
		}
	}

	public MFlags NotResult_4
	{
		get
		{
			if (NotResult_4__cache == null)
			{
				NotResult_4__cache = MFlags.Get(_0024var_0024NotResult_4);
			}
			return NotResult_4__cache;
		}
	}

	public MFlags NotResult_5
	{
		get
		{
			if (NotResult_5__cache == null)
			{
				NotResult_5__cache = MFlags.Get(_0024var_0024NotResult_5);
			}
			return NotResult_5__cache;
		}
	}

	public MFlags NotResult_6
	{
		get
		{
			if (NotResult_6__cache == null)
			{
				NotResult_6__cache = MFlags.Get(_0024var_0024NotResult_6);
			}
			return NotResult_6__cache;
		}
	}

	public MFlags NotResult_7
	{
		get
		{
			if (NotResult_7__cache == null)
			{
				NotResult_7__cache = MFlags.Get(_0024var_0024NotResult_7);
			}
			return NotResult_7__cache;
		}
	}

	public MFlags NotResult_8
	{
		get
		{
			if (NotResult_8__cache == null)
			{
				NotResult_8__cache = MFlags.Get(_0024var_0024NotResult_8);
			}
			return NotResult_8__cache;
		}
	}

	public string NextScene => _0024var_0024NextScene;

	public string NextSceneKeepObjects => _0024var_0024NextSceneKeepObjects;

	public string ResultPlayerPosition => _0024var_0024ResultPlayerPosition;

	public string ResultNpcPosition => _0024var_0024ResultNpcPosition;

	public bool TurnAround => _0024var_0024TurnAround;

	public bool BustShot => _0024var_0024BustShot;

	public EnumNpcTalkIcons Icon => _0024var_0024Icon;

	public EnumNpcTalkIcons DistantIcon => _0024var_0024DistantIcon;

	public float Distance => _0024var_0024Distance;

	public float Range => _0024var_0024Range;

	public string Collision => _0024var_0024Collision;

	public int TalkCount => _0024var_0024TalkCount;

	public EnumWindowTypes WindowType => _0024var_0024WindowType;

	public EnumNpcTalkTypes TalkType => _0024var_0024TalkType;

	public bool NoResumeLastBgm => _0024var_0024NoResumeLastBgm;

	public MBgm StartBgm
	{
		get
		{
			if (StartBgm__cache == null)
			{
				StartBgm__cache = MBgm.Get(_0024var_0024StartBgm);
			}
			return StartBgm__cache;
		}
	}

	public MBgm ResultBgm
	{
		get
		{
			if (ResultBgm__cache == null)
			{
				ResultBgm__cache = MBgm.Get(_0024var_0024ResultBgm);
			}
			return ResultBgm__cache;
		}
	}

	public string StartSe => _0024var_0024StartSe;

	public int StartSeDelayMsec => _0024var_0024StartSeDelayMsec;

	public string ResultSe => _0024var_0024ResultSe;

	public int ResultSeDelayMsec => _0024var_0024ResultSeDelayMsec;

	public MCharacterActionTypes ResultAction
	{
		get
		{
			if (ResultAction__cache == null)
			{
				ResultAction__cache = MCharacterActionTypes.Get(_0024var_0024ResultAction);
			}
			return ResultAction__cache;
		}
	}

	public MCharacterActionTypes ResultPlayerAction
	{
		get
		{
			if (ResultPlayerAction__cache == null)
			{
				ResultPlayerAction__cache = MCharacterActionTypes.Get(_0024var_0024ResultPlayerAction);
			}
			return ResultPlayerAction__cache;
		}
	}

	public MPlayerRaces StartRace
	{
		get
		{
			if (StartRace__cache == null)
			{
				StartRace__cache = MPlayerRaces.Get(_0024var_0024StartRace);
			}
			return StartRace__cache;
		}
	}

	public MPlayerRaces ResultRace
	{
		get
		{
			if (ResultRace__cache == null)
			{
				ResultRace__cache = MPlayerRaces.Get(_0024var_0024ResultRace);
			}
			return ResultRace__cache;
		}
	}

	public MWarps Warp
	{
		get
		{
			if (Warp__cache == null)
			{
				Warp__cache = MWarps.Get(_0024var_0024Warp);
			}
			return Warp__cache;
		}
	}

	public static MNpcTalks[] All
	{
		get
		{
			MNpcTalks[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MNpcTalks");
				MNpcTalks[] array = (MNpcTalks[])Builtins.array(typeof(MNpcTalks), _0024mst_002459.Values);
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

	public MNpcTalks()
	{
		_0024var_0024TurnAround = true;
		_0024var_0024StartBgm = -1;
		_0024var_0024ResultBgm = -1;
	}

	public override string ToString()
	{
		return new StringBuilder("MNpcTalks(").Append((object)Id).Append(",").Append(Progname)
			.Append(")")
			.ToString();
	}

	public static MNpcTalks Get(int _id)
	{
		MerlinMaster.GetHandler("MNpcTalks");
		return (!_0024mst_002459.ContainsKey(_id)) ? null : _0024mst_002459[_id];
	}

	public static void Unload()
	{
		_0024mst_002459.Clear();
		All_cache = null;
	}

	public static MNpcTalks New(Hashtable data)
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
			MNpcTalks mNpcTalks = Create(data);
			if (!_0024mst_002459.ContainsKey(mNpcTalks.Id))
			{
				_0024mst_002459[mNpcTalks.Id] = mNpcTalks;
			}
			result = mNpcTalks;
		}
		return (MNpcTalks)result;
	}

	public static MNpcTalks New2(string[] keys, object[] vals)
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
		return (MNpcTalks)result;
	}

	public static MNpcTalks Entry(MNpcTalks mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002459[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MNpcTalks)result;
	}

	public static void AddMst(MNpcTalks mst)
	{
		if (mst != null)
		{
			_0024mst_002459[mst.Id] = mst;
		}
	}

	public static MNpcTalks Create(Hashtable data)
	{
		MNpcTalks mNpcTalks = new MNpcTalks();
		MNpcTalks result;
		if (data == null)
		{
			result = mNpcTalks;
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
				mNpcTalks.setField((string)obj, data[current]);
			}
			result = mNpcTalks;
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
		case "Condition_1":
			_0024var_0024Condition_1 = MasterBaseClass.ToInt(val);
			break;
		case "Condition_2":
			_0024var_0024Condition_2 = MasterBaseClass.ToInt(val);
			break;
		case "Condition_3":
			_0024var_0024Condition_3 = MasterBaseClass.ToInt(val);
			break;
		case "Condition_4":
			_0024var_0024Condition_4 = MasterBaseClass.ToInt(val);
			break;
		case "Condition_5":
			_0024var_0024Condition_5 = MasterBaseClass.ToInt(val);
			break;
		case "Condition_6":
			_0024var_0024Condition_6 = MasterBaseClass.ToInt(val);
			break;
		case "Condition_7":
			_0024var_0024Condition_7 = MasterBaseClass.ToInt(val);
			break;
		case "Condition_8":
			_0024var_0024Condition_8 = MasterBaseClass.ToInt(val);
			break;
		case "NotCondition_1":
			_0024var_0024NotCondition_1 = MasterBaseClass.ToInt(val);
			break;
		case "NotCondition_2":
			_0024var_0024NotCondition_2 = MasterBaseClass.ToInt(val);
			break;
		case "NotCondition_3":
			_0024var_0024NotCondition_3 = MasterBaseClass.ToInt(val);
			break;
		case "NotCondition_4":
			_0024var_0024NotCondition_4 = MasterBaseClass.ToInt(val);
			break;
		case "NotCondition_5":
			_0024var_0024NotCondition_5 = MasterBaseClass.ToInt(val);
			break;
		case "NotCondition_6":
			_0024var_0024NotCondition_6 = MasterBaseClass.ToInt(val);
			break;
		case "NotCondition_7":
			_0024var_0024NotCondition_7 = MasterBaseClass.ToInt(val);
			break;
		case "NotCondition_8":
			_0024var_0024NotCondition_8 = MasterBaseClass.ToInt(val);
			break;
		case "FadeResult":
			_0024var_0024FadeResult = MasterBaseClass.ToInt(val);
			break;
		case "MSceneId":
			_0024var_0024MSceneId = MasterBaseClass.ToStringValue(val);
			break;
		case "TalkGroupId":
			_0024var_0024TalkGroupId = MasterBaseClass.ToStringValue(val);
			break;
		case "Rate":
			_0024var_0024Rate = MasterBaseClass.ToSingle(val);
			break;
		case "MNpcTextId":
			_0024var_0024MNpcTextId = MasterBaseClass.ToInt(val);
			break;
		case "CutScene":
			_0024var_0024CutScene = MasterBaseClass.ToStringValue(val);
			break;
		case "Result_1":
			_0024var_0024Result_1 = MasterBaseClass.ToInt(val);
			break;
		case "Result_2":
			_0024var_0024Result_2 = MasterBaseClass.ToInt(val);
			break;
		case "Result_3":
			_0024var_0024Result_3 = MasterBaseClass.ToInt(val);
			break;
		case "Result_4":
			_0024var_0024Result_4 = MasterBaseClass.ToInt(val);
			break;
		case "Result_5":
			_0024var_0024Result_5 = MasterBaseClass.ToInt(val);
			break;
		case "Result_6":
			_0024var_0024Result_6 = MasterBaseClass.ToInt(val);
			break;
		case "Result_7":
			_0024var_0024Result_7 = MasterBaseClass.ToInt(val);
			break;
		case "Result_8":
			_0024var_0024Result_8 = MasterBaseClass.ToInt(val);
			break;
		case "NotResult_1":
			_0024var_0024NotResult_1 = MasterBaseClass.ToInt(val);
			break;
		case "NotResult_2":
			_0024var_0024NotResult_2 = MasterBaseClass.ToInt(val);
			break;
		case "NotResult_3":
			_0024var_0024NotResult_3 = MasterBaseClass.ToInt(val);
			break;
		case "NotResult_4":
			_0024var_0024NotResult_4 = MasterBaseClass.ToInt(val);
			break;
		case "NotResult_5":
			_0024var_0024NotResult_5 = MasterBaseClass.ToInt(val);
			break;
		case "NotResult_6":
			_0024var_0024NotResult_6 = MasterBaseClass.ToInt(val);
			break;
		case "NotResult_7":
			_0024var_0024NotResult_7 = MasterBaseClass.ToInt(val);
			break;
		case "NotResult_8":
			_0024var_0024NotResult_8 = MasterBaseClass.ToInt(val);
			break;
		case "NextScene":
			_0024var_0024NextScene = MasterBaseClass.ToStringValue(val);
			break;
		case "NextSceneKeepObjects":
			_0024var_0024NextSceneKeepObjects = MasterBaseClass.ToStringValue(val);
			break;
		case "ResultPlayerPosition":
			_0024var_0024ResultPlayerPosition = MasterBaseClass.ToStringValue(val);
			break;
		case "ResultNpcPosition":
			_0024var_0024ResultNpcPosition = MasterBaseClass.ToStringValue(val);
			break;
		case "TurnAround":
			_0024var_0024TurnAround = MasterBaseClass.ToBool(val);
			break;
		case "BustShot":
			_0024var_0024BustShot = MasterBaseClass.ToBool(val);
			break;
		case "Icon":
			if (typeof(EnumNpcTalkIcons).IsEnum)
			{
				_0024var_0024Icon = (EnumNpcTalkIcons)MasterBaseClass.ToEnum(val);
			}
			break;
		case "DistantIcon":
			if (typeof(EnumNpcTalkIcons).IsEnum)
			{
				_0024var_0024DistantIcon = (EnumNpcTalkIcons)MasterBaseClass.ToEnum(val);
			}
			break;
		case "Distance":
			_0024var_0024Distance = MasterBaseClass.ToSingle(val);
			break;
		case "Range":
			_0024var_0024Range = MasterBaseClass.ToSingle(val);
			break;
		case "Collision":
			_0024var_0024Collision = MasterBaseClass.ToStringValue(val);
			break;
		case "TalkCount":
			_0024var_0024TalkCount = MasterBaseClass.ToInt(val);
			break;
		case "WindowType":
			if (typeof(EnumWindowTypes).IsEnum)
			{
				_0024var_0024WindowType = (EnumWindowTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "TalkType":
			if (typeof(EnumNpcTalkTypes).IsEnum)
			{
				_0024var_0024TalkType = (EnumNpcTalkTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "NoResumeLastBgm":
			_0024var_0024NoResumeLastBgm = MasterBaseClass.ToBool(val);
			break;
		case "StartBgm":
			_0024var_0024StartBgm = MasterBaseClass.ToInt(val);
			break;
		case "ResultBgm":
			_0024var_0024ResultBgm = MasterBaseClass.ToInt(val);
			break;
		case "StartSe":
			_0024var_0024StartSe = MasterBaseClass.ToStringValue(val);
			break;
		case "StartSeDelayMsec":
			_0024var_0024StartSeDelayMsec = MasterBaseClass.ToInt(val);
			break;
		case "ResultSe":
			_0024var_0024ResultSe = MasterBaseClass.ToStringValue(val);
			break;
		case "ResultSeDelayMsec":
			_0024var_0024ResultSeDelayMsec = MasterBaseClass.ToInt(val);
			break;
		case "ResultAction":
			_0024var_0024ResultAction = MasterBaseClass.ToInt(val);
			break;
		case "ResultPlayerAction":
			_0024var_0024ResultPlayerAction = MasterBaseClass.ToInt(val);
			break;
		case "StartRace":
			_0024var_0024StartRace = MasterBaseClass.ToInt(val);
			break;
		case "ResultRace":
			_0024var_0024ResultRace = MasterBaseClass.ToInt(val);
			break;
		case "Warp":
			_0024var_0024Warp = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Progname" => true, 
			"Condition_1" => true, 
			"Condition_2" => true, 
			"Condition_3" => true, 
			"Condition_4" => true, 
			"Condition_5" => true, 
			"Condition_6" => true, 
			"Condition_7" => true, 
			"Condition_8" => true, 
			"NotCondition_1" => true, 
			"NotCondition_2" => true, 
			"NotCondition_3" => true, 
			"NotCondition_4" => true, 
			"NotCondition_5" => true, 
			"NotCondition_6" => true, 
			"NotCondition_7" => true, 
			"NotCondition_8" => true, 
			"FadeResult" => true, 
			"MSceneId" => true, 
			"TalkGroupId" => true, 
			"Rate" => true, 
			"MNpcTextId" => true, 
			"CutScene" => true, 
			"Result_1" => true, 
			"Result_2" => true, 
			"Result_3" => true, 
			"Result_4" => true, 
			"Result_5" => true, 
			"Result_6" => true, 
			"Result_7" => true, 
			"Result_8" => true, 
			"NotResult_1" => true, 
			"NotResult_2" => true, 
			"NotResult_3" => true, 
			"NotResult_4" => true, 
			"NotResult_5" => true, 
			"NotResult_6" => true, 
			"NotResult_7" => true, 
			"NotResult_8" => true, 
			"NextScene" => true, 
			"NextSceneKeepObjects" => true, 
			"ResultPlayerPosition" => true, 
			"ResultNpcPosition" => true, 
			"TurnAround" => true, 
			"BustShot" => true, 
			"Icon" => true, 
			"DistantIcon" => true, 
			"Distance" => true, 
			"Range" => true, 
			"Collision" => true, 
			"TalkCount" => true, 
			"WindowType" => true, 
			"TalkType" => true, 
			"NoResumeLastBgm" => true, 
			"StartBgm" => true, 
			"ResultBgm" => true, 
			"StartSe" => true, 
			"StartSeDelayMsec" => true, 
			"ResultSe" => true, 
			"ResultSeDelayMsec" => true, 
			"ResultAction" => true, 
			"ResultPlayerAction" => true, 
			"StartRace" => true, 
			"ResultRace" => true, 
			"Warp" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[66]
		{
			"Id", "Progname", "Condition_1", "Condition_2", "Condition_3", "Condition_4", "Condition_5", "Condition_6", "Condition_7", "Condition_8",
			"NotCondition_1", "NotCondition_2", "NotCondition_3", "NotCondition_4", "NotCondition_5", "NotCondition_6", "NotCondition_7", "NotCondition_8", "FadeResult", "MSceneId",
			"TalkGroupId", "Rate", "MNpcTextId", "CutScene", "Result_1", "Result_2", "Result_3", "Result_4", "Result_5", "Result_6",
			"Result_7", "Result_8", "NotResult_1", "NotResult_2", "NotResult_3", "NotResult_4", "NotResult_5", "NotResult_6", "NotResult_7", "NotResult_8",
			"NextScene", "NextSceneKeepObjects", "ResultPlayerPosition", "ResultNpcPosition", "TurnAround", "BustShot", "Icon", "DistantIcon", "Distance", "Range",
			"Collision", "TalkCount", "WindowType", "TalkType", "NoResumeLastBgm", "StartBgm", "ResultBgm", "StartSe", "StartSeDelayMsec", "ResultSe",
			"ResultSeDelayMsec", "ResultAction", "ResultPlayerAction", "StartRace", "ResultRace", "Warp"
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
						_0024var_0024Condition_1 = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Condition_2 = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024Condition_3 = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Condition_4 = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024Condition_5 = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024Condition_6 = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024Condition_7 = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024Condition_8 = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024NotCondition_1 = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024NotCondition_2 = MasterBaseClass.ParseInt(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024NotCondition_3 = MasterBaseClass.ParseInt(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024NotCondition_4 = MasterBaseClass.ParseInt(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024NotCondition_5 = MasterBaseClass.ParseInt(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null)
																		{
																			_0024var_0024NotCondition_6 = MasterBaseClass.ParseInt(vals[15]);
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null)
																			{
																				_0024var_0024NotCondition_7 = MasterBaseClass.ParseInt(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null)
																				{
																					_0024var_0024NotCondition_8 = MasterBaseClass.ParseInt(vals[17]);
																				}
																				if (length <= 18)
																				{
																					result = 18;
																				}
																				else
																				{
																					if (vals[18] != null)
																					{
																						_0024var_0024FadeResult = MasterBaseClass.ParseInt(vals[18]);
																					}
																					if (length <= 19)
																					{
																						result = 19;
																					}
																					else
																					{
																						if (vals[19] != null)
																						{
																							_0024var_0024MSceneId = vals[19];
																						}
																						if (length <= 20)
																						{
																							result = 20;
																						}
																						else
																						{
																							if (vals[20] != null)
																							{
																								_0024var_0024TalkGroupId = vals[20];
																							}
																							if (length <= 21)
																							{
																								result = 21;
																							}
																							else
																							{
																								if (vals[21] != null)
																								{
																									_0024var_0024Rate = MasterBaseClass.ParseSingle(vals[21]);
																								}
																								if (length <= 22)
																								{
																									result = 22;
																								}
																								else
																								{
																									if (vals[22] != null)
																									{
																										_0024var_0024MNpcTextId = MasterBaseClass.ParseInt(vals[22]);
																									}
																									if (length <= 23)
																									{
																										result = 23;
																									}
																									else
																									{
																										if (vals[23] != null)
																										{
																											_0024var_0024CutScene = vals[23];
																										}
																										if (length <= 24)
																										{
																											result = 24;
																										}
																										else
																										{
																											if (vals[24] != null)
																											{
																												_0024var_0024Result_1 = MasterBaseClass.ParseInt(vals[24]);
																											}
																											if (length <= 25)
																											{
																												result = 25;
																											}
																											else
																											{
																												if (vals[25] != null)
																												{
																													_0024var_0024Result_2 = MasterBaseClass.ParseInt(vals[25]);
																												}
																												if (length <= 26)
																												{
																													result = 26;
																												}
																												else
																												{
																													if (vals[26] != null)
																													{
																														_0024var_0024Result_3 = MasterBaseClass.ParseInt(vals[26]);
																													}
																													if (length <= 27)
																													{
																														result = 27;
																													}
																													else
																													{
																														if (vals[27] != null)
																														{
																															_0024var_0024Result_4 = MasterBaseClass.ParseInt(vals[27]);
																														}
																														if (length <= 28)
																														{
																															result = 28;
																														}
																														else
																														{
																															if (vals[28] != null)
																															{
																																_0024var_0024Result_5 = MasterBaseClass.ParseInt(vals[28]);
																															}
																															if (length <= 29)
																															{
																																result = 29;
																															}
																															else
																															{
																																if (vals[29] != null)
																																{
																																	_0024var_0024Result_6 = MasterBaseClass.ParseInt(vals[29]);
																																}
																																if (length <= 30)
																																{
																																	result = 30;
																																}
																																else
																																{
																																	if (vals[30] != null)
																																	{
																																		_0024var_0024Result_7 = MasterBaseClass.ParseInt(vals[30]);
																																	}
																																	if (length <= 31)
																																	{
																																		result = 31;
																																	}
																																	else
																																	{
																																		if (vals[31] != null)
																																		{
																																			_0024var_0024Result_8 = MasterBaseClass.ParseInt(vals[31]);
																																		}
																																		if (length <= 32)
																																		{
																																			result = 32;
																																		}
																																		else
																																		{
																																			if (vals[32] != null)
																																			{
																																				_0024var_0024NotResult_1 = MasterBaseClass.ParseInt(vals[32]);
																																			}
																																			if (length <= 33)
																																			{
																																				result = 33;
																																			}
																																			else
																																			{
																																				if (vals[33] != null)
																																				{
																																					_0024var_0024NotResult_2 = MasterBaseClass.ParseInt(vals[33]);
																																				}
																																				if (length <= 34)
																																				{
																																					result = 34;
																																				}
																																				else
																																				{
																																					if (vals[34] != null)
																																					{
																																						_0024var_0024NotResult_3 = MasterBaseClass.ParseInt(vals[34]);
																																					}
																																					if (length <= 35)
																																					{
																																						result = 35;
																																					}
																																					else
																																					{
																																						if (vals[35] != null)
																																						{
																																							_0024var_0024NotResult_4 = MasterBaseClass.ParseInt(vals[35]);
																																						}
																																						if (length <= 36)
																																						{
																																							result = 36;
																																						}
																																						else
																																						{
																																							if (vals[36] != null)
																																							{
																																								_0024var_0024NotResult_5 = MasterBaseClass.ParseInt(vals[36]);
																																							}
																																							if (length <= 37)
																																							{
																																								result = 37;
																																							}
																																							else
																																							{
																																								if (vals[37] != null)
																																								{
																																									_0024var_0024NotResult_6 = MasterBaseClass.ParseInt(vals[37]);
																																								}
																																								if (length <= 38)
																																								{
																																									result = 38;
																																								}
																																								else
																																								{
																																									if (vals[38] != null)
																																									{
																																										_0024var_0024NotResult_7 = MasterBaseClass.ParseInt(vals[38]);
																																									}
																																									if (length <= 39)
																																									{
																																										result = 39;
																																									}
																																									else
																																									{
																																										if (vals[39] != null)
																																										{
																																											_0024var_0024NotResult_8 = MasterBaseClass.ParseInt(vals[39]);
																																										}
																																										if (length <= 40)
																																										{
																																											result = 40;
																																										}
																																										else
																																										{
																																											if (vals[40] != null)
																																											{
																																												_0024var_0024NextScene = vals[40];
																																											}
																																											if (length <= 41)
																																											{
																																												result = 41;
																																											}
																																											else
																																											{
																																												if (vals[41] != null)
																																												{
																																													_0024var_0024NextSceneKeepObjects = vals[41];
																																												}
																																												if (length <= 42)
																																												{
																																													result = 42;
																																												}
																																												else
																																												{
																																													if (vals[42] != null)
																																													{
																																														_0024var_0024ResultPlayerPosition = vals[42];
																																													}
																																													if (length <= 43)
																																													{
																																														result = 43;
																																													}
																																													else
																																													{
																																														if (vals[43] != null)
																																														{
																																															_0024var_0024ResultNpcPosition = vals[43];
																																														}
																																														if (length <= 44)
																																														{
																																															result = 44;
																																														}
																																														else
																																														{
																																															if (vals[44] != null)
																																															{
																																																_0024var_0024TurnAround = MasterBaseClass.ParseBool(vals[44]);
																																															}
																																															if (length <= 45)
																																															{
																																																result = 45;
																																															}
																																															else
																																															{
																																																if (vals[45] != null)
																																																{
																																																	_0024var_0024BustShot = MasterBaseClass.ParseBool(vals[45]);
																																																}
																																																if (length <= 46)
																																																{
																																																	result = 46;
																																																}
																																																else
																																																{
																																																	if (vals[46] != null && typeof(EnumNpcTalkIcons).IsEnum)
																																																	{
																																																		_0024var_0024Icon = (EnumNpcTalkIcons)MasterBaseClass.ParseEnum(vals[46]);
																																																	}
																																																	if (length <= 47)
																																																	{
																																																		result = 47;
																																																	}
																																																	else
																																																	{
																																																		if (vals[47] != null && typeof(EnumNpcTalkIcons).IsEnum)
																																																		{
																																																			_0024var_0024DistantIcon = (EnumNpcTalkIcons)MasterBaseClass.ParseEnum(vals[47]);
																																																		}
																																																		if (length <= 48)
																																																		{
																																																			result = 48;
																																																		}
																																																		else
																																																		{
																																																			if (vals[48] != null)
																																																			{
																																																				_0024var_0024Distance = MasterBaseClass.ParseSingle(vals[48]);
																																																			}
																																																			if (length <= 49)
																																																			{
																																																				result = 49;
																																																			}
																																																			else
																																																			{
																																																				if (vals[49] != null)
																																																				{
																																																					_0024var_0024Range = MasterBaseClass.ParseSingle(vals[49]);
																																																				}
																																																				if (length <= 50)
																																																				{
																																																					result = 50;
																																																				}
																																																				else
																																																				{
																																																					if (vals[50] != null)
																																																					{
																																																						_0024var_0024Collision = vals[50];
																																																					}
																																																					if (length <= 51)
																																																					{
																																																						result = 51;
																																																					}
																																																					else
																																																					{
																																																						if (vals[51] != null)
																																																						{
																																																							_0024var_0024TalkCount = MasterBaseClass.ParseInt(vals[51]);
																																																						}
																																																						if (length <= 52)
																																																						{
																																																							result = 52;
																																																						}
																																																						else
																																																						{
																																																							if (vals[52] != null && typeof(EnumWindowTypes).IsEnum)
																																																							{
																																																								_0024var_0024WindowType = (EnumWindowTypes)MasterBaseClass.ParseEnum(vals[52]);
																																																							}
																																																							if (length <= 53)
																																																							{
																																																								result = 53;
																																																							}
																																																							else
																																																							{
																																																								if (vals[53] != null && typeof(EnumNpcTalkTypes).IsEnum)
																																																								{
																																																									_0024var_0024TalkType = (EnumNpcTalkTypes)MasterBaseClass.ParseEnum(vals[53]);
																																																								}
																																																								if (length <= 54)
																																																								{
																																																									result = 54;
																																																								}
																																																								else
																																																								{
																																																									if (vals[54] != null)
																																																									{
																																																										_0024var_0024NoResumeLastBgm = MasterBaseClass.ParseBool(vals[54]);
																																																									}
																																																									if (length <= 55)
																																																									{
																																																										result = 55;
																																																									}
																																																									else
																																																									{
																																																										if (vals[55] != null)
																																																										{
																																																											_0024var_0024StartBgm = MasterBaseClass.ParseInt(vals[55]);
																																																										}
																																																										if (length <= 56)
																																																										{
																																																											result = 56;
																																																										}
																																																										else
																																																										{
																																																											if (vals[56] != null)
																																																											{
																																																												_0024var_0024ResultBgm = MasterBaseClass.ParseInt(vals[56]);
																																																											}
																																																											if (length <= 57)
																																																											{
																																																												result = 57;
																																																											}
																																																											else
																																																											{
																																																												if (vals[57] != null)
																																																												{
																																																													_0024var_0024StartSe = vals[57];
																																																												}
																																																												if (length <= 58)
																																																												{
																																																													result = 58;
																																																												}
																																																												else
																																																												{
																																																													if (vals[58] != null)
																																																													{
																																																														_0024var_0024StartSeDelayMsec = MasterBaseClass.ParseInt(vals[58]);
																																																													}
																																																													if (length <= 59)
																																																													{
																																																														result = 59;
																																																													}
																																																													else
																																																													{
																																																														if (vals[59] != null)
																																																														{
																																																															_0024var_0024ResultSe = vals[59];
																																																														}
																																																														if (length <= 60)
																																																														{
																																																															result = 60;
																																																														}
																																																														else
																																																														{
																																																															if (vals[60] != null)
																																																															{
																																																																_0024var_0024ResultSeDelayMsec = MasterBaseClass.ParseInt(vals[60]);
																																																															}
																																																															if (length <= 61)
																																																															{
																																																																result = 61;
																																																															}
																																																															else
																																																															{
																																																																if (vals[61] != null)
																																																																{
																																																																	_0024var_0024ResultAction = MasterBaseClass.ParseInt(vals[61]);
																																																																}
																																																																if (length <= 62)
																																																																{
																																																																	result = 62;
																																																																}
																																																																else
																																																																{
																																																																	if (vals[62] != null)
																																																																	{
																																																																		_0024var_0024ResultPlayerAction = MasterBaseClass.ParseInt(vals[62]);
																																																																	}
																																																																	if (length <= 63)
																																																																	{
																																																																		result = 63;
																																																																	}
																																																																	else
																																																																	{
																																																																		if (vals[63] != null)
																																																																		{
																																																																			_0024var_0024StartRace = MasterBaseClass.ParseInt(vals[63]);
																																																																		}
																																																																		if (length <= 64)
																																																																		{
																																																																			result = 64;
																																																																		}
																																																																		else
																																																																		{
																																																																			if (vals[64] != null)
																																																																			{
																																																																				_0024var_0024ResultRace = MasterBaseClass.ParseInt(vals[64]);
																																																																			}
																																																																			if (length <= 65)
																																																																			{
																																																																				result = 65;
																																																																			}
																																																																			else
																																																																			{
																																																																				if (vals[65] != null)
																																																																				{
																																																																					_0024var_0024Warp = MasterBaseClass.ParseInt(vals[65]);
																																																																				}
																																																																				int num = 66;
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
			}
		}
		return result;
	}
}
