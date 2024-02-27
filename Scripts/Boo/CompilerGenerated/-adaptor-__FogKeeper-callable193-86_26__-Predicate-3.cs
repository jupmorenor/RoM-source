using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__FogKeeper_0024callable193_002486_26___0024Predicate_00243
{
	protected __FogKeeper_0024callable193_002486_26__ _0024from;

	public _0024adaptor_0024__FogKeeper_0024callable193_002486_26___0024Predicate_00243(__FogKeeper_0024callable193_002486_26__ from)
	{
		_0024from = from;
	}

	public bool Invoke(FogKeeper.StackData obj)
	{
		return _0024from(obj);
	}

	public static Predicate<FogKeeper.StackData> Adapt(__FogKeeper_0024callable193_002486_26__ from)
	{
		return new _0024adaptor_0024__FogKeeper_0024callable193_002486_26___0024Predicate_00243(from).Invoke;
	}
}
