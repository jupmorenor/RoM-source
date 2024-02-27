using UnityEngine;

public class Button : MonoBehaviour
{
	private void OnGUI()
	{
		Rect position = new Rect(10f, 10f, 100f, 50f);
		if (GUI.Button(position, "Change!"))
		{
			if (Application.loadedLevelName == "Scene1")
			{
				Application.LoadLevel("Scene2");
			}
			else
			{
				Application.LoadLevel("Scene1");
			}
		}
	}
}
