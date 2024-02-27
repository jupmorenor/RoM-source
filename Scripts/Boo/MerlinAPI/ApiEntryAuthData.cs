using System;
using Boo.Lang.Runtime;

namespace MerlinAPI;

[Serializable]
public class ApiEntryAuthData : RequestBase
{
	public string token;

	public override string ApiPath => "/Web/Entry/EntryAuthData";

	public override ServerType Server => ServerType.Entry;

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
