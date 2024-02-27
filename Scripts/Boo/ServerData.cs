using System;
using System.Text;
using Boo.Lang.Runtime;

[Serializable]
public class ServerData
{
	public static string Read(int[] src)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		int length = src.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int num2 = num;
			num++;
			char value = (char)checked((ushort)(src[RuntimeServices.NormalizeArrayIndex(src, num2)] ^ (num2 * 1129)));
			stringBuilder.Append(value);
		}
		return stringBuilder.ToString();
	}
}
