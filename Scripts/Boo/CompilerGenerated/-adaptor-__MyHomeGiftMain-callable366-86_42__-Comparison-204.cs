using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MyHomeGiftMain_0024callable366_002486_42___0024Comparison_0024204
{
	protected __MyHomeGiftMain_0024callable366_002486_42__ _0024from;

	public _0024adaptor_0024__MyHomeGiftMain_0024callable366_002486_42___0024Comparison_0024204(__MyHomeGiftMain_0024callable366_002486_42__ from)
	{
		_0024from = from;
	}

	public int Invoke(RespPlayerPresentBox x, RespPlayerPresentBox y)
	{
		return _0024from(x, y);
	}

	public static Comparison<RespPlayerPresentBox> Adapt(__MyHomeGiftMain_0024callable366_002486_42__ from)
	{
		return new _0024adaptor_0024__MyHomeGiftMain_0024callable366_002486_42___0024Comparison_0024204(from).Invoke;
	}
}
