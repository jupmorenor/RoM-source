using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__DebugSubUserData_0024callable288_0024466_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002489
{
	protected __DebugSubUserData_0024callable288_0024466_5__ _0024from;

	public _0024adaptor_0024__DebugSubUserData_0024callable288_0024466_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002489(__DebugSubUserData_0024callable288_0024466_5__ from)
	{
		_0024from = from;
	}

	public void Invoke(DebugSubUserData.ActionBase arg0)
	{
		_0024from((DebugSubUserData.ActionClassFlagMode)arg0);
	}

	public static __ActionBase__0024act_0024t_0024563_0024callable33_0024179_5__ Adapt(__DebugSubUserData_0024callable288_0024466_5__ from)
	{
		return new _0024adaptor_0024__DebugSubUserData_0024callable288_0024466_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002489(from).Invoke;
	}
}
