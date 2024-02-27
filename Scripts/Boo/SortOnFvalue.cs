using System;
using System.Collections.Generic;

[Serializable]
public class SortOnFvalue : IComparer<NodeSearch>
{
	public virtual int Compare(NodeSearch a, NodeSearch b)
	{
		return (a.F > b.F) ? 1 : ((a.F < b.F) ? (-1) : 0);
	}
}
