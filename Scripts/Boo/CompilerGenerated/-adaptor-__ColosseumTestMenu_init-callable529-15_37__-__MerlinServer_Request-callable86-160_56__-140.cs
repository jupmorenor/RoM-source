using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__ColosseumTestMenu_init_0024callable529_002415_37___0024__MerlinServer_Request_0024callable86_0024160_56___0024140
{
	protected __ColosseumTestMenu_init_0024callable529_002415_37__ _0024from;

	public _0024adaptor_0024__ColosseumTestMenu_init_0024callable529_002415_37___0024__MerlinServer_Request_0024callable86_0024160_56___0024140(__ColosseumTestMenu_init_0024callable529_002415_37__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase arg0)
	{
		_0024from((ApiColosseumFriendOpponentList)arg0);
	}

	public static __MerlinServer_Request_0024callable86_0024160_56__ Adapt(__ColosseumTestMenu_init_0024callable529_002415_37__ from)
	{
		return new _0024adaptor_0024__ColosseumTestMenu_init_0024callable529_002415_37___0024__MerlinServer_Request_0024callable86_0024160_56___0024140(from).Invoke;
	}
}