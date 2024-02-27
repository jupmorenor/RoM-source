using System;
using Boo.Lang.Runtime;

namespace MerlinAPI;

[Serializable]
public class ApiEntryJoinDevice : RequestBase
{
	public string DeviceUUID;

	public int marketCode;

	public override string ApiPath => "/Web/Entry/JoinDevice";

	public override ServerType Server => ServerType.Entry;

	public ApiEntryJoinDevice()
	{
		marketCode = ApiEntryCreateUser.GetMarketCode();
	}

	public JsonBase GetResponse()
	{
		object obj = ResponseObj;
		if (!(obj is JsonBase))
		{
			obj = RuntimeServices.Coerce(obj, typeof(JsonBase));
		}
		return (JsonBase)obj;
	}

	public override Type responseType()
	{
		return typeof(JsonBase);
	}
}
