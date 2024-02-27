using System.Runtime.CompilerServices;
using MerlinAPI;

[CompilerGlobalScope]
public sealed class StatusCalcModule
{
	private StatusCalcModule()
	{
	}

	public static float getPlayerStatCalc(EnumStatus statType, PlayerControl player)
	{
		return statType switch
		{
			EnumStatus.Atk => DamageCalc.TotalPlayerAttack(player.weaponEquipments, player.PoppetsData), 
			EnumStatus.AtkRate => 0f, 
			EnumStatus.Hp => player.HitPoint, 
			EnumStatus.HpRate => player.HitPointRate * 100f, 
			EnumStatus.Def => 0f, 
			EnumStatus.DefRate => 0f, 
			EnumStatus.Critical => player.getMainWeapon().Critical, 
			EnumStatus.CriticalDamageRate => 0f, 
			EnumStatus.Speed => 0f, 
			EnumStatus.SpeedRate => 0f, 
			EnumStatus.ElementsAtk => 0f, 
			EnumStatus.ElementsAtkRate => 0f, 
			EnumStatus.ElementsDef => 0f, 
			EnumStatus.ElementsDefRate => 0f, 
			EnumStatus.Penetration => 0f, 
			EnumStatus.PenetrationRate => 0f, 
			EnumStatus.ReduceDamage => 0f, 
			EnumStatus.ReduceDamageRate => 0f, 
			EnumStatus.GuardDamageRate => 0f, 
			EnumStatus.RaidBonusDamageRate => 0f, 
			EnumStatus.Tenacity => 0f, 
			EnumStatus.Break => player.getMainWeapon().BreakPow, 
			EnumStatus.ReduceCoolDown => 0f, 
			EnumStatus.ReduceCoolDownRate => 0f, 
			EnumStatus.ReduceMp => 0f, 
			EnumStatus.ReduceMpRate => 0f, 
			EnumStatus.RecoverMpRate => 0f, 
			EnumStatus.ResistAbnormal => 0f, 
			EnumStatus.CurrentLevel => UserData.Current.Level, 
			EnumStatus.CurrentHp => player.HitPoint, 
			EnumStatus.CurrentHpRate => player.HitPointRate * 100f, 
			EnumStatus.MaxHp => player.MaxHitPoint, 
			EnumStatus.TotalAtk => DamageCalc.TotalPlayerAttack(player.weaponEquipments, player.PoppetsData), 
			EnumStatus.TotalDef => 0f, 
			EnumStatus.TotalMoveSpeed => 0f, 
			_ => 0f, 
		};
	}

	public static float getPoppetStatCalc(EnumStatus statType, PlayerControl player, AIControl ai)
	{
		float result;
		if (!ai.HasPoppetData)
		{
			result = 0f;
		}
		else
		{
			RespPoppet poppetData = ai.PoppetData;
			result = statType switch
			{
				EnumStatus.Atk => poppetData.Attack, 
				EnumStatus.AtkRate => 0f, 
				EnumStatus.Hp => ai.HitPoint, 
				EnumStatus.HpRate => ai.HitPointRate * 100f, 
				EnumStatus.Def => poppetData.Defense, 
				EnumStatus.DefRate => 0f, 
				EnumStatus.Critical => poppetData.Critical, 
				EnumStatus.CriticalDamageRate => 0f, 
				EnumStatus.ElementsAtk => 0f, 
				EnumStatus.ElementsAtkRate => 0f, 
				EnumStatus.ElementsDef => 0f, 
				EnumStatus.ElementsDefRate => 0f, 
				EnumStatus.Penetration => 0f, 
				EnumStatus.PenetrationRate => 0f, 
				EnumStatus.Speed => 0f, 
				EnumStatus.SpeedRate => 0f, 
				EnumStatus.ReduceDamage => 0f, 
				EnumStatus.ReduceDamageRate => 0f, 
				EnumStatus.GuardDamageRate => 0f, 
				EnumStatus.Tenacity => 0f, 
				EnumStatus.Break => poppetData.BreakPow, 
				EnumStatus.CurrentLevel => poppetData.Level, 
				EnumStatus.CurrentHp => ai.HitPoint, 
				EnumStatus.CurrentHpRate => ai.HitPointRate * 100f, 
				EnumStatus.MaxHp => ai.MaxHitPoint, 
				EnumStatus.TotalAtk => poppetData.Attack, 
				EnumStatus.TotalDef => poppetData.Defense, 
				EnumStatus.TotalMoveSpeed => 0f, 
				_ => 0f, 
			};
		}
		return result;
	}

	public static float getMonsterStatCalc(EnumStatus statType, AIControl ai)
	{
		float result;
		if (!ai.HasPoppetData)
		{
			result = 0f;
		}
		else
		{
			RespMonster monsterData = ai.MonsterData;
			result = statType switch
			{
				EnumStatus.Atk => monsterData.Attack, 
				EnumStatus.AtkRate => 0f, 
				EnumStatus.Hp => ai.HitPoint, 
				EnumStatus.HpRate => ai.HitPointRate * 100f, 
				EnumStatus.Def => monsterData.Defense, 
				EnumStatus.DefRate => 0f, 
				EnumStatus.Critical => monsterData.Critical, 
				EnumStatus.CriticalDamageRate => 0f, 
				EnumStatus.ElementsAtk => 0f, 
				EnumStatus.ElementsAtkRate => 0f, 
				EnumStatus.ElementsDef => 0f, 
				EnumStatus.ElementsDefRate => 0f, 
				EnumStatus.Penetration => 0f, 
				EnumStatus.PenetrationRate => 0f, 
				EnumStatus.Speed => 0f, 
				EnumStatus.SpeedRate => 0f, 
				EnumStatus.ReduceDamage => 0f, 
				EnumStatus.ReduceDamageRate => 0f, 
				EnumStatus.GuardDamageRate => 0f, 
				EnumStatus.Tenacity => 0f, 
				EnumStatus.Break => monsterData.BreakPow, 
				EnumStatus.CurrentLevel => monsterData.Level, 
				EnumStatus.CurrentHp => ai.HitPoint, 
				EnumStatus.CurrentHpRate => ai.HitPointRate * 100f, 
				EnumStatus.MaxHp => ai.MaxHitPoint, 
				EnumStatus.TotalAtk => monsterData.Attack, 
				EnumStatus.TotalDef => monsterData.Defense, 
				EnumStatus.TotalMoveSpeed => 0f, 
				_ => 0f, 
			};
		}
		return result;
	}
}
