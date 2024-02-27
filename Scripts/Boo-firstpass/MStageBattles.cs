using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MStageBattles : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Progname;

	public string _0024var_0024PositionObject;

	public int _0024var_0024MStageMonsters_Id_1;

	public int _0024var_0024MStageMonsters_Id_2;

	public int _0024var_0024MStageMonsters_Id_3;

	public int _0024var_0024MStageMonsters_Id_4;

	public int _0024var_0024MStageMonsters_Id_5;

	public int _0024var_0024MStageMonsters_Id_6;

	public int _0024var_0024MStageMonsters_Id_7;

	public int _0024var_0024MStageMonsters_Id_8;

	public int _0024var_0024MStageMonsters_Id_9;

	public int _0024var_0024MStageMonsters_Id_10;

	public int _0024var_0024MStageMonsters_Id_11;

	public int _0024var_0024MStageMonsters_Id_12;

	public int _0024var_0024MStageMonsters_Id_13;

	public int _0024var_0024MStageMonsters_Id_14;

	public int _0024var_0024MStageMonsters_Id_15;

	public int _0024var_0024MStageMonsters_Id_16;

	public int _0024var_0024MStageMonsters_Id_17;

	public int _0024var_0024MStageMonsters_Id_18;

	public int _0024var_0024MStageMonsters_Id_19;

	public int _0024var_0024MStageMonsters_Id_20;

	public int _0024var_0024MStageMonsters_Id_21;

	public int _0024var_0024MStageMonsters_Id_22;

	public int _0024var_0024MStageMonsters_Id_23;

	public int _0024var_0024MStageMonsters_Id_24;

	public int _0024var_0024MStageMonsters_Id_25;

	public int _0024var_0024MStageMonsters_Id_26;

	public int _0024var_0024MStageMonsters_Id_27;

	public int _0024var_0024MStageMonsters_Id_28;

	public int _0024var_0024MStageMonsters_Id_29;

	public int _0024var_0024MStageMonsters_Id_30;

	public int _0024var_0024MStageMonsters_Id_31;

	public int _0024var_0024MStageMonsters_Id_32;

	public int _0024var_0024MStageMonsters_Id_33;

	public int _0024var_0024MStageMonsters_Id_34;

	public int _0024var_0024MStageMonsters_Id_35;

	public int _0024var_0024MStageMonsters_Id_36;

	public int _0024var_0024MStageMonsters_Id_37;

	public int _0024var_0024MStageMonsters_Id_38;

	public int _0024var_0024MStageMonsters_Id_39;

	public int _0024var_0024MStageMonsters_Id_40;

	public int _0024var_0024MStageMonsters_Id_41;

	public int _0024var_0024MStageMonsters_Id_42;

	public int _0024var_0024MStageMonsters_Id_43;

	public int _0024var_0024MStageMonsters_Id_44;

	public int _0024var_0024MStageMonsters_Id_45;

	public int _0024var_0024MStageMonsters_Id_46;

	public int _0024var_0024MStageMonsters_Id_47;

	public int _0024var_0024MStageMonsters_Id_48;

	public bool _0024var_0024PreBattleCutSceneFade;

	public string _0024var_0024PreBattleCutScene;

	public string _0024var_0024PreBattleCutScenePos;

	public int _0024var_0024PreBattleFlag;

	public bool _0024var_0024PostBattleCutSceneFade;

	public string _0024var_0024PostBattleCutScene;

	public string _0024var_0024PostBattleCutScenePos;

	public int _0024var_0024BattleBgm;

	public int _0024var_0024WaitSecToOpen;

	public bool _0024var_0024KeepBattleMode;

	public int _0024var_0024ClearFlag;

	public int _0024var_0024ClearNotFlag;

	public BattleOpenConditions _0024var_0024OpenCondition;

	public bool _0024var_0024IsRaidCameraMode;

	public float _0024var_0024BattleCameraDistance;

	public float _0024var_0024BattleCameraHeight;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_1__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_2__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_3__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_4__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_5__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_6__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_7__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_8__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_9__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_10__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_11__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_12__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_13__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_14__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_15__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_16__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_17__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_18__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_19__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_20__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_21__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_22__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_23__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_24__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_25__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_26__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_27__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_28__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_29__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_30__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_31__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_32__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_33__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_34__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_35__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_36__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_37__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_38__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_39__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_40__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_41__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_42__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_43__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_44__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_45__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_46__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_47__cache;

	[NonSerialized]
	private MStageMonsters MStageMonsters_Id_48__cache;

	[NonSerialized]
	private MFlags PreBattleFlag__cache;

	[NonSerialized]
	private MBgm BattleBgm__cache;

	[NonSerialized]
	private MFlags ClearFlag__cache;

	[NonSerialized]
	private MFlags ClearNotFlag__cache;

	[NonSerialized]
	private static Dictionary<int, MStageBattles> _0024mst_002468 = new Dictionary<int, MStageBattles>();

	[NonSerialized]
	private static MStageBattles[] All_cache;

	public bool HasPostBattleCutScene => !string.IsNullOrEmpty(PostBattleCutScene);

	public MStageMonsters[] AllStageMonsters
	{
		get
		{
			System.Collections.Generic.List<MStageMonsters> list = new System.Collections.Generic.List<MStageMonsters>();
			if (MStageMonsters_Id_1 != null)
			{
				list.Add(MStageMonsters_Id_1);
			}
			if (MStageMonsters_Id_2 != null)
			{
				list.Add(MStageMonsters_Id_2);
			}
			if (MStageMonsters_Id_3 != null)
			{
				list.Add(MStageMonsters_Id_3);
			}
			if (MStageMonsters_Id_4 != null)
			{
				list.Add(MStageMonsters_Id_4);
			}
			if (MStageMonsters_Id_5 != null)
			{
				list.Add(MStageMonsters_Id_5);
			}
			if (MStageMonsters_Id_6 != null)
			{
				list.Add(MStageMonsters_Id_6);
			}
			if (MStageMonsters_Id_7 != null)
			{
				list.Add(MStageMonsters_Id_7);
			}
			if (MStageMonsters_Id_8 != null)
			{
				list.Add(MStageMonsters_Id_8);
			}
			if (MStageMonsters_Id_9 != null)
			{
				list.Add(MStageMonsters_Id_9);
			}
			if (MStageMonsters_Id_10 != null)
			{
				list.Add(MStageMonsters_Id_10);
			}
			if (MStageMonsters_Id_11 != null)
			{
				list.Add(MStageMonsters_Id_11);
			}
			if (MStageMonsters_Id_12 != null)
			{
				list.Add(MStageMonsters_Id_12);
			}
			if (MStageMonsters_Id_13 != null)
			{
				list.Add(MStageMonsters_Id_13);
			}
			if (MStageMonsters_Id_14 != null)
			{
				list.Add(MStageMonsters_Id_14);
			}
			if (MStageMonsters_Id_15 != null)
			{
				list.Add(MStageMonsters_Id_15);
			}
			if (MStageMonsters_Id_16 != null)
			{
				list.Add(MStageMonsters_Id_16);
			}
			if (MStageMonsters_Id_17 != null)
			{
				list.Add(MStageMonsters_Id_17);
			}
			if (MStageMonsters_Id_18 != null)
			{
				list.Add(MStageMonsters_Id_18);
			}
			if (MStageMonsters_Id_19 != null)
			{
				list.Add(MStageMonsters_Id_19);
			}
			if (MStageMonsters_Id_20 != null)
			{
				list.Add(MStageMonsters_Id_20);
			}
			if (MStageMonsters_Id_21 != null)
			{
				list.Add(MStageMonsters_Id_21);
			}
			if (MStageMonsters_Id_22 != null)
			{
				list.Add(MStageMonsters_Id_22);
			}
			if (MStageMonsters_Id_23 != null)
			{
				list.Add(MStageMonsters_Id_23);
			}
			if (MStageMonsters_Id_24 != null)
			{
				list.Add(MStageMonsters_Id_24);
			}
			if (MStageMonsters_Id_25 != null)
			{
				list.Add(MStageMonsters_Id_25);
			}
			if (MStageMonsters_Id_26 != null)
			{
				list.Add(MStageMonsters_Id_26);
			}
			if (MStageMonsters_Id_27 != null)
			{
				list.Add(MStageMonsters_Id_27);
			}
			if (MStageMonsters_Id_28 != null)
			{
				list.Add(MStageMonsters_Id_28);
			}
			if (MStageMonsters_Id_29 != null)
			{
				list.Add(MStageMonsters_Id_29);
			}
			if (MStageMonsters_Id_30 != null)
			{
				list.Add(MStageMonsters_Id_30);
			}
			if (MStageMonsters_Id_31 != null)
			{
				list.Add(MStageMonsters_Id_31);
			}
			if (MStageMonsters_Id_32 != null)
			{
				list.Add(MStageMonsters_Id_32);
			}
			if (MStageMonsters_Id_33 != null)
			{
				list.Add(MStageMonsters_Id_33);
			}
			if (MStageMonsters_Id_34 != null)
			{
				list.Add(MStageMonsters_Id_34);
			}
			if (MStageMonsters_Id_35 != null)
			{
				list.Add(MStageMonsters_Id_35);
			}
			if (MStageMonsters_Id_36 != null)
			{
				list.Add(MStageMonsters_Id_36);
			}
			if (MStageMonsters_Id_37 != null)
			{
				list.Add(MStageMonsters_Id_37);
			}
			if (MStageMonsters_Id_38 != null)
			{
				list.Add(MStageMonsters_Id_38);
			}
			if (MStageMonsters_Id_39 != null)
			{
				list.Add(MStageMonsters_Id_39);
			}
			if (MStageMonsters_Id_40 != null)
			{
				list.Add(MStageMonsters_Id_40);
			}
			if (MStageMonsters_Id_41 != null)
			{
				list.Add(MStageMonsters_Id_41);
			}
			if (MStageMonsters_Id_42 != null)
			{
				list.Add(MStageMonsters_Id_42);
			}
			if (MStageMonsters_Id_43 != null)
			{
				list.Add(MStageMonsters_Id_43);
			}
			if (MStageMonsters_Id_44 != null)
			{
				list.Add(MStageMonsters_Id_44);
			}
			if (MStageMonsters_Id_45 != null)
			{
				list.Add(MStageMonsters_Id_45);
			}
			if (MStageMonsters_Id_46 != null)
			{
				list.Add(MStageMonsters_Id_46);
			}
			if (MStageMonsters_Id_47 != null)
			{
				list.Add(MStageMonsters_Id_47);
			}
			if (MStageMonsters_Id_48 != null)
			{
				list.Add(MStageMonsters_Id_48);
			}
			return list.ToArray();
		}
	}

	public bool ContainsBoss
	{
		get
		{
			bool result = false;
			int i = 0;
			MStageMonsters[] allStageMonsters = AllStageMonsters;
			for (int length = allStageMonsters.Length; i < length; i = checked(i + 1))
			{
				if (allStageMonsters[i].IsBoss != 0)
				{
					result = true;
				}
			}
			return result;
		}
	}

	public MScenes ParentScene
	{
		get
		{
			int num = 0;
			MScenes[] all = MScenes.All;
			int length = all.Length;
			checked
			{
				object result;
				while (true)
				{
					if (num < length)
					{
						int num2 = 0;
						MStageBattles[] allStageBattles = all[num].AllStageBattles;
						int length2 = allStageBattles.Length;
						while (num2 < length2)
						{
							if (allStageBattles[num2].Id != Id)
							{
								num2++;
								continue;
							}
							goto IL_0045;
						}
						num++;
						continue;
					}
					result = null;
					break;
					IL_0045:
					result = all[num];
					break;
				}
				return (MScenes)result;
			}
		}
	}

	public int Id => _0024var_0024Id;

	public string Progname => _0024var_0024Progname;

	public string PositionObject => _0024var_0024PositionObject;

	public MStageMonsters MStageMonsters_Id_1
	{
		get
		{
			if (MStageMonsters_Id_1__cache == null)
			{
				MStageMonsters_Id_1__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_1);
			}
			return MStageMonsters_Id_1__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_2
	{
		get
		{
			if (MStageMonsters_Id_2__cache == null)
			{
				MStageMonsters_Id_2__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_2);
			}
			return MStageMonsters_Id_2__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_3
	{
		get
		{
			if (MStageMonsters_Id_3__cache == null)
			{
				MStageMonsters_Id_3__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_3);
			}
			return MStageMonsters_Id_3__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_4
	{
		get
		{
			if (MStageMonsters_Id_4__cache == null)
			{
				MStageMonsters_Id_4__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_4);
			}
			return MStageMonsters_Id_4__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_5
	{
		get
		{
			if (MStageMonsters_Id_5__cache == null)
			{
				MStageMonsters_Id_5__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_5);
			}
			return MStageMonsters_Id_5__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_6
	{
		get
		{
			if (MStageMonsters_Id_6__cache == null)
			{
				MStageMonsters_Id_6__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_6);
			}
			return MStageMonsters_Id_6__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_7
	{
		get
		{
			if (MStageMonsters_Id_7__cache == null)
			{
				MStageMonsters_Id_7__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_7);
			}
			return MStageMonsters_Id_7__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_8
	{
		get
		{
			if (MStageMonsters_Id_8__cache == null)
			{
				MStageMonsters_Id_8__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_8);
			}
			return MStageMonsters_Id_8__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_9
	{
		get
		{
			if (MStageMonsters_Id_9__cache == null)
			{
				MStageMonsters_Id_9__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_9);
			}
			return MStageMonsters_Id_9__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_10
	{
		get
		{
			if (MStageMonsters_Id_10__cache == null)
			{
				MStageMonsters_Id_10__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_10);
			}
			return MStageMonsters_Id_10__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_11
	{
		get
		{
			if (MStageMonsters_Id_11__cache == null)
			{
				MStageMonsters_Id_11__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_11);
			}
			return MStageMonsters_Id_11__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_12
	{
		get
		{
			if (MStageMonsters_Id_12__cache == null)
			{
				MStageMonsters_Id_12__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_12);
			}
			return MStageMonsters_Id_12__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_13
	{
		get
		{
			if (MStageMonsters_Id_13__cache == null)
			{
				MStageMonsters_Id_13__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_13);
			}
			return MStageMonsters_Id_13__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_14
	{
		get
		{
			if (MStageMonsters_Id_14__cache == null)
			{
				MStageMonsters_Id_14__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_14);
			}
			return MStageMonsters_Id_14__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_15
	{
		get
		{
			if (MStageMonsters_Id_15__cache == null)
			{
				MStageMonsters_Id_15__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_15);
			}
			return MStageMonsters_Id_15__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_16
	{
		get
		{
			if (MStageMonsters_Id_16__cache == null)
			{
				MStageMonsters_Id_16__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_16);
			}
			return MStageMonsters_Id_16__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_17
	{
		get
		{
			if (MStageMonsters_Id_17__cache == null)
			{
				MStageMonsters_Id_17__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_17);
			}
			return MStageMonsters_Id_17__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_18
	{
		get
		{
			if (MStageMonsters_Id_18__cache == null)
			{
				MStageMonsters_Id_18__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_18);
			}
			return MStageMonsters_Id_18__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_19
	{
		get
		{
			if (MStageMonsters_Id_19__cache == null)
			{
				MStageMonsters_Id_19__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_19);
			}
			return MStageMonsters_Id_19__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_20
	{
		get
		{
			if (MStageMonsters_Id_20__cache == null)
			{
				MStageMonsters_Id_20__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_20);
			}
			return MStageMonsters_Id_20__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_21
	{
		get
		{
			if (MStageMonsters_Id_21__cache == null)
			{
				MStageMonsters_Id_21__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_21);
			}
			return MStageMonsters_Id_21__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_22
	{
		get
		{
			if (MStageMonsters_Id_22__cache == null)
			{
				MStageMonsters_Id_22__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_22);
			}
			return MStageMonsters_Id_22__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_23
	{
		get
		{
			if (MStageMonsters_Id_23__cache == null)
			{
				MStageMonsters_Id_23__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_23);
			}
			return MStageMonsters_Id_23__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_24
	{
		get
		{
			if (MStageMonsters_Id_24__cache == null)
			{
				MStageMonsters_Id_24__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_24);
			}
			return MStageMonsters_Id_24__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_25
	{
		get
		{
			if (MStageMonsters_Id_25__cache == null)
			{
				MStageMonsters_Id_25__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_25);
			}
			return MStageMonsters_Id_25__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_26
	{
		get
		{
			if (MStageMonsters_Id_26__cache == null)
			{
				MStageMonsters_Id_26__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_26);
			}
			return MStageMonsters_Id_26__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_27
	{
		get
		{
			if (MStageMonsters_Id_27__cache == null)
			{
				MStageMonsters_Id_27__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_27);
			}
			return MStageMonsters_Id_27__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_28
	{
		get
		{
			if (MStageMonsters_Id_28__cache == null)
			{
				MStageMonsters_Id_28__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_28);
			}
			return MStageMonsters_Id_28__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_29
	{
		get
		{
			if (MStageMonsters_Id_29__cache == null)
			{
				MStageMonsters_Id_29__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_29);
			}
			return MStageMonsters_Id_29__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_30
	{
		get
		{
			if (MStageMonsters_Id_30__cache == null)
			{
				MStageMonsters_Id_30__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_30);
			}
			return MStageMonsters_Id_30__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_31
	{
		get
		{
			if (MStageMonsters_Id_31__cache == null)
			{
				MStageMonsters_Id_31__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_31);
			}
			return MStageMonsters_Id_31__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_32
	{
		get
		{
			if (MStageMonsters_Id_32__cache == null)
			{
				MStageMonsters_Id_32__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_32);
			}
			return MStageMonsters_Id_32__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_33
	{
		get
		{
			if (MStageMonsters_Id_33__cache == null)
			{
				MStageMonsters_Id_33__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_33);
			}
			return MStageMonsters_Id_33__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_34
	{
		get
		{
			if (MStageMonsters_Id_34__cache == null)
			{
				MStageMonsters_Id_34__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_34);
			}
			return MStageMonsters_Id_34__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_35
	{
		get
		{
			if (MStageMonsters_Id_35__cache == null)
			{
				MStageMonsters_Id_35__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_35);
			}
			return MStageMonsters_Id_35__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_36
	{
		get
		{
			if (MStageMonsters_Id_36__cache == null)
			{
				MStageMonsters_Id_36__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_36);
			}
			return MStageMonsters_Id_36__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_37
	{
		get
		{
			if (MStageMonsters_Id_37__cache == null)
			{
				MStageMonsters_Id_37__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_37);
			}
			return MStageMonsters_Id_37__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_38
	{
		get
		{
			if (MStageMonsters_Id_38__cache == null)
			{
				MStageMonsters_Id_38__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_38);
			}
			return MStageMonsters_Id_38__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_39
	{
		get
		{
			if (MStageMonsters_Id_39__cache == null)
			{
				MStageMonsters_Id_39__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_39);
			}
			return MStageMonsters_Id_39__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_40
	{
		get
		{
			if (MStageMonsters_Id_40__cache == null)
			{
				MStageMonsters_Id_40__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_40);
			}
			return MStageMonsters_Id_40__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_41
	{
		get
		{
			if (MStageMonsters_Id_41__cache == null)
			{
				MStageMonsters_Id_41__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_41);
			}
			return MStageMonsters_Id_41__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_42
	{
		get
		{
			if (MStageMonsters_Id_42__cache == null)
			{
				MStageMonsters_Id_42__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_42);
			}
			return MStageMonsters_Id_42__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_43
	{
		get
		{
			if (MStageMonsters_Id_43__cache == null)
			{
				MStageMonsters_Id_43__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_43);
			}
			return MStageMonsters_Id_43__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_44
	{
		get
		{
			if (MStageMonsters_Id_44__cache == null)
			{
				MStageMonsters_Id_44__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_44);
			}
			return MStageMonsters_Id_44__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_45
	{
		get
		{
			if (MStageMonsters_Id_45__cache == null)
			{
				MStageMonsters_Id_45__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_45);
			}
			return MStageMonsters_Id_45__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_46
	{
		get
		{
			if (MStageMonsters_Id_46__cache == null)
			{
				MStageMonsters_Id_46__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_46);
			}
			return MStageMonsters_Id_46__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_47
	{
		get
		{
			if (MStageMonsters_Id_47__cache == null)
			{
				MStageMonsters_Id_47__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_47);
			}
			return MStageMonsters_Id_47__cache;
		}
	}

	public MStageMonsters MStageMonsters_Id_48
	{
		get
		{
			if (MStageMonsters_Id_48__cache == null)
			{
				MStageMonsters_Id_48__cache = MStageMonsters.Get(_0024var_0024MStageMonsters_Id_48);
			}
			return MStageMonsters_Id_48__cache;
		}
	}

	public bool PreBattleCutSceneFade => _0024var_0024PreBattleCutSceneFade;

	public string PreBattleCutScene => _0024var_0024PreBattleCutScene;

	public string PreBattleCutScenePos => _0024var_0024PreBattleCutScenePos;

	public MFlags PreBattleFlag
	{
		get
		{
			if (PreBattleFlag__cache == null)
			{
				PreBattleFlag__cache = MFlags.Get(_0024var_0024PreBattleFlag);
			}
			return PreBattleFlag__cache;
		}
	}

	public bool PostBattleCutSceneFade => _0024var_0024PostBattleCutSceneFade;

	public string PostBattleCutScene => _0024var_0024PostBattleCutScene;

	public string PostBattleCutScenePos => _0024var_0024PostBattleCutScenePos;

	public MBgm BattleBgm
	{
		get
		{
			if (BattleBgm__cache == null)
			{
				BattleBgm__cache = MBgm.Get(_0024var_0024BattleBgm);
			}
			return BattleBgm__cache;
		}
	}

	public int WaitSecToOpen => _0024var_0024WaitSecToOpen;

	public bool KeepBattleMode => _0024var_0024KeepBattleMode;

	public MFlags ClearFlag
	{
		get
		{
			if (ClearFlag__cache == null)
			{
				ClearFlag__cache = MFlags.Get(_0024var_0024ClearFlag);
			}
			return ClearFlag__cache;
		}
	}

	public MFlags ClearNotFlag
	{
		get
		{
			if (ClearNotFlag__cache == null)
			{
				ClearNotFlag__cache = MFlags.Get(_0024var_0024ClearNotFlag);
			}
			return ClearNotFlag__cache;
		}
	}

	public BattleOpenConditions OpenCondition => _0024var_0024OpenCondition;

	public bool IsRaidCameraMode => _0024var_0024IsRaidCameraMode;

	public float BattleCameraDistance => _0024var_0024BattleCameraDistance;

	public float BattleCameraHeight => _0024var_0024BattleCameraHeight;

	public static MStageBattles[] All
	{
		get
		{
			MStageBattles[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MStageBattles");
				MStageBattles[] array = (MStageBattles[])Builtins.array(typeof(MStageBattles), _0024mst_002468.Values);
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

	public MStageBattles()
	{
		_0024var_0024PreBattleCutSceneFade = true;
		_0024var_0024PostBattleCutSceneFade = true;
		_0024var_0024PostBattleCutScenePos = string.Empty;
		_0024var_0024BattleBgm = -1;
		_0024var_0024OpenCondition = BattleOpenConditions.None;
	}

	public static MStageBattles Find(int stageBattlesID)
	{
		int num = 0;
		MStageBattles[] all = All;
		int length = all.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (all[num].Id == stageBattlesID)
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
		return (MStageBattles)result;
	}

	public override string ToString()
	{
		return new StringBuilder("MStageBattles(").Append((object)Id).Append(",").Append(Progname)
			.Append(",")
			.Append(PositionObject)
			.Append(")")
			.ToString();
	}

	public static MStageBattles Get(int _id)
	{
		MerlinMaster.GetHandler("MStageBattles");
		return (!_0024mst_002468.ContainsKey(_id)) ? null : _0024mst_002468[_id];
	}

	public static void Unload()
	{
		_0024mst_002468.Clear();
		All_cache = null;
	}

	public static MStageBattles New(Hashtable data)
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
			MStageBattles mStageBattles = Create(data);
			if (!_0024mst_002468.ContainsKey(mStageBattles.Id))
			{
				_0024mst_002468[mStageBattles.Id] = mStageBattles;
			}
			result = mStageBattles;
		}
		return (MStageBattles)result;
	}

	public static MStageBattles New2(string[] keys, object[] vals)
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
		return (MStageBattles)result;
	}

	public static MStageBattles Entry(MStageBattles mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002468[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MStageBattles)result;
	}

	public static void AddMst(MStageBattles mst)
	{
		if (mst != null)
		{
			_0024mst_002468[mst.Id] = mst;
		}
	}

	public static MStageBattles Create(Hashtable data)
	{
		MStageBattles mStageBattles = new MStageBattles();
		MStageBattles result;
		if (data == null)
		{
			result = mStageBattles;
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
				mStageBattles.setField((string)obj, data[current]);
			}
			result = mStageBattles;
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
		case "PositionObject":
			_0024var_0024PositionObject = MasterBaseClass.ToStringValue(val);
			break;
		case "MStageMonsters_Id_1":
			_0024var_0024MStageMonsters_Id_1 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_2":
			_0024var_0024MStageMonsters_Id_2 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_3":
			_0024var_0024MStageMonsters_Id_3 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_4":
			_0024var_0024MStageMonsters_Id_4 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_5":
			_0024var_0024MStageMonsters_Id_5 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_6":
			_0024var_0024MStageMonsters_Id_6 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_7":
			_0024var_0024MStageMonsters_Id_7 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_8":
			_0024var_0024MStageMonsters_Id_8 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_9":
			_0024var_0024MStageMonsters_Id_9 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_10":
			_0024var_0024MStageMonsters_Id_10 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_11":
			_0024var_0024MStageMonsters_Id_11 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_12":
			_0024var_0024MStageMonsters_Id_12 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_13":
			_0024var_0024MStageMonsters_Id_13 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_14":
			_0024var_0024MStageMonsters_Id_14 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_15":
			_0024var_0024MStageMonsters_Id_15 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_16":
			_0024var_0024MStageMonsters_Id_16 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_17":
			_0024var_0024MStageMonsters_Id_17 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_18":
			_0024var_0024MStageMonsters_Id_18 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_19":
			_0024var_0024MStageMonsters_Id_19 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_20":
			_0024var_0024MStageMonsters_Id_20 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_21":
			_0024var_0024MStageMonsters_Id_21 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_22":
			_0024var_0024MStageMonsters_Id_22 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_23":
			_0024var_0024MStageMonsters_Id_23 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_24":
			_0024var_0024MStageMonsters_Id_24 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_25":
			_0024var_0024MStageMonsters_Id_25 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_26":
			_0024var_0024MStageMonsters_Id_26 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_27":
			_0024var_0024MStageMonsters_Id_27 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_28":
			_0024var_0024MStageMonsters_Id_28 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_29":
			_0024var_0024MStageMonsters_Id_29 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_30":
			_0024var_0024MStageMonsters_Id_30 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_31":
			_0024var_0024MStageMonsters_Id_31 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_32":
			_0024var_0024MStageMonsters_Id_32 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_33":
			_0024var_0024MStageMonsters_Id_33 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_34":
			_0024var_0024MStageMonsters_Id_34 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_35":
			_0024var_0024MStageMonsters_Id_35 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_36":
			_0024var_0024MStageMonsters_Id_36 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_37":
			_0024var_0024MStageMonsters_Id_37 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_38":
			_0024var_0024MStageMonsters_Id_38 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_39":
			_0024var_0024MStageMonsters_Id_39 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_40":
			_0024var_0024MStageMonsters_Id_40 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_41":
			_0024var_0024MStageMonsters_Id_41 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_42":
			_0024var_0024MStageMonsters_Id_42 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_43":
			_0024var_0024MStageMonsters_Id_43 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_44":
			_0024var_0024MStageMonsters_Id_44 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_45":
			_0024var_0024MStageMonsters_Id_45 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_46":
			_0024var_0024MStageMonsters_Id_46 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_47":
			_0024var_0024MStageMonsters_Id_47 = MasterBaseClass.ToInt(val);
			break;
		case "MStageMonsters_Id_48":
			_0024var_0024MStageMonsters_Id_48 = MasterBaseClass.ToInt(val);
			break;
		case "PreBattleCutSceneFade":
			_0024var_0024PreBattleCutSceneFade = MasterBaseClass.ToBool(val);
			break;
		case "PreBattleCutScene":
			_0024var_0024PreBattleCutScene = MasterBaseClass.ToStringValue(val);
			break;
		case "PreBattleCutScenePos":
			_0024var_0024PreBattleCutScenePos = MasterBaseClass.ToStringValue(val);
			break;
		case "PreBattleFlag":
			_0024var_0024PreBattleFlag = MasterBaseClass.ToInt(val);
			break;
		case "PostBattleCutSceneFade":
			_0024var_0024PostBattleCutSceneFade = MasterBaseClass.ToBool(val);
			break;
		case "PostBattleCutScene":
			_0024var_0024PostBattleCutScene = MasterBaseClass.ToStringValue(val);
			break;
		case "PostBattleCutScenePos":
			_0024var_0024PostBattleCutScenePos = MasterBaseClass.ToStringValue(val);
			break;
		case "BattleBgm":
			_0024var_0024BattleBgm = MasterBaseClass.ToInt(val);
			break;
		case "WaitSecToOpen":
			_0024var_0024WaitSecToOpen = MasterBaseClass.ToInt(val);
			break;
		case "KeepBattleMode":
			_0024var_0024KeepBattleMode = MasterBaseClass.ToBool(val);
			break;
		case "ClearFlag":
			_0024var_0024ClearFlag = MasterBaseClass.ToInt(val);
			break;
		case "ClearNotFlag":
			_0024var_0024ClearNotFlag = MasterBaseClass.ToInt(val);
			break;
		case "OpenCondition":
			if (typeof(BattleOpenConditions).IsEnum)
			{
				_0024var_0024OpenCondition = (BattleOpenConditions)MasterBaseClass.ToEnum(val);
			}
			break;
		case "IsRaidCameraMode":
			_0024var_0024IsRaidCameraMode = MasterBaseClass.ToBool(val);
			break;
		case "BattleCameraDistance":
			_0024var_0024BattleCameraDistance = MasterBaseClass.ToSingle(val);
			break;
		case "BattleCameraHeight":
			_0024var_0024BattleCameraHeight = MasterBaseClass.ToSingle(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Progname" => true, 
			"PositionObject" => true, 
			"MStageMonsters_Id_1" => true, 
			"MStageMonsters_Id_2" => true, 
			"MStageMonsters_Id_3" => true, 
			"MStageMonsters_Id_4" => true, 
			"MStageMonsters_Id_5" => true, 
			"MStageMonsters_Id_6" => true, 
			"MStageMonsters_Id_7" => true, 
			"MStageMonsters_Id_8" => true, 
			"MStageMonsters_Id_9" => true, 
			"MStageMonsters_Id_10" => true, 
			"MStageMonsters_Id_11" => true, 
			"MStageMonsters_Id_12" => true, 
			"MStageMonsters_Id_13" => true, 
			"MStageMonsters_Id_14" => true, 
			"MStageMonsters_Id_15" => true, 
			"MStageMonsters_Id_16" => true, 
			"MStageMonsters_Id_17" => true, 
			"MStageMonsters_Id_18" => true, 
			"MStageMonsters_Id_19" => true, 
			"MStageMonsters_Id_20" => true, 
			"MStageMonsters_Id_21" => true, 
			"MStageMonsters_Id_22" => true, 
			"MStageMonsters_Id_23" => true, 
			"MStageMonsters_Id_24" => true, 
			"MStageMonsters_Id_25" => true, 
			"MStageMonsters_Id_26" => true, 
			"MStageMonsters_Id_27" => true, 
			"MStageMonsters_Id_28" => true, 
			"MStageMonsters_Id_29" => true, 
			"MStageMonsters_Id_30" => true, 
			"MStageMonsters_Id_31" => true, 
			"MStageMonsters_Id_32" => true, 
			"MStageMonsters_Id_33" => true, 
			"MStageMonsters_Id_34" => true, 
			"MStageMonsters_Id_35" => true, 
			"MStageMonsters_Id_36" => true, 
			"MStageMonsters_Id_37" => true, 
			"MStageMonsters_Id_38" => true, 
			"MStageMonsters_Id_39" => true, 
			"MStageMonsters_Id_40" => true, 
			"MStageMonsters_Id_41" => true, 
			"MStageMonsters_Id_42" => true, 
			"MStageMonsters_Id_43" => true, 
			"MStageMonsters_Id_44" => true, 
			"MStageMonsters_Id_45" => true, 
			"MStageMonsters_Id_46" => true, 
			"MStageMonsters_Id_47" => true, 
			"MStageMonsters_Id_48" => true, 
			"PreBattleCutSceneFade" => true, 
			"PreBattleCutScene" => true, 
			"PreBattleCutScenePos" => true, 
			"PreBattleFlag" => true, 
			"PostBattleCutSceneFade" => true, 
			"PostBattleCutScene" => true, 
			"PostBattleCutScenePos" => true, 
			"BattleBgm" => true, 
			"WaitSecToOpen" => true, 
			"KeepBattleMode" => true, 
			"ClearFlag" => true, 
			"ClearNotFlag" => true, 
			"OpenCondition" => true, 
			"IsRaidCameraMode" => true, 
			"BattleCameraDistance" => true, 
			"BattleCameraHeight" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[67]
		{
			"Id", "Progname", "PositionObject", "MStageMonsters_Id_1", "MStageMonsters_Id_2", "MStageMonsters_Id_3", "MStageMonsters_Id_4", "MStageMonsters_Id_5", "MStageMonsters_Id_6", "MStageMonsters_Id_7",
			"MStageMonsters_Id_8", "MStageMonsters_Id_9", "MStageMonsters_Id_10", "MStageMonsters_Id_11", "MStageMonsters_Id_12", "MStageMonsters_Id_13", "MStageMonsters_Id_14", "MStageMonsters_Id_15", "MStageMonsters_Id_16", "MStageMonsters_Id_17",
			"MStageMonsters_Id_18", "MStageMonsters_Id_19", "MStageMonsters_Id_20", "MStageMonsters_Id_21", "MStageMonsters_Id_22", "MStageMonsters_Id_23", "MStageMonsters_Id_24", "MStageMonsters_Id_25", "MStageMonsters_Id_26", "MStageMonsters_Id_27",
			"MStageMonsters_Id_28", "MStageMonsters_Id_29", "MStageMonsters_Id_30", "MStageMonsters_Id_31", "MStageMonsters_Id_32", "MStageMonsters_Id_33", "MStageMonsters_Id_34", "MStageMonsters_Id_35", "MStageMonsters_Id_36", "MStageMonsters_Id_37",
			"MStageMonsters_Id_38", "MStageMonsters_Id_39", "MStageMonsters_Id_40", "MStageMonsters_Id_41", "MStageMonsters_Id_42", "MStageMonsters_Id_43", "MStageMonsters_Id_44", "MStageMonsters_Id_45", "MStageMonsters_Id_46", "MStageMonsters_Id_47",
			"MStageMonsters_Id_48", "PreBattleCutSceneFade", "PreBattleCutScene", "PreBattleCutScenePos", "PreBattleFlag", "PostBattleCutSceneFade", "PostBattleCutScene", "PostBattleCutScenePos", "BattleBgm", "WaitSecToOpen",
			"KeepBattleMode", "ClearFlag", "ClearNotFlag", "OpenCondition", "IsRaidCameraMode", "BattleCameraDistance", "BattleCameraHeight"
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
						_0024var_0024PositionObject = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024MStageMonsters_Id_1 = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024MStageMonsters_Id_2 = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024MStageMonsters_Id_3 = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024MStageMonsters_Id_4 = MasterBaseClass.ParseInt(vals[6]);
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024MStageMonsters_Id_5 = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024MStageMonsters_Id_6 = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024MStageMonsters_Id_7 = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024MStageMonsters_Id_8 = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024MStageMonsters_Id_9 = MasterBaseClass.ParseInt(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024MStageMonsters_Id_10 = MasterBaseClass.ParseInt(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024MStageMonsters_Id_11 = MasterBaseClass.ParseInt(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024MStageMonsters_Id_12 = MasterBaseClass.ParseInt(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null)
																		{
																			_0024var_0024MStageMonsters_Id_13 = MasterBaseClass.ParseInt(vals[15]);
																		}
																		if (length <= 16)
																		{
																			result = 16;
																		}
																		else
																		{
																			if (vals[16] != null)
																			{
																				_0024var_0024MStageMonsters_Id_14 = MasterBaseClass.ParseInt(vals[16]);
																			}
																			if (length <= 17)
																			{
																				result = 17;
																			}
																			else
																			{
																				if (vals[17] != null)
																				{
																					_0024var_0024MStageMonsters_Id_15 = MasterBaseClass.ParseInt(vals[17]);
																				}
																				if (length <= 18)
																				{
																					result = 18;
																				}
																				else
																				{
																					if (vals[18] != null)
																					{
																						_0024var_0024MStageMonsters_Id_16 = MasterBaseClass.ParseInt(vals[18]);
																					}
																					if (length <= 19)
																					{
																						result = 19;
																					}
																					else
																					{
																						if (vals[19] != null)
																						{
																							_0024var_0024MStageMonsters_Id_17 = MasterBaseClass.ParseInt(vals[19]);
																						}
																						if (length <= 20)
																						{
																							result = 20;
																						}
																						else
																						{
																							if (vals[20] != null)
																							{
																								_0024var_0024MStageMonsters_Id_18 = MasterBaseClass.ParseInt(vals[20]);
																							}
																							if (length <= 21)
																							{
																								result = 21;
																							}
																							else
																							{
																								if (vals[21] != null)
																								{
																									_0024var_0024MStageMonsters_Id_19 = MasterBaseClass.ParseInt(vals[21]);
																								}
																								if (length <= 22)
																								{
																									result = 22;
																								}
																								else
																								{
																									if (vals[22] != null)
																									{
																										_0024var_0024MStageMonsters_Id_20 = MasterBaseClass.ParseInt(vals[22]);
																									}
																									if (length <= 23)
																									{
																										result = 23;
																									}
																									else
																									{
																										if (vals[23] != null)
																										{
																											_0024var_0024MStageMonsters_Id_21 = MasterBaseClass.ParseInt(vals[23]);
																										}
																										if (length <= 24)
																										{
																											result = 24;
																										}
																										else
																										{
																											if (vals[24] != null)
																											{
																												_0024var_0024MStageMonsters_Id_22 = MasterBaseClass.ParseInt(vals[24]);
																											}
																											if (length <= 25)
																											{
																												result = 25;
																											}
																											else
																											{
																												if (vals[25] != null)
																												{
																													_0024var_0024MStageMonsters_Id_23 = MasterBaseClass.ParseInt(vals[25]);
																												}
																												if (length <= 26)
																												{
																													result = 26;
																												}
																												else
																												{
																													if (vals[26] != null)
																													{
																														_0024var_0024MStageMonsters_Id_24 = MasterBaseClass.ParseInt(vals[26]);
																													}
																													if (length <= 27)
																													{
																														result = 27;
																													}
																													else
																													{
																														if (vals[27] != null)
																														{
																															_0024var_0024MStageMonsters_Id_25 = MasterBaseClass.ParseInt(vals[27]);
																														}
																														if (length <= 28)
																														{
																															result = 28;
																														}
																														else
																														{
																															if (vals[28] != null)
																															{
																																_0024var_0024MStageMonsters_Id_26 = MasterBaseClass.ParseInt(vals[28]);
																															}
																															if (length <= 29)
																															{
																																result = 29;
																															}
																															else
																															{
																																if (vals[29] != null)
																																{
																																	_0024var_0024MStageMonsters_Id_27 = MasterBaseClass.ParseInt(vals[29]);
																																}
																																if (length <= 30)
																																{
																																	result = 30;
																																}
																																else
																																{
																																	if (vals[30] != null)
																																	{
																																		_0024var_0024MStageMonsters_Id_28 = MasterBaseClass.ParseInt(vals[30]);
																																	}
																																	if (length <= 31)
																																	{
																																		result = 31;
																																	}
																																	else
																																	{
																																		if (vals[31] != null)
																																		{
																																			_0024var_0024MStageMonsters_Id_29 = MasterBaseClass.ParseInt(vals[31]);
																																		}
																																		if (length <= 32)
																																		{
																																			result = 32;
																																		}
																																		else
																																		{
																																			if (vals[32] != null)
																																			{
																																				_0024var_0024MStageMonsters_Id_30 = MasterBaseClass.ParseInt(vals[32]);
																																			}
																																			if (length <= 33)
																																			{
																																				result = 33;
																																			}
																																			else
																																			{
																																				if (vals[33] != null)
																																				{
																																					_0024var_0024MStageMonsters_Id_31 = MasterBaseClass.ParseInt(vals[33]);
																																				}
																																				if (length <= 34)
																																				{
																																					result = 34;
																																				}
																																				else
																																				{
																																					if (vals[34] != null)
																																					{
																																						_0024var_0024MStageMonsters_Id_32 = MasterBaseClass.ParseInt(vals[34]);
																																					}
																																					if (length <= 35)
																																					{
																																						result = 35;
																																					}
																																					else
																																					{
																																						if (vals[35] != null)
																																						{
																																							_0024var_0024MStageMonsters_Id_33 = MasterBaseClass.ParseInt(vals[35]);
																																						}
																																						if (length <= 36)
																																						{
																																							result = 36;
																																						}
																																						else
																																						{
																																							if (vals[36] != null)
																																							{
																																								_0024var_0024MStageMonsters_Id_34 = MasterBaseClass.ParseInt(vals[36]);
																																							}
																																							if (length <= 37)
																																							{
																																								result = 37;
																																							}
																																							else
																																							{
																																								if (vals[37] != null)
																																								{
																																									_0024var_0024MStageMonsters_Id_35 = MasterBaseClass.ParseInt(vals[37]);
																																								}
																																								if (length <= 38)
																																								{
																																									result = 38;
																																								}
																																								else
																																								{
																																									if (vals[38] != null)
																																									{
																																										_0024var_0024MStageMonsters_Id_36 = MasterBaseClass.ParseInt(vals[38]);
																																									}
																																									if (length <= 39)
																																									{
																																										result = 39;
																																									}
																																									else
																																									{
																																										if (vals[39] != null)
																																										{
																																											_0024var_0024MStageMonsters_Id_37 = MasterBaseClass.ParseInt(vals[39]);
																																										}
																																										if (length <= 40)
																																										{
																																											result = 40;
																																										}
																																										else
																																										{
																																											if (vals[40] != null)
																																											{
																																												_0024var_0024MStageMonsters_Id_38 = MasterBaseClass.ParseInt(vals[40]);
																																											}
																																											if (length <= 41)
																																											{
																																												result = 41;
																																											}
																																											else
																																											{
																																												if (vals[41] != null)
																																												{
																																													_0024var_0024MStageMonsters_Id_39 = MasterBaseClass.ParseInt(vals[41]);
																																												}
																																												if (length <= 42)
																																												{
																																													result = 42;
																																												}
																																												else
																																												{
																																													if (vals[42] != null)
																																													{
																																														_0024var_0024MStageMonsters_Id_40 = MasterBaseClass.ParseInt(vals[42]);
																																													}
																																													if (length <= 43)
																																													{
																																														result = 43;
																																													}
																																													else
																																													{
																																														if (vals[43] != null)
																																														{
																																															_0024var_0024MStageMonsters_Id_41 = MasterBaseClass.ParseInt(vals[43]);
																																														}
																																														if (length <= 44)
																																														{
																																															result = 44;
																																														}
																																														else
																																														{
																																															if (vals[44] != null)
																																															{
																																																_0024var_0024MStageMonsters_Id_42 = MasterBaseClass.ParseInt(vals[44]);
																																															}
																																															if (length <= 45)
																																															{
																																																result = 45;
																																															}
																																															else
																																															{
																																																if (vals[45] != null)
																																																{
																																																	_0024var_0024MStageMonsters_Id_43 = MasterBaseClass.ParseInt(vals[45]);
																																																}
																																																if (length <= 46)
																																																{
																																																	result = 46;
																																																}
																																																else
																																																{
																																																	if (vals[46] != null)
																																																	{
																																																		_0024var_0024MStageMonsters_Id_44 = MasterBaseClass.ParseInt(vals[46]);
																																																	}
																																																	if (length <= 47)
																																																	{
																																																		result = 47;
																																																	}
																																																	else
																																																	{
																																																		if (vals[47] != null)
																																																		{
																																																			_0024var_0024MStageMonsters_Id_45 = MasterBaseClass.ParseInt(vals[47]);
																																																		}
																																																		if (length <= 48)
																																																		{
																																																			result = 48;
																																																		}
																																																		else
																																																		{
																																																			if (vals[48] != null)
																																																			{
																																																				_0024var_0024MStageMonsters_Id_46 = MasterBaseClass.ParseInt(vals[48]);
																																																			}
																																																			if (length <= 49)
																																																			{
																																																				result = 49;
																																																			}
																																																			else
																																																			{
																																																				if (vals[49] != null)
																																																				{
																																																					_0024var_0024MStageMonsters_Id_47 = MasterBaseClass.ParseInt(vals[49]);
																																																				}
																																																				if (length <= 50)
																																																				{
																																																					result = 50;
																																																				}
																																																				else
																																																				{
																																																					if (vals[50] != null)
																																																					{
																																																						_0024var_0024MStageMonsters_Id_48 = MasterBaseClass.ParseInt(vals[50]);
																																																					}
																																																					if (length <= 51)
																																																					{
																																																						result = 51;
																																																					}
																																																					else
																																																					{
																																																						if (vals[51] != null)
																																																						{
																																																							_0024var_0024PreBattleCutSceneFade = MasterBaseClass.ParseBool(vals[51]);
																																																						}
																																																						if (length <= 52)
																																																						{
																																																							result = 52;
																																																						}
																																																						else
																																																						{
																																																							if (vals[52] != null)
																																																							{
																																																								_0024var_0024PreBattleCutScene = vals[52];
																																																							}
																																																							if (length <= 53)
																																																							{
																																																								result = 53;
																																																							}
																																																							else
																																																							{
																																																								if (vals[53] != null)
																																																								{
																																																									_0024var_0024PreBattleCutScenePos = vals[53];
																																																								}
																																																								if (length <= 54)
																																																								{
																																																									result = 54;
																																																								}
																																																								else
																																																								{
																																																									if (vals[54] != null)
																																																									{
																																																										_0024var_0024PreBattleFlag = MasterBaseClass.ParseInt(vals[54]);
																																																									}
																																																									if (length <= 55)
																																																									{
																																																										result = 55;
																																																									}
																																																									else
																																																									{
																																																										if (vals[55] != null)
																																																										{
																																																											_0024var_0024PostBattleCutSceneFade = MasterBaseClass.ParseBool(vals[55]);
																																																										}
																																																										if (length <= 56)
																																																										{
																																																											result = 56;
																																																										}
																																																										else
																																																										{
																																																											if (vals[56] != null)
																																																											{
																																																												_0024var_0024PostBattleCutScene = vals[56];
																																																											}
																																																											if (length <= 57)
																																																											{
																																																												result = 57;
																																																											}
																																																											else
																																																											{
																																																												if (vals[57] != null)
																																																												{
																																																													_0024var_0024PostBattleCutScenePos = vals[57];
																																																												}
																																																												if (length <= 58)
																																																												{
																																																													result = 58;
																																																												}
																																																												else
																																																												{
																																																													if (vals[58] != null)
																																																													{
																																																														_0024var_0024BattleBgm = MasterBaseClass.ParseInt(vals[58]);
																																																													}
																																																													if (length <= 59)
																																																													{
																																																														result = 59;
																																																													}
																																																													else
																																																													{
																																																														if (vals[59] != null)
																																																														{
																																																															_0024var_0024WaitSecToOpen = MasterBaseClass.ParseInt(vals[59]);
																																																														}
																																																														if (length <= 60)
																																																														{
																																																															result = 60;
																																																														}
																																																														else
																																																														{
																																																															if (vals[60] != null)
																																																															{
																																																																_0024var_0024KeepBattleMode = MasterBaseClass.ParseBool(vals[60]);
																																																															}
																																																															if (length <= 61)
																																																															{
																																																																result = 61;
																																																															}
																																																															else
																																																															{
																																																																if (vals[61] != null)
																																																																{
																																																																	_0024var_0024ClearFlag = MasterBaseClass.ParseInt(vals[61]);
																																																																}
																																																																if (length <= 62)
																																																																{
																																																																	result = 62;
																																																																}
																																																																else
																																																																{
																																																																	if (vals[62] != null)
																																																																	{
																																																																		_0024var_0024ClearNotFlag = MasterBaseClass.ParseInt(vals[62]);
																																																																	}
																																																																	if (length <= 63)
																																																																	{
																																																																		result = 63;
																																																																	}
																																																																	else
																																																																	{
																																																																		if (vals[63] != null && typeof(BattleOpenConditions).IsEnum)
																																																																		{
																																																																			_0024var_0024OpenCondition = (BattleOpenConditions)MasterBaseClass.ParseEnum(vals[63]);
																																																																		}
																																																																		if (length <= 64)
																																																																		{
																																																																			result = 64;
																																																																		}
																																																																		else
																																																																		{
																																																																			if (vals[64] != null)
																																																																			{
																																																																				_0024var_0024IsRaidCameraMode = MasterBaseClass.ParseBool(vals[64]);
																																																																			}
																																																																			if (length <= 65)
																																																																			{
																																																																				result = 65;
																																																																			}
																																																																			else
																																																																			{
																																																																				if (vals[65] != null)
																																																																				{
																																																																					_0024var_0024BattleCameraDistance = MasterBaseClass.ParseSingle(vals[65]);
																																																																				}
																																																																				if (length <= 66)
																																																																				{
																																																																					result = 66;
																																																																				}
																																																																				else
																																																																				{
																																																																					if (vals[66] != null)
																																																																					{
																																																																						_0024var_0024BattleCameraHeight = MasterBaseClass.ParseSingle(vals[66]);
																																																																					}
																																																																					int num = 67;
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
		return result;
	}
}
