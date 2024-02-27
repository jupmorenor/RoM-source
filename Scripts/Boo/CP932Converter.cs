using System;
using System.Text;
using USEncoder;

[Serializable]
public class CP932Converter
{
	[NonSerialized]
	private static UTF8Encoding EncUTF8 = new UTF8Encoding();

	[NonSerialized]
	private static UnicodeEncoding EncUTF16 = new UnicodeEncoding();

	public static string ToUTF8(byte[] cp932bytes)
	{
		string s = ToEncoding.ToUnicode(cp932bytes);
		byte[] bytes = EncUTF16.GetBytes(s);
		byte[] bytes2 = Encoding.Convert(EncUTF16, EncUTF8, bytes);
		return EncUTF8.GetString(bytes2);
	}
}
