using System;
using UnityEngine;

[Serializable]
public class MagicPointCalc
{
	public static void HitPlayerAttack(float damage, PlayerControl player, MerlinActionControl dfcCont)
	{
		checked
		{
			if (!(player == null) && !(dfcCont == null))
			{
				int num = (int)damage;
				if (!(damage <= dfcCont.HitPoint))
				{
					num = (int)Mathf.Max(dfcCont.HitPoint, 0f);
				}
				float num2 = Mathf.Max(1f, dfcCont.MaxHitPoint);
				float num3 = (float)num / num2 * 100f;
				if (dfcCont.IS_BOSS || dfcCont.IS_ELITE)
				{
					num3 *= 5f;
				}
				if (!dfcCont.IsDead)
				{
					player.addMagicPoint((int)(num3 * player.SkillEffect.mpRecoveryRateWhenAttack));
				}
			}
		}
	}

	public static void HitIfPoppetAttack(float damage, AIControl poppet, MerlinActionControl dfcCont)
	{
		if (poppet == null || dfcCont == null)
		{
			return;
		}
		MagicSkill magicSkillComponent = poppet.MagicSkillComponent;
		if (magicSkillComponent != null)
		{
			float num = damage;
			if (!(damage <= dfcCont.HitPoint))
			{
				num = Mathf.Max(dfcCont.HitPoint, 0f);
			}
			float num2 = Mathf.Max(1f, dfcCont.MaxHitPoint);
			float num3 = num / num2 * 100f;
			if (dfcCont.IS_BOSS || dfcCont.IS_ELITE)
			{
				num3 *= 5f;
			}
			magicSkillComponent.addMagicPoint(checked((int)num3));
		}
	}

	public static void DamageToPlayer(float damage, PlayerControl player)
	{
		if (!(player == null))
		{
			float mpRecoveryRateWhenDamaged = player.SkillEffect.mpRecoveryRateWhenDamaged;
			float maxHitPoint = player.MaxHitPoint;
			float num = damage * mpRecoveryRateWhenDamaged / maxHitPoint * 400f;
			player.addMagicPoint(checked((int)num));
		}
	}

	public static void DodgeRecover(PlayerControl player)
	{
		if (player != null)
		{
			float num = 100f + player.SkillEffect.mpRecoveryValueWhenKaihi;
			player.addMagicPoint(checked((int)num));
		}
	}

	public static void ColosseumHitToEnemy(AIControl attacker, AIControl defenser, float damage)
	{
		if (!(attacker == null) && !(defenser == null))
		{
			float pnt = _ColosseumHitRecovery(damage, defenser, 200f);
			_AddMagicPoint(attacker, pnt);
		}
	}

	public static void ColosseumHitToMe(AIControl attacker, AIControl defenser, float damage)
	{
		if (!(attacker == null) && !(defenser == null))
		{
			float pnt = _ColosseumHitRecovery(damage, defenser, 400f);
			_AddMagicPoint(defenser, pnt);
		}
	}

	public static void ColosseumTeammateKilled(AIControl teammate)
	{
		_AddMagicPoint(teammate, 200f);
	}

	public static void DodgeRecoverInColosseum(AIControl ch)
	{
		float pnt = 100f + ch.SkillEffect.mpRecoveryValueWhenKaihi;
		_AddMagicPoint(ch, pnt);
	}

	private static float _ColosseumHitRecovery(float damage, AIControl maxHitPointChar, float coef)
	{
		float num = Mathf.Min(damage, maxHitPointChar.MaxHitPoint);
		return num * coef / maxHitPointChar.MaxHitPoint;
	}

	private static void _AddMagicPoint(AIControl ch, float pnt)
	{
		if (!(ch == null))
		{
			MagicSkill magicSkillComponent = ch.MagicSkillComponent;
			if (magicSkillComponent != null)
			{
				magicSkillComponent.addMagicPoint(checked((int)pnt));
			}
		}
	}
}
