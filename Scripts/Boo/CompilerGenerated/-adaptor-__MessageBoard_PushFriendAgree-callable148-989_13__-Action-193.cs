using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MessageBoard_PushFriendAgree_0024callable148_0024989_13___0024Action_0024193
{
	protected __MessageBoard_PushFriendAgree_0024callable148_0024989_13__ _0024from;

	public _0024adaptor_0024__MessageBoard_PushFriendAgree_0024callable148_0024989_13___0024Action_0024193(__MessageBoard_PushFriendAgree_0024callable148_0024989_13__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase obj)
	{
		_0024from((ApiFriendAccept)obj);
	}

	public static Action<RequestBase> Adapt(__MessageBoard_PushFriendAgree_0024callable148_0024989_13__ from)
	{
		return new _0024adaptor_0024__MessageBoard_PushFriendAgree_0024callable148_0024989_13___0024Action_0024193(from).Invoke;
	}
}
