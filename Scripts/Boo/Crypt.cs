using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Boo.Lang.Runtime;

[Serializable]
public class Crypt
{
	[NonSerialized]
	private const string SALT_STRING = "Merlin0000";

	public static string Encrypt(string src)
	{
		string result;
		if (string.IsNullOrEmpty(src))
		{
			result = string.Empty;
		}
		else
		{
			byte[] inArray = Encrypt(Encoding.UTF8.GetBytes(src));
			result = Convert.ToBase64String(inArray);
		}
		return result;
	}

	public static string Decrypt(string src)
	{
		string result;
		if (string.IsNullOrEmpty(src))
		{
			result = string.Empty;
		}
		else
		{
			byte[] bytes = Decrypt(Convert.FromBase64String(src));
			result = Encoding.UTF8.GetString(bytes);
		}
		return result;
	}

	public static byte[] Encrypt(byte[] src)
	{
		if (src == null || src.Length <= 0)
		{
			throw new AssertionFailedException("(src != null) and (len(src) > 0)");
		}
		return src;
	}

	public static byte[] Decrypt(byte[] src)
	{
		if (src == null || src.Length <= 0)
		{
			throw new AssertionFailedException("(src != null) and (len(src) > 0)");
		}
		return src;
	}

	public static string GenerateNewKey()
	{
		byte[] inArray = AndroidCipher.GenKey();
		return Convert.ToBase64String(inArray);
	}

	public static string EncryptQuest(string src, byte[] key)
	{
		string result;
		if (string.IsNullOrEmpty(src))
		{
			result = string.Empty;
		}
		else
		{
			byte[] inArray = EncryptQuest(Encoding.UTF8.GetBytes(src), key);
			result = Convert.ToBase64String(inArray);
		}
		return result;
	}

	public static string DecryptQuest(string src, byte[] key)
	{
		string result;
		if (string.IsNullOrEmpty(src))
		{
			result = string.Empty;
		}
		else
		{
			byte[] bytes = DecryptQuest(Convert.FromBase64String(src), key);
			result = Encoding.UTF8.GetString(bytes);
		}
		return result;
	}

	public static byte[] EncryptQuest(byte[] src, byte[] key)
	{
		if (src == null || src.Length <= 0)
		{
			throw new AssertionFailedException("(src != null) and (len(src) > 0)");
		}
		return AndroidCipher.Encode(src, key);
	}

	public static byte[] DecryptQuest(byte[] src, byte[] key)
	{
		if (src == null || src.Length <= 0)
		{
			throw new AssertionFailedException("(src != null) and (len(src) > 0)");
		}
		return AndroidCipher.Decode(src, key);
	}

	public static byte[] EncryptColosseum(byte[] src, byte[] key)
	{
		if (src == null || src.Length <= 0)
		{
			throw new AssertionFailedException("(src != null) and (len(src) > 0)");
		}
		return AndroidCipher.Encode(src, key);
	}

	public static byte[] DecryptColosseum(byte[] src, byte[] key)
	{
		if (src == null || src.Length <= 0)
		{
			throw new AssertionFailedException("(src != null) and (len(src) > 0)");
		}
		return AndroidCipher.Decode(src, key);
	}

	private static RijndaelManaged CreateRijndael(string saltStr, string pwd)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(saltStr);
		Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(pwd, bytes);
		rfc2898DeriveBytes.IterationCount = 5440;
		RijndaelManaged rijndaelManaged = new RijndaelManaged();
		rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
		rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);
		return rijndaelManaged;
	}

	private static byte[] DoJob(byte[] src, ICryptoTransform cryptTransform)
	{
		if (src == null || src.Length <= 0 || cryptTransform == null)
		{
			throw new AssertionFailedException("((src != null) and (len(src) > 0)) and (cryptTransform != null)");
		}
		MemoryStream memoryStream = new MemoryStream();
		CryptoStream cryptoStream;
		IDisposable disposable = (cryptoStream = new CryptoStream(memoryStream, cryptTransform, CryptoStreamMode.Write)) as IDisposable;
		try
		{
			cryptoStream.Write(src, 0, src.Length);
			cryptoStream.FlushFinalBlock();
		}
		finally
		{
			if (disposable != null)
			{
				disposable.Dispose();
				disposable = null;
			}
		}
		return memoryStream.ToArray();
	}

	private static byte[] XorBytes(byte[] src, byte[] key)
	{
		byte[] result;
		if (src == null)
		{
			result = src;
		}
		else
		{
			if (key == null || key.Length <= 0)
			{
				throw new AssertionFailedException("(key != null) and (len(key) > 0)");
			}
			int length = src.Length;
			int length2 = key.Length;
			byte[] array = new byte[length];
			int num = 0;
			int num2 = length;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int num3 = num;
				num++;
				checked
				{
					array[RuntimeServices.NormalizeArrayIndex(array, num3)] = (byte)unchecked((int)src[RuntimeServices.NormalizeArrayIndex(src, num3)] ^ (int)key[RuntimeServices.NormalizeArrayIndex(key, num3 % length2)]);
				}
			}
			result = array;
		}
		return result;
	}
}
