using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__PlayerSkillEffectControl_0024callable337_0024158_30___0024Predicate_0024137
{
	protected __PlayerSkillEffectControl_0024callable337_0024158_30__ _0024from;

	public _0024adaptor_0024__PlayerSkillEffectControl_0024callable337_0024158_30___0024Predicate_0024137(__PlayerSkillEffectControl_0024callable337_0024158_30__ from)
	{
		_0024from = from;
	}

	public bool Invoke(SkillEffector obj)
	{
		return _0024from(obj);
	}

	public static Predicate<SkillEffector> Adapt(__PlayerSkillEffectControl_0024callable337_0024158_30__ from)
	{
		return new _0024adaptor_0024__PlayerSkillEffectControl_0024callable337_0024158_30___0024Predicate_0024137(from).Invoke;
	}
}
