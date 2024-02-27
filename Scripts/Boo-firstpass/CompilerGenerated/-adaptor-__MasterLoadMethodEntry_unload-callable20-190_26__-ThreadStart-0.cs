using System;
using System.Threading;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MasterLoadMethodEntry_unload_0024callable20_0024190_26___0024ThreadStart_00240
{
	protected __MasterLoadMethodEntry_unload_0024callable20_0024190_26__ _0024from;

	public _0024adaptor_0024__MasterLoadMethodEntry_unload_0024callable20_0024190_26___0024ThreadStart_00240(__MasterLoadMethodEntry_unload_0024callable20_0024190_26__ from)
	{
		_0024from = from;
	}

	public void Invoke()
	{
		_0024from();
	}

	public static ThreadStart Adapt(__MasterLoadMethodEntry_unload_0024callable20_0024190_26__ from)
	{
		return new _0024adaptor_0024__MasterLoadMethodEntry_unload_0024callable20_0024190_26___0024ThreadStart_00240(from).Invoke;
	}
}
