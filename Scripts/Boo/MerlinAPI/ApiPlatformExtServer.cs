using System;
using System.Collections;
using System.Linq;
using Boo.Lang.Runtime;
using CompilerGenerated;

namespace MerlinAPI;

[Serializable]
public class ApiPlatformExtServer : RequestBase
{
	[Serializable]
	public class RespExtServer : JsonBase
	{
		public string Name;

		public string TypeCode;

		public string HostName;
	}

	[Serializable]
	public class RespMaintenanceMode : GameApiResponseBase
	{
		public string moveURL;
	}

	public override string ApiPath => "/Merlin/ExtServer";

	public override ServerType Server => ServerType.Platform;

	public override bool InfRetry => true;

	public RespExtServer[] GetResponse()
	{
		return ResponseObj as RespExtServer[];
	}

	public override Type responseType()
	{
		return typeof(RespExtServer[]);
	}

	protected bool EntryServerFinder(RespExtServer x)
	{
		return x.Name == "EntryServer";
	}

	protected bool AssetServerFinder(RespExtServer x)
	{
		return x.Name == "AssetServer";
	}

	public override object setResponse(object @params)
	{
		object obj;
		if (!RuntimeServices.ToBool(@params))
		{
			obj = null;
		}
		else if (@params is Hashtable)
		{
			ResponseObj = JsonBase.CreateFromJson(typeof(RespMaintenanceMode), @params);
			obj = ResponseObj;
		}
		else
		{
			obj = base.setResponse(@params);
		}
		return obj;
	}

	public override void doPostRequestJob()
	{
		if (UnderMaintenance)
		{
			MerlinServer.MaintenanceDialog(this);
			return;
		}
		RespExtServer[] array = GetResponse();
		if (array != null && array.Length > 0 && array[0] != null)
		{
			if (array.Any(_0024adaptor_0024__ApiPlatformExtServer_doPostRequestJob_0024callable562_0024120_26___0024Func_0024171.Adapt(EntryServerFinder)))
			{
				RespExtServer respExtServer = array.Where(_0024adaptor_0024__ApiPlatformExtServer_doPostRequestJob_0024callable562_0024120_26___0024Func_0024171.Adapt(EntryServerFinder)).First();
				ServerURL.ENTRY_SRV_URL = respExtServer.HostName;
				ServerURL.GAME_SRV_URL = respExtServer.HostName;
			}
			if (array.Any(_0024adaptor_0024__ApiPlatformExtServer_doPostRequestJob_0024callable562_0024120_26___0024Func_0024171.Adapt(AssetServerFinder)))
			{
				RespExtServer respExtServer = array.Where(_0024adaptor_0024__ApiPlatformExtServer_doPostRequestJob_0024callable562_0024120_26___0024Func_0024171.Adapt(AssetServerFinder)).First();
				ServerURL.ASSET_SRV_URL = respExtServer.HostName;
			}
		}
		else
		{
			Status = 500;
		}
	}
}
