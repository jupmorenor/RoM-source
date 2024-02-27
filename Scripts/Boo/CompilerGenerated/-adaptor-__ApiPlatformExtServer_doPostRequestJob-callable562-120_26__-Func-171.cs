using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__ApiPlatformExtServer_doPostRequestJob_0024callable562_0024120_26___0024Func_0024171
{
	protected __ApiPlatformExtServer_doPostRequestJob_0024callable562_0024120_26__ _0024from;

	public _0024adaptor_0024__ApiPlatformExtServer_doPostRequestJob_0024callable562_0024120_26___0024Func_0024171(__ApiPlatformExtServer_doPostRequestJob_0024callable562_0024120_26__ from)
	{
		_0024from = from;
	}

	public bool Invoke(ApiPlatformExtServer.RespExtServer arg1)
	{
		return _0024from(arg1);
	}

	public static Func<ApiPlatformExtServer.RespExtServer, bool> Adapt(__ApiPlatformExtServer_doPostRequestJob_0024callable562_0024120_26__ from)
	{
		return new _0024adaptor_0024__ApiPlatformExtServer_doPostRequestJob_0024callable562_0024120_26___0024Func_0024171(from).Invoke;
	}
}
