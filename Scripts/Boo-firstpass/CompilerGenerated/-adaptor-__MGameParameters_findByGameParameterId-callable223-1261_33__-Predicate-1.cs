using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MGameParameters_findByGameParameterId_0024callable223_00241261_33___0024Predicate_00241
{
	protected __MGameParameters_findByGameParameterId_0024callable223_00241261_33__ _0024from;

	public _0024adaptor_0024__MGameParameters_findByGameParameterId_0024callable223_00241261_33___0024Predicate_00241(__MGameParameters_findByGameParameterId_0024callable223_00241261_33__ from)
	{
		_0024from = from;
	}

	public bool Invoke(MGameParameters obj)
	{
		return _0024from(obj);
	}

	public static Predicate<MGameParameters> Adapt(__MGameParameters_findByGameParameterId_0024callable223_00241261_33__ from)
	{
		return new _0024adaptor_0024__MGameParameters_findByGameParameterId_0024callable223_00241261_33___0024Predicate_00241(from).Invoke;
	}
}
