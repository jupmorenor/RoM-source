using System;

[Serializable]
public class PicBookData
{
	[NonSerialized]
	public MWeapons weapon;

	[NonSerialized]
	public MPoppets poppet;

	private int attack;

	private int hp;

	public DamageCalc.BonusValue bonus;

	private bool isCheckedHave;

	private bool isHave;

	public bool isHaveDebug;

	public PicBookData(MWeapons w)
	{
		weapon = w;
	}

	public PicBookData(MPoppets p)
	{
		poppet = p;
	}

	public bool IsWeapon()
	{
		return weapon != null;
	}

	public bool IsPoppet()
	{
		return poppet != null;
	}

	public int GetAttack()
	{
		if (attack == 0)
		{
			if (IsWeapon())
			{
				attack = checked((int)weapon.attack(weapon.LevelLimitMax));
			}
			else if (IsPoppet())
			{
				attack = poppet.attack(poppet.LevelLimitMax);
			}
		}
		return attack;
	}

	public int GetHp()
	{
		if (hp == 0)
		{
			if (IsWeapon())
			{
				hp = checked((int)weapon.hp(weapon.LevelLimitMax));
			}
			else if (IsPoppet())
			{
				hp = poppet.hp(poppet.LevelLimitMax);
			}
		}
		return hp;
	}

	public DamageCalc.BonusValue GetBonus()
	{
		if (bonus.evoTrack == null)
		{
			if (IsWeapon())
			{
				bonus = DamageCalc.WeaponBonusMaximumValue(weapon);
			}
			else if (IsPoppet())
			{
				bonus = DamageCalc.PoppetBonusMaximumValue(poppet);
			}
		}
		return bonus;
	}

	public bool IsHave()
	{
		int result;
		if (isHaveDebug)
		{
			result = 1;
		}
		else
		{
			if (!isCheckedHave)
			{
				if (IsWeapon())
				{
					isHave = UserData.Current.userMiscInfo.weaponBookData.isHave(weapon);
				}
				if (IsPoppet())
				{
					isHave = UserData.Current.userMiscInfo.poppetBookData.isHave(poppet);
				}
				isCheckedHave = true;
			}
			result = (isHave ? 1 : 0);
		}
		return (byte)result != 0;
	}
}
