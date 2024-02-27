using System;
using MerlinAPI;

[Serializable]
public class RaidPlayInfo : JsonBase
{
	public int useRp;

	public int recommendId;

	public RespPoppet recommendPoppet;

	private string startApiKey;

	private ApiGuildRaidStart.Resp startResponse;

	private string resultApiKey;

	public RaidPlayInfo()
	{
		init();
	}

	private void init()
	{
		useRp = 1;
		int num = 1;
		object obj = null;
		startApiKey = null;
		startResponse = null;
	}

	public ApiGuildRaidStart createStartRequest()
	{
		ApiGuildRaidStart apiGuildRaidStart = new ApiGuildRaidStart();
		apiGuildRaidStart.UseRp = useRp;
		apiGuildRaidStart.RecommendId = recommendId;
		if (string.IsNullOrEmpty(startApiKey))
		{
			startApiKey = apiGuildRaidStart.ApiKey;
		}
		else
		{
			apiGuildRaidStart.ApiKey = startApiKey;
		}
		return apiGuildRaidStart;
	}

	public ApiGuildResult createResultRequest()
	{
		ApiGuildResult apiGuildResult = new ApiGuildResult();
		apiGuildResult.CycleId = startResponse.CycleId;
		apiGuildResult.TicketId = startResponse.TicketId;
		apiGuildResult.Damage = 0;
		apiGuildResult.IsDead = false;
		if (string.IsNullOrEmpty(resultApiKey))
		{
			resultApiKey = apiGuildResult.ApiKey;
		}
		else
		{
			apiGuildResult.ApiKey = resultApiKey;
		}
		return apiGuildResult;
	}
}
