using System;
using Boo.Lang.Runtime;
using MerlinAPI;

[Serializable]
public class DamageCalcCharDataPlayer : IDamageCalcCharData
{
	private PlayerControl player;

	public DamageCalcCharDataPlayer(PlayerControl p)
	{
		if (!(p != null))
		{
			throw new AssertionFailedException("!!!!! DamageCalcCharDataPlayer p = null");
		}
		player = p;
	}

	public override MElements element()
	{
		return player.getMainWeapon().Element;
	}

	public override EnumElements elementEnum()
	{
		return (EnumElements)element().Id;
	}

	public override EnumElements elementWeapon1()
	{
		RespWeapon[] mainWeaponList = player.MainWeaponList;
		return (mainWeaponList != null && mainWeaponList.Length > 0 && mainWeaponList[0] != null) ? ((EnumElements)mainWeaponList[0].ElementId) : ((EnumElements)0);
	}

	public override EnumElements elementWeapon2()
	{
		RespWeapon[] mainWeaponList = player.MainWeaponList;
		return (mainWeaponList != null && mainWeaponList.Length > 1 && mainWeaponList[1] != null) ? ((EnumElements)mainWeaponList[1].ElementId) : ((EnumElements)0);
	}

	public override MStyles style()
	{
		return player.getMainWeapon().Style;
	}

	public override EnumStyles styleEnum()
	{
		return (EnumStyles)player.getMainWeapon().Style.Id;
	}

	public override EnumRaces race()
	{
		return (EnumRaces)0;
	}

	public override EnumStyles weakStyle()
	{
		return EnumStyles.None;
	}

	public override float hitPoint()
	{
		return player.HitPoint;
	}

	public override float maxHitPoint()
	{
		return player.MaxHitPoint;
	}

	public override float hitPointRate()
	{
		return player.HitPointRate;
	}

	public override bool isPlayer()
	{
		return true;
	}

	public override bool isTensi()
	{
		return player.IsTensi;
	}

	public override bool isAkuma()
	{
		return player.IsAkuma;
	}

	public override bool isInJustDodge()
	{
		return player.IsJustDodge;
	}

	public override bool isGuarding()
	{
		return player.ActionParameters.guard;
	}

	public override bool isElite()
	{
		return false;
	}

	public override bool isDead()
	{
		return player.IsDead;
	}

	public override float attack()
	{
		return player.totalPlayerAttack();
	}

	public override float resist()
	{
		return player.getMainWeapon().Resist;
	}

	public override float defense()
	{
		return 0f;
	}

	public override float breakPow()
	{
		return player.getMainWeapon().BreakPow;
	}

	public override float critical()
	{
		return player.getMainWeapon().Critical;
	}

	public override bool needQuestPoppetRevice()
	{
		return false;
	}

	public override bool needColosseumPoppetRevice()
	{
		return false;
	}

	public override bool hasAbnormalState()
	{
		return player.HasAnyAbnormalState;
	}

	public override PlayerRaidData getRaidBonusData()
	{
		PlayerRaidData raidData = player.RaidData;
		return (raidData == null || !raidData.isRaid) ? null : raidData;
	}
}
