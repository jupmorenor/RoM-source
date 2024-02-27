using System;
using Boo.Lang.Runtime;

[Serializable]
public struct BoxId
{
	private long value;

	public bool IsValid => value > 0;

	public static BoxId InvalidId => new BoxId(0L);

	public long Value => value;

	public BoxId(long n)
	{
		value = n;
	}

	public override string ToString()
	{
		return value.ToString();
	}

	public static BoxId[] ToArray(params int[] ns)
	{
		BoxId[] array = new BoxId[ns.Length];
		int num = 0;
		int length = ns.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			ref BoxId reference = ref array[RuntimeServices.NormalizeArrayIndex(array, index)];
			reference = new BoxId(ns[RuntimeServices.NormalizeArrayIndex(ns, index)]);
		}
		return array;
	}

	public override int GetHashCode()
	{
		return value.GetHashCode();
	}

	public override bool Equals(object v)
	{
		Type type = v.GetType();
		int result;
		if (RuntimeServices.EqualityOperator(type, typeof(int)))
		{
			result = ((value == checked((long)RuntimeServices.UnboxInt32(v))) ? 1 : 0);
		}
		else if (RuntimeServices.EqualityOperator(type, typeof(long)))
		{
			result = ((value == RuntimeServices.UnboxInt64(v)) ? 1 : 0);
		}
		else if (RuntimeServices.EqualityOperator(type, typeof(BoxId)))
		{
			long num = value;
			BoxId boxId = (BoxId)v;
			result = ((num == boxId.value) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}
}
