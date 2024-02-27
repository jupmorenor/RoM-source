using System;
using Boo.Lang.Runtime;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__FaderCore_0024callable309_0024175_23___0024EventHandler_0024113
{
	protected __FaderCore_0024callable309_0024175_23__ _0024from;

	public _0024adaptor_0024__FaderCore_0024callable309_0024175_23___0024EventHandler_0024113(__FaderCore_0024callable309_0024175_23__ from)
	{
		_0024from = from;
	}

	public void Invoke(object sender, EventArgs e)
	{
		__FaderCore_0024callable309_0024175_23__ _FaderCore_0024callable309_0024175_23__ = _0024from;
		object obj = sender;
		if (!(obj is FaderCore))
		{
			obj = RuntimeServices.Coerce(obj, typeof(FaderCore));
		}
		_FaderCore_0024callable309_0024175_23__((FaderCore)obj);
	}

	public static EventHandler Adapt(__FaderCore_0024callable309_0024175_23__ from)
	{
		return new _0024adaptor_0024__FaderCore_0024callable309_0024175_23___0024EventHandler_0024113(from).Invoke;
	}
}
