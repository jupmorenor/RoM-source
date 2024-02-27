using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__PowupRecommender_PickOne_0024callable601_0024100_32___0024Comparison_0024206
{
	protected __PowupRecommender_PickOne_0024callable601_0024100_32__ _0024from;

	public _0024adaptor_0024__PowupRecommender_PickOne_0024callable601_0024100_32___0024Comparison_0024206(__PowupRecommender_PickOne_0024callable601_0024100_32__ from)
	{
		_0024from = from;
	}

	public int Invoke(RespWeaponPoppet x, RespWeaponPoppet y)
	{
		return _0024from(x, y);
	}

	public static Comparison<RespWeaponPoppet> Adapt(__PowupRecommender_PickOne_0024callable601_0024100_32__ from)
	{
		return new _0024adaptor_0024__PowupRecommender_PickOne_0024callable601_0024100_32___0024Comparison_0024206(from).Invoke;
	}
}
