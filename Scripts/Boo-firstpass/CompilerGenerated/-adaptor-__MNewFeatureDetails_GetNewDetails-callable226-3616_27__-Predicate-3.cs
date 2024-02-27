using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MNewFeatureDetails_GetNewDetails_0024callable226_00243616_27___0024Predicate_00243
{
	protected __MNewFeatureDetails_GetNewDetails_0024callable226_00243616_27__ _0024from;

	public _0024adaptor_0024__MNewFeatureDetails_GetNewDetails_0024callable226_00243616_27___0024Predicate_00243(__MNewFeatureDetails_GetNewDetails_0024callable226_00243616_27__ from)
	{
		_0024from = from;
	}

	public bool Invoke(MNewFeatureDetails obj)
	{
		return _0024from(obj);
	}

	public static Predicate<MNewFeatureDetails> Adapt(__MNewFeatureDetails_GetNewDetails_0024callable226_00243616_27__ from)
	{
		return new _0024adaptor_0024__MNewFeatureDetails_GetNewDetails_0024callable226_00243616_27___0024Predicate_00243(from).Invoke;
	}
}
