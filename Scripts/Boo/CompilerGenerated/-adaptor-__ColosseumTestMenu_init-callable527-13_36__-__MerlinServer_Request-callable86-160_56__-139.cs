using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__ColosseumTestMenu_init_0024callable527_002413_36___0024__MerlinServer_Request_0024callable86_0024160_56___0024139
{
	protected __ColosseumTestMenu_init_0024callable527_002413_36__ _0024from;

	public _0024adaptor_0024__ColosseumTestMenu_init_0024callable527_002413_36___0024__MerlinServer_Request_0024callable86_0024160_56___0024139(__ColosseumTestMenu_init_0024callable527_002413_36__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase arg0)
	{
		_0024from((ApiColosseumOpponentList)arg0);
	}

	public static __MerlinServer_Request_0024callable86_0024160_56__ Adapt(__ColosseumTestMenu_init_0024callable527_002413_36__ from)
	{
		return new _0024adaptor_0024__ColosseumTestMenu_init_0024callable527_002413_36___0024__MerlinServer_Request_0024callable86_0024160_56___0024139(from).Invoke;
	}
}
