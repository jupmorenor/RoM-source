using System;

namespace MerlinAPI;

[Serializable]
public class RespExtServer : JsonBase
{
	public string Name;

	public string TypeCode;

	public string HostName;
}
