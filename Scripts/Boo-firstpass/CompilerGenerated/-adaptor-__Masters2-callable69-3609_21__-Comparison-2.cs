using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__Masters2_0024callable69_00243609_21___0024Comparison_00242
{
	protected __Masters2_0024callable69_00243609_21__ _0024from;

	public _0024adaptor_0024__Masters2_0024callable69_00243609_21___0024Comparison_00242(__Masters2_0024callable69_00243609_21__ from)
	{
		_0024from = from;
	}

	public int Invoke(MNewFeatureDetails x, MNewFeatureDetails y)
	{
		return _0024from(x, y);
	}

	public static Comparison<MNewFeatureDetails> Adapt(__Masters2_0024callable69_00243609_21__ from)
	{
		return new _0024adaptor_0024__Masters2_0024callable69_00243609_21___0024Comparison_00242(from).Invoke;
	}
}
