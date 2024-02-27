using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__ArrayMapMain_FilterResps_0024callable116_002441_67___0024Func_0024168
{
	protected __ArrayMapMain_FilterResps_0024callable116_002441_67__ _0024from;

	public _0024adaptor_0024__ArrayMapMain_FilterResps_0024callable116_002441_67___0024Func_0024168(__ArrayMapMain_FilterResps_0024callable116_002441_67__ from)
	{
		_0024from = from;
	}

	public bool Invoke(RespMember arg1)
	{
		return _0024from(arg1);
	}

	public static Func<RespMember, bool> Adapt(__ArrayMapMain_FilterResps_0024callable116_002441_67__ from)
	{
		return new _0024adaptor_0024__ArrayMapMain_FilterResps_0024callable116_002441_67___0024Func_0024168(from).Invoke;
	}
}
