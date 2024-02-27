using System;
using System.Collections;
using System.IO;
using Boo.Lang.Runtime;

[Serializable]
public class DownloadUtil
{
	[NonSerialized]
	public const string ASSETBUNDLE_EXTENSION = ".unity3d";

	public static bool IsAssetBundleFile(string pathOrURL)
	{
		bool num = !string.IsNullOrEmpty(pathOrURL);
		if (num)
		{
			num = Path.GetExtension(pathOrURL) == ".unity3d";
		}
		return num;
	}

	public static int GetAssetBundleVersion(Hashtable rsrcHash, string _fileName)
	{
		return (int)GetAssetBundleUIntInfo(rsrcHash, "ver", _fileName);
	}

	public static uint GetAssetBundleCRC(Hashtable rsrcHash, string _fileName)
	{
		return GetAssetBundleUIntInfo(rsrcHash, "crc", _fileName);
	}

	public static uint GetAssetBundleSize(Hashtable rsrcHash, string _fileName)
	{
		return GetAssetBundleUIntInfo(rsrcHash, "size", _fileName);
	}

	public static uint GetAssetBundleUIntInfo(Hashtable rsrcHash, string ename, string _fileName)
	{
		int result;
		if (rsrcHash == null || string.IsNullOrEmpty(_fileName))
		{
			result = 0;
		}
		else
		{
			string text = Path.GetFileName(_fileName);
			if (!rsrcHash.ContainsKey(text))
			{
				result = 0;
			}
			else
			{
				if (string.IsNullOrEmpty(Path.GetExtension(text)))
				{
					text += ".unity3d";
				}
				Hashtable hashtable = rsrcHash[text] as Hashtable;
				if (hashtable == null || !hashtable.ContainsKey(ename))
				{
				}
				uint num = 0u;
				object obj = hashtable[ename];
				if (obj is int || obj is long || obj is float || obj is double || obj is uint)
				{
					num = RuntimeServices.UnboxUInt32(obj);
				}
				else if (obj is string)
				{
					uint result2 = default(uint);
					object obj2 = obj;
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					if (uint.TryParse((string)obj2, out result2))
					{
						num = result2;
					}
				}
				result = (int)num;
			}
		}
		return (uint)result;
	}
}
