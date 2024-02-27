using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__PlayerAbnormalStateControl_0024callable333_002441_38___0024Predicate_0024133
{
	protected __PlayerAbnormalStateControl_0024callable333_002441_38__ _0024from;

	public _0024adaptor_0024__PlayerAbnormalStateControl_0024callable333_002441_38___0024Predicate_0024133(__PlayerAbnormalStateControl_0024callable333_002441_38__ from)
	{
		_0024from = from;
	}

	public bool Invoke(PlayerAbnormalState obj)
	{
		return _0024from(obj);
	}

	public static Predicate<PlayerAbnormalState> Adapt(__PlayerAbnormalStateControl_0024callable333_002441_38__ from)
	{
		return new _0024adaptor_0024__PlayerAbnormalStateControl_0024callable333_002441_38___0024Predicate_0024133(from).Invoke;
	}
}
