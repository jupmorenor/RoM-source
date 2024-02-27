using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__NPCControl_0024callable322_0024199_5___0024__ActionBase__0024act_0024t_00241163_0024callable47_0024173_5___0024124
{
	protected __NPCControl_0024callable322_0024199_5__ _0024from;

	public _0024adaptor_0024__NPCControl_0024callable322_0024199_5___0024__ActionBase__0024act_0024t_00241163_0024callable47_0024173_5___0024124(__NPCControl_0024callable322_0024199_5__ from)
	{
		_0024from = from;
	}

	public void Invoke(NPCControl.ActionBase arg0)
	{
		_0024from((NPCControl.ActionClasswalk)arg0);
	}

	public static __ActionBase__0024act_0024t_00241163_0024callable47_0024173_5__ Adapt(__NPCControl_0024callable322_0024199_5__ from)
	{
		return new _0024adaptor_0024__NPCControl_0024callable322_0024199_5___0024__ActionBase__0024act_0024t_00241163_0024callable47_0024173_5___0024124(from).Invoke;
	}
}
