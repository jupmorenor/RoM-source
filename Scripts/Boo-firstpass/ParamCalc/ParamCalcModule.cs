using System.Runtime.CompilerServices;
using UnityEngine;

namespace ParamCalc;

[CompilerGlobalScope]
public sealed class ParamCalcModule
{
	private ParamCalcModule()
	{
	}

	public static int ComputeGrowthInt(int level, int levelMax, int min, int max, float exp)
	{
		return checked((int)ComputeGrowth(level, levelMax, min, max, exp));
	}

	public static int ComputeGrowthInt(int level, int levelMax, int min, int max, float exp, string msg)
	{
		return checked((int)ComputeGrowth(level, levelMax, min, max, exp));
	}

	public static float ComputeGrowth(int level, int levelMax, int min, int max, float exp, string msg)
	{
		return ComputeGrowth(level, levelMax, min, max, exp);
	}

	public static float ComputeGrowth(int level, int levelMax, int min, int max, float exp)
	{
		checked
		{
			int num = Mathf.Max(0, level - 1);
			int num2 = Mathf.Max(1, levelMax - 1);
			float f = (float)num / (float)num2;
			return (float)(max - min) * Mathf.Pow(f, exp) + (float)min;
		}
	}
}
