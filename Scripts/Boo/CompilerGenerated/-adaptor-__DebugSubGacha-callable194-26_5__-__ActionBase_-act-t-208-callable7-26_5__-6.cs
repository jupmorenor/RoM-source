using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__DebugSubGacha_0024callable194_002426_5___0024__ActionBase__0024act_0024t_0024208_0024callable7_002426_5___00246
{
	protected __DebugSubGacha_0024callable194_002426_5__ _0024from;

	public _0024adaptor_0024__DebugSubGacha_0024callable194_002426_5___0024__ActionBase__0024act_0024t_0024208_0024callable7_002426_5___00246(__DebugSubGacha_0024callable194_002426_5__ from)
	{
		_0024from = from;
	}

	public void Invoke(DebugSubGacha.ActionBase arg0)
	{
		_0024from((DebugSubGacha.ActionClassmainMode)arg0);
	}

	public static __ActionBase__0024act_0024t_0024208_0024callable7_002426_5__ Adapt(__DebugSubGacha_0024callable194_002426_5__ from)
	{
		return new _0024adaptor_0024__DebugSubGacha_0024callable194_002426_5___0024__ActionBase__0024act_0024t_0024208_0024callable7_002426_5___00246(from).Invoke;
	}
}
