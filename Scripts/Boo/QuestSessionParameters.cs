using System;
using System.Text;
using Boo.Lang.Runtime;
using MerlinAPI;

[Serializable]
public class QuestSessionParameters
{
	public bool withServer;

	public int storyId;

	public RespFriendPoppet helper;

	public bool noSceneLoad;

	public bool withSceneFade;

	public bool needEndLogo;

	public bool needResultMode;

	public MScenes debugMScenes;

	public string startApiKey;

	public string lastDataKey;

	public int option;

	public bool WithServer
	{
		get
		{
			bool num = withServer;
			if (num)
			{
				num = debugMScenes == null;
			}
			return num;
		}
	}

	public bool NoSceneLoad
	{
		get
		{
			bool num = noSceneLoad;
			if (num)
			{
				num = debugMScenes == null;
			}
			return num;
		}
	}

	public int StoryId
	{
		get
		{
			int id;
			if (debugMScenes == null)
			{
				id = storyId;
			}
			else
			{
				MQuests mQuestId = debugMScenes.MQuestId;
				if (mQuestId == null)
				{
					id = storyId;
				}
				else
				{
					int num = 0;
					MStories[] all = MStories.All;
					int length = all.Length;
					while (true)
					{
						if (num < length)
						{
							if (RuntimeServices.EqualityOperator(all[num].MQuestId, mQuestId))
							{
								id = all[num].Id;
								break;
							}
							num = checked(num + 1);
							continue;
						}
						id = storyId;
						break;
					}
				}
			}
			return id;
		}
	}

	public QuestSessionParameters()
	{
		withServer = true;
		noSceneLoad = true;
		withSceneFade = true;
		needEndLogo = true;
		needResultMode = true;
		startApiKey = string.Empty;
		lastDataKey = string.Empty;
		clear();
	}

	public void dump(string msg)
	{
		string lhs = new StringBuilder().Append(msg).Append(" QuestSessionParameters:\n").ToString();
		lhs += new StringBuilder("withServer: ").Append(withServer).Append("\n").ToString();
		lhs += new StringBuilder("storyId: ").Append((object)storyId).Append("\n").ToString();
		lhs += new StringBuilder("helper: ").Append(helper).Append("\n").ToString();
		lhs += new StringBuilder("noSceneLoad: ").Append(noSceneLoad).Append("\n").ToString();
		lhs += new StringBuilder("withSceneFade: ").Append(withSceneFade).Append("\n").ToString();
		lhs += new StringBuilder("needEndLogo: ").Append(needEndLogo).Append("\n").ToString();
		lhs += new StringBuilder("needResultMode: ").Append(needResultMode).Append("\n").ToString();
		lhs += new StringBuilder("debugMScenes: ").Append(debugMScenes).Append("\n").ToString();
		lhs += new StringBuilder("startApiKey: ").Append(startApiKey).Append("\n").ToString();
		lhs += new StringBuilder("lastDataKey: ").Append(lastDataKey).Append("\n").ToString();
		lhs += new StringBuilder("option: ").Append((object)option).Append("\n").ToString();
	}

	public ApiQuestStart createStartRequest()
	{
		if (string.IsNullOrEmpty(lastDataKey))
		{
			lastDataKey = ServerUtilModule.GenerateUUID();
		}
		ApiQuestStart apiQuestStart = new ApiQuestStart();
		int num = (apiQuestStart.Id = storyId);
		string text = (apiQuestStart.DataKey = lastDataKey);
		int num2 = (apiQuestStart.RecommendId = helper.SocialId);
		int num3 = (apiQuestStart.Option = option);
		ApiQuestStart apiQuestStart2 = apiQuestStart;
		if (string.IsNullOrEmpty(startApiKey))
		{
			startApiKey = apiQuestStart2.ApiKey;
		}
		else
		{
			apiQuestStart2.ApiKey = startApiKey;
		}
		return apiQuestStart2;
	}

	public override string ToString()
	{
		return new StringBuilder("鯖:").Append(withServer).Append(" MStories id:").Append((object)storyId)
			.Append(" お助け:")
			.Append(helper)
			.Append(" シーンロード:")
			.Append(noSceneLoad)
			.ToString();
	}

	public void clear()
	{
		withServer = true;
		storyId = 0;
		helper = null;
		noSceneLoad = true;
		withSceneFade = true;
		needEndLogo = true;
		needResultMode = true;
		debugMScenes = null;
		startApiKey = string.Empty;
		lastDataKey = string.Empty;
		option = 0;
	}

	public void checkIdentity(QuestSessionParameters o)
	{
		if (o == null)
		{
			throw new AssertionFailedException("not (o == null)");
		}
		if (withServer != o.withServer)
		{
			throw new AssertionFailedException("not (withServer != o.withServer)");
		}
		if (storyId != o.storyId)
		{
			throw new AssertionFailedException("not (storyId != o.storyId)");
		}
		checkIdentity(helper, o.helper);
		if (noSceneLoad != o.noSceneLoad)
		{
			throw new AssertionFailedException("not (noSceneLoad != o.noSceneLoad)");
		}
		if (withSceneFade != o.withSceneFade)
		{
			throw new AssertionFailedException("not (withSceneFade != o.withSceneFade)");
		}
		if (needEndLogo != o.needEndLogo)
		{
			throw new AssertionFailedException("not (needEndLogo != o.needEndLogo)");
		}
		if (needResultMode != o.needResultMode)
		{
			throw new AssertionFailedException("not (needResultMode != o.needResultMode)");
		}
		if (!RuntimeServices.EqualityOperator(debugMScenes, o.debugMScenes))
		{
			throw new AssertionFailedException("not (debugMScenes != o.debugMScenes)");
		}
		if (startApiKey != o.startApiKey)
		{
			throw new AssertionFailedException("not (startApiKey != o.startApiKey)");
		}
		if (lastDataKey != o.lastDataKey)
		{
			throw new AssertionFailedException("not (lastDataKey != o.lastDataKey)");
		}
	}

	private static void checkIdentity(RespFriendPoppet f1, RespFriendPoppet f2)
	{
		if (f1 == null && f2 == null)
		{
			throw new AssertionFailedException("not ((f1 == null) and (f2 == null))");
		}
		if (f1 != null && f2 == null)
		{
			throw new AssertionFailedException("not ((f1 != null) and (f2 == null))");
		}
		if (f1 == null && f2 != null)
		{
			throw new AssertionFailedException("not ((f1 == null) and (f2 != null))");
		}
		if (f1.MPoppetId != f2.MPoppetId)
		{
			throw new AssertionFailedException("not (f1.MPoppetId != f2.MPoppetId)");
		}
		if (f1.AttackBonus != f2.AttackBonus)
		{
			throw new AssertionFailedException("not (f1.AttackBonus != f2.AttackBonus)");
		}
		if (f1.ChainSkillLevel != f2.ChainSkillLevel)
		{
			throw new AssertionFailedException("not (f1.ChainSkillLevel != f2.ChainSkillLevel)");
		}
		if (f1.UserName != f2.UserName)
		{
			throw new AssertionFailedException(new StringBuilder("f1.UserName:").Append(f1.UserName).Append(" f2.UserName:").Append(f2.UserName)
				.ToString());
		}
		if (f1.IsFriend != f2.IsFriend)
		{
			throw new AssertionFailedException("not (f1.IsFriend != f2.IsFriend)");
		}
		if (f1.SocialId != f2.SocialId)
		{
			throw new AssertionFailedException("not (f1.SocialId != f2.SocialId)");
		}
	}
}
