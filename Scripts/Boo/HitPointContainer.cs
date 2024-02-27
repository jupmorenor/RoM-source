using System;
using System.Collections.Generic;
using System.Text;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class HitPointContainer
{
	[Serializable]
	private class SingleValue
	{
		private byte[] _values;

		private int _key;

		[NonSerialized]
		private static byte[] _work = new byte[4];

		[NonSerialized]
		private static Queue<SingleValue> unuses = new Queue<SingleValue>();

		[NonSerialized]
		private static int _totalCount;

		public float Value
		{
			get
			{
				int num = 0;
				while (num < 4)
				{
					int index = num;
					num++;
					byte[] work = _work;
					int num2 = RuntimeServices.NormalizeArrayIndex(work, index);
					byte[] values = _values;
					checked
					{
						work[num2] = (byte)(unchecked((int)values[RuntimeServices.NormalizeArrayIndex(values, index)]) ^ _key);
					}
				}
				return BitConverter.ToSingle(_work, 0);
			}
			set
			{
				init(value);
			}
		}

		private SingleValue()
		{
			init();
		}

		private SingleValue(float val)
		{
			init(val);
		}

		private SingleValue(SingleValue sv)
		{
			if (sv != null)
			{
				init(sv.Value);
			}
			else
			{
				init();
			}
		}

		public void init()
		{
			init(100f);
		}

		public void init(float val)
		{
			_values = BitConverter.GetBytes(val);
			_key = UnityEngine.Random.Range(0, 255);
			if (_values.Length != 4)
			{
				throw new AssertionFailedException("len(_values) == 4");
			}
			int num = 0;
			while (num < 4)
			{
				int index = num;
				num++;
				byte[] values = _values;
				int num2 = RuntimeServices.NormalizeArrayIndex(values, index);
				byte[] values2 = _values;
				checked
				{
					values[num2] = (byte)(unchecked((int)values2[RuntimeServices.NormalizeArrayIndex(values2, index)]) ^ _key);
				}
			}
		}

		public static SingleValue Refresh(SingleValue sv)
		{
			SingleValue singleValue = New();
			if (sv != null)
			{
				singleValue.init(sv.Value);
				Discard(sv);
			}
			return singleValue;
		}

		public static SingleValue New()
		{
			SingleValue singleValue = null;
			checked
			{
				if (unuses.Count > 0)
				{
					singleValue = unuses.Dequeue();
				}
				else
				{
					singleValue = new SingleValue();
					_totalCount++;
				}
				return singleValue;
			}
		}

		public static void Discard(SingleValue sv)
		{
			if (sv != null)
			{
				sv.init();
				unuses.Enqueue(sv);
			}
		}

		public static string Info()
		{
			return new StringBuilder("unuses:").Append((object)unuses.Count).Append(" _totalCount:").Append((object)_totalCount)
				.ToString();
		}
	}

	private SingleValue current;

	private SingleValue max;

	public float Current
	{
		get
		{
			if (current == null)
			{
				current = SingleValue.New();
			}
			return current.Value;
		}
		set
		{
			current = SingleValue.Refresh(current);
			current.Value = value;
		}
	}

	public float Max
	{
		get
		{
			if (max == null)
			{
				max = SingleValue.New();
			}
			return max.Value;
		}
		set
		{
			max = SingleValue.Refresh(max);
			max.Value = value;
		}
	}

	public void discard()
	{
		SingleValue.Discard(current);
		SingleValue.Discard(max);
		current = null;
		max = null;
	}

	public override string ToString()
	{
		return new StringBuilder("HitPointContainer(").Append(Current).Append("/").Append(Max)
			.Append(")")
			.ToString();
	}

	public static string Info()
	{
		return SingleValue.Info();
	}
}
