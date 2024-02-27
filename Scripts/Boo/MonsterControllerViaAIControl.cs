using System;
using UnityEngine;

[Serializable]
public class MonsterControllerViaAIControl : MonoBehaviour
{
	public bool defaultIsPlayerSide;

	private AIControl aiControl;

	public void Awake()
	{
		aiControl = gameObject.GetComponent<AIControl>();
		if (!(aiControl != null))
		{
			setPlayerSide(defaultIsPlayerSide);
		}
	}

	public void setPlayerSide(bool isPlayer)
	{
		if (!(aiControl == null))
		{
			aiControl.setPlayerSide(isPlayer);
			defaultIsPlayerSide = isPlayer;
		}
	}

	public void Update()
	{
		if (!(aiControl == null))
		{
		}
	}
}
