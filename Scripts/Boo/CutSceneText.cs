using System;
using System.Text;
using Boo.Lang.Runtime;

[Serializable]
public class CutSceneText
{
	[NonSerialized]
	public static readonly string[] languageTypeName = new string[2] { "ja", "en" };

	[NonSerialized]
	public static readonly string[] genderTypeName = new string[2] { "male", "female" };

	[NonSerialized]
	public const string genderFreeTypeName = "common";

	[NonSerialized]
	public const string aliasName = "ja_m";

	[NonSerialized]
	public const string ANGEL_TAG = "PC_NAME_A";

	[NonSerialized]
	public const string DEVIL_TAG = "PC_NAME_D";

	public static string GetHeaderName(EnumGenders g)
	{
		int currentLanguage = (int)MerlinLanguageSetting.GetCurrentLanguage();
		int index = ((g != EnumGenders.male) ? 1 : 0);
		string[] array = languageTypeName;
		string value = array[RuntimeServices.NormalizeArrayIndex(array, currentLanguage)];
		string[] array2 = genderTypeName;
		string value2 = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
		return new StringBuilder().Append(value).Append("_").Append(value2)
			.ToString();
	}

	public static string GetHeaderNameCurrentGender()
	{
		return GetHeaderName(getCurrentGender());
	}

	public static string GetHeaderNameForAngel()
	{
		return GetHeaderName(getCurrentGender(RACE_TYPE.Tensi));
	}

	public static string GetHeaderNameForDevil()
	{
		return GetHeaderName(getCurrentGender(RACE_TYPE.Akuma));
	}

	public static string GetHeaderNameCurrentLanguageCommon()
	{
		int currentLanguage = (int)MerlinLanguageSetting.GetCurrentLanguage();
		string[] array = languageTypeName;
		string value = array[RuntimeServices.NormalizeArrayIndex(array, currentLanguage)];
		return new StringBuilder().Append(value).Append("_").Append("common")
			.ToString();
	}

	private static EnumGenders getCurrentGender()
	{
		return getCurrentGender(UserData.Current.PlayerRace);
	}

	private static EnumGenders getCurrentGender(RACE_TYPE race)
	{
		EnumGenders enumGenders = default(EnumGenders);
		return race switch
		{
			RACE_TYPE.Tensi => (EnumGenders)UserData.Current.AngelGender, 
			RACE_TYPE.Akuma => (EnumGenders)UserData.Current.DemonGender, 
			_ => enumGenders, 
		};
	}

	public static RACE_TYPE getRaceFromTextTag(string raw)
	{
		return (!RuntimeServices.op_Member("PC_NAME_A", raw)) ? (RuntimeServices.op_Member("PC_NAME_D", raw) ? RACE_TYPE.Akuma : RACE_TYPE.Tensi) : RACE_TYPE.Tensi;
	}
}
