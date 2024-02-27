using System;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;

[Serializable]
public class QuestSessionData
{
	public bool finStartCommunication;

	public RespQuestStart startResponse;

	public RespMonster[] monsterData;

	public Boo.Lang.List<MScenes> visitedScenes;

	public Dictionary<MStageBattles, RespMonster[]> monsterMap;

	public HashSet<MStageBattles> existBattles;

	public QuestDropManager stageDropManager;

	public int keyItemPoint;

	public MScenes currentScene;

	public HashSet<MStageBattles> markedBattles;

	public MScenes[] allScenes;

	public QuestBattleSessionData battleSession;

	public bool playedOpeningCutScene;

	public bool ended;

	public int endStatus;

	public string endCommunicationApiKey;

	public QuestBattleStatistics questBattleStatistics;

	[NonSerialized]
	public const int END_STATUS_SUCCEEDED = 0;

	[NonSerialized]
	public const int END_STATUS_FAILED = 1;

	[NonSerialized]
	public const int END_STATUS_TIMEOVER = 2;

	public bool EndedSucceeded => endStatus == 0;

	public RespMonster[] AllQuestMonsters
	{
		get
		{
			Boo.Lang.List<RespMonster> list = new Boo.Lang.List<RespMonster>();
			foreach (RespMonster[] value in monsterMap.Values)
			{
				RespMonster[] array = value;
				int length = array.Length;
				int num = 0;
				while (num < length)
				{
					RespMonster respMonster = array[RuntimeServices.NormalizeArrayIndex(array, checked(num++))];
					if (respMonster != null)
					{
						list.Add(respMonster);
					}
				}
			}
			return (RespMonster[])Builtins.array(typeof(RespMonster), list);
		}
	}

	public int EarnedCoin
	{
		get
		{
			int num = 0;
			int i = 0;
			RespMonster[] allQuestMonsters = AllQuestMonsters;
			checked
			{
				for (int length = allQuestMonsters.Length; i < length; i++)
				{
					if (allQuestMonsters[i].IsKill)
					{
						num += allQuestMonsters[i].Coin + allQuestMonsters[i].RewardCoinTotal;
					}
				}
				return num;
			}
		}
	}

	public int EarnedDummyCoin
	{
		get
		{
			int num = 0;
			int i = 0;
			RespMonster[] allQuestMonsters = AllQuestMonsters;
			checked
			{
				for (int length = allQuestMonsters.Length; i < length; i++)
				{
					if (allQuestMonsters[i].IsKill && allQuestMonsters[i].StageMonsterMaster != null)
					{
						num += allQuestMonsters[i].StageMonsterMaster.DummyCoin;
					}
				}
				return num;
			}
		}
	}

	public int EarnedTreasureNum
	{
		get
		{
			int num = 0;
			int i = 0;
			RespMonster[] allQuestMonsters = AllQuestMonsters;
			checked
			{
				for (int length = allQuestMonsters.Length; i < length; i++)
				{
					if (allQuestMonsters[i].IsKill)
					{
						num += allQuestMonsters[i].RewardTreasureBoxedDrops.Length;
					}
				}
				return num;
			}
		}
	}

	public int EarnedDummyTreasureNum
	{
		get
		{
			int num = 0;
			int i = 0;
			RespMonster[] allQuestMonsters = AllQuestMonsters;
			checked
			{
				for (int length = allQuestMonsters.Length; i < length; i++)
				{
					if (allQuestMonsters[i].IsKill && allQuestMonsters[i].StageMonsterMaster != null && allQuestMonsters[i].StageMonsterMaster.DummyDropLevel > 0)
					{
						num++;
					}
				}
				return num;
			}
		}
	}

	public QuestSessionData()
	{
		monsterData = new RespMonster[0];
		visitedScenes = new Boo.Lang.List<MScenes>();
		monsterMap = new Dictionary<MStageBattles, RespMonster[]>();
		existBattles = new HashSet<MStageBattles>();
		stageDropManager = new QuestDropManager();
		markedBattles = new HashSet<MStageBattles>();
		allScenes = new MScenes[0];
		battleSession = new QuestBattleSessionData();
		endCommunicationApiKey = string.Empty;
		clear();
	}

	public void clear()
	{
		monsterData = new RespMonster[0];
		allScenes = new MScenes[0];
		visitedScenes = new Boo.Lang.List<MScenes>();
		monsterMap = new Dictionary<MStageBattles, RespMonster[]>();
		existBattles = new HashSet<MStageBattles>();
		stageDropManager = new QuestDropManager();
		keyItemPoint = 0;
		currentScene = null;
		markedBattles = new HashSet<MStageBattles>();
		startResponse = null;
		finStartCommunication = false;
		battleSession.clear();
		playedOpeningCutScene = false;
		ended = false;
		endStatus = 0;
		endCommunicationApiKey = string.Empty;
	}

	public void setStartResponse(RespQuestStart resp)
	{
		if (resp == null)
		{
			throw new AssertionFailedException("resp != null");
		}
		startResponse = resp;
		monsterData = resp.Monsters;
	}

	public void setStartRequestNoServer(RespMonster[] _monsterData)
	{
		if (_monsterData == null)
		{
			throw new AssertionFailedException("_monsterData != null");
		}
		startResponse = null;
		monsterData = _monsterData;
	}

	public void eachMonster(__QuestSessionData_eachMonster_0024callable81_0024164_34__ c)
	{
		if (c == null)
		{
			return;
		}
		foreach (RespMonster[] value in monsterMap.Values)
		{
			RespMonster[] array = value;
			int length = array.Length;
			int num = 0;
			while (num < length)
			{
				RespMonster respMonster = array[RuntimeServices.NormalizeArrayIndex(array, checked(num++))];
				if (respMonster != null)
				{
					c(respMonster);
				}
			}
		}
	}

	public RespMonster findMonster(__QuestSessionData_findMonster_0024callable82_0024170_37__ pred)
	{
		RespMonster respMonster2;
		foreach (RespMonster[] value in monsterMap.Values)
		{
			RespMonster[] array = value;
			int length = array.Length;
			int num = 0;
			while (num < length)
			{
				RespMonster respMonster = array[RuntimeServices.NormalizeArrayIndex(array, checked(num++))];
				if (respMonster == null || !pred(respMonster))
				{
					continue;
				}
				respMonster2 = respMonster;
				goto IL_0089;
			}
		}
		object result = null;
		goto IL_008b;
		IL_0089:
		result = respMonster2;
		goto IL_008b;
		IL_008b:
		return (RespMonster)result;
	}

	public ApiQuestResult createEndRequest(RespQuestStart startResponse, bool succ)
	{
		ApiQuestResult result;
		if (startResponse == null)
		{
			result = new ApiQuestResult();
		}
		else
		{
			ApiQuestResult apiQuestResult = new ApiQuestResult(startResponse, succ);
			if (string.IsNullOrEmpty(endCommunicationApiKey))
			{
				endCommunicationApiKey = apiQuestResult.ApiKey;
			}
			else
			{
				apiQuestResult.ApiKey = endCommunicationApiKey;
			}
			setClearInfoParameters(apiQuestResult);
			result = apiQuestResult;
		}
		return result;
	}

	private void setClearInfoParameters(ApiQuestResult req)
	{
		checked
		{
			req.ClearInfo.Time = (int)QuestEventHandler.PlayerCurrentPlayTime;
			req.ClearInfo.IsNoDamage = QuestEventHandler.PlayerDamageCount <= 0;
			req.ClearInfo.RemainingHp = (int)QuestEventHandler.PlayerLastHP;
			req.ClearInfo.IsNotAbnormal = QuestEventHandler.PlayerAbnormalStateCount <= 0;
			req.ClearInfo.TotalAtk = (int)QuestEventHandler.PlayerTotalAttack;
			req.ClearInfo.TotalHp = (int)QuestEventHandler.PlayerTotalHP;
		}
	}

	public void dump(string title)
	{
		string empty = string.Empty;
		empty += new StringBuilder("finStartCommunication: ").Append(finStartCommunication).Append("\n").ToString();
		empty += new StringBuilder("monsterData: ").Append(monsterData).Append("\n").ToString();
		empty += new StringBuilder("allScenes: ").Append(allScenes).Append("\n").ToString();
		empty += new StringBuilder("visitedScenes: ").Append(visitedScenes).Append("\n").ToString();
		empty += new StringBuilder("monsterMap: ").Append(monsterMap).Append("\n").ToString();
		empty += new StringBuilder("existBattles: ").Append(existBattles).Append("\n").ToString();
		empty += new StringBuilder("stageDropManager: ").Append(stageDropManager).Append("\n").ToString();
		empty += new StringBuilder("keyItemPoint: ").Append((object)keyItemPoint).Append("\n").ToString();
		empty += new StringBuilder("currentScene: ").Append(currentScene).Append("\n").ToString();
		empty += new StringBuilder("markedBattles: ").Append(markedBattles).Append("\n").ToString();
		empty += new StringBuilder("startResponse: ").Append(startResponse).Append("\n").ToString();
		empty += new StringBuilder("playedOpeningCutScene: ").Append(playedOpeningCutScene).Append("\n").ToString();
		empty += new StringBuilder("ended: ").Append(ended).Append("\n").ToString();
		empty += new StringBuilder("endStatus: ").Append((object)endStatus).Append("\n").ToString();
		empty += new StringBuilder("endCommunicationApiKey: ").Append(endCommunicationApiKey).Append("\n").ToString();
	}
}
