using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MessageBoard_PushFriendSearch_0024callable145_0024918_13___0024__MerlinServer_Request_0024callable86_0024160_56___0024212
{
	protected __MessageBoard_PushFriendSearch_0024callable145_0024918_13__ _0024from;

	public _0024adaptor_0024__MessageBoard_PushFriendSearch_0024callable145_0024918_13___0024__MerlinServer_Request_0024callable86_0024160_56___0024212(__MessageBoard_PushFriendSearch_0024callable145_0024918_13__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase arg0)
	{
		_0024from((ApiFriendPlayerSearch)arg0);
	}

	public static __MerlinServer_Request_0024callable86_0024160_56__ Adapt(__MessageBoard_PushFriendSearch_0024callable145_0024918_13__ from)
	{
		return new _0024adaptor_0024__MessageBoard_PushFriendSearch_0024callable145_0024918_13___0024__MerlinServer_Request_0024callable86_0024160_56___0024212(from).Invoke;
	}
}
