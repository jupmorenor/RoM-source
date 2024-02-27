using System;

[Serializable]
public class StableSortKey
{
	public int k;

	public object v;

	public StableSortKey(int _k, object _v)
	{
		k = _k;
		v = _v;
	}
}
