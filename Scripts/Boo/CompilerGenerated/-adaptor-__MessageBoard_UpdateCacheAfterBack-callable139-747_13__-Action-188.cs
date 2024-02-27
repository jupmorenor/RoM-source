using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MessageBoard_UpdateCacheAfterBack_0024callable139_0024747_13___0024Action_0024188
{
	protected __MessageBoard_UpdateCacheAfterBack_0024callable139_0024747_13__ _0024from;

	public _0024adaptor_0024__MessageBoard_UpdateCacheAfterBack_0024callable139_0024747_13___0024Action_0024188(__MessageBoard_UpdateCacheAfterBack_0024callable139_0024747_13__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase obj)
	{
		_0024from((ApiHomeSlim)obj);
	}

	public static Action<RequestBase> Adapt(__MessageBoard_UpdateCacheAfterBack_0024callable139_0024747_13__ from)
	{
		return new _0024adaptor_0024__MessageBoard_UpdateCacheAfterBack_0024callable139_0024747_13___0024Action_0024188(from).Invoke;
	}
}
