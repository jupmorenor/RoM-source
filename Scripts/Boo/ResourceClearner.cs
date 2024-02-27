using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class ResourceClearner : MonoBehaviour
{
	public static void CleanUpForQuest()
	{
		CleanUpWorldmaps();
	}

	public static void CleanUpForTown()
	{
		CleanUpWorldmaps();
	}

	private static void CleanUpWorldmaps()
	{
		CleanUpMaterials("WorldMap");
		CleanUpTextures("worldmap");
	}

	private static void CleanUpMaterials(params string[] ns)
	{
		int i = 0;
		Material[] array = Resources.FindObjectsOfTypeAll<Material>();
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null && RuntimeServices.op_Member(array[i].name, ns))
			{
				Resources.UnloadAsset(array[i]);
			}
		}
	}

	private static void CleanUpTextures(params string[] ns)
	{
		int i = 0;
		Texture[] array = Resources.FindObjectsOfTypeAll<Texture>();
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null && RuntimeServices.op_Member(array[i].name, ns))
			{
				Resources.UnloadAsset(array[i]);
			}
		}
	}
}
