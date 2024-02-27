using System;

[Serializable]
public class NodeSearch : IComparable<NodeSearch>
{
	private int id;

	public int F;

	public float Fv;

	private bool _0024initialized__NodeSearch_0024;

	public int ID
	{
		get
		{
			return id;
		}
		private set
		{
			id = value;
		}
	}

	public NodeSearch(int i, int f)
	{
		if (!_0024initialized__NodeSearch_0024)
		{
			_0024initialized__NodeSearch_0024 = true;
		}
		id = i;
		F = f;
	}

	public NodeSearch(int i, float f)
	{
		if (!_0024initialized__NodeSearch_0024)
		{
			_0024initialized__NodeSearch_0024 = true;
		}
		id = i;
		Fv = f;
	}

	public virtual int CompareTo(NodeSearch b)
	{
		return F.CompareTo(b.F);
	}
}
