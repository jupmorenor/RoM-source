using System;
using UnityEngine;

[Serializable]
public class Ef_SetLayerFromEmitter : MonoBehaviour
{
	public GameObject layerObj;

	public string playerLayer;

	public string enemyLayer;

	public string playerTag;

	public string enemyTag;

	public Ef_SetLayerFromEmitter()
	{
		playerLayer = "PlayerAttackColi";
		enemyLayer = "EnemyAttackColi";
		playerTag = string.Empty;
		enemyTag = string.Empty;
	}

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		if (emtr == null)
		{
			return;
		}
		if (!layerObj)
		{
			layerObj = gameObject;
		}
		if (emtr.IsSidePlayer)
		{
			layerObj.layer = LayerMask.NameToLayer(playerLayer);
			if (playerTag.Length > 0)
			{
				layerObj.tag = playerTag;
			}
		}
		else if (emtr.IsSideEnemy)
		{
			layerObj.layer = LayerMask.NameToLayer(enemyLayer);
			if (enemyTag.Length > 0)
			{
				layerObj.tag = enemyTag;
			}
		}
	}
}
