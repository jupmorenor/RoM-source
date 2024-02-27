using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__IconAtlasPool_removeReqsBySprite_0024callable570_0024783_23___0024Predicate_0024178
{
	protected __IconAtlasPool_removeReqsBySprite_0024callable570_0024783_23__ _0024from;

	public _0024adaptor_0024__IconAtlasPool_removeReqsBySprite_0024callable570_0024783_23___0024Predicate_0024178(__IconAtlasPool_removeReqsBySprite_0024callable570_0024783_23__ from)
	{
		_0024from = from;
	}

	public bool Invoke(IconAtlasPool.Req obj)
	{
		return _0024from(obj);
	}

	public static Predicate<IconAtlasPool.Req> Adapt(__IconAtlasPool_removeReqsBySprite_0024callable570_0024783_23__ from)
	{
		return new _0024adaptor_0024__IconAtlasPool_removeReqsBySprite_0024callable570_0024783_23___0024Predicate_0024178(from).Invoke;
	}
}
