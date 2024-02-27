using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class CypherKeyGenerator
{
	private string prefKey;

	private CypherKeyGenerator(string _prefKey)
	{
		if (string.IsNullOrEmpty(_prefKey))
		{
			throw new AssertionFailedException("not string.IsNullOrEmpty(_prefKey)");
		}
		prefKey = _prefKey;
	}

	public static CypherKeyGenerator ForQuest()
	{
		return new CypherKeyGenerator("QS-SAVE-KEY");
	}

	public static CypherKeyGenerator ForColosseum()
	{
		return new CypherKeyGenerator("CO-SAVE-KEY");
	}

	public byte[] getSaveKey()
	{
		string text = PlayerPrefs.GetString(prefKey, null);
		if (text == null)
		{
			text = renewSaveKey();
		}
		return Convert.FromBase64String(text);
	}

	public string renewSaveKey()
	{
		string text = genNewKey();
		PlayerPrefs.SetString(prefKey, text);
		PlayerPrefs.Save();
		return text;
	}

	public string genNewKey()
	{
		return Crypt.GenerateNewKey();
	}
}
