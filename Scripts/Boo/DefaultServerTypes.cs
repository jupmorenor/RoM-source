using System;

[Serializable]
public class DefaultServerTypes
{
	[NonSerialized]
	public static readonly EnumServerTypes DefaultDev = EnumServerTypes.Dev05;

	[NonSerialized]
	public static readonly EnumServerTypes DefaultTest = EnumServerTypes.Dev03;

	[NonSerialized]
	public static readonly EnumServerTypes DefaultQA = EnumServerTypes.QA03;
}
