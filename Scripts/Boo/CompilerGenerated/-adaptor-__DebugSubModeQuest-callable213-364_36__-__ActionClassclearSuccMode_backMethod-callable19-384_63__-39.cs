using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__DebugSubModeQuest_0024callable213_0024364_36___0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___002439
{
	protected __DebugSubModeQuest_0024callable213_0024364_36__ _0024from;

	public _0024adaptor_0024__DebugSubModeQuest_0024callable213_0024364_36___0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___002439(__DebugSubModeQuest_0024callable213_0024364_36__ from)
	{
		_0024from = from;
	}

	public void Invoke()
	{
		_0024from();
	}

	public static __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ Adapt(__DebugSubModeQuest_0024callable213_0024364_36__ from)
	{
		return new _0024adaptor_0024__DebugSubModeQuest_0024callable213_0024364_36___0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___002439(from).Invoke;
	}
}
