using System;

namespace Photon.SocketServer.Numeric;

internal class BigInteger
{
	private const int maxLength = 70;

	public static readonly int[] primesBelow2000 = new int[303]
	{
		2, 3, 5, 7, 11, 13, 17, 19, 23, 29,
		31, 37, 41, 43, 47, 53, 59, 61, 67, 71,
		73, 79, 83, 89, 97, 101, 103, 107, 109, 113,
		127, 131, 137, 139, 149, 151, 157, 163, 167, 173,
		179, 181, 191, 193, 197, 199, 211, 223, 227, 229,
		233, 239, 241, 251, 257, 263, 269, 271, 277, 281,
		283, 293, 307, 311, 313, 317, 331, 337, 347, 349,
		353, 359, 367, 373, 379, 383, 389, 397, 401, 409,
		419, 421, 431, 433, 439, 443, 449, 457, 461, 463,
		467, 479, 487, 491, 499, 503, 509, 521, 523, 541,
		547, 557, 563, 569, 571, 577, 587, 593, 599, 601,
		607, 613, 617, 619, 631, 641, 643, 647, 653, 659,
		661, 673, 677, 683, 691, 701, 709, 719, 727, 733,
		739, 743, 751, 757, 761, 769, 773, 787, 797, 809,
		811, 821, 823, 827, 829, 839, 853, 857, 859, 863,
		877, 881, 883, 887, 907, 911, 919, 929, 937, 941,
		947, 953, 967, 971, 977, 983, 991, 997, 1009, 1013,
		1019, 1021, 1031, 1033, 1039, 1049, 1051, 1061, 1063, 1069,
		1087, 1091, 1093, 1097, 1103, 1109, 1117, 1123, 1129, 1151,
		1153, 1163, 1171, 1181, 1187, 1193, 1201, 1213, 1217, 1223,
		1229, 1231, 1237, 1249, 1259, 1277, 1279, 1283, 1289, 1291,
		1297, 1301, 1303, 1307, 1319, 1321, 1327, 1361, 1367, 1373,
		1381, 1399, 1409, 1423, 1427, 1429, 1433, 1439, 1447, 1451,
		1453, 1459, 1471, 1481, 1483, 1487, 1489, 1493, 1499, 1511,
		1523, 1531, 1543, 1549, 1553, 1559, 1567, 1571, 1579, 1583,
		1597, 1601, 1607, 1609, 1613, 1619, 1621, 1627, 1637, 1657,
		1663, 1667, 1669, 1693, 1697, 1699, 1709, 1721, 1723, 1733,
		1741, 1747, 1753, 1759, 1777, 1783, 1787, 1789, 1801, 1811,
		1823, 1831, 1847, 1861, 1867, 1871, 1873, 1877, 1879, 1889,
		1901, 1907, 1913, 1931, 1933, 1949, 1951, 1973, 1979, 1987,
		1993, 1997, 1999
	};

	private uint[] data = null;

	public int dataLength;

	public BigInteger()
	{
		data = new uint[70];
		dataLength = 1;
	}

	public BigInteger(long value)
	{
		data = new uint[70];
		long num = value;
		dataLength = 0;
		while (value != 0 && dataLength < 70)
		{
			data[dataLength] = (uint)(value & 0xFFFFFFFFu);
			value >>= 32;
			dataLength++;
		}
		if (num > 0)
		{
			if (value != 0 || (data[69] & 0x80000000u) != 0)
			{
				throw new ArithmeticException("Positive overflow in constructor.");
			}
		}
		else if (num < 0 && (value != -1 || (data[dataLength - 1] & 0x80000000u) == 0))
		{
			throw new ArithmeticException("Negative underflow in constructor.");
		}
		if (dataLength == 0)
		{
			dataLength = 1;
		}
	}

	public BigInteger(BigInteger bi)
	{
		data = new uint[70];
		dataLength = bi.dataLength;
		for (int i = 0; i < dataLength; i++)
		{
			data[i] = bi.data[i];
		}
	}

	public BigInteger(byte[] inData)
	{
		dataLength = inData.Length >> 2;
		int num = inData.Length & 3;
		if (num != 0)
		{
			dataLength++;
		}
		if (dataLength > 70)
		{
			throw new ArithmeticException("Byte overflow in constructor.");
		}
		data = new uint[70];
		int num2 = inData.Length - 1;
		int num3 = 0;
		while (num2 >= 3)
		{
			data[num3] = (uint)((inData[num2 - 3] << 24) + (inData[num2 - 2] << 16) + (inData[num2 - 1] << 8) + inData[num2]);
			num2 -= 4;
			num3++;
		}
		switch (num)
		{
		case 1:
			data[dataLength - 1] = inData[0];
			break;
		case 2:
			data[dataLength - 1] = (uint)((inData[0] << 8) + inData[1]);
			break;
		case 3:
			data[dataLength - 1] = (uint)((inData[0] << 16) + (inData[1] << 8) + inData[2]);
			break;
		}
		while (dataLength > 1 && data[dataLength - 1] == 0)
		{
			dataLength--;
		}
	}

	public BigInteger(uint[] inData)
	{
		dataLength = inData.Length;
		if (dataLength > 70)
		{
			throw new ArithmeticException("Byte overflow in constructor.");
		}
		data = new uint[70];
		int num = dataLength - 1;
		int num2 = 0;
		while (num >= 0)
		{
			data[num2] = inData[num];
			num--;
			num2++;
		}
		while (dataLength > 1 && data[dataLength - 1] == 0)
		{
			dataLength--;
		}
	}

	public static implicit operator BigInteger(long value)
	{
		return new BigInteger(value);
	}

	public static implicit operator BigInteger(int value)
	{
		return new BigInteger(value);
	}

	public static BigInteger operator +(BigInteger bi1, BigInteger bi2)
	{
		BigInteger bigInteger = new BigInteger();
		bigInteger.dataLength = ((bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength);
		long num = 0L;
		for (int i = 0; i < bigInteger.dataLength; i++)
		{
			long num2 = (long)bi1.data[i] + (long)bi2.data[i] + num;
			num = num2 >> 32;
			bigInteger.data[i] = (uint)(num2 & 0xFFFFFFFFu);
		}
		if (num != 0 && bigInteger.dataLength < 70)
		{
			bigInteger.data[bigInteger.dataLength] = (uint)num;
			bigInteger.dataLength++;
		}
		while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0)
		{
			bigInteger.dataLength--;
		}
		int num3 = 69;
		if ((bi1.data[num3] & 0x80000000u) == (bi2.data[num3] & 0x80000000u) && (bigInteger.data[num3] & 0x80000000u) != (bi1.data[num3] & 0x80000000u))
		{
			throw new ArithmeticException();
		}
		return bigInteger;
	}

	public static BigInteger operator -(BigInteger bi1, BigInteger bi2)
	{
		BigInteger bigInteger = new BigInteger();
		bigInteger.dataLength = ((bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength);
		long num = 0L;
		for (int i = 0; i < bigInteger.dataLength; i++)
		{
			long num2 = (long)bi1.data[i] - (long)bi2.data[i] - num;
			bigInteger.data[i] = (uint)(num2 & 0xFFFFFFFFu);
			num = ((num2 >= 0) ? 0 : 1);
		}
		if (num != 0)
		{
			for (int i = bigInteger.dataLength; i < 70; i++)
			{
				bigInteger.data[i] = uint.MaxValue;
			}
			bigInteger.dataLength = 70;
		}
		while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0)
		{
			bigInteger.dataLength--;
		}
		int num3 = 69;
		if ((bi1.data[num3] & 0x80000000u) != (bi2.data[num3] & 0x80000000u) && (bigInteger.data[num3] & 0x80000000u) != (bi1.data[num3] & 0x80000000u))
		{
			throw new ArithmeticException();
		}
		return bigInteger;
	}

	public static BigInteger operator *(BigInteger bi1, BigInteger bi2)
	{
		int num = 69;
		bool flag = false;
		bool flag2 = false;
		try
		{
			if ((bi1.data[num] & 0x80000000u) != 0)
			{
				flag = true;
				bi1 = -bi1;
			}
			if ((bi2.data[num] & 0x80000000u) != 0)
			{
				flag2 = true;
				bi2 = -bi2;
			}
		}
		catch (Exception)
		{
		}
		BigInteger bigInteger = new BigInteger();
		try
		{
			for (int i = 0; i < bi1.dataLength; i++)
			{
				if (bi1.data[i] != 0)
				{
					ulong num2 = 0uL;
					int num3 = 0;
					int num4 = i;
					while (num3 < bi2.dataLength)
					{
						ulong num5 = (ulong)((long)bi1.data[i] * (long)bi2.data[num3] + bigInteger.data[num4]) + num2;
						bigInteger.data[num4] = (uint)(num5 & 0xFFFFFFFFu);
						num2 = num5 >> 32;
						num3++;
						num4++;
					}
					if (num2 != 0)
					{
						bigInteger.data[i + bi2.dataLength] = (uint)num2;
					}
				}
			}
		}
		catch (Exception)
		{
			throw new ArithmeticException("Multiplication overflow.");
		}
		bigInteger.dataLength = bi1.dataLength + bi2.dataLength;
		if (bigInteger.dataLength > 70)
		{
			bigInteger.dataLength = 70;
		}
		while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0)
		{
			bigInteger.dataLength--;
		}
		if ((bigInteger.data[num] & 0x80000000u) != 0)
		{
			if (flag != flag2 && bigInteger.data[num] == 2147483648u)
			{
				if (bigInteger.dataLength == 1)
				{
					return bigInteger;
				}
				bool flag3 = true;
				for (int i = 0; i < bigInteger.dataLength - 1; i++)
				{
					if (!flag3)
					{
						break;
					}
					if (bigInteger.data[i] != 0)
					{
						flag3 = false;
					}
				}
				if (flag3)
				{
					return bigInteger;
				}
			}
			throw new ArithmeticException("Multiplication overflow.");
		}
		if (flag != flag2)
		{
			return -bigInteger;
		}
		return bigInteger;
	}

	public static BigInteger operator <<(BigInteger bi1, int shiftVal)
	{
		BigInteger bigInteger = new BigInteger(bi1);
		bigInteger.dataLength = shiftLeft(bigInteger.data, shiftVal);
		return bigInteger;
	}

	private static int shiftLeft(uint[] buffer, int shiftVal)
	{
		int num = 32;
		int num2 = buffer.Length;
		while (num2 > 1 && buffer[num2 - 1] == 0)
		{
			num2--;
		}
		for (int num3 = shiftVal; num3 > 0; num3 -= num)
		{
			if (num3 < num)
			{
				num = num3;
			}
			ulong num4 = 0uL;
			for (int i = 0; i < num2; i++)
			{
				ulong num5 = (ulong)buffer[i] << num;
				num5 |= num4;
				buffer[i] = (uint)(num5 & 0xFFFFFFFFu);
				num4 = num5 >> 32;
			}
			if (num4 != 0 && num2 + 1 <= buffer.Length)
			{
				buffer[num2] = (uint)num4;
				num2++;
			}
		}
		return num2;
	}

	private static int shiftRight(uint[] buffer, int shiftVal)
	{
		int num = 32;
		int num2 = 0;
		int num3 = buffer.Length;
		while (num3 > 1 && buffer[num3 - 1] == 0)
		{
			num3--;
		}
		for (int num4 = shiftVal; num4 > 0; num4 -= num)
		{
			if (num4 < num)
			{
				num = num4;
				num2 = 32 - num;
			}
			ulong num5 = 0uL;
			for (int num6 = num3 - 1; num6 >= 0; num6--)
			{
				ulong num7 = (ulong)buffer[num6] >> num;
				num7 |= num5;
				num5 = (ulong)buffer[num6] << num2;
				buffer[num6] = (uint)num7;
			}
		}
		while (num3 > 1 && buffer[num3 - 1] == 0)
		{
			num3--;
		}
		return num3;
	}

	public static BigInteger operator -(BigInteger bi1)
	{
		if (bi1.dataLength == 1 && bi1.data[0] == 0)
		{
			return new BigInteger();
		}
		BigInteger bigInteger = new BigInteger(bi1);
		for (int i = 0; i < 70; i++)
		{
			bigInteger.data[i] = ~bi1.data[i];
		}
		long num = 1L;
		int num2 = 0;
		while (num != 0 && num2 < 70)
		{
			long num3 = bigInteger.data[num2];
			num3++;
			bigInteger.data[num2] = (uint)(num3 & 0xFFFFFFFFu);
			num = num3 >> 32;
			num2++;
		}
		if ((bi1.data[69] & 0x80000000u) == (bigInteger.data[69] & 0x80000000u))
		{
			throw new ArithmeticException("Overflow in negation.\n");
		}
		bigInteger.dataLength = 70;
		while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0)
		{
			bigInteger.dataLength--;
		}
		return bigInteger;
	}

	public static bool operator ==(BigInteger bi1, BigInteger bi2)
	{
		return bi1.Equals(bi2);
	}

	public override bool Equals(object o)
	{
		BigInteger bigInteger = (BigInteger)o;
		if (dataLength != bigInteger.dataLength)
		{
			return false;
		}
		for (int i = 0; i < dataLength; i++)
		{
			if (data[i] != bigInteger.data[i])
			{
				return false;
			}
		}
		return true;
	}

	public override int GetHashCode()
	{
		return ToString().GetHashCode();
	}

	public static bool operator >(BigInteger bi1, BigInteger bi2)
	{
		int num = 69;
		if ((bi1.data[num] & 0x80000000u) != 0 && (bi2.data[num] & 0x80000000u) == 0)
		{
			return false;
		}
		if ((bi1.data[num] & 0x80000000u) == 0 && (bi2.data[num] & 0x80000000u) != 0)
		{
			return true;
		}
		int num2 = ((bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength);
		num = num2 - 1;
		while (num >= 0 && bi1.data[num] == bi2.data[num])
		{
			num--;
		}
		if (num >= 0)
		{
			if (bi1.data[num] > bi2.data[num])
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public static bool operator <(BigInteger bi1, BigInteger bi2)
	{
		int num = 69;
		if ((bi1.data[num] & 0x80000000u) != 0 && (bi2.data[num] & 0x80000000u) == 0)
		{
			return true;
		}
		if ((bi1.data[num] & 0x80000000u) == 0 && (bi2.data[num] & 0x80000000u) != 0)
		{
			return false;
		}
		int num2 = ((bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength);
		num = num2 - 1;
		while (num >= 0 && bi1.data[num] == bi2.data[num])
		{
			num--;
		}
		if (num >= 0)
		{
			if (bi1.data[num] < bi2.data[num])
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public static bool operator >=(BigInteger bi1, BigInteger bi2)
	{
		return bi1 == bi2 || bi1 > bi2;
	}

	private static void multiByteDivide(BigInteger bi1, BigInteger bi2, BigInteger outQuotient, BigInteger outRemainder)
	{
		uint[] array = new uint[70];
		int num = bi1.dataLength + 1;
		uint[] array2 = new uint[num];
		uint num2 = 2147483648u;
		uint num3 = bi2.data[bi2.dataLength - 1];
		int num4 = 0;
		int num5 = 0;
		while (num2 != 0 && (num3 & num2) == 0)
		{
			num4++;
			num2 >>= 1;
		}
		for (int i = 0; i < bi1.dataLength; i++)
		{
			array2[i] = bi1.data[i];
		}
		shiftLeft(array2, num4);
		bi2 <<= num4;
		int num6 = num - bi2.dataLength;
		int num7 = num - 1;
		ulong num8 = bi2.data[bi2.dataLength - 1];
		ulong num9 = bi2.data[bi2.dataLength - 2];
		int num10 = bi2.dataLength + 1;
		uint[] array3 = new uint[num10];
		while (num6 > 0)
		{
			ulong num11 = ((ulong)array2[num7] << 32) + array2[num7 - 1];
			ulong num12 = num11 / num8;
			ulong num13 = num11 % num8;
			bool flag = false;
			while (!flag)
			{
				flag = true;
				if (num12 == 4294967296L || num12 * num9 > (num13 << 32) + array2[num7 - 2])
				{
					num12--;
					num13 += num8;
					if (num13 < 4294967296L)
					{
						flag = false;
					}
				}
			}
			for (int j = 0; j < num10; j++)
			{
				array3[j] = array2[num7 - j];
			}
			BigInteger bigInteger = new BigInteger(array3);
			BigInteger bigInteger2;
			for (bigInteger2 = bi2 * (long)num12; bigInteger2 > bigInteger; bigInteger2 -= bi2)
			{
				num12--;
			}
			BigInteger bigInteger3 = bigInteger - bigInteger2;
			for (int j = 0; j < num10; j++)
			{
				array2[num7 - j] = bigInteger3.data[bi2.dataLength - j];
			}
			array[num5++] = (uint)num12;
			num7--;
			num6--;
		}
		outQuotient.dataLength = num5;
		int k = 0;
		int num14 = outQuotient.dataLength - 1;
		while (num14 >= 0)
		{
			outQuotient.data[k] = array[num14];
			num14--;
			k++;
		}
		for (; k < 70; k++)
		{
			outQuotient.data[k] = 0u;
		}
		while (outQuotient.dataLength > 1 && outQuotient.data[outQuotient.dataLength - 1] == 0)
		{
			outQuotient.dataLength--;
		}
		if (outQuotient.dataLength == 0)
		{
			outQuotient.dataLength = 1;
		}
		outRemainder.dataLength = shiftRight(array2, num4);
		for (k = 0; k < outRemainder.dataLength; k++)
		{
			outRemainder.data[k] = array2[k];
		}
		for (; k < 70; k++)
		{
			outRemainder.data[k] = 0u;
		}
	}

	private static void singleByteDivide(BigInteger bi1, BigInteger bi2, BigInteger outQuotient, BigInteger outRemainder)
	{
		uint[] array = new uint[70];
		int num = 0;
		int i;
		for (i = 0; i < 70; i++)
		{
			outRemainder.data[i] = bi1.data[i];
		}
		outRemainder.dataLength = bi1.dataLength;
		while (outRemainder.dataLength > 1 && outRemainder.data[outRemainder.dataLength - 1] == 0)
		{
			outRemainder.dataLength--;
		}
		ulong num2 = bi2.data[0];
		int num3 = outRemainder.dataLength - 1;
		ulong num4 = outRemainder.data[num3];
		if (num4 >= num2)
		{
			ulong num5 = num4 / num2;
			array[num++] = (uint)num5;
			outRemainder.data[num3] = (uint)(num4 % num2);
		}
		num3--;
		while (num3 >= 0)
		{
			num4 = ((ulong)outRemainder.data[num3 + 1] << 32) + outRemainder.data[num3];
			ulong num5 = num4 / num2;
			array[num++] = (uint)num5;
			outRemainder.data[num3 + 1] = 0u;
			outRemainder.data[num3--] = (uint)(num4 % num2);
		}
		outQuotient.dataLength = num;
		int j = 0;
		i = outQuotient.dataLength - 1;
		while (i >= 0)
		{
			outQuotient.data[j] = array[i];
			i--;
			j++;
		}
		for (; j < 70; j++)
		{
			outQuotient.data[j] = 0u;
		}
		while (outQuotient.dataLength > 1 && outQuotient.data[outQuotient.dataLength - 1] == 0)
		{
			outQuotient.dataLength--;
		}
		if (outQuotient.dataLength == 0)
		{
			outQuotient.dataLength = 1;
		}
		while (outRemainder.dataLength > 1 && outRemainder.data[outRemainder.dataLength - 1] == 0)
		{
			outRemainder.dataLength--;
		}
	}

	public static BigInteger operator /(BigInteger bi1, BigInteger bi2)
	{
		BigInteger bigInteger = new BigInteger();
		BigInteger outRemainder = new BigInteger();
		int num = 69;
		bool flag = false;
		bool flag2 = false;
		if ((bi1.data[num] & 0x80000000u) != 0)
		{
			bi1 = -bi1;
			flag2 = true;
		}
		if ((bi2.data[num] & 0x80000000u) != 0)
		{
			bi2 = -bi2;
			flag = true;
		}
		if (bi1 < bi2)
		{
			return bigInteger;
		}
		if (bi2.dataLength == 1)
		{
			singleByteDivide(bi1, bi2, bigInteger, outRemainder);
		}
		else
		{
			multiByteDivide(bi1, bi2, bigInteger, outRemainder);
		}
		if (flag2 != flag)
		{
			return -bigInteger;
		}
		return bigInteger;
	}

	public static BigInteger operator %(BigInteger bi1, BigInteger bi2)
	{
		BigInteger outQuotient = new BigInteger();
		BigInteger bigInteger = new BigInteger(bi1);
		int num = 69;
		bool flag = false;
		if ((bi1.data[num] & 0x80000000u) != 0)
		{
			bi1 = -bi1;
			flag = true;
		}
		if ((bi2.data[num] & 0x80000000u) != 0)
		{
			bi2 = -bi2;
		}
		if (bi1 < bi2)
		{
			return bigInteger;
		}
		if (bi2.dataLength == 1)
		{
			singleByteDivide(bi1, bi2, outQuotient, bigInteger);
		}
		else
		{
			multiByteDivide(bi1, bi2, outQuotient, bigInteger);
		}
		if (flag)
		{
			return -bigInteger;
		}
		return bigInteger;
	}

	public override string ToString()
	{
		return ToString(10);
	}

	public string ToString(int radix)
	{
		if (radix < 2 || radix > 36)
		{
			throw new ArgumentException("Radix must be >= 2 and <= 36");
		}
		string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		string text2 = "";
		BigInteger bigInteger = this;
		bool flag = false;
		if ((bigInteger.data[69] & 0x80000000u) != 0)
		{
			flag = true;
			try
			{
				bigInteger = -bigInteger;
			}
			catch (Exception)
			{
			}
		}
		BigInteger bigInteger2 = new BigInteger();
		BigInteger bigInteger3 = new BigInteger();
		BigInteger bi = new BigInteger(radix);
		if (bigInteger.dataLength == 1 && bigInteger.data[0] == 0)
		{
			text2 = "0";
		}
		else
		{
			while (bigInteger.dataLength > 1 || (bigInteger.dataLength == 1 && bigInteger.data[0] != 0))
			{
				singleByteDivide(bigInteger, bi, bigInteger2, bigInteger3);
				text2 = ((bigInteger3.data[0] >= 10) ? (text[(int)(bigInteger3.data[0] - 10)] + text2) : (bigInteger3.data[0] + text2));
				bigInteger = bigInteger2;
			}
			if (flag)
			{
				text2 = "-" + text2;
			}
		}
		return text2;
	}

	public BigInteger ModPow(BigInteger exp, BigInteger n)
	{
		if ((exp.data[69] & 0x80000000u) != 0)
		{
			throw new ArithmeticException("Positive exponents only.");
		}
		BigInteger bigInteger = 1;
		bool flag = false;
		BigInteger bigInteger2;
		if ((data[69] & 0x80000000u) != 0)
		{
			bigInteger2 = -this % n;
			flag = true;
		}
		else
		{
			bigInteger2 = this % n;
		}
		if ((n.data[69] & 0x80000000u) != 0)
		{
			n = -n;
		}
		BigInteger bigInteger3 = new BigInteger();
		int num = n.dataLength << 1;
		bigInteger3.data[num] = 1u;
		bigInteger3.dataLength = num + 1;
		bigInteger3 /= n;
		int num2 = exp.bitCount();
		int num3 = 0;
		for (int i = 0; i < exp.dataLength; i++)
		{
			uint num4 = 1u;
			for (int j = 0; j < 32; j++)
			{
				if ((exp.data[i] & num4) != 0)
				{
					bigInteger = BarrettReduction(bigInteger * bigInteger2, n, bigInteger3);
				}
				num4 <<= 1;
				bigInteger2 = BarrettReduction(bigInteger2 * bigInteger2, n, bigInteger3);
				if (bigInteger2.dataLength == 1 && bigInteger2.data[0] == 1)
				{
					if (flag && (exp.data[0] & (true ? 1u : 0u)) != 0)
					{
						return -bigInteger;
					}
					return bigInteger;
				}
				num3++;
				if (num3 == num2)
				{
					break;
				}
			}
		}
		if (flag && (exp.data[0] & (true ? 1u : 0u)) != 0)
		{
			return -bigInteger;
		}
		return bigInteger;
	}

	private BigInteger BarrettReduction(BigInteger x, BigInteger n, BigInteger constant)
	{
		int num = n.dataLength;
		int num2 = num + 1;
		int num3 = num - 1;
		BigInteger bigInteger = new BigInteger();
		int num4 = num3;
		int num5 = 0;
		while (num4 < x.dataLength)
		{
			bigInteger.data[num5] = x.data[num4];
			num4++;
			num5++;
		}
		bigInteger.dataLength = x.dataLength - num3;
		if (bigInteger.dataLength <= 0)
		{
			bigInteger.dataLength = 1;
		}
		BigInteger bigInteger2 = bigInteger * constant;
		BigInteger bigInteger3 = new BigInteger();
		num4 = num2;
		num5 = 0;
		while (num4 < bigInteger2.dataLength)
		{
			bigInteger3.data[num5] = bigInteger2.data[num4];
			num4++;
			num5++;
		}
		bigInteger3.dataLength = bigInteger2.dataLength - num2;
		if (bigInteger3.dataLength <= 0)
		{
			bigInteger3.dataLength = 1;
		}
		BigInteger bigInteger4 = new BigInteger();
		int num6 = ((x.dataLength > num2) ? num2 : x.dataLength);
		for (num4 = 0; num4 < num6; num4++)
		{
			bigInteger4.data[num4] = x.data[num4];
		}
		bigInteger4.dataLength = num6;
		BigInteger bigInteger5 = new BigInteger();
		for (num4 = 0; num4 < bigInteger3.dataLength; num4++)
		{
			if (bigInteger3.data[num4] != 0)
			{
				ulong num7 = 0uL;
				int num8 = num4;
				num5 = 0;
				while (num5 < n.dataLength && num8 < num2)
				{
					ulong num9 = (ulong)((long)bigInteger3.data[num4] * (long)n.data[num5] + bigInteger5.data[num8]) + num7;
					bigInteger5.data[num8] = (uint)(num9 & 0xFFFFFFFFu);
					num7 = num9 >> 32;
					num5++;
					num8++;
				}
				if (num8 < num2)
				{
					bigInteger5.data[num8] = (uint)num7;
				}
			}
		}
		bigInteger5.dataLength = num2;
		while (bigInteger5.dataLength > 1 && bigInteger5.data[bigInteger5.dataLength - 1] == 0)
		{
			bigInteger5.dataLength--;
		}
		bigInteger4 -= bigInteger5;
		if ((bigInteger4.data[69] & 0x80000000u) != 0)
		{
			BigInteger bigInteger6 = new BigInteger();
			bigInteger6.data[num2] = 1u;
			bigInteger6.dataLength = num2 + 1;
			bigInteger4 += bigInteger6;
		}
		for (; bigInteger4 >= n; bigInteger4 -= n)
		{
		}
		return bigInteger4;
	}

	public int bitCount()
	{
		while (dataLength > 1 && data[dataLength - 1] == 0)
		{
			dataLength--;
		}
		uint num = data[dataLength - 1];
		uint num2 = 2147483648u;
		int num3 = 32;
		while (num3 > 0 && (num & num2) == 0)
		{
			num3--;
			num2 >>= 1;
		}
		return num3 + (dataLength - 1 << 5);
	}

	public byte[] GetBytes()
	{
		if (this == 0)
		{
			return new byte[1];
		}
		int num = bitCount();
		int num2 = num >> 3;
		if (((uint)num & 7u) != 0)
		{
			num2++;
		}
		byte[] array = new byte[num2];
		int num3 = num2 & 3;
		if (num3 == 0)
		{
			num3 = 4;
		}
		int num4 = 0;
		for (int num5 = dataLength - 1; num5 >= 0; num5--)
		{
			uint num6 = data[num5];
			for (int num7 = num3 - 1; num7 >= 0; num7--)
			{
				array[num4 + num7] = (byte)(num6 & 0xFFu);
				num6 >>= 8;
			}
			num4 += num3;
			num3 = 4;
		}
		return array;
	}
}
