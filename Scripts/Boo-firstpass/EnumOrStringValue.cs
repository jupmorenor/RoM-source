using System;
using System.Text;

[Serializable]
public struct EnumOrStringValue<ET>
{
	public string stringValue;

	public int enumValue;

	public bool hasString;

	public static EnumOrStringValue<ET> ByString(string n)
	{
		EnumOrStringValue<ET> result = default(EnumOrStringValue<ET>);
		string text = (result.stringValue = n);
		bool flag = (result.hasString = true);
		return result;
	}

	public static EnumOrStringValue<ET> ByEnum(int n)
	{
		EnumOrStringValue<ET> result = default(EnumOrStringValue<ET>);
		int num = (result.enumValue = n);
		bool flag = (result.hasString = false);
		return result;
	}

	public override string ToString()
	{
		return (!hasString) ? new StringBuilder("EnumOrStringValue(enum=").Append((object)enumValue).Append(")").ToString() : new StringBuilder("EnumOrStringValue(string=").Append(stringValue).Append(")").ToString();
	}
}
