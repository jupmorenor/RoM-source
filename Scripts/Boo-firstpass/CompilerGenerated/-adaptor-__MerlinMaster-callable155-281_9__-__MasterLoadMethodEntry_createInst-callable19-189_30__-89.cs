using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MerlinMaster_0024callable155_0024281_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002489
{
	protected __MerlinMaster_0024callable155_0024281_9__ _0024from;

	public _0024adaptor_0024__MerlinMaster_0024callable155_0024281_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002489(__MerlinMaster_0024callable155_0024281_9__ from)
	{
		_0024from = from;
	}

	public MerlinMaster Invoke()
	{
		return _0024from();
	}

	public static __MasterLoadMethodEntry_createInst_0024callable19_0024189_30__ Adapt(__MerlinMaster_0024callable155_0024281_9__ from)
	{
		return new _0024adaptor_0024__MerlinMaster_0024callable155_0024281_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002489(from).Invoke;
	}
}
