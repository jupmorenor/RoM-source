using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__DebugSubSound_0024callable280_002458_5___0024__ActionBase__0024act_0024t_0024519_0024callable29_002458_5___002481
{
	protected __DebugSubSound_0024callable280_002458_5__ _0024from;

	public _0024adaptor_0024__DebugSubSound_0024callable280_002458_5___0024__ActionBase__0024act_0024t_0024519_0024callable29_002458_5___002481(__DebugSubSound_0024callable280_002458_5__ from)
	{
		_0024from = from;
	}

	public void Invoke(DebugSubSound.ActionBase arg0)
	{
		_0024from((DebugSubSound.ActionClassMainMode)arg0);
	}

	public static __ActionBase__0024act_0024t_0024519_0024callable29_002458_5__ Adapt(__DebugSubSound_0024callable280_002458_5__ from)
	{
		return new _0024adaptor_0024__DebugSubSound_0024callable280_002458_5___0024__ActionBase__0024act_0024t_0024519_0024callable29_002458_5___002481(from).Invoke;
	}
}
