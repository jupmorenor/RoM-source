using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MerlinServer_Request_0024callable86_0024160_56___0024Action_0024189
{
	protected __MerlinServer_Request_0024callable86_0024160_56__ _0024from;

	public _0024adaptor_0024__MerlinServer_Request_0024callable86_0024160_56___0024Action_0024189(__MerlinServer_Request_0024callable86_0024160_56__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase obj)
	{
		_0024from(obj);
	}

	public static Action<RequestBase> Adapt(__MerlinServer_Request_0024callable86_0024160_56__ from)
	{
		return new _0024adaptor_0024__MerlinServer_Request_0024callable86_0024160_56___0024Action_0024189(from).Invoke;
	}
}
