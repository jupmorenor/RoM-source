using System;
using UnityEngine;

[Serializable]
public class Ef_VacuumToPlayer : Ef_Base
{
	public float life;

	public float delay;

	public float power;

	public float maxDistance;

	public float minDistance;

	public bool invalidLife;

	private CutSceneManager _cutSceneMan;

	private CutSceneManager cutSceneMan
	{
		get
		{
			CutSceneManager result;
			if ((bool)_cutSceneMan)
			{
				result = _cutSceneMan;
			}
			else
			{
				_cutSceneMan = CutSceneManager.Instance;
				result = _cutSceneMan;
			}
			return result;
		}
	}

	public Ef_VacuumToPlayer()
	{
		life = 4f;
		power = 1f;
		maxDistance = 30f;
		minDistance = 5f;
	}

	public void Update()
	{
		PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
		if (currentPlayer == null || ((bool)cutSceneMan && cutSceneMan.isBusy))
		{
			return;
		}
		if (!(delay <= 0f))
		{
			delay -= deltaTime;
		}
		else if (life > 0f || invalidLife)
		{
			Vector3 vector = transform.position - currentPlayer.transform.position;
			vector.y = 0f;
			float magnitude = vector.magnitude;
			if (!(magnitude > maxDistance) && magnitude >= minDistance)
			{
				vector = vector.normalized * power * deltaTime;
				currentPlayer.addVolatileMovement(vector);
			}
		}
	}

	public Transform FindTarget()
	{
		PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
		return ((bool)currentPlayer && currentPlayer.IsReady) ? currentPlayer.transform : null;
	}
}
