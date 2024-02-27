using System;

namespace MerlinAPI;

[Serializable]
public class RespWebServer : JsonBase
{
	public string Name;

	public string Id;

	public string HostName;
}
