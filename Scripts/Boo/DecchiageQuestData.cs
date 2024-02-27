using System;
using System.Collections.Generic;
using Boo.Lang.Runtime;
using MerlinAPI;

[Serializable]
public class DecchiageQuestData
{
	public bool IsSuccess;

	public int Exp;

	public int Coin;

	public RespReward[] QuestRewards;

	public RespMonster[] Monsters;

	public RespFriend Fellow;

	public MQuests quest;

	public MScenes[] stages;

	public Dictionary<int, MStageBattles> battle;

	public MScenes currentScene;

	public DecchiageQuestData()
	{
		battle = new Dictionary<int, MStageBattles>();
	}

	public void start(int storyId)
	{
		IsSuccess = false;
		Exp = 1;
		Coin = 10;
		QuestRewards = new RespReward[0];
		MStories mStories = MStories.Get(storyId);
		if (mStories == null)
		{
			throw new AssertionFailedException("mstory != null");
		}
		MQuests mQuestId = mStories.MQuestId;
		if (mQuestId == null)
		{
			throw new AssertionFailedException("mquest != null");
		}
		MScenes[] all = MScenes.All;
		int i = 0;
		MScenes[] array = all;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if (array[i] == null)
				{
					throw new AssertionFailedException("s != null");
				}
				int j = 0;
				MStageBattles[] allStageBattles = array[i].AllStageBattles;
				for (int length2 = allStageBattles.Length; j < length2; j++)
				{
					battle[array[i].Id] = allStageBattles[j];
					int k = 0;
					MStageMonsters[] allStageMonsters = allStageBattles[j].AllStageMonsters;
					for (int length3 = allStageMonsters.Length; k < length3; k++)
					{
						allStageMonsters[k].setField("MStageId", array[i].Id);
					}
				}
			}
			currentScene = mQuestId.StartSceneId;
			if (currentScene == null)
			{
				throw new AssertionFailedException("currentScene != null");
			}
		}
	}

	public MScenes gotoStage(string dirStr)
	{
		try
		{
			EnumMapLinkDir dir = (EnumMapLinkDir)Enum.Parse(typeof(EnumMapLinkDir), dirStr);
			return gotoStage(dir);
		}
		catch (Exception)
		{
			return null;
		}
	}

	public MScenes gotoStage(EnumMapLinkDir dir)
	{
		if (currentScene == null)
		{
			throw new AssertionFailedException("currentScene != null");
		}
		return currentScene.linkTo(dir);
	}

	public void success()
	{
	}
}
