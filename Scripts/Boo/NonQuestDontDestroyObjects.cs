using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NonQuestDontDestroyObjects : MonoBehaviour
{
	[NonSerialized]
	private static Dictionary<int, UnityEngine.Object> registrations = new Dictionary<int, UnityEngine.Object>();

	public static Dictionary<int, UnityEngine.Object> Registrations => registrations;

	public static void Entry(UnityEngine.Object obj)
	{
		if (!(obj == null))
		{
			UnityEngine.Object.DontDestroyOnLoad(obj);
			registrations[obj.GetInstanceID()] = obj;
		}
	}

	public static void DestroyAll()
	{
		foreach (UnityEngine.Object value in registrations.Values)
		{
			if (value != null)
			{
				UnityEngine.Object.Destroy(value);
			}
		}
		registrations.Clear();
	}
}
