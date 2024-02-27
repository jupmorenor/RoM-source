using System;
using UnityEngine;

[Serializable]
public class DropDataNut : QuestDropManager.DropData
{
	public override GameObject doInstantiate()
	{
		return QuestAssets.Instance.instantiateStageNut().gameObject;
	}
}
