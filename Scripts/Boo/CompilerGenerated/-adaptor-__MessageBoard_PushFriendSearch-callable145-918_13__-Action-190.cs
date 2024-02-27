using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MessageBoard_PushFriendSearch_0024callable145_0024918_13___0024Action_0024190
{
	protected __MessageBoard_PushFriendSearch_0024callable145_0024918_13__ _0024from;

	public _0024adaptor_0024__MessageBoard_PushFriendSearch_0024callable145_0024918_13___0024Action_0024190(__MessageBoard_PushFriendSearch_0024callable145_0024918_13__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase obj)
	{
		_0024from((ApiFriendPlayerSearch)obj);
	}

	public static Action<RequestBase> Adapt(__MessageBoard_PushFriendSearch_0024callable145_0024918_13__ from)
	{
		return new _0024adaptor_0024__MessageBoard_PushFriendSearch_0024callable145_0024918_13___0024Action_0024190(from).Invoke;
	}
}
