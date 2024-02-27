using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MessageBoard_PushFriendLeave_0024callable147_0024968_13___0024Action_0024192
{
	protected __MessageBoard_PushFriendLeave_0024callable147_0024968_13__ _0024from;

	public _0024adaptor_0024__MessageBoard_PushFriendLeave_0024callable147_0024968_13___0024Action_0024192(__MessageBoard_PushFriendLeave_0024callable147_0024968_13__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase obj)
	{
		_0024from((ApiFriendRemove)obj);
	}

	public static Action<RequestBase> Adapt(__MessageBoard_PushFriendLeave_0024callable147_0024968_13__ from)
	{
		return new _0024adaptor_0024__MessageBoard_PushFriendLeave_0024callable147_0024968_13___0024Action_0024192(from).Invoke;
	}
}
