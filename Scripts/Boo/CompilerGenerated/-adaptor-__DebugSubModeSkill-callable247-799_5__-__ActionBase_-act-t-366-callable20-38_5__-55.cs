using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__DebugSubModeSkill_0024callable247_0024799_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002455
{
	protected __DebugSubModeSkill_0024callable247_0024799_5__ _0024from;

	public _0024adaptor_0024__DebugSubModeSkill_0024callable247_0024799_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002455(__DebugSubModeSkill_0024callable247_0024799_5__ from)
	{
		_0024from = from;
	}

	public void Invoke(DebugSubSkill.ActionBase arg0)
	{
		_0024from((DebugSubSkill.ActionClassviewPoppets)arg0);
	}

	public static __ActionBase__0024act_0024t_0024366_0024callable20_002438_5__ Adapt(__DebugSubModeSkill_0024callable247_0024799_5__ from)
	{
		return new _0024adaptor_0024__DebugSubModeSkill_0024callable247_0024799_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002455(from).Invoke;
	}
}
