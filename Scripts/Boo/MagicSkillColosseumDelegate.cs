using System;

[Serializable]
public class MagicSkillColosseumDelegate : MagicSkillDelegate
{
	public override bool canUseSkill(MagicSkill magicSkill)
	{
		AIControl poppetAI = magicSkill.PoppetAI;
		return !(poppetAI == null) && !NageManager.Instance.isEntried(poppetAI) && !poppetAI.IsDead && !poppetAI.IsChainDisabledByAbnormalState && !ChainSkillRoutine.IsPlaying && magicSkill.IsFullCharge;
	}

	public override void useSkill(MagicSkill magicSkill)
	{
		AIControl poppetAI = magicSkill.PoppetAI;
		ChainSkillRoutine.Instance.execSkill(poppetAI);
	}

	public override void setPoppetIndexOfPlayer(MagicSkill magicSkill, int index)
	{
	}

	public override void magicPointChanged(MagicSkill magicSkill)
	{
	}

	public override void magicPointFullCharged(MagicSkill magicSkill)
	{
	}

	public override void start(MagicSkill magicSkill)
	{
	}

	public override void update(MagicSkill magicSkill)
	{
	}
}
