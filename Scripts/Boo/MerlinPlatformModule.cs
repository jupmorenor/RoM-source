using System.Runtime.CompilerServices;
using UnityEngine;

[CompilerGlobalScope]
public sealed class MerlinPlatformModule
{
	private MerlinPlatformModule()
	{
	}

	public static MerlinPlatform ToMerlinPlatform(RuntimePlatform rp)
	{
		return MerlinPlatform.Android;
	}

	public static MerlinPlatform CurrentMerlinPlatform()
	{
		return ToMerlinPlatform(Application.platform);
	}
}
