using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NPCStopper
{
	private Dictionary<NPCControl, bool> npcMoveFlags;

	public NPCStopper()
	{
		npcMoveFlags = new Dictionary<NPCControl, bool>();
	}

	public void stop(NPCControl exclude)
	{
		npcMoveFlags.Clear();
		int i = 0;
		NPCControl[] array = (NPCControl[])UnityEngine.Object.FindObjectsOfType(typeof(NPCControl));
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != exclude)
			{
				npcMoveFlags[array[i]] = array[i].StopMove;
				array[i].StopMove = true;
			}
		}
	}

	public void restart()
	{
		int i = 0;
		NPCControl[] array = (NPCControl[])UnityEngine.Object.FindObjectsOfType(typeof(NPCControl));
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (npcMoveFlags.ContainsKey(array[i]))
			{
				array[i].StopMove = npcMoveFlags[array[i]];
			}
		}
		npcMoveFlags.Clear();
	}
}
