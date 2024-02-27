using System;

[Serializable]
public class MerlinLanguageSetting
{
	[NonSerialized]
	public static bool debugLanguageFlag;

	[NonSerialized]
	public static LanguageType debugLanguageType;

	public static LanguageType GetCurrentLanguage()
	{
		return LanguageType.Ja;
	}
}
