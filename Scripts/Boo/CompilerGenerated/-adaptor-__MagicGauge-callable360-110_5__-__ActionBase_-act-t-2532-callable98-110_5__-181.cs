using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MagicGauge_0024callable360_0024110_5___0024__ActionBase__0024act_0024t_00242532_0024callable98_0024110_5___0024181
{
	protected __MagicGauge_0024callable360_0024110_5__ _0024from;

	public _0024adaptor_0024__MagicGauge_0024callable360_0024110_5___0024__ActionBase__0024act_0024t_00242532_0024callable98_0024110_5___0024181(__MagicGauge_0024callable360_0024110_5__ from)
	{
		_0024from = from;
	}

	public void Invoke(MagicGauge.ActionBase arg0)
	{
		_0024from((MagicGauge.ActionClassMagicPointDisplayMode)arg0);
	}

	public static __ActionBase__0024act_0024t_00242532_0024callable98_0024110_5__ Adapt(__MagicGauge_0024callable360_0024110_5__ from)
	{
		return new _0024adaptor_0024__MagicGauge_0024callable360_0024110_5___0024__ActionBase__0024act_0024t_00242532_0024callable98_0024110_5___0024181(from).Invoke;
	}
}
