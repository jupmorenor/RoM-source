using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__DownloadMain_0024callable364_0024273_36___0024Predicate_0024187
{
	protected __DownloadMain_0024callable364_0024273_36__ _0024from;

	public _0024adaptor_0024__DownloadMain_0024callable364_0024273_36___0024Predicate_0024187(__DownloadMain_0024callable364_0024273_36__ from)
	{
		_0024from = from;
	}

	public bool Invoke(DownloadRequest obj)
	{
		return _0024from(obj);
	}

	public static Predicate<DownloadRequest> Adapt(__DownloadMain_0024callable364_0024273_36__ from)
	{
		return new _0024adaptor_0024__DownloadMain_0024callable364_0024273_36___0024Predicate_0024187(from).Invoke;
	}
}
