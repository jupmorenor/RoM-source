using System;
using System.Collections;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__AIControl_0024callable317_0024551_5___0024__ActionBase__0024act_0024t_00241137_0024callable46_0024524_5___0024120
{
	protected __AIControl_0024callable317_0024551_5__ _0024from;

	public _0024adaptor_0024__AIControl_0024callable317_0024551_5___0024__ActionBase__0024act_0024t_00241137_0024callable46_0024524_5___0024120(__AIControl_0024callable317_0024551_5__ from)
	{
		_0024from = from;
	}

	public IEnumerator Invoke(AIControl.ActionBase arg0)
	{
		return _0024from((AIControl.ActionClassAIMODE_ChasePlayer)arg0);
	}

	public static __ActionBase__0024act_0024t_00241137_0024callable46_0024524_5__ Adapt(__AIControl_0024callable317_0024551_5__ from)
	{
		return new _0024adaptor_0024__AIControl_0024callable317_0024551_5___0024__ActionBase__0024act_0024t_00241137_0024callable46_0024524_5___0024120(from).Invoke;
	}
}
