using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__QuestSession_0024callable352_0024920_54___0024__MerlinServer_Request_0024callable86_0024160_56___0024161
{
	protected __QuestSession_0024callable352_0024920_54__ _0024from;

	public _0024adaptor_0024__QuestSession_0024callable352_0024920_54___0024__MerlinServer_Request_0024callable86_0024160_56___0024161(__QuestSession_0024callable352_0024920_54__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase arg0)
	{
		_0024from((ApiPresent)arg0);
	}

	public static __MerlinServer_Request_0024callable86_0024160_56__ Adapt(__QuestSession_0024callable352_0024920_54__ from)
	{
		return new _0024adaptor_0024__QuestSession_0024callable352_0024920_54___0024__MerlinServer_Request_0024callable86_0024160_56___0024161(from).Invoke;
	}
}
