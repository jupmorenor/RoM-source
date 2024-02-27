using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MessageBoard_PushFriendReject_0024callable149_00241014_13___0024Action_0024194
{
	protected __MessageBoard_PushFriendReject_0024callable149_00241014_13__ _0024from;

	public _0024adaptor_0024__MessageBoard_PushFriendReject_0024callable149_00241014_13___0024Action_0024194(__MessageBoard_PushFriendReject_0024callable149_00241014_13__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase obj)
	{
		_0024from((ApiFriendReject)obj);
	}

	public static Action<RequestBase> Adapt(__MessageBoard_PushFriendReject_0024callable149_00241014_13__ from)
	{
		return new _0024adaptor_0024__MessageBoard_PushFriendReject_0024callable149_00241014_13___0024Action_0024194(from).Invoke;
	}
}
