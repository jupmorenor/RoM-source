using System;
using Boo.Lang;

namespace MerlinAPI;

[Serializable]
public class ApiSellBase : RequestBase
{
	public string BoxId;

	public void set(BoxId[] ids)
	{
		BoxId = Builtins.join(ids, ",");
	}
}
