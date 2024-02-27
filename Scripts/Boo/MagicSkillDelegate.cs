using System;

[Serializable]
public abstract class MagicSkillDelegate
{
	public virtual bool canUseSkill(MagicSkill magicSkill)
	{
		return false;
	}

	public virtual void useSkill(MagicSkill magicSkill)
	{
	}

	public virtual void setPoppetIndexOfPlayer(MagicSkill magicSkill, int index)
	{
	}

	public virtual void magicPointChanged(MagicSkill magicSkill)
	{
	}

	public virtual void magicPointFullCharged(MagicSkill magicSkill)
	{
	}

	public virtual void start(MagicSkill magicSkill)
	{
	}

	public virtual void update(MagicSkill magicSkill)
	{
	}
}
