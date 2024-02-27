using System;

[Serializable]
public class BattleConstants
{
	[NonSerialized]
	public const float DEFAULT_PLAYER_MAGIC_TIME = 12f;

	[NonSerialized]
	public const float DEFAULT_WEAPON_SKILL_COOLDOWN_TIME = 6f;

	[NonSerialized]
	public const float MIN_PLAYER_MAGIC_TIME = 1f;

	[NonSerialized]
	public const float RAID_STYLE_BONUS_MULT = 2f;

	[NonSerialized]
	public const float RAID_ELEMENT_BONUS_MULT = 2f;

	[NonSerialized]
	public const float RAID_FULL_MATCH_BONUS_MULT = 6f;

	[NonSerialized]
	public const float ENEMY_POP_INTERVAL = 0.4f;

	[NonSerialized]
	public const float PAUSE_TIME_AFTER_2ND_POP = 1.5f;

	[NonSerialized]
	public const float KNOCKBACK_ATTENUATE = 0.5f;

	[NonSerialized]
	public const float KNOCKBACK_ATTENUATE_PLAYER_GUARD = 0.5f;

	[NonSerialized]
	public const float KNOCKBACK_ATTENUATE_MONSTER_GUARD = 0.5f;

	[NonSerialized]
	public const float DAMAGE_ATTENUATE_PLAYER_GUARD = 0.5f;

	[NonSerialized]
	public const float DAMAGE_ATTENUATE_MONSTER_GUARD = 0.25f;

	[NonSerialized]
	public const int PLAYER_WEAK_YARARE_RATE = 20;

	[NonSerialized]
	public const int COIN_PER_1_COINOBJ = 2;

	[NonSerialized]
	public const float TOUCH_LIMIT_TIME_TO_ATTACK = 0.01f;

	[NonSerialized]
	public const float TARGET_DISTANCE_TO_STOP_RUN = 0.1f;

	[NonSerialized]
	public const float CRITICAL_STOP_TIME = 0.1f;

	[NonSerialized]
	public const float JUST_DODGE_HP_RECOVERY_RATE = 0.02f;

	[NonSerialized]
	public const float JUSTDODGE_SKILL_COOLDOWN_TIME = 2f;

	[NonSerialized]
	public const int JUSTDODGE_MP_RESTORATION = 100;

	[NonSerialized]
	public const float MAGIC_RECOVERY_PlAYER_ATTACK_MULT = 100f;

	[NonSerialized]
	public const float MAGIC_RECOVERY_PlAYER_ATTACK_IF_BOSS_OR_ELITE = 5f;

	[NonSerialized]
	public const float MAGIC_RECOVERY_PlAYER_DAMAGE_MULT = 400f;

	[NonSerialized]
	public const float SUPPORT_WEAPON_COST_STYLE_MULT = 0.01f;

	[NonSerialized]
	public const float SUPPORT_WEAPON_COST_ELEMENT_MULT = 0.01f;

	[NonSerialized]
	public const float SUPPORT_WEAPON_COST_MULT_BASE = 0.02f;

	[NonSerialized]
	public const float SUPPORT_POPPET_COST_ELEMENT_MULT = 0.01f;

	[NonSerialized]
	public const float SUPPORT_POPPET_COST_MULT_BASE = 0.02f;

	[NonSerialized]
	public const float BOSS_SIGN_TIME = 2f;

	[NonSerialized]
	public const float BATTLE_RESET_NO_DAMAGE_TIME = 60f;

	[NonSerialized]
	public const float CONT_DIALOG_DELAY_TIME = 3f;

	[NonSerialized]
	public const float RAID_RESTORE_HP_WHEN_FRIEND_APPEARS = 0.1f;

	[NonSerialized]
	public const int RAID_FULL_POWER_ATTACK_DAMAGE = 1000000;

	[NonSerialized]
	public const float WEAK_STYLE_DAMAGE_MULT = 1.5f;

	[NonSerialized]
	public const bool RESTORE_POPPET_HP_AFTER_CHAINSKILL = true;

	[NonSerialized]
	public const float CONTINUE_NOHIT_TIME = 3f;

	[NonSerialized]
	public const float CHAINSKILL_NOHIT_TIME = 3f;

	[NonSerialized]
	public const float POPPET_DAMAGE_RATE = 0.2f;

	[NonSerialized]
	public const float POPPET_COLOSSEUM_DAMAGE_RATE = 0.2f;

	[NonSerialized]
	public const float ABNORMAL_STATE_RESTORATION_SPEED = 0f;

	[NonSerialized]
	public const float ABNORMAL_STATE_TOLERANCE_SCALE = 1.5f;

	[NonSerialized]
	public const float COLOSSEUM_FORCE_MAX = 100f;

	[NonSerialized]
	public const float COLOSSEUM_POPPET_REVIVE_TIME = 3f;

	[NonSerialized]
	public const float COLOSSEUM_BATTLE_TIME_LIMIT = 60f;

	[NonSerialized]
	public const float COLOSSEUM_MAGICPOINT_ATTACKER_RECOVERY_COEF = 200f;

	[NonSerialized]
	public const float COLOSSEUM_MAGICPOINT_DEFENSER_RECOVERY_COEF = 400f;

	[NonSerialized]
	public const float COLOSSEUM_MAGICPOINT_TEAMMATE_KILLED = 200f;

	[NonSerialized]
	public const float COLOSSEUM_CHAIN_SKILL_STAGE_TIME = 1.5f;

	[NonSerialized]
	public const float COLOSSEUM_WEAPON_ATK_COEF = 0.1f;

	[NonSerialized]
	public const float COLOSSEUM_WEAPON_ATK_COEF_MATCH = 0.2f;

	[NonSerialized]
	public const float COLOSSEUM_WEAPON_HP_COEF = 0.1f;

	[NonSerialized]
	public const float COLOSSEUM_WEAPON_HP_COEF_MATCH = 0.2f;

	[NonSerialized]
	public const float PLUS_ATTACK_STATUS_COEF = 2f;

	[NonSerialized]
	public const float PLUS_HP_STATUS_COEF = 10f;

	[NonSerialized]
	public const float PLUS_UR_ATTACK_STATUS_COEF = 3f;

	[NonSerialized]
	public const float PLUS_UR_HP_STATUS_COEF = 15f;

	[NonSerialized]
	public const float RECOVERY_DAMAGE_RATE = 0.666f;

	[NonSerialized]
	public const string LAYER_PLAYER = "CHR_RAID";

	[NonSerialized]
	public const string LAYER_ENEMY = "CHR";

	[NonSerialized]
	public const string LAYER_NOPUSHOUT = "CHR_NOPUSHOUT";

	[NonSerialized]
	public const string LAYER_PLAYER_ATTACK = "PlayerAttackColi";

	[NonSerialized]
	public const string LAYER_ENEMY_ATTACK = "EnemyAttackColi";

	[NonSerialized]
	public const string LAYER_PLAYER_YARARE = "PlayerYarareColi";

	[NonSerialized]
	public const string LAYER_ENEMY_YARARE = "EnemyYarareColi";

	[NonSerialized]
	public const string LAYER_AREA = "Default";

	[NonSerialized]
	public const string TAG_PLAYER = "Player";

	[NonSerialized]
	public const string TAG_ENEMY = "Enemy";

	[NonSerialized]
	public const string TAG_STATECHANGE_AREA = "StateChangeArea";

	[NonSerialized]
	public const string TAG_PLANE = "Plane";

	[NonSerialized]
	public const string TAG_PORTAL = "Portal";

	[NonSerialized]
	public const string ELITE_EFFECT_BASE_BONE = "cog";
}
