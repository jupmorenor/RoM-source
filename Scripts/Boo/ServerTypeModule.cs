using System.Runtime.CompilerServices;

[CompilerGlobalScope]
public sealed class ServerTypeModule
{
	private ServerTypeModule()
	{
	}

	public static bool WillZipResponse(ServerType st)
	{
		bool num = st != ServerType.Platform;
		if (num)
		{
			num = st != ServerType.ExamVer;
		}
		return num;
	}
}
