using System;
using UnityEngine;

[Serializable]
public class ResetButton : MonoBehaviour
{
	public void OnGUI()
	{
		if (GUI.Button(new Rect(10f, 30f, 100f, 50f), "Battle"))
		{
			Application.LoadLevel("Merlin");
		}
		else if (GUI.Button(new Rect(10f, 90f, 100f, 50f), "Camera"))
		{
			Application.LoadLevel("BGViewer");
		}
		else if (GUI.Button(new Rect(10f, 150f, 100f, 50f), "Raid"))
		{
			Application.LoadLevel("Raid");
		}
	}
}
