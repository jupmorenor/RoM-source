using System;
using System.Text;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class DamageCalcV3 : DamageCalc
{
	private float actionMult;

	private YarareTypes actionYarare;

	private float actionBreakPow;

	private float actionCriticalRate;

	private bool usingWeaponSkill;

	private RespPoppet usingChainSkill;

	private float useChainPoppetAttack;

	private RespWeapon attackOriginWeapon;

	private EnumElements attackOriginElement;

	private IDamageCalcCharData attackerData => AttackerControl.DamageCalcCharData;

	private IDamageCalcCharData defenserData => DefenserControl.DamageCalcCharData;

	private PlayerSkillEffectControl attackerSkEffCntr => AttackerControl.SkillEffectControl;

	private PlayerSkillEffectControl defenserSkEffCntr => DefenserControl.SkillEffectControl;

	private SkillEffectData defenserSkEffData => DefenserControl.SkillEffect;

	public float ActionMult
	{
		get
		{
			return actionMult;
		}
		set
		{
			actionMult = value;
		}
	}

	public YarareTypes ActionYarare
	{
		get
		{
			return actionYarare;
		}
		set
		{
			actionYarare = value;
		}
	}

	public float ActionBreakPow
	{
		get
		{
			return actionBreakPow;
		}
		set
		{
			actionBreakPow = value;
		}
	}

	public float ActionCriticalRate
	{
		get
		{
			return actionCriticalRate;
		}
		set
		{
			actionCriticalRate = value;
		}
	}

	public bool UsingWeaponSkill
	{
		get
		{
			return usingWeaponSkill;
		}
		set
		{
			usingWeaponSkill = value;
		}
	}

	public RespPoppet UsingChainSkill
	{
		get
		{
			return usingChainSkill;
		}
		set
		{
			usingChainSkill = value;
		}
	}

	public float UseChainPoppetAttack
	{
		get
		{
			return useChainPoppetAttack;
		}
		set
		{
			useChainPoppetAttack = value;
		}
	}

	public RespWeapon AttackOriginWeapon
	{
		get
		{
			return attackOriginWeapon;
		}
		set
		{
			attackOriginWeapon = value;
		}
	}

	public EnumElements AttackOriginElement
	{
		get
		{
			return attackOriginElement;
		}
		set
		{
			attackOriginElement = value;
		}
	}

	public DamageCalcV3()
	{
		actionCriticalRate = 1f;
	}

	protected override void doCalc()
	{
		attackerCriticalCheck();
		guardCheck();
		float num = 0f;
		num = ((usingChainSkill == null) ? DamageCalc.val("D-攻撃力総合", attackerAttack()) : chainSkillAttack(usingChainSkill.ChainSkill));
		num *= DamageCalc.val("D-状態異常攻撃力倍率", attackerAbnormalStateAttackMult());
		float num2 = 0f;
		num2 = ((!GuardCancel) ? DamageCalc.val("D-防御力総合", defenserAdjustedDefense()) : DamageCalc.val("D-防御力総合(無効)", 0f));
		float num3 = DamageCalc.val("D-ダメージ乗算補正", attackerSkillDamageMult(GuardOk));
		float num4 = DamageCalc.val("D-ダメージ加算補正", attackerSkillDamagePlus());
		float num5 = DamageCalc.val("D-レイド攻撃力乗算補正", raidBonusMult());
		outDamage = (num * num5 - num2 + num4) * num3;
		outDamage *= DamageCalc.val("D-状態異常ダメージ倍率", defenserAbnormalStateDamageMult());
		outDamage = DamageCalc.val(new StringBuilder("D-スキルダメージ補正値 ").Append(outDamage).Append(" -> ").ToString(), defenserSkillDamageAdjustment(outDamage));
		if (defenserNeedsQuestPoppetRevice())
		{
			float num6 = DamageCalc.val("D-クエスト魔ペットダメージ補正", 0.2f);
			outDamage *= num6;
		}
		if (defenserNeedsColosseumPoppetRevice())
		{
			float num7 = DamageCalc.val("D-闘技場魔ペットダメージ補正", 0.2f);
			outDamage *= num7;
		}
		float num8 = Mathf.Max(1f, attackerMinimumDamageBySkill());
		float num9 = defenserMaximumDamage();
		if (!(num8 <= num9))
		{
			num8 = num9;
		}
		DamageCalc.val("D-最小/最大ダメージ", new StringBuilder().Append(num8).Append("/").Append(num9)
			.ToString());
		outDamage = DamageCalc.val("D-最終ダメージ", Mathf.Clamp(outDamage, num8, num9));
		defenserYorokeCheck();
		attackerInvalidateSuperArmorCheck();
		dodgeActionCheck();
		dodgeHealCheck(GuardOk);
		float num10 = attackerHpRevoveryWhenAttackHit();
		if (!(num10 <= 0f))
		{
			DamageCalc.val("C-HP回復", num10);
		}
		string text = DamageCalc.flushLog(new StringBuilder("**** ダメージ計算結果 ").Append(outDamage).Append("：").Append(AttackerControl.gameObject.name)
			.Append(") -> ")
			.Append(DefenserControl.gameObject.name)
			.Append("\n")
			.ToString());
	}

	public override void doHit(bool isKilled, bool isCorpse)
	{
		if (!isCorpse)
		{
			attackerSkEffCntr.applyHitEffectToAttacker(AttackerControl, outCriticalOk, defenserElement(), isKilled);
		}
	}

	private bool attackerIsTensi()
	{
		return attackerData.isTensi();
	}

	private bool attackerIsAkuma()
	{
		return attackerData.isAkuma();
	}

	private float attackerHitPointRate()
	{
		return attackerData.hitPointRate();
	}

	private float attackerMaxHitPoint()
	{
		return attackerData.maxHitPoint();
	}

	private MElements attackerElement()
	{
		return MElements.Get((int)attackerElementEnum());
	}

	private EnumElements attackerElementEnum()
	{
		return (attackOriginElement > (EnumElements)0) ? attackOriginElement : ((!attackerData.isPlayer() || attackOriginWeapon == null) ? attackerData.elementEnum() : ((EnumElements)attackOriginWeapon.ElementId));
	}

	private float attackerCritical()
	{
		return (!attackerData.isPlayer() || attackOriginWeapon == null) ? attackerData.critical() : ((float)attackOriginWeapon.Critical);
	}

	private float attackerBreakPow()
	{
		return (!attackerData.isPlayer() || attackOriginWeapon == null) ? attackerData.breakPow() : ((float)attackOriginWeapon.BreakPow);
	}

	private MStyles attackerStyle()
	{
		return MStyles.Get((int)attackerStyleEnum());
	}

	private EnumStyles attackerStyleEnum()
	{
		return (attackOriginWeapon == null) ? attackerData.styleEnum() : ((EnumStyles)attackOriginWeapon.StyleId);
	}

	private MElements defenserElement()
	{
		return defenserData.element();
	}

	private EnumElements defenserElementEnum()
	{
		return defenserData.elementEnum();
	}

	private MStyles defenserStyle()
	{
		return defenserData.style();
	}

	private EnumStyles defenserStyleEnum()
	{
		return defenserData.styleEnum();
	}

	private EnumRaces defenserRace()
	{
		return defenserData.race();
	}

	private float defenserResist()
	{
		return defenserData.resist();
	}

	private float defenserDefense()
	{
		return defenserData.defense();
	}

	private EnumStyles defenserWeakStyle()
	{
		return defenserData.weakStyle();
	}

	private float defenserHitPointRate()
	{
		return defenserData.hitPointRate();
	}

	private float defenserHitPoint()
	{
		return defenserData.hitPoint();
	}

	private float defenserMaxHitPoint()
	{
		return defenserData.maxHitPoint();
	}

	private float defenserSkillResist()
	{
		return defenserSkEffCntr.yarareResistPlus();
	}

	private bool defenserIsPlayer()
	{
		return defenserData.isPlayer();
	}

	private bool defenserIsInJustDodge()
	{
		return defenserData.isInJustDodge();
	}

	private bool defenserNeedsQuestPoppetRevice()
	{
		return defenserData.needQuestPoppetRevice();
	}

	private bool defenserNeedsColosseumPoppetRevice()
	{
		return defenserData.needColosseumPoppetRevice();
	}

	private bool defenserIsGuarding()
	{
		return defenserData.isGuarding();
	}

	private bool defenserIsElite()
	{
		return defenserData.isElite();
	}

	private bool defenserIsDead()
	{
		return defenserData.isDead();
	}

	private void attackerCriticalCheck()
	{
		float num = 0f;
		num += DamageCalc.val("C-武器クリティカル", DamageCalc.ToRate(attackerCritical()));
		num *= DamageCalc.val("C-スキルクリティカル乗算", attackerSkEffCntr.criticalRateMult(attackerHitPointRate(), attackerIsTensi(), attackerIsAkuma()));
		num *= DamageCalc.val("C-アクションクリティカル率", actionCriticalRate);
		num = DamageCalc.val("C-(連携)スキルクリティカル率強制設定", attackerSkEffCntr.maximumChainCriticalRate(num));
		DamageCalc.val("C-総合クリティカル発生率", num);
		outCriticalOk = DamageCalc.val("C-クリティカル発生", num > UnityEngine.Random.value);
		if (GameParameter.alwaysCritical)
		{
			outCriticalOk = DamageCalc.val("C-debugmode-critical-設定", b: true);
		}
	}

	private void attackerInvalidateSuperArmorCheck()
	{
		float num = DamageCalc.val("SA-super armor無効化率", 1f - attackerSkEffCntr.notInvalidateSuperArmor());
		outInvalidateSuperArmor = DamageCalc.val("SA-super armor無効:", !(UnityEngine.Random.value > num));
	}

	private void defenserYorokeCheck()
	{
		DamageCalc.val("Y-アクションやられ", ActionYarare.ToString());
		float num = default(float);
		num = DamageCalc.val("Y-武器崩し力", attackerBreakPow());
		num *= DamageCalc.val("Y-アクション崩し力補正", ActionBreakPow);
		float num2 = DamageCalc.val("Y-崩し属性補正", Mathf.Min(1f, DamageCalc.ElementalMult(attackerElementEnum(), defenserElementEnum())));
		float num3 = DamageCalc.val("Y-崩しクリティカル補正", (!outCriticalOk) ? 1f : 1.5f);
		float num4 = DamageCalc.val("Y-崩し乱数ベース", num + 100f * num2 * num3 - 100f);
		float num5 = default(float);
		num5 = DamageCalc.val("Y-基礎ふんばり力", defenserResist());
		num5 += DamageCalc.val("Y-スキルふんばり力", defenserSkillResist());
		int num6 = UnityEngine.Random.Range(Mathf.Clamp(checked((int)num4), 0, 100), 100);
		DamageCalc.val("Y-崩し乱数結果", num6);
		if (!((float)num6 < num5))
		{
			outYarareType = ActionYarare;
		}
		else
		{
			outYarareType = YarareTypes.None;
		}
		DamageCalc.val("Y-よろけ結果(中間)", outYarareType.ToString());
		if (defenserIsPlayer() && outYarareType == YarareTypes.Weak)
		{
			int num7 = UnityEngine.Random.Range(0, 100);
			int num8 = 20;
			DamageCalc.val(new StringBuilder("Y-弱->ダウン変換(").Append((object)num8).Append("未満でダウン)").ToString(), num7);
			if (num7 < num8)
			{
				outYarareType = YarareTypes.Down;
			}
		}
		if (outYarareType == YarareTypes.Down)
		{
			float num9 = DamageCalc.val("YD-援護スキルダウンしない率", 1f - defenserSkEffCntr.downRate());
			if (DamageCalc.val("YD-援護スキルでダウンしない", !(UnityEngine.Random.value > num9)))
			{
				outYarareType = YarareTypes.Weak;
			}
		}
		if (outYarareType != YarareTypes.None)
		{
			float num10 = DamageCalc.val("YS-やられ無し率", 1f - defenserSkEffCntr.yarareRate(UsingWeaponSkill));
			if (DamageCalc.val("YS-やられ無し", !(UnityEngine.Random.value > num10)))
			{
				outYarareType = YarareTypes.None;
				outAntiInvalidateSuperArmor = true;
			}
		}
	}

	private void guardCheck()
	{
		bool flag = false;
		if (GameParameter.alwaysGuard)
		{
			flag = true;
		}
		else if (defenserIsGuarding())
		{
			flag = true;
		}
		else if (defenserSkEffData.fullGuard)
		{
			flag = true;
		}
		else
		{
			float num = DamageCalc.val("G-援護スキルガード率", 1f - defenserSkEffCntr.unguardRate(attackerElement(), defenserStyle()));
			flag = UnityEngine.Random.value < num;
		}
		outGuardOk = DamageCalc.val("G-ガードOK", flag);
	}

	private void dodgeActionCheck()
	{
		outIsSucceededDodgeAction = DamageCalc.val("DG-ドッジアクション", defenserIsInJustDodge());
	}

	private void dodgeHealCheck(bool isGuarded)
	{
		float num = DamageCalc.val("J-回避回復率", 1f - defenserSkEffCntr.undodgeHeal(defenserStyle(), defenserElement(), isGuarded));
		outDodgeHealOk = DamageCalc.val("J-回避回復OK", UnityEngine.Random.value < num);
	}

	private float attackerAttack()
	{
		float num = 0f;
		num += DamageCalc.val("A1-基礎攻撃力", attackerData.attack());
		float num2 = attackerSkEffCntr.attackPlus(attackerData.hasAbnormalState(), attackerStyle(), attackerElement());
		EnumElements atkElem = attackerData.elementWeapon1();
		EnumElements atkElem2 = attackerData.elementWeapon2();
		num2 += attackerSkEffCntr.attackPlusBy2Weapons(atkElem, atkElem2);
		float v = attackerSkEffCntr.attackMult(attackerData.hasAbnormalState(), attackerStyle());
		num += DamageCalc.val("A1-武器/魔ペット援護スキル攻撃力加算", num2);
		num *= DamageCalc.val("A1-武器/魔ペット援護スキル攻撃力乗算", v);
		DamageCalc.val("A1-結果", num);
		float num3 = num;
		num3 *= DamageCalc.val("A2-アクション補正", actionMult);
		if (!defenserIsPlayer())
		{
			num3 *= DamageCalc.val("A2-属性補正", DamageCalc.ElementalMult(attackerElementEnum(), defenserElementEnum()));
		}
		num3 *= DamageCalc.val("A2-弱点武器補正", weakStyleAttackMult());
		if (outCriticalOk)
		{
			num3 *= DamageCalc.val("A2-クリティカル攻撃力倍率", 2f);
		}
		DamageCalc.val("A2-結果", num3);
		float num4 = num3;
		float v2 = defenserSkEffCntr.defenseMult(DefenserControl, attackerElementEnum(), GuardOk, defenserHitPointRate());
		num4 *= DamageCalc.val(new StringBuilder("A3-防御側武器/魔ペット防御補正(guard ").Append(GuardOk).Append(")").ToString(), v2);
		DamageCalc.val("A3-結果", num4);
		return num4;
	}

	private float attackerAbnormalStateAttackMult()
	{
		return AttackerAbsp.attack;
	}

	private float defenserAdjustedDefense()
	{
		float num = DamageCalc.val("D-モンスター防御力", defenserDefense());
		return num * attackerSkEffCntr.enemyDefenseMult();
	}

	private float attackerMinimumDamageBySkill()
	{
		return attackerSkEffCntr.attackMinimumDamage();
	}

	private float attackerSkillDamagePlus()
	{
		return attackerSkEffCntr.attackDamageAdd(attackerMaxHitPoint());
	}

	private float attackerSkillDamageMult(bool isGuarding)
	{
		float num = 1f;
		float v = attackerSkEffCntr.attackDamageMult(AttackerControl, defenserElementEnum(), defenserRace(), isGuarding, defenserIsElite(), outCriticalOk, DefenserControl);
		return num * DamageCalc.val("D-武器/魔ペット援護スキルダメージ倍率", v);
	}

	private float defenserAbnormalStateDamageMult()
	{
		return DefenserAbsp.damage;
	}

	private float attackerHpRevoveryWhenAttackHit()
	{
		return (!defenserIsDead()) ? attackerSkEffCntr.attackHitHpRecovery(AttackerControl, outCriticalOk) : 0f;
	}

	private float defenserSkillDamageAdjustment(float damage)
	{
		float num = defenserSkEffCntr.finalDamageAdjust(damage, defenserHitPoint());
		damage = ((num == damage) ? Mathf.Max(1f, damage) : num);
		return damage;
	}

	private float defenserMaximumDamage()
	{
		return defenserSkEffCntr.maximumDamage(defenserMaxHitPoint());
	}

	private float weakStyleAttackMult()
	{
		EnumStyles weaponStyle = attackerStyleEnum();
		EnumStyles monsterWeak = defenserWeakStyle();
		return DamageCalc.WeakStyleAttackMult(weaponStyle, monsterWeak);
	}

	private float raidBonusMult()
	{
		PlayerRaidData raidBonusData = attackerData.getRaidBonusData();
		float result;
		if (raidBonusData == null || !raidBonusData.isRaid)
		{
			result = 1f;
		}
		else
		{
			float num = 1f;
			bool flag = IsSameStyle(attackerStyleEnum(), raidBonusData.bonusWeaponStyle);
			bool flag2 = attackerElement().Id == (int)raidBonusData.bonusWeaponElement;
			if (flag && flag2)
			{
				num *= 6f;
			}
			else if (flag)
			{
				num *= 2f;
			}
			else if (flag2)
			{
				num *= 2f;
			}
			num *= raidBonusData.comboBonus;
			result = num;
		}
		return result;
	}

	private float chainSkillAttack(MChainSkills chsk)
	{
		float num = 0f;
		if (chsk != null)
		{
			if (!(useChainPoppetAttack > 0f))
			{
				num = DamageCalc.val(new StringBuilder("D-攻撃力(連携:").Append((object)chsk.Id).Append(":").Append(chsk.Name)
					.Append(")")
					.ToString(), chsk.PowerBase);
			}
			else
			{
				float totalAttack = UsingChainSkill.TotalAttack;
				float num2 = useChainPoppetAttack;
				num = DamageCalc.val(new StringBuilder("D-連携攻撃力(魔ペット攻撃力").Append(totalAttack).Append("×連携倍率").Append(useChainPoppetAttack)
					.ToString(), totalAttack * useChainPoppetAttack);
			}
			if (!(num > 0f))
			{
			}
			num *= DamageCalc.val("D-連携属性補正", DamageCalc.ElementalMult((EnumElements)usingChainSkill.Element.Id, defenserElementEnum()));
			DamageCalc.val("D-攻撃力総合", num);
		}
		else
		{
			num = DamageCalc.val("D-攻撃力総合(連携情報不明)", 10f);
		}
		return num;
	}

	private static bool IsSameStyle(EnumStyles a, EnumStyles b)
	{
		return a != 0 && b != 0 && a == b;
	}
}
