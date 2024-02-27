using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__PauseQuest_0024callable349_0024121_51___0024__MerlinServer_Request_0024callable86_0024160_56___0024152
{
	protected __PauseQuest_0024callable349_0024121_51__ _0024from;

	public _0024adaptor_0024__PauseQuest_0024callable349_0024121_51___0024__MerlinServer_Request_0024callable86_0024160_56___0024152(__PauseQuest_0024callable349_0024121_51__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase arg0)
	{
		_0024from((ApiHelp)arg0);
	}

	public static __MerlinServer_Request_0024callable86_0024160_56__ Adapt(__PauseQuest_0024callable349_0024121_51__ from)
	{
		return new _0024adaptor_0024__PauseQuest_0024callable349_0024121_51___0024__MerlinServer_Request_0024callable86_0024160_56___0024152(from).Invoke;
	}
}
