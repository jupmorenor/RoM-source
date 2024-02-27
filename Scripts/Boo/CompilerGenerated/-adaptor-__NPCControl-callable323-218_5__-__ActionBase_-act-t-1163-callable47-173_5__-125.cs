using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__NPCControl_0024callable323_0024218_5___0024__ActionBase__0024act_0024t_00241163_0024callable47_0024173_5___0024125
{
	protected __NPCControl_0024callable323_0024218_5__ _0024from;

	public _0024adaptor_0024__NPCControl_0024callable323_0024218_5___0024__ActionBase__0024act_0024t_00241163_0024callable47_0024173_5___0024125(__NPCControl_0024callable323_0024218_5__ from)
	{
		_0024from = from;
	}

	public void Invoke(NPCControl.ActionBase arg0)
	{
		_0024from((NPCControl.ActionClassrun)arg0);
	}

	public static __ActionBase__0024act_0024t_00241163_0024callable47_0024173_5__ Adapt(__NPCControl_0024callable323_0024218_5__ from)
	{
		return new _0024adaptor_0024__NPCControl_0024callable323_0024218_5___0024__ActionBase__0024act_0024t_00241163_0024callable47_0024173_5___0024125(from).Invoke;
	}
}
