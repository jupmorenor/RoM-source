using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MerlinMotionPackControl_execAddPack_0024callable372_00241174_33___0024Predicate_00241
{
	protected __MerlinMotionPackControl_execAddPack_0024callable372_00241174_33__ _0024from;

	public _0024adaptor_0024__MerlinMotionPackControl_execAddPack_0024callable372_00241174_33___0024Predicate_00241(__MerlinMotionPackControl_execAddPack_0024callable372_00241174_33__ from)
	{
		_0024from = from;
	}

	public bool Invoke(MerlinMotionPackControl.PackInfo obj)
	{
		return _0024from(obj);
	}

	public static Predicate<MerlinMotionPackControl.PackInfo> Adapt(__MerlinMotionPackControl_execAddPack_0024callable372_00241174_33__ from)
	{
		return new _0024adaptor_0024__MerlinMotionPackControl_execAddPack_0024callable372_00241174_33___0024Predicate_00241(from).Invoke;
	}
}
