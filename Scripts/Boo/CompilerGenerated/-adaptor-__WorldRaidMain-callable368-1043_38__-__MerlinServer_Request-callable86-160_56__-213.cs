using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__WorldRaidMain_0024callable368_00241043_38___0024__MerlinServer_Request_0024callable86_0024160_56___0024213
{
	protected __WorldRaidMain_0024callable368_00241043_38__ _0024from;

	public _0024adaptor_0024__WorldRaidMain_0024callable368_00241043_38___0024__MerlinServer_Request_0024callable86_0024160_56___0024213(__WorldRaidMain_0024callable368_00241043_38__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase arg0)
	{
		_0024from((ApiGuildRaidStart)arg0);
	}

	public static __MerlinServer_Request_0024callable86_0024160_56__ Adapt(__WorldRaidMain_0024callable368_00241043_38__ from)
	{
		return new _0024adaptor_0024__WorldRaidMain_0024callable368_00241043_38___0024__MerlinServer_Request_0024callable86_0024160_56___0024213(from).Invoke;
	}
}
