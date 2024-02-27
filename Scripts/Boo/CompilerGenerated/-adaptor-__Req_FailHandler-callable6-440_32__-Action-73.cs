using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__Req_FailHandler_0024callable6_0024440_32___0024Action_002473
{
	protected __Req_FailHandler_0024callable6_0024440_32__ _0024from;

	public _0024adaptor_0024__Req_FailHandler_0024callable6_0024440_32___0024Action_002473(__Req_FailHandler_0024callable6_0024440_32__ from)
	{
		_0024from = from;
	}

	public void Invoke(string arg0)
	{
		_0024from(arg0);
	}

	public static Action<string> Adapt(__Req_FailHandler_0024callable6_0024440_32__ from)
	{
		return new _0024adaptor_0024__Req_FailHandler_0024callable6_0024440_32___0024Action_002473(from).Invoke;
	}
}
