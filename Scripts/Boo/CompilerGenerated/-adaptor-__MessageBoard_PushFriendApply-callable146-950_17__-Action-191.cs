using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MessageBoard_PushFriendApply_0024callable146_0024950_17___0024Action_0024191
{
	protected __MessageBoard_PushFriendApply_0024callable146_0024950_17__ _0024from;

	public _0024adaptor_0024__MessageBoard_PushFriendApply_0024callable146_0024950_17___0024Action_0024191(__MessageBoard_PushFriendApply_0024callable146_0024950_17__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase obj)
	{
		_0024from((ApiFriendApply)obj);
	}

	public static Action<RequestBase> Adapt(__MessageBoard_PushFriendApply_0024callable146_0024950_17__ from)
	{
		return new _0024adaptor_0024__MessageBoard_PushFriendApply_0024callable146_0024950_17___0024Action_0024191(from).Invoke;
	}
}
