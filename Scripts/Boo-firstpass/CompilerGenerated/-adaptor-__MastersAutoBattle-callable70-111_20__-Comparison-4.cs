using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MastersAutoBattle_0024callable70_0024111_20___0024Comparison_00244
{
	protected __MastersAutoBattle_0024callable70_0024111_20__ _0024from;

	public _0024adaptor_0024__MastersAutoBattle_0024callable70_0024111_20___0024Comparison_00244(__MastersAutoBattle_0024callable70_0024111_20__ from)
	{
		_0024from = from;
	}

	public int Invoke(MAutoFlowPoint x, MAutoFlowPoint y)
	{
		return _0024from(x, y);
	}

	public static Comparison<MAutoFlowPoint> Adapt(__MastersAutoBattle_0024callable70_0024111_20__ from)
	{
		return new _0024adaptor_0024__MastersAutoBattle_0024callable70_0024111_20___0024Comparison_00244(from).Invoke;
	}
}
