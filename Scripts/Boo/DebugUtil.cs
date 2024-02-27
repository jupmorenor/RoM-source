using System;
using UnityEngine;

[Serializable]
public class DebugUtil : MonoBehaviour
{
	public bool checkObjectsEveryFrame;

	public bool outLogAtCheckingObjects;

	[NonSerialized]
	private static DebugUtil instance;

	public DebugUtil()
	{
		checkObjectsEveryFrame = true;
	}

	public void Update()
	{
		CheckAllExistingObjects(outLogAtCheckingObjects);
		if (instance == null)
		{
			instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(this);
		}
	}

	public void OnGUI()
	{
		GUI.Label(new Rect(checked(Screen.width - 20), 10f, 20f, 20f), "D");
	}

	public static void CheckAllExistingObjects(bool logging)
	{
		int i = 0;
		UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeof(UnityEngine.Object));
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (!(array[i] == null))
			{
				string myID = ExtensionsModule.GetMyID(array[i]);
				if (!logging)
				{
				}
			}
		}
	}
}
