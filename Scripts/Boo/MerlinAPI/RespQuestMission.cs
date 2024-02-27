using System;

namespace MerlinAPI;

[Serializable]
public class RespQuestMission : JsonBase
{
	public int Id;

	public int MQuestId;

	public int Number;

	public int MissionTypeValue;

	public DateTime BeginDate;

	public DateTime EndDate;

	public int ConditionTypeValue1;

	public int ConditionParameter1;

	public int ConditionTypeValue2;

	public int ConditionParameter2;

	public RespReward[] Rewards;

	public string Detail
	{
		get
		{
			MQuestMissions mQuestMissions = MQuestMissions.Get(Id);
			return (mQuestMissions == null) ? string.Empty : mQuestMissions.Detail;
		}
	}

	public bool HasClearTimeCondition
	{
		get
		{
			bool num = ConditionTypeValue1 == 8;
			if (!num)
			{
				num = ConditionTypeValue2 == 8;
			}
			return num;
		}
	}
}
