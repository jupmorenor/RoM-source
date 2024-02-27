using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MNpcs : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	public string _0024var_0024DisplayName;

	public string _0024var_0024DisplayName_En;

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

	public string _0024var_0024PositionObject;

	public string _0024var_0024SceneObject;

	public MFlags _0024var_0024PrefabCond;

	public string _0024var_0024Prefab;

	public string _0024var_0024AltPrefab;

	public bool _0024var_0024DestroySceneObjectIfNotShow;

	public string _0024var_0024NpcNoDupId;

	public string _0024var_0024Action;

	public bool _0024var_0024Pause;

	public int _0024var_0024GimmickFlag;

	public int _0024var_0024NpcTalkId_1;

	public int _0024var_0024NpcTalkId_2;

	public int _0024var_0024NpcTalkId_3;

	public int _0024var_0024NpcTalkId_4;

	public int _0024var_0024NpcTalkId_5;

	public int _0024var_0024NpcTalkId_6;

	public int _0024var_0024NpcTalkId_7;

	public int _0024var_0024NpcTalkId_8;

	public int _0024var_0024NpcTalkId_9;

	public int _0024var_0024NpcTalkId_10;

	public int _0024var_0024NpcTalkId_11;

	public int _0024var_0024NpcTalkId_12;

	public int _0024var_0024NpcTalkId_13;

	public int _0024var_0024NpcTalkId_14;

	public int _0024var_0024NpcTalkId_15;

	public int _0024var_0024NpcTalkId_16;

	public int _0024var_0024NpcTalkId_17;

	public int _0024var_0024NpcTalkId_18;

	public int _0024var_0024NpcTalkId_19;

	public int _0024var_0024NpcTalkId_20;

	public int _0024var_0024NpcTalkId_21;

	public int _0024var_0024NpcTalkId_22;

	public int _0024var_0024NpcTalkId_23;

	public int _0024var_0024NpcTalkId_24;

	public int _0024var_0024NpcTalkId_25;

	public int _0024var_0024NpcTalkId_26;

	public int _0024var_0024NpcTalkId_27;

	public int _0024var_0024NpcTalkId_28;

	public int _0024var_0024NpcTalkId_29;

	public int _0024var_0024NpcTalkId_30;

	public int _0024var_0024NpcTalkId_31;

	public int _0024var_0024NpcTalkId_32;

	public float _0024var_0024IconHeight;

	public EnumNPCMoveInitTypes _0024var_0024MoveInitType;

	public bool _0024var_0024Loop;

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
	private MFlags GimmickFlag__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_1__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_2__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_3__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_4__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_5__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_6__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_7__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_8__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_9__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_10__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_11__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_12__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_13__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_14__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_15__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_16__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_17__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_18__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_19__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_20__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_21__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_22__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_23__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_24__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_25__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_26__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_27__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_28__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_29__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_30__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_31__cache;

	[NonSerialized]
	private MNpcTalks NpcTalkId_32__cache;

	[NonSerialized]
	private static Dictionary<int, MNpcs> _0024mst_002455 = new Dictionary<int, MNpcs>();

	[NonSerialized]
	private static MNpcs[] All_cache;

	public MFlags[] AllConditions
	{
		get
		{
			MFlags[] array = new MFlags[8] { Condition_1, Condition_2, Condition_3, Condition_4, Condition_5, Condition_6, Condition_7, Condition_8 };
			System.Collections.Generic.List<MFlags> list = new System.Collections.Generic.List<MFlags>();
			int i = 0;
			MFlags[] array2 = array;
			for (int length = array2.Length; i < length; i = checked(i + 1))
			{
				if (array2[i] != null)
				{
					list.Add(array2[i]);
				}
			}
			return list.ToArray();
		}
	}

	public MFlags[] AllNotConditions
	{
		get
		{
			MFlags[] flags = new MFlags[8] { NotCondition_1, NotCondition_2, NotCondition_3, NotCondition_4, NotCondition_5, NotCondition_6, NotCondition_7, NotCondition_8 };
			return ArrayMap.FilterMFlags(flags, (MFlags m) => m != null);
		}
	}

	public MNpcTalks[] AllNpcTalks
	{
		get
		{
			System.Collections.Generic.List<MNpcTalks> list = new System.Collections.Generic.List<MNpcTalks>();
			if (NpcTalkId_1 != null)
			{
				list.Add(NpcTalkId_1);
			}
			if (NpcTalkId_2 != null)
			{
				list.Add(NpcTalkId_2);
			}
			if (NpcTalkId_3 != null)
			{
				list.Add(NpcTalkId_3);
			}
			if (NpcTalkId_4 != null)
			{
				list.Add(NpcTalkId_4);
			}
			if (NpcTalkId_5 != null)
			{
				list.Add(NpcTalkId_5);
			}
			if (NpcTalkId_6 != null)
			{
				list.Add(NpcTalkId_6);
			}
			if (NpcTalkId_7 != null)
			{
				list.Add(NpcTalkId_7);
			}
			if (NpcTalkId_8 != null)
			{
				list.Add(NpcTalkId_8);
			}
			if (NpcTalkId_9 != null)
			{
				list.Add(NpcTalkId_9);
			}
			if (NpcTalkId_10 != null)
			{
				list.Add(NpcTalkId_10);
			}
			if (NpcTalkId_11 != null)
			{
				list.Add(NpcTalkId_11);
			}
			if (NpcTalkId_12 != null)
			{
				list.Add(NpcTalkId_12);
			}
			if (NpcTalkId_13 != null)
			{
				list.Add(NpcTalkId_13);
			}
			if (NpcTalkId_14 != null)
			{
				list.Add(NpcTalkId_14);
			}
			if (NpcTalkId_15 != null)
			{
				list.Add(NpcTalkId_15);
			}
			if (NpcTalkId_16 != null)
			{
				list.Add(NpcTalkId_16);
			}
			if (NpcTalkId_17 != null)
			{
				list.Add(NpcTalkId_17);
			}
			if (NpcTalkId_18 != null)
			{
				list.Add(NpcTalkId_18);
			}
			if (NpcTalkId_19 != null)
			{
				list.Add(NpcTalkId_19);
			}
			if (NpcTalkId_20 != null)
			{
				list.Add(NpcTalkId_20);
			}
			if (NpcTalkId_21 != null)
			{
				list.Add(NpcTalkId_21);
			}
			if (NpcTalkId_22 != null)
			{
				list.Add(NpcTalkId_22);
			}
			if (NpcTalkId_23 != null)
			{
				list.Add(NpcTalkId_23);
			}
			if (NpcTalkId_24 != null)
			{
				list.Add(NpcTalkId_24);
			}
			if (NpcTalkId_25 != null)
			{
				list.Add(NpcTalkId_25);
			}
			if (NpcTalkId_26 != null)
			{
				list.Add(NpcTalkId_26);
			}
			if (NpcTalkId_27 != null)
			{
				list.Add(NpcTalkId_27);
			}
			if (NpcTalkId_28 != null)
			{
				list.Add(NpcTalkId_28);
			}
			if (NpcTalkId_29 != null)
			{
				list.Add(NpcTalkId_29);
			}
			if (NpcTalkId_30 != null)
			{
				list.Add(NpcTalkId_30);
			}
			if (NpcTalkId_31 != null)
			{
				list.Add(NpcTalkId_31);
			}
			if (NpcTalkId_32 != null)
			{
				list.Add(NpcTalkId_32);
			}
			return list.ToArray();
		}
	}

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

	public string DisplayName => _0024var_0024DisplayName;

	public string DisplayName_En => _0024var_0024DisplayName_En;

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

	public string PositionObject => _0024var_0024PositionObject;

	public string SceneObject => _0024var_0024SceneObject;

	public MFlags PrefabCond => _0024var_0024PrefabCond;

	public string Prefab => _0024var_0024Prefab;

	public string AltPrefab => _0024var_0024AltPrefab;

	public bool DestroySceneObjectIfNotShow => _0024var_0024DestroySceneObjectIfNotShow;

	public string NpcNoDupId => _0024var_0024NpcNoDupId;

	public string Action => _0024var_0024Action;

	public bool Pause => _0024var_0024Pause;

	public MFlags GimmickFlag
	{
		get
		{
			if (GimmickFlag__cache == null)
			{
				GimmickFlag__cache = MFlags.Get(_0024var_0024GimmickFlag);
			}
			return GimmickFlag__cache;
		}
	}

	public MNpcTalks NpcTalkId_1
	{
		get
		{
			if (NpcTalkId_1__cache == null)
			{
				NpcTalkId_1__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_1);
			}
			return NpcTalkId_1__cache;
		}
	}

	public MNpcTalks NpcTalkId_2
	{
		get
		{
			if (NpcTalkId_2__cache == null)
			{
				NpcTalkId_2__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_2);
			}
			return NpcTalkId_2__cache;
		}
	}

	public MNpcTalks NpcTalkId_3
	{
		get
		{
			if (NpcTalkId_3__cache == null)
			{
				NpcTalkId_3__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_3);
			}
			return NpcTalkId_3__cache;
		}
	}

	public MNpcTalks NpcTalkId_4
	{
		get
		{
			if (NpcTalkId_4__cache == null)
			{
				NpcTalkId_4__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_4);
			}
			return NpcTalkId_4__cache;
		}
	}

	public MNpcTalks NpcTalkId_5
	{
		get
		{
			if (NpcTalkId_5__cache == null)
			{
				NpcTalkId_5__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_5);
			}
			return NpcTalkId_5__cache;
		}
	}

	public MNpcTalks NpcTalkId_6
	{
		get
		{
			if (NpcTalkId_6__cache == null)
			{
				NpcTalkId_6__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_6);
			}
			return NpcTalkId_6__cache;
		}
	}

	public MNpcTalks NpcTalkId_7
	{
		get
		{
			if (NpcTalkId_7__cache == null)
			{
				NpcTalkId_7__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_7);
			}
			return NpcTalkId_7__cache;
		}
	}

	public MNpcTalks NpcTalkId_8
	{
		get
		{
			if (NpcTalkId_8__cache == null)
			{
				NpcTalkId_8__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_8);
			}
			return NpcTalkId_8__cache;
		}
	}

	public MNpcTalks NpcTalkId_9
	{
		get
		{
			if (NpcTalkId_9__cache == null)
			{
				NpcTalkId_9__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_9);
			}
			return NpcTalkId_9__cache;
		}
	}

	public MNpcTalks NpcTalkId_10
	{
		get
		{
			if (NpcTalkId_10__cache == null)
			{
				NpcTalkId_10__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_10);
			}
			return NpcTalkId_10__cache;
		}
	}

	public MNpcTalks NpcTalkId_11
	{
		get
		{
			if (NpcTalkId_11__cache == null)
			{
				NpcTalkId_11__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_11);
			}
			return NpcTalkId_11__cache;
		}
	}

	public MNpcTalks NpcTalkId_12
	{
		get
		{
			if (NpcTalkId_12__cache == null)
			{
				NpcTalkId_12__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_12);
			}
			return NpcTalkId_12__cache;
		}
	}

	public MNpcTalks NpcTalkId_13
	{
		get
		{
			if (NpcTalkId_13__cache == null)
			{
				NpcTalkId_13__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_13);
			}
			return NpcTalkId_13__cache;
		}
	}

	public MNpcTalks NpcTalkId_14
	{
		get
		{
			if (NpcTalkId_14__cache == null)
			{
				NpcTalkId_14__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_14);
			}
			return NpcTalkId_14__cache;
		}
	}

	public MNpcTalks NpcTalkId_15
	{
		get
		{
			if (NpcTalkId_15__cache == null)
			{
				NpcTalkId_15__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_15);
			}
			return NpcTalkId_15__cache;
		}
	}

	public MNpcTalks NpcTalkId_16
	{
		get
		{
			if (NpcTalkId_16__cache == null)
			{
				NpcTalkId_16__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_16);
			}
			return NpcTalkId_16__cache;
		}
	}

	public MNpcTalks NpcTalkId_17
	{
		get
		{
			if (NpcTalkId_17__cache == null)
			{
				NpcTalkId_17__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_17);
			}
			return NpcTalkId_17__cache;
		}
	}

	public MNpcTalks NpcTalkId_18
	{
		get
		{
			if (NpcTalkId_18__cache == null)
			{
				NpcTalkId_18__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_18);
			}
			return NpcTalkId_18__cache;
		}
	}

	public MNpcTalks NpcTalkId_19
	{
		get
		{
			if (NpcTalkId_19__cache == null)
			{
				NpcTalkId_19__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_19);
			}
			return NpcTalkId_19__cache;
		}
	}

	public MNpcTalks NpcTalkId_20
	{
		get
		{
			if (NpcTalkId_20__cache == null)
			{
				NpcTalkId_20__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_20);
			}
			return NpcTalkId_20__cache;
		}
	}

	public MNpcTalks NpcTalkId_21
	{
		get
		{
			if (NpcTalkId_21__cache == null)
			{
				NpcTalkId_21__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_21);
			}
			return NpcTalkId_21__cache;
		}
	}

	public MNpcTalks NpcTalkId_22
	{
		get
		{
			if (NpcTalkId_22__cache == null)
			{
				NpcTalkId_22__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_22);
			}
			return NpcTalkId_22__cache;
		}
	}

	public MNpcTalks NpcTalkId_23
	{
		get
		{
			if (NpcTalkId_23__cache == null)
			{
				NpcTalkId_23__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_23);
			}
			return NpcTalkId_23__cache;
		}
	}

	public MNpcTalks NpcTalkId_24
	{
		get
		{
			if (NpcTalkId_24__cache == null)
			{
				NpcTalkId_24__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_24);
			}
			return NpcTalkId_24__cache;
		}
	}

	public MNpcTalks NpcTalkId_25
	{
		get
		{
			if (NpcTalkId_25__cache == null)
			{
				NpcTalkId_25__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_25);
			}
			return NpcTalkId_25__cache;
		}
	}

	public MNpcTalks NpcTalkId_26
	{
		get
		{
			if (NpcTalkId_26__cache == null)
			{
				NpcTalkId_26__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_26);
			}
			return NpcTalkId_26__cache;
		}
	}

	public MNpcTalks NpcTalkId_27
	{
		get
		{
			if (NpcTalkId_27__cache == null)
			{
				NpcTalkId_27__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_27);
			}
			return NpcTalkId_27__cache;
		}
	}

	public MNpcTalks NpcTalkId_28
	{
		get
		{
			if (NpcTalkId_28__cache == null)
			{
				NpcTalkId_28__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_28);
			}
			return NpcTalkId_28__cache;
		}
	}

	public MNpcTalks NpcTalkId_29
	{
		get
		{
			if (NpcTalkId_29__cache == null)
			{
				NpcTalkId_29__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_29);
			}
			return NpcTalkId_29__cache;
		}
	}

	public MNpcTalks NpcTalkId_30
	{
		get
		{
			if (NpcTalkId_30__cache == null)
			{
				NpcTalkId_30__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_30);
			}
			return NpcTalkId_30__cache;
		}
	}

	public MNpcTalks NpcTalkId_31
	{
		get
		{
			if (NpcTalkId_31__cache == null)
			{
				NpcTalkId_31__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_31);
			}
			return NpcTalkId_31__cache;
		}
	}

	public MNpcTalks NpcTalkId_32
	{
		get
		{
			if (NpcTalkId_32__cache == null)
			{
				NpcTalkId_32__cache = MNpcTalks.Get(_0024var_0024NpcTalkId_32);
			}
			return NpcTalkId_32__cache;
		}
	}

	public float IconHeight => _0024var_0024IconHeight;

	public EnumNPCMoveInitTypes MoveInitType => _0024var_0024MoveInitType;

	public bool Loop => _0024var_0024Loop;

	public static MNpcs[] All
	{
		get
		{
			MNpcs[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MNpcs");
				MNpcs[] array = (MNpcs[])Builtins.array(typeof(MNpcs), _0024mst_002455.Values);
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

	public MNpcs()
	{
		_0024var_0024DisplayName = string.Empty;
		_0024var_0024DisplayName_En = string.Empty;
		_0024var_0024IconHeight = 2.5f;
		_0024var_0024MoveInitType = EnumNPCMoveInitTypes.Default;
	}

	public override string ToString()
	{
		return new StringBuilder("MNpcs(").Append((object)Id).Append(",").Append(Progname)
			.Append(",")
			.Append(Prefab)
			.Append("/")
			.Append(AltPrefab)
			.Append(")")
			.ToString();
	}

	public string GetName()
	{
		return (MerlinLanguageSetting.GetCurrentLanguage() != 0) ? DisplayName_En : DisplayName;
	}

	public static MNpcs Get(int _id)
	{
		MerlinMaster.GetHandler("MNpcs");
		return (!_0024mst_002455.ContainsKey(_id)) ? null : _0024mst_002455[_id];
	}

	public static void Unload()
	{
		_0024mst_002455.Clear();
		All_cache = null;
	}

	public static MNpcs New(Hashtable data)
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
			MNpcs mNpcs = Create(data);
			if (!_0024mst_002455.ContainsKey(mNpcs.Id))
			{
				_0024mst_002455[mNpcs.Id] = mNpcs;
			}
			result = mNpcs;
		}
		return (MNpcs)result;
	}

	public static MNpcs New2(string[] keys, object[] vals)
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
		return (MNpcs)result;
	}

	public static MNpcs Entry(MNpcs mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002455[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MNpcs)result;
	}

	public static void AddMst(MNpcs mst)
	{
		if (mst != null)
		{
			_0024mst_002455[mst.Id] = mst;
		}
	}

	public static MNpcs Create(Hashtable data)
	{
		MNpcs mNpcs = new MNpcs();
		MNpcs result;
		if (data == null)
		{
			result = mNpcs;
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
				mNpcs.setField((string)obj, data[current]);
			}
			result = mNpcs;
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
		case "DisplayName":
			_0024var_0024DisplayName = MasterBaseClass.ToStringValue(val);
			break;
		case "DisplayName_En":
			_0024var_0024DisplayName_En = MasterBaseClass.ToStringValue(val);
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
		case "PositionObject":
			_0024var_0024PositionObject = MasterBaseClass.ToStringValue(val);
			break;
		case "SceneObject":
			_0024var_0024SceneObject = MasterBaseClass.ToStringValue(val);
			break;
		case "PrefabCond":
			if (typeof(MFlags).IsEnum)
			{
				object obj = MasterBaseClass.ToEnum(val);
				if (!(obj is MFlags))
				{
					obj = RuntimeServices.Coerce(obj, typeof(MFlags));
				}
				_0024var_0024PrefabCond = (MFlags)obj;
			}
			break;
		case "Prefab":
			_0024var_0024Prefab = MasterBaseClass.ToStringValue(val);
			break;
		case "AltPrefab":
			_0024var_0024AltPrefab = MasterBaseClass.ToStringValue(val);
			break;
		case "DestroySceneObjectIfNotShow":
			_0024var_0024DestroySceneObjectIfNotShow = MasterBaseClass.ToBool(val);
			break;
		case "NpcNoDupId":
			_0024var_0024NpcNoDupId = MasterBaseClass.ToStringValue(val);
			break;
		case "Action":
			_0024var_0024Action = MasterBaseClass.ToStringValue(val);
			break;
		case "Pause":
			_0024var_0024Pause = MasterBaseClass.ToBool(val);
			break;
		case "GimmickFlag":
			_0024var_0024GimmickFlag = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_1":
			_0024var_0024NpcTalkId_1 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_2":
			_0024var_0024NpcTalkId_2 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_3":
			_0024var_0024NpcTalkId_3 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_4":
			_0024var_0024NpcTalkId_4 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_5":
			_0024var_0024NpcTalkId_5 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_6":
			_0024var_0024NpcTalkId_6 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_7":
			_0024var_0024NpcTalkId_7 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_8":
			_0024var_0024NpcTalkId_8 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_9":
			_0024var_0024NpcTalkId_9 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_10":
			_0024var_0024NpcTalkId_10 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_11":
			_0024var_0024NpcTalkId_11 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_12":
			_0024var_0024NpcTalkId_12 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_13":
			_0024var_0024NpcTalkId_13 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_14":
			_0024var_0024NpcTalkId_14 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_15":
			_0024var_0024NpcTalkId_15 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_16":
			_0024var_0024NpcTalkId_16 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_17":
			_0024var_0024NpcTalkId_17 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_18":
			_0024var_0024NpcTalkId_18 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_19":
			_0024var_0024NpcTalkId_19 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_20":
			_0024var_0024NpcTalkId_20 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_21":
			_0024var_0024NpcTalkId_21 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_22":
			_0024var_0024NpcTalkId_22 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_23":
			_0024var_0024NpcTalkId_23 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_24":
			_0024var_0024NpcTalkId_24 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_25":
			_0024var_0024NpcTalkId_25 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_26":
			_0024var_0024NpcTalkId_26 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_27":
			_0024var_0024NpcTalkId_27 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_28":
			_0024var_0024NpcTalkId_28 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_29":
			_0024var_0024NpcTalkId_29 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_30":
			_0024var_0024NpcTalkId_30 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_31":
			_0024var_0024NpcTalkId_31 = MasterBaseClass.ToInt(val);
			break;
		case "NpcTalkId_32":
			_0024var_0024NpcTalkId_32 = MasterBaseClass.ToInt(val);
			break;
		case "IconHeight":
			_0024var_0024IconHeight = MasterBaseClass.ToSingle(val);
			break;
		case "MoveInitType":
			if (typeof(EnumNPCMoveInitTypes).IsEnum)
			{
				_0024var_0024MoveInitType = (EnumNPCMoveInitTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "Loop":
			_0024var_0024Loop = MasterBaseClass.ToBool(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Progname" => true, 
			"DisplayName" => true, 
			"DisplayName_En" => true, 
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
			"PositionObject" => true, 
			"SceneObject" => true, 
			"PrefabCond" => true, 
			"Prefab" => true, 
			"AltPrefab" => true, 
			"DestroySceneObjectIfNotShow" => true, 
			"NpcNoDupId" => true, 
			"Action" => true, 
			"Pause" => true, 
			"GimmickFlag" => true, 
			"NpcTalkId_1" => true, 
			"NpcTalkId_2" => true, 
			"NpcTalkId_3" => true, 
			"NpcTalkId_4" => true, 
			"NpcTalkId_5" => true, 
			"NpcTalkId_6" => true, 
			"NpcTalkId_7" => true, 
			"NpcTalkId_8" => true, 
			"NpcTalkId_9" => true, 
			"NpcTalkId_10" => true, 
			"NpcTalkId_11" => true, 
			"NpcTalkId_12" => true, 
			"NpcTalkId_13" => true, 
			"NpcTalkId_14" => true, 
			"NpcTalkId_15" => true, 
			"NpcTalkId_16" => true, 
			"NpcTalkId_17" => true, 
			"NpcTalkId_18" => true, 
			"NpcTalkId_19" => true, 
			"NpcTalkId_20" => true, 
			"NpcTalkId_21" => true, 
			"NpcTalkId_22" => true, 
			"NpcTalkId_23" => true, 
			"NpcTalkId_24" => true, 
			"NpcTalkId_25" => true, 
			"NpcTalkId_26" => true, 
			"NpcTalkId_27" => true, 
			"NpcTalkId_28" => true, 
			"NpcTalkId_29" => true, 
			"NpcTalkId_30" => true, 
			"NpcTalkId_31" => true, 
			"NpcTalkId_32" => true, 
			"IconHeight" => true, 
			"MoveInitType" => true, 
			"Loop" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[65]
		{
			"Id", "Progname", "DisplayName", "DisplayName_En", "Condition_1", "Condition_2", "Condition_3", "Condition_4", "Condition_5", "Condition_6",
			"Condition_7", "Condition_8", "NotCondition_1", "NotCondition_2", "NotCondition_3", "NotCondition_4", "NotCondition_5", "NotCondition_6", "NotCondition_7", "NotCondition_8",
			"PositionObject", "SceneObject", "PrefabCond", "Prefab", "AltPrefab", "DestroySceneObjectIfNotShow", "NpcNoDupId", "Action", "Pause", "GimmickFlag",
			"NpcTalkId_1", "NpcTalkId_2", "NpcTalkId_3", "NpcTalkId_4", "NpcTalkId_5", "NpcTalkId_6", "NpcTalkId_7", "NpcTalkId_8", "NpcTalkId_9", "NpcTalkId_10",
			"NpcTalkId_11", "NpcTalkId_12", "NpcTalkId_13", "NpcTalkId_14", "NpcTalkId_15", "NpcTalkId_16", "NpcTalkId_17", "NpcTalkId_18", "NpcTalkId_19", "NpcTalkId_20",
			"NpcTalkId_21", "NpcTalkId_22", "NpcTalkId_23", "NpcTalkId_24", "NpcTalkId_25", "NpcTalkId_26", "NpcTalkId_27", "NpcTalkId_28", "NpcTalkId_29", "NpcTalkId_30",
			"NpcTalkId_31", "NpcTalkId_32", "IconHeight", "MoveInitType", "Loop"
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
						_0024var_0024DisplayName = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024DisplayName_En = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024Condition_1 = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Condition_2 = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024Condition_3 = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024Condition_4 = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024Condition_5 = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024Condition_6 = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024Condition_7 = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024Condition_8 = MasterBaseClass.ParseInt(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024NotCondition_1 = MasterBaseClass.ParseInt(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024NotCondition_2 = MasterBaseClass.ParseInt(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024NotCondition_3 = MasterBaseClass.ParseInt(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null)
																		{
																			_0024var_0024NotCondition_4 = MasterBaseClass.ParseInt(vals[15]);
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null)
																			{
																				_0024var_0024NotCondition_5 = MasterBaseClass.ParseInt(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null)
																				{
																					_0024var_0024NotCondition_6 = MasterBaseClass.ParseInt(vals[17]);
																				}
																				if (length <= 18)
																				{
																					result = 18;
																				}
																				else
																				{
																					if (vals[18] != null)
																					{
																						_0024var_0024NotCondition_7 = MasterBaseClass.ParseInt(vals[18]);
																					}
																					if (length <= 19)
																					{
																						result = 19;
																					}
																					else
																					{
																						if (vals[19] != null)
																						{
																							_0024var_0024NotCondition_8 = MasterBaseClass.ParseInt(vals[19]);
																						}
																						if (length <= 20)
																						{
																							result = 20;
																						}
																						else
																						{
																							if (vals[20] != null)
																							{
																								_0024var_0024PositionObject = vals[20];
																							}
																							if (length <= 21)
																							{
																								result = 21;
																							}
																							else
																							{
																								if (vals[21] != null)
																								{
																									_0024var_0024SceneObject = vals[21];
																								}
																								if (length <= 22)
																								{
																									result = 22;
																								}
																								else
																								{
																									if (vals[22] != null && typeof(MFlags).IsEnum)
																									{
																										object obj = MasterBaseClass.ParseEnum(vals[22]);
																										if (!(obj is MFlags))
																										{
																											obj = RuntimeServices.Coerce(obj, typeof(MFlags));
																										}
																										_0024var_0024PrefabCond = (MFlags)obj;
																									}
																									if (length <= 23)
																									{
																										result = 23;
																									}
																									else
																									{
																										if (vals[23] != null)
																										{
																											_0024var_0024Prefab = vals[23];
																										}
																										if (length <= 24)
																										{
																											result = 24;
																										}
																										else
																										{
																											if (vals[24] != null)
																											{
																												_0024var_0024AltPrefab = vals[24];
																											}
																											if (length <= 25)
																											{
																												result = 25;
																											}
																											else
																											{
																												if (vals[25] != null)
																												{
																													_0024var_0024DestroySceneObjectIfNotShow = MasterBaseClass.ParseBool(vals[25]);
																												}
																												if (length <= 26)
																												{
																													result = 26;
																												}
																												else
																												{
																													if (vals[26] != null)
																													{
																														_0024var_0024NpcNoDupId = vals[26];
																													}
																													if (length <= 27)
																													{
																														result = 27;
																													}
																													else
																													{
																														if (vals[27] != null)
																														{
																															_0024var_0024Action = vals[27];
																														}
																														if (length <= 28)
																														{
																															result = 28;
																														}
																														else
																														{
																															if (vals[28] != null)
																															{
																																_0024var_0024Pause = MasterBaseClass.ParseBool(vals[28]);
																															}
																															if (length <= 29)
																															{
																																result = 29;
																															}
																															else
																															{
																																if (vals[29] != null)
																																{
																																	_0024var_0024GimmickFlag = MasterBaseClass.ParseInt(vals[29]);
																																}
																																if (length <= 30)
																																{
																																	result = 30;
																																}
																																else
																																{
																																	if (vals[30] != null)
																																	{
																																		_0024var_0024NpcTalkId_1 = MasterBaseClass.ParseInt(vals[30]);
																																	}
																																	if (length <= 31)
																																	{
																																		result = 31;
																																	}
																																	else
																																	{
																																		if (vals[31] != null)
																																		{
																																			_0024var_0024NpcTalkId_2 = MasterBaseClass.ParseInt(vals[31]);
																																		}
																																		if (length <= 32)
																																		{
																																			result = 32;
																																		}
																																		else
																																		{
																																			if (vals[32] != null)
																																			{
																																				_0024var_0024NpcTalkId_3 = MasterBaseClass.ParseInt(vals[32]);
																																			}
																																			if (length <= 33)
																																			{
																																				result = 33;
																																			}
																																			else
																																			{
																																				if (vals[33] != null)
																																				{
																																					_0024var_0024NpcTalkId_4 = MasterBaseClass.ParseInt(vals[33]);
																																				}
																																				if (length <= 34)
																																				{
																																					result = 34;
																																				}
																																				else
																																				{
																																					if (vals[34] != null)
																																					{
																																						_0024var_0024NpcTalkId_5 = MasterBaseClass.ParseInt(vals[34]);
																																					}
																																					if (length <= 35)
																																					{
																																						result = 35;
																																					}
																																					else
																																					{
																																						if (vals[35] != null)
																																						{
																																							_0024var_0024NpcTalkId_6 = MasterBaseClass.ParseInt(vals[35]);
																																						}
																																						if (length <= 36)
																																						{
																																							result = 36;
																																						}
																																						else
																																						{
																																							if (vals[36] != null)
																																							{
																																								_0024var_0024NpcTalkId_7 = MasterBaseClass.ParseInt(vals[36]);
																																							}
																																							if (length <= 37)
																																							{
																																								result = 37;
																																							}
																																							else
																																							{
																																								if (vals[37] != null)
																																								{
																																									_0024var_0024NpcTalkId_8 = MasterBaseClass.ParseInt(vals[37]);
																																								}
																																								if (length <= 38)
																																								{
																																									result = 38;
																																								}
																																								else
																																								{
																																									if (vals[38] != null)
																																									{
																																										_0024var_0024NpcTalkId_9 = MasterBaseClass.ParseInt(vals[38]);
																																									}
																																									if (length <= 39)
																																									{
																																										result = 39;
																																									}
																																									else
																																									{
																																										if (vals[39] != null)
																																										{
																																											_0024var_0024NpcTalkId_10 = MasterBaseClass.ParseInt(vals[39]);
																																										}
																																										if (length <= 40)
																																										{
																																											result = 40;
																																										}
																																										else
																																										{
																																											if (vals[40] != null)
																																											{
																																												_0024var_0024NpcTalkId_11 = MasterBaseClass.ParseInt(vals[40]);
																																											}
																																											if (length <= 41)
																																											{
																																												result = 41;
																																											}
																																											else
																																											{
																																												if (vals[41] != null)
																																												{
																																													_0024var_0024NpcTalkId_12 = MasterBaseClass.ParseInt(vals[41]);
																																												}
																																												if (length <= 42)
																																												{
																																													result = 42;
																																												}
																																												else
																																												{
																																													if (vals[42] != null)
																																													{
																																														_0024var_0024NpcTalkId_13 = MasterBaseClass.ParseInt(vals[42]);
																																													}
																																													if (length <= 43)
																																													{
																																														result = 43;
																																													}
																																													else
																																													{
																																														if (vals[43] != null)
																																														{
																																															_0024var_0024NpcTalkId_14 = MasterBaseClass.ParseInt(vals[43]);
																																														}
																																														if (length <= 44)
																																														{
																																															result = 44;
																																														}
																																														else
																																														{
																																															if (vals[44] != null)
																																															{
																																																_0024var_0024NpcTalkId_15 = MasterBaseClass.ParseInt(vals[44]);
																																															}
																																															if (length <= 45)
																																															{
																																																result = 45;
																																															}
																																															else
																																															{
																																																if (vals[45] != null)
																																																{
																																																	_0024var_0024NpcTalkId_16 = MasterBaseClass.ParseInt(vals[45]);
																																																}
																																																if (length <= 46)
																																																{
																																																	result = 46;
																																																}
																																																else
																																																{
																																																	if (vals[46] != null)
																																																	{
																																																		_0024var_0024NpcTalkId_17 = MasterBaseClass.ParseInt(vals[46]);
																																																	}
																																																	if (length <= 47)
																																																	{
																																																		result = 47;
																																																	}
																																																	else
																																																	{
																																																		if (vals[47] != null)
																																																		{
																																																			_0024var_0024NpcTalkId_18 = MasterBaseClass.ParseInt(vals[47]);
																																																		}
																																																		if (length <= 48)
																																																		{
																																																			result = 48;
																																																		}
																																																		else
																																																		{
																																																			if (vals[48] != null)
																																																			{
																																																				_0024var_0024NpcTalkId_19 = MasterBaseClass.ParseInt(vals[48]);
																																																			}
																																																			if (length <= 49)
																																																			{
																																																				result = 49;
																																																			}
																																																			else
																																																			{
																																																				if (vals[49] != null)
																																																				{
																																																					_0024var_0024NpcTalkId_20 = MasterBaseClass.ParseInt(vals[49]);
																																																				}
																																																				if (length <= 50)
																																																				{
																																																					result = 50;
																																																				}
																																																				else
																																																				{
																																																					if (vals[50] != null)
																																																					{
																																																						_0024var_0024NpcTalkId_21 = MasterBaseClass.ParseInt(vals[50]);
																																																					}
																																																					if (length <= 51)
																																																					{
																																																						result = 51;
																																																					}
																																																					else
																																																					{
																																																						if (vals[51] != null)
																																																						{
																																																							_0024var_0024NpcTalkId_22 = MasterBaseClass.ParseInt(vals[51]);
																																																						}
																																																						if (length <= 52)
																																																						{
																																																							result = 52;
																																																						}
																																																						else
																																																						{
																																																							if (vals[52] != null)
																																																							{
																																																								_0024var_0024NpcTalkId_23 = MasterBaseClass.ParseInt(vals[52]);
																																																							}
																																																							if (length <= 53)
																																																							{
																																																								result = 53;
																																																							}
																																																							else
																																																							{
																																																								if (vals[53] != null)
																																																								{
																																																									_0024var_0024NpcTalkId_24 = MasterBaseClass.ParseInt(vals[53]);
																																																								}
																																																								if (length <= 54)
																																																								{
																																																									result = 54;
																																																								}
																																																								else
																																																								{
																																																									if (vals[54] != null)
																																																									{
																																																										_0024var_0024NpcTalkId_25 = MasterBaseClass.ParseInt(vals[54]);
																																																									}
																																																									if (length <= 55)
																																																									{
																																																										result = 55;
																																																									}
																																																									else
																																																									{
																																																										if (vals[55] != null)
																																																										{
																																																											_0024var_0024NpcTalkId_26 = MasterBaseClass.ParseInt(vals[55]);
																																																										}
																																																										if (length <= 56)
																																																										{
																																																											result = 56;
																																																										}
																																																										else
																																																										{
																																																											if (vals[56] != null)
																																																											{
																																																												_0024var_0024NpcTalkId_27 = MasterBaseClass.ParseInt(vals[56]);
																																																											}
																																																											if (length <= 57)
																																																											{
																																																												result = 57;
																																																											}
																																																											else
																																																											{
																																																												if (vals[57] != null)
																																																												{
																																																													_0024var_0024NpcTalkId_28 = MasterBaseClass.ParseInt(vals[57]);
																																																												}
																																																												if (length <= 58)
																																																												{
																																																													result = 58;
																																																												}
																																																												else
																																																												{
																																																													if (vals[58] != null)
																																																													{
																																																														_0024var_0024NpcTalkId_29 = MasterBaseClass.ParseInt(vals[58]);
																																																													}
																																																													if (length <= 59)
																																																													{
																																																														result = 59;
																																																													}
																																																													else
																																																													{
																																																														if (vals[59] != null)
																																																														{
																																																															_0024var_0024NpcTalkId_30 = MasterBaseClass.ParseInt(vals[59]);
																																																														}
																																																														if (length <= 60)
																																																														{
																																																															result = 60;
																																																														}
																																																														else
																																																														{
																																																															if (vals[60] != null)
																																																															{
																																																																_0024var_0024NpcTalkId_31 = MasterBaseClass.ParseInt(vals[60]);
																																																															}
																																																															if (length <= 61)
																																																															{
																																																																result = 61;
																																																															}
																																																															else
																																																															{
																																																																if (vals[61] != null)
																																																																{
																																																																	_0024var_0024NpcTalkId_32 = MasterBaseClass.ParseInt(vals[61]);
																																																																}
																																																																if (length <= 62)
																																																																{
																																																																	result = 62;
																																																																}
																																																																else
																																																																{
																																																																	if (vals[62] != null)
																																																																	{
																																																																		_0024var_0024IconHeight = MasterBaseClass.ParseSingle(vals[62]);
																																																																	}
																																																																	if (length <= 63)
																																																																	{
																																																																		result = 63;
																																																																	}
																																																																	else
																																																																	{
																																																																		if (vals[63] != null && typeof(EnumNPCMoveInitTypes).IsEnum)
																																																																		{
																																																																			_0024var_0024MoveInitType = (EnumNPCMoveInitTypes)MasterBaseClass.ParseEnum(vals[63]);
																																																																		}
																																																																		if (length <= 64)
																																																																		{
																																																																			result = 64;
																																																																		}
																																																																		else
																																																																		{
																																																																			if (vals[64] != null)
																																																																			{
																																																																				_0024var_0024Loop = MasterBaseClass.ParseBool(vals[64]);
																																																																			}
																																																																			int num = 65;
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
		return result;
	}

	internal bool _0024get_AllNotConditions_0024closure_0024249(MFlags m)
	{
		return m != null;
	}
}
