using System.Globalization;
using UnityEngine;

public static class DateTimeLocalization
{
	public enum Language
	{
		Dutch,
		English,
		French,
		German,
		Portuguese,
		Spanish,
		None
	}

	private static Language _currentLanguage = Language.None;

	private static string[] _languageCodes = new string[6] { "nl-NL", "en-US", "fr-FR", "de-DE", "pt-PT", "es-ES" };

	public static CultureInfo Culture { get; private set; }

	public static Language CurrentLanguage => _currentLanguage;

	public static bool SetLanguage(Language language)
	{
		if (language == _currentLanguage)
		{
			return false;
		}
		_currentLanguage = language;
		Culture = new CultureInfo(_languageCodes[(int)language]);
		return true;
	}

	public static string[] GetDayNames(bool abbreviated)
	{
		if (_currentLanguage == Language.None)
		{
			Debug.LogError("No Language set !");
			return null;
		}
		string[] array = new string[7];
		for (int i = 0; i < 7; i++)
		{
			array[i] = ((!abbreviated) ? Culture.DateTimeFormat.DayNames[i] : Culture.DateTimeFormat.AbbreviatedDayNames[i]);
		}
		return array;
	}

	public static string[] GetMonthNames(bool abbreviated)
	{
		if (_currentLanguage == Language.None)
		{
			Debug.LogError("No Language set !");
			return null;
		}
		string[] array = new string[12];
		for (int i = 0; i < 12; i++)
		{
			array[i] = ((!abbreviated) ? Culture.DateTimeFormat.MonthNames[i] : Culture.DateTimeFormat.AbbreviatedMonthGenitiveNames[i]);
		}
		return array;
	}

	public static bool TrySetLanguage(string languageString)
	{
		bool result = false;
		for (int i = 0; i < 6; i++)
		{
			Language language = (Language)i;
			if (language.ToString() == languageString && language != CurrentLanguage)
			{
				SetLanguage(language);
				result = true;
				break;
			}
		}
		return result;
	}
}
