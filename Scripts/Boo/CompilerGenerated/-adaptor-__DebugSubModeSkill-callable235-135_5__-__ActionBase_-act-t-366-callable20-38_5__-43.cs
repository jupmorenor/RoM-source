using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__DebugSubModeSkill_0024callable235_0024135_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002443
{
	protected __DebugSubModeSkill_0024callable235_0024135_5__ _0024from;

	public _0024adaptor_0024__DebugSubModeSkill_0024callable235_0024135_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002443(__DebugSubModeSkill_0024callable235_0024135_5__ from)
	{
		_0024from = from;
	}

	public void Invoke(DebugSubSkill.ActionBase arg0)
	{
		_0024from((DebugSubSkill.ActionClasseditPlayer)arg0);
	}

	public static __ActionBase__0024act_0024t_0024366_0024callable20_002438_5__ Adapt(__DebugSubModeSkill_0024callable235_0024135_5__ from)
	{
		return new _0024adaptor_0024__DebugSubModeSkill_0024callable235_0024135_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002443(from).Invoke;
	}
}
