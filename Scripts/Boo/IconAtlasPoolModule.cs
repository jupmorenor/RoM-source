using System.Runtime.CompilerServices;

[CompilerGlobalScope]
public sealed class IconAtlasPoolModule
{
	private IconAtlasPoolModule()
	{
	}

	public static void SetGearIcon(this UISprite sprite, string iconName)
	{
		if (!(sprite == null))
		{
			IconAtlasPool.SetSprite(sprite, iconName);
		}
	}
}
