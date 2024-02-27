using System;

[Serializable]
public class SkillEffectData
{
	public float skillCoolDownRate;

	public float kaihiSkillCoolDownVal;

	public float candyRecoveryRate;

	public float candyMagicRecoveryValue;

	public float justDodgeTimeBonus;

	public float speedMult;

	public float moveCommandSpeedMult;

	public float hpMult;

	public float hpAdd;

	public bool invalidateDamageArea;

	public bool invalidateSlowArea;

	public bool invalidateGravityArea;

	public float mpRecoveryRateWhenDamaged;

	public float mpRecoveryValueWhenKaihi;

	public float mpRecoveryRateWhenAttack;

	public float hpRecoveryValueWhenKilled;

	public float changeCoolDownDecTime;

	public bool fullGuard;

	public bool stopWorld;

	public SkillEffectData()
	{
		setDefault();
	}

	public void setDefault()
	{
		skillCoolDownRate = 1f;
		kaihiSkillCoolDownVal = 0f;
		candyRecoveryRate = 0.1f;
		candyMagicRecoveryValue = 0f;
		float num = 0f;
		justDodgeTimeBonus = 0f;
		speedMult = 1f;
		moveCommandSpeedMult = 1f;
		hpMult = 1f;
		hpAdd = 0f;
		invalidateDamageArea = false;
		invalidateSlowArea = false;
		invalidateGravityArea = false;
		mpRecoveryRateWhenDamaged = 1f;
		mpRecoveryValueWhenKaihi = 0f;
		mpRecoveryRateWhenAttack = 1f;
		hpRecoveryValueWhenKilled = 0f;
		changeCoolDownDecTime = 0f;
		fullGuard = false;
		stopWorld = false;
	}

	public float calcHpMax(float @base)
	{
		return (@base + hpAdd) * hpMult;
	}
}
