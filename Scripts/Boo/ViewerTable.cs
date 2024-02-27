using System;
using Boo.Lang;

[Serializable]
public class ViewerTable
{
	[NonSerialized]
	public const string VIEWR_CHAR_TAG = "TestChar";

	[NonSerialized]
	public const string MODEL_FBX_PATH = "/Model";

	[NonSerialized]
	public const string EFFECT_PREFAB_PATH = "Assets/Effect/_Ef_Prefab";

	[NonSerialized]
	public static readonly Hash CHARCTER_ATTR_TABLE = new Hash
	{
		{
			"c0000",
			new string[1] { "主人公（チビ天使男）" }
		},
		{
			"c0001",
			new string[1] { "主人公（チビ悪魔男）" }
		},
		{
			"c0002",
			new string[1] { "主人公（チビ天使女）" }
		},
		{
			"c0003",
			new string[1] { "主人公（チビ悪魔女）" }
		},
		{
			"c5000",
			new string[1] { "カカオ" }
		},
		{
			"c5001",
			new string[1] { "カルカオ" }
		},
		{
			"c5002",
			new string[1] { "NPC（人型男）" }
		},
		{
			"c5003",
			new string[1] { "NPC（人型女）" }
		},
		{
			"c5004",
			new string[1] { "NPC（狼型）" }
		},
		{
			"c5005",
			new string[1] { "NPC（猫型）" }
		},
		{
			"c9000",
			new string[1] { "宝箱" }
		},
		{
			"e0000",
			new string[1] { "スケルトン" }
		},
		{
			"e0001",
			new string[1] { "ラビ" }
		},
		{
			"e0002",
			new string[1] { "マイコニド" }
		},
		{
			"e0003",
			new string[1] { "ランドドラゴン" }
		},
		{
			"e0004",
			new string[1] { "スカイドラゴン" }
		},
		{
			"e0005",
			new string[1] { "パンプキンボム " }
		},
		{
			"e0006",
			new string[1] { "デスクラブ" }
		},
		{
			"e0007",
			new string[1] { "グリフォンハンド" }
		},
		{
			"e0008",
			new string[1] { "キラービー" }
		},
		{
			"e0025",
			new string[1] { "バットム" }
		},
		{
			"e5000",
			new string[1] { "フルメタルハガー（旧）" }
		},
		{
			"e5001",
			new string[1] { "フルメタルハガー" }
		},
		{
			"e5002",
			new string[1] { "ジャッカル" }
		},
		{
			"p0000",
			new string[1] { "魔ペット（スケルトン）" }
		},
		{
			"p5000",
			new string[1] { "魔ペット（ロッテ）" }
		}
	};

	[NonSerialized]
	public static readonly Hash MOT2EFF_TABLE = new Hash();

	[NonSerialized]
	public static readonly Hash EFFECT_TABLE = new Hash
	{
		{
			"Ef_e0000_bt_atk1",
			new object[5]
			{
				"Ef_e0000_bt_atk1",
				"r_hand",
				true,
				true,
				new double[3] { 0.0, 0.5, 0.0 }
			}
		},
		{
			"Ef_e0001_bt_atk1",
			new object[5]
			{
				"Ef_e0001_bt_atk1",
				"c_head",
				true,
				true,
				new double[3] { -0.5, 0.5, 0.0 }
			}
		},
		{
			"Ef_e0001_bt_atk2",
			new object[5]
			{
				"Ef_e0001_bt_atk1",
				"c_head",
				true,
				true,
				new double[3] { 0.5, 0.5, 0.0 }
			}
		},
		{
			"Ef_e0002_bt_atk1",
			new object[5] { "Ef_e0002_bt_atk1", "y_ang", true, true, null }
		},
		{
			"Ef_e0002_bt_atk2",
			new object[5] { "Ef_e0002_bt_atk2", "c_umbrella_a", true, true, null }
		},
		{
			"Ef_e0003_bt_atk1",
			new object[5] { "Ef_e0003_bt_atk1", "c_mouth", true, true, null }
		},
		{
			"Ef_e0003_bt_atk4",
			new object[5] { "Ef_e0003_bt_atk4", "y_ang", true, true, null }
		},
		{
			"Ef_e0004_bt_atk1",
			new object[5] { "Ef_e0004_bt_atk1", "c_head", true, true, null }
		},
		{
			"Ef_e0004_bt_atk2",
			new object[5] { "Ef_e0004_bt_atk2", "c_tail_c", true, true, null }
		},
		{
			"Ef_e0004_bt_atk3",
			new object[5] { "Ef_e0004_bt_atk2", "c_head", true, true, null }
		},
		{
			"Ef_e0004_bt_atk4",
			new object[5]
			{
				"Ef_e0004_bt_atk2",
				"l_foot",
				true,
				true,
				new double[3] { 0.0, 0.0, 0.3 }
			}
		},
		{
			"Ef_e0005_bt_atk1_Dig",
			new object[5] { "Ef_e0005_bt_atk1_Dig", "y_ang", true, true, null }
		},
		{
			"Ef_e0005_bt_atk1_Bomb",
			new object[5] { "Ef_e0005_bt_atk1_Bomb", "y_ang", true, true, null }
		},
		{
			"Ef_e0005_bt_atk2",
			new object[5]
			{
				"Ef_e0005_bt_atk2",
				"cog",
				true,
				true,
				new double[3] { 0.0, 1.5, 2.0 }
			}
		},
		{
			"Ef_e0005_bt_atk3",
			new object[5] { "Ef_e0005_bt_atk3", "y_ang", true, true, null }
		},
		{
			"Ef_e0008_bt_atk1",
			new object[5] { "Ef_e0008_bt_atk1", "c_spine_c", true, true, null }
		},
		{
			"Ef_e0008_bt_atk2",
			new object[5] { "Ef_e0008_bt_atk2", "c_hip_b", true, true, null }
		},
		{
			"Ef_e0008_bt_atk3",
			new object[5] { "Ef_e0008_bt_atk3", "c_hip_b", true, true, null }
		},
		{
			"Ef_e0019_bt_atk1",
			new object[5] { "Ef_e0019_bt_atk1", "c_tail_e", true, true, null }
		},
		{
			"Ef_e0019_bt_atk1_Needle",
			new object[5]
			{
				"Ef_e0019_bt_atk1_Needle",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 1.0, 1.0 }
			}
		},
		{
			"Ef_e0019_bt_atk2",
			new object[5] { "Ef_e0019_bt_atk2", "c_tail_e", true, true, null }
		},
		{
			"Ef_e0020_bt_atk1",
			new object[5] { "Ef_e0020_bt_atk1", "c_head", true, true, null }
		},
		{
			"Ef_e0020_bt_atk2",
			new object[5] { "Ef_e0020_bt_atk2", "y_ang", true, true, null }
		},
		{
			"Ef_e0020_bt_atk3",
			new object[5] { "Ef_e0020_bt_atk3", "c_head", true, true, null }
		},
		{
			"Ef_e0020_bt_atk4",
			new object[5] { "Ef_e0020_bt_atk4", "y_ang", true, true, null }
		},
		{
			"Ef_Claw_l45",
			new object[5] { "Ef_Claw_l45", "y_ang", false, false, null }
		},
		{
			"Ef_Claw_r45",
			new object[5] { "Ef_Claw_r45", "y_ang", false, false, null }
		},
		{
			"Ef_Claw_l80",
			new object[5] { "Ef_Claw_l80", "y_ang", false, false, null }
		},
		{
			"Ef_Slash_0",
			new object[5] { "Ef_Slash_0", "y_ang", false, false, null }
		},
		{
			"Ef_Slash_l45",
			new object[5] { "Ef_Slash_l45", "y_ang", false, false, null }
		},
		{
			"Ef_Slash_r45",
			new object[5] { "Ef_Slash_r45", "y_ang", false, false, null }
		},
		{
			"Ef_Slash_l80",
			new object[5] { "Ef_Slash_l80", "y_ang", false, false, null }
		},
		{
			"Ef_Slash_l90",
			new object[5] { "Ef_Slash_l90", "y_ang", false, false, null }
		},
		{
			"Ef_Slash_r90",
			new object[5] { "Ef_Slash_r90", "y_ang", false, false, null }
		},
		{
			"Ef_Slash_l135",
			new object[5] { "Ef_Slash_l135", "y_ang", false, false, null }
		},
		{
			"Ef_Slash_r135",
			new object[5] { "Ef_Slash_r135", "y_ang", false, false, null }
		},
		{
			"Ef_AfterImage",
			new object[5] { "Ef_AfterImage", "y_ang", false, false, null }
		},
		{
			"Ef_landdragon_fire",
			new object[5] { "Ef_fireBreathBase", "c_head", true, true, null }
		},
		{
			"Ef_Blur",
			new object[5] { "Ef_Blur", "y_ang", false, true, null }
		},
		{
			"Ef_Bubble",
			new object[5] { "Ef_Bubble", "y_ang", true, true, null }
		},
		{
			"Ef_Condition_Burn",
			new object[5] { "Ef_Condition_Burn", "c_hip", true, true, null }
		},
		{
			"Ef_Condition_Burn_h",
			new object[5] { "Ef_Condition_Burn", "c_head", true, true, null }
		},
		{
			"Ef_Condition_Stun",
			new object[5] { "Ef_Condition_Stun", "c_hip", true, true, null }
		},
		{
			"Ef_Drain",
			new object[5] { "Ef_Drain", "y_ang", false, false, null }
		},
		{
			"Ef_FireBreathBase",
			new object[5] { "Ef_FireBreathBase", "y_ang", true, true, null }
		},
		{
			"Ef_IceBallBase",
			new object[5] { "Ef_IceBallBase", "y_ang", true, true, null }
		},
		{
			"Ef_Luminous",
			new object[5]
			{
				"Ef_Luminous",
				"r_weapon_1",
				true,
				true,
				new double[3] { -1.0, 0.0, 0.0 }
			}
		},
		{
			"Ef_Smoke_Dead",
			new object[5] { "Ef_Smoke_Dead", "y_ang", true, true, null }
		},
		{
			"Ef_Smoke_Jump",
			new object[5] { "Ef_Smoke_Jump", "y_ang", false, false, null }
		},
		{
			"Ef_Smoke_Jump_Lage",
			new object[5] { "Ef_Smoke_Jump_Lage", "y_ang", false, false, null }
		},
		{
			"Ef_Smoke_Jump_Small",
			new object[5] { "Ef_Smoke_Jump_Small", "y_ang", false, false, null }
		},
		{
			"Ef_Smoke_Pop",
			new object[5] { "Ef_Smoke_Pop", "y_ang", true, true, null }
		},
		{
			"Ef_Smoke_Run",
			new object[5] { "Ef_Smoke_Run", "y_ang", false, false, null }
		},
		{
			"Ef_Sonic_Air_lf",
			new object[5] { "Ef_Sonic_Air_Punch", "l_foot", false, false, null }
		},
		{
			"Ef_Sonic_Air_rf",
			new object[5] { "Ef_Sonic_Air_Punch", "r_foot", false, false, null }
		},
		{
			"Ef_Sonic_Air_lh",
			new object[5] { "Ef_Sonic_Air_Punch", "l_hand", false, false, null }
		},
		{
			"Ef_Sonic_Air_rh",
			new object[5] { "Ef_Sonic_Air_Punch", "r_hand", false, false, null }
		},
		{
			"Ef_Sonic_Air_bow_sk3",
			new object[5]
			{
				"Ef_Sonic_Air_bow_sk3",
				"y_ang",
				false,
				true,
				new double[3] { 0.0, 2.0, 0.8 }
			}
		},
		{
			"Ef_Sonic_Air_bow_sk9",
			new object[5]
			{
				"Ef_Sonic_Air_bow_sk9",
				"y_ang",
				false,
				true,
				new double[3] { 0.0, 1.5, -0.5 }
			}
		},
		{
			"Ef_Sonic_Air_bow_sk10",
			new object[5] { "Ef_Sonic_Air_bow_sk10", "l_weapon_1", false, false, null }
		},
		{
			"Ef_Sonic_Air_bow_sk12",
			new object[5]
			{
				"Ef_Sonic_Air_bow_sk12",
				"y_ang",
				false,
				true,
				new double[3] { 0.0, 3.0, 1.0 }
			}
		},
		{
			"Ef_Sonic_Air_spr_sk3",
			new object[5] { "Ef_Sonic_Air_spr_sk3", "y_ang", false, true, null }
		},
		{
			"Ef_Sonic_Air_spr_sk9",
			new object[5]
			{
				"Ef_Sonic_Air_S",
				"y_ang",
				false,
				true,
				new double[3] { -0.3, 0.5, 1.5 }
			}
		},
		{
			"Ef_Sonic_Air_spr_sk13",
			new object[5]
			{
				"Ef_Sonic_Air",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.7, 1.0 }
			}
		},
		{
			"Ef_Sonic_Air_spr_sk14",
			new object[5]
			{
				"Ef_Sonic_Air",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.0, 3.0 }
			}
		},
		{
			"Ef_Sonic_Air_spr_sk15",
			new object[5]
			{
				"Ef_Sonic_Air",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.0, 3.0 }
			}
		},
		{
			"Ef_Sonic_Air_hth_sk11",
			new object[5] { "Ef_Sonic_Air_hth_sk11", "l_foot", false, false, null }
		},
		{
			"Ef_Sonic_Blast",
			new object[5] { "Ef_Sonic_Blast", "l_hand", false, false, null }
		},
		{
			"Ef_Sonic_Cone_1hs_sk5",
			new object[5]
			{
				"Ef_Sonic_Cone_1hs_sk5",
				"y_ang",
				false,
				false,
				new double[3] { 0.3, 0.8, 1.0 }
			}
		},
		{
			"Ef_Sonic_Cone_spr_sk2",
			new object[5] { "Ef_Sonic_Cone_spr_sk2", "r_weapon_1", true, true, null }
		},
		{
			"Ef_Sonic_Cone_spr_sk14",
			new object[5]
			{
				"Ef_Sonic_Cone_spr_sk14",
				"y_ang",
				false,
				false,
				new double[3] { 0.3, 0.6, 2.0 }
			}
		},
		{
			"Ef_Sonic_Dash",
			new object[5]
			{
				"Ef_Sonic_Dash",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.8, 2.0 }
			}
		},
		{
			"Ef_Sonic_Front",
			new object[5] { "Ef_Sonic_Front", "y_ang", false, false, null }
		},
		{
			"Ef_Sonic_Front_Large",
			new object[5] { "Ef_Sonic_Front_Large", "y_ang", false, false, null }
		},
		{
			"Ef_Sonic_Round",
			new object[5] { "Ef_Sonic_Round", "y_ang", false, false, null }
		},
		{
			"Ef_Sonic_Round_spr_sk3",
			new object[5]
			{
				"Ef_Sonic_Round",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.0, 0.5 }
			}
		},
		{
			"Ef_Sonic_Round_spr_sk13",
			new object[5]
			{
				"Ef_Sonic_Round",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.0, 2.0 }
			}
		},
		{
			"Ef_Sonic_Round_Small_spr_sk6",
			new object[5]
			{
				"Ef_Sonic_Round_Small",
				"y_ang",
				false,
				false,
				new double[3] { 0.4, 0.0, 0.5 }
			}
		},
		{
			"Ef_Sonic_Round_Lage",
			new object[5] { "Ef_Sonic_Round_Lage", "y_ang", false, false, null }
		},
		{
			"Ef_Sonic_Round_Water",
			new object[5] { "Ef_Sonic_Round_Water", "y_ang", false, false, null }
		},
		{
			"Ef_Sonic_Slash",
			new object[5] { "Ef_Sonic_Slash", "y_ang", false, false, null }
		},
		{
			"Ef_Sonic_Slash_l",
			new object[5] { "Ef_Sonic_Slash_l", "y_ang", false, false, null }
		},
		{
			"Ef_Sonic_Slash_r",
			new object[5] { "Ef_Sonic_Slash_r", "y_ang", false, false, null }
		},
		{
			"Ef_Sonic_Sphere",
			new object[5] { "Ef_Sonic_Sphere", "y_ang", false, false, null }
		},
		{
			"Ef_Sonic_Spin",
			new object[5] { "Ef_Sonic_Spin", "y_ang", false, false, null }
		},
		{
			"Ef_Sonic_Spin_r",
			new object[5] { "Ef_Sonic_Spin_r", "y_ang", false, false, null }
		},
		{
			"Ef_Sonic_Thrust",
			new object[5] { "Ef_Sonic_Thrust", "y_ang", false, false, null }
		},
		{
			"Ef_Sonic_Thrust_spr_sk9a",
			new object[5]
			{
				"Ef_Sonic_Thrust_spr_sk10a",
				"r_weapon_1",
				false,
				true,
				new double[3] { 0.0, 0.0, -1.0 }
			}
		},
		{
			"Ef_Sonic_Thrust_spr_sk9b",
			new object[5] { "Ef_Sonic_Thrust_spr_sk10b", "r_weapon_1", false, true, null }
		},
		{
			"Ef_Sonic_Thrust_spr_sk10a",
			new object[5] { "Ef_Sonic_Thrust_spr_sk10a", "r_weapon_1", false, true, null }
		},
		{
			"Ef_Sonic_Thrust_spr_sk10b",
			new object[5] { "Ef_Sonic_Thrust_spr_sk10b", "r_weapon_1", false, true, null }
		},
		{
			"Ef_Sonic_Tornado",
			new object[5] { "Ef_Sonic_Tornado", "y_ang", false, false, null }
		},
		{
			"Ef_Sonic_Tornado_OneShot",
			new object[5] { "Ef_Sonic_Tornado_OneShot", "y_ang", false, false, null }
		},
		{
			"Ef_Sonic_Uprise",
			new object[5]
			{
				"Ef_Sonic_Uprise",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.0, 1.5 }
			}
		},
		{
			"Ef_Sonic_Uprise_Small",
			new object[5]
			{
				"Ef_Sonic_Uprise_Small",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.0, -1.0 }
			}
		},
		{
			"Ef_Sonic_Uprise_Small_spr_sk5",
			new object[5]
			{
				"Ef_Sonic_Uprise_Small",
				"y_ang",
				false,
				false,
				new double[3]
			}
		},
		{
			"Ef_Sonic_Uprise_Lage_spr_sk6",
			new object[5]
			{
				"Ef_Sonic_Uprise_Lage",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.0, 5.0 }
			}
		},
		{
			"Ef_Sonic_Uprise_Line",
			new object[5]
			{
				"Ef_Sonic_Uprise_Line",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.0, 1.0 }
			}
		},
		{
			"Ef_SonicBoom",
			new object[5] { "Ef_SonicBoom", "y_ang", false, false, null }
		},
		{
			"Ef_Spark",
			new object[5] { "Ef_Spark", "y_ang", false, false, null }
		},
		{
			"Ef_Spark_1hs_sk",
			new object[5]
			{
				"Ef_Spark",
				"y_ang",
				true,
				true,
				new double[3] { 1.0, 0.0, -0.3 }
			}
		},
		{
			"Ef_Spark_1hs_sk10b",
			new object[5]
			{
				"Ef_Spark",
				"y_ang",
				true,
				true,
				new double[3] { -1.0, 0.0, 0.3 }
			}
		},
		{
			"Ef_Spark_1hs_sk13a",
			new object[5]
			{
				"Ef_Spark",
				"y_ang",
				true,
				false,
				new double[3] { 0.5, 0.0, 0.0 }
			}
		},
		{
			"Ef_Spark_1hs_sk13b",
			new object[5]
			{
				"Ef_Spark",
				"y_ang",
				true,
				false,
				new double[3] { -0.5, 0.0, 0.0 }
			}
		},
		{
			"Ef_Spark_1hs_sk7",
			new object[5]
			{
				"Ef_Spark",
				"y_ang",
				true,
				false,
				new double[3] { 0.5, 0.0, 0.0 }
			}
		},
		{
			"Ef_Spark_spr_sk5",
			new object[5]
			{
				"Ef_Spark",
				"y_ang",
				true,
				false,
				new double[3]
			}
		},
		{
			"Ef_Spark_spr_sk9",
			new object[5]
			{
				"Ef_Spark",
				"y_ang",
				true,
				false,
				new double[3] { -2.2, 0.0, -0.2 }
			}
		},
		{
			"Ef_Spark_spr_sk11",
			new object[5]
			{
				"Ef_Spark",
				"y_ang",
				true,
				false,
				new double[3] { 0.5, 0.0, 0.5 }
			}
		},
		{
			"Ef_SpAtk_Pet",
			new object[5] { "Ef_SpAtk_Pet", "y_ang", false, false, null }
		},
		{
			"Ef_SpAtk_Ply_Fire",
			new object[5] { "Ef_SpAtk_Ply_Fire", "y_ang", false, false, null }
		},
		{
			"Ef_SpAtk_Ply_intro",
			new object[5] { "Ef_SpAtk_Ply_intro", "y_ang", false, false, null }
		},
		{
			"Ef_SpAtk_Ply_trail",
			new object[5] { "Ef_SpAtk_Ply_trail", "y_ang", false, false, null }
		},
		{
			"Ef_Summer",
			new object[5] { "Ef_Summer", "r_weapon_1", true, true, null }
		},
		{
			"Ef_Comb_Storm",
			new object[5] { "Ef_Comb_Storm", "y_ang", false, false, null }
		},
		{
			"Ef_Comb_IceNeedle",
			new object[5] { "Ef_Comb_IceNeedle", "y_ang", false, false, null }
		},
		{
			"Ef_Comb_RockBlast",
			new object[5] { "Ef_Comb_RockBlast", "y_ang", false, false, null }
		},
		{
			"Ef_Splash_Run",
			new object[5] { "Ef_Splash_Run", "y_ang", false, false, null }
		},
		{
			"Ef_Electric",
			new object[5] { "Ef_Electric", "c_hip", true, true, null }
		},
		{
			"Ef_Thrust",
			new object[5]
			{
				"Ef_Thrust",
				"y_ang",
				false,
				false,
				new double[3] { 0.5, 0.6, 0.0 }
			}
		},
		{
			"Ef_Thrust_One",
			new object[5]
			{
				"Ef_Thrust_One",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.4, 1.0 }
			}
		},
		{
			"Ef_Charge",
			new object[5] { "Ef_Charge", "r_weapon_1", false, false, null }
		},
		{
			"Ef_1hs_skill1",
			new object[5]
			{
				"Ef_1hs_skill1",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.0, 1.0 }
			}
		},
		{
			"Ef_1hs_skill2",
			new object[5]
			{
				"Ef_1hs_skill2",
				"y_ang",
				true,
				true,
				new double[3] { 0.0, 0.7, 1.5 }
			}
		},
		{
			"Ef_1hs_skill3",
			new object[5] { "Ef_1hs_skill3", "y_ang", true, true, null }
		},
		{
			"Ef_1hs_skill4a",
			new object[5] { "Ef_1hs_skill4a", "y_ang", true, true, null }
		},
		{
			"Ef_1hs_skill4b",
			new object[5] { "Ef_1hs_skill4b", "y_ang", true, true, null }
		},
		{
			"Ef_1hs_skill8",
			new object[5] { "Ef_1hs_skill8", "y_ang", true, false, null }
		},
		{
			"Ef_1hs_skill9",
			new object[5] { "Ef_1hs_skill9", "y_ang", true, false, null }
		},
		{
			"Ef_1hs_skill11",
			new object[5] { "Ef_1hs_skill11", "y_ang", true, false, null }
		},
		{
			"Ef_1hs_skill14",
			new object[5]
			{
				"Ef_1hs_skill14",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.7, 0.2 }
			}
		},
		{
			"Ef_bow_skill4",
			new object[5]
			{
				"Ef_bow_skill4",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.7, 1.0 }
			}
		},
		{
			"Ef_bow_skill5",
			new object[5]
			{
				"Ef_bow_skill5",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.7, 1.0 }
			}
		},
		{
			"Ef_bow_skill6",
			new object[5] { "Ef_bow_skill6", "l_weapon_1", true, true, null }
		},
		{
			"Ef_bow_skill7",
			new object[5]
			{
				"Ef_bow_skill7",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 3.3, 1.2 }
			}
		},
		{
			"Ef_bow_skill9",
			new object[5]
			{
				"Ef_bow_skill9",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 1.5, -0.5 }
			}
		},
		{
			"Ef_bow_skill11_b",
			new object[5] { "Ef_bow_skill11_b", "y_ang", false, false, null }
		},
		{
			"Ef_bow_skill12_a",
			new object[5] { "Ef_bow_skill12_a", "y_ang", false, false, null }
		},
		{
			"Ef_bow_skill12_b",
			new object[5] { "Ef_bow_skill12_b", "y_ang", false, false, null }
		},
		{
			"Ef_bow_skill13",
			new object[5]
			{
				"Ef_bow_skill13",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.7, 1.0 }
			}
		},
		{
			"Ef_bow_skill14",
			new object[5]
			{
				"Ef_bow_skill14",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 1.2, 1.0 }
			}
		},
		{
			"Ef_spr_skill3",
			new object[5] { "Ef_spr_skill3", "y_ang", false, false, null }
		},
		{
			"Ef_spr_skill5",
			new object[5] { "Ef_spr_skill5", "y_ang", true, true, null }
		},
		{
			"Ef_spr_skill11",
			new object[5]
			{
				"Ef_spr_skill11",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.0, 2.0 }
			}
		},
		{
			"Ef_spr_skill12",
			new object[5] { "Ef_spr_skill12", "y_ang", false, false, null }
		},
		{
			"Ef_spr_skill12_b",
			new object[5] { "Ef_spr_skill12_b", "y_ang", false, false, null }
		},
		{
			"Ef_hth_skill9",
			new object[5] { "Ef_hth_skill9", "y_ang", true, false, null }
		},
		{
			"Ef_Cannonball",
			new object[5]
			{
				"Ef_Cannonball",
				"c_spine_b",
				false,
				false,
				new double[3] { 0.0, 0.0, 1.0 }
			}
		},
		{
			"Ef_Cannonball_Air",
			new object[5]
			{
				"Ef_Sonic_Air",
				"c_spine_b",
				false,
				false,
				new double[3] { 0.0, 0.0, 1.0 }
			}
		},
		{
			"Ef_ChaosMissile",
			new object[5]
			{
				"Ef_ChaosMissile",
				"c_spine_b",
				false,
				false,
				new double[3] { 0.0, 0.0, 1.0 }
			}
		},
		{
			"Ef_Crack",
			new object[5]
			{
				"Ef_Crack",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.0, 1.0 }
			}
		},
		{
			"Ef_Crack_Lage",
			new object[5]
			{
				"Ef_Crack_Lage",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.0, 1.2 }
			}
		},
		{
			"Ef_Crack_Small",
			new object[5]
			{
				"Ef_Crack_Small",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.0, 0.8 }
			}
		},
		{
			"Ef_Dig_Start",
			new object[5] { "Ef_Dig_Start", "y_ang", false, false, null }
		},
		{
			"Ef_Dig_Loop_Emit",
			new object[5] { "Ef_Dig_Start", "y_ang", false, false, null }
		},
		{
			"Ef_Dig_End",
			new object[5] { "Ef_Dig_End", "y_ang", false, false, null }
		},
		{
			"Ef_HelixHealing",
			new object[5] { "Ef_HelixHealing", "y_ang", false, false, null }
		},
		{
			"Ef_Holy_Sword",
			new object[5] { "Ef_Holy_Sword", "r_hand", false, false, null }
		},
		{
			"Ef_Charge_Holy_Sword",
			new object[5] { "Ef_Charge_Holy_Sword", "r_hand", true, false, null }
		},
		{
			"Ef_Kiss",
			new object[5] { "Ef_Kiss", "c_head", false, false, null }
		},
		{
			"Ef_Laser",
			new object[5]
			{
				"Ef_Laser",
				"c_body",
				true,
				false,
				new double[3] { 0.0, -3.0, 3.0 }
			}
		},
		{
			"Ef_Rush_Atk",
			new object[5]
			{
				"Ef_Rush_Atk",
				"y_ang",
				false,
				true,
				new double[3] { 0.0, 0.8, 0.0 }
			}
		},
		{
			"Ef_Spore_Bom",
			new object[5] { "Ef_Spore_Bom", "c_spine_c", true, false, null }
		},
		{
			"Ef_Tiger_Atk",
			new object[5]
			{
				"Ef_Tiger_Atk",
				"y_ang",
				false,
				true,
				new double[3] { 0.0, 0.8, 1.0 }
			}
		},
		{
			"Ef_Tiger_Atk_Weapon",
			new object[5] { "Ef_Tiger_Atk_Weapon", "r_weapon_1", true, false, null }
		},
		{
			"Ef_Twister",
			new object[5]
			{
				"Ef_Twister",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.0, 1.0 }
			}
		},
		{
			"Ef_Twister_spr_sk4",
			new object[5]
			{
				"Ef_Twister_spr_sk4",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.0, 1.0 }
			}
		},
		{
			"Ef_bow_shot",
			new object[5] { "Ef_Sonic_Front", "y_ang", false, false, null }
		},
		{
			"Ef_Holy_Bow",
			new object[5] { "Ef_Holy_Bow", "y_ang", false, false, null }
		},
		{
			"Ef_Holy_Bow_Arrow",
			new object[5]
			{
				"Ef_Holy_Bow_Arrow",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.7, 0.5 }
			}
		},
		{
			"Ef_Arrow_Rain_Shot",
			new object[5] { "Ef_Arrow_Rain_Shot", "y_ang", true, true, null }
		},
		{
			"Ef_Arrow_Rain_Shot_Weapon",
			new object[5] { "Ef_Arrow_Rain_Shot_Weapon", "r_weapon_1", true, true, null }
		},
		{
			"Ef_Arrow_Rain_Atk",
			new object[5]
			{
				"Ef_Arrow_Rain_Atk",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.0, 10.0 }
			}
		},
		{
			"Ef_Dril_Shot",
			new object[5]
			{
				"Ef_Dril_Shot",
				"y_ang",
				false,
				false,
				new double[3] { 0.0, 0.7, 0.0 }
			}
		},
		{
			"Ef_Charge_1hs_sk14",
			new object[5] { "Ef_Charge_1hs_sk14", "r_weapon_1", true, true, null }
		},
		{
			"Ef_Charge_bow_sk1",
			new object[5]
			{
				"Ef_Charge_bow_sk1",
				"r_weapon_1",
				true,
				true,
				new double[3] { -1.0, 0.0, 0.0 }
			}
		},
		{
			"Ef_Charge_bow_sk2",
			new object[5]
			{
				"Ef_Charge_bow_sk2",
				"r_weapon_1",
				true,
				true,
				new double[3] { -1.0, 0.0, 0.0 }
			}
		},
		{
			"Ef_Charge_bow_sk4",
			new object[5]
			{
				"Ef_Charge_bow_sk4",
				"r_weapon_1",
				true,
				true,
				new double[3] { -1.0, 0.0, 0.0 }
			}
		},
		{
			"Ef_Charge_bow_sk5",
			new object[5]
			{
				"Ef_Charge_bow_sk5",
				"r_weapon_1",
				true,
				true,
				new double[3] { -1.0, 0.0, 0.0 }
			}
		},
		{
			"Ef_Charge_bow_sk6",
			new object[5]
			{
				"Ef_Charge_bow_sk6",
				"r_weapon_1",
				true,
				true,
				new double[3] { -1.0, 0.0, 0.0 }
			}
		},
		{
			"Ef_Charge_bow_sk7",
			new object[5]
			{
				"Ef_Charge_bow_sk7",
				"r_weapon_1",
				true,
				true,
				new double[3] { -1.0, 0.0, 0.0 }
			}
		},
		{
			"Ef_Charge_bow_sk8",
			new object[5]
			{
				"Ef_Charge_bow_sk8",
				"r_weapon_1",
				true,
				true,
				new double[3] { -1.0, 0.0, 0.0 }
			}
		},
		{
			"Ef_Charge_bow_sk9",
			new object[5]
			{
				"Ef_Charge_bow_sk9",
				"r_weapon_1",
				true,
				true,
				new double[3] { -1.0, 0.0, 0.0 }
			}
		},
		{
			"Ef_Charge_bow_sk10",
			new object[5]
			{
				"Ef_Charge_bow_sk10",
				"r_weapon_1",
				true,
				true,
				new double[3] { -1.0, 0.0, 0.0 }
			}
		},
		{
			"Ef_Charge_bow_sk11",
			new object[5]
			{
				"Ef_Charge_bow_sk11",
				"r_weapon_1",
				true,
				true,
				new double[3] { -1.0, 0.0, 0.0 }
			}
		},
		{
			"Ef_Charge_bow_sk12",
			new object[5]
			{
				"Ef_Charge_bow_sk12",
				"r_weapon_1",
				true,
				true,
				new double[3] { -1.0, 0.0, 0.0 }
			}
		},
		{
			"Ef_Charge_bow_sk13",
			new object[5]
			{
				"Ef_Charge_bow_sk13",
				"r_weapon_1",
				true,
				true,
				new double[3] { -1.0, 0.0, 0.0 }
			}
		},
		{
			"Ef_Charge_bow_sk14",
			new object[5]
			{
				"Ef_Charge_bow_sk14",
				"r_weapon_1",
				true,
				true,
				new double[3] { -1.0, 0.0, 0.0 }
			}
		},
		{
			"Ef_Charge_hth_sk6",
			new object[5] { "Ef_Charge_hth_sk6", "r_hand", true, true, null }
		},
		{
			"Ef_Charge_hth_sk7",
			new object[5] { "Ef_Charge_hth_sk7", "r_hand", true, true, null }
		},
		{
			"Ef_Charge_hth_sk10",
			new object[5] { "Ef_Charge_hth_sk10", "r_hand", true, true, null }
		},
		{
			"Ef_Charge_hth_sk12",
			new object[5] { "Ef_Charge_hth_sk12", "r_hand", true, true, null }
		},
		{
			"Ef_Charge_hth_sk14",
			new object[5] { "Ef_Charge_hth_sk14", "r_hand", true, true, null }
		},
		{
			"Ef_Charge_hth_sk15",
			new object[5] { "Ef_Charge_hth_sk15", "r_hand", true, true, null }
		},
		{
			"Ef_Sword_Trail",
			new object[5] { "Ef_Sword_Trail", "y_ang", false, false, null }
		},
		{
			"Ef_Sword_Trail_05",
			new object[5] { "Ef_Sword_Trail_05", "y_ang", false, false, null }
		},
		{
			"Ef_Sword_Trail_08",
			new object[5] { "Ef_Sword_Trail_08", "y_ang", false, false, null }
		},
		{
			"Ef_Sword_Trail_10",
			new object[5] { "Ef_Sword_Trail_10", "y_ang", false, false, null }
		},
		{
			"Ef_Sword_Trail_12",
			new object[5] { "Ef_Sword_Trail_12", "y_ang", false, false, null }
		},
		{
			"Ef_Sword_Trail_15",
			new object[5] { "Ef_Sword_Trail_15", "y_ang", false, false, null }
		},
		{
			"Ef_Sword_Trail_20",
			new object[5] { "Ef_Sword_Trail_20", "y_ang", false, false, null }
		},
		{
			"Ef_Sword_Trail_25",
			new object[5] { "Ef_Sword_Trail_25", "y_ang", false, false, null }
		},
		{
			"Ef_Sword_Trail_36",
			new object[5] { "Ef_Sword_Trail_36", "y_ang", false, false, null }
		}
	};
}
