using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__DebugSubModeSystemInfo_0024callable253_0024323_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002460
{
	protected __DebugSubModeSystemInfo_0024callable253_0024323_5__ _0024from;

	public _0024adaptor_0024__DebugSubModeSystemInfo_0024callable253_0024323_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002460(__DebugSubModeSystemInfo_0024callable253_0024323_5__ from)
	{
		_0024from = from;
	}

	public void Invoke(DebugSubSystemInfo.ActionBase arg0)
	{
		_0024from((DebugSubSystemInfo.ActionClassServerClockMode2)arg0);
	}

	public static __ActionBase__0024act_0024t_0024424_0024callable23_002424_5__ Adapt(__DebugSubModeSystemInfo_0024callable253_0024323_5__ from)
	{
		return new _0024adaptor_0024__DebugSubModeSystemInfo_0024callable253_0024323_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002460(from).Invoke;
	}
}
