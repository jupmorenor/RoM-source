using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024EventHandler_0024156
{
	protected __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024from;

	public _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024EventHandler_0024156(__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ from)
	{
		_0024from = from;
	}

	public void Invoke(object arg0)
	{
		_0024from();
	}

	public static UpdateManager.EventHandler Adapt(__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ from)
	{
		return new _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024EventHandler_0024156(from).Invoke;
	}
}
