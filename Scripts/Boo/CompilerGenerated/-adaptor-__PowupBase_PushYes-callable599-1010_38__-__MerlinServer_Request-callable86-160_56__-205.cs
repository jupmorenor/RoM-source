using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__PowupBase_PushYes_0024callable599_00241010_38___0024__MerlinServer_Request_0024callable86_0024160_56___0024205
{
	protected __PowupBase_PushYes_0024callable599_00241010_38__ _0024from;

	public _0024adaptor_0024__PowupBase_PushYes_0024callable599_00241010_38___0024__MerlinServer_Request_0024callable86_0024160_56___0024205(__PowupBase_PushYes_0024callable599_00241010_38__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase arg0)
	{
		_0024from((ApiCompositionBase)arg0);
	}

	public static __MerlinServer_Request_0024callable86_0024160_56__ Adapt(__PowupBase_PushYes_0024callable599_00241010_38__ from)
	{
		return new _0024adaptor_0024__PowupBase_PushYes_0024callable599_00241010_38___0024__MerlinServer_Request_0024callable86_0024160_56___0024205(from).Invoke;
	}
}
