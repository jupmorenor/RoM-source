using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__ArrayMapMain_FilterRewards_0024callable121_002484_75___0024Predicate_0024167
{
	protected __ArrayMapMain_FilterRewards_0024callable121_002484_75__ _0024from;

	public _0024adaptor_0024__ArrayMapMain_FilterRewards_0024callable121_002484_75___0024Predicate_0024167(__ArrayMapMain_FilterRewards_0024callable121_002484_75__ from)
	{
		_0024from = from;
	}

	public bool Invoke(RespSimpleReward obj)
	{
		return _0024from(obj);
	}

	public static Predicate<RespSimpleReward> Adapt(__ArrayMapMain_FilterRewards_0024callable121_002484_75__ from)
	{
		return new _0024adaptor_0024__ArrayMapMain_FilterRewards_0024callable121_002484_75___0024Predicate_0024167(from).Invoke;
	}
}
