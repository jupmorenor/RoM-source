using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__DebugSubUserData_0024callable299_0024874_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024100
{
	protected __DebugSubUserData_0024callable299_0024874_5__ _0024from;

	public _0024adaptor_0024__DebugSubUserData_0024callable299_0024874_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024100(__DebugSubUserData_0024callable299_0024874_5__ from)
	{
		_0024from = from;
	}

	public void Invoke(DebugSubUserData.ActionBase arg0)
	{
		_0024from((DebugSubUserData.ActionClassuserDataLoadMain)arg0);
	}

	public static __ActionBase__0024act_0024t_0024563_0024callable33_0024179_5__ Adapt(__DebugSubUserData_0024callable299_0024874_5__ from)
	{
		return new _0024adaptor_0024__DebugSubUserData_0024callable299_0024874_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024100(from).Invoke;
	}
}
