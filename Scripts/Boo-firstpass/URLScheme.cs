using System;
using System.Collections.Generic;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class URLScheme : MonoBehaviour
{
	[NonSerialized]
	private static string LastRequested;

	[NonSerialized]
	private const string URLSCHEME_PREF_KEY = "merlin-android-url-scheme-string";

	public void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(gameObject);
	}

	public static void ClearSavedURL()
	{
		PlayerPrefs.DeleteKey("merlin-android-url-scheme-string");
	}

	public static string GetLastRequestURI()
	{
		return PlayerPrefs.GetString("merlin-android-url-scheme-string", string.Empty);
	}

	public static string GetScheme()
	{
		string lastRequestURI = GetLastRequestURI();
		return string.IsNullOrEmpty(lastRequestURI) ? string.Empty : new Uri(lastRequestURI).Scheme;
	}

	public static string GetIdentifier()
	{
		string lastRequestURI = GetLastRequestURI();
		return string.IsNullOrEmpty(lastRequestURI) ? string.Empty : new Uri(lastRequestURI).Authority;
	}

	public static Dictionary<string, string> GetFFRKParameters()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		checked
		{
			try
			{
				string lastRequestURI = GetLastRequestURI();
				if (!string.IsNullOrEmpty(lastRequestURI))
				{
					int num = lastRequestURI.IndexOf("?");
					if (num >= 0)
					{
						string text = lastRequestURI;
						string text2 = text.Substring(RuntimeServices.NormalizeStringIndex(text, num + 1));
						if (!string.IsNullOrEmpty(text2))
						{
							string[] array = text2.Split('&');
							int i = 0;
							string[] array2 = array;
							for (int length = array2.Length; i < length; i++)
							{
								string[] array3 = array2[i].Split('=');
								if (array3.Length >= 2 && !string.IsNullOrEmpty(array3[0]))
								{
									dictionary[array3[0]] = Uri.UnescapeDataString(array3[1]);
								}
								else
								{
									Debug.LogError("malformed parameter: " + array2[i]);
								}
							}
						}
						else
						{
							Debug.LogError("a parameter is null: " + lastRequestURI);
						}
					}
					else
					{
						Debug.LogError("no parameters: " + lastRequestURI);
					}
				}
			}
			catch (Exception)
			{
			}
			return dictionary;
		}
	}

	public void Update()
	{
	}

	private static void SetURI(string uri)
	{
		if (!string.IsNullOrEmpty(uri))
		{
			PlayerPrefs.SetString("merlin-android-url-scheme-string", uri);
			Debug.Log("URLScheme.SetURI " + uri);
		}
	}
}
