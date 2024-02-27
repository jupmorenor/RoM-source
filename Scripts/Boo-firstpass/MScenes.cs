using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class MScenes : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	public int _0024var_0024MAreaId;

	public int _0024var_0024MQuestId;

	public string _0024var_0024SceneName;

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

	public DateTime _0024var_0024BeginPeriod;

	public DateTime _0024var_0024EndPeriod;

	public int _0024var_0024TempFlag;

	public int _0024var_0024ExtMScenes;

	public int _0024var_0024StageBattleId_1;

	public int _0024var_0024StageBattleId_2;

	public int _0024var_0024StageBattleId_3;

	public int _0024var_0024StageBattleId_4;

	public int _0024var_0024StageBattleId_5;

	public int _0024var_0024StageBattleId_6;

	public int _0024var_0024StageBattleId_7;

	public int _0024var_0024StageBattleId_8;

	public int _0024var_0024NpcId_1;

	public int _0024var_0024NpcId_2;

	public int _0024var_0024NpcId_3;

	public int _0024var_0024NpcId_4;

	public int _0024var_0024NpcId_5;

	public int _0024var_0024NpcId_6;

	public int _0024var_0024NpcId_7;

	public int _0024var_0024NpcId_8;

	public int _0024var_0024NpcId_9;

	public int _0024var_0024NpcId_10;

	public int _0024var_0024NpcId_11;

	public int _0024var_0024NpcId_12;

	public int _0024var_0024NpcId_13;

	public int _0024var_0024NpcId_14;

	public int _0024var_0024NpcId_15;

	public int _0024var_0024NpcId_16;

	public int _0024var_0024NpcId_17;

	public int _0024var_0024NpcId_18;

	public int _0024var_0024NpcId_19;

	public int _0024var_0024NpcId_20;

	public int _0024var_0024NpcId_21;

	public int _0024var_0024NpcId_22;

	public int _0024var_0024NpcId_23;

	public int _0024var_0024NpcId_24;

	public string _0024var_0024KusamushiPos_1;

	public string _0024var_0024KusamushiPos_2;

	public string _0024var_0024KusamushiPos_3;

	public string _0024var_0024KusamushiPos_4;

	public string _0024var_0024KusamushiPos_5;

	public string _0024var_0024KusamushiPos_6;

	public string _0024var_0024KusamushiPos_7;

	public string _0024var_0024KusamushiPos_8;

	public int _0024var_0024N;

	public int _0024var_0024NE;

	public int _0024var_0024E;

	public int _0024var_0024SE;

	public int _0024var_0024S;

	public int _0024var_0024SW;

	public int _0024var_0024W;

	public int _0024var_0024NW;

	public EnumMapLinkDir _0024var_0024DirN;

	public EnumMapLinkDir _0024var_0024DirNE;

	public EnumMapLinkDir _0024var_0024DirE;

	public EnumMapLinkDir _0024var_0024DirSE;

	public EnumMapLinkDir _0024var_0024DirS;

	public EnumMapLinkDir _0024var_0024DirSW;

	public EnumMapLinkDir _0024var_0024DirW;

	public EnumMapLinkDir _0024var_0024DirNW;

	public bool _0024var_0024BlockN;

	public bool _0024var_0024BlockNE;

	public bool _0024var_0024BlockE;

	public bool _0024var_0024BlockSE;

	public bool _0024var_0024BlockS;

	public bool _0024var_0024BlockSW;

	public bool _0024var_0024BlockW;

	public bool _0024var_0024BlockNW;

	public int _0024var_0024SeId_1;

	public int _0024var_0024SeId_2;

	public int _0024var_0024SeId_3;

	public int _0024var_0024SeId_4;

	public int _0024var_0024SeId_5;

	public int _0024var_0024SeId_6;

	public int _0024var_0024SeId_7;

	public int _0024var_0024SeId_8;

	[NonSerialized]
	private MAreas MAreaId__cache;

	[NonSerialized]
	private MQuests MQuestId__cache;

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
	private MFlags TempFlag__cache;

	[NonSerialized]
	private MScenes ExtMScenes__cache;

	[NonSerialized]
	private MStageBattles StageBattleId_1__cache;

	[NonSerialized]
	private MStageBattles StageBattleId_2__cache;

	[NonSerialized]
	private MStageBattles StageBattleId_3__cache;

	[NonSerialized]
	private MStageBattles StageBattleId_4__cache;

	[NonSerialized]
	private MStageBattles StageBattleId_5__cache;

	[NonSerialized]
	private MStageBattles StageBattleId_6__cache;

	[NonSerialized]
	private MStageBattles StageBattleId_7__cache;

	[NonSerialized]
	private MStageBattles StageBattleId_8__cache;

	[NonSerialized]
	private MNpcs NpcId_1__cache;

	[NonSerialized]
	private MNpcs NpcId_2__cache;

	[NonSerialized]
	private MNpcs NpcId_3__cache;

	[NonSerialized]
	private MNpcs NpcId_4__cache;

	[NonSerialized]
	private MNpcs NpcId_5__cache;

	[NonSerialized]
	private MNpcs NpcId_6__cache;

	[NonSerialized]
	private MNpcs NpcId_7__cache;

	[NonSerialized]
	private MNpcs NpcId_8__cache;

	[NonSerialized]
	private MNpcs NpcId_9__cache;

	[NonSerialized]
	private MNpcs NpcId_10__cache;

	[NonSerialized]
	private MNpcs NpcId_11__cache;

	[NonSerialized]
	private MNpcs NpcId_12__cache;

	[NonSerialized]
	private MNpcs NpcId_13__cache;

	[NonSerialized]
	private MNpcs NpcId_14__cache;

	[NonSerialized]
	private MNpcs NpcId_15__cache;

	[NonSerialized]
	private MNpcs NpcId_16__cache;

	[NonSerialized]
	private MNpcs NpcId_17__cache;

	[NonSerialized]
	private MNpcs NpcId_18__cache;

	[NonSerialized]
	private MNpcs NpcId_19__cache;

	[NonSerialized]
	private MNpcs NpcId_20__cache;

	[NonSerialized]
	private MNpcs NpcId_21__cache;

	[NonSerialized]
	private MNpcs NpcId_22__cache;

	[NonSerialized]
	private MNpcs NpcId_23__cache;

	[NonSerialized]
	private MNpcs NpcId_24__cache;

	[NonSerialized]
	private MScenes N__cache;

	[NonSerialized]
	private MScenes NE__cache;

	[NonSerialized]
	private MScenes E__cache;

	[NonSerialized]
	private MScenes SE__cache;

	[NonSerialized]
	private MScenes S__cache;

	[NonSerialized]
	private MScenes SW__cache;

	[NonSerialized]
	private MScenes W__cache;

	[NonSerialized]
	private MScenes NW__cache;

	[NonSerialized]
	private MSe SeId_1__cache;

	[NonSerialized]
	private MSe SeId_2__cache;

	[NonSerialized]
	private MSe SeId_3__cache;

	[NonSerialized]
	private MSe SeId_4__cache;

	[NonSerialized]
	private MSe SeId_5__cache;

	[NonSerialized]
	private MSe SeId_6__cache;

	[NonSerialized]
	private MSe SeId_7__cache;

	[NonSerialized]
	private MSe SeId_8__cache;

	[NonSerialized]
	private static Dictionary<int, MScenes> _0024mst_002465 = new Dictionary<int, MScenes>();

	[NonSerialized]
	private static MScenes[] All_cache;

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

	public MStageBattles[] AllStageBattles
	{
		get
		{
			System.Collections.Generic.List<MStageBattles> list = new System.Collections.Generic.List<MStageBattles>();
			if (StageBattleId_1 != null)
			{
				list.Add(StageBattleId_1);
			}
			if (StageBattleId_2 != null)
			{
				list.Add(StageBattleId_2);
			}
			if (StageBattleId_3 != null)
			{
				list.Add(StageBattleId_3);
			}
			if (StageBattleId_4 != null)
			{
				list.Add(StageBattleId_4);
			}
			if (StageBattleId_5 != null)
			{
				list.Add(StageBattleId_5);
			}
			if (StageBattleId_6 != null)
			{
				list.Add(StageBattleId_6);
			}
			if (StageBattleId_7 != null)
			{
				list.Add(StageBattleId_7);
			}
			if (StageBattleId_8 != null)
			{
				list.Add(StageBattleId_8);
			}
			return list.ToArray();
		}
	}

	public MNpcs[] AllNpcs
	{
		get
		{
			System.Collections.Generic.List<MNpcs> list = new System.Collections.Generic.List<MNpcs>();
			if (NpcId_1 != null)
			{
				list.Add(NpcId_1);
			}
			if (NpcId_2 != null)
			{
				list.Add(NpcId_2);
			}
			if (NpcId_3 != null)
			{
				list.Add(NpcId_3);
			}
			if (NpcId_4 != null)
			{
				list.Add(NpcId_4);
			}
			if (NpcId_5 != null)
			{
				list.Add(NpcId_5);
			}
			if (NpcId_6 != null)
			{
				list.Add(NpcId_6);
			}
			if (NpcId_7 != null)
			{
				list.Add(NpcId_7);
			}
			if (NpcId_8 != null)
			{
				list.Add(NpcId_8);
			}
			if (NpcId_9 != null)
			{
				list.Add(NpcId_9);
			}
			if (NpcId_10 != null)
			{
				list.Add(NpcId_10);
			}
			if (NpcId_11 != null)
			{
				list.Add(NpcId_11);
			}
			if (NpcId_12 != null)
			{
				list.Add(NpcId_12);
			}
			if (NpcId_13 != null)
			{
				list.Add(NpcId_13);
			}
			if (NpcId_14 != null)
			{
				list.Add(NpcId_14);
			}
			if (NpcId_15 != null)
			{
				list.Add(NpcId_15);
			}
			if (NpcId_16 != null)
			{
				list.Add(NpcId_16);
			}
			if (NpcId_17 != null)
			{
				list.Add(NpcId_17);
			}
			if (NpcId_18 != null)
			{
				list.Add(NpcId_18);
			}
			if (NpcId_19 != null)
			{
				list.Add(NpcId_19);
			}
			if (NpcId_20 != null)
			{
				list.Add(NpcId_20);
			}
			if (NpcId_21 != null)
			{
				list.Add(NpcId_21);
			}
			if (NpcId_22 != null)
			{
				list.Add(NpcId_22);
			}
			if (NpcId_23 != null)
			{
				list.Add(NpcId_23);
			}
			if (NpcId_24 != null)
			{
				list.Add(NpcId_24);
			}
			return list.ToArray();
		}
	}

	public string[] KusamushiPositions
	{
		get
		{
			System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
			string text = _0024get_KusamushiPositions_0024closure_0024250(KusamushiPos_1) as string;
			if (text != null)
			{
				list.Add(text);
			}
			text = _0024get_KusamushiPositions_0024closure_0024251(KusamushiPos_2) as string;
			if (text != null)
			{
				list.Add(text);
			}
			text = _0024get_KusamushiPositions_0024closure_0024252(KusamushiPos_3) as string;
			if (text != null)
			{
				list.Add(text);
			}
			text = _0024get_KusamushiPositions_0024closure_0024253(KusamushiPos_4) as string;
			if (text != null)
			{
				list.Add(text);
			}
			text = _0024get_KusamushiPositions_0024closure_0024254(KusamushiPos_5) as string;
			if (text != null)
			{
				list.Add(text);
			}
			text = _0024get_KusamushiPositions_0024closure_0024255(KusamushiPos_6) as string;
			if (text != null)
			{
				list.Add(text);
			}
			text = _0024get_KusamushiPositions_0024closure_0024256(KusamushiPos_7) as string;
			if (text != null)
			{
				list.Add(text);
			}
			text = _0024get_KusamushiPositions_0024closure_0024257(KusamushiPos_8) as string;
			if (text != null)
			{
				list.Add(text);
			}
			return list.ToArray();
		}
	}

	public bool HasKusamushiPositions => KusamushiPositions.Length > 0;

	public Vector3[] KusamushiPositionsAsVector3
	{
		get
		{
			__MScenes_get_KusamushiPositionsAsVector3_0024callable25_00241343_17__ _MScenes_get_KusamushiPositionsAsVector3_0024callable25_00241343_17__ = delegate(string s)
			{
				string[] array = s.Split(',');
				try
				{
					float[] array2 = new float[array.Length];
					int num2 = 0;
					int length2 = array.Length;
					if (length2 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num2 < length2)
					{
						int index = num2;
						num2++;
						array2[RuntimeServices.NormalizeArrayIndex(array2, index)] = float.Parse(array[RuntimeServices.NormalizeArrayIndex(array, index)]);
					}
					int length3 = array2.Length;
					Vector3 result = default(Vector3);
					if (length3 >= 1)
					{
						result.x = array2[0];
					}
					if (length3 >= 2)
					{
						result.y = array2[1];
					}
					if (length3 >= 3)
					{
						result.z = array2[2];
					}
					return result;
				}
				catch (Exception)
				{
					string message = new StringBuilder("position string format error: '").Append(s).Append("'").ToString();
					throw new Exception(message);
				}
			};
			System.Collections.Generic.List<Vector3> list = new System.Collections.Generic.List<Vector3>();
			string[] kusamushiPositions = KusamushiPositions;
			int length = kusamushiPositions.Length;
			int num = 0;
			while (num < length)
			{
				string s2 = kusamushiPositions[RuntimeServices.NormalizeArrayIndex(kusamushiPositions, checked(num++))];
				list.Add(_MScenes_get_KusamushiPositionsAsVector3_0024callable25_00241343_17__(s2));
			}
			return list.ToArray();
		}
	}

	public MSe[] AllSe
	{
		get
		{
			System.Collections.Generic.List<MSe> list = new System.Collections.Generic.List<MSe>();
			if (SeId_1 != null)
			{
				list.Add(SeId_1);
			}
			if (SeId_2 != null)
			{
				list.Add(SeId_2);
			}
			if (SeId_3 != null)
			{
				list.Add(SeId_3);
			}
			if (SeId_4 != null)
			{
				list.Add(SeId_4);
			}
			if (SeId_5 != null)
			{
				list.Add(SeId_5);
			}
			if (SeId_6 != null)
			{
				list.Add(SeId_6);
			}
			if (SeId_7 != null)
			{
				list.Add(SeId_7);
			}
			if (SeId_8 != null)
			{
				list.Add(SeId_8);
			}
			return list.ToArray();
		}
	}

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

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

	public MQuests MQuestId
	{
		get
		{
			if (MQuestId__cache == null)
			{
				MQuestId__cache = MQuests.Get(_0024var_0024MQuestId);
			}
			return MQuestId__cache;
		}
	}

	public string SceneName => _0024var_0024SceneName;

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

	public DateTime BeginPeriod => _0024var_0024BeginPeriod;

	public DateTime EndPeriod => _0024var_0024EndPeriod;

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

	public MScenes ExtMScenes
	{
		get
		{
			if (ExtMScenes__cache == null)
			{
				ExtMScenes__cache = Get(_0024var_0024ExtMScenes);
			}
			return ExtMScenes__cache;
		}
	}

	public MStageBattles StageBattleId_1
	{
		get
		{
			if (StageBattleId_1__cache == null)
			{
				StageBattleId_1__cache = MStageBattles.Get(_0024var_0024StageBattleId_1);
			}
			return StageBattleId_1__cache;
		}
	}

	public MStageBattles StageBattleId_2
	{
		get
		{
			if (StageBattleId_2__cache == null)
			{
				StageBattleId_2__cache = MStageBattles.Get(_0024var_0024StageBattleId_2);
			}
			return StageBattleId_2__cache;
		}
	}

	public MStageBattles StageBattleId_3
	{
		get
		{
			if (StageBattleId_3__cache == null)
			{
				StageBattleId_3__cache = MStageBattles.Get(_0024var_0024StageBattleId_3);
			}
			return StageBattleId_3__cache;
		}
	}

	public MStageBattles StageBattleId_4
	{
		get
		{
			if (StageBattleId_4__cache == null)
			{
				StageBattleId_4__cache = MStageBattles.Get(_0024var_0024StageBattleId_4);
			}
			return StageBattleId_4__cache;
		}
	}

	public MStageBattles StageBattleId_5
	{
		get
		{
			if (StageBattleId_5__cache == null)
			{
				StageBattleId_5__cache = MStageBattles.Get(_0024var_0024StageBattleId_5);
			}
			return StageBattleId_5__cache;
		}
	}

	public MStageBattles StageBattleId_6
	{
		get
		{
			if (StageBattleId_6__cache == null)
			{
				StageBattleId_6__cache = MStageBattles.Get(_0024var_0024StageBattleId_6);
			}
			return StageBattleId_6__cache;
		}
	}

	public MStageBattles StageBattleId_7
	{
		get
		{
			if (StageBattleId_7__cache == null)
			{
				StageBattleId_7__cache = MStageBattles.Get(_0024var_0024StageBattleId_7);
			}
			return StageBattleId_7__cache;
		}
	}

	public MStageBattles StageBattleId_8
	{
		get
		{
			if (StageBattleId_8__cache == null)
			{
				StageBattleId_8__cache = MStageBattles.Get(_0024var_0024StageBattleId_8);
			}
			return StageBattleId_8__cache;
		}
	}

	public MNpcs NpcId_1
	{
		get
		{
			if (NpcId_1__cache == null)
			{
				NpcId_1__cache = MNpcs.Get(_0024var_0024NpcId_1);
			}
			return NpcId_1__cache;
		}
	}

	public MNpcs NpcId_2
	{
		get
		{
			if (NpcId_2__cache == null)
			{
				NpcId_2__cache = MNpcs.Get(_0024var_0024NpcId_2);
			}
			return NpcId_2__cache;
		}
	}

	public MNpcs NpcId_3
	{
		get
		{
			if (NpcId_3__cache == null)
			{
				NpcId_3__cache = MNpcs.Get(_0024var_0024NpcId_3);
			}
			return NpcId_3__cache;
		}
	}

	public MNpcs NpcId_4
	{
		get
		{
			if (NpcId_4__cache == null)
			{
				NpcId_4__cache = MNpcs.Get(_0024var_0024NpcId_4);
			}
			return NpcId_4__cache;
		}
	}

	public MNpcs NpcId_5
	{
		get
		{
			if (NpcId_5__cache == null)
			{
				NpcId_5__cache = MNpcs.Get(_0024var_0024NpcId_5);
			}
			return NpcId_5__cache;
		}
	}

	public MNpcs NpcId_6
	{
		get
		{
			if (NpcId_6__cache == null)
			{
				NpcId_6__cache = MNpcs.Get(_0024var_0024NpcId_6);
			}
			return NpcId_6__cache;
		}
	}

	public MNpcs NpcId_7
	{
		get
		{
			if (NpcId_7__cache == null)
			{
				NpcId_7__cache = MNpcs.Get(_0024var_0024NpcId_7);
			}
			return NpcId_7__cache;
		}
	}

	public MNpcs NpcId_8
	{
		get
		{
			if (NpcId_8__cache == null)
			{
				NpcId_8__cache = MNpcs.Get(_0024var_0024NpcId_8);
			}
			return NpcId_8__cache;
		}
	}

	public MNpcs NpcId_9
	{
		get
		{
			if (NpcId_9__cache == null)
			{
				NpcId_9__cache = MNpcs.Get(_0024var_0024NpcId_9);
			}
			return NpcId_9__cache;
		}
	}

	public MNpcs NpcId_10
	{
		get
		{
			if (NpcId_10__cache == null)
			{
				NpcId_10__cache = MNpcs.Get(_0024var_0024NpcId_10);
			}
			return NpcId_10__cache;
		}
	}

	public MNpcs NpcId_11
	{
		get
		{
			if (NpcId_11__cache == null)
			{
				NpcId_11__cache = MNpcs.Get(_0024var_0024NpcId_11);
			}
			return NpcId_11__cache;
		}
	}

	public MNpcs NpcId_12
	{
		get
		{
			if (NpcId_12__cache == null)
			{
				NpcId_12__cache = MNpcs.Get(_0024var_0024NpcId_12);
			}
			return NpcId_12__cache;
		}
	}

	public MNpcs NpcId_13
	{
		get
		{
			if (NpcId_13__cache == null)
			{
				NpcId_13__cache = MNpcs.Get(_0024var_0024NpcId_13);
			}
			return NpcId_13__cache;
		}
	}

	public MNpcs NpcId_14
	{
		get
		{
			if (NpcId_14__cache == null)
			{
				NpcId_14__cache = MNpcs.Get(_0024var_0024NpcId_14);
			}
			return NpcId_14__cache;
		}
	}

	public MNpcs NpcId_15
	{
		get
		{
			if (NpcId_15__cache == null)
			{
				NpcId_15__cache = MNpcs.Get(_0024var_0024NpcId_15);
			}
			return NpcId_15__cache;
		}
	}

	public MNpcs NpcId_16
	{
		get
		{
			if (NpcId_16__cache == null)
			{
				NpcId_16__cache = MNpcs.Get(_0024var_0024NpcId_16);
			}
			return NpcId_16__cache;
		}
	}

	public MNpcs NpcId_17
	{
		get
		{
			if (NpcId_17__cache == null)
			{
				NpcId_17__cache = MNpcs.Get(_0024var_0024NpcId_17);
			}
			return NpcId_17__cache;
		}
	}

	public MNpcs NpcId_18
	{
		get
		{
			if (NpcId_18__cache == null)
			{
				NpcId_18__cache = MNpcs.Get(_0024var_0024NpcId_18);
			}
			return NpcId_18__cache;
		}
	}

	public MNpcs NpcId_19
	{
		get
		{
			if (NpcId_19__cache == null)
			{
				NpcId_19__cache = MNpcs.Get(_0024var_0024NpcId_19);
			}
			return NpcId_19__cache;
		}
	}

	public MNpcs NpcId_20
	{
		get
		{
			if (NpcId_20__cache == null)
			{
				NpcId_20__cache = MNpcs.Get(_0024var_0024NpcId_20);
			}
			return NpcId_20__cache;
		}
	}

	public MNpcs NpcId_21
	{
		get
		{
			if (NpcId_21__cache == null)
			{
				NpcId_21__cache = MNpcs.Get(_0024var_0024NpcId_21);
			}
			return NpcId_21__cache;
		}
	}

	public MNpcs NpcId_22
	{
		get
		{
			if (NpcId_22__cache == null)
			{
				NpcId_22__cache = MNpcs.Get(_0024var_0024NpcId_22);
			}
			return NpcId_22__cache;
		}
	}

	public MNpcs NpcId_23
	{
		get
		{
			if (NpcId_23__cache == null)
			{
				NpcId_23__cache = MNpcs.Get(_0024var_0024NpcId_23);
			}
			return NpcId_23__cache;
		}
	}

	public MNpcs NpcId_24
	{
		get
		{
			if (NpcId_24__cache == null)
			{
				NpcId_24__cache = MNpcs.Get(_0024var_0024NpcId_24);
			}
			return NpcId_24__cache;
		}
	}

	public string KusamushiPos_1 => _0024var_0024KusamushiPos_1;

	public string KusamushiPos_2 => _0024var_0024KusamushiPos_2;

	public string KusamushiPos_3 => _0024var_0024KusamushiPos_3;

	public string KusamushiPos_4 => _0024var_0024KusamushiPos_4;

	public string KusamushiPos_5 => _0024var_0024KusamushiPos_5;

	public string KusamushiPos_6 => _0024var_0024KusamushiPos_6;

	public string KusamushiPos_7 => _0024var_0024KusamushiPos_7;

	public string KusamushiPos_8 => _0024var_0024KusamushiPos_8;

	public MScenes N
	{
		get
		{
			if (N__cache == null)
			{
				N__cache = Get(_0024var_0024N);
			}
			return N__cache;
		}
	}

	public MScenes NE
	{
		get
		{
			if (NE__cache == null)
			{
				NE__cache = Get(_0024var_0024NE);
			}
			return NE__cache;
		}
	}

	public MScenes E
	{
		get
		{
			if (E__cache == null)
			{
				E__cache = Get(_0024var_0024E);
			}
			return E__cache;
		}
	}

	public MScenes SE
	{
		get
		{
			if (SE__cache == null)
			{
				SE__cache = Get(_0024var_0024SE);
			}
			return SE__cache;
		}
	}

	public MScenes S
	{
		get
		{
			if (S__cache == null)
			{
				S__cache = Get(_0024var_0024S);
			}
			return S__cache;
		}
	}

	public MScenes SW
	{
		get
		{
			if (SW__cache == null)
			{
				SW__cache = Get(_0024var_0024SW);
			}
			return SW__cache;
		}
	}

	public MScenes W
	{
		get
		{
			if (W__cache == null)
			{
				W__cache = Get(_0024var_0024W);
			}
			return W__cache;
		}
	}

	public MScenes NW
	{
		get
		{
			if (NW__cache == null)
			{
				NW__cache = Get(_0024var_0024NW);
			}
			return NW__cache;
		}
	}

	public EnumMapLinkDir DirN => _0024var_0024DirN;

	public EnumMapLinkDir DirNE => _0024var_0024DirNE;

	public EnumMapLinkDir DirE => _0024var_0024DirE;

	public EnumMapLinkDir DirSE => _0024var_0024DirSE;

	public EnumMapLinkDir DirS => _0024var_0024DirS;

	public EnumMapLinkDir DirSW => _0024var_0024DirSW;

	public EnumMapLinkDir DirW => _0024var_0024DirW;

	public EnumMapLinkDir DirNW => _0024var_0024DirNW;

	public bool BlockN => _0024var_0024BlockN;

	public bool BlockNE => _0024var_0024BlockNE;

	public bool BlockE => _0024var_0024BlockE;

	public bool BlockSE => _0024var_0024BlockSE;

	public bool BlockS => _0024var_0024BlockS;

	public bool BlockSW => _0024var_0024BlockSW;

	public bool BlockW => _0024var_0024BlockW;

	public bool BlockNW => _0024var_0024BlockNW;

	public MSe SeId_1
	{
		get
		{
			if (SeId_1__cache == null)
			{
				SeId_1__cache = MSe.Get(_0024var_0024SeId_1);
			}
			return SeId_1__cache;
		}
	}

	public MSe SeId_2
	{
		get
		{
			if (SeId_2__cache == null)
			{
				SeId_2__cache = MSe.Get(_0024var_0024SeId_2);
			}
			return SeId_2__cache;
		}
	}

	public MSe SeId_3
	{
		get
		{
			if (SeId_3__cache == null)
			{
				SeId_3__cache = MSe.Get(_0024var_0024SeId_3);
			}
			return SeId_3__cache;
		}
	}

	public MSe SeId_4
	{
		get
		{
			if (SeId_4__cache == null)
			{
				SeId_4__cache = MSe.Get(_0024var_0024SeId_4);
			}
			return SeId_4__cache;
		}
	}

	public MSe SeId_5
	{
		get
		{
			if (SeId_5__cache == null)
			{
				SeId_5__cache = MSe.Get(_0024var_0024SeId_5);
			}
			return SeId_5__cache;
		}
	}

	public MSe SeId_6
	{
		get
		{
			if (SeId_6__cache == null)
			{
				SeId_6__cache = MSe.Get(_0024var_0024SeId_6);
			}
			return SeId_6__cache;
		}
	}

	public MSe SeId_7
	{
		get
		{
			if (SeId_7__cache == null)
			{
				SeId_7__cache = MSe.Get(_0024var_0024SeId_7);
			}
			return SeId_7__cache;
		}
	}

	public MSe SeId_8
	{
		get
		{
			if (SeId_8__cache == null)
			{
				SeId_8__cache = MSe.Get(_0024var_0024SeId_8);
			}
			return SeId_8__cache;
		}
	}

	public static MScenes[] All
	{
		get
		{
			MScenes[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MScenes");
				MScenes[] array = (MScenes[])Builtins.array(typeof(MScenes), _0024mst_002465.Values);
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

	public MScenes()
	{
		_0024var_0024BeginPeriod = DateTime.Parse("1999/01/01");
		_0024var_0024EndPeriod = DateTime.Parse("2099/01/01");
		_0024var_0024KusamushiPos_1 = string.Empty;
		_0024var_0024KusamushiPos_2 = string.Empty;
		_0024var_0024KusamushiPos_3 = string.Empty;
		_0024var_0024KusamushiPos_4 = string.Empty;
		_0024var_0024KusamushiPos_5 = string.Empty;
		_0024var_0024KusamushiPos_6 = string.Empty;
		_0024var_0024KusamushiPos_7 = string.Empty;
		_0024var_0024KusamushiPos_8 = string.Empty;
		_0024var_0024BlockN = true;
		_0024var_0024BlockNE = true;
		_0024var_0024BlockE = true;
		_0024var_0024BlockSE = true;
		_0024var_0024BlockS = true;
		_0024var_0024BlockSW = true;
		_0024var_0024BlockW = true;
		_0024var_0024BlockNW = true;
		_0024var_0024SeId_1 = -1;
		_0024var_0024SeId_2 = -1;
		_0024var_0024SeId_3 = -1;
		_0024var_0024SeId_4 = -1;
		_0024var_0024SeId_5 = -1;
		_0024var_0024SeId_6 = -1;
		_0024var_0024SeId_7 = -1;
		_0024var_0024SeId_8 = -1;
	}

	public MScenes[] links()
	{
		return new MScenes[8] { N, NE, E, SE, S, SW, W, NW };
	}

	public MScenes linkTo(EnumMapLinkDir dir)
	{
		int num = (int)checked(dir - 1);
		MScenes[] array = new MScenes[8] { N, NE, E, SE, S, SW, W, NW };
		object result;
		if (0 <= num && num < array.Length)
		{
			result = array[RuntimeServices.NormalizeArrayIndex(array, num)];
		}
		else
		{
			result = null;
		}
		return (MScenes)result;
	}

	public EnumMapLinkDir linkToDir(EnumMapLinkDir dir)
	{
		int num = (int)checked(dir - 1);
		EnumMapLinkDir[] array = new EnumMapLinkDir[8] { DirN, DirNE, DirE, DirSE, DirS, DirSW, DirW, DirNW };
		object obj;
		if (0 <= num && num < array.Length)
		{
			obj = array[RuntimeServices.NormalizeArrayIndex(array, num)];
		}
		else
		{
			obj = 0;
		}
		return (EnumMapLinkDir)obj;
	}

	public bool isBlocked(EnumMapLinkDir dir)
	{
		int num = (int)checked(dir - 1);
		bool[] array = new bool[8] { BlockN, BlockNE, BlockE, BlockSE, BlockS, BlockSW, BlockW, BlockNW };
		int result;
		if (0 <= num && num < array.Length)
		{
			result = (array[RuntimeServices.NormalizeArrayIndex(array, num)] ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public override string ToString()
	{
		return new StringBuilder("MScenes(").Append((object)Id).Append(",").Append(Progname)
			.Append(",")
			.Append(SceneName)
			.Append(")")
			.ToString();
	}

	public MScenes[] collectAllLinkedScenes()
	{
		return (MScenes[])Builtins.array(typeof(MScenes), collectAllLinkedScenes(new HashSet<MScenes>()));
	}

	public HashSet<MScenes> collectAllLinkedScenes(HashSet<MScenes> collection)
	{
		collection.Add(this);
		collectAllLinkedScenesFromNPCWarp(collection);
		int i = 0;
		MScenes[] array = new MScenes[8] { N, NE, E, SE, S, SW, W, NW };
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null && !collection.Contains(array[i]))
			{
				array[i].collectAllLinkedScenes(collection);
			}
		}
		return collection;
	}

	private void collectAllLinkedScenesFromNPCWarp(HashSet<MScenes> collection)
	{
		int i = 0;
		MNpcs[] allNpcs = AllNpcs;
		checked
		{
			for (int length = allNpcs.Length; i < length; i++)
			{
				int j = 0;
				MNpcTalks[] allNpcTalks = allNpcs[i].AllNpcTalks;
				for (int length2 = allNpcTalks.Length; j < length2; j++)
				{
					if (allNpcTalks[j] != null && allNpcTalks[j].Warp != null)
					{
						MScenes sceneToWarp = allNpcTalks[j].Warp.SceneToWarp;
						if (sceneToWarp != null && !collection.Contains(sceneToWarp))
						{
							sceneToWarp.collectAllLinkedScenes(collection);
						}
					}
				}
			}
		}
	}

	public static MScenes Get(int _id)
	{
		MerlinMaster.GetHandler("MScenes");
		return (!_0024mst_002465.ContainsKey(_id)) ? null : _0024mst_002465[_id];
	}

	public static void Unload()
	{
		_0024mst_002465.Clear();
		All_cache = null;
	}

	public static MScenes New(Hashtable data)
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
			MScenes mScenes = Create(data);
			if (!_0024mst_002465.ContainsKey(mScenes.Id))
			{
				_0024mst_002465[mScenes.Id] = mScenes;
			}
			result = mScenes;
		}
		return (MScenes)result;
	}

	public static MScenes New2(string[] keys, object[] vals)
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
		return (MScenes)result;
	}

	public static MScenes Entry(MScenes mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002465[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MScenes)result;
	}

	public static void AddMst(MScenes mst)
	{
		if (mst != null)
		{
			_0024mst_002465[mst.Id] = mst;
		}
	}

	public static MScenes Create(Hashtable data)
	{
		MScenes mScenes = new MScenes();
		MScenes result;
		if (data == null)
		{
			result = mScenes;
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
				mScenes.setField((string)obj, data[current]);
			}
			result = mScenes;
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
		case "MAreaId":
			_0024var_0024MAreaId = MasterBaseClass.ToInt(val);
			break;
		case "MQuestId":
			_0024var_0024MQuestId = MasterBaseClass.ToInt(val);
			break;
		case "SceneName":
			_0024var_0024SceneName = MasterBaseClass.ToStringValue(val);
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
		case "BeginPeriod":
		{
			object obj2 = val;
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			_0024var_0024BeginPeriod = DateTime.Parse((string)obj2);
			break;
		}
		case "EndPeriod":
		{
			object obj = val;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			_0024var_0024EndPeriod = DateTime.Parse((string)obj);
			break;
		}
		case "TempFlag":
			_0024var_0024TempFlag = MasterBaseClass.ToInt(val);
			break;
		case "ExtMScenes":
			_0024var_0024ExtMScenes = MasterBaseClass.ToInt(val);
			break;
		case "StageBattleId_1":
			_0024var_0024StageBattleId_1 = MasterBaseClass.ToInt(val);
			break;
		case "StageBattleId_2":
			_0024var_0024StageBattleId_2 = MasterBaseClass.ToInt(val);
			break;
		case "StageBattleId_3":
			_0024var_0024StageBattleId_3 = MasterBaseClass.ToInt(val);
			break;
		case "StageBattleId_4":
			_0024var_0024StageBattleId_4 = MasterBaseClass.ToInt(val);
			break;
		case "StageBattleId_5":
			_0024var_0024StageBattleId_5 = MasterBaseClass.ToInt(val);
			break;
		case "StageBattleId_6":
			_0024var_0024StageBattleId_6 = MasterBaseClass.ToInt(val);
			break;
		case "StageBattleId_7":
			_0024var_0024StageBattleId_7 = MasterBaseClass.ToInt(val);
			break;
		case "StageBattleId_8":
			_0024var_0024StageBattleId_8 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_1":
			_0024var_0024NpcId_1 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_2":
			_0024var_0024NpcId_2 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_3":
			_0024var_0024NpcId_3 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_4":
			_0024var_0024NpcId_4 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_5":
			_0024var_0024NpcId_5 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_6":
			_0024var_0024NpcId_6 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_7":
			_0024var_0024NpcId_7 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_8":
			_0024var_0024NpcId_8 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_9":
			_0024var_0024NpcId_9 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_10":
			_0024var_0024NpcId_10 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_11":
			_0024var_0024NpcId_11 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_12":
			_0024var_0024NpcId_12 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_13":
			_0024var_0024NpcId_13 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_14":
			_0024var_0024NpcId_14 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_15":
			_0024var_0024NpcId_15 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_16":
			_0024var_0024NpcId_16 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_17":
			_0024var_0024NpcId_17 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_18":
			_0024var_0024NpcId_18 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_19":
			_0024var_0024NpcId_19 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_20":
			_0024var_0024NpcId_20 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_21":
			_0024var_0024NpcId_21 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_22":
			_0024var_0024NpcId_22 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_23":
			_0024var_0024NpcId_23 = MasterBaseClass.ToInt(val);
			break;
		case "NpcId_24":
			_0024var_0024NpcId_24 = MasterBaseClass.ToInt(val);
			break;
		case "KusamushiPos_1":
			_0024var_0024KusamushiPos_1 = MasterBaseClass.ToStringValue(val);
			break;
		case "KusamushiPos_2":
			_0024var_0024KusamushiPos_2 = MasterBaseClass.ToStringValue(val);
			break;
		case "KusamushiPos_3":
			_0024var_0024KusamushiPos_3 = MasterBaseClass.ToStringValue(val);
			break;
		case "KusamushiPos_4":
			_0024var_0024KusamushiPos_4 = MasterBaseClass.ToStringValue(val);
			break;
		case "KusamushiPos_5":
			_0024var_0024KusamushiPos_5 = MasterBaseClass.ToStringValue(val);
			break;
		case "KusamushiPos_6":
			_0024var_0024KusamushiPos_6 = MasterBaseClass.ToStringValue(val);
			break;
		case "KusamushiPos_7":
			_0024var_0024KusamushiPos_7 = MasterBaseClass.ToStringValue(val);
			break;
		case "KusamushiPos_8":
			_0024var_0024KusamushiPos_8 = MasterBaseClass.ToStringValue(val);
			break;
		case "N":
			_0024var_0024N = MasterBaseClass.ToInt(val);
			break;
		case "NE":
			_0024var_0024NE = MasterBaseClass.ToInt(val);
			break;
		case "E":
			_0024var_0024E = MasterBaseClass.ToInt(val);
			break;
		case "SE":
			_0024var_0024SE = MasterBaseClass.ToInt(val);
			break;
		case "S":
			_0024var_0024S = MasterBaseClass.ToInt(val);
			break;
		case "SW":
			_0024var_0024SW = MasterBaseClass.ToInt(val);
			break;
		case "W":
			_0024var_0024W = MasterBaseClass.ToInt(val);
			break;
		case "NW":
			_0024var_0024NW = MasterBaseClass.ToInt(val);
			break;
		case "DirN":
			if (typeof(EnumMapLinkDir).IsEnum)
			{
				_0024var_0024DirN = (EnumMapLinkDir)MasterBaseClass.ToEnum(val);
			}
			break;
		case "DirNE":
			if (typeof(EnumMapLinkDir).IsEnum)
			{
				_0024var_0024DirNE = (EnumMapLinkDir)MasterBaseClass.ToEnum(val);
			}
			break;
		case "DirE":
			if (typeof(EnumMapLinkDir).IsEnum)
			{
				_0024var_0024DirE = (EnumMapLinkDir)MasterBaseClass.ToEnum(val);
			}
			break;
		case "DirSE":
			if (typeof(EnumMapLinkDir).IsEnum)
			{
				_0024var_0024DirSE = (EnumMapLinkDir)MasterBaseClass.ToEnum(val);
			}
			break;
		case "DirS":
			if (typeof(EnumMapLinkDir).IsEnum)
			{
				_0024var_0024DirS = (EnumMapLinkDir)MasterBaseClass.ToEnum(val);
			}
			break;
		case "DirSW":
			if (typeof(EnumMapLinkDir).IsEnum)
			{
				_0024var_0024DirSW = (EnumMapLinkDir)MasterBaseClass.ToEnum(val);
			}
			break;
		case "DirW":
			if (typeof(EnumMapLinkDir).IsEnum)
			{
				_0024var_0024DirW = (EnumMapLinkDir)MasterBaseClass.ToEnum(val);
			}
			break;
		case "DirNW":
			if (typeof(EnumMapLinkDir).IsEnum)
			{
				_0024var_0024DirNW = (EnumMapLinkDir)MasterBaseClass.ToEnum(val);
			}
			break;
		case "BlockN":
			_0024var_0024BlockN = MasterBaseClass.ToBool(val);
			break;
		case "BlockNE":
			_0024var_0024BlockNE = MasterBaseClass.ToBool(val);
			break;
		case "BlockE":
			_0024var_0024BlockE = MasterBaseClass.ToBool(val);
			break;
		case "BlockSE":
			_0024var_0024BlockSE = MasterBaseClass.ToBool(val);
			break;
		case "BlockS":
			_0024var_0024BlockS = MasterBaseClass.ToBool(val);
			break;
		case "BlockSW":
			_0024var_0024BlockSW = MasterBaseClass.ToBool(val);
			break;
		case "BlockW":
			_0024var_0024BlockW = MasterBaseClass.ToBool(val);
			break;
		case "BlockNW":
			_0024var_0024BlockNW = MasterBaseClass.ToBool(val);
			break;
		case "SeId_1":
			_0024var_0024SeId_1 = MasterBaseClass.ToInt(val);
			break;
		case "SeId_2":
			_0024var_0024SeId_2 = MasterBaseClass.ToInt(val);
			break;
		case "SeId_3":
			_0024var_0024SeId_3 = MasterBaseClass.ToInt(val);
			break;
		case "SeId_4":
			_0024var_0024SeId_4 = MasterBaseClass.ToInt(val);
			break;
		case "SeId_5":
			_0024var_0024SeId_5 = MasterBaseClass.ToInt(val);
			break;
		case "SeId_6":
			_0024var_0024SeId_6 = MasterBaseClass.ToInt(val);
			break;
		case "SeId_7":
			_0024var_0024SeId_7 = MasterBaseClass.ToInt(val);
			break;
		case "SeId_8":
			_0024var_0024SeId_8 = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Progname" => true, 
			"MAreaId" => true, 
			"MQuestId" => true, 
			"SceneName" => true, 
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
			"BeginPeriod" => true, 
			"EndPeriod" => true, 
			"TempFlag" => true, 
			"ExtMScenes" => true, 
			"StageBattleId_1" => true, 
			"StageBattleId_2" => true, 
			"StageBattleId_3" => true, 
			"StageBattleId_4" => true, 
			"StageBattleId_5" => true, 
			"StageBattleId_6" => true, 
			"StageBattleId_7" => true, 
			"StageBattleId_8" => true, 
			"NpcId_1" => true, 
			"NpcId_2" => true, 
			"NpcId_3" => true, 
			"NpcId_4" => true, 
			"NpcId_5" => true, 
			"NpcId_6" => true, 
			"NpcId_7" => true, 
			"NpcId_8" => true, 
			"NpcId_9" => true, 
			"NpcId_10" => true, 
			"NpcId_11" => true, 
			"NpcId_12" => true, 
			"NpcId_13" => true, 
			"NpcId_14" => true, 
			"NpcId_15" => true, 
			"NpcId_16" => true, 
			"NpcId_17" => true, 
			"NpcId_18" => true, 
			"NpcId_19" => true, 
			"NpcId_20" => true, 
			"NpcId_21" => true, 
			"NpcId_22" => true, 
			"NpcId_23" => true, 
			"NpcId_24" => true, 
			"KusamushiPos_1" => true, 
			"KusamushiPos_2" => true, 
			"KusamushiPos_3" => true, 
			"KusamushiPos_4" => true, 
			"KusamushiPos_5" => true, 
			"KusamushiPos_6" => true, 
			"KusamushiPos_7" => true, 
			"KusamushiPos_8" => true, 
			"N" => true, 
			"NE" => true, 
			"E" => true, 
			"SE" => true, 
			"S" => true, 
			"SW" => true, 
			"W" => true, 
			"NW" => true, 
			"DirN" => true, 
			"DirNE" => true, 
			"DirE" => true, 
			"DirSE" => true, 
			"DirS" => true, 
			"DirSW" => true, 
			"DirW" => true, 
			"DirNW" => true, 
			"BlockN" => true, 
			"BlockNE" => true, 
			"BlockE" => true, 
			"BlockSE" => true, 
			"BlockS" => true, 
			"BlockSW" => true, 
			"BlockW" => true, 
			"BlockNW" => true, 
			"SeId_1" => true, 
			"SeId_2" => true, 
			"SeId_3" => true, 
			"SeId_4" => true, 
			"SeId_5" => true, 
			"SeId_6" => true, 
			"SeId_7" => true, 
			"SeId_8" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[97]
		{
			"Id", "Progname", "MAreaId", "MQuestId", "SceneName", "Condition_1", "Condition_2", "Condition_3", "Condition_4", "Condition_5",
			"Condition_6", "Condition_7", "Condition_8", "NotCondition_1", "NotCondition_2", "NotCondition_3", "NotCondition_4", "NotCondition_5", "NotCondition_6", "NotCondition_7",
			"NotCondition_8", "BeginPeriod", "EndPeriod", "TempFlag", "ExtMScenes", "StageBattleId_1", "StageBattleId_2", "StageBattleId_3", "StageBattleId_4", "StageBattleId_5",
			"StageBattleId_6", "StageBattleId_7", "StageBattleId_8", "NpcId_1", "NpcId_2", "NpcId_3", "NpcId_4", "NpcId_5", "NpcId_6", "NpcId_7",
			"NpcId_8", "NpcId_9", "NpcId_10", "NpcId_11", "NpcId_12", "NpcId_13", "NpcId_14", "NpcId_15", "NpcId_16", "NpcId_17",
			"NpcId_18", "NpcId_19", "NpcId_20", "NpcId_21", "NpcId_22", "NpcId_23", "NpcId_24", "KusamushiPos_1", "KusamushiPos_2", "KusamushiPos_3",
			"KusamushiPos_4", "KusamushiPos_5", "KusamushiPos_6", "KusamushiPos_7", "KusamushiPos_8", "N", "NE", "E", "SE", "S",
			"SW", "W", "NW", "DirN", "DirNE", "DirE", "DirSE", "DirS", "DirSW", "DirW",
			"DirNW", "BlockN", "BlockNE", "BlockE", "BlockSE", "BlockS", "BlockSW", "BlockW", "BlockNW", "SeId_1",
			"SeId_2", "SeId_3", "SeId_4", "SeId_5", "SeId_6", "SeId_7", "SeId_8"
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
						_0024var_0024MAreaId = MasterBaseClass.ParseInt(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024MQuestId = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024SceneName = vals[4];
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Condition_1 = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024Condition_2 = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024Condition_3 = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024Condition_4 = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024Condition_5 = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024Condition_6 = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024Condition_7 = MasterBaseClass.ParseInt(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024Condition_8 = MasterBaseClass.ParseInt(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024NotCondition_1 = MasterBaseClass.ParseInt(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024NotCondition_2 = MasterBaseClass.ParseInt(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null)
																		{
																			_0024var_0024NotCondition_3 = MasterBaseClass.ParseInt(vals[15]);
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null)
																			{
																				_0024var_0024NotCondition_4 = MasterBaseClass.ParseInt(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null)
																				{
																					_0024var_0024NotCondition_5 = MasterBaseClass.ParseInt(vals[17]);
																				}
																				if (length <= 18)
																				{
																					result = 18;
																				}
																				else
																				{
																					if (vals[18] != null)
																					{
																						_0024var_0024NotCondition_6 = MasterBaseClass.ParseInt(vals[18]);
																					}
																					if (length <= 19)
																					{
																						result = 19;
																					}
																					else
																					{
																						if (vals[19] != null)
																						{
																							_0024var_0024NotCondition_7 = MasterBaseClass.ParseInt(vals[19]);
																						}
																						if (length <= 20)
																						{
																							result = 20;
																						}
																						else
																						{
																							if (vals[20] != null)
																							{
																								_0024var_0024NotCondition_8 = MasterBaseClass.ParseInt(vals[20]);
																							}
																							if (length <= 21)
																							{
																								result = 21;
																							}
																							else
																							{
																								if (vals[21] != null)
																								{
																									_0024var_0024BeginPeriod = MasterBaseClass.ParseDateTime(vals[21]);
																								}
																								if (length <= 22)
																								{
																									result = 22;
																								}
																								else
																								{
																									if (vals[22] != null)
																									{
																										_0024var_0024EndPeriod = MasterBaseClass.ParseDateTime(vals[22]);
																									}
																									if (length <= 23)
																									{
																										result = 23;
																									}
																									else
																									{
																										if (vals[23] != null)
																										{
																											_0024var_0024TempFlag = MasterBaseClass.ParseInt(vals[23]);
																										}
																										if (length <= 24)
																										{
																											result = 24;
																										}
																										else
																										{
																											if (vals[24] != null)
																											{
																												_0024var_0024ExtMScenes = MasterBaseClass.ParseInt(vals[24]);
																											}
																											if (length <= 25)
																											{
																												result = 25;
																											}
																											else
																											{
																												if (vals[25] != null)
																												{
																													_0024var_0024StageBattleId_1 = MasterBaseClass.ParseInt(vals[25]);
																												}
																												if (length <= 26)
																												{
																													result = 26;
																												}
																												else
																												{
																													if (vals[26] != null)
																													{
																														_0024var_0024StageBattleId_2 = MasterBaseClass.ParseInt(vals[26]);
																													}
																													if (length <= 27)
																													{
																														result = 27;
																													}
																													else
																													{
																														if (vals[27] != null)
																														{
																															_0024var_0024StageBattleId_3 = MasterBaseClass.ParseInt(vals[27]);
																														}
																														if (length <= 28)
																														{
																															result = 28;
																														}
																														else
																														{
																															if (vals[28] != null)
																															{
																																_0024var_0024StageBattleId_4 = MasterBaseClass.ParseInt(vals[28]);
																															}
																															if (length <= 29)
																															{
																																result = 29;
																															}
																															else
																															{
																																if (vals[29] != null)
																																{
																																	_0024var_0024StageBattleId_5 = MasterBaseClass.ParseInt(vals[29]);
																																}
																																if (length <= 30)
																																{
																																	result = 30;
																																}
																																else
																																{
																																	if (vals[30] != null)
																																	{
																																		_0024var_0024StageBattleId_6 = MasterBaseClass.ParseInt(vals[30]);
																																	}
																																	if (length <= 31)
																																	{
																																		result = 31;
																																	}
																																	else
																																	{
																																		if (vals[31] != null)
																																		{
																																			_0024var_0024StageBattleId_7 = MasterBaseClass.ParseInt(vals[31]);
																																		}
																																		if (length <= 32)
																																		{
																																			result = 32;
																																		}
																																		else
																																		{
																																			if (vals[32] != null)
																																			{
																																				_0024var_0024StageBattleId_8 = MasterBaseClass.ParseInt(vals[32]);
																																			}
																																			if (length <= 33)
																																			{
																																				result = 33;
																																			}
																																			else
																																			{
																																				if (vals[33] != null)
																																				{
																																					_0024var_0024NpcId_1 = MasterBaseClass.ParseInt(vals[33]);
																																				}
																																				if (length <= 34)
																																				{
																																					result = 34;
																																				}
																																				else
																																				{
																																					if (vals[34] != null)
																																					{
																																						_0024var_0024NpcId_2 = MasterBaseClass.ParseInt(vals[34]);
																																					}
																																					if (length <= 35)
																																					{
																																						result = 35;
																																					}
																																					else
																																					{
																																						if (vals[35] != null)
																																						{
																																							_0024var_0024NpcId_3 = MasterBaseClass.ParseInt(vals[35]);
																																						}
																																						if (length <= 36)
																																						{
																																							result = 36;
																																						}
																																						else
																																						{
																																							if (vals[36] != null)
																																							{
																																								_0024var_0024NpcId_4 = MasterBaseClass.ParseInt(vals[36]);
																																							}
																																							if (length <= 37)
																																							{
																																								result = 37;
																																							}
																																							else
																																							{
																																								if (vals[37] != null)
																																								{
																																									_0024var_0024NpcId_5 = MasterBaseClass.ParseInt(vals[37]);
																																								}
																																								if (length <= 38)
																																								{
																																									result = 38;
																																								}
																																								else
																																								{
																																									if (vals[38] != null)
																																									{
																																										_0024var_0024NpcId_6 = MasterBaseClass.ParseInt(vals[38]);
																																									}
																																									if (length <= 39)
																																									{
																																										result = 39;
																																									}
																																									else
																																									{
																																										if (vals[39] != null)
																																										{
																																											_0024var_0024NpcId_7 = MasterBaseClass.ParseInt(vals[39]);
																																										}
																																										if (length <= 40)
																																										{
																																											result = 40;
																																										}
																																										else
																																										{
																																											if (vals[40] != null)
																																											{
																																												_0024var_0024NpcId_8 = MasterBaseClass.ParseInt(vals[40]);
																																											}
																																											if (length <= 41)
																																											{
																																												result = 41;
																																											}
																																											else
																																											{
																																												if (vals[41] != null)
																																												{
																																													_0024var_0024NpcId_9 = MasterBaseClass.ParseInt(vals[41]);
																																												}
																																												if (length <= 42)
																																												{
																																													result = 42;
																																												}
																																												else
																																												{
																																													if (vals[42] != null)
																																													{
																																														_0024var_0024NpcId_10 = MasterBaseClass.ParseInt(vals[42]);
																																													}
																																													if (length <= 43)
																																													{
																																														result = 43;
																																													}
																																													else
																																													{
																																														if (vals[43] != null)
																																														{
																																															_0024var_0024NpcId_11 = MasterBaseClass.ParseInt(vals[43]);
																																														}
																																														if (length <= 44)
																																														{
																																															result = 44;
																																														}
																																														else
																																														{
																																															if (vals[44] != null)
																																															{
																																																_0024var_0024NpcId_12 = MasterBaseClass.ParseInt(vals[44]);
																																															}
																																															if (length <= 45)
																																															{
																																																result = 45;
																																															}
																																															else
																																															{
																																																if (vals[45] != null)
																																																{
																																																	_0024var_0024NpcId_13 = MasterBaseClass.ParseInt(vals[45]);
																																																}
																																																if (length <= 46)
																																																{
																																																	result = 46;
																																																}
																																																else
																																																{
																																																	if (vals[46] != null)
																																																	{
																																																		_0024var_0024NpcId_14 = MasterBaseClass.ParseInt(vals[46]);
																																																	}
																																																	if (length <= 47)
																																																	{
																																																		result = 47;
																																																	}
																																																	else
																																																	{
																																																		if (vals[47] != null)
																																																		{
																																																			_0024var_0024NpcId_15 = MasterBaseClass.ParseInt(vals[47]);
																																																		}
																																																		if (length <= 48)
																																																		{
																																																			result = 48;
																																																		}
																																																		else
																																																		{
																																																			if (vals[48] != null)
																																																			{
																																																				_0024var_0024NpcId_16 = MasterBaseClass.ParseInt(vals[48]);
																																																			}
																																																			if (length <= 49)
																																																			{
																																																				result = 49;
																																																			}
																																																			else
																																																			{
																																																				if (vals[49] != null)
																																																				{
																																																					_0024var_0024NpcId_17 = MasterBaseClass.ParseInt(vals[49]);
																																																				}
																																																				if (length <= 50)
																																																				{
																																																					result = 50;
																																																				}
																																																				else
																																																				{
																																																					if (vals[50] != null)
																																																					{
																																																						_0024var_0024NpcId_18 = MasterBaseClass.ParseInt(vals[50]);
																																																					}
																																																					if (length <= 51)
																																																					{
																																																						result = 51;
																																																					}
																																																					else
																																																					{
																																																						if (vals[51] != null)
																																																						{
																																																							_0024var_0024NpcId_19 = MasterBaseClass.ParseInt(vals[51]);
																																																						}
																																																						if (length <= 52)
																																																						{
																																																							result = 52;
																																																						}
																																																						else
																																																						{
																																																							if (vals[52] != null)
																																																							{
																																																								_0024var_0024NpcId_20 = MasterBaseClass.ParseInt(vals[52]);
																																																							}
																																																							if (length <= 53)
																																																							{
																																																								result = 53;
																																																							}
																																																							else
																																																							{
																																																								if (vals[53] != null)
																																																								{
																																																									_0024var_0024NpcId_21 = MasterBaseClass.ParseInt(vals[53]);
																																																								}
																																																								if (length <= 54)
																																																								{
																																																									result = 54;
																																																								}
																																																								else
																																																								{
																																																									if (vals[54] != null)
																																																									{
																																																										_0024var_0024NpcId_22 = MasterBaseClass.ParseInt(vals[54]);
																																																									}
																																																									if (length <= 55)
																																																									{
																																																										result = 55;
																																																									}
																																																									else
																																																									{
																																																										if (vals[55] != null)
																																																										{
																																																											_0024var_0024NpcId_23 = MasterBaseClass.ParseInt(vals[55]);
																																																										}
																																																										if (length <= 56)
																																																										{
																																																											result = 56;
																																																										}
																																																										else
																																																										{
																																																											if (vals[56] != null)
																																																											{
																																																												_0024var_0024NpcId_24 = MasterBaseClass.ParseInt(vals[56]);
																																																											}
																																																											if (length <= 57)
																																																											{
																																																												result = 57;
																																																											}
																																																											else
																																																											{
																																																												if (vals[57] != null)
																																																												{
																																																													_0024var_0024KusamushiPos_1 = vals[57];
																																																												}
																																																												if (length <= 58)
																																																												{
																																																													result = 58;
																																																												}
																																																												else
																																																												{
																																																													if (vals[58] != null)
																																																													{
																																																														_0024var_0024KusamushiPos_2 = vals[58];
																																																													}
																																																													if (length <= 59)
																																																													{
																																																														result = 59;
																																																													}
																																																													else
																																																													{
																																																														if (vals[59] != null)
																																																														{
																																																															_0024var_0024KusamushiPos_3 = vals[59];
																																																														}
																																																														if (length <= 60)
																																																														{
																																																															result = 60;
																																																														}
																																																														else
																																																														{
																																																															if (vals[60] != null)
																																																															{
																																																																_0024var_0024KusamushiPos_4 = vals[60];
																																																															}
																																																															if (length <= 61)
																																																															{
																																																																result = 61;
																																																															}
																																																															else
																																																															{
																																																																if (vals[61] != null)
																																																																{
																																																																	_0024var_0024KusamushiPos_5 = vals[61];
																																																																}
																																																																if (length <= 62)
																																																																{
																																																																	result = 62;
																																																																}
																																																																else
																																																																{
																																																																	if (vals[62] != null)
																																																																	{
																																																																		_0024var_0024KusamushiPos_6 = vals[62];
																																																																	}
																																																																	if (length <= 63)
																																																																	{
																																																																		result = 63;
																																																																	}
																																																																	else
																																																																	{
																																																																		if (vals[63] != null)
																																																																		{
																																																																			_0024var_0024KusamushiPos_7 = vals[63];
																																																																		}
																																																																		if (length <= 64)
																																																																		{
																																																																			result = 64;
																																																																		}
																																																																		else
																																																																		{
																																																																			if (vals[64] != null)
																																																																			{
																																																																				_0024var_0024KusamushiPos_8 = vals[64];
																																																																			}
																																																																			if (length <= 65)
																																																																			{
																																																																				result = 65;
																																																																			}
																																																																			else
																																																																			{
																																																																				if (vals[65] != null)
																																																																				{
																																																																					_0024var_0024N = MasterBaseClass.ParseInt(vals[65]);
																																																																				}
																																																																				if (length <= 66)
																																																																				{
																																																																					result = 66;
																																																																				}
																																																																				else
																																																																				{
																																																																					if (vals[66] != null)
																																																																					{
																																																																						_0024var_0024NE = MasterBaseClass.ParseInt(vals[66]);
																																																																					}
																																																																					if (length <= 67)
																																																																					{
																																																																						result = 67;
																																																																					}
																																																																					else
																																																																					{
																																																																						if (vals[67] != null)
																																																																						{
																																																																							_0024var_0024E = MasterBaseClass.ParseInt(vals[67]);
																																																																						}
																																																																						if (length <= 68)
																																																																						{
																																																																							result = 68;
																																																																						}
																																																																						else
																																																																						{
																																																																							if (vals[68] != null)
																																																																							{
																																																																								_0024var_0024SE = MasterBaseClass.ParseInt(vals[68]);
																																																																							}
																																																																							if (length <= 69)
																																																																							{
																																																																								result = 69;
																																																																							}
																																																																							else
																																																																							{
																																																																								if (vals[69] != null)
																																																																								{
																																																																									_0024var_0024S = MasterBaseClass.ParseInt(vals[69]);
																																																																								}
																																																																								if (length <= 70)
																																																																								{
																																																																									result = 70;
																																																																								}
																																																																								else
																																																																								{
																																																																									if (vals[70] != null)
																																																																									{
																																																																										_0024var_0024SW = MasterBaseClass.ParseInt(vals[70]);
																																																																									}
																																																																									if (length <= 71)
																																																																									{
																																																																										result = 71;
																																																																									}
																																																																									else
																																																																									{
																																																																										if (vals[71] != null)
																																																																										{
																																																																											_0024var_0024W = MasterBaseClass.ParseInt(vals[71]);
																																																																										}
																																																																										if (length <= 72)
																																																																										{
																																																																											result = 72;
																																																																										}
																																																																										else
																																																																										{
																																																																											if (vals[72] != null)
																																																																											{
																																																																												_0024var_0024NW = MasterBaseClass.ParseInt(vals[72]);
																																																																											}
																																																																											if (length <= 73)
																																																																											{
																																																																												result = 73;
																																																																											}
																																																																											else
																																																																											{
																																																																												if (vals[73] != null && typeof(EnumMapLinkDir).IsEnum)
																																																																												{
																																																																													_0024var_0024DirN = (EnumMapLinkDir)MasterBaseClass.ParseEnum(vals[73]);
																																																																												}
																																																																												if (length <= 74)
																																																																												{
																																																																													result = 74;
																																																																												}
																																																																												else
																																																																												{
																																																																													if (vals[74] != null && typeof(EnumMapLinkDir).IsEnum)
																																																																													{
																																																																														_0024var_0024DirNE = (EnumMapLinkDir)MasterBaseClass.ParseEnum(vals[74]);
																																																																													}
																																																																													if (length <= 75)
																																																																													{
																																																																														result = 75;
																																																																													}
																																																																													else
																																																																													{
																																																																														if (vals[75] != null && typeof(EnumMapLinkDir).IsEnum)
																																																																														{
																																																																															_0024var_0024DirE = (EnumMapLinkDir)MasterBaseClass.ParseEnum(vals[75]);
																																																																														}
																																																																														if (length <= 76)
																																																																														{
																																																																															result = 76;
																																																																														}
																																																																														else
																																																																														{
																																																																															if (vals[76] != null && typeof(EnumMapLinkDir).IsEnum)
																																																																															{
																																																																																_0024var_0024DirSE = (EnumMapLinkDir)MasterBaseClass.ParseEnum(vals[76]);
																																																																															}
																																																																															if (length <= 77)
																																																																															{
																																																																																result = 77;
																																																																															}
																																																																															else
																																																																															{
																																																																																if (vals[77] != null && typeof(EnumMapLinkDir).IsEnum)
																																																																																{
																																																																																	_0024var_0024DirS = (EnumMapLinkDir)MasterBaseClass.ParseEnum(vals[77]);
																																																																																}
																																																																																if (length <= 78)
																																																																																{
																																																																																	result = 78;
																																																																																}
																																																																																else
																																																																																{
																																																																																	if (vals[78] != null && typeof(EnumMapLinkDir).IsEnum)
																																																																																	{
																																																																																		_0024var_0024DirSW = (EnumMapLinkDir)MasterBaseClass.ParseEnum(vals[78]);
																																																																																	}
																																																																																	if (length <= 79)
																																																																																	{
																																																																																		result = 79;
																																																																																	}
																																																																																	else
																																																																																	{
																																																																																		if (vals[79] != null && typeof(EnumMapLinkDir).IsEnum)
																																																																																		{
																																																																																			_0024var_0024DirW = (EnumMapLinkDir)MasterBaseClass.ParseEnum(vals[79]);
																																																																																		}
																																																																																		if (length <= 80)
																																																																																		{
																																																																																			result = 80;
																																																																																		}
																																																																																		else
																																																																																		{
																																																																																			if (vals[80] != null && typeof(EnumMapLinkDir).IsEnum)
																																																																																			{
																																																																																				_0024var_0024DirNW = (EnumMapLinkDir)MasterBaseClass.ParseEnum(vals[80]);
																																																																																			}
																																																																																			if (length <= 81)
																																																																																			{
																																																																																				result = 81;
																																																																																			}
																																																																																			else
																																																																																			{
																																																																																				if (vals[81] != null)
																																																																																				{
																																																																																					_0024var_0024BlockN = MasterBaseClass.ParseBool(vals[81]);
																																																																																				}
																																																																																				if (length <= 82)
																																																																																				{
																																																																																					result = 82;
																																																																																				}
																																																																																				else
																																																																																				{
																																																																																					if (vals[82] != null)
																																																																																					{
																																																																																						_0024var_0024BlockNE = MasterBaseClass.ParseBool(vals[82]);
																																																																																					}
																																																																																					if (length <= 83)
																																																																																					{
																																																																																						result = 83;
																																																																																					}
																																																																																					else
																																																																																					{
																																																																																						if (vals[83] != null)
																																																																																						{
																																																																																							_0024var_0024BlockE = MasterBaseClass.ParseBool(vals[83]);
																																																																																						}
																																																																																						if (length <= 84)
																																																																																						{
																																																																																							result = 84;
																																																																																						}
																																																																																						else
																																																																																						{
																																																																																							if (vals[84] != null)
																																																																																							{
																																																																																								_0024var_0024BlockSE = MasterBaseClass.ParseBool(vals[84]);
																																																																																							}
																																																																																							if (length <= 85)
																																																																																							{
																																																																																								result = 85;
																																																																																							}
																																																																																							else
																																																																																							{
																																																																																								if (vals[85] != null)
																																																																																								{
																																																																																									_0024var_0024BlockS = MasterBaseClass.ParseBool(vals[85]);
																																																																																								}
																																																																																								if (length <= 86)
																																																																																								{
																																																																																									result = 86;
																																																																																								}
																																																																																								else
																																																																																								{
																																																																																									if (vals[86] != null)
																																																																																									{
																																																																																										_0024var_0024BlockSW = MasterBaseClass.ParseBool(vals[86]);
																																																																																									}
																																																																																									if (length <= 87)
																																																																																									{
																																																																																										result = 87;
																																																																																									}
																																																																																									else
																																																																																									{
																																																																																										if (vals[87] != null)
																																																																																										{
																																																																																											_0024var_0024BlockW = MasterBaseClass.ParseBool(vals[87]);
																																																																																										}
																																																																																										if (length <= 88)
																																																																																										{
																																																																																											result = 88;
																																																																																										}
																																																																																										else
																																																																																										{
																																																																																											if (vals[88] != null)
																																																																																											{
																																																																																												_0024var_0024BlockNW = MasterBaseClass.ParseBool(vals[88]);
																																																																																											}
																																																																																											if (length <= 89)
																																																																																											{
																																																																																												result = 89;
																																																																																											}
																																																																																											else
																																																																																											{
																																																																																												if (vals[89] != null)
																																																																																												{
																																																																																													_0024var_0024SeId_1 = MasterBaseClass.ParseInt(vals[89]);
																																																																																												}
																																																																																												if (length <= 90)
																																																																																												{
																																																																																													result = 90;
																																																																																												}
																																																																																												else
																																																																																												{
																																																																																													if (vals[90] != null)
																																																																																													{
																																																																																														_0024var_0024SeId_2 = MasterBaseClass.ParseInt(vals[90]);
																																																																																													}
																																																																																													if (length <= 91)
																																																																																													{
																																																																																														result = 91;
																																																																																													}
																																																																																													else
																																																																																													{
																																																																																														if (vals[91] != null)
																																																																																														{
																																																																																															_0024var_0024SeId_3 = MasterBaseClass.ParseInt(vals[91]);
																																																																																														}
																																																																																														if (length <= 92)
																																																																																														{
																																																																																															result = 92;
																																																																																														}
																																																																																														else
																																																																																														{
																																																																																															if (vals[92] != null)
																																																																																															{
																																																																																																_0024var_0024SeId_4 = MasterBaseClass.ParseInt(vals[92]);
																																																																																															}
																																																																																															if (length <= 93)
																																																																																															{
																																																																																																result = 93;
																																																																																															}
																																																																																															else
																																																																																															{
																																																																																																if (vals[93] != null)
																																																																																																{
																																																																																																	_0024var_0024SeId_5 = MasterBaseClass.ParseInt(vals[93]);
																																																																																																}
																																																																																																if (length <= 94)
																																																																																																{
																																																																																																	result = 94;
																																																																																																}
																																																																																																else
																																																																																																{
																																																																																																	if (vals[94] != null)
																																																																																																	{
																																																																																																		_0024var_0024SeId_6 = MasterBaseClass.ParseInt(vals[94]);
																																																																																																	}
																																																																																																	if (length <= 95)
																																																																																																	{
																																																																																																		result = 95;
																																																																																																	}
																																																																																																	else
																																																																																																	{
																																																																																																		if (vals[95] != null)
																																																																																																		{
																																																																																																			_0024var_0024SeId_7 = MasterBaseClass.ParseInt(vals[95]);
																																																																																																		}
																																																																																																		if (length <= 96)
																																																																																																		{
																																																																																																			result = 96;
																																																																																																		}
																																																																																																		else
																																																																																																		{
																																																																																																			if (vals[96] != null)
																																																																																																			{
																																																																																																				_0024var_0024SeId_8 = MasterBaseClass.ParseInt(vals[96]);
																																																																																																			}
																																																																																																			int num = 97;
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

	internal string _0024get_KusamushiPositions_0024closure_0024250(string s)
	{
		return (!string.IsNullOrEmpty(s)) ? s : null;
	}

	internal string _0024get_KusamushiPositions_0024closure_0024251(string s)
	{
		return (!string.IsNullOrEmpty(s)) ? s : null;
	}

	internal string _0024get_KusamushiPositions_0024closure_0024252(string s)
	{
		return (!string.IsNullOrEmpty(s)) ? s : null;
	}

	internal string _0024get_KusamushiPositions_0024closure_0024253(string s)
	{
		return (!string.IsNullOrEmpty(s)) ? s : null;
	}

	internal string _0024get_KusamushiPositions_0024closure_0024254(string s)
	{
		return (!string.IsNullOrEmpty(s)) ? s : null;
	}

	internal string _0024get_KusamushiPositions_0024closure_0024255(string s)
	{
		return (!string.IsNullOrEmpty(s)) ? s : null;
	}

	internal string _0024get_KusamushiPositions_0024closure_0024256(string s)
	{
		return (!string.IsNullOrEmpty(s)) ? s : null;
	}

	internal string _0024get_KusamushiPositions_0024closure_0024257(string s)
	{
		return (!string.IsNullOrEmpty(s)) ? s : null;
	}

	internal Vector3 _0024get_KusamushiPositionsAsVector3_0024toPos_0024258(string s)
	{
		string[] array = s.Split(',');
		try
		{
			float[] array2 = new float[array.Length];
			int num = 0;
			int length = array.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int index = num;
				num++;
				array2[RuntimeServices.NormalizeArrayIndex(array2, index)] = float.Parse(array[RuntimeServices.NormalizeArrayIndex(array, index)]);
			}
			int length2 = array2.Length;
			Vector3 result = default(Vector3);
			if (length2 >= 1)
			{
				result.x = array2[0];
			}
			if (length2 >= 2)
			{
				result.y = array2[1];
			}
			if (length2 >= 3)
			{
				result.z = array2[2];
			}
			return result;
		}
		catch (Exception)
		{
			string message = new StringBuilder("position string format error: '").Append(s).Append("'").ToString();
			throw new Exception(message);
		}
	}
}
