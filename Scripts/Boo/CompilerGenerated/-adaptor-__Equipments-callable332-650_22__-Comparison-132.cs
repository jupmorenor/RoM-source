using System;
using System.Collections.Generic;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__Equipments_0024callable332_0024650_22___0024Comparison_0024132
{
	protected __Equipments_0024callable332_0024650_22__ _0024from;

	public _0024adaptor_0024__Equipments_0024callable332_0024650_22___0024Comparison_0024132(__Equipments_0024callable332_0024650_22__ from)
	{
		_0024from = from;
	}

	public int Invoke(KeyValuePair<int[], float> x, KeyValuePair<int[], float> y)
	{
		return checked((int)_0024from(x, y));
	}

	public static Comparison<KeyValuePair<int[], float>> Adapt(__Equipments_0024callable332_0024650_22__ from)
	{
		return new _0024adaptor_0024__Equipments_0024callable332_0024650_22___0024Comparison_0024132(from).Invoke;
	}
}
