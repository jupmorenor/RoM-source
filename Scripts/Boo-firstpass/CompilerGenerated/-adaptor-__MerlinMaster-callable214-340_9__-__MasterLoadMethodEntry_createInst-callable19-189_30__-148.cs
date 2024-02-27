using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MerlinMaster_0024callable214_0024340_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024148
{
	protected __MerlinMaster_0024callable214_0024340_9__ _0024from;

	public _0024adaptor_0024__MerlinMaster_0024callable214_0024340_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024148(__MerlinMaster_0024callable214_0024340_9__ from)
	{
		_0024from = from;
	}

	public MerlinMaster Invoke()
	{
		return _0024from();
	}

	public static __MasterLoadMethodEntry_createInst_0024callable19_0024189_30__ Adapt(__MerlinMaster_0024callable214_0024340_9__ from)
	{
		return new _0024adaptor_0024__MerlinMaster_0024callable214_0024340_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024148(from).Invoke;
	}
}
