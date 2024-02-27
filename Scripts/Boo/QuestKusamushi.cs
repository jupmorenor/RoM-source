using System;
using System.Collections;
using Boo.Lang.Runtime;

[Serializable]
public class QuestKusamushi : DropBase
{
	protected override void doPickMeUp(PlayerControl p)
	{
		int totalKusamushiNum = QuestSession.TotalKusamushiNum;
		int pickedKusamushiNum = QuestSession.PickedKusamushiNum;
		if (((ICollection)StageDrops).Count != 1 || !(StageDrops[0] is DropDataKusamushi))
		{
			throw new AssertionFailedException("(len(StageDrops) == 1) and (StageDrops[0] isa DropDataKusamushi)");
		}
		if (!(StageDrops[0] is DropDataKusamushi { Master: not null } dropDataKusamushi))
		{
			throw new AssertionFailedException("(d != null) and (d.Master != null)");
		}
		BattleHUDQuestCondition.dispKusamushi(dropDataKusamushi.Master.Progname, pickedKusamushiNum, totalKusamushiNum);
	}
}
