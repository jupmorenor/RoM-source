using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__AIControl_0024callable318_0024582_5___0024__ActionBase__0024act_0024t_00241131_0024callable45_0024524_5___0024121
{
	protected __AIControl_0024callable318_0024582_5__ _0024from;

	public _0024adaptor_0024__AIControl_0024callable318_0024582_5___0024__ActionBase__0024act_0024t_00241131_0024callable45_0024524_5___0024121(__AIControl_0024callable318_0024582_5__ from)
	{
		_0024from = from;
	}

	public void Invoke(AIControl.ActionBase arg0)
	{
		_0024from((AIControl.ActionClassAIMODE_Battle)arg0);
	}

	public static __ActionBase__0024act_0024t_00241131_0024callable45_0024524_5__ Adapt(__AIControl_0024callable318_0024582_5__ from)
	{
		return new _0024adaptor_0024__AIControl_0024callable318_0024582_5___0024__ActionBase__0024act_0024t_00241131_0024callable45_0024524_5___0024121(from).Invoke;
	}
}
