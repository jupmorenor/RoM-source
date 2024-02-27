using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__CreateUserIDMain_0024callable363_0024202_65___0024__MerlinServer_Request_0024callable86_0024160_56___0024185
{
	protected __CreateUserIDMain_0024callable363_0024202_65__ _0024from;

	public _0024adaptor_0024__CreateUserIDMain_0024callable363_0024202_65___0024__MerlinServer_Request_0024callable86_0024160_56___0024185(__CreateUserIDMain_0024callable363_0024202_65__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase arg0)
	{
		_0024from((ApiWebFriendInviteInput)arg0);
	}

	public static __MerlinServer_Request_0024callable86_0024160_56__ Adapt(__CreateUserIDMain_0024callable363_0024202_65__ from)
	{
		return new _0024adaptor_0024__CreateUserIDMain_0024callable363_0024202_65___0024__MerlinServer_Request_0024callable86_0024160_56___0024185(from).Invoke;
	}
}
