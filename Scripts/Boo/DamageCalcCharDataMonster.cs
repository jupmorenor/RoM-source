using System;
using Boo.Lang.Runtime;
using MerlinAPI;

[Serializable]
public class DamageCalcCharDataMonster : IDamageCalcCharData
{
	private AIControl ai;

	private RespPoppet poppet;

	private RespMonster monster;

	private bool _0024initialized__DamageCalcCharDataMonster_0024;

	public AIControl AI => ai;

	public RespPoppet Poppet => poppet;

	public RespMonster Monster => monster;

	public DamageCalcCharDataMonster(AIControl _ai, RespPoppet _poppetData)
	{
		if (!_0024initialized__DamageCalcCharDataMonster_0024)
		{
			_0024initialized__DamageCalcCharDataMonster_0024 = true;
		}
		if (!(_ai != null))
		{
			throw new AssertionFailedException("!!!!! DamageCalcCharDataMonster _ai = null");
		}
		if (_poppetData == null)
		{
			throw new AssertionFailedException("!!!!! DamageCalcCharDataMonster _poppetData = null");
		}
		ai = _ai;
		poppet = _poppetData;
	}

	public DamageCalcCharDataMonster(AIControl _ai, RespMonster _monsterData)
	{
		if (!_0024initialized__DamageCalcCharDataMonster_0024)
		{
			_0024initialized__DamageCalcCharDataMonster_0024 = true;
		}
		if (!(_ai != null))
		{
			throw new AssertionFailedException("!!!!! DamageCalcCharDataMonster _ai = null");
		}
		if (_monsterData == null)
		{
			throw new AssertionFailedException("!!!!! DamageCalcCharDataMonster _monsterData = null");
		}
		ai = _ai;
		monster = _monsterData;
	}

	public override MElements element()
	{
		return MElements.Get((int)elementEnum());
	}

	public override EnumElements elementEnum()
	{
		return ai.CurrentElement;
	}

	public override EnumElements elementWeapon1()
	{
		return elementEnum();
	}

	public override EnumElements elementWeapon2()
	{
		return (EnumElements)0;
	}

	public override MStyles style()
	{
		return ai.getMainWeapon()?.Style;
	}

	public override EnumStyles styleEnum()
	{
		return (EnumStyles)(ai.getMainWeapon()?.StyleId ?? 0);
	}

	public override EnumRaces race()
	{
		return (poppet == null) ? ((EnumRaces)monster.Race.Id) : poppet.Race;
	}

	public override EnumStyles weakStyle()
	{
		return (monster == null) ? poppet.MonsterMaster.WeakStyle : monster.WeakStyle;
	}

	public override float hitPoint()
	{
		return ai.HitPoint;
	}

	public override float maxHitPoint()
	{
		return ai.MaxHitPoint;
	}

	public override float hitPointRate()
	{
		return ai.HitPointRate;
	}

	public override bool isPlayer()
	{
		return false;
	}

	public override bool isTensi()
	{
		return false;
	}

	public override bool isAkuma()
	{
		return false;
	}

	public override bool isInJustDodge()
	{
		return false;
	}

	public override bool isGuarding()
	{
		return ai.ActionParameters.guard;
	}

	public override bool isElite()
	{
		return ai.IS_ELITE;
	}

	public override bool isDead()
	{
		return ai.IsDead;
	}

	public override float attack()
	{
		return (monster == null) ? DamageCalc.ColosseumPoppetAttack(poppet, ai.getMainWeapon()) : ((float)monster.Attack);
	}

	public override float resist()
	{
		return (monster == null) ? poppet.Resist : monster.Resist;
	}

	public override float defense()
	{
		return (monster == null) ? poppet.Defense : monster.Defense;
	}

	public override float breakPow()
	{
		return (monster == null) ? poppet.BreakPow : monster.BreakPow;
	}

	public override float critical()
	{
		return (monster == null) ? poppet.Critical : monster.Critical;
	}

	public override bool needQuestPoppetRevice()
	{
		bool num = poppet != null;
		if (num)
		{
			num = QuestInitializer.IsInQuest;
		}
		return num;
	}

	public override bool needColosseumPoppetRevice()
	{
		bool num = poppet != null;
		if (num)
		{
			num = ai.IsColosseumSetup;
		}
		return num;
	}

	public override bool hasAbnormalState()
	{
		return ai.HasAnyAbnormalState;
	}

	public override PlayerRaidData getRaidBonusData()
	{
		return null;
	}
}
