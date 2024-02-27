using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MQuests : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	public string _0024var_0024Origname;

	public string _0024var_0024Name;

	public EnumQuestTypes _0024var_0024QuestType;

	public bool _0024var_0024IsChallenge;

	public bool _0024var_0024StoryFlag;

	public bool _0024var_0024HideFlag;

	public string _0024var_0024DisplayName;

	public string _0024var_0024Explain;

	public string _0024var_0024DisplayName_En;

	public string _0024var_0024Explain_En;

	public int _0024var_0024TempFlag;

	public int _0024var_0024ApCost;

	public int _0024var_0024RpCost;

	public int _0024var_0024Difficulty;

	public int _0024var_0024StartSceneId;

	public string _0024var_0024StartPosition;

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

	public int _0024var_0024MAreaId;

	public int _0024var_0024MStageId;

	public int _0024var_0024Clear_1;

	public int _0024var_0024Clear_2;

	public int _0024var_0024Clear_3;

	public int _0024var_0024LimitTime;

	public int _0024var_0024CandyDropNum;

	public int _0024var_0024NutDropNum;

	public int _0024var_0024MItemGroupId;

	public int _0024var_0024MTutorialItemId;

	public int _0024var_0024ParameterCorrectId;

	public DateTime _0024var_0024BeginDate;

	public DateTime _0024var_0024EndDate;

	public string _0024var_0024ClearCutScene;

	public int _0024var_0024MSceneWhenClear;

	public string _0024var_0024MScenePlayerPosition;

	public string _0024var_0024StartCutScene;

	public int _0024var_0024SceneOfStartCutScene;

	public int _0024var_0024StartCutScenePlayCond;

	public int _0024var_0024StartCutScenePlayNotCond;

	public int _0024var_0024StageCandyNum;

	public int _0024var_0024NutRateOfMonsterCandy;

	public bool _0024var_0024NoPoppets;

	public int _0024var_0024Rank;

	public bool _0024var_0024ForbidContinuation;

	public bool _0024var_0024FailIfDead;

	public bool _0024var_0024NeedTicket;

	public float _0024var_0024AttackAdjMult;

	public float _0024var_0024AttackAdjPlus;

	public float _0024var_0024HpAdjMult;

	public float _0024var_0024HpAdjPlus;

	public float _0024var_0024DefenseAdjMult;

	public float _0024var_0024DefenseAdjPlus;

	public bool _0024var_0024AutoRunOn;

	public int _0024var_0024AliveMonsterLimit;

	public int _0024var_0024BgmId;

	public bool _0024var_0024Deprecated;

	public int _0024var_0024SortPriority;

	public string _0024var_0024CenterpieceItemGroupChildIdList;

	public int _0024var_0024HighestDropWithoutCount;

	[NonSerialized]
	private MFlags TempFlag__cache;

	[NonSerialized]
	private MScenes StartSceneId__cache;

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
	private MAreas MAreaId__cache;

	[NonSerialized]
	private MStages MStageId__cache;

	[NonSerialized]
	private MQuestClears Clear_1__cache;

	[NonSerialized]
	private MQuestClears Clear_2__cache;

	[NonSerialized]
	private MQuestClears Clear_3__cache;

	[NonSerialized]
	private MItemGroups MItemGroupId__cache;

	[NonSerialized]
	private MTutorialItems MTutorialItemId__cache;

	[NonSerialized]
	private MParameterCorrects ParameterCorrectId__cache;

	[NonSerialized]
	private MScenes MSceneWhenClear__cache;

	[NonSerialized]
	private MScenes SceneOfStartCutScene__cache;

	[NonSerialized]
	private MFlags StartCutScenePlayCond__cache;

	[NonSerialized]
	private MFlags StartCutScenePlayNotCond__cache;

	[NonSerialized]
	private MBgm BgmId__cache;

	[NonSerialized]
	private static Dictionary<int, MQuests> _0024mst_002474 = new Dictionary<int, MQuests>();

	[NonSerialized]
	private static MQuests[] All_cache;

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

	public MQuestClears[] ClearConditions
	{
		get
		{
			System.Collections.Generic.List<MQuestClears> list = new System.Collections.Generic.List<MQuestClears>();
			if (Clear_1 != null)
			{
				list.Add(Clear_1);
			}
			if (Clear_2 != null)
			{
				list.Add(Clear_2);
			}
			if (Clear_3 != null)
			{
				list.Add(Clear_3);
			}
			return list.ToArray();
		}
	}

	public bool HasStartCutScene => !string.IsNullOrEmpty(StartCutScene);

	public bool HasSceneOfStartCutScene
	{
		get
		{
			bool num = HasStartCutScene;
			if (num)
			{
				num = SceneOfStartCutScene != null;
			}
			return num;
		}
	}

	public bool HasStartCutSceneCondition
	{
		get
		{
			bool num = StartCutScenePlayCond != null;
			if (!num)
			{
				num = StartCutScenePlayNotCond != null;
			}
			return num;
		}
	}

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

	public string Origname => _0024var_0024Origname;

	public string Name => _0024var_0024Name;

	public EnumQuestTypes QuestType => _0024var_0024QuestType;

	public bool IsChallenge => _0024var_0024IsChallenge;

	public bool StoryFlag => _0024var_0024StoryFlag;

	public bool HideFlag => _0024var_0024HideFlag;

	public string DisplayName => _0024var_0024DisplayName;

	public string Explain => _0024var_0024Explain;

	public string DisplayName_En => _0024var_0024DisplayName_En;

	public string Explain_En => _0024var_0024Explain_En;

	public MFlags TempFlag
	{
		get
		{
			if (TempFlag__cache == null)
			{
				TempFlag__cache = MFlags.Get(_0024var_0024TempFlag);
			}
			return TempFlag__cache;
		}
	}

	public int ApCost => _0024var_0024ApCost;

	public int RpCost => _0024var_0024RpCost;

	public int Difficulty => _0024var_0024Difficulty;

	public MScenes StartSceneId
	{
		get
		{
			if (StartSceneId__cache == null)
			{
				StartSceneId__cache = MScenes.Get(_0024var_0024StartSceneId);
			}
			return StartSceneId__cache;
		}
	}

	public string StartPosition => _0024var_0024StartPosition;

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

	public MAreas MAreaId
	{
		get
		{
			if (MAreaId__cache == null)
			{
				MAreaId__cache = MAreas.Get(_0024var_0024MAreaId);
			}
			return MAreaId__cache;
		}
	}

	public MStages MStageId
	{
		get
		{
			if (MStageId__cache == null)
			{
				MStageId__cache = MStages.Get(_0024var_0024MStageId);
			}
			return MStageId__cache;
		}
	}

	public MQuestClears Clear_1
	{
		get
		{
			if (Clear_1__cache == null)
			{
				Clear_1__cache = MQuestClears.Get(_0024var_0024Clear_1);
			}
			return Clear_1__cache;
		}
	}

	public MQuestClears Clear_2
	{
		get
		{
			if (Clear_2__cache == null)
			{
				Clear_2__cache = MQuestClears.Get(_0024var_0024Clear_2);
			}
			return Clear_2__cache;
		}
	}

	public MQuestClears Clear_3
	{
		get
		{
			if (Clear_3__cache == null)
			{
				Clear_3__cache = MQuestClears.Get(_0024var_0024Clear_3);
			}
			return Clear_3__cache;
		}
	}

	public int LimitTime => _0024var_0024LimitTime;

	public int CandyDropNum => _0024var_0024CandyDropNum;

	public int NutDropNum => _0024var_0024NutDropNum;

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

	public MTutorialItems MTutorialItemId
	{
		get
		{
			if (MTutorialItemId__cache == null)
			{
				MTutorialItemId__cache = MTutorialItems.Get(_0024var_0024MTutorialItemId);
			}
			return MTutorialItemId__cache;
		}
	}

	public MParameterCorrects ParameterCorrectId
	{
		get
		{
			if (ParameterCorrectId__cache == null)
			{
				ParameterCorrectId__cache = MParameterCorrects.Get(_0024var_0024ParameterCorrectId);
			}
			return ParameterCorrectId__cache;
		}
	}

	public DateTime BeginDate => _0024var_0024BeginDate;

	public DateTime EndDate => _0024var_0024EndDate;

	public string ClearCutScene => _0024var_0024ClearCutScene;

	public MScenes MSceneWhenClear
	{
		get
		{
			if (MSceneWhenClear__cache == null)
			{
				MSceneWhenClear__cache = MScenes.Get(_0024var_0024MSceneWhenClear);
			}
			return MSceneWhenClear__cache;
		}
	}

	public string MScenePlayerPosition => _0024var_0024MScenePlayerPosition;

	public string StartCutScene => _0024var_0024StartCutScene;

	public MScenes SceneOfStartCutScene
	{
		get
		{
			if (SceneOfStartCutScene__cache == null)
			{
				SceneOfStartCutScene__cache = MScenes.Get(_0024var_0024SceneOfStartCutScene);
			}
			return SceneOfStartCutScene__cache;
		}
	}

	public MFlags StartCutScenePlayCond
	{
		get
		{
			if (StartCutScenePlayCond__cache == null)
			{
				StartCutScenePlayCond__cache = MFlags.Get(_0024var_0024StartCutScenePlayCond);
			}
			return StartCutScenePlayCond__cache;
		}
	}

	public MFlags StartCutScenePlayNotCond
	{
		get
		{
			if (StartCutScenePlayNotCond__cache == null)
			{
				StartCutScenePlayNotCond__cache = MFlags.Get(_0024var_0024StartCutScenePlayNotCond);
			}
			return StartCutScenePlayNotCond__cache;
		}
	}

	public int StageCandyNum => _0024var_0024StageCandyNum;

	public int NutRateOfMonsterCandy => _0024var_0024NutRateOfMonsterCandy;

	public bool NoPoppets => _0024var_0024NoPoppets;

	public int Rank => _0024var_0024Rank;

	public bool ForbidContinuation => _0024var_0024ForbidContinuation;

	public bool FailIfDead => _0024var_0024FailIfDead;

	public bool NeedTicket => _0024var_0024NeedTicket;

	public float AttackAdjMult => _0024var_0024AttackAdjMult;

	public float AttackAdjPlus => _0024var_0024AttackAdjPlus;

	public float HpAdjMult => _0024var_0024HpAdjMult;

	public float HpAdjPlus => _0024var_0024HpAdjPlus;

	public float DefenseAdjMult => _0024var_0024DefenseAdjMult;

	public float DefenseAdjPlus => _0024var_0024DefenseAdjPlus;

	public bool AutoRunOn => _0024var_0024AutoRunOn;

	public int AliveMonsterLimit => _0024var_0024AliveMonsterLimit;

	public MBgm BgmId
	{
		get
		{
			if (BgmId__cache == null)
			{
				BgmId__cache = MBgm.Get(_0024var_0024BgmId);
			}
			return BgmId__cache;
		}
	}

	public bool Deprecated => _0024var_0024Deprecated;

	public int SortPriority => _0024var_0024SortPriority;

	public string CenterpieceItemGroupChildIdList => _0024var_0024CenterpieceItemGroupChildIdList;

	public int HighestDropWithoutCount => _0024var_0024HighestDropWithoutCount;

	public static MQuests[] All
	{
		get
		{
			MQuests[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MQuests");
				MQuests[] array = (MQuests[])Builtins.array(typeof(MQuests), _0024mst_002474.Values);
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

	public MQuests()
	{
		_0024var_0024StartPosition = string.Empty;
		_0024var_0024BeginDate = DateTime.Parse("2010/01/01");
		_0024var_0024EndDate = DateTime.Parse("2099/01/01");
		_0024var_0024MScenePlayerPosition = string.Empty;
		_0024var_0024Rank = 1;
		_0024var_0024AttackAdjMult = 1f;
		_0024var_0024HpAdjMult = 1f;
		_0024var_0024DefenseAdjMult = 1f;
		_0024var_0024BgmId = -1;
		_0024var_0024CenterpieceItemGroupChildIdList = string.Empty;
	}

	public string GetName()
	{
		return (MerlinLanguageSetting.GetCurrentLanguage() != 0) ? DisplayName_En : DisplayName;
	}

	public string GetExplain()
	{
		return (MerlinLanguageSetting.GetCurrentLanguage() != 0) ? Explain_En : Explain;
	}

	public override string ToString()
	{
		return (!Deprecated) ? new StringBuilder("MQuests(").Append((object)Id).Append(",").Append(Progname)
			.Append(",")
			.Append(DisplayName)
			.Append(", ")
			.Append(BeginDate)
			.Append(" ~ ")
			.Append(EndDate)
			.Append(")")
			.ToString() : new StringBuilder("MQuests(").Append((object)Id).Append(",").Append(Progname)
			.Append(",")
			.Append(DisplayName)
			.Append(", 廃止)")
			.ToString();
	}

	public override string ToDebugModeString()
	{
		return (!Deprecated) ? new StringBuilder().Append(Progname).Append(" / ").Append(DisplayName)
			.ToString() : new StringBuilder().Append(Progname).Append(" / ").Append(DisplayName)
			.Append(" / 廃止")
			.ToString();
	}

	public static MQuests FindByProgname(string progname)
	{
		MQuests result = null;
		int i = 0;
		MQuests[] all = All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (all[i].Progname == progname)
			{
				result = all[i];
				break;
			}
		}
		return result;
	}

	public bool isDeprecatedAndExpired(DateTime utcNow)
	{
		bool num = Deprecated;
		if (num)
		{
			num = EndDate < utcNow;
		}
		return num;
	}

	public static MStories FindStory(MQuests q)
	{
		object result;
		if (q == null)
		{
			result = null;
		}
		else
		{
			int num = 0;
			MStories[] all = MStories.All;
			int length = all.Length;
			while (true)
			{
				if (num < length)
				{
					if (RuntimeServices.EqualityOperator(all[num].MQuestId, q))
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
		}
		return (MStories)result;
	}

	public static MQuests Get(int _id)
	{
		MerlinMaster.GetHandler("MQuests");
		return (!_0024mst_002474.ContainsKey(_id)) ? null : _0024mst_002474[_id];
	}

	public static void Unload()
	{
		_0024mst_002474.Clear();
		All_cache = null;
	}

	public static MQuests New(Hashtable data)
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
			MQuests mQuests = Create(data);
			if (!_0024mst_002474.ContainsKey(mQuests.Id))
			{
				_0024mst_002474[mQuests.Id] = mQuests;
			}
			result = mQuests;
		}
		return (MQuests)result;
	}

	public static MQuests New2(string[] keys, object[] vals)
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
		return (MQuests)result;
	}

	public static MQuests Entry(MQuests mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002474[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MQuests)result;
	}

	public static void AddMst(MQuests mst)
	{
		if (mst != null)
		{
			_0024mst_002474[mst.Id] = mst;
		}
	}

	public static MQuests Create(Hashtable data)
	{
		MQuests mQuests = new MQuests();
		MQuests result;
		if (data == null)
		{
			result = mQuests;
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
				mQuests.setField((string)obj, data[current]);
			}
			result = mQuests;
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
		case "Origname":
			_0024var_0024Origname = MasterBaseClass.ToStringValue(val);
			break;
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		case "QuestType":
			if (typeof(EnumQuestTypes).IsEnum)
			{
				_0024var_0024QuestType = (EnumQuestTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "IsChallenge":
			_0024var_0024IsChallenge = MasterBaseClass.ToBool(val);
			break;
		case "StoryFlag":
			_0024var_0024StoryFlag = MasterBaseClass.ToBool(val);
			break;
		case "HideFlag":
			_0024var_0024HideFlag = MasterBaseClass.ToBool(val);
			break;
		case "DisplayName":
			_0024var_0024DisplayName = MasterBaseClass.ToStringValue(val);
			break;
		case "Explain":
			_0024var_0024Explain = MasterBaseClass.ToStringValue(val);
			break;
		case "DisplayName_En":
			_0024var_0024DisplayName_En = MasterBaseClass.ToStringValue(val);
			break;
		case "Explain_En":
			_0024var_0024Explain_En = MasterBaseClass.ToStringValue(val);
			break;
		case "TempFlag":
			_0024var_0024TempFlag = MasterBaseClass.ToInt(val);
			break;
		case "ApCost":
			_0024var_0024ApCost = MasterBaseClass.ToInt(val);
			break;
		case "RpCost":
			_0024var_0024RpCost = MasterBaseClass.ToInt(val);
			break;
		case "Difficulty":
			_0024var_0024Difficulty = MasterBaseClass.ToInt(val);
			break;
		case "StartSceneId":
			_0024var_0024StartSceneId = MasterBaseClass.ToInt(val);
			break;
		case "StartPosition":
			_0024var_0024StartPosition = MasterBaseClass.ToStringValue(val);
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
		case "MAreaId":
			_0024var_0024MAreaId = MasterBaseClass.ToInt(val);
			break;
		case "MStageId":
			_0024var_0024MStageId = MasterBaseClass.ToInt(val);
			break;
		case "Clear_1":
			_0024var_0024Clear_1 = MasterBaseClass.ToInt(val);
			break;
		case "Clear_2":
			_0024var_0024Clear_2 = MasterBaseClass.ToInt(val);
			break;
		case "Clear_3":
			_0024var_0024Clear_3 = MasterBaseClass.ToInt(val);
			break;
		case "LimitTime":
			_0024var_0024LimitTime = MasterBaseClass.ToInt(val);
			break;
		case "CandyDropNum":
			_0024var_0024CandyDropNum = MasterBaseClass.ToInt(val);
			break;
		case "NutDropNum":
			_0024var_0024NutDropNum = MasterBaseClass.ToInt(val);
			break;
		case "MItemGroupId":
			_0024var_0024MItemGroupId = MasterBaseClass.ToInt(val);
			break;
		case "MTutorialItemId":
			_0024var_0024MTutorialItemId = MasterBaseClass.ToInt(val);
			break;
		case "ParameterCorrectId":
			_0024var_0024ParameterCorrectId = MasterBaseClass.ToInt(val);
			break;
		case "BeginDate":
		{
			object obj2 = val;
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			_0024var_0024BeginDate = DateTime.Parse((string)obj2);
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
		case "ClearCutScene":
			_0024var_0024ClearCutScene = MasterBaseClass.ToStringValue(val);
			break;
		case "MSceneWhenClear":
			_0024var_0024MSceneWhenClear = MasterBaseClass.ToInt(val);
			break;
		case "MScenePlayerPosition":
			_0024var_0024MScenePlayerPosition = MasterBaseClass.ToStringValue(val);
			break;
		case "StartCutScene":
			_0024var_0024StartCutScene = MasterBaseClass.ToStringValue(val);
			break;
		case "SceneOfStartCutScene":
			_0024var_0024SceneOfStartCutScene = MasterBaseClass.ToInt(val);
			break;
		case "StartCutScenePlayCond":
			_0024var_0024StartCutScenePlayCond = MasterBaseClass.ToInt(val);
			break;
		case "StartCutScenePlayNotCond":
			_0024var_0024StartCutScenePlayNotCond = MasterBaseClass.ToInt(val);
			break;
		case "StageCandyNum":
			_0024var_0024StageCandyNum = MasterBaseClass.ToInt(val);
			break;
		case "NutRateOfMonsterCandy":
			_0024var_0024NutRateOfMonsterCandy = MasterBaseClass.ToInt(val);
			break;
		case "NoPoppets":
			_0024var_0024NoPoppets = MasterBaseClass.ToBool(val);
			break;
		case "Rank":
			_0024var_0024Rank = MasterBaseClass.ToInt(val);
			break;
		case "ForbidContinuation":
			_0024var_0024ForbidContinuation = MasterBaseClass.ToBool(val);
			break;
		case "FailIfDead":
			_0024var_0024FailIfDead = MasterBaseClass.ToBool(val);
			break;
		case "NeedTicket":
			_0024var_0024NeedTicket = MasterBaseClass.ToBool(val);
			break;
		case "AttackAdjMult":
			_0024var_0024AttackAdjMult = MasterBaseClass.ToSingle(val);
			break;
		case "AttackAdjPlus":
			_0024var_0024AttackAdjPlus = MasterBaseClass.ToSingle(val);
			break;
		case "HpAdjMult":
			_0024var_0024HpAdjMult = MasterBaseClass.ToSingle(val);
			break;
		case "HpAdjPlus":
			_0024var_0024HpAdjPlus = MasterBaseClass.ToSingle(val);
			break;
		case "DefenseAdjMult":
			_0024var_0024DefenseAdjMult = MasterBaseClass.ToSingle(val);
			break;
		case "DefenseAdjPlus":
			_0024var_0024DefenseAdjPlus = MasterBaseClass.ToSingle(val);
			break;
		case "AutoRunOn":
			_0024var_0024AutoRunOn = MasterBaseClass.ToBool(val);
			break;
		case "AliveMonsterLimit":
			_0024var_0024AliveMonsterLimit = MasterBaseClass.ToInt(val);
			break;
		case "BgmId":
			_0024var_0024BgmId = MasterBaseClass.ToInt(val);
			break;
		case "Deprecated":
			_0024var_0024Deprecated = MasterBaseClass.ToBool(val);
			break;
		case "SortPriority":
			_0024var_0024SortPriority = MasterBaseClass.ToInt(val);
			break;
		case "CenterpieceItemGroupChildIdList":
			_0024var_0024CenterpieceItemGroupChildIdList = MasterBaseClass.ToStringValue(val);
			break;
		case "HighestDropWithoutCount":
			_0024var_0024HighestDropWithoutCount = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Progname" => true, 
			"Origname" => true, 
			"Name" => true, 
			"QuestType" => true, 
			"IsChallenge" => true, 
			"StoryFlag" => true, 
			"HideFlag" => true, 
			"DisplayName" => true, 
			"Explain" => true, 
			"DisplayName_En" => true, 
			"Explain_En" => true, 
			"TempFlag" => true, 
			"ApCost" => true, 
			"RpCost" => true, 
			"Difficulty" => true, 
			"StartSceneId" => true, 
			"StartPosition" => true, 
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
			"MAreaId" => true, 
			"MStageId" => true, 
			"Clear_1" => true, 
			"Clear_2" => true, 
			"Clear_3" => true, 
			"LimitTime" => true, 
			"CandyDropNum" => true, 
			"NutDropNum" => true, 
			"MItemGroupId" => true, 
			"MTutorialItemId" => true, 
			"ParameterCorrectId" => true, 
			"BeginDate" => true, 
			"EndDate" => true, 
			"ClearCutScene" => true, 
			"MSceneWhenClear" => true, 
			"MScenePlayerPosition" => true, 
			"StartCutScene" => true, 
			"SceneOfStartCutScene" => true, 
			"StartCutScenePlayCond" => true, 
			"StartCutScenePlayNotCond" => true, 
			"StageCandyNum" => true, 
			"NutRateOfMonsterCandy" => true, 
			"NoPoppets" => true, 
			"Rank" => true, 
			"ForbidContinuation" => true, 
			"FailIfDead" => true, 
			"NeedTicket" => true, 
			"AttackAdjMult" => true, 
			"AttackAdjPlus" => true, 
			"HpAdjMult" => true, 
			"HpAdjPlus" => true, 
			"DefenseAdjMult" => true, 
			"DefenseAdjPlus" => true, 
			"AutoRunOn" => true, 
			"AliveMonsterLimit" => true, 
			"BgmId" => true, 
			"Deprecated" => true, 
			"SortPriority" => true, 
			"CenterpieceItemGroupChildIdList" => true, 
			"HighestDropWithoutCount" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[74]
		{
			"Id", "Progname", "Origname", "Name", "QuestType", "IsChallenge", "StoryFlag", "HideFlag", "DisplayName", "Explain",
			"DisplayName_En", "Explain_En", "TempFlag", "ApCost", "RpCost", "Difficulty", "StartSceneId", "StartPosition", "Condition_1", "Condition_2",
			"Condition_3", "Condition_4", "Condition_5", "Condition_6", "Condition_7", "Condition_8", "NotCondition_1", "NotCondition_2", "NotCondition_3", "NotCondition_4",
			"NotCondition_5", "NotCondition_6", "NotCondition_7", "NotCondition_8", "MAreaId", "MStageId", "Clear_1", "Clear_2", "Clear_3", "LimitTime",
			"CandyDropNum", "NutDropNum", "MItemGroupId", "MTutorialItemId", "ParameterCorrectId", "BeginDate", "EndDate", "ClearCutScene", "MSceneWhenClear", "MScenePlayerPosition",
			"StartCutScene", "SceneOfStartCutScene", "StartCutScenePlayCond", "StartCutScenePlayNotCond", "StageCandyNum", "NutRateOfMonsterCandy", "NoPoppets", "Rank", "ForbidContinuation", "FailIfDead",
			"NeedTicket", "AttackAdjMult", "AttackAdjPlus", "HpAdjMult", "HpAdjPlus", "DefenseAdjMult", "DefenseAdjPlus", "AutoRunOn", "AliveMonsterLimit", "BgmId",
			"Deprecated", "SortPriority", "CenterpieceItemGroupChildIdList", "HighestDropWithoutCount"
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
						_0024var_0024Origname = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024Name = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null && typeof(EnumQuestTypes).IsEnum)
							{
								_0024var_0024QuestType = (EnumQuestTypes)MasterBaseClass.ParseEnum(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024IsChallenge = MasterBaseClass.ParseBool(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024StoryFlag = MasterBaseClass.ParseBool(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024HideFlag = MasterBaseClass.ParseBool(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024DisplayName = vals[8];
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024Explain = vals[9];
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024DisplayName_En = vals[10];
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024Explain_En = vals[11];
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024TempFlag = MasterBaseClass.ParseInt(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024ApCost = MasterBaseClass.ParseInt(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024RpCost = MasterBaseClass.ParseInt(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null)
																		{
																			_0024var_0024Difficulty = MasterBaseClass.ParseInt(vals[15]);
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null)
																			{
																				_0024var_0024StartSceneId = MasterBaseClass.ParseInt(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null)
																				{
																					_0024var_0024StartPosition = vals[17];
																				}
																				if (length <= 18)
																				{
																					result = 18;
																				}
																				else
																				{
																					if (vals[18] != null)
																					{
																						_0024var_0024Condition_1 = MasterBaseClass.ParseInt(vals[18]);
																					}
																					if (length <= 19)
																					{
																						result = 19;
																					}
																					else
																					{
																						if (vals[19] != null)
																						{
																							_0024var_0024Condition_2 = MasterBaseClass.ParseInt(vals[19]);
																						}
																						if (length <= 20)
																						{
																							result = 20;
																						}
																						else
																						{
																							if (vals[20] != null)
																							{
																								_0024var_0024Condition_3 = MasterBaseClass.ParseInt(vals[20]);
																							}
																							if (length <= 21)
																							{
																								result = 21;
																							}
																							else
																							{
																								if (vals[21] != null)
																								{
																									_0024var_0024Condition_4 = MasterBaseClass.ParseInt(vals[21]);
																								}
																								if (length <= 22)
																								{
																									result = 22;
																								}
																								else
																								{
																									if (vals[22] != null)
																									{
																										_0024var_0024Condition_5 = MasterBaseClass.ParseInt(vals[22]);
																									}
																									if (length <= 23)
																									{
																										result = 23;
																									}
																									else
																									{
																										if (vals[23] != null)
																										{
																											_0024var_0024Condition_6 = MasterBaseClass.ParseInt(vals[23]);
																										}
																										if (length <= 24)
																										{
																											result = 24;
																										}
																										else
																										{
																											if (vals[24] != null)
																											{
																												_0024var_0024Condition_7 = MasterBaseClass.ParseInt(vals[24]);
																											}
																											if (length <= 25)
																											{
																												result = 25;
																											}
																											else
																											{
																												if (vals[25] != null)
																												{
																													_0024var_0024Condition_8 = MasterBaseClass.ParseInt(vals[25]);
																												}
																												if (length <= 26)
																												{
																													result = 26;
																												}
																												else
																												{
																													if (vals[26] != null)
																													{
																														_0024var_0024NotCondition_1 = MasterBaseClass.ParseInt(vals[26]);
																													}
																													if (length <= 27)
																													{
																														result = 27;
																													}
																													else
																													{
																														if (vals[27] != null)
																														{
																															_0024var_0024NotCondition_2 = MasterBaseClass.ParseInt(vals[27]);
																														}
																														if (length <= 28)
																														{
																															result = 28;
																														}
																														else
																														{
																															if (vals[28] != null)
																															{
																																_0024var_0024NotCondition_3 = MasterBaseClass.ParseInt(vals[28]);
																															}
																															if (length <= 29)
																															{
																																result = 29;
																															}
																															else
																															{
																																if (vals[29] != null)
																																{
																																	_0024var_0024NotCondition_4 = MasterBaseClass.ParseInt(vals[29]);
																																}
																																if (length <= 30)
																																{
																																	result = 30;
																																}
																																else
																																{
																																	if (vals[30] != null)
																																	{
																																		_0024var_0024NotCondition_5 = MasterBaseClass.ParseInt(vals[30]);
																																	}
																																	if (length <= 31)
																																	{
																																		result = 31;
																																	}
																																	else
																																	{
																																		if (vals[31] != null)
																																		{
																																			_0024var_0024NotCondition_6 = MasterBaseClass.ParseInt(vals[31]);
																																		}
																																		if (length <= 32)
																																		{
																																			result = 32;
																																		}
																																		else
																																		{
																																			if (vals[32] != null)
																																			{
																																				_0024var_0024NotCondition_7 = MasterBaseClass.ParseInt(vals[32]);
																																			}
																																			if (length <= 33)
																																			{
																																				result = 33;
																																			}
																																			else
																																			{
																																				if (vals[33] != null)
																																				{
																																					_0024var_0024NotCondition_8 = MasterBaseClass.ParseInt(vals[33]);
																																				}
																																				if (length <= 34)
																																				{
																																					result = 34;
																																				}
																																				else
																																				{
																																					if (vals[34] != null)
																																					{
																																						_0024var_0024MAreaId = MasterBaseClass.ParseInt(vals[34]);
																																					}
																																					if (length <= 35)
																																					{
																																						result = 35;
																																					}
																																					else
																																					{
																																						if (vals[35] != null)
																																						{
																																							_0024var_0024MStageId = MasterBaseClass.ParseInt(vals[35]);
																																						}
																																						if (length <= 36)
																																						{
																																							result = 36;
																																						}
																																						else
																																						{
																																							if (vals[36] != null)
																																							{
																																								_0024var_0024Clear_1 = MasterBaseClass.ParseInt(vals[36]);
																																							}
																																							if (length <= 37)
																																							{
																																								result = 37;
																																							}
																																							else
																																							{
																																								if (vals[37] != null)
																																								{
																																									_0024var_0024Clear_2 = MasterBaseClass.ParseInt(vals[37]);
																																								}
																																								if (length <= 38)
																																								{
																																									result = 38;
																																								}
																																								else
																																								{
																																									if (vals[38] != null)
																																									{
																																										_0024var_0024Clear_3 = MasterBaseClass.ParseInt(vals[38]);
																																									}
																																									if (length <= 39)
																																									{
																																										result = 39;
																																									}
																																									else
																																									{
																																										if (vals[39] != null)
																																										{
																																											_0024var_0024LimitTime = MasterBaseClass.ParseInt(vals[39]);
																																										}
																																										if (length <= 40)
																																										{
																																											result = 40;
																																										}
																																										else
																																										{
																																											if (vals[40] != null)
																																											{
																																												_0024var_0024CandyDropNum = MasterBaseClass.ParseInt(vals[40]);
																																											}
																																											if (length <= 41)
																																											{
																																												result = 41;
																																											}
																																											else
																																											{
																																												if (vals[41] != null)
																																												{
																																													_0024var_0024NutDropNum = MasterBaseClass.ParseInt(vals[41]);
																																												}
																																												if (length <= 42)
																																												{
																																													result = 42;
																																												}
																																												else
																																												{
																																													if (vals[42] != null)
																																													{
																																														_0024var_0024MItemGroupId = MasterBaseClass.ParseInt(vals[42]);
																																													}
																																													if (length <= 43)
																																													{
																																														result = 43;
																																													}
																																													else
																																													{
																																														if (vals[43] != null)
																																														{
																																															_0024var_0024MTutorialItemId = MasterBaseClass.ParseInt(vals[43]);
																																														}
																																														if (length <= 44)
																																														{
																																															result = 44;
																																														}
																																														else
																																														{
																																															if (vals[44] != null)
																																															{
																																																_0024var_0024ParameterCorrectId = MasterBaseClass.ParseInt(vals[44]);
																																															}
																																															if (length <= 45)
																																															{
																																																result = 45;
																																															}
																																															else
																																															{
																																																if (vals[45] != null)
																																																{
																																																	_0024var_0024BeginDate = MasterBaseClass.ParseDateTime(vals[45]);
																																																}
																																																if (length <= 46)
																																																{
																																																	result = 46;
																																																}
																																																else
																																																{
																																																	if (vals[46] != null)
																																																	{
																																																		_0024var_0024EndDate = MasterBaseClass.ParseDateTime(vals[46]);
																																																	}
																																																	if (length <= 47)
																																																	{
																																																		result = 47;
																																																	}
																																																	else
																																																	{
																																																		if (vals[47] != null)
																																																		{
																																																			_0024var_0024ClearCutScene = vals[47];
																																																		}
																																																		if (length <= 48)
																																																		{
																																																			result = 48;
																																																		}
																																																		else
																																																		{
																																																			if (vals[48] != null)
																																																			{
																																																				_0024var_0024MSceneWhenClear = MasterBaseClass.ParseInt(vals[48]);
																																																			}
																																																			if (length <= 49)
																																																			{
																																																				result = 49;
																																																			}
																																																			else
																																																			{
																																																				if (vals[49] != null)
																																																				{
																																																					_0024var_0024MScenePlayerPosition = vals[49];
																																																				}
																																																				if (length <= 50)
																																																				{
																																																					result = 50;
																																																				}
																																																				else
																																																				{
																																																					if (vals[50] != null)
																																																					{
																																																						_0024var_0024StartCutScene = vals[50];
																																																					}
																																																					if (length <= 51)
																																																					{
																																																						result = 51;
																																																					}
																																																					else
																																																					{
																																																						if (vals[51] != null)
																																																						{
																																																							_0024var_0024SceneOfStartCutScene = MasterBaseClass.ParseInt(vals[51]);
																																																						}
																																																						if (length <= 52)
																																																						{
																																																							result = 52;
																																																						}
																																																						else
																																																						{
																																																							if (vals[52] != null)
																																																							{
																																																								_0024var_0024StartCutScenePlayCond = MasterBaseClass.ParseInt(vals[52]);
																																																							}
																																																							if (length <= 53)
																																																							{
																																																								result = 53;
																																																							}
																																																							else
																																																							{
																																																								if (vals[53] != null)
																																																								{
																																																									_0024var_0024StartCutScenePlayNotCond = MasterBaseClass.ParseInt(vals[53]);
																																																								}
																																																								if (length <= 54)
																																																								{
																																																									result = 54;
																																																								}
																																																								else
																																																								{
																																																									if (vals[54] != null)
																																																									{
																																																										_0024var_0024StageCandyNum = MasterBaseClass.ParseInt(vals[54]);
																																																									}
																																																									if (length <= 55)
																																																									{
																																																										result = 55;
																																																									}
																																																									else
																																																									{
																																																										if (vals[55] != null)
																																																										{
																																																											_0024var_0024NutRateOfMonsterCandy = MasterBaseClass.ParseInt(vals[55]);
																																																										}
																																																										if (length <= 56)
																																																										{
																																																											result = 56;
																																																										}
																																																										else
																																																										{
																																																											if (vals[56] != null)
																																																											{
																																																												_0024var_0024NoPoppets = MasterBaseClass.ParseBool(vals[56]);
																																																											}
																																																											if (length <= 57)
																																																											{
																																																												result = 57;
																																																											}
																																																											else
																																																											{
																																																												if (vals[57] != null)
																																																												{
																																																													_0024var_0024Rank = MasterBaseClass.ParseInt(vals[57]);
																																																												}
																																																												if (length <= 58)
																																																												{
																																																													result = 58;
																																																												}
																																																												else
																																																												{
																																																													if (vals[58] != null)
																																																													{
																																																														_0024var_0024ForbidContinuation = MasterBaseClass.ParseBool(vals[58]);
																																																													}
																																																													if (length <= 59)
																																																													{
																																																														result = 59;
																																																													}
																																																													else
																																																													{
																																																														if (vals[59] != null)
																																																														{
																																																															_0024var_0024FailIfDead = MasterBaseClass.ParseBool(vals[59]);
																																																														}
																																																														if (length <= 60)
																																																														{
																																																															result = 60;
																																																														}
																																																														else
																																																														{
																																																															if (vals[60] != null)
																																																															{
																																																																_0024var_0024NeedTicket = MasterBaseClass.ParseBool(vals[60]);
																																																															}
																																																															if (length <= 61)
																																																															{
																																																																result = 61;
																																																															}
																																																															else
																																																															{
																																																																if (vals[61] != null)
																																																																{
																																																																	_0024var_0024AttackAdjMult = MasterBaseClass.ParseSingle(vals[61]);
																																																																}
																																																																if (length <= 62)
																																																																{
																																																																	result = 62;
																																																																}
																																																																else
																																																																{
																																																																	if (vals[62] != null)
																																																																	{
																																																																		_0024var_0024AttackAdjPlus = MasterBaseClass.ParseSingle(vals[62]);
																																																																	}
																																																																	if (length <= 63)
																																																																	{
																																																																		result = 63;
																																																																	}
																																																																	else
																																																																	{
																																																																		if (vals[63] != null)
																																																																		{
																																																																			_0024var_0024HpAdjMult = MasterBaseClass.ParseSingle(vals[63]);
																																																																		}
																																																																		if (length <= 64)
																																																																		{
																																																																			result = 64;
																																																																		}
																																																																		else
																																																																		{
																																																																			if (vals[64] != null)
																																																																			{
																																																																				_0024var_0024HpAdjPlus = MasterBaseClass.ParseSingle(vals[64]);
																																																																			}
																																																																			if (length <= 65)
																																																																			{
																																																																				result = 65;
																																																																			}
																																																																			else
																																																																			{
																																																																				if (vals[65] != null)
																																																																				{
																																																																					_0024var_0024DefenseAdjMult = MasterBaseClass.ParseSingle(vals[65]);
																																																																				}
																																																																				if (length <= 66)
																																																																				{
																																																																					result = 66;
																																																																				}
																																																																				else
																																																																				{
																																																																					if (vals[66] != null)
																																																																					{
																																																																						_0024var_0024DefenseAdjPlus = MasterBaseClass.ParseSingle(vals[66]);
																																																																					}
																																																																					if (length <= 67)
																																																																					{
																																																																						result = 67;
																																																																					}
																																																																					else
																																																																					{
																																																																						if (vals[67] != null)
																																																																						{
																																																																							_0024var_0024AutoRunOn = MasterBaseClass.ParseBool(vals[67]);
																																																																						}
																																																																						if (length <= 68)
																																																																						{
																																																																							result = 68;
																																																																						}
																																																																						else
																																																																						{
																																																																							if (vals[68] != null)
																																																																							{
																																																																								_0024var_0024AliveMonsterLimit = MasterBaseClass.ParseInt(vals[68]);
																																																																							}
																																																																							if (length <= 69)
																																																																							{
																																																																								result = 69;
																																																																							}
																																																																							else
																																																																							{
																																																																								if (vals[69] != null)
																																																																								{
																																																																									_0024var_0024BgmId = MasterBaseClass.ParseInt(vals[69]);
																																																																								}
																																																																								if (length <= 70)
																																																																								{
																																																																									result = 70;
																																																																								}
																																																																								else
																																																																								{
																																																																									if (vals[70] != null)
																																																																									{
																																																																										_0024var_0024Deprecated = MasterBaseClass.ParseBool(vals[70]);
																																																																									}
																																																																									if (length <= 71)
																																																																									{
																																																																										result = 71;
																																																																									}
																																																																									else
																																																																									{
																																																																										if (vals[71] != null)
																																																																										{
																																																																											_0024var_0024SortPriority = MasterBaseClass.ParseInt(vals[71]);
																																																																										}
																																																																										if (length <= 72)
																																																																										{
																																																																											result = 72;
																																																																										}
																																																																										else
																																																																										{
																																																																											if (vals[72] != null)
																																																																											{
																																																																												_0024var_0024CenterpieceItemGroupChildIdList = vals[72];
																																																																											}
																																																																											if (length <= 73)
																																																																											{
																																																																												result = 73;
																																																																											}
																																																																											else
																																																																											{
																																																																												if (vals[73] != null)
																																																																												{
																																																																													_0024var_0024HighestDropWithoutCount = MasterBaseClass.ParseInt(vals[73]);
																																																																												}
																																																																												int num = 74;
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
