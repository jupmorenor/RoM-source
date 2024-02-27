using System;
using UnityEngine;

[Serializable]
public class DropDataCandy : QuestDropManager.DropData
{
	public override GameObject doInstantiate()
	{
		return QuestAssets.Instance.instantiateStageCandy().gameObject;
	}
}
