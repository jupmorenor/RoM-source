using System;
using Boo.Lang.Runtime;

[Serializable]
public class MerlinActionSkillCommandBase : MerlinActionControl.ActTimeCommand
{
	protected SkillEffectParameters skillEffect;

	protected int skillLevel;

	protected int skillLevelMax;

	public override bool UpdateWithWorldTime => true;

	public MerlinActionSkillCommandBase(SkillEffectParameters _skillEffect, int _skillLevel, int _skillLevelMax)
	{
		if (_skillEffect == null)
		{
			throw new AssertionFailedException("_skillEffect != null");
		}
		if (_skillLevelMax <= 0)
		{
			throw new AssertionFailedException("_skillLevelMax > 0");
		}
		if (_skillLevel <= 0 || _skillLevelMax < _skillLevel)
		{
			throw new AssertionFailedException("(_skillLevel > 0) and (_skillLevelMax >= _skillLevel)");
		}
		if (_skillEffect.MSkillEffectTypeId == null)
		{
			throw new AssertionFailedException("_skillEffect.MSkillEffectTypeId != null");
		}
		skillEffect = _skillEffect;
		skillLevel = _skillLevel;
		skillLevelMax = _skillLevelMax;
	}

	protected float effectValue()
	{
		skillEffect.getEffectValue(skillLevel, skillLevelMax, "SkillEffect");
		return 0f;
	}

	protected float effectRate()
	{
		skillEffect.getEffectValueAsRate(skillLevel, skillLevelMax, "SkillEffect");
		return 0f;
	}
}
