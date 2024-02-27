using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__DebugSubGacha_Init_0024callable381_002416_59___0024__MerlinServer_Request_0024callable86_0024160_56___00245
{
	protected __DebugSubGacha_Init_0024callable381_002416_59__ _0024from;

	public _0024adaptor_0024__DebugSubGacha_Init_0024callable381_002416_59___0024__MerlinServer_Request_0024callable86_0024160_56___00245(__DebugSubGacha_Init_0024callable381_002416_59__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase arg0)
	{
		_0024from((ApiPurchaseProductIdList)arg0);
	}

	public static __MerlinServer_Request_0024callable86_0024160_56__ Adapt(__DebugSubGacha_Init_0024callable381_002416_59__ from)
	{
		return new _0024adaptor_0024__DebugSubGacha_Init_0024callable381_002416_59___0024__MerlinServer_Request_0024callable86_0024160_56___00245(from).Invoke;
	}
}
