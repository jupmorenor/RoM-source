using System;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class SkillEffector
{
	private RespPoppet originPoppet;

	private RespWeapon originWeapon;

	public SkillEffectParameters skileff;

	public int level;

	public int levelMax;

	public float powerBase;

	public bool HasExpiration;

	private float expirationTime;

	private float initialExpirationTime;

	private bool emitted;

	private EnumSkillEffectTypes _effectType;

	private bool _0024initialized__SkillEffector_0024;

	public object Origin => (originPoppet == null) ? ((JsonBase)originWeapon) : ((JsonBase)originPoppet);

	public float PowerBaseRate => powerBase / 100f;

	public bool IsExpired
	{
		get
		{
			bool num = HasExpiration;
			if (num)
			{
				num = !(expirationTime > 0f);
			}
			return num;
		}
	}

	public bool IsNotExpiredAndNotInfinity
	{
		get
		{
			bool num = HasExpiration;
			if (num)
			{
				num = expirationTime > 0f;
			}
			return num;
		}
	}

	public EnumSkillEffectTypes EffectType
	{
		get
		{
			if (_effectType == (EnumSkillEffectTypes)(-1) && skileff != null)
			{
				_effectType = skileff.SkillEffectType;
			}
			return (EnumSkillEffectTypes)((_effectType == (EnumSkillEffectTypes)(-1)) ? ((object)0) : ((object)_effectType));
		}
	}

	public float EffValueAsRate => skileff.getEffectValueAsRate(level, levelMax, string.Empty);

	public float EffValue => skileff.getEffectValue(level, levelMax, string.Empty);

	public RespPoppet OriginPoppet => originPoppet;

	public RespWeapon OriginWeapon => originWeapon;

	public float ExpirationTime => expirationTime;

	public float InitialExpirationTime => initialExpirationTime;

	private SkillEffector(object origin, SkillEffectParameters ske, int level, int levelMax)
	{
		if (!_0024initialized__SkillEffector_0024)
		{
			_effectType = (EnumSkillEffectTypes)(-1);
			_0024initialized__SkillEffector_0024 = true;
		}
		if (ske == null)
		{
			throw new AssertionFailedException("ske != null");
		}
		init(ske, level, levelMax, 0f, 0f);
		setOrigin(origin);
	}

	private SkillEffector(object origin, SkillEffectParameters ske, int level, int levelMax, float powerBase)
	{
		if (!_0024initialized__SkillEffector_0024)
		{
			_effectType = (EnumSkillEffectTypes)(-1);
			_0024initialized__SkillEffector_0024 = true;
		}
		init(ske, level, levelMax, powerBase, 0f);
		setOrigin(origin);
	}

	private SkillEffector(object origin, SkillEffectParameters ske, int level, int levelMax, float powerBase, float expirationTime)
	{
		if (!_0024initialized__SkillEffector_0024)
		{
			_effectType = (EnumSkillEffectTypes)(-1);
			_0024initialized__SkillEffector_0024 = true;
		}
		init(ske, level, levelMax, powerBase, expirationTime);
		setOrigin(origin);
	}

	public override string ToString()
	{
		return new StringBuilder("SkillEffector(").Append(skileff).Append(" level:").Append((object)level)
			.Append(" levelMax:")
			.Append((object)levelMax)
			.Append(" powerBase:")
			.Append(powerBase)
			.Append(") - origin=")
			.Append(Origin)
			.ToString();
	}

	private void setExpired()
	{
		HasExpiration = true;
		expirationTime = 0f;
		initialExpirationTime = 0f;
	}

	private void setOrigin(object origin)
	{
		if (origin is RespPoppet)
		{
			originPoppet = origin as RespPoppet;
		}
		else if (origin is RespWeapon)
		{
			originWeapon = origin as RespWeapon;
		}
	}

	private void init(SkillEffectParameters ske, int level, int levelMax, float powerBase, float expirationTime)
	{
		if (ske == null)
		{
			throw new AssertionFailedException("ske != null");
		}
		skileff = ske;
		this.level = level;
		this.levelMax = levelMax;
		this.powerBase = powerBase;
		if (!(expirationTime <= 0f))
		{
			HasExpiration = true;
			this.expirationTime = expirationTime;
			initialExpirationTime = expirationTime;
		}
		else
		{
			HasExpiration = false;
		}
	}

	public static SkillEffector WeaponCoverSkill(RespWeapon w)
	{
		object result;
		if (w == null || w.CoverSkill == null)
		{
			result = null;
		}
		else
		{
			MCoverSkills coverSkill = w.CoverSkill;
			result = new SkillEffector(w, coverSkill.SkillEffect, w.CoverSkillLevel, coverSkill.LevelMax);
		}
		return (SkillEffector)result;
	}

	public static SkillEffector[] PoppetCoverSkills(RespPoppet p)
	{
		object result;
		if (p == null)
		{
			result = new SkillEffector[0];
		}
		else
		{
			List<SkillEffector> list = new List<SkillEffector>();
			SkillEffector skillEffector = PoppetCoverSkill1(p);
			if (skillEffector != null)
			{
				list.Add(skillEffector);
			}
			SkillEffector skillEffector2 = PoppetCoverSkill2(p);
			if (skillEffector2 != null)
			{
				list.Add(skillEffector2);
			}
			result = (SkillEffector[])Builtins.array(typeof(SkillEffector), list);
		}
		return (SkillEffector[])result;
	}

	public static SkillEffector PoppetCoverSkill1(RespPoppet p)
	{
		object result;
		if (p != null && p.CoverSkill1 != null)
		{
			MCoverSkills coverSkill = p.CoverSkill1;
			result = new SkillEffector(p, coverSkill.SkillEffect, p.CoverSkillLevel_1, coverSkill.LevelMax);
		}
		else
		{
			result = null;
		}
		return (SkillEffector)result;
	}

	public static SkillEffector PoppetCoverSkill2(RespPoppet p)
	{
		object result;
		if (p != null && p.CoverSkill2 != null)
		{
			MCoverSkills coverSkill = p.CoverSkill2;
			result = new SkillEffector(p, coverSkill.SkillEffect, p.CoverSkillLevel_2, coverSkill.LevelMax);
		}
		else
		{
			result = null;
		}
		return (SkillEffector)result;
	}

	public static SkillEffector PoppetChainSkill(RespPoppet p)
	{
		object result;
		if (p == null)
		{
			result = null;
		}
		else
		{
			MChainSkills chainSkill = p.ChainSkill;
			result = ((chainSkill == null) ? null : new SkillEffector(p, chainSkill.SkillEffect, p.ChainSkillLevel, chainSkill.LevelMax, chainSkill.PowerBase, chainSkill.ExpirationTime));
		}
		return (SkillEffector)result;
	}

	public static SkillEffector CreateFromCoverSkillMaster(MCoverSkills csmst, int level)
	{
		return (csmst == null) ? null : new SkillEffector(null, csmst.SkillEffect, level, csmst.LevelMax);
	}

	public static SkillEffector CreateForDebug(SkillEffectParameters ske, int level, int levelMax, float powerBase, float expirationTime)
	{
		return new SkillEffector(null, ske, level, levelMax, powerBase, expirationTime);
	}

	public void update(float dt)
	{
		if (HasExpiration && emitted)
		{
			expirationTime -= dt;
		}
	}

	public void calcSkillEffectData(SkillEffectData d, MerlinActionControl ch, RespWeapon[] weapons)
	{
		if (EffectType == EnumSkillEffectTypes.IncKaihiMutekiTime)
		{
			d.justDodgeTimeBonus += EffValue / 60f;
		}
		if (EffectType == EnumSkillEffectTypes.IncKaihiDistance && ch.isAnimType(PlayerAnimationTypes.Kaihi))
		{
			d.moveCommandSpeedMult *= EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.IncSpeed)
		{
			d.speedMult *= EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.IncHP)
		{
			d.hpMult *= EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.PlusHP)
		{
			d.hpAdd += EffValue;
		}
		if (weapons != null)
		{
			int i = 0;
			for (int length = weapons.Length; i < length; i = checked(i + 1))
			{
				if (weapons[i] != null)
				{
					if (EffectType == EnumSkillEffectTypes.IncHPByStyle && RuntimeServices.EqualityOperator(weapons[i].Style, skileff.MStyleId))
					{
						d.hpMult *= EffValueAsRate;
					}
					if (EffectType == EnumSkillEffectTypes.AddHPByStyle && RuntimeServices.EqualityOperator(weapons[i].Style, skileff.MStyleId))
					{
						d.hpAdd += EffValue;
					}
					if (EffectType == EnumSkillEffectTypes.IncHPByElement && RuntimeServices.EqualityOperator(weapons[i].Element, skileff.MElementId))
					{
						d.hpMult *= EffValueAsRate;
					}
					if (EffectType == EnumSkillEffectTypes.AddHPByElement && RuntimeServices.EqualityOperator(weapons[i].Element, skileff.MElementId))
					{
						d.hpAdd += EffValue;
					}
				}
			}
		}
		if (EffectType == EnumSkillEffectTypes.InvalidateDamageArea)
		{
			d.invalidateDamageArea = true;
		}
		if (EffectType == EnumSkillEffectTypes.InvalidateSlowArea)
		{
			d.invalidateSlowArea = true;
		}
		if (EffectType == EnumSkillEffectTypes.InvalidateGravityArea)
		{
			d.invalidateGravityArea = true;
		}
		if (EffectType == EnumSkillEffectTypes.IncDropRestoration)
		{
			d.candyRecoveryRate *= EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.MPDropRestoration)
		{
			d.candyMagicRecoveryValue += EffValue;
		}
		if (EffectType == EnumSkillEffectTypes.DecSkillCooldownOfStyle && ch.isAStyle(skileff.MStyleId))
		{
			d.skillCoolDownRate *= EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.QuickCooldownUnderHP20 && !(ch.HitPointRate > 0.2f))
		{
			d.skillCoolDownRate *= EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.QuickCooldownUnderHP10 && !(ch.HitPointRate > 0.1f))
		{
			d.skillCoolDownRate *= EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.QuickCooldownUnderHPNN && !(ch.HitPointRate > skileff.UnderHPAsRate))
		{
			d.skillCoolDownRate *= EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.QuickCooldownWhenKaihi)
		{
			d.kaihiSkillCoolDownVal += EffValue;
		}
		if (EffectType == EnumSkillEffectTypes.IncMpRestorationWhenDamaged)
		{
			d.mpRecoveryRateWhenDamaged *= EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.MPRestorationWhenKaihi)
		{
			d.mpRecoveryValueWhenKaihi += EffValue;
		}
		if (EffectType == EnumSkillEffectTypes.IncMpRestorationWhenAttack)
		{
			d.mpRecoveryRateWhenAttack *= EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.HPRestorationWhenKill)
		{
			d.hpRecoveryValueWhenKilled += EffValue;
		}
		if (EffectType == EnumSkillEffectTypes.QuickChangeCooldown)
		{
			d.changeCoolDownDecTime += EffValue;
		}
		if (EffectType == EnumSkillEffectTypes.ChFullGuard)
		{
			d.fullGuard = true;
		}
		if (EffectType == EnumSkillEffectTypes.ChFastCooldown)
		{
			d.skillCoolDownRate *= PowerBaseRate;
		}
		if (EffectType == EnumSkillEffectTypes.ChSpeed)
		{
			d.speedMult *= PowerBaseRate;
		}
		if (EffectType == EnumSkillEffectTypes.ChInvalidAbnormalState)
		{
			d.invalidateDamageArea = true;
		}
		if (EffectType == EnumSkillEffectTypes.ChInvalidAbnormalState)
		{
			d.invalidateSlowArea = true;
		}
		if (EffectType == EnumSkillEffectTypes.ChInvalidAbnormalState)
		{
			d.invalidateGravityArea = true;
		}
		if (EffectType == EnumSkillEffectTypes.ChNoDamage)
		{
			d.invalidateDamageArea = true;
		}
	}

	private void displayAddHp(PlayerControl pl, float val)
	{
		if (pl != null)
		{
			DamageDisplay.DisplayAddPlayerHp(pl, val);
		}
	}

	public bool effectAtSkillEmission(RespPoppet poppet, MerlinActionControl ch)
	{
		int result;
		if (ch == null)
		{
			result = 0;
		}
		else
		{
			PlayerControl playerControl = ch as PlayerControl;
			emitted = true;
			if (EffectType == EnumSkillEffectTypes.ChAddHP)
			{
				displayAddHp(playerControl, powerBase);
				ch.addHP(powerBase);
				setExpired();
				result = 1;
			}
			else if (EffectType == EnumSkillEffectTypes.ChRestoreHPByPoppetHP)
			{
				if (poppet != null)
				{
					float num = poppet.TotalHP * PowerBaseRate;
					displayAddHp(playerControl, num);
					ch.addHP(num);
					setExpired();
					result = 1;
				}
				else
				{
					result = 0;
				}
			}
			else if (EffectType == EnumSkillEffectTypes.ChInvalidateAttackNTimes)
			{
				if (playerControl != null)
				{
					playerControl.startHitCancel(checked((int)powerBase));
				}
				result = 1;
			}
			else
			{
				result = 0;
			}
		}
		return (byte)result != 0;
	}

	public bool effectAtSkillEmissionToEnemies(MerlinActionControl origin)
	{
		int result;
		if (origin == null)
		{
			result = 0;
		}
		else if (EffectType == EnumSkillEffectTypes.ChRateDamageToAll)
		{
			damageAndYarareToAllEnemies(origin);
			result = 1;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	private void damageAndYarareToAllEnemies(MerlinActionControl ch)
	{
		if (ch == null)
		{
			return;
		}
		int i = 0;
		BaseControl[] allControls = BaseControl.AllControls;
		checked
		{
			for (int length = allControls.Length; i < length; i++)
			{
				AIControl aIControl = allControls[i] as AIControl;
				if (!(aIControl == null) && !aIControl.IsDead && !(aIControl.tag == ch.tag))
				{
					float num = aIControl.HitPoint * PowerBaseRate;
					aIControl.HitAttack((int)num, YarareTypes.Weak, ch.gameObject);
				}
			}
		}
	}

	public float requiredMagicPoint()
	{
		return EffValue;
	}

	public float criticalRateMult(float attackerHitPointRate, bool attackerIsTensi, bool attackerIsAkuma)
	{
		float num = 1f;
		if (EffectType == EnumSkillEffectTypes.IncCriticalRate)
		{
			num *= EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.IncCriticalRateWhenHP20 && !(attackerHitPointRate > 0.2f))
		{
			num *= EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.IncCriticalTenshi && attackerIsTensi)
		{
			num *= EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.IncCriticalAkuma && attackerIsAkuma)
		{
			num *= EffValueAsRate;
		}
		return num;
	}

	public float maximumChainCriticalRate()
	{
		float result = 0f;
		if (EffectType == EnumSkillEffectTypes.ChCritical)
		{
			result = PowerBaseRate;
		}
		return result;
	}

	public float attackPlus(bool attackerHasAnyAbnormalState, MStyles attackStyle, MElements attackElement)
	{
		float num = 0f;
		if (EffectType == EnumSkillEffectTypes.PlusAttackByStyle && RuntimeServices.EqualityOperator(skileff.MStyleId, attackStyle))
		{
			num += EffValue;
		}
		if (EffectType == EnumSkillEffectTypes.PlusAttackWhenAbnormalState && attackerHasAnyAbnormalState)
		{
			num += EffValue;
		}
		return num;
	}

	public float attackPlusBy2Weapons(EnumElements atkElem1, EnumElements atkElem2)
	{
		float num = 0f;
		if (EffectType == EnumSkillEffectTypes.PlusAttackByElement && skileff.Element == atkElem1)
		{
			num += EffValue;
		}
		if (EffectType == EnumSkillEffectTypes.PlusAttackByElement && skileff.Element == atkElem2)
		{
			num += EffValue;
		}
		return num;
	}

	public float attackMult(bool attackerHasAnyAbnormalState, MStyles attackStyle)
	{
		float num = 1f;
		if (EffectType == EnumSkillEffectTypes.IncAttackByStyle && RuntimeServices.EqualityOperator(attackStyle, skileff.MStyleId))
		{
			num *= EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.IncAttack)
		{
			num *= EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.IncAttackWhenAbnormalState && attackerHasAnyAbnormalState)
		{
			num *= EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.ChAttack)
		{
			num *= PowerBaseRate;
		}
		return num;
	}

	public float attackDamageMult(MerlinActionControl attacker, EnumElements enElm, EnumRaces enRace, bool enGuard, bool enElite, bool isCritical, MerlinActionControl dfcCont)
	{
		float result;
		if (attacker == null)
		{
			result = 1f;
		}
		else
		{
			PlayerControl playerControl = attacker as PlayerControl;
			float num = 1f;
			if (EffectType == EnumSkillEffectTypes.IncDamageToElement && enElm == skileff.Element)
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageToRace && enRace == skileff.Race)
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageToGuarder && enGuard)
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageToExtraMonster && enElite)
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageUnderHP10 && !(attacker.HitPointRate > 0.1f))
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageUnderHP20 && !(attacker.HitPointRate > 0.2f))
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncCriticalDamage && isCritical)
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageUnderHPNN && !(attacker.HitPointRate > skileff.UnderHPAsRate))
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageIfSameStyleAll && IsAllWeaponStyle(playerControl, skileff.Style))
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageIfMainSameStyleAll && IsMainWeaponStyle(playerControl, skileff.Style))
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageIfSameStyle4 && IsAllWeaponStyleN(playerControl, skileff.Style, 4))
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageIfSameElementAll && IsAllWeaponElement(playerControl, skileff.Element))
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageIfMainSameElementAll && IsMainWeaponStyle(playerControl, skileff.Element))
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageIfSameElement4 && IsAllWeaponElementN(playerControl, skileff.Element, 4))
			{
				num *= EffValueAsRate;
			}
			DayOfWeek dayOfWeek = CurrentWeekDay();
			if (EffectType == EnumSkillEffectTypes.IncDamageMonday && dayOfWeek == DayOfWeek.Monday)
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageTuesday && dayOfWeek == DayOfWeek.Tuesday)
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageWednesday && dayOfWeek == DayOfWeek.Wednesday)
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageThursday && dayOfWeek == DayOfWeek.Thursday)
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageFriday && dayOfWeek == DayOfWeek.Friday)
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageSaturday && dayOfWeek == DayOfWeek.Saturday)
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageSunday && dayOfWeek == DayOfWeek.Sunday)
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamage7To19 && Is7To19())
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamage19To26 && Is19To26())
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageIfAbnormalStatePoisonEnemy && HasAbst(dfcCont, EnumAbnormalStates.Poison))
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageIfAbnormalStateConflictEnemy && HasAbst(dfcCont, EnumAbnormalStates.Conflict))
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageIfAbnormalStateStunEnemy && HasAbst(dfcCont, EnumAbnormalStates.Stun))
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageIfAbnormalStateSlowEnemy && HasAbst(dfcCont, EnumAbnormalStates.Slow))
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageIfAbnormalStateBlindEnemy && HasAbst(dfcCont, EnumAbnormalStates.Blind))
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageIfAbnormalStateBurnEnemy && HasAbst(dfcCont, EnumAbnormalStates.Burn))
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageIfAbnormalStateFreezeEnemy && HasAbst(dfcCont, EnumAbnormalStates.Freeze))
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.IncDamageOverHPNN && !(attacker.HitPointRate < skileff.UnderHPAsRate))
			{
				num *= EffValueAsRate;
			}
			if (playerControl != null)
			{
				if (EffectType == EnumSkillEffectTypes.IncDamageIfTensi && playerControl.IsTensi)
				{
					num *= EffValueAsRate;
				}
				if (EffectType == EnumSkillEffectTypes.IncDamageIfAkuma && playerControl.IsAkuma)
				{
					num *= EffValueAsRate;
				}
			}
			result = num;
		}
		return result;
	}

	private static bool HasAbst(MerlinActionControl ch, EnumAbnormalStates state)
	{
		return ch != null && ch.AbnormalStateControl.hasAbnormalState(state);
	}

	private static DayOfWeek CurrentWeekDay()
	{
		return PlayDateTime().ToLocalTime().DayOfWeek;
	}

	public static DateTime PlayDateTime()
	{
		DateTime result = MerlinDateTime.UtcNow;
		if (!QuestInitializer.IsInQuest)
		{
			GameApiResponseBase lastGameResponse = CurrentInfo.LastGameResponse;
			if (lastGameResponse != null)
			{
				result = lastGameResponse.ParseRequestDate();
			}
		}
		else if (QuestSession.Session != null && QuestSession.Session.startResponse != null)
		{
			result = QuestSession.Session.startResponse.ParseRequestDate();
		}
		return result;
	}

	private static bool IsAllWeaponStyle(PlayerControl pl, EnumStyles style)
	{
		int result;
		if (pl == null || pl.weaponEquipments == null)
		{
			result = 0;
		}
		else
		{
			int num = 0;
			RespWeapon[] array = pl.weaponEquipments.allWeaponsArray();
			int length = array.Length;
			while (true)
			{
				if (num < length)
				{
					if (array[num] == null || array[num].StyleId != (int)style)
					{
						result = 0;
						break;
					}
					num = checked(num + 1);
					continue;
				}
				result = 1;
				break;
			}
		}
		return (byte)result != 0;
	}

	private static bool IsAllWeaponStyleN(PlayerControl pl, EnumStyles style, int num)
	{
		int result;
		if (pl == null || pl.weaponEquipments == null)
		{
			result = 0;
		}
		else
		{
			int num2 = 0;
			int i = 0;
			RespWeapon[] array = pl.weaponEquipments.allWeaponsArray();
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (array[i] == null || array[i].StyleId != (int)style)
				{
					num2 = checked(num2 + 1);
				}
			}
			result = ((num2 >= num) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	private static bool IsMainWeaponStyle(PlayerControl pl, EnumStyles style)
	{
		int result;
		if (pl == null)
		{
			result = 0;
		}
		else
		{
			int num = 0;
			RespWeapon[] mainWeaponList = pl.MainWeaponList;
			int length = mainWeaponList.Length;
			while (true)
			{
				if (num < length)
				{
					if (mainWeaponList[num] == null || mainWeaponList[num].StyleId != (int)style)
					{
						result = 0;
						break;
					}
					num = checked(num + 1);
					continue;
				}
				result = 1;
				break;
			}
		}
		return (byte)result != 0;
	}

	private static bool IsAllWeaponElement(PlayerControl pl, EnumElements elm)
	{
		int result;
		if (pl == null || pl.weaponEquipments == null)
		{
			result = 0;
		}
		else
		{
			int num = 0;
			RespWeapon[] array = pl.weaponEquipments.allWeaponsArray();
			int length = array.Length;
			while (true)
			{
				if (num < length)
				{
					if (array[num] == null || array[num].ElementId != (int)elm)
					{
						result = 0;
						break;
					}
					num = checked(num + 1);
					continue;
				}
				result = 1;
				break;
			}
		}
		return (byte)result != 0;
	}

	private static bool IsAllWeaponElementN(PlayerControl pl, EnumElements elm, int num)
	{
		int result;
		if (pl == null || pl.weaponEquipments == null)
		{
			result = 0;
		}
		else
		{
			int num2 = 0;
			int i = 0;
			RespWeapon[] array = pl.weaponEquipments.allWeaponsArray();
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (array[i] == null || array[i].ElementId != (int)elm)
				{
					num2 = checked(num2 + 1);
				}
			}
			result = ((num2 >= num) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	private static bool IsAllMainWeaponElement(PlayerControl pl, EnumElements elem)
	{
		int result;
		if (pl == null || pl.weaponEquipments == null)
		{
			result = 0;
		}
		else
		{
			int num = 0;
			RespWeapon[] mainWeaponList = pl.MainWeaponList;
			int length = mainWeaponList.Length;
			while (true)
			{
				if (num < length)
				{
					if (mainWeaponList[num] == null || mainWeaponList[num].ElementId != (int)elem)
					{
						result = 0;
						break;
					}
					num = checked(num + 1);
					continue;
				}
				result = 1;
				break;
			}
		}
		return (byte)result != 0;
	}

	private static bool IsDayOfWeek(DayOfWeek weekday)
	{
		DayOfWeek dayOfWeek = MerlinDateTime.Now.DayOfWeek;
		return dayOfWeek == weekday;
	}

	private static bool Is7To19()
	{
		int hour = PlayDateTime().Hour;
		bool num = 7 <= hour;
		if (num)
		{
			num = hour <= 19;
		}
		return num;
	}

	private static bool Is19To26()
	{
		int hour = PlayDateTime().Hour;
		bool num = 19 <= hour;
		if (!num)
		{
			num = hour <= 2;
		}
		return num;
	}

	private static bool IsMainWeaponStyle(PlayerControl pl, EnumElements elm)
	{
		int result;
		if (pl == null)
		{
			result = 0;
		}
		else
		{
			int num = 0;
			RespWeapon[] mainWeaponList = pl.MainWeaponList;
			int length = mainWeaponList.Length;
			while (true)
			{
				if (num < length)
				{
					if (mainWeaponList[num] == null || mainWeaponList[num].ElementId != (int)elm)
					{
						result = 0;
						break;
					}
					num = checked(num + 1);
					continue;
				}
				result = 1;
				break;
			}
		}
		return (byte)result != 0;
	}

	public float attackDamageAdd(float attackerMaxHitPoint)
	{
		float num = 0f;
		if (EffectType == EnumSkillEffectTypes.AddDamageByHP)
		{
			num += EffValueAsRate * attackerMaxHitPoint;
		}
		return num;
	}

	public float defenseMult(MerlinActionControl defenser, EnumElements attackerElement, bool defenserIsGuarding, float defenserHitPointRate)
	{
		float num = 1f;
		PlayerControl playerControl = defenser as PlayerControl;
		if (EffectType == EnumSkillEffectTypes.DecDamageByElement && attackerElement == skileff.Element)
		{
			num *= EffValueAsRate;
		}
		if (playerControl != null)
		{
			if (EffectType == EnumSkillEffectTypes.DecDamageWhenRecoveryDamageZero && playerControl.RecoveryDamage <= 0)
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.DecDamageWhenUsingSkill && playerControl.isActionType(ActionTypes.Skill))
			{
				num *= EffValueAsRate;
			}
		}
		if (EffectType == EnumSkillEffectTypes.DecDamageWhenGuard && defenserIsGuarding)
		{
			num *= EffValueAsRate;
		}
		if (playerControl != null)
		{
			if (EffectType == EnumSkillEffectTypes.DecDamageIfTensi && playerControl.IsTensi)
			{
				num *= EffValueAsRate;
			}
			if (EffectType == EnumSkillEffectTypes.DecDamageIfAkuma && playerControl.IsAkuma)
			{
				num *= EffValueAsRate;
			}
		}
		if (EffectType == EnumSkillEffectTypes.DecDamageUnderHPNN && !(defenserHitPointRate > skileff.UnderHPAsRate))
		{
			num *= EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.DecDamageOverHPNN && !(defenserHitPointRate < skileff.UnderHPAsRate))
		{
			num *= EffValueAsRate;
		}
		if (playerControl != null && EffectType == EnumSkillEffectTypes.DecDamageIfMainSameElementAll && IsAllMainWeaponElement(playerControl, skileff.Element))
		{
			num *= EffValueAsRate;
		}
		return num;
	}

	public float yarareResistPlus()
	{
		float num = 0f;
		if (EffectType == EnumSkillEffectTypes.DecYarareRate)
		{
			num += EffValue;
		}
		return num;
	}

	public float enemyDefenseMult()
	{
		float num = 1f;
		if (EffectType == EnumSkillEffectTypes.ChInvalidDefense)
		{
			num *= 0f;
		}
		return num;
	}

	public float finalDamageAdjust(float damage, float defenserHitPoint)
	{
		float result = damage;
		if (EffectType == EnumSkillEffectTypes.Damage1UnderSpecHP && !(defenserHitPoint > EffValue) && !(damage <= 1f))
		{
			result = 1f;
		}
		return result;
	}

	public float unguardRate(MElements attackerElement, MStyles defenserStyle)
	{
		float num = 1f;
		if (EffectType == EnumSkillEffectTypes.GuardByStyle && RuntimeServices.EqualityOperator(defenserStyle, skileff.MStyleId))
		{
			num *= 1f - EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.GuardByElement && RuntimeServices.EqualityOperator(skileff.MElementId, attackerElement))
		{
			num *= 1f - EffValueAsRate;
		}
		return num;
	}

	public float undodgeHeal(MStyles defenserStyle, MElements defenserElement, bool defenserIsGuarding)
	{
		float num = 1f;
		if (EffectType == EnumSkillEffectTypes.DodgeHealByStyle && RuntimeServices.EqualityOperator(skileff.MStyleId, defenserStyle))
		{
			num *= 1f - EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.DodgeHealByElement && RuntimeServices.EqualityOperator(skileff.MElementId, defenserElement))
		{
			num *= 1f - EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.DodgeWhenGuard && defenserIsGuarding)
		{
			num *= 1f - EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.ChDodgeHeal)
		{
			num = 0f;
		}
		return num;
	}

	public float yarareRate(bool usingSkill)
	{
		float num = 1f;
		if (EffectType == EnumSkillEffectTypes.NoYarare)
		{
			num *= 1f - EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.NoYarareWhenUsingSkill && usingSkill)
		{
			num *= 1f - EffValueAsRate;
		}
		if (EffectType == EnumSkillEffectTypes.ChNoDamage)
		{
			num = 0f;
		}
		return num;
	}

	public float notInvalidateSuperArmor()
	{
		float result = 1f;
		if (EffectType == EnumSkillEffectTypes.ChInvalidateSuperArmor)
		{
			result = 0f;
		}
		return result;
	}

	public float downRate()
	{
		float num = 1f;
		if (EffectType == EnumSkillEffectTypes.NoDown)
		{
			num *= EffValueAsRate;
		}
		return num;
	}

	public float attackHitHpRecovery(MerlinActionControl attacker, bool isCritical)
	{
		float num = 0f;
		if (EffectType == EnumSkillEffectTypes.RandomRestorationWhenCritical && isCritical && !(UnityEngine.Random.Range(0f, 1f) >= EffValueAsRate))
		{
			num += 1f;
		}
		if (EffectType == EnumSkillEffectTypes.RandomRestoration2WhenCritical && isCritical && !(UnityEngine.Random.Range(0f, 1f) >= EffValueAsRate))
		{
			num += 2f;
		}
		if (EffectType == EnumSkillEffectTypes.HPRestorationWhenCritical && isCritical)
		{
			num += EffValue;
		}
		if (EffectType == EnumSkillEffectTypes.ChAddHPIfHit)
		{
			num += powerBase;
		}
		if (!(num <= 0f))
		{
			attacker.HitPointRecovery(num);
			if (attacker is PlayerControl)
			{
				displayAddHp(attacker as PlayerControl, powerBase);
			}
		}
		return num;
	}

	public bool canResistAbnormalState(MerlinActionControl ch, EnumAbnormalStates state)
	{
		return !(ch == null) && (EffectType == EnumSkillEffectTypes.ChInvalidAbnormalState || EffectType == EnumSkillEffectTypes.ChNoDamage || (EffectType == EnumSkillEffectTypes.ResistAllAbnormalState && randomSuccess()) || ((EffectType == EnumSkillEffectTypes.ResistPoison && state == EnumAbnormalStates.Poison) ? randomSuccess() : ((EffectType == EnumSkillEffectTypes.ResistConfliction && state == EnumAbnormalStates.Conflict) ? randomSuccess() : ((EffectType == EnumSkillEffectTypes.ResistParalyze && state == EnumAbnormalStates.Stun) ? randomSuccess() : ((EffectType == EnumSkillEffectTypes.ResistSlow && state == EnumAbnormalStates.Slow) ? randomSuccess() : ((EffectType == EnumSkillEffectTypes.ResistBlind && state == EnumAbnormalStates.Blind) ? randomSuccess() : ((EffectType == EnumSkillEffectTypes.ResistHidaruma && state == EnumAbnormalStates.Burn) ? randomSuccess() : ((EffectType == EnumSkillEffectTypes.ResistHesitation && state == EnumAbnormalStates.Hate) ? randomSuccess() : ((EffectType == EnumSkillEffectTypes.ResistChibikko && state == EnumAbnormalStates.Small) ? randomSuccess() : (EffectType == EnumSkillEffectTypes.ResistFreeze && state == EnumAbnormalStates.Freeze && randomSuccess()))))))))));
	}

	public bool randomSuccess()
	{
		return !(UnityEngine.Random.Range(0f, 1f) > EffValueAsRate);
	}

	public float attackMinimumDamage()
	{
		return (EffectType != EnumSkillEffectTypes.LimitMonsterMininumDamage) ? 1f : EffValue;
	}

	public float maximumDamage(float defenserMaxHitPoint)
	{
		float num = float.PositiveInfinity;
		if (EffectType == EnumSkillEffectTypes.LimitPlayerDamageByHP)
		{
			num = Mathf.Min(num, EffValueAsRate * defenserMaxHitPoint);
		}
		if (EffectType == EnumSkillEffectTypes.ChNoDamage)
		{
			num = 0f;
		}
		return num;
	}

	public void applyHitEffectToAttacker(MerlinActionControl attacker, bool criticalOk, MElements monsterElement, bool isKilled)
	{
		if (attacker == null)
		{
			return;
		}
		PlayerControl playerControl = attacker as PlayerControl;
		if (playerControl != null)
		{
			if (EffectType == EnumSkillEffectTypes.QuickCooldownWhenCritical && criticalOk)
			{
				playerControl.coolDownWeaponSkill(EffValue);
			}
			if (EffectType == EnumSkillEffectTypes.QuickCooldownWhenDefeat && isKilled)
			{
				playerControl.coolDownWeaponSkill(EffValue);
			}
		}
		if (EffectType == EnumSkillEffectTypes.AddHPWhenAttackByElement && RuntimeServices.EqualityOperator(skileff.MElementId, monsterElement))
		{
			displayAddHp(playerControl, EffValue);
			attacker.addHP(EffValue);
		}
		if (EffectType == EnumSkillEffectTypes.IncHPWhenAttackByElement && RuntimeServices.EqualityOperator(skileff.MElementId, monsterElement))
		{
			float num = EffValueAsRate * attacker.MaxHitPoint;
			displayAddHp(playerControl, num);
			attacker.addHP(num);
		}
		if (EffectType == EnumSkillEffectTypes.ChAddHPIfCritical && criticalOk)
		{
			displayAddHp(playerControl, powerBase);
			attacker.addHP(powerBase);
		}
		if (EffectType == EnumSkillEffectTypes.ChAddHPIfCriticalByRel && criticalOk)
		{
			float num2 = PowerBaseRate * attacker.MaxHitPoint;
			displayAddHp(playerControl, num2);
			attacker.addHP(num2);
		}
	}

	public void applyHitEffectToDefenser(MerlinActionControl defenser, bool successDodge, bool isKilled)
	{
		PlayerControl playerControl = defenser as PlayerControl;
		if (playerControl != null && EffectType == EnumSkillEffectTypes.RevivePoppetWhenDodge && successDodge && randomSuccess())
		{
			playerControl.revivePoppetsIfDead();
		}
	}

	public void doEffectsPoppetDied(PlayerControl pl)
	{
		if (!(pl == null))
		{
			if (EffectType == EnumSkillEffectTypes.AddHPWhenPoppetDead)
			{
				displayAddHp(pl, EffValue);
				pl.addHP(EffValue);
			}
			if (EffectType == EnumSkillEffectTypes.IncHPWhenPoppetDead)
			{
				float num = pl.MaxHitPoint * EffValueAsRate;
				displayAddHp(pl, num);
				pl.addHP(num);
			}
		}
	}

	public void setAbnormalStateToAttackCommand(ActionCommandAttack cmd)
	{
		if (cmd != null)
		{
			int rate = skileff.Rate;
			int power = checked((int)EffValue);
			if (EffectType == EnumSkillEffectTypes.AbnormalStateAttackPoison)
			{
				cmd.addAbnormalStateEffect(EnumAbnormalStates.Poison, rate, power);
			}
			if (EffectType == EnumSkillEffectTypes.AbnormalStateAttackConflict)
			{
				cmd.addAbnormalStateEffect(EnumAbnormalStates.Conflict, rate, power);
			}
			if (EffectType == EnumSkillEffectTypes.AbnormalStateAttackStun)
			{
				cmd.addAbnormalStateEffect(EnumAbnormalStates.Stun, rate, power);
			}
			if (EffectType == EnumSkillEffectTypes.AbnormalStateAttackSlow)
			{
				cmd.addAbnormalStateEffect(EnumAbnormalStates.Slow, rate, power);
			}
			if (EffectType == EnumSkillEffectTypes.AbnormalStateAttackBlind)
			{
				cmd.addAbnormalStateEffect(EnumAbnormalStates.Blind, rate, power);
			}
			if (EffectType == EnumSkillEffectTypes.AbnormalStateAttackBurn)
			{
				cmd.addAbnormalStateEffect(EnumAbnormalStates.Burn, rate, power);
			}
			if (EffectType == EnumSkillEffectTypes.AbnormalStateAttackFreeze)
			{
				cmd.addAbnormalStateEffect(EnumAbnormalStates.Freeze, rate, power);
			}
		}
	}

	public void effectChangingRace(PlayerControl pl)
	{
		if (!(pl == null) && EffectType == EnumSkillEffectTypes.CureAbnormalStateWhenChange)
		{
			PlayerAbnormalStateControl abnormalStateControl = pl.AbnormalStateControl;
			if (abnormalStateControl != null && randomSuccess())
			{
				abnormalStateControl.disableTopState();
			}
		}
	}
}
