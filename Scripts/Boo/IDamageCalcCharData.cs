using System;

[Serializable]
public class IDamageCalcCharData
{
	public virtual MElements element()
	{
		return MElements.Get(1);
	}

	public virtual EnumElements elementEnum()
	{
		return EnumElements.fire;
	}

	public virtual EnumElements elementWeapon1()
	{
		return elementEnum();
	}

	public virtual EnumElements elementWeapon2()
	{
		return (EnumElements)0;
	}

	public virtual MStyles style()
	{
		return MStyles.Get(1);
	}

	public virtual EnumStyles styleEnum()
	{
		return EnumStyles.Sword;
	}

	public virtual EnumRaces race()
	{
		return EnumRaces.beast;
	}

	public virtual EnumStyles weakStyle()
	{
		return EnumStyles.None;
	}

	public virtual float hitPoint()
	{
		return 10f;
	}

	public virtual float maxHitPoint()
	{
		return 10f;
	}

	public virtual float hitPointRate()
	{
		return hitPoint() / maxHitPoint();
	}

	public virtual bool isPlayer()
	{
		return false;
	}

	public virtual bool isTensi()
	{
		return false;
	}

	public virtual bool isAkuma()
	{
		return false;
	}

	public virtual bool isInJustDodge()
	{
		return false;
	}

	public virtual bool isGuarding()
	{
		return false;
	}

	public virtual bool isElite()
	{
		return false;
	}

	public virtual bool isDead()
	{
		return false;
	}

	public virtual float attack()
	{
		return 0f;
	}

	public virtual float resist()
	{
		return 0f;
	}

	public virtual float defense()
	{
		return 0f;
	}

	public virtual float breakPow()
	{
		return 0f;
	}

	public virtual float critical()
	{
		return 0f;
	}

	public virtual bool needQuestPoppetRevice()
	{
		return false;
	}

	public virtual bool needColosseumPoppetRevice()
	{
		return false;
	}

	public virtual bool hasAbnormalState()
	{
		return false;
	}

	public virtual PlayerRaidData getRaidBonusData()
	{
		return null;
	}
}
