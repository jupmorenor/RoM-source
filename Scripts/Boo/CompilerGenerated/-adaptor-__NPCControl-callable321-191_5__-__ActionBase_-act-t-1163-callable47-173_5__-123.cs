using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__NPCControl_0024callable321_0024191_5___0024__ActionBase__0024act_0024t_00241163_0024callable47_0024173_5___0024123
{
	protected __NPCControl_0024callable321_0024191_5__ _0024from;

	public _0024adaptor_0024__NPCControl_0024callable321_0024191_5___0024__ActionBase__0024act_0024t_00241163_0024callable47_0024173_5___0024123(__NPCControl_0024callable321_0024191_5__ from)
	{
		_0024from = from;
	}

	public void Invoke(NPCControl.ActionBase arg0)
	{
		_0024from((NPCControl.ActionClasstalk)arg0);
	}

	public static __ActionBase__0024act_0024t_00241163_0024callable47_0024173_5__ Adapt(__NPCControl_0024callable321_0024191_5__ from)
	{
		return new _0024adaptor_0024__NPCControl_0024callable321_0024191_5___0024__ActionBase__0024act_0024t_00241163_0024callable47_0024173_5___0024123(from).Invoke;
	}
}
