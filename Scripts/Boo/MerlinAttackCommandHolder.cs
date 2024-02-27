using System;
using UnityEngine;

[Serializable]
public class MerlinAttackCommandHolder : MonoBehaviour
{
	private ActionCommandAttack command;

	public ActionCommandAttack Command
	{
		get
		{
			return command;
		}
		set
		{
			command = value;
		}
	}
}
