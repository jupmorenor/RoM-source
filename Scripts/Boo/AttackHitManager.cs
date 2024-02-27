using System;
using CompilerGenerated;
using GameAsset;
using UnityEngine;

[Serializable]
public class AttackHitManager : MonoBehaviour
{
	[Serializable]
	public enum DamagePointLocationType
	{
		Root,
		Contact
	}

	[Serializable]
	internal class _0024collide_0024locals_002414372
	{
		internal ActionCommandAttack _0024atkcmd;

		internal MerlinActionControl _0024atkCont;

		internal MerlinActionControl _0024dfcCont;
	}

	[Serializable]
	internal class _0024InfectAbnormalState_0024locals_002414373
	{
		internal MerlinActionControl _0024dfcCont;

		internal MerlinActionControl _0024atkCont;

		internal bool _0024guard;
	}

	[Serializable]
	internal class _0024collide_0024_isInvalidatedSuperArmorBySide_00243717
	{
		internal _0024collide_0024locals_002414372 _0024_0024locals_002414852;

		public _0024collide_0024_isInvalidatedSuperArmorBySide_00243717(_0024collide_0024locals_002414372 _0024_0024locals_002414852)
		{
			this._0024_0024locals_002414852 = _0024_0024locals_002414852;
		}

		public bool Invoke()
		{
			int num;
			if (_0024_0024locals_002414852._0024atkcmd == null)
			{
				num = 0;
			}
			else if (_0024_0024locals_002414852._0024atkCont == null || _0024_0024locals_002414852._0024dfcCont == null)
			{
				num = 0;
			}
			else
			{
				int invalidSuperArmorAttackers = _0024_0024locals_002414852._0024atkcmd.InvalidSuperArmorAttackers;
				int invalidSuperArmorDefensers = _0024_0024locals_002414852._0024atkcmd.InvalidSuperArmorDefensers;
				if (invalidSuperArmorAttackers == 0 || invalidSuperArmorDefensers == 0)
				{
					num = 0;
				}
				else
				{
					int mySide = (int)_0024_0024locals_002414852._0024atkCont.MySide;
					int mySide2 = (int)_0024_0024locals_002414852._0024dfcCont.MySide;
					num = (((invalidSuperArmorAttackers & mySide) != 0) ? 1 : 0);
					if (num != 0)
					{
						num = (((invalidSuperArmorDefensers & mySide2) != 0) ? 1 : 0);
					}
				}
			}
			return (byte)num != 0;
		}
	}

	[Serializable]
	internal class _0024InfectAbnormalState_0024closure_00243718
	{
		internal _0024InfectAbnormalState_0024locals_002414373 _0024_0024locals_002414853;

		public _0024InfectAbnormalState_0024closure_00243718(_0024InfectAbnormalState_0024locals_002414373 _0024_0024locals_002414853)
		{
			this._0024_0024locals_002414853 = _0024_0024locals_002414853;
		}

		public void Invoke(ActionCommandAttack.AbnormalStateInfo info)
		{
			InfectAbnormalState(_0024_0024locals_002414853._0024dfcCont, _0024_0024locals_002414853._0024atkCont, info.effect, info.rate, info.power, _0024_0024locals_002414853._0024guard);
		}
	}

	private MerlinActionControl actionControl;

	public string hitEffectPath;

	public string criticalHitEffectPath;

	public string guardEffectPath;

	public GameObject justDodgeEffct;

	private SQEX_SoundPlayer sndmgr;

	private bool playerTeam;

	private DamagePointLocationType damagePointLocationType_;

	public DamagePointLocationType damagePointLocationType
	{
		get
		{
			return damagePointLocationType_;
		}
		set
		{
			damagePointLocationType_ = value;
		}
	}

	protected bool IsEnemyTypeObject
	{
		get
		{
			Transform root = transform.root;
			return root.name.ToUpper().StartsWith("E");
		}
	}

	public AttackHitManager()
	{
		damagePointLocationType_ = DamagePointLocationType.Root;
	}

	public void Start()
	{
		if (string.IsNullOrEmpty(hitEffectPath))
		{
			hitEffectPath = ((!IsEnemyTypeObject) ? "Prefab/Effect/Ef_Hit_Damage" : "Prefab/Effect/Ef_Hit");
		}
		if (string.IsNullOrEmpty(criticalHitEffectPath))
		{
			criticalHitEffectPath = "Prefab/Effect/Ef_Hit_Critical";
		}
		if (string.IsNullOrEmpty(guardEffectPath))
		{
			guardEffectPath = "Prefab/Effect/Ef_Block";
		}
		sndmgr = SQEX_SoundPlayer.Instance;
		actionControl = transform.root.GetComponent<MerlinActionControl>();
		if (transform.root.tag == "Player")
		{
			playerTeam = true;
		}
		else
		{
			playerTeam = false;
		}
	}

	public void OnCollisionEnter(Collision coli)
	{
		if (GameParameter.enableCollisionEnter)
		{
			collide(coli);
		}
	}

	public void OnCollisionStay(Collision coli)
	{
		collide(coli);
	}

	private void collide(Collision coli)
	{
		_0024collide_0024locals_002414372 _0024collide_0024locals_0024 = new _0024collide_0024locals_002414372();
		if (actionControl == null)
		{
			actionControl = transform.root.GetComponent<MerlinActionControl>();
			if (actionControl == null)
			{
				return;
			}
		}
		if (coli.contacts.Length <= 0)
		{
			return;
		}
		ContactPoint contactPoint = coli.contacts[0];
		if (collider != contactPoint.thisCollider)
		{
			return;
		}
		MerlinActionParameters actionParameters = actionControl.ActionParameters;
		if (actionParameters.noAttackHit)
		{
			return;
		}
		int num = 0;
		YarareTypes yarareTypes = YarareTypes.Weak;
		float num2 = 0f;
		bool flag = false;
		MerlinAttackCommandHolder component = coli.gameObject.GetComponent<MerlinAttackCommandHolder>();
		if (component == null)
		{
			return;
		}
		_0024collide_0024locals_0024._0024atkcmd = component.Command;
		if (_0024collide_0024locals_0024._0024atkcmd == null)
		{
			return;
		}
		_0024collide_0024locals_0024._0024atkCont = _0024collide_0024locals_0024._0024atkcmd.parent;
		Transform root = this.gameObject.transform.root;
		_0024collide_0024locals_0024._0024dfcCont = root.GetComponent<MerlinActionControl>();
		if (_0024collide_0024locals_0024._0024atkCont == null || _0024collide_0024locals_0024._0024dfcCont == null || _0024collide_0024locals_0024._0024atkCont.IsDead || (_0024collide_0024locals_0024._0024dfcCont != null && _0024collide_0024locals_0024._0024dfcCont.noHitAttack))
		{
			return;
		}
		MerlinActionControl parent = _0024collide_0024locals_0024._0024atkcmd.parent;
		NageManager instance = NageManager.Instance;
		if (instance.isEntried(_0024collide_0024locals_0024._0024atkCont) || instance.isEntried(_0024collide_0024locals_0024._0024dfcCont) || !_0024collide_0024locals_0024._0024atkcmd.canHit(actionControl))
		{
			return;
		}
		GameObject attackChar = ((!(parent != null)) ? null : parent.gameObject);
		int damage = _0024collide_0024locals_0024._0024atkcmd.damage;
		yarareTypes = _0024collide_0024locals_0024._0024atkcmd.yarareType;
		num2 = _0024collide_0024locals_0024._0024atkcmd.knockBackPow;
		float breakPow = _0024collide_0024locals_0024._0024atkcmd.breakPow;
		PlayerControl playerControl = _0024collide_0024locals_0024._0024atkCont as PlayerControl;
		PlayerControl playerControl2 = _0024collide_0024locals_0024._0024dfcCont as PlayerControl;
		bool flag2 = playerControl != null;
		bool flag3 = playerControl2 != null;
		DamageCalc damageCalc = null;
		DamageCalcV3 damageCalcV = new DamageCalcV3();
		damageCalcV.ActionMult = (float)damage / 100f;
		damageCalcV.ActionYarare = yarareTypes;
		damageCalcV.ActionBreakPow = breakPow;
		damageCalcV.ActionCriticalRate = _0024collide_0024locals_0024._0024atkcmd.criticalRate;
		damageCalcV.UsingChainSkill = _0024collide_0024locals_0024._0024atkcmd.chainSkillPoppet;
		damageCalcV.GuardCancel = _0024collide_0024locals_0024._0024atkcmd.guardCancel;
		damageCalcV.UseChainPoppetAttack = _0024collide_0024locals_0024._0024atkcmd.useChainPoppetAttack;
		damageCalcV.AttackOriginWeapon = _0024collide_0024locals_0024._0024atkcmd.OriginWeapon;
		damageCalcV.AttackOriginElement = _0024collide_0024locals_0024._0024atkcmd.OriginElement;
		if (playerControl2 != null)
		{
			damageCalcV.UsingWeaponSkill = playerControl2.IsActionTypeSkill;
		}
		else
		{
			damageCalcV.UsingWeaponSkill = false;
		}
		damageCalc = damageCalcV;
		damageCalc.AttackerControl = _0024collide_0024locals_0024._0024atkCont;
		damageCalc.DefenserControl = _0024collide_0024locals_0024._0024dfcCont;
		damageCalc.calc();
		checked
		{
			num = (int)damageCalc.Damage;
			bool criticalOk = damageCalc.CriticalOk;
			yarareTypes = damageCalc.YarareType;
			bool guardOk = damageCalc.GuardOk;
			bool num3 = _0024collide_0024locals_0024._0024atkcmd.invalidSuperArmor;
			if (!num3)
			{
				num3 = damageCalc.InvalidateSuperArmor;
			}
			flag = num3;
			__LotterySequence_startUpdateFunc_0024callable42_002410_31__ _LotterySequence_startUpdateFunc_0024callable42_002410_31__ = new _0024collide_0024_isInvalidatedSuperArmorBySide_00243717(_0024collide_0024locals_0024).Invoke;
			bool num4 = flag;
			if (!num4)
			{
				num4 = _LotterySequence_startUpdateFunc_0024callable42_002410_31__();
			}
			flag = num4;
			if (_0024collide_0024locals_0024._0024dfcCont.IsHitCancel)
			{
				_0024collide_0024locals_0024._0024dfcCont.decHitCancelCount();
				return;
			}
			if (damageCalc.IsSucceededDodgeAction)
			{
				justDodgeAndHeal(_0024collide_0024locals_0024._0024dfcCont);
				return;
			}
			if (damageCalc.DodgeHealOk)
			{
				justDodgeAndHeal(_0024collide_0024locals_0024._0024dfcCont);
				return;
			}
			if (guardOk)
			{
				if (flag3)
				{
					num = (int)((float)num * 0.5f);
					num2 *= 0.5f;
				}
				else
				{
					num = (int)((float)num * 0.25f);
					num2 *= 0.5f;
				}
			}
			bool flag4;
			if (flag && !damageCalc.AntiInvalidateSuperArmor)
			{
				flag4 = false;
				yarareTypes = _0024collide_0024locals_0024._0024atkcmd.yarareType;
			}
			else
			{
				bool num5 = _0024collide_0024locals_0024._0024dfcCont.superArmor;
				if (!num5)
				{
					num5 = guardOk;
				}
				flag4 = num5;
			}
			if (flag4)
			{
				yarareTypes = YarareTypes.None;
			}
			if (flag2 && !flag3 && _0024collide_0024locals_0024._0024atkcmd.HasRecoveryRate)
			{
				float num6 = playerControl.execDrainSkill(_0024collide_0024locals_0024._0024atkcmd.recoveryRate);
				DamageDisplay.HealPlayer(playerControl, (int)num6);
			}
			_0024collide_0024locals_0024._0024atkcmd.playHitSE();
			if (_0024collide_0024locals_0024._0024atkcmd.nageInfo.IsValid)
			{
				if (!_0024collide_0024locals_0024._0024dfcCont.CharParameters.NoThrow)
				{
					instance.start(_0024collide_0024locals_0024._0024atkcmd.nageInfo, _0024collide_0024locals_0024._0024atkCont, _0024collide_0024locals_0024._0024dfcCont, num);
				}
				return;
			}
			if (_0024collide_0024locals_0024._0024dfcCont.CharParameters.NoKnockBack)
			{
				num2 = 0f;
			}
			if (criticalOk)
			{
				if ((bool)sndmgr)
				{
					sndmgr.PlaySe(91, 0, this.gameObject.GetInstanceID());
				}
				_0024collide_0024locals_0024._0024atkCont.addCommand(new ActionCommandMotionStop(0f, 0.1f));
			}
			if (flag2 && !_0024collide_0024locals_0024._0024atkcmd.IsChainSkill)
			{
				MagicPointCalc.HitPlayerAttack(num, playerControl, _0024collide_0024locals_0024._0024dfcCont);
			}
			if (_0024collide_0024locals_0024._0024atkCont.HasPoppetData)
			{
				AIControl aIControl = _0024collide_0024locals_0024._0024atkCont as AIControl;
				if (aIControl != null)
				{
					MagicPointCalc.HitIfPoppetAttack(num, aIControl, _0024collide_0024locals_0024._0024dfcCont);
				}
			}
			bool isAlive = actionControl.IsAlive;
			actionControl.HitAttack(num, yarareTypes, attackChar);
			bool num7 = !(_0024collide_0024locals_0024._0024dfcCont.HitPoint > 0f);
			if (num7)
			{
				num7 = isAlive;
			}
			bool flag5 = num7;
			damageCalc.doHit(flag5, !isAlive);
			Vector3 vector = default(Vector3);
			vector = contactPoint.point;
			if (needDamagePop(_0024collide_0024locals_0024._0024atkCont, _0024collide_0024locals_0024._0024dfcCont))
			{
				DamageDisplay.Type type = DamageDisplay.Type.Normal;
				if (guardOk)
				{
					type = DamageDisplay.Type.Guard;
				}
				else if (playerTeam)
				{
					type = DamageDisplay.Type.PlayerTeam;
				}
				else if (criticalOk)
				{
					type = DamageDisplay.Type.Critical;
				}
				DamageDisplay.DrawByType(vector, num, type);
			}
			if (criticalOk)
			{
				GameAssetModule.InstantiatePrefab(criticalHitEffectPath, contactPoint.point, transform.rotation);
			}
			else if (guardOk)
			{
				GameObject gameObject = GameAssetModule.InstantiatePrefab(guardEffectPath, contactPoint.point, transform.root.rotation);
				if ((bool)gameObject)
				{
					gameObject.transform.parent = transform.root;
					gameObject.transform.localPosition = new Vector3(0f, 1f, 0f);
				}
			}
			else
			{
				GameAssetModule.InstantiatePrefab(hitEffectPath, contactPoint.point, transform.rotation);
			}
			Vector3 vector2 = transform.position - coli.transform.root.position;
			vector2.y = 0f;
			actionControl.KnockBack = vector2.normalized * num2;
			if (flag2 || flag3)
			{
				float num8 = default(float);
				float num9 = default(float);
				if (criticalOk)
				{
					num8 = (float)((double)UnityEngine.Random.Range(70, 80) * 0.01);
					num9 = (float)((double)UnityEngine.Random.Range(25, 35) * 0.01);
				}
				else
				{
					num8 = (float)((double)UnityEngine.Random.Range(35, 50) * 0.01);
					num9 = (float)((double)UnityEngine.Random.Range(15, 25) * 0.01);
				}
				iTween.ShakePosition(Camera.main.gameObject, new Vector3(0f, num8, 0f), num9);
			}
			if (flag2 && flag5)
			{
				float hpRecoveryValueWhenKilled = playerControl.SkillEffect.hpRecoveryValueWhenKilled;
				playerControl.addHP(hpRecoveryValueWhenKilled);
				DamageDisplay.HealPlayer(playerControl, (int)hpRecoveryValueWhenKilled);
			}
			if (GameParameter.alwaysAbnormalStateAttack)
			{
				EnumAbnormalStates defaultAbnormalStateType = GameParameter.defaultAbnormalStateType;
				_0024collide_0024locals_0024._0024atkcmd.addAbnormalStateEffect(defaultAbnormalStateType, 100, 100);
			}
			InfectAbnormalState(_0024collide_0024locals_0024._0024dfcCont, _0024collide_0024locals_0024._0024atkCont, _0024collide_0024locals_0024._0024atkcmd, guardOk);
			if (flag5)
			{
				if (flag3)
				{
					PlayerEventDispatcher.InvokePlayerDead(playerControl2);
				}
				else if (_0024collide_0024locals_0024._0024atkCont.HasPoppetData)
				{
					PlayerEventDispatcher.InvokePoppetFinish(_0024collide_0024locals_0024._0024atkCont, _0024collide_0024locals_0024._0024dfcCont, num);
				}
				else if (_0024collide_0024locals_0024._0024dfcCont.HasPoppetData)
				{
					PlayerEventDispatcher.InvokeDead(_0024collide_0024locals_0024._0024atkCont, _0024collide_0024locals_0024._0024dfcCont, num);
				}
			}
			else if (yarareTypes == YarareTypes.Down)
			{
				if (flag3)
				{
					PlayerEventDispatcher.InvokePlayerDown(_0024collide_0024locals_0024._0024dfcCont);
				}
				else if (_0024collide_0024locals_0024._0024dfcCont.HasPoppetData)
				{
					PlayerEventDispatcher.InvokePoppetDown(_0024collide_0024locals_0024._0024atkCont, _0024collide_0024locals_0024._0024dfcCont, num);
				}
				else
				{
					PlayerEventDispatcher.InvokeMonsterDown(_0024collide_0024locals_0024._0024dfcCont);
				}
			}
			else if (flag3)
			{
				PlayerEventDispatcher.InvokePlayerDamage(_0024collide_0024locals_0024._0024dfcCont);
			}
			else if (_0024collide_0024locals_0024._0024dfcCont.HasPoppetData)
			{
				PlayerEventDispatcher.InvokePoppetDamage(_0024collide_0024locals_0024._0024atkCont, _0024collide_0024locals_0024._0024dfcCont, num);
			}
			else
			{
				PlayerEventDispatcher.InvokeMonsterDamage(_0024collide_0024locals_0024._0024dfcCont);
			}
		}
	}

	private bool needDamagePop(MerlinActionControl atk, MerlinActionControl dfc)
	{
		return !(dfc == null) && (dfc.IsColosseumSetup || dfc.MySide == AttackDamageActors.MONSTER || atk.MySide == AttackDamageActors.PLAYER || dfc.MySide == AttackDamageActors.PLAYER);
	}

	private static void InfectAbnormalState(MerlinActionControl dfcCont, MerlinActionControl atkCont, ActionCommandAttack atkcmd, bool guard)
	{
		_0024InfectAbnormalState_0024locals_002414373 _0024InfectAbnormalState_0024locals_0024 = new _0024InfectAbnormalState_0024locals_002414373();
		_0024InfectAbnormalState_0024locals_0024._0024dfcCont = dfcCont;
		_0024InfectAbnormalState_0024locals_0024._0024atkCont = atkCont;
		_0024InfectAbnormalState_0024locals_0024._0024guard = guard;
		atkcmd?.enumerateAbnormalState(new _0024InfectAbnormalState_0024closure_00243718(_0024InfectAbnormalState_0024locals_0024).Invoke);
	}

	private static void InfectAbnormalState(MerlinActionControl dfcCont, MerlinActionControl atkCont, EnumAbnormalStates state, float rate, int infectionPower, bool guard)
	{
		if (dfcCont.IsDead || guard || !((float)UnityEngine.Random.Range(0, 100) < rate))
		{
			return;
		}
		if (state == EnumAbnormalStates.None)
		{
			state = EnumAbnormalStates.Poison;
		}
		if (dfcCont.hasAbnormalState(state))
		{
			return;
		}
		bool flag = dfcCont.canResistAbnormalStateBySkill(state);
		bool num = flag;
		if (!num)
		{
			num = GameParameter.alwaysResistAbnormalStateAttack;
		}
		flag = num;
		AbnormalStateLimitter abnormalStateLimitter = dfcCont.AbnormalStateLimitter;
		abnormalStateLimitter.updateInfection(state, infectionPower);
		if (abnormalStateLimitter.isIll(state))
		{
			if (flag)
			{
				dfcCont.resistAbnormalState(state);
				PlayerEventDispatcher.InvokeResistAbnormalStateAttack(state, dfcCont, atkCont);
			}
			else
			{
				dfcCont.setAbnormalState(state);
				PlayerEventDispatcher.InvokeInfectAbnormalState(state, dfcCont, atkCont);
			}
		}
	}

	private void justDodgeAndHeal(MerlinActionControl dfc)
	{
		PlayerControl playerControl = dfc as PlayerControl;
		if (playerControl != null)
		{
			playerControl.UpdateSkillCoolDown(2f);
			float kaihiSkillCoolDownVal = playerControl.SkillEffect.kaihiSkillCoolDownVal;
			playerControl.coolDownWeaponSkill(kaihiSkillCoolDownVal);
		}
		float num = dfc.HitPointRecoveryRate(0.02f);
		Vector3 position = dfc.transform.position;
		Quaternion rotation = dfc.transform.rotation;
		DamageDisplay.Heal(position, checked((int)num));
		if (justDodgeEffct != null)
		{
			UnityEngine.Object.Instantiate(justDodgeEffct, position, rotation);
		}
		if (playerControl != null)
		{
			MagicPointCalc.DodgeRecover(playerControl);
		}
		else if (dfc.IsColosseumSetup)
		{
			MagicPointCalc.DodgeRecoverInColosseum((AIControl)dfc);
		}
	}
}
