using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34___0024Action_0024214
{
	protected __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ _0024from;

	public _0024adaptor_0024__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34___0024Action_0024214(__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ from)
	{
		_0024from = from;
	}

	public void Invoke(bool arg0)
	{
		_0024from(arg0);
	}

	public static Action<bool> Adapt(__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ from)
	{
		return new _0024adaptor_0024__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34___0024Action_0024214(from).Invoke;
	}
}
