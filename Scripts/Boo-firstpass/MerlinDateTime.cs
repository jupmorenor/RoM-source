using System;

[Serializable]
public class MerlinDateTime
{
	[NonSerialized]
	private static TimeSpan _TimeOffset = default(TimeSpan);

	public static DateTime Now => DateTime.Now + _TimeOffset;

	public static DateTime UtcNow => DateTime.UtcNow + _TimeOffset;

	public static TimeSpan TimeOffset => _TimeOffset;

	public static void SetTimeOffset(TimeSpan ofs)
	{
		_TimeOffset = ofs;
	}
}
