using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__DebugSubModeMaster_0024callable206_0024158_5___0024__ActionBase__0024act_0024t_0024265_0024callable13_002419_5___002415
{
	protected __DebugSubModeMaster_0024callable206_0024158_5__ _0024from;

	public _0024adaptor_0024__DebugSubModeMaster_0024callable206_0024158_5___0024__ActionBase__0024act_0024t_0024265_0024callable13_002419_5___002415(__DebugSubModeMaster_0024callable206_0024158_5__ from)
	{
		_0024from = from;
	}

	public void Invoke(DebugSubModeMaster.ActionBase arg0)
	{
		_0024from((DebugSubModeMaster.ActionClassweekEventEditMode)arg0);
	}

	public static __ActionBase__0024act_0024t_0024265_0024callable13_002419_5__ Adapt(__DebugSubModeMaster_0024callable206_0024158_5__ from)
	{
		return new _0024adaptor_0024__DebugSubModeMaster_0024callable206_0024158_5___0024__ActionBase__0024act_0024t_0024265_0024callable13_002419_5___002415(from).Invoke;
	}
}
