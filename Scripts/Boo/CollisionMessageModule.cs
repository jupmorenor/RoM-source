using System.Runtime.CompilerServices;

[CompilerGlobalScope]
public sealed class CollisionMessageModule
{
	private CollisionMessageModule()
	{
	}

	public static bool IsIn(this CollisionMessage c)
	{
		return c != null && c.isIn;
	}
}
