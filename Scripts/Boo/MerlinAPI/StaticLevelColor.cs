using System;
using UnityEngine;

namespace MerlinAPI;

public static class StaticLevelColor
{
	[NonSerialized]
	private static Color normal = UIBasicUtility.GetColor(228f, 198f, 26f);

	[NonSerialized]
	private static Color lbreak = UIBasicUtility.GetColor(171f, 236f, 83f);

	[NonSerialized]
	private static Color max = UIBasicUtility.GetColor(251f, 78f, 146f);

	public static Color NORMAL => normal;

	public static Color LIMIT_BREAK => lbreak;

	public static Color LIMIT_BREAK_MAX => max;

	public static void set_normal(Color c)
	{
		normal = c;
	}

	public static void set_limit_break(Color c)
	{
		lbreak = c;
	}

	public static void set_limit_break_max(Color c)
	{
		max = c;
	}
}
