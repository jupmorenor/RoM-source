using System;
using System.Text.RegularExpressions;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class DebugSubTestLoadEffect : RuntimeDebugModeGuiMixin
{
	[Serializable]
	internal class _0024applyFilter_0024locals_002414308
	{
		internal Regex _0024r;
	}

	[Serializable]
	internal class _0024OnGUI_0024locals_002414309
	{
		internal GUILayoutOption _0024w;
	}

	[Serializable]
	internal class _0024applyFilter_0024closure_00243472
	{
		internal _0024applyFilter_0024locals_002414308 _0024_0024locals_002414718;

		public _0024applyFilter_0024closure_00243472(_0024applyFilter_0024locals_002414308 _0024_0024locals_002414718)
		{
			this._0024_0024locals_002414718 = _0024_0024locals_002414718;
		}

		public bool Invoke(string x)
		{
			return _0024_0024locals_002414718._0024r.Match(x).Success;
		}
	}

	[Serializable]
	internal class _0024_0024OnGUI_0024closure_00243473_0024closure_00243474
	{
		internal _0024OnGUI_0024locals_002414309 _0024_0024locals_002414719;

		internal DebugSubTestLoadEffect _0024this_002414720;

		public _0024_0024OnGUI_0024closure_00243473_0024closure_00243474(_0024OnGUI_0024locals_002414309 _0024_0024locals_002414719, DebugSubTestLoadEffect _0024this_002414720)
		{
			this._0024_0024locals_002414719 = _0024_0024locals_002414719;
			this._0024this_002414720 = _0024this_002414720;
		}

		public void Invoke()
		{
			if (RuntimeDebugModeGuiMixin.button("Game UI Root", _0024_0024locals_002414719._0024w))
			{
				_0024this_002414720.toggle_ui("Game UI Root");
			}
		}
	}

	[Serializable]
	internal class _0024OnGUI_0024closure_00243473
	{
		internal DebugSubTestLoadEffect _0024this_002414721;

		internal _0024OnGUI_0024locals_002414309 _0024_0024locals_002414722;

		public _0024OnGUI_0024closure_00243473(DebugSubTestLoadEffect _0024this_002414721, _0024OnGUI_0024locals_002414309 _0024_0024locals_002414722)
		{
			this._0024this_002414721 = _0024this_002414721;
			this._0024_0024locals_002414722 = _0024_0024locals_002414722;
		}

		public void Invoke()
		{
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024OnGUI_0024closure_00243473_0024closure_00243474(_0024_0024locals_002414722, _0024this_002414721).Invoke));
		}
	}

	protected int cursor;

	[NonSerialized]
	protected static string[][] by_type_filter_label = new string[8][]
	{
		new string[2]
		{
			"全",
			string.Empty
		},
		new string[2] { "cutscene", "CutScene|_cam_" },
		new string[2] { "1hs", "1hs" },
		new string[2]
		{
			"bow",
			string.Empty
		},
		new string[2]
		{
			"spr",
			string.Empty
		},
		new string[2]
		{
			"hth",
			string.Empty
		},
		new string[2]
		{
			"2hs",
			string.Empty
		},
		new string[2] { "monster skill", "[e][0-9]{4}" }
	};

	[NonSerialized]
	protected static readonly string[] allEffects = new string[572]
	{
		"Ef_Angry_c0000", "Ef_Angry_c0001", "Ef_Angry_e5004", "Ef_Angry_e5005", "Ef_AngryPoint_e5005", "Ef_Breath_e5004", "Ef_Breath_e5005", "Ef_c5032_run_cry", "Ef_Common_Awake", "Ef_Common_Awake_L",
		"Ef_Common_Awake_M", "Ef_Common_Awake_S", "Ef_Common_AwakeL", "Ef_Common_AwakeL_L", "Ef_Common_AwakeL_M", "Ef_Common_AwakeL_S", "Ef_Common_Cross", "Ef_Common_Disappoint", "Ef_Common_Disappoint_L", "Ef_Common_Disappoint_M",
		"Ef_Common_Disappoint_S", "Ef_Common_Doki_L", "Ef_Common_Doki_M", "Ef_Common_Doki_S", "Ef_Common_DokiL_L", "Ef_Common_DokiL_M", "Ef_Common_DokiL_S", "Ef_Common_DokiR_L", "Ef_Common_DokiR_M", "Ef_Common_DokiR_S",
		"Ef_Common_FootSmoke", "Ef_Common_Fun_L", "Ef_Common_Fun_M", "Ef_Common_Fun_S", "Ef_Common_Heart", "Ef_Common_Heart_L", "Ef_Common_Heart_M", "Ef_Common_Heart_S", "Ef_Common_HideWeapon", "Ef_Common_Icon_Dark",
		"Ef_Common_Icon_Think_L", "Ef_Common_Icon_Think_M", "Ef_Common_Icon_Think_S", "Ef_Common_Oinori", "Ef_Common_Question", "Ef_Common_Question_L", "Ef_Common_Question_M", "Ef_Common_Question_S", "Ef_Common_Sigh", "Ef_Common_Sigh_L",
		"Ef_Common_Sigh_M", "Ef_Common_Sigh_S", "Ef_Common_SighL", "Ef_Common_SighL_L", "Ef_Common_SighL_M", "Ef_Common_SighL_S", "Ef_Common_Sweat", "Ef_Common_Sweat_L", "Ef_Common_Sweat_M", "Ef_Common_Sweat_S",
		"Ef_Common_SweatS_L", "Ef_Common_SweatS_M", "Ef_Common_SweatS_S", "Ef_Common_Tear_S", "Ef_CutSceneEffs_Opening", "Ef_CutSceneEffs_Prologue", "Ef_CutSceneEffs_Prologue_ev3", "Ef_e0012_EmitSmokeDistance", "Ef_Leaf_m0000", "Ef_Light_c9004",
		"Ef_Light_c9004_End", "Ef_Lightball", "Ef_op1_BrackSmoke", "Ef_op1_c9001", "Ef_op1_Crowd", "Ef_op1_Destroy", "Ef_op1_FistTrail", "Ef_op1_Jump", "Ef_op1_Linework", "Ef_op1_Linework_L",
		"Ef_op1_Linework_S", "Ef_op1_Mana_Angel", "Ef_op1_Mana_Devil", "Ef_op1_Mana_End", "Ef_op1_Mana_Ground", "Ef_op1_Mana_Ground2", "Ef_op1_Shock", "Ef_op1_Slash", "Ef_pro1_Destroy", "Ef_pro1_Doki",
		"Ef_pro1_Flare", "Ef_pro1_Flare2", "Ef_pro1_Fusion", "Ef_pro1_Helix_Angel", "Ef_pro1_Helix_Devil", "Ef_pro1_HelixHealing", "Ef_pro1_Jump", "Ef_pro1_Linework_l", "Ef_pro1_Linework_r", "Ef_pro1_Linework_S",
		"Ef_pro1_Run", "Ef_pro1_Star", "Ef_pro1_Star_L", "Ef_pro3_Claw", "Ef_pro3_Jump", "Ef_pro3_Jump2", "Ef_pro3_Landing", "Ef_pro3_Linework", "Ef_pro3_Linework_L", "Ef_pro3_Run",
		"Ef_pro3_Run2", "Ef_pro3_Shock", "Ef_pro4_Ball", "Ef_pro4_BallMove", "Ef_pro4_c9001", "Ef_pro4_Dependance", "Ef_pro4_p5000", "Ef_pro4_Run", "Ef_pro4_Run2", "Ef_pro4_Run_kakao",
		"Ef_Smoke_Doron", "Ef_Sonic_Jump_e5004", "Ef_Sonic_Jump_e5005", "Ef_ST04_05_Wall", "Ef_ST09_07_Alert", "Ef_ST09_07_LandSmoke", "Ef_ST09_07_Linework", "Ef_ST09_08_GolemOut", "Ef_ST10_06_Destroy", "Ef_ST10_06_Linework",
		"Ef_ST10_06_Restraint", "Ef_ST10_07_Aula", "Ef_ST10_08_FloorSmoke", "Ef_1hs_skill1", "Ef_1hs_skill10", "Ef_1hs_skill14_01", "Ef_1hs_skill14_01_Bomb", "Ef_1hs_skill14_02", "Ef_1hs_skill14_02_Bomb", "Ef_1hs_skill14_03",
		"Ef_1hs_skill14_03_Bomb", "Ef_1hs_skill14_04", "Ef_1hs_skill14_04_Bomb", "Ef_1hs_skill15", "Ef_1hs_skill15_Ring", "Ef_1hs_skill1_Ring", "Ef_1hs_skill2", "Ef_1hs_skill3", "Ef_1hs_skill4a", "Ef_1hs_skill4b",
		"Ef_1hs_skill5", "Ef_AfterImage", "Ef_Angry", "Ef_Area_Damage", "Ef_Area_Damage_Smoke", "Ef_Area_Fire", "Ef_Area_Gravity", "Ef_Area_Gravity_Smoke", "Ef_Area_Ice", "Ef_Area_Ice_Block",
		"Ef_Area_Ice_Block_Big", "Ef_Area_Ice_Smoke", "Ef_Arrow", "Ef_Arrow_Line", "Ef_Arrow_Line_sample", "Ef_Arrow_Rain_Atk", "Ef_Arrow_Rain_Atk_Bullet", "Ef_Arrow_Rain_Shot", "Ef_Arrow_Rain_Shot_Weapon", "Ef_ArrowMine",
		"Ef_ArrowMine_Bomb", "Ef_Aura", "Ef_Aura02", "Ef_Barrier", "Ef_Bite", "Ef_Blur", "Ef_bow_skill11_b", "Ef_bow_skill12_a", "Ef_bow_skill12_b", "Ef_bow_skill14",
		"Ef_bow_skill14_Arrow", "Ef_bow_skill14_Bomb", "Ef_bow_skill4", "Ef_bow_skill5", "Ef_bow_skill5_Bomb", "Ef_bow_skill6", "Ef_bow_skill7", "Ef_bow_skill7_Bomb", "Ef_bow_skill9", "Ef_bow_skill9_Bomb",
		"Ef_Break", "Ef_Bubble", "Ef_Bubble_Shower", "Ef_Bubble_Splash", "Ef_Bubble_Splash_L", "Ef_c9001_000_ma", "Ef_Cannonball", "Ef_Cannonball_Muzzleflash", "Ef_ChaosMissile", "Ef_Charge",
		"Ef_Charge_Bow", "Ef_Charge_bow_sk13", "Ef_Charge_bow_sk14", "Ef_Charge_Electric", "Ef_Charge_Holy_Sword", "Ef_Charge_hth_sk10", "Ef_Charge_hth_sk12", "Ef_Charge_hth_sk14", "Ef_Charge_hth_sk15", "Ef_Charge_hth_sk6",
		"Ef_Charge_hth_sk7", "Ef_Charge_Shine", "Ef_Charge_Shine_Weapon", "Ef_Charge_spr_sk14", "Ef_Charge_Storm", "Ef_Charge_StormNega", "Ef_Claw", "Ef_Claw_e0007", "Ef_Claw_l45", "Ef_Claw_l80",
		"Ef_Claw_Lage", "Ef_Claw_r45", "Ef_Claw_r80", "Ef_Claw_Small", "Ef_Coin_Scatter_Coin", "Ef_Coin_Scatter_Get", "Ef_Coin_Scatter_Test", "Ef_Comb_IceNeedle", "Ef_Comb_RockBlast", "Ef_Comb_RockBlast_Rock",
		"Ef_Comb_Storm", "Ef_Condition_Burn", "Ef_Condition_Confuse", "Ef_Condition_Freeze", "Ef_Condition_Hate", "Ef_Condition_Poison", "Ef_Condition_Stun", "Ef_Crack", "Ef_Crack_Large", "Ef_Crack_Small",
		"Ef_DamageArea", "Ef_Dead_Smoke", "Ef_Dig_End", "Ef_Dig_Loop", "Ef_Dig_Loop_Emit", "Ef_Dig_Start", "Ef_Drain", "Ef_Drain_Emit", "Ef_Drain_Enemy", "Ef_Drain_Get",
		"Ef_Drain_Homing", "Ef_Dril_Shot", "Ef_DropItem", "Ef_e0000_bt_atk1", "Ef_e0001_bt_atk1", "Ef_e0001_bt_atk3", "Ef_e0002_bt_atk1", "Ef_e0002_bt_atk2", "Ef_e0002_bt_atk4", "Ef_e0003_bt_atk1",
		"Ef_e0003_bt_atk3", "Ef_e0003_bt_atk4", "Ef_e0004_bt_atk1", "Ef_e0004_bt_atk2", "Ef_e0005_bt_atk1_Bomb", "Ef_e0005_bt_atk1_Dig", "Ef_e0005_bt_atk2", "Ef_e0005_bt_atk2_Explosion", "Ef_e0005_bt_atk3", "Ef_e0005_Bullet_b",
		"Ef_e0005_Bullet_c", "Ef_e0005_Bullet_d", "Ef_e0005_Bullet_e", "Ef_e0006_bt_atk1", "Ef_e0006_bt_atk2", "Ef_e0006_bt_atk4", "Ef_e0007_bt_atk1", "Ef_e0007_bt_atk2", "Ef_e0007_bt_atk3", "Ef_e0008_bt_atk1",
		"Ef_e0008_bt_atk2", "Ef_e0008_bt_atk3", "Ef_e0009_bt_atk2", "Ef_e0009_bt_atk2_Smoke", "Ef_e0009_bt_atk3", "Ef_e0012_bt_atk1", "Ef_e0012_bt_atk2", "Ef_e0012_bt_atk3", "Ef_e0018_bt_atk1", "Ef_e0018_bt_atk2",
		"Ef_e0018_bt_atk3", "Ef_e0018_bt_atk4", "Ef_e0018_Seed", "Ef_e0019_bt_atk1", "Ef_e0019_bt_atk1_Needle", "Ef_e0019_bt_atk2", "Ef_e0019_Bullet_b", "Ef_e0019_Bullet_e", "Ef_e0020_bt_atk1", "Ef_e0020_bt_atk2",
		"Ef_e0020_bt_atk3", "Ef_e0020_bt_atk4", "Ef_e0023_bt_atk1", "Ef_e0023_bt_atk2", "Ef_e0023_bt_atk2_Fin", "Ef_e0023_bt_atk4", "Ef_e0025_bt_atk1", "Ef_e0025_bt_atk2", "Ef_e0025_bt_atk3", "Ef_e0025_bt_atk4",
		"Ef_e0026_bt_atk1", "Ef_e0026_bt_atk2", "Ef_e0026_bt_atk3", "Ef_e0026_bt_atk4", "Ef_e0028_bt_atk1", "Ef_e0028_bt_atk1_Eye", "Ef_e0028_bt_atk2", "Ef_e0028_bt_atk3", "Ef_e0030_bt_atk1", "Ef_e0030_bt_run",
		"Ef_e0031_bt_atk1", "Ef_e0032_bt_atk", "Ef_e5001_Alert", "Ef_e5001_bt_atk1", "Ef_e5001_bt_atk2", "Ef_e5001_bt_atk3", "Ef_e5001_bt_atk4", "Ef_e5001_bt_atk5", "Ef_e5001_HandSmoke", "Ef_e5001_Jump",
		"Ef_e5001_Landing", "Ef_e5001_RoundShock", "Ef_e5001_Shock", "Ef_e5001_Shock_Lage", "Ef_e5002_Brake", "Ef_e5002_bt_atk1", "Ef_e5002_bt_atk2", "Ef_e5002_bt_atk3", "Ef_e5002_bt_atk4", "Ef_e5002_bt_atk4_Alert",
		"Ef_e5002_Drool", "Ef_e5002_Peddle", "Ef_e5004_bt_atk1", "Ef_e5004_bt_skill1", "Ef_e5004_bt_skill2", "Ef_e5004_bt_skill3", "Ef_e5004_bt_skill4", "Ef_e5004_SwordTrail", "Ef_e5005_bt_atk1", "Ef_e5005_bt_skill1",
		"Ef_e5005_bt_skill2", "Ef_e5005_bt_skill3", "Ef_e5005_bt_skill4", "Ef_e5005_FistPuf", "Ef_e5008_Breath", "Ef_e5008_bt_atk1", "Ef_e5008_bt_atk3", "Ef_e5008_bt_atk3_Smoke", "Ef_e5008_bt_atk4", "Ef_e5008_bt_atk5",
		"Ef_e5008_Electric", "Ef_e5009_Attachment", "Ef_e5009_Breath", "Ef_e5009_bt_atk2", "Ef_e5009_FootStep", "Ef_e5009_FootStep_Emit", "Ef_e5009_Inhale", "Ef_e5009_Prime", "Ef_e5009_SandSpray", "Ef_e5009_Shock",
		"Ef_e5011_Alert", "Ef_e5011_bt_atk1", "Ef_e5011_bt_atk2", "Ef_e5011_bt_atk3", "Ef_e5011_bt_atk4", "Ef_e5011_Spell", "Ef_Electric", "Ef_Energy_Ball", "Ef_Energy_Geyser", "Ef_Explosion",
		"Ef_Feathers", "Ef_Fire_Ball", "Ef_FireBreathBase", "Ef_FistTrail", "Ef_FistTrail_e5005", "Ef_FistTrail_e5005_2", "Ef_Heal", "Ef_HelixHealing", "Ef_Hit", "Ef_Hit_Smoke",
		"Ef_Holy_Bow", "Ef_Holy_Bow_Arrow", "Ef_Holy_Sword", "Ef_hth_skill9", "Ef_IceBallBase", "Ef_Item_Line", "Ef_Item_Line_r", "Ef_Item_Line_sr", "Ef_Item_Open", "Ef_Kiss",
		"Ef_Kiss_Hit", "Ef_Laser", "Ef_Laser_Bom", "Ef_Laser_Bom_Emit", "Ef_Laser_e0023", "Ef_Laser_e5001", "Ef_Linework", "Ef_Luminous", "Ef_Map_Bubble", "Ef_Map_FireZone",
		"Ef_Map_FuwaZone", "Ef_Map_Sandstorm", "Ef_Map_SecretGate", "Ef_Map_Snowstorm", "Ef_Map_Volcano", "Ef_Map_Volcano_Lava", "Ef_Map_Wind", "Ef_p3000_Attachment", "Ef_p3000_Phantom_DrainHit", "Ef_p3000_Phantom_DrainHoming",
		"Ef_p3000_Phantom_DrainReturn", "Ef_p3000_Phantom_DrainStart", "Ef_p3000_Phantom_Get", "Ef_p3000_Phantom_Hit", "Ef_p3000_Phantom_Homing", "Ef_p3000_Phantom_Start", "Ef_p3000_Sword", "Ef_Pebble", "Ef_Pebble_Emit", "Ef_Pebble_Hit",
		"Ef_Plane", "Ef_Power_Up", "Ef_RaidWall", "Ef_Ring", "Ef_RingMesh", "Ef_Run", "Ef_Run_Emit", "Ef_Rush_Atk", "Ef_Rush_Atk_Hit", "Ef_Scratch",
		"Ef_Seed", "Ef_Seed_Emit", "Ef_Seed_Hit", "Ef_Slash", "Ef_Slash_0", "Ef_Slash_l135", "Ef_Slash_l45", "Ef_Slash_l80", "Ef_Slash_l90", "Ef_Slash_Lage",
		"Ef_Slash_r135", "Ef_Slash_r45", "Ef_Slash_r90", "Ef_Slash_Small", "Ef_Slash_Spin", "Ef_Smoke_Dead", "Ef_Smoke_Jump", "Ef_Smoke_Jump_Lage", "Ef_Smoke_Jump_Lage_Obj", "Ef_Smoke_Jump_Obj",
		"Ef_Smoke_Jump_Small", "Ef_Smoke_Jump_Small_Obj", "Ef_Smoke_Pop", "Ef_Smoke_Run", "Ef_SmokeColorData", "Ef_SmokeColorData_Cave", "Ef_SmokeColorData_Coast_1", "Ef_SmokeColorData_Coast_2", "Ef_SmokeColorData_Desert", "Ef_SmokeColorData_Forest",
		"Ef_SmokeColorData_Mountain", "Ef_SmokeColorData_MyHome", "Ef_SmokeColorData_Snowfield", "Ef_SmokeColorData_Temple", "Ef_SmokeColorData_Town", "Ef_SmokeColorData_Volcano", "Ef_SmokeColorTest", "Ef_Sonic_Air", "Ef_Sonic_Air_bow_sk10", "Ef_Sonic_Air_bow_sk12",
		"Ef_Sonic_Air_bow_sk3", "Ef_Sonic_Air_bow_sk9", "Ef_Sonic_Air_e5001", "Ef_Sonic_Air_e5002", "Ef_Sonic_Air_e5011", "Ef_Sonic_Air_hth_sk11", "Ef_Sonic_Air_Punch", "Ef_Sonic_Air_S", "Ef_Sonic_Air_spr_sk3", "Ef_Sonic_Blast",
		"Ef_Sonic_Bomb", "Ef_Sonic_Boom", "Ef_Sonic_Cone_1hs_sk5", "Ef_Sonic_Cone_1hs_sk6", "Ef_Sonic_Cone_spr_sk14", "Ef_Sonic_Cone_spr_sk2", "Ef_Sonic_Dash", "Ef_Sonic_Dash_e5005", "Ef_Sonic_Front", "Ef_Sonic_Front_Large",
		"Ef_Sonic_Roll", "Ef_Sonic_Round", "Ef_Sonic_Round_Lage", "Ef_Sonic_Round_Small", "Ef_Sonic_Round_Water", "Ef_Sonic_Slash", "Ef_Sonic_Slash_l", "Ef_Sonic_Slash_r", "Ef_Sonic_Sphere", "Ef_Sonic_Spin",
		"Ef_Sonic_Spin_r", "Ef_Sonic_Thrust", "Ef_Sonic_Thrust_Fist", "Ef_Sonic_Thrust_Spear", "Ef_Sonic_Thrust_spr_sk10a", "Ef_Sonic_Thrust_spr_sk10b", "Ef_Sonic_Tornado", "Ef_Sonic_Tornado_OneShot", "Ef_Sonic_Tornado_Sphere", "Ef_Sonic_Uprise",
		"Ef_Sonic_Uprise_Lage", "Ef_Sonic_Uprise_Line", "Ef_Sonic_Uprise_Line_Water", "Ef_Sonic_Uprise_Small", "Ef_SonicBoom", "Ef_Spark", "Ef_SpAtk_Pet", "Ef_SpAtk_Ply_Fire", "Ef_SpAtk_Ply_FireBall", "Ef_SpAtk_Ply_intro",
		"Ef_SpAtk_Ply_trail", "Ef_Spirit_Gin", "Ef_Spirit_Gnome", "Ef_Spirit_Marmaid", "Ef_Spirit_Salamander", "Ef_Spirit_Undine", "Ef_Splash_Run", "Ef_Splash_Run_old", "Ef_Spore_Bom", "Ef_spr_skill11",
		"Ef_spr_skill12", "Ef_spr_skill12_B", "Ef_spr_skill5", "Ef_Spray_Sand", "Ef_Spray_Water", "Ef_Spray_Water_heaven", "Ef_Summer", "Ef_Sword_Trail", "Ef_Sword_Trail_05", "Ef_Sword_Trail_08",
		"Ef_Sword_Trail_10", "Ef_Sword_Trail_12", "Ef_Sword_Trail_15", "Ef_Sword_Trail_20", "Ef_Sword_Trail_25", "Ef_Sword_Trail_36", "Ef_Sword_Trail_Spear", "Ef_Tap", "Ef_Thrust", "Ef_Thrust_One",
		"Ef_Thrust_spr_sk2", "Ef_Thrust_spr_sk2_B", "Ef_Tiger_Atk", "Ef_Tiger_Atk_Hit", "Ef_Tiger_Atk_Weapon", "Ef_Torch_Fire", "Ef_Treasure", "Ef_Twister", "Ef_Twister_spr_sk4", "Ef_Ultrasonic",
		"Ef_Wall", "Ef_WeaponScale"
	};

	[NonSerialized]
	protected static string[] filterdList = allEffects;

	[NonSerialized]
	internal static Regex _0024re_002424717 = new Regex(" ");

	public DebugSubTestLoadEffect()
	{
		cursor = -1;
	}

	public static void applyFilter(string f)
	{
		_0024applyFilter_0024locals_002414308 _0024applyFilter_0024locals_0024 = new _0024applyFilter_0024locals_002414308();
		string[] array = null;
		int i = 0;
		string[] array2 = _0024re_002424717.Split(f);
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			_0024applyFilter_0024locals_0024._0024r = new Regex(array2[i], RegexOptions.IgnoreCase);
			array = ArrayMap.FilterStrings(allEffects, new _0024applyFilter_0024closure_00243472(_0024applyFilter_0024locals_0024).Invoke);
		}
		filterdList = ((array == null) ? array : filterdList);
	}

	public override void OnGUI()
	{
		_0024OnGUI_0024locals_002414309 _0024OnGUI_0024locals_0024 = new _0024OnGUI_0024locals_002414309();
		RuntimeDebugModeGuiMixin.slabel("UI Root (2d) トグル");
		_0024OnGUI_0024locals_0024._0024w = RuntimeDebugModeGuiMixin.optWidth(200);
		RuntimeDebugModeGuiMixin.vertical(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024OnGUI_0024closure_00243473(this, _0024OnGUI_0024locals_0024).Invoke));
		RuntimeDebugModeGuiMixin.slabel("エフェクト読み込みテスト");
		RuntimeDebugModeGuiMixin.listWithFilter(by_type_filter_label, new __Req_FailHandler_0024callable6_0024440_32__(applyFilter));
		cursor = RuntimeDebugModeGuiMixin.grid(cursor, filterdList, 2);
		if (cursor != -1)
		{
			int num = cursor;
			int length = filterdList.Length;
			int num2 = 1;
			if (length < num)
			{
				num2 = -1;
			}
			while (num != length)
			{
				int index = num;
				num += num2;
				string[] array = filterdList;
				load(array[RuntimeServices.NormalizeArrayIndex(array, index)]);
				string[] array2 = filterdList;
				array2[RuntimeServices.NormalizeArrayIndex(array2, index)] = "--";
			}
			cursor = -1;
		}
	}

	public void load(string name)
	{
		try
		{
			GameObject gameObject = Resources.Load(name) as GameObject;
		}
		catch (Exception)
		{
		}
	}

	public void toggle_ui(string obj_name)
	{
		UIRoot[] array = (UIRoot[])UnityEngine.Object.FindObjectsOfType(typeof(UIRoot));
		int length = array.Length;
		int num = 0;
		while (num < length)
		{
			UIRoot uIRoot = array[RuntimeServices.NormalizeArrayIndex(array, checked(num++))];
			if (uIRoot.name.Contains("UI Root"))
			{
				uIRoot.gameObject.SetActive(value: false);
			}
		}
	}

	public override void Update()
	{
	}

	public override void HideModeUpdate()
	{
	}

	public override void HideModeOnGUI()
	{
	}

	public override void Init()
	{
	}

	public override void Exit()
	{
	}
}
