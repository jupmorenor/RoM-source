using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MerlinMaster_0024callable79_0024205_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002413
{
	protected __MerlinMaster_0024callable79_0024205_9__ _0024from;

	public _0024adaptor_0024__MerlinMaster_0024callable79_0024205_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002413(__MerlinMaster_0024callable79_0024205_9__ from)
	{
		_0024from = from;
	}

	public MerlinMaster Invoke()
	{
		return _0024from();
	}

	public static __MasterLoadMethodEntry_createInst_0024callable19_0024189_30__ Adapt(__MerlinMaster_0024callable79_0024205_9__ from)
	{
		return new _0024adaptor_0024__MerlinMaster_0024callable79_0024205_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002413(from).Invoke;
	}
}
