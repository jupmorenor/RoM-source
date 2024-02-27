using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MerlinServer_Home_0024callable87_0024671_34___0024__MerlinServer_Request_0024callable86_0024160_56___0024108
{
	protected __MerlinServer_Home_0024callable87_0024671_34__ _0024from;

	public _0024adaptor_0024__MerlinServer_Home_0024callable87_0024671_34___0024__MerlinServer_Request_0024callable86_0024160_56___0024108(__MerlinServer_Home_0024callable87_0024671_34__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase arg0)
	{
		_0024from((ApiHome)arg0);
	}

	public static __MerlinServer_Request_0024callable86_0024160_56__ Adapt(__MerlinServer_Home_0024callable87_0024671_34__ from)
	{
		return new _0024adaptor_0024__MerlinServer_Home_0024callable87_0024671_34___0024__MerlinServer_Request_0024callable86_0024160_56___0024108(from).Invoke;
	}
}
