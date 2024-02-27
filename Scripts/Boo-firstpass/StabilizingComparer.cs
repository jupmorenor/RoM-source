using System;
using System.Collections.Generic;

[Serializable]
public class StabilizingComparer<T> : IComparer<StableSortKey>
{
	private readonly Comparison<T> _comparison;

	public StabilizingComparer(Comparison<T> comparison)
	{
		_comparison = comparison;
	}

	public virtual int Compare(StableSortKey x, StableSortKey y)
	{
		Comparison<T> comparison = _comparison;
		object x2 = (object)/*isinst with value type is only supported in some contexts*/;
		object v = y.v;
		int num = comparison((T)x2, (T)((v is T) ? v : null));
		return (num == 0) ? x.k.CompareTo(y.k) : num;
	}
}
