using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024OnFinished_0024157
{
	protected __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024from;

	public _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024OnFinished_0024157(__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ from)
	{
		_0024from = from;
	}

	public void Invoke(UITweener tw)
	{
		_0024from();
	}

	public static UITweener.OnFinished Adapt(__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ from)
	{
		return new _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024OnFinished_0024157(from).Invoke;
	}
}
