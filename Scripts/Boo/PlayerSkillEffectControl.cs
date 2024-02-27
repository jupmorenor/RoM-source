using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class PlayerSkillEffectControl
{
	[Serializable]
	internal class _0024criticalRateMult_0024locals_002414361
	{
		internal float _0024attackerHitPointRate;

		internal bool _0024attackerIsTensi;

		internal bool _0024attackerIsAkuma;
	}

	[Serializable]
	internal class _0024attackMult_0024locals_002414362
	{
		internal bool _0024attackerHasAnyAbnormalState;

		internal MStyles _0024attackStyle;
	}

	[Serializable]
	internal class _0024attackPlus_0024locals_002414363
	{
		internal bool _0024attackerHasAnyAbnormalState;

		internal MStyles _0024attackStyle;

		internal MElements _0024attackElement;
	}

	[Serializable]
	internal class _0024attackPlusBy2Weapons_0024locals_002414364
	{
		internal EnumElements _0024atkElem1;

		internal EnumElements _0024atkElem2;
	}

	[Serializable]
	internal class _0024attackDamageMult_0024locals_002414365
	{
		internal MerlinActionControl _0024attacker;

		internal EnumElements _0024enElm;

		internal EnumRaces _0024enRace;

		internal bool _0024enGuard;

		internal bool _0024enElite;

		internal bool _0024isCritical;

		internal MerlinActionControl _0024dfcCont;
	}

	[Serializable]
	internal class _0024attackDamageAdd_0024locals_002414366
	{
		internal float _0024attackerMaxHitPoint;
	}

	[Serializable]
	internal class _0024defenseMult_0024locals_002414367
	{
		internal MerlinActionControl _0024defenser;

		internal EnumElements _0024attackerElement;

		internal bool _0024defenserIsGuarding;

		internal float _0024defenserHitPointRate;
	}

	[Serializable]
	internal class _0024unguardRate_0024locals_002414368
	{
		internal MElements _0024attackerElement;

		internal MStyles _0024defenserStyle;
	}

	[Serializable]
	internal class _0024undodgeHeal_0024locals_002414369
	{
		internal MStyles _0024defenserStyle;

		internal MElements _0024defenserElement;

		internal bool _0024defenserIsGuarding;
	}

	[Serializable]
	internal class _0024attackHitHpRecovery_0024locals_002414370
	{
		internal MerlinActionControl _0024attacker;

		internal bool _0024isCritical;
	}

	[Serializable]
	internal class _0024yarareRate_0024locals_002414371
	{
		internal bool _0024usingSkill;
	}

	[Serializable]
	internal class _0024criticalRateMult_0024closure_00243854
	{
		internal _0024criticalRateMult_0024locals_002414361 _0024_0024locals_002414841;

		public _0024criticalRateMult_0024closure_00243854(_0024criticalRateMult_0024locals_002414361 _0024_0024locals_002414841)
		{
			this._0024_0024locals_002414841 = _0024_0024locals_002414841;
		}

		public float Invoke(SkillEffector cs)
		{
			return cs.criticalRateMult(_0024_0024locals_002414841._0024attackerHitPointRate, _0024_0024locals_002414841._0024attackerIsTensi, _0024_0024locals_002414841._0024attackerIsAkuma);
		}
	}

	[Serializable]
	internal class _0024attackMult_0024closure_00243856
	{
		internal _0024attackMult_0024locals_002414362 _0024_0024locals_002414842;

		public _0024attackMult_0024closure_00243856(_0024attackMult_0024locals_002414362 _0024_0024locals_002414842)
		{
			this._0024_0024locals_002414842 = _0024_0024locals_002414842;
		}

		public float Invoke(SkillEffector cs)
		{
			return cs.attackMult(_0024_0024locals_002414842._0024attackerHasAnyAbnormalState, _0024_0024locals_002414842._0024attackStyle);
		}
	}

	[Serializable]
	internal class _0024attackPlus_0024closure_00243857
	{
		internal _0024attackPlus_0024locals_002414363 _0024_0024locals_002414843;

		public _0024attackPlus_0024closure_00243857(_0024attackPlus_0024locals_002414363 _0024_0024locals_002414843)
		{
			this._0024_0024locals_002414843 = _0024_0024locals_002414843;
		}

		public float Invoke(SkillEffector cs)
		{
			return cs.attackPlus(_0024_0024locals_002414843._0024attackerHasAnyAbnormalState, _0024_0024locals_002414843._0024attackStyle, _0024_0024locals_002414843._0024attackElement);
		}
	}

	[Serializable]
	internal class _0024attackPlusBy2Weapons_0024closure_00243858
	{
		internal _0024attackPlusBy2Weapons_0024locals_002414364 _0024_0024locals_002414844;

		public _0024attackPlusBy2Weapons_0024closure_00243858(_0024attackPlusBy2Weapons_0024locals_002414364 _0024_0024locals_002414844)
		{
			this._0024_0024locals_002414844 = _0024_0024locals_002414844;
		}

		public float Invoke(SkillEffector cs)
		{
			return cs.attackPlusBy2Weapons(_0024_0024locals_002414844._0024atkElem1, _0024_0024locals_002414844._0024atkElem2);
		}
	}

	[Serializable]
	internal class _0024attackDamageMult_0024closure_00243859
	{
		internal _0024attackDamageMult_0024locals_002414365 _0024_0024locals_002414845;

		public _0024attackDamageMult_0024closure_00243859(_0024attackDamageMult_0024locals_002414365 _0024_0024locals_002414845)
		{
			this._0024_0024locals_002414845 = _0024_0024locals_002414845;
		}

		public float Invoke(SkillEffector cs)
		{
			return cs.attackDamageMult(_0024_0024locals_002414845._0024attacker, _0024_0024locals_002414845._0024enElm, _0024_0024locals_002414845._0024enRace, _0024_0024locals_002414845._0024enGuard, _0024_0024locals_002414845._0024enElite, _0024_0024locals_002414845._0024isCritical, _0024_0024locals_002414845._0024dfcCont);
		}
	}

	[Serializable]
	internal class _0024attackDamageAdd_0024closure_00243860
	{
		internal _0024attackDamageAdd_0024locals_002414366 _0024_0024locals_002414846;

		public _0024attackDamageAdd_0024closure_00243860(_0024attackDamageAdd_0024locals_002414366 _0024_0024locals_002414846)
		{
			this._0024_0024locals_002414846 = _0024_0024locals_002414846;
		}

		public float Invoke(SkillEffector cs)
		{
			return cs.attackDamageAdd(_0024_0024locals_002414846._0024attackerMaxHitPoint);
		}
	}

	[Serializable]
	internal class _0024defenseMult_0024closure_00243861
	{
		internal _0024defenseMult_0024locals_002414367 _0024_0024locals_002414847;

		public _0024defenseMult_0024closure_00243861(_0024defenseMult_0024locals_002414367 _0024_0024locals_002414847)
		{
			this._0024_0024locals_002414847 = _0024_0024locals_002414847;
		}

		public float Invoke(SkillEffector cs)
		{
			return cs.defenseMult(_0024_0024locals_002414847._0024defenser, _0024_0024locals_002414847._0024attackerElement, _0024_0024locals_002414847._0024defenserIsGuarding, _0024_0024locals_002414847._0024defenserHitPointRate);
		}
	}

	[Serializable]
	internal class _0024unguardRate_0024closure_00243863
	{
		internal _0024unguardRate_0024locals_002414368 _0024_0024locals_002414848;

		public _0024unguardRate_0024closure_00243863(_0024unguardRate_0024locals_002414368 _0024_0024locals_002414848)
		{
			this._0024_0024locals_002414848 = _0024_0024locals_002414848;
		}

		public float Invoke(SkillEffector cs)
		{
			return cs.unguardRate(_0024_0024locals_002414848._0024attackerElement, _0024_0024locals_002414848._0024defenserStyle);
		}
	}

	[Serializable]
	internal class _0024undodgeHeal_0024closure_00243864
	{
		internal _0024undodgeHeal_0024locals_002414369 _0024_0024locals_002414849;

		public _0024undodgeHeal_0024closure_00243864(_0024undodgeHeal_0024locals_002414369 _0024_0024locals_002414849)
		{
			this._0024_0024locals_002414849 = _0024_0024locals_002414849;
		}

		public float Invoke(SkillEffector cs)
		{
			return cs.undodgeHeal(_0024_0024locals_002414849._0024defenserStyle, _0024_0024locals_002414849._0024defenserElement, _0024_0024locals_002414849._0024defenserIsGuarding);
		}
	}

	[Serializable]
	internal class _0024attackHitHpRecovery_0024closure_00243867
	{
		internal _0024attackHitHpRecovery_0024locals_002414370 _0024_0024locals_002414850;

		public _0024attackHitHpRecovery_0024closure_00243867(_0024attackHitHpRecovery_0024locals_002414370 _0024_0024locals_002414850)
		{
			this._0024_0024locals_002414850 = _0024_0024locals_002414850;
		}

		public float Invoke(SkillEffector cs)
		{
			return cs.attackHitHpRecovery(_0024_0024locals_002414850._0024attacker, _0024_0024locals_002414850._0024isCritical);
		}
	}

	[Serializable]
	internal class _0024yarareRate_0024closure_00243868
	{
		internal _0024yarareRate_0024locals_002414371 _0024_0024locals_002414851;

		public _0024yarareRate_0024closure_00243868(_0024yarareRate_0024locals_002414371 _0024_0024locals_002414851)
		{
			this._0024_0024locals_002414851 = _0024_0024locals_002414851;
		}

		public float Invoke(SkillEffector cs)
		{
			return cs.yarareRate(_0024_0024locals_002414851._0024usingSkill);
		}
	}

	private SkillEffectData currentData;

	private MerlinActionControl parent;

	private PlayerControl player;

	private RespWeapon[] weapons;

	private Boo.Lang.List<RespPoppet> poppets;

	private Boo.Lang.List<SkillEffector> allSkills;

	private bool needInitialize;

	public SkillEffectData CurrentData => currentData;

	public Boo.Lang.List<SkillEffector> AllSkills => allSkills;

	public PlayerSkillEffectControl()
	{
		currentData = new SkillEffectData();
		weapons = new RespWeapon[0];
		poppets = new Boo.Lang.List<RespPoppet>();
		allSkills = new Boo.Lang.List<SkillEffector>();
		needInitialize = true;
	}

	public void setParent(MerlinActionControl ch)
	{
		parent = ch;
		player = ch as PlayerControl;
		needInitialize = true;
	}

	public void setWeapons(RespWeapon[] mainWeapons)
	{
		if (!(mainWeapons == null))
		{
			setWeaponsWithoutSkills(mainWeapons);
			initialize();
		}
	}

	public void setPoppets(AIControl[] ais)
	{
		Boo.Lang.List<RespPoppet> list = new Boo.Lang.List<RespPoppet>();
		int i = 0;
		for (int length = ais.Length; i < length; i = checked(i + 1))
		{
			if (ais[i] != null)
			{
				list.Add(ais[i].PoppetData);
			}
		}
		setPoppets((RespPoppet[])Builtins.array(typeof(RespPoppet), list));
	}

	public void setPoppets(RespPoppet[] ppts)
	{
		poppets.Clear();
		if (ppts != null)
		{
			int i = 0;
			for (int length = ppts.Length; i < length; i = checked(i + 1))
			{
				poppets.Add(ppts[i]);
			}
		}
		initialize();
	}

	public void setWeaponsWithoutSkills(RespWeapon[] wpns)
	{
		Boo.Lang.List<RespWeapon> list = new Boo.Lang.List<RespWeapon>();
		int i = 0;
		for (int length = wpns.Length; i < length; i = checked(i + 1))
		{
			if (wpns[i] != null)
			{
				list.Add(wpns[i]);
			}
		}
		weapons = (RespWeapon[])Builtins.array(typeof(RespWeapon), list);
	}

	public void update(float dt)
	{
		if (needInitialize)
		{
			initialize();
		}
		updateParametersAndDeleteExpires(dt);
	}

	public void initialize()
	{
		needInitialize = false;
		allSkills.Clear();
		int i = 0;
		RespWeapon[] array = weapons;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			SkillEffector skillEffector = SkillEffector.WeaponCoverSkill(array[i]);
			if (skillEffector != null)
			{
				allSkills.Add(skillEffector);
			}
		}
		IEnumerator<RespPoppet> enumerator = poppets.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				RespPoppet current = enumerator.Current;
				if (!isEffectivePoppet(current))
				{
					continue;
				}
				IEnumerator enumerator2 = SkillEffector.PoppetCoverSkills(current).GetEnumerator();
				while (enumerator2.MoveNext())
				{
					object obj = enumerator2.Current;
					if (!(obj is SkillEffector))
					{
						obj = RuntimeServices.Coerce(obj, typeof(SkillEffector));
					}
					SkillEffector skillEffector = (SkillEffector)obj;
					if (skillEffector != null)
					{
						allSkills.Add(skillEffector);
					}
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		updateParametersAndDeleteExpires(0f);
	}

	public void addSkillEffector(SkillEffector skeff)
	{
		if (skeff != null && !allSkills.Contains(skeff))
		{
			allSkills.Add(skeff);
			updateParametersAndDeleteExpires(0f);
		}
	}

	private bool isEffectivePoppet(RespPoppet p)
	{
		return true;
	}

	public SkillEffector createChainSkill(RespPoppet poppet)
	{
		SkillEffector skillEffector = SkillEffector.PoppetChainSkill(poppet);
		if (skillEffector != null)
		{
			allSkills.Add(skillEffector);
		}
		return skillEffector;
	}

	public SkillEffector createForDebug(SkillEffectParameters ske, int level, int levelMax, float powerBase, float expirationTime)
	{
		SkillEffector skillEffector = SkillEffector.CreateForDebug(ske, level, levelMax, powerBase, expirationTime);
		allSkills.Add(skillEffector);
		return skillEffector;
	}

	private void updateParametersAndDeleteExpires(float dt)
	{
		currentData.setDefault();
		IEnumerator<SkillEffector> enumerator = allSkills.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				SkillEffector current = enumerator.Current;
				current.update(dt);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		recalcAllSkillEffection(currentData);
		if (player != null)
		{
			CooldownValue weaponSkillCooldown = player.WeaponSkillCooldown;
			if (weaponSkillCooldown != null)
			{
				weaponSkillCooldown.DecreaseScale = currentData.skillCoolDownRate;
			}
		}
		if (player != null)
		{
			CooldownValue changeCooldown = player.ChangeCooldown;
			if (changeCooldown != null)
			{
				float b = 12f - currentData.changeCoolDownDecTime;
				changeCooldown.HeatTime = Mathf.Max(1f, b);
			}
		}
		parent.MoveCommandSpeedScale = currentData.moveCommandSpeedMult;
		allSkills.RemoveAll(_0024adaptor_0024__PlayerSkillEffectControl_0024callable337_0024158_30___0024Predicate_0024137.Adapt((SkillEffector se) => se.IsExpired));
	}

	public void recalcAllSkillEffection()
	{
		recalcAllSkillEffection(currentData);
	}

	private void recalcAllSkillEffection(SkillEffectData cd)
	{
		cd.setDefault();
		IEnumerator<SkillEffector> enumerator = allSkills.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				SkillEffector current = enumerator.Current;
				current.calcSkillEffectData(cd, parent, weapons);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public float criticalRateMult(float attackerHitPointRate, bool attackerIsTensi, bool attackerIsAkuma)
	{
		_0024criticalRateMult_0024locals_002414361 _0024criticalRateMult_0024locals_0024 = new _0024criticalRateMult_0024locals_002414361();
		_0024criticalRateMult_0024locals_0024._0024attackerHitPointRate = attackerHitPointRate;
		_0024criticalRateMult_0024locals_0024._0024attackerIsTensi = attackerIsTensi;
		_0024criticalRateMult_0024locals_0024._0024attackerIsAkuma = attackerIsAkuma;
		return product(new _0024criticalRateMult_0024closure_00243854(_0024criticalRateMult_0024locals_0024).Invoke);
	}

	public float maximumChainCriticalRate(float minValue)
	{
		return maximum((SkillEffector cs) => cs.maximumChainCriticalRate(), minValue);
	}

	public float attackMult(bool attackerHasAnyAbnormalState, MStyles attackStyle)
	{
		_0024attackMult_0024locals_002414362 _0024attackMult_0024locals_0024 = new _0024attackMult_0024locals_002414362();
		_0024attackMult_0024locals_0024._0024attackerHasAnyAbnormalState = attackerHasAnyAbnormalState;
		_0024attackMult_0024locals_0024._0024attackStyle = attackStyle;
		return product(new _0024attackMult_0024closure_00243856(_0024attackMult_0024locals_0024).Invoke);
	}

	public float attackPlus(bool attackerHasAnyAbnormalState, MStyles attackStyle, MElements attackElement)
	{
		_0024attackPlus_0024locals_002414363 _0024attackPlus_0024locals_0024 = new _0024attackPlus_0024locals_002414363();
		_0024attackPlus_0024locals_0024._0024attackerHasAnyAbnormalState = attackerHasAnyAbnormalState;
		_0024attackPlus_0024locals_0024._0024attackStyle = attackStyle;
		_0024attackPlus_0024locals_0024._0024attackElement = attackElement;
		return sum(new _0024attackPlus_0024closure_00243857(_0024attackPlus_0024locals_0024).Invoke);
	}

	public float attackPlusBy2Weapons(EnumElements atkElem1, EnumElements atkElem2)
	{
		_0024attackPlusBy2Weapons_0024locals_002414364 _0024attackPlusBy2Weapons_0024locals_0024 = new _0024attackPlusBy2Weapons_0024locals_002414364();
		_0024attackPlusBy2Weapons_0024locals_0024._0024atkElem1 = atkElem1;
		_0024attackPlusBy2Weapons_0024locals_0024._0024atkElem2 = atkElem2;
		return sum(new _0024attackPlusBy2Weapons_0024closure_00243858(_0024attackPlusBy2Weapons_0024locals_0024).Invoke);
	}

	public float attackDamageMult(MerlinActionControl attacker, EnumElements enElm, EnumRaces enRace, bool enGuard, bool enElite, bool isCritical, MerlinActionControl dfcCont)
	{
		_0024attackDamageMult_0024locals_002414365 _0024attackDamageMult_0024locals_0024 = new _0024attackDamageMult_0024locals_002414365();
		_0024attackDamageMult_0024locals_0024._0024attacker = attacker;
		_0024attackDamageMult_0024locals_0024._0024enElm = enElm;
		_0024attackDamageMult_0024locals_0024._0024enRace = enRace;
		_0024attackDamageMult_0024locals_0024._0024enGuard = enGuard;
		_0024attackDamageMult_0024locals_0024._0024enElite = enElite;
		_0024attackDamageMult_0024locals_0024._0024isCritical = isCritical;
		_0024attackDamageMult_0024locals_0024._0024dfcCont = dfcCont;
		return product(new _0024attackDamageMult_0024closure_00243859(_0024attackDamageMult_0024locals_0024).Invoke);
	}

	public float attackDamageAdd(float attackerMaxHitPoint)
	{
		_0024attackDamageAdd_0024locals_002414366 _0024attackDamageAdd_0024locals_0024 = new _0024attackDamageAdd_0024locals_002414366();
		_0024attackDamageAdd_0024locals_0024._0024attackerMaxHitPoint = attackerMaxHitPoint;
		return sum(new _0024attackDamageAdd_0024closure_00243860(_0024attackDamageAdd_0024locals_0024).Invoke);
	}

	public float defenseMult(MerlinActionControl defenser, EnumElements attackerElement, bool defenserIsGuarding, float defenserHitPointRate)
	{
		_0024defenseMult_0024locals_002414367 _0024defenseMult_0024locals_0024 = new _0024defenseMult_0024locals_002414367();
		_0024defenseMult_0024locals_0024._0024defenser = defenser;
		_0024defenseMult_0024locals_0024._0024attackerElement = attackerElement;
		_0024defenseMult_0024locals_0024._0024defenserIsGuarding = defenserIsGuarding;
		_0024defenseMult_0024locals_0024._0024defenserHitPointRate = defenserHitPointRate;
		return product(new _0024defenseMult_0024closure_00243861(_0024defenseMult_0024locals_0024).Invoke);
	}

	public float yarareResistPlus()
	{
		return sum((SkillEffector cs) => cs.yarareResistPlus());
	}

	public float finalDamageAdjust(float damage, float defenserHitPoint)
	{
		IEnumerator<SkillEffector> enumerator = allSkills.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				SkillEffector current = enumerator.Current;
				float num = current.finalDamageAdjust(damage, defenserHitPoint);
				if (damage != num)
				{
					damage = num;
				}
			}
			return damage;
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public float unguardRate(MElements attackerElement, MStyles defenserStyle)
	{
		_0024unguardRate_0024locals_002414368 _0024unguardRate_0024locals_0024 = new _0024unguardRate_0024locals_002414368();
		_0024unguardRate_0024locals_0024._0024attackerElement = attackerElement;
		_0024unguardRate_0024locals_0024._0024defenserStyle = defenserStyle;
		return product(new _0024unguardRate_0024closure_00243863(_0024unguardRate_0024locals_0024).Invoke);
	}

	public float undodgeHeal(MStyles defenserStyle, MElements defenserElement, bool defenserIsGuarding)
	{
		_0024undodgeHeal_0024locals_002414369 _0024undodgeHeal_0024locals_0024 = new _0024undodgeHeal_0024locals_002414369();
		_0024undodgeHeal_0024locals_0024._0024defenserStyle = defenserStyle;
		_0024undodgeHeal_0024locals_0024._0024defenserElement = defenserElement;
		_0024undodgeHeal_0024locals_0024._0024defenserIsGuarding = defenserIsGuarding;
		return product(new _0024undodgeHeal_0024closure_00243864(_0024undodgeHeal_0024locals_0024).Invoke);
	}

	public float notInvalidateSuperArmor()
	{
		return product((SkillEffector cs) => cs.notInvalidateSuperArmor());
	}

	public float downRate()
	{
		return product((SkillEffector cs) => cs.downRate());
	}

	public float attackHitHpRecovery(MerlinActionControl attacker, bool isCritical)
	{
		_0024attackHitHpRecovery_0024locals_002414370 _0024attackHitHpRecovery_0024locals_0024 = new _0024attackHitHpRecovery_0024locals_002414370();
		_0024attackHitHpRecovery_0024locals_0024._0024attacker = attacker;
		_0024attackHitHpRecovery_0024locals_0024._0024isCritical = isCritical;
		return sum(new _0024attackHitHpRecovery_0024closure_00243867(_0024attackHitHpRecovery_0024locals_0024).Invoke);
	}

	public float yarareRate(bool usingSkill)
	{
		_0024yarareRate_0024locals_002414371 _0024yarareRate_0024locals_0024 = new _0024yarareRate_0024locals_002414371();
		_0024yarareRate_0024locals_0024._0024usingSkill = usingSkill;
		return product(new _0024yarareRate_0024closure_00243868(_0024yarareRate_0024locals_0024).Invoke);
	}

	public bool canResistAbnormalState(MerlinActionControl ch, EnumAbnormalStates state)
	{
		IEnumerator<SkillEffector> enumerator = allSkills.GetEnumerator();
		bool flag;
		try
		{
			while (enumerator.MoveNext())
			{
				SkillEffector current = enumerator.Current;
				if (!current.canResistAbnormalState(ch, state))
				{
					continue;
				}
				flag = true;
				goto IL_0046;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		int result = 0;
		goto IL_0047;
		IL_0046:
		result = (flag ? 1 : 0);
		goto IL_0047;
		IL_0047:
		return (byte)result != 0;
	}

	public float enemyDefenseMult()
	{
		return product((SkillEffector cs) => cs.enemyDefenseMult());
	}

	public float attackMinimumDamage()
	{
		float num = 1f;
		IEnumerator<SkillEffector> enumerator = allSkills.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				SkillEffector current = enumerator.Current;
				num = Mathf.Max(num, current.attackMinimumDamage());
			}
			return num;
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public float maximumDamage(float defenserMaxHitPoint)
	{
		float num = float.PositiveInfinity;
		IEnumerator<SkillEffector> enumerator = allSkills.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				SkillEffector current = enumerator.Current;
				num = Mathf.Min(num, current.maximumDamage(defenserMaxHitPoint));
			}
			return num;
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void applyHitEffectToAttacker(MerlinActionControl attacker, bool criticalOk, MElements monsterElement, bool isKilled)
	{
		IEnumerator<SkillEffector> enumerator = allSkills.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				SkillEffector current = enumerator.Current;
				current.applyHitEffectToAttacker(attacker, criticalOk, monsterElement, isKilled);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void applyHitEffectToDefenser(MerlinActionControl defenser, bool successDodge, bool isKilled)
	{
		IEnumerator<SkillEffector> enumerator = allSkills.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				SkillEffector current = enumerator.Current;
				current.applyHitEffectToDefenser(defenser, successDodge, isKilled);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void doEffectsPoppetDied(PlayerControl pl)
	{
		if (pl == null)
		{
			return;
		}
		IEnumerator<SkillEffector> enumerator = allSkills.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				SkillEffector current = enumerator.Current;
				current.doEffectsPoppetDied(pl);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void setAbnormalStateToAttackCommand(ActionCommandAttack cmd)
	{
		if (cmd == null)
		{
			return;
		}
		IEnumerator<SkillEffector> enumerator = allSkills.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				SkillEffector current = enumerator.Current;
				current.setAbnormalStateToAttackCommand(cmd);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void effectChangingRace(PlayerControl pl)
	{
		if (pl == null)
		{
			return;
		}
		IEnumerator<SkillEffector> enumerator = allSkills.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				SkillEffector current = enumerator.Current;
				current.effectChangingRace(pl);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	private float product(__PlayerSkillEffectControl_product_0024callable69_0024340_34__ func)
	{
		return product(allSkills, func);
	}

	private float sum(__PlayerSkillEffectControl_product_0024callable69_0024340_34__ func)
	{
		return sum(allSkills, func);
	}

	private float maximum(__PlayerSkillEffectControl_product_0024callable69_0024340_34__ func, float minValue)
	{
		return maximum(allSkills, func, minValue);
	}

	private float product(Boo.Lang.List<SkillEffector> list, __PlayerSkillEffectControl_product_0024callable69_0024340_34__ func)
	{
		float num = 1f;
		IEnumerator<SkillEffector> enumerator = list.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				SkillEffector current = enumerator.Current;
				num *= func(current);
			}
			return num;
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	private float sum(Boo.Lang.List<SkillEffector> list, __PlayerSkillEffectControl_product_0024callable69_0024340_34__ func)
	{
		float num = 0f;
		IEnumerator<SkillEffector> enumerator = allSkills.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				SkillEffector current = enumerator.Current;
				num += func(current);
			}
			return num;
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	private float maximum(Boo.Lang.List<SkillEffector> list, __PlayerSkillEffectControl_product_0024callable69_0024340_34__ func, float minValue)
	{
		float num = minValue;
		IEnumerator<SkillEffector> enumerator = list.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				SkillEffector current = enumerator.Current;
				float num2 = func(current);
				if (!(num2 <= num))
				{
					num = num2;
				}
			}
			return num;
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public bool hasNonInfinityEffectorOriginedBy(RespPoppet poppet)
	{
		int result;
		bool flag;
		if (poppet == null)
		{
			result = 0;
		}
		else
		{
			IEnumerator<SkillEffector> enumerator = allSkills.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SkillEffector current = enumerator.Current;
					if (!current.IsNotExpiredAndNotInfinity || !RuntimeServices.EqualityOperator(current.OriginPoppet, poppet))
					{
						continue;
					}
					flag = true;
					goto IL_0061;
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			result = 0;
		}
		goto IL_0062;
		IL_0062:
		return (byte)result != 0;
		IL_0061:
		result = (flag ? 1 : 0);
		goto IL_0062;
	}

	internal bool _0024updateParametersAndDeleteExpires_0024closure_00243853(SkillEffector se)
	{
		return se.IsExpired;
	}

	internal float _0024maximumChainCriticalRate_0024closure_00243855(SkillEffector cs)
	{
		return cs.maximumChainCriticalRate();
	}

	internal float _0024yarareResistPlus_0024closure_00243862(SkillEffector cs)
	{
		return cs.yarareResistPlus();
	}

	internal float _0024notInvalidateSuperArmor_0024closure_00243865(SkillEffector cs)
	{
		return cs.notInvalidateSuperArmor();
	}

	internal float _0024downRate_0024closure_00243866(SkillEffector cs)
	{
		return cs.downRate();
	}

	internal float _0024enemyDefenseMult_0024closure_00243869(SkillEffector cs)
	{
		return cs.enemyDefenseMult();
	}
}
