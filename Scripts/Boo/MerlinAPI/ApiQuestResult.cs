using System;

namespace MerlinAPI;

[Serializable]
public class ApiQuestResult : RequestBase
{
	[Serializable]
	public class ClearInfoType
	{
		public int Time;

		public bool IsNoDamage;

		public int RemainingHp;

		public bool IsNotAbnormal;

		public int TotalHp;

		public int TotalAtk;
	}

	public string DataKey;

	public bool IsSuccess;

	public int Exp;

	public int Coin;

	public RespSimpleReward[] QuestRewards;

	public RespMonster[] Monsters;

	public ClearInfoType ClearInfo;

	private bool _0024initialized__MerlinAPI_ApiQuestResult_0024;

	public override bool IsOk
	{
		get
		{
			bool num;
			if (!(ResponseObj is GameApiResponseBase gameApiResponseBase))
			{
				num = base.IsOk;
			}
			else
			{
				num = base.IsOk;
				if (num)
				{
					num = gameApiResponseBase.IsOkStatusCode;
				}
			}
			return num;
		}
	}

	public override bool HasValidStatus
	{
		get
		{
			GameApiResponseBase gameApiResponseBase = ResponseObj as GameApiResponseBase;
			bool num = gameApiResponseBase != null;
			if (num)
			{
				num = !string.IsNullOrEmpty(gameApiResponseBase.StatusCode);
			}
			return num;
		}
	}

	public override string ApiPath => "/Quest/Result";

	public override ServerType Server => ServerType.Game;

	public ApiQuestResult()
	{
		if (!_0024initialized__MerlinAPI_ApiQuestResult_0024)
		{
			ClearInfo = new ClearInfoType();
			_0024initialized__MerlinAPI_ApiQuestResult_0024 = true;
		}
		QuestRewards = new RespSimpleReward[0];
		Monsters = new RespMonster[0];
	}

	public ApiQuestResult(RespQuestStart startResponse, bool succ)
	{
		if (!_0024initialized__MerlinAPI_ApiQuestResult_0024)
		{
			ClearInfo = new ClearInfoType();
			_0024initialized__MerlinAPI_ApiQuestResult_0024 = true;
		}
		IsSuccess = succ;
		DataKey = startResponse.DataKey;
		Exp = startResponse.Exp;
		Coin = startResponse.Coin;
		QuestRewards = startResponse.QuestRewards;
		Monsters = startResponse.Monsters;
	}

	public RespQuestResult GetResponse()
	{
		return ResponseObj as RespQuestResult;
	}

	public override Type responseType()
	{
		return typeof(RespQuestResult);
	}

	protected override string adjustDateTime()
	{
		return null;
	}

	public RespReward[] getQuestRewards()
	{
		return RespReward.FromSimpleRewardList(QuestRewards);
	}
}
