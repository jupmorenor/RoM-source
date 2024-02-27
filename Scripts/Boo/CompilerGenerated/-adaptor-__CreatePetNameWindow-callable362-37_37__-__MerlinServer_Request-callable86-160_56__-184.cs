using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__CreatePetNameWindow_0024callable362_002437_37___0024__MerlinServer_Request_0024callable86_0024160_56___0024184
{
	protected __CreatePetNameWindow_0024callable362_002437_37__ _0024from;

	public _0024adaptor_0024__CreatePetNameWindow_0024callable362_002437_37___0024__MerlinServer_Request_0024callable86_0024160_56___0024184(__CreatePetNameWindow_0024callable362_002437_37__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase arg0)
	{
		_0024from((ApiUpdatePoppetName)arg0);
	}

	public static __MerlinServer_Request_0024callable86_0024160_56__ Adapt(__CreatePetNameWindow_0024callable362_002437_37__ from)
	{
		return new _0024adaptor_0024__CreatePetNameWindow_0024callable362_002437_37___0024__MerlinServer_Request_0024callable86_0024160_56___0024184(from).Invoke;
	}
}
