using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__ResponseExtensions_0024callable355_00241581_38___0024Comparison_0024170
{
	protected __ResponseExtensions_0024callable355_00241581_38__ _0024from;

	public _0024adaptor_0024__ResponseExtensions_0024callable355_00241581_38___0024Comparison_0024170(__ResponseExtensions_0024callable355_00241581_38__ from)
	{
		_0024from = from;
	}

	public int Invoke(RespDeck2Support x, RespDeck2Support y)
	{
		return _0024from(x, y);
	}

	public static Comparison<RespDeck2Support> Adapt(__ResponseExtensions_0024callable355_00241581_38__ from)
	{
		return new _0024adaptor_0024__ResponseExtensions_0024callable355_00241581_38___0024Comparison_0024170(from).Invoke;
	}
}
