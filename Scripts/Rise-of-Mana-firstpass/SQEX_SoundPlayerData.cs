using System.Collections.Generic;

public class SQEX_SoundPlayerData
{
	public enum BGM
	{
		NONE = -1,
		world_001,
		town_001,
		field_001,
		dungeon_001,
		sacred_001,
		nature_001,
		boss_001,
		boss_002,
		last_001,
		raid_001,
		gameover_001,
		no_data_1,
		no_data_2,
		ending_001,
		crisis_001,
		conspire_001,
		peaceful_001,
		no_data_3,
		majestic_001,
		lottery_001,
		combine_001,
		worry_001,
		title_001,
		fanfare_001,
		result_001,
		lastdungeon_001,
		raidmenu_001,
		restful_001,
		greatevil_001,
		wasteland_001,
		romasaga2_001,
		cq_field_001,
		cq_boss_001,
		dungeon_002,
		seiken2_001,
		brave_field_001,
		brave_boss_001,
		brave_field_002,
		brave_boss_002,
		merc_field_001,
		merc_field_002,
		merc_boss_001,
		merc_boss_002,
		ruin_001,
		ff4_field_001,
		ff4_boss_001,
		ff4_boss_002,
		ff4_boss_003,
		greatevil_002,
		seiken3_boss_001,
		seiken3_boss_002,
		seiken3_boss_003,
		seiken3_boss_004,
		peaceful_002,
		lom_boss_001,
		lom_boss_002,
		lom_boss_003,
		lom_boss_004,
		lom_raid_001,
		ffl_field_001,
		ffl_boss_001,
		ffl_boss_002,
		boss_003,
		bs_field_001,
		bs_boss_001,
		bs_raid_001,
		seiken2_raid_001,
		romasaga2_002,
		romasaga3_001,
		lastdungeon_002,
		seiken1_boss_001,
		seiken1_boss_002,
		seiken1_boss_003,
		last_boss_002,
		fft_field_001,
		fft_boss_001,
		fft_boss_002,
		ending_002,
		ffrk_field_001,
		ffrk_boss_001,
		ffrk_boss_002,
		ffrk_raid_001,
		Max
	}

	public enum SE
	{
		NONE = -1,
		item_appear = 24,
		treasure_get = 25,
		treasure_get2 = 26,
		drop_get = 27,
		soulstone_get = 28,
		coin_get = 29,
		walnut_get = 30,
		sword_draw = 56,
		sword_sheathe = 57,
		sword_swish = 58,
		sword_hit_s = 59,
		sword_hit_l = 60,
		spear_draw = 61,
		spear_sheathe = 62,
		spear_swish = 63,
		spear_hit_s = 64,
		spear_hit_l = 65,
		bow_draw = 66,
		bow_sheathe = 67,
		bow_shoot = 68,
		bow_hit_s = 69,
		bow_hit_l = 70,
		knuckle_draw = 71,
		knuckle_sheathe = 72,
		knuckle_swish = 73,
		knuckle_hit_s = 74,
		knuckle_hit_l = 75,
		sword2_draw = 76,
		sword2_sheathe = 77,
		sword2_swish = 78,
		sword2_hit_s = 79,
		sword2_hit_l = 80,
		skill_motion = 81,
		combination_motion = 82,
		combination_fire = 83,
		combination_water = 84,
		combination_wind = 85,
		combination_earth = 86,
		levelup_user = 87,
		damage_s = 88,
		down = 89,
		down_water = 90,
		damage_critical = 91,
		damage_guard = 92,
		dead = 93,
		state_motion = 94,
		state_resist = 95,
		minus_area_motion = 96,
		dying_alert = 97,
		fanfare = 98,
		dodge = 101,
		dodge_water = 102,
		ready = 103,
		minus_area_smoke = 104,
		combination_ready = 105,
		weapon_ready = 106,
		change_ready = 107,
		combination_end = 108,
		state_end = 109,
		pet_dead = 110,
		sword_skill1 = 121,
		sword_skill2 = 122,
		sword_skill3 = 123,
		sword_skill4 = 124,
		sword_skill5 = 125,
		sword_skill6 = 126,
		sword_skill7 = 127,
		sword_skill8 = 128,
		sword_skill9 = 129,
		sword_skill10 = 130,
		sword_skill11 = 131,
		sword_skill12 = 132,
		sword_skill13 = 133,
		sword_skill14 = 134,
		sword_skill15 = 135,
		sword_skill16 = 136,
		sword_skill17 = 137,
		spear_skill1 = 138,
		spear_skill2 = 139,
		spear_skill3 = 140,
		spear_skill4 = 141,
		spear_skill5 = 142,
		spear_skill6 = 143,
		spear_skill7 = 144,
		spear_skill8 = 145,
		spear_skill9 = 146,
		spear_skill10 = 147,
		spear_skill11 = 148,
		spear_skill12 = 149,
		spear_skill13 = 150,
		bow_skill1 = 151,
		bow_skill2 = 152,
		bow_skill3 = 153,
		bow_skill4 = 154,
		bow_skill5 = 155,
		bow_skill6 = 156,
		bow_skill7 = 157,
		bow_skill8 = 158,
		bow_skill9 = 159,
		bow_skill10 = 160,
		bow_skill11 = 161,
		bow_skill12 = 162,
		bow_skill13 = 163,
		bow_skill14 = 164,
		bow_skill15 = 165,
		knuckle_skill1 = 166,
		knuckle_skill2 = 167,
		knuckle_skill3 = 168,
		knuckle_skill4 = 169,
		knuckle_skill5 = 170,
		knuckle_skill6 = 171,
		knuckle_skill7 = 172,
		knuckle_skill8 = 173,
		knuckle_skill9 = 174,
		knuckle_skill10 = 175,
		knuckle_skill11 = 176,
		knuckle_skill12 = 177,
		knuckle_skill13 = 178,
		knuckle_skill14 = 179,
		knuckle_skill15 = 180,
		sword_skill18 = 196,
		spear_skill14 = 197,
		spear_skill15 = 198,
		spear_skill16 = 199,
		bow_skill16 = 200,
		bow_skill17 = 201,
		knuckle_skill16 = 202,
		knuckle_skill17 = 203,
		knuckle_skill18 = 204,
		knuckle_skill19 = 205,
		sword_skill50 = 206,
		sword_skill51 = 207,
		sword_skill52 = 208,
		sword_skill54 = 209,
		spear_skill51 = 210,
		sword_skill57 = 211,
		sword_skill58 = 212,
		cursor = 216,
		fix = 217,
		cansel = 218,
		beep = 219,
		shop = 220,
		composition = 221,
		composition_s = 222,
		composition_m = 223,
		composition_l = 224,
		change = 225,
		levelup = 226,
		skill_levelup = 227,
		limit_break = 228,
		get_weapon = 229,
		add_area = 230,
		door = 231,
		door2 = 232,
		quest_appear = 233,
		window_open = 234,
		window_close = 235,
		sabo_write = 236,
		sabo_diary = 237,
		revival = 238,
		exp_countup = 239,
		levelup2 = 240,
		new_item = 241,
		new_item2 = 242,
		lottery_roll = 243,
		lottery_normal = 244,
		lottery_rare = 245,
		lottery_srare = 246,
		lottery_urare = 247,
		lottery_kira = 248,
		lottery_prizm = 249,
		lottery_hanabi1 = 250,
		lottery_hanabi2 = 251,
		evolution1 = 252,
		evolution2 = 253,
		composition2 = 254,
		boss_appear = 255,
		c5013_greet = 258,
		c5013_clap = 263,
		mon_swish_s = 665,
		mon_swish_m = 666,
		mon_disappear = 667,
		mon_appear = 668
	}

	public static string[] bgmList = new string[83]
	{
		"music_map/01_map_world_001",
		"music_map/02_map_town_001",
		"music_map/03_map_field_001",
		"music_map/04_map_dungeon_001",
		"music_map/05_map_sacred_001",
		"music_map/06_map_nature_001",
		"music_btl/01_btl_boss_001",
		"music_btl/02_btl_boss_002",
		"music_btl/03_btl_last_001",
		"music_btl/04_btl_raid_001",
		"music_sys/01_sys_gameover_001",
		string.Empty,
		string.Empty,
		"music_evt/02_evt_ending_001",
		"music_evt/03_evt_crisis_001",
		"music_evt/04_evt_conspire_001",
		"music_evt/05_evt_peaceful_001",
		string.Empty,
		"music_evt/07_evt_majestic_001",
		"music_sys/03_sys_lottery_001",
		"music_sys/04_sys_combine_001",
		"music_evt/08_evt_worry_001",
		"music_sys/05_sys_title_001",
		"music_sys/06_sys_fanfare_001",
		"music_sys/07_sys_result_001",
		"music_map/07_map_lastdungeon_001",
		"music_sys/08_sys_raidmenu_001",
		"music_evt/09_evt_restful_001",
		"music_evt/10_evt_greatevil_001",
		"music_map/08_map_wasteland_001",
		"music_map/09_map_romasaga2_001",
		"music_map/10_map_cq_field_001",
		"music_btl/05_btl_cq_boss_001",
		"music_map/11_map_dungeon_002",
		"music_map/12_map_seiken2_001",
		"music_map/13_map_brave_field_001",
		"music_btl/06_btl_brave_boss_001",
		"music_map/14_map_brave_field_002",
		"music_btl/07_btl_brave_boss_002",
		"music_map/15_map_merc_field_001",
		"music_map/16_map_merc_field_002",
		"music_btl/08_btl_merc_boss_001",
		"music_btl/09_btl_merc_boss_002",
		"music_map/17_map_ruin_001",
		"music_map/18_map_ff4_field_001",
		"music_btl/10_btl_ff4_boss_001",
		"music_btl/11_btl_ff4_boss_002",
		"music_btl/12_btl_ff4_boss_003",
		"music_evt/11_evt_greatevil_002",
		"music_btl/13_btl_seiken3_001",
		"music_btl/14_btl_seiken3_002",
		"music_btl/15_btl_seiken3_003",
		"music_btl/16_btl_seiken3_004",
		"music_evt/12_evt_peaceful_002",
		"music_btl/17_btl_lom_001",
		"music_btl/18_btl_lom_002",
		"music_btl/19_btl_lom_003",
		"music_btl/20_btl_lom_004",
		"music_btl/21_btl_lom_raid_001",
		"music_map/19_map_ffl_field_001",
		"music_btl/22_btl_ffl_001",
		"music_btl/23_btl_ffl_002",
		"music_btl/24_btl_boss_003",
		"music_map/20_map_bs_field_001",
		"music_btl/25_btl_bs_boss_001",
		"music_btl/27_btl_bs_raid_001",
		"music_btl/28_btl_seiken2_raid_001",
		"music_btl/29_btl_romasaga2_002",
		"music_btl/30_btl_romasaga3_001",
		"music_map/21_map_lastdungeon_002",
		"music_btl/31_btl_seiken1_boss_001",
		"music_btl/32_btl_seiken1_boss_002",
		"music_btl/33_btl_seiken1_boss_003",
		"music_btl/34_btl_last_boss_002",
		"music_map/22_map_fft_field_001",
		"music_btl/35_btl_fft_boss_001",
		"music_btl/36_btl_fft_boss_002",
		"music_evt/13_evt_ending_002",
		"music_map/24_map_ffrk_field_001",
		"music_btl/38_btl_ffrk_boss_001",
		"music_btl/39_btl_ffrk_boss_002",
		"music_btl/40_btl_ffrk_raid_001",
		string.Empty
	};

	public static string[] seList = new string[0];

	public static Dictionary<string, int> seNames = new Dictionary<string, int>();

	public static Dictionary<int, int[]> seTypes = new Dictionary<int, int[]>();

	public static Dictionary<string, int[]> seGroups = new Dictionary<string, int[]>();
}
