using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__DebugSubWebView_0024callable308_0024117_5___0024__ActionBase__0024act_0024t_0024647_0024callable36_002450_5___0024112
{
	protected __DebugSubWebView_0024callable308_0024117_5__ _0024from;

	public _0024adaptor_0024__DebugSubWebView_0024callable308_0024117_5___0024__ActionBase__0024act_0024t_0024647_0024callable36_002450_5___0024112(__DebugSubWebView_0024callable308_0024117_5__ from)
	{
		_0024from = from;
	}

	public void Invoke(DebugSubWebView.ActionBase arg0)
	{
		_0024from((DebugSubWebView.ActionClasswebReqMode)arg0);
	}

	public static __ActionBase__0024act_0024t_0024647_0024callable36_002450_5__ Adapt(__DebugSubWebView_0024callable308_0024117_5__ from)
	{
		return new _0024adaptor_0024__DebugSubWebView_0024callable308_0024117_5___0024__ActionBase__0024act_0024t_0024647_0024callable36_002450_5___0024112(from).Invoke;
	}
}