using System.Runtime.CompilerServices;

[CompilerGlobalScope]
public sealed class MotionViewerModule
{
	private MotionViewerModule()
	{
	}

	public static float seconds_to_frame(float sec)
	{
		float num = 30f;
		float num2 = num;
		return sec * num2;
	}

	public static double get_one_frame()
	{
		float num = 30f;
		float num2 = num;
		return 1.0 / (double)num2;
	}
}
