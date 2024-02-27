using System;
using System.Text;
using UnityEngine;

[Serializable]
public class EPBattlePoint : AbstractEventPoint
{
	public MStageBattles stageBattle;

	private GameObject popObj;

	public EPBattlePoint(MScenes _scene, MStageBattles _battle)
	{
		scene = _scene;
		stageBattle = _battle;
	}

	public override void initInScene()
	{
		if (QuestMapper.Current != null)
		{
			popObj = QuestMapper.Current.GetPopObject(stageBattle);
		}
	}

	public override bool isReachedAndSatisfied(AutoFlowEnv env)
	{
		return QuestSession.IsMarkedBattle(stageBattle);
	}

	public override Vector3 position()
	{
		return (!(popObj != null)) ? Vector3.zero : popObj.transform.position;
	}

	public override string ToString()
	{
		return new StringBuilder("EPBattlePoint(").Append(scene).Append(" ").Append(stageBattle)
			.Append(") popObj=")
			.ToString() + popObj;
	}
}
