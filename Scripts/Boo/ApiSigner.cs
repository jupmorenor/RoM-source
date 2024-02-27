using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;
using Boo.Lang;
using Boo.Lang.PatternMatching;
using Boo.Lang.Runtime;

[Serializable]
public class ApiSigner
{
	[NonSerialized]
	protected const string _Timestamp = "timestamp";

	[NonSerialized]
	protected const string _Signature = "signature";

	[NonSerialized]
	protected const string _SecretKey = "secretKey";

	[NonSerialized]
	public static readonly int[] k1 = new int[32]
	{
		50, 1114, 2231, 3416, 4501, 5693, 6676, 7917, 9005, 10116,
		11311, 12471, 13534, 14640, 15759, 16964, 18161, 19151, 20308, 21418,
		22609, 23803, 24884, 25867, 27115, 28273, 29337, 30578, 31562, 32732,
		33916, 34949
	};

	[NonSerialized]
	public static readonly int[] k2 = new int[32]
	{
		56, 1117, 2272, 3343, 4550, 5737, 6724, 7914, 9084, 10195,
		11309, 12519, 13524, 14690, 15839, 16926, 18084, 19098, 20311, 21496,
		22613, 23725, 24932, 25865, 27068, 28279, 29338, 30583, 31512, 32647,
		33915, 35027
	};

	public static string d1 => ServerData.Read(k1);

	public static string d2 => ServerData.Read(k2);

	public static void Sign(Hashtable @params, ServerType srvType)
	{
		switch (srvType)
		{
		case ServerType.Platform:
			SignToPlatform(@params);
			break;
		case ServerType.Entry:
			SignToGame(@params);
			break;
		case ServerType.Game:
			SignToGame(@params);
			break;
		case ServerType.None:
		case ServerType.ExamVer:
			break;
		default:
			throw new MatchError(new StringBuilder("`srvType` failed to match `").Append(srvType).Append("`").ToString());
		}
	}

	public static void SignToPlatform(Hashtable @params)
	{
		ToEncryptedQueryParams(@params, d1);
	}

	public static void SignToGame(Hashtable @params)
	{
		ToEncryptedQueryParams(@params, d2);
	}

	public static string GetHash(string queryString)
	{
		StringBuilder stringBuilder = new StringBuilder();
		byte[] array = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(queryString));
		int i = 0;
		byte[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			stringBuilder.Append(array2[i].ToString("x2"));
		}
		return stringBuilder.ToString();
	}

	public static string GetSignature(NameValueCollection queryString, string secretKey)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		int i = 0;
		string[] allKeys = queryString.AllKeys;
		checked
		{
			for (int length = allKeys.Length; i < length; i++)
			{
				if (!(allKeys[i] == "signature"))
				{
					string value = queryString[allKeys[i]];
					dictionary.Add(allKeys[i], value);
				}
			}
			dictionary.Add("secretKey", secretKey);
			Boo.Lang.List<string> list = new Boo.Lang.List<string>();
			foreach (string key in dictionary.Keys)
			{
				list.Add(key);
			}
			string[] array = list.ToArray();
			Array.Sort(array);
			Boo.Lang.List<string> list2 = new Boo.Lang.List<string>();
			int j = 0;
			string[] array2 = array;
			for (int length2 = array2.Length; j < length2; j++)
			{
				list2.Add(UIBasicUtility.SafeFormat("{0}={1}", array2[j], dictionary[array2[j]]));
			}
			return GetHash(Builtins.join(list2, "&"));
		}
	}

	public static NameValueCollection ToEncryptedQuery(NameValueCollection @params, string secretKey)
	{
		if (@params == null)
		{
			throw new AssertionFailedException("params != null");
		}
		@params["timestamp"] = MerlinDateTime.UtcNow.ToString();
		@params["signature"] = GetSignature(@params, secretKey);
		return @params;
	}

	public static void ToEncryptedQueryParams(Hashtable @params, string secretKey)
	{
		NameValueCollection nameValueCollection = new NameValueCollection();
		IEnumerator enumerator = @params.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object current = enumerator.Current;
			object obj = current;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			nameValueCollection[(string)obj] = new StringBuilder().Append(@params[current]).ToString();
		}
		ToEncryptedQuery(nameValueCollection, secretKey);
		@params.Clear();
		int i = 0;
		string[] allKeys = nameValueCollection.AllKeys;
		for (int length = allKeys.Length; i < length; i = checked(i + 1))
		{
			@params[allKeys[i]] = nameValueCollection[allKeys[i]];
		}
	}
}
