using System.Collections.Generic;
using System.Text;

namespace USEncoder;

public class ToEncoding
{
	public static byte[] ToSJIS(string unicode_str)
	{
		byte[] bytes = Encoding.BigEndianUnicode.GetBytes(unicode_str);
		List<byte> list = new List<byte>();
		int num;
		for (num = 0; num < bytes.Length; num++)
		{
			ushort num2 = (ushort)(bytes[num] << 8);
			num2 += bytes[++num];
			ushort code = USEncoder.ToSJIS.GetCode(num2);
			byte b = (byte)(code >> 8);
			byte item = (byte)(code & 0xFFu);
			if ((b >= 129 && b <= 159) || (b >= 224 && b <= 234))
			{
				list.Add(b);
				list.Add(item);
			}
			else
			{
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	public static string ToUnicode(byte[] sjis_bytes)
	{
		List<byte> list = new List<byte>();
		for (int i = 0; i < sjis_bytes.Length; i++)
		{
			ushort num;
			if ((sjis_bytes[i] >= 129 && sjis_bytes[i] <= 159) || (sjis_bytes[i] >= 224 && sjis_bytes[i] <= 234))
			{
				num = (ushort)(sjis_bytes[i] << 8);
				num += sjis_bytes[++i];
			}
			else
			{
				num = sjis_bytes[i];
			}
			ushort code = USEncoder.ToUnicode.GetCode(num);
			byte item = (byte)(code >> 8);
			byte item2 = (byte)(code & 0xFFu);
			list.Add(item2);
			list.Add(item);
		}
		return Encoding.Unicode.GetString(list.ToArray());
	}
}
