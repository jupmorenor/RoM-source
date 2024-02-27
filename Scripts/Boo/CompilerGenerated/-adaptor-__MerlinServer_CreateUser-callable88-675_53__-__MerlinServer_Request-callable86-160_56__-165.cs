using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MerlinServer_CreateUser_0024callable88_0024675_53___0024__MerlinServer_Request_0024callable86_0024160_56___0024165
{
	protected __MerlinServer_CreateUser_0024callable88_0024675_53__ _0024from;

	public _0024adaptor_0024__MerlinServer_CreateUser_0024callable88_0024675_53___0024__MerlinServer_Request_0024callable86_0024160_56___0024165(__MerlinServer_CreateUser_0024callable88_0024675_53__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase arg0)
	{
		_0024from((ApiEntryCreateUser)arg0);
	}

	public static __MerlinServer_Request_0024callable86_0024160_56__ Adapt(__MerlinServer_CreateUser_0024callable88_0024675_53__ from)
	{
		return new _0024adaptor_0024__MerlinServer_CreateUser_0024callable88_0024675_53___0024__MerlinServer_Request_0024callable86_0024160_56___0024165(from).Invoke;
	}
}
