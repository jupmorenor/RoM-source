using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__IconAtlasPool_0024callable359_0024643_30___0024Predicate_0024177
{
	protected __IconAtlasPool_0024callable359_0024643_30__ _0024from;

	public _0024adaptor_0024__IconAtlasPool_0024callable359_0024643_30___0024Predicate_0024177(__IconAtlasPool_0024callable359_0024643_30__ from)
	{
		_0024from = from;
	}

	public bool Invoke(IconAtlasPool.Atlas obj)
	{
		return _0024from(obj);
	}

	public static Predicate<IconAtlasPool.Atlas> Adapt(__IconAtlasPool_0024callable359_0024643_30__ from)
	{
		return new _0024adaptor_0024__IconAtlasPool_0024callable359_0024643_30___0024Predicate_0024177(from).Invoke;
	}
}
