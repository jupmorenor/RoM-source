using System;
using UnityEngine;

[Serializable]
public class TestBattleMonsterSeInitializer : MonoBehaviour
{
	public bool mobSeLoad;

	public void Start()
	{
		if (mobSeLoad)
		{
			MobSeLoad();
		}
	}

	public void OnDestroy()
	{
		MobSeUnLoad();
	}

	public void MobSeUnLoad()
	{
		SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
		if ((bool)instance)
		{
			instance.UnloadSeType(6);
			instance.UnloadSeType(7);
		}
	}

	public void MobSeLoad()
	{
		MobSeUnLoad();
		SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
		GameSoundManager instance2 = GameSoundManager.Instance;
		if (!instance || !instance2)
		{
			return;
		}
		instance2.LoadSeGroup("e_common");
		int i = 0;
		AIControl[] array = (AIControl[])UnityEngine.Object.FindObjectsOfType(typeof(AIControl));
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			MMonsters mMonsters = MMonsters.Get(array[i].DebugMonsterMasterId);
			if (mMonsters == null || string.IsNullOrEmpty(mMonsters.SoundID) || instance2.LoadSeGroup(mMonsters.SoundID))
			{
			}
		}
	}

	public void OnGUI()
	{
		if (GUILayout.Button("Reoad Mob SE"))
		{
			MobSeLoad();
		}
	}
}
