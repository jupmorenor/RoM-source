using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__PlayerLabelControl_0024callable354_002451_27___0024Predicate_0024163
{
	protected __PlayerLabelControl_0024callable354_002451_27__ _0024from;

	public _0024adaptor_0024__PlayerLabelControl_0024callable354_002451_27___0024Predicate_0024163(__PlayerLabelControl_0024callable354_002451_27__ from)
	{
		_0024from = from;
	}

	public bool Invoke(PlayerLabelControl.Pair obj)
	{
		return _0024from(obj);
	}

	public static Predicate<PlayerLabelControl.Pair> Adapt(__PlayerLabelControl_0024callable354_002451_27__ from)
	{
		return new _0024adaptor_0024__PlayerLabelControl_0024callable354_002451_27___0024Predicate_0024163(from).Invoke;
	}
}
