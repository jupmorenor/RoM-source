using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__QuestSession_0024callable353_0024924_41___0024__MerlinServer_Request_0024callable86_0024160_56___0024162
{
	protected __QuestSession_0024callable353_0024924_41__ _0024from;

	public _0024adaptor_0024__QuestSession_0024callable353_0024924_41___0024__MerlinServer_Request_0024callable86_0024160_56___0024162(__QuestSession_0024callable353_0024924_41__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase arg0)
	{
		_0024from((ApiQuestResult)arg0);
	}

	public static __MerlinServer_Request_0024callable86_0024160_56__ Adapt(__QuestSession_0024callable353_0024924_41__ from)
	{
		return new _0024adaptor_0024__QuestSession_0024callable353_0024924_41___0024__MerlinServer_Request_0024callable86_0024160_56___0024162(from).Invoke;
	}
}
