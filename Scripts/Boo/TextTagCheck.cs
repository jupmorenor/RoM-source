using System;
using System.Text;
using MerlinAPI;

[Serializable]
public class TextTagCheck
{
	[NonSerialized]
	public const string PC_NAME_ALIAS_RE = "PC_NAME_[AD]";

	public static string[] GetMultiLineArray(string text)
	{
		text = text.Replace("<P>", "<p>");
		text = text.Replace("<p>\n", "<p>");
		return text.Split(new string[1] { "<p>" }, StringSplitOptions.None);
	}

	public static string ReplaceMultiLine(string text)
	{
		text = text.Replace("<P>", "<p>");
		text = text.Replace("<p>\n", "<p>");
		text = text.Replace("<p>", "\r\n");
		return text;
	}

	public static string CheckPlayerName(string str)
	{
		if (str == null)
		{
			str = string.Empty;
		}
		UserData current = UserData.Current;
		RespPlayerInfo userStatus = current.userStatus;
		string[][] array = new string[3][]
		{
			new string[2] { "PC_NAME_A", userStatus.AngelName },
			new string[2] { "PC_NAME_D", userStatus.DemonName },
			new string[2] { "MA_NAME", userStatus.PoppetName }
		};
		int i = 0;
		string[][] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			str = str.Replace(new StringBuilder("<").Append(array2[i][0]).Append(">").ToString(), array2[i][1]);
		}
		return str;
	}
}
