using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MessageBoard_PushLeaderChange_0024callable153_00241360_20___0024Action_0024198
{
	protected __MessageBoard_PushLeaderChange_0024callable153_00241360_20__ _0024from;

	public _0024adaptor_0024__MessageBoard_PushLeaderChange_0024callable153_00241360_20___0024Action_0024198(__MessageBoard_PushLeaderChange_0024callable153_00241360_20__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase obj)
	{
		_0024from((ApiPartyLeaderChange)obj);
	}

	public static Action<RequestBase> Adapt(__MessageBoard_PushLeaderChange_0024callable153_00241360_20__ from)
	{
		return new _0024adaptor_0024__MessageBoard_PushLeaderChange_0024callable153_00241360_20___0024Action_0024198(from).Invoke;
	}
}
