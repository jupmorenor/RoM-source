using System;

[Serializable]
public class MQuestsUtil
{
	public static bool MustPlayStartCutScene(MQuests qmst)
	{
		int num;
		if (!qmst.HasStartCutScene)
		{
			num = 0;
		}
		else if (qmst.HasStartCutSceneCondition)
		{
			GameLevelManager instance = GameLevelManager.Instance;
			bool flag = GameLevelManager.CheckCondition(qmst.StartCutScenePlayCond, notFlag: false);
			bool flag2 = GameLevelManager.CheckCondition(qmst.StartCutScenePlayNotCond, notFlag: true);
			num = (flag ? 1 : 0);
			if (num == 0)
			{
				num = (flag2 ? 1 : 0);
			}
		}
		else
		{
			num = 1;
		}
		return (byte)num != 0;
	}
}
